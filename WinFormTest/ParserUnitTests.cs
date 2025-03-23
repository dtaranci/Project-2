using ClassLibrary1.JsonParser;
using ClassLibrary1.Models.Test;
using ClassLibrary1.Models;
using System.Diagnostics;
using System.Net;
using ClassLibrary1.Models.Two;

namespace WinFormTest
{
    [TestClass]
    public class ParserUnitTests
    {
        private IJsonParser parser;

        private IList<TeamsModel> Teams;
        private IList<TeamsModel> Teams2;

        private IList<MatchesModel2> Matches;
        private IList<MatchesModel2> Matches2;
        
        private IList<ResultsModel> Results;
        private IList<ResultsModel> Results2;


        private const string TeamsM = "https://worldcup-vua.nullbit.hr/men/teams";
        private const string MatchesM = "https://worldcup-vua.nullbit.hr/men/matches";
        private const string ResultsM = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private const string MatchesByCodeM = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";

        private const string TeamsW = "https://worldcup-vua.nullbit.hr/women/teams";
        private const string MatchesW = "https://worldcup-vua.nullbit.hr/women/matches";
        private const string ResultsW = "https://worldcup-vua.nullbit.hr/women/teams/results";
        private const string MatchesByCodeW = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";

        [TestMethod]
        public void Parser_GetInstance_Success()
        {
            try
            {
                parser = JsonParserFactory.GetInstance();
                Debug.WriteLine("Parser instance assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Can't get JsonParser instance");
            }
        }
            [TestMethod]
        public void MatchesByFifaCode_Parse_Success()
        {
            try
            {
                parser = JsonParserFactory.GetInstance();
            }
            catch (Exception)
            {
                Assert.Fail("Can't get JsonParser instance");
            }
            //string[] FifaCodes = ["CRO", "ENG", "RUS", "AUS", "SRB", "FRA", "GER", "COL", "ARG", "BRA", "POL"];
            try
            {
                Teams = new List<TeamsModel>(parser.ParseMatchModel<TeamsModel>(TeamsM));
                Debug.WriteLine("TeamsModel (M) list assigned successfully");
                Teams2 = new List<TeamsModel>(parser.ParseMatchModel<TeamsModel>(TeamsW));
                Debug.WriteLine("TeamsModel (W) list assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Parsing teams failed");
            }
            try
            {
                for (int i = 0; i < Teams.Count; i++)
                {
                    Debug.WriteLine(MatchesByCodeM+Teams[i].FifaCode);
                    var ParsedFifaCode = new List<FifaCodeMatchModel>(parser.ParseMatchModel<FifaCodeMatchModel>(MatchesByCodeM+Teams[i].FifaCode));
                    Debug.WriteLine(Teams[i].FifaCode + " Parsed successfully");
                }
                Debug.WriteLine("FifaCodeMatchModel (M) lists assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Can't parse fifacode (M) from source");
            }

            try
            {
                for (int i = 0; i < Teams2.Count; i++)
                {
                    Debug.WriteLine(MatchesByCodeW + Teams2[i].FifaCode);
                    var ParsedFifaCode = new List<FifaCodeMatchModel>(parser.ParseMatchModel<FifaCodeMatchModel>(MatchesByCodeW + Teams2[i].FifaCode));
                    Debug.WriteLine(Teams2[i].FifaCode + " Parsed successfully");
                }
                Debug.WriteLine("FifaCodeMatchModel (W) lists assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Can't parse fifacode (W) from source");
            }
        }

        [TestMethod]
        public void Teams_Parse_Success()
        {
            try
            {
                parser = JsonParserFactory.GetInstance();

            }
            catch (Exception)
            {
                Assert.Fail("Can't get JsonParser instance");
            }
            try
            {
                Teams = new List<TeamsModel>(parser.ParseMatchModel<TeamsModel>(TeamsM));
                Debug.WriteLine("TeamsModel (M) list assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Parsing teams (M) failed");
            }
            try
            {
                Teams2 = new List<TeamsModel>(parser.ParseMatchModel<TeamsModel>(TeamsW));
                Debug.WriteLine("TeamsModel (W) list assigned successfully");

            }
            catch (Exception)
            {
                Assert.Fail("Parsing teams (W) failed");
            }
        }

        [TestMethod]
        public void Matches_Parse_Success()
        {
            try
            {
                parser = JsonParserFactory.GetInstance();

            }
            catch (Exception)
            {
                Assert.Fail("Can't get JsonParser instance");
            }
            try
            {
                Matches = new List<MatchesModel2>(parser.ParseMatchModel<MatchesModel2>(MatchesM));
                Debug.WriteLine("MatchesModel (M) list assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Parsing teams failed");
            }
            try
            {
                Matches2 = new List<MatchesModel2>(parser.ParseMatchModel<MatchesModel2>(MatchesW));
                Debug.WriteLine("MatchesModel (W) list assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Parsing teams failed");
            }
        }

        [TestMethod]
        public void Results_Parse_Success()
        {
            try
            {
                parser = JsonParserFactory.GetInstance();

            }
            catch (Exception)
            {
                Assert.Fail("Can't get JsonParser instance");
            }
            try
            {
                Results = new List<ResultsModel>(parser.ParseMatchModel<ResultsModel>(ResultsM));
                Debug.WriteLine("ResultsModel (M) list assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Parsing results (M) failed");
            }
            try
            {
                Results2 = new List<ResultsModel>(parser.ParseMatchModel<ResultsModel>(ResultsW));
                Debug.WriteLine("ResultsModel (W) list assigned successfully");
            }
            catch (Exception)
            {
                Assert.Fail("Parsing results (W) failed");
            }
        }
        /*
        //[DynamicData(nameof(MatchesModel2), DynamicDataSourceType.Method)]
        [TestMethod]
        public void All_Parse_Success<T>(ref string value)
        {
            try
            {
                parser = JsonParserFactory.GetInstance();

            }
            catch (Exception)
            {
                Assert.Fail("Can't get JsonParser instance");
            }
            try
            {
                var Results = new List<T>(parser.ParseMatchModel<T>(value));
            }
            catch (Exception)
            {
                Assert.Fail("Parsing results (M) failed");
            }
        }*/
    }
}