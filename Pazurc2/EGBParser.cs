﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Pazurc2
{
    static class EGBParser
    {
        static public List<Tie> ParseTies(string page)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            var ties = new List<Tie>();
            var nodes = doc.QuerySelectorAll("div.table-bets__content-row");
            foreach (var node in nodes)
            {
                try
                {
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
            return new Tie()
            {
                Time = ParseTime(node),
                Event = ParseEvent(node),
                Team1 = ParseTeam1(node),
                Odds1 = ParseOdds1(node),
                Team2 = ParseTeam2(node),
                Odds2 = ParseOdds2(node)
            };
        }

        static DateTime ParseTime(HtmlNode node)
        {          
            var HTMLDate = node.QuerySelector("div.table-bets__date");

            if (HTMLDate == null || HTMLDate.FirstChild.InnerHtml.Length != 5)
                throw new ArgumentException("Cant parse all information");

            DateTime date = DateTime.Parse(HTMLDate.FirstChild.InnerHtml + " " + DateTime.Now.Year + " " + HTMLDate.LastChild.InnerHtml);

            if (date < DateTime.Now)
                throw new ArgumentException("This match was alerady started");
        
            return date;
        }

        static string ParseEvent(HtmlNode node)
        {
            return node.QuerySelector("div.table-bets__event").LastChild.InnerHtml;
        }

        static string ParseTeam1(HtmlNode node)
        {
            return node.QuerySelector("div.table-bets__col-1").FirstChild.LastChild.InnerHtml;
        }

        static double ParseOdds1(HtmlNode node)
        {
            if (node.QuerySelector("div.table-bets__col-1").LastChild.FirstChild == null)
                throw new ArgumentException("Cant parse all information");

            return double.Parse(node.QuerySelector("div.table-bets__col-1").LastChild.FirstChild.InnerHtml.Replace('.', ','));
        }

        static string ParseTeam2(HtmlNode node)
        {
            return node.QuerySelector("div.table-bets__col-3").FirstChild.LastChild.InnerHtml;
        }

        static double ParseOdds2(HtmlNode node)
        {
            if (node.QuerySelector("div.table-bets__col-3").LastChild.FirstChild == null)
                throw new ArgumentException("Cant parse all information");

            return double.Parse(node.QuerySelector("div.table-bets__col-3").LastChild.FirstChild.InnerHtml.Replace('.', ','));
        }
    }
}
