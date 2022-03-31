using System.Drawing;

namespace ChuniCon.Utils
{
    internal static class ColorExtensions
    {
        public static Color Reverse(this Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        public static string ToCommaString(this Color color)
        {
            return string.Format("{0},{1},{2}", color.R, color.G, color.B);
        }
    }
}
