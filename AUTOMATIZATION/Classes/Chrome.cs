using Microsoft.Win32;
using System;
using System.Diagnostics;


namespace AUTOMATIZATION.Classes
{
    class ChromeLauncher
    {
        private const string ChromeAppKey = @"\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";

        private static string ChromeAppFileName
        {
            get
            {
                return (string)(Registry.GetValue("HKEY_LOCAL_MACHINE" + ChromeAppKey, "", null) ??
                                    Registry.GetValue("HKEY_CURRENT_USER" + ChromeAppKey, "", null));
            }
        }

        public void OpenLink(string url)
        {
            string chromeAppFileName = ChromeAppFileName;
            if (string.IsNullOrEmpty(chromeAppFileName))
            {
                throw new Exception("Could not find chrome.exe!");
            }
            Process.Start(chromeAppFileName, url);
        }

        public static void Youtube(string text)
        {

            ChromeLauncher chrome = new ChromeLauncher();
            string url = "https://www.youtube.com/results?search_query=" + text.Replace(" ", "+");
            chrome.OpenLink(url);

        }
        public static void Research(string text )
        {
          ChromeLauncher chrome = new ChromeLauncher();
            string url = "" + text.Replace(" ", "+");
            chrome.OpenLink(url);
       }
    }
}
