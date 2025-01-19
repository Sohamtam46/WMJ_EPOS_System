using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMJ_EPOS_System
{
    public partial class TransactionHistoryForm : Form
    {
        public TransactionHistoryForm()
        {
            InitializeComponent();
        }

        // Event handler for the 'Search By Option' button click
        private void SearchByOptionEnterButton_Click(object sender, EventArgs e)
        {
            // Check if an option is selected in the ListBox
            if (SearchByOptionsListBox.SelectedIndex != -1)
            {
                SearchPanel.Visible = true; // Display the search panel

                // If the first option (e.g., search by date) is selected
                if (SearchByOptionsListBox.SelectedIndex == 0)
                {
                    // Prepare the UI for date-based search
                    SearchResultsListBox.Items.Clear();
                    SearchResultsListBox.Visible = false;
                    SearchCriteriaDateDayTextBox.Text = string.Empty;
                    SearchCriteriaDateMonthTextBox.Text = string.Empty;
                    SearchCriteriaDateYearTextBox.Text = string.Empty;
                    SearchByDatePanel.Visible = true; // Show date input panel
                    SearchByTransactionNumberTextBox.Visible = false; // Hide transaction number input
                    SearchCriteriaDateDayTextBox.Focus(); // Focus on the day input
                }
                else // For search by transaction number
                {
                    // Prepare the UI for transaction number-based search
                    SearchResultsListBox.Items.Clear();
                    SearchResultsListBox.Visible = false;
                    SearchByTransactionNumberTextBox.Text = string.Empty;
                    SearchByDatePanel.Visible = false; // Hide date input panel
                    SearchByTransactionNumberTextBox.Visible = true; // Show transaction number input
                    SearchByTransactionNumberTextBox.Focus(); // Focus on the transaction number input
                }
            }
            else
            {
                // Display an error message if no option is selected
                MessageBox.Show("Please Select a Search-By Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Read the file into an array of lines
                string[] transactionLines = File.ReadAllLines("TransactionData.txt");
                string searchTerm = string.Empty;
                bool recordFound = false;

                // Clear previous search results
                SearchResultsListBox.Items.Clear();
                SearchResultsListBox.Visible = false;

                // Search by transaction number
                if (SearchByOptionsListBox.SelectedIndex == 1)
                {
                    searchTerm = SearchByTransactionNumberTextBox.Text.Trim();

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        for (int i = 0; i < transactionLines.Length; i++)
                        {
                            string line = transactionLines[i].Trim();

                            if (line.StartsWith(searchTerm)) // Transaction number match
                            {
                                recordFound = true;
                                SearchResultsListBox.Visible = true;

                                // Output transaction number
                                SearchResultsListBox.Items.Add($"Transaction Number - {line}");

                                // Output transaction date
                                string transactionDate = transactionLines[++i].Trim();
                                SearchResultsListBox.Items.Add($"Date - {transactionDate}");
                                SearchResultsListBox.Items.Add("Transaction Details:");

                                // Process transaction details until encountering "*********" or end of file
                                while (++i < transactionLines.Length && !transactionLines[i].StartsWith("*********"))
                                {
                                    // Read details for each jumper in groups of four lines
                                    if (i + 3 < transactionLines.Length) // Ensure there are enough lines for a jumper
                                    {
                                        string jumperName = transactionLines[i].Trim();         // Line 1: Jumper name
                                        string size = transactionLines[++i].Trim();             // Line 2: Size
                                        string quantity = transactionLines[++i].Trim();         // Line 3: Quantity
                                        string revenue = transactionLines[++i].Trim();          // Line 4: Revenue

                                        // Add jumper details to the SearchResultsListBox
                                        SearchResultsListBox.Items.Add(
                                            $"Jumper Type - {jumperName}, Size - {size}, Quantity - {quantity}, Revenue - {revenue}"
                                        );
                                    }
                                    else
                                    {
                                        // Handle incomplete or invalid jumper details
                                        SearchResultsListBox.Items.Add("Invalid or incomplete jumper details encountered.");
                                        break;
                                    }
                                }

                                // Output total price (as is from input)
                                if (i < transactionLines.Length && transactionLines[i].StartsWith("*********"))
                                {
                                    i++; // Move to the next line after "*********"
                                    if (i < transactionLines.Length)
                                    {
                                        string totalLine = transactionLines[i].Trim();
                                        SearchResultsListBox.Items.Add($"Total Order Price: {totalLine}");
                                    }
                                }

                                SearchResultsListBox.Items.Add("------------------------");
                            }
                        }

                        if (!recordFound)
                        {
                            MessageBox.Show($"No Record Found with '{searchTerm}' Transaction Number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input a Transaction Number to Search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Search by date
                else if (SearchByOptionsListBox.SelectedIndex == 0)
                {
                    if (!string.IsNullOrEmpty(SearchCriteriaDateDayTextBox.Text) &&
                        !string.IsNullOrEmpty(SearchCriteriaDateMonthTextBox.Text) &&
                        !string.IsNullOrEmpty(SearchCriteriaDateYearTextBox.Text))
                    {
                        string searchDate = $"{SearchCriteriaDateDayTextBox.Text}-{SearchCriteriaDateMonthTextBox.Text}-{SearchCriteriaDateYearTextBox.Text}";

                        for (int i = 0; i < transactionLines.Length; i++)
                        {
                            string line = transactionLines[i].Trim();

                            if (line == searchDate) // Date match
                            {
                                recordFound = true;
                                SearchResultsListBox.Visible = true;

                                // Output transaction number
                                SearchResultsListBox.Items.Add($"Transaction Number - {transactionLines[i - 1]}");

                                // Output transaction date
                                SearchResultsListBox.Items.Add($"Date - {searchDate}");
                                SearchResultsListBox.Items.Add("Transaction Details:");

                                // Process transaction details until encountering "*********" or end of file
                                while (++i < transactionLines.Length && !transactionLines[i].StartsWith("*********"))
                                {
                                    // Read details for each jumper in groups of four lines
                                    if (i + 3 < transactionLines.Length) // Ensure there are enough lines for a jumper
                                    {
                                        string jumperName = transactionLines[i].Trim();         // Line 1: Jumper name
                                        string size = transactionLines[++i].Trim();             // Line 2: Size
                                        string quantity = transactionLines[++i].Trim();         // Line 3: Quantity
                                        string revenue = transactionLines[++i].Trim();          // Line 4: Revenue

                                        // Add jumper details to the SearchResultsListBox
                                        SearchResultsListBox.Items.Add(
                                            $"Jumper Type - {jumperName}, Size - {size}, Quantity - {quantity}, Revenue - {revenue}"
                                        );
                                    }
                                    else
                                    {
                                        // Handle incomplete or invalid jumper details
                                        SearchResultsListBox.Items.Add("Invalid or incomplete jumper details encountered.");
                                        break;
                                    }
                                }

                                // Output total price (as is from input)
                                if (i < transactionLines.Length && transactionLines[i].StartsWith("*********"))
                                {
                                    i++; // Move to the next line after "*********"
                                    if (i < transactionLines.Length)
                                    {
                                        string totalLine = transactionLines[i].Trim();
                                        SearchResultsListBox.Items.Add($"Total Order Price: {totalLine}");
                                    }
                                }

                                SearchResultsListBox.Items.Add("------------------------");
                            }
                        }

                        if (!recordFound)
                        {
                            MessageBox.Show($"No Record Found for the date '{searchDate}'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input a Valid Date to Search (DD-MM-YYYY)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any file errors or other exceptions
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the 'Clear' button click
        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clear all input fields and reset focus
            SearchByTransactionNumberTextBox.Text = string.Empty;
            SearchCriteriaDateDayTextBox.Text = string.Empty;
            SearchCriteriaDateMonthTextBox.Text = string.Empty;
            SearchCriteriaDateYearTextBox.Text = string.Empty;
            SearchResultsListBox.Items.Clear();
            SearchResultsListBox.Visible = false;
            SearchCriteriaDateDayTextBox.Focus();
            SearchByTransactionNumberTextBox.Focus();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

