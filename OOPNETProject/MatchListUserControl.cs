using ClassLibrary1.Models.Two;
using ClassLibrary1.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace OOPNETProject
{
    public partial class MatchListUserControl : UserControl, IComparable<MatchListUserControl>
    {

        private const string rPicPath = @"..\..\..\..\..\Images\Default_image.png";
        private readonly string _defaultpicturePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPicPath));
        private const string rPicSavePath = @"..\..\..\..\..\Images\";
        private readonly string _PicSavePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPicSavePath));

        private readonly string currentloc = System.Reflection.Assembly.GetExecutingAssembly().Location;


        public ClassLibrary1.Models.Two.MatchesModel2 matchObject { get; set; }
        public MatchListUserControl()
        {
            InitializeComponent();
        }


        /*
         * Create a ranking list of the number of visitors for a specific match - it is necessary to display the location, number of
         * visitors, the name of the host ("home_team") and the name of the guest ("away_team").
         * Note: all rankings refer to the selected national team
         */ 
        public MatchListUserControl(MatchesModel2 match) : this()
        {
            if (match == null)
            {
                throw new Exception(nameof(match));
            }
            matchObject = match;

            lblVenue.Text = matchObject.Venue;
            lblLocation.Text = matchObject.Location;
            lblVisitors.Text = matchObject.Attendance.ToString();
            lblHometeam.Text = matchObject.HomeTeamCountry;
            lblAwayteam.Text = matchObject.AwayTeamCountry;
            lblDate.Text = matchObject.Datetime.ToString();
        }

        public MatchListUserControl(MatchesModel2 match, CultureInfo currentUICulture) : this(match)
        {
            Thread.CurrentThread.CurrentUICulture = currentUICulture;
            Thread.CurrentThread.CurrentCulture = currentUICulture;

            //todo
        }

        public int CompareTo(MatchListUserControl? other)
        {
            int one = int.Parse(this.lblVisitors.Text) ;
            int two = int.Parse(other.lblVisitors.Text);

            return -one.CompareTo(two);
        }
    }
}
