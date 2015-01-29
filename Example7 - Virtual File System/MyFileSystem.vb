'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.IO

Public Class MyFileSystem

    Implements WinWrap.Basic.IVirtualFileSystem

    Private rootDir As String = Path.GetFullPath("..\..\..\Scripts")

    Public Function Combine(baseScriptPath As String, name As String) As String Implements WinWrap.Basic.IVirtualFileSystem.Combine
        ' ignore baseScriptPath in this example
        ' all scripts are in the same "directory"
        Return name
    End Function

    Public Sub Delete(scriptPath As String) Implements WinWrap.Basic.IVirtualFileSystem.Delete
        File.Delete(ActualFileName(scriptPath))
    End Sub

    Public Function Exists(scriptPath As String) As Boolean Implements WinWrap.Basic.IVirtualFileSystem.Exists
        Return File.Exists(ActualFileName(scriptPath))
    End Function

    Public Function GetCaption(scriptPath As String) As String Implements WinWrap.Basic.IVirtualFileSystem.GetCaption
        Return Path.GetFileName(ActualFileName(scriptPath))
    End Function

    Public Function GetTimeStamp(scriptPath As String) As Date Implements WinWrap.Basic.IVirtualFileSystem.GetTimeStamp
        Return File.GetLastWriteTimeUtc(ActualFileName(scriptPath))
    End Function

    Public Function Read(scriptPath As String) As String Implements WinWrap.Basic.IVirtualFileSystem.Read
        Return File.ReadAllText(ActualFileName(scriptPath))
    End Function

    Public Sub Write(scriptPath As String, text As String) Implements WinWrap.Basic.IVirtualFileSystem.Write
        File.WriteAllText(ActualFileName(scriptPath), text, System.Text.Encoding.UTF8)
    End Sub

    Private Function ActualFileName(scriptPath As String) As String
        Return Path.Combine(rootDir, scriptPath)
    End Function

End Class
