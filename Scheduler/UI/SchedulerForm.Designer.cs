namespace Scheduler.UI 
{ 
    partial class SchedulerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerForm));
            this.CustomerAddButton = new System.Windows.Forms.Button();
            this.CustomerDeleteButton = new System.Windows.Forms.Button();
            this.WeeklyRadioButton = new System.Windows.Forms.RadioButton();
            this.MonthRadioButton = new System.Windows.Forms.RadioButton();
            this.DGVCustomers = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.CustomerModifyButton = new System.Windows.Forms.Button();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.AppointmentLabel = new System.Windows.Forms.Label();
            this.AppointmentAddButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.AppointmentModifyButton = new System.Windows.Forms.Button();
            this.AppointmentDeleteButton = new System.Windows.Forms.Button();
            this.DGVCalendarAndRadio = new System.Windows.Forms.DataGridView();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.DGVAppointments = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentTimeTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCustomers)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCalendarAndRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointments)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomerAddButton
            // 
            this.CustomerAddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.CustomerAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomerAddButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomerAddButton.Location = new System.Drawing.Point(3, 3);
            this.CustomerAddButton.Name = "CustomerAddButton";
            this.CustomerAddButton.Size = new System.Drawing.Size(119, 34);
            this.CustomerAddButton.TabIndex = 0;
            this.CustomerAddButton.Text = "Add";
            this.CustomerAddButton.UseVisualStyleBackColor = false;
            this.CustomerAddButton.Click += new System.EventHandler(this.CustomerAddButton_Click);
            // 
            // CustomerDeleteButton
            // 
            this.CustomerDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.CustomerDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomerDeleteButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomerDeleteButton.Location = new System.Drawing.Point(253, 3);
            this.CustomerDeleteButton.Name = "CustomerDeleteButton";
            this.CustomerDeleteButton.Size = new System.Drawing.Size(119, 34);
            this.CustomerDeleteButton.TabIndex = 2;
            this.CustomerDeleteButton.Text = "Delete";
            this.CustomerDeleteButton.UseVisualStyleBackColor = false;
            this.CustomerDeleteButton.Click += new System.EventHandler(this.CustomerDeleteButton_Click);
            // 
            // WeeklyRadioButton
            // 
            this.WeeklyRadioButton.AutoSize = true;
            this.WeeklyRadioButton.ForeColor = System.Drawing.SystemColors.Control;
            this.WeeklyRadioButton.Location = new System.Drawing.Point(9, 234);
            this.WeeklyRadioButton.Name = "WeeklyRadioButton";
            this.WeeklyRadioButton.Size = new System.Drawing.Size(151, 17);
            this.WeeklyRadioButton.TabIndex = 115;
            this.WeeklyRadioButton.TabStop = true;
            this.WeeklyRadioButton.Text = "This Week\'s Appointments";
            this.WeeklyRadioButton.UseVisualStyleBackColor = true;
            this.WeeklyRadioButton.CheckedChanged += new System.EventHandler(this.WeeklyRadioButton_CheckedChanged);
            // 
            // MonthRadioButton
            // 
            this.MonthRadioButton.AutoSize = true;
            this.MonthRadioButton.ForeColor = System.Drawing.SystemColors.Control;
            this.MonthRadioButton.Location = new System.Drawing.Point(166, 234);
            this.MonthRadioButton.Name = "MonthRadioButton";
            this.MonthRadioButton.Size = new System.Drawing.Size(152, 17);
            this.MonthRadioButton.TabIndex = 116;
            this.MonthRadioButton.TabStop = true;
            this.MonthRadioButton.Text = "This Month\'s Appointments";
            this.MonthRadioButton.UseVisualStyleBackColor = true;
            this.MonthRadioButton.CheckedChanged += new System.EventHandler(this.MonthRadioButton_CheckedChanged);
            // 
            // DGVCustomers
            // 
            this.DGVCustomers.AllowUserToOrderColumns = true;
            this.DGVCustomers.AllowUserToResizeColumns = false;
            this.DGVCustomers.AllowUserToResizeRows = false;
            this.DGVCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCustomers.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DGVCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.DGVCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCustomers.Location = new System.Drawing.Point(12, 632);
            this.DGVCustomers.MultiSelect = false;
            this.DGVCustomers.Name = "DGVCustomers";
            this.DGVCustomers.ReadOnly = true;
            this.DGVCustomers.RowHeadersVisible = false;
            this.DGVCustomers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DGVCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCustomers.Size = new System.Drawing.Size(1062, 188);
            this.DGVCustomers.TabIndex = 113;
            this.DGVCustomers.TabStop = false;
            this.DGVCustomers.DataSourceChanged += new System.EventHandler(this.DGVCustomers_DataSourceChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.CustomerAddButton);
            this.flowLayoutPanel3.Controls.Add(this.CustomerModifyButton);
            this.flowLayoutPanel3.Controls.Add(this.CustomerDeleteButton);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(9, 826);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(391, 44);
            this.flowLayoutPanel3.TabIndex = 111;
            // 
            // CustomerModifyButton
            // 
            this.CustomerModifyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.CustomerModifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomerModifyButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomerModifyButton.Location = new System.Drawing.Point(128, 3);
            this.CustomerModifyButton.Name = "CustomerModifyButton";
            this.CustomerModifyButton.Size = new System.Drawing.Size(119, 34);
            this.CustomerModifyButton.TabIndex = 1;
            this.CustomerModifyButton.Text = "Modify";
            this.CustomerModifyButton.UseVisualStyleBackColor = false;
            this.CustomerModifyButton.Click += new System.EventHandler(this.CustomerModifyButton_Click);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomerLabel.Location = new System.Drawing.Point(12, 593);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(124, 25);
            this.CustomerLabel.TabIndex = 110;
            this.CustomerLabel.Text = "Customers";
            // 
            // AppointmentLabel
            // 
            this.AppointmentLabel.AutoSize = true;
            this.AppointmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppointmentLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AppointmentLabel.Location = new System.Drawing.Point(12, 291);
            this.AppointmentLabel.Name = "AppointmentLabel";
            this.AppointmentLabel.Size = new System.Drawing.Size(155, 25);
            this.AppointmentLabel.TabIndex = 109;
            this.AppointmentLabel.Text = "Appointments";
            // 
            // AppointmentAddButton
            // 
            this.AppointmentAddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.AppointmentAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AppointmentAddButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AppointmentAddButton.Location = new System.Drawing.Point(3, 3);
            this.AppointmentAddButton.Name = "AppointmentAddButton";
            this.AppointmentAddButton.Size = new System.Drawing.Size(119, 34);
            this.AppointmentAddButton.TabIndex = 0;
            this.AppointmentAddButton.Text = "Add";
            this.AppointmentAddButton.UseVisualStyleBackColor = false;
            this.AppointmentAddButton.Click += new System.EventHandler(this.AppointmentAddButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.AppointmentAddButton);
            this.flowLayoutPanel2.Controls.Add(this.AppointmentModifyButton);
            this.flowLayoutPanel2.Controls.Add(this.AppointmentDeleteButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(9, 525);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(391, 42);
            this.flowLayoutPanel2.TabIndex = 108;
            // 
            // AppointmentModifyButton
            // 
            this.AppointmentModifyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.AppointmentModifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AppointmentModifyButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AppointmentModifyButton.Location = new System.Drawing.Point(128, 3);
            this.AppointmentModifyButton.Name = "AppointmentModifyButton";
            this.AppointmentModifyButton.Size = new System.Drawing.Size(119, 34);
            this.AppointmentModifyButton.TabIndex = 1;
            this.AppointmentModifyButton.Text = "Modify";
            this.AppointmentModifyButton.UseVisualStyleBackColor = false;
            this.AppointmentModifyButton.Click += new System.EventHandler(this.AppointmentModifyButton_Click);
            // 
            // AppointmentDeleteButton
            // 
            this.AppointmentDeleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.AppointmentDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AppointmentDeleteButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AppointmentDeleteButton.Location = new System.Drawing.Point(253, 3);
            this.AppointmentDeleteButton.Name = "AppointmentDeleteButton";
            this.AppointmentDeleteButton.Size = new System.Drawing.Size(119, 34);
            this.AppointmentDeleteButton.TabIndex = 2;
            this.AppointmentDeleteButton.Text = "Delete";
            this.AppointmentDeleteButton.UseVisualStyleBackColor = false;
            this.AppointmentDeleteButton.Click += new System.EventHandler(this.AppointmentDeleteButton_Click);
            // 
            // DGVCalendarAndRadio
            // 
            this.DGVCalendarAndRadio.AllowUserToOrderColumns = true;
            this.DGVCalendarAndRadio.AllowUserToResizeColumns = false;
            this.DGVCalendarAndRadio.AllowUserToResizeRows = false;
            this.DGVCalendarAndRadio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCalendarAndRadio.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DGVCalendarAndRadio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVCalendarAndRadio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.DGVCalendarAndRadio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCalendarAndRadio.Location = new System.Drawing.Point(245, 71);
            this.DGVCalendarAndRadio.MultiSelect = false;
            this.DGVCalendarAndRadio.Name = "DGVCalendarAndRadio";
            this.DGVCalendarAndRadio.ReadOnly = true;
            this.DGVCalendarAndRadio.RowHeadersVisible = false;
            this.DGVCalendarAndRadio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DGVCalendarAndRadio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCalendarAndRadio.Size = new System.Drawing.Size(829, 162);
            this.DGVCalendarAndRadio.TabIndex = 107;
            this.DGVCalendarAndRadio.TabStop = false;
            this.DGVCalendarAndRadio.DataSourceChanged += new System.EventHandler(this.DGVCalendarAndRadio_DataSourceChanged);
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.MonthCalendar.Location = new System.Drawing.Point(9, 71);
            this.MonthCalendar.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.MonthCalendar.MaxSelectionCount = 1;
            this.MonthCalendar.MinDate = new System.DateTime(1945, 9, 2, 0, 0, 0, 0);
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.ScrollChange = 1;
            this.MonthCalendar.TabIndex = 103;
            this.MonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateSelected);
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(4)))), ((int)(((byte)(9)))));
            this.CurrentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTimeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(1009, 4);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(64, 16);
            this.CurrentTimeLabel.TabIndex = 106;
            this.CurrentTimeLabel.Text = "12: 00 AM";
            // 
            // DGVAppointments
            // 
            this.DGVAppointments.AllowUserToOrderColumns = true;
            this.DGVAppointments.AllowUserToResizeColumns = false;
            this.DGVAppointments.AllowUserToResizeRows = false;
            this.DGVAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVAppointments.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DGVAppointments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVAppointments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.DGVAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAppointments.Location = new System.Drawing.Point(9, 331);
            this.DGVAppointments.MultiSelect = false;
            this.DGVAppointments.Name = "DGVAppointments";
            this.DGVAppointments.ReadOnly = true;
            this.DGVAppointments.RowHeadersVisible = false;
            this.DGVAppointments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DGVAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVAppointments.Size = new System.Drawing.Size(1065, 188);
            this.DGVAppointments.TabIndex = 105;
            this.DGVAppointments.TabStop = false;
            this.DGVAppointments.DataSourceChanged += new System.EventHandler(this.DGVAppointments_DataSourceChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(4)))), ((int)(((byte)(9)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1090, 24);
            this.menuStrip1.TabIndex = 104;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateReportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generateReportToolStripMenuItem.Text = "Generate Report";
            this.generateReportToolStripMenuItem.Click += new System.EventHandler(this.generateReportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // currentTimeTimer
            // 
            this.currentTimeTimer.Enabled = true;
            this.currentTimeTimer.Interval = 1000;
            this.currentTimeTimer.Tick += new System.EventHandler(this.currentTimeTimer_Tick);
            // 
            // SchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1090, 882);
            this.Controls.Add(this.WeeklyRadioButton);
            this.Controls.Add(this.MonthRadioButton);
            this.Controls.Add(this.DGVCustomers);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.AppointmentLabel);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.DGVCalendarAndRadio);
            this.Controls.Add(this.MonthCalendar);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.DGVAppointments);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SchedulerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SchedulerForm";
            this.Activated += new System.EventHandler(this.SchedulerForm_Activated);
            this.Shown += new System.EventHandler(this.SchedulerForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCustomers)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCalendarAndRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAppointments)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CustomerAddButton;
        private System.Windows.Forms.Button CustomerDeleteButton;
        private System.Windows.Forms.RadioButton WeeklyRadioButton;
        private System.Windows.Forms.RadioButton MonthRadioButton;
        private System.Windows.Forms.DataGridView DGVCustomers;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button CustomerModifyButton;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label AppointmentLabel;
        private System.Windows.Forms.Button AppointmentAddButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button AppointmentModifyButton;
        private System.Windows.Forms.Button AppointmentDeleteButton;
        private System.Windows.Forms.DataGridView DGVCalendarAndRadio;
        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.DataGridView DGVAppointments;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer currentTimeTimer;
    }
}