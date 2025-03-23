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
    public partial class PlayerListUserControl : UserControl, IComparable<PlayerListUserControl>
    {

        private const string rPicPath = @"..\..\..\..\..\Images\Default_image.png";
        private readonly string _defaultpicturePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPicPath));
        private const string rPicSavePath = @"..\..\..\..\..\Images\";
        private readonly string _PicSavePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPicSavePath));

        private readonly string currentloc = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public string goals;
        public string yellowcards;

        public ClassLibrary1.Models.Two.StartingEleven playerObject { get; set; }
        public PlayerListUserControl()
        {
            InitializeComponent();
        }



        public PlayerListUserControl(PlayerUserControl puc, MatchesModel2 match) : this()
        {
            playerObject = puc.playerObject;

            lblName.Text = playerObject.Name;
            lblPosition.Text = playerObject.Position.ToString();
            lblNumber.Text = playerObject.ShirtNumber.ToString();

            var union = (match.HomeTeamStatistics.StartingEleven).Union(match.HomeTeamStatistics.Substitutes);

            IEnumerable<TeamEvent> filter;

            if (union.Any(x => x.Name == playerObject.Name))
            {
                filter = match.HomeTeamEvents.Where(x => x.Player == puc.playerObject.Name);
            }
            else
            {
                filter = match.AwayTeamEvents.Where(x => x.Player == puc.playerObject.Name);
            }

            if (filter.Count() > 0 )
            {
                lblGoals.Text = filter.Where(x => x.TypeOfEvent == TypeOfEvent.Goal || x.TypeOfEvent == TypeOfEvent.GoalPenalty).Count().ToString();
                lblYellowCards.Text = filter.Where(x => x.TypeOfEvent == TypeOfEvent.YellowCard|| x.TypeOfEvent == TypeOfEvent.YellowCardSecond).Count().ToString();
            }
            else
            {
                lblGoals.Text = "0";
                lblYellowCards.Text = "0";
            }

            pictureBox2.Visible = puc.IsFavorite;
            lblCaptain.Visible = puc.playerObject.Captain;

            //if (!string.IsNullOrEmpty(playerObject.PicturePath))
            //{
            //    pictureBox1.BackgroundImage = Image.FromFile(playerObject.PicturePath); // default is set via designer
            //}

            try
            {
                if (!string.IsNullOrEmpty(playerObject.PicturePath))
                {
                    try
                    {
                        pictureBox1.BackgroundImage = Image.FromFile(Path.Combine(currentloc, playerObject.PicturePath));
                    }
                    catch (Exception)
                    {
                        pictureBox1.BackgroundImage = Image.FromFile(_defaultpicturePATH);
                    }
                }
                else
                {
                    pictureBox1.BackgroundImage = Image.FromFile(_defaultpicturePATH);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            goals = lblGoals.Text;
            yellowcards = lblYellowCards.Text;
        }

        public PlayerListUserControl(PlayerUserControl puc, MatchesModel2 match, CultureInfo currentUICulture) : this(puc, match)
        {
            Thread.CurrentThread.CurrentUICulture = currentUICulture;
            label1.Text = Resource.numberofgoals;
            label2.Text = Resource.numberofyellowcards;
        }

        public int CompareTo(PlayerListUserControl? other)
        {
                int one = int.Parse(this.lblGoals.Text);
                int two = int.Parse(other.lblGoals.Text);

                return -one.CompareTo(two);
        }

        public bool StatisticsIsNull()
        {
            return (string.IsNullOrEmpty(this.lblGoals.Text) || this.lblGoals.Text == "N/A" || string.IsNullOrEmpty(this.lblYellowCards.Text) || this.lblYellowCards.Text == "N/A");
        }
    }
}
