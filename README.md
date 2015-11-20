# APTool_10586
Handy tool to change the AccentPalette in Win10 Build 10586

The registry value is located at:
HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent

The 'AccentPalette' value decides the color of many elements.
The elements I discovered are:
* Floating
* FloatingModern
* FloatingModernSpecial
* StartOrbHover
* Taskbar
* TaskbarTile
* Tile

Please note that the names aren't from Microsoft; they're just codename I made to make my life easier.

For FloatingModern, you must change the value of 'AccentColorMenu' to any other value (non-zero value) so the Explorer will read the new value upon restart.
