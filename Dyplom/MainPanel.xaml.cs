using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Dyplom.Models;
using System.Data.Entity;
using Microsoft.Win32;
using ExcelDataReader;
using System.Data;

namespace Dyplom
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainPanel : Window
    {
        ModelContext db;
        private string FileName = string.Empty;
        private DataTableCollection tableCollection = null;
        public MainPanel()
        {
            InitializeComponent();

            db = new ModelContext();
            studentInfoGrid.Items.Clear();
            db.Students.Load();
            studentInfoGrid.ItemsSource = db.Students.Local.ToBindingList();

            db.Classes.Load();

            this.Closing += MainWindow_Closing;

        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            db.Students.Load();
            studentInfoGrid.ItemsSource = db.Students.Local.ToBindingList();
        }
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            MessageBox.Show("Обновление базы данных прошло успешно!", "Уведомление от системы");
            db.Students.Load();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (studentInfoGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < studentInfoGrid.SelectedItems.Count; i++)
                {
                    Students student = studentInfoGrid.SelectedItems[i] as Students;
                    if (student != null)
                    {
                        db.Students.Remove(student);
                        MessageBox.Show("Удаление записи из базы данных прошло успешно!", "Уведомление от системы");
                    }
                }
            }
            db.SaveChanges();
        }
        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            ModelContext db;

            db = new ModelContext();
            switch (findComboBox.SelectedIndex)
            {
                case (0):
                    {
                        db.Students.Where(s => s.studentName.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (1):
                    {
                        //db.Students.Where(s => s.Birthdate.Contains(findTextBox.Text)).Load();
                        //MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (2):
                    {
                        db.Students.Where(s => s.homeAdressReg.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (3):
                    {
                        db.Students.Where(s => s.homeAdressRel.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (4):
                    {
                        db.Students.Where(s => s.studentTel.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (5):
                    {
                        db.Students.Where(s => s.motherName.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (6):
                    {
                        db.Students.Where(s => s.motherPlaceOfWork.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (7):
                    {
                        db.Students.Where(s => s.motherWorkPhone.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (8):
                    {
                        db.Students.Where(s => s.motherMobPhone.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (9):
                    {
                        db.Students.Where(s => s.fatherName.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (10):
                    {
                        db.Students.Where(s => s.fatherPlaceOfWork.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (11):
                    {
                        db.Students.Where(s => s.fatherWorkPhone.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (12):
                    {
                        db.Students.Where(s => s.fatherMobPhone.Contains(findTextBox.Text)).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
            }
            switch (childInvalidComboBox.SelectedIndex)
            {
                case (0):
                    {
                        db.Students.Where(s => s.isChildInvalit == true).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        //db.StudentsInfo.Local.Where(s => s.isChildInvalit == true);
                        break;
                    }
                case (1):
                    {
                        db.Students.Where(s => s.isChildInvalit == false).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (2):
                    {
                        db.Students.Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
            }
            switch (childOPFRComboBox.SelectedIndex)
            {
                case (0):
                    {
                        db.Students.Where(s => s.isChildWithOPFR == true).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (1):
                    {
                        db.Students.Where(s => s.isChildWithOPFR == false).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (2):
                    {
                        db.Students.Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
            }
            switch (childincustodyComboBox.SelectedIndex)
            {
                case (0):
                    {
                        db.Students.Where(s => s.childInCustody == true).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (1):
                    {
                        db.Students.Where(s => s.childInCustody == false).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (2):
                    {
                        db.Students.Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
            }
            switch (childinFosterCareComboBox.SelectedIndex)
            {
                case (0):
                    {
                        db.Students.Where(s => s.isChildInFosterCare == true).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (1):
                    {
                        db.Students.Where(s => s.isChildInFosterCare == false).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (2):
                    {
                        db.Students.Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
            }
            switch (childRegisteredComboBox.SelectedIndex)
            {
                case (0):
                    {
                        db.Students.Where(s => s.isChildRegistered == true).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (1):
                    {
                        db.Students.Where(s => s.isChildRegistered == false).Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
                case (2):
                    {
                        db.Students.Load();
                        MessageBox.Show("Поиск записи в базе данных прошло успешно!", "Уведомление от системы");
                        break;
                    }
            }
            studentInfoGrid.ItemsSource = db.Students.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void importExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            //OpenExcelImportMenu();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL файлы(*.xltm;*.xlsx)|*.xltm;*.xlsx" + "|Все файлы (*.*)|*.* ";
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    FileName = openFileDialog.FileName;

                    OpenExcelFile(FileName);
                }

                else
                {
                    throw new Exception("Файл не выбран!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OpenExcelFile(string path)
        {
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            tableCollection = db.Tables;

            ExcelImportListComboBox.Items.Clear();

            foreach (DataTable table in tableCollection)
            {
                ExcelImportListComboBox.Items.Add(table.TableName);
            }
            ExcelImportListComboBox.SelectedIndex = 0;




        }
        private void exportExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenExcelExportMenu();
        }

        private void OpenExcelExportMenu()
        {
            ExcelImportPanel excelImport = new ExcelImportPanel();
            excelImport.Owner = this;
            excelImport.Show();
        }

        private void classesShowBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExcelImportListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable table = tableCollection[Convert.ToString(ExcelImportListComboBox.SelectedItem)];

            studentInfoGrid.DataContext = table;
        }

        /*private void OpenExcelImportMenu()
        {
            ExcelExportPanel excelExport = new ExcelExportPanel();
            excelExport.Owner = this;
            excelExport.Show();
        }*/
    }
}
