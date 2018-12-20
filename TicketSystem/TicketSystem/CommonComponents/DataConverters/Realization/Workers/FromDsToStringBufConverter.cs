using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.DataConverters.Exceptions;
using TicketSystem.CommonComponents.Interfaces;

namespace TicketSystem.CommonComponents.DataConverters.Realization.Workers
{
    class FromDsToStringBufConverter : DataConverter<DataSet, string[]>
    {
        public string[] convert(DataSet ds)
        {
            try
            {
                string[] newData = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    newData[i] = ds.Tables[0].Rows[i][0].ToString();
                }
                return newData;
            }
            catch (Exception ex)
            {
                throw new СonversionError();
            }
        }
    }
}
