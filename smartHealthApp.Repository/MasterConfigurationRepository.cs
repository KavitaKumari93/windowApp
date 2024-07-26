using smartHealthApp.DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Repository
{
    public class MasterConfigurationRepository
    {
        public IEnumerable<MasterConfigurationModel> GetConfigurationDetails()
        {
            return new MasterConfigurationModel().GetConfigurationDetails() ;
        }

    }
}
