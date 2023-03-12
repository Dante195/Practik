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
/// номер шгфпрзшгршфгк
namespace UCHEBYA.main
{
    /// <summary>
    /// Логика взаимодействия для Ligin.xaml
    /// </summary>
    public partial class Ligin : Page
    {
        public Ligin()
        {
            InitializeComponent();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frame.Navigate(new Registr());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectHelper.entObj.User.FirstOrDefault(
                    x => x.Ligin == TxbLogin.Text && x.Password == PsbPassword.Password
                    );

                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь отсутствует!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                    FrameApp.frame.Navigate(new Registr());
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            //MessageBox.Show("Здравствуйте, "+ userObj.Ligin +" !",
                            //"Уведомление",
                            //MessageBoxButton.OK,
                            //MessageBoxImage.Information);
                            FrameApp.frame.Navigate(new PageClient());
                            break;

                        case 2:
                            //MessageBox.Show("Здравствуйте " + userObj.Ligin + "!",
                            //"Уведомление",
                            //MessageBoxButton.OK,
                            //MessageBoxImage.Information);
                            FrameApp.frame.Navigate(new PageEmployee());
                            break;

                           

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбой в работе приложения:" + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
               
            }
        }
    }
}
