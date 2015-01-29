'#Language "WWB.NET"

Dim WithEvents anincident1 As Incident = TheIncident

Private Sub anincident1_Started() Handles anincident1.Started
    anincident1.FilledInBy = ScriptName()
    ' force a parsing error
    xyz = 1
End Sub
