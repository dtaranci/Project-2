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
    public class Favoritesclass
    {

        private const char DELIMITER = '|';
        private const char DELIMITER_PLAYERS = '@';

        public Models.Two.Team? SelectedTeam { get; set; } //= new ClassLibrary1.Models.Two.Team { Code = "www", Country = "test", Goals = 10, Penalties = 99 };
        public IList<Models.Two.StartingEleven>? SelectedPlayers { get; set; }

        public override string ToString()
        => $"{SelectedTeam.Country}, {SelectedPlayers.FirstOrDefault().Name}";

        public static Favoritesclass Parse(string line)
        {
            var temp = line.Split(DELIMITER);
            string team = temp[0];
            IList<Models.Two.StartingEleven> list = new List<Models.Two.StartingEleven>();
            IList<string> temp2 = new List<string>( temp[1].Split(DELIMITER_PLAYERS));
            temp2.RemoveAt(0);
            temp2.ToList().ForEach(x => list.Add(Models.Two.StartingEleven.ParseOne(x)));
            

            return new Favoritesclass
            {
                SelectedPlayers = list,
                SelectedTeam = Models.Two.Team.Parse(team)
            };

        }

        public static string Write(Favoritesclass favoritesclass)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{Models.Two.Team.Write(favoritesclass.SelectedTeam)}{DELIMITER}");
            favoritesclass.SelectedPlayers.ToList().ForEach(x =>  sb.Append(Favoritesclass.Write(x))); // fav players to string
            return sb.ToString();
        }
        public static string Write(Models.Two.StartingEleven player)
        {
            return $"{DELIMITER_PLAYERS}{Models.Two.StartingEleven.Write(player)}"; //each player to string
        }

        public static string Write(Models.Two.Team team)
        {
            return $"{DELIMITER}{Models.Two.Team.Write2(team)}";
        }

        public static void WriteToFile(string PATH, Favoritesclass favoritesclass)
        {
            string[] temp = new string[1];
            temp[0] = Write(favoritesclass);
            File.WriteAllLines(PATH, temp);
        }
    }
}
