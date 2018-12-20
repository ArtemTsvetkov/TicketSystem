using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Realization.DS.SubTypes;

namespace TicketSystem.CommonComponents.DataConverters.Realization.DS
{
    static class DataSetConverter
    {
        public static FromDsToSingle fromDsToSingle = new FromDsToSingle();
        public static FromDsToBuf fromDsToBuf = new FromDsToBuf();
    }
}