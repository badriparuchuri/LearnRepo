using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

 

        private ObservableCollection<String> items;
        private string test;

 

        public HistoryViewModel()
        {
            items = new ObservableCollection<String>();
            sample = "default";
        }

 

        public ObservableCollection<String> history
        {
            get => items;
        }

 

        public string sample
        {
            get => test;
            set  {
                test = value;
                OnPropertyChanged("sample");
                OnPropertyChanged("test");
            }
        }
        

 

        public void saveToHistory(String item) {
            items.Add(item);
            OnPropertyChanged("history");
            OnPropertyChanged();
        }

 

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

 

    }
 
}
