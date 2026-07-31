'
' Copyright (c) 2014-2020, MindFusion LLC - Bulgaria
'

Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports MindFusion.Mapping.WebForms

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class MapService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GenerateMap(ByVal json As String) As String
        Return MapView.GenerateMap(json)
    End Function

End Class