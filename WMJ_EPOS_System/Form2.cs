using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMJ_EPOS_System
{
    public partial class DailySalesReportForm : Form
    {
        public DailySalesReportForm()
        {
            InitializeComponent();
        }

        private void DailySalesReportForm_Load(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void LoadSalesReport()
        {

            // Display today's date
            TodaysDateOutputLabel.Text = DateTime.Now.ToString("dd-MM-yyyy");

            // Clear the list box before adding data
            SalesReportListBox.Items.Clear();

            // Get references to the necessary arrays/data
            int[,] InitialStock = SalesForm.OpeningStock;
            int[,] RunningStock = SalesForm.RunningCurrentStock;
            decimal[,] Prices = SalesForm.PRICES;
            string[] JumperNames = SalesForm.JumperName;
            string[] JumperSizes = SalesForm.JumperSize;

            // Iterate through all jumpers and sizes
            for (int i = 0; i < JumperNames.Length; i++) // Loop through jumper types
            {
                for (int j = 0; j < JumperSizes.Length; j++) // Loop through sizes
                {
                    int QuantitySold = InitialStock[i, j] - RunningStock[i, j]; // Calculate quantity sold
                    decimal Revenue = QuantitySold * Prices[i, j];                 // Calculate revenue

                    // Format the display string
                    string reportLine = $"{JumperNames[i],-18} {JumperSizes[j],-25} {QuantitySold,-15} {Revenue,10:C2}";

                    // Add the report line to the list box
                    SalesReportListBox.Items.Add(reportLine);
                }

                // Add a separator after each jumper type
                SalesReportListBox.Items.Add(new string('-', 80));
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
