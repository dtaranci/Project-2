using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNETProject
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = "About";
            this.labelProductName.Text = "Football Information Viewer";
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = "Copyright © 2024 Derin Taranci";
            this.labelCompanyName.Text = "Algebra University";
            this.textBoxDescription.Text = $"OOP.NET Course Project 2023 - 2024 {Environment.NewLine}{Environment.NewLine} A C# .NET 8.0 desktop application that parses JSON data from a web API and displays it with some additional features.";
        }

        #region Assembly Attribute Accessors

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        #endregion
    }
}
