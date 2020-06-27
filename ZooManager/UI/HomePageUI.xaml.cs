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

namespace ZooUI.UI
{
    /// <summary>
    /// Interaction logic for HomePageUI.xaml
    /// </summary>
    public partial class HomePageUI : Window
    {
        public HomePageUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window1 = new CreateAnimalUI();
            window1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window1 = new CreateZooUI();
            window1.Show();
            this.Close();
        }
    }
}
