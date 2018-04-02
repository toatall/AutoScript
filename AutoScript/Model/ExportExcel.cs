using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutoScript.Model
{
    class ExportExcel: IExport
    {
        private string _fileSave;
        private int _lastDataRow = 1;
        private List<Header> _headers = new List<Header>();
        private Excel.Application _excelApp;
        private Excel._Workbook _workbook;
        private Excel._Worksheet _worksheet;
        private Exception _lastError;

        public Exception getLastError 
        { 
            get 
            { 
                return _lastError; 
            } 
        }


        public ExportExcel(string fileSave)
        {
            _fileSave = fileSave;
        }

        public bool initialize()
        {
            try
            {
                // инициализировать MS Excel           
                _excelApp = new Excel.Application();
                _excelApp.Visible = false;
                _excelApp.DisplayAlerts = false;
                _workbook = _excelApp.Workbooks.Add();
                _worksheet = (Excel._Worksheet)_excelApp.ActiveSheet;
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex;
                return false;
            }
        }

        public bool setHeaders(List<Header> headers)
        {
            try
            {
                _headers = headers;
                int column = 1;
                foreach (Header header in _headers)
                {
                    if (header.isText)
                        _worksheet.Cells[_lastDataRow, column].NumberFormat = "@";
                    _worksheet.Cells[_lastDataRow, column] = header.text;
                    column++;
                }

                _lastDataRow++;

                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex;
                return false;
            }

        }

        public bool nextRow(List<string> row)
        {
            try
            {
                if (_headers.Count == 0)
                    throw new Exception("Заголовок не инициализорован");


                // вставить строку
                int column = 1;
                foreach (string str in row)
                {
                    if (_headers[column - 1].isText)
                        _worksheet.Cells[_lastDataRow, column].NumberFormat = "@";
                    _worksheet.Cells[_lastDataRow, column] = str;
                    column++;
                }

                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex;
                return false;
            }
        }

        public bool export()
        {
            try
            {                
                _workbook.SaveAs(_fileSave, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                _excelApp.Workbooks.Close();
                _excelApp.Quit();
                return true;
            }
            catch (Exception ex)
            {
                _lastError = ex;
                return false;
            }
        }

        public bool useQuotes { get; set; }

    }
}
