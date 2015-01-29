'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.IO

Public Class RealFileSystem

    Implements WinWrap.Basic.IVirtualFileSystem

    Public Function Combine(baseScriptPath As String, name As String) As String Implements WinWrap.Basic.IVirtualFileSystem.Combine
        If String.IsNullOrEmpty(baseScriptPath) Then
            baseScriptPath = Directory.GetCurrentDirectory()
        Else
            baseScriptPath = Path.GetDirectoryName(baseScriptPath)
        End If
        Return Path.GetFullPath(Path.Combine(baseScriptPath, name))
    End Function

    Public Sub Delete(scriptPath As String) Implements WinWrap.Basic.IVirtualFileSystem.Delete
        File.Delete(scriptPath)
    End Sub

    Public Function Exists(scriptPath As String) As Boolean Implements WinWrap.Basic.IVirtualFileSystem.Exists
        Return File.Exists(scriptPath)
    End Function

    Public Function GetCaption(scriptPath As String) As String Implements WinWrap.Basic.IVirtualFileSystem.GetCaption
        Return Path.GetFileName(scriptPath)
    End Function

    Public Function GetTimeStamp(scriptPath As String) As Date Implements WinWrap.Basic.IVirtualFileSystem.GetTimeStamp
        Return File.GetLastWriteTimeUtc(scriptPath)
    End Function

    Public Function Read(scriptPath As String) As String Implements WinWrap.Basic.IVirtualFileSystem.Read
        Return File.ReadAllText(scriptPath)
    End Function

    Public Sub Write(scriptPath As String, text As String) Implements WinWrap.Basic.IVirtualFileSystem.Write
        File.WriteAllText(scriptPath, text, System.Text.Encoding.UTF8)
    End Sub

End Class
