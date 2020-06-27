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
    /// Interaction logic for CreateAnimalUI.xaml
    /// </summary>
    public partial class CreateAnimalUI : Window
    {
        public CreateAnimalUI()
        {
            InitializeComponent();

            DBConnector.OpenDb();
            DBConnector.getAllData("Animal");
            DBConnector.CloseDb();

            animalcombobox.ItemsSource = DBConnector.getAnimals();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int j;
            if (namebox.Text.Length == 0 | agebox.Text.Length == 0 | speciesbox.Text.Length == 0 | zoobox.Text.Length == 0 | !int.TryParse(agebox.Text, out j))
            {
                resultbox.Text = "Please enter all of the required information.";
            } else
            {
                String name = namebox.Text;
                int age = int.Parse(agebox.Text);
                String species = speciesbox.Text;
                int zoo = int.Parse(zoobox.Text);

                DBConnector.OpenDb();
                Boolean result = DBConnector.AddAnimal(name, age, species, zoo);
                DBConnector.CloseDb();

                if (result)
                {
                    resultbox.Text = "Successfully added animal.";
                }
                else
                {
                    resultbox.Text = "Animal already exists.";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Animal choice = (Animal)animalcombobox.SelectedItem;

            DBConnector.OpenDb();
            Boolean result = DBConnector.DeleteAnimal(choice.Id);
            DBConnector.CloseDb();

            if (result)
            {
                resultbox2.Text = "Successfully deleted animal.";
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
            Window window1 = new AnimalReportUI();
            window1.Show();
            this.Close();
        }
    }
}
