using smartHealthApp.Common;
using smartHealthApp.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class MasterOrganizationModel : BaseEntityModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        private string _organizationName;
        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; OnPropertyChanged(); }
        }

        private string _businessName;
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        private string _address1;
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; OnPropertyChanged(); }
        }

        private string _apartmentNumber;
        public string ApartmentNumber
        {
            get { return _apartmentNumber; }
            set { _apartmentNumber = value; OnPropertyChanged(); }
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

        private string _zip;
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; OnPropertyChanged(); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }

        private int? _countryId;
        public int? CountryID
        {
            get { return _countryId; }
            set { _countryId = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; OnPropertyChanged(); }
        }



        private string _logo;
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; OnPropertyChanged(); }
        }
        private string _contactPersonFirstName;
        public string ContactPersonFirstName
        {
            get { return _contactPersonFirstName; }
            set { _contactPersonFirstName = value; OnPropertyChanged(); }
        }

        private string _contactPersonMiddleName;
        public string ContactPersonMiddleName
        {
            get { return _contactPersonMiddleName; }
            set { _contactPersonMiddleName = value; OnPropertyChanged(); }
        }

        private string _contactPersonLastName;
        public string ContactPersonLastName
        {
            get { return _contactPersonLastName; }
            set { _contactPersonLastName = value; OnPropertyChanged(); }
        }

        private string _contactPersonPhoneNumber;
        public string ContactPersonPhoneNumber
        {
            get => _contactPersonPhoneNumber;
            set { _contactPersonPhoneNumber = value; OnPropertyChanged(); }
        }

        
    }
   
}


