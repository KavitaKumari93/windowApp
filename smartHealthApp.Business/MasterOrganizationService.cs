using smartHealthApp.DataAccess.Repository.Organization;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Business
{
    public class MasterOrganizationService
    {
        private MasterOrganizationRepository masterOrganizationRepository;
        public MasterOrganizationService()
        {
            masterOrganizationRepository = new MasterOrganizationRepository();
        }
       
    }
}
