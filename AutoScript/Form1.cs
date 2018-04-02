using AutoScript.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScript
{

    public partial class MainForm : Form
    {
        /// <summary>
        /// Класс для отдельного скрипта,
        /// который необходимо выполнить на 
        /// определенном сервере и БД
        /// </summary>
        private class Script
        {
            public string SQL { get; set; }
            public string Ifns { get; set; }
            public string Server { get; set; }
            public string Database { get; set; }
            public string FileNameScript { get; set; }
            public ListViewItem Tag { get; set; }
        }

        private int _countFinishThread = 0;
        private int _countThread = 0;
        private int _countErrorInterval = 1;
        private int _countErrorIntervalMin = 10;

        // статусы результатов (изображения)
        const byte IMAGE_STATUS_ERROR = 0; 
        const byte IMAGE_STATUS_WARNING = 1;
        const byte IMAGE_STATUS_SUCCESS = 2;
        const byte IMAGE_STATUS_PROCESS = 3;
        const byte IMAGE_STATUS_STOP = 4;


        /// <summary>
        ///  Количество работающих потоков
        /// </summary>
        public int countFinishThread
        {
            get
            {
                return _countFinishThread;
            }
            set
            {
                _countFinishThread = value;
                // progress bar
                if (progressBar1.Maximum <= value)
                    progressBar1.Value = value;
                // количество статусов
                labelResult.Text = "Потоков: " + value.ToString() + " из " + _countThread.ToString();

                // Если последний потоко завершил работу
                if (_countThread == value)
                {
                    progressBar1.Value = 0;
                    labelResult.Text = "Задание выполнено!";
                }
            }
        }
        
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            loadIfns();
            loadScripts();
        }

        /// <summary>
        /// Кнопка запуска выполнения скриптов 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            
            // для возможности передавать данные в контрол на форме из потока
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            
            countFinishThread = 0;
            if (numericUpDownIntervalCount.Value >= 1)
            {
                _countErrorInterval = (int)numericUpDownIntervalCount.Value;
            }
            if (numericUpDownIntervalMin.Value >= 1)
            {
                _countErrorIntervalMin = (int)numericUpDownIntervalMin.Value;
            }

            // расчет количества создаваемых потоков
            int allChecked = listViewIfns.Items.OfType<ListViewItem>().Where(item => item.Checked == true).Count() *
                listViewScripts.Items.OfType<ListViewItem>().Where(item => item.Checked == true).Count();
            if (allChecked == 0)
            {
                MessageBox.Show("Необходимо выбрать инспекцию и скрипт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;                
            }
            progressBar1.Maximum = _countThread = allChecked;
            buttonStart.Enabled = false;

            // переход на другую вкладку, где выполняется поиск
            tabControl1.SelectedIndex = 1;

            // очистка списка с результатом (в случае, если уже ранее был запуск)
            listViewResult.Items.Clear();

            // запуск выполнения скриптов
            foreach (ListViewItem itemIfns in listViewIfns.Items.OfType<ListViewItem>().Where(item => item.Checked == true))
            {
                foreach (ListViewItem itemScripts in listViewScripts.Items.OfType<ListViewItem>().Where(item => item.Checked == true))
                {
                    
                    // создание строки в списке с результатами
                    ListViewItem item = listViewResult.Items.Add(itemIfns.Text);
                    item.SubItems.Add(Path.GetFileName(itemScripts.Text));
                    item.SubItems.Add("");
                    
                    // проверка файла
                    if (File.Exists(itemScripts.Text))
                    {
                        Script script = new Script();
                        script.Ifns = itemIfns.Text;
                        script.Server = itemIfns.SubItems[1].Text;
                        script.Database = itemIfns.SubItems[2].Text;
                        script.SQL = File.ReadAllText(itemScripts.Text);
                        script.FileNameScript = itemScripts.Text;
                        script.Tag = item;

                        // запуск потока
                        ThreadPool.QueueUserWorkItem(runThread, script);
                    }
                    else
                    {
                        item.ImageIndex = 0; // error
                        item.SubItems[2].Text = "Файл \"" + itemScripts.Text + "\" не найден!";
                        countFinishThread++;
                    }
                }

            }
            buttonStart.Enabled = true;
        }

        
        /// <summary>
        /// Запись лога
        /// </summary>
        /// <param name="str">строка</param>
        private void log(string str)
        {
            try
            {
                saveLogFile(str);
                listBoxLog.Items.Add(str);
                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            }
            catch { }
        }

        private void saveLogFile(string str)
        {
            string fileLog = AppDomain.CurrentDomain.BaseDirectory + "\\Log_" + DateTime.Today.ToShortDateString() + ".log";
            StreamWriter f = new StreamWriter(fileLog, true);
            f.WriteLine(str);
            f.Close();
        }


        /// <summary>
        /// Запуск потока
        /// </summary>
        /// <param name="script"></param>
        private void runThread(object script)
        {
            // проверка принадлежности объекта script к классу Script
            Script scriptCurrent = script as Script;
            if (scriptCurrent == null)
            { 
                log("Объект script не является классом Script");
                return;
            }

            // флаг, для возможности повторного выполнения SQL, в случае возникновения ошибок
            bool flagErrorSQL = false;

            // выполнение скрипта, в случае успешного выполнения 
            for (int i = 0; i < _countErrorInterval; i++)
            {
                                  
                try
                {
                    setStatusListResult(scriptCurrent.Tag, "Выполняется....", IMAGE_STATUS_PROCESS);

                    // Получение имени файла для сохранения
                    string outputFile = resultFile(scriptCurrent.Ifns, scriptCurrent.FileNameScript);
                        
                    // Инициализация MS Excel
                    IExport csv = new ExportCSV(outputFile);
                    csv.initialize();
                    csv.useQuotes = checkBoxQuote.Checked;
                        
                    // MS SQL запуск
                    SQL sqlModel = new SQL("Data Source=" + scriptCurrent.Server + ";Initial Catalog=" + scriptCurrent.Database + ";Integrated Security=SSPI;");
                    if (sqlModel.RunSQL(scriptCurrent.SQL, csv))
                    {
                        if (!csv.export())
                        {
                            log("Не удалось выполнить экспорт в Excel " + scriptCurrent.Ifns + " / " 
                                + scriptCurrent.FileNameScript + " / " + csv.getLastError.Message + " / " 
                                + csv.getLastError.StackTrace);
                            throw new Exception("Не удалось выполнить экспорт в Excel. " + csv.getLastError.Message);
                        }
                        else
                        {
                            log("Выполнен экспорт " + scriptCurrent.Ifns + " в " + outputFile);
                        }
                    }
                    else
                    {
                        log("Не удалось выполнить скрипт " + scriptCurrent.Ifns + " / "
                            + scriptCurrent.FileNameScript + " / " + sqlModel.lastError.Message);
                        flagErrorSQL = true; // только, если ошибка подключения или выполнения
                        throw new Exception("Не удалось выполнить скрипт. " + sqlModel.lastError.Message);
                    }                        
                }
                catch (Exception ex)
                {
                    log(ex.Message);                        
                    setStatusListResult(scriptCurrent.Tag, ex.Message, IMAGE_STATUS_ERROR);
                }
                
                
                if (flagErrorSQL)
                {
                    if (i < _countErrorInterval - 1) // если еще есть попытки
                    {
                        setStatusListResult(scriptCurrent.Tag, null, IMAGE_STATUS_WARNING);
                        Thread.Sleep(_countErrorIntervalMin * 60 * 1000);
                    }
                    else // если больше попыток нет
                    {
                        setStatusListResult(scriptCurrent.Tag, null, IMAGE_STATUS_STOP);
                    }
                }
                else
                {
                    setStatusListResult(scriptCurrent.Tag, "Завершено", IMAGE_STATUS_SUCCESS);
                    break;
                }
            }

            countFinishThread++;
        }

        /// <summary>
        /// Установка статуса в списке выполнения заданий
        /// </summary>
        /// <param name="item">Ссылка на строчку в списке</param>
        /// <param name="textStatus">Текст статуса</param>
        /// <param name="status">Номер статуса</param>
        private void setStatusListResult(ListViewItem item, string textStatus, byte status)
        {
            if (item.SubItems.Count >= 2)
            {
                if (textStatus != null)
                    item.SubItems[2].Text = textStatus;

                item.ImageIndex = status;
            }
        }

        /// <summary>
        /// Проверка и создания каталога для сохранения результата
        /// и генерация имени файла
        /// </summary>
        /// <param name="ifns">Код ифнс</param>
        /// <param name="scriptName">Имя скрипта</param>
        /// <returns>Полный путь к файлу с резульататми</returns>
        private string resultFile(string ifns, string scriptName)
        {
            scriptName = Path.GetFileNameWithoutExtension(scriptName);
            
            string outputDir = AppDomain.CurrentDomain.BaseDirectory;
            if (outputDir[outputDir.Length - 1] != '\\')
                outputDir += '\\';
            outputDir += "output\\" + DateTime.Today.ToShortDateString() + "\\" + scriptName + "\\";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);            
            return outputDir + ifns + ".csv";
        }

      

        /// <summary>
        /// Загрузка информации о подключениях из файла Ifns.txt
        /// </summary>
        private void loadIfns()
        {
            // Определение текущего каталога, добавление имени файла
            // и проверка существования файла
            string fileIfns = AppDomain.CurrentDomain.BaseDirectory;
            if (fileIfns[fileIfns.Length-1] != '\\')
                fileIfns += "\\";
            fileIfns += "Ifns.txt";

            if (!File.Exists(fileIfns))
            {
                MessageBox.Show("Файл Ifns.txt не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // чтение файла со списком инспекций
            string[] fileRow = File.ReadAllLines(fileIfns);

            // перебор всех строк в файле
            foreach (string row in fileRow)
            {
                // если строка=0, то переход к следующей строке
                if (row.Trim().Length == 0)
                    continue;
                // если первый символ # (комментарий), то переход к следующей строке
                if (row.Trim()[0] == '#')
                    continue;

                // парсинг строки (извлечение кода, сервера и имя бд)
                string[] rowSplit = row.Split('|');
                
                if (rowSplit.Length < 3)
                    continue;

                listViewIfns.Items.Add(new ListViewItem(rowSplit));                
            }

            listViewIfns.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);            
        }

        /// <summary>
        /// Загрузка списка скриптов
        /// </summary>
        private void loadScripts()
        {
            // Определение текущего каталога, добавление имени каталога Script
            // и проверка его существования
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            if (currentDir[currentDir.Length - 1] != '\\')
                currentDir += "\\";
            currentDir += "Scripts";

            // Если нет такого каталога, то создаем
            if (!Directory.Exists(currentDir))
            {
                Directory.CreateDirectory(currentDir);               
                return;
            }

            // поиск файлов *.sql и добавление в список
            string[] filesScript = Directory.GetFiles(currentDir, "*.sql", SearchOption.TopDirectoryOnly);
            foreach (string fileScript in filesScript)
            {
                listViewScripts.Items.Add(new ListViewItem{ Text = fileScript });
            }

            listViewScripts.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
            
        }

        /// <summary>
        /// Установить на всех элементах галочки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuIfnsCheckAll_Click(object sender, EventArgs e)
        {
            ListView control = getControl(sender);
            if (control != null)
                control.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
        }

        /// <summary>
        /// Убрать на всех элементах галочки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuIfnsUncheckAll_Click(object sender, EventArgs e)
        {
            ListView control = getControl(sender);
            if (control != null)
                control.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = false);
        }

        /// <summary>
        /// Инвертировать на всех элементах галочки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuIfnsInverse_Click(object sender, EventArgs e)
        {
            ListView control = getControl(sender);
            if (control != null)
                control.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = !item.Checked);
        }

        /// <summary>
        /// Хэлпер для захвата LitsView
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private ListView getControl(object sender)
        {
            ToolStripItem toolStripItem = sender as ToolStripItem;
            if (toolStripItem != null)
            {
                ContextMenuStrip contextStripMenu = toolStripItem.Owner as ContextMenuStrip;
                if (contextStripMenu != null)
                {
                    return contextStripMenu.SourceControl as ListView; 
                }
            }
            return null;
        }


        /// <summary>
        /// Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            // переход на главную вкладку
            tabControl1.SelectedIndex = 0;
        }

        
       
    }
}
