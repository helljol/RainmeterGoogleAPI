; MODERNGADGETS STYLESHEET

[Variables]
; General positioning and background
bgOffset=6
bgWidth=160
bgWidthAbs=(#bgWidth# + (#bgOffset# * 2))
mgVersion=1.2.2

contentMarginAbs=3
contentMargin=(#bgOffset# + #contentMarginAbs#)
contentMarginCenter=((#bgWidth# / 2) + #bgOffset#)
contentMarginRight=((#bgWidth# + #bgOffset#) - #contentMarginAbs# - 1)
contentWidth=(#bgWidth# - (#contentMarginAbs# * 2))

rowSpacing=1
barTextOffset=1
barHeight=1
graphHeight=41

labelOffset=53

; Font options
fontFace=Roboto
fontSize=8

; Colors
colorBg=0,0,0,255
colorBgA=255
colorBgBorder=#colorDim#
colorBgBorderA=#colorBgA#

colorGraphBorder=#colorDim#
colorGraphBorderA=#colorBgA#

colorMain=255,255,255,#colorBgA#
colorMainA=#colorBgA#
colorInfo=150,150,150,#colorBgA#
colorInfoA=#colorBgA#
colorDim=50,50,50,#colorBgA#
colorDimA=#colorBgA#

colorBarBg=#colorDim#

colorAccent=138,210,250,220
colorAccentRgb=138,210,250

colorButtonPress=255,50,50

colorHwinfoValueInputText=225,220,225,255
colorHwinfoValueInputBg=30,30,30,255
colorHwinfoError=255,30,30,255

colorInputBoxBorder=#colorDim#

colorIntel=0,125,198

histogramAlpha=50

; Paths
imgPath=#@#Assets\Images\
soundPath=#@#Assets\Sounds\
fontPath=#@#Fonts\
scriptPath=#@#Scripts\

rainRgbPath=#@#Addons\RainRGB\RainRGB4.exe

globalSettingsPath=#@#Settings\GlobalSettings.inc

styleSheetPath=#@#Settings\StyleSheet.inc


; Styles
[StyleBackground]
SolidColor=0,0,0,150
X=#bgOffset#
Y=#bgOffset#
W=#bgWidth#
H=([BackgroundHeight:Y] - (#bgOffset# * 2))
DynamicVariables=1
Group=Background


[StyleBackgroundBorder]
ImageName=#imgPath#border.png
ImageTint=#colorBgBorder#
ImageAlpha=#colorBgBorderA#
ScaleMargins=2,2,2,2
X=(#bgOffset# - 1)
Y=(#bgOffset# - 1)
W=(#bgWidth# + 2)
H=([BackgroundHeight:Y] - (#bgOffset# * 2) + 2)
DynamicVariables=1
Hidden=0
Group=Background

[StyleBackgroundHeight]
SolidColor=255,255,255,0
X=0
Y=(#contentMarginAbs# + #bgOffset#)R
W=#bgWidthAbs#
H=1
Group=Background

[StyleString]
FontColor=#colorMain#
FontSize=#fontSize#
FontFace=#fontFace#
X=#contentMargin#
Y=#rowSpacing#R
Antialias=1

[StyleStringArrowButtonLabel]
FontSize=10
X=50
Y=0R
Padding=0,-18,0,0
StringAlign=Left


[StyleStringArrowButton]
ImageName=#imgPath#arrow-right.png
ImageTint=#colorAccent#
X=170
Y=-18R
Padding=0,0,0,0
W=17
H=17
Antialias=0

[StyleToggleImageGadgets]
X=110
DynamicVariables=1

[StyleStringSectionHeader]
FontSize=12
Y=10R

[StyleStringGadgetHeader]
FontSize=10
X=#contentMargin#
Y=(#contentMargin# - 2)

[StyleStringCenterAlign]
StringAlign=Center
X=#contentMarginCenter#

[StyleStringRightAlign]
StringAlign=Right
X=#contentMarginRight#
Y=r

[StyleStringInfo]
StringAlign=Center
X=#contentMarginCenter#
Y=r
FontColor=#colorInfo#

[StyleStringToggleLabel]
FontSize=10
X=(#contentMargin# + 1)
Y=4R

[StyleStringGadgetToggleLabel]
X=(#contentMargin# + 3)

[StyleToggleImage]
X=(#contentMarginRight# - 31)
; X=5R
Y=-1r
W=31
H=20
Group=ToggleButtons

[StyleStringConfigSectionHeader]
FontFace=#fontFace# Cn
FontColor=#colorInfo#
FontSize=10
Y=5R

[StyleStringInputBox]
FontColor=#colorInfo#
FontFace=Roboto
; SolidColor=100,100,100,250
X=5r
Y=2r
W=200
H=13
Padding=0,2,0,0

[StyleStringParagraph]
FontColor=#colorMain#
FontSize=10
X=(#contentMargin# + 2)
Y=5R
W=(#contentWidth# - 6)
ClipString=2

[StyleStringConfigTitle]
FontSize=12
FontColor=EBAA00
X=#contentMargin#
Y=(#contentMargin# - 2)

[StyleBar]
SolidColor=#colorBarBg#
X=(#contentMargin#)
Y=#barTextOffset#R
W=(#contentWidth#)
w=(#contentWidth#)
h=#barHeight#
BarOrientation=Horizontal
DynamicVariables=1

[StyleCloseButton]
ImageName=#imgPath#close.png
ImageAlpha=#colorBgA#
X=(#contentMarginRight# - 18)
Y=(#contentMargin# - 5)
W=24
H=24
Antialias=0
ToolTipText="Close"
; MouseOverAction=[!SetOption CloseButton ImageTint "#colorButtonPress#"][!UpdateMeter CloseButton][!Redraw]
LeftMouseUpAction=[!DeactivateConfig]

[StyleSettingsButton]
ImageName=#imgPath#Wrench.png
ImageAlpha=#colorBgA#
X=(#contentMarginRight# - 10)
Y=(#contentMargin# + 2)
W=9
H=9
Antialias=1
Hidden=1
Group=ConfigButton
MouseOverAction=[!SetOption ConfigButton ImageTint "#colorButtonPress#"][!UpdateMeter ConfigButton][!Redraw]
MouseLeaveAction=[!SetOption ConfigButton ImageTint ""][!UpdateMeter ConfigButton][!Redraw]
LeftMouseUpAction=[!SkinCustomMenu]

[StyleHelpButton]
ImageName=#imgPath#help.png
W=14
H=14
Antialias=0

[StyleStringColorPickerLabel]
StringAlign=Right
FontSize=10
X=-5r
Y=5R

[StyleColorPicker]
Shape=Rectangle 0,0,25,17,3 | Stroke Color 100,100,100,100 | StrokeWidth 1 | Extend MeterSpecific
X=5r
Y=r
DynamicVariables=1
