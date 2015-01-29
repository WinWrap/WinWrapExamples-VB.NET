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
        "Good2.bas",
        "ParseError2.bas",
        "RuntimeError2.bas",
        "Stop2.bas",
        "TooLong2.bas"}

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
            ' Extend WinWrap Basic scripts with Examples.Extensions assembly
            ' Add "Imports Examples.Extensions" to all WinWrap Basic scripts
            ' Add "Imports Examples.Extensions.ScriptingLanguage" all WinWrap Basic scripts
            basicNoUIObj_.AddScriptableObjectModel(GetType(ScriptingLanguage))

            If Not basicNoUIObj_.LoadModule(ScriptPath("Globals.bas")) Then
                LogError(basicNoUIObj_.Error)
            Else
                Using [module] As WinWrap.Basic.Module = basicNoUIObj_.ModuleInstance(ScriptPath(Script), False)
                    If [module] Is Nothing Then
                        ' script parsing error
                        LogError(basicNoUIObj_.Error)
                    Else
                        Try
                            Using instance As WinWrap.Basic.Instance = basicNoUIObj_.CreateInstance(ScriptPath(Script) & "<IncidentAction")
                                ' Execute script code via an interface
                                Dim action As IIncidentAction = instance.Cast(Of IIncidentAction)()
                                TheIncident.Start(action, Text)
                            End Using
                        Catch exception1 As WinWrap.Basic.TerminatedException
                            ' script execution terminated, ignore error
                        Catch ex As Exception
                            ' script caused an exception
                            basicNoUIObj_.ReportError(ex)
                        End Try
                    End If
                End Using
            End If
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
