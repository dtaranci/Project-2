using ClassLibrary1.Models;
using ClassLibrary1.Models.Test;
using ClassLibrary1.Models.Two;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOPNETProject
{
    public partial class NonModalMessageBox() : Form
    {
        private string Teams { get; set; }
        private string Matches { get; set; }
        private string FifaMatches { get; set; }
        private string Results { get; set; }

        //private IList<TeamsModel> ModelTeams { get; set; }
        //private IList<MatchesModel> ModelMatches { get; set; }
        //private IList<FifaCodeMatchModel> ModelFifaMatches { get; set; }
        //private IList<ResultsModel> ModelResults { get; set; }
        public NonModalMessageBox(string teams, string matches, string fifamatches, string results) : this()
        {
            InitializeComponent();
            Teams = teams;
            Matches = matches;
            FifaMatches = fifamatches;
            Results = results;
        }
        public NonModalMessageBox(IList<TeamsModel> teams, IList<MatchesModel2> matches, IList<FifaCodeMatchModel> fifamatches, IList<ResultsModel> results) : this()
        {
            InitializeComponent();
            StringBuilder sb = new StringBuilder();
            string[] temp = new string[4];
            Task.Run(() =>
            {
                teams.ToList().ForEach(x => sb.Append(x));
                temp[0] = sb.ToString();
                sb.Clear();

                matches.ToList().ForEach(x => sb.Append(x));
                temp[1] = sb.ToString();
                sb.Clear();

                fifamatches.ToList().ForEach(x => sb.Append(x));
                temp[2] = sb.ToString();
                sb.Clear();

                results.ToList().ForEach(x => sb.Append(x));
                temp[3] = sb.ToString();
                sb.Clear();

                Teams = temp[0];
                Matches = temp[1];
                FifaMatches = temp[2];
                Results = temp[3];
            });

        }

        private void NonModalMessageBox_Load(object sender, EventArgs e)
        {
            tBTeams.Text = Teams;
            tBMatches.Text = Matches;
            tBFifa.Text = FifaMatches;
            tBResults.Text = Results;
            tBResults.Select(0,0);
            bool isnull = false;
            foreach (Control control in Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    if (String.IsNullOrEmpty(textBox.Text))
                    {
                        isnull = true;
                        break;
                    }
                }
            }
            lblStatus.ForeColor = isnull ? Color.Red : Color.Green;
            lblStatus.Text = isnull ? "FAIL" : "PASS";
        }
    }
}
