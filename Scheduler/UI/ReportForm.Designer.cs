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
            ((System.ComponentModel.ISupportInitialize)(this.DGVReport)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVReport
            // 
            this.DGVReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReport.Location = new System.Drawing.Point(12, 68);
            this.DGVReport.Name = "DGVReport";
            this.DGVReport.Size = new System.Drawing.Size(776, 357);
            this.DGVReport.TabIndex = 0;
            // 
            // ReportSelectionComboBox
            // 
            this.ReportSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReportSelectionComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportSelectionComboBox.FormattingEnabled = true;
            this.ReportSelectionComboBox.Location = new System.Drawing.Point(12, 21);
            this.ReportSelectionComboBox.Name = "ReportSelectionComboBox";
            this.ReportSelectionComboBox.Size = new System.Drawing.Size(409, 37);
            this.ReportSelectionComboBox.TabIndex = 1;
            this.ReportSelectionComboBox.SelectionChangeCommitted += new System.EventHandler(this.ReportSelectionComboBox_SelectionChangeCommitted);
            // 
            // UserComboBox
            // 
            this.UserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.Location = new System.Drawing.Point(427, 21);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(243, 41);
            this.UserComboBox.TabIndex = 2;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(800, 437);
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
    }
}