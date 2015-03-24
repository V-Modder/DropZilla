using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropZilla
{
    public partial class AddFolder : Form
    {
        public string FolderName
        {
            get;
            set;
        }

        public bool isNew
        {
            get;
            set;
        }

        public AddFolder()
        {
            InitializeComponent();
            this.isNew = true;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (rdb_new.Checked)
            {
                if (txt_name.Text != "")
                {
                    this.FolderName = txt_name.Text;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                if (txt_upload.Text != "")
                {
                    this.FolderName = txt_upload.Text;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void rdb_new_CheckedChanged(object sender, EventArgs e)
        {
            grb_new.Enabled = true;
            grb_upload.Enabled = false;
            btn_create.Text = "Erstellen";
            this.isNew = true;
        }

        private void rdb_upload_CheckedChanged(object sender, EventArgs e)
        {
            grb_upload.Enabled = true;
            grb_new.Enabled = false;
            btn_create.Text = "Hochladen";
            this.isNew = false;
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_upload.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
