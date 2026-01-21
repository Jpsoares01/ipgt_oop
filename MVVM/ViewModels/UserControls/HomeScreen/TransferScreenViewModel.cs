using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ipgt_oop.Core;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    class TransferScreenViewModel : ObservableObject
    {
        public ObservableCollection<Card> ListaCartoes { get; set; }
        private Card _sourceCard;
        public Card SourceCard
        {
            get { return _sourceCard; }
            set {_sourceCard = value; OnPropertyChanged();}
        }
        
        private string _recipientCard;
        public string RecipientCard
        {
            get { return _recipientCard; }
            set {_recipientCard = value; OnPropertyChanged();}
        }
        
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
        
        public ICommand TransferCommand { get; set; }

        public TransferScreenViewModel()
        {
            TransferCommand = new RelayCommand(MakeTransfer, o => true);
            ListaCartoes = new ObservableCollection<Card>();
            CarregarCartoes();
        }
        
        private async void MakeTransfer(object obj)
        {

            if (SourceCard == null)
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

            var newTransaction = new TransactionRequest
            {
                scrId = SourceCard.id,
                dstCardNumber = RecipientCard, 
                amount = Amount,
                entity = 0,            
                reference = "Transfer"
            };

            
            var api = new ApiService();
            bool success = await api.TransactionAsync(newTransaction);

            // 4. Verificar o resultado
            if (success)
            {
                // colocar popup
                MessageBox.Show("Transferencia realizado com sucesso! 💰");
                Amount = 0; // Limpar o campo do valor
            }
            else
            {
                // colocar pop up
                MessageBox.Show("Falha ao transferir. Tente novamente (Provavelmente Recipient Card Number dont exist).");
            }
        }
        
        private async void CarregarCartoes()
        {
            var api = new ApiService();

            var cartoes = await api.GetCardsAsync();

            SourceCard = cartoes[0];
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
