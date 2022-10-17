Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace AccountEmployeeTimeEntryTableAdapters
    Partial Public Class AccountEmployeeTimeEntryTableAdapter

        Public Function TimeEntryInsert(
                           ByVal AccountEmployeeId As System.Nullable(Of Integer),
                           ByVal TimeEntryDate As DateTime,
                           ByVal StartTime As String,
                           ByVal EndTime As String,
                           ByVal TotalTime As String,
                           ByVal AccountProjectId As Integer,
                           ByVal AccountProjectTaskId As Integer,
                           ByVal Description As String,
                           ByVal Approved As Boolean,
                           ByVal CreatedOn As Date,
                           ByVal ModifiedOn As DateTime,
                           ByVal AccountPartyId As Integer,
                           ByVal Submitted As Boolean,
                           ByVal AccountWorkTypeId As Integer,
                           ByVal AccountCostCenterId As Integer,
                           ByVal AccountEmployeeTimeEntryPeriodId As Guid,
                           ByVal IsTimeOff As Boolean,
                           ByVal AccountTimeOffTypeId As Guid,
                           ByVal AccountEmployeeTimeOffRequestId As Guid,
                           ByVal BillingRate As Double,
                           ByVal EmployeeRate As Double,
                           ByVal BillingRateCurrencyId As Integer,
                           ByVal EmployeeRateCurrencyId As Integer,
                           ByVal BillingRateExchangeRate As Double,
                           ByVal EmployeeRateExchangeRate As Double,
                           ByVal AccountBaseCurrencyId As Double,
                           ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid,
                           ByVal Percentage As Double,
                           ByVal Hours As Decimal,
                           ByVal IsFixedBid As Boolean,
                           Optional ByVal CustomField1 As String = "",
                           Optional ByVal CustomField2 As String = "",
                           Optional ByVal CustomField3 As String = "",
                           Optional ByVal CustomField4 As String = "",
                           Optional ByVal CustomField5 As String = "",
                           Optional ByVal CustomField6 As String = "",
                           Optional ByVal CustomField7 As String = "",
                           Optional ByVal CustomField8 As String = "",
                           Optional ByVal CustomField9 As String = "",
                           Optional ByVal CustomField10 As String = "",
                           Optional ByVal CustomField11 As String = "",
                           Optional ByVal CustomField12 As String = "",
                           Optional ByVal CustomField13 As String = "",
                           Optional ByVal CustomField14 As String = "",
                           Optional ByVal CustomField15 As String = ""
                           ) As Integer

            Me.Adapter.InsertCommand = New SqlCommand("", Me.Connection)
            Dim TimeEntryBLL As New AccountEmployeeTimeEntryBLL

            Dim sql As String = "INSERT INTO AccountEmployeeTimeEntry (AccountEmployeeId, TimeEntryDate, StartTime, EndTime, TotalTime, AccountProjectId, AccountProjectTaskId, Description, Approved, CreatedOn, ModifiedOn, TeamLeadApproved, ProjectManagerApproved, AdministratorApproved, Rejected, BillingRate, AccountPartyId, Submitted, AccountWorkTypeId, EmployeeRate, AccountCostCenterId, BillingRateCurrencyId, EmployeeRateCurrencyId, BillingRateExchangeRate, EmployeeRateExchangeRate, AccountBaseCurrencyId, AccountEmployeeTimeEntryPeriodId, Billed, CreatedByEmployeeId, ModifiedByEmployeeId, IsTimeOff, AccountTimeOffTypeId, AccountEmployeeTimeOffRequestId, AccountEmployeeTimeEntryApprovalProjectId, IsTimeOffConsumed, Percentage, Hours, CustomField1, CustomField2, CustomField3, CustomField4, CustomField5, CustomField6, CustomField7, CustomField8, CustomField9, CustomField10, CustomField11, CustomField12, CustomField13, CustomField14, CustomField15, IsFixedBid) " &
                " VALUES (@AccountEmployeeId, @TimeEntryDate, @StartTime, @EndTime, @TotalTime, @AccountProjectId, @AccountProjectTaskId, @Description, @Approved, getdate(), getdate(), 0, 0, 0, 0, @BillingRate, @AccountPartyId, @Submitted, @AccountWorkTypeId, @EmployeeRate, @AccountCostCenterId, @BillingRateCurrencyId, @EmployeeRateCurrencyId, @BillingRateExchangeRate, @EmployeeRateExchangeRate, @AccountBaseCurrencyId, @AccountEmployeeTimeEntryPeriodId, 0, @CreatedByEmployeeId, @ModifiedByEmployeeId, @IsTimeOff, @AccountTimeOffTypeId, @AccountEmployeeTimeOffRequestId, @AccountEmployeeTimeEntryApprovalProjectId, @IsTimeOffConsumed, @Percentage, @Hours, @CustomField1, @CustomField2, @CustomField3, @CustomField4, @CustomField5, @CustomField6, @CustomField7, @CustomField8, @CustomField9, @CustomField10, @CustomField11, @CustomField12, @CustomField13, @CustomField14, @CustomField15, @IsFixedBid); " &
                " SELECT SCOPE_IDENTITY()"

            Me.Adapter.InsertCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Me.Adapter.InsertCommand.Parameters.Add("@TimeEntryDate", SqlDbType.DateTime)
            Me.Adapter.InsertCommand.Parameters("@TimeEntryDate").Value = TimeEntryDate

            Me.Adapter.InsertCommand.Parameters.Add("@StartTime", SqlDbType.DateTime)
            Me.Adapter.InsertCommand.Parameters("@StartTime").Value = IIf(StartTime Is Nothing, System.DBNull.Value, StartTime)

            Me.Adapter.InsertCommand.Parameters.Add("@EndTime", SqlDbType.DateTime)
            Me.Adapter.InsertCommand.Parameters("@EndTime").Value = IIf(EndTime Is Nothing, System.DBNull.Value, EndTime)

            Me.Adapter.InsertCommand.Parameters.Add("@TotalTime", SqlDbType.DateTime)
            Me.Adapter.InsertCommand.Parameters("@TotalTime").Value = TotalTime

            Me.Adapter.InsertCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@AccountProjectId").Value = IIf(AccountProjectId = 0, System.DBNull.Value, AccountProjectId)

            Me.Adapter.InsertCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@AccountProjectTaskId").Value = IIf(AccountProjectTaskId = 0, System.DBNull.Value, AccountProjectTaskId)

            Me.Adapter.InsertCommand.Parameters.Add("@Description", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@Description").Value = IIf(Description Is Nothing, System.DBNull.Value, Description)

            Me.Adapter.InsertCommand.Parameters.Add("@Approved", SqlDbType.Bit)
            Me.Adapter.InsertCommand.Parameters("@Approved").Value = Approved

            Me.Adapter.InsertCommand.Parameters.Add("@BillingRate", SqlDbType.Float)
            Me.Adapter.InsertCommand.Parameters("@BillingRate").Value = IIf(BillingRate = 0, 0, BillingRate)

            Me.Adapter.InsertCommand.Parameters.Add("@AccountPartyId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@AccountPartyId").Value = IIf(AccountPartyId = 0, 0, AccountPartyId)

            Me.Adapter.InsertCommand.Parameters.Add("@Submitted", SqlDbType.Bit)
            Me.Adapter.InsertCommand.Parameters("@Submitted").Value = Submitted

            Me.Adapter.InsertCommand.Parameters.Add("@AccountWorkTypeId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@AccountWorkTypeId").Value = IIf(AccountWorkTypeId = 0, System.DBNull.Value, AccountWorkTypeId)

            Me.Adapter.InsertCommand.Parameters.Add("@EmployeeRate", SqlDbType.Float)
            Me.Adapter.InsertCommand.Parameters("@EmployeeRate").Value = IIf(EmployeeRate = 0, 0, EmployeeRate)

            Me.Adapter.InsertCommand.Parameters.Add("@AccountCostCenterId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@AccountCostCenterId").Value = IIf(AccountCostCenterId = 0, System.DBNull.Value, AccountCostCenterId)

            Me.Adapter.InsertCommand.Parameters.Add("@BillingRateCurrencyId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@BillingRateCurrencyId").Value = IIf(BillingRateCurrencyId = 0, System.DBNull.Value, BillingRateCurrencyId)

            Me.Adapter.InsertCommand.Parameters.Add("@EmployeeRateCurrencyId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@EmployeeRateCurrencyId").Value = IIf(EmployeeRateCurrencyId = 0, System.DBNull.Value, EmployeeRateCurrencyId)

            Me.Adapter.InsertCommand.Parameters.Add("@BillingRateExchangeRate", SqlDbType.Float)
            Me.Adapter.InsertCommand.Parameters("@BillingRateExchangeRate").Value = IIf(BillingRateExchangeRate = 0, System.DBNull.Value, BillingRateExchangeRate)

            Me.Adapter.InsertCommand.Parameters.Add("@EmployeeRateExchangeRate", SqlDbType.Float)
            Me.Adapter.InsertCommand.Parameters("@EmployeeRateExchangeRate").Value = IIf(EmployeeRateExchangeRate = 0, System.DBNull.Value, EmployeeRateExchangeRate)

            Me.Adapter.InsertCommand.Parameters.Add("@AccountBaseCurrencyId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@AccountBaseCurrencyId").Value = IIf(AccountBaseCurrencyId = 0, System.DBNull.Value, AccountBaseCurrencyId)

            Me.Adapter.InsertCommand.Parameters.Add("@AccountEmployeeTimeEntryPeriodId", SqlDbType.UniqueIdentifier)
            Me.Adapter.InsertCommand.Parameters("@AccountEmployeeTimeEntryPeriodId").Value = AccountEmployeeTimeEntryPeriodId

            Me.Adapter.InsertCommand.Parameters.Add("@CreatedByEmployeeId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@CreatedByEmployeeId").Value = IIf(Not System.Web.HttpContext.Current.Session Is Nothing, DBUtilities.GetSessionAccountEmployeeId, AccountEmployeeId)

            Me.Adapter.InsertCommand.Parameters.Add("@ModifiedByEmployeeId", SqlDbType.Int)
            Me.Adapter.InsertCommand.Parameters("@ModifiedByEmployeeId").Value = IIf(Not System.Web.HttpContext.Current.Session Is Nothing, DBUtilities.GetSessionAccountEmployeeId, AccountEmployeeId)

            Me.Adapter.InsertCommand.Parameters.Add("@IsTimeOff", SqlDbType.Bit)
            Me.Adapter.InsertCommand.Parameters("@IsTimeOff").Value = IsTimeOff

            Me.Adapter.InsertCommand.Parameters.Add("@AccountTimeOffTypeId", SqlDbType.UniqueIdentifier)
            Me.Adapter.InsertCommand.Parameters("@AccountTimeOffTypeId").Value = IIf(IsTimeOff, AccountTimeOffTypeId, System.DBNull.Value)

            Me.Adapter.InsertCommand.Parameters.Add("@AccountEmployeeTimeOffRequestId", SqlDbType.UniqueIdentifier)
            Me.Adapter.InsertCommand.Parameters("@AccountEmployeeTimeOffRequestId").Value = IIf(AccountEmployeeTimeOffRequestId <> System.Guid.Empty, AccountEmployeeTimeOffRequestId, System.DBNull.Value)

            Me.Adapter.InsertCommand.Parameters.Add("@AccountEmployeeTimeEntryApprovalProjectId", SqlDbType.UniqueIdentifier)
            Me.Adapter.InsertCommand.Parameters("@AccountEmployeeTimeEntryApprovalProjectId").Value = IIf(AccountEmployeeTimeEntryApprovalProjectId <> System.Guid.Empty, AccountEmployeeTimeEntryApprovalProjectId, System.DBNull.Value)

            Me.Adapter.InsertCommand.Parameters.Add("@IsTimeOffConsumed", SqlDbType.Bit)
            Me.Adapter.InsertCommand.Parameters("@IsTimeOffConsumed").Value = False

            Me.Adapter.InsertCommand.Parameters.Add("@Percentage", SqlDbType.Decimal)
            Me.Adapter.InsertCommand.Parameters("@Percentage").Value = Percentage

            Me.Adapter.InsertCommand.Parameters.Add("@Hours", SqlDbType.Decimal)
            Me.Adapter.InsertCommand.Parameters("@Hours").Value = Hours

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField1", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField1").Value = IIf(CustomField1 = "", System.DBNull.Value, CustomField1)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField2", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField2").Value = IIf(CustomField2 = "", System.DBNull.Value, CustomField2)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField3", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField3").Value = IIf(CustomField3 = "", System.DBNull.Value, CustomField3)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField4", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField4").Value = IIf(CustomField4 = "", System.DBNull.Value, CustomField4)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField5", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField5").Value = IIf(CustomField5 = "", System.DBNull.Value, CustomField5)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField6", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField6").Value = IIf(CustomField6 = "", System.DBNull.Value, CustomField6)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField7", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField7").Value = IIf(CustomField7 = "", System.DBNull.Value, CustomField7)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField8", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField8").Value = IIf(CustomField8 = "", System.DBNull.Value, CustomField8)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField9", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField9").Value = IIf(CustomField9 = "", System.DBNull.Value, CustomField9)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField10", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField10").Value = IIf(CustomField10 = "", System.DBNull.Value, CustomField10)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField11", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField11").Value = IIf(CustomField11 = "", System.DBNull.Value, CustomField11)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField12", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField12").Value = IIf(CustomField12 = "", System.DBNull.Value, CustomField12)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField13", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField13").Value = IIf(CustomField13 = "", System.DBNull.Value, CustomField13)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField14", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField14").Value = IIf(CustomField14 = "", System.DBNull.Value, CustomField14)

            Me.Adapter.InsertCommand.Parameters.Add("@CustomField15", SqlDbType.NVarChar)
            Me.Adapter.InsertCommand.Parameters("@CustomField15").Value = IIf(CustomField15 = "", System.DBNull.Value, CustomField15)

            Me.Adapter.InsertCommand.Parameters.Add("@IsFixedBid", SqlDbType.Bit)
            Me.Adapter.InsertCommand.Parameters("@IsFixedBid").Value = IsFixedBid


            LoggingBLL.WriteToLog("PartialClassFunction-TimeEntryInsert: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " &
                                  DBUtilities.GetSessionAccountEmployeeId & " TimeEntryDate=" & TimeEntryDate &
                                  " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" &
                                  AccountEmployeeTimeEntryApprovalProjectId.ToString)

            Me.Adapter.InsertCommand.CommandText = sql
            Me.Connection.Open()
            Dim InsertedAccountEmployeeTimeEntryId As Integer = Me.Adapter.InsertCommand.ExecuteScalar()
            Me.Connection.Close()
            Return InsertedAccountEmployeeTimeEntryId
        End Function
        Public Function TimeEntryUpdate( _
        ByVal AccountEmployeeId As System.Nullable(Of Integer), _
                           ByVal TimeEntryDate As DateTime, _
                           ByVal StartTime As String, _
                           ByVal EndTime As String, _
                           ByVal TotalTime As String, _
                           ByVal AccountProjectId As Integer, _
                           ByVal AccountProjectTaskId As Integer, _
                           ByVal Description As String, _
                           ByVal Approved As Boolean, _
                           ByVal ModifiedOn As Date, _
                           ByVal Submitted As Boolean, _
                           ByVal Rejected As Boolean, _
                           ByVal AccountWorkTypeId As Integer, _
                           ByVal AccountCostCenterId As Integer, _
                           ByVal AccountEmployeeTimeEntryPeriodId As Guid, _
                           ByVal IsTimeOff As Boolean, _
                           ByVal AccountTimeOffTypeId As Guid, _
                           ByVal BillingRate As Double, _
                           ByVal EmployeeRate As Double, _
                           ByVal BillingRateCurrencyId As Integer, _
                           ByVal EmployeeRateCurrencyId As Integer, _
                           ByVal BillingRateExchangeRate As Double, _
                           ByVal EmployeeRateExchangeRate As Double, _
                           ByVal AccountBaseCurrencyId As Double, _
                           ByVal AccountEmployeeTimeEntryApprovalProjectId As Guid, _
                           ByVal Original_AccountEmployeeTimeEntryid As Integer, _
                           ByVal Percentage As Double, _
                           ByVal Hours As Decimal, _
                           ByVal IsFixedBid As Boolean, _
                           ByVal AccountPartyId As Integer, _
                           Optional ByVal CustomField1 As String = "", _
                           Optional ByVal CustomField2 As String = "", _
                           Optional ByVal CustomField3 As String = "", _
                           Optional ByVal CustomField4 As String = "", _
                           Optional ByVal CustomField5 As String = "", _
                           Optional ByVal CustomField6 As String = "", _
                           Optional ByVal CustomField7 As String = "", _
                           Optional ByVal CustomField8 As String = "", _
                           Optional ByVal CustomField9 As String = "", _
                           Optional ByVal CustomField10 As String = "", _
                           Optional ByVal CustomField11 As String = "", _
                           Optional ByVal CustomField12 As String = "", _
                           Optional ByVal CustomField13 As String = "", _
                           Optional ByVal CustomField14 As String = "", _
                           Optional ByVal CustomField15 As String = "" _
                           ) As Integer

            Dim command As SqlCommand
            Dim AsyncConnection As SqlConnection
            AsyncConnection = New SqlConnection(DBUtilities.GetConnectionString & ";Async=true;")
            command = New SqlCommand("sp_UpdateTimeEntry", AsyncConnection)
            LoggingBLL.WriteToLog("PartialClassFunction-TimeEntryUpdate: AccountEmployeeId=" & AccountEmployeeId & " Session-AccountEmployeeId= " & _
                                  DBUtilities.GetSessionAccountEmployeeId & " TimeEntryDate=" & TimeEntryDate & _
                                  " AccountEmployeeTimeEntryPeriodId=" & AccountEmployeeTimeEntryPeriodId.ToString & " AccountEmployeeTimeEntryApprovalProjectId=" & _
                                  AccountEmployeeTimeEntryApprovalProjectId.ToString & " Original_AccountEmployeeTimeEntryid=" & Original_AccountEmployeeTimeEntryid)
            Dim ST As Date
            Dim ET As Date
            If StartTime Is Nothing Then
                StartTime = ""
            Else
                ST = CDate(StartTime)
            End If
            If EndTime Is Nothing Then
                EndTime = ""
            Else
                ET = CDate(EndTime)
            End If
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Clear()
            command.Parameters.AddWithValue("@AccountEmployeeId", AccountEmployeeId)
            command.Parameters.AddWithValue("@TimeEntryDate", TimeEntryDate)
            command.Parameters.AddWithValue("@StartTime", IIf(StartTime = "", System.DBNull.Value, ST))
            command.Parameters.AddWithValue("@EndTime", IIf(EndTime = "", System.DBNull.Value, ET))
            command.Parameters.AddWithValue("@TotalTime", CDate(TotalTime))
            command.Parameters.AddWithValue("@AccountProjectId", IIf(AccountProjectId = 0, System.DBNull.Value, AccountProjectId))
            command.Parameters.AddWithValue("@AccountProjectTaskId", IIf(AccountProjectTaskId = 0, System.DBNull.Value, AccountProjectTaskId))
            command.Parameters.AddWithValue("@Description", IIf(Description Is Nothing, System.DBNull.Value, Description))
            command.Parameters.AddWithValue("@Approved", Approved)
            command.Parameters.AddWithValue("@ModifiedOn", Now)
            command.Parameters.AddWithValue("@Rejected", Rejected)
            command.Parameters.AddWithValue("@BillingRate", IIf(BillingRate = 0, 0, BillingRate))
            command.Parameters.AddWithValue("@Submitted", Submitted)
            command.Parameters.AddWithValue("@AccountWorkTypeId", IIf(AccountWorkTypeId = 0, System.DBNull.Value, AccountWorkTypeId))
            command.Parameters.AddWithValue("@EmployeeRate", IIf(EmployeeRate = 0, 0, EmployeeRate))
            command.Parameters.AddWithValue("@AccountCostCenterId", IIf(AccountCostCenterId = 0, System.DBNull.Value, AccountCostCenterId))
            command.Parameters.AddWithValue("@BillingRateCurrencyId", IIf(BillingRateCurrencyId = 0, System.DBNull.Value, BillingRateCurrencyId))
            command.Parameters.AddWithValue("@EmployeeRateCurrencyId", IIf(EmployeeRateCurrencyId = 0, System.DBNull.Value, EmployeeRateCurrencyId))
            command.Parameters.AddWithValue("@BillingRateExchangeRate", IIf(BillingRateExchangeRate = 0, System.DBNull.Value, BillingRateExchangeRate))
            command.Parameters.AddWithValue("@EmployeeRateExchangeRate", IIf(EmployeeRateExchangeRate = 0, System.DBNull.Value, EmployeeRateExchangeRate))
            command.Parameters.AddWithValue("@AccountBaseCurrencyId", IIf(AccountBaseCurrencyId = 0, System.DBNull.Value, AccountBaseCurrencyId))
            command.Parameters.AddWithValue("@AccountEmployeeTimeEntryPeriodId", AccountEmployeeTimeEntryPeriodId)
            command.Parameters.AddWithValue("@AccountEmployeeTimeEntryApprovalProjectId", IIf(AccountEmployeeTimeEntryApprovalProjectId <> System.Guid.Empty, AccountEmployeeTimeEntryApprovalProjectId, System.DBNull.Value))
            command.Parameters.AddWithValue("@ModifiedByEmployeeId", DBUtilities.GetSessionAccountEmployeeId)
            command.Parameters.AddWithValue("@IsTimeOff", IsTimeOff)
            command.Parameters.AddWithValue("@AccountTimeOffTypeId", IIf(IsTimeOff, AccountTimeOffTypeId, System.DBNull.Value))
            command.Parameters.AddWithValue("@AccountEmployeeTimeEntryId", Original_AccountEmployeeTimeEntryid)
            command.Parameters.AddWithValue("@Percentage", Percentage)
            command.Parameters.AddWithValue("@Hours", Hours)
            command.Parameters.AddWithValue("@IsFixedBid", IsFixedBid)
            command.Parameters.AddWithValue("@AccountPartyId", AccountPartyId)
            command.Parameters.AddWithValue("@CustomField1", IIf(CustomField1 = "", System.DBNull.Value, CustomField1))
            command.Parameters.AddWithValue("@CustomField2", IIf(CustomField2 = "", System.DBNull.Value, CustomField2))
            command.Parameters.AddWithValue("@CustomField3", IIf(CustomField3 = "", System.DBNull.Value, CustomField3))
            command.Parameters.AddWithValue("@CustomField4", IIf(CustomField4 = "", System.DBNull.Value, CustomField4))
            command.Parameters.AddWithValue("@CustomField5", IIf(CustomField5 = "", System.DBNull.Value, CustomField5))
            command.Parameters.AddWithValue("@CustomField6", IIf(CustomField6 = "", System.DBNull.Value, CustomField6))
            command.Parameters.AddWithValue("@CustomField7", IIf(CustomField7 = "", System.DBNull.Value, CustomField7))
            command.Parameters.AddWithValue("@CustomField8", IIf(CustomField8 = "", System.DBNull.Value, CustomField8))
            command.Parameters.AddWithValue("@CustomField9", IIf(CustomField9 = "", System.DBNull.Value, CustomField9))
            command.Parameters.AddWithValue("@CustomField10", IIf(CustomField10 = "", System.DBNull.Value, CustomField10))
            command.Parameters.AddWithValue("@CustomField11", IIf(CustomField11 = "", System.DBNull.Value, CustomField11))
            command.Parameters.AddWithValue("@CustomField12", IIf(CustomField12 = "", System.DBNull.Value, CustomField12))
            command.Parameters.AddWithValue("@CustomField13", IIf(CustomField13 = "", System.DBNull.Value, CustomField13))
            command.Parameters.AddWithValue("@CustomField14", IIf(CustomField14 = "", System.DBNull.Value, CustomField14))
            command.Parameters.AddWithValue("@CustomField15", IIf(CustomField15 = "", System.DBNull.Value, CustomField15))
            AsyncConnection.Open()
            command.BeginExecuteNonQuery(AddressOf asyncCallback, command)
            'command.ExecuteNonQuery()
            'Me.Connection.Close()
            Return Original_AccountEmployeeTimeEntryid
        End Function
        Public Sub asyncCallback(result As IAsyncResult)
            Dim command As SqlCommand
            Try
                command = result.AsyncState
                command.EndExecuteNonQuery(result)
            Catch ex As Exception
                LoggingBLL.WriteToLog(command.CommandText & "_Exception_" & ex.Message)
                Throw ex
            Finally
                command.Connection.Close()
                command.Dispose()
            End Try
        End Sub
        Public Function UpdateTimeEntryCustomFieldByCustomFieldId(CustomFieldColumnName As String, AccountId As Integer)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "Update AccountEmployeeTimeEntry Set " & CustomFieldColumnName & " = NULL Where AccountProjectId in (Select AccountProjectId from AccountProject Where AccountId = " & AccountId & ")"
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Function
        Public Sub TimeEntriesUpdate(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "Execute sp_defix " & AccountId & ", " & AccountEmployeeId
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Sub
        Public Sub TimeEntriesUpdateAccount(ByVal AccountId As Integer)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "Execute sp_defixfullaccount " & AccountId
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 1000
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()
        End Sub
        Public Sub UpdateTimeEntryClientRecord(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal TimeEntryStartDate As String, ByVal TimeEntryEndDate As String)
            Dim objConnection As SqlConnection
            objConnection = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LiveConnectionString").ConnectionString)
            objConnection.Open()
            Dim sqlCommand As New SqlClient.SqlCommand
            sqlCommand.Connection = objConnection
            Dim strSQL As String = "Update AccountEmployeeTimeEntry Set dbo.AccountEmployeeTimeEntry.AccountPartyId = dbo.AccountProject.AccountClientId FROM dbo.AccountEmployeeTimeEntry " & _
                                    "INNER JOIN dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId " & _
                                    "WHERE (dbo.AccountEmployeeTimeEntry.AccountPartyId = 0 OR dbo.AccountEmployeeTimeEntry.AccountPartyId Is NULL) AND (dbo.AccountProject.AccountId = " & AccountId & ") AND (dbo.AccountEmployeeTimeEntry.AccountEmployeeId = " & AccountEmployeeId & ") AND (dbo.AccountEmployeeTimeEntry.TimeEntryDate >= " & TimeEntryStartDate & ") AND (dbo.AccountEmployeeTimeEntry.TimeEntryDate <= " & TimeEntryEndDate & ")"
            'sqlCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            'sqlCommand.Parameters("@AccountId").Value = AccountId
            'sqlCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            'sqlCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId
            'sqlCommand.Parameters.Add("@TimeEntryStartDate", SqlDbType.Date)
            'sqlCommand.Parameters("@TimeEntryStartDate").Value = TimeEntryStartDate
            'sqlCommand.Parameters.Add("@TimeEntryEndDate", SqlDbType.Date)
            'sqlCommand.Parameters("@TimeEntryEndDate").Value = TimeEntryEndDate
            sqlCommand.CommandText = strSQL
            sqlCommand.CommandTimeout = 99999
            Dim recordsAffected As Integer
            recordsAffected = sqlCommand.ExecuteNonQuery()
            objConnection.Close()

        End Sub
        Public Function GetDataByAccountIdAndDatabaseFieldName(ByVal AccountId As Integer, ByVal DatabaseFieldName As String)
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from AccountEmployeeTimeEntry "
            sql = sql & "WHERE  "
            If AccountId <> -1 Then
                sql = sql & "AccountEmployeeId in (select AccountEmployeeId from AccountEmployee where AccountId = " & AccountId & ") "
            End If

            sql = sql & "And " & DatabaseFieldName & " is not null "


            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable = New AccountEmployeeTimeEntry.AccountEmployeeTimeEntryDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace
