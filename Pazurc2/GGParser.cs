using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Globalization;

namespace Pazurc2
{
    static class GGParser
    {
        static public List<Tie> ParseTies(string page)
        {

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            var ties = new List<Tie>();
            var nodes = doc.QuerySelectorAll("div.matchRowContainer__container___1_tLJ");
            foreach (var node in nodes)
            {
                try
                {
                    if (node.QuerySelector("div.matchRowSecondary__market-name___30Q_s").InnerText != "Winner") //no 1 vs 1 bet
                        continue;
                    ties.Add(ParseTie(node));
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return ties;
        }

        static Tie ParseTie(HtmlNode node)
        {
            var tie = new Tie()
            {
                Time = ParseTime(node),
                Event = ParseEvent(node),
                Team1 = ParseTeam1(node),
                Team2 = ParseTeam2(node)
            };
            tie.Odds1 = ParseOdds1(node, tie.Team1);
            tie.Odds2 = ParseOdds1(node, tie.Team2);
            return tie;
        }

        static DateTime ParseTime(HtmlNode node)
        {
            var HTMLDate = node.QuerySelector("div.__app-DateTime-container");
            if (HTMLDate == null)
                throw new ArgumentException("Cant parse all information");

            return GetDateFromInnerHTML(HTMLDate.InnerText);
        }

        private static DateTime GetDateFromInnerHTML(string date)
        {
            if (date.Contains("Today"))
                return DateTime.Parse(DateTime.Now.Date.ToString().Remove(10) + " " + date.Remove(5));
            else
            {
                var x = date.Insert(6, "h").Split('h');
                var y = x[0].Split(' ');
                return DateTime.Parse(x[1] + " " + y[1] + " " + y[0]);
            }
        }

        static string ParseEvent(HtmlNode node)
        {
            return node.QuerySelector("div.__app-TournamentLogo-tournament-logo").GetAttributeValue("title", "");
        }

        static string ParseTeam1(HtmlNode node)
        {
            return node.QuerySelector("div.middlePartMatchRow__bunch-left___3KZAo").InnerText;
        }

        static string ParseTeam2(HtmlNode node)
        {
            return node.QuerySelector("div.middlePartMatchRow__bunch-right___3CW7s").InnerText; 
        }

        static double ParseOdds1(HtmlNode node, string team1)
        {
            var titles = node.QuerySelectorAll("div.__app-Odd-inner");
            if (titles[0].ParentNode.GetAttributeValue("title", "").Contains(team1))
                return double.Parse(titles[0].QuerySelector("div.__app-Odd-inner").InnerText.Replace('.', ','));
            else
                return double.Parse(titles[1].QuerySelector("div.__app-Odd-inner").InnerText.Replace('.', ','));
        }

        static double ParseOdds2(HtmlNode node, string team2)
        {
            var titles = node.QuerySelectorAll("div.__app-Odd-inner");
            if (titles[0].ParentNode.GetAttributeValue("title", "").Contains(team2))
                return double.Parse(titles[1].QuerySelector("div.__app-Odd-inner").InnerText.Replace('.', ','));
            else
                return double.Parse(titles[0].QuerySelector("div.__app-Odd-inner").InnerText.Replace('.', ','));
        }
    }
}

