Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Namespace TimeLiveDataSetTableAdapters
    Public Class vueAccountProjectTaskTableAdapter
        Public Function GetAssignedProjectTasksFromvueAccountProjectTask(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal Completed As Boolean) As TimeLiveDataSet.vueAccountProjectTaskDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT AccountPriorityId, AccountProjectId, AccountProjectMilestoneId, AccountProjectTaskId, AccountTaskTypeId, Completed, CompletedPercent, " & _
                    " CreatedByEmployeeId, CreatedByFirstName, CreatedByLastName, CreatedOn, DeadlineDate, Duration, DurationUnit, IsDisabled, IsForAllEmployees, " & _
                    " IsParentTask, IsReOpen, IsTemplate, MilestoneDescription, ModifiedByEmployeeId, ModifiedByFirstName, ModifiedByLastName, ModifiedOn, " & _
                    " ParentAccountProjectTaskId, Priority, ProjectCode, ProjectName, TaskCode, TaskDescription, TaskName, TaskStatus, TaskStatusId, TaskType " & _
                    " FROM vueAccountProjectTask " & _
                    " WHERE "

            sql = sql + " ((IsParentTask <> 1) AND (IsDisabled <> 1) AND (IsTemplate <> 1) AND "

            If Completed <> True Then
                sql = sql + " (Completed = @Completed) AND "
            End If

            sql = sql + " (((IsForAllProjectTask = 1) AND (AccountProjectTaskId IN (SELECT AccountProjectTaskId FROM " & _
                        " AccountProjectTaskEmployee WHERE (AccountProjectTaskId = vueAccountProjectTask.AccountProjectTaskId) AND " & _
                        " (vueAccountProjectTask.AccountProjectId = vueAccountProjectTask.AccountProjectId) AND  " & _
                        " (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (AccountProjectId = @AccountProjectId)) OR "


            sql = sql + " ((IsForAllProjectTask = 1) AND (IsForAllEmployees = 1) AND (AccountProjectId IN " & _
                        " (SELECT AccountProjectId FROM AccountProjectEmployee " & _
                        " WHERE (AccountProjectId = vueAccountProjectTask.AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllProjectTask IS NULL OR IsForAllProjectTask <> 1) AND (IsForAllEmployees IS NULL OR IsForAllEmployees <> 1) " & _
                        " AND (AccountProjectTaskId IN " & _
                        " (SELECT AccountProjectTaskId FROM AccountProjectTaskEmployee AS AccountProjectTaskEmployee_1 " & _
                        " WHERE (AccountProjectTaskId = vueAccountProjectTask.AccountProjectTaskId) AND " & _
                        " (vueAccountProjectTask.AccountProjectId = @AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (IsForAllProjectTask = 1) AND (AccountId = @AccountId)))) "

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


            Dim dataTable As TimeLiveDataSet.vueAccountProjectTaskDataTable = New TimeLiveDataSet.vueAccountProjectTaskDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetAssignedProjectTasksByProjectTask(ByVal AccountId As Integer, ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer, ByVal AccountProjectTaskId As Integer, ByVal Completed As Boolean, ByVal TaskName As String) As TimeLiveDataSet.vueAccountProjectTaskDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = " SELECT AccountPriorityId, AccountProjectId, AccountProjectMilestoneId, AccountProjectTaskId, AccountTaskTypeId, Completed, CompletedPercent, " & _
                    " CreatedByEmployeeId, CreatedByFirstName, CreatedByLastName, CreatedOn, DeadlineDate, Duration, DurationUnit, IsDisabled, IsForAllEmployees, " & _
                    " IsParentTask, IsReOpen, IsTemplate, MilestoneDescription, ModifiedByEmployeeId, ModifiedByFirstName, ModifiedByLastName, ModifiedOn, " & _
                    " ParentAccountProjectTaskId, Priority, ProjectCode, ProjectName, TaskCode, TaskDescription, TaskName, TaskStatus, TaskStatusId, TaskType " & _
                    " FROM vueAccountProjectTask " & _
                    " WHERE "

            sql = sql + " (((IsParentTask <> 1) AND (IsDisabled <> 1) AND (IsTemplate <> 1) AND (Completed = @Completed) AND "

            sql = sql + " (((IsForAllProjectTask = 1) AND (AccountProjectTaskId IN (SELECT AccountProjectTaskId FROM " & _
                        " AccountProjectTaskEmployee WHERE (AccountProjectTaskId = vueAccountProjectTask.AccountProjectTaskId) AND " & _
                        " (vueAccountProjectTask.AccountProjectId = vueAccountProjectTask.AccountProjectId) AND  " & _
                        " (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (AccountProjectId = @AccountProjectId)) OR "


            sql = sql + " ((IsForAllProjectTask = 1) AND (IsForAllEmployees = 1) AND (AccountProjectId IN " & _
                        " (SELECT AccountProjectId FROM AccountProjectEmployee " & _
                        " WHERE (AccountProjectId = vueAccountProjectTask.AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllProjectTask IS NULL OR IsForAllProjectTask <> 1) AND (IsForAllEmployees IS NULL OR IsForAllEmployees <> 1) " & _
                        " AND (AccountProjectTaskId IN " & _
                        " (SELECT AccountProjectTaskId FROM AccountProjectTaskEmployee AS AccountProjectTaskEmployee_1 " & _
                        " WHERE (AccountProjectTaskId = vueAccountProjectTask.AccountProjectTaskId) AND " & _
                        " (vueAccountProjectTask.AccountProjectId = @AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) OR "

            sql = sql + " ((IsForAllEmployees = 1) AND (IsForAllProjectTask = 1) AND (AccountId = @AccountId)))) "

            sql = sql + " AND ((TaskName = @TaskName))) OR ((AccountProjectTaskId = @AccountProjectTaskId))"

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

            Me.Adapter.SelectCommand.Parameters.Add("@TaskName", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@TaskName").Value = TaskName

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountProjectTaskDataTable = New TimeLiveDataSet.vueAccountProjectTaskDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetDataTaskSearchForMyTask(ByVal AccountId As Integer, ByVal AccountProjectTaskId As Long, ByVal AccountProjectMilestoneId As Integer, ByVal AccountTaskTypeId As Integer, ByVal ReportedBy As Integer, ByVal IncludeDateRange As String, ByVal CreatedDateFrom As Date, ByVal CreatedDateUpto As Date, ByVal AssignedTo As Integer, ByVal TaskStatusId As Integer, ByVal CompletedStatus As String, ByVal Description As String, ByVal AccountProjects As String, ByVal AccountEmployeeId As Integer, Optional ByVal IsTaskAdd As Boolean = False) As TimeLiveDataSet.vueAccountProjectTaskDataTable
            Dim sql As String

            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            Me.Adapter.SelectCommand.Parameters.Add("@AccountId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountId").Value = AccountId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectTaskId", SqlDbType.Float)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectTaskId").Value = AccountProjectTaskId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountProjectMilestoneId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountProjectMilestoneId").Value = AccountProjectMilestoneId

            Me.Adapter.SelectCommand.Parameters.Add("@AccountTaskTypeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountTaskTypeId").Value = AccountTaskTypeId

            Me.Adapter.SelectCommand.Parameters.Add("@ReportedBy", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@ReportedBy").Value = ReportedBy

            Me.Adapter.SelectCommand.Parameters.Add("@IncludeDateRange", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@IncludeDateRange").Value = IncludeDateRange

            Me.Adapter.SelectCommand.Parameters.Add("@CreatedDateFrom", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@CreatedDateFrom").Value = CreatedDateFrom

            Me.Adapter.SelectCommand.Parameters.Add("@CreatedDateUpto", SqlDbType.DateTime)
            Me.Adapter.SelectCommand.Parameters("@CreatedDateUpto").Value = CreatedDateUpto

            Me.Adapter.SelectCommand.Parameters.Add("@AssignedTo", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AssignedTo").Value = AssignedTo

            Me.Adapter.SelectCommand.Parameters.Add("@TaskStatusId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@TaskStatusId").Value = TaskStatusId

            Me.Adapter.SelectCommand.Parameters.Add("@CompletedStatus", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@CompletedStatus").Value = CompletedStatus

            Me.Adapter.SelectCommand.Parameters.Add("@Description", SqlDbType.VarChar)
            Me.Adapter.SelectCommand.Parameters("@Description").Value = Description

            Me.Adapter.SelectCommand.Parameters.Add("@AccountEmployeeId", SqlDbType.Int)
            Me.Adapter.SelectCommand.Parameters("@AccountEmployeeId").Value = AccountEmployeeId



            sql = "SELECT AccountPriorityId, AccountProjectId, AccountProjectMilestoneId, AccountProjectTaskId, " & _
                    " AccountTaskTypeId, Completed, CompletedPercent, CreatedByEmployeeId, CreatedByFirstName, " & _
                    " CreatedByLastName, CreatedOn, DeadlineDate, Duration, DurationUnit, IsDisabled, IsForAllEmployees, " & _
                    " IsParentTask, IsReOpen, IsTemplate, MilestoneDescription, ModifiedByEmployeeId, ModifiedByFirstName, " & _
                    " ModifiedByLastName, ModifiedOn, ParentAccountProjectTaskId, Priority, ProjectCode, ProjectName, " & _
                    " TaskCode, TaskDescription, TaskName, TaskStatus, TaskStatusId, TaskType, " & _
                    " PartyName,AssignedBy,StartDate,IsDeletedClient,IsProjectDeleted FROM vueAccountProjectTask WHERE "

            ''"OR ((IsForAllEmployees = 1) AND (AccountProjectId IN  (SELECT AccountProjectId FROM AccountProjectEmployee WHERE (AccountProjectId = AccountProjectId) AND (AccountEmployeeId = @AccountEmployeeId)))) " & _
            sql = sql + " (IsTemplate <> 1) AND (AccountId = @AccountId) AND (ISNULL(IsDeletedClient,0) <> 1) AND (ISNULL(IsProjectDeleted,0) <> 1) AND (IsParentTask <> 1) AND (IsDisabled <> 1) AND ISNULL(MilestoneCompleted, 0) = 0 AND (IsForAllEmployees <> 1) " & _
                    " AND (@AccountProjectTaskId = - 1 OR AccountProjectTaskId = @AccountProjectTaskId) " & _
                    " AND (@AccountProjectMilestoneId = 0 OR AccountProjectMilestoneId = @AccountProjectMilestoneId) " & _
                    " AND (@AccountTaskTypeId = 0 OR AccountTaskTypeId = @AccountTaskTypeId) " & _
                    " AND (@ReportedBy = 0 OR CreatedByEmployeeId = @ReportedBy) " & _
                    " AND (@IncludeDateRange = 0 AND StartDate = StartDate OR @IncludeDateRange = 1 " & _
                    " AND CONVERT(datetime, CONVERT(char(10), StartDate, 101)) >= @CreatedDateFrom " & _
                    " AND CONVERT(datetime,  CONVERT(char(10), StartDate, 101)) <= @CreatedDateUpto) " & _
                    " AND (@AssignedTo = 0 OR AccountProjectTaskId IN (SELECT AccountProjectTaskId " & _
                    " FROM AccountProjectTaskEmployee " & _
                    " WHERE (AccountEmployeeId = @AssignedTo) " & _
                    " AND (vueAccountProjectTask.AccountProjectId IN (SELECT AccountProjectId " & _
                    " FROM AccountProjectEmployee " & _
                    " WHERE (AccountEmployeeId = @AccountEmployeeId))))) " & _
                    " AND (@TaskStatusId = 0 OR TaskStatusId = @TaskStatusId) " & _
                    " AND (@CompletedStatus = - 1 AND Completed = Completed OR @CompletedStatus = 1 AND Completed = 1 OR @CompletedStatus = 0 " & _
                    " AND (Completed IS NULL OR Completed = 0)) " & _
                    " AND (@Description = '' OR AccountProjectTaskId IN (SELECT AccountProjectTaskId " & _
                    " FROM vueAccountProjectTaskWithComments " & _
                    " WHERE (TaskName LIKE @Description) OR (TaskDescription LIKE @Description) OR (Comments LIKE @Description) " & _
                    " OR (CommentsTitle LIKE @Description))) " & _
                    " AND (AccountProjectId IN (" & AccountProjects & "))"

            If IsTaskAdd = True Then
                sql = sql + " Order By AccountProjectTaskId "
            End If

            Me.Adapter.SelectCommand.CommandText = sql


            Dim dataTable As TimeLiveDataSet.vueAccountProjectTaskDataTable = New TimeLiveDataSet.vueAccountProjectTaskDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable

        End Function
        Public Function GetAccountIdByAccountProjectTaskId(ByVal AccountProjectTaskId As Integer)
            Dim sql As String
            Me.Adapter.SelectCommand = New SqlCommand("", Me.Connection)

            sql = "Select * from vueAccountProjectTask "
            sql = sql & "WHERE "

            sql = sql & "AccountProjectTaskId = " & AccountProjectTaskId

            Me.Adapter.SelectCommand.CommandText = sql

            Dim dataTable As TimeLiveDataSet.vueAccountProjectTaskDataTable = New TimeLiveDataSet.vueAccountProjectTaskDataTable
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function
    End Class

End Namespace
