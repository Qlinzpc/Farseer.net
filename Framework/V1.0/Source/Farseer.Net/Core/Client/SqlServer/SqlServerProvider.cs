﻿using System.Data.Common;
using FS.Core.Client.SqlServer.SqlBuilder;
using FS.Core.Data;
using FS.Core.Infrastructure;

namespace FS.Core.Client.SqlServer
{
    public class SqlServerProvider : DbProvider
    {
        public override DbProviderFactory GetDbProviderFactory
        {
            get { return DbProviderFactories.GetFactory("System.Data.SqlClient"); }
        }

        public override IBuilderSqlQuery CreateBuilderSqlQuery(BaseQueueManger queueManger, Queue queue)
        {
            switch (queueManger.ContextMap.ContextProperty.DataVer)
            {
                case "2000": return new SqlQuery2000(queueManger, queue);
            }
            return new SqlQuery(queueManger, queue);
        }

        public override IBuilderSqlOper CreateBuilderSqlOper(BaseQueueManger queueManger, Queue queue)
        {
            return new SqlOper(queueManger, queue);
        }
    }
}
