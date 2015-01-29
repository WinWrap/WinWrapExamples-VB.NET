'#Language "WWB.NET"

Imports System
Imports System.Collections.Generic

Dim WithEvents anincident1 As Incident = TheIncident

Private Sub anincident1_Started() Handles anincident1.Started
    anincident1.FilledInBy = ScriptName()
    Dim alist As List(Of Integer) = New List(Of Integer)
    Dim rand As Random = New Random()
    alist.Add(rand.Next(1, 100))
    anincident1.Data = String.Format("Random(1, 100) => {0}", alist.Item(0).ToString)
    anincident1.LogMe()
End Sub
