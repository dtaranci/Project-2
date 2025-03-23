using ClassLibrary1.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNETProject
{
    public partial class ExitForm : Form
    {
        public ExitForm()
        {
            InitializeComponent();
        }

        public ExitForm(CultureInfo currentUICulture, string title) : this()
        {
            Thread.CurrentThread.CurrentUICulture = currentUICulture;

            lblText.Text = Resource.areyousure;

            btnConfirm.Text = Resource.confirm;
            btnCancel.Text = Resource.cancel;

            btnConfirm.TabStop = false;
            btnCancel.TabStop = false;

            pictureBox1.BackgroundImage = System.Drawing.SystemIcons.Question.ToBitmap();

            this.Text = title;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ExitForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyData == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
