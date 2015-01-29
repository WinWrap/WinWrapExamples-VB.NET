'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.Text

<Scriptable> _
Public Class Incident
    <Scriptable>  Public Sub LogMe()
        Datetime = Date.Now
        ScriptingLanguage.Host.Log(ToString)
    End Sub

    Public Sub Start(ByVal action As IIncidentAction, ByVal firedby As String)
        Me.FiredBy = firedby
        action.Started(Me)
    End Sub

    <Scriptable>  Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.AppendLine(String.Format("Incident at {0:dddd, MMMM yyyy HH:mm:ss tt zzz}", Me.Datetime))
        sb.AppendLine(("  FiredBy: " & Me.FiredBy))
        sb.AppendLine(("  FilledInBy: " & Me.FilledInBy))
        If (Not Me.Data Is Nothing) Then
            sb.AppendLine(("  Data: " & Me.Data))
        End If
        Return sb.ToString
    End Function

    ' Properties
    <Scriptable> Property Data As String
    Private Property Datetime As DateTime
    <Scriptable> Property FilledInBy As String
    <Scriptable> Property FiredBy As String
End Class

