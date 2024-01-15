using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02_SimpleDocument
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        // Указывает изменился ли документ с момента открытия.
        private bool isDirty = false;
        string FName;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = false;
        }

        private void OpenCommand(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = false;
        }

        private void SaveAsCommand(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = false;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = false;
        }


        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            isDirty = true;
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Делаем элементы связанные с командой Save активными или не активными.
            // WPF самостоятельно решает, когда вызывать этот метод (например, перемещение фокуса, выполнение команды)
            // Вызов этого обработчика может происходить достаточно часто, поэтому в нем не желательно использовать код с длительным временем выполнения.
            e.CanExecute = isDirty;
            // Для того, что бы принудительно вызвать CanExecute для всех команд, нужно вызвать метод CommandManager.InvalidateRequerySuggested();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                FName = ofd.FileName;
                TextRange doc = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            isDirty = false;
            if (FName != null)
            {
                TextRange doc = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                using (FileStream fs = File.Create(FName))
                {
                    isDirty = true;
                    if (System.IO.Path.GetExtension(FName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(FName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
                isDirty = false;
                if (sfd.ShowDialog() == true)
                {
                    isDirty = true;
                    TextRange doc = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                    using (FileStream fs = File.Create(sfd.FileName))
                    {
                        if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                            doc.Save(fs, DataFormats.Rtf);
                        else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                            doc.Save(fs, DataFormats.Text);
                        else
                            doc.Save(fs, DataFormats.Xaml);
                    }
                }
            }
        }
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            isDirty = false;
            if (sfd.ShowDialog() == true)
            {
                isDirty = true;
                TextRange doc = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!isDirty)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void SaveAs_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!isDirty)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            TextRange doc = new TextRange(txt.Document.ContentStart, txt.Document.ContentEnd);
            doc.Text = "";
            FName = null;
        }
    }
}
