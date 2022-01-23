using CaseManagement.Data;
using CaseManagement.Helpers;
using CaseManagement.Model;
using System.Windows.Input;

namespace CaseManagement.ViewModel
{
    internal class AddCustomerViewModel : ViewModelBase
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; OnPropertyChanged(); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }


        private string _street;
        public string Street
        {
            get { return _street; }
            set { _street = value; OnPropertyChanged(); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged(); }
        }

        private string _postcode;
        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; OnPropertyChanged(); }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; OnPropertyChanged(); }
        }

        public ICommand SaveCustomerCommand { get; set; }

        public AddCustomerViewModel()
        {
            SaveCustomerCommand = new RelayCommand((p) =>
            {
                var address = new Address()
                {
                    Street = Street,
                    City = City,
                    Postcode = Postcode,
                    Country = Country
                };

                var customer = new Customer()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Mobile = Mobile,
                    Phone = Phone,
                    Address = address
                };

                using (var context = new CaseManagementDbContext())
                {
                    context.Add(customer);
                    context.SaveChanges();
                }

                ResetForm();
            });
        }

        private void ResetForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Mobile = string.Empty;
            Phone = string.Empty;
            Street = string.Empty;
            City = string.Empty;
            Postcode = string.Empty;
            Country = string.Empty;
        }
    }
}
