using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeyadRemoteControl.Forms
{
    public partial class FR : Form
    {
        [DllImport("User32.dll")]
        public static extern int BlockInput(int fBlock);
        private bool word;
        public FR(bool WordByWord)
        {
            InitializeComponent();
            word = WordByWord;
        }

        private void FR_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            Cursor.Hide();
            this.Opacity = 100;
            this.Visible = true;
            if (!word)
            {
                CenterLabel();
                Label1.Text = this.Text;
            }
            else
            {
                EveryWordShow();
            }

        }

        private void FR_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cursor.Show();
            FR.BlockInput(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
            timer1.Stop();
        }


        private async void EveryWordShow()
        {
            Random rnd = new Random();
            timer1.Stop();
            foreach (string x in Text.Split(' '))
            {
               
                Color randomColor = Color.FromArgb(rnd.Next(0, 70), rnd.Next(0, 100), rnd.Next(0, 100));
                if(BackColor != randomColor)
                {
                    BackColor = randomColor;
                }
                Label1.Text = x;
                await Task.Delay(750);
            }
            await Task.Delay(750);
            this.Dispose();
        }

        private void Label1_SizeChanged(object sender, EventArgs e)
        {
            CenterLabel();
        }

        void CenterLabel()
        {
            int x = (this.Size.Width - Label1.Size.Width) / 2;
            int y = (this.Size.Height - Label1.Size.Height) / 2;
            Label1.Location = new Point(x, y);
        }
    }
}
