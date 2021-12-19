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

namespace UCHEBYA.Admin
{
    /// <summary>
    /// Логика взаимодействия для PageAddClient.xaml
    /// </summary>
    public partial class PageAddClient : Page
    {
        public PageAddClient()
        {
            InitializeComponent();

            CmbProduct.SelectedValuePath = "Id";
            CmbProduct.DisplayMemberPath = "Name";
            CmbProduct.ItemsSource = OdbConnectHelper.entObj.Products.ToList();       

            CmbNumber.SelectedValuePath = "Id";
            CmbNumber.DisplayMemberPath = "Number";
            CmbNumber.ItemsSource = OdbConnectHelper.entObj.NumberProducts.ToList();
        }



        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Client client = new Client()
                {
                    Name = TxbNameClient.Text,
                    Products = CmbProduct.SelectedItem as Products,
                    NumberProducts = CmbNumber.SelectedItem as NumberProducts,
                };
                OdbConnectHelper.entObj.Client.Add(client);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show(
                "Клиент" + client.Name + "Успешно добавлен!",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                FrameApp.frame.GoBack();

            }   
            catch (Exception ex)
            {
                MessageBox.Show(
                   "Критическая работа с приложением" + ex.Message.ToString(),
                   "Уведомление",
                   MessageBoxButton.OK,
                   MessageBoxImage.Warning);

                
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frame.GoBack();
        }
    }
}
