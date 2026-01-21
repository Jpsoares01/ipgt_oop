using System.Windows;
using System.Windows.Input;
using ipgt_oop.Core;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.Popups;

public class ChangePasswordViewModel : ObservableObject
{
    public ICommand ChangePasswordCommand { get; }
    
    private string _username;
    public string Username
    {
        get => _username;
        set {_username = value; OnPropertyChanged(); }
    }
    
    private string _password;
    public string Password
    {
        get => _password;
        set {_password = value; OnPropertyChanged(); }
    }
    
    private string _newPassword;
    public string NewPassword
    {
        get => _newPassword;
        set {_newPassword = value; OnPropertyChanged(); }
    }

    public ChangePasswordViewModel()
    {
        ChangePasswordCommand = new RelayCommand(o => ChangePassword(), o => true);
    }

    public async void ChangePassword()
    {
        var api = new ApiService();
        bool changePasswordSuccess =  await api.ChangeClientPassword(Username, Password,  NewPassword);

        if (changePasswordSuccess)
        {
            MessageBox.Show("Password changed successfully");
        }
        else
        {
            MessageBox.Show("Password change failed");
        }
    }
    
}