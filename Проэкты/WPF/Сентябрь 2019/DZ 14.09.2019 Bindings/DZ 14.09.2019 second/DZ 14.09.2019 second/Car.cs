using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DZ_14._09._2019_second
{
    class Car:INotifyPropertyChanged
    {
        private string _title;
        private string _color;
        private int _year;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                Notify();
            }
        }
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                Notify();
            }
        }
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                Notify();
            }
        }
        protected void Notify([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
