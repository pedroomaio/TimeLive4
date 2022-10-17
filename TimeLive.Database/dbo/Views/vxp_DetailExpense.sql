CREATE VIEW dbo.vxp_DetailExpense
AS
SELECT     aee.AccountExpenseEntryId AS _ID, aee.AccountExpenseEntryDate AS _DATE, aee.AccountEmployeeId AS _EMPLOYEE, 
                      aemp.EmployeeCode + ' - ' + aemp.FirstName + ' ' + aemp.LastName AS _EMPLOYEENAME, apy.PartyName AS _CUSTOMER, SUBSTRING(aee.Description, 1,
                          (SELECT     PATINDEX('%;%', aee.Description) - 1 AS Expr1)) AS _DESCRIPTION, 8 AS _TIME, CASE WHEN upper(aet.ExpenseType) 
                      LIKE 'CAR MILEAGE%' THEN 'Km' WHEN upper(aet.ExpenseType) = 'TOLLS' THEN 'Portagens' ELSE '' END AS _TYPE, SUBSTRING(aee.Description,
                          (SELECT     PATINDEX('%Viatura %', aee.Description) AS Expr1) + 8, LEN(aee.Description)) AS _VEHICLE, 
                      CASE WHEN aee.quantity > 0 THEN aee.quantity ELSE 1 END AS _QUANTITY, aee.Rate AS _RATE, aee.Amount AS _AMOUNT
FROM         dbo.AccountExpenseEntry AS aee INNER JOIN
                      dbo.AccountProject AS ap ON aee.AccountProjectId = ap.AccountProjectId INNER JOIN
                      dbo.AccountParty AS apy ON ap.AccountClientId = apy.AccountPartyId INNER JOIN
                      dbo.AccountExpense AS ae ON aee.AccountExpenseId = ae.AccountExpenseId INNER JOIN
                      dbo.AccountExpenseType AS aet ON ae.AccountExpenseTypeId = aet.AccountExpenseTypeId INNER JOIN
                      dbo.AccountEmployee AS aemp ON aemp.AccountEmployeeId = aee.AccountEmployeeId
WHERE     (aee.Approved = 1) AND (ae.AccountExpenseName LIKE '%TOLLS%' OR
                      ae.AccountExpenseName LIKE '%MILEAGE%')
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vxp_DetailExpense';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'    Width = 1500
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
         Column = 1440
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vxp_DetailExpense';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[10] 2[31] 3) )"
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
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "aee"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ap"
            Begin Extent = 
               Top = 6
               Left = 282
               Bottom = 114
               Right = 491
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "apy"
            Begin Extent = 
               Top = 6
               Left = 529
               Bottom = 114
               Right = 714
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ae"
            Begin Extent = 
               Top = 127
               Left = 38
               Bottom = 235
               Right = 229
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "aet"
            Begin Extent = 
               Top = 127
               Left = 283
               Bottom = 235
               Right = 507
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "aemp"
            Begin Extent = 
               Top = 240
               Left = 38
               Bottom = 359
               Right = 264
            End
            DisplayFlags = 280
            TopColumn = 39
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
     ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vxp_DetailExpense';

