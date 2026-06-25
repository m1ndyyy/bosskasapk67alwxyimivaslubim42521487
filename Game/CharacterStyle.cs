using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NovelWF.Game
{
    public static class CharacterStyle
    {
        public class Style
        {
            public Font Font { get; set; }
            public Color Color { get; set; }

            public Style(Font font, Color color)
            {
                Font = font;
                Color = color;
            }
        }

        private static Dictionary<string, Style> _styles = new Dictionary<string, Style>
        {
            { "Рассказчик", new Style(
                new Font("Georgia", 11, FontStyle.Italic),
                Color.Black
            )},
            { "Игрок", new Style(
                new Font("Segoe UI", 11, FontStyle.Bold),
                Color.Black
            )},
            { "Робо-Навальный", new Style(
                new Font("Courier New", 11, FontStyle.Bold),
                Color.Black
            )},
            { "Система", new Style(
                new Font("Consolas", 11, FontStyle.Bold),
                Color.Black
            )},
            { "Шрек", new Style(
                new Font("Comic Sans MS", 12, FontStyle.Bold),
                Color.Black
            )},
            { "Dream", new Style(
                new Font("Segoe UI", 11, FontStyle.Italic),
                Color.Black
            )},
        };

        public static void ApplyStyle(string speaker, Label label)
        {
            if (string.IsNullOrEmpty(speaker))
            {
                label.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                label.ForeColor = Color.Black;
                return;
            }

            if (_styles.ContainsKey(speaker))
            {
                var style = _styles[speaker];
                label.Font = style.Font;
                label.ForeColor = style.Color;
            }
            else
            {
                label.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                label.ForeColor = Color.Black;
            }
        }
    }
}