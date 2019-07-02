using System;
using System.IO;
using System.Windows.Forms;

namespace AUTOMATIZATION.Classes
{
    class ComandReceiver
    {
        public static void CreateFileWatcher(string path)
        {
            // Create a new FileSystemWatcher and set its properties.
            try
            {

                WinDLLsUsage.watcher.Path = path;
                /* Watch for changes in LastAccess and LastWrite times, and 
                   the renaming of files or directories. */
                WinDLLsUsage.watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                WinDLLsUsage.watcher.Filter = "*.txt";

                // Add event handlers.
                WinDLLsUsage.watcher.Changed += new FileSystemEventHandler(OnChanged);
                WinDLLsUsage.watcher.Created += new FileSystemEventHandler(OnChanged);
                WinDLLsUsage.watcher.Deleted += new FileSystemEventHandler(OnChanged);
                WinDLLsUsage.watcher.Renamed += new RenamedEventHandler(OnRenamed);

                // Begin watching.
                WinDLLsUsage.watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex){ _ = MessageBox.Show("Error! " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            //string comand = Leitura();
            string comand = "";
            System.Threading.Thread.Sleep(50);
            using (StreamReader reader = new StreamReader(@"D:\OneDrive\Google\COMMAND.txt"))
            {
                WinDLLsUsage.watcher.EnableRaisingEvents = false;
                comand += reader.ReadLine();

                #region Processing
                switch (comand)
                {
                    //Coloquei o Unmute também...
                    case "Unmute": { Midia.Unmute(); break; }
                    case "MONITORS_OFF": { PwrControl.TurnOff_Monitor(); break; }
                    case "MONITORS_ON": { PwrControl.TurnOn_Monitor(); break; }
                    case "PC_OFF": { PwrControl.TurnOff_PC(); break; }
                    case "Mute": { Midia.Mute(); break; }
                    case "VOL_UP": { Midia.RaiseVolume(); break; }
                    case "VOL_DOWN": { Midia.DownVolume(); break; }
                    case "VOL_UP_TIMES": { Midia.RaiseVolumeTimes(Convert.ToInt32(reader.ReadLine())); break; }
                    case "VOL_DOWN_TIMES": { Midia.DownVolumeTimes(Convert.ToInt32(reader.ReadLine())); break; }
                    case "YOUTUBE": { ChromeLauncher.Youtube(reader.ReadLine()); break; }
                    case "PCRESEARCH": { ChromeLauncher.Research(reader.ReadLine()); break; }
                    default: { MessageBox.Show("Comando não reconhecido =/"); break; }
                } 
                #endregion
                WinDLLsUsage.watcher.EnableRaisingEvents = true;
            }
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }



        private static void OnRenamed(object source, RenamedEventArgs e) => Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        
    }
}
