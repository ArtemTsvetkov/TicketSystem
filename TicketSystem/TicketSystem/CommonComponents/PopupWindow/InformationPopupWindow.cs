using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem.CommonComponents.PopupWindow
{
    class InformationPopupWindow
    {
        private InformationPopupWindowConfig config;

        public void setConfig(InformationPopupWindowConfig config)
        {
            this.config = config;
        }

        public void show()
        {
            MessageBox.Show(
                config.getMessage(),
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
