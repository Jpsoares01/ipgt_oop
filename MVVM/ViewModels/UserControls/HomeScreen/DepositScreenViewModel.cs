using ipgt_oop.Core;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    class DepositScreenViewModel : ObservableObject
    {
        public ObservableCollection<Card> ListaCartoes { get; set; }

        public DepositScreenViewModel()
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
