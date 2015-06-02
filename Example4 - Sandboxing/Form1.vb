'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.IO
Imports Examples.Extensions

Partial Public Class Form1

    Private timedout_ As Boolean
    Private timelimit_ As Date
    Private Shared scripts_() As String = New String() {
        "Good.bas",
        "BlockedParseError.bas",
        "BlockedRuntimeError.bas"}

    Private WithEvents basicNoUIObj_ As WinWrap.Basic.BasicNoUIObj

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListBoxScripts_Initialize()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize Language with this as the IHost
        ScriptingLanguage.SetHost(Me)
    End Sub

    Private Sub buttonRunScript_Click(sender As Object, e As EventArgs) Handles ButtonRunScript.Click
        theincident_ = New Incident
        basicNoUIObj_ = New WinWrap.Basic.BasicNoUIObj
        Using basicNoUIObj_
            basicNoUIObj_.Secret = New Guid("00000000-0000-0000-0000-000000000000")
            basicNoUIObj_.Initialize()
            basicNoUIObj_.AddScriptableObjectModel(GetType(ScriptingLanguage))

            basicNoUIObj_.Sandboxed = True
            Try
                If Not basicNoUIObj_.LoadModule(ScriptPath("Globals.bas")) Then
                    Throw basicNoUIObj_.Error.Exception
                End If
                Using [module] As WinWrap.Basic.Module = basicNoUIObj_.ModuleInstance(ScriptPath(Script), False)
                    If [module] Is Nothing Then
                        Throw basicNoUIObj_.Error.Exception
                    End If
                    ' Execute script code via an event
                    ScriptingLanguage.TheIncident.Start(Me.Text)
                End Using
            Catch ex As Exception
                basicNoUIObj_.ReportError(ex)
            End Try
        End Using
        basicNoUIObj_ = Nothing
        theincident_ = Nothing
    End Sub

    Private Sub basicNoUIObj__Begin(sender As Object, e As EventArgs) Handles basicNoUIObj_.Begin
        timedout_ = False
        timelimit_ = (DateTime.Now + New TimeSpan(0, 0, 1))
    End Sub

    Private Sub basicNoUIObj__DoEvents(sender As Object, e As EventArgs) Handles basicNoUIObj_.DoEvents
        If (DateTime.Now >= timelimit_) Then
            timedout_ = True
            Dim basicNoUIObj As WinWrap.Basic.BasicNoUIObj = TryCast(sender, WinWrap.Basic.BasicNoUIObj)
            basicNoUIObj.Run = False
        End If
    End Sub

    Private Sub basicNoUIObj__ErrorAlert(sender As Object, e As EventArgs) Handles basicNoUIObj_.ErrorAlert
        Dim basicNoUIObj As WinWrap.Basic.BasicNoUIObj = TryCast(sender, WinWrap.Basic.BasicNoUIObj)
        LogError(basicNoUIObj.Error)
    End Sub

    Private Sub basicNoUIObj__Pause_(sender As Object, e As EventArgs) Handles basicNoUIObj_.Pause_
        Dim basicNoUIObj As WinWrap.Basic.BasicNoUIObj = TryCast(sender, WinWrap.Basic.BasicNoUIObj)
        If (basicNoUIObj.Error Is Nothing) Then
            LogError(WinWrapBasic.FormatTimeoutError(basicNoUIObj, timedout_))
        End If
        basicNoUIObj.Run = False
    End Sub

    Private Sub ListBoxScripts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxScripts.SelectedIndexChanged
        TextBoxScript.Text = File.ReadAllText(ScriptPath(Script))
    End Sub

End Class
