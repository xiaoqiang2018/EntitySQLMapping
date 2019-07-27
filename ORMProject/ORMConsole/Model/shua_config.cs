/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMConsole.Model
*文件名： shua_config
*创建人： 郑伯强
*创建时间：2019/7/27 15:29:27
*描述
*=====================================================================
*修改标记
*修改时间：2019/7/27 15:29:27
*修改人：郑伯强
*描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMConsole.Model
{
    public class shua_config
    {
        [Key]
        public string k { get; set; }
        public string v { get; set; }
    }
    /// <summary>
    /// DOTO 实体中的主键 映射 表的主键 ???
    /// </summary>
    public class Key : Attribute
    {

    }
}
