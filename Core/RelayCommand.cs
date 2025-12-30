using System;
using System.Windows.Input;

namespace mp_anapp.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> _executeAction;
        private Func<object, bool> _canExecuteFunc;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecuteFunc == null || _canExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
