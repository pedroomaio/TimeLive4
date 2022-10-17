-- SystemReportDataSource

Insert into [SystemReportDataSourceField] values(
'F2553353-7B53-461F-AEE1-074E92F5014A' , '07C1C8C9-C148-40C0-A700-AF2FB1A0A149' , 'AvailableHours' , 70 , 1 , null , null , 6 , '0DA31DDC-9040-46FA-A33A-74E06A645050' , 'Available Hours' , 0 , 0)

Update [SystemReportDataSourceField]
set SystemReportDataSourceFieldColumnOrder = 7
where SystemReportDataSourceFieldId = '72F08A75-7886-489E-9719-2317E36DD558'

Update [SystemReportDataSourceField]
set SystemReportDataSourceFieldColumnOrder = 8
where SystemReportDataSourceFieldId = '203C900A-79E3-4AA3-876F-2909A968A53D'

-- AccountReportColumn 

Update AccountReportColumn
set ColumnOrder = ColumnOrder + 1
where ColumnOrder >= 6 and AccountReportId = 'eb0fc9d4-ef60-451b-834f-261dfb0228be'

Insert into AccountReportColumn values(
'AADE0D4E-3707-4A94-B407-001C15635055' , 'eb0fc9d4-ef60-451b-834f-261dfb0228be' , 'Available Hours' , 'F2553353-7B53-461F-AEE1-074E92F5014A' , 6 , null , null)

--

