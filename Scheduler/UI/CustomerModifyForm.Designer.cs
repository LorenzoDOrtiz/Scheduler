namespace Scheduler.UI
{
    partial class CustomerModifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerModifyForm));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CustomerModifyCountryComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.CustomerModifySaveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerModifyCityComboBox = new System.Windows.Forms.ComboBox();
            this.CustomerModifyAddressTextBox = new System.Windows.Forms.TextBox();
            this.CustomerModifyNameTextBox = new System.Windows.Forms.TextBox();
            this.CustomerModifyPostalCodeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.CustomerModifyPhoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(61, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 25);
            this.label7.TabIndex = 68;
            this.label7.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(48, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 66;
            this.label6.Text = "Country";
            // 
            // CustomerModifyCountryComboBox
            // 
            this.CustomerModifyCountryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerModifyCountryComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerModifyCountryComboBox.FormattingEnabled = true;
            this.CustomerModifyCountryComboBox.Location = new System.Drawing.Point(148, 123);
            this.CustomerModifyCountryComboBox.Name = "CustomerModifyCountryComboBox";
            this.CustomerModifyCountryComboBox.Size = new System.Drawing.Size(225, 33);
            this.CustomerModifyCountryComboBox.TabIndex = 65;
            this.CustomerModifyCountryComboBox.SelectionChangeCommitted += new System.EventHandler(this.CustomerModifyCountryComboBox_SelectionChangeCommitted);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(273, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 37);
            this.button2.TabIndex = 64;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CustomerModifySaveButton
            // 
            this.CustomerModifySaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.CustomerModifySaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomerModifySaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CustomerModifySaveButton.Location = new System.Drawing.Point(148, 304);
            this.CustomerModifySaveButton.Name = "CustomerModifySaveButton";
            this.CustomerModifySaveButton.Size = new System.Drawing.Size(101, 37);
            this.CustomerModifySaveButton.TabIndex = 63;
            this.CustomerModifySaveButton.Text = "Save";
            this.CustomerModifySaveButton.UseVisualStyleBackColor = false;
            this.CustomerModifySaveButton.Click += new System.EventHandler(this.CustomerModifySaveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(6, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 25);
            this.label5.TabIndex = 62;
            this.label5.Text = "Postal Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(86, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 25);
            this.label4.TabIndex = 61;
            this.label4.Text = "City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(44, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 60;
            this.label3.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(67, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 59;
            this.label1.Text = "Name";
            // 
            // CustomerModifyCityComboBox
            // 
            this.CustomerModifyCityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerModifyCityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerModifyCityComboBox.FormattingEnabled = true;
            this.CustomerModifyCityComboBox.Location = new System.Drawing.Point(148, 162);
            this.CustomerModifyCityComboBox.Name = "CustomerModifyCityComboBox";
            this.CustomerModifyCityComboBox.Size = new System.Drawing.Size(225, 33);
            this.CustomerModifyCityComboBox.TabIndex = 57;
            // 
            // CustomerModifyAddressTextBox
            // 
            this.CustomerModifyAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerModifyAddressTextBox.Location = new System.Drawing.Point(148, 84);
            this.CustomerModifyAddressTextBox.Multiline = true;
            this.CustomerModifyAddressTextBox.Name = "CustomerModifyAddressTextBox";
            this.CustomerModifyAddressTextBox.Size = new System.Drawing.Size(225, 33);
            this.CustomerModifyAddressTextBox.TabIndex = 56;
            this.CustomerModifyAddressTextBox.Leave += new System.EventHandler(this.CustomerModifyAddressTextBox_Leave);
            // 
            // CustomerModifyNameTextBox
            // 
            this.CustomerModifyNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerModifyNameTextBox.Location = new System.Drawing.Point(148, 45);
            this.CustomerModifyNameTextBox.Multiline = true;
            this.CustomerModifyNameTextBox.Name = "CustomerModifyNameTextBox";
            this.CustomerModifyNameTextBox.Size = new System.Drawing.Size(225, 33);
            this.CustomerModifyNameTextBox.TabIndex = 55;
            this.CustomerModifyNameTextBox.TextChanged += new System.EventHandler(this.CustomerModifyNameTextBox_TextChanged);
            // 
            // CustomerModifyPostalCodeTextBox
            // 
            this.CustomerModifyPostalCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerModifyPostalCodeTextBox.Location = new System.Drawing.Point(148, 201);
            this.CustomerModifyPostalCodeTextBox.Mask = "00000";
            this.CustomerModifyPostalCodeTextBox.Name = "CustomerModifyPostalCodeTextBox";
            this.CustomerModifyPostalCodeTextBox.Size = new System.Drawing.Size(225, 31);
            this.CustomerModifyPostalCodeTextBox.TabIndex = 69;
            this.CustomerModifyPostalCodeTextBox.ValidatingType = typeof(int);
            this.CustomerModifyPostalCodeTextBox.Enter += new System.EventHandler(this.CustomerModifyPostalCodeTextBox_Enter);
            // 
            // CustomerModifyPhoneTextBox
            // 
            this.CustomerModifyPhoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerModifyPhoneTextBox.Location = new System.Drawing.Point(148, 238);
            this.CustomerModifyPhoneTextBox.Mask = "000-0000";
            this.CustomerModifyPhoneTextBox.Name = "CustomerModifyPhoneTextBox";
            this.CustomerModifyPhoneTextBox.Size = new System.Drawing.Size(225, 31);
            this.CustomerModifyPhoneTextBox.TabIndex = 70;
            this.CustomerModifyPhoneTextBox.Enter += new System.EventHandler(this.CustomerModifyPhoneTextBox_Enter);
            // 
            // CustomerModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(386, 387);
            this.Controls.Add(this.CustomerModifyPhoneTextBox);
            this.Controls.Add(this.CustomerModifyPostalCodeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CustomerModifyCountryComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CustomerModifySaveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerModifyCityComboBox);
            this.Controls.Add(this.CustomerModifyAddressTextBox);
            this.Controls.Add(this.CustomerModifyNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerModifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Customer";
            this.Load += new System.EventHandler(this.CustomerModifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CustomerModifyCountryComboBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CustomerModifySaveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CustomerModifyCityComboBox;
        private System.Windows.Forms.TextBox CustomerModifyAddressTextBox;
        private System.Windows.Forms.TextBox CustomerModifyNameTextBox;
        private System.Windows.Forms.MaskedTextBox CustomerModifyPostalCodeTextBox;
        private System.Windows.Forms.MaskedTextBox CustomerModifyPhoneTextBox;
    }
}