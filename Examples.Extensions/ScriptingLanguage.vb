'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

' AddScriptableObjectModel(typeof(Extensions))
' adds this static class to the scripting language directly
<Scriptable> Public Module ScriptingLanguage
    '  accessible by all classes in this assembly
    Friend Property Host As IHost

    ' make TheIncident available to WinWrap Basic script
    <Scriptable> Public ReadOnly Property TheIncident As Incident
        Get
            Return Host.TheIncident
        End Get
    End Property

    Public Sub SetHost(ByVal host As IHost)
        ScriptingLanguage.Host = host
    End Sub
End Module
