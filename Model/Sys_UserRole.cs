﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.0
//     Support: http://www.cnblogs.com/huxj
//     Website: http://www.ITdos.com/
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace DataAccess.Entities
{

    /// <summary>
    /// 实体类Sys_UserRole 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_UserRole : Entity
    {
        public Sys_UserRole() : base("Sys_UserRole") { }

        #region Model
        private Guid _ID;
        private Guid _UserId;
        private Guid _RoleName;
        private DateTime _CreateTime;
        private Guid? _ClassId;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserId
        {
            get { return _UserId; }
            set
            {
                this.OnPropertyValueChange(_.UserId, _UserId, value);
                this._UserId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid RoleName
        {
            get { return _RoleName; }
            set
            {
                this.OnPropertyValueChange(_.RoleName, _RoleName, value);
                this._RoleName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set
            {
                this.OnPropertyValueChange(_.CreateTime, _CreateTime, value);
                this._CreateTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid? ClassId
        {
            get { return _ClassId; }
            set
            {
                this.OnPropertyValueChange(_.ClassId, _ClassId, value);
                this._ClassId = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
				_.ID};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ID,
				_.UserId,
				_.RoleName,
				_.CreateTime,
				_.ClassId};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._UserId,
				this._RoleName,
				this._CreateTime,
				this._ClassId};
        }
        /// <summary>
        /// 给当前实体赋值
        /// </summary>
        public override void SetPropertyValues(IDataReader reader)
        {
            this._ID = DataUtils.ConvertValue<Guid>(reader["ID"]);
            this._UserId = DataUtils.ConvertValue<Guid>(reader["UserId"]);
            this._RoleName = DataUtils.ConvertValue<Guid>(reader["RoleName"]);
            this._CreateTime = DataUtils.ConvertValue<DateTime>(reader["CreateTime"]);
            this._ClassId = DataUtils.ConvertValue<Guid?>(reader["ClassId"]);
        }
        /// <summary>
        /// 给当前实体赋值
        /// </summary>
        public override void SetPropertyValues(DataRow row)
        {
            this._ID = DataUtils.ConvertValue<Guid>(row["ID"]);
            this._UserId = DataUtils.ConvertValue<Guid>(row["UserId"]);
            this._RoleName = DataUtils.ConvertValue<Guid>(row["RoleName"]);
            this._CreateTime = DataUtils.ConvertValue<DateTime>(row["CreateTime"]);
            this._ClassId = DataUtils.ConvertValue<Guid?>(row["ClassId"]);
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "Sys_UserRole");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "Sys_UserRole", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserId = new Field("UserId", "Sys_UserRole", "UserId");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field RoleName = new Field("RoleName", "Sys_UserRole", "RoleName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field CreateTime = new Field("CreateTime", "Sys_UserRole", "CreateTime");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ClassId = new Field("ClassId", "Sys_UserRole", "ClassId");
        }
        #endregion


    }
}

