Imports Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Public Class ProjectTask
    Public ID As Integer
    Public Name As String
    Public StartTime As Date
    Public Effort As TimeSpan
    Public Resources As String
    Public ProgressPercent As Double
    Public IndentLevel As Integer
    Public Description As String
    Public Predecessor As String
    Public IsViewPermission As Boolean
    Public IsAddPermission As Boolean
    Public IsUpdatePermission As Boolean
    Public IsDeletePermission As Boolean
   
End Class



