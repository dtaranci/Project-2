using ClassLibrary1;
using ClassLibrary1.Constants;
using ClassLibrary1.Exceptions;
using ClassLibrary1.JsonParser;
using ClassLibrary1.Models;
using ClassLibrary1.Models.Test;
using ClassLibrary1.Models.Two;
using ClassLibrary1.Resources;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

namespace OOPNETProject
{
    public partial class Form1 : Form
    {
        // Applicaiton settings parser related

        private const string rPATH = @"..\..\..\..\..\Text\appinit.txt";
        private readonly string PATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPATH));
        //private const string FavsPATH = "favs.txt";
        private const string rFavsPATH = @"..\..\..\..\Text\favs.txt";
        private readonly string FavsPATH = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rFavsPATH));
        private const string rPlayersPATH = @"..\..\..\..\Text\players.txt";
        private readonly string PlayersPATH = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rPlayersPATH));

        internal IRepository repository;

        //Inital settings class
        private Initclass initclass;
        private Favoritesclass favoritesclass;
        private PlayersNotFavorite playersclass;

        // JSON parser related
        internal IJsonParser parser;

        //Endpoint selection (M or F)
        private string[] EndpointSelection;

        // Parsed JSON storage
        private IList<TeamsModel> ParsedTeams = new List<TeamsModel>();
        private IList<MatchesModel2> ParsedMatches = new List<MatchesModel2>();
        private IList<ResultsModel> ParsedResults = new List<ResultsModel>();
        private IList<FifaCodeMatchModel> ParsedFifaCode = new List<FifaCodeMatchModel>(); //I ended up not using this but left it here since it's completely functional and just needs a fifacode which I hardcoded here for testing purposes

        // For status label
        private bool StatusBusy = false;

        private PlayerUserControl? PlayerUCStartedDragDrop;

        private IEnumerable<ClassLibrary1.Models.Two.StartingEleven>? UnionPlayers;

        private CultureInfo currentcultureinfo;



        public Form1()
        {
            try
            {
                Thread mainthread = Thread.CurrentThread;
                mainthread.Name = "Main Thread";
                InitPersistentSettings();
                InitLocalization();
                InitializeComponent(); //fix for broken setting of thread localization
                SetLocalizedText();
            }
            catch (Exception ex) when (ex is FileNotFoundException)
            {
                //move this to Form1 show event
                var res = new InitForm(PATH).ShowDialog(); //a case where .Show() will not work because the next line gets null and is not in a try catch block, ShowDialog displays it in a modal way preventing this
                if (res == DialogResult.OK)
                {
                    InitPersistentSettings();
                    InitLocalization();
                    InitializeComponent(); //fix for broken setting of thread localization
                    SetLocalizedText();
                }  
            }
            catch (Exception ey)
            {
                new Thread(() => MessageBox.Show(ey.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error)).Start();
            }
        }
        private void Form1_Shown(object sender, EventArgs e) //Shown because otherwise it does not show the window open
        {
            SetStatusLabel("Loading");
            //await Task.Run(InitAll);
            InitAll();
            SetStatusLabel("Ready");
        }

        private async void InitAll() // One Init for all Inits in proper sequence, can be called from anywhere without breaking.
        {
            try
            {

                InitDataFetchMethodLabel();
                InitEndpointSelection();
                await Task.Run(InitParser);
                EnumerateTeamsComboBox();
                // FillPlayers(cbTeam.SelectedItem.ToString());   EnumarateTeamsComboBox() triggers combobox index change which Fills players so this would double the players in flp (bug)
                //FillFavorites(); duplicates
                //RemoveFavoritesFromPlayersFLP();
                UpdateFlpCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitLocalization()
        {
            switch (initclass.SelectedLanguage)
            {
                case Initclass.Language.Croatian:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr");
                    currentcultureinfo = Thread.CurrentThread.CurrentUICulture;
                    CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
                    CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;
                    break;
                case Initclass.Language.English:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                    currentcultureinfo = Thread.CurrentThread.CurrentUICulture;
                    CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
                    CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;
                    break;
                default:
                    break;
            }
        /*  CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
            CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;      */
        }

        private void SetLocalizedText()
        {
            settingsToolStripMenuItem.Text = Resource.settings;
            setInitialSettingsToolStripMenuItem.Text = Resource.setinitialsettings;
            helpToolStripMenuItem.Text = Resource.help;
            aboutToolStripMenuItem.Text = Resource.about;

            label3.Text = Resource.team;

            btnRanking.Text = Resource.ranking;
            btnFavorite.Text = Resource.favorite;

            label1.Text = Resource.favorites;
            label2.Text = Resource.players;

            lblFavoritesCount.Text = Resource.count + ": 0";
            lblPlayerCount.Text = Resource.count + ": 0";

            lblStatus.Text = Resource.status;
            lblMethod.Text = Resource.method;
        }

        private void InitPersistentSettings()
        {
            try
            {
                repository = RepositoryFactory.GetRepository(PATH);
                initclass = repository.GetInitclass();
                var fr = repository as FileRepository;
                fr.LoadFavorites(FavsPATH);
                favoritesclass = repository.GetFavoritesclass();
                fr.LoadPlayers(PlayersPATH);
                playersclass = repository.GetPlayersclass();
            }
            catch (ConfigurationMissingException mc)
            {
                new InitForm(PATH).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (initclass != null)
            {
                //MessageBox.Show("Parse result: " + initclass.ToString());
                Debug.WriteLine("Parse result: " + initclass.ToString());
            }
            else
            {
                //MessageBox.Show("FAIL , initclass null!");
                Debug.WriteLine("FAIL , initclass null!");
                var res = new InitForm(PATH).ShowDialog();
                if (res == DialogResult.OK)
                {
                    InitPersistentSettings();
                }
                else
                {
                    Environment.Exit(Environment.ExitCode);
                }
                //InitPersistentSettings(); // go back
                //throw new MissingMemberException();
            }
        } //load application settings and data from file

        private void InitDataFetchMethodLabel() // Display application data source setting
        {
            if (initclass != null)
            {
                lblMethod.Text = Resource.accessmethod + ": " + initclass.SelectedMethod.ToString();
            }
            else
            {
                lblMethod.Text = "Initclass null error!";
            }
        }

        private void InitEndpointSelection()
        {
            string current = AppDomain.CurrentDomain.BaseDirectory;
            switch (initclass.SelectedGender)
            {
                case Initclass.Gender.Male:
                    if (initclass.SelectedMethod == Initclass.AccessMethod.API)
                    {
                        EndpointSelection = new string[4]
                        {
                            EndpointConstants.MatchesM, EndpointConstants.ResultsM, EndpointConstants.MatchesByCodeM+"CRO", EndpointConstants.TeamsM
                        };
                    }
                    else
                    {
                        EndpointSelection = new string[4]
                        {
                            Path.GetFullPath(Path.Combine(current, EndpointConstants.rMatchesMLocal)), Path.GetFullPath(Path.Combine(current, EndpointConstants.rResultsMLocal)), Path.GetFullPath(Path.Combine(current, EndpointConstants.rResultsMLocal)), Path.GetFullPath(Path.Combine(current, EndpointConstants.rTeamsMLocal))
                        };
                    }

               
                    break;
                case Initclass.Gender.Female:
                    if (initclass.SelectedMethod == Initclass.AccessMethod.API)
                    {
                        EndpointSelection = new string[4]
                    {
                            EndpointConstants.MatchesW, EndpointConstants.ResultsW, EndpointConstants.MatchesByCodeW+"KOR", EndpointConstants.TeamsW
                    };
                    }
                    else
                    {
                        EndpointSelection = new string[4]
                        {
                            Path.GetFullPath(Path.Combine(current, EndpointConstants.rMatchesWLocal)), Path.GetFullPath(Path.Combine(current, EndpointConstants.rResultsWLocal)), Path.GetFullPath(Path.Combine(current, EndpointConstants.rResultsWLocal)), Path.GetFullPath(Path.Combine(current, EndpointConstants.rTeamsWLocal))
                        };
                    }
                    break;
                default:
                    throw new InvalidDataException();
                    //break;
            }
        } // selecting FILE PATHs or URLs based on initial gender selection setting logic

        private void EnumerateTeamsComboBox() //fill combo box
        {
            //Enumerates ComboBox with ParsedTeams which is already initialized from endpoints based on gender setting
            List<TeamsModel> models = new List<TeamsModel>(ParsedTeams);
            models.Sort((x, y) => x.Country.CompareTo(y.Country));
            models.ForEach(x => cbTeam.Items.Add(x.Country + " (" + x.FifaCode + ")"));
            if (initclass.SelectedTeam != null)
            {
                cbTeam.SelectedIndex = cbTeam.Items.IndexOf(initclass.SelectedTeam.Country.ToString() + " (" + initclass.SelectedTeam.Code + ")"); //bug fixed
            }
            else
            {
                cbTeam.SelectedIndex = 0;
            }
        }

        private void InitParser() //Initialize parser
        {
            StringBuilder sb = new StringBuilder();
            parser = JsonParserFactory.GetInstance();
            //Assign parsed values to matching list
            try
            {

                ParsedTeams = ParseAndAssign<TeamsModel>(EndpointSelection[3], initclass.SelectedMethod);
                ParsedMatches = ParseAndAssign<MatchesModel2>(EndpointSelection[0], initclass.SelectedMethod);
                ParsedResults = ParseAndAssign<ResultsModel>(EndpointSelection[1], initclass.SelectedMethod);
                ParsedFifaCode = ParseAndAssign<FifaCodeMatchModel>(EndpointSelection[2], initclass.SelectedMethod);

            }
            catch (Exception e)
            {
                ErrorMessageDialog(e);
            }

            SetStatusLabel("Ready");

        }

        private void FillFavorites() // fill favorites FLP
        {
            if (favoritesclass == null || string.IsNullOrEmpty(GetCountry().Trim()))
            {
                throw new Exception("FAVORITESCLASS IS NULL");
            }
            if (GetCountry().Trim() == favoritesclass.SelectedTeam.Country.ToString().Trim())
            {
                favoritesclass.SelectedPlayers.ToList().ForEach(x => flpFavorites.Controls.Add(new PlayerUserControl(x, true, currentcultureinfo)));
            }
        }

        private void FillPlayersFromFile() // fill favorites FLP
        {
            if (playersclass == null || string.IsNullOrEmpty(GetCountry().Trim()))
            {
                throw new Exception("PLAYERSCLASS IS NULL");
            }
            if (GetCountry().Trim() == playersclass.SelectedTeam.Country.ToString().Trim())
            {
                playersclass.SelectedPlayers.ToList().ForEach(x => flpPlayers.Controls.Add(new PlayerUserControl(x, false, currentcultureinfo)));
            }
        }

        private void RemoveFavoritesFromPlayersFLP()
        {
            var temp = flpPlayers.Controls;
            int index = 0;

            foreach (PlayerUserControl favorites in flpFavorites.Controls)
            {
                foreach (PlayerUserControl players in temp)
                {
                    if (players.playerObject.Name == favorites.playerObject.Name)
                    {
                        Control temp2 = players as Control;
                        temp2.Dispose();
                        break;
                    }
                }
            }
        }

        private void UpdateFlpCounts() // Update player count / favorite player count
        {
            lblPlayerCount.Text = Resource.count+": " + flpPlayers.Controls.Count;
            lblFavoritesCount.Text = Resource.count+": " + flpFavorites.Controls.Count;
        }













        private async void RunAsync(object? obj)
        {
            SetStatusLabel("Loading");
            Thread.CurrentThread.Name = "Auxiliary Thread";
            Thread.CurrentThread.IsBackground = true;
            await Task.Run(() => { InitPersistentSettings(); }); // Init application settings (parse)
            await Task.Run(() => { InitEndpointAndParser(); });

        }

        private void InitEndpointAndParser() //required for task.run, one async call to two synced methods
        {
            InitEndpointSelection();
            InitParser();
        }

        private void FillPlayers(string selectedcountry) // fill flps with players
        {
            if (playersclass == null || GetCountry().Trim() != playersclass.SelectedTeam.Country.ToString().Trim())
            {
                flpPlayers.Visible = true;
                //debug  var selection = ParsedMatches.FirstOrDefault().HomeTeamStatistics.StartingEleven;
                var selection = ParsedMatches.FirstOrDefault(x => x.HomeTeamCountry == selectedcountry);



                var union = (selection.HomeTeamStatistics.StartingEleven).Union(selection.HomeTeamStatistics.Substitutes);
                UnionPlayers = union;
                foreach (ClassLibrary1.Models.Two.StartingEleven player in union)
                {
                    //flpPlayers.Controls.Add(
                    //    new PlayerUserControl(
                    //        player.Name,
                    //        player.ShirtNumber.ToString(),
                    //        player.Position.ToString()
                    //        )


                    flpPlayers.Controls.Add(
                        new PlayerUserControl(player, currentcultureinfo) //much better
                    );
                }
                UpdateFlpCounts(); 
            }
        }





        private static void ErrorMessageDialog(Exception e)
        {
            new Thread(() =>
            {
                MessageBox.Show(e.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            }).Start();
        }



        private IList<T> ParseAndAssign<T>(string URLorPATH, Initclass.AccessMethod selectedMethod)
        {
            if (selectedMethod == Initclass.AccessMethod.API)
            {
                return parser.ParseMatchModel<T>(URLorPATH);
            }
            else if (selectedMethod == Initclass.AccessMethod.File)
            {
                return parser.ParseMatchModelFromFile<T>(URLorPATH);
            }
            else
            {
                throw new InvalidDataException();
            }
        } //simplified to require one <T> instead of two throughout code



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //Simple about form
        {
            AboutBox1 a = new AboutBox1();
            //a.ShowDialog();
            new Thread(() => a.ShowDialog()).Start();

        }

        private void initSettingsToolStripMenuItem_Click(object sender, EventArgs e) //Simple display of initial parsed settings
        {
            initclass = repository.GetInitclass();  //Persistance

            if (initclass != null)
            {
                InformationMessageDialog(initclass.ToString());
                Debug.WriteLine("Parse result: " + initclass.ToString());
            }
            else
            {
                WarningMessageDialog("FAIL, initclass null!");
                Debug.WriteLine("FAIL , initclass null!");
            }
        }

        private static void WarningMessageDialog(string text)
        {
            MessageBox.Show(text, "Init settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void InformationMessageDialog(string text)
        {
            MessageBox.Show("Parse result: " + text, "Init settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MyMessageDialog(string text)
        {
            Task.Run(() => MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning));
        }









        private void setInitialSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = new InitForm(initclass,PATH, Thread.CurrentThread.CurrentUICulture).ShowDialog();
            if (result == DialogResult.OK)
            {
                var oldinit = initclass;
                InitPersistentSettings();
                var newinit = initclass;
                if (oldinit != newinit)
                {
                    var temp = ParsedMatches.FirstOrDefault(x => x.HomeTeam.Country.ToString() == GetCountry());
                    Initclass.AppendTeamToFile(PATH, initclass, temp.HomeTeam);
                    CleanFlowLayoutPanels();
                    InitAll();
                }
            }
            else
            {
                return;
            }

        }// show initial settings form from menu button logic

        private void CleanFlowLayoutPanels()
        {
            /*  only have 2 so why waste CPU time
             *  
            foreach (Control control in this.Controls)
            {
                switch (control)
                {
                    case FlowLayoutPanel:
                        control.Controls.Clear();
                        break;
                    default:
                        break;
                }
            };
            */
            flpPlayers.Controls.Clear();
            flpFavorites.Controls.Clear();
        }








        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Environment.Exit(Environment.ExitCode); //close all (threads included)
            var res = new ExitForm(Thread.CurrentThread.CurrentUICulture, Resource.exitapplication).ShowDialog();
            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                // due to multiple threads, I'm using another method
                //e.Cancel = false;
                Environment.Exit(Environment.ExitCode);
            }
        }


































        /*
         * ----------------------------------  DRAG AND DROP -------------------------------------------
         */
        private void flpPlayers_DragDrop(object sender, DragEventArgs e) //from Favorites into Players
        {
            PlayerUserControl? transfering = (PlayerUserControl)e.Data.GetData(typeof(PlayerUserControl));
            var con = transfering as Control;
            var parent = con.Parent;
            var listofcontrolsfordraganddrop = PlayerUserControl.GetDragDropList();
            if (parent.Name == "flpFavorites") // B U G F I X E D!!!!
            {
                foreach (Control control in flpPlayers.Controls)
                {
                    PlayerUserControl local = control as PlayerUserControl;
                    listofcontrolsfordraganddrop.ToList().ForEach(x =>
                    {
                        if (x.playerObject.Name ==  local.playerObject.Name)
                        {
                            control.Dispose();
                        }
                    });
                }
                listofcontrolsfordraganddrop.ToList().ForEach(x =>
                {
                    x.SetFavorite(false);
                    x.UnselectDragDrop();
                    flpPlayers.Controls.Add(x);
                });
            }
            else
            {
                listofcontrolsfordraganddrop.ToList().ForEach(x =>
                {
                    x.UnselectDragDrop();
                }); ;
            }
            Debug.WriteLine("DragDrop");
            UpdateFlpCounts();
        } // drag and drop

        private void flpFavorites_DragDrop(object sender, DragEventArgs e) //from Players into Favorites
        {

            PlayerUserControl? transfering = (PlayerUserControl)e.Data.GetData(typeof(PlayerUserControl));
            var con = transfering as Control;
            var parent = con.Parent;
            var listofcontrolsfordraganddrop = PlayerUserControl.GetDragDropList();
            if (parent.Name == "flpPlayers") // B U G F I X E D!!!!
            {
                foreach (Control control in flpFavorites.Controls)
                {
                    PlayerUserControl local = control as PlayerUserControl;
                    listofcontrolsfordraganddrop.ToList().ForEach(x =>
                    {
                        if (x.playerObject.Name == local.playerObject.Name)
                        {
                            control.Dispose();
                        }
                    });
                }
                if (flpFavorites.Controls.Count < 3 && (flpFavorites.Controls.Count + listofcontrolsfordraganddrop.Count <= 3))
                {
                    listofcontrolsfordraganddrop.ToList().ForEach(x =>
                    {
                        x.SetFavorite(true);
                        x.UnselectDragDrop();
                        flpFavorites.Controls.Add(x);
                    }) ;
                }
                else
                {
                    listofcontrolsfordraganddrop.ToList().ForEach(x =>
                    {
                        x.UnselectDragDrop();
                    });
                    MyMessageDialog(Resource.maxthreefavorites);
                }
            }
            else
            {
                return;
            }
            Debug.WriteLine("DragDrop");
            UpdateFlpCounts();
        } // drag and drop

        private void flpPlayers_DragEnter(object sender, DragEventArgs e)
        {
            //if (sender is not PlayerUserControl playerUserControl)
            //{
            //   return;
            //}

            e.Effect = DragDropEffects.Move;
            Debug.WriteLine("DragEnter");

        } // drag and drop effect


        /*
         *  ----------------------------------------------------------------------------------------------------
         */




        private void cbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpPlayers.Controls.Clear();
            flpFavorites.Controls.Clear();
            try
            {
                FillPlayers(GetCountry());
                if (flpFavorites.Controls.Count < 1) // load on change, selected index changed is called on first selection also so no need to manually call fillfavorites in init
                {
                    FillFavorites();
                    RemoveFavoritesFromPlayersFLP();
                    FillPlayersFromFile();
                }
            }
            catch (Exception ex)
            {

                ErrorMessageDialog(ex);
            }
            UpdateFlpCounts();
        } // Update FLPs each time the combo box selection changes

        private string GetCountry()
        {
            //return cbTeam.SelectedItem.ToString().Split(' ')[0];
            return cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6); //bug fixed
        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            if (cbTeam.SelectedItem == null)
            {
                return;
            }

            var temp = ParsedMatches.FirstOrDefault(x => x.HomeTeam.Country.ToString() == GetCountry());
            Initclass.AppendTeamToFile(PATH, initclass, temp.HomeTeam);
            IList<ClassLibrary1.Models.Two.StartingEleven> favplayers = new List<ClassLibrary1.Models.Two.StartingEleven>();
            IList<ClassLibrary1.Models.Two.StartingEleven> notfavplayers = new List<ClassLibrary1.Models.Two.StartingEleven>();
            foreach (PlayerUserControl plc in flpFavorites.Controls)
            {
                //todo
                var temp4 = (PlayerUserControl)plc;
                favplayers.Add(temp4.playerObject);
            }
            foreach (PlayerUserControl plc in flpPlayers.Controls)
            {
                //todo
                var temp5 = (PlayerUserControl)plc;
                notfavplayers.Add(temp5.playerObject);
            }
            //Initclass.AppendTeamAndFavoritesToFile(PATH, initclass, temp.HomeTeam, favplayers);
            var repo = repository as FileRepository;
            repo.AddFavsPath(FavsPATH);
            favoritesclass = repository.GetFavoritesclass();
            favoritesclass = new Favoritesclass
            {
                SelectedTeam = temp.HomeTeam,
                SelectedPlayers = favplayers
            };
            repo.AddPlayersPath(PlayersPATH);
            playersclass = repository.GetPlayersclass();
            playersclass = new PlayersNotFavorite
            {
                SelectedTeam = temp.HomeTeam,
                SelectedPlayers = notfavplayers
            };
            repo.SaveFavorites(favoritesclass);
            repo.SavePlayers(playersclass);
        } // Save favorite team and favorite players for that team

        private void flpPlayers_ControlAdded(object sender, ControlEventArgs e)
        { /*    Inefficient and stuttery, better way is to manually set it to count once any action is performed, way less spam
            var control = sender as Control;
            switch (control.Name)
            {
                case "flpPlayers":
                    lblPlayerCount.Text = "Count: " + flpPlayers.Controls.Count;
                    break;
                case "flpFavorites":
                    lblFavoritesCount.Text = "Count: " + flpFavorites.Controls.Count;
                    break;
                default:
                    break; 
            }
            */
            //UpdateFlpCounts();
        } // legacy code / found a better way




































































        /*
         * 
         * 
         * 
         *  Extra stuff, not directly related to LO
         * 
         * 
         */




        private void SetStatusLabel(string status) // for fun
        {
            Task.Run(() =>
            {
                if (string.IsNullOrEmpty(status))
                {
                    return; //don't the crash program with exception for a single label mistake
                }
                string temp = status.ToLower().Trim();
                StringBuilder sb = new StringBuilder();
                //string formatted = sb.Append(temp.ToCharArray().ElementAt(0).ToString().ToUpper() + temp.Substring(1).ToLower().ToString()).ToString(); // look how long it can be :)

                switch (temp)
                {
                    case "ready":
                        //Console.Beep(700,100);
                        StatusBusy = false;
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = Resource.ready.ToString();
                        break;
                    case "loading":
                        //Task.Run(()=>Console.Beep(400,200));
                        StatusBusy = true;
                        lblStatus.ForeColor = Color.Gray;
                        lblStatus.Text = Resource.loading.ToString(); //?

                        sb.Clear();
                        sb.Append(Resource.loading.ToString());
                        int loop = 0;
                        while (StatusBusy)
                        {
                            if (loop < 4)
                            {
                                lblStatus.Text = sb.ToString();
                                sb.Append('.');
                                ++loop;
                                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                            }
                            else
                            {
                                sb.Clear();
                                sb.Append(Resource.loading.ToString());
                                loop = 0;
                            }
                        }

                        break;
                    default:
                        lblStatus.Text = "Default";
                        break;
                };
            });
        }
        private void readyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStatusLabel("Ready");
        } //debug / test form

        private void loadingToolStripMenuItem_Click(object sender, EventArgs e) //debug / test form
        {
            SetStatusLabel("Loading");
        }

        private async void parserdataToolStripMenuItem_Click(object sender, EventArgs e) //debug / test form
        {
            await Task.Run(() =>
            {
                Thread thread1 = new Thread(RunAsync);
                thread1.Name = "Auxiliary Thread";
                thread1.Start();
            });
            using (Form f = new NonModalMessageBox(ParsedTeams, ParsedMatches, ParsedFifaCode, ParsedResults))
            {
                //System.Windows.Forms.Application.Run(f);
                f.ShowDialog();
            }

        }


        private async Task FetchRemoteSourceAsync()
        {
            var Task1 = await parser.ParseMatchModelAsync<TeamsModel>(EndpointSelection[3]);

            ParsedTeams = Task1;
            StringBuilder sb = new StringBuilder();
            ParsedTeams.ToList().ForEach(s => sb.Append(s.Country));
            Debug.WriteLine("Async thread = " + Thread.CurrentThread.Name);
            MessageBox.Show(sb.ToString());
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            IList<PlayerUserControl> users = new List<PlayerUserControl>();

            foreach (PlayerUserControl puc in flpFavorites.Controls)
            {
                users.Add(puc);
            }
            foreach (PlayerUserControl puc in flpPlayers.Controls)
            {
                users.Add(puc);
            }


            var a = new RankingForm(users,ParsedMatches, cbTeam.SelectedItem, Thread.CurrentThread.CurrentUICulture);
            a.ShowDialog();
        }
    }
}