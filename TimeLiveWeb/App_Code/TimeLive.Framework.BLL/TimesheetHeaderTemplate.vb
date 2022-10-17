Imports Microsoft.VisualBasic
Public Class TimesheetHeaderTemplate
    Implements ITemplate
    Private m_imgHolidayColumnName As String
    Private m_STColumnName As String
    Private m_IsVisible As Boolean
    Public Property imgHolidayColumnName() As String
        Get
            Return m_imgHolidayColumnName
        End Get
        Set(ByVal value As String)
            m_imgHolidayColumnName = value
        End Set
    End Property
    Public Property STColumnName() As String
        Get
            Return m_STColumnName
        End Get
        Set(ByVal value As String)
            m_STColumnName = value
        End Set
    End Property
    Public Sub New(ByVal imgHolidayColumnName As String, ByVal STColumnName As String, ByVal IsVisible As Boolean)
        Me.imgHolidayColumnName = imgHolidayColumnName
        Me.STColumnName = STColumnName
        m_IsVisible = IsVisible
    End Sub

    Private Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        Dim StatusHolidayImage As New System.Web.UI.WebControls.Image
        Dim HTLabel As New System.Web.UI.WebControls.Label
        With StatusHolidayImage
            .ID = imgHolidayColumnName
            .Width = 20
            .ImageUrl = "~/Images/Holiday.gif"
            .EnableTheming = "True"
            .Visible = m_IsVisible
        End With
        ThisColumn.Controls.Add(StatusHolidayImage)
        With HTLabel
            .ID = STColumnName
            .Text = STColumnName
        End With
        ThisColumn.Controls.Add(HTLabel)
    End Sub
End Class