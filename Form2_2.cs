using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form2_2 : Form
    {
        public Form2_2()
        {
            InitializeComponent();

            label1.Text = "1. Снять шлем";
            label2.Text = "2. Оставить шлем";

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
            GameState.AddStrength(1);
            GameState.AddCourage(1);
            GameState.AddGood(1);
            MessageBox.Show("Вы снимаете шлем. Из динамиков где-то вдали начинает играть \"Can You Feel My Heart\".\n" +
                            "*глубокий вдох* Почему воздух пахнет энергетиком и горелой пластмассой?\n" +
                            "Вы кашляете, а потом замечаете в песке идеально сохранившийся спиннер.\n" +
                            "Теперь вы чувствуете ветер, запах пыли и присутствие Райана Гослинга где-то неподалеку.\n\n" +
                            "+1 Сила, +1 Смелость, +1 Good", "Выбор сделан", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ShowContinuedDialog();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            GameState.AddIntelligence(1);
            GameState.AddSanity(1);
            MessageBox.Show("Вы решаете не рисковать. В этом мире любой микроб может оказаться подписчиком Влада А4.\n" +
                            "Шлем остается на месте. Визор автоматически включает Subway Surfers, чтобы вы не заскучали.\n\n" +
                            "+1 Интеллект, +1 Рассудок", "Выбор сделан", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ShowContinuedDialog();
        }

        private void ShowContinuedDialog()
        {
            MessageBox.Show("Рассказчик: Вдалеке вы замечаете разрушенный рекламный щит с надписью: \"РАБОТА ВПН\".\n" +
                            "Рассказчик: За щитом скрывается USB-флешка с надписью \"VPN\".\n" +
                            "Игрок: Слава Богу, сюда не добрались РКН.", "Продолжение", MessageBoxButtons.OK, MessageBoxIcon.Information);

            GameManager.CloseAndShow<Form2_3>();
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