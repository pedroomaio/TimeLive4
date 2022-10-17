Imports Microsoft.VisualBasic
Public Class TimesheetFooterTemplate
    Implements ITemplate
    Private m_SumTimeColumnName As String
    Private m_IsEnable As Boolean
    Private m_SumPercentageColumnName As String

    Public Property SumTimeColumnName() As String
        Get
            Return m_SumTimeColumnName
        End Get
        Set(ByVal value As String)
            m_SumTimeColumnName = value
        End Set
    End Property
    Public Property SumPercentageColumnName() As String
        Get
            Return m_SumPercentageColumnName
        End Get
        Set(ByVal value As String)
            m_SumPercentageColumnName = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal SumTimeColumnName As String, ByVal IsEnable As Boolean, ByVal SumPercentageColumnName As String)
        Me.SumTimeColumnName = SumTimeColumnName
        Me.m_IsEnable = IsEnable
        Me.SumPercentageColumnName = SumPercentageColumnName
    End Sub

    Private Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        If m_IsEnable = True Then
            Dim SumTimeTextBox As New TextBox()
            Dim SumPercentageTextBox As New TextBox()
            Dim tbl As New System.Web.UI.WebControls.Table
            Dim tblrow As New System.Web.UI.WebControls.TableRow
            Dim tblcell As New System.Web.UI.WebControls.TableCell

            With tbl
                .ID = "T" + SumTimeColumnName
                .HorizontalAlign = HorizontalAlign.Center
                .BorderWidth = 0
            End With
            With tblrow
                .ID = "R" + SumTimeColumnName
                .HorizontalAlign = HorizontalAlign.Center
                .BorderWidth = 0
            End With
            With tblcell
                .ID = "C" + SumTimeColumnName
                .HorizontalAlign = HorizontalAlign.Center
                .BorderWidth = 0
            End With

            tbl.Rows.Add(tblrow)
            tblrow.Cells.Add(tblcell)

            With SumTimeTextBox
                .ID = SumTimeColumnName
                .EnableViewState = False
                .Width = 50
                .ReadOnly = True
                .Style.Add("text-align", "center")
            End With
            tblcell.Controls.Add(SumTimeTextBox)
            If LocaleUtilitiesBLL.ShowPercentageInTimesheet() Then
                With SumPercentageTextBox
                    .ID = SumPercentageColumnName
                    .EnableViewState = False
                    .Width = 50
                    .ReadOnly = True
                End With
                tblcell.Controls.Add(SumPercentageTextBox)
            End If

            ThisColumn.Controls.Add(tbl)
        End If
    End Sub
End Class