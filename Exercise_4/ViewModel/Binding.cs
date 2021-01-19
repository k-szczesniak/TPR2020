﻿using System;
using System.Windows.Input;

namespace ViewModel
{
    public class Binding : ICommand
    {
        private readonly Action action;
        public event EventHandler CanExecuteChanged;

        public Binding(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
