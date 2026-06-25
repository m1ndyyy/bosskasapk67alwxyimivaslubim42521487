using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form9_GE : Form
    {
        public Form9_GE()
        {
            InitializeComponent();

            string robotText = GameState.HasRobot ?
                "\nРобо-Навальный тихо говорит: \"maybe the real sigma was the friends we made along the way\"" : "";

            label1.Text = "Самолет взлетает. Сквозь облака вы видите зеленый остров и гигантскую надпись \"WELCOME BACK\".\n" +
                          "Вас встречают выжившие: Гатс, CJ из GTA San Andreas, Курт Кобейн и человек в костюме Among Us.\n" +
                          "Кто-то включает музыку." +
                          robotText +
                          "\n\nИстория только начинается...";

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