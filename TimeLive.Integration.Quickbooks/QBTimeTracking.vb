Imports Interop.QBFC10
Public Class QBTimeTracking
    Private p_token As String
    Private p_AccountId As String
    Public Overloads Sub Show(ByVal token As String, ByVal AccountId As String)
        If token Is Nothing Then
            MsgBox("Please Login")
        Else
            p_AccountId = AccountId
            p_token = token
            MyBase.Show()
        End If
    End Sub
    Private Sub btnGetAndAddTimeEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAndAddTimeEntries.Click
        pgbar.Value = 0
        Try
            Dim objTimeTrackingServices As New Services.TimeLive.TimeEntries.TimeEntries
            Dim authentication As New Services.TimeLive.TimeEntries.SecuredWebServiceHeader
            authentication.AuthenticatedToken = p_token
            objTimeTrackingServices.SecuredWebServiceHeaderValue = authentication
            Dim objTimeEntryArray() As Object
            objTimeEntryArray = objTimeTrackingServices.GetTimeEntriesByEmployeeIdAndDateRange(cbEmployee.SelectedValue, CDate(dpStartDate.Value).Date, CDate(dpEndDate.Value).Date)
            Dim objTimeEntry As New Services.TimeLive.TimeEntries.TimeEntry
            Dim pblenth As Integer = objTimeEntryArray.Length - 1
            If pblenth >= 0 Then
                pgbar.Maximum = pblenth
            End If
            For n As Integer = 0 To objTimeEntryArray.Length - 1
                pgbar.Increment(n)
                objTimeEntry = objTimeEntryArray(n)
                With objTimeEntry
                    AddTimeEntryInQB(.ClientName, .EmployeeName, .IsBillable, .ProjectName, .TaskWithParent, .TotalTime, .TimeEntryDate, IIf(Me.chkPayrollTimesheet.Checked = True, GetClass(objTimeEntry), "<None>"), IIf(Me.chkPayrollTimesheet.Checked = True, GetPayrollItem(objTimeEntry), "<None>"))
                End With
            Next
            MessageBox.Show("Record(s) transferred successfully")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddTimeEntryInQB(ByVal CustomerName As String, ByVal EmployeeName As String, ByVal IsBillable As Boolean, ByVal ProjectName As String, ByVal ServiceItemName As String, ByVal TotalTime As DateTime, ByVal TimeEntryDate As Date, ByVal TimeEntryClass As String, ByVal PayrollItem As String)
        If rbtJobitems.Checked = True Then
            AddTimeEntryInQBJobItem(CustomerName, EmployeeName, IsBillable, ProjectName, ServiceItemName, TotalTime, TimeEntryDate, TimeEntryClass, PayrollItem)
        ElseIf rbJob.Checked = True Then
            AddTimeEntryInQBJobSubJob(CustomerName, EmployeeName, IsBillable, ProjectName, ServiceItemName, TotalTime, TimeEntryDate, TimeEntryClass, PayrollItem)
        ElseIf rbItem.Checked = True Then
            AddTimeEntryInQBItemSubItem(CustomerName, EmployeeName, IsBillable, ProjectName, ServiceItemName, TotalTime, TimeEntryDate, TimeEntryClass, PayrollItem)
        End If
    End Sub
    Public Sub AddTimeEntryInQBJobItem(ByVal CustomerName As String, ByVal EmployeeName As String, ByVal IsBillable As Boolean, ByVal ProjectName As String, ByVal ServiceItemName As String, ByVal TotalTime As DateTime, ByVal TimeEntryDate As Date, ByVal TimeEntryClass As String, ByVal PayrollItem As String)

        'step1: create QBFC session manager and prepare the request
        Dim sessManager As QBSessionManager
        Dim msgSetRs As IMsgSetResponse
        Try
            ProjectName = SetLength(ProjectName)
            sessManager = New QBSessionManagerClass()
            Dim msgSetRq As IMsgSetRequest = sessManager.CreateMsgSetRequest("US", 2, 0)
            msgSetRq.Attributes.OnError = ENRqOnError.roeContinue
            Dim timeAdd As ITimeTrackingAdd = msgSetRq.AppendTimeTrackingAddRq
            timeAdd.CustomerRef.FullName.SetValue(CustomerName & ":" & ProjectName)
            timeAdd.Duration.SetValue(TotalTime.Hour, TotalTime.Minute, 0, False)
            timeAdd.EntityRef.FullName.SetValue(EmployeeName)
            timeAdd.IsBillable.SetValue(IsBillable)
            timeAdd.ItemServiceRef.FullName.SetValue(ServiceItemName)
            timeAdd.TxnDate.SetValue(TimeEntryDate)
            If Not TimeEntryClass = "<None>" Then
                AddClass(TimeEntryClass)
                timeAdd.ClassRef.FullName.SetValue(TimeEntryClass)
            End If
            If Not PayrollItem = "<None>" Then
                AddPayrollItem(PayrollItem)
                timeAdd.PayrollItemWageRef.FullName.SetValue(PayrollItem)
            End If

            'step2: begin QB session and send the request
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
            msgSetRs = sessManager.DoRequests(msgSetRq)
            If msgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
                Throw New Exception(msgSetRs.ResponseList.GetAt(0).StatusMessage)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sessManager Is Nothing Then
                sessManager.EndSession()
                sessManager.CloseConnection()
            End If
        End Try
    End Sub
    Public Sub AddTimeEntryInQBItemSubItem(ByVal CustomerName As String, ByVal EmployeeName As String, ByVal IsBillable As Boolean, ByVal ProjectName As String, ByVal ServiceItemName As String, ByVal TotalTime As DateTime, ByVal TimeEntryDate As Date, ByVal TimeEntryClass As String, ByVal PayrollItem As String)

        'step1: create QBFC session manager and prepare the request
        Dim sessManager As QBSessionManager
        Dim msgSetRs As IMsgSetResponse
        Try
            ProjectName = SetLength(ProjectName)
            sessManager = New QBSessionManagerClass()
            Dim msgSetRq As IMsgSetRequest = sessManager.CreateMsgSetRequest("US", 2, 0)
            msgSetRq.Attributes.OnError = ENRqOnError.roeContinue
            Dim timeAdd As ITimeTrackingAdd = msgSetRq.AppendTimeTrackingAddRq
            timeAdd.CustomerRef.FullName.SetValue(CustomerName)
            timeAdd.Duration.SetValue(TotalTime.Hour, TotalTime.Minute, 0, False)
            timeAdd.EntityRef.FullName.SetValue(EmployeeName)
            timeAdd.IsBillable.SetValue(IsBillable)
            timeAdd.ItemServiceRef.FullName.SetValue(ProjectName & ":" & ServiceItemName)
            timeAdd.TxnDate.SetValue(TimeEntryDate)
            If Not TimeEntryClass = "<None>" Then
                timeAdd.ClassRef.FullName.SetValue(TimeEntryClass)
            End If
            If Not PayrollItem = "<None>" Then
                timeAdd.PayrollItemWageRef.FullName.SetValue(PayrollItem)
            End If

            'step2: begin QB session and send the request
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
            msgSetRs = sessManager.DoRequests(msgSetRq)
            If msgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
                Throw New Exception(msgSetRs.ResponseList.GetAt(0).StatusMessage)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sessManager Is Nothing Then
                sessManager.EndSession()
                sessManager.CloseConnection()
            End If
        End Try
    End Sub
    Public Sub AddTimeEntryInQBJobSubJob(ByVal CustomerName As String, ByVal EmployeeName As String, ByVal IsBillable As Boolean, ByVal ProjectName As String, ByVal ServiceItemName As String, ByVal TotalTime As DateTime, ByVal TimeEntryDate As Date, ByVal TimeEntryClass As String, ByVal PayrollItem As String)

        'step1: create QBFC session manager and prepare the request
        Dim sessManager As QBSessionManager
        Dim msgSetRs As IMsgSetResponse
        Try
            ProjectName = SetLength(ProjectName)
            sessManager = New QBSessionManagerClass()
            Dim msgSetRq As IMsgSetRequest = sessManager.CreateMsgSetRequest("US", 2, 0)
            msgSetRq.Attributes.OnError = ENRqOnError.roeContinue
            Dim timeAdd As ITimeTrackingAdd = msgSetRq.AppendTimeTrackingAddRq
            timeAdd.CustomerRef.FullName.SetValue(CustomerName & ":" & ProjectName & ":" & ServiceItemName)
            timeAdd.Duration.SetValue(TotalTime.Hour, TotalTime.Minute, 0, False)
            timeAdd.EntityRef.FullName.SetValue(EmployeeName)
            timeAdd.IsBillable.SetValue(IsBillable)
            AddNoneItemInQB("<None>", "<None>")
            timeAdd.ItemServiceRef.FullName.SetValue("<None>")
            timeAdd.TxnDate.SetValue(TimeEntryDate)
            If Not TimeEntryClass = "<None>" Then
                timeAdd.ClassRef.FullName.SetValue(TimeEntryClass)
            End If
            If Not PayrollItem = "<None>" Then
                timeAdd.PayrollItemWageRef.FullName.SetValue(PayrollItem)
            End If

            'step2: begin QB session and send the request
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
            msgSetRs = sessManager.DoRequests(msgSetRq)
            If msgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
                Throw New Exception(msgSetRs.ResponseList.GetAt(0).StatusMessage)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sessManager Is Nothing Then
                sessManager.EndSession()
                sessManager.CloseConnection()
            End If
        End Try
    End Sub
    Public Sub AddNoneItemInQB(ByVal ItemName As String, ByVal ServiceItemAccount As String)
        'step1: create QBFC session manager and prepare the request
        Dim sessManager As QBSessionManager
        Dim msgSetRs As IMsgSetResponse
        Try
            ItemName = SetLength(ItemName)
            sessManager = New QBSessionManagerClass()
            Dim msgSetRq As IMsgSetRequest = sessManager.CreateMsgSetRequest("US", 2, 0)
            msgSetRq.Attributes.OnError = ENRqOnError.roeContinue
            Dim AccountAdd As IAccountAdd = msgSetRq.AppendAccountAddRq
            AccountAdd.Name.SetValue(ServiceItemAccount)
            AccountAdd.AccountType.SetValue(ENAccountType.atExpense)
            Dim ItemAdd As IItemServiceAdd = msgSetRq.AppendItemServiceAddRq
            ItemAdd.Name.SetValue(ItemName)
            ItemAdd.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.SetValue(ServiceItemAccount)
            'step2: begin QB session and send the request
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
            msgSetRs = sessManager.DoRequests(msgSetRq)
            'If msgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
            '    Throw New Exception(msgSetRs.ResponseList.GetAt(0).StatusMessage)
            'End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sessManager Is Nothing Then
                sessManager.EndSession()
                sessManager.CloseConnection()
            End If
        End Try
    End Sub
    Public Function SetLength(ByVal Name As String) As String
        If Name.Length > 31 Then
            Name = Name.Substring(0, 31)
        End If
        Return Name
    End Function
    Private Sub TimeTracking_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        MainMenu.Enabled = True
    End Sub
    Public Function GetClass(ByVal objTimeEntry As Services.TimeLive.TimeEntries.TimeEntry) As String
        Dim TimeEntryClass As String = "<None>"
        With objTimeEntry
            If cbClass.SelectedItem = "CostCenter" Then
                Return .CostCenter
            ElseIf cbClass.SelectedItem = "Department" Then
                Return .EmployeeDepartment
            ElseIf cbClass.SelectedItem = "EmployeeType" Then
                Return .EmployeeType
            ElseIf cbClass.SelectedItem = "Milestone" Then
                Return .Milestone
            ElseIf cbClass.SelectedItem = "WorkType" Then
                Return .WorkType
            End If
        End With
        Return TimeEntryClass
    End Function
    Public Function GetPayrollItem(ByVal objTimeEntry As Services.TimeLive.TimeEntries.TimeEntry) As String
        Dim PayrollItem As String = "<None>"
        With objTimeEntry
            If cbPayrollItem.SelectedItem = "CostCenter" Then
                Return .CostCenter
            ElseIf cbPayrollItem.SelectedItem = "Department" Then
                Return .EmployeeDepartment
            ElseIf cbPayrollItem.SelectedItem = "EmployeeType" Then
                Return .EmployeeType
            ElseIf cbPayrollItem.SelectedItem = "Milestone" Then
                Return .Milestone
            ElseIf cbPayrollItem.SelectedItem = "WorkType" Then
                Return .WorkType
            End If
        End With
        Return PayrollItem
    End Function

    Private Sub TimeTracking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objEmployeeServices As New Services.TimeLive.Employees.Employees
        Dim authentication As New Services.TimeLive.Employees.SecuredWebServiceHeader
        authentication.AuthenticatedToken = p_token
        objEmployeeServices.SecuredWebServiceHeaderValue = authentication
        Dim dv As New DataView(objEmployeeServices.GetEmployeesData)        
        Me.cbEmployee.DataSource = dv
        Me.cbEmployee.DisplayMember = "FullName"
        Me.cbEmployee.ValueMember = "AccountEmployeeId"
        Me.cbEmployee.SelectedIndex = 0
        Me.cbClass.SelectedIndex = 0
        Me.cbPayrollItem.SelectedIndex = 0
        Me.cbWageType.SelectedIndex = 3
    End Sub

    Private Sub chkPayrollTimesheet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPayrollTimesheet.CheckedChanged
        If chkPayrollTimesheet.Checked = True Then
            Me.cbClass.Enabled = True
            Me.cbPayrollItem.Enabled = True
            Me.cbWageType.Enabled = True
        Else
            Me.cbClass.Enabled = False
            Me.cbPayrollItem.Enabled = False
            Me.cbWageType.Enabled = False
        End If
    End Sub
    Public Sub AddClass(ByVal ClassName As String)
        'step1: create QBFC session manager and prepare the request
        Dim sessManager As QBSessionManager
        Dim msgSetRs As IMsgSetResponse
        Try
            sessManager = New QBSessionManagerClass()
            Dim msgSetRq As IMsgSetRequest = sessManager.CreateMsgSetRequest("US", 2, 0)
            msgSetRq.Attributes.OnError = ENRqOnError.roeContinue
            Dim ClassAdd As IClassAdd = msgSetRq.AppendClassAddRq
            ClassAdd.Name.SetValue(ClassName)

            'step2: begin QB session and send the request
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
            msgSetRs = sessManager.DoRequests(msgSetRq)
            If Not msgSetRs.ResponseList.GetAt(0).StatusMessage.Contains("already in use") Then
                If msgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
                    Throw New Exception(msgSetRs.ResponseList.GetAt(0).StatusMessage)
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sessManager Is Nothing Then
                sessManager.EndSession()
                sessManager.CloseConnection()
            End If
        End Try
    End Sub
    Public Sub AddPayrollItem(ByVal PayrollItem As String)
        'step1: create QBFC session manager and prepare the request
        Dim sessManager As QBSessionManager
        Dim msgSetRs As IMsgSetResponse
        Try
            sessManager = New QBSessionManagerClass()
            Dim msgSetRq As IMsgSetRequest = sessManager.CreateMsgSetRequest("US", 2, 0)
            msgSetRq.Attributes.OnError = ENRqOnError.roeContinue
            Dim PayrollItemAdd As IPayrollItemWageAdd = msgSetRq.AppendPayrollItemWageAddRq
            PayrollItemAdd.Name.SetValue(PayrollItem)
            PayrollItemAdd.ExpenseAccountRef.FullName.SetValue("Payroll Expenses")
            PayrollItemAdd.WageType.SetValue(GetWageType(cbWageType.SelectedItem))

            'step2: begin QB session and send the request
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
            msgSetRs = sessManager.DoRequests(msgSetRq)
            If Not msgSetRs.ResponseList.GetAt(0).StatusMessage.Contains("already in use") Then
                If msgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
                    Throw New Exception(msgSetRs.ResponseList.GetAt(0).StatusMessage)
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sessManager Is Nothing Then
                sessManager.EndSession()
                sessManager.CloseConnection()
            End If
        End Try
    End Sub
    Public Function GetWageType(ByVal val As String) As ENWageType
        If val = "Bonus" Then
            Return ENWageType.wtBonus
        ElseIf val = "Comission" Then
            Return ENWageType.wtCommission
        ElseIf val = "Hourly" Then
            Return ENWageType.wtHourly
        ElseIf val = "Hourly-Overtime" Then
            Return ENWageType.wtHourlyOvertime
        ElseIf val = "Hourly-Regular" Then
            Return ENWageType.wtHourlyRegular
        ElseIf val = "Hourly-Sick" Then
            Return ENWageType.wtHourlySick
        ElseIf val = "Hourly-Vacation" Then
            Return ENWageType.wtHourlyVacation
        ElseIf val = "Salary" Then
            Return ENWageType.wtSalary
        ElseIf val = "Salary-Regular" Then
            Return ENWageType.wtSalaryRegular
        ElseIf val = "Salary-Sick" Then
            Return ENWageType.wtSalarySick
        ElseIf val = "Salary-Vacation" Then
            Return ENWageType.wtSalaryVacation
        End If
    End Function
End Class