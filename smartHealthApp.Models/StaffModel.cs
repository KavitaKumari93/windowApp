using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using smartHealthApp.Models.MasterEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class StaffModel:BaseEntity.BaseEntityModel
    {
        
        private int _staffID;
        public int StaffID
        {
            get { return _staffID; }
            set { _staffID = value; OnPropertyChanged(); }
        }

        private string _name;
        public string Name
        {
            get { return this.FirstName + " " + this.MiddleName + " " + this.LastName; }
            set { _name = value; OnPropertyChanged(); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }

        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; OnPropertyChanged(); }
        }

        private string _lastName;
        
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }


        private int? _gender;
        public int? Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged(); }
        }

        private DateTime _dob;
        public DateTime DOB
        {
            get { return _dob; }
            set { _dob = value; OnPropertyChanged(); }
        }

        private DateTime _doj;
        public DateTime DOJ
        {
            get { return _doj; }
            set { _doj = value; OnPropertyChanged(); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private int? _maritalStatus;
        public int? MaritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; OnPropertyChanged(); }
        }

        private string _npiNumber;
        public string NPINumber
        {
            get { return _npiNumber; }
            set { _npiNumber = value; OnPropertyChanged(); }
        }

        private string _taxId;
        public string TaxId
        {
            get { return _taxId; }
            set { _taxId = value; OnPropertyChanged(); }
        }

       
        public string UserName { get; set; }
       
        public string Password { get; set; }

        private int _roleId;
        public int RoleID
        {
            get { return _roleId; }
            set { _roleId = value; OnPropertyChanged(); }
        }

       
        public string RoleName { get; set; }

        private string _photoPath;
        public string PhotoPath
        {
            get { return _photoPath; }
            set { _photoPath = value; OnPropertyChanged(); }
        }

       
        public string PhotoBase64 { get; set; }

        private string _photoThumbnailPath;
        public string PhotoThumbnailPath
        {
            get { return _photoThumbnailPath; }
            set { _photoThumbnailPath = value; OnPropertyChanged(); }
        }

        private int _userId;
        public int UserID
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged(); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged(); }
        }

        private int? _stateId;
        public int? StateID
        {
            get { return _stateId; }
            set { _stateId = value; OnPropertyChanged(); }
        }

        private int? _countryId;
        public int? CountryID
        {
            get { return _countryId; }
            set { _countryId = value; OnPropertyChanged(); }
        }

        private string _zip;
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; OnPropertyChanged(); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(); }
        }
        private bool _isRenderingProvider;
        public bool IsRenderingProvider
        {
            get { return _isRenderingProvider; }
            set { _isRenderingProvider = value; OnPropertyChanged(); }
        }

        private string _caqhId;
        public string CAQHID
        {
            get { return _caqhId; }
            set { _caqhId = value; OnPropertyChanged(); }
        }

        private string _language;
        public string Language
        {
            get { return _language; }
            set { _language = value; OnPropertyChanged(); }
        }

        private int _organizationId;
        public int OrganizationID
        {
            get { return _organizationId; }
            set { _organizationId = value; OnPropertyChanged(); }
        }

        private int? _employeeTypeId;
        public int? EmployeeTypeID
        {
            get { return _employeeTypeId; }
            set { _employeeTypeId = value; OnPropertyChanged(); }
        }

        private DateTime? _terminationDate;
        public DateTime? TerminationDate
        {
            get { return _terminationDate; }
            set { _terminationDate = value; OnPropertyChanged(); }
        }

        private string _ssn;
        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; OnPropertyChanged(); }
        }

        private int? _payrollGroupId;
        public int? PayrollGroupID
        {
            get { return _payrollGroupId; }
            set { _payrollGroupId = value; OnPropertyChanged(); }
        }

        private double? _latitude;
        public double? Latitude
        {
            get { return _latitude; }
            set { _latitude = value; OnPropertyChanged(); }
        }

        private double? _longitude;
        public double? Longitude
        {
            get { return _longitude; }
            set { _longitude = value; OnPropertyChanged(); }
        }

        private string _apartmentNumber;
        public string ApartmentNumber
        {
            get { return _apartmentNumber; }
            set { _apartmentNumber = value; OnPropertyChanged(); }
        }

        private int? _degreeId;
        public int? DegreeID
        {
            get { return _degreeId; }
            set { _degreeId = value; OnPropertyChanged(); }
        }

        private string _employeeId;
        public string EmployeeID
        {
            get { return _employeeId; }
            set { _employeeId = value; OnPropertyChanged(); }
        }

        private decimal _payRate;
        public decimal PayRate
        {
            get { return _payRate; }
            set { _payRate = value; OnPropertyChanged(); }
        }


        //public string DegreeName
        //{
        //    get
        //    {
        //        try
        //        {
        //            return MasterDegree?.DegreeName;
        //        }
        //        catch (Exception)
        //        {
        //            return string.Empty;
        //        }
        //    }
        //    set { }
        //}

       
        private bool _isBlock;
        public bool IsBlock
        {
            get { return _isBlock; }
            set { _isBlock = value; OnPropertyChanged(); }
        }
        public string GenderName { get; set; }

       
        public List<StaffLocationModel> StaffLocationList { get; set; }
       
        public List<StaffTeamModel> StaffTeamList { get; set; }
       
        public List<StaffTagsModel> StaffTagsModel { get; set; }

        public OrganizationModel Organization { get; set; }
        public MasterGenderModel MasterGender { get; set; }
        public MasterCountryModel MasterCountry { get; set; }
        public MasterStateModel MasterState { get; set; }
        public List<StaffTagsModel> StaffTags { get; set; }
       // public virtual MasterDegree MasterDegree { get; set; }
        public UserRoleModel UserRoles { get; set; }
        public UserModel UserObj { get; set; }
        public List<StaffLocationModel> StaffLocation { get; set; }
        public List<StaffTeamModel> StaffTeam { get; set; }
    }

}

