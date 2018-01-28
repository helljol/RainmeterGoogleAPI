[Rainmeter]
Update=1000
AccurateText=1
MouseOverAction=[!ToggleMeterGroup ConfigButton][!UpdateMeterGroup Background][!Redraw]
MouseLeaveAction=[!ToggleMeterGroup ConfigButton][!UpdateMeterGroup Background][!Redraw]
Group=RainGoo | RainGooMail
; Custom Context Menu
ContextTitle=Google Account Settings
ContextAction=[!ActivateConfig "RainGoo\Config\" "Config.ini"]




[Metadata]
Name=Google Gmail
Description=Shows unread email in gmail inbox.
Instructions=?What?
Version=1.0.0
License=Creative Commons BY-NC-SA 3.0

[Variables]
@IncludeVariables=Variables.inc
@includeGlobalSettings=#@#Settings\GoogleAccount.inc


; MEASURES ====================================

[mGMail]
Measure=Plugin
Plugin=RainGoo.dll
Max=#GmailMaxEmail#
IncludePath=#CURRENTPATH#
GoogleClientId=#GoogleAccountID#
GoogleClientSecret=#GoogleAccountSecret#
GoogleAppName=#mGMail.GoogleAppName#
GoogleUserName=#GmailUserName#
RefreshMail=#RefreshMail#
OnChangeAction=[!Refresh]
@IncludeMeasures=Measures.inc



; STYLES ======================================

@IncludeStyle=Style.inc


; METERS ======================================

; ----- Gadget header -----

[BackgroundBorder]
Meter=Image
MeterStyle=StyleBackgroundBorder

[Background]
Meter=Image
MeterStyle=StyleBackground


[GmailImage]
Meter=Image
ImageName=#imgPath#gmail.png
ImageTint=#colorInfo#
ImageAlpha=#colorBgA#
X=#contentMargin#
Y=#contentMargin#
W=16
H=16
ToolTipIcon=Info
Antialias=1
DynamicVariables=1
Hidden=0

[GmailUsageLabelString]
Meter=String
MeterStyle=StyleString | StyleStringGadgetHeader
ToolTipText="Open Gmail"
X=4R
Y=8
W=260
Text="Gmail"
DynamicVariables=1
LeftMouseUpAction=!Execute [https://mail.google.com/mail/u/0/?shva=1#inbox]



;[GmailPlaceholder]
;Meter=String
;Y=15R

[GmailCount]
Meter=STRING
MeterStyle=CounterStyle
MeasureName=mGMail
Text="%1"
Group=ConfigButton
FontColor=#ColorGmail#

[ConfigButton]
Meter=Image
MeterStyle=StyleSettingsButton






; METERS ITEMS ============================

@IncludeMeters=Meters.inc

[BackgroundHeight]
Meter=Image
MeterStyle=StyleBackgroundHeight
