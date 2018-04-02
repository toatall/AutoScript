using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScript.Model
{

    /// <summary>
    /// Экспорт в csv формат
    /// </summary>
    class ExportCSV: IExport
    {
        // имя файла csv
        private string _fileSave;        
        // сведение о последнем исключении
        private Exception _lastError;
        // заголовки (наименования столбцов)
        private List<Header> _headers;
        // данные
        private List<string> _fileData = new List<string>();
        // использование ковычек для текстовых значений
        private bool _useQuotes = false;
        // разделитель
        private const string SEPARATOR = ";"; 

        /// <summary>
        /// Использование ковычек для текстовых значений
        /// </summary>
        public bool useQuotes
        {
            get
            {
                return _useQuotes;
            }
            set
            {
                _useQuotes = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fileSave"></param>
        public ExportCSV(string fileSave)
        {
            _fileSave = fileSave;
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        /// <returns></returns>
        public bool initialize()
        {
            return true;
        }

        /// <summary>
        /// Передача заголовков
        /// </summary>
        /// <param name="headers">Список заголовков</param>
        /// <returns>bool</returns>
        public bool setHeaders(List<Header> headers)
        {

            _headers = headers;
            return true;

        }

        /// <summary>
        /// Передача строки
        /// </summary>
        /// <param name="row">Список значений строки</param>
        /// <returns>bool</returns>
        public bool nextRow(List<string> row)
        {
            try
            {
                _fileData.Add(convertToString(row));
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Получение последнего исключения
        /// </summary>
        public Exception getLastError
        {
            get
            {
                return _lastError;
            }
        }

        /// <summary>
        /// Экспорт в файл csv
        /// </summary>
        /// <returns>bool</returns>
        public bool export()
        {
            try
            {
                // создание файла для сохранения
                // сохранение в файл
                List<string> ResultFileData = new List<string>();
                
                // header
                string[] d = _headers.Select(x => x.text).ToArray();
                ResultFileData.Add(string.Join(SEPARATOR, d));

                ResultFileData.AddRange(_fileData);                

                File.WriteAllLines(_fileSave, ResultFileData.ToArray(), Encoding.UTF8);

                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex;
                return false;
            }
        }

        /// <summary>
        /// Преобразование из списка значений в строку
        /// </summary>
        /// <param name="line">Список занчений</param>
        /// <returns>string</returns>
        private string convertToString(List<string> line)
        {

            if (_useQuotes)
            {
                if (line.Count == _headers.Count)
                {
                    for (int i = 0; i < line.Count; i++)
                    {
                        if (_headers[i].isText)
                        {
                            line[i] = "=\"" + line[i] + "\"";
                        }
                    }
                }
            }
            return string.Join(SEPARATOR, line.ToArray());
        }
    }
}
