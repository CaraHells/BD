using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CinemaApp.infrastructure
{
    public class Entity
    {
        /// <summary>
        /// Получить список объектов со значениями полей
        /// </summary>
        /// <typeparam name="T">Объект</typeparam>
        /// <param name="sqlString">sql команда</param>
        /// <returns>Список объектов с полями-значениями </returns>
        public static List<T> Execute<T>(string sqlString) where T : new()
        {
            var list = new List<T>();
            var objType = typeof(T);
            var properties = typeof(T).GetProperties();
            DBconn dBconn = new DBconn();
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sqlString, DBconn.SqlConnection))
                {
                    var sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        var element = new T();
                        int i = 0;
                        foreach (var itemProp in properties)
                        {
                            objType.GetProperty(itemProp.Name).SetValue(element, sqlDataReader.GetValue(i) == DBNull.Value ? null : sqlDataReader.GetValue(i));
                            i++;
                        }
                        list.Add(element);
                    }
                }
                DBconn.SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return list;
        }

        /// <summary>
        /// Возвращает целочисленное значение из базы
        /// </summary>
        /// <param name="sqlString">sql команда</param>
        /// <returns>Целочисленное значение поля</returns>
        public static Int64 NumExecute(string sqlString)
        {
            using (var npgsqlCommand = new NpgsqlCommand(sqlString, DBconn.SqlConnection))
            {
                int num = 0;
                NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    num = Int32.Parse(reader[0].ToString());
                }
                DBconn.SqlConnection.Close();
                return num;
            }
        }

        /// <summary>
        /// Строка из базы данных
        /// </summary>
        /// <param name="sqlString">sql команда</param>
        /// <returns>Строковое значение поля из бд</returns>
        public static string StringExecute(string sqlString)
        {
            using (var npgsqlCommand = new NpgsqlCommand(sqlString, DBconn.SqlConnection))
            {
                string str = "";
                NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    str = reader[0].ToString();
                }
                DBconn.SqlConnection.Close();
                return str;
            }
        }

        /// <summary>
        /// Вставить или удалить записи
        /// </summary>
        /// <param name="sqlString">sql команда</param>
        public static void Execute(string sqlString)
        {
            try
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlString, DBconn.SqlConnection);
                npgsqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DBconn.SqlConnection.Close();
            }

        }

        /// <summary>
        /// Получить названий таблиц из БД
        /// </summary>
        /// <param name="sqlCommand">sql команда</param>
        /// <returns>список названий таблиц</returns>
        public static List<string> GetTables(string sqlCommand)
        {
            using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand( sqlCommand, DBconn.SqlConnection))
            {
                NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
                List<string> tablesName = new List<string>();
                while(reader.Read())
                {
                    string tableName = reader.GetString(0);
                    tablesName.Add(tableName);
                }
                DBconn.SqlConnection.Close();
                return tablesName;
            }
        }

        /// <summary>
        /// Список полей объекта
        /// </summary>
        /// <param name="sqlCommand">sql команда</param>
        /// <returns>Список полей объекта и тип полей</returns>
        public static List<Tuple<string,string>> GetProperties(string sqlCommand)
        {
            List<Tuple<string,string>> tuples = new List<Tuple<string,string>>();
            using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlCommand, DBconn.SqlConnection))
            {
                npgsqlCommand.CommandText = sqlCommand;
                NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    var tableProp=reader.GetString(0);
                    var tableType=reader.GetString(1);
                    tuples.Add(new Tuple<string, string> ( tableProp, tableType ));
                }
            }
            DBconn.SqlConnection.Close();
            return tuples;
        }
    }
}
