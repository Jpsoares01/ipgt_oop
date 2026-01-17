using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Collections.ObjectModel; 
using ipgt_oop.MVVM.Models;           
using ipgt_oop.Services;              

namespace ipgt_oop.MVVM.ViewModels
{
    internal class RegistryViewModel : ObservableObject
    {

        public ObservableCollection<Bank> BankList { get; set; }

        public RegistryViewModel()
        {
            BankList = new ObservableCollection<Bank>();

            LoadBanks();
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
