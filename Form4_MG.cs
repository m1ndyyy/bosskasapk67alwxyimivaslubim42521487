using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form4_MG : Form
    {
        public Form4_MG()
        {
            InitializeComponent();

            label1.Text = "1. Открыть капсулу";
            label2.Text = "2. Не трогать";

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
            GameState.AddBad(1);
            GameState.AddSanity(1);

            string dialog;
            if (GameState.HasRobot)
            {
                dialog = "Рассказчик: Из капсулы вываливается человек в зеленой маске и моментально убегает со скоростью света.\n" +
                         "Игрок: Это был… Dream?\n" +
                         "Робо-Навальный: Хуже. Это был его фанат.\n\n" +
                         "+1 Bad, +1 Рассудок";
            }
            else
            {
                dialog = "Рассказчик: Из капсулы вываливается человек в зеленой маске и моментально убегает со скоростью света.\n" +
                         "Игрок: Это был… Dream?\n\n" +
                         "+1 Bad, +1 Рассудок";
            }

            MessageBox.Show(dialog, "Капсула", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form5>();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            GameState.AddSecret(1);
            MessageBox.Show("Рассказчик: Изнутри капсулы кто-то тихо шепчет: \"спидран…\"\n\n+1 Secret", "Капсула", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form5>();
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