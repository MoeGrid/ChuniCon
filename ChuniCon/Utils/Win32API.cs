using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChuniCon.Utils
{
    internal class Win32API
    {
        /// <summary>
        /// 模拟按键
        /// </summary>
        /// <param name="bVk">虚拟键值</param>
        /// <param name="bScan">一般为0</param>
        /// <param name="dwFlags">0为按下2为释放</param>
        /// <param name="dwExtraInfo">一般为0</param>
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void KeybdEvent(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
    }
}
