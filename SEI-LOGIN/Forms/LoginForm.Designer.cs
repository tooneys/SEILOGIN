namespace SEI_LOGIN.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panelTop = new Panel();
            btnUpload = new PictureBox();
            label3 = new Label();
            btnClose = new PictureBox();
            panelMid = new Panel();
            SettingPanel = new Panel();
            groupBox1 = new GroupBox();
            btnCancel = new Button();
            btnOK = new Button();
            label4 = new Label();
            txtDatabase = new TextBox();
            label5 = new Label();
            txtDBPassword = new TextBox();
            label6 = new Label();
            txtUID = new TextBox();
            label7 = new Label();
            txtPort = new TextBox();
            label8 = new Label();
            txtDBAddress = new TextBox();
            mainScreen = new PictureBox();
            panel1 = new Panel();
            cmbCompany = new ComboBox();
            btnSettings = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtID = new TextBox();
            label2 = new Label();
            label9 = new Label();
            label1 = new Label();
            panelBot = new Panel();
            msg = new Label();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnUpload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            panelMid.SuspendLayout();
            SettingPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainScreen).BeginInit();
            panel1.SuspendLayout();
            panelBot.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnUpload);
            panelTop.Controls.Add(label3);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(919, 50);
            panelTop.TabIndex = 0;
            // 
            // btnUpload
            // 
            btnUpload.Dock = DockStyle.Right;
            btnUpload.Image = (Image)resources.GetObject("btnUpload.Image");
            btnUpload.Location = new Point(801, 0);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(59, 50);
            btnUpload.SizeMode = PictureBoxSizeMode.CenterImage;
            btnUpload.TabIndex = 2;
            btnUpload.TabStop = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(113, 29);
            label3.TabIndex = 1;
            label3.Text = "㈜ 케이언트";
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.Image = Properties.Resources.Close;
            btnClose.Location = new Point(860, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(59, 50);
            btnClose.SizeMode = PictureBoxSizeMode.CenterImage;
            btnClose.TabIndex = 0;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelMid
            // 
            panelMid.Controls.Add(SettingPanel);
            panelMid.Controls.Add(mainScreen);
            panelMid.Controls.Add(panel1);
            panelMid.Dock = DockStyle.Fill;
            panelMid.Location = new Point(0, 50);
            panelMid.Name = "panelMid";
            panelMid.Size = new Size(919, 372);
            panelMid.TabIndex = 1;
            // 
            // SettingPanel
            // 
            SettingPanel.Controls.Add(groupBox1);
            SettingPanel.Location = new Point(352, 53);
            SettingPanel.Name = "SettingPanel";
            SettingPanel.Size = new Size(252, 236);
            SettingPanel.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnOK);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtDatabase);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtDBPassword);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtUID);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtPort);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtDBAddress);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(252, 236);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "DB Settings";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(128, 187);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(47, 187);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 37);
            label4.Name = "label4";
            label4.Size = new Size(56, 14);
            label4.TabIndex = 0;
            label4.Text = "Address";
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(88, 146);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(144, 22);
            txtDatabase.TabIndex = 1;
            txtDatabase.Text = "SEIERP_STD";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 65);
            label5.Name = "label5";
            label5.Size = new Size(35, 14);
            label5.TabIndex = 0;
            label5.Text = "Port";
            // 
            // txtDBPassword
            // 
            txtDBPassword.Location = new Point(88, 118);
            txtDBPassword.Name = "txtDBPassword";
            txtDBPassword.PasswordChar = '*';
            txtDBPassword.Size = new Size(144, 22);
            txtDBPassword.TabIndex = 1;
            txtDBPassword.Text = "1234123412341234";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(54, 95);
            label6.Name = "label6";
            label6.Size = new Size(28, 14);
            label6.TabIndex = 0;
            label6.Text = "UID";
            // 
            // txtUID
            // 
            txtUID.Location = new Point(88, 90);
            txtUID.Name = "txtUID";
            txtUID.Size = new Size(144, 22);
            txtUID.TabIndex = 1;
            txtUID.Text = "sa";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 121);
            label7.Name = "label7";
            label7.Size = new Size(63, 14);
            label7.TabIndex = 0;
            label7.Text = "Password";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(88, 62);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(144, 22);
            txtPort.TabIndex = 1;
            txtPort.Text = "1234";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 149);
            label8.Name = "label8";
            label8.Size = new Size(63, 14);
            label8.TabIndex = 0;
            label8.Text = "Database";
            // 
            // txtDBAddress
            // 
            txtDBAddress.Location = new Point(88, 34);
            txtDBAddress.Name = "txtDBAddress";
            txtDBAddress.Size = new Size(144, 22);
            txtDBAddress.TabIndex = 1;
            txtDBAddress.Text = "112.111.111.111";
            // 
            // mainScreen
            // 
            mainScreen.Dock = DockStyle.Left;
            mainScreen.Image = (Image)resources.GetObject("mainScreen.Image");
            mainScreen.Location = new Point(0, 0);
            mainScreen.Name = "mainScreen";
            mainScreen.Size = new Size(613, 372);
            mainScreen.SizeMode = PictureBoxSizeMode.StretchImage;
            mainScreen.TabIndex = 0;
            mainScreen.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbCompany);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(558, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(361, 372);
            panel1.TabIndex = 1;
            // 
            // cmbCompany
            // 
            cmbCompany.FormattingEnabled = true;
            cmbCompany.Location = new Point(140, 87);
            cmbCompany.Name = "cmbCompany";
            cmbCompany.Size = new Size(167, 22);
            cmbCompany.TabIndex = 5;
            cmbCompany.TabStop = false;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(206, 182);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(88, 25);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += Settings_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(112, 182);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(88, 25);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 142);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(167, 22);
            txtPassword.TabIndex = 2;
            // 
            // txtID
            // 
            txtID.Location = new Point(140, 114);
            txtID.Name = "txtID";
            txtID.Size = new Size(167, 22);
            txtID.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 145);
            label2.Name = "label2";
            label2.Size = new Size(63, 14);
            label2.TabIndex = 0;
            label2.Text = "Password";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(78, 90);
            label9.Name = "label9";
            label9.Size = new Size(56, 14);
            label9.TabIndex = 0;
            label9.Text = "Company";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 117);
            label1.Name = "label1";
            label1.Size = new Size(21, 14);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // panelBot
            // 
            panelBot.Controls.Add(msg);
            panelBot.Dock = DockStyle.Bottom;
            panelBot.Location = new Point(0, 422);
            panelBot.Name = "panelBot";
            panelBot.Size = new Size(919, 50);
            panelBot.TabIndex = 2;
            // 
            // msg
            // 
            msg.AutoSize = true;
            msg.Location = new Point(29, 18);
            msg.Name = "msg";
            msg.Size = new Size(179, 14);
            msg.TabIndex = 0;
            msg.Text = "업데이트 파일이 있는지 확인중입니다.";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(919, 472);
            Controls.Add(panelMid);
            Controls.Add(panelBot);
            Controls.Add(panelTop);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SEIERP LOGIN";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnUpload).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            panelMid.ResumeLayout(false);
            SettingPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainScreen).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelBot.ResumeLayout(false);
            panelBot.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Panel panelMid;
        private PictureBox mainScreen;
        private Panel panelBot;
        private Panel panel1;
        private Button btnSettings;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtID;
        private Label label2;
        private Label label1;
        private PictureBox btnClose;
        private Label msg;
        private Label label3;
        private Panel SettingPanel;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox txtDatabase;
        private TextBox txtDBPassword;
        private TextBox txtUID;
        private TextBox txtPort;
        private TextBox txtDBAddress;
        private Button btnCancel;
        private Button btnOK;
        private PictureBox btnUpload;
        private ComboBox cmbCompany;
        private Label label9;
    }
}