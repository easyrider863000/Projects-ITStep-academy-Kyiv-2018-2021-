using Exam.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Exam.ViewModels
{
    [Serializable]
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        bool if_desc = false;
        string value_sort = "";
        BinaryFormatter bf = new BinaryFormatter();
        void SelectMenuThemes(object o)
        {
            var menu = o as Control;
            string style = menu.Tag as string;

            var uri = new Uri("Themes/" + style + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        void PrevNextSelected(object o)
        {
            if (o == null)
                return;
            var elem = o as Control;
            string tag = elem.Tag as string;
            if (tag == "prev")
            {
                if (PhotosList.CurrentPhoto == 0)
                {
                    PhotosList.CurrentPhoto = SelectedAuto.Photos.Count;
                }
                PhotosList.CurrentPhoto--;
                SelectedAuto.CurrentPhoto = PhotosList[PhotosList.CurrentPhoto];
                Notify("SelectedPhoto");
            }
            else if (tag == "next")
            {
                if (PhotosList.CurrentPhoto + 1 == PhotosList.Count)
                {
                    PhotosList.CurrentPhoto = -1;
                }
                PhotosList.CurrentPhoto++;
                SelectedAuto.CurrentPhoto = PhotosList[PhotosList.CurrentPhoto];
                Notify("SelectedPhoto");
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand MenuThemes { get; set; }
        public ICommand PrevNextCommand { get; set; }
        public ICommand SortCommand { get; set; }
        public ICommand HowSortCommand { get; set; }
        public ICommand AddPhotoCommand { get; set; }
        public ObservableCollection<AutoModel> Autos { get; set; }
        private AutoModel _SelectedAuto { get; set; }
        public AutoModel SelectedAuto
        {
            get { return _SelectedAuto; }
            set
            {
                _SelectedAuto = value;
                PhotosList = new StoragePhoto(_SelectedAuto.Id);
                Notify("SelectedAuto");
                Notify("SelectedPhoto");
            }
        }
        public string SelectedPhoto {
            get
            {
                return SelectedAuto.CurrentPhoto.Path;
            }
            set { } }
        public ObservableCollection<CountryManufacturerModel> Manufacturers { get; set; }
        public ObservableCollection<BodyTypeModel> BodyTypes { get; set; }
        public StoragePhoto PhotosList { get; set; }
        public MainWindowViewModel()
        {
            Autos = new Cars();
            Manufacturers = new StorageCountryManufacturers();
            BodyTypes = new StorageBodyTypes();
            SelectedAuto = Autos.FirstOrDefault();
            PhotosList = new StoragePhoto(SelectedAuto.Id);
            SelectedAuto.CurrentPhoto = PhotosList[0];
            SelectedPhoto = SelectedAuto.CurrentPhoto.Path;
            AddCommand = new RelayCommand(x =>
            {
                SelectedAuto = new AutoModel(StaticCar.GetLastCarId() + 1,
                    "?", "?", new CountryManufacturerModel(0, "не выбрано"), new BodyTypeModel(0, "не выбрано"), 0, 0, 0, 0, new List<AutoPhoto>());
                Autos.Add(SelectedAuto);
            });
            RemoveCommand = new RelayCommand(x =>
            {
                if (MessageBox.Show($"Are you delete {SelectedAuto.Name} {SelectedAuto.Model} ?", "Delete record", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    using (var context = new CarsArchitecureEntities())
                    {
                        foreach (var i in context.PhotoDB)
                        {
                            if (i.CarId == SelectedAuto.Id)
                            {
                                context.PhotoDB.Remove(i);
                            }
                        }
                        if(StaticCar.Exist(SelectedAuto.Id))
                        {
                            context.CarDB.Remove(context.CarDB.SqlQuery($"select * from CarDB where Id={SelectedAuto.Id}").FirstOrDefault());
                        }
                        context.SaveChanges();
                    }
                    Autos = new Cars();
                    SelectedAuto = Autos.FirstOrDefault();
                    Notify("Autos");
                }
            }, x => SelectedAuto != null);
            SaveCommand = new RelayCommand(x =>
            {
                using (var context = new CarsArchitecureEntities())
                {
                    foreach(var i in Autos)
                    {
                        if(!StaticCar.Exist(i.Id))
                        {
                            context.CarDB.Add(new CarDB() { EngineCapacity = i.EngineCapacity, IdBodyType = StaticCar.GetBodyTypeIdByName(i.BodyType.BodyTypeName), IdCountryManufacturer = StaticCar.GetManufacturerIdByName(i.CountryManufacturer.CountryName), Mass = i.Mass, Model = i.Model, Name = i.Name, Power = i.Power, YearOfIssue = i.YearOfIssue });
                        }
                    }
                    foreach(var i in context.CarDB)
                    {
                        foreach(var j in Autos)
                        {
                            if(i.Id==j.Id)
                            {
                                i.EngineCapacity = j.EngineCapacity;
                                i.IdBodyType = StaticCar.GetBodyTypeIdByName(j.BodyType.BodyTypeName);
                                i.IdCountryManufacturer = StaticCar.GetManufacturerIdByName(j.CountryManufacturer.CountryName);
                                i.Mass = j.Mass;
                                i.Model = j.Model;
                                i.Name = j.Name;
                                i.Power = j.Power;
                                i.YearOfIssue = j.YearOfIssue;
                            }
                        }
                    }
                    context.SaveChanges();
                    Autos = new Cars();
                    Notify("Autos");
                }
            });
            PrevNextCommand = new RelayCommand(PrevNextSelected,x=>SelectedAuto!=null&&SelectedAuto.Photos.Count>=1);
            MenuThemes = new RelayCommand(SelectMenuThemes);
            SortCommand = new RelayCommand(x =>
            {
                value_sort = x.ToString();
                ObservableCollection<AutoModel> tmp;
                if (x.ToString() == "Name")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.Name.Length
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.Name.Length descending
                                                                                                                                      select word);
                }
                else if (x.ToString() == "Model")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.Model.Length
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.Model.Length descending
                                                                                                                                      select word);
                }
                else if (x.ToString() == "BodyType")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.BodyType.BodyTypeName.Length
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.BodyType.BodyTypeName.Length descending
                                                                                                                                      select word);
                }
                else if (x.ToString() == "EngineCapacity")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.EngineCapacity
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.EngineCapacity descending
                                                                                                                                      select word);
                }
                else if (x.ToString() == "Power")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.Power
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.Power descending
                                                                                                                                      select word);
                }
                else if (x.ToString() == "Mass")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.Mass
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.Mass descending
                                                                                                                                      select word);
                }
                else if (x.ToString() == "CountryManufacturer")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.CountryManufacturer.CountryName.Length
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.CountryManufacturer.CountryName.Length descending
                                                                                                                                      select word);
                }
                else if (x.ToString() == "YearOfIssue")
                {
                    tmp = (if_desc == false) ? new ObservableCollection<AutoModel>(from word in Autos
                                                                                   orderby word.YearOfIssue
                                                                                   select word) : new ObservableCollection<AutoModel>(from word in Autos
                                                                                                                                      orderby word.YearOfIssue descending
                                                                                                                                      select word);
                }
                else
                {
                    tmp = new ObservableCollection<AutoModel>();
                }
                Autos.Clear();
                foreach (var i in tmp)
                {
                    Autos.Add(i);
                }
            });
            HowSortCommand = new RelayCommand(x =>
            {
                if_desc = Convert.ToBoolean(x.ToString());
                if (value_sort != "")
                {
                    SortCommand.Execute(value_sort);
                }
            });
            AddPhotoCommand = new RelayCommand(x =>
            {
                if (!StaticCar.Exist(SelectedAuto.Id))
                {
                    MessageBox.Show("Click to save button please!");
                    return;
                }
                Stream myStream;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog().Value)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (var context = new CarsArchitecureEntities())
                        {
                            context.PhotoDB.Add(new PhotoDB() { PhotoPath = Path.GetFullPath(openFileDialog1.FileName), CarId = SelectedAuto.Id });
                            context.SaveChanges();
                        }
                        SelectedAuto.Photos.Add(new AutoPhoto(StaticPhoto.GetPhotoLastId() + 1, Path.GetFullPath(openFileDialog1.FileName)));
                        PhotosList = new StoragePhoto(SelectedAuto.Id);
                        SelectedPhoto = SelectedAuto.Photos[SelectedAuto.Photos.Count - 1].Path;
                        myStream.Close();
                    }
                }
            }, x => SelectedAuto != null);
        }

        public void Notify([CallerMemberName]string s = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
