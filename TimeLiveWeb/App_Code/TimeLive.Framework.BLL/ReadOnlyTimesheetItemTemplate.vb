Imports Microsoft.VisualBasic
Public Class ReadOnlyTimesheetItemTemplate
    Implements ITemplate
    Private m_STColumnName As String
    Private m_ETColumnName As String
    Private m_TTColumnName As String
    Private m_PColumnName As String
    Private m_IsEnable As Boolean
    Public Property STColumnName() As String
        Get
            Return m_STColumnName
        End Get
        Set(ByVal value As String)
            m_STColumnName = value
        End Set
    End Property
    Public Property ETColumnName() As String
        Get
            Return m_ETColumnName
        End Get
        Set(ByVal value As String)
            m_ETColumnName = value
        End Set
    End Property
    Public Property TTColumnName() As String
        Get
            Return m_TTColumnName
        End Get
        Set(ByVal value As String)
            m_TTColumnName = value
        End Set
    End Property
    Public Property PColumnName() As String
        Get
            Return m_PColumnName
        End Get
        Set(ByVal value As String)
            m_PColumnName = value
        End Set
    End Property
    Public Sub New(ByVal STColumnName As String, ByVal ETColumnName As String, ByVal TTColumnName As String, ByVal IsEnable As Boolean, ByVal PColumnName As String)
        Me.STColumnName = STColumnName
        Me.ETColumnName = ETColumnName
        Me.TTColumnName = TTColumnName
        Me.PColumnName = PColumnName
        m_IsEnable = IsEnable
    End Sub

    Private Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        'If m_IsEnable = True Then
        Dim STTextBox As New Label()
        Dim ETTextBox As New Label()
        Dim TTTextBox As New Label()
        Dim PTextBox As New Label()
        If DBUtilities.IsTimeEntryHoursFormat = "Time" Or DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
            If DBUtilities.GetShowClockStartEnd = True Then
                With STTextBox
                    .ID = STColumnName
                    '.Width = 54
                End With
                ThisColumn.Controls.Add(STTextBox)
                ThisColumn.Controls.Add(New LiteralControl("<br />"))
                With ETTextBox
                    .ID = ETColumnName
                    '.Width = 54
                End With
                ThisColumn.Controls.Add(ETTextBox)
                ThisColumn.Controls.Add(New LiteralControl("<br />"))
            End If
            If DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Then
                If DBUtilities.GetShowClockStartEnd = True Then
                    With STTextBox
                        .ID = STColumnName
                        '.Width = 54
                    End With
                    ThisColumn.Controls.Add(STTextBox)
                    ThisColumn.Controls.Add(New LiteralControl("<br />"))
                    With ETTextBox
                        .ID = ETColumnName
                        '.Width = 54
                    End With
                    ThisColumn.Controls.Add(ETTextBox)
                    ThisColumn.Controls.Add(New LiteralControl("<br />"))
                End If
            End If
        End If
        If DBUtilities.IsTimeEntryHoursFormat = "Time" Or DBUtilities.IsTimeEntryHoursFormat = "Decimal" Or LocaleUtilitiesBLL.IsShowTimeOffInTimesheet() Then
            With TTTextBox
                .ID = TTColumnName
                '.Width = 54
            End With
            ThisColumn.Controls.Add(TTTextBox)
            ThisColumn.Controls.Add(New LiteralControl("<br />"))
        ElseIf DBUtilities.IsTimeEntryHoursFormat = "None" And LocaleUtilitiesBLL.ShowPercentageInTimesheet = False Then
            With TTTextBox
                .ID = TTColumnName
                '.Width = 54
            End With
            ThisColumn.Controls.Add(TTTextBox)
            ThisColumn.Controls.Add(New LiteralControl("<br />"))
        End If
        If LocaleUtilitiesBLL.ShowPercentageInTimesheet() Then
            With PTextBox
                .ID = PColumnName
                '.Width = 50
            End With
            ThisColumn.Controls.Add(PTextBox)
        End If
    End Sub
End Class