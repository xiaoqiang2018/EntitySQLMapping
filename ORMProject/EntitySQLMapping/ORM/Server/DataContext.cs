/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：EntitySQLMapping.ORM.Server
*文件名： DataContext
*创建人： 郑伯强
*创建时间：2019/7/27 17:06:28
*描述
*=====================================================================
*修改标记
*修改时间：2019/7/27 17:06:28
*修改人：郑伯强
*描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitySQLMapping.ORM;
using ORMProject.ORM.Help;
using ORMProject.ORM.ModelFactory;

namespace EntitySQLMapping.ORM.Server
{
    public class DataContext:MySQLConnection
    {
        //public MapFactory Map = new MapFactory();
        public DataContext()
        {
            Console.WriteLine("DataContext Child ");
        }
        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        public void Init()
        {
            Open();//初始化 数据库 连接
        }
        /// <summary>
        /// 实体映射到表
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="TableName">表名</param>
        /// <returns></returns>
        public List<T> EntityData<T>(string TableName) where T:class,new()
        {
            //MapFactory.GetMapList
            MapFactory.Map<T>(TableName);
            return MapFactory.GetMapList<T>();
        }
        /// <summary>
        /// 更新实体的值 ( 请不要更新实体的主键 )
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public int UpdateData<T>(T Entity) where T:class,new()
        {
            //update entity => update sql =>return row

            //string TableName = MapFactory.SelectEntityTableName<T>(Entity);
            //string Key = "";
            //string Value = "";
            //List<KeyValue> PropertyName = MapFactory.GetEntityProperty(Entity,out Key);
            //string SQL_KeyValue = "";
            //int index = 0;
            //foreach (KeyValue Name in PropertyName)
            //{
            //    SQL_KeyValue +=  Name.Key+" = "+"'"+Name.Value +"'" ;
            //    if (PropertyName.Count()-1 != index)
            //    {
            //        SQL_KeyValue += ",";
            //    }
            //    if (Name.Key == Key)
            //    {
            //        Value = Name.Value;
            //    }
            //    index++;
            //}
            //string SQL = "UPDATE "+TableName+" SET  "+SQL_KeyValue+" WHERE " + Key +" = '"+Value+"'"  ;
            string SQL = GetSQLParam(Entity,"update");
            return MySQLConnection.SqlReturnRow(SQL);

        }
        /// <summary>
        /// 删除实体 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public int RemoveData<T>(Func<T, T> action) where T : class,new()
        {
            //T t = new T();
            //Type Entity_type = t.GetType();
            //T Value =  action.Invoke(t);//获取返回值
            //string key = "";
            //List<KeyValue> keyvalueList = MapFactory.GetEntityProperty(Value, out key);
            //int index = 0;
            //string SQLParary = "";
            //foreach (KeyValue kv in keyvalueList)
            //{
            //    SQLParary = kv.Key +" = '"+ kv.Value+"'" ;
            //    if (keyvalueList.Count()-1 != index)
            //    {
            //        SQLParary = " AND ";
            //    }
            //    index++;
            //}
            //string SQL = " DELETE FROM "+Entity_type.Name + " WHERE " + SQLParary+";" ;
            string SQL = GetSQLParam(new T(), "delete",action);
            int Result = MySQLConnection.SqlReturnRow(SQL);
            return Result;
        }

