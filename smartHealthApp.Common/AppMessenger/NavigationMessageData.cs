using smartHealthApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Common.AppMessenger
{
    public class NavigationMessageData
    {
        public NavigationPages NavigationTarget { get; set; }
        public Dictionary<String, Object> NavigationData { get; set; }
        public Transition? Transition { get; set; }
    }
}
