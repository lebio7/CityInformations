using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInformationsApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Members
        private bool isGoBack = false;
        #endregion

        #region Properties
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public ICommand GoBack { get; private set; }

        #endregion

        public BaseViewModel()
        {
            GoBack = new Command(
            execute: () =>
            {
                isGoBack = true;
                GoBackCommand();
            },
            canExecute: () =>
            {
                return !isGoBack;
            });
        }

        public async void GoBackCommand()
        {
           await Shell.Current.Navigation.PopAsync();
        }

        #region NotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #endregion
    }
}
