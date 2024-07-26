using smartHealthApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Common.AppMessenger
{
    public class AppMessage
    {
        public AppMessageType MessageType { get; set; }
        public object MessageData { get; set; }
    }
}
