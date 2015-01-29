VERSION 1.0 CLASS
BEGIN
  MultiUse = -1 'True
END
Attribute VB_PredeclaredId = False
Attribute VB_Creatable = True
Attribute VB_Exposed = False
Attribute VB_GlobalNameSpace = False
Attribute VB_Name = "LogIncident"
Attribute VB_Name = "IncidentAction"
Attribute Context = "IncidentAction.ctx"
'#Language "WWB.NET"

Implements IIncidentAction

Public Sub Started(ByVal incident As Incident) Implements IIncidentAction.Started
    ' force a runtime error
    Error 1
    incident.FilledInBy = ScriptName()
    incident.LogMe()
End Sub
