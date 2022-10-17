CREATE VIEW dbo.vxp_DetailTimesheet
AS
SELECT     dbo.AccountEmployee.EmployeeCode, dbo.AccountEmployee.AccountEmployeeId, dbo.AccountEmployeeTimeEntry.TimeEntryDate, 
                      dbo.AccountProject.AccountProjectId, dbo.AccountProject.AccountClientId, dbo.AccountProject.ProjectCode, dbo.AccountProject.ProjectName, 
                      dbo.AccountProjectTask.AccountProjectTaskId, dbo.AccountProjectTask.TaskName, dbo.AccountTaskType.TaskType, dbo.AccountEmployeeTimeEntry.Description, 
                      dbo.AccountEmployeeTimeEntry.Approved, CASE WHEN CAST(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) AS int) < 10 THEN '0' + CAST(DATEPART(hh, 
                      dbo.AccountEmployeeTimeEntry.TotalTime) AS varchar(1)) ELSE CAST(DATEPART(hh, dbo.AccountEmployeeTimeEntry.TotalTime) AS varchar(2)) END AS Hours, 
                      CASE WHEN CAST(DATEPART(mi, dbo.AccountEmployeeTimeEntry.TotalTime) AS int) < 10 THEN '0' + CAST(DATEPART(mi, dbo.AccountEmployeeTimeEntry.TotalTime) 
                      AS varchar(1)) ELSE CAST(DATEPART(mi, dbo.AccountEmployeeTimeEntry.TotalTime) AS varchar(2)) END AS Minutes, CASE WHEN UPPER(AccountWorkTypeId) 
                      = 1 THEN 'F' ELSE 'T' END AS IsOverTime
FROM         dbo.AccountEmployeeTimeEntry INNER JOIN
                      dbo.AccountProject ON dbo.AccountEmployeeTimeEntry.AccountProjectId = dbo.AccountProject.AccountProjectId INNER JOIN
                      dbo.AccountEmployee ON dbo.AccountEmployeeTimeEntry.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId INNER JOIN
                      dbo.AccountProjectTask ON dbo.AccountEmployeeTimeEntry.AccountProjectTaskId = dbo.AccountProjectTask.AccountProjectTaskId INNER JOIN
                      dbo.AccountTaskType ON dbo.AccountProjectTask.AccountTaskTypeId = dbo.AccountTaskType.AccountTaskTypeId
WHERE     (dbo.AccountEmployeeTimeEntry.Approved = 1)
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vxp_DetailTimesheet';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'     Column = 1440
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vxp_DetailTimesheet';


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
         Begin Table = "AccountEmployeeTimeEntry"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 338
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountProject"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 222
               Right = 250
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountEmployee"
            Begin Extent = 
               Top = 222
               Left = 38
               Bottom = 330
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountProjectTask"
            Begin Extent = 
               Top = 330
               Left = 38
               Bottom = 438
               Right = 267
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AccountTaskType"
            Begin Extent = 
               Top = 438
               Left = 38
               Bottom = 546
               Right = 246
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
    ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vxp_DetailTimesheet';

