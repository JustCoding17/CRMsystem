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

namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для AppealWindow.xaml
    /// </summary>
    public partial class AppealWindow : Window
    {
        List<Appeal> appeals = new List<Appeal>();
        List<string> sortList = new List<string>()
          {
            "Не выбрано",
            "Статус",
            "Категория",
            "Приоритет больший",
            "Приоритет меньший",
            "Инициатор",
            "Сотрудник",
            "Форма обращения"
        };
        public AppealWindow()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            GetAppeal();
            GetListAppeal();
            if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
            {
                BtnEmployee.Visibility = Visibility.Visible;
                BtnEmployee.IsEnabled = true;
                TblEmployee.Visibility = Visibility.Visible;
                TblEmployee.IsEnabled = true;
            }
        }
       
        void GetAppeal()
        {
            DgAppeal.ItemsSource = Contextmy.Appeal.ToList();
        }
        private void GetListAppeal()
        {
            try
            {
                appeals = Contextmy.Appeal.ToList();
                appeals = appeals.Where(x => x.AppealNumber.Contains(TxbSearch.Text)
                || x.Status.StatusTitle.ToString().Contains(TxbSearch.Text)
                || x.Category.CategoryTitle.ToString().Contains(TxbSearch.Text)
                || x.Client.LastName.ToString().Contains(TxbSearch.Text)
                || x.Employee.LastName.ToString().Contains(TxbSearch.Text)
                || x.AppealForm.AppealFormTitle.ToString().Contains(TxbSearch.Text)
                || x.BriefDescription.ToString().Contains(TxbSearch.Text)).ToList();
                switch (CmbSort.SelectedIndex)
                {
                    case 0:
                        DgAppeal.ItemsSource = Contextmy.Appeal.ToList();
                        break;
                    case 1:
                        appeals = appeals.OrderBy(i => i.Status.StatusTitle).ToList();
                        break;
                    case 2:
                        appeals = appeals.OrderBy(i => i.Category.CategoryTitle).ToList();
                        break;
                    case 3:
                        appeals = appeals.OrderByDescending(i => i.Priority.PriorityNumber).ToList();
                        break;
                    case 4:
                        appeals = appeals.OrderBy(i => i.Priority.PriorityNumber).ToList();
                        break;
                    case 5:
                        appeals = appeals.OrderBy(i => i.Client.LastName).ToList();
                        break;
                    case 6:
                        appeals = appeals.OrderBy(i => i.Employee.LastName).ToList();
                        break;
                    case 7:
                        appeals = appeals.OrderBy(i => i.AppealForm.AppealFormTitle).ToList();
                        break;
                    default:
                        break;
                }
                DgAppeal.ItemsSource = appeals;
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

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListAppeal();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListAppeal();
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditAppeaWindow addEditAppeaWindow = new AddEditAppeaWindow();
            addEditAppeaWindow.Show();
            this.Close();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DgAppeal.SelectedItem is Appeal)
            {
                var appl = DgAppeal.SelectedItem as Appeal;
                AddEditAppeaWindow addEditAppeaWindow = new AddEditAppeaWindow(appl);
                addEditAppeaWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Обращение не выбрано", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
