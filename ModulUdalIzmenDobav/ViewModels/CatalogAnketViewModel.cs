using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;
using ModulUdalIzmenDobav.Services;

namespace ModulUdalIzmenDobav.ViewModels
{
    class CatalogAnketViewModel : ViewModelBase
    {
        public ObservableCollection<SectionFilter> SectionFilters { get; private set; }
        public string SearchString { get; set; } = "";
        IDialogService _dialogService;
        public CatalogAnketViewModel()
        {
            Title = "Каталог анкет";
            _dialogService = ServiceContainer.Instance.GetService<IDialogService>();
            Obekt_nedvizhimostis = new ObservableCollection<Obekt_nedvizhimosti>();
            SectionFilters = new ObservableCollection<SectionFilter>(DataBase.GetContext().Obekt_nedvizhimosti.Select(p=>p.Kolichestvo_komnat).Where(p=>p !=null).Distinct().Select(p => new SectionFilter() { Kolichestvo_komnat = (int)p }));
            if (AuthorizationViewModel.Account.ID_Account == 2)
                ArchivistAccess = true;
            UpdateClientList();
        }
        public ObservableCollection<Obekt_nedvizhimosti> Obekt_nedvizhimostis { get; private set; }
        public Obekt_nedvizhimosti SelectedItem { get;set; }
        public void UpdateClientList()
        {
            try
            {
                Obekt_nedvizhimostis.Clear();
                List<int> sections = SectionFilters.Where(p => p.IsChecked).Select(p => p.Kolichestvo_komnat).ToList();
                List<Obekt_nedvizhimosti> nedvizhimostis = DataBase.GetContext().Obekt_nedvizhimosti.ToList();
                CountAllElements = nedvizhimostis.Count;
                //Поиск
                if (!String.IsNullOrWhiteSpace(SearchString))
                    nedvizhimostis = nedvizhimostis.Where(p => p.Adres.Contains(SearchString.Trim())).ToList();
                if (sections.Count != 0)
                {
                    nedvizhimostis = nedvizhimostis.Where(p => sections.Contains((int)p.Kolichestvo_komnat)).ToList();
                    ResetFilterActive = true;
                }
                else ResetFilterActive = false;
                switch (SelectedSort)
                {
                    case 0:
                        nedvizhimostis = nedvizhimostis.OrderBy(p => p.Stoimost).ToList();
                        break;
                    case 1:
                        nedvizhimostis = nedvizhimostis.OrderByDescending(p => p.Stoimost).ToList();
                        break;
                    case 2:
                        nedvizhimostis = nedvizhimostis.OrderByDescending(p => p.Ploshchad).ToList();
                        break;
                    case 3:
                        nedvizhimostis = nedvizhimostis.OrderBy(p => p.Ploshchad).ToList();
                        break;
                    case 4:
                        nedvizhimostis = nedvizhimostis.OrderBy(p => p.Kolichestvo_komnat).ToList();
                        break;
                    case 5:
                        nedvizhimostis = nedvizhimostis.OrderByDescending(p => p.Kolichestvo_komnat).ToList();
                        break;
                }
                CurrentCountElements = nedvizhimostis.Count;
                if (nedvizhimostis.Count != 0)
                {
                    foreach (Obekt_nedvizhimosti obekt_Nedvizhimosti in nedvizhimostis)
                        Obekt_nedvizhimostis.Add(obekt_Nedvizhimosti);
                }
                else _dialogService?.ShowDialog("По вашему запросу ничего не найдено", "Результаты поиска", TypeDialog.InfoType);
            }
            catch (Exception e)
            {
                _dialogService?.ShowDialog(e.Message, $"Ошибка {e.HResult}", TypeDialog.ErrorType);
            }
        }
        private bool _archivistAccess = false;
        public bool ArchivistAccess
        {
            get => _archivistAccess;
            private set
            {
                if (value != _archivistAccess)
                {
                    _archivistAccess = value;
                    PropertyChange();
                }
            }
        }

        private bool _resetFilterActive = false;
        public bool ResetFilterActive
        {
            get => _resetFilterActive;
            private set
            {
                if (value != _resetFilterActive)
                {
                    _resetFilterActive = value;
                    PropertyChange();
                }
            }
        }

        public void ResetFilters()
        {
            ResetFilterActive = false;
            foreach (SectionFilter sectionFilter in SectionFilters)
                sectionFilter.IsChecked = false;
            UpdateClientList();
        }

        public int SelectedSort { get; set; } = 0;
        private int _currentCountElements = 0;
        private int _countAllElements = 0;
        public int CurrentCountElements
        {
            get => _currentCountElements;
            private set
            {
                if (_currentCountElements != value)
                {
                    _currentCountElements = value;
                    PropertyChange("CurrentCountElements");
                }
            }
        }
        public int CountAllElements
        {
            get => _countAllElements;
            set
            {
                if (_countAllElements != value)
                {
                    _countAllElements = value;
                    PropertyChange("CountAllElements");
                }
            }
        }
        private bool _administratorAccess = false;
        public bool AdministartorAccess
        {
            get => _administratorAccess;
            private set
            {
                if (value != _administratorAccess)
                {
                    _administratorAccess = value;
                    PropertyChange();
                }
            }
        }
        private Command _removecommand;
        public Command RemoveCommand
        {
            get
            {
                return _removecommand ?? (_removecommand = new Command(
                      obj =>
                      {
                          DialogResult dialogResult = _dialogService.ShowDialog("Вы действительно хотите удалить объект из базы данных?",
                              "Подтверждение", TypeDialog.ConfirmationType);
                          if (dialogResult == DialogResult.Yes)
                          {
                              Obekt_nedvizhimosti obekt_Nedvizhimosti = obj as Obekt_nedvizhimosti;
                              DataBase.GetContext().Obekt_nedvizhimosti.Remove(obekt_Nedvizhimosti);
                              DataBase.SaveChanges();
                              UpdateClientList();
                          }
                      },obj => obj != null));
            }
        }

        INavigationService<AddEditNedvizhViewModel> _navigationService = ServiceContainer.Instance.GetService<INavigationService<AddEditNedvizhViewModel>>();
        private Command _editCommand;
        public Command EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new Command(obj =>
                {
                    _navigationService.ShowView(new AddEditNedvizhViewModel(obj as Obekt_nedvizhimosti));
                    _navigationService.ClosedView += (o, e) => UpdateClientList();
                }, obj => obj != null));
            }
        }
        private Command _addCommand;
        public Command AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(obj =>
                {
                    _navigationService.ShowView(new AddEditNedvizhViewModel());
                    _navigationService.ClosedView += (o, e) => UpdateClientList();
                }));
            }
        }
    }
}
