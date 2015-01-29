'#Language "WWB.NET"

Imports System
Imports System.Text

Dim WithEvents anincident1 As Incident = TheIncident

Private Sub anincident1_Started() Handles anincident1.Started
    anincident1.FilledInBy = ScriptName()
    Dim sb As New StringBuilder
    sb.Append("Hello")
    Dim t As Type = sb.GetType
    ' force an unsafe parsing error
    Dim a As Object = t.Assembly
End Sub
