using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ORMProject.ORM.config;
using ORMProject.ORM.Help;
namespace ORMProject.ORM.ModelFactory
{
    /// <summary>
    /// 类映射工厂  结果集转化为列表  
    /// </summary>
    public class MapFactory
    {
        protected static List<MapTable> MapTables = new List<MapTable>();
        /// <summary>
        /// 表映射到实体
        /// </summary>
        /// <typeparam name="T">Model层</typeparam>
        /// <param name="TableName">表名</param>
        public static void Map<T>(string TableName) where T:class,new()
        {
            string Cmd = GetConfig.Config("/Config/Cmd.config", System.Text.Encoding.UTF8, "GetTableColumn");
            MySqlDataReader reader = MySQLConnection.SqlDataReader(Cmd);

            Type t = (new T()).GetType();
            PropertyInfo[] Propertys = t.GetProperties();
            int index = 0;
            while (reader.Read())
            {
                //SQLColumns.Add(reader[index].ToString());
                bool IsExixt = false;
                int index_sealed = 1;
                foreach (PropertyInfo info in Propertys)
                {
                    string Name = info.Name;
                    if (Name == reader[index].ToString())
                    {
                        //Entity.Add(Name);
                        IsExixt = true;
                        break;
                    }
                    if (IsExixt == false && Propertys.Count() == index_sealed)
                    {
                        //Entity.Clear();
                        Exception ex = new Exception();
                        ex.Source = "SQL Column And Property NoMate Error Column "+Name;
                    }
                    index_sealed++;
                    //
                    //string Value =  info.GetValue(t).ToString();
                }
                index++;
            }
            MapTables.Add(new MapTable() { EntityName= t.Name, TableName= TableName });
            //string Cmd = GetConfig.Config("/Config/Cmd.config",System.Text.Encoding.UTF8,"GetTableColumn");
            //MySqlDataReader reader = MySQLConnection.SqlDataReader(Cmd);



        }
        public static List<T> GetMapList<T>()where T:class,new()
        {
            T t = new T();
            string EntityName = t.ToString();
            Type type = (new T()).GetType();
            PropertyInfo[] Propertys = type.GetProperties();
            List<T> result = new List<T>();
            foreach (MapTable Table in MapTables)
            {
                if (Table.EntityName == EntityName)
                {
                  var reader  =  MySQLConnection.SqlDataReader("Select * From "+Table.TableName);
                    //int index = 0;
                    while (reader.Read())
                    {
                        object item = new object();

                        foreach (PropertyInfo info in Propertys)
                        {
                            string Name = info.Name;
                            //item = (T)reader[Name];
                            //item = (Name);
                            info.SetValue(Name,reader[Name]);
                        }
                        result.Add(t);

                        //index++;
                    }
                }
            }
            return result;
        }
       
    }

    public class MapTable
    {
        public string TableName { get; set; }
        public string EntityName { get; set; }
    }
}
