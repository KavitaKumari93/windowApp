using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models.MasterEntity
{
    public class MasterGenderModel
    {
        public int GenderID { get; set; }
        public string Gender { get; set; }
        public string value { get { return this.Gender; } set { this.Gender = value; } }
        public int? OrganizationID { get; set; }
        public virtual OrganizationModel Organization { get; set; }
    }
}
