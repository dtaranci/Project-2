using ClassLibrary1.Models.Two;
using ClassLibrary1.Resources;
using System;
using System.CodeDom.Compiler;
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
    public partial class RankingForm : Form
    {
        private IList<PlayerUserControl> players;
        private IList<MatchesModel2> _matches;
        private string selectedcountry;

        private const string rPicPath = @"..\..\..\..\..\Images\Default_image.png";
        private readonly string _defaultpicturePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPicPath));

        private const string rStadiumPicPath = @"..\..\..\..\..\Images\Stadium.png";
        private readonly string _stadiumdefaultpicturePATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rStadiumPicPath));


        private int currentpagetoprint = 0;
        private RankingForm()
        {
            InitializeComponent();
        }

        private RankingForm(IList<MatchesModel2> matches) : this()
        {

        }

        public RankingForm(IList<PlayerUserControl> players, IList<MatchesModel2> matches, object? selectedItem) : this(matches)
        {
            this.players = players;
            this._matches = matches;
            string temp = selectedItem.ToString();
            selectedcountry = temp.Split(' ')[0];

            matches.ToList().ForEach(match =>
            {
                if (match.HomeTeamCountry == selectedcountry || match.AwayTeamCountry == selectedcountry)
                {
                    cBMatch.Items.Add(match);
                    //cBMatch2.Items.Add(match);
                }
            });
            FillVisitors();
        }

        private void FillVisitors()
        {
            flpVisitors.Controls.Clear();
            List<MatchListUserControl> list = new List<MatchListUserControl>();
            foreach (ClassLibrary1.Models.Two.MatchesModel2 match in _matches)
            {
                if (match.HomeTeamCountry == selectedcountry || match.AwayTeamCountry == selectedcountry)
                {
                    var temp = new MatchListUserControl((ClassLibrary1.Models.Two.MatchesModel2)match, Thread.CurrentThread.CurrentUICulture);
                    list.Add(temp);
                }
            }
            list.Sort((x, y) => x.CompareTo(y));

            list.ToList().ForEach(x =>
            {
                // if (!x.StatisticsIsNull())
                //{
                flpVisitors.Controls.Add(x);
                //}
            });
        }

        public RankingForm(IList<PlayerUserControl> players, IList<MatchesModel2> matches, object? selectedItem, CultureInfo currentUICulture) : this(players, matches, selectedItem)
        {
            Thread.CurrentThread.CurrentUICulture = currentUICulture;


            this.Text = Resource.ranking;

            tabControl1.TabPages[0].Text = Resource.players;
            tabControl1.TabPages[1].Text = Resource.matches;

            printToolStripMenuItem.Text = Resource.print;
            pageSetupToolStripMenuItem.Text = Resource.pagesetup;
            printPreviewToolStripMenuItem.Text = Resource.printpreview;
            printToolStripMenuItem1.Text = Resource.print;

            lblMatch.Text = Resource.matchlist;

            label1.Text = Resource.match + ":";
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var controlsender = sender as Control;
            if (controlsender.Name == cBMatch.Name)
            {
                flpRanking.Controls.Clear();
                List<PlayerListUserControl> list = new List<PlayerListUserControl>();
                foreach (PlayerUserControl player in players)
                {
                    var temp = new PlayerListUserControl(player, (ClassLibrary1.Models.Two.MatchesModel2)cBMatch.SelectedItem, Thread.CurrentThread.CurrentUICulture);
                    list.Add(temp);
                }
                list.Sort((x, y) => x.CompareTo(y));

                list.ToList().ForEach(x =>
                {
                    // if (!x.StatisticsIsNull())
                    //{
                    flpRanking.Controls.Add(x);
                    //}
                });
            }
            /*else if (controlsender.Name == cBMatch2.Name)
            {

            }*/
        }

        private void RankingForm_Shown(object sender, EventArgs e)
        {
            cBMatch.SelectedIndex = 0;
            //cBMatch2.SelectedIndex = 0;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





        /*
         * ------------------------------ PRINTING --------------------------------------------
         */
        private Bitmap ImageForPrinting;
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureControl();
            printPreviewDialog1.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            };
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int maxWidth = 1080;
            int maxHeight = 1920;

            //if (tabControl1.SelectedIndex == 0) //print only selected tab
            if (currentpagetoprint == 0) //print all
            {
                e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, maxWidth, maxHeight));
                //this.WindowState = FormWindowState.Maximized;


                //e.Graphics.DrawImage(ImageForPrinting, 0, 0,maxWidth,flpRanking.Height);
                e.Graphics.DrawString(Resource.rankinglist, new Font("Arial", 12), Brushes.Black, 400, 10);
                int x = 0;
                int y = 100;
                foreach (PlayerListUserControl puc in flpRanking.Controls)
                {
                    e.Graphics.DrawImage((string.IsNullOrEmpty(puc.playerObject.PicturePath) ? GetImageFromRelativePath(_defaultpicturePATH,30,30) : GetImageFromRelativePath(puc.playerObject.PicturePath,30,30)), 10, y-5);
                    e.Graphics.DrawString(puc.playerObject.Name, new Font("Arial", 12), Brushes.Black, 100, y);
                    e.Graphics.DrawString(Resource.number+": "+puc.playerObject.ShirtNumber.ToString(), new Font("Arial", 12), Brushes.Black, 300, y);
                    e.Graphics.DrawString(puc.playerObject.Position.ToString(), new Font("Arial", 12), Brushes.Black, 500, y);
                    e.Graphics.DrawString(Resource.goals+": " + puc.goals, new Font("Arial", 12), Brushes.Black, 600, y);
                    e.Graphics.DrawString(Resource.yellowcards+": " + puc.yellowcards, new Font("Arial", 12), Brushes.Black, 700, y);
                    e.Graphics.DrawString(Environment.NewLine, new Font("Arial", 12), Brushes.Black, 100, y);
                    e.Graphics.DrawLine(new Pen(Color.Black), new Point { X = 0, Y = y + 30 }, new Point { X = 1000, Y = y + 30 });

                    y += 40;
                }
                currentpagetoprint++;
                e.HasMorePages = true;
                return;
            }
            //else if (tabControl1.SelectedIndex == 1)
            if (currentpagetoprint == 1)
            {
                e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, maxWidth, maxHeight));
                //this.WindowState = FormWindowState.Maximized;


                //e.Graphics.DrawImage(ImageForPrinting, 0, 0,maxWidth,flpRanking.Height);
                e.Graphics.DrawString(Resource.visitorslist, new Font("Arial", 12), Brushes.Black, 400, 10);
                int x = 0;
                int y = 100;
                foreach (MatchListUserControl muc in flpVisitors.Controls)
                {
                    e.Graphics.DrawImage(GetImageFromRelativePath(_stadiumdefaultpicturePATH, 80, 80), 10, y - 10);

                    e.Graphics.DrawString(muc.matchObject.Location, new Font("Arial", 12), Brushes.Black, 100, y);
                    e.Graphics.DrawString(muc.matchObject.Venue, new Font("Arial", 12), Brushes.Black, 100, y+20);
                    e.Graphics.DrawString(Resource.visitors+": " + muc.matchObject.Attendance.ToString(), new Font("Arial", 12), Brushes.Black, 100, y+40);
                    e.Graphics.DrawString(Resource.hometeam+": "+ muc.matchObject.HomeTeamCountry, new Font("Arial", 12), Brushes.Black, 500, y);
                    e.Graphics.DrawString(Resource.awayteam+": " + muc.matchObject.AwayTeamCountry, new Font("Arial", 12), Brushes.Black, 500, y+20);
                    e.Graphics.DrawString(Environment.NewLine, new Font("Arial", 12), Brushes.Black, 100, y);
                    e.Graphics.DrawLine(new Pen(Color.Black), new Point { X = 0, Y= y + 100 },new Point { X = 1000, Y = y + 100});
                    y += 150;
                }
                currentpagetoprint = 0;
                e.HasMorePages = false;
                return;
            }
        }

        private Image GetImageFromRelativePath(string? relativePicturePath, int width, int height)
        {
            Image image = Image.FromFile(Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, relativePicturePath)));

            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, width, height);
            }

            return resizedImage;
        }

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            ImageForPrinting = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(ImageForPrinting);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void CaptureControl()
        {

            Rectangle rect = new Rectangle(0, 0, flpRanking.Width, flpRanking.Height);
            ImageForPrinting = new Bitmap(flpRanking.Width, flpRanking.Height);
            flpRanking.DrawToBitmap(ImageForPrinting, rect);
               
        }


    }
}
