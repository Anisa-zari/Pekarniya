using Pekarniya.BDkon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace Pekarniya.App
{
    /// <summary>
    /// Логика взаимодействия для AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public AuthoPage()
        {
            InitializeComponent();
        }

        private void Autho_btn_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = Class.pekBD.cashier.FirstOrDefault(u => u.login == log_txb.Text && u.password == pass_txb.Password);

            if (CurrentUser != null)
            {

                NavigationService.Navigate(new App.ListPage());

            }
            else
            {
                MessageBox.Show("Ошибка...", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
