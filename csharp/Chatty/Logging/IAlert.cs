using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatty.Logging
{
    public interface IAlert
    {
        void Alert(string title, string sender, string message, MessageBoxIcon messageBoxIcon);
        void Alert(string title, string message, MessageBoxIcon messageBoxIcon);
    }
}
