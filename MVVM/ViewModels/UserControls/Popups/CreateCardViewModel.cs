using System.Collections.ObjectModel;
using System.Windows.Input;
using ipgt_oop.Core;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.Popups;

public class CreateCardViewModel : ObservableObject
{
    public ObservableCollection<Bank> BankList { get; set; }
    public ICommand CreateCardCommand { get; }
    
    private Bank _selectedBank;
    public Bank SelectedBank
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

    public CreateCardViewModel()
    {
        BankList = new ObservableCollection<Bank>();
        CreateCardCommand = new RelayCommand(o => CreateCard(), o => true);
        LoadBanks();
    }


    public async void CreateCard()
    {
        Console.WriteLine($"{SelectedBank.id} - {CardNumber}");
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