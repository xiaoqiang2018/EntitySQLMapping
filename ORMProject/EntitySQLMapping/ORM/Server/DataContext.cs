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

    }
}
