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
using ZooManager;
using ZooManager.Database;

namespace ZooUI.UI
{
    /// <summary>
    /// Interaction logic for CreateZooUI.xaml
    /// </summary>
    public partial class CreateZooUI : Window
    {
        public CreateZooUI()
        {
            InitializeComponent();

            InitializeComponent();

            DBConnector.OpenDb();
            DBConnector.getAllData("Zoo");
            DBConnector.CloseDb();

            zoocombobox.ItemsSource = DBConnector.getZoos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (zoonamebox.Text.Length == 0 | addressbox.Text.Length == 0)
            {
                resultbox.Text = "Please enter all of the required information.";
            } else
            {
                String name = zoonamebox.Text;
                String address = addressbox.Text;

                DBConnector.OpenDb();
                Boolean result = DBConnector.AddZoo(name, address);
                DBConnector.CloseDb();

                if (result)
                {
                    resultbox.Text = "Successfully added zoo.";
                }
                else
                {
                    resultbox.Text = "Zoo already exists.";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Zoo choice = (Zoo)zoocombobox.SelectedItem;

            DBConnector.OpenDb();
            Boolean result = DBConnector.DeleteZoo(choice.Id);
            DBConnector.CloseDb();

            zoocombobox.InvalidateVisual();

            if (result)
            {
                resultbox2.Text = "Successfully deleted zoo.";
            } else
            {
                resultbox2.Text = "Failed to delete animal.";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window window1 = new HomePageUI();
            window1.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window window1 = new ZooReportUI();
            window1.Show();
            this.Close();
        }
    }
}
