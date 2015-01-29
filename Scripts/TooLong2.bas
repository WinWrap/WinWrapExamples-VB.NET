'#Language "WWB.NET"

Public Class IncidentAction
    Implements IIncidentAction

    Public Sub Started(ByVal incident As Incident) Implements IIncidentAction.Started
        Wait 10
        incident.FilledInBy = ScriptName()
        incident.LogMe()
    End Sub
End Class
