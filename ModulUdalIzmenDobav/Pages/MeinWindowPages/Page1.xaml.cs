using System.Windows;
using System.Windows.Controls;
using ModulUdalIzmenDobav.ViewModels;

namespace ModulUdalIzmenDobav.Pages.MeinWindowPages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>

    public partial class Page1 : Page
    {
        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => (DataContext as CatalogAnketViewModel)?.UpdateClientList();
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) => (DataContext as CatalogAnketViewModel).UpdateClientList();
        private void ResetFilterButton_Click(object sender, RoutedEventArgs e) => (DataContext as CatalogAnketViewModel).ResetFilters();
        private void Filter_Checked(object sender, RoutedEventArgs e) => (DataContext as CatalogAnketViewModel).UpdateClientList();
        private void Filter_UnCehcked(object sender, RoutedEventArgs e)
        {
            if ((DataContext as CatalogAnketViewModel).ResetFilterActive == true)
                (DataContext as CatalogAnketViewModel).UpdateClientList();
        }
        public Page1()
        {
            InitializeComponent();
        }

    }
}
