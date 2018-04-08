using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty.Utilities
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string sender, string message);
    }
}
