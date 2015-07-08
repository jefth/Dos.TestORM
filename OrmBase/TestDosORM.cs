#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：TestDosORM
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：周浩
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/6 20:36:17
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
using Dos.ORM;

namespace OrmTest.OrmBase
{   
    public class DB
    {
        public static readonly DbSession Context = new DbSession("conn1");
        //public static DbSession ContextMySql = new DbSession("conn2");
        //static DB()
        //{
        //    Context.RegisterSqlLogger(delegate(string sql)
        //    {
        //        var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\TestDosORM" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        //        #region 把sql以txt文件记录至目录
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
        //        #endregion
        //    });
        //    ContextMySql.RegisterSqlLogger(delegate(string sql)
        //    {
        //        var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\TestDosORM" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        //        #region 把sql以txt文件记录至目录
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
        //        #endregion
        //    });
        //}
    }
}
