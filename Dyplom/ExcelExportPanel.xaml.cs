﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Dyplom
{
    /// <summary>
    /// Логика взаимодействия для ExcelExportPanel.xaml
    /// </summary>
    public partial class ExcelExportPanel : Window
    {
        public ExcelExportPanel()
        {
            InitializeComponent();
        }

        private void SocialPassportExpBtn_Click(object sender, RoutedEventArgs e)
        {
            SocialPassportExpBtn.IsEnabled = false;
        }

        private void NumbericStrenghtExpBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic Excel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));

            var wb = Excel.Workbooks.Add("D:\\Documents\\Предметы\\Диплом\\Example.xltm");

            Excel.DisplayAlerts = false;

            var sheets = wb.Sheets[1];
            sheets.Cells[3, 2].value = "21";
            sheets.Cells[2, 3].value = "26";
            sheets.Cells[4, 3].value = "24";

            wb.SaveAs("D:\\Documents\\Предметы\\Диплом\\ExampleComplete.xlsx");

            System.Diagnostics.Process.Start(@"D:\\Documents\\Предметы\\Диплом\\ExampleComplete.xlsx");
        }

        private void StudentDataExpBtn_Click(object sender, RoutedEventArgs e)
        {
            StudentDataExpBtn.IsEnabled = false;
        }
    }
}