﻿'#Language "WWB.NET"

Public Class IncidentAction
    Implements IIncidentAction

    Public Sub Started(ByVal incident As Incident) Implements IIncidentAction.Started
        ' force a runtime error
        Error 1
        incident.FilledInBy = ScriptName()
        incident.LogMe()
    End Sub
End Class
