namespace SEI_LOGIN.Forms
{
    partial class SystemFileUpload
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
            label1 = new Label();
            panelTop = new Panel();
            UploadedList = new ListView();
            colNM_FILE = new ColumnHeader();
            colDT_UPLOAD = new ColumnHeader();
            colNM_DIR = new ColumnHeader();
            btnClose = new PictureBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 68);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "Hello";
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(700, 50);
            panelTop.TabIndex = 1;
            // 
            // UploadedList
            // 
            UploadedList.Columns.AddRange(new ColumnHeader[] { colNM_FILE, colDT_UPLOAD, colNM_DIR });
            UploadedList.Location = new Point(378, 56);
            UploadedList.Name = "UploadedList";
            UploadedList.Size = new Size(310, 332);
            UploadedList.TabIndex = 0;
            UploadedList.UseCompatibleStateImageBehavior = false;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.Image = Properties.Resources.Close;
            btnClose.Location = new Point(641, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(59, 50);
            btnClose.SizeMode = PictureBoxSizeMode.CenterImage;
            btnClose.TabIndex = 1;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // SystemFileUpload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 400);
            Controls.Add(UploadedList);
            Controls.Add(panelTop);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SystemFileUpload";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SystemFileUpload";
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panelTop;
        private ListView UploadedList;
        private ColumnHeader colNM_FILE;
        private ColumnHeader colDT_UPLOAD;
        private ColumnHeader colNM_DIR;
        private PictureBox btnClose;
    }
}