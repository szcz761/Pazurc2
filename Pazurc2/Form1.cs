using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Threading;

namespace Pazurc2
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowserEGB;
        public ChromiumWebBrowser chromeBrowserGG;
        private List<Tie> tiesEGB;
        private List<Tie> tiesGG;
        bool auto =false;
        Thread t;
        public Form1()
        {
            InitializeComponent();
            Cef.Initialize(new CefSettings());
            chromeBrowserGG = InitializeChromium("https://gg.bet/en/betting?page=1");
            chromeBrowserEGB = InitializeChromium("https://egb.com/play/simple_bets");
            chromeBrowserGG.Focus();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        public ChromiumWebBrowser InitializeChromium(string uri)
        {          
            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser(uri);
            this.Controls.Add(chromeBrowser);
            //chromeBrowser.Dock = DockStyle.Bottom;
            return chromeBrowser;
        }

        private void GetHTMLButton_Click(object sender, EventArgs e)
        {
            try
            {
                getFrameEGBasync();
                getFrameGG();
            }
            catch
            {
                Cef.Shutdown();
            }
        }
        async void strollDown()
        {
            chromeBrowserGG.Focus();
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                    SendKeys.Send("{PGDN}");

                Thread.Sleep(2000);
            }
        }

        async void getFrameEGBasync()
        {

            richTextBox1.Text =  await chromeBrowserEGB.GetBrowser().MainFrame.GetSourceAsync();
        }

        async void getFrameGG()
        {
            richTextBox2.Text = await chromeBrowserGG.GetBrowser().MainFrame.GetSourceAsync();
        }

        private void ParseButton_Click(object sender, EventArgs e)
        {
            tiesEGB = EGBParser.ParseTies(richTextBox1.Text);

            tiesEGB = EGBParser.RepaireTies(tiesEGB);
            Console.WriteLine("==========EGB=========");
            foreach (var tie in tiesEGB)
                Console.WriteLine(tie.Print());
            Console.WriteLine(tiesEGB.Count);

            richTextBox3.Text += "Znaleziono w EGB dobrych meczy: " + tiesEGB.Count + "\n";

            Console.WriteLine("==========GG=========");
            tiesGG = GGParser.ParseTies(richTextBox2.Text);
            foreach (var tie in tiesGG)
                Console.WriteLine(tie.Print());
            Console.WriteLine(tiesGG.Count);
            richTextBox3.Text += "Znaleziono w GG dobrych meczy: " + tiesGG.Count + "\n";
        }


        private void Automat(object sender, EventArgs e, double sureBetValue, bool beep, int timeSleep, List<Tuple<string,string>> checkedSure)
        {
            while (true)
            {
                Task<string> a = chromeBrowserEGB.GetBrowser().MainFrame.GetSourceAsync();
                Task<string> b = chromeBrowserGG.GetBrowser().MainFrame.GetSourceAsync();
                var tEGB = EGBParser.ParseTies(a.Result);
                tEGB = EGBParser.RepaireTies(tEGB);
                var tGG = GGParser.ParseTies(b.Result);
                Console.WriteLine("Znaleziono w EGB dobrych meczy: " + tEGB.Count + "\n");
                Console.WriteLine("Znaleziono w GG dobrych meczy: " + tGG.Count + "\n");
                var sureBets = FinderSureBets.FindSureBets(tEGB, tGG, sureBetValue);
                foreach (var sureBet in sureBets)
                {
                    if (checkedSure.Count !=0 && checkedSure.Contains(new Tuple<string,string>(sureBet[0].Team1, sureBet[0].Team2)))
                        continue;
                    Console.WriteLine("----------------ZNALEZIONOI SUREBET-------------------");
                    Console.WriteLine("Zysk: " + FinderSureBets.CalculateProfitPercent(sureBet[0], sureBet[1]));
                    Console.WriteLine("   ");
                    Console.WriteLine(sureBet[0].Print());
                    Console.WriteLine("-----VS-----");
                    Console.WriteLine(sureBet[1].Print());
                    if(beep)
                        Console.Beep();
                }
                Thread.Sleep(timeSleep);
            }
        }
        private void ScrollDownButton_Click(object sender, EventArgs e)
        {
            if (!auto)
            {
                ScrollDownButton.Text = "Automat ON";
                List<Tuple<string, string>> checkedSure = new List<Tuple<string, string>>();
                //string[] array = ;

                foreach (string line in SureChecked.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    if(line.Contains("&"))
                        checkedSure.Add(new Tuple<string, string>(line.Split('&')[0], line.Split('&')[1]));
                t = new Thread(() => Automat(sender, e, double.Parse(MinScore.Text), Beep.Checked, int.Parse(TimeSleepS.Text) * 1000, checkedSure));
                t.Start();
                auto = true;
            }
            else
            {
                t.Abort();
                auto = false;
                ScrollDownButton.Text = "Automat OFF";
            }
        }
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var sureBets = FinderSureBets.FindSureBets(tiesEGB, tiesGG, -0.1);
            foreach (var sureBet in sureBets)
            {
                Console.WriteLine("----------------ZNALEZIONOI SUREBET-------------------");
                Console.WriteLine("Zysk: "+  FinderSureBets.CalculateProfitPercent(sureBet[0], sureBet[1]));
                Console.WriteLine("   ");
                Console.WriteLine(sureBet[0].Print());
                Console.WriteLine("-----VS-----");
                Console.WriteLine(sureBet[1].Print());
                ShowSureBets(sureBet);
            }
        }
        private void ShowSureBets(Tie[] sureBet)
        {
            richTextBox3.Text += "---------ZNALEZIONOI SUREBET---------\n";
            richTextBox3.Text += "Zysk: " + FinderSureBets.CalculateProfitPercent(sureBet[0], sureBet[1])+"\n\n";
            richTextBox3.Text += sureBet[0].Print() + "\n";
            richTextBox3.Text += "-----VS-----\n";
            richTextBox3.Text += sureBet[1].Print() + "\n\n";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
