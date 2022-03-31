using System.Runtime.InteropServices;

namespace ChuniCon.Utils
{
    internal static class DD
    {
        [DllImport("DD32.dll", EntryPoint = "DD_btn")]
        public static extern int Btn(int btn);
        [DllImport("DD32.dll", EntryPoint = "DD_whl")]
        public static extern int Whl(int whl);
        [DllImport("DD32.dll", EntryPoint = "DD_key")]
        public static extern int Key(int ddcode, int flag);
        [DllImport("DD32.dll", EntryPoint = "DD_mov")]
        public static extern int Mov(int x, int y);
        [DllImport("DD32.dll", EntryPoint = "DD_movR")]
        public static extern int MovR(int dx, int dy);
        [DllImport("DD32.dll", EntryPoint = "DD_str")]
        public static extern int Str(string str);
        [DllImport("DD32.dll", EntryPoint = "DD_todc")]
        public static extern int Todc(int vkcode);
    }
}
