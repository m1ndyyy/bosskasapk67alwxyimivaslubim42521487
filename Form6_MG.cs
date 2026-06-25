using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form6_MG : Form
    {
        private int enemyHP = 25;
        private int playerHP = 30;

        public Form6_MG()
        {
            InitializeComponent();

            playerHP = 30 + GameState.Strength;
            UpdateUI();

            label1.Click += Label1_Click;
            label2.Click += Label2_Click;

            label1.Cursor = Cursors.Hand;
            label2.Cursor = Cursors.Hand;

            label1.MouseEnter += (s, e) => label1.ForeColor = System.Drawing.Color.Gold;
            label1.MouseLeave += (s, e) => label1.ForeColor = System.Drawing.Color.Black;
            label2.MouseEnter += (s, e) => label2.ForeColor = System.Drawing.Color.Gold;
            label2.MouseLeave += (s, e) => label2.ForeColor = System.Drawing.Color.Black;

            label1.Text = "1. Атаковать";
            label2.Text = "2. Защищаться";

            button3.Click += button3_Click;
        }

        private void UpdateUI()
        {
            label3.Text = $"Ваше HP: {playerHP}\nВраг HP: {enemyHP}";
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            int damage = 3 + GameState.Strength + new Random().Next(0, 3);
            enemyHP -= damage;
            MessageBox.Show($"Вы нанесли {damage} урона!", "Атака!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (enemyHP <= 0)
            {
                Victory();
                return;
            }

            int enemyDamage = 4 + new Random().Next(0, 3);
            playerHP -= enemyDamage;
            MessageBox.Show($"Враг атакует и наносит {enemyDamage} урона!", "Удар!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (playerHP <= 0)
            {
                Defeat();
                return;
            }

            UpdateUI();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            int enemyDamage = (4 + new Random().Next(0, 3)) / 2;
            playerHP -= enemyDamage;
            MessageBox.Show($"Вы защищаетесь! Получено {enemyDamage} урона.", "Защита!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (playerHP <= 0)
            {
                Defeat();
                return;
            }

            UpdateUI();
        }

        private void Victory()
        {
            GameState.AddStrength(2);
            GameState.AddGood(3);
            MessageBox.Show("Вы победили монстра!\n+2 Сила, +3 Good", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form7>();
        }

        private void Defeat()
        {
            GameState.AddSanity(-3);
            GameState.AddBad(5);
            MessageBox.Show("Вы проиграли сражение...\n-3 Рассудка, +5 Bad", "Поражение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GameManager.CloseAndShow<Form11_BE>();
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