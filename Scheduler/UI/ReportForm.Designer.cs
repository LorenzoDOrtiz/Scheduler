namespace Scheduler.UI
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.DGVReport = new System.Windows.Forms.DataGridView();
            this.ReportSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.ReportRefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReport)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVReport
            // 
            this.DGVReport.AllowUserToResizeColumns = false;
            this.DGVReport.AllowUserToResizeRows = false;
            this.DGVReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.DGVReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReport.Location = new System.Drawing.Point(12, 95);
            this.DGVReport.MultiSelect = false;
            this.DGVReport.Name = "DGVReport";
            this.DGVReport.ReadOnly = true;
            this.DGVReport.RowHeadersVisible = false;
            this.DGVReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVReport.ShowEditingIcon = false;
            this.DGVReport.Size = new System.Drawing.Size(587, 221);
            this.DGVReport.TabIndex = 0;
            this.DGVReport.DataSourceChanged += new System.EventHandler(this.DGVReport_DataSourceChanged);
            this.DGVReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVReport_CellFormatting);
            // 
            // ReportSelectionComboBox
            // 
            this.ReportSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReportSelectionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSelectionComboBox.FormattingEnabled = true;
            this.ReportSelectionComboBox.Location = new System.Drawing.Point(12, 52);
            this.ReportSelectionComboBox.Name = "ReportSelectionComboBox";
            this.ReportSelectionComboBox.Size = new System.Drawing.Size(338, 37);
            this.ReportSelectionComboBox.TabIndex = 1;
            this.ReportSelectionComboBox.SelectionChangeCommitted += new System.EventHandler(this.ReportSelectionComboBox_SelectionChangeCommitted);
            // 
            // UserComboBox
            // 
            this.UserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(356, 52);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(243, 37);
            this.UserComboBox.TabIndex = 2;
            this.UserComboBox.SelectionChangeCommitted += new System.EventHandler(this.UserComboBox_SelectionChangeCommitted);
            // 
            // ReportRefreshButton
            // 
            this.ReportRefreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReportRefreshButton.BackgroundImage")));
            this.ReportRefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReportRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReportRefreshButton.Location = new System.Drawing.Point(12, 12);
            this.ReportRefreshButton.Name = "ReportRefreshButton";
            this.ReportRefreshButton.Size = new System.Drawing.Size(42, 34);
            this.ReportRefreshButton.TabIndex = 4;
            this.ReportRefreshButton.UseVisualStyleBackColor = true;
            this.ReportRefreshButton.Click += new System.EventHandler(this.ReportRefreshButton_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(609, 328);
            this.Controls.Add(this.ReportRefreshButton);
            this.Controls.Add(this.UserComboBox);
            this.Controls.Add(this.ReportSelectionComboBox);
            this.Controls.Add(this.DGVReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.DGVReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVReport;
        private System.Windows.Forms.ComboBox ReportSelectionComboBox;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.Button ReportRefreshButton;
    }
}