        public int InsertData<T>(T Entity) where T:class,new()
        {
            //T t = new T();
            //Type Entity_type = t.GetType();
            //string key = "";
            //List<KeyValue> keyvalueList = MapFactory.GetEntityProperty(Entity, out key);
            //int index = 0;
            //string SQLPararyKey = "";
            //string SQLPararyValue = "";
            //foreach (KeyValue kv in keyvalueList)
            //{
            //    SQLPararyKey += kv.Key ;
            //    SQLPararyValue +=  "'"+kv.Value+"'";
            //    if (keyvalueList.Count() - 1 != index)
            //    {
            //        SQLPararyKey += ",";
            //        SQLPararyValue += ",";
            //    }
            //    index++;
            //}
            string SQL = GetSQLParam(Entity, "insert");
            //string SQL = "INSERT INTO "+Entity_type.Name +" ( "+SQLPararyKey+" ) "
            //    +" Value ( "+ SQLPararyValue +" )";
            int ResultRow = SqlReturnRow(SQL);
            return ResultRow;
        }
        /// <summary>
        /// insert delete update 模式中 获取 拼接字段
        /// </summary>
        /// <param name="Model">拼接模式(默认为update)</param>
        /// <returns></returns>
        protected string GetSQLParam<T>(T Entity, string Model, Func<T, T> Func = null ) where T:class,new()
        {
            string SQL = "";
            string SQLParary = "";
            string key = "";
            //int index = 0;
            string[] ModelType = { "insert", "delete", "update" };
            T t = new T();
            Type Entity_type = t.GetType();

            if (Model == ModelType[0])
            {
                List<KeyValue> keyvalueList = MapFactory.GetEntityProperty(Entity, out key);

                //string key = "";
                //int index = 0;
                //string SQLPararyKey = "";
                //string SQLPararyValue = "";
                //foreach (KeyValue kv in keyvalueList)
                //{
                //    SQLPararyKey += kv.Key;
                //    SQLPararyValue += "'" + kv.Value + "'";
                //    if (keyvalueList.Count() - 1 != index)
                //    {
                //        SQLPararyKey += ",";
                //        SQLPararyValue += ",";
                //    }
                //    index++;
                //}
                SQLParary = SQLKeyValueFilter(Model, keyvalueList);

                //SQL = "INSERT INTO " + Entity_type.Name + " ( " + SQLPararyKey + " ) "
                //    + " Value ( " + SQLPararyValue + " )";
                SQL = "INSERT INTO " + Entity_type.Name + SQLParary  ;
            }
            else if (Model == ModelType[1])
            {
                //T t = new T();
                //Type Entity_type = t.GetType();
                T Value = Func.Invoke(t);//获取返回值
                //string key = "";
                //List<KeyValue> keyvalueList = MapFactory.GetEntityProperty(Value, out key);
                //int index = 0;
                //SQLParary = "";
                //foreach (KeyValue kv in keyvalueList)
                //{
                //    SQLParary += kv.Key + " = '" + kv.Value + "'";
                //    if (keyvalueList.Count() - 1 != index)
                //    {
                //        SQLParary += " AND ";
                //    }
                //    index++;
                //}
                 List<KeyValue> List = MapFactory.GetEntityProperty(Value, out key);
                 SQLParary = SQLKeyValueFilter(Model, List);
                 SQL = " DELETE FROM " + Entity_type.Name + " WHERE " + SQLParary + ";";
            }
            else
            {
                List<KeyValue> keyvalueList = MapFactory.GetEntityProperty(Entity, out key);
                string TableName = MapFactory.SelectEntityTableName<T>(Entity);
                SQLParary = SQLKeyValueFilter(Model, keyvalueList);
                var keyvalue = keyvalueList.Single(s => s.Key == key);
                //string Key = "";
                //string Value = "";
                //List<KeyValue> PropertyName = MapFactory.GetEntityProperty(Entity, out Key);
                //SQLParary = "";
                //int index = 0;
                //foreach (KeyValue Name in keyvalueList)
                //{

                //        SQLParary += Name.Key + " = " + "'" + Name.Value + "'";

                //    if (keyvalueList.Count() - 1 != index)
                //    {
                //        SQLParary += ",";
                //    }
                //    if (Name.Key == key)
                //    {
                //        Value = Name.Value;
                //    }
                //    index++;
                //}
                SQL = "UPDATE " + TableName + " SET  " + SQLParary + " WHERE " + key + " = '" + keyvalue.Value + "'";

            }

            return SQL;
        }

        protected string SQLKeyValueFilter(string Model,List<KeyValue> keyvalueList)
        {
            string SQLParary = "";
            string key = "";
            //string Value = "";
            int index = 0;
            string SQLPararyKey = "";
            string SQLPararyValue = "";
            string[] ModelType = { "insert", "delete", "update" };
            //update 
            foreach (KeyValue Name in keyvalueList)
            {
                if (Model == ModelType[0])
                {
                    SQLParary += "";
                    SQLPararyKey += Name.Key;
                    SQLPararyValue += "'" + Name.Value + "'";
                }
                else
                {
                    SQLParary += Name.Key + " = " + "'" + Name.Value + "'";
                }
                if (keyvalueList.Count() - 1 != index)
                {
                    if (ModelType[2]==Model) {
                        SQLParary += ",";
                    }
                    else if (ModelType[1]==Model)
                    {
                        SQLParary += " AND ";
                    }
                    else if(ModelType[0] == Model)
                    {
                        SQLPararyKey += ",";
                        SQLPararyValue += ",";
                    }
                    else
                    {

                    }
                }
                //if (Name.Key == key)
                //{
                //    Value = Name.Value;
                //}
                index++;
            }
            //delete
            //foreach (KeyValue kv in keyvalueList)
            //{
            //    SQLParary += kv.Key + " = '" + kv.Value + "'";
            //    if (keyvalueList.Count() - 1 != index)
            //    {
            //        SQLParary += " AND ";
            //    }
            //    index++;
            //}
            if (Model == ModelType[0])
            {
                SQLParary = " ( " + SQLPararyKey + " ) "
                   + " Value ( " + SQLPararyValue + " )";
            }
            return SQLParary;

        }

    }
}
