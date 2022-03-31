using System.Drawing;

namespace ChuniCon.Entity
{
    internal class RGBPair
    {
        public byte Area { get; set; } = 0;
        public Color Color { get; set; } = Color.Black;
        public Color PressColor { get; set; } = Color.Black;
    }
}
