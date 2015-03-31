using System.Drawing;
using System.Windows.Forms;

namespace DropZilla
{
    public partial class LoadingForm : Form
    {
        Form parents;

        public LoadingForm(Form Parent)
        {
            InitializeComponent();
            this.parents = Parent;
            Rectangle rect = Screen.GetBounds(this);
            this.Location = new Point((rect.Width - this.Size.Width) / 2, (rect.Height - this.Size.Height) / 2);
        }

        private void LoadingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parents.Opacity = 100;
        }
    }
}
