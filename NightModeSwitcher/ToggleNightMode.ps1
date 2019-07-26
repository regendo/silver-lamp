# Toggles Light/Dark mode on and off.
# Both app- and system-wide modes are set to the same value.

cd HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes
$key = (Get-Item .).OpenSubKey("Personalize", $true)
$oldValue = $key.GetValue("AppsUseLightTheme")
if ($oldValue -eq 1) {
	$newValue = 0
} else {
	$newValue = 1
}
$key.SetValue("AppsUseLightTheme", $newValue)
$key.SetValue("SystemUsesLightTheme", $newValue)
