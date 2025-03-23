using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Constants
{
    public static class EndpointConstants
    {

        public const string TeamsM = "https://worldcup-vua.nullbit.hr/men/teams";
        public const string MatchesM = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string ResultsM = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string MatchesByCodeM = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";

        public const string TeamsW = "https://worldcup-vua.nullbit.hr/women/teams";
        public const string MatchesW = "https://worldcup-vua.nullbit.hr/women/matches";
        public const string ResultsW = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string MatchesByCodeW = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
        
        public const string rTeamsMLocal = @"..\..\..\..\worldcup-sfg-io\worldcup.sfg.io\men\teams.json";
        public const string rMatchesMLocal = @"..\..\..\..\worldcup-sfg-io\worldcup.sfg.io\men\matches.json";
        public const string rResultsMLocal = @"..\..\..\..\worldcup-sfg-io\worldcup.sfg.io\men\results.json";

        public const string rTeamsWLocal = @"..\..\..\..\worldcup-sfg-io\worldcup.sfg.io\women\teams.json";
        public const string rMatchesWLocal = @"..\..\..\..\worldcup-sfg-io\worldcup.sfg.io\women\matches.json";
        public const string rResultsWLocal = @"..\..\..\..\worldcup-sfg-io\worldcup.sfg.io\women\results.json";

    }
}
