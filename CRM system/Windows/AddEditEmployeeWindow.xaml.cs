using CRM_system.ClassHelper;
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


namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        private bool isEdit = false;
        private Employee editEmp;
        public AddEditEmployeeWindow()
        {
            InitializeComponent();
            if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
            {
                BtnEmployee.Visibility = Visibility.Visible;
                BtnEmployee.IsEnabled = true;
                TblEmployee.Visibility = Visibility.Visible;
                TblEmployee.IsEnabled = true;
            }
            CmbPost.ItemsSource = Contextmy.Post.ToList();
            CmbPost.DisplayMemberPath = "PostTitle";
            CmbPost.SelectedIndex = 0;

            CmbWorkSchedule.ItemsSource = Contextmy.WorkSchedule.ToList();
            CmbWorkSchedule.DisplayMemberPath = "Title";
            CmbWorkSchedule.SelectedIndex = 0;
        }
        public AddEditEmployeeWindow(Employee empl)
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
                CmbPost.ItemsSource = Contextmy.Post.ToList();
                CmbPost.DisplayMemberPath = "PostTitle";
                CmbWorkSchedule.ItemsSource = Contextmy.WorkSchedule.ToList();
                CmbWorkSchedule.DisplayMemberPath = "Title";
                if (empl.IsBlocked == true)
                {
                    CbBlock.IsChecked = true;
                }
                else
                {
                    CbBlock.IsChecked = false;
                }
               
                TbLName.Text = empl.LastName;
                TbFName.Text = empl.FirstName;
                TbLPatronymic.Text = empl.Patronymic;
                TbPhone.Text = empl.PhoneNumber;
                TbEmail.Text = empl.Email;
                DpBirthday.Text = empl.Birthday.ToString();
                CmbPost.SelectedItem = Contextmy.Post.Where(i => i.IdPost == empl.IdPost).FirstOrDefault();
                CmbWorkSchedule.SelectedItem = Contextmy.WorkSchedule.Where(i => i.IdWorkSchedule == empl.IdWorkSchedule).FirstOrDefault();
                TbLogin.Text = empl.Login;
                TbPassword.Text = empl.Password;
                if (CbBlock.IsChecked == true)
                {
                    empl.IsBlocked = true;
                }
                else
                {
                    empl.IsBlocked = false;
                }
                isEdit = true;
                editEmp = empl;            
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isEdit)
                {
                    if (string.IsNullOrWhiteSpace(TbLName.Text))
                    {
                        MessageBox.Show("Заполните фамилию сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbFName.Text))
                    {
                        MessageBox.Show("Заполните имя сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbPhone.Text))
                    {
                        MessageBox.Show("Заполните телефон сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbEmail.Text))
                    {
                        MessageBox.Show("Заполните почту сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (!DpBirthday.SelectedDate.HasValue)
                    {
                        MessageBox.Show("Укажите дату рождения сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbPost.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите должность сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbWorkSchedule.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите график работы сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbLogin.Text))
                    {
                        MessageBox.Show("Заполните логин сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbPassword.Text))
                    {
                        MessageBox.Show("Заполните пароль сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    editEmp.LastName = TbLName.Text;
                    editEmp.FirstName = TbFName.Text;
                    editEmp.Patronymic = TbLPatronymic.Text;
                    editEmp.PhoneNumber = TbPhone.Text;
                    editEmp.Email = TbEmail.Text;
                    editEmp.Birthday = DpBirthday.SelectedDate.Value;
                    editEmp.IdPost = (CmbPost.SelectedItem as Post).IdPost;
                    editEmp.IdWorkSchedule = (CmbWorkSchedule.SelectedItem as WorkSchedule).IdWorkSchedule;
                    editEmp.Login = TbLogin.Text;
                    editEmp.Password = TbPassword.Text;
                    if (CbBlock.IsChecked == true)
                    {
                        editEmp.IsBlocked = true;
                    }
                    else
                    {
                        editEmp.IsBlocked = false;
                    }
                    Contextmy.SaveChanges();
                    MessageBox.Show("Изменения сохранены", "Успешно");
                    EmployeeWindow employeeWindow2 = new EmployeeWindow();
                    employeeWindow2.Show();
                    this.Close();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(TbLName.Text))
                    {
                        MessageBox.Show("Заполните фамилию сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbFName.Text))
                    {
                        MessageBox.Show("Заполните имя сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbPhone.Text))
                    {
                        MessageBox.Show("Заполните телефон сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbEmail.Text))
                    {
                        MessageBox.Show("Заполните почту сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (!DpBirthday.SelectedDate.HasValue)
                    {
                        MessageBox.Show("Укажите дату рождения сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbPost.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите должность сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbWorkSchedule.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите график работы сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbLogin.Text))
                    {
                        MessageBox.Show("Заполните логин сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbPassword.Text))
                    {
                        MessageBox.Show("Заполните пароль сотрудника", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    Employee employee = new Employee();
                    employee.LastName = TbLName.Text;
                    employee.FirstName = TbFName.Text;
                    employee.Patronymic = TbLPatronymic.Text;
                    employee.PhoneNumber = TbPhone.Text;
                    employee.Email = TbEmail.Text;
                    employee.Birthday = DpBirthday.SelectedDate.Value;
                    employee.IdPost = (CmbPost.SelectedItem as Post).IdPost;
                    employee.IdWorkSchedule = (CmbWorkSchedule.SelectedItem as WorkSchedule).IdWorkSchedule;
                    employee.Login = TbLogin.Text;
                    employee.Password = TbPassword.Text;
                    if (CbBlock.IsChecked == true)
                    {
                        employee.IsBlocked = true;
                    }
                    else
                    {
                        employee.IsBlocked = false;
                    }
                    Contextmy.Employee.Add(employee);
                    Contextmy.SaveChanges();
                    MessageBox.Show("Сотрудник успешно добавлен", "Успешно");
                    EmployeeWindow employeeWindow = new EmployeeWindow();
                    employeeWindow.Show();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TbLName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);           
        }

        private void TbFName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }

        private void TbLPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }

        private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
    }
}
