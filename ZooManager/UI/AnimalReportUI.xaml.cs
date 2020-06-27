using System;
using System.Collections;
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
    /// Interaction logic for AnimalReportUI.xaml
    /// </summary>
    public partial class AnimalReportUI : Window
    {
        public AnimalReportUI()
        {
            InitializeComponent();

            DBConnector.OpenDb();
            DBConnector.getAllData("Animal");
            DBConnector.CloseDb();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            userviewbox.Text = " ";

            if (idbox.Text.Length == 0)
            {
                userviewbox.Text = "No valid animal ID provided.";

            } else
            {
                int j;

                if (!int.TryParse(idbox.Text, out j))
                {
                    userviewbox.Text = "Please enter a valid ID number.";
                } else
                {

                    if (j <= 0 | j >= 5000)
                    {
                        userviewbox.Text = "Please enter a valid ID number.";
                    } else
                    {
                        int id = int.Parse(idbox.Text);

                        ArrayList allReports = DBConnector.getAnimalReports();
                        ArrayList searchResult = new ArrayList();

                        foreach (AnimalReport report in allReports)
                        {
                            if (report.AnimalId == id)
                            {
                                searchResult.Add(report);
                            }
                        }

                        reportcombobox.ItemsSource = searchResult;
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AnimalReport selectedReport = (AnimalReport) reportcombobox.SelectedItem;

            if (selectedReport == null)
            {
                userviewbox.Text = "No report for such ID.";
            }
            else
            {
                userviewbox.Text = selectedReport.Description;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window window1 = new CreateAnimalUI();
            window1.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window window1 = new CreateAnimalReport();
            window1.Show();
            this.Close();
        }
    }
}
