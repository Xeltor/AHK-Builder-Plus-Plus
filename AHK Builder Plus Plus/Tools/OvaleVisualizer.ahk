#Persistent
#NoTrayIcon

OvaleMiddleX = %1%
OvaleMiddleY = %2%
PixelOneHorizontalOffset = %3%
PixelOneVerticalOffset = %4%
PixelTwoHorizontalOffset = %5%
PixelTwoVerticalOffset = %6%
OffSet = %7%

if (%0% < 6)
{
	Exit
}

RedrawLabel:
OvaleLeftX := OvaleMiddleX - OffSet
OvaleUpY := OvaleMiddleY - OffSet
PixelOneHorizontalPixel := OvaleMiddleX + PixelOneHorizontalOffset
PixelOneVerticalPixel := OvaleMiddleY + PixelOneVerticalOffset
PixelTwoHorizontalPixel := OvaleMiddleX + PixelTwoHorizontalOffset
PixelTwoVerticalPixel := OvaleMiddleY + PixelTwoVerticalOffset

Gui, LineRight:+ToolWindow +E0x20 -Caption +AlwaysOnTop
Gui, LineRight:Color, 0xcbc0ff
Gui, LineRight:Show, x%OvaleMiddleX% y%OvaleMiddleY% w%OffSet% h1

Gui, LineDown:+ToolWindow +E0x20 -Caption +AlwaysOnTop
Gui, LineDown:Color, 0xcbc0ff
Gui, LineDown:Show, x%OvaleMiddleX% y%OvaleMiddleY% w1 h%OffSet%

Gui, LineLeft:+ToolWindow +E0x20 -Caption +AlwaysOnTop
Gui, LineLeft:Color, 0xcbc0ff
Gui, LineLeft:Show, x%OvaleLeftX% y%OvaleMiddleY% w%OffSet% h1

Gui, LineUp:+ToolWindow +E0x20 -Caption +AlwaysOnTop
Gui, LineUp:Color, 0xcbc0ff
Gui, LineUp:Show, x%OvaleMiddleX% y%OvaleUpY% w1 h%OffSet%

Gui, PxlLocOne:+ToolWindow +E0x20 -Caption +AlwaysOnTop
Gui, PxlLocOne:Color, 0xcbc0ff
Gui, PxlLocOne:Show, x%PixelOneHorizontalPixel% y%PixelOneVerticalPixel% w1 h1

Gui, PxlLocTwo:+ToolWindow +E0x20 -Caption +AlwaysOnTop
Gui, PxlLocTwo:Color, 0xcbc0ff
Gui, PxlLocTwo:Show, x%PixelTwoHorizontalPixel% y%PixelTwoVerticalPixel% w1 h1
return

^LButton::
{
	MouseClick
	MouseGetPos, OvaleMiddleX, OvaleMiddleY

	FileAppend %OvaleMiddleX%:%OvaleMiddleY%:, *

	Goto, RedrawLabel
}
