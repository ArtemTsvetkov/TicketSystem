using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Realization.Workers;
using TicketSystem.CommonComponents.Interfaces;

namespace TicketSystem.CommonComponents.DataConverters.Realization.DS.SubTypes
{
    class FromDsToSingle
    {
        public DataConverter<DataSet, int> toInt = new FromDataSetToIntDataConverter();
        public DataConverter<DataSet, string> toString = new FromDataSetToString();
    }
}