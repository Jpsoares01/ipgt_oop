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
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    class DepositScreenViewModel : ObservableObject
    {
        public ObservableCollection<Card> ListaCartoes { get; set; }

        //cartõ escolhido

        private Card _selectedCard;
        public Card SelectedCard
        {
            get { return _selectedCard; }
            set {_selectedCard = value; OnPropertyChanged();
            }
        }

        // valor do deposito 
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        // comando para botao depositar
        public ICommand DepositarCommand { get; set; }

        

        public DepositScreenViewModel()
        {
            ListaCartoes = new ObservableCollection<Card>();
            CarregarCartoes();

            // Inicializa o comando (Assumindo que tens RelayCommand no teu Core)
            DepositarCommand = new RelayCommand(FazerDeposito, o => true);
        }

        private async void FazerDeposito(object obj)
        {

            if (SelectedCard == null)
            {
                MessageBox.Show("ERRO: O programa acha que não escolheste cartão nenhum (SelectedCard está null)!");
                return;
            }

            // 2. Verificar se o Valor falhou
            if (Amount <= 0)
            {
                MessageBox.Show($"ERRO: O programa acha que o valor é {Amount} (Zero ou negativo)!");
                return;
            }

            var novaTransacao = new TransactionRequest
            {
                scrId = -1,
                dstCardNumber = SelectedCard.number, 
                amount = Amount,
                entity = 0,            
                reference = "Depósito"
            };

            
            var api = new ApiService();
            bool sucesso = await api.RealizarTransacaoAsync(novaTransacao);

            // 4. Verificar o resultado
            if (sucesso)
            {
                // colocar popup
                MessageBox.Show("Depósito realizado com sucesso! 💰");
                Amount = 0; // Limpar o campo do valor
            }
            else
            {
                // colocar pop up
                MessageBox.Show("Falha ao depositar. Tente novamente.");
            }
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
                    
        }

    }
}
