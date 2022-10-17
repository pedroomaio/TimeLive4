CREATE VIEW dbo.vueAccountProjectTaskWithPreferences
AS
SELECT     dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.AccountProjectId, dbo.AccountProjectTask.ParentAccountProjectTaskId, 
                      dbo.AccountProjectTask.TaskName, dbo.AccountProjectTask.TaskDescription, dbo.AccountProjectTask.AccountTaskTypeId, 
                      dbo.AccountProjectTask.Duration, dbo.AccountProjectTask.DurationUnit, dbo.AccountProjectTask.DeadlineDate, 
                      dbo.AccountProjectTask.CompletedPercent, dbo.AccountProjectTask.Completed, dbo.AccountProjectTask.IsParentTask, 
                      dbo.AccountProjectTask.IsForAllEmployees, dbo.AccountProjectTask.AccountPriorityId, dbo.AccountProjectTask.TaskStatusId, 
                      dbo.AccountProjectTask.AccountProjectMilestoneId, dbo.AccountProjectTask.CreatedOn, dbo.AccountProjectTask.CreatedByEmployeeId, 
                      dbo.AccountProjectTask.ModifiedOn, dbo.AccountProjectTask.ModifiedByEmployeeId, dbo.AccountEmployee.FirstName AS CreatedByFirstName, 
                      dbo.AccountEmployee.LastName AS CreatedByLastName, dbo.AccountProjectMilestone.MilestoneDescription, dbo.AccountTaskType.TaskType, 
                      dbo.AccountStatus.Status, dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, AccountEmployee_1.FirstName, 
                      AccountEmployee_1.LastName, AccountEmployee_1.EMailAddress, dbo.AccountEmployeeProjectPreferences.SendEMailOfActivityAssignToMe, 
                      dbo.AccountEmployeeProjectPreferences.SendEMailOfAllProjectActivities, dbo.AccountPriority.Priority
FROM         dbo.AccountEmployeeProjectPreferences INNER JOIN
                      dbo.AccountEmployee AS AccountEmployee_1 ON 
                      dbo.AccountEmployeeProjectPreferences.AccountEmployeeId = AccountEmployee_1.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectMilestone INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountProjectMilestone.AccountProjectMilestoneId = dbo.AccountProjectTask.AccountProjectMilestoneId INNER JOIN
                      dbo.AccountTaskType ON dbo.AccountProjectTask.AccountTaskTypeId = dbo.AccountTaskType.AccountTaskTypeId INNER JOIN
                      dbo.AccountStatus ON dbo.AccountProjectTask.TaskStatusId = dbo.AccountStatus.AccountStatusId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountProjectTask.CreatedByEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProject ON dbo.AccountProjectTask.AccountProjectId = dbo.AccountProject.AccountProjectId ON 
                      dbo.AccountEmployeeProjectPreferences.AccountProjectId = dbo.AccountProjectTask.AccountProjectId INNER JOIN
                      dbo.AccountPriority ON dbo.AccountProjectTask.AccountPriorityId = dbo.AccountPriority.AccountPriorityId
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vueAccountProjectTaskWithPreferences';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' = 721
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountProject"
            Begin Extent = 
               Top = 726
               Left = 38
               Bottom = 841
               Right = 251
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountPriority"
            Begin Extent = 
               Top = 246
               Left = 285
               Bottom = 361
               Right = 449
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2460
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vueAccountProjectTaskWithPreferences';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AccountEmployeeProjectPreferences"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 306
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountEmployee_1"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountProjectMilestone"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 361
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountProjectTask"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 481
               Right = 256
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountTaskType"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 601
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountStatus"
            Begin Extent = 
               Top = 126
               Left = 280
               Bottom = 241
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountEmployee"
            Begin Extent = 
               Top = 606
               Left = 38
               Bottom', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vueAccountProjectTaskWithPreferences';

