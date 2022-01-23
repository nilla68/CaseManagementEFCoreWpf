using CaseManagement.Data;
using CaseManagement.Helpers;
using CaseManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CaseManagement.ViewModel
{
    internal class AddCaseViewModel : ViewModelBase
    {
        public List<CustomerViewModel> Customers { get; set; }

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

        private CustomerViewModel _selectedCustomer;
        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; OnPropertyChanged(); }
        }

        private DateTime _created;
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; OnPropertyChanged(); }
        }

        private string _administrator;
        public string Administrator
        {
            get { return _administrator; }
            set { _administrator = value; OnPropertyChanged(); }
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
            set { _status = value; OnPropertyChanged(); }
        }

        public ICommand SaveNewCaseCommand { get; set; }

        public AddCaseViewModel()
        {
            using (var context = new CaseManagementDbContext())
            {
                Customers = context.Customers
                    .Select(c => new CustomerViewModel(c))
                    .ToList();
            }

            SaveNewCaseCommand = new RelayCommand(c =>
            {
                var newCase = new Case()
                {
                    Headline = Headline,
                    Description = Description,
                    Created = Created,
                    Modified = Modified,
                    Administrator = Administrator,
                    Status = Status,
                    CustomerId = SelectedCustomer.Id
                };

                using (var context = new CaseManagementDbContext())
                {
                    context.Cases.Add(newCase);
                    context.SaveChanges();
                }

                ResetForm();
            });

            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        private void ResetForm()
        {
            Headline = string.Empty;
            Description = string.Empty;
            SelectedCustomer = null;
            Created = DateTime.Now;
            Administrator = string.Empty;
            Modified = DateTime.Now;
            Status = Status.New;
        }
    }
}