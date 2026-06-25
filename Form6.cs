using NovelWF.Game;
using System;
using System.Windows.Forms;

namespace NovelWF
{
    public partial class Form6 : Form
    {
        private int step = 0;
        private string fullText = "";
        private int charIndex = 0;
        private System.Windows.Forms.Timer typingTimer = new System.Windows.Forms.Timer();
        private bool isTyping = false;

        private string[][] dialog = new string[][]
        {
            new string[] { "Рассказчик", "Ночь опускается на пустыню. Освещение магазина начинает мигать как во ФНАФе." },
            new string[] { "Рассказчик", "Из темноты появляются длинные черные фигуры. Они выглядят как смесь Титанов и Слендермена." },
            new string[] { "Игрок", "Почему у одного из них лицо Джима Керри?!" }
        };

        public Form6()
        {
            InitializeComponent();
            typingTimer.Interval = 30;
            typingTimer.Tick += TypingTimer_Tick;
            ShowDialog();

            groupBox1.Click += GroupBox_Click;
            foreach (Control ctrl in groupBox1.Controls) ctrl.Click += GroupBox_Click;

            pictureBox2.Click += PictureBox2_Click;
            pictureBox2.Cursor = Cursors.Hand;

            pictureBox3.Click += PictureBox3_Click;
            pictureBox3.Cursor = Cursors.Hand;

            pictureBox4.Click += PictureBox4_Click;
            pictureBox4.Cursor = Cursors.Hand;

            button3.Click += button3_Click;
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            if (charIndex < fullText.Length)
            {
                label1.Text += fullText[charIndex];
                charIndex++;
            }
            else
            {
                typingTimer.Stop();
                isTyping = false;
            }
        }

        private void ShowDialog()
        {
            if (step >= dialog.Length)
            {
                GameManager.CloseAndShow<Form6_2>();
                return;
            }

            var d = dialog[step];
            fullText = d[1];
            label1.Text = "";
            charIndex = 0;
            isTyping = true;
            typingTimer.Start();
            CharacterStyle.ApplyStyle(d[0], label1);
        }

        private void SkipTyping()
        {
            if (isTyping)
            {
                typingTimer.Stop();
                label1.Text = fullText;
                isTyping = false;
            }
        }

        private void GroupBox_Click(object sender, EventArgs e)
        {
            if (isTyping) { SkipTyping(); return; }
            if (step < dialog.Length)
            {
                step++;
                ShowDialog();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (isTyping) { SkipTyping(); return; }
            if (step < dialog.Length)
            {
                step++;
                ShowDialog();
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (isTyping) { SkipTyping(); return; }
            if (step < dialog.Length - 1)
            {
                step = dialog.Length - 1;
                ShowDialog();
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (isTyping) { SkipTyping(); return; }
            if (step > 0)
            {
                step--;
                ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isTyping) SkipTyping();
            ShowStats();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isTyping) SkipTyping();
            GameManager.SaveGame();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isTyping) SkipTyping();
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