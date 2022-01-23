using CaseManagement.Model;

namespace CaseManagement.ViewModel
{
    internal class CustomerViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(); }
        }

        public CustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            FullName = $"{customer.FirstName} {customer.LastName}";
        }
    }
}
