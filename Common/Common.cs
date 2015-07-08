#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Common
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：周浩
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/6 16:21:51
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrmTest
{
    public class Common
    {
        public static TResult EntityCopy<TResult>(object input)
        {
            if (input == null)
            {
                return default(TResult);
            }
            if (input.GetType() == typeof(TResult))
            {
                return (TResult)input;
            }
            return (TResult)EntityCopy(input, typeof(TResult));
        }

        public static List<TResult> EntityCopy<TEntity, TResult>(IList<TEntity> input)
        {
            return input.Select(entity => EntityCopy<TResult>(entity)).ToList();
        }

        private static object EntityCopy(object input, Type targetType)
        {
            var objResult = Activator.CreateInstance(targetType);
            var properties = targetType.GetProperties();
            var type = input.GetType();
            foreach (var info in properties)
            {
                if (!info.CanWrite) continue;
                var property = type.GetProperty(info.Name);
                if (property == null) continue;
                var objTemp = property.GetValue(input, null);
                info.SetValue(objResult, objTemp, null);
            }
            return objResult;
        }
    }
}
