using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AUTOMATIZATION.Classes
{
    class PwrControl
    {
        public static void TurnOff_Monitor()
        {
            int WM_SYSCOMMAND = 0x0112;
            uint SC_MONITORPOWER = 0xF170;
            Form form = new Form();
            WinDLLsUsage.SendMessage(form.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)2);
            form.Dispose();
        }

        public static void TurnOn_Monitor()
        {
            int MouseeventfMove = 0x0001;
            WinDLLsUsage.mouse_event(MouseeventfMove, 0, 1, 0, UIntPtr.Zero);
        }

        public static void TurnOff_PC()
        {
            ProcessStartInfo psi = new ProcessStartInfo("shutdown", "/s /t 0"){CreateNoWindow = true,UseShellExecute = false};
            Process.Start(psi);
        }
    }
}
