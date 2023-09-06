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
            panelTop = new Panel();
            label3 = new Label();
            btnClose = new PictureBox();
            UploadedList = new ListView();
            colNM_FILE = new ColumnHeader();
            colDT_UPLOAD = new ColumnHeader();
            colNM_DIR = new ColumnHeader();
            AddList = new ListView();
            fileName = new ColumnHeader();
            btnAddFiles = new Button();
            btnUpload = new Button();
            btnDelete = new Button();
            cmbDownFolder = new ComboBox();
            progressBar = new ProgressBar();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(label3);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(20, 60);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(660, 50);
            panelTop.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(151, 29);
            label3.TabIndex = 2;
            label3.Text = "실행파일 업로드";
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.Image = Properties.Resources.Close;
            btnClose.Location = new Point(601, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(59, 50);
            btnClose.SizeMode = PictureBoxSizeMode.CenterImage;
            btnClose.TabIndex = 1;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // UploadedList
            // 
            UploadedList.Columns.AddRange(new ColumnHeader[] { colNM_FILE, colDT_UPLOAD, colNM_DIR });
            UploadedList.Location = new Point(378, 85);
            UploadedList.Name = "UploadedList";
            UploadedList.Size = new Size(310, 274);
            UploadedList.TabIndex = 0;
            UploadedList.UseCompatibleStateImageBehavior = false;
            UploadedList.View = View.Details;
            // 
            // colNM_FILE
            // 
            colNM_FILE.Text = "파일명";
            colNM_FILE.Width = 100;
            // 
            // colDT_UPLOAD
            // 
            colDT_UPLOAD.Text = "업로드일자";
            colDT_UPLOAD.Width = 80;
            // 
            // colNM_DIR
            // 
            colNM_DIR.Text = "폴더";
            // 
            // AddList
            // 
            AddList.Columns.AddRange(new ColumnHeader[] { fileName });
            AddList.Location = new Point(12, 85);
            AddList.Name = "AddList";
            AddList.Size = new Size(360, 274);
            AddList.TabIndex = 2;
            AddList.UseCompatibleStateImageBehavior = false;
            AddList.View = View.Details;
            // 
            // fileName
            // 
            fileName.Text = "파일명";
            fileName.Width = 200;
            // 
            // btnAddFiles
            // 
            btnAddFiles.Location = new Point(12, 56);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new Size(75, 23);
            btnAddFiles.TabIndex = 3;
            btnAddFiles.Text = "파일선택";
            btnAddFiles.UseVisualStyleBackColor = true;
            btnAddFiles.Click += btnAddFiles_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(297, 56);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(75, 23);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "업로드";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(378, 56);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cmbDownFolder
            // 
            cmbDownFolder.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDownFolder.FormattingEnabled = true;
            cmbDownFolder.Items.AddRange(new object[] { "EXECUTE", "PRINT", "DATA", "ETC" });
            cmbDownFolder.Location = new Point(600, 57);
            cmbDownFolder.Name = "cmbDownFolder";
            cmbDownFolder.Size = new Size(88, 23);
            cmbDownFolder.TabIndex = 4;
            cmbDownFolder.TabStop = false;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.Green;
            progressBar.Location = new Point(12, 365);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(676, 23);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 5;
            // 
            // SystemFileUpload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 400);
            Controls.Add(progressBar);
            Controls.Add(cmbDownFolder);
            Controls.Add(btnDelete);
            Controls.Add(btnUpload);
            Controls.Add(btnAddFiles);
            Controls.Add(AddList);
            Controls.Add(UploadedList);
            Controls.Add(panelTop);
            Name = "SystemFileUpload";
            Text = "실행파일 업로드";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelTop;
        private ListView UploadedList;
        private ColumnHeader colNM_FILE;
        private ColumnHeader colDT_UPLOAD;
        private ColumnHeader colNM_DIR;
        private PictureBox btnClose;
        private ListView AddList;
        private Button btnAddFiles;
        private Button btnUpload;
        private Button btnDelete;
        private ColumnHeader fileName;
        private ComboBox cmbDownFolder;
        private ProgressBar progressBar;
        private Label label3;
    }
}