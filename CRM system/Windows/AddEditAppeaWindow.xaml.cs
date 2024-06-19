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


namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditAppeaWindow.xaml
    /// </summary>
    public partial class AddEditAppeaWindow : Window
    {
        private bool isEdit = false;
        private Client editClient;
        private Appeal editAppl;
        public AddEditAppeaWindow()
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
            CmbStatus.SelectedIndex = 0;

            CmbCategory.ItemsSource = Contextmy.Category.ToList();
            CmbCategory.DisplayMemberPath = "CategoryTitle";
            CmbCategory.SelectedIndex = 0;

            CmbPriority.ItemsSource = Contextmy.Priority.ToList();
            CmbPriority.DisplayMemberPath = "PriorityNumber";
            CmbPriority.SelectedIndex = 0;

            CmbForm.ItemsSource = Contextmy.AppealForm.ToList();
            CmbForm.DisplayMemberPath = "AppealFormTitle";
            CmbForm.SelectedIndex = 0;          
        }
        public AddEditAppeaWindow(Appeal apl)
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

                CmbCategory.ItemsSource = Contextmy.Category.ToList();
                CmbCategory.DisplayMemberPath = "CategoryTitle";

                CmbPriority.ItemsSource = Contextmy.Priority.ToList();
                CmbPriority.DisplayMemberPath = "PriorityNumber";

                CmbForm.ItemsSource = Contextmy.AppealForm.ToList();
                CmbForm.DisplayMemberPath = "AppealFormTitle";

                TbLastName.Text = apl.Client.LastName;
                TbFirstName.Text = apl.Client.FirstName;
                TbPatronymic.Text = apl.Client.Patronymic;
                TbPhone.Text = apl.Client.PhoneNumber;
                TbEmail.Text = apl.Client.Email;

                TbNumber.Text = apl.AppealNumber;
                TbBriefDesc.Text = apl.BriefDescription;
                TbDesc.Text = apl.Description;
                TbComment.Text = apl.Commentary;

                TbEmployee.Text = apl.Employee.LastName;

                CmbStatus.SelectedItem = Contextmy.Status.Where(i => i.IdStatus == apl.IdStatus).FirstOrDefault();
                CmbCategory.SelectedItem = Contextmy.Category.Where(i => i.IdCategory == apl.IdCategory).FirstOrDefault();
                CmbPriority.SelectedItem = Contextmy.Priority.Where(i => i.IdPriority == apl.IdPriority).FirstOrDefault();
                CmbForm.SelectedItem = Contextmy.AppealForm.Where(i => i.IdAppealForm == apl.IdAppealForm).FirstOrDefault();
                isEdit = true;
                editClient = apl.Client;
                editAppl = apl;
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
            var question = MessageBox.Show("Вы уверены что хотите вернуться к обращениям?","Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (question == MessageBoxResult.Yes)
            {
                AppealWindow appealWindow = new AppealWindow();
                appealWindow.Show();
                this.Close();
            }
            else{}
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isEdit)
                {
                    if (string.IsNullOrWhiteSpace(TbNumber.Text))
                    {
                        MessageBox.Show("Укажите номер обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbBriefDesc.Text))
                    {
                        MessageBox.Show("Заполните краткое описание", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbDesc.Text))
                    {
                        MessageBox.Show("Заполните полное описание", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbStatus.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите статус обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbCategory.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите категорию обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbPriority.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите приоритет обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbForm.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите форму обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    
                    editClient.LastName = TbLastName.Text;
                    editClient.FirstName = TbFirstName.Text;
                    editClient.Patronymic = TbPatronymic.Text;
                    editClient.PhoneNumber = TbPhone.Text;
                    editClient.Email = TbEmail.Text;
                    Contextmy.SaveChanges();
                    editClient.IdClient = Contextmy.Client.ToList().LastOrDefault().IdClient;
                                                                                                 
                    editAppl.IdEmployee = Convert.ToInt32(Contextmy.Employee.Where(i => i.LastName == TbEmployee.Text).FirstOrDefault().IdEmployee.ToString());
                    editAppl.IdStatus = (CmbStatus.SelectedItem as Status).IdStatus;
                    editAppl.IdCategory = (CmbCategory.SelectedItem as Category).IdCategory;
                    editAppl.IdPriority = (CmbPriority.SelectedItem as Priority).IdPriority;
                    editAppl.IdAppealForm = (CmbForm.SelectedItem as AppealForm).IdAppealForm;
                    editAppl.AppealNumber = TbNumber.Text;
                    editAppl.BriefDescription = TbBriefDesc.Text;
                    editAppl.Description = TbDesc.Text;
                    editAppl.Commentary = TbComment.Text;

                    Contextmy.SaveChanges();
                    MessageBox.Show("Изменения сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppealWindow appealWindow = new AppealWindow();
                    appealWindow.Show();
                    this.Close();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(TbNumber.Text))
                    {
                        MessageBox.Show("Укажите номер обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                
                    if (string.IsNullOrWhiteSpace(TbBriefDesc.Text))
                    {
                        MessageBox.Show("Заполните краткое описание", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(TbDesc.Text))
                    {
                        MessageBox.Show("Заполните полное описание", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbStatus.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите статус обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbCategory.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите категорию обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbPriority.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите приоритет обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (CmbForm.SelectedIndex == -1)
                    {
                        MessageBox.Show("Укажите форму обращения", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    Appeal appeal = new Appeal();
                    appeal.IdStatus = (CmbStatus.SelectedItem as Status).IdStatus;
                    appeal.IdCategory = (CmbCategory.SelectedItem as Category).IdCategory;
                    appeal.IdPriority = (CmbPriority.SelectedItem as Priority).IdPriority;
                    appeal.IdAppealForm = (CmbForm.SelectedItem as AppealForm).IdAppealForm;
                    appeal.AppealNumber = TbNumber.Text;
                    appeal.BriefDescription = TbBriefDesc.Text;
                    appeal.Description = TbDesc.Text;
                    appeal.Commentary = TbComment.Text;
                    appeal.IdEmployee = EmployeeDataClass.Employee.IdEmployee;

                    Client client1 = new Client();
                    client1 = Contextmy.Client.Where(i => i.FirstName == TbFirstName.Text && i.LastName == TbLastName.Text).FirstOrDefault();
                    if (client1 == null) 
                    {      
                        Client client = new Client();
                        client.LastName = TbLastName.Text;
                        client.FirstName = TbFirstName.Text;
                        client.Patronymic = TbPatronymic.Text;
                        client.PhoneNumber = TbPhone.Text;
                        client.Email = TbEmail.Text;
                        Contextmy.Client.Add(client);
                        Contextmy.SaveChanges();
                        appeal.IdClient = Contextmy.Client.ToList().LastOrDefault().IdClient;
                    }
                    else
                    {
                       appeal.IdClient = client1.IdClient;
                    }
                 
                    Contextmy.Appeal.Add(appeal);                   
                    Contextmy.SaveChanges();
                    MessageBox.Show("Обращение создано", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppealWindow appealWindow = new AppealWindow();
                    appealWindow.Show();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }          
        }

        private void BtnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppealClass appealClass = new AppealClass();
                appealClass.TextAppeal = TbNumber.Text;
                AddEditTaskWindow addEditTaskWindow = new AddEditTaskWindow(appealClass);
                addEditTaskWindow.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TbLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }

        private void TbFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }

        private void TbPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }

        private void TbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void TbEmployee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsLetter(e.Text, 0);
        }
    }
}

