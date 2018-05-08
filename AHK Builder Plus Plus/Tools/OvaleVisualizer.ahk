#Persistent
#NoTrayIcon

OvaleMiddleX = %1%
OvaleMiddleY = %2%
PixelLocationOneX = %3%
PixelLocationOneY = %4%
PixelLocationTwoX = %5%
PixelLocationTwoY = %6%
OffSet = %7%
OvaleLeftX := OvaleMiddleX - OffSet
OvaleUpY := OvaleMiddleY - OffSet

if (%0% < 6)
{
	ExitApp
}

Gui, LineRight:+ToolWindow -Caption +AlwaysOnTop
Gui, LineRight:Color, red
Gui, LineRight:Show, x%OvaleMiddleX% y%OvaleMiddleY% w%OffSet% h1

Gui, LineDown:+ToolWindow -Caption +AlwaysOnTop
Gui, LineDown:Color, red
Gui, LineDown:Show, x%OvaleMiddleX% y%OvaleMiddleY% w1 h%OffSet%

Gui, LineLeft:+ToolWindow -Caption +AlwaysOnTop
Gui, LineLeft:Color, red
Gui, LineLeft:Show, x%OvaleLeftX% y%OvaleMiddleY% w%OffSet% h1

Gui, LineUp:+ToolWindow -Caption +AlwaysOnTop
Gui, LineUp:Color, red
Gui, LineUp:Show, x%OvaleMiddleX% y%OvaleUpY% w1 h%OffSet%

Gui, PxlLocOne:+ToolWindow -Caption +AlwaysOnTop
Gui, PxlLocOne:Color, 0xFF007F
Gui, PxlLocOne:Show, x%PixelLocationOneX% y%PixelLocationOneY% w1 h1

Gui, PxlLocTwo:+ToolWindow -Caption +AlwaysOnTop
Gui, PxlLocTwo:Color, 0xFF007F
Gui, PxlLocTwo:Show, x%PixelLocationTwoX% y%PixelLocationTwoY% w1 h1