using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoScript.Model
{
    /// <summary>
    /// Класс для работы с MS SQL
    /// </summary>
    class SQL: IDisposable
    {
        // ссылка на подключение
        private SqlConnection _connection = null;
        private int _countTry;
        // последняя ошибка
        private Exception _lastError;
        public Exception lastError
        {
            get
            {
                return _lastError;
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString">Строка подключения</param>
        public SQL(string connectionString, int countTry = 5)
        {
            _countTry = countTry;
            if (_connection == null)
            {
                try
                {
                    _connection = new SqlConnection(connectionString);                                        
                }
                catch (Exception ex)
                {
                    _lastError = ex;
                }
            }
        }
        

        /// <summary>
        /// Выполнение запроса
        /// </summary>
        /// <param name="script"></param>        
        public bool RunSQL(string script, IExport export)
        {            
            /*for (int iTry = 1; iTry <= _countTry; iTry++)
            {*/
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(script, _connection);  
                    sqlCommand.CommandTimeout = 24 * 60 * 60;
                    _connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();                                        
                    // 1 передать столбцы и типы данных
                    List<Header> headers = new List<Header>();
                    for (int i=0; i < reader.FieldCount; i++)
                    {                        
                        headers.Add(new Header
                        {
                            text = reader.GetName(i),
                            isText = (reader.GetFieldType(i) == typeof(string)) ? true : false
                        });
                    }
                 
                    export.setHeaders(headers);

                    List<string> dataRow = new List<string>();
                    // 2 передать все данные
                    while (reader.Read())
                    {
                        dataRow.Clear();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {                            
                            dataRow.Add(reader[i].ToString());
                        }
                        export.nextRow(dataRow);
                    }

                    return true;

                }                
                catch (Exception ex)
                {
                    _lastError = ex;                    
                }
            //}
            return false;
        }

        /// <summary>
        /// Высвобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                _connection.Dispose();
            }
            catch { }
        }
    }
}
