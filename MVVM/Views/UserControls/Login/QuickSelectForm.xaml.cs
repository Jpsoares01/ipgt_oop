using ipgt_oop.MVVM.ViewModels.UserControls.Login;
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

namespace ipgt_oop.MVVM.Views.UserControls.Login
{
    /// <summary>
    /// Interaction logic for QuickSelectForm.xaml
    /// </summary>
    public partial class QuickSelectForm : UserControl
    {
        public event EventHandler RequestHomeWindow;
        private HomeWindow _HomeWindow;

        public QuickSelectForm()
        {
            InitializeComponent();
            var vm = new QuickSelectFormViewModel();
            DataContext = vm;

            vm.RequestHomeWindow += OpenHomeWindow;
        }

        private void OpenHomeWindow(object sender, EventArgs e)
            {
                if (_HomeWindow == null)
                {
                    _HomeWindow = new HomeWindow();
                    _HomeWindow.Closed += (s, e) => _HomeWindow = null;
                    _HomeWindow.Show();

                    CloseWindow();
                }
                else
                {
                    if (_HomeWindow.WindowState == WindowState.Minimized)
                        _HomeWindow.WindowState = WindowState.Normal;

                    _HomeWindow.Activate();
                    CloseWindow();
                }
            }

            private void CloseWindow()
            {
                Window parentWindow = Window.GetWindow(this);
                parentWindow?.Close();
            }
    }
}
