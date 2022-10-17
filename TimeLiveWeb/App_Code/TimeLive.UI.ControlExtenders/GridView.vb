Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design
Namespace ControlExtenders

    Partial Public Class GridView : Inherits System.Web.UI.WebControls.GridView


        Protected Overrides Sub OnLoad(ByVal e As EventArgs)
            MyBase.OnLoad(e)
            Me.SetPageSize()

        End Sub
        Protected Overloads Overrides Sub InitializeRow(ByVal row As GridViewRow, ByVal fields As DataControlField())
            MyBase.InitializeRow(row, fields)
            If row.RowType = DataControlRowType.Header Then
                InitializeHeaderRow(row, fields)
            End If

        End Sub
        Dim FilterBLL As New AccountFilterModuleBLL
        Dim m_SystemFilterModuleFieldName As String
        Dim SystemFilterModuleId As Guid
        Dim m_SystemFilterModuleFieldId As Guid
        'Dim FiledsSortExpression As New Hashtable
        'Dim IsPageLoad As Boolean = True
        Protected Overridable Sub InitializeHeaderRow(ByVal row As GridViewRow, ByVal fields As DataControlField())
            ' AddGlyph(Me, row)
            AddFilters(row, fields)

        End Sub

        Protected Overridable Sub AddFilters(ByVal headerRow As GridViewRow, ByVal fields As DataControlField())
            For i As Integer = 0 To Columns.Count - 1
                SystemFilterModuleId = FilterBLL.InsertSystemModule(Me.Page)
                If Not Columns(i).SortExpression = [String].Empty Then
                    m_SystemFilterModuleFieldName = Columns(i).HeaderText
                    ResourceHelper.GetFromResource(m_SystemFilterModuleFieldName)
                    FilterBLL.InsertSystemFilterModuleField(SystemFilterModuleId, m_SystemFilterModuleFieldName, True, Columns(i).HeaderText)
                    m_SystemFilterModuleFieldId = FilterBLL.GetSystemFilterModuleField(SystemFilterModuleId, m_SystemFilterModuleFieldName, True)

                    AddFilter(i, headerRow.Cells(i), fields(i))

                    Dim dt As AccountFilterModule.vueAccountFilterModuleDataTable = New AccountFilterModuleBLL().GetEmployeeFilters(SystemFilterModuleId, m_SystemFilterModuleFieldId, DBUtilities.GetSessionAccountEmployeeId)
                    Dim dr As AccountFilterModule.vueAccountFilterModuleRow
                    If dt.Rows.Count = 0 Then
                        FilterBLL.InsertFilters(m_SystemFilterModuleFieldName, Nothing, Nothing, m_SystemFilterModuleFieldId, True, Me.Page, Me, Nothing)
                    End If
                End If
            Next

        End Sub
        Dim m_txtFilter As New Hashtable
        Dim m_ddlFilter As New Hashtable
        Dim nFilterTextAndValue As New Hashtable
        Protected Overridable Sub AddFilter(ByVal columnIndex As Integer, ByVal headerCell As TableCell, ByVal field As DataControlField)
            If headerCell.Controls.Count = 0 Then
                Dim ltlHeaderText As New LiteralControl(headerCell.Text)
                headerCell.Controls.Add(ltlHeaderText)
            End If
            Dim ltlBreak As New LiteralControl("</br>")
            headerCell.Controls.Add(ltlBreak)
            Dim txtFilter As TextBox = Nothing

            If m_txtFilter.Contains(columnIndex) Then
                txtFilter = DirectCast(m_txtFilter(columnIndex), TextBox)
            Else
                txtFilter = New TextBox()
                txtFilter.ID = FilterBLL.GetSystemFilterModuleField(SystemFilterModuleId, m_SystemFilterModuleFieldName, True).ToString()
                nFilterTextAndValue.Add(txtFilter.ID, txtFilter.Text)
                txtFilter.Text = FilterBLL.GetLastFilters(SystemFilterModuleId, New System.Guid(txtFilter.ID), "")
                ''txtFilter.Style.Add(HtmlTextWriterStyle.Width, Convert.ToString(field.ItemStyle.Width))
                If field.ItemStyle.Width.Value <> 0.0R Then
                    ''txtFilter.Style.Add(HtmlTextWriterStyle.Width, Convert.ToString(100))
                ElseIf field.HeaderStyle.Width.Value <> 0.0R Then
                    ''txtFilter.Style.Add(HtmlTextWriterStyle.Width, Convert.ToString(field.HeaderStyle.Width.Value))
                Else
                End If
                ''txtFilter.Attributes.Add("Width", "8%")
                txtFilter.Style.Add(HtmlTextWriterStyle.Width, Convert.ToString(75) & "%")
                ''txtFilter.Style.Add(HtmlTextWriterStyle.TextAlign, "Center")
                m_txtFilter(columnIndex) = txtFilter
                AddHandler txtFilter.TextChanged, AddressOf Me.HandleFilterCommand
                Dim js As String
                js = "javascript:" & Page.GetPostBackEventReference(Me, "@@@@@buttonPostBack") & ";"
                txtFilter.Attributes.Add("onchange", js)
            End If
            headerCell.Controls.Add(txtFilter)
        End Sub
        Private Sub HandleFilterCommand(ByVal sender As Object, ByVal e As EventArgs)
            If Not FilterBLL.GetSystemModule(SystemFilterModuleId) = "AccountApproval.aspx" Then
                'this is required to make sure that unsetting of filter is also handled 
                Me.RequiresDataBinding = True
                ' Dim filterArgs As New FilterCommandEventArgs()
                'filterArgs.FilterExpression = GetFilterCommand()
                'IsPageLoad = False
                Dim filterString = GetFilterCommand()
                System.Web.HttpContext.Current.Session.Add("HandleFilterCommand", "1")
                'Me.OnFilterCommand(filterArgs)
            End If
        End Sub
        Dim FiledName As String
        Protected Overloads Overrides Sub OnPreRender(ByVal e As EventArgs)
            If Not FilterBLL.GetSystemModule(SystemFilterModuleId) = "AuditTrail.aspx" And Not FilterBLL.GetSystemModule(SystemFilterModuleId) = "AccountApproval.aspx" And Not FilterBLL.GetSystemModule(SystemFilterModuleId) = "ReportDesign.aspx" And Not FilterBLL.GetSystemModule(SystemFilterModuleId) = "AccountInvoiceForm.aspx" And Not FilterBLL.GetSystemModule(SystemFilterModuleId) = "AccountEmployeeTimeEntryAudit.aspx" And Not FilterBLL.GetSystemModule(SystemFilterModuleId) = "AccountExpenseEntryAudit.aspx" Then
                Dim filterCommand As String = GetFilterCommand()
                'If [String].IsNullOrEmpty(filterCommand) = False Then
                ApplyFilterCommand(filterCommand)
                If Not System.Web.HttpContext.Current.Session("HandleFilterCommand") Is Nothing Then
                    System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl, False)
                    System.Web.HttpContext.Current.Session.Remove("HandleFilterCommand")
                End If
                'End If

            End If
            Try
                MyBase.OnPreRender(e)
            Catch ex As Exception
                Exit Sub
            End Try
        End Sub
        Public Function IsBoundColumn(ByVal objColumn As DataControlField) As Boolean
            If Not objColumn.SortExpression = String.Empty Then
                Return True
            End If
        End Function
        Dim TextValue As String
        Protected Overridable Function GetFilterCommand() As String
            ' Return ""
            Dim filterCommand As String = ""
            Dim i As Integer = 0
            While i < Me.Columns.Count
                If IsBoundColumn(Me.Columns(i)) Then
                    If Me.HeaderRow Is Nothing Then
                        i = i + 1
                        Continue While
                    End If
                    Dim headerCell As DataControlFieldHeaderCell = DirectCast(Me.HeaderRow.Cells(i), DataControlFieldHeaderCell)
                    Dim txtFilter As TextBox = DirectCast(m_txtFilter(i), TextBox)
                    Dim aColumn As DataControlField
                    'If Not (TypeOf Me.Columns(i) Is BoundField) Then
                    '    i = i + 1
                    '    Continue While
                    'End If
                    aColumn = DirectCast(Me.Columns(i), DataControlField)
                    If [String].IsNullOrEmpty(txtFilter.Text) Then
                        i = i + 1
                        Continue While
                    End If
                    Dim ResetFilter As Integer = System.Web.HttpContext.Current.Session("ResetFilter")
                    If ResetFilter = 1 Then
                        TextValue = ""
                        txtFilter.Text = TextValue

                    Else
                        TextValue = txtFilter.Text
                        txtFilter.Text = TextValue
                        TextValue = TextValue.Replace("'", "''")
                    End If

                    If [String].IsNullOrEmpty(filterCommand) Then
                        '                       Convert(TimespanColumn, 'System.String'
                        filterCommand = "Convert(" & aColumn.SortExpression + "," + Chr(39) + "System.String" + Chr(39) + ") like " + Chr(39) + "%" + TextValue + "%" + Chr(39)
                        nFilterTextAndValue(txtFilter.ID) = TextValue
                        ' nFilterTextAndValue.Add((aColumn.SortExpression & "_txtFilter"), TextValue)
                    Else
                        filterCommand += " AND " + "Convert(" & aColumn.SortExpression + "," + Chr(39) + "System.String" + Chr(39) + ") like " + Chr(39) + "%" + TextValue + "%" + Chr(39)
                        nFilterTextAndValue(txtFilter.ID) = TextValue
                        'nFilterTextAndValue.Add((aColumn.SortExpression & "_txtFilter"), TextValue)
                    End If
                End If

                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            System.Web.HttpContext.Current.Session.Remove("ResetFilter")
            Return filterCommand
        End Function
        Protected Overridable Sub ApplyFilterCommand(ByVal filterCommand As String)
            Dim CurrentPage As Control = Page
            Dim dsv As DataSourceView = Me.GetData()
            Dim objDataSourceView As ObjectDataSourceView
            Try
                If FilterBLL.GetSystemModule(SystemFilterModuleId) = "ExpenseEntryArchive.aspx" Or FilterBLL.GetSystemModule(SystemFilterModuleId) = "TimeEntryArchive.aspx" Or FilterBLL.GetSystemModule(SystemFilterModuleId) = "TimeSheetApproval.aspx" Or FilterBLL.GetSystemModule(SystemFilterModuleId) = "ExpenseApproval.aspx" Or FilterBLL.GetSystemModule(SystemFilterModuleId) = "MyTimeOffRequestApproval.aspx" Then
                    If System.Web.HttpContext.Current.Session("IsCheckAll") <> "1" And System.Web.HttpContext.Current.Session("IsUnCheckAll") <> "1" Then
                        objDataSourceView = dsv
                        objDataSourceView.FilterExpression = filterCommand
                        Me.DataBind()
                    End If
                    System.Web.HttpContext.Current.Session.Remove("IsCheckAll")
                    System.Web.HttpContext.Current.Session.Remove("IsUnCheckAll")
                Else
                    objDataSourceView = dsv
                    objDataSourceView.FilterExpression = filterCommand
                    Me.DataBind()
                End If

                If Me.Rows.Count = 0 Then
                    objDataSourceView.FilterExpression = filterCommand
                    For Each keys As String In nFilterTextAndValue.Keys
                        Dim nTextValue As String = FilterBLL.GetLastFilters(SystemFilterModuleId, New System.Guid(keys), nFilterTextAndValue(keys))
                        Dim Field As Array = keys.Split("_")
                        If nFilterTextAndValue(keys) <> "" Then
                            Me.ShowHeaderWhenEmpty = True
                            Me.EmptyDataText = "There are no items to display."
                        End If
                    Next
                    Me.DataBind()
                End If
                For Each keys As String In nFilterTextAndValue.Keys
                    FilterBLL.UpdateFilters(New System.Guid(keys), nFilterTextAndValue(keys), nFilterTextAndValue(keys), True, Me.Page, Me)
                Next
            Catch ex As Exception
                FilterBLL.ResetFilters(CurrentPage, Page)
                System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl, False)
            End Try
        End Sub
        Public Sub ShowNotFoundMessage()
            Dim strMessage As String
            For Each keys As String In nFilterTextAndValue.Keys
                Dim Field As Array = keys.Split("_")
                If [String].IsNullOrEmpty(strMessage) Then
                    strMessage = "No records found for this specified search specification." + "\n\n" + Field(0) + " = " + nFilterTextAndValue(keys)
                Else
                    strMessage += "\n\n" + Field(0) + " = " + nFilterTextAndValue(keys)
                End If
            Next


            Dim strScript As String = "alert('" & strMessage & "'); "
            If (Not Me.Page.ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "clientScript", strScript, True)
            End If
        End Sub
        Public Sub SetPageSize()
            'Skip hardcoded page size for role permission
            If Me.PageSize <> 500 And Me.PageSize <> 25 Then
                Me.PageSize = DBUtilities.GetPageSize
            End If
        End Sub
    End Class

End Namespace