using Calculator.Models;
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

namespace Calculator.ViewModels
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<HistoryModel> historyOfItems;
        private string tst;
        private DatabaseService db;

        public HistoryViewModel(DatabaseService historyDatabase)
        {
            historyOfItems = new ObservableCollection<HistoryModel>();
            db = historyDatabase;
            sample = "default";
            _ = initData();
        }

        public async Task initData()
        {
            var res = await db.GetItemsAsync();
            historyOfItems = new ObservableCollection<HistoryModel>();
            res.ForEach(historyOfItems.Add);
        }

        public ObservableCollection<HistoryModel> history
        {
            get => historyOfItems;
        }

        public string sample
        {
            get => tst;
            set
            {
                tst = value;
                OnPropertyChanged("sample");
                OnPropertyChanged("tst");
            }
        }


        public async void saveToHistory(string item)
        {
            HistoryModel historyModel = new HistoryModel();
            historyModel.expression = item;
            await db.SaveItemAsync(historyModel);
            await initData();
            OnPropertyChanged("history");
            OnPropertyChanged();
        }

        

        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
