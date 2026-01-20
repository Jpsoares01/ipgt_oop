using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.Login
{
    internal class ManualEntryFormViewModel : ObservableObject
    {
        // para username
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        // para password
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public ICommand OpenHomeWindowCommand { get; }

        public event EventHandler RequestHomeWindow;

        public ManualEntryFormViewModel() 
        {
            /*OpenHomeWindowCommand = new RelayCommand(
                o => RequestHomeWindow?.Invoke(this, EventArgs.Empty),
                o => true
                );*/

            OpenHomeWindowCommand = new RelayCommand(o => FazerLogin(),o => true);
        }

        // para pop up
        public event EventHandler<string> RequestPopup;

        private async void FazerLogin()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                //colocar pop up
                RequestPopup?.Invoke(this, "Preencha todos os campos!");
                return;
            }


            var api = new ApiService();
            bool loginSucesso = await api.LoginAsync(Username, Password);

            if (loginSucesso)
            {
                RequestHomeWindow?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // colocar pop up 
                RequestPopup?.Invoke(this, "Utilizador ou Password incorretos!");
               
            }
        }


    }
}
