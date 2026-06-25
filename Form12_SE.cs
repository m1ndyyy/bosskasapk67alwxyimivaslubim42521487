using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form12_SE : Form
    {
        public Form12_SE()
        {
            InitializeComponent();
            label1.Text = "Вы находите скрытый бункер NASA. На двери надпись: \"BACKROOMS\".\n" +
                          "Внутри — машина времени, собранная Тони Старком из металлолома.\n" +
                          "На экране появляется сообщение: \"RETURN TO 2020? Y/N\"\n" +
                          "Камера медленно приближается к вашему лицу под музыку \"Memory Reboot\".";

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