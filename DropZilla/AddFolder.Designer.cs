namespace DropZilla
{
    partial class AddFolder
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
            this.btn_create = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.grb_new = new System.Windows.Forms.GroupBox();
            this.rdb_new = new System.Windows.Forms.RadioButton();
            this.rdb_upload = new System.Windows.Forms.RadioButton();
            this.grb_upload = new System.Windows.Forms.GroupBox();
            this.lbl_upload = new System.Windows.Forms.Label();
            this.txt_upload = new System.Windows.Forms.TextBox();
            this.btn_upload = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grb_new.SuspendLayout();
            this.grb_upload.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(108, 224);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 0;
            this.btn_create.Text = "Erstellen";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(6, 58);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(178, 20);
            this.txt_name.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(6, 42);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(128, 13);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Name des neuen Ordners";
            // 
            // grb_new
            // 
            this.grb_new.Controls.Add(this.txt_name);
            this.grb_new.Controls.Add(this.lbl_name);
            this.grb_new.Location = new System.Drawing.Point(49, 12);
            this.grb_new.Name = "grb_new";
            this.grb_new.Size = new System.Drawing.Size(253, 100);
            this.grb_new.TabIndex = 3;
            this.grb_new.TabStop = false;
            this.grb_new.Text = "Neuen Ordner erstellen";
            // 
            // rdb_new
            // 
            this.rdb_new.AutoSize = true;
            this.rdb_new.Checked = true;
            this.rdb_new.Location = new System.Drawing.Point(12, 54);
            this.rdb_new.Name = "rdb_new";
            this.rdb_new.Size = new System.Drawing.Size(14, 13);
            this.rdb_new.TabIndex = 4;
            this.rdb_new.TabStop = true;
            this.rdb_new.UseVisualStyleBackColor = true;
            this.rdb_new.CheckedChanged += new System.EventHandler(this.rdb_new_CheckedChanged);
            // 
            // rdb_upload
            // 
            this.rdb_upload.AutoSize = true;
            this.rdb_upload.Location = new System.Drawing.Point(13, 155);
            this.rdb_upload.Name = "rdb_upload";
            this.rdb_upload.Size = new System.Drawing.Size(14, 13);
            this.rdb_upload.TabIndex = 5;
            this.rdb_upload.UseVisualStyleBackColor = true;
            this.rdb_upload.CheckedChanged += new System.EventHandler(this.rdb_upload_CheckedChanged);
            // 
            // grb_upload
            // 
            this.grb_upload.Controls.Add(this.btn_upload);
            this.grb_upload.Controls.Add(this.txt_upload);
            this.grb_upload.Controls.Add(this.lbl_upload);
            this.grb_upload.Enabled = false;
            this.grb_upload.Location = new System.Drawing.Point(49, 118);
            this.grb_upload.Name = "grb_upload";
            this.grb_upload.Size = new System.Drawing.Size(253, 100);
            this.grb_upload.TabIndex = 6;
            this.grb_upload.TabStop = false;
            this.grb_upload.Text = "Ordner hochladen";
            // 
            // lbl_upload
            // 
            this.lbl_upload.AutoSize = true;
            this.lbl_upload.Location = new System.Drawing.Point(9, 37);
            this.lbl_upload.Name = "lbl_upload";
            this.lbl_upload.Size = new System.Drawing.Size(29, 13);
            this.lbl_upload.TabIndex = 0;
            this.lbl_upload.Text = "Pfad";
            // 
            // txt_upload
            // 
            this.txt_upload.Location = new System.Drawing.Point(9, 54);
            this.txt_upload.Name = "txt_upload";
            this.txt_upload.Size = new System.Drawing.Size(175, 20);
            this.txt_upload.TabIndex = 1;
            // 
            // btn_upload
            // 
            this.btn_upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_upload.Location = new System.Drawing.Point(190, 51);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(31, 23);
            this.btn_upload.TabIndex = 2;
            this.btn_upload.Text = "...";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // AddFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 260);
            this.Controls.Add(this.grb_upload);
            this.Controls.Add(this.rdb_upload);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.rdb_new);
            this.Controls.Add(this.grb_new);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFolder";
            this.Text = "AddFolder";
            this.grb_new.ResumeLayout(false);
            this.grb_new.PerformLayout();
            this.grb_upload.ResumeLayout(false);
            this.grb_upload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.GroupBox grb_new;
        private System.Windows.Forms.RadioButton rdb_new;
        private System.Windows.Forms.RadioButton rdb_upload;
        private System.Windows.Forms.GroupBox grb_upload;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.TextBox txt_upload;
        private System.Windows.Forms.Label lbl_upload;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}