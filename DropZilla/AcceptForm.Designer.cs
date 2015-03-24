namespace DropZilla
{
    partial class AcceptForm
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_warning = new System.Windows.Forms.Label();
            this.pic_one = new System.Windows.Forms.PictureBox();
            this.pic_two = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_one)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_two)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser.Location = new System.Drawing.Point(0, 29);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(904, 713);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_warning
            // 
            this.lbl_warning.AutoSize = true;
            this.lbl_warning.Location = new System.Drawing.Point(267, 9);
            this.lbl_warning.Name = "lbl_warning";
            this.lbl_warning.Size = new System.Drawing.Size(386, 13);
            this.lbl_warning.TabIndex = 1;
            this.lbl_warning.Text = "Bitte melden Sie Sich in Ihren Dropbox-Account an und Akzeptiren Sie DropZilla!";
            // 
            // pic_one
            // 
            this.pic_one.BackgroundImage = global::DropZilla.Properties.Resources.Warning;
            this.pic_one.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_one.Location = new System.Drawing.Point(0, 0);
            this.pic_one.Name = "pic_one";
            this.pic_one.Size = new System.Drawing.Size(28, 28);
            this.pic_one.TabIndex = 2;
            this.pic_one.TabStop = false;
            // 
            // pic_two
            // 
            this.pic_two.BackgroundImage = global::DropZilla.Properties.Resources.Warning;
            this.pic_two.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_two.Location = new System.Drawing.Point(876, 0);
            this.pic_two.Name = "pic_two";
            this.pic_two.Size = new System.Drawing.Size(28, 28);
            this.pic_two.TabIndex = 3;
            this.pic_two.TabStop = false;
            // 
            // AcceptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 742);
            this.Controls.Add(this.pic_two);
            this.Controls.Add(this.pic_one);
            this.Controls.Add(this.lbl_warning);
            this.Controls.Add(this.webBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AcceptForm";
            this.Text = "DropZilla";
            this.Load += new System.EventHandler(this.AcceptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_one)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_two)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_warning;
        private System.Windows.Forms.PictureBox pic_one;
        private System.Windows.Forms.PictureBox pic_two;
    }
}