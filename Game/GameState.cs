using System.Collections.Generic;

namespace NovelWF.Game
{
    public static class GameState
    {
        public static int Strength { get; set; } = 0;
        public static int Intelligence { get; set; } = 0;
        public static int Charisma { get; set; } = 0;
        public static int Sanity { get; set; } = 0;
        public static int Courage { get; set; } = 0;

        public static int GoodEnding { get; set; } = 0;
        public static int NeutralEnding { get; set; } = 0;
        public static int BadEnding { get; set; } = 0;
        public static int SecretEnding { get; set; } = 0;

        public static bool HasRobot { get; set; } = false;
        public static bool HasIPad { get; set; } = false;
        public static bool MiniGameSuccess { get; set; } = false;

        public static List<string> Inventory { get; set; } = new List<string>();
        public static List<HistoryEntry> History { get; set; } = new List<HistoryEntry>();

        public static void AddStrength(int v) => Strength += v;
        public static void AddIntelligence(int v) => Intelligence += v;
        public static void AddCharisma(int v) => Charisma += v;
        public static void AddSanity(int v) => Sanity += v;
        public static void AddCourage(int v) => Courage += v;

        public static void AddGood(int v) => GoodEnding += v;
        public static void AddNeutral(int v) => NeutralEnding += v;
        public static void AddBad(int v) => BadEnding += v;
        public static void AddSecret(int v) => SecretEnding += v;

        public static void AddHistory(string speaker, string text)
        {
            History.Add(new HistoryEntry { Speaker = speaker, Text = text });
        }

        public static void Reset()
        {
            Strength = 0;
            Intelligence = 0;
            Charisma = 0;
            Sanity = 0;
            Courage = 0;
            GoodEnding = 0;
            NeutralEnding = 0;
            BadEnding = 0;
            SecretEnding = 0;
            HasRobot = false;
            HasIPad = false;
            MiniGameSuccess = false;
            Inventory.Clear();
            History.Clear();
        }

        public static string GetFinalEnding()
        {
            if (SecretEnding >= 3) return "secret";
            if (GoodEnding >= NeutralEnding && GoodEnding >= BadEnding) return "good";
            if (NeutralEnding >= BadEnding) return "neutral";
            return "bad";
        }
    }

    public class HistoryEntry
    {
        public string Speaker { get; set; }
        public string Text { get; set; }
    }
}