﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.Interfaces;

namespace TicketSystem.CommonComponents.WorkWithDataBase.SqlLite
{
    static class SqlLiteSimpleExecute
    {
        public static DataSet execute(string query)
        {
            DataWorker<SqlLiteStateFields, DataSet> dataWorker = new SqlLiteDataWorker();
            SqlLiteStateFields configProxy =
                new SqlLiteStateFields(query);
            dataWorker.setConfig(configProxy);
            dataWorker.execute();
            return dataWorker.getResult();
        }
    }
}
