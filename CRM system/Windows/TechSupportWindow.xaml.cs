using CRM_system.ClassHelper;
using CRM_system.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace CRM_system.Windows
{
    /// <summary>
    /// Логика взаимодействия для TechSupportWindow.xaml
    /// </summary>
    public partial class TechSupportWindow : Window
    {
        private string pathPhoto = null;     
        public TechSupportWindow()
        {
            InitializeComponent();
            if (EmployeeDataClass.Employee.IdPost.ToString() == "2")
            {
                BtnEmployee.Visibility = Visibility.Visible;
                BtnEmployee.IsEnabled = true;
                TblEmployee.Visibility = Visibility.Visible;
                TblEmployee.IsEnabled = true;
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(TbBriefDesc.Text) || String.IsNullOrWhiteSpace(TbBriefDesc.Text))
                {
                    MessageBox.Show("Заполните краткое описание", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (String.IsNullOrEmpty(TbDesc.Text) || String.IsNullOrWhiteSpace(TbDesc.Text))
                {
                    MessageBox.Show("Заполните полное описание", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    AppealTechnicalSupport appealTechnicalSupport = new AppealTechnicalSupport();
                    appealTechnicalSupport.BriefDescription = TbBriefDesc.Text;
                    appealTechnicalSupport.Description = TbDesc.Text;
                    appealTechnicalSupport.IdEmployee = EmployeeDataClass.Employee.IdEmployee;
                    if (pathPhoto != null)
                    {
                        appealTechnicalSupport.Image = File.ReadAllBytes(pathPhoto);
                    }

                    Contextmy.AppealTechnicalSupport.Add(appealTechnicalSupport);
                    Contextmy.SaveChanges();
                    MessageBox.Show("Обращение отправлено", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    TbBriefDesc.Text = "";
                    TbDesc.Text = "";
                    ImgSupport.Source = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void BtnChoosseImg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    ImgSupport.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    pathPhoto = openFileDialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность выбранного фото", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
    }
}
