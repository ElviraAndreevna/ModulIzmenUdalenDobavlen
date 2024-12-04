using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ModulUdalIzmenDobav.ViewModels.ViewModelBase;

namespace ModulUdalIzmenDobav
{
    /// <summary>
    /// Логика взаимодействия для AddEditNedwizhWindow.xaml
    /// </summary>
    public partial class AddEditNedwizhWindow : Window
    {
        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    TextBox tB = sender as TextBox;
        //    foreach (Task a in lB.Items)
        //    {
        //        if ($"{a.Naimenovanie} {a.Stoimost}".Contains(tB.Text))
        //            ((ListBoxItem)lB.ItemContainerGenerator.ContainerFromItem(a)).Visibility = Visibility.Visible;
        //        else ((ListBoxItem)lB.ItemContainerGenerator.ContainerFromItem(a)).Visibility = Visibility.Hidden;
        //    }
        //}
        private void AddEditClientWindow_CommandExecuted(object obj, CommandExecutedEventArgs commandExecuted)
        {
            if (commandExecuted.CommandExecutedResult == CommandExecutedResult.Ok)
                Close();
            else Services.ServiceContainer.Instance.GetService<Services.IDialogService>()
                        .ShowDialog(commandExecuted.ErrorMessage, "Ошибка выполнения", Services.TypeDialog.ErrorType);
        }
        public AddEditNedwizhWindow()
        {
            InitializeComponent();
        }


    }
}
