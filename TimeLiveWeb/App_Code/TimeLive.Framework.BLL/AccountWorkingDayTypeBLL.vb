Imports Microsoft.VisualBasic
Imports AccountWorkingDayTypeTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountWorkingDayTypeBLL
    Private _AccountWorkingDayTypeTableAdapter As AccountWorkingDayTypeTableAdapter = Nothing
    Private _vueAccountWorkingDayTypeTableAdapter As vueAccountWorkingDayTypeTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As AccountWorkingDayTypeTableAdapter
        Get
            If _AccountWorkingDayTypeTableAdapter Is Nothing Then
                _AccountWorkingDayTypeTableAdapter = New AccountWorkingDayTypeTableAdapter()
            End If
            Return _AccountWorkingDayTypeTableAdapter
        End Get
    End Property
    Protected ReadOnly Property vueAdapter() As vueAccountWorkingDayTypeTableAdapter
        Get
            If _vueAccountWorkingDayTypeTableAdapter Is Nothing Then
                _vueAccountWorkingDayTypeTableAdapter = New vueAccountWorkingDayTypeTableAdapter()
            End If
            Return _vueAccountWorkingDayTypeTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDayTypes() As AccountWorkingDayType.AccountWorkingDayTypeDataTable
        Return Adapter.GetData
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDayTypeByAccountId(ByVal AccountId As Integer) As AccountWorkingDayType.AccountWorkingDayTypeDataTable
        Return Adapter.GetDataByAccountId(AccountId)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDayTypeByAccountIdAndIsDisabled(ByVal AccountId As Integer, ByVal AccountWorkingDayTypeId As Guid) As AccountWorkingDayType.AccountWorkingDayTypeDataTable
        Return Adapter.GetDataByAccountIdAndIsDisabled(AccountId, AccountWorkingDayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountWorkingDayTypeByAccountId(ByVal AccountId As Integer) As AccountWorkingDayType.vueAccountWorkingDayTypeDataTable
        GetvueAccountWorkingDayTypeByAccountId = vueAdapter.GetDataByAccountId(AccountId)
        UIUtilities.FixTableForNoRecords(GetvueAccountWorkingDayTypeByAccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDayTypeByAccountWorkingDayTypeId(ByVal AccountWorkingDayTypeId As Guid) As AccountWorkingDayType.AccountWorkingDayTypeDataTable
        Return Adapter.GetDataByAccountWorkingDayTypeId(AccountWorkingDayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetvueAccountWorkingDayTypeByAccountWorkingDayTypeId(ByVal AccountWorkingDayTypeId As Guid) As AccountWorkingDayType.vueAccountWorkingDayTypeDataTable
        Return vueAdapter.GetDataByAccountWorkingDayTypeId(AccountWorkingDayTypeId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountWorkingDayTypeByMasterWorkingDayTypeIdAndAccountId(ByVal MasterWorkingDayTypeId As Guid, ByVal AccountId As Integer) As AccountWorkingDayType.AccountWorkingDayTypeDataTable
        Return Adapter.GetDataByMasterWorkingDayTypeIdAndAccountId(MasterWorkingDayTypeId, AccountId)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
    Public Function AddAccountWorkingDayType( _
                    ByVal AccountId As Integer, ByVal AccountWorkingDayType As String, ByVal HoursPerDay As Double, _
                    ByVal MinimumHoursPerDay As Double, ByVal MaximumHoursPerDay As Double, _
                    ByVal MinimumHoursPerWeek As Double, ByVal MaximumHoursPerWeek As Double, ByVal WeekStartDay As System.Nullable(Of Short), _
                    ByVal CreatedByEmployeeId As Integer, ByVal ModifiedByEmployeeId As Integer, ByVal AccountTimesheetPeriodTypeId As Guid, ByVal TimesheetOverdueAfterDays As Short, _
                    ByVal MinimumPercentagePerDay As Integer, ByVal MaximumPercentagePerDay As Integer, _
                    ByVal MinimumPercentagePerWeek As Integer, ByVal MaximumPercentagePerWeek As Integer, ByVal LockAllPreviousTimesheets As Boolean, _
                    ByVal LockAllFutureTimesheets As Boolean, ByVal LockPreviousTimesheetPeriods As Integer, ByVal LockFutureTimsheetPeriods As Integer, _
                    ByVal LockPreviousNextMonthTimesheetOn As Integer, ByVal EnableBalanceValidationForTimeOff As Boolean, ByVal LockAllPeriodExceptPrevious As Integer, ByVal LockAllPeriodExceptNext As Integer, ByVal ShowClockStartEndEmployee As Boolean) As Boolean

        _AccountWorkingDayTypeTableAdapter = New AccountWorkingDayTypeTableAdapter

        Dim dtWorkingDay As New AccountWorkingDayType.AccountWorkingDayTypeDataTable
        Dim drWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeRow = dtWorkingDay.NewAccountWorkingDayTypeRow
        Dim AccountWorkingDayTypeId As Guid = System.Guid.NewGuid
        With drWorkingDay
            .AccountWorkingDayTypeId = AccountWorkingDayTypeId
            .AccountId = AccountId
            .AccountWorkingDayType = AccountWorkingDayType
            .WeekStartDay = WeekStartDay
            .HoursPerDay = HoursPerDay
            .MinimumHoursPerDay = MinimumHoursPerDay
            .MaximumHoursPerDay = MaximumHoursPerDay
            .MinimumHoursPerWeek = MinimumHoursPerWeek
            .MaximumHoursPerWeek = MaximumHoursPerWeek
            .MinimumPercentagePerDay = MinimumPercentagePerDay
            .MaximumPercentagePerDay = MaximumPercentagePerDay
            .MinimumPercentagePerWeek = MinimumPercentagePerWeek
            .MaximumPercentagePerWeek = MaximumPercentagePerWeek
            .CreatedByEmployeeId = CreatedByEmployeeId
            .CreatedOn = Now
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .ModifiedOn = Now
            .IsDisabled = False
            .AccountTimesheetPeriodTypeId = AccountTimesheetPeriodTypeId
            .TimesheetOverdueAfterDays = TimesheetOverdueAfterDays
            .LockAllPreviousTimesheets = LockAllPreviousTimesheets
            .LockAllFutureTimesheets = LockAllFutureTimesheets
            .LockPreviousTimesheetPeriods = LockPreviousTimesheetPeriods
            .LockFutureTimsheetPeriods = LockFutureTimsheetPeriods
            .LockPreviousNextMonthTimesheetOn = LockPreviousNextMonthTimesheetOn
            .EnableBalanceValidationForTimeOff = EnableBalanceValidationForTimeOff
            .LockAllPeriodExceptPrevious = LockAllPeriodExceptPrevious
            .LockAllPeriodExceptNext = LockAllPeriodExceptNext
            .ShowClockStartEndEmployee = ShowClockStartEndEmployee
        End With

        dtWorkingDay.AddAccountWorkingDayTypeRow(drWorkingDay)
        Dim rowsAffected As Integer = Adapter.Update(dtWorkingDay)
        System.Web.HttpContext.Current.Session.Add("AccountWorkingDayTypeId", AccountWorkingDayTypeId)
        Return rowsAffected = 1
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountWorkingDayType( _
                ByVal AccountWorkingDayType As String, ByVal WeekStartDay As System.Nullable(Of Short), _
                ByVal ModifiedByEmployeeId As Integer, ByVal HoursPerDay As Double, ByVal MinimumHoursPerDay As Double, ByVal MaximumHoursPerDay As Double, _
                ByVal MinimumHoursPerWeek As Double, ByVal MaximumHoursPerWeek As Double, _
                ByVal IsDisabled As Boolean, ByVal Original_AccountWorkingDayTypeId As Guid, ByVal AccountTimesheetPeriodTypeId As Guid, ByVal TimesheetOverdueAfterDays As Short, _
                ByVal MinimumPercentagePerDay As Integer, ByVal MaximumPercentagePerDay As Integer, _
                ByVal MinimumPercentagePerWeek As Integer, ByVal MaximumPercentagePerWeek As Integer, ByVal LockAllPreviousTimesheets As Boolean, _
                ByVal LockAllFutureTimesheets As Boolean, ByVal LockPreviousTimesheetPeriods As Integer, ByVal LockFutureTimsheetPeriods As Integer, _
                ByVal LockPreviousNextMonthTimesheetOn As Integer, ByVal EnableBalanceValidationForTimeOff As Boolean, ByVal LockAllPeriodExceptPrevious As Integer, ByVal LockAllPeriodExceptNext As Integer, ByVal ShowClockStartEndEmployee As Boolean) As Boolean

        _AccountWorkingDayTypeTableAdapter = New AccountWorkingDayTypeTableAdapter

        Dim dtWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeDataTable = Adapter.GetDataByAccountWorkingDayTypeId(Original_AccountWorkingDayTypeId)
        Dim drWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeRow = dtWorkingDay.Rows(0)

        With drWorkingDay
            .AccountWorkingDayType = AccountWorkingDayType
            .WeekStartDay = WeekStartDay
            .HoursPerDay = HoursPerDay
            .MinimumHoursPerDay = MinimumHoursPerDay
            .MaximumHoursPerDay = MaximumHoursPerDay
            .MinimumHoursPerWeek = MinimumHoursPerWeek
            .MaximumHoursPerWeek = MaximumHoursPerWeek
            .MinimumPercentagePerDay = MinimumPercentagePerDay
            .MaximumPercentagePerDay = MaximumPercentagePerDay
            .MinimumPercentagePerWeek = MinimumPercentagePerWeek
            .MaximumPercentagePerWeek = MaximumPercentagePerWeek
            .ModifiedByEmployeeId = ModifiedByEmployeeId
            .ModifiedOn = Now
            .IsDisabled = IsDisabled
            .AccountTimesheetPeriodTypeId = AccountTimesheetPeriodTypeId
            .TimesheetOverdueAfterDays = TimesheetOverdueAfterDays
            .LockAllPreviousTimesheets = LockAllPreviousTimesheets
            .LockAllFutureTimesheets = LockAllFutureTimesheets
            .LockPreviousTimesheetPeriods = LockPreviousTimesheetPeriods
            .LockFutureTimsheetPeriods = LockFutureTimsheetPeriods
            .LockPreviousNextMonthTimesheetOn = LockPreviousNextMonthTimesheetOn
            .EnableBalanceValidationForTimeOff = EnableBalanceValidationForTimeOff
            .LockAllPeriodExceptPrevious = LockAllPeriodExceptPrevious
            .LockAllPeriodExceptNext = LockAllPeriodExceptNext
            .ShowClockStartEndEmployee = ShowClockStartEndEmployee
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtWorkingDay)
        Dim bll As New AccountEmployeeBLL
        If bll.GetAccountWorkingDayTypeIdByEmployeeId(DBUtilities.GetSessionAccountEmployeeId) = Original_AccountWorkingDayTypeId Then
            Me.AddSessionValuesForWorkingDayType(False, Original_AccountWorkingDayTypeId, 0)
        End If
        Return rowsAffected = 1
    End Function
    Public Sub AddSessionValuesForWorkingDayType(ByVal IsEmployee As Boolean, ByVal AccountWorkingDayTypeId As Guid, ByVal AccountEmployeeId As Integer)
        Dim dt As AccountWorkingDayType.vueAccountWorkingDayTypeDataTable = Me.GetvueAccountWorkingDayTypeByAccountWorkingDayTypeId(AccountWorkingDayTypeId)
        Dim dr As AccountWorkingDayType.vueAccountWorkingDayTypeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            If IsEmployee = True And AccountEmployeeId = DBUtilities.GetSessionAccountEmployeeId Then
                System.Web.HttpContext.Current.Session.Add("EmployeeWeekStartDay", dr.WeekStartDay)
                System.Web.HttpContext.Current.Session.Add("EmployeeTimesheetPeriodType", dr.SystemTimesheetPeriodType)

            ElseIf IsEmployee = False Then
                System.Web.HttpContext.Current.Session.Add("EmployeeWeekStartDay", dr.WeekStartDay)
                System.Web.HttpContext.Current.Session.Add("EmployeeTimesheetPeriodType", dr.SystemTimesheetPeriodType)
                System.Web.HttpContext.Current.Session.Add("MinimumHoursPerDay", dr.MinimumHoursPerDay)
                System.Web.HttpContext.Current.Session.Add("MaximumHoursPerDay", dr.MaximumHoursPerDay)
                System.Web.HttpContext.Current.Session.Add("MinimumHoursPerWeek", dr.MinimumHoursPerWeek)
                System.Web.HttpContext.Current.Session.Add("MaximumHoursPerWeek", dr.MaximumHoursPerWeek)
                System.Web.HttpContext.Current.Session.Add("MinimumPercentagePerDay", dr.MinimumPercentagePerDay)
                System.Web.HttpContext.Current.Session.Add("MaximumPercentagePerDay", dr.MaximumPercentagePerDay)
                System.Web.HttpContext.Current.Session.Add("MinimumPercentagePerWeek", dr.MinimumPercentagePerWeek)
                System.Web.HttpContext.Current.Session.Add("MaximumPercentagePerWeek", dr.MaximumPercentagePerWeek)
                System.Web.HttpContext.Current.Session.Add("HoursPerDay", dr.HoursPerDay)
                System.Web.HttpContext.Current.Session.Add("TimesheetOverdueAfterDays", dr.TimesheetOverdueAfterDays)
                System.Web.HttpContext.Current.Session.Add("LockAllPreviousTimesheets", dr.LockAllPreviousTimesheets)
                System.Web.HttpContext.Current.Session.Add("LockAllFutureTimesheets", dr.LockAllFutureTimesheets)
                System.Web.HttpContext.Current.Session.Add("LockPreviousTimesheetPeriods", dr.LockPreviousTimesheetPeriods)
                System.Web.HttpContext.Current.Session.Add("LockFutureTimsheetPeriods", dr.LockFutureTimsheetPeriods)
                System.Web.HttpContext.Current.Session.Add("LockPreviousNextMonthTimesheetOn", dr.LockPreviousNextMonthTimesheetOn)
                System.Web.HttpContext.Current.Session.Add("EnableBalanceValidationForTimeOff", dr.EnableBalanceValidationForTimeOff)
                System.Web.HttpContext.Current.Session.Add("LockAllPeriodExceptPrevious", dr.LockAllPeriodExceptPrevious)
                System.Web.HttpContext.Current.Session.Add("LockAllPeriodExceptNext", dr.LockAllPeriodExceptNext)
                System.Web.HttpContext.Current.Session.Add("ShowClockStartEndEmployee", dr.ShowClockStartEndEmployee)
            End If
        End If
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, True)> _
    Public Function DeleteAccountWorkingDayType(ByVal Original_AccountWorkingDayTypeId As Guid) As Boolean
        Try
            Dim rowsAffected As Integer = Adapter.Delete(Original_AccountWorkingDayTypeId)
            Return rowsAffected = 1
        Catch ex As Exception
            Throw New Exception("Can’t delete. Dependent data is exist with this record.")
        End Try
    End Function
    Public Function InsertDefault(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, Optional ByVal UserInterfaceLanguage As String = "") As Guid
        If IsExistMasterRecordInWorkingDayType(AccountId) = False Then
            Adapter.InsertDefault(AccountId, AccountEmployeeId)
            If Not LocaleUtilitiesBLL.IsEnglishCultureString(UserInterfaceLanguage) Then
                Me.ChangeWorkingDayTypeByUICulture(AccountId)
            End If
        End If
        Return GetDefaultAccountWorkingDayTypeId(AccountId)
    End Function
    Public Function GetDefaultAccountWorkingDayTypeId(ByVal AccountId As Integer)
        Dim MasterWorkingDayTypeId As New Guid("06DDC13D-7195-489D-A7E7-935567B7A285")
        Dim dt As AccountWorkingDayType.AccountWorkingDayTypeDataTable = Adapter.GetDataByMasterWorkingDayTypeIdAndAccountId(MasterWorkingDayTypeId, AccountId)
        Dim dr As AccountWorkingDayType.AccountWorkingDayTypeRow
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)
            Return dr.AccountWorkingDayTypeId
        End If
    End Function
    Public Sub ChangeWorkingDayTypeByUICulture(ByVal AccountId As Integer)
        Dim dtWorkingDayType As AccountWorkingDayType.AccountWorkingDayTypeDataTable = Me.GetAccountWorkingDayTypeByAccountId(AccountId)
        Dim drWorkingDayType As AccountWorkingDayType.AccountWorkingDayTypeRow
        For Each drWorkingDayType In dtWorkingDayType.Rows
            Me.UpdateAccountWorkingDayTypeName(ResourceHelper.GetDefaultDataLocalValue(drWorkingDayType.AccountWorkingDayType), drWorkingDayType.AccountWorkingDayTypeId)
        Next
    End Sub
    Public Sub UpdateWeekStartDay(ByVal AccountId As Integer)
        Adapter.UpdateQuery(DBUtilities.GetSessionAccountId)
    End Sub
    Public Function IsExistMasterRecordInWorkingDayType(ByVal AccountId As Integer) As Boolean
        Dim MasterWorkingDayTypeId As New Guid("06DDC13D-7195-489D-A7E7-935567B7A285")
        If Adapter.GetDataByMasterWorkingDayTypeIdAndAccountId(MasterWorkingDayTypeId, AccountId).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Sub UpdateAccounTimesheetPeriodTypeId(ByVal AccountId As Integer)
        Adapter.UpdateAccountTimesheetPeriodTypeId(AccountId)
    End Sub
    Public Sub UpdateAccountWorkingDayTypes(ByVal ShowClockStartEndBy As Boolean, ByVal AccountId As Integer)
        Adapter.UpdateShowClockStartEndEmployee(ShowClockStartEndBy, AccountId)
    End Sub
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, True)> _
    Public Function UpdateAccountWorkingDayTypeName( _
                ByVal AccountWorkingDayType As String, Original_AccountWorkingDayTypeId As Guid) As Boolean

        _AccountWorkingDayTypeTableAdapter = New AccountWorkingDayTypeTableAdapter

        Dim dtWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeDataTable = Adapter.GetDataByAccountWorkingDayTypeId(Original_AccountWorkingDayTypeId)
        Dim drWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeRow = dtWorkingDay.Rows(0)

        With drWorkingDay
            .AccountWorkingDayType = AccountWorkingDayType
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtWorkingDay)
        Return rowsAffected = 1
    End Function
    Public Sub UpdateWorkindDayFromWizard(AccountWorkingDayTypeId As Guid, AccountTimesheetPeriodTypeId As Guid)
        Dim dtWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeDataTable = Adapter.GetDataByAccountWorkingDayTypeId(AccountWorkingDayTypeId)
        Dim drWorkingDay As AccountWorkingDayType.AccountWorkingDayTypeRow = dtWorkingDay.Rows(0)
        With drWorkingDay
            .AccountTimesheetPeriodTypeId = AccountTimesheetPeriodTypeId
        End With
        Dim rowsAffected As Integer = Adapter.Update(dtWorkingDay)
    End Sub
    Public Sub UpdateEnableBalanceValidation(ByVal EnableBalanceValidation As Boolean, ByVal AccountId As Integer)
        Adapter.UpdateEnableBalanceValidation(EnableBalanceValidation, AccountId)
    End Sub
End Class