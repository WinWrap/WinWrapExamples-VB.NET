Public Interface IHost
    ' Methods
    Sub Log(ByVal [text] As String)

    ' Properties
    ReadOnly Property TheIncident As Incident
End Interface
