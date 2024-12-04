using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ModulUdalIzmenDobav.Services;
using ModulUdalIzmenDobav.ViewModels;

namespace ModulUdalIzmenDobav
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceContainer.Instance.AddService<INavigationService<AddEditNedvizhViewModel>>
(new WindowNavigationService<AddEditNedvizhViewModel, AddEditNedwizhWindow>());
            base.OnStartup(e);
            ServiceContainer.Instance.AddService<IDialogService>(new DialogService());
        }
    }
}
