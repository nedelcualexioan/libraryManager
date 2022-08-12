using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Dapper;
using MySql.Data.MySqlClient;

namespace libraryManager
{
    public class DataAcces
    {
        public List<T> LoadData<T, U>(string sqlStatement, U parameters, String connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string sqlstatement, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                connection.Execute(sqlstatement, parameters);
            }
        }
    }
}