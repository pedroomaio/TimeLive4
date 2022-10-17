
Partial Class Employee_Default
    Inherits System.Web.UI.Page
    Dim FullSizeTableRow As TableRow
    Dim FullSizeTableCell As TableCell
    Dim DoubleTableRow As TableRow
    Dim DoubleTableCell As TableCell
    Public DoubleRows As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not (Me.Page.PreviousPage) Is Nothing) Then
            Dim ContentPlaceHolder1 As Control = Me.Page.PreviousPage.Master.FindControl("ContentPlaceHolder1")
            Dim GridView1 As GridView = CType(ContentPlaceHolder1.FindControl("GridView1"), GridView)
        End If
        Me.TS.Visible = False
        Me.APGC.Visible = False
        Me.MODGC.Visible = False
        Me.DGC.Visible = False
        Me.MP.Visible = False
        Me.MPGC.Visible = False
        'Me.PL.Visible = False
        'Me.PP.Visible = False
        'Me.PS.Visible = False
        Me.PTBG.Visible = False
        'Me.PTEC.Visible = False
        Me.PTC.Visible = False
        Me.OVDT.Visible = False
        Me.ODT.Visible = False
        Me.Or.Visible = False
        Me.WS.Visible = False
        Me.MT.Visible = False
        Me.IsVisibleDashboardGridAndChart()
        If Session("Role") = "External User" Then
            Me.DS.Visible = False
        End If
    End Sub
    Public Sub AddRowForFullTable()
        FullSizeTableRow = New TableRow
        FullSizeTable.Rows.Add(FullSizeTableRow)
    End Sub
    Public Sub AddCellForFullTable()
        FullSizeTableCell = New TableCell
        FullSizeTableCell.Attributes.Add("Width", "100%")
    End Sub
    Public Sub AddFullSizeTableCellIntoRow()
        FullSizeTableRow.Cells.Add(FullSizeTableCell)
    End Sub
    Public Sub AddRowForDoubleTable()
        DoubleTableRow = New TableRow
        DoubleTable.Rows.Add(DoubleTableRow)
    End Sub
    Public Sub AddCellForDoubleTable()
        DoubleTableCell = New TableCell
        DoubleTableCell.Attributes.Add("Width", "50%")
        DoubleTableCell.VerticalAlign = VerticalAlign.Top
    End Sub
    Public Sub AddDoubleTableCellIntoRow()
        DoubleTableRow.Cells.Add(DoubleTableCell)
    End Sub
    Public Sub AddLiteral()
        Dim objLiterControl As New LiteralControl
        objLiterControl.Text = "<br />"
        FullSizeTableCell.Controls.Add(objLiterControl)
    End Sub
    Public Sub AddLiteralForDoubleTable()
        Dim objLiterControl As New LiteralControl
        objLiterControl.Text = "<br />"
        DoubleTableCell.Controls.Add(objLiterControl)
    End Sub
    Public Sub IsVisibleDashboardGridAndChart()
        Dim bll As New AccountEmployeeDashboardBLL
        Dim dtDashboard As AccountEmployeeDashboard.AccountEmployeeDashboardDataTable = bll.GetAccountEmployeeDashboardByAccountIdAndAccountEmployeeId(DBUtilities.GetSessionAccountId, DBUtilities.GetSessionAccountEmployeeId)
        Dim drDashboard As AccountEmployeeDashboard.AccountEmployeeDashboardRow

        Dim dt As AccountFeatureManagement.AccountFeaturesDataTable

        If dtDashboard.Rows.Count > 0 Then
            drDashboard = dtDashboard.Rows(0)
            For Each drDashboard In dtDashboard.Rows
                If drDashboard.SystemEmployeeDashboardId = New Guid("8b8dac4f-190b-4665-a430-17e3388c9a35") Then
                    Me.AddRowForFullTable()
                    Me.AddCellForFullTable()
                    FullSizeTableCell.Controls.Add(Me.TS)
                    AddLiteral()
                    AddFullSizeTableCellIntoRow()
                    Me.TS.Visible = True
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("2eb5f81a-7f80-41eb-a5ab-67f281a479e9") Then
                    Me.AddRowForFullTable()
                    Me.AddCellForFullTable()
                    FullSizeTableCell.Controls.Add(Me.MT)
                    AddLiteral()
                    AddFullSizeTableCellIntoRow()
                    Me.MT.Visible = True
                End If
                dt = New AccountFeatureManagementBLL().GetAccountFeatureByAccountIdAndSystemFeatureId(DBUtilities.GetSessionAccountId, New System.Guid("DB17DEB7-51A0-4400-BF3B-9094E01EF038"))
                If dt.Rows.Count > 0 Then
                    If drDashboard.SystemEmployeeDashboardId = New Guid("9da22d6e-4f92-4b84-8283-be6162df1910") Then
                        If DoubleRows = 0 Then
                            Me.AddRowForDoubleTable()
                        End If
                        Me.AddCellForDoubleTable()
                        DoubleTableCell.Controls.Add(Me.WS)
                        AddLiteralForDoubleTable()
                        AddDoubleTableCellIntoRow()
                        DoubleRows += 1
                        Me.WS.Visible = True
                    End If

                    If drDashboard.SystemEmployeeDashboardId = New Guid("9bf4dd65-512b-411f-b71d-ff2722824fc0") Then
                        Me.AddRowForFullTable()
                        Me.AddCellForFullTable()
                        FullSizeTableCell.Controls.Add(Me.ODT)
                        AddLiteral()
                        AddFullSizeTableCellIntoRow()
                        Me.ODT.Visible = True
                    End If
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("cd0eb649-39b5-4ca2-935c-6c706c5c1685") Then
                    Me.AddRowForFullTable()
                    Me.AddCellForFullTable()
                    FullSizeTableCell.Controls.Add(Me.OVDT)
                    AddLiteral()
                    AddFullSizeTableCellIntoRow()
                    Me.OVDT.Visible = True
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("d499b170-6785-4e9a-8b92-cd3d91134e7e") Then
                    Me.AddRowForFullTable()
                    Me.AddCellForFullTable()
                    FullSizeTableCell.Controls.Add(Me.MP)
                    AddLiteral()
                    AddFullSizeTableCellIntoRow()
                    Me.MP.Visible = True
                End If

                'Double Size table in which one row has two cell.
                If drDashboard.SystemEmployeeDashboardId = New Guid("7a44f088-4217-4456-982c-ace38b2caf16") Then
                    If DoubleRows = 0 Then
                        Me.AddRowForDoubleTable()
                    End If
                    Me.AddCellForDoubleTable()
                    DoubleTableCell.Controls.Add(Me.Or)
                    AddLiteralForDoubleTable()
                    AddDoubleTableCellIntoRow()
                    DoubleRows += 1
                    Me.Or.Visible = True
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("411219a5-ec78-40b7-9850-37385716dd9b") Then
                    If DoubleRows = 0 Then
                        Me.AddRowForDoubleTable()
                    End If
                    Me.AddCellForDoubleTable()
                    DoubleTableCell.Controls.Add(Me.PTC)
                    AddLiteralForDoubleTable()
                    AddDoubleTableCellIntoRow()
                    DoubleRows += 1
                    Me.PTC.Visible = True
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("9e433f25-3fcb-4365-ad90-d15db881ba64") Then
                    If DoubleRows = 0 Then
                        Me.AddRowForDoubleTable()
                    End If
                    Me.AddCellForDoubleTable()
                    DoubleTableCell.Controls.Add(Me.PTBG)
                    AddLiteralForDoubleTable()
                    AddDoubleTableCellIntoRow()
                    DoubleRows += 1
                    Me.PTBG.Visible = True
                End If
                'If drDashboard.SystemEmployeeDashboardId = New Guid("8bc604f1-e485-4d5e-b0b5-297affcb6e78") Then
                '    If DoubleRows = 0 Then
                '        Me.AddRowForDoubleTable()
                '    End If
                '    Me.AddCellForDoubleTable()
                '    DoubleTableCell.Controls.Add(Me.PTEC)
                '    AddLiteralForDoubleTable()
                '    AddDoubleTableCellIntoRow()
                '    DoubleRows += 1
                '    Me.PTEC.Visible = True
                'End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("5e21d895-5f48-45fb-82ae-792ba7061b8e") Then
                    If DoubleRows = 0 Then
                        Me.AddRowForDoubleTable()
                    End If
                    Me.AddCellForDoubleTable()
                    DoubleTableCell.Controls.Add(Me.MPGC)
                    AddLiteralForDoubleTable()
                    AddDoubleTableCellIntoRow()
                    DoubleRows += 1
                    Me.MPGC.Visible = True
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("82115554-4ef7-465d-bca3-9f4067916d5d") Then
                    If DoubleRows = 0 Then
                        Me.AddRowForDoubleTable()
                    End If
                    Me.AddCellForDoubleTable()
                    DoubleTableCell.Controls.Add(Me.DGC)
                    AddLiteralForDoubleTable()
                    AddDoubleTableCellIntoRow()
                    DoubleRows += 1
                    Me.DGC.Visible = True
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("59574f62-547a-423c-8a12-76c47191ae05") Then
                    If DoubleRows = 0 Then
                        Me.AddRowForDoubleTable()
                    End If
                    Me.AddCellForDoubleTable()
                    DoubleTableCell.Controls.Add(Me.MODGC)
                    AddLiteralForDoubleTable()
                    AddDoubleTableCellIntoRow()
                    DoubleRows += 1
                    Me.MODGC.Visible = True
                End If
                If drDashboard.SystemEmployeeDashboardId = New Guid("eec56c67-0dbf-45e4-a3b0-9c4692ee8f9b") Then
                    If DoubleRows = 0 Then
                        Me.AddRowForDoubleTable()
                    End If
                    Me.AddCellForDoubleTable()
                    DoubleTableCell.Controls.Add(Me.APGC)
                    AddLiteralForDoubleTable()
                    AddDoubleTableCellIntoRow()
                    DoubleRows += 1
                    Me.APGC.Visible = True
                End If
                If DoubleRows = 2 Then
                    DoubleRows = 0
                End If
            Next
            If DoubleRows = 1 Then
                AddCellForDoubleTable()
                AddLiteralForDoubleTable()
                AddDoubleTableCellIntoRow()
            End If
        End If
        'Me.APGC.Visible = False
        'Me.MODGC.Visible = False
        'Me.DGC.Visible = False
        'Me.MPGC.Visible = False
    End Sub
End Class