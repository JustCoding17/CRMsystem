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
using static CRM_system.ClassHelper.EFClass;
using CRM_system.DB;
using CRM_system.ClassHelper;
using Syncfusion.UI.Xaml.Charts;
using System.Runtime.Remoting.Contexts;

namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public class ViewModel
        {
            public List<VW_AppealStatistics> Data { get; set; }
            public List<VW_TaskStatistics> Data2 { get; set; }

            public ViewModel()
            {
                Data = new List<VW_AppealStatistics>();
                Data = Contextmy.VW_AppealStatistics.ToList();
                Data2 = new List<VW_TaskStatistics>();
                Data2 = Contextmy.VW_TaskStatistics.ToList();
            }
        }
            public DashboardWindow()
            {
                InitializeComponent();
                this.DataContext = new ViewModel();        
            }
  
        private void BtnExit_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void TblExit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
