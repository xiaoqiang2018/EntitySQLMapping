/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMConsole.DataContext
*文件名： Context
*创建人： 郑伯强
*创建时间：2019/7/27 17:27:30
*描述
*=====================================================================
*修改标记
*修改时间：2019/7/27 17:27:30
*修改人：郑伯强
*描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitySQLMapping.ORM.Server;
using ORMConsole.Model;

namespace ORMConsole.Data
{
    public class Context:DataContext
    {
        public Context()
        {
            Init();
        }
        public static Context Entity = new Context();
        //public List<shua_config> config_List = Entity.EntityData<shua_config>("shua_config");
        //public List<shua_pay> pay_List = Context.Entity.EntityData<shua_pay>("shua_pay");
        

        public static List<shua_config> config
        {
            get { return Entity.EntityData<shua_config>("shua_config"); }
            set {  }
        }

        //public static List<shua_config> GetConfig()
        //{
        //    List<shua_config> config_List = Entity.EntityData<shua_config>("shua_config");
        //    return config_List;
        //}
        public static List<shua_pay> GetPay()
        {
            List<shua_pay> pay_List = Context.Entity.EntityData<shua_pay>("shua_pay");
            return pay_List;
        }


    }
}
