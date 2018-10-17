using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazurc2
{
    class TeamWithOdds : IComparable<TeamWithOdds>
    {
        public string Team { get; set; }
        public double Odds { get; set; }

        public static bool IsTheSameBets(TeamWithOdds two1, TeamWithOdds two2)
        {
            return (two1.Odds == two2.Odds && two1.Team == two2.Team);
        }

        public int CompareTo(TeamWithOdds obj)
        {
            return Odds.CompareTo(obj.Odds);
        }
    }

    class Tie
    {
        public DateTime Time { get; set; }
        public string Event { get; set; }

        public string Team1 { get; set; }
        public double Odds1 { get; set; }

        public string Team2 { get; set; }
        public double Odds2 { get; set; }

        public TeamWithOdds GetHigherOddsTeam()
        {
            if (Odds1>Odds2)
                return new TeamWithOdds() { Odds = Odds1, Team = Team1 };
            else
                return new TeamWithOdds() { Odds = Odds2, Team = Team2 };
        }
        public TeamWithOdds GetLowerOddsTeam()
        {
            if (Odds1 < Odds2)
                return new TeamWithOdds() { Odds = Odds1, Team = Team1 };
            else
                return new TeamWithOdds() { Odds = Odds2, Team = Team2 };
        }

        public static bool IsTheSameTeams(Tie tie1, Tie tie2)
        {
            return
                (tie1.Team1.ToLower() == tie2.Team1.ToLower() || tie1.Team1.ToLower() == tie2.Team2.ToLower()) &&
                (tie1.Team2.ToLower() == tie2.Team1.ToLower() || tie1.Team2.ToLower() == tie2.Team2.ToLower());
        }

        public string Print()
        {
            return Time + "\n" + Event + "\n" + Team1 + " : " + Odds1 + "\n" + Team2 + " : " + Odds2;
        }

        public static T Max<T>(T v1, T v2) where T : class, IComparable<T>
        {
            return (v1.CompareTo(v2) > 0 ? v1 : v2);
        }
    }
}
