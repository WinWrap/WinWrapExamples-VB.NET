'#Language "WWB.NET"

Public Class IncidentAction
    Implements IIncidentAction

    Public Sub Started(ByVal incident As Incident) Implements IIncidentAction.Started
        Stop
        incident.FilledInBy = ScriptName()
        incident.LogMe()
    End Sub
End Class
