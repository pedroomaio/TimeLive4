
Partial Class Employee_AccountEmployeeTimeEntry
    Inherits System.Web.UI.Page

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs)

        Select Case e.Item.Value
            Case "DayView"

                Me.MultiView1.ActiveViewIndex = 0
            Case "WeekView"
                Me.MultiView1.ActiveViewIndex = 1
        End Select



    End Sub


    Protected Sub MultiView1_ActiveViewChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MultiView1.ActiveViewChanged

        Dim objView As MultiView = sender



        Select Case objView.ActiveViewIndex
            Case 0
                If Me.ViewState("CurrentView") <> 0 Then
                    Me.RefreshDayView()
                End If

            Case 1
                If Me.ViewState("CurrentView") <> 1 Then
                    Me.RefreshWeekView()
                End If
                '   Me.CtlAccountEmployeeTimeEntryWeekView1.FindControl(
        End Select

        Me.ViewState.Add("CurrentView", Me.MultiView1.ActiveViewIndex)

    End Sub

    Public Sub RefreshView(Optional ByVal bDateSelect As Boolean = False)
        If Me.MultiView1.ActiveViewIndex = 0 Then
            Me.RefreshDayView()
        Else
            Me.RefreshWeekView(bDateSelect)
            
        End If
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.RefreshView(True)
    End Sub

    Public Sub RefreshDayView()

        '        Me.CtlAccountEmployeeTimeEntryDayView1.ShowForDate(Me.txtTimeEntryDate.SelectedDate.Date)

    End Sub

    Public Sub RefreshWeekView(Optional ByVal bDateSelect As Boolean = False)

        If bDateSelect = False Then
            ' Me.CtlAccountEmployeeTimeEntryWeekView1.ShowDate(Me.txtTimeEntryDate.SelectedDate.Date)
        Else
            Response.Redirect("AccountEmployeeTimeEntry.aspx?Mode=Week&StartDate=" & Me.txtTimeEntryDate.SelectedDate.Date, False)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            If Not Request.QueryString("Mode") Is Nothing Then
                Me.txtTimeEntryDate.SelectedDate = Request.QueryString("StartDate")
                Me.MultiView1.ActiveViewIndex = 1
                Me.RefreshView()
            End If
        End If
    End Sub

    Protected Sub MultiView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MultiView1.Init
        Me.ViewState.Add("CurrentView", -1)
    End Sub


End Class
