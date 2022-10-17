Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveDataSetTableAdapters
    Public Class AccountProjectTaskTimesheetTableAdapter
        Public Function GetAssignedProjectTasksFromvueAccountProjectTask(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal Completed As Boolean, Optional ByVal IsFromCSV As Boolean = False, Optional ByVal TaskName As String = "") As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT AccountProjectTaskId, ParentAccountProjectTaskId, TaskName, TaskCode " & _
                    " FROM AccountProjectTask INNER JOIN AccountProject " & _
                    " ON AccountProjectTask.AccountProjectId = AccountProject.AccountProjectId " & _
                    " AND AccountProject.AccountId = @AccountId " & _
                    " WHERE "

            sql = sql + " ((AccountProject.IsDeleted <> 1 OR AccountProject.IsDeleted IS NULL) AND (IsParentTask <> 1) AND (AccountProjectTask.IsDisabled <> 1) AND (IsTemplate <> 1) AND "

            If Completed <> True Then
                sql = sql + " (AccountProjectTask.Completed = @Completed) AND "
            End If

            sql = sql + " (((IsForAllProjectTask = 1) AND (AccountProjectTaskId IN (SELECT AccountProjectTaskId FROM " & _
                        " AccountProjectTaskEmployee WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                        " (AccountProjectTask.AccountProjectId = AccountProjectTask.AccountProjectId) AND  " & _
                        " (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (AccountProjectTask.AccountProjectId = @AccountProjectId)) OR "


            sql = sql + " ((IsForAllProjectTask = 1) AND (IsForAllEmployees = 1) AND (AccountProjectTask.AccountProjectId IN " & _
                        " (SELECT AccountProjectId FROM AccountProjectEmployee " & _
                        " WHERE (AccountProjectId = AccountProjectTask.AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllProjectTask IS NULL OR IsForAllProjectTask <> 1) AND (IsForAllEmployees IS NULL OR IsForAllEmployees <> 1) " & _
                        " AND (AccountProjectTaskId IN " & _
                        " (SELECT AccountProjectTaskId FROM AccountProjectTaskEmployee AS AccountProjectTaskEmployee_1 " & _
                        " WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                        " (AccountProjectTask.AccountProjectId = @AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (IsForAllProjectTask = 1) AND (AccountId = @AccountId)))) "

            If IsFromCSV Then
                sql = sql + " And ((TaskName = @TaskName)) "
                Me.Adapter.SelectCommand.Parameters.Add("@TaskName", SqlDbType.VarChar)
                Me.Adapter.SelectCommand.Parameters("@TaskName").Value = TaskName
            End If

            sql = sql + " OR ((AccountProjectTaskId = @AccountProjectTaskId)) "

            sql = sql + " ORDER BY TaskName "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Me.Adapter.SelectCommand.Parameters.Add("@Completed", SqlDbType.Bit)
            Me.Adapter.SelectCommand.Parameters("@Completed").Value = Completed

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable = New TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetAssignedProjectTasksFromvueAccountProjectTaskForTimesheetTaskDropdown(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectTaskId As Integer, ByVal Completed As Boolean, Optional ByVal IsFromCSV As Boolean = False, Optional ByVal TaskName As String = "") As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT AccountProjectTaskId, ParentAccountProjectTaskId, TaskName, TaskCode " & _
                    " FROM AccountProjectTask INNER JOIN AccountProject " & _
                    " ON AccountProjectTask.AccountProjectId = AccountProject.AccountProjectId " & _
                    "INNER JOIN AccountParty ON AccountParty.AccountPartyid = AccountProject.AccountClientId " & _
                    " AND AccountProject.AccountId = @AccountId " & _
                    " WHERE "

            sql = sql + " ((AccountProject.IsDeleted <> 1 OR AccountProject.IsDeleted IS NULL) AND (AccountParty.IsDeleted <> 1 OR AccountParty.IsDeleted IS NULL) AND (IsParentTask <> 1) AND (AccountProjectTask.IsDisabled <> 1) AND (AccountParty.IsDisabled <> 1) AND (AccountProject.IsDisabled <> 1) AND (IsTemplate <> 1) AND "

            If Completed <> True Then
                sql = sql + " (AccountProjectTask.Completed = @Completed) AND "
            End If

            sql = sql + " (((IsForAllProjectTask = 1) AND (AccountProjectTaskId IN (SELECT AccountProjectTaskId FROM " & _
                        " AccountProjectTaskEmployee WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                        " (AccountProjectTask.AccountProjectId = AccountProjectTask.AccountProjectId) AND  " & _
                        " (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1)) OR "


            sql = sql + " ((IsForAllProjectTask = 1) AND (IsForAllEmployees = 1) AND (AccountProjectTask.AccountProjectId IN " & _
                        " (SELECT AccountProjectId FROM AccountProjectEmployee " & _
                        " WHERE (AccountProjectId = AccountProjectTask.AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllProjectTask IS NULL OR IsForAllProjectTask <> 1) AND (IsForAllEmployees IS NULL OR IsForAllEmployees <> 1) " & _
                        " AND (AccountProjectTaskId IN " & _
                        " (SELECT AccountProjectTaskId FROM AccountProjectTaskEmployee AS AccountProjectTaskEmployee_1 " & _
                        " WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                        " (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (IsForAllProjectTask = 1) AND (AccountProject.AccountId = @AccountId)))) "

            If IsFromCSV Then
                sql = sql + " And ((TaskName = @TaskName)) "
                Me.Adapter.SelectCommand.Parameters.Add("@TaskName", SqlDbType.VarChar)
                Me.Adapter.SelectCommand.Parameters("@TaskName").Value = TaskName
            End If

            sql = sql + " OR ((AccountProjectTaskId = @AccountProjectTaskId)) "

            sql = sql + " ORDER BY TaskName "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId


            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Me.Adapter.SelectCommand.Parameters.Add("@Completed", SqlDbType.Bit)
            Me.Adapter.SelectCommand.Parameters("@Completed").Value = Completed

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable = New TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetAssignedProjectTasksFromvueAccountProjectTaskForCLient(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountClientId As Integer, ByVal AccountProjectTaskId As Integer, ByVal Completed As Boolean, Optional ByVal IsFromCSV As Boolean = False, Optional ByVal TaskName As String = "") As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT AccountProjectTaskId, ParentAccountProjectTaskId, TaskName, TaskCode " & _
                    " FROM AccountProjectTask INNER JOIN AccountProject " & _
                    " ON AccountProjectTask.AccountProjectId = AccountProject.AccountProjectId " & _
                    " AND AccountProject.AccountId = @AccountId " & _
                    " WHERE "

            sql = sql + " ((AccountProject.IsDeleted <> 1 OR AccountProject.IsDeleted IS NULL) AND (AccountProject.AccountClientId = @AccountClientId or (IsForAllClientProject = 1 and AccountProject.AccountId = @AccountId)) AND (IsParentTask <> 1) AND (AccountProjectTask.IsDisabled <> 1) AND (IsTemplate <> 1) AND "

            If Completed <> True Then
                sql = sql + " (AccountProjectTask.Completed = @Completed) AND "
            End If

            sql = sql + " (((IsForAllProjectTask = 1) AND (AccountProjectTaskId IN (SELECT AccountProjectTaskId FROM " & _
                        " AccountProjectTaskEmployee WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                        " (AccountProjectTask.AccountProjectId = AccountProjectTask.AccountProjectId) AND  " & _
                        " (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1)) OR "


            sql = sql + " ((IsForAllProjectTask = 1) AND (IsForAllEmployees = 1) AND (AccountProjectTask.AccountProjectId IN " & _
                        " (SELECT AccountProjectId FROM AccountProjectEmployee " & _
                        " WHERE (AccountProjectId = AccountProjectTask.AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllProjectTask IS NULL OR IsForAllProjectTask <> 1) AND (IsForAllEmployees IS NULL OR IsForAllEmployees <> 1) " & _
                        " AND (AccountProjectTaskId IN " & _
                        " (SELECT AccountProjectTaskId FROM AccountProjectTaskEmployee AS AccountProjectTaskEmployee_1 " & _
                        " WHERE (AccountProjectTaskId = AccountProjectTask.AccountProjectTaskId) AND " & _
                        " (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (IsForAllProjectTask = 1) AND (AccountId = @AccountId)))) "

            If IsFromCSV Then
                sql = sql + " And ((TaskName = @TaskName)) "
                Me.Adapter.SelectCommand.Parameters.Add("@TaskName", SqlDbType.VarChar)
                Me.Adapter.SelectCommand.Parameters("@TaskName").Value = TaskName
            End If

            sql = sql + " OR ((AccountProjectTaskId = @AccountProjectTaskId)) "

            sql = sql + " ORDER BY TaskName "

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountClientId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountClientId").Value = AccountClientId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Me.Adapter.SelectCommand.Parameters.Add("@Completed", SqlDbType.Bit)
            Me.Adapter.SelectCommand.Parameters("@Completed").Value = Completed

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable = New TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetAssignedProjectTasksFromvueAccountProjectTaskForCustomizedReport(ByVal WhereClause As String, ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal Completed As Boolean) As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectId").Value = AccountProjectId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId

            Me.Adapter.SelectCommand.Parameters.Add("@Completed", SqlDbType.Bit)
            Me.Adapter.SelectCommand.Parameters("@Completed").Value = Completed

            Me.Adapter.SelectCommand.CommandText = WhereClause
            Dim dataTable As TimeLiveDataSet.AccountProjectTaskTimesheetDataTable = New TimeLiveDataSet.AccountProjectTaskTimesheetDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class
End Namespace
