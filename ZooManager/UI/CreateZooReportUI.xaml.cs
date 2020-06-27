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
using ZooManager.Database;

namespace ZooUI.UI
{
    /// <summary>
    /// Interaction logic for CreateZooReportUI.xaml
    /// </summary>
    public partial class CreateZooReportUI : Window
    {
        public CreateZooReportUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int j;

            if (!int.TryParse(idbox.Text, out j))
            {
                resultbox.Text = "The ID given is not valid.";
            }
            else if (usertextbox.Text.Length == 0)
            {
                resultbox.Text = "Please type a report.";
            }
            else
            {
                int id = int.Parse(idbox.Text);
                String reportBody = (String)usertextbox.Text;

                DBConnector.OpenDb();
                Boolean result = DBConnector.AddZooReport(id, reportBody);
                DBConnector.CloseDb();

                if (result)
                {
                    resultbox.Text = "Successfully added report.";
                }
                else
                {
                    resultbox.Text = "Failed to add report.";
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window1 = new ZooReportUI();
            window1.Show();
            this.Close();
        }
    }
}
