using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form6_3 : Form
    {
        public Form6_3()
        {
            InitializeComponent();

            label1.Text = "1. Включить котиков";
            label2.Text = "2. Включить брейнроты";

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
            GameState.AddGood(1);
            MessageBox.Show("Рассказчик: Существа довольные уходят\n\n+1 Good", "Котики!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameManager.CloseAndShow<Form7>();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            GameState.AddBad(1);
            MessageBox.Show("Рассказчик: Существа раздраженно уходят\n\n+1 Bad", "Брейнроты", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GameManager.CloseAndShow<Form7>();
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