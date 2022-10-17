Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Web.UI.Control
Public Class AspNetCustomControlsBLL
    Public Const DROPDOWN_SMALL_WIDTH As Integer = 150
    Dim CustomFieldRow As TableRow
    Dim CustomFieldCell As TableCell
    Dim CustomFieldHeader As TableHeaderCell
    Dim CustomFieldTable As Table
    Public Function AddTextBox(ID As String, Optional MaximumLenght As Integer = 0, Optional DefaultValue As String = "", Optional Width As String = "", Optional CssClass As String = "", Optional OnBlurAttribute As String = "", Optional ValidationGroup As String = "") As TextBox
        Dim txt As New TextBox
        txt.ID = ID
        txt.Text = DefaultValue
        If MaximumLenght <> 0 Then
            txt.MaxLength = MaximumLenght
        End If
        If Width <> "" Then
            txt.Width = Width
        End If
        If CssClass <> "" Then
            txt.CssClass = CssClass
        End If
        If OnBlurAttribute <> "" Then
            txt.Attributes.Add("onblur", OnBlurAttribute)
        End If
        If ValidationGroup <> "" Then
            txt.ValidationGroup = ValidationGroup
        End If
        Return txt
    End Function
    Public Function AddDateCalendarPopup(ByVal ID As String, Optional CssClass As String = "", Optional OnBlurAttribute As String = "", Optional Width As String = "", Optional IsShowPopUpLocationOnBottom As Boolean = False) As eWorld.UI.CalendarPopup
        Dim CalendarPopup As New eWorld.UI.CalendarPopup
        CalendarPopup.ID = ID
        If IsShowPopUpLocationOnBottom Then
            CalendarPopup.PopupLocation = eWorld.UI.DisplayLocation.Bottom
        End If
        CalendarPopup.SkinID = "DatePicker"
        If Width <> "" Then
            CalendarPopup.Width = Width
        End If
        If OnBlurAttribute <> "" Then
            CalendarPopup.Attributes.Add("onblur", OnBlurAttribute)
        End If
        Return CalendarPopup
    End Function
    Public Function AddDropDownList(ID As String, Optional CssClass As String = "", Optional OnBlurAttribute As String = "", Optional Width As String = "") As DropDownList
        Dim ddl As New DropDownList
        ddl.ID = ID
        ddl.Width = DROPDOWN_SMALL_WIDTH
        If Width <> "" Then
            ddl.Width = Width
        End If
        AddDropDownListItem("None", "None", ddl)
        If OnBlurAttribute <> "" Then
            ddl.Attributes.Add("onblur", OnBlurAttribute)
        End If
        Return ddl
    End Function
    Public Function AddLabel(ID As String, Caption As String, Optional CssClass As String = "") As Label
        Dim lbl As New Label
        lbl.ID = "lbl" & ID

        lbl.Text = Caption & ": "
        If CssClass <> "" Then
            lbl.CssClass = CssClass
        End If
        Return lbl
    End Function
    Public Sub AddDropDownListItem(ByVal Text As String, ByVal Value As String, ByVal ddl As DropDownList)
        Dim item As New System.Web.UI.WebControls.ListItem
        ddl.AppendDataBoundItems = True
        item.Text = Text
        item.Value = Value
        ddl.Items.Add(item)
    End Sub
    Public Function AddRequiredFieldValidator(ID As String, ControlToValidate As String, Optional ValidationGroup As String = "") As RequiredFieldValidator
        Dim Req As New RequiredFieldValidator
        Req.ID = "RFV" & ID
        Req.ControlToValidate = ControlToValidate
        Req.Display = ValidatorDisplay.Dynamic
        Req.ErrorMessage = "*"
        Req.CssClass = "ErrorMessage"
        If ValidationGroup <> "" Then
            Req.ValidationGroup = ValidationGroup
        End If
        Return Req
    End Function
    Public Function AddRangeValidator(ID As String, ControlToValidate As String, MinimumValue As String, MaximumValue As String, Optional ValidationGroup As String = "") As RangeValidator
        Dim RV As New RangeValidator
        RV.ID = "RV" & ID
        RV.ControlToValidate = ControlToValidate
        RV.Display = ValidatorDisplay.Dynamic
        RV.CssClass = "ErrorMessage"
        RV.ErrorMessage = "Value must be in numeric"
        RV.MinimumValue = MinimumValue
        RV.MaximumValue = MaximumValue
        RV.ErrorMessage = "Value must be between " & MinimumValue & " to " & MaximumValue & "."
        RV.Type = ValidationDataType.Double
        If ValidationGroup <> "" Then
            RV.ValidationGroup = ValidationGroup
        End If
        Return RV
    End Function
    Public Sub AddFilterTableSubHeader()
        CustomFieldRow = New TableRow
        CustomFieldHeader = New TableHeaderCell
        CustomFieldHeader.CssClass = "FormViewSubHeader"
        Dim lblSubHeader As New Label
        CustomFieldHeader.ColumnSpan = 2 'FilterTable.Rows.Count - 1
        'AddFilterCellIntoFilterRow()
        lblSubHeader.Text = "Custom Fields"
        Me.CustomFieldHeader.Controls.Add(lblSubHeader)

        Me.CustomFieldRow.Cells.Add(CustomFieldHeader)
        CustomFieldTable.Rows.Add(CustomFieldRow)
    End Sub
    Public Sub AddRow()
        CustomFieldRow = New TableRow
        CustomFieldTable.Rows.Add(CustomFieldRow)
    End Sub
    Public Sub AddCell()
        CustomFieldCell = New TableCell
        ' FilterCell.BorderWidth = 1
    End Sub
    Public Sub AddFilterCellIntoFilterRow(Optional ByVal SpecificWidth As String = "70%", Optional ByVal SpecificHeight As String = "")
        'FilterCell.Width = 600%
        CustomFieldRow.Cells.Add(CustomFieldCell)
        CustomFieldCell.Attributes.Add("Width", SpecificWidth)
        If SpecificHeight <> "" Then
            CustomFieldCell.Attributes.Add("Height", SpecificHeight)
        End If
        'FilterTable.BorderWidth = 2
        'FilterTable.BorderStyle = BorderStyle.Solid
        'FilterRow.BorderStyle = BorderStyle.Solid
        'FilterCell.BorderStyle = BorderStyle.Solid
    End Sub
    Public Sub AddFilterCellIntoFilterRowForCaption(Optional ByVal CSSClass As String = "", Optional ByVal SpecificWidth As String = "30%")
        CustomFieldCell.Attributes.Add("Width", SpecificWidth)
        If CSSClass <> "" Then
            CustomFieldCell.CssClass = CSSClass
        End If
        CustomFieldRow.Cells.Add(CustomFieldCell)

        'FilterTable.BorderWidth = 2
        'FilterTable.BorderStyle = BorderStyle.Solid
        'FilterRow.BorderStyle = BorderStyle.Solid
        'FilterCell.BorderStyle = BorderStyle.Solid
    End Sub
    Public Sub AddCaption(ByVal ID As String, ByVal Caption As String, Optional ByVal AddCellToRow As Boolean = True, Optional ByVal SetRight As Boolean = True, Optional ByVal AddCellToRowForDate As Boolean = False, Optional ByVal SpecificWidth As String = "30%", Optional IsModalPopup As Boolean = False)
        Dim lbl As Label
        Me.AddCell()
        If IsModalPopup <> True Then
            lbl = Me.AddLabel(ID, Caption)
        Else
            lbl = Me.AddLabel(ID, Caption, "mylabelCustomField")
        End If
        Me.CustomFieldCell.Controls.Add(lbl)
        If AddCellToRow = True Then
            Me.AddFilterCellIntoFilterRowForCaption(IIf(IsModalPopup = True, "FormViewLabelCellCustomField", "FormViewLabelCell"), SpecificWidth)
        End If
        If SetRight Then
            CustomFieldCell.HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub
    Public Sub AddRequiredFieldValidatorAndSetCellValue(ID As String, ControlToValidate As String, IsRequired As Boolean, Optional ByVal ValidationGroup As String = "")
        Dim ReqFieldValidator As RequiredFieldValidator
        If IsRequired Then
            ReqFieldValidator = Me.AddRequiredFieldValidator(ID, ControlToValidate, ValidationGroup)
            Me.CustomFieldCell.Controls.Add(ReqFieldValidator)
        End If
    End Sub
    Public Sub AddCustomFields(CustomTable As Table, MasterEntityTypeId As Guid, Optional ByVal CaptionSpecifiedWidth As String = "30%", Optional ByVal ControlsSpecifiedWidth As String = "70%", Optional ByVal SpecifiedHeight As String = "", Optional ByVal ValidationGroup As String = "", Optional ByVal IsModalPopup As Boolean = False)
        Dim CustomFieldBLL As New AccountCustomFieldBLL
        Dim dt As AccountCustomField.vueAccountCustomFieldManageDataTable = CustomFieldBLL.GetvueAccountCustomFieldByAccountIdandMasterEntityTypeId(DBUtilities.GetSessionAccountId, MasterEntityTypeId)
        Dim dr As AccountCustomField.vueAccountCustomFieldManageRow
        If dt.Rows.Count > 0 Then
            CustomFieldTable = CustomTable
            CustomFieldTable.CssClass = "xFormView"
            CustomFieldTable.BorderWidth = 0
            If IsModalPopup <> True Then
                AddFilterTableSubHeader()
            End If

            Dim txtbox As TextBox
            Dim ddllist As DropDownList
            Dim ctldate As eWorld.UI.CalendarPopup

            For Each dr In dt.Rows
                If dr.IsDisabled <> True Then
                    Me.AddRow()
                    If dr.MasterCustomDataTypeId.ToString = "7e295184-9623-4445-b99f-48f07929dce5" Then 'For TextBox
                        Me.AddCaption(dr.DatabaseFieldName, dr.CustomFieldCaption, , IIf(IsModalPopup = True, False, True), , CaptionSpecifiedWidth, IsModalPopup)
                        Me.AddCell()
                        txtbox = Me.AddTextBox(dr.DatabaseFieldName, IIf(Not IsDBNull(dr.Item("MaximumLength")), dr.Item("MaximumLength"), 0), IIf(Not IsDBNull(dr.Item("DefaultValue")), dr.Item("DefaultValue"), ""), 150, , , ValidationGroup)
                        Me.CustomFieldCell.Controls.Add(txtbox)
                        Me.AddRequiredFieldValidatorAndSetCellValue(dr.DatabaseFieldName, txtbox.ID, dr.IsRequired, ValidationGroup)
                        Me.AddFilterCellIntoFilterRow(ControlsSpecifiedWidth, SpecifiedHeight)
                    ElseIf dr.MasterCustomDataTypeId.ToString = "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then 'For DropDownList
                        Me.AddCaption(dr.DatabaseFieldName, dr.CustomFieldCaption, , IIf(IsModalPopup = True, False, True), , CaptionSpecifiedWidth, IsModalPopup)
                        Me.AddCell()
                        ddllist = Me.AddDropDownList(dr.DatabaseFieldName)
                        ' Me.AddDropDownListItem("<None>", "<None>", ddllist)
                        If Not IsDBNull(dr.Item("DropDownOptions")) Then
                            Dim ddlitems() As String = Split(dr.DropDownOptions, "+")
                            For n As Integer = 0 To ddlitems.Length - 1
                                Me.AddDropDownListItem(ddlitems(n), ddlitems(n), ddllist)
                            Next
                        End If
                        If Not IsDBNull(dr.Item("DefaultValue")) Then
                            ddllist.SelectedValue = dr.DefaultValue
                        End If
                        Me.CustomFieldCell.Controls.Add(ddllist)
                        Me.AddRequiredFieldValidatorAndSetCellValue(dr.DatabaseFieldName, ddllist.ID, dr.IsRequired, ValidationGroup)
                        Me.AddFilterCellIntoFilterRow(ControlsSpecifiedWidth, SpecifiedHeight)
                    ElseIf dr.MasterCustomDataTypeId.ToString = "5942a0be-e7fe-4abb-b96f-f0b20d744ce3" Then 'For Date
                        Me.AddCaption(dr.DatabaseFieldName, dr.CustomFieldCaption, , IIf(IsModalPopup = True, False, True), , CaptionSpecifiedWidth, IsModalPopup)
                        Me.AddCell()
                        ctldate = Me.AddDateCalendarPopup(dr.DatabaseFieldName)
                        Me.CustomFieldCell.Controls.Add(ctldate)
                        Me.AddRequiredFieldValidatorAndSetCellValue(dr.DatabaseFieldName, ctldate.ID, dr.IsRequired, ValidationGroup)
                        Me.AddFilterCellIntoFilterRow(ControlsSpecifiedWidth, SpecifiedHeight)
                    ElseIf dr.MasterCustomDataTypeId.ToString = "bacd6824-9011-4c30-864f-0899fefc004f" Then 'For Number
                        Me.AddCaption(dr.DatabaseFieldName, dr.CustomFieldCaption, , IIf(IsModalPopup = True, False, True), , CaptionSpecifiedWidth, IsModalPopup)
                        Me.AddCell()
                        txtbox = Me.AddTextBox(dr.DatabaseFieldName, , IIf(Not IsDBNull(dr.Item("DefaultValue")), dr.Item("DefaultValue"), ""), 50, , , ValidationGroup)
                        Me.CustomFieldCell.Controls.Add(txtbox)
                        Me.AddRequiredFieldValidatorAndSetCellValue(dr.DatabaseFieldName, txtbox.ID, dr.IsRequired, ValidationGroup)
                        Me.CustomFieldCell.Controls.Add(Me.AddRangeValidator(dr.DatabaseFieldName, txtbox.ID, IIf(Not IsDBNull(dr.Item("MinimumValue")), dr.Item("MinimumValue"), "0"), IIf(Not IsDBNull(dr.Item("MaximumValue")), dr.Item("MaximumValue"), "999999"), ValidationGroup))
                        Me.AddFilterCellIntoFilterRow(ControlsSpecifiedWidth, SpecifiedHeight)
                    End If
                End If
            Next
        End If
    End Sub
End Class
