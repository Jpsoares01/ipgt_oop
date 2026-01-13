using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels.UserControls.Login
{
    internal class ManualEntryFormViewModel : ObservableObject
    {
        public ICommand OpenHomeWindowCommand { get; }
        private HomeWindow _HomeWindow;

        public event EventHandler RequestHomeWindow;

        public ManualEntryFormViewModel() 
        {
            OpenHomeWindowCommand = new RelayCommand(
                o => RequestHomeWindow?.Invoke(this, EventArgs.Empty),
                o => true                                          
                );
        }
    }
}
