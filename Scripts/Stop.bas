'#Language "WWB.NET"

Dim WithEvents anincident1 As Incident = TheIncident

Private Sub anincident1_Started() Handles anincident1.Started
    Stop
    anincident1.FilledInBy = ScriptName()
    anincident1.LogMe()
End Sub
