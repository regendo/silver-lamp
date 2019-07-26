using Microsoft.Win32;

namespace NightModeSwitcher
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
            bool wasLightTheme = key.GetValue("AppsUseLightTheme").ToString() == "1";
            int newValue = wasLightTheme ? 0 : 1;
            key.SetValue("AppsUseLightTheme", newValue);
            key.SetValue("SystemUsesLightTheme", newValue);
        }
    }
}
