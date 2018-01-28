[Variables]
font.Name=Roboto
;font.Size=7
font.Style=SHADOW
skin.ToolTipHidden=0
skin.Width=310
;skin.Height=((#h.Item# * #mGcal.Max#) + 10)
h.Item=14
;color.Skin=00000033
;color.Title=FFFFFFFF
;color.Text=FFFFFFFF
;color.Seperator=FFFFFF33

h.Other=(#h.Item#-7)
w.TextR=90
w.TextL=(#skin.Width#-#w.TextR#)
w.ToolTip=(#skin.Width# + 100)

;ICI
; General positioning and background
bgOffset=6
bgWidth=312
bgWidthAbs=(#bgWidth# + (#bgOffset# * 2))

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
fontPath=#@#Fonts\
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
;Hidden=(#showBgBorder# = 1) ? 0 : 1
Group=Background

[StyleBackgroundHeight]
SolidColor=255,255,255,0
X=0
Y=(#contentMarginAbs# + #bgOffset#)R
W=#bgWidthAbs#
H=1



[StyleString]
FontColor=#colorMain#
FontSize=#fontSize#
FontFace=#fontFace#
X=#contentMargin#
Y=#rowSpacing#R
Antialias=1

[StyleStringArrowButtonLabel]
FontSize=10
StringAlign=Right
X=(#contentMarginRight# - 17)

[StyleStringArrowButton]
ImageName=#imgPath#arrow-right.png
ImageTint=#colorAccent#
X=r
Y=r
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
Y=10
Padding=0,0,0,0
W=9
H=9
Antialias=1
Hidden=1
Group=ConfigButton
MouseOverAction=[!SetOption ConfigButton ImageTint "#colorButtonPress#"][!UpdateMeter ConfigButton][!Redraw]
MouseLeaveAction=[!SetOption ConfigButton ImageTint ""][!UpdateMeter ConfigButton][!Redraw]
LeftMouseUpAction=[!ActivateConfig "RainGoo\Config\" "Config.ini"]

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
;LA

[AuthorStyle]
FontFace=Roboto-Bold
FontColor=eaeaea99
FontSize=10
StringStyle=BOLD
X=12
Y=3R
w=298
h=25
ClipString=1
AntiAlias=1
Hidden=0

[ContentStyle]
FontFace=Roboto
FontSize=8
;StringStyle=BOLD
FontColor=255,255,255,255
;StringEffect=SHADOW
;FontEffectColor=0,0,0,20
StringAlign=LEFT
X=14
Y=1r
w=200
h=16
Padding=10,2,0,0
ClipString=1
AntiAlias=1
Hidden=0

[DateStyle]
SolidColor=0,0,0,1
FontFace=Roboto
FontColor=eaeaea99
Padding=25,2,0,0
w=62
FontSize=8
h=16
;Padding=0,2,0,0
X=224

Y=0r
AntiAlias=1
Hidden=0

[ButtonStyle]
;ImageName=Button.png
;Path=#@#Images\
X=2
Y=r
w=305
h=45
MouseLeaveAction=[!HideMeter #CURRENTSECTION#][!Redraw]
DynamicVariables=1
Hidden=0

[LineStyle]
SolidColor=255,255,255,15
X=12
Y=0R
W=308
H=1
Hidden=0


;---------------------

