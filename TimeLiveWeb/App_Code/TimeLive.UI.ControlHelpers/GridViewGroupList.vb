'------------------------------------------------------------------------------------------ 
' Copyright � 2006 Agrinei Sousa [www.agrinei.com] 
' 
' Esse c�digo fonte � fornecido sem garantia de qualquer tipo. 
' Sinta-se livre para utiliz�-lo, modific�-lo e distribu�-lo, 
' inclusive em aplica��es comerciais. 
' � altamente desej�vel que essa mensagem n�o seja removida. 
'------------------------------------------------------------------------------------------ 

Imports System
Imports System.Collections.Generic

''' <summary> 
''' Summary description for GridViewGroupList 
''' </summary> 
Public Class GridViewGroupList
    Inherits List(Of GridViewGroup)
    Default Public ReadOnly Property Item(ByVal name As String) As GridViewGroup
        Get
            Return Me.FindGroupByName(name)
        End Get
    End Property

    Public Function FindGroupByName(ByVal name As String) As GridViewGroup
        For Each g As GridViewGroup In Me
            If g.Name.ToLower() = name.ToLower() Then
                Return g
            End If
        Next

        Return Nothing
    End Function
End Class