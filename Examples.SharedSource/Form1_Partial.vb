'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.Text
Imports Examples.Extensions

Partial Public Class Form1
    Inherits Form
    Implements IHost


#Region "IHost"

    Private theincident_ As Incident

    Public ReadOnly Property TheIncident As Incident Implements IHost.TheIncident
        Get
            Return theincident_
        End Get
    End Property

    Public Sub Log(ByVal [text] As String) Implements IHost.Log
        If outputIsError_ Then
            RichTextBoxOutput.Text = ""
        End If
        RichTextBoxOutput.AppendText(([text] & Environment.NewLine))
        RichTextBoxOutput.SelectionStart = RichTextBoxOutput.Text.Length
        RichTextBoxOutput.ScrollToCaret()
        outputIsError_ = False
    End Sub

#End Region

    Private ReadOnly Property Script As String
        Get
            Return scripts_(ListBoxScripts.SelectedIndex)
        End Get
    End Property

    Private outputIsError_ As Boolean

    Private Sub ListBoxScripts_Initialize()
        Dim script As String
        For Each script In Form1.scripts_
            ListBoxScripts.Items.Add(script)
        Next
        ListBoxScripts.SelectedIndex = 0
    End Sub

    Private Function ScriptPath(ByVal script As String) As String
        Dim dir As String = "..\..\..\Scripts"
        Return String.Format("{0}\{1}", dir, script)
    End Function

    Private Sub LogError(ByVal [error] As WinWrap.Basic.Error)
        LogError(WinWrapBasic.FormatError([error]))
    End Sub

    Private Sub LogError(ByVal [text] As String)
        Dim sb As New StringBuilder
        sb.AppendLine(DateTime.Now.ToString)
        sb.AppendLine([text])
        RichTextBoxOutput.Text = ""
        RichTextBoxOutput.SelectionColor = Color.Red
        RichTextBoxOutput.SelectedText = sb.ToString
        outputIsError_ = True
    End Sub

End Class
