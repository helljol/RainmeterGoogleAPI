; ===================== METERS 1 =====================

;[Item1Bloc]
;Meter=Image
;MeasureName=mGcal1_Data@CalId
;ImageName=cal%1.png
;MeterStyle=sColorBloc
;LeftMouseUpAction=!Execute ["[mGcal1_Calendar.Link]"]
;MouseActionCursor=1

[Item1Left]
Meter=String
MeterStyle=ContentStyle
MeasureName=mGcal1_Title
LeftMouseUpAction=!Execute ["[mGcal1_Link]"]
MouseActionCursor=1
SolidColor=[mGcal1_HexaColor]85

[Item1Right]
Meter=String
MeterStyle=DateStyle
MeasureName=mGcal1_Start
MeasureName2=mGcal1_StartTooltip
MeasureName3=mGcal1_EndTooltip
ToolTipText=%2#CRLF#%3
SolidColor=[mGcal1_HexaColor]85
SolidColor2=[mGcal1_HexaColorCal]85

[Item1Bar]
Meter=Image
MeterStyle=LineStyle
; ===================== METERS 2 =====================

;[Item2Bloc]
;Meter=Image
;MeasureName=mGcal2_Data@CalId
;ImageName=cal%1.png
;MeterStyle=sColorBloc
;LeftMouseUpAction=!Execute ["[mGcal2_Calendar.Link]"]
;MouseActionCursor=1

[Item2Left]
Meter=String
MeterStyle=ContentStyle
MeasureName=mGcal2_Title
LeftMouseUpAction=!Execute ["[mGcal2_Link]"]
MouseActionCursor=1
SolidColor=[mGcal2_HexaColor]85

[Item2Right]
Meter=String
MeterStyle=DateStyle
MeasureName=mGcal2_Start
MeasureName2=mGcal2_StartTooltip
MeasureName3=mGcal2_EndTooltip
ToolTipText=%2#CRLF#%3
SolidColor=[mGcal2_HexaColor]85
SolidColor2=[mGcal2_HexaColorCal]85

[Item2Bar]
Meter=Image
MeterStyle=LineStyle
; ===================== METERS 3 =====================

;[Item3Bloc]
;Meter=Image
;MeasureName=mGcal3_Data@CalId
;ImageName=cal%1.png
;MeterStyle=sColorBloc
;LeftMouseUpAction=!Execute ["[mGcal3_Calendar.Link]"]
;MouseActionCursor=1

[Item3Left]
Meter=String
MeterStyle=ContentStyle
MeasureName=mGcal3_Title
LeftMouseUpAction=!Execute ["[mGcal3_Link]"]
MouseActionCursor=1
SolidColor=[mGcal3_HexaColor]85

[Item3Right]
Meter=String
MeterStyle=DateStyle
MeasureName=mGcal3_Start
MeasureName2=mGcal3_StartTooltip
MeasureName3=mGcal3_EndTooltip
ToolTipText=%2#CRLF#%3
SolidColor=[mGcal3_HexaColor]85
SolidColor2=[mGcal3_HexaColorCal]85

[Item3Bar]
Meter=Image
MeterStyle=LineStyle