/****** Object:  View [dbo].[vueAccountEmployeeTimeOffRequestForReport]    Script Date: 15/12/2016 13:39:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vueAccountEmployeeTimeOffRequestForReport]
AS
SELECT        dbo.AccountEmployeeTimeOffRequest.AccountEmployeeTimeOffRequestId, dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId, dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId, 
                         dbo.AccountEmployeeTimeOffRequest.RequestSubmitDate, dbo.AccountEmployeeTimeOffRequest.HoursOff, dbo.AccountEmployeeTimeOffRequest.StartDate, dbo.AccountEmployeeTimeOffRequest.EndDate, 
                         dbo.AccountEmployeeTimeOffRequest.InApproval, dbo.AccountEmployeeTimeOffRequest.Approved, dbo.AccountEmployeeTimeOffRequest.Rejected, dbo.AccountEmployeeTimeOffRequest.Description, 
                         dbo.AccountEmployeeTimeOffRequest.ApprovedOn, dbo.AccountEmployeeTimeOffRequest.ApprovedBy, dbo.AccountEmployeeTimeOffRequest.DayOff, dbo.AccountEmployeeTimeOffRequest.CreatedByEmployee, 
                         dbo.AccountEmployeeTimeOffRequest.CreatedOn, dbo.AccountEmployeeTimeOffRequest.ModifiedByEmployeeId, dbo.AccountEmployeeTimeOffRequest.ModifiedOn, 
                         dbo.AccountEmployeeTimeOffRequest.AccountId, dbo.AccountEmployeeTimeOffRequest.AccountProjectId, dbo.AccountTimeOffType.AccountTimeOffType, dbo.AccountTimeOffType.IsTimeOffRequestRequired, 
                         CASE WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName + ' ' + '(Disabled)' WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 2 AND 
                         dbo.AccountEmployee.IsDisabled = 0 THEN dbo.AccountEmployee.LastName + ' ' + dbo.AccountEmployee.FirstName WHEN dbo.AccountPreferences.ShowEmployeeNameBy = 1 AND 
                         dbo.AccountEmployee.IsDisabled = 1 THEN dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName + ' ' + '(Disabled)' ELSE dbo.AccountEmployee.FirstName + ' ' + dbo.AccountEmployee.LastName
                          END AS EmployeeName, dbo.AccountLocation.AccountLocation, dbo.AccountLocation.AccountLocationId, dbo.AccountTimeOffPolicy.AccountTimeOffPolicy, dbo.AccountDepartment.AccountDepartmentId, 
                         dbo.AccountDepartment.DepartmentCode, dbo.AccountDepartment.DepartmentName, dbo.AccountRole.AccountRoleId, dbo.AccountRole.Role, 
                         AccountEmployee_1.FirstName + ' ' + AccountEmployee_1.LastName AS ApprovedByEmployeeName, dbo.AccountProject.ProjectName, dbo.AccountProject.ProjectDescription, 
                         CASE WHEN rejected = 0 THEN CONVERT(bit, 1) ELSE CONVERT(bit, 0) END AS Submitted, dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId,
						 (Select Available from VueAccountEmployeeTimeOff where dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = VueAccountEmployeeTimeOff.AccountTimeOffTypeId and dbo.AccountEmployee.AccountEmployeeId = VueAccountEmployeeTimeOff.AccountEmployeeId) as [AvailableHours]
FROM            dbo.AccountRole RIGHT OUTER JOIN
                         dbo.AccountEmployeeTimeOffRequest LEFT OUTER JOIN
                         dbo.AccountProject ON dbo.AccountEmployeeTimeOffRequest.AccountProjectId = dbo.AccountProject.AccountProjectId LEFT OUTER JOIN
                         dbo.AccountEmployee ON dbo.AccountEmployeeTimeOffRequest.AccountEmployeeId = dbo.AccountEmployee.AccountEmployeeId LEFT OUTER JOIN
                         dbo.AccountPreferences ON dbo.AccountEmployeeTimeOffRequest.AccountId = dbo.AccountPreferences.AccountId LEFT OUTER JOIN
                         dbo.AccountEmployee AS AccountEmployee_1 ON dbo.AccountEmployeeTimeOffRequest.ApprovedBy = AccountEmployee_1.AccountEmployeeId ON 
                         dbo.AccountRole.AccountRoleId = dbo.AccountEmployee.AccountRoleId LEFT OUTER JOIN
                         dbo.AccountDepartment ON dbo.AccountEmployee.AccountDepartmentId = dbo.AccountDepartment.AccountDepartmentId LEFT OUTER JOIN
                         dbo.AccountTimeOffPolicy ON dbo.AccountEmployee.AccountTimeOffPolicyId = dbo.AccountTimeOffPolicy.AccountTimeOffPolicyId LEFT OUTER JOIN
                         dbo.AccountLocation ON dbo.AccountEmployee.AccountLocationId = dbo.AccountLocation.AccountLocationId LEFT OUTER JOIN
                         dbo.AccountTimeOffType ON dbo.AccountEmployeeTimeOffRequest.AccountTimeOffTypeId = dbo.AccountTimeOffType.AccountTimeOffTypeId


GO


/****** Object:  View [dbo].[rptvueAccountEmployeeTimeOffRequest]    Script Date: 15/12/2016 13:38:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[rptvueAccountEmployeeTimeOffRequest]
AS
SELECT        AccountEmployeeTimeOffRequestId, AccountTimeOffTypeId, AccountEmployeeId, RequestSubmitDate, HoursOff, StartDate, EndDate, InApproval, Submitted, Approved, Rejected, Description, ApprovedOn, 
                         ApprovedBy, DayOff, CreatedByEmployee, CreatedOn, ModifiedByEmployeeId, ModifiedOn, AccountId, AccountProjectId, AccountTimeOffType, IsTimeOffRequestRequired, EmployeeName, AccountLocation, 
                         AccountLocationId, AccountTimeOffPolicy, AccountDepartmentId, DepartmentCode, DepartmentName, AccountRoleId, Role, ApprovedByEmployeeName, ProjectName, ProjectDescription, AccountTimeOffPolicyId, 
                         dbo.CombineValuesForTimeOffCurrentApprover(AccountEmployeeTimeOffRequestId) AS CurrentApprover, AvailableHours
FROM            dbo.vueAccountEmployeeTimeOffRequestForReport


GO