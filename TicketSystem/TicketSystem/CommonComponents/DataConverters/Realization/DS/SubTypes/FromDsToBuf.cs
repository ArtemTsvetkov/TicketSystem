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
    class FromDsToBuf
    {
        public DataConverter<DataSet, string[]> toStringBuf =
            new FromDsToStringBufConverter();
        public DataConverter<DataSet, int[]> toIntBuf =
            new FromDsToIntBufConverter();
    }
}
