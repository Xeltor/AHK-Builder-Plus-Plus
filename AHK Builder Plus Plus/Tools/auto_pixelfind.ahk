SetTitleMatchMode, 2

if (%0% < 4)
{
	FileAppend 0x000000:0x000000, *
	Exit
}

IfWinNotExist, World of Warcraft
{
	FileAppend 0x000000:0x000000, *
	Exit
}

WinActivate, World of Warcraft
WinWaitActive, World of Warcraft

Sleep, 100
PixelGetColor, HBa, %1%, %2%, Slow
PixelGetColor, HBb, %3%, %4%, Slow

FileAppend %HBa%:%HBb%, *