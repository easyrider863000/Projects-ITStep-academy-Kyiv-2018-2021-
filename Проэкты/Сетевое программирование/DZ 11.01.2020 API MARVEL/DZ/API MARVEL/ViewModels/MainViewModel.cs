using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_MARVEL.Models;
using API_MARVEL.Infrastructure;
using System.Windows.Input;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace API_MARVEL.ViewModels
{
    class MainViewModel:INotifyPropertyChanged
    {
        public ICommand UpdateCommand { get; set; }
        public int MaxOffset { get; set; }
        public int MaxCount { get; set; }
        private int _currentOffset;
        private int _currentCount;
        public int CurrentOffset
        {
            get
            {
                return _currentOffset;
            }
            set
            {
                _currentOffset = value;
                Notify();
            }
        }
        public int CurrentCount
        {
            get { return _currentCount; }
            set
            {
                _currentCount = value;
                Notify();
            }
        }
        public ObservableCollection<MarvelCharacter> Characters { get; set; }
        MarvelManager marvelManager;
        public MainViewModel()
        {
            if (API_MARVEL.Models.APIConfig.PrivateKey == "")
            {
                AutorizationView window2 = new AutorizationView();
                window2.ShowDialog();
                AutorizationViewModel objectVM = window2.DataContext as AutorizationViewModel;
                APIConfig.PrivateKey = objectVM.PrivateKey;
                APIConfig.PublicKey = objectVM.PublicKey;
            }
            marvelManager = new MarvelManager();
            CurrentOffset = 100;
            CurrentCount = 1290;
            LoadCharacters(CurrentCount, CurrentOffset);
            UpdateCommand = new RelayCommand(x =>
            {
                CurrentCount = Convert.ToInt32(x.ToString().Split(' ')[0]);
                CurrentOffset = Convert.ToInt32(x.ToString().Split(' ')[1]);
                if (CurrentOffset > 0 && CurrentOffset <= MaxOffset && (CurrentCount + CurrentOffset) <= MaxCount && CurrentCount > 0)
                {
                    LoadCharacters(CurrentCount, CurrentOffset);
                }
                else
                {
                    MessageBox.Show("Entry data is not correct");
                }
            });
        }

        public async void LoadCharacters(int fst, int cnt)
        {
            Characters = new ObservableCollection<MarvelCharacter>(await marvelManager.GetCharacters(fst, cnt));
            Notify("Characters");
            MaxOffset = marvelManager.Limit;
            MaxCount = marvelManager.Total;
            Notify("MaxCount");
            Notify("MaxOffset");
        }




        public void Notify([CallerMemberName]string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
