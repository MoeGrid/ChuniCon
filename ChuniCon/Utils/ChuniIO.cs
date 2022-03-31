using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChuniCon.Utils
{
    internal class ChuniIO
    {

        // chuniio.dll

        // =====================================================================

        // void chuni_io_jvs_read_coin_counter(uint16_t *out)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_jvs_read_coin_counter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ChuniIoJvsReadCoinCounter(ref ushort output);

        // void chuni_io_jvs_set_coin_blocker(bool open)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_jvs_set_coin_blocker", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ChuniIoJvsReadCoinBlocker(bool open);

        // HRESULT chuni_io_jvs_init(void)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_jvs_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ChuniIoJvsInit();

        // void chuni_io_jvs_poll(uint8_t *opbtn, uint8_t *beams)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_jvs_poll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ChuniIoJvsPoll(ref byte opbtn, ref byte beams);

        // HRESULT chuni_io_slider_init(void)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_slider_init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ChuniIoSliderInit();

        // void chuni_io_slider_set_leds(const uint8_t *rgb)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_slider_set_leds", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ChuniIoSliderSetLeds([MarshalAs(UnmanagedType.LPArray, SizeConst = 93)] byte[] rgb);

        // void chuni_io_slider_start(chuni_io_slider_callback_t callback)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_slider_start", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ChuniIoSliderStart(ChuniIoSliderCallback callback);

        // void chuni_io_slider_stop(void)
        [DllImport("chuniio.dll", EntryPoint = "chuni_io_slider_stop", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ChuniIoSliderStop();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ChuniIoSliderCallback([MarshalAs(UnmanagedType.LPArray, SizeConst = 32)] byte[] buffer);
    }
}
