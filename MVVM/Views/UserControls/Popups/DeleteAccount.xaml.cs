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
using YourApp.Helpers;

namespace ipgt_oop.MVVM.Views.UserControls.Popups
{
    /// <summary>
    /// Lógica interna para DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : Window
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }

        private void TogglePassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordHelper.TogglePasswordVisibility(
                PasswordBox,
                PasswordTextBox,
                PasswordButtonImage,
                (ImageSource)FindResource("PasswordEye"),
                (ImageSource)FindResource("PasswordEyeCrossed"));
        }

        private void ToggleConfPassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordHelper.TogglePasswordVisibility(
                ConfPasswordBox,
                ConfPasswordTextBox,
                ConfPasswordButtonImage,
                (ImageSource)FindResource("PasswordEye"),
                (ImageSource)FindResource("PasswordEyeCrossed"));
        }
    }
}
