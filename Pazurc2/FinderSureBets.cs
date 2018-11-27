using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazurc2
{
    class FinderSureBets
    {
        

        public static List<Tie[]> FindSureBets(List<Tie> page1, List<Tie> page2, double sureBetValue)
        {
            List<Tie[]> SureBets = new List<Tie[]>();
            int i=0;
            foreach (var tie1 in page1)
            {
                bool ostatni = false;
                foreach (var tie2 in page2)
                    if (Tie.IsTheSameTeams(tie1, tie2))
                    {
                        ostatni = true;
                        ++i;
                        if (CalculateProfitPercent(tie1, tie2) > sureBetValue)
                            SureBets.Add(new Tie[] { tie1, tie2 });
                    }
               if(!ostatni)
               {
                Console.WriteLine("\n\n Odrzucony mecz: \n" + tie1.Print());
                    ostatni = false;
               }
            }
            Console.WriteLine("Przeliczono zysk z meczy: " + i);
            return SureBets;
        }

        public static double CalculateProfitPercent(Tie tie1, Tie tie2)
        {
            TeamWithOdds BeterBet = Tie.Max<TeamWithOdds>(tie1.GetHigherOddsTeam(), tie2.GetHigherOddsTeam());
            if (TeamWithOdds.IsTheSameBets(BeterBet, tie1.GetHigherOddsTeam()))
                if (!Tie.IsSimilarName( BeterBet.Team, tie2.Team1))
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie2.Odds1))) - 1) * 100;
                else
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie2.Odds2))) - 1) * 100;
            else
                 if (!Tie.IsSimilarName(BeterBet.Team, tie1.Team1))
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie1.Odds1))) - 1) * 100; 
                else
                    return ((1 / ((1 / BeterBet.Odds) + (1 / tie1.Odds2))) - 1) * 100;

        }
    }
}
