﻿using FS.Core.Data;
using FS.Core.Infrastructure;

namespace FS.Core.Client.MySql.SqlBuilder
{
    public sealed class SqlOper : Common.SqlBuilder.SqlOper
    {
        /// <summary>
        /// 查询支持的SQL方法
        /// </summary>
        /// <param name="queueManger">队列管理模块</param>
        /// <param name="queue">包含数据库SQL操作的队列</param>
        public SqlOper(BaseQueueManger queueManger, Queue queue) : base(queueManger, queue) { }

        public override Queue InsertIdentity<TEntity>(TEntity entity)
        {
            base.InsertIdentity(entity);
            Queue.Sql.AppendFormat("SELECT @@IDENTITY;");
            return Queue;
        }
    }
}