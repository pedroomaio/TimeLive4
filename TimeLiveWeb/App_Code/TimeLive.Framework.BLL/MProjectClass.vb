Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports net.sf.mpxj
Imports net.sf.mpxj.reader
Imports net.sf.mpxj.MpxjUtilities
Imports net.sf.mpxj.writer
Imports net.sf.mpxj.ProjectFile
Imports net.sf.mpxj.planner.PlannerWriter
Imports net.sf.mpxj.planner
Imports net.sf.mpxj.mspdi
Imports net.sf.mpxj.mpp

<System.ComponentModel.DataObject()> _
Public Class MprojectClass

    ''' <summary>
    ''' Main entry point.
    ''' </summary>
    ''' <param name="args">command line arguments</param>
    Sub Main(args As String())
        Try
            If args.Length <> 1 Then
                System.Console.WriteLine("Usage: MpxQuery <input file name>")
            Else
                query(args(0))
            End If

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This method performs a set of queries to retrieve information
    ''' from the an MPP or an MPX file.
    ''' </summary>
    ''' <param name="filename">name of the project file</param>
    Public Function query(filename As String)
        Dim reader As ProjectReader = ProjectReaderUtility.getProjectReader(filename)
        Dim mpx As ProjectFile = reader.read(filename)

        System.Console.WriteLine("MPP file type: " & mpx.ProjectProperties.MppFileType.ToNullableInt)

        listProjectHeader(mpx)

        listResources(mpx)

        listTasks(mpx)

        listAssignments(mpx)

        listAssignmentsByTask(mpx)

        listAssignmentsByResource(mpx)

        listHierarchy(mpx)

        listTaskNotes(mpx)

        listResourceNotes(mpx)

        listRelationships(mpx)

        listSlack(mpx)

        listCalendars(mpx)
    End Function

    ''' <summary>
    ''' Reads basic summary details from the project header.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listProjectHeader(file As ProjectFile)
        Dim header As ProjectProperties = file.ProjectProperties
        Dim formattedStartDate As String = If(header.StartDate Is Nothing, "(none)", header.StartDate.ToDateTime().ToString())
        Dim formattedFinishDate As String = If(header.FinishDate Is Nothing, "(none)", header.FinishDate.ToDateTime().ToString())

        System.Console.WriteLine("Project Header: StartDate=" & formattedStartDate & " FinishDate=" & formattedFinishDate)
        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method lists all resources defined in the file.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listResources(file As ProjectFile)
        For Each resource As Resource In file.AllResources.ToIEnumerable()
            System.Console.WriteLine("Resource: " & resource.Name & " (Unique ID=" & ToString(resource.UniqueID) & ") Start=" & ToString(resource.Start) & " Finish=" & ToString(resource.Finish))
        Next
        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method lists all tasks defined in the file.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listTasks(file As ProjectFile)
        For Each task As net.sf.mpxj.Task In file.AllTasks.ToIEnumerable()
            Dim startDate As String
            Dim finishDate As String
            Dim duration As String
            Dim dur As Duration

            Dim [date] = task.Start
            If [date] IsNot Nothing Then
                startDate = [date].ToDateTime().ToString()
            Else
                startDate = "(no date supplied)"
            End If

            [date] = task.Finish
            If [date] IsNot Nothing Then
                finishDate = [date].ToDateTime().ToString()
            Else
                finishDate = "(no date supplied)"
            End If

            dur = task.Duration
            If dur IsNot Nothing Then
                duration = dur.toString()
            Else
                duration = "(no duration supplied)"
            End If

            Dim baselineDuration As String = task.BaselineDurationText
            If baselineDuration Is Nothing Then
                dur = task.BaselineDuration
                If dur IsNot Nothing Then
                    baselineDuration = dur.toString()
                Else
                    baselineDuration = "(no duration supplied)"
                End If
            End If

            System.Console.WriteLine("Task: " & task.Name & " ID=" & ToString(task.ID) & " Unique ID=" & ToString(task.UniqueID) & " (Start Date=" & startDate & " Finish Date=" & finishDate & " Duration=" & duration & " Baseline Duration=" & baselineDuration & " Outline Level=" & ToString(task.OutlineLevel) & " Outline Number=" & task.OutlineNumber & " Recurring=" & task.Recurring & ")")
        Next
        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method lists all tasks defined in the file in a hierarchical format, 
    ''' reflecting the parent-child relationships between them.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listHierarchy(file As ProjectFile)
        For Each task As net.sf.mpxj.Task In file.ChildTasks.ToIEnumerable()
            System.Console.WriteLine("Task: " & task.Name)
            listHierarchy(task, " ")
        Next

        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' Helper method called recursively to list child tasks.
    ''' </summary>
    ''' <param name="task">Task instance</param>
    ''' <param name="indent">print indent</param>
    Private Sub listHierarchy(task As net.sf.mpxj.Task, indent As String)
        For Each child As net.sf.mpxj.Task In task.ChildTasks.ToIEnumerable()
            System.Console.WriteLine(indent & "Task: " & child.Name)
            listHierarchy(child, indent & " ")
        Next
    End Sub

    ''' <summary>
    ''' This method lists all resource assignments defined in the file.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listAssignments(file As ProjectFile)
        Dim task As net.sf.mpxj.Task
        Dim resource As Resource
        Dim taskName As String
        Dim resourceName As String

        For Each assignment As ResourceAssignment In file.AllResourceAssignments.ToIEnumerable()
            task = assignment.Task
            If task Is Nothing Then
                taskName = "(null task)"
            Else
                taskName = task.Name
            End If

            resource = assignment.Resource
            If resource Is Nothing Then
                resourceName = "(null resource)"
            Else
                resourceName = resource.Name
            End If

            System.Console.WriteLine("Assignment: Task=" & taskName & " Resource=" & resourceName)
        Next

        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method displays the resource assignments for each task. 
    ''' This time rather than just iterating through the list of all 
    ''' assignments in the file, we extract the assignments on a task-by-task basis.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listAssignmentsByTask(file As ProjectFile)
        For Each task As net.sf.mpxj.Task In file.AllTasks.ToIEnumerable()
            System.Console.WriteLine("Assignments for task " & task.Name & ":")

            For Each assignment As ResourceAssignment In task.ResourceAssignments.ToIEnumerable()
                Dim resource As Resource = assignment.Resource
                Dim resourceName As String

                If resource Is Nothing Then
                    resourceName = "(null resource)"
                Else
                    resourceName = resource.Name
                End If

                System.Console.WriteLine("   " & resourceName)
            Next
        Next

        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method displays the resource assignments for each resource. 
    ''' This time rather than just iterating through the list of all 
    ''' assignments in the file, we extract the assignments on a resource-by-resource basis.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listAssignmentsByResource(file As ProjectFile)
        For Each resource As Resource In file.AllResources.ToIEnumerable()
            System.Console.WriteLine("Assignments for resource " & resource.Name & ":")

            For Each assignment As ResourceAssignment In resource.TaskAssignments.ToIEnumerable()
                Dim task As net.sf.mpxj.Task = assignment.Task
                System.Console.WriteLine("   " & task.Name)
            Next
        Next

        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method lists any notes attached to tasks..
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listTaskNotes(file As ProjectFile)
        For Each task As net.sf.mpxj.Task In file.AllTasks.ToIEnumerable()
            Dim notes As String = task.Notes

            If notes IsNot Nothing AndAlso notes.Length <> 0 Then
                System.Console.WriteLine("Notes for " & task.Name & ": " & notes)
            End If
        Next

        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method lists any notes attached to resources.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listResourceNotes(file As ProjectFile)
        For Each resource As Resource In file.AllResources.ToIEnumerable()
            Dim notes As String = resource.Notes

            If notes IsNot Nothing AndAlso notes.Length <> 0 Then
                System.Console.WriteLine("Notes for " & resource.Name & ": " & notes)
            End If
        Next

        System.Console.WriteLine()
    End Sub

    ''' <summary>
    ''' This method lists task predecessor and successor relationships.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listRelationships(file As ProjectFile)
        For Each task As net.sf.mpxj.Task In file.AllTasks.ToIEnumerable()
            System.Console.Write(task.ID)
            System.Console.Write(ControlChars.Tab)
            System.Console.Write(task.Name)
            System.Console.Write(ControlChars.Tab)

            dumpRelationList(task.Predecessors)
            System.Console.Write(ControlChars.Tab)
            dumpRelationList(task.Successors)
            System.Console.WriteLine()
        Next
    End Sub

    ''' <summary>
    ''' Internal utility to dump relationship lists in a structured format that can 
    ''' easily be compared with the tabular data in MS Project.
    ''' </summary>
    ''' <param name="relations">project file</param>
    Private Sub dumpRelationList(relations As java.util.List)
        If relations IsNot Nothing AndAlso relations.isEmpty() = False Then
            If relations.size() > 1 Then
                System.Console.Write(""""c)
            End If
            Dim first As Boolean = True
            For Each relation As Relation In relations.ToIEnumerable()
                If Not first Then
                    System.Console.Write(","c)
                End If
                first = False
                System.Console.Write(relation.TargetTask.ID)
                Dim lag As Duration = relation.Lag
                If Not relation.GetType().Equals(RelationType.FINISH_START) OrElse lag.Duration <> 0 Then
                    System.Console.Write(relation.[GetType]())
                End If

                If lag.Duration <> 0 Then
                    If lag.Duration > 0 Then
                        System.Console.Write("+")
                    End If
                    System.Console.Write(lag)
                End If
            Next
            If relations.size() > 1 Then
                System.Console.Write(""""c)
            End If
        End If
    End Sub

    ''' <summary>
    ''' List the slack values for each task.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listSlack(file As ProjectFile)
        For Each task As net.sf.mpxj.Task In file.AllTasks.ToIEnumerable()
            System.Console.WriteLine(task.Name & " Total Slack=" & ToString(task.TotalSlack) & " Start Slack=" & ToString(task.StartSlack) & " Finish Slack=" & ToString(task.FinishSlack))
        Next
    End Sub

    ''' <summary>
    ''' List details of all calendars in the file.
    ''' </summary>
    ''' <param name="file">project file</param>
    Private Sub listCalendars(file As ProjectFile)
        For Each cal As ProjectCalendar In file.Calendars.ToIEnumerable()
            System.Console.WriteLine(cal.toString())
        Next
    End Sub

    ''' <summary>
    ''' Convenience method to handle null values
    ''' </summary>
    ''' <param name="javaObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ToString(javaObject As java.lang.Integer)
        Dim result As String
        If javaObject Is Nothing Then
            result = "null"
        Else
            result = javaObject.toString()
        End If
        Return result
    End Function

    ''' <summary>
    ''' Convenience method to handle null values
    ''' </summary>
    ''' <param name="javaObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ToString(javaObject As java.util.Date)
        Dim result As String
        If javaObject Is Nothing Then
            result = "null"
        Else
            result = javaObject.toString()
        End If
        Return result
    End Function

    ''' <summary>
    ''' Convenience method to handle null values
    ''' </summary>
    ''' <param name="javaObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ToString(javaObject As net.sf.mpxj.Duration)
        Dim result As String
        If javaObject Is Nothing Then
            result = "null"
        Else
            result = javaObject.toString()
        End If
        Return result
    End Function
    Public Function ExportFileforMicrosoftProject(ByVal AccountProjectId As Integer, ByVal tempFile As String) As Integer

        Dim TaskName As String
        Dim Project As New net.sf.mpxj.ProjectFile
        'Project.setAutoOutlineLevel(True)
        'Project.setAutoOutlineNumber(True)
        'Project.setAutoTaskID(True)
        'Project.setAutoTaskUniqueID(True)
        'Project.setAutoWBS(True)
        'Project.setAutoCalendarUniqueID(True)

        Dim AccountProjectTaskId As Integer
        Dim dttaskName As TimeLiveDataSet.AccountProjectTaskDataTable = New AccountProjectTaskBLL().GetAccountProjectTasksByAccountProjectIdandIsParentTaskId(AccountProjectId)
        Dim drtaskName As TimeLiveDataSet.AccountProjectTaskRow
        If dttaskName.Rows.Count > 0 Then
            drtaskName = dttaskName.Rows(0)
            For Each drtaskName In dttaskName.Rows
                TaskName = drtaskName.TaskName
                AccountProjectTaskId = drtaskName.AccountProjectTaskId
                Dim TaskDuration As Integer
                TaskDuration = drtaskName.Duration
                Dim TimeUnit = drtaskName.DurationUnit
                Dim PComplete = CDbl(drtaskName.CompletedPercent)
                Dim FinishDate As Date = drtaskName.DeadlineDate
                Dim df = New java.text.SimpleDateFormat("MM/dd/yyyy")
                Dim task As net.sf.mpxj.Task = Project.addTask
                task.Name = TaskName
                'task.setDuration(0, Duration.getInstance(TaskDuration, net.sf.mpxj.TimeUnit.DAYS))
                'task.setStart(df.parse(FinishDate))
                'task.setStart(New java.util.Date)
                'task.setFinish(New java.util.Date(FinishDate))
                'task.setDuration(Duration.getInstance(TaskDuration, net.sf.mpxj.TimeUnit.DAYS))
                'task.setID(New java.lang.Integer(AccountProjectTaskId))
                'task.setUniqueID(New java.lang.Integer(AccountProjectTaskId))
                'task.setPercentageComplete(NumberUtility.getDouble(PComplete))

                ''childtask
                Dim Taskchild As net.sf.mpxj.Task
                Dim ChildTaskId As Integer
                Dim ChildTaskName As String
                Dim dtcheckchildtaskName As TimeLiveDataSet.AccountProjectTaskDataTable = New AccountProjectTaskBLL().GetAccountProjectTasksByParentAccountProjectTaskId(AccountProjectTaskId)
                Dim drcheckchildtaskName As TimeLiveDataSet.AccountProjectTaskRow
                If dtcheckchildtaskName.Rows.Count > 0 Then
                    drcheckchildtaskName = dtcheckchildtaskName.Rows(0)
                    For Each drcheckchildtaskName In dtcheckchildtaskName.Rows
                        ChildTaskName = drcheckchildtaskName.TaskName
                        ChildTaskId = drcheckchildtaskName.AccountProjectTaskId
                        Dim ChildUnit = drcheckchildtaskName.DurationUnit
                        Taskchild = task.addTask
                        'Taskchild.setName(ChildTaskName)
                        Taskchild.Name = ChildTaskName
                        Dim ChildTaskDuration As Integer
                        ChildTaskDuration = drcheckchildtaskName.Duration
                        Dim ChildTimeUnit = drcheckchildtaskName.DurationUnit
                        Dim ChildPComplete = CDbl(drcheckchildtaskName.CompletedPercent)
                        Dim ChildFinishDate As Date = drcheckchildtaskName.DeadlineDate
                        Dim dtf = New java.text.SimpleDateFormat("MM/dd/yyyy")
                        'Taskchild.setFinish(dtf.parse(ChildFinishDate))
                        'Taskchild.setDuration(0, Duration.getInstance(ChildTaskDuration, net.sf.mpxj.TimeUnit.DAYS))


                        ''ProjectEmployeeLoop
                        Dim ProjectEmployeeName As String
                        Dim ProjectEmployeeId As Integer

                        Dim Resource As net.sf.mpxj.Resource

                        Dim dtProjectEmployee As TimeLiveDataSet.AccountProjectEmployeeDataTable = New AccountProjectEmployeeBLL().GetAccountProjectEmployeesByAccountProjectId(AccountProjectId)
                        Dim drProjectEmployee As TimeLiveDataSet.AccountProjectEmployeeRow
                        If dtProjectEmployee.Rows.Count > 0 Then
                            drProjectEmployee = dtProjectEmployee.Rows(0)
                            For Each drProjectEmployee In dtProjectEmployee.Rows
                                ProjectEmployeeId = drProjectEmployee.AccountEmployeeId
                                Dim dtProjectResourceName As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(ProjectEmployeeId)
                                Dim drProjectResourceName As AccountEmployee.AccountEmployeeRow
                                If dtProjectResourceName.Rows.Count > 0 Then
                                    drProjectResourceName = dtProjectResourceName.Rows(0)
                                    ProjectEmployeeName = drProjectResourceName.FirstName + " " + drProjectResourceName.LastName
                                    Resource = Project.addResource()
                                    Resource.Name = ProjectEmployeeName
                                    'Resource.UniqueID(New java.lang.Integer(ProjectEmployeeId))
                                    'Resource.setName(ProjectEmployeeName)
                                    'Resource.setUniqueID(New java.lang.Integer(ProjectEmployeeId))
                                    'Resource.setID(New java.lang.Integer(ProjectEmployeeId))


                                    Dim ChildAccountEmployeeId As Integer
                                    Dim ChildTaskEmployeeName As String
                                    Dim dtChildTaskEmployee As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable = New AccountProjectTaskEmployeeBLL().GetAccountProjectTaskByAccountEmployeeIdandAccountProjectTaskId(ProjectEmployeeId, ChildTaskId)
                                    Dim drChildTaskEmployee As TimeLiveDataSet.AccountProjectTaskEmployeeRow
                                    If dtChildTaskEmployee.Rows.Count > 0 Then
                                        drChildTaskEmployee = dtChildTaskEmployee.Rows(0)
                                        For Each drChildTaskEmployee In dtChildTaskEmployee.Rows
                                            ChildAccountEmployeeId = drChildTaskEmployee.AccountEmployeeId
                                            Dim dtTaskResourceName As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(ChildAccountEmployeeId)
                                            Dim drTaskResourceName As AccountEmployee.AccountEmployeeRow
                                            If dtTaskResourceName.Rows.Count > 0 Then
                                                drTaskResourceName = dtTaskResourceName.Rows(0)
                                                ChildTaskEmployeeName = drTaskResourceName.FirstName + " " + drTaskResourceName.LastName
                                                'Dim objResourceAssignment As ResourceAssignment
                                                'objResourceAssignment = task.addResourceAssignment(Resource)
                                                'objResourceAssignment.setResourceUniqueID(New java.lang.Integer(ProjectEmployeeId))
                                                Taskchild.addResourceAssignment(Resource)
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    Next
                Else
                    ''Not child task available ProjectEmployeeLoop
                    Dim NotChildResource As net.sf.mpxj.Resource
                    Dim ProjectEmployeeName As String
                    Dim ProjectEmployeeId As Integer

                    Dim dtProjectEmployee As TimeLiveDataSet.AccountProjectEmployeeDataTable = New AccountProjectEmployeeBLL().GetAccountProjectEmployeesByAccountProjectId(AccountProjectId)
                    Dim drProjectEmployee As TimeLiveDataSet.AccountProjectEmployeeRow
                    If dtProjectEmployee.Rows.Count > 0 Then
                        drProjectEmployee = dtProjectEmployee.Rows(0)
                        For Each drProjectEmployee In dtProjectEmployee.Rows
                            ProjectEmployeeId = drProjectEmployee.AccountEmployeeId
                            Dim dtProjectResourceName As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(ProjectEmployeeId)
                            Dim drProjectResourceName As AccountEmployee.AccountEmployeeRow
                            If dtProjectResourceName.Rows.Count > 0 Then
                                drProjectResourceName = dtProjectResourceName.Rows(0)
                                ProjectEmployeeName = drProjectResourceName.FirstName + " " + drProjectResourceName.LastName
                                NotChildResource = Project.addResource()
                                'NotChildResource.setName(ProjectEmployeeName)
                                'NotChildResource.setUniqueID(New java.lang.Integer(ProjectEmployeeId))
                                'NotChildResource.setID(New java.lang.Integer(ProjectEmployeeId))


                                Dim NotChildAccountEmployeeId As Integer
                                Dim NotChildTaskEmployeeName As String
                                Dim dtChildTaskEmployee As TimeLiveDataSet.AccountProjectTaskEmployeeDataTable = New AccountProjectTaskEmployeeBLL().GetAccountProjectTaskByAccountEmployeeIdandAccountProjectTaskId(ProjectEmployeeId, AccountProjectTaskId)
                                Dim drChildTaskEmployee As TimeLiveDataSet.AccountProjectTaskEmployeeRow
                                If dtChildTaskEmployee.Rows.Count > 0 Then
                                    drChildTaskEmployee = dtChildTaskEmployee.Rows(0)
                                    For Each drChildTaskEmployee In dtChildTaskEmployee.Rows
                                        NotChildAccountEmployeeId = drChildTaskEmployee.AccountEmployeeId
                                        Dim dtTaskResourceName As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByAccountEmployeeId(NotChildAccountEmployeeId)
                                        Dim drTaskResourceName As AccountEmployee.AccountEmployeeRow
                                        If dtTaskResourceName.Rows.Count > 0 Then
                                            drTaskResourceName = dtTaskResourceName.Rows(0)
                                            NotChildTaskEmployeeName = drTaskResourceName.FirstName + " " + drTaskResourceName.LastName
                                            'Dim objResourceAssignment As ResourceAssignment
                                            'objResourceAssignment = task.addResourceAssignment(Resource)
                                            'objResourceAssignment.setResourceUniqueID(New java.lang.Integer(ProjectEmployeeId))
                                            task.addResourceAssignment(NotChildResource)
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            '            ProjectReader reader = new MPPReader();
            'ProjectFile sourceObj = reader.read(<sourcefilename>);
            'Dim writer As PlannerWriter = New PlannerWriter()
            'writer.write(Project, tempFile)

            'Dim reader As New MPPReader = new MPPReader()
            'Dim ProjectFile projectFile = reader.read(inputFile)

            '            MPXWriter writer = new MPXWriter();
            'writer.write(projectFile, outputFileName);


            Dim writer As MSPDIWriter = New MSPDIWriter()
            'writer.write(Project, tempFile)


            'Dim writer As ProjectWriter = New net.sf.mpxj.mpx.MPXWriter
            Dim ExportType As String = "MProject"
            writer.write(Project, tempFile)
            ' Me.process(tempFile, tempFile)
        End If


        Return AccountProjectTaskId

    End Function
    Public Sub process(inputFile As String, outputFile As String)
        Console.Out.WriteLine("Reading input file started.")
        Dim start As DateTime = DateTime.Now
        Dim reader As ProjectReader = ProjectReaderUtility.getProjectReader(inputFile)
        Dim projectFile As ProjectFile = reader.read(inputFile)
        Dim elapsed As TimeSpan = DateTime.Now - start
        Console.Out.WriteLine("Reading input file completed in " + elapsed.TotalMilliseconds & "ms.")

        Console.Out.WriteLine("Writing output file started.")
        start = DateTime.Now
        Dim writer As ProjectWriter = ProjectWriterUtility.getProjectWriter(outputFile)
        writer.write(projectFile, outputFile)
        elapsed = DateTime.Now - start
        Console.Out.WriteLine("Writing output completed in " + elapsed.TotalMilliseconds & "ms.")
    End Sub
    ''' <summary>
    ''' Upload Microsoft Project file
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <param name="Delimiter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PopulateDataTableFromUploadedFile(ByVal FileName As String, ByVal Delimiter As String) As DataTable
        'm_MProject = Delimiter
        Dim reader As net.sf.mpxj.reader.ProjectReader = New MPPReader()
        Dim project As net.sf.mpxj.ProjectFile = reader.read(FileName)

        Dim strLine As [String] = [String].Empty
        Dim iLineCount As Int32 = 0
        Dim AccountProjectTypeId As Integer
        Dim AccountBillingTypeId As Integer
        Dim AccountStatusId As Integer
        Dim ProjectCode As String
        Dim taskName As String
        Dim ProjectName As String
        Dim IsMilestone As Boolean
        Dim ProjectStartDate As Date
        Dim ProjectEndDate As Date
        'strLine = reader

        'If strLine Is Nothing Then
        '    Return Nothing
        'End If

        'm_MProject = Me.CreateDataTableForMProjectData(strLine)

        'Dim task As net.sf.mpxj.Task
        Dim projectbll As New AccountProjectBLL

        Dim AccountClientId As System.Nullable(Of Integer)
        'For Each task As net.sf.mpxj.Task In file.AllTasks.ToIEnumerable()
        For Each task As net.sf.mpxj.Task In project.AllTasks.toArray()

            taskName = task.Name
            If taskName <> Nothing Then
                Dim Id = task.ID
                Dim taskuniqueId = task.UniqueID 
                Dim method = task.EarnedValueMethod
                Dim chi = task.ChildTasks


                If task.ID.toString = 0 Then

                    Dim dtClientName As TimeLiveDataSet.vueAccountPartyDataTable = New AccountPartyBLL().GetvueAccountPartiesByAccountId(DBUtilities.GetSessionAccountId, 0)
                    Dim drClientName As TimeLiveDataSet.vueAccountPartyRow
                    drClientName = dtClientName.Rows(0)
                    If dtClientName.Rows.Count > 0 Then
                        Dim PartyName = drClientName.PartyName
                        AccountClientId = drClientName.AccountPartyId
                    End If

                    Dim dtStatus As TimeLiveDataSet.AccountStatusDataTable = New AccountStatusBLL().GetAccountsStatusByStatusTypeId(DBUtilities.GetSessionAccountId, 3)
                    Dim drStatus As TimeLiveDataSet.AccountStatusRow
                    drStatus = dtStatus.Rows(0)
                    If dtStatus.Rows.Count > 0 Then
                        AccountStatusId = drStatus.AccountStatusId
                    End If

                    Dim dtProjectType As TimeLiveDataSet.AccountProjectTypeDataTable = New AccountProjectTypeBLL().GetAccountProjectTypeByAccountId(DBUtilities.GetSessionAccountId)
                    Dim drProjectType As TimeLiveDataSet.AccountProjectTypeRow
                    drProjectType = dtProjectType.Rows(0)
                    If dtProjectType.Rows.Count > 0 Then
                        AccountProjectTypeId = drProjectType.AccountProjectTypeId
                    End If

                    Dim dtBillingType As TimeLiveDataSet.AccountBillingTypeDataTable = New AccountBillingTypeBLL().GetAccountBillingTypesForProjectByAccountId(DBUtilities.GetSessionAccountId)
                    Dim drBillingType As TimeLiveDataSet.AccountBillingTypeRow
                    drBillingType = dtBillingType.Rows(0)
                    If dtBillingType.Rows.Count > 0 Then
                        AccountBillingTypeId = drBillingType.AccountBillingTypeId
                    End If
                    ProjectName = taskName
                    ProjectCode = LTrim(RTrim(Left(taskName, 5)))
                    ProjectStartDate = task.Start.toGMTString
                    ProjectEndDate = task.Finish.toGMTString
                    If taskName = Nothing Then
                        taskName = "Microsoft Project-1"
                    End If
                    projectbll.AddAccountProject(DBUtilities.GetSessionAccountId, AccountProjectTypeId, AccountClientId, 0, 0, AccountBillingTypeId, ProjectName, ProjectName, ProjectStartDate, ProjectEndDate, AccountStatusId, DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountEmployeeId, 0, 0, 0, "Days", ProjectCode, 0, 0, False, False, 0, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, False, "", False, 0, 0)
                Else

                    'Last ProjectId
                    Dim AccountProjectId = projectbll.GetLastInsertedId()

                    Dim AccountPriorityId As Integer
                    Dim dtPriority As TimeLiveDataSet.AccountPriorityDataTable = New AccountPriorityBLL().GetAccountPrioritiesByAccountId(DBUtilities.GetSessionAccountId)
                    Dim drPriority As TimeLiveDataSet.AccountPriorityRow
                    drPriority = dtPriority.Rows(0)
                    If dtPriority.Rows.Count > 0 Then
                        AccountPriorityId = drPriority.AccountPriorityId
                    End If
                    Dim AccountProjectMilestoneId As Integer
                    Dim dtMilestone As TimeLiveDataSet.AccountProjectMilestoneDataTable = New AccountProjectMilestoneBLL().GetAccountProjectMilestonesByAccountProjectId(AccountProjectId)
                    Dim drMilestone As TimeLiveDataSet.AccountProjectMilestoneRow
                    drMilestone = dtMilestone.Rows(0)
                    If dtMilestone.Rows.Count > 0 Then
                        AccountProjectMilestoneId = drMilestone.AccountProjectMilestoneId
                    End If
                    Dim AccountTaskTypeId As Integer
                    Dim dtTaskType As TimeLiveDataSet.AccountTaskTypeDataTable = New AccountTaskTypeBLL().GetAccountTaskTypesByAccountId(DBUtilities.GetSessionAccountId)
                    Dim drTaskType As TimeLiveDataSet.AccountTaskTypeRow
                    drTaskType = dtTaskType.Rows(0)
                    If dtTaskType.Rows.Count > 0 Then
                        AccountTaskTypeId = drTaskType.AccountTaskTypeId
                    End If
                    Dim TaskStatusId As Integer
                    Dim dttaskStatus As TimeLiveDataSet.AccountStatusDataTable = New AccountStatusBLL().GetAccountsStatusByStatusTypeId(DBUtilities.GetSessionAccountId, 4)
                    Dim drtaskStatus As TimeLiveDataSet.AccountStatusRow
                    drtaskStatus = dttaskStatus.Rows(0)
                    If dttaskStatus.Rows.Count > 0 Then
                        TaskStatusId = drtaskStatus.AccountStatusId
                    End If

                    Dim AccountCurrencyId = DBUtilities.GetAccountBaseCurrencyId

                    Dim FinishDate As Date
                    Dim StartDate As Date
                    Dim TaskDuration As Double
                    Dim Completed As Double
                    Dim iscompleted As Boolean
                    Dim taskbll As New AccountProjectTaskBLL
                    Dim ParentTaskId As Integer
                    Dim ParentTaskName As String
                    Dim TaskDurationUnit As String
                    Dim Milestone As Boolean
                    Dim MilestoneBll As New AccountProjectMilestoneBLL
                    FinishDate = task.Start.toGMTString
                    StartDate = task.Finish.toGMTString
                    TaskDuration = CDbl(task.Duration.Duration)
                    TaskDurationUnit = task.Duration.Units.toString
                    Completed = task.PercentageComplete.doubleValue
                    Milestone = task.Milestone

                    ''Search Assign Milestone task
                    'If Not task.getPredecessors Is Nothing Then
                    '    '    Dim MilestoneTaskName = Split(task.getPredecessors.ToString, "name=")
                    '    '    ParentTaskName = Replace(MilestoneTaskName(1), "]", "")
                    '    For Each MilestoneTask In task.getPredecessors.toArray()

                    '    Next
                    'End If
                    If Completed <> 100 Then
                        iscompleted = False
                    Else
                        iscompleted = True
                    End If
                    If task.ChildTasks.toArray.Length <> 0 Then
                        If TaskDurationUnit = Nothing Then
                            TaskDurationUnit = "Days"
                        ElseIf TaskDurationUnit = "h" Then
                            TaskDurationUnit = "Hours"
                        ElseIf TaskDurationUnit = "d" Then
                            TaskDurationUnit = "Days"
                        ElseIf TaskDurationUnit = "m" Then
                            TaskDurationUnit = "Minutes"
                        ElseIf TaskDurationUnit = "w" Then
                            TaskDurationUnit = "Weeks"
                        ElseIf TaskDurationUnit = "mo" Then
                            TaskDurationUnit = "Months"
                        End If
                        If Milestone = True Then
                            MilestoneBll.AddAccountProjectMilestone(DBUtilities.GetSessionAccountId, AccountProjectId, taskName, FinishDate, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, "", False)
                            IsMilestone = True
                        Else
                            If IsMilestone = False Then
                                taskbll.AddAccountProjectTask(AccountProjectId, 0, taskName, taskName, AccountTaskTypeId, TaskDuration, TaskDurationUnit, Completed, iscompleted, FinishDate, TaskStatusId, AccountPriorityId, AccountProjectMilestoneId, False, True, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, 0, 0, "", True, "", 0, False, AccountCurrencyId, StartDate, 0)
                            Else
                                taskbll.AddAccountProjectTask(AccountProjectId, 0, taskName, taskName, AccountTaskTypeId, TaskDuration, TaskDurationUnit, Completed, iscompleted, FinishDate, TaskStatusId, AccountPriorityId, MilestoneBll.GetLastInsertedId, False, True, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, 0, 0, "", True, "", 0, False, AccountCurrencyId, StartDate, 0)
                            End If
                        End If
                    Else
                        ''SearchParentTaskName
                        Dim ParentTask = Split(task.ParentTask.toString, "name=")
                        ParentTaskName = Replace(ParentTask(1), "]", "")

                        Dim dttaskName As TimeLiveDataSet.AccountProjectTaskDataTable = New AccountProjectTaskBLL().GetAccountProjectTasksByAccountProjectIdandTaskName(AccountProjectId, ParentTaskName)
                        Dim drtaskName As TimeLiveDataSet.AccountProjectTaskRow
                        If dttaskName.Rows.Count > 0 Then
                            drtaskName = dttaskName.Rows(0)
                            ParentTaskId = drtaskName.AccountProjectTaskId
                        End If
                        If TaskDurationUnit = Nothing Then
                            TaskDurationUnit = "Days"
                        ElseIf TaskDurationUnit = "h" Then
                            TaskDurationUnit = "Hours"
                        ElseIf TaskDurationUnit = "d" Then
                            TaskDurationUnit = "Days"
                        ElseIf TaskDurationUnit = "m" Then
                            TaskDurationUnit = "Minutes"
                        ElseIf TaskDurationUnit = "w" Then
                            TaskDurationUnit = "Weeks"
                        ElseIf TaskDurationUnit = "mo" Then
                            TaskDurationUnit = "Months"
                        End If
                        If Milestone = True Then
                            MilestoneBll.AddAccountProjectMilestone(DBUtilities.GetSessionAccountId, AccountProjectId, taskName, FinishDate, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, "", False)
                            IsMilestone = True
                        Else
                            If IsMilestone = False Then
                                taskbll.AddAccountProjectTask(AccountProjectId, ParentTaskId, taskName, taskName, AccountTaskTypeId, TaskDuration, TaskDurationUnit, Completed, iscompleted, FinishDate, TaskStatusId, AccountPriorityId, AccountProjectMilestoneId, False, False, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, 0, 0, "", True, "", 0, False, AccountCurrencyId, StartDate, 0)
                            Else
                                taskbll.AddAccountProjectTask(AccountProjectId, ParentTaskId, taskName, taskName, AccountTaskTypeId, TaskDuration, TaskDurationUnit, Completed, iscompleted, FinishDate, TaskStatusId, AccountPriorityId, MilestoneBll.GetLastInsertedId, False, False, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, 0, 0, "", True, "", 0, False, AccountCurrencyId, StartDate, 0)
                            End If
                        End If
                    End If
                    Dim AccountProjectTaskId = taskbll.GetLastInsertedId()
                    Dim bllemp As New AccountEmployeeBLL
                    Dim taskresource As net.sf.mpxj.ResourceAssignment
                    For Each taskresource In task.ResourceAssignments.toArray()
                        Dim employeeNam = taskresource.Resource
                        If taskresource.ResourceUniqueID.intValue <> -65535 Then
                            Dim ResName = employeeNam.toString
                            Dim Employ() As String = Split(ResName, "name=")
                            Dim EmployeeName = Replace(Employ(1), "]", "")

                            Dim AccountEmployeeId As Integer
                            If employeeNam.toString <> Nothing Then
                                Dim dtResourceName As AccountEmployee.AccountEmployeeDataTable = New AccountEmployeeBLL().GetAccountEmployeesByEmployeeName(DBUtilities.GetSessionAccountId, EmployeeName)
                                Dim drResourceName As AccountEmployee.AccountEmployeeRow
                                If dtResourceName.Rows.Count > 0 Then
                                    drResourceName = dtResourceName.Rows(0)
                                    AccountEmployeeId = drResourceName.AccountEmployeeId
                                    Dim TaskEmployeeBLL As New AccountProjectTaskEmployeeBLL
                                    TaskEmployeeBLL.AddAccountProjectTaskEmployee(DBUtilities.GetSessionAccountId, AccountProjectId, AccountProjectTaskId, AccountEmployeeId, 100)
                                    Dim projectemployeeBLL As New AccountProjectEmployeeBLL
                                    Dim dtProjectEmployeeName As TimeLiveDataSet.AccountProjectEmployeeDataTable = New AccountProjectEmployeeBLL().GetAccountProjectEmployeesByAccountProjectIdandAccountEmployeeId(DBUtilities.GetSessionAccountId, AccountEmployeeId, AccountProjectId)
                                    If dtProjectEmployeeName.Rows.Count = 0 Then
                                        projectemployeeBLL.AddAccountProjectEmployee(DBUtilities.GetSessionAccountId, AccountProjectId, AccountEmployeeId, 0, 0)
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next
        projectbll.UpdateAccountProject(DBUtilities.GetSessionAccountId, AccountProjectTypeId, AccountClientId, 0, 0, AccountBillingTypeId, ProjectName, ProjectName, ProjectStartDate, ProjectEndDate, AccountStatusId, DBUtilities.GetSessionAccountEmployeeId, DBUtilities.GetSessionAccountEmployeeId, 0, 0, 0, "Days", ProjectCode, 0, 1, False, False, 0, Now.Date, DBUtilities.GetSessionAccountEmployeeId, Now.Date, DBUtilities.GetSessionAccountEmployeeId, projectbll.GetLastInsertedId, False, False, "", False, 0, 0)
        '    Return m_MProject

    End Function
End Class
