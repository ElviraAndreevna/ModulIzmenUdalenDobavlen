﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ModulUdalIzmenDobav.ViewModels
{
    interface IGettingPassword
    {
        string GetPassword();
    }
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public delegate void CommandExecutedEventHandler(object obj, CommandExecutedEventArgs commandExecuted);
        public event CommandExecutedEventHandler CommandExecuted;
        protected void OnCommandExecuted(CommandExecutedResult commandExecutedResult, string errorMessage = null) =>
              CommandExecuted?.Invoke(this, new CommandExecutedEventArgs(commandExecutedResult, errorMessage));
        public event PropertyChangedEventHandler PropertyChanged;
        protected void PropertyChange([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected string _title;
        public string Title
        {
            get => _title;
            protected set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyChange();
                }
            }
        }
        public enum CommandExecutedResult
        {
            Ok,
            Error
        }
        public class CommandExecutedEventArgs : EventArgs
        {
            public CommandExecutedResult CommandExecutedResult { get; private set; }
            public string ErrorMessage { get; private set; }
            public CommandExecutedEventArgs(CommandExecutedResult commandExecutedResult, string errorMessage = null)
            {
                CommandExecutedResult = commandExecutedResult;
                ErrorMessage = errorMessage;
            }
        }
    }
}
