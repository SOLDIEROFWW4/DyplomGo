using System;
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
    /// Логика взаимодействия для ManagementMenuWindow.xaml
    /// </summary>
    public partial class ManagementMenuWindow : Window
    {
        private void OpenUsersPanel()
        {
            Hide();
            Window2 w2 = new Window2();
            w2.Owner = this;
            w2.Show();
        }

        private void OpenMainPanel()
        {
            Hide();
            Window1 w1 = new Window1();
            w1.Owner = this;
            w1.Show();
        }
        public ManagementMenuWindow()
        {
            InitializeComponent();
        }

        private void UMPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenUsersPanel();
        }

        private void MainPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenMainPanel();
        }

        private void StatisticPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            StatisticPanelBtn.IsEnabled = false;
        }
    }
}
