Imports Microsoft.VisualBasic

Public Class ItemTemplate
    Implements ITemplate
    Private m_ColumnName As String
    Private m_ColumnData As String
    Public Property ColumnName() As String
        Get
            Return m_ColumnName
        End Get
        Set(ByVal value As String)
            m_ColumnName = value
        End Set
    End Property
    Public Property ColumnData() As String
        Get
            Return m_ColumnData
        End Get
        Set(ByVal value As String)
            m_ColumnData = value
        End Set
    End Property
    Public Sub New(ColumnName As String, ColumnData As String)
        Me.ColumnName = ColumnName
        Me.ColumnData = ColumnData
    End Sub
    Public Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn
        Dim tbl As New System.Web.UI.WebControls.Table
        Dim tblrow As New System.Web.UI.WebControls.TableRow
        Dim tblcell As New System.Web.UI.WebControls.TableCell
        Dim LBL As New Label
        tbl.BorderWidth = "0"
        tblrow.BorderWidth = "0"
        tblcell.BorderWidth = "0"
        With tbl
            .ID = "T" & ColumnName
            .CssClass = "intab"
            .ClientIDMode = ClientIDMode.Static
        End With
        With tblrow
            .ID = "R" & ColumnName
            .ClientIDMode = ClientIDMode.Static
        End With
        With tblcell
            .ID = "C" & ColumnName
            .ClientIDMode = ClientIDMode.Static
        End With

        tbl.Rows.Add(tblrow)
        tblrow.Cells.Add(tblcell)

        With LBL
            .ID = ColumnName
            .Text = ColumnData
        End With
        tblcell.Controls.Add(LBL)


        ThisColumn.Controls.Add(tbl)
    End Sub
End Class
