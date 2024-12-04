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
using ModulUdalIzmenDobav.Services;

namespace ModulUdalIzmenDobav
{
    /// <summary>
    /// Логика взаимодействия для Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        public TypeDialog TypeDialog { get; set; }
        public Dialog(string message, string caption = "Диалоговое окно", TypeDialog typeDialog = TypeDialog.InfoType)
        {
            TypeDialog = typeDialog;
            InitializeComponent();
            _messageTextBlock.Text = message;
            _captionTextBlock.Text = caption;
            if (typeDialog == TypeDialog.InfoType || typeDialog == TypeDialog.ErrorType)
            {
                Button button = new Button();
                button.Click += OkButton_Click;
                if (typeDialog == TypeDialog.InfoType)

                    button.Style = (Style)this.Resources["infoStyleButton"];

                else button.Style = (Style)this.Resources["errorStyleButton"];
                _contentСontrol.Content = button;
            }
            else
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                Button buttonYes = new Button();
                buttonYes.Style = (Style)this.Resources["yesConfStyleButton"];
                buttonYes.Click += YesButton_Click;

                Button buttonNo = new Button();
                buttonNo.Style = (Style)this.Resources["noConfStyleButton"];
                buttonNo.Click += NoButton_Click;

                stackPanel.Children.Add(buttonYes);
                stackPanel.Children.Add(buttonNo);
                _contentСontrol.Content = stackPanel;
            }
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = null;
            this.Close();
        }
    }
}
