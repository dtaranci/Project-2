using ClassLibrary1.Models;
using ClassLibrary1.Resources;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class PlayerInfoWindow : Window
    {
        private readonly string currentloc = System.Reflection.Assembly.GetExecutingAssembly().Location;
        private const string rPicPath = @"..\..\..\..\..\Images\Default_image.png";

        private ClassLibrary1.Models.Two.StartingEleven playerObject;

        public PlayerInfoWindow()
        {
            InitializeComponent();
        }

        public PlayerInfoWindow(ClassLibrary1.Models.Two.StartingEleven player) : this()
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            playerObject = player;

            lblName.Content = player.Name;
            lblNumber.Content = player.ShirtNumber;
            lblPosition.Content = player.Position;
            lblCaptain.Content = player.Captain ? Resource.yes : Resource.no;

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

        public PlayerInfoWindow(ClassLibrary1.Models.Two.StartingEleven player, CultureInfo currentUICulture) : this(player)
        {
            Thread.CurrentThread.CurrentCulture = currentUICulture;
            labeltitle.Content = Resource.players.Substring(0,Resource.players.Length-1) +" "+ Resource.info; //quick fix
            label1.Content = Resource.name + ": ";
            label2.Content = Resource.number + ": ";
            label3.Content = Resource.position + ": ";
            label4.Content = Resource.captain + ": ";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
