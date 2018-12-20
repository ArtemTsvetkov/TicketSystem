using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.PopupWindow;

namespace TicketSystem.CommonComponents.WorkWithDataBase.Exceptions
{
    class DatabaseQueryError : Exception
    {
        public DatabaseQueryError() : base() { }

        public DatabaseQueryError(string message) : base(message) {
            processing(this);
        }

        public void processing(Exception ex)
        {
            SimplePopupWindow.showMessage("Синтаксическая ошибка в запросе к БД");
        }
    }
}
