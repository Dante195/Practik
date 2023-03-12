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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UCHEBYA.db;
/// ЛЖТОТЖЛОЛОИЛДОИЖДЛЧПВРДЖЛ ИЬР ЗДЕСЬ БЫЛ Я
namespace UCHEBYA.main
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frame.GoBack();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (OdbConnectHelper.entObj.User.Count(x => x.Ligin == TextLogin.Text ) > 0)
            {
                MessageBox.Show("Такой пользователь уже есть!", "Уведомление ", MessageBoxButton.OK, MessageBoxImage.Information);
                
                return;
            }
            else
            {
                try
                {
                    User userObj = new User()
                    {
                        Ligin = TextLogin.Text,
                        Password = RepidPass.Password,
                        IdRole = 1
                    };

                    OdbConnectHelper.entObj.User.Add(userObj);
                    OdbConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Пользователь создан!", "Уведомление ", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Критический сбой работы", MessageBoxButton.OK, MessageBoxImage.Warning);
                    
                }

            }
        }

        private void RepidPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextPass.Text == RepidPass.Password)
            {
                Create.IsEnabled = true;
                RepidPass.Background = Brushes.Green;
                RepidPass.Background = Brushes.LightGreen;
            }
            else
            {
                Create.IsEnabled = false;
                RepidPass.Background = Brushes.Red;
                RepidPass.Background = Brushes.LightCoral;
            }
        }
    }
}
