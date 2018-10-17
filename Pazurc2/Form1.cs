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
        public Form1()
        {
                InitializeComponent();
                Cef.Initialize(new CefSettings());
            chromeBrowserGG = InitializeChromium("https://gg.bet/en/betting?page=1");
            chromeBrowserEGB = InitializeChromium("https://egb.com/play/simple_bets");
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


        private void ScrollDownButton_Click(object sender, EventArgs e)
        {

        }
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var sureBets = FinderSureBets.FindSureBets(tiesGG, tiesEGB);
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
    }
}
