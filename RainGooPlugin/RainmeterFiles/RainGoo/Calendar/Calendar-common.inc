[Rainmeter]
Update=1000
AccurateText=1
MouseOverAction=[!ToggleMeterGroup ConfigButton][!UpdateMeterGroup Background][!Redraw]
MouseLeaveAction=[!ToggleMeterGroup ConfigButton][!UpdateMeterGroup Background][!Redraw]
Group=RainGoo | RainGooCalendar
; Custom Context Menu
ContextTitle=Google Account Settings
ContextAction=[!ActivateConfig "RainGoo\Config\" "Config.ini"]


[Metadata]
Name=Google Calendar
Description=Shows upcoming events in Google Calendar.
Instructions=?what?
Version=1.0.0
License=Creative Commons BY-NC-SA 3.0

[Variables]
@IncludeVariables=Variables.inc
@includeGlobalSettings=#@#Settings\GoogleAccount.inc


; MEASURES ====================================

[mGcal]
Measure=Plugin
Plugin=RainGoo.dll
Cal1=#Calendar1#
Cal2=#Calendar2#
Cal3=#Calendar3#
TodayDateFormat=#format.Time#
WeekDateFormat=#format.Week#
DateFormat=#format.Date#
Max=#CalendarMaxEvent#
Limit2Xdays=#CalendarLimit2XDays#
IncludePath=#CURRENTPATH#
GoogleClientId=#GoogleAccountID#
GoogleClientSecret=#GoogleAccountSecret#
GoogleAppName=#mGcal.GoogleAppName#
GoogleUserName=#GmailUserName#
RefreshCal=#RefreshCal#
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

[ConfigButton]
Meter=Image
MeterStyle=StyleSettingsButton

[GmailImage]
Meter=Image
ImageName=#imgPath#Calendar.png
ImageTint=#colorInfo#
ImageAlpha=#colorBgA#
X=#contentMargin#
Y=#contentMargin#
W=20
H=20
ToolTipIcon=Info
Antialias=1
DynamicVariables=1
Hidden=0


[CalendarLabelString]
Meter=String
MeterStyle=StyleString | StyleStringGadgetHeader
ToolTipText="Open Google Calendar"
X=4R
Y=10
W=250
Text="Google Calendars"
DynamicVariables=1
LeftMouseUpAction=!Execute [http://www.google.com/calendar]



[CalendarPlaceholder]
Meter=String
Y=8R







; METERS ITEMS ============================

@IncludeMeters=Meters.inc

[BackgroundHeight]
Meter=Image
MeterStyle=StyleBackgroundHeight
