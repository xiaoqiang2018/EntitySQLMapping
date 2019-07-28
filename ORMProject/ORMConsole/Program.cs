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
            #region 查询
            {

            foreach (var value in Context.Entity.EntityData<shua_config>("shua_config"))
            {
                Console.WriteLine(value.k + "   " + value.v);
            }
            Console.Read();
            }
            #endregion

            #region 更新

            shua_config config = new shua_config();
            config.k = "version1";
            config.v = "100861";
            int result = Context.Entity.UpdateData<shua_config>(config);
            Console.Read();
            #endregion

            #region 删除值

            Context.Entity.RemoveData<shua_config>(
                (shua_config config1) => {
                    config1.k = "version1";
                    return config1;
                });

            #endregion

            #region 添加值
            shua_config config_Add = new shua_config();
            config_Add.k = "insert orm_k 1";
            config_Add.v = "insert orm_v 1";
            int ResultRow = Context.Entity.InsertData<shua_config>(config_Add);
            Console.Read();
            #endregion


        }
    }
}
