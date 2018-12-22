using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.TSystem
{
    static class QueryConfigurator
    {
        public static string getNodeProbabilitys(int nodeId)
        {
            return "select object_id from Objects_references r where reference in (select " +
                "object_id	 from Objects_references where reference = "+nodeId+" and attr_id=1)"+
                " and attr_id=4";
        }

        public static string getNodeName(int nodeId)
        {
            return "select name from Objects where id="+nodeId;
        }

        public static string getNodeItems(int nodeId)
        {
            return "select object_id from Objects_references where reference = "+nodeId+
                " and attr_id=1";
        }

        public static string getNodeItemName(int nodeItemId)
        {
            return "select name from Objects where id="+nodeItemId;
        }

        public static string getProbabilityitems(int probabilityId)
        {
            return "select reference from Objects_references where attr_id=5 and object_id="+
                probabilityId;
        }

        public static string getProbabilityCurrentItemId(int probabilityId)
        {
            return "select reference from Objects_references where attr_id=4 and object_id="+
                probabilityId;
        }

        public static string getProbabilityValue(int probabilityId)
        {
            return "select value from parameters where attr_id=6 and object_id="+
                probabilityId;
        }
    }
}
