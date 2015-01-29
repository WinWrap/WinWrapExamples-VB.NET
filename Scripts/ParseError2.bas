'#Language "WWB.NET"

Public Class IncidentAction
    Implements IIncidentAction

    Public Sub Started(ByVal incident As Incident) Implements IIncidentAction.Started
        incident.FilledInBy = ScriptName()
        incident.LogMe()
        ' force a parsing error
        xyz = 1
    End Sub
End Class
