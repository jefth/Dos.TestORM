#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Orm_Hxj
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：周浩
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/6 11:26:24
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hxj.Data;

namespace OrmTest
{
    public class TestHxj
    {
        public static readonly DbSession DBsession = new DbSession("conn1");
        //static TestHxj()
        //{
        //    DBsession.RegisterSqlLogger(delegate(string sql)
        //    {
        //        var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\TestHxj" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        //        var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\");
        //        if (!di.Exists)
        //        {
        //            di.Create();
        //        }
        //        using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write))
        //        {
        //            var sw = new StreamWriter(fs);
        //            sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //            sw.WriteLine();
        //            sw.Write(sql);
        //            sw.WriteLine();
        //            sw.Write("-----------------------------------------------------------------------------");
        //            sw.WriteLine();
        //            sw.Flush();
        //            sw.Close();
        //        }
        //    });
        //}
    }
}
