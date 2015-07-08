#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：TestDapper
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：周浩
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/6 13:44:16
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
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace OrmTest
{
    public class TestDapper
    {
        public static readonly TestDapper DBsession = new TestDapper();
        private static readonly string SqlConn = ConfigurationManager.ConnectionStrings["conn1"].ToString();
        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(SqlConn);
            conn.Open();
            return conn;
        }

        public int Execute(string sql, object param = null)
        {
            var count = 0;
            using (IDbConnection conn = OpenConnection())
            {
                count = conn.Execute(sql, param);
                conn.Close();
            }
            return count;
        }
        public List<T> Query<T>(string sql)
        {
            List<T> result;
            using (IDbConnection conn = OpenConnection())
            {
                result = conn.Query<T>(sql).ToList();
                conn.Close();
            }
            return result;
        }
    }
}
