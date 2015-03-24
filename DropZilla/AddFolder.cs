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

        public AddFolder()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "")
            {
                this.FolderName = txt_name.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
