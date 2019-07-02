using System;
using System.Windows.Forms;

namespace AUTOMATIZATION.Classes
{
    class Midia
    {
        public static void Mute()
        {
            int WM_APPCOMMAND = 0x319;
            int APPCOMMAND_VOLUME_MUTE = 0x80000;
            Form form = new Form();
            WinDLLsUsage.SendMessageW(form.Handle, WM_APPCOMMAND, form.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
            form.Dispose();
        }

        //Coloquei o Unmute Aqui ó

        public static void Unmute()
        {
            int WM_APPCOMMAND = 0x319;
            int APPCOMMAND_VOLUME_UNMUTE = 0x80000;
            Form form = new Form();
            WinDLLsUsage.SendMessageW(form.Handle, WM_APPCOMMAND, form.Handle, (IntPtr)APPCOMMAND_VOLUME_UNMUTE);
            form.Dispose();
        }


        public static void RaiseVolume()
        {
            int WM_APPCOMMAND = 0x319;
            int APPCOMMAND_VOLUME_UP = 0xA0000;
            Form form = new Form();
            WinDLLsUsage.SendMessageW(form.Handle, WM_APPCOMMAND, form.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            form.Dispose();
        }

        public static void DownVolume()
        {
            int WM_APPCOMMAND = 0x319;
            int APPCOMMAND_VOLUME_DOWN = 0x90000;
            Form form = new Form();
            WinDLLsUsage.SendMessageW(form.Handle, WM_APPCOMMAND, form.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
            form.Dispose();
        }

        public static void RaiseVolumeTimes(int i = 0)
        {
            for (int a = i; a > 0; a--)
            {
                RaiseVolume();
            }
        }
        public static void DownVolumeTimes(int i = 0)
        {
            for (int a = i; a > 0; a--)
            {
                DownVolume();
            }
        }
    }
}
