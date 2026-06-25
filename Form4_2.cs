using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form4_2 : Form
    {
        public Form4_2()
        {
            InitializeComponent();

            label1.Text = "1. Взломать силой";
            label2.Text = "2. Взломать интеллектом";

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
            if (GameState.Strength >= 2)
            {
                GameState.AddStrength(1);
                GameState.AddGood(1);
                MessageBox.Show("Рассказчик: Дверь открывается! Внутри — оружие, энергетики и Blu-ray коллекция \"Евангелиона\".\n" +
                                "Игрок: Пистолет... и фигурка Аски. Человечество действительно погибло.\n\n" +
                                "+1 Сила, +1 Good", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GameState.AddIntelligence(-1);
                GameState.AddBad(1);
                MessageBox.Show("Рассказчик: Система блокируется. Из динамиков начинает орать \"AMOGUS\".\n" +
                                "Рассказчик: Вам приходится уйти, пока стены не начали воспроизводить брейнрот мемы.\n\n" +
                                "-1 Интеллект, +1 Bad", "Провал!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ShowContinuedDialog();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            if (GameState.Intelligence >= 2)
            {
                GameState.AddIntelligence(1);
                GameState.AddGood(1);
                MessageBox.Show("Рассказчик: Дверь открывается! Внутри — оружие, энергетики и Blu-ray коллекция \"Евангелиона\".\n" +
                                "Игрок: Пистолет... и фигурка Аски. Человечество действительно погибло.\n\n" +
                                "+1 Интеллект, +1 Good", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GameState.AddIntelligence(-1);
                GameState.AddBad(1);
                MessageBox.Show("Рассказчик: Система блокируется. Из динамиков начинает орать \"AMOGUS\".\n" +
                                "Рассказчик: Вам приходится уйти, пока стены не начали воспроизводить брейнрот мемы.\n\n" +
                                "-1 Интеллект, +1 Bad", "Провал!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ShowContinuedDialog();
        }

        private void ShowContinuedDialog()
        {
            MessageBox.Show("Рассказчик: В лаборатории вы находите криокапсулу с надписью \"DO NOT OPEN\".",
                            "Продолжение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GameManager.CloseAndShow<Form4_MG>();
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