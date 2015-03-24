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
            this.SuspendLayout();
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(197, 37);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 0;
            this.btn_create.Text = "Erstellen";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(12, 40);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(178, 20);
            this.txt_name.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(128, 13);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Name des neuen Ordners";
            // 
            // AddFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 72);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btn_create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFolder";
            this.Text = "AddFolder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
    }
}