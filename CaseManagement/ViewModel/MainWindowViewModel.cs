using CaseManagement.Helpers;
using System.Windows.Input;

namespace CaseManagement.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand ShowHomeViewCommand { get; set; }
        public ICommand ShowAddCaseViewCommand { get; set; }
        public ICommand ShowAddCustomerViewCommand { get; set; }
        public ICommand ShowListCustomersViewCommand { get; set; }
        public ICommand ShowListCasesViewCommand { get; set; }

        public MainWindowViewModel()
        {
            CurrentView = new HomeViewModel();

            ShowHomeViewCommand = new RelayCommand(p => CurrentView = new HomeViewModel());
            ShowAddCaseViewCommand = new RelayCommand(p => CurrentView = new AddCaseViewModel());
            ShowAddCustomerViewCommand = new RelayCommand(p => CurrentView = new AddCustomerViewModel());
            ShowListCustomersViewCommand = new RelayCommand(p => CurrentView = new ListCustomersViewModel());
            ShowListCasesViewCommand = new RelayCommand(p => CurrentView = new ListCasesViewModel());
        }
    }
}