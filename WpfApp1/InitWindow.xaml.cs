using ClassLibrary1;
using ClassLibrary1.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static WpfApp1.SaveInfoClass;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for InitWindow.xaml
    /// </summary>
    /// 
    public partial class InitWindow : Window
    {
        private readonly string PATH;

        private const string rPATH = @"..\..\..\..\..\Text\appinit.txt";
        private readonly string aPATH = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPATH));
        //private const string FavsPATH = "favs.txt";

        public InitWindow()
        {
            InitializeComponent();
            cbLanguage.SelectedIndex = 1;
            cbWindowSize.SelectedIndex = 0;
            rbMale.IsChecked = true;
            rbAPI.IsChecked = true;
        }

        public InitWindow(CultureInfo currentUICulture) : this()
        {
            Thread.CurrentThread.CurrentCulture = currentUICulture;
        }

        public InitWindow(CultureInfo currentUICulture, string path) : this(currentUICulture)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            PATH = path;
        }

        public InitWindow(CultureInfo currentUICulture, Initclass initclass, string pATH) : this(currentUICulture, pATH) // display current settings, no change in functionality, just nicer
        {
            if (initclass == null)
            {
                throw new ArgumentNullException(nameof(initclass));
            }
            switch (initclass.SelectedGender)
            {
                case Initclass.Gender.Male:
                    rbMale.IsChecked = true;
                    rbFemale.IsChecked = false;
                    break;
                case Initclass.Gender.Female:
                    rbMale.IsChecked = false;
                    rbFemale.IsChecked = true;
                    break;
                default:
                    break;
            }
            switch (initclass.SelectedLanguage)
            {
                case Initclass.Language.Croatian:
                    cbLanguage.SelectedIndex = 0;
                    break;
                case Initclass.Language.English:
                    cbLanguage.SelectedIndex = 1;
                    break;
                default:
                    break;
            }
            switch (initclass.SelectedResolution)
            {
                case Initclass.Resolution.Res1:
                    cbWindowSize.SelectedIndex = 0;
                    break;
                case Initclass.Resolution.Res2:
                    cbWindowSize.SelectedIndex = 1;
                    break;
                case Initclass.Resolution.Res3:
                    cbWindowSize.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
            switch (initclass.SelectedMethod)
            {
                case Initclass.AccessMethod.API:
                    rbAPI.IsChecked = true;
                    rbFile.IsChecked = false;
                    break;
                case Initclass.AccessMethod.File:
                    rbAPI.IsChecked = false;
                    rbFile.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        public InitWindow(string pATH) :this()
        {
            PATH = pATH;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            AskAndSave();
        }

        private void AskAndSave()
        {
            var result = new ExitWindow().ShowDialog();
            if (result == true)
            {
                int gen = -1;
                int lang = -1;
                int method = -1;
                int res = -1;

                if ((bool)rbMale.IsChecked)
                {
                    gen = 0;
                }
                else if ((bool)rbFemale.IsChecked)
                {
                    gen = 1;
                }
                if ((bool)rbAPI.IsChecked)
                {
                    method = 0;
                }
                else if ((bool)rbFile.IsChecked)
                {
                    method = 1;
                }
                lang = cbLanguage.SelectedIndex;
                res = cbWindowSize.SelectedIndex;
                try
                {
                    //SaveInfoClass.WriteToFile("appinit.txt", new SaveInfoClass
                    SaveInfoClass.WriteToFile(PATH, new SaveInfoClass
                    {
                        SelectedGender = (Gender)gen,
                        SelectedLanguage = (Language)lang,
                        SelectedMethod = (AccessMethod)method,
                        SelectedResolution = (Resolution)res
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show(Resource.success, Resource.save, MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult= false;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
                this.Close();
            }
            else if (e.Key == Key.Enter)
            {
                AskAndSave();
            }
        }
    }
}
