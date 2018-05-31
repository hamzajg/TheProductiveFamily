using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheProductiveFamily.ViewModels
{
    public class BasePageVM : INotifyPropertyChanged
    {
        public BasePageVM()
        {
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
