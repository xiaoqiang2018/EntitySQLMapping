using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ORMProject.ORM;
using ORMProject.ORM.config;
using ORMProject.ORM.Help;
using ORMProject.ORM.ModelFactory;
using ORMConsole.Model;
using ORMConsole.Data;
namespace ORMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get Column Of Table
            //string error_msg = "";
            //string TableColumn_SQL = GetConfig.Config("Cmd.config",Encoding.UTF8, "GetTableColumn",out error_msg);
            //Get Column Of ConnectionStr
            //string SQL_ConnectionStr =
            //     GetConfig.Config("Cmd.config", Encoding.UTF8, "Connection",out error_msg);
            //MySQLConnection.SetConnection(SQL_ConnectionStr);
            //MySQLConnection.Open();
            //MySqlDataReader reader = MySQLConnection.SqlDataReader("select * from shua_config;");
            //MapFactory.Map<shua_config>("shua_config");
            //List<shua_config> config_List = MapFactory.GetMapList<shua_config>();
            //Context context = new Context();

            //List<shua_config> config_List = Context.Entity.EntityData<shua_config>("shua_config");
            //List<shua_pay>  pay_List = Context.Entity.EntityData<shua_pay>("shua_pay");
            foreach (var value in Context.config)
            {
                Console.WriteLine(value.k +"   "+value.v);
            }
            //while (reader.Read())
            //{
            //   string k =  reader.GetString("k");
            //   string v =  reader.GetString("v");
            //}
            Console.WriteLine("Test ORM Init ");
            Console.Read();
        }
    }
}
