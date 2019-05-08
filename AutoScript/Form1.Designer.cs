namespace AutoScript
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStripIfns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuIfnsCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIfnsUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIfnsInverse = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelInterval = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelShedule = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBoxShedule = new System.Windows.Forms.CheckBox();
            this.checkBoxQuote = new System.Windows.Forms.CheckBox();
            this.numericUpDownIntervalMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownIntervalCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelButton1 = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.listViewScripts = new System.Windows.Forms.ListView();
            this.columnScript1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewIfns = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.timerShedule = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripIfns.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelInterval.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalCount)).BeginInit();
            this.panelButton1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripIfns
            // 
            this.contextMenuStripIfns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIfnsCheckAll,
            this.menuIfnsUncheckAll,
            this.menuIfnsInverse});
            this.contextMenuStripIfns.Name = "contextMenuStripIfns";
            this.contextMenuStripIfns.Size = new System.Drawing.Size(194, 70);
            // 
            // menuIfnsCheckAll
            // 
            this.menuIfnsCheckAll.Name = "menuIfnsCheckAll";
            this.menuIfnsCheckAll.Size = new System.Drawing.Size(193, 22);
            this.menuIfnsCheckAll.Text = "Выбрать все";
            this.menuIfnsCheckAll.Click += new System.EventHandler(this.menuIfnsCheckAll_Click);
            // 
            // menuIfnsUncheckAll
            // 
            this.menuIfnsUncheckAll.Name = "menuIfnsUncheckAll";
            this.menuIfnsUncheckAll.Size = new System.Drawing.Size(193, 22);
            this.menuIfnsUncheckAll.Text = "Отменить выбор всех";
            this.menuIfnsUncheckAll.Click += new System.EventHandler(this.menuIfnsUncheckAll_Click);
            // 
            // menuIfnsInverse
            // 
            this.menuIfnsInverse.Name = "menuIfnsInverse";
            this.menuIfnsInverse.Size = new System.Drawing.Size(193, 22);
            this.menuIfnsInverse.Text = "Инвертировать";
            this.menuIfnsInverse.Click += new System.EventHandler(this.menuIfnsInverse_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(530, 611);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewScripts);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.listViewIfns);
            this.tabPage1.Controls.Add(this.panelInterval);
            this.tabPage1.Controls.Add(this.panelButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(522, 585);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Параметры";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelInterval
            // 
            this.panelInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInterval.Controls.Add(this.groupBox1);
            this.panelInterval.Controls.Add(this.checkBoxQuote);
            this.panelInterval.Controls.Add(this.numericUpDownIntervalMin);
            this.panelInterval.Controls.Add(this.label2);
            this.panelInterval.Controls.Add(this.numericUpDownIntervalCount);
            this.panelInterval.Controls.Add(this.label1);
            this.panelInterval.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInterval.Location = new System.Drawing.Point(3, 411);
            this.panelInterval.Name = "panelInterval";
            this.panelInterval.Size = new System.Drawing.Size(516, 124);
            this.panelInterval.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelShedule);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.checkBoxShedule);
            this.groupBox1.Location = new System.Drawing.Point(267, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отложить запуск";
            // 
            // labelShedule
            // 
            this.labelShedule.AutoSize = true;
            this.labelShedule.Location = new System.Drawing.Point(15, 68);
            this.labelShedule.Name = "labelShedule";
            this.labelShedule.Size = new System.Drawing.Size(10, 13);
            this.labelShedule.TabIndex = 9;
            this.labelShedule.Text = "-";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(155, 41);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(75, 20);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // checkBoxShedule
            // 
            this.checkBoxShedule.AutoSize = true;
            this.checkBoxShedule.Location = new System.Drawing.Point(15, 22);
            this.checkBoxShedule.Name = "checkBoxShedule";
            this.checkBoxShedule.Size = new System.Drawing.Size(75, 17);
            this.checkBoxShedule.TabIndex = 6;
            this.checkBoxShedule.Text = "Включить";
            this.checkBoxShedule.UseVisualStyleBackColor = true;
            this.checkBoxShedule.CheckedChanged += new System.EventHandler(this.checkBoxShedule_CheckedChanged);
            // 
            // checkBoxQuote
            // 
            this.checkBoxQuote.AutoSize = true;
            this.checkBoxQuote.Location = new System.Drawing.Point(20, 60);
            this.checkBoxQuote.Name = "checkBoxQuote";
            this.checkBoxQuote.Size = new System.Drawing.Size(225, 17);
            this.checkBoxQuote.TabIndex = 4;
            this.checkBoxQuote.Text = "Добавлять ковычки в текстовых полях";
            this.checkBoxQuote.UseVisualStyleBackColor = true;
            // 
            // numericUpDownIntervalMin
            // 
            this.numericUpDownIntervalMin.Location = new System.Drawing.Point(202, 34);
            this.numericUpDownIntervalMin.Name = "numericUpDownIntervalMin";
            this.numericUpDownIntervalMin.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownIntervalMin.TabIndex = 3;
            this.numericUpDownIntervalMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Интервал между попытками (мин)";
            // 
            // numericUpDownIntervalCount
            // 
            this.numericUpDownIntervalCount.Location = new System.Drawing.Point(135, 8);
            this.numericUpDownIntervalCount.Name = "numericUpDownIntervalCount";
            this.numericUpDownIntervalCount.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownIntervalCount.TabIndex = 1;
            this.numericUpDownIntervalCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество попыток";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 195);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(516, 5);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // panelButton1
            // 
            this.panelButton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButton1.Controls.Add(this.buttonStart);
            this.panelButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton1.Location = new System.Drawing.Point(3, 535);
            this.panelButton1.Name = "panelButton1";
            this.panelButton1.Size = new System.Drawing.Size(516, 47);
            this.panelButton1.TabIndex = 8;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(382, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(121, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Запустить";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listViewScripts
            // 
            this.listViewScripts.CheckBoxes = true;
            this.listViewScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnScript1});
            this.listViewScripts.ContextMenuStrip = this.contextMenuStripIfns;
            this.listViewScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewScripts.FullRowSelect = true;
            this.listViewScripts.GridLines = true;
            this.listViewScripts.Location = new System.Drawing.Point(3, 200);
            this.listViewScripts.Name = "listViewScripts";
            this.listViewScripts.Size = new System.Drawing.Size(516, 211);
            this.listViewScripts.TabIndex = 4;
            this.listViewScripts.UseCompatibleStateImageBehavior = false;
            this.listViewScripts.View = System.Windows.Forms.View.Details;
            // 
            // columnScript1
            // 
            this.columnScript1.Text = "Файл";
            this.columnScript1.Width = 454;
            // 
            // listViewIfns
            // 
            this.listViewIfns.CheckBoxes = true;
            this.listViewIfns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3});
            this.listViewIfns.ContextMenuStrip = this.contextMenuStripIfns;
            this.listViewIfns.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewIfns.FullRowSelect = true;
            this.listViewIfns.GridLines = true;
            this.listViewIfns.Location = new System.Drawing.Point(3, 3);
            this.listViewIfns.Name = "listViewIfns";
            this.listViewIfns.Size = new System.Drawing.Size(516, 192);
            this.listViewIfns.TabIndex = 3;
            this.listViewIfns.UseCompatibleStateImageBehavior = false;
            this.listViewIfns.View = System.Windows.Forms.View.Details;
            // 
            // column1
            // 
            this.column1.Text = "Код ИФНС";
            this.column1.Width = 100;
            // 
            // column2
            // 
            this.column2.Text = "Сервер";
            this.column2.Width = 150;
            // 
            // column3
            // 
            this.column3.Text = "База данных";
            this.column3.Width = 150;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewResult);
            this.tabPage2.Controls.Add(this.splitter2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(522, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Результаты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listViewResult
            // 
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.FullRowSelect = true;
            this.listViewResult.GridLines = true;
            this.listViewResult.Location = new System.Drawing.Point(3, 3);
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(516, 352);
            this.listViewResult.SmallImageList = this.imageList1;
            this.listViewResult.TabIndex = 15;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ИФНС";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Скрипт";
            this.columnHeader2.Width = 139;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Статус";
            this.columnHeader3.Width = 250;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_ball_red.png");
            this.imageList1.Images.SetKeyName(1, "bullet_ball_yellow.png");
            this.imageList1.Images.SetKeyName(2, "bullet_ball_green.png");
            this.imageList1.Images.SetKeyName(3, "nav_refresh_blue.png");
            this.imageList1.Images.SetKeyName(4, "bullet_square_grey.png");
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(3, 355);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(516, 5);
            this.splitter2.TabIndex = 14;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.listBoxLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 175);
            this.panel2.TabIndex = 16;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(516, 15);
            this.progressBar1.TabIndex = 15;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(0, 0);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(516, 175);
            this.listBoxLog.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelResult);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 535);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 47);
            this.panel1.TabIndex = 10;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(18, 13);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(10, 13);
            this.labelResult.TabIndex = 5;
            this.labelResult.Text = "-";
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonBack.Location = new System.Drawing.Point(382, 13);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(121, 23);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // timerShedule
            // 
            this.timerShedule.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 611);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoScript";
            this.contextMenuStripIfns.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelInterval.ResumeLayout(false);
            this.panelInterval.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalCount)).EndInit();
            this.panelButton1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripIfns;
        private System.Windows.Forms.ToolStripMenuItem menuIfnsCheckAll;
        private System.Windows.Forms.ToolStripMenuItem menuIfnsUncheckAll;
        private System.Windows.Forms.ToolStripMenuItem menuIfnsInverse;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelButton1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListView listViewScripts;
        private System.Windows.Forms.ColumnHeader columnScript1;
        private System.Windows.Forms.ListView listViewIfns;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.Panel panelInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.CheckBox checkBoxQuote;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Timer timerShedule;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBoxShedule;
        private System.Windows.Forms.Label labelShedule;
    }
}

