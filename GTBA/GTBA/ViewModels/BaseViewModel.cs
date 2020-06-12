using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using GTBA.Models;
using GTBA.Services;
using GTBA.Services.Interfaces;
using System.Collections.ObjectModel;

namespace GTBA.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
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

        private ObservableCollection<string> tags = new ObservableCollection<string>();
        public ObservableCollection<string> Tags
        {
            get { return tags; }
            set { SetProperty(ref tags, value); }
        }

        public Command SortCommand { get; set; }
        public Command DeleteTagCommand { get; set; }

        #endregion

        public void ExecuteDeleteTagCommand(string tag)
        {
            Tags.Remove(tag);
        }

        public string SerializeTags()
        {
            String str = "";
            for (int i = 0; i < Tags.Count; i++)
            {
                str += Tags[i];
                // Do not append comma at the end of last element
                if (i < Tags.Count - 1)
                {
                    str += "#";
                }
            }
            return str;
        }

        #region SetProperty
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
