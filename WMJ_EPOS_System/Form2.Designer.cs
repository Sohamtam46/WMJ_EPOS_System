namespace WMJ_EPOS_System
{
    partial class DailySalesReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailySalesReportForm));
            this.BackButton = new System.Windows.Forms.Button();
            this.SalesReportListBox = new System.Windows.Forms.ListBox();
            this.JumperTypeLabel = new System.Windows.Forms.Label();
            this.JumperSizeLabel = new System.Windows.Forms.Label();
            this.JumperQuantitySoldLabel = new System.Windows.Forms.Label();
            this.TotalSaleLabel = new System.Windows.Forms.Label();
            this.TodaysDateLabel = new System.Windows.Forms.Label();
            this.TodaysDateOutputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(314, 433);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(139, 45);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SalesReportListBox
            // 
            this.SalesReportListBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesReportListBox.FormattingEnabled = true;
            this.SalesReportListBox.ItemHeight = 18;
            this.SalesReportListBox.Location = new System.Drawing.Point(12, 75);
            this.SalesReportListBox.Name = "SalesReportListBox";
            this.SalesReportListBox.Size = new System.Drawing.Size(757, 346);
            this.SalesReportListBox.TabIndex = 1;
            // 
            // JumperTypeLabel
            // 
            this.JumperTypeLabel.AutoSize = true;
            this.JumperTypeLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JumperTypeLabel.Location = new System.Drawing.Point(31, 54);
            this.JumperTypeLabel.Name = "JumperTypeLabel";
            this.JumperTypeLabel.Size = new System.Drawing.Size(118, 18);
            this.JumperTypeLabel.TabIndex = 2;
            this.JumperTypeLabel.Text = "Jumper Type";
            this.JumperTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JumperSizeLabel
            // 
            this.JumperSizeLabel.AutoSize = true;
            this.JumperSizeLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JumperSizeLabel.Location = new System.Drawing.Point(185, 54);
            this.JumperSizeLabel.Name = "JumperSizeLabel";
            this.JumperSizeLabel.Size = new System.Drawing.Size(118, 18);
            this.JumperSizeLabel.TabIndex = 3;
            this.JumperSizeLabel.Text = "Jumper Size";
            this.JumperSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JumperQuantitySoldLabel
            // 
            this.JumperQuantitySoldLabel.AutoSize = true;
            this.JumperQuantitySoldLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JumperQuantitySoldLabel.Location = new System.Drawing.Point(412, 54);
            this.JumperQuantitySoldLabel.Name = "JumperQuantitySoldLabel";
            this.JumperQuantitySoldLabel.Size = new System.Drawing.Size(218, 18);
            this.JumperQuantitySoldLabel.TabIndex = 4;
            this.JumperQuantitySoldLabel.Text = "Jumper Quanitity Sold";
            this.JumperQuantitySoldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalSaleLabel
            // 
            this.TotalSaleLabel.AutoSize = true;
            this.TotalSaleLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalSaleLabel.Location = new System.Drawing.Point(646, 54);
            this.TotalSaleLabel.Name = "TotalSaleLabel";
            this.TotalSaleLabel.Size = new System.Drawing.Size(108, 18);
            this.TotalSaleLabel.TabIndex = 5;
            this.TotalSaleLabel.Text = "Total Sale";
            this.TotalSaleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TodaysDateLabel
            // 
            this.TodaysDateLabel.AutoSize = true;
            this.TodaysDateLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodaysDateLabel.Location = new System.Drawing.Point(12, 20);
            this.TodaysDateLabel.Name = "TodaysDateLabel";
            this.TodaysDateLabel.Size = new System.Drawing.Size(158, 18);
            this.TodaysDateLabel.TabIndex = 6;
            this.TodaysDateLabel.Text = "Today\'s Date : ";
            this.TodaysDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TodaysDateOutputLabel
            // 
            this.TodaysDateOutputLabel.BackColor = System.Drawing.Color.White;
            this.TodaysDateOutputLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TodaysDateOutputLabel.Location = new System.Drawing.Point(176, 20);
            this.TodaysDateOutputLabel.Name = "TodaysDateOutputLabel";
            this.TodaysDateOutputLabel.Size = new System.Drawing.Size(126, 18);
            this.TodaysDateOutputLabel.TabIndex = 7;
            // 
            // DailySalesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 489);
            this.Controls.Add(this.TodaysDateOutputLabel);
            this.Controls.Add(this.TodaysDateLabel);
            this.Controls.Add(this.TotalSaleLabel);
            this.Controls.Add(this.JumperQuantitySoldLabel);
            this.Controls.Add(this.JumperSizeLabel);
            this.Controls.Add(this.JumperTypeLabel);
            this.Controls.Add(this.SalesReportListBox);
            this.Controls.Add(this.BackButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DailySalesReportForm";
            this.Text = "Daily Sales Report";
            this.Load += new System.EventHandler(this.DailySalesReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ListBox SalesReportListBox;
        private System.Windows.Forms.Label JumperTypeLabel;
        private System.Windows.Forms.Label JumperSizeLabel;
        private System.Windows.Forms.Label JumperQuantitySoldLabel;
        private System.Windows.Forms.Label TotalSaleLabel;
        private System.Windows.Forms.Label TodaysDateLabel;
        private System.Windows.Forms.Label TodaysDateOutputLabel;
    }
}