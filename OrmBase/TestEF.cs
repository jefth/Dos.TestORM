#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Orm_EF
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：周浩
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/6 11:26:57
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using OrmTest.Model;

namespace OrmTest
{
    public class TestEF
    {
        public partial class TestTableRepository : Repository<TestTable>
        {
            /// <summary>
            /// 数据模型上下文
            /// </summary>
            private readonly ITdosEntities _context;
            public TestTableRepository()
            {
                _context = new ITdosEntities();
            }
        }
    }
}
