using System.Collections.ObjectModel;

namespace MyModels
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateBirthday { get; set; }
        public string INN { get; set; }
        public OrderStatus Status { get; set; }
        public Education Educ { get; set; }
        public MaitalStatus Maitial { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        private ObservableCollection<Person> _personsList = null;
        public ObservableCollection<Person> PersonsList
        {
            get
            {
                if (_personsList != null)
                {
                    return _personsList;
                }

                _personsList = new ObservableCollection<Person>();

                _personsList.Add(new Person()
                {
                    FirstName = "Jhon",
                    LastName = "Doe",
                    Status = OrderStatus.InProgress,
                    Educ = Education.Higher,
                    Maitial = MaitalStatus.Maried
                });

                _personsList.Add(new Person()
                {
                    FirstName = "Kent",
                    LastName = "Elgas",
                    Status = OrderStatus.InProgress,
                    Educ = Education.Higher,
                    Maitial = MaitalStatus.Maried
                });

                _personsList.Add(new Person()
                {
                    FirstName = "Rea",
                    LastName = "Ostrom",
                    Status = OrderStatus.Delivered,
                    Educ = Education.SecondaryEd,
                    Maitial = MaitalStatus.UnMaried
                });

                _personsList.Add(new Person()
                {
                    FirstName = "Lupe",
                    LastName = "Campen",
                    Status = OrderStatus.InProgress,
                    Educ = Education.SecondarySpecializedEd,
                    Maitial = MaitalStatus.UnMaried
                });

                return _personsList;
            }
        }
    }
}
