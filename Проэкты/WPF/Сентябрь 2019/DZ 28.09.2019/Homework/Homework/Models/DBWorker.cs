using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Homework.Models
{
    class DBWorker:INotifyPropertyChanged
    {
        string connectionString;
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        DataTable table;
        private string _nameDB;
        public DBWorker(string nameDB)
        {
            _nameDB = nameDB;
            connectionString = ConfigurationManager.ConnectionStrings["ShopAdoConnectionString"].ConnectionString;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public DataTable LoadData()
        {
            connection = new SqlConnection(connectionString);
                dataAdapter = new SqlDataAdapter($"select * from {_nameDB}", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.InsertCommand = builder.GetInsertCommand();
                dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                dataAdapter.DeleteCommand = builder.GetDeleteCommand();
                table = new DataTable();
                dataAdapter.Fill(table);

            connection.Close();
            OnPropertyChanged();
            return table;
        }
        public void Save(DataTable dataTable)
        {
            table = dataTable;
            connection.Open();
            dataAdapter.Update(table);
            connection.Close();
        }
    }
}
