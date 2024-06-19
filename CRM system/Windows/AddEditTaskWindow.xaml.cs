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
using System.Collections;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;


namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditTaskWindow.xaml
    /// </summary>
    public partial class AddEditTaskWindow : Window
    {
        private bool isEdit = false;
        private DB.Task editTask;
        public AddEditTaskWindow()
        {
            InitializeComponent();
            CmbStatus.ItemsSource = Contextmy.Status.ToList();
            CmbStatus.DisplayMemberPath = "StatusTitle";
            CmbStatus.SelectedIndex = 0;

            CmbPriority.ItemsSource = Contextmy.Priority.ToList();
            CmbPriority.DisplayMemberPath = "PriorityNumber";
            CmbPriority.SelectedIndex = 0;
            if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
            {
                BtnEmployee.Visibility = Visibility.Visible;
                BtnEmployee.IsEnabled = true;
                TblEmployee.Visibility = Visibility.Visible;
                TblEmployee.IsEnabled = true;
            }
        }

        public AddEditTaskWindow(AppealClass appealClass)
        {
            InitializeComponent();
            CmbStatus.ItemsSource = Contextmy.Status.ToList();
            CmbStatus.DisplayMemberPath = "StatusTitle";
            CmbStatus.SelectedIndex = 0;

            CmbPriority.ItemsSource = Contextmy.Priority.ToList();
            CmbPriority.DisplayMemberPath = "PriorityNumber";
            CmbPriority.SelectedIndex = 0;
            TbAppeal.Text = appealClass.TextAppeal;
            TbEmployee.Text = EmployeeDataClass.Employee.LastName;
        }

        public AddEditTaskWindow(DB.Task task)
        {
            try
            {
                InitializeComponent();
                if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
                {
                    BtnEmployee.Visibility = Visibility.Visible;
                    BtnEmployee.IsEnabled = true;
                    TblEmployee.Visibility = Visibility.Visible;
                    TblEmployee.IsEnabled = true;
                }
                CmbStatus.ItemsSource = Contextmy.Status.ToList();
                CmbStatus.DisplayMemberPath = "StatusTitle";

                CmbPriority.ItemsSource = Contextmy.Priority.ToList();
                CmbPriority.DisplayMemberPath = "PriorityNumber";

                TbAppeal.Text = task.Appeal.AppealNumber;
                TbNumber.Text = task.TaskNumber;
                TbComment.Text = task.Commentary;
                TbEmployee.Text = task.Employee.LastName;

                CmbStatus.SelectedItem = Contextmy.Status.Where(i => i.IdStatus == task.IdStatus).FirstOrDefault();
                CmbPriority.SelectedItem = Contextmy.Priority.Where(i => i.IdPriority == task.IdPriority).FirstOrDefault();
                isEdit = true;
                editTask = task;
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void BtnCansel_Click(object sender, RoutedEventArgs e)
        {
            var question = MessageBox.Show("Вы уверены что хотите вернутьтся к заданиям?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                TaskWindow taskWindow = new TaskWindow();
                taskWindow.Show();
                this.Close();
            }
            else { }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isEdit)
                {
                    if (string.IsNullOrWhiteSpace(TbNumber.Text))
                    {
                        MessageBox.Show("Заполните номер задания", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbPriority.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите приоритет задания", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbStatus.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите статус задания", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbEmployee.Text))
                    {
                        MessageBox.Show("Заполните фамилию ответственного сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbAppeal.Text))
                    {
                        MessageBox.Show("Укажите номер обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }                  
                    editTask.IdStatus = (CmbStatus.SelectedItem as Status).IdStatus;
                    editTask.IdPriority = (CmbPriority.SelectedItem as Priority).IdPriority;
                    editTask.TaskNumber = TbNumber.Text;
                    editTask.IdAppeal = Convert.ToInt32(Contextmy.Appeal.Where(i => i.AppealNumber == TbAppeal.Text).FirstOrDefault().IdAppeal.ToString());
                    editTask.Commentary = TbComment.Text;
                    editTask.IdEmployee = Convert.ToInt32(Contextmy.Employee.Where(i => i.LastName == TbEmployee.Text).FirstOrDefault().IdEmployee.ToString());
                    Contextmy.SaveChanges();
                    MessageBox.Show("Изменения сохранены", "Успешно");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(TbNumber.Text))
                    {
                        MessageBox.Show("Заполните номер задания", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbPriority.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите приоритет задания", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbStatus.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите статус задания", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbAppeal.Text))
                    {
                        MessageBox.Show("Укажите номер обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    
                    var appeal = new Appeal();
                    appeal = Contextmy.Appeal.Where(i => i.AppealNumber == TbAppeal.Text).FirstOrDefault();
                    DB.Task task = new DB.Task();
                    task.IdStatus = (CmbStatus.SelectedItem as Status).IdStatus;
                    task.IdPriority = (CmbPriority.SelectedItem as Priority).IdPriority;
                    task.TaskNumber = TbNumber.Text;
                    task.Commentary = TbComment.Text;

                    if (appeal != null)
                    {
                        task.IdAppeal = appeal.IdAppeal;
                    }
                    task.IdEmployee = EmployeeDataClass.Employee.IdEmployee;
                    Contextmy.Task.Add(task);
                    Contextmy.SaveChanges();
                    MessageBox.Show("Задание создано", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    TaskWindow taskWindow = new TaskWindow();
                    taskWindow.Show();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TbEmployee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }
    }
}
