using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.InitialyzerComponent;

namespace TicketSystem.CommonComponents.WorkWithDataBase.SqlLite
{
    class SqlLiteStateFields
    {
        private string dbPath;
        private string query;

        public SqlLiteStateFields(string query)
        {
            dbPath = ConfigReader.getInstance().getDbPath();
            this.query = query;
        }

        public string getDbPath()
        {
            return dbPath;
        }

        public string getQuery()
        {
            return query;
        }
    }
}
