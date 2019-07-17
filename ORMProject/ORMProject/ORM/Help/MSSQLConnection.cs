using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ORMProject.ORM.Help
{
    public class ConnectionHelp
    {
        protected static string Connection;
        protected static SqlConnection Sql_Connection = null;
        protected static SqlCommand Command = null;
        public ConnectionHelp()
        {
            //log init 
            Console.WriteLine("ORM Init");
        }
        public ConnectionHelp(string Con_str)
        {
            Connection = Con_str;
            Sql_Connection = new SqlConnection(Connection);
        }
        public static void SetConnection(string ConnectionStr)
        {
            Connection = ConnectionStr;
        }
        public static SqlDataReader SqlDataReader(string CmdText)
        {
            Command = new SqlCommand(CmdText, Sql_Connection);
            return Command.ExecuteReader();
        }
        public static int SqlReturnRow(string CmdText)
        {
            Command = new SqlCommand(CmdText, Sql_Connection);
            return Command.ExecuteNonQuery();
        }
        public static DataSet SqlDataDataSet(string CmdText)
        {
            DataSet datas = new DataSet();
            SqlDataAdapter adapter =
                new SqlDataAdapter(CmdText, Connection);
            adapter.Fill(datas);
            //return datas.Tables[0];
            return datas;
        }



    }
}
