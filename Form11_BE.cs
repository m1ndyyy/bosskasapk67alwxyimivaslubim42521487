using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form11_BE : Form
    {
        public Form11_BE()
        {
            InitializeComponent();
            label1.Text = "Силы покидают вас. Песок засыпает следы, а небо становится красным как превью к creepypasta.\n" +
                          "Вы падаете на колени. Вдалеке медленно приближается Big Pibbles.\n" +
                          "Последнее, что вы слышите: \"bruh\".";

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