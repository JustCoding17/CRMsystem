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
using System.Collections;
using System.Data.Entity;
using System.Security.Cryptography;

namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        List<Employee> employees = new List<Employee>();
        List<string> sortList = new List<string>()
          {
            "Не выбрано",
            "Фамилия",
            "Имя",
            "Отчество",
            "День рождения",
            "Номер телефона",
            "Почта",
            "Должность",
            "График работы",
            "Блокировка",
            "Логин",
            "Пароль"
        };
        public EmployeeWindow()
        {
            InitializeComponent();
            if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
            {
                BtnEmployee.Visibility = Visibility.Visible;
                BtnEmployee.IsEnabled = true;
                TblEmployee.Visibility = Visibility.Visible;
                TblEmployee.IsEnabled = true;
            }
            CmbEval.ItemsSource = sortList;
            CmbEval.SelectedIndex = 0;
            GetEmployee();
            GetListEmployee();
        }
        void GetEmployee()
        {
            DgEmp.ItemsSource = Contextmy.Employee.ToList();
        }
        private void GetListEmployee()
        {
            try
            {
                employees = Contextmy.Employee.ToList();
                employees = employees.Where(x => x.Email.Contains(TxbSearch.Text)
                || x.Post.PostTitle.ToString().Contains(TxbSearch.Text)
                || x.WorkSchedule.Title.ToString().Contains(TxbSearch.Text)
                || x.Login.ToString().Contains(TxbSearch.Text)
                || x.Password.ToString().Contains(TxbSearch.Text)
                || x.LastName.ToString().Contains(TxbSearch.Text)
                || x.FirstName.ToString().Contains(TxbSearch.Text)).ToList();
                switch (CmbEval.SelectedIndex)
                {
                    case 0:
                        DgEmp.ItemsSource = Contextmy.Employee.ToList();
                        break;
                    case 1:
                        employees = employees.OrderBy(i => i.LastName).ToList();
                        break;
                    case 2:
                        employees = employees.OrderBy(i => i.FirstName).ToList();
                        break;
                    case 3:
                        employees = employees.OrderBy(i => i.Patronymic).ToList();
                        break;
                    case 4:
                        employees = employees.OrderBy(i => i.Birthday).ToList();
                        break;
                    case 5:
                        employees = employees.OrderBy(i => i.PhoneNumber).ToList();
                        break;
                    case 6:
                        employees = employees.OrderBy(i => i.Email).ToList();
                        break;
                    case 7:
                        employees = employees.OrderBy(i => i.Post.PostTitle).ToList();
                        break;
                    case 8:
                        employees = employees.OrderBy(i => i.WorkSchedule.Title).ToList();
                        break;
                    case 9:
                        employees = employees.OrderBy(i => i.IsBlocked).ToList();
                        break;
                    case 10:
                        employees = employees.OrderBy(i => i.Login).ToList();
                        break;
                    case 11:
                        employees = employees.OrderBy(i => i.Password).ToList();
                        break;
                    default:
                        break;
                }
                DgEmp.ItemsSource = employees;
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
            GetListEmployee();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListEmployee();
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
            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow();
            addEditEmployeeWindow.Show();
            this.Close();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DgEmp.SelectedItem is Employee)
            {
                var emp = DgEmp.SelectedItem as Employee;
                AddEditEmployeeWindow employeeWindow = new AddEditEmployeeWindow(emp);
                employeeWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Запись не выбрана", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgEmp.SelectedItem is Employee)
                {
                    var item = DgEmp.SelectedItem as Employee;
                    GetListEmployee();
                    var dialogResult = MessageBox.Show("Вы действительно хотите удалить данные о сотруднике?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        Contextmy.Employee.Remove(item);
                        Contextmy.SaveChanges();
                        MessageBox.Show("Сотрудник успешно удален!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                        EmployeeWindow employeeWindow = new EmployeeWindow();
                        employeeWindow.Show();
                        this.Close();
                    }
                    else
                    { }
                }
                else
                {
                    MessageBox.Show("Запись не выбрана", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
