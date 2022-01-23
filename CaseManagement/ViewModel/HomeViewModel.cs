using CaseManagement.Data;
using CaseManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CaseManagement.ViewModel
{
    internal class HomeViewModel : ViewModelBase
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

        private int _numberOfNewCases;
        public int NumberOfNewCases
        {
            get { return _numberOfNewCases; }
            set { _numberOfNewCases = value; OnPropertyChanged(); }
        }

        private int _numberOfOngoingCases;
        public int NumberOfOngoingCases
        {
            get { return _numberOfOngoingCases; }
            set { _numberOfOngoingCases = value; OnPropertyChanged(); }
        }

        private int _numberOfClosedCases;
        public int NumberOfClosedCases
        {
            get { return _numberOfClosedCases; }
            set { _numberOfClosedCases = value; OnPropertyChanged(); }
        }

        public HomeViewModel()
        {
            using (var context = new CaseManagementDbContext())
            {
                Cases = context.Cases
                    .Include(c => c.Customer)
                    .OrderByDescending(c => c.Created)
                    .Take(10)
                    .Select(c => new CaseViewModel(c))
                    .ToList();

                NumberOfNewCases = context.Cases
                    .Where(c => c.Status == Status.New)
                    .Count();

                NumberOfOngoingCases = context.Cases
                    .Where(c => c.Status == Status.Ongoing)
                    .Count();

                NumberOfClosedCases = context.Cases
                    .Where(c => c.Status == Status.Closed)
                    .Count();
            }

            SelectedCase = Cases.FirstOrDefault();
        }
    }
}