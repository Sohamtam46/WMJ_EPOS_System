/* 
 * Student Name: Soham Tambde
 * Student ID: 24259687
 * Date: 19/12/2024
 * Assignment: 4
 * Assignment: The application is an EPOS system for Where's Me Jumper? Business. It will take in different types of jumpers and their sizes along with quanitity 
 *             as input and will add it to the cart as user needs. once the user is satisfied with his/her order, they can press order to confirm order. the order
 *             details are stored in files as well as arrays whereever needed and a proper formated daily report is presented to the business along with stock report.
 *             User will also be reminded of any stock going below certain limit and get a low stock alert. User can also search all past transactions either by date
 *             or transaction id.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WMJ_EPOS_System
{
    public partial class SalesForm : Form
    {

        private bool IsJumperTypeSelected = false;
        private bool IsJumperSizeSelected = false;
        private decimal ItemPrice = 0m;
        private int OrderIndexNum = 0;
        private string OrderOutput;
        private decimal TotalOrderCost = 0m;
        private int LOWSTOCK_Threshold = 4;
        private const int NumberofJumperTypes = 10, NumberofJumperSizes = 5;
        readonly static string[] JumperDisplayName = { "Boucle Knit", "Cable Knit ", "Cashmere   ", "Twist Knit ", "Fisherman Knit", "Aran       ", "Button Placket", "Full Zipper", "Cowl       ", "Merino     " };
        public readonly static string[] JumperName = { "Boucle Knit", "Cable Knit ", "Cashmere", "Twist Knit ", "Fisherman Knit", "Aran", "Button Placket", "Full Zipper", "Cowl", "Merino" };
        public readonly static string[] JumperSize = { "XS", "S", "M", "L", "XL" };
        private int[,] TempStockChanges;
        private const int JUMPERTYPE1 = 0, JUMPERTYPE2 = 1, JUMPERTYPE3 = 2, JUMPERTYPE4 = 3, JUMPERTYPE5 = 4, JUMPERTYPE6 = 5, JUMPERTYPE7 = 6, JUMPERTYPE8 = 7, JUMPERTYPE9 = 8, JUMPERTYPE10 = 9;
        private const int JUMPERSIZE1 = 0, JUMPERSIZE2 = 1, JUMPERSIZE3 = 2, JUMPERSIZE4 = 3, JUMPERSIZE5 = 4;
        private int JumperTypeSelected, JumperSizeSelected;
        private List<string> JumperNames = new List<string>(); // List for jumper names
        private List<string> JumperSizes = new List<string>(); // List for jumper sizes
        private List<int> JumperQuantities = new List<int>(); // List for jumper quantities
        public static int[,] OpeningStock = new int[NumberofJumperTypes, NumberofJumperSizes];
        public static int[,] RunningCurrentStock = new int[NumberofJumperTypes, NumberofJumperSizes];
        public readonly static decimal[,] PRICES = { { 15m,16m,18m,20m,22m },
                              { 13m,15m,17m,19m,20m },
                              { 11m,14m,16m,18m,23m },
                              { 9m,13m,15m,17m,19m },
                              { 7m,12m,14m,16m,18m },
                              { 24m,26m,28m,30m,32m },
                              { 35m,38m,39m,40m,43m },
                              { 63m,64m,65m,66m,68m },
                              { 32m,34m,36m,37m,40m },
                              { 21m,22m,23m,24m,25m }
                            };

        private string FileName = "StockQuantityData.txt";


        public SalesForm()
        {
            InitializeComponent();
        }


        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadStockDataFromFile();

            // Copy data from CurrentStock to RunningCurrentStock
            CopyStockData(OpeningStock, RunningCurrentStock);
        }

        private void LoadStockDataFromFile()
        {
            int rows,columns,index = 0;
            string[] values, AllRecordRow;

            try
            {
                
                // Read the file lines into a string array
                AllRecordRow = File.ReadAllLines(FileName);

                // Determine the size of the 2D array
                rows = AllRecordRow.Length;                       
                columns = AllRecordRow[index].Split(',').Length;

                // Fill the 2D array with values
                for (int i = 0; i < rows; i++)
                {
                    // Split the line into individual string values
                    values = AllRecordRow[i].Split(',');

                    for (int j = 0; j < columns; j++)
                    {
                        // Parse and store each value in the 2D array
                        OpeningStock[i, j] = int.Parse(values[j]);
                    }
                }
                
            }
            catch (Exception ex)
            {
                // Display any exception messages
                MessageBox.Show(ex.Message);
            }
        }
        
        private void CopyStockData(int[,] FromArray, int[,] ToArray)
        {
            // Copy data from CurrentStock to RunningCurrentStock

            for (int i = 0; i < FromArray.GetLength(0); i++) // Loop through rows
            {
                for (int j = 0; j < FromArray.GetLength(1); j++) // Loop through columns
                {
                    ToArray[i, j] = FromArray[i, j]; // Copy each element
                }
            }
        }

        private void JumperType1Button_Click(object sender, EventArgs e)
        {
            
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE1;
            JumperType1Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE1);
            
        }

        private void JumperType2Button_Click(object sender, EventArgs e)
        {
            
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE2;
            JumperType2Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE2);
        }

        private void JumperType3Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE3;
            JumperType3Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE3);
        }

        private void JumperType4Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE4;
            JumperType4Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE4);
        }

        private void JumperType5Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE5;
            JumperType5Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE5);
        }

        private void JumperType6Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE6;
            JumperType6Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE6);
        }

        private void JumperType7Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE7;
            JumperType7Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE7);
        }

        private void JumperType8Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE8;
            JumperType8Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE8);
        }

        private void JumperType9Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE9;
            JumperType9Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE9);
        }

        private void JumperType10Button_Click(object sender, EventArgs e)
        {
            ResetJumperTypeInputButtons();
            JumperTypeSelected = JUMPERTYPE10;
            JumperType10Button.BackColor = Color.Pink;
            IsJumperTypeSelected = true;
            DisplayJumperPrice(JUMPERTYPE10);
        }

        private void JumperSize1Button_Click(object sender, EventArgs e)
        {
            ResetJumperSizeInputButtons();
            JumperSizeSelected = JUMPERSIZE1;
            JumperSize1Button.BackColor = Color.Pink;
            IsJumperSizeSelected = true;
        }

        private void JumperSize2Button_Click(object sender, EventArgs e)
        {
            ResetJumperSizeInputButtons();
            JumperSizeSelected = JUMPERSIZE2;
            JumperSize2Button.BackColor = Color.Pink;
            IsJumperSizeSelected = true;
        }

        private void JumperSize3Button_Click(object sender, EventArgs e)
        {
            ResetJumperSizeInputButtons();
            JumperSizeSelected = JUMPERSIZE3;
            JumperSize3Button.BackColor = Color.Pink;
            IsJumperSizeSelected = true;
        }

        private void JumperSize4Button_Click(object sender, EventArgs e)
        {
            ResetJumperSizeInputButtons();
            JumperSizeSelected = JUMPERSIZE4;
            JumperSize4Button.BackColor = Color.Pink;
            IsJumperSizeSelected = true;
        }

        private void JumperSize5Button_Click(object sender, EventArgs e)
        {
            ResetJumperSizeInputButtons();
            JumperSizeSelected = JUMPERSIZE5;
            JumperSize5Button.BackColor = Color.Pink;
            IsJumperSizeSelected = true;
        }


        private void ResetJumperTypeInputButtons()
        {

            JumperType1Button.BackColor = Color.White;
            JumperType2Button.BackColor = Color.White;
            JumperType3Button.BackColor = Color.White;
            JumperType4Button.BackColor = Color.White;
            JumperType5Button.BackColor = Color.White;
            JumperType6Button.BackColor = Color.White;
            JumperType7Button.BackColor = Color.White;
            JumperType8Button.BackColor = Color.White;
            JumperType9Button.BackColor = Color.White;
            JumperType10Button.BackColor = Color.White;

        }

        private void ResetJumperSizeInputButtons()
        {

            JumperSize1Button.BackColor = Color.White;
            JumperSize2Button.BackColor = Color.White;
            JumperSize3Button.BackColor = Color.White;
            JumperSize4Button.BackColor = Color.White;
            JumperSize5Button.BackColor = Color.White;

        }


        private void DisplayJumperPrice(int JumperType)
        {
            JumperSize1PriceLabel.Text = PRICES[JumperType, 0].ToString("C2");
            JumperSize2PriceLabel.Text = PRICES[JumperType, 1].ToString("C2");
            JumperSize3PriceLabel.Text = PRICES[JumperType, 2].ToString("C2");
            JumperSize4PriceLabel.Text = PRICES[JumperType, 3].ToString("C2");
            JumperSize5PriceLabel.Text = PRICES[JumperType, 4].ToString("C2");
        }         
       
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            
            int JumperQuantity, JumperInStockQuantity;


            if (IsJumperTypeSelected)
            {
                if (IsJumperSizeSelected)
                {
                    if (JumperQuantityInput.Value > 0)
                    {

                        // Initialize the TempStockChanges array if it's null or uninitialized
                        if (TempStockChanges == null)
                        {
                            TempStockChanges = new int[RunningCurrentStock.GetLength(0), RunningCurrentStock.GetLength(1)];

                        }

                        JumperQuantity = (int)JumperQuantityInput.Value;
                        JumperInStockQuantity = RunningCurrentStock[JumperTypeSelected, JumperSizeSelected];

                        if (JumperQuantity <= (JumperInStockQuantity - TempStockChanges[JumperTypeSelected, JumperSizeSelected]))
                        {
                            CartDetailsPanel.Visible = true;
                            OrderIndexNum++;
                            ItemPrice = (int)JumperQuantityInput.Value * PRICES[JumperTypeSelected, JumperSizeSelected];
                            OrderOutput = FormatOrderOutput();
                            CartListBox.Items.Add(OrderOutput);
                            TotalOrderCost += ItemPrice;
                            TotalOrderOutputLabel.Text = TotalOrderCost.ToString("C2");
                                                        

                            // Update stock level
                            TempStockChanges[JumperTypeSelected, JumperSizeSelected] += JumperQuantity;

                            // Check stock levels against the Threshold
                            CheckStockThreshold(LOWSTOCK_Threshold);

                            // Add order details to the respective lists
                            JumperNames.Add(JumperName[JumperTypeSelected]);
                            JumperSizes.Add(JumperSize[JumperSizeSelected]);
                            JumperQuantities.Add(JumperQuantity);

                            ResetJumperTypeInputButtons();
                            ResetJumperSizeInputButtons();
                            JumperQuantityInput.Value = 1;
                            OrderButton.Enabled = true;
                            JumperSize1PriceLabel.Text = string.Empty;
                            JumperSize2PriceLabel.Text = string.Empty;
                            JumperSize3PriceLabel.Text = string.Empty;
                            JumperSize4PriceLabel.Text = string.Empty;
                            JumperSize5PriceLabel.Text = string.Empty;
                            IsJumperTypeSelected = false;
                            IsJumperSizeSelected = false;
                        }
                        else
                        {
                            JumperQuantityInput.Focus();
                            JumperQuantityInput.Select();
                            MessageBox.Show($"Not Enough Stock!!!. Availabel Stock of {JumperName[JumperTypeSelected]} and Size {JumperSize[JumperSizeSelected]} is {RunningCurrentStock[JumperTypeSelected, JumperSizeSelected] - TempStockChanges[JumperTypeSelected, JumperSizeSelected]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                        
                    }
                    else
                    {
                        JumperQuantityInput.Focus();
                        JumperQuantityInput.Select();
                        MessageBox.Show("Please Enter Value that is Greater Than Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Jumper Size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Jumper Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void CheckStockThreshold(int Threshold)
        {
            List<string> LowStockItems = new List<string>(); // List to track low stock items

            for (int i = 0; i < RunningCurrentStock.GetLength(0); i++) // Loop through jumper types
            {
                for (int j = 0; j < RunningCurrentStock.GetLength(1); j++) // Loop through jumper sizes
                {
                    int CurrentStock = RunningCurrentStock[i, j];
                    int TempStockChange = TempStockChanges[i, j];
                    int NewStock = CurrentStock - TempStockChange;

                    if (NewStock < Threshold)
                    {
                        LowStockItems.Add($"{JumperName[i]} (Size {JumperSize[j]}): {NewStock} remaining");
                    }
                }
            }

            if (LowStockItems.Count > 0)
            {
                string message = "The following items are below the Threshold limit:\n" + string.Join("\n", LowStockItems);
                MessageBox.Show(message, "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void OrderButton_Click(object sender, EventArgs e)
        {
            List<string> OrderDetails = new List<string>();

            for (int i = 0; i < JumperNames.Count; i++)
            {
                string JumperName = JumperNames[i];
                string JumperSize = JumperSizes[i];
                int Quantity = JumperQuantities[i];

                OrderDetails.Add($"{JumperName} (Size {JumperSize}) x {Quantity}");

            }

            // Show order details in confirmation pop-up
            string OrderSummary = string.Join("\n", OrderDetails);
            OrderSummary += $"\n\nTotal Price: {TotalOrderCost:C2}";

            if (MessageBox.Show(OrderSummary,"Please Confirm the Order: ",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                // Apply temporary changes to the running stock
                for (int i = 0; i < TempStockChanges.GetLength(0); i++)
                {
                    for (int j = 0; j < TempStockChanges.GetLength(1); j++)
                    {
                        RunningCurrentStock[i, j] -= TempStockChanges[i, j]; // Apply changes to the running stock
                    }
                }

                // Save the transaction data
                SaveTransactionData();

                OrderDetails.Clear();
                ClearOrderButton_Click(sender, e);
            }
            else
            {
                OrderDetails.Clear();
            }
            
        }
        private string GetUniqueRandomTransactionNumber()
        {
            const string TRANSACTIONS_FILE = "TransactionData.txt"; // Path to the transaction data file
            string TransactionNo;
            string[] AllFileLines;
            int Index;
            string Default = "000000";

            Random Random = new Random();

            try
            {
                AllFileLines = File.ReadAllLines(TRANSACTIONS_FILE);

                do
                {
                    // Generate a random 6-digit number as a transaction number
                    TransactionNo = Random.Next(100000, 999999).ToString();

                    // Check if this transaction number already exists in the file
                    Index = Array.IndexOf(AllFileLines, TransactionNo);

                } while (Index != -1); // Repeat while the index is not -1 (i.e., transaction number exists in file)
                return TransactionNo;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, etc.)
                string errorMessage = string.Format("Error accessing or reading the file '{0}'. Details: {1}", TRANSACTIONS_FILE, ex.Message);
            }

            return Default;
        }

        private void SaveTransactionData()
        {
            string TransactionFilePath = "TransactionData.txt"; // Path to the transaction data file
            string TransactionNumber = GetUniqueRandomTransactionNumber(); // Get a unique transaction number
            string Date = DateTime.Now.ToString("dd-MM-yyyy"); // Get the current date in the specified format

            List<string> OrderDetails = new List<string>();

            for (int i = 0; i < TempStockChanges.GetLength(0); i++) // Loop through jumper types
            {
                for (int j = 0; j < TempStockChanges.GetLength(1); j++) // Loop through jumper sizes
                {
                    int Quantity = TempStockChanges[i, j]; // Get the quantity from TempStockChanges
                    if (Quantity > 0) // Only include quantities greater than zero
                    {

                        decimal Price = PRICES[i, j] * Quantity;

                        OrderDetails.Add($"{JumperName[i]}\n{JumperSize[j]}\n{Quantity}\n{Price:C2}");
                    }
                }
            }

            // Prepare the full transaction record
            string transactionRecord = TransactionNumber + "\n" +
                                       Date + "\n" +
                                       string.Join("\n", OrderDetails) + "\n" +
                                       "****************\n" +
                                       $"{TotalOrderCost:C2}\n" +
                                       "----------------";

            // Write the transaction to the file
            File.AppendAllText(TransactionFilePath, transactionRecord + Environment.NewLine);
        }


        private void TransactionHistoryButton_Click(object sender, EventArgs e)
        {
            // Open the Sales Report Form
            TransactionHistoryForm transactionHistoryForm = new TransactionHistoryForm();
            transactionHistoryForm.ShowDialog();
        }

        private void StockReportButton_Click(object sender, EventArgs e)
        {
            // Path to Input File and Output File
            string InputFilePath = "StockQuantityData.txt";
            string OutputFilePath = $"Stock Report ({DateTime.Now:dd-MM-yyyy}).txt";

            try
            {
                // Read stock data from input file into a 2D array
                int[,] StockData = new int[JumperName.Length, JumperSize.Length];
                string[] Lines = File.ReadAllLines(InputFilePath);

                for (int i = 0; i < JumperName.Length; i++)
                {
                    string[] values = Lines[i].Split(',');
                    for (int j = 0; j < JumperSize.Length; j++)
                    {
                        StockData[i, j] = int.Parse(values[j]);
                    }
                }

                // Write stock report to the output file
                using (StreamWriter Writer = new StreamWriter(OutputFilePath))
                {
                    // Write report header
                    Writer.WriteLine($"Trading Day: {DateTime.Now:dd-MM-yyyy}, Report Generation Time : {DateTime.Now:HH:mm:ss}");
                    Writer.WriteLine();

                    // Write column headers (Jumper Sizes)
                    Writer.Write("".PadRight(25));
                    foreach (string Size in JumperSize)
                    {
                        Writer.Write($"{Size,-8}");
                    }
                    Writer.WriteLine();

                    // Write stock data with Jumper Names
                    for (int i = 0; i < JumperName.Length; i++)
                    {
                        Writer.Write($"{JumperName[i],-25}");
                        for (int j = 0; j < JumperSize.Length; j++)
                        {
                            int StockValue = StockData[i, j];
                            string FormattedValue;
                            if (StockValue < 4)
                            {
                                FormattedValue = $"({StockValue})";
                            }
                            else
                            {
                                FormattedValue = StockValue.ToString();
                            }
                            Writer.Write($"{FormattedValue,-8}");
                        }
                        Writer.WriteLine();
                    }

                    // Write the low stock note at the bottom
                    Writer.WriteLine();
                    Writer.WriteLine("() - Stock for this particular Jumper is low and needs to be ordered");
                }

                // Show message box on successful generation
                MessageBox.Show($"Stock report generated successfully!\nFile Path: {Path.GetFullPath(OutputFilePath)}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string FormatOrderOutput()
        {
            return $"{OrderIndexNum,-4} {JumperDisplayName[JumperTypeSelected],-15} {JumperSize[JumperSizeSelected],-19} {JumperQuantityInput.Value,-5} {ItemPrice:C2}";
        }

        private void ClearOrderButton_Click(object sender, EventArgs e)
        {
            JumperNames.Clear();
            JumperSizes.Clear();
            JumperQuantities.Clear();
            CartDetailsPanel.Visible = false;
            OrderButton.Enabled = false;
            ResetJumperTypeInputButtons();
            ResetJumperSizeInputButtons();
            JumperQuantityInput.Value = 1;
            CartListBox.Items.Clear();
            JumperSize1PriceLabel.Text = string.Empty;
            JumperSize2PriceLabel.Text = string.Empty;
            JumperSize3PriceLabel.Text = string.Empty;
            JumperSize4PriceLabel.Text = string.Empty;
            JumperSize5PriceLabel.Text = string.Empty;
            TotalOrderOutputLabel.Text = string.Empty;
            OrderIndexNum = 0;
            TotalOrderCost = 0;
            IsJumperTypeSelected = false;
            IsJumperSizeSelected = false;
            TempStockChanges = null;
        }


        private void DailySalesReport_Click(object sender, EventArgs e)
        {
            // Open the Sales Report Form
            DailySalesReportForm reportForm = new DailySalesReportForm();
            reportForm.ShowDialog();
        }



        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearOrderButton_Click(sender,e);
            SaveStockData(); // Save stock data to file

        }

        private void SaveStockData()
        {
            // Copy data from RunningCurrentStock to CurrentStock
            CopyStockData(RunningCurrentStock, OpeningStock);

            try
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    for (int i = 0; i < OpeningStock.GetLength(0); i++) // Jumper types
                    {
                        string line = "";
                        for (int j = 0; j < OpeningStock.GetLength(1); j++) // Jumper sizes
                        {
                            line += OpeningStock[i, j].ToString();
                            if (j < OpeningStock.GetLength(1) - 1)
                            {
                                line += ","; // Add a comma between sizes
                            }
                                
                        }
                        writer.WriteLine(line); // Write the row
                    }
                }
                MessageBox.Show("Stock data saved successfully!", "Save Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving stock data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
