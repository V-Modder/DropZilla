using System;
using System.Windows.Forms;

namespace DropZilla
{
    public partial class AcceptForm : Form
    {
        private string authenticationUri;
        
        public string Response
        {
            get;
            set;
        }

        public AcceptForm(string authenticationUri)
        {
            InitializeComponent();
            this.authenticationUri = authenticationUri;
        }

        private void AcceptForm_Load(object sender, EventArgs e)
        {
            this.Icon = DropZilla.Properties.Resources.main;
            webBrowser.Url = new Uri(authenticationUri);
            webBrowser.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string s = webBrowser.Url.AbsoluteUri;

            if (s.Contains("code="))
            {
                this.Response = s.Substring(s.IndexOf("code") + 5);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (webBrowser.Url != null)
            {
                string s = webBrowser.Url.AbsoluteUri;
                int x = 0;
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string s = webBrowser.Url.AbsoluteUri;

            if (s.Contains("code="))
            {
                this.Response = s.Substring(s.IndexOf("code") + 5);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
