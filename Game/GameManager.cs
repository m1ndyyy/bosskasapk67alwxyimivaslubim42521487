using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace NovelWF.Game
{
    public static class GameManager
    {
        public static Form CurrentForm { get; private set; }
        private static string SavePath = "save.json";

        public static void ShowForm(Form form)
        {
            CurrentForm = form;
            form.Show();
        }

        public static void ShowForm<T>() where T : Form, new()
        {
            var form = new T();
            ShowForm(form);
        }

        public static void CloseAndShow<T>() where T : Form, new()
        {
            var form = new T();
            if (CurrentForm != null && !CurrentForm.IsDisposed)
            {
                CurrentForm.Close();
                CurrentForm.Dispose();
            }
            CurrentForm = form;
            form.Show();
        }

        public static void ExitToMain()
        {
            GameState.Reset();
            if (CurrentForm != null && !CurrentForm.IsDisposed)
            {
                CurrentForm.Close();
                CurrentForm.Dispose();
            }
            ShowForm<Form1>();
        }

        public static void EndGame()
        {
            string ending = GameState.GetFinalEnding();
            if (CurrentForm != null && !CurrentForm.IsDisposed)
            {
                CurrentForm.Close();
                CurrentForm.Dispose();
            }
            switch (ending)
            {
                case "good": ShowForm<Form9_GE>(); break;
                case "neutral": ShowForm<Form10_NE>(); break;
                case "bad": ShowForm<Form11_BE>(); break;
                case "secret": ShowForm<Form12_SE>(); break;
                default: ShowForm<Form1>(); break;
            }
        }

        public static void SaveGame()
        {
            try
            {
                var data = new SaveData
                {
                    Strength = GameState.Strength,
                    Intelligence = GameState.Intelligence,
                    Charisma = GameState.Charisma,
                    Sanity = GameState.Sanity,
                    Courage = GameState.Courage,
                    GoodEnding = GameState.GoodEnding,
                    NeutralEnding = GameState.NeutralEnding,
                    BadEnding = GameState.BadEnding,
                    SecretEnding = GameState.SecretEnding,
                    HasRobot = GameState.HasRobot,
                    HasIPad = GameState.HasIPad,
                    Inventory = GameState.Inventory,
                    CurrentForm = CurrentForm?.GetType().Name ?? "Form1"
                };
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SavePath, json);
                MessageBox.Show("Игра сохранена!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LoadGame()
        {
            try
            {
                if (!File.Exists(SavePath))
                {
                    MessageBox.Show("Сохранение не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string json = File.ReadAllText(SavePath);
                var data = JsonSerializer.Deserialize<SaveData>(json);
                if (data != null)
                {
                    GameState.Strength = data.Strength;
                    GameState.Intelligence = data.Intelligence;
                    GameState.Charisma = data.Charisma;
                    GameState.Sanity = data.Sanity;
                    GameState.Courage = data.Courage;
                    GameState.GoodEnding = data.GoodEnding;
                    GameState.NeutralEnding = data.NeutralEnding;
                    GameState.BadEnding = data.BadEnding;
                    GameState.SecretEnding = data.SecretEnding;
                    GameState.HasRobot = data.HasRobot;
                    GameState.HasIPad = data.HasIPad;
                    GameState.Inventory = data.Inventory ?? new List<string>();

                    string formName = data.CurrentForm;
                    var formType = Type.GetType($"NovelWF.{formName}");
                    if (formType != null)
                    {
                        var form = (Form)Activator.CreateInstance(formType);
                        if (CurrentForm != null && !CurrentForm.IsDisposed)
                        {
                            CurrentForm.Close();
                            CurrentForm.Dispose();
                        }
                        ShowForm(form);
                    }
                    else
                    {
                        ExitToMain();
                    }
                    MessageBox.Show("Игра загружена!", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class SaveData
    {
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Sanity { get; set; }
        public int Courage { get; set; }
        public int GoodEnding { get; set; }
        public int NeutralEnding { get; set; }
        public int BadEnding { get; set; }
        public int SecretEnding { get; set; }
        public bool HasRobot { get; set; }
        public bool HasIPad { get; set; }
        public List<string> Inventory { get; set; }
        public string CurrentForm { get; set; }
    }
}