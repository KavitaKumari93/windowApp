using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models.MasterEntity
{
    public class MasterStateModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string value { get { return this.StateName; } set { this.StateName = value; } }
        public string StateAbbr { get; set; }
        public int? CountryID { get; set; }
        public decimal? StandardTime { get; set; }
        public decimal? DaylightSavingTime { get; set; }
        public string TimeZoneName { get; set; }
        public virtual MasterCountryModel MasterCountry { get; set; }
        public int? OrganizationID { get; set; }
        public virtual OrganizationModel Organization { get; set; }
    }
}
