using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dao.DAO
{
    public sealed class Connection
    {
        public MySqlConnection DBConnection { get; set; }

        private static readonly Connection instance = new Connection();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Connection()
        {
        }

        private Connection()
        {
            string con = "Server=localhost;Database=venda_db;Uid=root;Pwd=venus";
            DBConnection = new MySqlConnection(con);
            DBConnection.Open();
        }

        public static MySqlConnection Instance
        {
            get
            {
                if (instance.DBConnection == null || instance.DBConnection.State != System.Data.ConnectionState.Open)
                {
                    instance.DBConnection = new Connection().DBConnection;
                }
                return instance.DBConnection;
            }
        }
    }
}