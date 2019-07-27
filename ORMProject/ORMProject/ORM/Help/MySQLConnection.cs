using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace ORMProject.ORM.Help
{
    public class MySQLConnection
    {
        protected static string Connection_str;
        //protected static SqlConnection Sql_Connection = null;
        protected static MySqlCommand Command = null;
        public static MySqlConnection Connection = new MySqlConnection();
        public MySQLConnection()
        {
            //log init 
            Console.WriteLine("ORM Init");
        }
        public MySQLConnection(string Con_str)
        {
            Connection_str = Con_str;
            //Sql_Connection = new SqlConnection(Connection_str);
        }
        public static void SetConnection(string ConnectionStr)
        {
            Connection_str = ConnectionStr;
        }
        /// <summary>
        /// 执行sql 返回结果集
        /// </summary>
        /// <param name="CmdText"></param>
        /// <returns></returns>
        public static MySqlDataReader SqlDataReader(string CmdText)
        {
            MySqlCommand command = new MySqlCommand(CmdText,Connection);
            return command.ExecuteReader();
        }
        public static int SqlReturnRow(string CmdText)
        {
            MySqlCommand command = new MySqlCommand(CmdText, Connection);
            return command.ExecuteNonQuery();
        }
        public static MySqlDataAdapter SqlDataDataSet(string CmdText)
        {
            //DataSet datas = new DataSet();
            MySqlDataAdapter adapter =
                new MySqlDataAdapter(CmdText, Connection);
            //adapter.Fill(datas);
            //return datas.Tables[0];
            return adapter;
        }
        public static void Open()
        {
            if (!(Connection.State == System.Data.ConnectionState.Open) && Connection.Ping())
            {
                Connection.Open();
            }
        }

        public static void Close()
        {
            if (!(Connection.State == System.Data.ConnectionState.Closed))
            {
                Connection.Close();
            }
        }

        public static void SetTimeout(int timeout)
        {
            Connection.CancelQuery(timeout);
        }

    }
}
