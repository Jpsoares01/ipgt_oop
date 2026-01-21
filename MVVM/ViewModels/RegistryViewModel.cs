using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using ipgt_oop.MVVM.Models;           
using ipgt_oop.Services;              

namespace ipgt_oop.MVVM.ViewModels
{
    internal class RegistryViewModel : ObservableObject
    {
        private string _userName;
        public string Username 
        { 
            get => _userName;
            set {_userName = value; OnPropertyChanged(); }
        }
        
        private int _selectedBank;
        public int SelectedBank
        {
            get => _selectedBank;
            set {_selectedBank = value; OnPropertyChanged(); }
        }
        
        private string _cardNumber;
        public string CardNumber
        {
            get => _cardNumber;
            set {_cardNumber = value; OnPropertyChanged(); }
        }
        
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        
        public ICommand CreateClientCommand { get; }

        public ObservableCollection<Bank> BankList { get; set; }

        public RegistryViewModel()
        {
            BankList = new ObservableCollection<Bank>();
            //CreateClientCommand = new RelayCommand(CreateClient);
            
            CreateClientCommand = new RelayCommand(CreateClient, o => true);
            
            LoadBanks();
        }

        public async void CreateClient(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            
            
            var api = new ApiService();
            api.CreateClient(Username, Password, _selectedBank, CardNumber);
        }

        private async void LoadBanks()
        {
            var api = new ApiService();

            var banks = await api.GetBanksAsync();
            foreach (var bank in banks)
            {
                BankList.Add(bank);
            }

        }
    }
}
