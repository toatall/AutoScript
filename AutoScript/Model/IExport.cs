using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScript.Model
{
    /// <summary>
    /// Заголовок
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Текст заголовка
        /// </summary>
        public string text { get; set; }
        
        /// <summary>
        /// Является ли заголовок строковым типом
        /// </summary>
        public bool isText { get; set; }
    }

    /// <summary>
    /// Описание экспорта
    /// </summary>
    interface IExport
    {
        /// <summary>
        /// Инициализация
        /// </summary>
        /// <returns>bool</returns>
        bool initialize();

        /// <summary>
        /// Передача заголовков
        /// </summary>
        /// <param name="headers">Список залоголовков</param>
        /// <returns>bool</returns>
        bool setHeaders(List<Header> headers);

        /// <summary>
        /// Передача строки
        /// </summary>
        /// <param name="row">Строка со значениями</param>
        /// <returns>bool</returns>
        bool nextRow(List<string> row);

        /// <summary>
        /// Получение последнего исключения
        /// </summary>
        Exception getLastError { get; }

        /// <summary>
        /// Выполнение экспорта
        /// </summary>
        /// <returns>bool</returns>
        bool export();

        /// <summary>
        /// Использование ковычек
        /// Например, в случае использования csv
        /// при подстановке ="TEXT", значение TEXT 
        /// при открытии в MS Excel будет 
        /// интерпретировано как текст
        /// </summary>
        bool useQuotes { get; set; }

    }
}
