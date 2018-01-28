; ===================== METERS {0} =====================
[Item{0}Sender]
Group=Mail{0} | MailAll
Meter=STRING
MeterStyle=AuthorStyle
MeasureName=mGMail{0}_Sender

[Item{0}TimeDate]
Group=Mail{0} | MailAll
Meter=STRING
MeasureName=mGMail{0}_EmailDate
MeterStyle=DateStyle


[Item{0}Email]
Meter=String
Group=Mail{0} | MailAll
MeterStyle=ContentStyle
MeasureName=mGMail{0}_Subject
MeasureName2=mGMail{0}_Snipet
text="%1 -#- %2"
InlineSetting=Weight | 500 
InlinePattern=^(.*) -#-
InlineSetting3=Color | #ColorGmail#
InlinePattern3=^(.*) -#-
InlineSetting2=size | 4
InlinePattern2=-#-
LeftMouseUpAction=!Execute ["[mGMail{0}_Link]"]
MouseActionCursor=1
ToolTipText="%2"



[Item{0}Bar]
Meter=Image
Group=Mail{0} | MailAll
MeterStyle=LineStyle

