# AccentPaletteTool
Handy tool to change the AccentPalette and relevant values in Windows 10.

Previously known as APTool_10586.

Screenshot: http://imgur.com/a/3O7wb

For build 14393 (ver 1607), please use ver 1.1.

For build 10586 (ver 1511), please use ver 1.0.

--- About AccentPalette ---

The registry value is located at:
HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent

The 'AccentPalette' value decides the color of many elements.
The elements I've discovered are:
* Floating
* FloatingModern
* FloatingModernSpecial
* StartOrbHover
* Taskbar
* TaskbarTile
* Tile

Please note that the names aren't from Microsoft; they're just codename I made to make my life easier.

--- Build 14393 specific ---

'AccentColorMenu' will override the DWM\AccentColor (title bar color) when Explorer is restarted.

--- Build 10586 specific ---

For FloatingModern, you must change the value of 'AccentColorMenu' to any other value (non-zero value) so the Explorer will read the new value upon restart.
