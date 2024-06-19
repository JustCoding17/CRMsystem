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
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        List<DB.Task> tasks = new List<DB.Task>();
        List<string> sortList = new List<string>()
            {
            "Не выбрано",
            "Статус",
            "Приоритет больший",
            "Приоритет меньший",
            "Сотрудник",
        };
        public TaskWindow()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            GetTask();
            GetListTask();
            if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
            {
                BtnEmployee.Visibility = Visibility.Visible;
                BtnEmployee.IsEnabled = true;
                TblEmployee.Visibility = Visibility.Visible;
                TblEmployee.IsEnabled = true;
            }
        }
        void GetTask()
        {
            DgTask.ItemsSource = Contextmy.Task.ToList();
        }
        private void GetListTask()
        {
            try
            {
                tasks = Contextmy.Task.ToList();
                tasks = tasks.Where(x => x.TaskNumber.Contains(TxbSearch.Text)
                || x.Status.StatusTitle.ToString().Contains(TxbSearch.Text)
                || x.Employee.LastName.ToString().Contains(TxbSearch.Text)
                || x.Appeal.AppealNumber.ToString().Contains(TxbSearch.Text)).ToList();
                switch (CmbSort.SelectedIndex)
                {
                    case 0:
                        DgTask.ItemsSource = Contextmy.Task.ToList();
                        break;
                    case 1:
                        tasks = tasks.OrderBy(i => i.Status.StatusTitle).ToList();
                        break;
                    case 2:
                        tasks = tasks.OrderByDescending(i => i.Priority.PriorityNumber).ToList();
                        break;
                    case 3:
                        tasks = tasks.OrderBy(i => i.Priority.PriorityNumber).ToList();
                        break;
                    case 4:
                        tasks = tasks.OrderBy(i => i.Employee.LastName).ToList();
                        break;
                    default:
                        break;
                }
                DgTask.ItemsSource = tasks;
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
            GetListTask();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListTask();
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
            AddEditTaskWindow addEditTaskWindow = new AddEditTaskWindow();
            addEditTaskWindow.Show();
            this.Close();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DgTask.SelectedItem is DB.Task)
            {
                var task = DgTask.SelectedItem as DB.Task;
                AddEditTaskWindow addEditTaskWindow = new AddEditTaskWindow(task);
                addEditTaskWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Задание не выбрано", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgTask.SelectedItem is DB.Task)
                {
                    var item = DgTask.SelectedItem as DB.Task;
                    GetListTask();
                    var dialogResult = MessageBox.Show("Вы действительно хотите удалить задание?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        Contextmy.Task.Remove(item);
                        Contextmy.SaveChanges();
                        MessageBox.Show("Задание успешно удалено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        TaskWindow taskWindow = new TaskWindow();
                        taskWindow.Show();
                        this.Close();
                    }
                    else
                    { }
                }
                else
                {
                    MessageBox.Show("Задание не выбрано", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
