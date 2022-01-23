using CaseManagement.Data;
using CaseManagement.Model;
using System;
using System.Linq;

namespace CaseManagement.ViewModel
{
    internal class CaseViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        private string _headline;
        public string Headline
        {
            get { return _headline; }
            set { _headline = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        private DateTime _created;
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; OnPropertyChanged(); }
        }

        private DateTime _modified;
        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; OnPropertyChanged(); }
        }

        private Status _status;
        public Status Status
        {
            get { return _status; }
            set
            {
                _status = value;
                Modified = DateTime.Now;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Modified));

                using (var context = new CaseManagementDbContext())
                {
                    var selectedCase = context.Cases.FirstOrDefault(c => c.Id == Id);
                    if (selectedCase != null)
                    {
                        selectedCase.Status = _status;
                        selectedCase.Modified = Modified;
                        context.SaveChanges();
                    }
                }
            }
        }

        public string Fullname
        {
            get { return $"{_customer.FirstName} {_customer.LastName}"; }
        }

        private string _administrator;
        public string Administrator
        {
            get { return _administrator; }
            set { _administrator = value; OnPropertyChanged(); }
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(); }
        }

        public CaseViewModel(Case selectedCase)
        {
            Id = selectedCase.Id;
            Headline = selectedCase.Headline;
            Description = selectedCase.Description;
            _status = selectedCase.Status;
            Created = selectedCase.Created;
            Modified = selectedCase.Modified;
            Administrator = selectedCase.Administrator;
            Customer = selectedCase.Customer;
        }
    }
}
