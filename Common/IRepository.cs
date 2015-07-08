#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Sys_BaseDataLogic
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：周浩
* 电子邮箱：admin@itdos.com
* 创建日期：2014/10/1 11:00:49
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Entities { get; }
        List<T> GetAll();
        List<T> Query(Expression<Func<T, bool>> where);
        int Insert(IEnumerable<T> entities);
        int Update(IEnumerable<T> entities);
        int Delete(IEnumerable<T> entities);
    }
}
