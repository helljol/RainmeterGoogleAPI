; ===================== METERS 1 =====================
[Item1Sender]
Group=Mail1 | MailAll
Meter=STRING
MeterStyle=AuthorStyle
MeasureName=mGMail1_Sender

[Item1TimeDate]
Group=Mail1 | MailAll
Meter=STRING
MeasureName=mGMail1_EmailDate
MeterStyle=DateStyle


[Item1Email]
Meter=String
Group=Mail1 | MailAll
MeterStyle=ContentStyle
MeasureName=mGMail1_Subject
MeasureName2=mGMail1_Snipet
text="%1 -#- %2"
InlineSetting=Weight | 500 
InlinePattern=^(.*) -#-
InlineSetting3=Color | #ColorGmail#
InlinePattern3=^(.*) -#-
InlineSetting2=size | 4
InlinePattern2=-#-
LeftMouseUpAction=!Execute ["[mGMail1_Link]"]
MouseActionCursor=1
ToolTipText="%2"



[Item1Bar]
Meter=Image
Group=Mail1 | MailAll
MeterStyle=LineStyle

; ===================== METERS 2 =====================
[Item2Sender]
Group=Mail2 | MailAll
Meter=STRING
MeterStyle=AuthorStyle
MeasureName=mGMail2_Sender

[Item2TimeDate]
Group=Mail2 | MailAll
Meter=STRING
MeasureName=mGMail2_EmailDate
MeterStyle=DateStyle


[Item2Email]
Meter=String
Group=Mail2 | MailAll
MeterStyle=ContentStyle
MeasureName=mGMail2_Subject
MeasureName2=mGMail2_Snipet
text="%1 -#- %2"
InlineSetting=Weight | 500 
InlinePattern=^(.*) -#-
InlineSetting3=Color | #ColorGmail#
InlinePattern3=^(.*) -#-
InlineSetting2=size | 4
InlinePattern2=-#-
LeftMouseUpAction=!Execute ["[mGMail2_Link]"]
MouseActionCursor=1
ToolTipText="%2"



[Item2Bar]
Meter=Image
Group=Mail2 | MailAll
MeterStyle=LineStyle

