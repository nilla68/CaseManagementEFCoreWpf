using CaseManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CaseManagement.ViewModel
{
    internal class ListCasesViewModel : ViewModelBase
    {
        private List<CaseViewModel> _cases;
        public List<CaseViewModel> Cases
        {
            get { return _cases; }
            set { _cases = value; OnPropertyChanged(); }
        }

        private CaseViewModel _selectedCase;
        public CaseViewModel SelectedCase
        {
            get { return _selectedCase; }
            set { _selectedCase = value; OnPropertyChanged(); }
        }

        public ListCasesViewModel()
        {
            using (var context = new CaseManagementDbContext())
            {
                Cases = context.Cases
                    .Include(c => c.Customer)
                    .Select(c => new CaseViewModel(c))
                    .ToList();
            }

            SelectedCase = Cases.FirstOrDefault();
        }
    }
}
