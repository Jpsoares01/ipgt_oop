using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    
    class WithdrawScreenViewModel
    {
        public ObservableCollection<Card> ListaCartoes { get; set; }

        public WithdrawScreenViewModel()
        {
            ListaCartoes = new ObservableCollection<Card>();
            CarregarCartoes();
        }
        
        private async void CarregarCartoes()
        {
            var api = new ApiService();

            var cartoes = await api.GetCardsAsync();

            ListaCartoes.Clear();
            foreach (var cartao in cartoes)
            {
                ListaCartoes.Add(cartao);
            }

            if (ListaCartoes.Count == 0)
            {
                // colocar pop up
                MessageBox.Show("Nenhum cartão encontrado!"); 
            }
        }
    }
}
