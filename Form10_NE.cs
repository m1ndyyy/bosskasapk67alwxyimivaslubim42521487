using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form10_NE : Form
    {
        public Form10_NE()
        {
            InitializeComponent();
            label1.Text = "Вы находите убежище. Оно пустое. Только старый телевизор бесконечно показывает Shrek Forever After.\n" +
                          "Вы живете один среди руин, питаясь консервами и скачанными мемами.\n" +
                          "Иногда ночью вам кажется, что где-то рядом звучит SKIBIDI.";

            button3.Click += button3_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameManager.ExitToMain();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameManager.LoadGame();
        }
    }
}