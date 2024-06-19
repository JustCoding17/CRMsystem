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
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {      
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var authEmp = Contextmy.Employee.ToList()
                            .Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password 
                            || i.Login == TbLogin.Text && i.Password == TbPassword.Text && i.Password == PbPassword.Password
                            || i.Login == TbLogin.Text && i.Password == TbPassword.Text).FirstOrDefault();
            if (authEmp != null && authEmp.IsBlocked == false)
            {
                ClassHelper.EmployeeDataClass.Employee = authEmp;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Такой пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            TbPassword.Text = PbPassword.Password;
            PbPassword.Visibility = Visibility.Collapsed;
            TbPassword.Visibility = Visibility.Visible;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PbPassword.Password = TbPassword.Text;
            TbPassword.Visibility = Visibility.Collapsed;
            PbPassword.Visibility = Visibility.Visible;
        }    
    }
 }
