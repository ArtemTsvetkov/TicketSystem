using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.TSystem.Exceptions
{
    class ParentNodeMustBeCalcFirst : Exception
    {
        public ParentNodeMustBeCalcFirst() : base() { }

        public ParentNodeMustBeCalcFirst(string message) : base(message) {
            processing(this);
        }

        public void processing(Exception ex)
        {
            
        }
    }
}
