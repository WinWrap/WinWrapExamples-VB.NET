'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

' used by application, not used by WWB.NET scripts
Public Interface IHost
    ReadOnly Property TheIncident As Incident
    Sub Log(ByVal [text] As String)
End Interface
