using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess
{
    public static class DatabaseHelper
    {
        #region Connections
        public static readonly SqlConnectionStringBuilder HCMaster = new SqlConnectionStringBuilder { DataSource = "3.131.105.103", InitialCatalog = "smartHealthMasterV2", UserID = "MasterDB", Password = "MasterDB" };
        public static readonly SqlConnectionStringBuilder HCOrganization = new SqlConnectionStringBuilder { DataSource = "3.131.105.103", InitialCatalog = "smartHealthAgencyV2", UserID = "AgencyDB", Password = "AgencyDB" };
        #endregion

        #region Store Procedures


        #region Master Organization
        public const string sp_GetMasterOrganization = "Org_GetMasterOrganization";
        public const string sp_InsertMasterOrganization = "Org_InsertMasterOrganization";

        #endregion
        #region Organization
        public const string sp_InsertOrganization = "Org_InsertOrganization";
        public const string sp_InsertOrUpdateSMTPDetails = "Org_SaveOrUpdateSMTPDetails";
        public const string sp_GetOrganizationDetailsByBusinessName = "Org_GetOrganizationDetailsByBusinessName";
 
        #endregion
        #region User

        public const string sp_InsertOrUpdateUser = "InsertOrUpdateUser";
        public const string sp_GetUsersDetailsByOrganizationId = "GetUsersDetailsByOrganizationId";
        public const string sp_GetStaffUsers = "STF_GetStaffUsers";

        #region Staff

        public const string sp_InsertOrUpdateStaff = "SaveOrUpdateStaff";

        public const string sp_VerifyStaffAlreadyExists = "VerifyStaffAlreadyExists";

        #endregion
        #endregion
        #region Roles
        public const string sp_InsertOrUpdateUserRole = "InsertUserRole";
        #endregion

        #region Payroll
        public const string sp_GetPayrollGroupDropdown = "PRL_GetPayrollGroupDropdown";
        #endregion
        #endregion
    }
}
