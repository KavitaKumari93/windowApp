using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models.MasterEntity
{
    public class MasterCountryModel
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string value { get { return this.CountryName; } set { this.CountryName = value; } }
        public int? OrganizationID { get; set; }
        public virtual OrganizationModel Organization { get; set; }
    }
}
