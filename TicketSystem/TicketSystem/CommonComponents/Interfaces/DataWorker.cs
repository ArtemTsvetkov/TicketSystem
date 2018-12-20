using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.CommonComponents.Interfaces
{
    interface DataWorker<TStateWithConfigFields, TStorage>
    {
        void setConfig(TStateWithConfigFields fields);
        void execute();
        bool connect();
        TStorage getResult();
    }
}
