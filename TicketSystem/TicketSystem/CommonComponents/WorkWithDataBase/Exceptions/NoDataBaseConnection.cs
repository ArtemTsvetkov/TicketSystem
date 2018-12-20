using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.PopupWindow;

namespace TicketSystem.CommonComponents.WorkWithDataBase.Exceptions
{
    class NoDataBaseConnection : Exception
    {
        public NoDataBaseConnection() : base() { }

        public NoDataBaseConnection(string message) : base(message) {
            processing(this);
        }

        public void processing(Exception ex)
        {
            SimplePopupWindow.showMessage("Нет соединения с базой данных!");
        }
    }
}