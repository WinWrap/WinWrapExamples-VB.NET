﻿'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.IO
Imports Examples.Extensions

Public Class Form1

    Implements IHost

#Region "IHost"

    Private theincident_ As Incident

    Public ReadOnly Property TheIncident As Incident Implements IHost.TheIncident
        Get
            Return theincident_
        End Get
    End Property

    Public Sub Log(ByVal [text] As String) Implements IHost.Log
        TextBox1.AppendText([text])
    End Sub

#End Region

    Private module_ As WinWrap.Basic.Module

    Private Shared scripts_() As String = New String() {
        "Good.bas",
        "DOTNet.bas",
        "ParseError.bas",
        "RuntimeError.bas"}

    Private ReadOnly Property Script As String
        Get
            Return scripts_(ListBoxScripts.SelectedIndex)
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        theincident_ = New Incident()
        Dim script As String
        For Each script In scripts_
            ListBoxScripts.Items.Add(script)
        Next
        ListBoxScripts.SelectedIndex = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' selecting TabPage2 initializes the BasicIdeCtl
        TabControl1.SelectedTab = TabPage2
        TabControl1.SelectedTab = TabPage1

        BasicIdeCtl1.AddScriptableObjectModel(GetType(ScriptingLanguage))

        ' Initialize Language with this as the IHost
        ScriptingLanguage.SetHost(Me)
    End Sub

    ' Prepare for script execution
    Private Sub BasicIdeCtl1_LeaveDesignMode(sender As Object, e As WinWrap.Basic.Classic.DesignModeEventArgs) Handles BasicIdeCtl1.LeaveDesignMode
        If BasicIdeCtl1.LoadModule(ScriptPath("Globals.bas")) Then
            ' Load selected script (can access globals loaded above)
            module_ = BasicIdeCtl1.ModuleInstance(ScriptPath(Script), False)
        End If

        If module_ Is Nothing Then
            ' Can't leave design mode because LoadModule or ModuleInstance were unsuccessful
            e.Cancel = True
            BasicIdeCtl1.ExecuteMenuCommand(WinWrap.Basic.CommandConstants.ShowError)
            BasicIdeCtl1.UnloadModule(ScriptPath("Globals.bas"))
        End If
    End Sub

    ' Prepare for script editing
    Private Sub BasicIdeCtl1_EnterDesignMode(sender As Object, e As WinWrap.Basic.Classic.DesignModeEventArgs) Handles BasicIdeCtl1.EnterDesignMode
        If module_ IsNot Nothing Then
            module_.Dispose()
            module_ = Nothing
            BasicIdeCtl1.UnloadModule(ScriptPath("Globals.bas"))
        End If
    End Sub

    ' WinWrap Basic execution has encountered an unhandled run-time error
    ' show the IDE so the error message box is not displayed
    Private Sub BasicIdeCtl1_HandleError(sender As Object, e As EventArgs) Handles BasicIdeCtl1.HandleError
        TabControl1.SelectedTab = TabPage2
    End Sub

    ' WinWrap Basic execution has paused because a break point
    ' has been encountered or a stop instruction has been
    ' executed or an unhandled run-time error has occurred
    Private Sub BasicIdeCtl1_Pause_(sender As Object, e As EventArgs) Handles BasicIdeCtl1.Pause_
        TabControl1.SelectedTab = TabPage2
    End Sub

    ' default AttachToForm behavior shows the correct form, now select the IDE's tab
    Private Sub BasicIdeCtl1_ShowForm(sender As Object, e As EventArgs) Handles BasicIdeCtl1.ShowForm
        TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub TabControl1_Deselecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Deselecting
        If e.TabPageIndex = 1 Then
            BasicIdeCtl1.Run = False
        End If
    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles ButtonEdit.Click
        BasicIdeCtl1.DesignMode_ = True ' enter design mode
        BasicIdeCtl1.FileName = ScriptPath(Script)
        BasicIdeCtl1.ActiveSheet = BasicIdeCtl1.FindSheet(ScriptPath(Script))
        tabControl1.SelectedTab = tabPage2
    End Sub

    Private Sub ButtonRun_Click(sender As Object, e As EventArgs) Handles ButtonRun.Click
        BasicIdeCtl1.DesignMode_ = True ' enter design mode
        BasicIdeCtl1.DesignMode_ = False ' leave design mode
        ' Execute script code via an event
        ScriptingLanguage.TheIncident.Start("Form1")
    End Sub

    Private Function ScriptPath(script As String) As String
        Dim dir As String = "..\..\..\Scripts"
        Return String.Format("{0}\{1}", dir, script)
    End Function

End Class
