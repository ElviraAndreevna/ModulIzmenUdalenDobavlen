using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ModulUdalIzmenDobav.Services;

namespace ModulUdalIzmenDobav.ViewModels
{
    class AddEditNedvizhViewModel : ViewModelBase
    {
        public List<Obekt_nedvizhimosti> Obekt_Nedvizhimostis { get; private set; }
        public List<Tip_nedvizhimosti> Tip_Nedvizhimostis { get; private set; }

        private Obekt_nedvizhimosti _obekt_Nedvizhimosti;
        public Obekt_nedvizhimosti Obekt_nedvizhimosti
        {
            get => _obekt_Nedvizhimosti;
            set
            {
                if (_obekt_Nedvizhimosti != value)
                {
                    _obekt_Nedvizhimosti = value;
                    PropertyChange();
                }
            }
        }

        public AddEditNedvizhViewModel(Obekt_nedvizhimosti obekt_Nedvizhimosti = null)
        {
            if (obekt_Nedvizhimosti == null)
            {
                Obekt_nedvizhimosti = new Obekt_nedvizhimosti();
                _isAddNedvizh = true;
                Title = "Добавить";
            }
            else
            {
                Obekt_nedvizhimosti = obekt_Nedvizhimosti;
                Title = "Редактировать";
            }
            Tip_Nedvizhimostis = DataBase.GetContext().Tip_nedvizhimosti.ToList();
        }


        private bool _isAddNedvizh;
        private Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(
                      obj =>
                      {
                          if (_isAddNedvizh)
                          {
                              DataBase.GetContext().Obekt_nedvizhimosti.Add(Obekt_nedvizhimosti);
                              _isAddNedvizh = false;
                          }
                          try
                          {
                              DataBase.SaveChanges();
                              OnCommandExecuted(CommandExecutedResult.Ok);
                          }
                          catch (Exception ex)
                          {
                              OnCommandExecuted(CommandExecutedResult.Error, ex.Message);
                          }
                      }));
            }

        }
    }
}
