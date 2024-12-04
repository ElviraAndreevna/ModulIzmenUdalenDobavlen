using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ModulUdalIzmenDobav.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public Account Account { get; private set; }
        public ObservableCollection<ViewModelBase> ViewModelsCollection { get; private set; }
        private ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                if (_selectedViewModel != value)
                {
                    _selectedViewModel = value;
                    _selectedViewModel = value;
                    PropertyChange();
                }
            }
        }

        public MainWindowViewModel()
        {
            Account = AuthorizationViewModel.Account;
            ViewModelsCollection = new ObservableCollection<ViewModelBase>();
            ViewModelsCollection.Add(new CatalogAnketViewModel());
            if (Account.AccountType.ID_AccountType !=1)
                ViewModelsCollection.Add(new StubOneViewModel ());
            if (Account.AccountType.ID_AccountType ==2)
                ViewModelsCollection.Add (new StubTwoViewModel ());
            SelectedViewModel = ViewModelsCollection[0];
            {

            }

        }
    }
}
