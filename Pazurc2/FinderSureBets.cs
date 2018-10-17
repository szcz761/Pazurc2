using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazurc2
{
    class FinderSureBets
    {
        

        public static List<Tie[]> FindSureBets(List<Tie> page1, List<Tie> page2)
        {
            List<Tie[]> SureBets = new List<Tie[]>();
            foreach (var tie1 in page1)
                foreach (var tie2 in page2)
                    if (Tie.IsTheSameTeams(tie1, tie2))
                        if (CalculateProfitPercent(tie1, tie2) > -0.5)
                            SureBets.Add(new Tie[]{ tie1, tie2});
            return SureBets;
        }

        public static double CalculateProfitPercent(Tie tie1, Tie tie2)
        {
            TeamWithOdds BeterBet = Tie.Max<TeamWithOdds>(tie1.GetHigherOddsTeam(), tie2.GetHigherOddsTeam());
            if (TeamWithOdds.IsTheSameBets(BeterBet, tie1.GetHigherOddsTeam()))
                if (BeterBet.Team.ToLower() != tie2.Team1.ToLower())
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie2.Odds1))) - 1) * 100;
                else
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie2.Odds2))) - 1) * 100;
            else
                if (BeterBet.Team.ToLower() != tie1.Team1.ToLower())
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie1.Odds1))) - 1) * 100; 
                else
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie1.Odds2))) - 1) * 100;

        }
    }
}
