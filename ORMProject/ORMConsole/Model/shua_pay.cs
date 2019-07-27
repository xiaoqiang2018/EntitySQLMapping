/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ORMConsole.Model
*文件名： shua_pay
*创建人： 郑伯强
*创建时间：2019/7/27 17:56:56
*描述
*=====================================================================
*修改标记
*修改时间：2019/7/27 17:56:56
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
    public class shua_pay
    {
        public string trade_no        {get;set;}
        public string type            {get;set;}
        public int    zid             {get;set;}
        public int    tid             {get;set;}
        public string input           {get;set;}
        public int    num             {get;set;}
        public string addtime         {get;set;}
        public string endtime         {get;set;}
        public string name            {get;set;}
        public string money           {get;set;}
        public string ip              {get;set;}
        public string userid          {get;set;}
        public int    inviteid        {get;set;}
        public string domain          {get;set;}
        public int    status { get; set; }

    }
}
