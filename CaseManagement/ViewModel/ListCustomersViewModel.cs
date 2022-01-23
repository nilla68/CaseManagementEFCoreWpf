using CaseManagement.Data;
using CaseManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CaseManagement.ViewModel
{
    internal class ListCustomersViewModel : ViewModelBase
    {
        public List<Customer> Customers { get; set; }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; OnPropertyChanged(); }
        }

        public ListCustomersViewModel()
        {
            using (var context = new CaseManagementDbContext())
            {
                Customers = context.Customers
                    .Include(c => c.Address)
                    .ToList();
            }

            SelectedCustomer = Customers.FirstOrDefault();
        }
    }
}
