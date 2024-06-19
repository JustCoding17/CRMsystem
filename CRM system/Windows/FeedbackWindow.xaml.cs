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
using CRM_system.ClassHelper;
using static CRM_system.ClassHelper.EFClass;
using CRM_system.DB;
using System.Runtime.Remoting.Contexts;
using System.Collections;
using System.Net.Sockets;

namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для FeedbackWindow.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        List<Feedback> feedbacks = new List<Feedback>();
        List<string> sortList = new List<string>()
          {            
            "Сначала положительные",
            "Сначала отрицательные",
            "Не выбрано"
        };
        public FeedbackWindow()
        {
            InitializeComponent();          
            GetFeedBack();
            GetListFeedback();
            if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
            {
                BtnEmployee.Visibility = Visibility.Visible;
                BtnEmployee.IsEnabled = true;
                TblEmployee.Visibility = Visibility.Visible;
                TblEmployee.IsEnabled = true;
            }
            CmbEval.ItemsSource = sortList;
            CmbEval.SelectedIndex = 2;
        }
        
        private void GetFeedBack()
        {           
            feedbacks = Contextmy.Feedback.ToList();
            LvFeedBack.ItemsSource = feedbacks;      
        }
        private void GetListFeedback()
        {
            try
            {
                feedbacks = Contextmy.Feedback.ToList();
                feedbacks = feedbacks.Where(x => x.Client.LastName.Contains(TxbSearch.Text)
                || x.Client.FirstName.Contains(TxbSearch.Text)
                || x.Evaluation.Number.ToString().Contains(TxbSearch.Text)
                || x.Commentary.Contains(TxbSearch.Text)).ToList();
                switch (CmbEval.SelectedIndex)
                {
                    case 0:
                        feedbacks = feedbacks.OrderByDescending(i => i.Evaluation.Number).ToList();
                        break;
                    case 1:
                        feedbacks = feedbacks.OrderBy(i => i.Evaluation.Number).ToList();
                        break;
                    case 2:
                        LvFeedBack.ItemsSource = Contextmy.Evaluation.ToList();
                        break;
                    default:
                        break;
                }
                LvFeedBack.ItemsSource = feedbacks;
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            var DialogResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DialogResult == MessageBoxResult.Yes)
            {
                SignInWindow signInWindow = new SignInWindow();
                signInWindow.Show();
                this.Close();
            }
        }
        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }

        private void BtnFeedback_Click(object sender, RoutedEventArgs e)
        {
            FeedbackWindow feedbackWindow = new FeedbackWindow();
            feedbackWindow.Show();
            this.Close();
        }

        private void BtnTask_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
            this.Close();
        }

        private void BtnTechSupport_Click(object sender, RoutedEventArgs e)
        {
            TechSupportWindow techSupportWindow = new TechSupportWindow();
            techSupportWindow.Show();
            this.Close();
        }

        private void BtnAppeal_Click(object sender, RoutedEventArgs e)
        {
            AppealWindow appealWindow = new AppealWindow();
            appealWindow.Show();
            this.Close();
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            this.Close();
        }

        private void TblDashboard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            this.Close();
        }

        private void TblProfile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }

        private void TblExit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var DialogResult = MessageBox.Show("Вы уверены, что хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DialogResult == MessageBoxResult.Yes)
            {
                SignInWindow signInWindow = new SignInWindow();
                signInWindow.Show();
                this.Close();
            }
        }

        private void TblFeedback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FeedbackWindow feedbackWindow = new FeedbackWindow();
            feedbackWindow.Show();
            this.Close();
        }

        private void TblAppeal_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AppealWindow appealWindow = new AppealWindow();
            appealWindow.Show();
            this.Close();
        }

        private void TblTask_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
            this.Close();
        }

        private void TblTechSupport_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TechSupportWindow techSupportWindow = new TechSupportWindow();
            techSupportWindow.Show();
            this.Close();
        }

        private void CmbEval_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListFeedback();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListFeedback();
        }

        private void TblEmployee_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }

        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }
    }
}
