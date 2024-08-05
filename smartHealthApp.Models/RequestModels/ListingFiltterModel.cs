using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models.RequestModels
{
    public class ListingFiltterModel : FilterModel
    {
        public string SearchKey { get; set; } = string.Empty;
        public string StartWith { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string LocationIDs { get; set; } = string.Empty;
        public string IsActive { get; set; }
        public string RoleIds { get; set; } = string.Empty;
    }
}
