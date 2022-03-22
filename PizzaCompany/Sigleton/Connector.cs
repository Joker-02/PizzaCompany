using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Pizza_Company.Sigleton
{
    public class Connector
    {
        //Change this to you server
        private string ServerName = @"DESKTOP-CA4M6G1\SQLEXPRESS";
        private string UserName = "Zax";
        private string Password = "Kingman#123";
        private string DataBase = "PizzaDB";
        private static SqlConnection _conn=new SqlConnection();
        private static Connector _connector=new Connector();
        private Connector()
        {

        }
        public static Connector GetConnector()
        {
            return _connector;
        }
        public SqlConnection GetConnection()
        {
            if( string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(UserName))//if no user auth
            {
                _conn.ConnectionString = $"server={ServerName}; database={DataBase}; Integrated Security=true";
            }
            else
            _conn.ConnectionString = $"server={ServerName}; database={DataBase}; uid={UserName}; password={Password}";
            return _conn;
        }
    }
}
