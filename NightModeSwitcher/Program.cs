using Microsoft.Win32;
using System;

namespace NightModeSwitcher {
	class Program {
		static void Main(string[] args) {
			const string usageMsg = "Usage: NightModeSwitcher.exe [on|off]";
			RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);
			int newValue;

			switch (args.Length) {
				case 0:
					bool wasLightTheme = key.GetValue("AppsUseLightTheme").ToString() == "1";
					newValue = wasLightTheme ? 0 : 1;
					break;
				case 1:
					switch (args[0]) {
						case "on":
							newValue = 1;
							break;
						case "off":
							newValue = 0;
							break;
						default:
							Console.Error.WriteLine(usageMsg);
							return;
					}
					break;
				default:
					Console.Error.WriteLine(usageMsg);
					return;
			}
			key.SetValue("AppsUseLightTheme", newValue);
			key.SetValue("SystemUsesLightTheme", newValue);
		}
	}
}
