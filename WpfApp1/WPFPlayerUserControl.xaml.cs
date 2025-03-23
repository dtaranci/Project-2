using ClassLibrary1.Models.Two;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for WPFPlayerUserControl.xaml
    /// </summary>
    public partial class WPFPlayerUserControl : UserControl
    {

        private readonly string currentloc = System.Reflection.Assembly.GetExecutingAssembly().Location;
        private const string rPicPath = @"..\..\..\..\..\Images\Default_image.png";

        public ClassLibrary1.Models.Two.StartingEleven playerObject;
        public bool isSubstitude;

        public WPFPlayerUserControl()
        {
            InitializeComponent();

        }

        public WPFPlayerUserControl(StartingEleven player, bool substitude) : this()
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(StartingEleven));
            }
            playerObject = player;
            isSubstitude = substitude;

            var split = player.Name.Split(' ');

            lblName.Content = split[0];
            lblSurname.Content = split.Length > 1 ? split[1] : ""; //bug fix
            if (!string.IsNullOrEmpty(lblName.Content.ToString()) && !string.IsNullOrEmpty(lblSurname.Content.ToString()))
            {
                lblNameSurname.Content = lblName.Content + " " + lblSurname.Content;
            }
            else
            {
                lblNameSurname.Content = lblName.Content;
            }

            lblNumber.Content = player.ShirtNumber.ToString();
            lblPosition.Content = player.Position.ToString();

            //if (substitude)
            //{
                //this.Background = Brushes.DarkGreen;
                //lblName.Foreground = Brushes.White;
                //lblSurname.Foreground = Brushes.White;
                //lblNumber.Foreground = Brushes.White;
                //lblPosition.Foreground = Brushes.White;
            //}

            if (!string.IsNullOrEmpty(playerObject.PicturePath))
            {
                try
                {
                    imgPlayerImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentloc, playerObject.PicturePath)));
                }
                catch (Exception)
                {
                    imgPlayerImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentloc, rPicPath)));
                }
            }
            else
            {
                imgPlayerImage.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentloc, rPicPath)));
            }
        }

        public WPFPlayerUserControl(StartingEleven player, bool substitude, CultureInfo currentUICulture) : this(player, substitude)
        {
            Thread.CurrentThread.CurrentUICulture = currentUICulture;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new PlayerInfoWindow(playerObject, Thread.CurrentThread.CurrentUICulture).ShowDialog();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
