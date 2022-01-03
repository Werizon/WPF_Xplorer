﻿using System;
using System.Windows.Input;


namespace WPF_Xplorer.ViewModels.Commands
{
    public class RelayCommand : ICommand//BaseCommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged // из-за BaseCommand коментим, там реализован
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
            // canExecute?.Invoke(parameter) ?? true
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
