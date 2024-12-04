using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModulUdalIzmenDobav.ViewModels;

namespace ModulUdalIzmenDobav.Services
{
    interface INavigationService<T> where T : ViewModelBase
    {
        void ShowView(T viewModel);
        event EventHandler ClosedView;
    }
}
