'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Imports System.IO
Imports System.Text
Imports WinWrap.Basic

Public Module WinWrapBasic

    Public Function FormatError(ByVal [error] As Winwrap.Basic.Error) As String
        Dim sb As New StringBuilder
        If (Not [error] Is Nothing) Then
            sb.AppendLine([error].File)
            If File.Exists([error].File) Then
                Dim line As String = File.ReadAllLines([error].File)(([error].Line - 1))
                If ([error].Offset >= 0) Then
                    line = line.Insert([error].Offset, "<here>")
                End If
                line = String.Format("{0:00}:{1}", [error].Line, line)
                sb.AppendLine(line)
            End If
            sb.AppendLine([error].Text)
            sb.AppendLine("")
        End If
        Return sb.ToString
    End Function

    Public Function FormatTimeoutError(ByVal basicNoUIObj As BasicNoUIObj, ByVal timedout As Boolean) As String
        Dim sb As New StringBuilder
        sb.AppendLine(CStr(basicNoUIObj.Query("GetStack", New Object(0 - 1) {}).Item("Caller[0]")))
        sb.AppendLine(IIf(timedout, "time exceeded", "paused, terminating script."))
        sb.AppendLine("")
        Return sb.ToString
    End Function

End Module
