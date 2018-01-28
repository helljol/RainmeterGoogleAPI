; ===================== METERS {0} =====================

;[Item{0}Bloc]
;Meter=Image
;MeasureName=mGcal{0}_Data@CalId
;ImageName=cal%1.png
;MeterStyle=sColorBloc
;LeftMouseUpAction=!Execute ["[mGcal{0}_Calendar.Link]"]
;MouseActionCursor=1

[Item{0}Left]
Meter=String
MeterStyle=ContentStyle
MeasureName=mGcal{0}_Title
LeftMouseUpAction=!Execute ["[mGcal{0}_Link]"]
MouseActionCursor=1
SolidColor=[mGcal{0}_HexaColor]85

[Item{0}Right]
Meter=String
MeterStyle=DateStyle
MeasureName=mGcal{0}_Start
MeasureName2=mGcal{0}_StartTooltip
MeasureName3=mGcal{0}_EndTooltip
ToolTipText=%2#CRLF#%3
SolidColor=[mGcal{0}_HexaColor]85
SolidColor2=[mGcal{0}_HexaColorCal]85

[Item{0}Bar]
Meter=Image
MeterStyle=LineStyle
