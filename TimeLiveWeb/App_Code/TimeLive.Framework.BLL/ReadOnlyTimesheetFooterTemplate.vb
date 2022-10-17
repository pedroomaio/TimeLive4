Imports Microsoft.VisualBasic
Public Class ReadOnlyTimesheetFooterTemplate
    Implements ITemplate
    Private m_SumTimeColumnName As String
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
    Public Sub New(ByVal SumTimeColumnName As String, ByVal SumPercentageColumnName As String)
        Me.SumTimeColumnName = SumTimeColumnName
        Me.m_SumPercentageColumnName = SumPercentageColumnName
    End Sub

    Private Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        Dim SumTimeTextBox As New Label()
        Dim SumPercentageTextBox As New Label()
        If DBUtilities.IsTimeEntryHoursFormat = "Time" Or DBUtilities.IsTimeEntryHoursFormat = "Decimal" Or LocaleUtilitiesBLL.IsShowTimeOffInTimesheet() Then
            With SumTimeTextBox
                .ID = SumTimeColumnName
                .Width = 54
            End With
            ThisColumn.Controls.Add(SumTimeTextBox)
        ElseIf DBUtilities.IsTimeEntryHoursFormat = "None" Or LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Then
            With SumTimeTextBox
                .ID = SumTimeColumnName
                .Width = 54
            End With
            ThisColumn.Controls.Add(SumTimeTextBox)
        End If
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet() Then
            With SumPercentageTextBox
                .ID = SumPercentageColumnName
                .Width = 54
            End With
            ThisColumn.Controls.Add(SumPercentageTextBox)
        End If
    End Sub
End Class