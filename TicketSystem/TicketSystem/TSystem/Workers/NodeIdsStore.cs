using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.TSystem.Workers
{
    static class NodeIdsStore
    {
        public static int[] getNodeIds()
        {
            int[] result = new int[10];
            result[0] = 1;
            result[1] = 5;
            result[2] = 9;
            result[3] = 13;
            result[4] = 17;
            result[5] = 21;
            result[6] = 25;
            result[7] = 29;
            result[8] = 33;
            result[9] = 37;

            return result;
        }
    }
}
