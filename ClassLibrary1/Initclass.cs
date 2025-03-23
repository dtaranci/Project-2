using ClassLibrary1.Models;
using ClassLibrary1.Models.Test;
using ClassLibrary1.Models.Two;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public class Initclass
    {
        // Initial settings(Outcome: I1 – minimum, I2 – desired)
        // When starting the application, a form will appear in which you need to set the desired priority(female or male) and the
        // language of the application(localization and globalization) - possible languages are Croatian and English.The selection
        // must be saved in a text file on disk and used every time the application is started.If the file does not exist, the user
        // should be asked again to select the priority and language.
        // Note: resources fetched from the API do not need to be localized (e.g., country name).

        private const char DELIMITER = '|';
        private const char DELIMITER_PLAYERS = '@';

        public Gender SelectedGender { get; set; }
        public Language SelectedLanguage { get; set; }
        public Models.Two.Team? SelectedTeam { get; set; } //= new ClassLibrary1.Models.Two.Team { Code = "www", Country = "test", Goals = 10, Penalties = 99 };
        public AccessMethod SelectedMethod { get; set; }
        public Resolution SelectedResolution { get; set; }
        public IList<Models.Two.StartingEleven>? SelectedPlayers { get; set; }

        public enum Gender
        {
            Male = 0,
            Female = 1,
        }

        public enum Language
        {
            Croatian = 0,
            English = 1,
        }
        public enum AccessMethod
        {
            API = 0,
            File = 1
        }
        public enum Resolution
        {
            Res1 = 0,
            Res2 = 1,
            Res3 = 2,
            Res4 = 3,
        }

        public override string ToString()
        => $"{SelectedGender}, {SelectedLanguage}";

        public static Initclass Parse(string line)
        {
            string[] splitlines = line.Split(DELIMITER);
            if (splitlines.Length == 3)
            {
                if (!(splitlines[0].Length > 0) && !(splitlines[1].Length > 0) && !(splitlines[2].Length > 0))
                {
                    throw new InvalidDataException();
                }
                return new Initclass
                {
                    SelectedGender = (Gender)int.Parse(splitlines[0]),
                    SelectedLanguage = (Language)int.Parse(splitlines[1]),
                    SelectedMethod = (AccessMethod)int.Parse(splitlines[2])
                };
            }
            /*else if (splitlines.Length == 4) // LOAD GENDER , LANGUAGE, ACCESSMETHOD (API, FILE) AND TEAM settings from settings file
            {
                if (!(splitlines[0].Length > 0) && !(splitlines[1].Length > 0) && !(splitlines[2].Length > 0) && !(splitlines[3].Length > 0))
                {
                    throw new InvalidDataException();
                }
                return new Initclass
                {
                    SelectedGender = (Gender)int.Parse(splitlines[0]),
                    SelectedLanguage = (Language)int.Parse(splitlines[1]),
                    SelectedMethod = (AccessMethod)int.Parse(splitlines[2]),
                    SelectedTeam = Models.Two.Team.Parse(splitlines[3]),
                };
            }*/

            else if (splitlines.Length == 4)
            {
                if (!(splitlines[0].Length > 0) && !(splitlines[1].Length > 0) && !(splitlines[2].Length > 0) && !(splitlines[3].Length > 0))
                {
                    throw new InvalidDataException();
                }
                return new Initclass
                {
                    SelectedGender = (Gender)int.Parse(splitlines[0]),
                    SelectedLanguage = (Language)int.Parse(splitlines[1]),
                    SelectedMethod = (AccessMethod)int.Parse(splitlines[2]),
                    SelectedResolution = (Resolution)int.Parse(splitlines[3]),
                };
            }
            else if (splitlines.Length == 5) //fixed
            {
                if (!(splitlines[0].Length > 0) && !(splitlines[1].Length > 0) && !(splitlines[2].Length > 0) && !(splitlines[3].Length > 0) && !(splitlines[4].Length > 0))
                {
                    throw new InvalidDataException();
                }
                return new Initclass
                {
                    SelectedGender = (Gender)int.Parse(splitlines[0]),
                    SelectedLanguage = (Language)int.Parse(splitlines[1]),
                    SelectedMethod = (AccessMethod)int.Parse(splitlines[2]),
                    SelectedResolution = (Resolution)int.Parse(splitlines[3]),
                    SelectedTeam = Models.Two.Team.Parse(splitlines[4]),
                };
            }
            else
            {
                throw new InvalidDataException();
            }
        }
            /*else if (splitlines.Length == 4) // LOAD GENDER , LANGUAGE, ACCESSMETHOD (API, FILE) AND TEAM settings from settings file
            {
                if (!(splitlines[0].Length > 0) && !(splitlines[1].Length > 0) && !(splitlines[2].Length > 0) && !(splitlines[3].Length > 0))
                {
                    throw new InvalidDataException();
                }
                return new Initclass
                {
                    SelectedGender = (Gender)int.Parse(splitlines[0]),
                    SelectedLanguage = (Language)int.Parse(splitlines[1]),
                    SelectedMethod = (AccessMethod)int.Parse(splitlines[2]),
                    SelectedTeam = Models.Two.Team.Parse(splitlines[3]),
                };*/
        
            /*
            else if (splitlines.Length == 17) // will use another method, this one turned out to be overcomplicated
            {
                if (!(splitlines[0].Length > 0) && !(splitlines[1].Length > 0) && !(splitlines[2].Length > 0) && !(splitlines[3].Length > 0))
                {
                    throw new InvalidDataException();
                }
                var players = splitlines[3].Split(DELIMITER_PLAYERS);
                string[] player2 = new string[1]; //stupid but i just want it to work with my nice already written foreach linq
                player2[0] = players[1];
                IList<Models.Two.StartingEleven> parsedplayers = new List<Models.Two.StartingEleven>();
                player2.ToList().ForEach(x =>
                {
                    if (!String.IsNullOrEmpty(x)) 
                    {
                        parsedplayers.Add(Models.Two.StartingEleven.ParseOne(x));
                    }
                });
                return new Initclass
                {
                    SelectedGender = (Gender)int.Parse(splitlines[0]),
                    SelectedLanguage = (Language)int.Parse(splitlines[1]),
                    SelectedMethod = (AccessMethod)int.Parse(splitlines[2]),
                    SelectedTeam = Models.Two.Team.Parse2(splitlines[3]),
                    SelectedPlayers = parsedplayers
                };*/

        public static string Write(Initclass initclass)
        {
            if (initclass.SelectedResolution == null)
            {
                return $"{(int)initclass.SelectedGender}{DELIMITER}{(int)initclass.SelectedLanguage}{DELIMITER}{(int)initclass.SelectedMethod}";
            }
            else
            {
                return $"{(int)initclass.SelectedGender}{DELIMITER}{(int)initclass.SelectedLanguage}{DELIMITER}{(int)initclass.SelectedMethod}{DELIMITER}{(int)initclass.SelectedResolution}";
            }
        }
        public static string Write(Models.Two.StartingEleven player)
        {
            return $"{DELIMITER_PLAYERS}{Models.Two.StartingEleven.Write(player)}";
        }

        public static string Write(Models.Two.Team team)
        {
            return $"{DELIMITER}{Models.Two.Team.Write(team)}";
        }

        public static void WriteToFile(string PATH,Initclass initclass)
        {
            string[] temp = new string[1];
            temp[0] = Write(initclass);
            File.WriteAllLines(PATH,temp);
        }

        public static void AppendTeamToFile(string PATH,Initclass initclass, Models.Two.Team team)
        {
            string[] temp = new string[1];
            StringBuilder sb = new StringBuilder();
            sb.Append(Write(initclass));
            sb.Append(Write(team));
            temp[0] = sb.ToString();
            File.WriteAllLines(PATH, temp);
        }

        public static void AppendTeamAndFavoritesToFile(string PATH, Initclass initclass, Models.Two.Team team, IList<Models.Two.StartingEleven> favplayers)
        {
            string[] temp = new string[1];
            StringBuilder sb = new StringBuilder();
            sb.Append(Write(initclass));
            sb.Append(Write(team));
            favplayers.ToList().ForEach(x => sb.Append(Write(x)) );
            temp[0] = sb.ToString();
            File.WriteAllLines(PATH, temp);

        }
    }
}
