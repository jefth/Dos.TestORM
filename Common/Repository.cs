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
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using OrmTest;
using OrmTest.Model;

namespace DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        protected Repository()
        {
            _context = new ITdosEntities();
        }

        public DbSet<T> Entities
        {
            get { return _context.Set<T>(); }
        }

        public List<T> GetAll()
        {
            return Entities.ToList();
        }
        public List<T> Query(Expression<Func<T, bool>> where)
        {
            var result = Entities.Where(where);
            if (result.Any())
            {
                return result.ToList();
            }
            return new List<T>();
        }
        public int Insert(T entity)
        {
            Entities.Add(entity);
            return _context.SaveChanges();
        }
        public int Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Entities.Add(entity);
            }
            return _context.SaveChanges();
        }
        public int Update(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges();
        }
        public int Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return _context.SaveChanges();
        }
        public int Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            }
            return _context.SaveChanges();
        }
    }
}
