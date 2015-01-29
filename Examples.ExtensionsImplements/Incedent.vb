'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.Text

<Scriptable> Public Class Incident
    Private Property Datetime As Date

    <Scriptable> Property FiredBy As String
    <Scriptable> Property FilledInBy As String
    <Scriptable> Property Data As String

    <Scriptable> Public Sub LogMe()
        Datetime = Date.Now
        ScriptingLanguage.Host.Log(ToString)
    End Sub

    '  no [Scriptable] attribute
    Public Sub Start(ByVal action As IIncidentAction, ByVal firedby As String)
        Me.FiredBy = firedby
        action.Started(Me)
    End Sub

    <Scriptable> Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.AppendLine(String.Format("Incident at {0:dddd, MMMM yyyy HH:mm:ss tt zzz}", Datetime))
        sb.AppendLine("  FiredBy: " & FiredBy)
        sb.AppendLine("  FilledInBy: " & FilledInBy)
        If Not Data Is Nothing Then
            sb.AppendLine("  Data: " & Data)
        End If
        Return sb.ToString
    End Function
End Class

