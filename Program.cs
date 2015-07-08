using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Entities;
using Dos.ORM;
using Dos.ORM.Common;
using Model;
using OrmTest.Model;
using OrmTest.OrmBase;
using System.Data.Common;

namespace OrmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            #region init
            var testIndex = 1;
            const string tempValue = "http://www.itdos.com/HxjData/Index.html";
            //测试数据条数
            const int testCount = 1000;
            var count = 0;
            var efAddModels = new List<OrmTest.Model.TestTable>();
            var dapperAddSql = new string[testCount];
            var dapperUptSql = new string[testCount];
            var dapperDelSql = new string[testCount];
            var dapperAddSqlParam = new object[testCount];
            var dapperUptSqlParam = new object[testCount];
            var dapperDelSqlParam = new object[testCount];
            var ids = new object[testCount];
            for (int i = 0; i < testCount; i++)
            {
                var tempId = Guid.NewGuid();
                ids[i] = tempId;
                efAddModels.Add(new OrmTest.Model.TestTable()
                {
                    ID = tempId,
                    c1 = tempValue + Guid.NewGuid(),
                    c2 = tempValue + Guid.NewGuid(),
                    c3 = tempValue + Guid.NewGuid(),
                    c4 = tempValue + Guid.NewGuid(),
                    c5 = tempValue + Guid.NewGuid(),
                    c6 = tempValue + Guid.NewGuid(),
                    c7 = tempValue + Guid.NewGuid(),
                    c8 = tempValue + Guid.NewGuid(),
                    c9 = 99999,
                    c10 = tempValue + Guid.NewGuid(),
                    c11 = tempValue + Guid.NewGuid(),
                    c12 = decimal.Parse("19.22"),
                    c13 = tempValue + Guid.NewGuid(),
                    c14 = Guid.NewGuid(),
                    c15 = 123,
                    c16 = true,
                    c17 = tempValue + Guid.NewGuid(),
                    c18 = DateTime.Now,
                    c19 = 19.22,
                    c20 = tempValue + Guid.NewGuid(),
                });
                dapperAddSql[i] = " insert into TestTable values(@ID,@C1,@C2,@C3,@C4,@C5,@C6,@C7,@C8,@C9,@C10,@C11,@C12,@C13,@C14,@C15,@C16,@C17,@C18,@C19,@C20) ";
                dapperAddSqlParam[i] = new
                {
                    ID = tempId,
                    c1 = tempValue + Guid.NewGuid(),
                    c2 = tempValue + Guid.NewGuid(),
                    c3 = tempValue + Guid.NewGuid(),
                    c4 = tempValue + Guid.NewGuid(),
                    c5 = tempValue + Guid.NewGuid(),
                    c6 = tempValue + Guid.NewGuid(),
                    c7 = tempValue + Guid.NewGuid(),
                    c8 = tempValue + Guid.NewGuid(),
                    c9 = 99999,
                    c10 = tempValue + Guid.NewGuid(),
                    c11 = tempValue + Guid.NewGuid(),
                    c12 = decimal.Parse("19.22"),
                    c13 = tempValue + Guid.NewGuid(),
                    c14 = Guid.NewGuid(),
                    c15 = 123,
                    c16 = true,
                    c17 = tempValue + Guid.NewGuid(),
                    c18 = DateTime.Now,
                    c19 = 19.22,
                    c20 = tempValue + Guid.NewGuid(),
                };
                dapperUptSql[i] = " update TestTable set C1=@C1,C2=@C2,C3=@C3,C4=@C4,C5=@C5,C6=@C6,C7=@C7,C8=@C8,C9=@C9,C10=@C10,C11=@C11,C12=@C12,C13=@C13,C14=@C14,C15=@C15,C16=@C16,C17=@C17,C18=@C18,C19=@C19,C20=@C20  where ID=@ID";
                dapperUptSqlParam[i] = new
                {
                    ID = tempId,
                    c1 = tempValue + Guid.NewGuid(),
                    c2 = tempValue + Guid.NewGuid(),
                    c3 = tempValue + Guid.NewGuid(),
                    c4 = tempValue + Guid.NewGuid(),
                    c5 = tempValue + Guid.NewGuid(),
                    c6 = tempValue + Guid.NewGuid(),
                    c7 = tempValue + Guid.NewGuid(),
                    c8 = tempValue + Guid.NewGuid(),
                    c9 = 99999,
                    c10 = tempValue + Guid.NewGuid(),
                    c11 = tempValue + Guid.NewGuid(),
                    c12 = decimal.Parse("19.22"),
                    c13 = tempValue + Guid.NewGuid(),
                    c14 = Guid.NewGuid(),
                    c15 = 123,
                    c16 = true,
                    c17 = tempValue + Guid.NewGuid(),
                    c18 = DateTime.Now,
                    c19 = 19.22,
                    c20 = tempValue + Guid.NewGuid(),
                };

                dapperDelSql[i] = " delete from TestTable where ID=@ID";
                dapperDelSqlParam[i] = new
                {
                    ID = tempId
                };
            }
            #endregion
        Start:
            Console.WriteLine("--【开始第" + testIndex + "次对比测试ORM性能】--【www.ITdos.com】--");

            #region EF
            if (false)
            {
                var db = new TestEF.TestTableRepository();
                Console.WriteLine("--------------------------------------");
                var efModels = Common.EntityCopy<OrmTest.Model.TestTable, OrmTest.Model.TestTable>(efAddModels);
                count = 0;
                timer.Restart();
                foreach (var testTable in efModels)
                {
                    count += db.Insert(testTable);
                }
                timer.Stop();
                Console.WriteLine("EF插入" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                foreach (var hxjAddModel in efModels)
                {
                    hxjAddModel.c1 = tempValue + Guid.NewGuid();
                    hxjAddModel.c2 = tempValue + Guid.NewGuid();
                    hxjAddModel.c3 = tempValue + Guid.NewGuid();
                    hxjAddModel.c4 = tempValue + Guid.NewGuid();
                    hxjAddModel.c5 = tempValue + Guid.NewGuid();
                    hxjAddModel.c6 = tempValue + Guid.NewGuid();
                    hxjAddModel.c7 = tempValue + Guid.NewGuid();
                }
                count = 0;
                timer.Restart();
                foreach (var testTable in efModels)
                {
                    count += db.Update(testTable);
                }
                timer.Stop();
                Console.WriteLine("EF修改" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                timer.Restart();
                var list3 = db.Query(a => a.c1 != "");
                timer.Stop();
                Console.WriteLine("EF查询所有数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + list3.Count());
                //---------------------------------
                timer.Restart();
                count = db.Delete(efModels);
                timer.Stop();
                Console.WriteLine("EF删除" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
            }
            #endregion

            #region Dapper
            if (true)
            {
                //var list2222 = TestDapper.DBsession.Query<OrmTest.Model.TestTable>("select * from TestTable where c1 <> ''");
                Console.WriteLine("--------------------------------------");
                count = 0;
                timer.Restart();
                for (int i = 0; i < dapperAddSql.Length; i++)
                {
                    count += TestDapper.DBsession.Execute(dapperAddSql[i], dapperAddSqlParam[i]);
                }
                timer.Stop();
                Console.WriteLine("Dapper插入" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                count = 0;
                timer.Restart();
                for (int i = 0; i < dapperUptSql.Length; i++)
                {
                    count += TestDapper.DBsession.Execute(dapperUptSql[i], dapperUptSqlParam[i]);
                }
                timer.Stop();
                Console.WriteLine("Dapper修改" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                timer.Restart();
                var list = TestDapper.DBsession.Query<OrmTest.Model.TestTable>("select * from TestTable where c1 <> ''");
                timer.Stop();
                Console.WriteLine("Dapper查询所有数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + list.Count());
                //---------------------------------
                count = 0;
                timer.Restart();
                for (int i = 0; i < dapperDelSql.Length; i++)
                {
                    count += TestDapper.DBsession.Execute(dapperDelSql[i], dapperDelSqlParam[i]);
                }
                timer.Stop();
                Console.WriteLine("Dapper删除" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
            }
            #endregion

            #region Hxj.Data

            if (true && testIndex < 2)
            {
                //暂时未解决第2次测试时异常
                var hxjOrmModls = Common.EntityCopy<OrmTest.Model.TestTable, Hxj.Model.TestTable>(efAddModels).ToArray();
                count = 0;
                timer.Restart();
                foreach (var hxjAddModel in hxjOrmModls)
                {
                    count += TestHxj.DBsession.Insert<Hxj.Model.TestTable>(hxjAddModel);
                }
                timer.Stop();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Hxj.Data插入" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                foreach (var hxjAddModel in hxjOrmModls)
                {
                    hxjAddModel.Attach();
                    hxjAddModel.c1 = tempValue + Guid.NewGuid();
                    hxjAddModel.c2 = tempValue + Guid.NewGuid();
                    hxjAddModel.c3 = tempValue + Guid.NewGuid();
                    hxjAddModel.c4 = tempValue + Guid.NewGuid();
                    hxjAddModel.c5 = tempValue + Guid.NewGuid();
                    hxjAddModel.c6 = tempValue + Guid.NewGuid();
                    hxjAddModel.c7 = tempValue + Guid.NewGuid();
                    hxjAddModel.c8 = tempValue + Guid.NewGuid();
                    hxjAddModel.c9 = 99999;
                    hxjAddModel.c10 = tempValue + Guid.NewGuid();
                    hxjAddModel.c11 = tempValue + Guid.NewGuid();
                    hxjAddModel.c12 = decimal.Parse("19.22");
                    hxjAddModel.c13 = tempValue + Guid.NewGuid();
                    hxjAddModel.c14 = Guid.NewGuid();
                    hxjAddModel.c15 = 123;
                    hxjAddModel.c16 = true;
                    hxjAddModel.c17 = tempValue + Guid.NewGuid();
                    hxjAddModel.c18 = DateTime.Now;
                    hxjAddModel.c19 = double.Parse("19.22");
                    hxjAddModel.c20 = tempValue + Guid.NewGuid();
                }
                count = 0;
                timer.Restart();
                foreach (var hxjAddModel in hxjOrmModls)
                {
                    count += TestHxj.DBsession.Update<Hxj.Model.TestTable>(hxjAddModel);
                }
                timer.Stop();
                Console.WriteLine("Hxj.Data修改" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                timer.Restart();
                var list2 = TestHxj.DBsession.From<Hxj.Model.TestTable>().ToList();
                timer.Stop();
                Console.WriteLine("Hxj.Data查询所有数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + list2.Count());
                //---------------------------------
                count = 0;
                timer.Restart();
                foreach (var hxjAddModel in hxjOrmModls)
                {
                    count += TestHxj.DBsession.Delete<Hxj.Model.TestTable>(hxjAddModel);
                }
                timer.Stop();
                Console.WriteLine("Hxj.Data删除" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
            }
            #endregion

            #region Dos.ORM

            if (true)
            {

                var dosOrmModls = Common.EntityCopy<OrmTest.Model.TestTable, Dos.Model.TestTable>(efAddModels);
                count = 0;
                timer.Restart();
                foreach (var dosOrmModl in dosOrmModls)
                {
                    count += DB.Context.Insert(dosOrmModl);
                }
                timer.Stop();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Dos.ORM（原Hxj.Data）插入" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                foreach (var hxjAddModel in dosOrmModls)
                {
                    hxjAddModel.c1 = tempValue + Guid.NewGuid();
                    hxjAddModel.c2 = tempValue + Guid.NewGuid();
                    hxjAddModel.c3 = tempValue + Guid.NewGuid();
                    hxjAddModel.c4 = tempValue + Guid.NewGuid();
                    hxjAddModel.c5 = tempValue + Guid.NewGuid();
                    hxjAddModel.c6 = tempValue + Guid.NewGuid();
                    hxjAddModel.c7 = tempValue + Guid.NewGuid();
                    hxjAddModel.c8 = tempValue + Guid.NewGuid();
                    hxjAddModel.c9 = 99999;
                    hxjAddModel.c10 = tempValue + Guid.NewGuid();
                    hxjAddModel.c11 = tempValue + Guid.NewGuid();
                    hxjAddModel.c12 = decimal.Parse("19.22");
                    hxjAddModel.c13 = tempValue + Guid.NewGuid();
                    hxjAddModel.c14 = Guid.NewGuid();
                    hxjAddModel.c15 = 123;
                    hxjAddModel.c16 = true;
                    hxjAddModel.c17 = tempValue + Guid.NewGuid();
                    hxjAddModel.c18 = DateTime.Now;
                    hxjAddModel.c19 = double.Parse("19.22");
                    hxjAddModel.c20 = tempValue + Guid.NewGuid();
                }
                count = 0;
                timer.Restart();
                foreach (var dosOrmModl in dosOrmModls)
                {
                    count += DB.Context.Update(dosOrmModl);
                }
                timer.Stop();
                Console.WriteLine("Dos.ORM（原Hxj.Data）修改" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
                //---------------------------------
                timer.Restart();
                var list4 = DB.Context.From<Dos.Model.TestTable>().ToList();
                timer.Stop();
                Console.WriteLine("Dos.ORM（原Hxj.Data）查询所有数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + list4.Count());
                //---------------------------------
                count = 0;
                timer.Restart();
                foreach (var dosOrmModl in dosOrmModls)
                {
                    count += DB.Context.Delete<Dos.Model.TestTable>(dosOrmModl);
                }
                timer.Stop();
                Console.WriteLine("Dos.ORM（原Hxj.Data）删除" + testCount + "条数据：" + timer.ElapsedMilliseconds + "毫秒。影响行：" + count);
            }
            #endregion

            Console.WriteLine("--------------------------------------");
            if (testIndex < 1)
            {
                testIndex++;
                goto Start;
            }
        }
    }
}
