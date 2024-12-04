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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModulUdalIzmenDobav.ViewModels;

namespace ModulUdalIzmenDobav
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IGettingPassword
{
    public string GetPassword() => _passwordBox.Password;

    public MainWindow()
    {
        InitializeComponent();
        (DataContext as AuthorizationViewModel).GettingPassword = (IGettingPassword)this;
    }

    private void Button_click(object sender, RoutedEventArgs e)
    {
        if ((DataContext as AuthorizationViewModel).LogIn())
        {
            MessageBox.Show($"Добро пожаловать, {AuthorizationViewModel.Account.Login}");
            MWindow mWindow = new MWindow();
            mWindow. Owner = this;
            mWindow.Show();

        }
        else MessageBox.Show("Неверный логин или пароль!");
    }
}
}
