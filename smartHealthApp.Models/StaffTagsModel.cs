using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class StaffTagsModel
    {
        public int Id { get; set; }
        public int StaffID { get; set; }
        public int TagID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
