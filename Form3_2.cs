using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form3_2 : Form
    {
        public Form3_2()
        {
            InitializeComponent();

            label1.Text = "1. Взять робота с собой";
            label2.Text = "2. Оставить робота";

            label1.Click += Label1_Click;
            label2.Click += Label2_Click;

            label1.Cursor = Cursors.Hand;
            label2.Cursor = Cursors.Hand;

            label1.MouseEnter += (s, e) => label1.ForeColor = System.Drawing.Color.Gold;
            label1.MouseLeave += (s, e) => label1.ForeColor = System.Drawing.Color.Black;
            label2.MouseEnter += (s, e) => label2.ForeColor = System.Drawing.Color.Gold;
            label2.MouseLeave += (s, e) => label2.ForeColor = System.Drawing.Color.Black;

            button3.Click += button3_Click;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            GameState.AddCharisma(1);
            GameState.AddGood(1);
            GameState.AddSecret(1);
            GameState.HasRobot = true;
            MessageBox.Show("Игрок: Ладно, Робо-Навальный. Только без политики, пж.\n" +
                            "Робо-Навальный: Не обещаю. Также у меня встроен VPN и 40 терабайт компромата на... человечество.\n" +
                            "Рассказчик: Робот довольно пищит и включает phonk-ремикс гимна России.\n" +
                            "Рассказчик: Вы впервые за долгое время ощущаете, что одиночество отступает.\n\n" +
                            "+1 Харизма, +1 Good, +1 Secret", "Новый союзник!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ShowContinuedDialog();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            GameState.AddSanity(-1);
            GameState.AddBad(1);
            MessageBox.Show("Игрок: Нет. После Detroit: Become Human я вам не доверяю.\n" +
                            "Робо-Навальный: Понимаю. Значит, снова смотреть мемы одному…\n" +
                            "Рассказчик: Экран робота медленно тухнет. Последнее, что вы слышите — грустный тромбон.\n\n" +
                            "-1 Рассудок, +1 Bad", "Прощание", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ShowContinuedDialog();
        }

        private void ShowContinuedDialog()
        {
            MessageBox.Show("Робо-Навальный: Кстати. Перед войной люди разделились на два лагеря.\n" +
                            "Игрок: Какие еще лагеря?\n" +
                            "Робо-Навальный: Те, кто смотрел аниме с субтитрами… и те, кто ел пиццу с ананасами.",
                            "Продолжение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GameManager.CloseAndShow<Form3_3>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowStats();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameManager.SaveGame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameManager.LoadGame();
        }

        private void ShowStats()
        {
            string stats = $"📊 ХАРАКТЕРИСТИКИ:\n\n" +
                          $"Сила: {GameState.Strength}\n" +
                          $"Интеллект: {GameState.Intelligence}\n" +
                          $"Харизма: {GameState.Charisma}\n" +
                          $"Рассудок: {GameState.Sanity}\n" +
                          $"Смелость: {GameState.Courage}\n\n" +
                          $"🏆 ОЧКИ КОНЦОВОК:\n" +
                          $"Good: {GameState.GoodEnding}\n" +
                          $"Neutral: {GameState.NeutralEnding}\n" +
                          $"Bad: {GameState.BadEnding}\n" +
                          $"Secret: {GameState.SecretEnding}";

            MessageBox.Show(stats, "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}