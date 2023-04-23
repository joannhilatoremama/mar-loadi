using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class LoadingForm : Form
    {
        /// if i gave this program to you it means you are awesome
        string[] quotes = new string[]
        {
            "loading the marcosi kernel",
            "ironing my clothes",
            "developed by kiwi",
            "hacking roblox",
            "leaking files",
            "joining cults",
            "jammin out",
            "FAILED",
            "fluffin my code",
            "spgahettification",
            "im a coward",
            "SUCCESS",
            "installed wannacry",
            "fjords...",
            "kurfuffled",
            "hi andromeda",
            "hi blu",
            "hi ck",
            "hi six",
            "Welcome to the marcosi platform",
            "MAYBE FAILED",
            "MAYBE SUCCEDDED",
            "this took to long to write",
            "GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS GERBALS",
            "i belive in myself",
            "idk choreography just isnt my thing",
            "I'm not sure what you think Stack Overflow is, or who you think YOU are, but you're not going to get far with all-caps in a community that debates the right way to indent code.",
            "Closed. This question needs debugging details. It is not currently accepting answers.",
            "i genuinly cant belive all the qoutes i made",
            "hi mom",
            "developed by kiwi/henryparks/dart/dootnet/dobby/jason/alex/unilerk",
            "finishing magic admin",
            "gtrnugiuguruigugeruigiue",
            "dont click that info box...",
            "wouldnt you like to know weather boy?",
            "im made of candy",
            "i have nothing againts furrys",
            "blargh! i flipped up my tests!",
            "im a true marcosi",
            "we makin it out da IDE wit dis one",
            "installed something",
            "your music tastes a bit off (im joking)",
            "can you even read these?",
            "no repeating qoutes here",
            "peter griffins bunker busting mega utla super",
            "im not going back to that friend group",
            "i respect your privacy (sometimes)",
            "dont read the code PLEASE ITS PRIVATE",
            "blank",
            "MAYBE SUCCEDDED",
            "#beat continues",
            "katsellers isnt dead",
            "sometimes i trust myself",
            "CAN SOMEONE PLEASE",
            "staue of lidually!",
            "if you live in oklahoma get the heck out of here"
        };

        private void CenterPanel(Panel panel)
        {
            panel.Left = (this.ClientSize.Width - panel.Width) / 2;
            panel.Top = (this.ClientSize.Height - panel.Height) / 2;
        }
        private void LoadingForm_Resize(object sender, EventArgs e)
        {
            CenterPanel(panel1);
        }

        private enum FadeState
        {
            FadeIn,
            FadeOut
        }

        private FadeState _fadeState;

        private SoundPlayer player;

        public LoadingForm()
        {
            InitializeComponent();
            timercool.Interval = 500; // Change this value to set the interval between quote changes.
            timercool.Tick += Timer1_Tick;
            Timer1_Tick(null, null); // Call the event handler once to display a random quote immediately.
            timercool.Start();
            player = new SoundPlayer("Marcosi.wav");
            try
            {
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing audio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Opacity = 0;
            pictureBox1.Visible = false;

            this.Resize += LoadingForm_Resize;

            _fadeState = FadeState.FadeIn;
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();

            delayTimer.Tick += DelayTimer_Tick;
            delayTimer.Start();

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int index = random.Next(quotes.Length);
            string selectedQuote = quotes[index];
            label1.Text = selectedQuote;
        }
        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            switch (_fadeState)
            {
                case FadeState.FadeIn:
                    if (this.Opacity < 0.95)
                    {
                        this.Opacity += 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                    }
                    break;
                case FadeState.FadeOut:
                    if (this.Opacity > 0) // Change this value to the desired minimum opacity.
                    {
                        this.Opacity -= 0.05;
                    }
                    else
                    {
                        fadeTimer.Stop();
                        this.Close();
                    }
                    break;
            }
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            delayTimer.Stop();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Simulate a long-running task.
            System.Threading.Thread.Sleep(3750); // Adjust the sleep time as needed.
        }

        private async void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Start fading out the loading screen when the task is complete.
            _fadeState = FadeState.FadeOut;
            fadeTimer.Start();
            await Task.Delay(1000);
            Process.Start("Marcosis.exe");
        }
    }
}