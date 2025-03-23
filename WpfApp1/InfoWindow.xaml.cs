using ClassLibrary1.Models;
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
    public partial class InfoWindow : Window
    {
        public TeamsModel Team { get; }
        public IList<ResultsModel> ParsedResults { get; }
        public ResultsModel ResultOfTeam { get; set; }
        public InfoWindow()
        {
            InitializeComponent();
        }

        public InfoWindow(TeamsModel selectedItem, IList<ResultsModel> parsedResults) : this()
        {
            Team = selectedItem;
            ParsedResults = parsedResults;

            if (Team == null || ParsedResults == null) 
            {
                throw new ArgumentNullException(nameof(Team));
            }

            ResultOfTeam = ParsedResults.FirstOrDefault(x => x.FifaCode == Team.FifaCode);

            lblTeamName.Content = Team.ToString();

            lblID.Content = ResultOfTeam.Id.ToString();
            lblCountry.Content = ResultOfTeam.Country.ToString();
            lblAltName.Content = string.IsNullOrEmpty(ResultOfTeam.AlternateName) ? "N/A": ResultOfTeam.AlternateName;
            lblFifaCode.Content = ResultOfTeam.FifaCode.ToString();
            lblGroupID.Content = ResultOfTeam.GroupId.ToString();
            lblGroupLetter.Content = ResultOfTeam.GroupLetter.ToString();
            lblWins.Content = ResultOfTeam.Wins.ToString();
            lblDraws.Content = ResultOfTeam.Draws.ToString();
            lblLosses.Content = ResultOfTeam.Losses.ToString();
            lblGamesPlayed.Content = ResultOfTeam.GamesPlayed.ToString();
            lblPoints.Content = ResultOfTeam.Points.ToString();
            lblGoalsFor.Content = ResultOfTeam.GoalsFor.ToString();
            lblGoalsAgainst.Content = ResultOfTeam.GoalsAgainst.ToString();
            lblGoalsDifferential.Content = ResultOfTeam.GoalDifferential.ToString();
        }

        public InfoWindow(TeamsModel selectedItem, IList<ResultsModel> parsedResults, CultureInfo currentUICulture) : this(selectedItem, parsedResults)
        {
            Thread.CurrentThread.CurrentCulture = currentUICulture;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
