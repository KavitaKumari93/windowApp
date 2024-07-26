using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class StaffTeamModel
    {
        public int id { get; set; }
        public int staffid { get; set; }
        public int staffteamid { get; set; }
        public bool isdeleted { get; set; }
    }
}
