using ClassLibrary1;
using ClassLibrary1.Constants;
using ClassLibrary1.Exceptions;
using ClassLibrary1.JsonParser;
using ClassLibrary1.Models;
using ClassLibrary1.Models.Test;
using ClassLibrary1.Models.Two;
using ClassLibrary1.Resources;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Applicaiton settings parser related
        private const string rPATH = @"..\..\..\..\..\Text\appinit.txt";
        private readonly string PATH = Path.GetFullPath(Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, rPATH));
        //private const string FavsPATH = "favs.txt";
        private const string rFavsPATH = @"..\..\..\..\Text\favs.txt";
        private readonly string FavsPATH = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rFavsPATH));

        private const string rPlayersPATH = @"..\..\..\..\Text\players.txt";
        private readonly string PlayersPATH = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rPlayersPATH));
        
        private const string rFieldPATH = @"..\..\..\..\Images\field.png";
        private readonly string FieldPATH = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rFieldPATH));

        internal IRepository repository;

        //Inital settings class
        private Initclass initclass;
        private Favoritesclass favoritesclass;
        private PlayersNotFavorite playersclass;

        private string selectedcountryfromfavorites;
        private string selectedcountryfromfavoritescode;

        // JSON parser related
        internal IJsonParser parser;

        //Endpoint selection (M or F)
        private string[] EndpointSelection;

        // Parsed JSON storage
        private IList<TeamsModel> ParsedTeams = new List<TeamsModel>();
        private IList<MatchesModel2> ParsedMatches = new List<MatchesModel2>();
        private IList<ResultsModel> ParsedResults = new List<ResultsModel>();
        private IList<FifaCodeMatchModel> ParsedFifaCode = new List<FifaCodeMatchModel>();
        private MatchesModel2? matchtoshow;

        private int Rowadded = 0;

        public MainWindow()
        {
            try
            {
                InitPersistentSettings();
                InitializeComponent();
                imBackgroundField.ImageSource = new BitmapImage(new Uri(FieldPATH));
                //imBackgroundField.Source = new BitmapImage(new Uri(FieldPATH));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitPersistentSettings()
        {
            try
            {
                //var lines = File.ReadAllLines(PATH);
                //initclass = Initclass.Parse(lines[0]);
                repository = RepositoryFactory.GetRepository(PATH);
                initclass = repository.GetInitclass();
            }
            catch (Exception ex)
            {
                var res = new InitWindow(PATH).ShowDialog();
                if (res == true)
                {
                    InitPersistentSettings();
                }
                else
                {
                    Environment.Exit(Environment.ExitCode);
                }
            }

            if (initclass != null)
            {
                Debug.WriteLine("Parse result: " + initclass.ToString());
            }
            else
            {
                Debug.WriteLine("FAIL , saveinfoclass null!");
                throw new MissingMemberException();
            }

            switch (initclass.SelectedLanguage)
            {
                case Initclass.Language.Croatian:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr");
                    CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
                    CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;
                    break;
                case Initclass.Language.English:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                    CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
                    CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;
                    break;
                default:
                    break;
            }
            /*CultureInfo.DefaultThreadCurrentUICulture = Thread.CurrentThread.CurrentUICulture;
            CultureInfo.DefaultThreadCurrentCulture = Thread.CurrentThread.CurrentCulture;*/

            InitializeComponent(); //redraw
        } //load application settings and data from file

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SetAccessMethodTextBlock();
                SetStatus("loading");
                InitWindowResolution();
                InitEndpointSelection();
                await Task.Run(InitParser);
                InitFavoritesFromFormsApp();
                EnumerateTeamsComboBox();
                //ReplaceWithFavorites();  substitutions background color can't be copied because that code did not run yet, causes white background UC
                SetStatus("ready");
            }
            catch (Exception ex)when (ex is ConfigurationMissingException)
            {
                try
                {
                    selectedcountryfromfavorites = "Argentina"; //quick fix
                    selectedcountryfromfavoritescode = "ARG";
                    EnumerateTeamsComboBox();
                }
                catch (Exception ez)
                {

                    throw new Exception(ez.Message);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetAccessMethodTextBlock()
        {
            if (initclass != null)
            {
                switch (initclass.SelectedMethod)
                {
                    case Initclass.AccessMethod.API:
                        tbAccessMethod.Text = Resource.accessmethod + ": " + Resource.api;
                        break;
                    case Initclass.AccessMethod.File:
                        tbAccessMethod.Text = Resource.accessmethod + ": " + Resource.file;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetStatus(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentException(nameof(status));
            }
            switch (status)
            {
                case "loading":
                    tbStatus.Text = Resource.loading.ToString();
                    tbStatus.Foreground = new SolidColorBrush(Colors.Gray);
                    break;
                case "ready":
                    tbStatus.Text = Resource.ready.ToString();
                    tbStatus.Foreground = new SolidColorBrush(Colors.ForestGreen);
                    break;
                default:
                    tbStatus.Text = "Default";
                    break;
            };
        }

        private void ReplaceWithFavorites()
        {
            for (int i = 0; i < PlayersGrid.Children.Count; i++) // FOR FAVORITESCLASS
            {
                if (PlayersGrid.Children[i] is WPFPlayerUserControl chld)
                {
                    favoritesclass.SelectedPlayers.ToList().ForEach(x =>
                    {
                        if (chld.playerObject.Name == x.Name && chld.playerObject.ShirtNumber == x.ShirtNumber)
                        {
                            PlayersGrid.Children.RemoveAt(i); // works
                            var toinsert = new WPFPlayerUserControl(x, chld.isSubstitude, Thread.CurrentThread.CurrentUICulture);

                            Grid.SetColumn(toinsert, Grid.GetColumn(chld));
                            Grid.SetRow(toinsert, Grid.GetRow(chld));
                            toinsert.Margin = chld.Margin;
                            toinsert.HorizontalAlignment = HorizontalAlignment.Stretch;
                            toinsert.Background = chld.Background;
                            /*if (chld.isSubstitude)
                            {
                                switch (Grid.GetColumn(chld)) //background color logic
                                {
                                    case <= 6:
                                        toinsert.Background = new SolidColorBrush(Colors.Red);
                                        break;
                                    case > 6:
                                        toinsert.Background = new SolidColorBrush(Colors.Orange);
                                        break;
                                    default:
                                        break;
                                }
                            }*/

                            PlayersGrid.Children.Insert(i, toinsert);
                        }
;
                    });
                }
            }
            for (int i = 0; i < PlayersGrid.Children.Count; i++) // FOR PLAYERSCLASS
            {
                if (PlayersGrid.Children[i] is WPFPlayerUserControl chld)
                {
                    playersclass.SelectedPlayers.ToList().ForEach(x =>
                    {
                        if (chld.playerObject.Name == x.Name && chld.playerObject.ShirtNumber == x.ShirtNumber)
                        {
                            PlayersGrid.Children.RemoveAt(i); // works
                            var toinsert = new WPFPlayerUserControl(x, chld.isSubstitude, Thread.CurrentThread.CurrentUICulture);

                            Grid.SetColumn(toinsert, Grid.GetColumn(chld));
                            Grid.SetRow(toinsert, Grid.GetRow(chld));
                            toinsert.Margin = chld.Margin;
                            toinsert.HorizontalAlignment = HorizontalAlignment.Stretch;
                            toinsert.Background = chld.Background;
                            PlayersGrid.Children.Insert(i, toinsert);
                        }
;
                    });
                }
            }
        }

        private void InitFavoritesFromFormsApp()
        {
            //var o = new OpenFileDialog();

            //var res = o.ShowDialog();

            //if (res == true)
            if (true)
            {
                try
                {

                    //if (!File.Exists(o.FileName))
                    if (!File.Exists(FavsPATH))
                    {
                        throw new FileNotFoundException();
                    }

                    //string[] temp = File.ReadAllLines(o.FileName);
                    string[] temp = File.ReadAllLines(FavsPATH);

                    if (!(temp[0].Length > 0))
                    {
                        throw new FormatException();
                    }

                    temp.ToList().ForEach(x => { favoritesclass = Favoritesclass.Parse(x); }); //stpd


                    var split = temp[0].Split('|');
                    var split2 = split[0].Split('#');
                    selectedcountryfromfavorites = split2[0];
                    selectedcountryfromfavoritescode = split2[1];

                }
                catch (Exception ex) when (ex is FormatException || ex is FileNotFoundException)
                {
                    Debug.WriteLine(ex.Message);
                    throw new ConfigurationMissingException(ex.Message);

                }
                var fr = repository as FileRepository;
                fr.LoadPlayers(PlayersPATH);
                playersclass = repository.GetPlayersclass();
            }
        }

        private void InitWindowResolution()
        {

            if (initclass.SelectedResolution == Initclass.Resolution.Res1)
            {
                this.Width = 1280;
                this.Height = 720;
            }

            else if (initclass.SelectedResolution == Initclass.Resolution.Res2)
            {
                this.Width = 1600;
                this.Height = 900;
            }

            else if (initclass.SelectedResolution == Initclass.Resolution.Res3)
            {
                this.Width = 1920;
                this.Height = 1080;
            }

            else if (initclass.SelectedResolution == Initclass.Resolution.Res4)
            {
                this.WindowState = WindowState.Maximized;
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
                    {
                        throw new InvalidDataException();
                        //break;
                    }
            }
        } // selecting FILE PATHs or URLs based on initial gender selection setting logic

        private void InitParser() //Initialize parser
        {
            StringBuilder sb = new StringBuilder();
            parser = JsonParserFactory.GetInstance();
            //Assign parsed values to matching list
            try
            {

                ParsedTeams = ParseAndAssign<TeamsModel>(EndpointSelection[3], (Initclass.AccessMethod)initclass.SelectedMethod);
                ParsedMatches = ParseAndAssign<MatchesModel2>(EndpointSelection[0], (Initclass.AccessMethod)initclass.SelectedMethod);
                ParsedResults = ParseAndAssign<ResultsModel>(EndpointSelection[1], (Initclass.AccessMethod)initclass.SelectedMethod);
                ParsedFifaCode = ParseAndAssign<FifaCodeMatchModel>(EndpointSelection[2], (Initclass.AccessMethod)initclass.SelectedMethod);
                //MessageBox.Show("WORKS!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

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


        private void EnumerateTeamsComboBox() //fill combo box
        {
            //Enumerates ComboBox with ParsedTeams which is already initialized from endpoints based on gender setting
            List<TeamsModel> models = new List<TeamsModel>(ParsedTeams);
            models.Sort((x, y) => x.Country.CompareTo(y.Country));
            models.ForEach(x => cbTeam.Items.Add(x));
            if (selectedcountryfromfavorites != null)
            {
                TeamsModel selection = null;
                var search = selectedcountryfromfavorites + " (" + selectedcountryfromfavoritescode + ")";
                bool foundFav = false;
                foreach (TeamsModel item in cbTeam.Items) //I wanted to move on to other things and this was annoying to do because I tried to use models in the combobox but only saved partial object data in the text file
                {                                         //so I cant simply IndexOf it. It's too late to fix now.
                    if (item.ToString() == search)
                    {
                        selection = item; 
                        foundFav = true;
                        break;
                    }
                }
                if (!foundFav)
                {
                    cbTeam.SelectedIndex = 0;
                }

                //cbTeam.SelectedIndex = cbTeam.Items.IndexOf(selectedcountryfromfavorites + " (" + selectedcountryfromfavoritescode + ")");
                else if (foundFav)
                {
                    cbTeam.SelectedIndex = cbTeam.Items.IndexOf(selection);
                }
            }
            else
            {
                cbTeam.SelectedIndex = 0;
            }

            
        }


        private void InitDataFetchMethodLabel() // Display application data source setting
        {
        }

        private void cbOponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbOponent.Items.Count > 1)
                {
                    var search = cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6); //fixed

                    var team1 = cbOponent.SelectedItem.ToString().Remove(cbOponent.SelectedItem.ToString().Length - 6);
                    matchtoshow = ParsedMatches.ToList().FirstOrDefault(x => x.HomeTeamCountry == search && x.AwayTeamCountry == team1 || x.AwayTeamCountry == search && x.HomeTeamCountry == team1);

                    lblResult.Content = matchtoshow.HomeTeamCountry == search ? matchtoshow.HomeTeam.Goals + ":" + matchtoshow.AwayTeam.Goals : matchtoshow.AwayTeam.Goals + ":" + matchtoshow.HomeTeam.Goals;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //show players here
            //MainGrid.Children.Clear();

            try
            {
                if (matchtoshow.HomeTeamCountry == cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6))
                {
                    PlayersGrid.Children.Clear();
                    ShowPlayers(matchtoshow);
                    ReplaceWithFavorites();
                    /*
                    List<ClassLibrary1.Models.Two.StartingEleven> list = new();
                    matchtoshow.HomeTeamStatistics.StartingEleven.ForEach(x => list.Add(x));
                    List<ClassLibrary1.Models.Two.StartingEleven> subs = new();
                    matchtoshow.HomeTeamStatistics.Substitutes.ForEach(x => list.Add(x));

                    list.Union(subs).ToList().ForEach(x => wrpPlayers.Children.Add(new WPFPlayerUserControl(x)));
                    */

                }
                else if (matchtoshow.AwayTeamCountry == cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6))
                {
                    PlayersGrid.Children.Clear();
                    ShowPlayers(matchtoshow);
                    ReplaceWithFavorites();
                    /*
                    matchtoshow.AwayTeamStatistics.StartingEleven.ForEach(x => MainGrid.Children.Add(new WPFPlayerUserControl(x, false, Thread.CurrentThread.CurrentUICulture)));
                    matchtoshow.AwayTeamStatistics.Substitutes.ForEach(x => MainGrid.Children.Add(new WPFPlayerUserControl(x, true, Thread.CurrentThread.CurrentUICulture)));
                    */

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowPlayers(MatchesModel2 match2)
        {

            //add name of teams to grid
            TextBlock text = new TextBlock();
            text.Text = Resource.hometeam+": " + match2.HomeTeamCountry;
            text.FontSize = 28;
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.Foreground = new SolidColorBrush(Colors.White);
            Grid.SetRow(text, 0);
            Grid.SetColumn(text, 1);
            Grid.SetColumnSpan(text, 5);
            PlayersGrid.Children.Add(text);

            TextBlock text2 = new TextBlock();
            text2.Text = Resource.awayteam+": " + match2.AwayTeamCountry;
            text2.FontSize = 28;
            text2.HorizontalAlignment = HorizontalAlignment.Center;
            text2.VerticalAlignment = VerticalAlignment.Center;
            text2.Foreground = new SolidColorBrush(Colors.White);
            Grid.SetRow(text2, 0);
            Grid.SetColumn(text2, 11);
            Grid.SetColumnSpan(text2, 5);
            PlayersGrid.Children.Add(text2);

            TextBlock text3 = new TextBlock();
            text3.Text = Resource.substitutions;
            text3.FontSize = 48;
            text3.HorizontalAlignment = HorizontalAlignment.Center;
            text3.VerticalAlignment = VerticalAlignment.Center;
            text3.Foreground = new SolidColorBrush(Colors.White);
            Grid.SetRow(text3, 9);
            Grid.SetColumn(text3, 0);
            Grid.SetColumnSpan(text3, 17);
            PlayersGrid.Children.Add(text3);



            int[] positions_y = new int[4];
            positions_y[0] = 3; //goalie
            positions_y[1] = 1; //defender
            positions_y[2] = 1; //midfield
            positions_y[3] = 1; //forward
            match2.HomeTeamStatistics.StartingEleven.ForEach(x =>
            {
                /*if (positions_y[0] >= 7 || positions_y[1] >= 7 || positions_y[2] >= 7 || positions_y[3] >= 7) //BUG
                {
                    RowDefinition Row = new RowDefinition();
                    Row.Height = GridLength.Auto;
                    Row.MinHeight = 110;
                    PlayersGrid.RowDefinitions.Add(Row);
                    Rowadded++;
                }*/
                WPFPlayerUserControl tempuc = new WPFPlayerUserControl(x, false, Thread.CurrentThread.CurrentUICulture);
                switch (tempuc.playerObject.Position)
                {
                    case ClassLibrary1.Models.Two.Position.Goalie:
                        Grid.SetRow(tempuc, positions_y[0]);
                        Grid.SetColumn(tempuc, 0);
                        //tempuc.Margin = new Thickness(5,5,5,5);
                        PlayersGrid.Children.Add(tempuc);
                        break;
                    case ClassLibrary1.Models.Two.Position.Defender:
                        Grid.SetRow(tempuc, positions_y[1]++);
                        Grid.SetColumn(tempuc, 3);
                        tempuc.Margin = new Thickness(0, 5, 0, 0);
                        PlayersGrid.Children.Add(tempuc);
                        break;
                    case ClassLibrary1.Models.Two.Position.Midfield:
                        Grid.SetRow(tempuc, positions_y[2]++);
                        Grid.SetColumn(tempuc, 5);
                        tempuc.Margin = new Thickness(0, 5, 0, 0);
                        PlayersGrid.Children.Add(tempuc);
                        break;
                    case ClassLibrary1.Models.Two.Position.Forward:
                        Grid.SetRow(tempuc, positions_y[3]++);
                        Grid.SetColumn(tempuc, 7);
                        tempuc.Margin = new Thickness(0, 5, 0, 0);
                        PlayersGrid.Children.Add(tempuc);
                        break;
                    default:
                        break;
                }
            });
            //substitudes logic
            /* OLD
            int subsitude_x = 2;
            int subsitude_y = 7 + Rowadded;
            match2.HomeTeamStatistics.Substitutes.ForEach(x =>
            {
                if (subsitude_x >= 8)
                {
                    subsitude_y++;
                    subsitude_x = 2;
                }
                WPFPlayerUserControl tempuc = new WPFPlayerUserControl(x, true, Thread.CurrentThread.CurrentUICulture);
                switch (tempuc.playerObject.Position)
                {
                    default:
                        Grid.SetRow(tempuc, subsitude_y);
                        Grid.SetColumn(tempuc, subsitude_x++);
                        tempuc.Margin = new Thickness(5, 25, 0, 0);
                        tempuc.Background = new SolidColorBrush(Colors.Red);
                        tempuc.Width = tempuc.Width * 0.5;
                        tempuc.Height = tempuc.Height * 0.5;
                        PlayersGrid.Children.Add(tempuc);
                        break;
                }
            });
            */
            int subsitude_x = 2;
            int subsitude_y = 7 + Rowadded;
            // show only substitution in -> starting_eleven union substitution in = all players of match
            match2.HomeTeamEvents.ForEach(x =>
            {
                if (subsitude_x >= 8)
                {
                    subsitude_y++;
                    subsitude_x = 2;
                }

                ClassLibrary1.Models.Two.StartingEleven subplayer;
                WPFPlayerUserControl tempuc;

                switch (x.TypeOfEvent)
                {
                    case ClassLibrary1.Models.Two.TypeOfEvent.Goal:
                        break;
                    case ClassLibrary1.Models.Two.TypeOfEvent.GoalOwn:
                        break;
                    case ClassLibrary1.Models.Two.TypeOfEvent.GoalPenalty:
                        break;
                    case ClassLibrary1.Models.Two.TypeOfEvent.RedCard:
                        break;
                    case ClassLibrary1.Models.Two.TypeOfEvent.SubstitutionIn:
                        subplayer = match2.HomeTeamStatistics.Substitutes.Find(y => y.Name == x.Player);
                        tempuc = new WPFPlayerUserControl(subplayer, true, Thread.CurrentThread.CurrentUICulture);
                        Grid.SetRow(tempuc, subsitude_y);
                        Grid.SetColumn(tempuc, subsitude_x++);
                        tempuc.Margin = new Thickness(5, 25, 0, 0);
                        tempuc.Background = new SolidColorBrush(Colors.LightGreen);
                        tempuc.Width = tempuc.Width * 0.5;
                        tempuc.Height = tempuc.Height * 0.5;
                        PlayersGrid.Children.Add(tempuc);
                        break;
                    case ClassLibrary1.Models.Two.TypeOfEvent.SubstitutionOut:
                        subplayer = match2.HomeTeamStatistics.StartingEleven.Find(y => y.Name == x.Player);
                        tempuc = new WPFPlayerUserControl(subplayer, true, Thread.CurrentThread.CurrentUICulture);
                        Grid.SetRow(tempuc, subsitude_y);
                        Grid.SetColumn(tempuc, subsitude_x++);
                        tempuc.Margin = new Thickness(5, 25, 0, 0);
                        tempuc.Background = new SolidColorBrush(Colors.OrangeRed);
                        tempuc.Width = tempuc.Width * 0.5;
                        tempuc.Height = tempuc.Height * 0.5;
                        PlayersGrid.Children.Add(tempuc);
                        break;
                    case ClassLibrary1.Models.Two.TypeOfEvent.YellowCard:
                        break;
                    case ClassLibrary1.Models.Two.TypeOfEvent.YellowCardSecond:
                        break;
                    default:
                        break;
                }
            });

            // ---------------------------- Opponent side ----------------------------


            positions_y[0] = 3; //goalie
            positions_y[1] = 1; //defender
            positions_y[2] = 1; //midfield
            positions_y[3] = 1; //forward

            match2.AwayTeamStatistics.StartingEleven.ForEach(x =>
            {
                /*if (positions_y[0] >= 7 || positions_y[1] >= 7 || positions_y[2] >= 7 || positions_y[3] >= 7) //BUG
                {
                    RowDefinition Row = new RowDefinition();
                    Row.Height = GridLength.Auto;
                    Row.MinHeight = 110;
                    PlayersGrid.RowDefinitions.Add(Row);
                    Rowadded++;
                }*/
                    WPFPlayerUserControl tempuc = new WPFPlayerUserControl(x, false, Thread.CurrentThread.CurrentUICulture);
                    switch (tempuc.playerObject.Position)
                    {
                        case ClassLibrary1.Models.Two.Position.Goalie:
                            Grid.SetRow(tempuc, positions_y[0]);
                            Grid.SetColumn(tempuc, 16);
                            //tempuc.Margin = new Thickness(5,5,5,5);
                            PlayersGrid.Children.Add(tempuc);
                            break;
                        case ClassLibrary1.Models.Two.Position.Defender:
                            Grid.SetRow(tempuc, positions_y[1]++);
                            Grid.SetColumn(tempuc, 13);
                            tempuc.Margin = new Thickness(0, 5, 0, 0);
                            PlayersGrid.Children.Add(tempuc);
                            break;
                        case ClassLibrary1.Models.Two.Position.Midfield:
                            Grid.SetRow(tempuc, positions_y[2]++);
                            Grid.SetColumn(tempuc, 11);
                            tempuc.Margin = new Thickness(0, 5, 0, 0);
                            PlayersGrid.Children.Add(tempuc);
                            break;
                        case ClassLibrary1.Models.Two.Position.Forward:
                            Grid.SetRow(tempuc, positions_y[3]++);
                            Grid.SetColumn(tempuc, 9);
                            tempuc.Margin = new Thickness(0, 5, 0, 0);
                            PlayersGrid.Children.Add(tempuc);
                            break;
                        default:
                            break;
                    }
            });
                //subsitude_x = 11;
                int right_x = 9;
                int opsubstitude_y = 7 + Rowadded;
                /*match2.AwayTeamStatistics.Substitutes.ForEach(x =>
                {
                    if (right_x >= 15)
                    {
                        opsubstitude_y++;
                        right_x = 9;
                    }
                    WPFPlayerUserControl tempuc = new WPFPlayerUserControl(x, true, Thread.CurrentThread.CurrentUICulture);
                    switch (tempuc.playerObject.Position)
                    {
                        default:
                            Grid.SetRow(tempuc, opsubstitude_y);
                            Grid.SetColumn(tempuc, right_x++);
                            tempuc.Margin = new Thickness(5, 25, 0, 0);
                            tempuc.Background = new SolidColorBrush(Colors.Orange);
                            tempuc.Width = tempuc.Width * 0.5;
                            tempuc.Height = tempuc.Height * 0.5;
                            PlayersGrid.Children.Add(tempuc);
                            break;
                    }
                });*/

                match2.AwayTeamEvents.ForEach(x =>
                {
                    if (right_x >= 15)
                    {
                        opsubstitude_y++;
                        right_x = 9;
                    }
                    ClassLibrary1.Models.Two.StartingEleven subplayer;
                    WPFPlayerUserControl tempuc;
                    switch (x.TypeOfEvent)
                    {
                        case ClassLibrary1.Models.Two.TypeOfEvent.Goal:
                            break;
                        case ClassLibrary1.Models.Two.TypeOfEvent.GoalOwn:
                            break;
                        case ClassLibrary1.Models.Two.TypeOfEvent.GoalPenalty:
                            break;
                        case ClassLibrary1.Models.Two.TypeOfEvent.RedCard:
                            break;
                        case ClassLibrary1.Models.Two.TypeOfEvent.SubstitutionIn:
                            subplayer = match2.AwayTeamStatistics.Substitutes.Find(y => y.Name == x.Player);
                            tempuc = new WPFPlayerUserControl(subplayer, true, Thread.CurrentThread.CurrentUICulture);
                            Grid.SetRow(tempuc, opsubstitude_y);
                            Grid.SetColumn(tempuc, right_x++);
                            tempuc.Margin = new Thickness(5, 25, 0, 0);
                            tempuc.Background = new SolidColorBrush(Colors.LightGreen);
                            tempuc.Width = tempuc.Width * 0.5;
                            tempuc.Height = tempuc.Height * 0.5;
                            PlayersGrid.Children.Add(tempuc);
                            break;
                        case ClassLibrary1.Models.Two.TypeOfEvent.SubstitutionOut:
                            subplayer = match2.AwayTeamStatistics.StartingEleven.Find(y => y.Name == x.Player);
                            tempuc = new WPFPlayerUserControl(subplayer, true, Thread.CurrentThread.CurrentUICulture);
                            Grid.SetRow(tempuc, opsubstitude_y);
                            Grid.SetColumn(tempuc, right_x++);
                            tempuc.Margin = new Thickness(5, 25, 0, 0);
                            tempuc.Background = new SolidColorBrush(Colors.OrangeRed);
                            tempuc.Width = tempuc.Width * 0.5;
                            tempuc.Height = tempuc.Height * 0.5;
                            PlayersGrid.Children.Add(tempuc);
                            break;
                        case ClassLibrary1.Models.Two.TypeOfEvent.YellowCard:
                            break;
                        case ClassLibrary1.Models.Two.TypeOfEvent.YellowCardSecond:
                            break;
                        default:
                            break;
                    }
                });

        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbOponent.IsEnabled = true;
                cbOponent.Items.Clear();
                //
                List<MatchesModel2> Matches = new List<MatchesModel2>(ParsedMatches);
                var search = cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6);
                //
                var list = Matches.FindAll((x) => x.HomeTeamCountry.ToString() == search || x.AwayTeamCountry.ToString() == search);
                //
                var matchesofopponentsaway = list.FindAll((x) => x.HomeTeamCountry != search);
                var matchesofopponentshome = list.FindAll((x) => x.AwayTeamCountry != search);
                //
                List<TeamsModel> Teams = new List<TeamsModel>(ParsedTeams);
                // 316 problematic
                matchesofopponentsaway.ForEach(x => cbOponent.Items.Add(Teams.FirstOrDefault(y =>
                {
                    var value1 = y.Country.ToString().Trim();
                    return value1 == x.HomeTeamCountry;
                }))); // overcomplicated but works and adds teamsmodel directly into cb!
                matchesofopponentshome.ForEach(x => cbOponent.Items.Add(Teams.FirstOrDefault(y =>
                {
                    var value1 = y.Country.ToString().Trim();
                    return value1 == x.AwayTeamCountry;
                })));
                //
                cbOponent.SelectedIndex = 1;
                //

                //Teams.ToList().ForEach(model => model.Country.ToString() != search ? cbOponent.Items.Add(model.Country.ToString()) : );
                //list.ToList().ForEach(x => cbTeam.Items.Add(x));

                //

                //var team1 = cbOponent.SelectedItem.ToString().ToString().Split(' ')[0];
                var team1 = cbOponent.SelectedItem.ToString().Remove(cbOponent.SelectedItem.ToString().Length - 6);
                var matchtoshow = Matches.ToList().FirstOrDefault(x => x.HomeTeamCountry == search && x.AwayTeamCountry == team1 || x.AwayTeamCountry == search && x.HomeTeamCountry == team1);

                lblResult.Content = matchtoshow.HomeTeamCountry == search ? matchtoshow.HomeTeam.Goals + ":" + matchtoshow.AwayTeam.Goals : matchtoshow.AwayTeam.Goals + ":" + matchtoshow.HomeTeam.Goals;

                if ((cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6)) == favoritesclass.SelectedTeam.Country.ToString())
                {
                    ReplaceWithFavorites();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetOponentMatches()
        {
            //var search = cbTeam.SelectedItem.ToString().Split(' ')[0];
            var search = cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6);
            List<MatchesModel2> models2 = new List<MatchesModel2>(ParsedMatches);
            var list = models2.FindAll((x) => x.HomeTeamCountry.ToString() == search || x.AwayTeamCountry.ToString() == search);
            var listofopponentaway = list.FindAll((x) => x.HomeTeamCountry != search);
            var listofopponenthome = list.FindAll((x) => x.AwayTeamCountry != search);

            List<TeamsModel> models = new List<TeamsModel>(ParsedTeams);
            listofopponentaway.ForEach(x => cbOponent.Items.Add(models.FirstOrDefault(y => y.Country.ToString().Remove(y.Country.ToString().Length - 6) == x.HomeTeamCountry))); // overcomplicated but works and adds teamsmodel directly into cb!
            listofopponenthome.ForEach(x => cbOponent.Items.Add(models.FirstOrDefault(y => y.Country.ToString().Remove(y.Country.ToString().Length - 6) == x.AwayTeamCountry)));
        }

        private void ShowResult()
        {
            List<MatchesModel2> models2 = new List<MatchesModel2>(ParsedMatches);
            var search = cbTeam.SelectedItem.ToString().Remove(cbTeam.SelectedItem.ToString().Length - 6);
            if(cbOponent.SelectedItem == null)
            {
                GetOponentMatches();
                cbOponent.SelectedIndex = 0;
            }
            var team1 = cbOponent.SelectedItem.ToString().Remove(cbOponent.SelectedItem.ToString().Length - 6);
            var matchtoshow = models2.ToList().FirstOrDefault(x => x.HomeTeamCountry == search && x.AwayTeamCountry == team1 ||
            x.AwayTeamCountry == search && x.HomeTeamCountry == team1);
            lblResult.Content = matchtoshow.HomeTeamCountry == search ? matchtoshow.HomeTeam.Goals + ":" + matchtoshow.AwayTeam.Goals : matchtoshow.AwayTeam.Goals + ":" + matchtoshow.HomeTeam.Goals;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new InitWindow(Thread.CurrentThread.CurrentUICulture, initclass, PATH).ShowDialog();
        }

        private void btnTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            new InfoWindow((TeamsModel)cbTeam.SelectedItem, ParsedResults, Thread.CurrentThread.CurrentUICulture).ShowDialog();
        }

        private void btnOponentInfo_Click(object sender, RoutedEventArgs e)
        {
            new InfoWindow((TeamsModel)cbOponent.SelectedItem, ParsedResults, Thread.CurrentThread.CurrentUICulture).ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var res = MessageBox.Show("Are you sure?","Exit",MessageBoxButton.YesNo,MessageBoxImage.Question);
            //if (res == MessageBoxResult.No)
            var res = new ExitWindow(Thread.CurrentThread.CurrentUICulture).ShowDialog();
            if (res == false)
            {
                e.Cancel = true;
            }

        }
    }
}