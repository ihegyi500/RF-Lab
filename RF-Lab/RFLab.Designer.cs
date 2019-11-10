namespace RFLab
{
    partial class RFLab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFLab));
            this.printersLabel = new System.Windows.Forms.Label();
            this.PrintersList = new System.Windows.Forms.ComboBox();
            this.PrintAndSaveButton = new System.Windows.Forms.Button();
            this.TextBox_0 = new System.Windows.Forms.TextBox();
            this.TextBox_1 = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.newBarcode = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PrintPreviewLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // printersLabel
            // 
            this.printersLabel.AutoSize = true;
            this.printersLabel.Location = new System.Drawing.Point(30, 20);
            this.printersLabel.Name = "printersLabel";
            this.printersLabel.Size = new System.Drawing.Size(88, 13);
            this.printersLabel.TabIndex = 0;
            this.printersLabel.Text = "Available Printers\r\n";
            // 
            // PrintersList
            // 
            this.PrintersList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrintersList.FormattingEnabled = true;
            this.PrintersList.Location = new System.Drawing.Point(32, 44);
            this.PrintersList.Name = "PrintersList";
            this.PrintersList.Size = new System.Drawing.Size(240, 21);
            this.PrintersList.TabIndex = 1;
            // 
            // PrintAndSaveButton
            // 
            this.PrintAndSaveButton.Location = new System.Drawing.Point(32, 99);
            this.PrintAndSaveButton.Name = "PrintAndSaveButton";
            this.PrintAndSaveButton.Size = new System.Drawing.Size(85, 23);
            this.PrintAndSaveButton.TabIndex = 2;
            this.PrintAndSaveButton.Text = "Print and Save";
            this.PrintAndSaveButton.UseVisualStyleBackColor = true;
            this.PrintAndSaveButton.Click += new System.EventHandler(this.PrintAndSaveButton_Click);
            // 
            // TextBox_0
            // 
            this.TextBox_0.Location = new System.Drawing.Point(300, 45);
            this.TextBox_0.Name = "TextBox_0";
            this.TextBox_0.Size = new System.Drawing.Size(100, 20);
            this.TextBox_0.TabIndex = 6;
            // 
            // TextBox_1
            // 
            this.TextBox_1.Location = new System.Drawing.Point(300, 90);
            this.TextBox_1.Name = "TextBox_1";
            this.TextBox_1.PasswordChar = '*';
            this.TextBox_1.Size = new System.Drawing.Size(100, 20);
            this.TextBox_1.TabIndex = 7;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(320, 25);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(55, 13);
            this.userLabel.TabIndex = 5;
            this.userLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(320, 70);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 6;
            this.passwordLabel.Text = "Password";
            // 
            // newBarcode
            // 
            this.newBarcode.Location = new System.Drawing.Point(300, 131);
            this.newBarcode.Name = "newBarcode";
            this.newBarcode.Size = new System.Drawing.Size(100, 23);
            this.newBarcode.TabIndex = 5;
            this.newBarcode.Text = "Add new Barcode";
            this.newBarcode.UseVisualStyleBackColor = true;
            this.newBarcode.Click += new System.EventHandler(this.NewBarcode_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(123, 99);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(64, 23);
            this.PrintButton.TabIndex = 3;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintingButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(197, 99);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PrintPreviewLabel
            // 
            this.PrintPreviewLabel.AutoSize = true;
            this.PrintPreviewLabel.Location = new System.Drawing.Point(30, 72);
            this.PrintPreviewLabel.Name = "PrintPreviewLabel";
            this.PrintPreviewLabel.Size = new System.Drawing.Size(78, 13);
            this.PrintPreviewLabel.TabIndex = 0;
            this.PrintPreviewLabel.TabStop = true;
            this.PrintPreviewLabel.Text = "Printer Preview";
            this.PrintPreviewLabel.Click += new System.EventHandler(this.PrintPreviewLabel_Click);
            // 
            // RFLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(438, 196);
            this.Controls.Add(this.PrintPreviewLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.newBarcode);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.TextBox_0);
            this.Controls.Add(this.TextBox_1);
            this.Controls.Add(this.PrintAndSaveButton);
            this.Controls.Add(this.PrintersList);
            this.Controls.Add(this.printersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RFLab";
            this.Text = "RF-Lab";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label printersLabel;
        private System.Windows.Forms.ComboBox PrintersList;
        private System.Windows.Forms.Button PrintAndSaveButton;
        private System.Windows.Forms.TextBox TextBox_1;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button newBarcode;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.LinkLabel PrintPreviewLabel;
        public System.Windows.Forms.TextBox TextBox_0;
    }
}

