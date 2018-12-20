using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.CommonComponents.PopupWindow;

namespace TicketSystem.CommonComponents.DataConverters.Exceptions
{
    class СonversionError : Exception
    {
        public СonversionError() : base() { }

        public СonversionError(string message) : base(message) {
            processing(this);
        }

        public void processing(Exception ex)
        {
            SimplePopupWindow.showMessage("Ошибка преобразования типов. Обратитесь к администратору.");
        }
    }
}
