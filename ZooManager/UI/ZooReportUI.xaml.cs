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
    /// Interaction logic for ZooReportUI.xaml
    /// </summary>
    public partial class ZooReportUI : Window
    {
        public ZooReportUI()
        {
            InitializeComponent();

            DBConnector.OpenDb();
            DBConnector.getAllData("Zoo");
            DBConnector.CloseDb();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            userviewbox.Text = " ";

            if (idbox.Text.Length == 0)
            {
                userviewbox.Text = "No valid zoo ID provided.";

            }
            else
            {
                int j;

                if (!int.TryParse(idbox.Text, out j))
                {
                    userviewbox.Text = "Please enter a valid ID number.";
                }
                else
                {

                    if (j <= 0 | j >= 10)
                    {
                        userviewbox.Text = "Please enter a valid ID number.";
                    }
                    else
                    {
                        int id = int.Parse(idbox.Text);

                        ArrayList allReports = DBConnector.getZooReports();
                        ArrayList searchResult = new ArrayList();

                        foreach (ZooReport report in allReports)
                        {
                            if (report.ZooId == id)
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
            ZooReport selectedReport = (ZooReport)reportcombobox.SelectedItem;

            if (selectedReport == null)
            {
                userviewbox.Text = "No report for such ID.";
            } else
            {
                userviewbox.Text = selectedReport.Description;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window window1 = new CreateZooUI();
            window1.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window window1 = new CreateZooReportUI();
            window1.Show();
            this.Close();
        }
    }
}
