using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form5_2 : Form
    {
        public Form5_2()
        {
            InitializeComponent();

            label1.Text = "1. Смотреть Skibidi Toilet";
            label2.Text = "2. Смотреть Стинта";
            label3.Text = "3. Смотреть документалку";
            label4.Text = "4. Разбить телевизор";

            label1.Click += Label1_Click;
            label2.Click += Label2_Click;
            label3.Click += Label3_Click;
            label4.Click += Label4_Click;

            label1.Cursor = Cursors.Hand;
            label2.Cursor = Cursors.Hand;
            label3.Cursor = Cursors.Hand;
            label4.Cursor = Cursors.Hand;

            label1.MouseEnter += (s, e) => label1.ForeColor = System.Drawing.Color.Gold;
            label1.MouseLeave += (s, e) => label1.ForeColor = System.Drawing.Color.Black;
            label2.MouseEnter += (s, e) => label2.ForeColor = System.Drawing.Color.Gold;
            label2.MouseLeave += (s, e) => label2.ForeColor = System.Drawing.Color.Black;
            label3.MouseEnter += (s, e) => label3.ForeColor = System.Drawing.Color.Gold;
            label3.MouseLeave += (s, e) => label3.ForeColor = System.Drawing.Color.Black;
            label4.MouseEnter += (s, e) => label4.ForeColor = System.Drawing.Color.Gold;
            label4.MouseLeave += (s, e) => label4.ForeColor = System.Drawing.Color.Black;

            button3.Click += button3_Click;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            GameState.AddSanity(-1);
            GameState.AddBad(1);
            MessageBox.Show("-1 Рассудок, +1 Bad", "Skibidi Toilet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GameManager.CloseAndShow<Form6>();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            GameState.AddCharisma(1);
            MessageBox.Show("+1 Харизма", "Стинт", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form6>();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            GameState.AddIntelligence(1);
            GameState.AddSecret(1);
            MessageBox.Show("+1 Интеллект, +1 Secret", "Документалка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form6>();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            GameState.AddStrength(1);
            MessageBox.Show("+1 Сила", "Сила!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form6>();
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