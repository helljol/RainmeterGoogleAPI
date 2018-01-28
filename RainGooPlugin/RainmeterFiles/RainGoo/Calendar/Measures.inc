; ===================== MEASURES 1 =====================

[mGcal1_IsAllDayTDF]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=IsAllDay
Substitute="1":"'all day'","0":"HH:mm"

[mGcal1_IsAllDayWDF]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=IsAllDay
Substitute="1":"ddd 'all day'","0":"ddd HH:mm"

[mGcal1_Title]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal1_Start]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=Start
TodayDateFormat=[mGcal1_IsAllDayTDF]
WeekDateFormat=[mGcal1_IsAllDayWDF]
DynamicVariables=1

[mGcal1_Data@CalId]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal1_Calendar.Link]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal1_Link]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal1_HexaColor]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
OnChangeAction=[!Refresh]

[mGcal1_HexaColorCal]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
OnChangeAction=[!Refresh]

[mGcal1_StartTooltip]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=Start
DateFormat=ddd dd MMMMM HH:mm

[mGcal1_EndTooltip]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=End
DateFormat=ddd dd MMMMM HH:mm


; ===================== MEASURES 2 =====================

[mGcal2_IsAllDayTDF]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=IsAllDay
Substitute="1":"'all day'","0":"HH:mm"

[mGcal2_IsAllDayWDF]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=IsAllDay
Substitute="1":"ddd 'all day'","0":"ddd HH:mm"

[mGcal2_Title]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal2_Start]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=Start
TodayDateFormat=[mGcal2_IsAllDayTDF]
WeekDateFormat=[mGcal2_IsAllDayWDF]
DynamicVariables=1

[mGcal2_Data@CalId]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal2_Calendar.Link]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal2_Link]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal2_HexaColor]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
OnChangeAction=[!Refresh]

[mGcal2_HexaColorCal]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
OnChangeAction=[!Refresh]

[mGcal2_StartTooltip]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=Start
DateFormat=ddd dd MMMMM HH:mm

[mGcal2_EndTooltip]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=End
DateFormat=ddd dd MMMMM HH:mm


; ===================== MEASURES 3 =====================

[mGcal3_IsAllDayTDF]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=IsAllDay
Substitute="1":"'all day'","0":"HH:mm"

[mGcal3_IsAllDayWDF]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=IsAllDay
Substitute="1":"ddd 'all day'","0":"ddd HH:mm"

[mGcal3_Title]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal3_Start]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=Start
TodayDateFormat=[mGcal3_IsAllDayTDF]
WeekDateFormat=[mGcal3_IsAllDayWDF]
DynamicVariables=1

[mGcal3_Data@CalId]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal3_Calendar.Link]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal3_Link]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal

[mGcal3_HexaColor]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
OnChangeAction=[!Refresh]

[mGcal3_HexaColorCal]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
OnChangeAction=[!Refresh]

[mGcal3_StartTooltip]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=Start
DateFormat=ddd dd MMMMM HH:mm

[mGcal3_EndTooltip]
Measure=Plugin
Plugin=RainGoo.dll
ParentName=mGcal
Property=End
DateFormat=ddd dd MMMMM HH:mm


