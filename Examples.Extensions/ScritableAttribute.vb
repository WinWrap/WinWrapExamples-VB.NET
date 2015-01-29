'------------------------------------------------------------------------------
' <copyright from='2013' to='2014' company='Polar Engineering and Consulting'>
'    Copyright (c) Polar Engineering and Consulting. All Rights Reserved.
'
'    This file contains confidential material.
'
' </copyright>
'------------------------------------------------------------------------------

Friend Class ScriptableAttribute
    Inherits Attribute

    ' http://www.winwrap.com/web2/basic/#!/ref/NET-WinWrap.Basic.BasicNoUIObj.AddScriptableObjectModel.html
    Public Overrides ReadOnly Property TypeId As Object
        Get
            Return New Guid("542F6A10-6097-445A-B09E-A248863C2873")
        End Get
    End Property
End Class
