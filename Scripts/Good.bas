'#Language "WWB.NET"

' Subscribe events for object mangaged by host (TheIncident)
' http://www.winwrap.com/web/basic/language/?p=doc_withevents__def.htm
Dim WithEvents anincident1 As Incident = TheIncident

Private Sub anincident1_Started() Handles anincident1.Started
    anincident1.FilledInBy = ScriptName()
    anincident1.LogMe()
End Sub
