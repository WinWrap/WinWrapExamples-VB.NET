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

Public Class Form1

    Private WithEvents basicNoUIObj_ As WinWrap.Basic.BasicNoUIObj
    Private timedout_ As Boolean
    Private timelimit_ As Date
    Private Shared scripts_() As String = New String() {
        "Good2.bas",
        "ParseError2.bas",
        "RuntimeError2.bas",
        "Stop2.bas",
        "TooLong2.bas"}

    Private mts As New Dictionary(Of String, InstanceAndTimestamp)

    Structure InstanceAndTimestamp
        Public [module] As WinWrap.Basic.Module
        Public instance As WinWrap.Basic.Instance
        Public timestamp As Date

        Public Sub Dispose()
            If instance IsNot Nothing Then
                instance.Dispose()
                instance = Nothing
            End If
            If [module] IsNot Nothing Then
                [module].Dispose()
                [module] = Nothing
            End If
        End Sub
    End Structure

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListBoxScripts_Initialize()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize Language with this as the IHost
        ScriptingLanguage.SetHost(Me)
        basicNoUIObj_ = New WinWrap.Basic.BasicNoUIObj
        basicNoUIObj_.Secret = New Guid("00000000-0000-0000-0000-000000000000")
        basicNoUIObj_.Initialize()
        ' automatically disconnect BasicNoUIObj when form closes
        basicNoUIObj_.AttachToForm(Me, WinWrap.Basic.ManageConstants.All)
        ' Extend WinWrap Basic scripts with Examples.Extensions assembly
        ' Add "Imports Examples.Extensions" to all WinWrap Basic scripts
        ' Add "Imports Examples.Extensions.ScriptingLanguage" all WinWrap Basic scripts
        basicNoUIObj_.AddScriptableObjectModel(GetType(ScriptingLanguage))
        If Not basicNoUIObj_.LoadModule(ScriptPath("Globals.bas")) Then
            LogError(basicNoUIObj_.Error)
            ButtonRunScript.Enabled = False
        End If
    End Sub

    Private Sub buttonRunScript_Click(sender As Object, e As EventArgs) Handles ButtonRunScript.Click
        theincident_ = New Incident

        Dim mt As New InstanceAndTimestamp
        Dim path As String = ScriptPath(Script)
        Dim timestamp As Date = File.GetLastWriteTimeUtc(path)
        If mts.TryGetValue(path, mt) AndAlso mt.timestamp <> timestamp Then
            ' file has changed, dump instance from cache
            mt.Dispose()
            mts.Remove(path)
            mt = New InstanceAndTimestamp()
        End If

        Try
            If mt.module Is Nothing Then
                mt.module = basicNoUIObj_.ModuleInstance(ScriptPath(Script), False)
                If mt.module Is Nothing Then
                    ' script parsing error
                    LogError(basicNoUIObj_.Error)
                Else
                    ' create an instance
                    mt.instance = basicNoUIObj_.CreateInstance(path + "<IncidentAction")
                    ' cache the instance with a timestamp
                    mt.timestamp = File.GetLastWriteTimeUtc(path)
                    mts.Add(path, mt)
                End If
            End If

            If mt.instance IsNot Nothing Then
                ' Execute script code via an interface
                Dim tstart2 As Date = DateTime.Now
                Dim action As IIncidentAction = mt.instance.Cast(Of IIncidentAction)()
                ScriptingLanguage.TheIncident.Start(action, "Form1")
                Dim ts2 As TimeSpan = DateTime.Now - tstart2
                Debug.Print(ts2.ToString())
            End If
        Catch exception1 As WinWrap.Basic.TerminatedException
            ' script execution terminated, ignore error
        Catch ex As Exception
            ' script caused an exception
            basicNoUIObj_.ReportError(ex)
        End Try

        If mt.instance Is Nothing AndAlso mt.module IsNot Nothing Then
            ' release module
            mt.Dispose()
        End If

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
