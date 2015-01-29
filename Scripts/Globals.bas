'#Language "WWB.NET"

Imports System.Text.RegularExpressions

Public Function ScriptName() As String
    Dim caller As String = CallersLine
    Dim regex As New regex("^.*\\(?<scriptname>.*[.](bas|cls)).*$")
    Return regex.Match(caller).Groups("scriptname").ToString()
End Function
