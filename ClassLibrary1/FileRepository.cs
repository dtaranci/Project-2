using ClassLibrary1.Exceptions;
using System.Diagnostics;
using System.IO;
using static ClassLibrary1.Initclass;

namespace ClassLibrary1
{
    public class FileRepository : IRepository
    {
        //private const string PATH = "appinit.txt"; don't use, does not make sense for library, get from caller instead

        private Initclass initclass;
        public Initclass Initclass { get => initclass; } //read only encapsulation

        private Favoritesclass favoritesclass;
        public Favoritesclass Favoritesclass { get; set; } //read only encapsulation
        public PlayersNotFavorite Playersclass { get; set; } //read only encapsulation

        private string LastUsedPATH;
        private string LastUsedFavsPATH;
        private string LastUsedPlayersPATH;


        public FileRepository() : this("appinit.txt") //it is not possible to call default constructor without path, so use default path if no path is specified
        {
        }

        public FileRepository(string PATH) //create Class1, you must have path + file must exists!
        {
            LastUsedPATH = PATH;
            try
            {
                if (!File.Exists(PATH))
                {
                    throw new FileNotFoundException();
                }

                string[] temp = File.ReadAllLines(PATH);

                if (!(temp[0].Length > 0))
                {
                    throw new FormatException();
                }

                temp.ToList().ForEach(x => { initclass = Initclass.Parse(x); }); //stpd
            }
            catch (Exception ex) when (ex is FormatException) //I want it to throw filenotfound and crash (so i can use try catch block in the form to show init form)
            {
                Debug.WriteLine(ex.Message);
                throw new ConfigurationMissingException(ex.Message);
            }
        }

        public void AddFavsPath(string FavsPATH)
        {
            LastUsedFavsPATH = FavsPATH;
        }

        public void AddPlayersPath(string PlayersPATH)
        {
            LastUsedPlayersPATH = PlayersPATH;
        }
        public Initclass GetInitclass()
        {
            return initclass;
        }

        public Favoritesclass GetFavoritesclass()
        {
            if (Favoritesclass == null)
            {
                Favoritesclass = new Favoritesclass();
            }
            return favoritesclass;
        }

        public PlayersNotFavorite GetPlayersclass()
        {
            if (Playersclass == null)
            {
                Playersclass = new PlayersNotFavorite();
            }
            return Playersclass;
        }

        public void SaveInit(Initclass initclass)
        {
            if (!File.Exists(LastUsedPATH))
            {
                File.Create(LastUsedPATH);
            }

            string[] temp = new string[1];

            temp[0] = (Initclass.Write(initclass));

            File.WriteAllLines(LastUsedPATH, temp);
        }

        public void SaveFavorites(Favoritesclass favoritesclass)
        {
            if (!File.Exists(LastUsedFavsPATH))
            {
                File.Create(LastUsedFavsPATH);
            }

            string[] temp = new string[1];

            temp[0] = (Favoritesclass.Write(favoritesclass));

            try
            {
                File.WriteAllLines(LastUsedFavsPATH, temp);
            }
            catch (Exception ex)
            {

                throw new Exception("Writing threw an exception: " + ex.Message);
            }
        }

        public void SavePlayers(PlayersNotFavorite playersclass)
        {
            if (!File.Exists(LastUsedPlayersPATH))
            {
                File.Create(LastUsedPlayersPATH);
            }

            string[] temp = new string[1];

            temp[0] = (PlayersNotFavorite.Write(playersclass));

            try
            {
                File.WriteAllLines(LastUsedPlayersPATH, temp);
            }
            catch (Exception ex)
            {

                throw new Exception("Writing threw an exception: " + ex.Message);
            }
        }

        public void LoadFavorites(string FavoritesPATH) //retrofit in order to not force favorite players and their path into a library class (initclass only constructor)
        {
            try
            {

                if (!File.Exists(FavoritesPATH))
                {
                    throw new FileNotFoundException();
                }

                string[] temp = File.ReadAllLines(FavoritesPATH);

                if (!(temp[0].Length > 0))
                {
                    throw new FormatException();
                }

                temp.ToList().ForEach(x => { favoritesclass = Favoritesclass.Parse(x); }); //stpd
            }
            catch (Exception ex) when (ex is FormatException) //I want it to throw filenotfound and crash (so i can use try catch block in the form to show init form)
            {
                Debug.WriteLine(ex.Message);
                throw new ConfigurationMissingException(ex.Message);
            }
        }


        public void LoadPlayers(string PlayersPATH) //retrofit in order to not force favorite players and their path into a library class (initclass only constructor)
        {
            try
            {

                if (!File.Exists(PlayersPATH))
                {
                    throw new FileNotFoundException();
                }

                string[] temp = File.ReadAllLines(PlayersPATH);

                if (!(temp[0].Length > 0))
                {
                    throw new FormatException();
                }

                temp.ToList().ForEach(x => { Playersclass = PlayersNotFavorite.Parse(x); }); //stpd
            }
            catch (Exception ex) when (ex is FormatException) //I want it to throw filenotfound and crash (so i can use try catch block in the form to show init form)
            {
                Debug.WriteLine(ex.Message);
                throw new ConfigurationMissingException(ex.Message);
            }
        }
    }
}
