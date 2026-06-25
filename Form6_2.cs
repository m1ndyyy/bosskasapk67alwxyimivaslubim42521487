using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form6_2 : Form
    {
        public Form6_2()
        {
            InitializeComponent();

            label1.Text = "1. Спрятаться";
            label2.Text = "2. Атаковать";

            if (GameState.HasRobot)
            {
                label3.Visible = true;
                label3.Text = "3. Попробовать договориться";
                label3.Click += Label3_Click;
                label3.Cursor = Cursors.Hand;
                label3.MouseEnter += (s, e) => label3.ForeColor = System.Drawing.Color.Gold;
                label3.MouseLeave += (s, e) => label3.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                label3.Visible = false;
            }

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
            GameState.AddSanity(1);
            GameState.AddIntelligence(1);
            GameState.AddNeutral(1);
            MessageBox.Show("Рассказчик: Вы прячетесь за холодильником с ПСЫЖем. Существа проходят мимо.\n\n" +
                            "+1 Рассудок, +1 Интеллект, +1 Neutral", "Выбор сделан", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form7>();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            GameState.AddStrength(1);
            GameState.AddGood(1);
            GameManager.CloseAndShow<Form6_MG>();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            GameState.AddGood(1);
            MessageBox.Show("Робо-Навальный: Есть идея. Мы можем отвлечь существ мемами.\n\n+1 Good", "Робот помогает!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form6_3>();
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