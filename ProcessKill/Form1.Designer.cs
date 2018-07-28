namespace ProcessKill
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnBasla = new System.Windows.Forms.Button();
            this.txtZaman = new System.Windows.Forms.TextBox();
            this.cmbTur = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.listProcess = new System.Windows.Forms.ListBox();
            this.btnGetProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP :";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(314, 16);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "192.168.100.1";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(314, 42);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(314, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pass :";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(420, 16);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(42, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "22";
            // 
            // btnBasla
            // 
            this.btnBasla.Enabled = false;
            this.btnBasla.Location = new System.Drawing.Point(408, 147);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(75, 23);
            this.btnBasla.TabIndex = 8;
            this.btnBasla.Text = "Start";
            this.btnBasla.UseVisualStyleBackColor = true;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // txtZaman
            // 
            this.txtZaman.Location = new System.Drawing.Point(337, 102);
            this.txtZaman.Name = "txtZaman";
            this.txtZaman.Size = new System.Drawing.Size(42, 20);
            this.txtZaman.TabIndex = 9;
            this.txtZaman.Text = "60";
            // 
            // cmbTur
            // 
            this.cmbTur.FormattingEnabled = true;
            this.cmbTur.Items.AddRange(new object[] {
            "Hour",
            "Minute",
            "Second"});
            this.cmbTur.Location = new System.Drawing.Point(385, 101);
            this.cmbTur.Name = "cmbTur";
            this.cmbTur.Size = new System.Drawing.Size(121, 21);
            this.cmbTur.TabIndex = 10;
            this.cmbTur.Text = "Second";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Every Time Period:";
            // 
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.Location = new System.Drawing.Point(12, 173);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(10, 13);
            this.lblSonuc.TabIndex = 12;
            this.lblSonuc.Text = "-";
            // 
            // listProcess
            // 
            this.listProcess.FormattingEnabled = true;
            this.listProcess.Location = new System.Drawing.Point(13, 23);
            this.listProcess.Name = "listProcess";
            this.listProcess.Size = new System.Drawing.Size(221, 147);
            this.listProcess.TabIndex = 13;
            this.listProcess.SelectedIndexChanged += new System.EventHandler(this.listProcess_SelectedIndexChanged);
            // 
            // btnGetProcess
            // 
            this.btnGetProcess.Location = new System.Drawing.Point(243, 147);
            this.btnGetProcess.Name = "btnGetProcess";
            this.btnGetProcess.Size = new System.Drawing.Size(124, 23);
            this.btnGetProcess.TabIndex = 14;
            this.btnGetProcess.Text = "Bring Processes First";
            this.btnGetProcess.UseVisualStyleBackColor = true;
            this.btnGetProcess.Click += new System.EventHandler(this.btnGetProcess_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 200);
            this.Controls.Add(this.btnGetProcess);
            this.Controls.Add(this.listProcess);
            this.Controls.Add(this.lblSonuc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTur);
            this.Controls.Add(this.txtZaman);
            this.Controls.Add(this.btnBasla);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fortigate Process Killer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBasla;
        private System.Windows.Forms.TextBox txtZaman;
        private System.Windows.Forms.ComboBox cmbTur;
        internal System.Windows.Forms.TextBox txtIP;
        internal System.Windows.Forms.TextBox txtUsername;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.ListBox listProcess;
        private System.Windows.Forms.Button btnGetProcess;
    }
}

