using Pekarniya.BDkon;
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
using goods_cashier = Pekarniya.BDkon.goods_cashier;


namespace Pekarniya.App
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public static List<goods_cashier> GC { get; set; }
        public ListPage()
        {
            InitializeComponent();
            GC = new List<goods_cashier>(Class.pekBD.goods_cashier.ToList());
            this.DataContext = this;
        }

   
        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as goods_cashier;
            MessageBox.Show($"Вы дейтсвительно хотите удалить { ser.id_goods}?");
            ser.IsDelete = true;
            Class.pekBD.SaveChanges();
            ServicesLv.ItemsSource = Class.pekBD.goods_cashier.Where(i => i.IsDelete == false).ToList();
        }

    }
}
