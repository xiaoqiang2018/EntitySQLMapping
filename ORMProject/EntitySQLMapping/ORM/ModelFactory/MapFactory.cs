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
        /// 校验 表 与  实体 的 列是否一致
        /// </summary>
        /// <typeparam name="T">Model层</typeparam>
        /// <param name="TableName">表名</param>
        public static void Map<T>(string TableName) where T:class,new()
        {
            string error_msg = "";
            string Cmd = GetConfig.Config("Cmd.config", System.Text.Encoding.UTF8, "GetTableColumn",out error_msg);
            MySqlDataReader reader = MySQLConnection.SqlDataReader(string.Format(Cmd,TableName));
            Type t = (new T()).GetType();
            PropertyInfo[] Propertys = t.GetProperties();
            int index = 0;
            while (reader.Read())
            {
                bool IsExixt = false;
                int index_sealed = 1;
                foreach (PropertyInfo info in Propertys)
                {
                    string Name = info.Name;
                    object Index = reader.GetString("COLUMN_NAME");
                    if (Name == Index.ToString())
                    {
                        IsExixt = true;
                        break;
                    }
                    if (IsExixt == false && Propertys.Count() == index_sealed)
                    {
                        Exception ex = new Exception();
                        ex.Source = "SQL Column And Property NoMate Error Column "+ Index;
                    }
                    index_sealed++;
                    
                }
                index++;
            }
            reader.Close();
            MapTables.Add(new MapTable() { EntityName= t.Name, TableName= TableName });
        }
        /// <summary>
        /// 获取实体的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetMapList<T>()where T:class,new()
        {
            T t = new T();
            Type type = (new T()).GetType();
            string EntityName = type.Name.ToString();
            PropertyInfo[] Propertys = type.GetProperties();
            List<T> result = new List<T>();
            foreach (MapTable Table in MapTables)
            {
                if (Table.EntityName == EntityName)
                {
                  var reader  =  MySQLConnection.SqlDataReader("Select * From "+Table.TableName);

                    while (reader.Read())
                    {
                        t = new T();
                        foreach (PropertyInfo info in Propertys)
                        {
                            String Name = info.Name.ToString();
                            object Value = reader[Name];//值类型与引用类型存在拆装箱效率问题
                            info.SetValue(t, Value);
                        }

                        result.Add(t);
                        
                    }
                    reader.Close();
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
