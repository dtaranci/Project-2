using ClassLibrary1;
using ClassLibrary1.Resources;
using Newtonsoft.Json.Linq;
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
using static ClassLibrary1.Initclass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOPNETProject
{
    public partial class InitForm : Form
    {
        private string PATH;

        //private IMyClass myClass = Class1Factory.GetClass1(); //          fix
        public InitForm()
        {
            InitializeComponent();
        }

        public InitForm(Initclass initclass) : this()
        {
            if ((int)initclass.SelectedGender == 0)
            {
                rbMale.Select();
            }
            else
            {
                rbFemale.Select();
            }
            if ((int)initclass.SelectedLanguage == 0)
            {
                cBLanguage.SelectedIndex = cBLanguage.FindString("Croatian");
            }
            else
            {
                cBLanguage.SelectedIndex = cBLanguage.FindString("English");
            }
            if ((int)initclass.SelectedMethod == 0)
            {
                rbAPI.Select();
            }
            else
            {
                rbFile.Select();
            }
        }

        public InitForm(string pATH) : this()
        {
            PATH = pATH;
        }

        public InitForm(Initclass initclass, CultureInfo currentUICulture) : this(initclass)
        {
            Thread.CurrentThread.CurrentUICulture = currentUICulture;


            this.Text = Resource.settings;

            groupBox1.Text = Resource.priority;
            groupBox2.Text = Resource.language;
            groupBox3.Text = Resource.datasource;

            rbMale.Text = Resource.male;
            rbFemale.Text = Resource.female;
            rbAPI.Text = Resource.api;
            rbFile.Text = Resource.file;

            btnCancel.Text = Resource.cancel;
            btnSave.Text = Resource.save;

        }

        public InitForm(Initclass initclass, string pATH, CultureInfo currentUICulture) : this(initclass, currentUICulture)
        {
            PATH = pATH;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AskAndSave();

        }

        private void AskAndSave()
        {
            var res = new ExitForm(Thread.CurrentThread.CurrentUICulture, Resource.save).ShowDialog();
            if (res == DialogResult.OK)
            {
                int gen = -1;
                int lang = -1;
                int method = -1;

                if (rbMale.Checked)
                {
                    gen = 0;
                }
                else if (rbFemale.Checked)
                {
                    gen = 1;
                }
                if (rbAPI.Checked)
                {
                    method = 0;
                }
                else if (rbFile.Checked)
                {
                    method = 1;
                }
                lang = cBLanguage.SelectedIndex;

                try
                {
                    Initclass.WriteToFile(PATH, new Initclass
                    {
                        SelectedGender = (Gender)gen,
                        SelectedLanguage = (Language)lang,
                        SelectedResolution = (Resolution)0,
                        //SelectedTeam = new ClassLibrary1.Models.Two.Team { Code = "www", Country = "test", Goals = 10, Penalties = 99 },
                        SelectedMethod = (AccessMethod)method
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void InitForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyData == Keys.Enter)
            {
                AskAndSave();
            }
        }
    }
}
