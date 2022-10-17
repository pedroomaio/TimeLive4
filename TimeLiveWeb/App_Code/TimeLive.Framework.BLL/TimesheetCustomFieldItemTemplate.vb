Imports Microsoft.VisualBasic
Public Class TimesheetCustomFieldItemTemplate
    Implements ITemplate
    Private m_CustomFieldRow As AccountCustomField.vueAccountCustomFieldManageRow
    Public Property CustomFieldRow() As AccountCustomField.vueAccountCustomFieldManageRow
        Get
            Return m_CustomFieldRow
        End Get
        Set(ByVal value As AccountCustomField.vueAccountCustomFieldManageRow)
            m_CustomFieldRow = value
        End Set
    End Property
    Public Sub New(CustomFieldRow As AccountCustomField.vueAccountCustomFieldManageRow)
        Me.CustomFieldRow = CustomFieldRow
    End Sub
    Private Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        Dim tbl As New System.Web.UI.WebControls.Table
        Dim tblrow As New System.Web.UI.WebControls.TableRow
        Dim tblcell As New System.Web.UI.WebControls.TableCell
        Dim CustomControlsBLL As New AspNetCustomControlsBLL
        With tbl
            .ID = "T" & CustomFieldRow.DatabaseFieldName
            .CssClass = "intab"
            .ClientIDMode = ClientIDMode.Static
        End With
        With tblrow
            .ID = "R" & CustomFieldRow.DatabaseFieldName
            .ClientIDMode = ClientIDMode.Static
        End With
        With tblcell
            .ID = "C" & CustomFieldRow.DatabaseFieldName
            .Width = 50
            .ClientIDMode = ClientIDMode.Static
        End With

        tbl.Rows.Add(tblrow)
        tblrow.Cells.Add(tblcell)

        If CustomFieldRow.IsDisabled <> True Then
            If CustomFieldRow.MasterCustomDataTypeId.ToString = "7e295184-9623-4445-b99f-48f07929dce5" Then 'For TextBox
                tblcell.Controls.Add(CustomControlsBLL.AddTextBox(CustomFieldRow.DatabaseFieldName, IIf(Not IsDBNull(CustomFieldRow.Item("MaximumLength")), CustomFieldRow.Item("MaximumLength"), 0), IIf(Not IsDBNull(CustomFieldRow.Item("DefaultValue")), CustomFieldRow.Item("DefaultValue"), ""), 150, , , "TimeEntry"))
                If CustomFieldRow.IsRequired Then
                    'tblcell.Controls.Add(CustomControlsBLL.AddRequiredFieldValidator(CustomFieldRow.DatabaseFieldName, CustomFieldRow.DatabaseFieldName, "TimeEntry"))
                End If
            ElseIf CustomFieldRow.MasterCustomDataTypeId.ToString = "574ded9c-7ad4-4649-8b39-d6741dd0ddca" Then 'For DropDownList
                Dim ddl As DropDownList = CustomControlsBLL.AddDropDownList(CustomFieldRow.DatabaseFieldName)
                tblcell.Controls.Add(ddl)
                If Not IsDBNull(CustomFieldRow.Item("DropDownOptions")) Then
                    Dim ddlitems() As String = Split(CustomFieldRow.DropDownOptions, "+")
                    For n As Integer = 0 To ddlitems.Length - 1
                        CustomControlsBLL.AddDropDownListItem(ddlitems(n), ddlitems(n), ddl)
                    Next
                End If
                If Not IsDBNull(CustomFieldRow.Item("DefaultValue")) Then
                    ddl.SelectedValue = CustomFieldRow.DefaultValue
                End If
            ElseIf CustomFieldRow.MasterCustomDataTypeId.ToString = "5942a0be-e7fe-4abb-b96f-f0b20d744ce3" Then 'For Date
                tblcell.Controls.Add(CustomControlsBLL.AddDateCalendarPopup(CustomFieldRow.DatabaseFieldName, , , 100, True))
            ElseIf CustomFieldRow.MasterCustomDataTypeId.ToString = "bacd6824-9011-4c30-864f-0899fefc004f" Then 'For Number
                tblcell.Controls.Add(CustomControlsBLL.AddTextBox(CustomFieldRow.DatabaseFieldName, , IIf(Not IsDBNull(CustomFieldRow.Item("DefaultValue")), CustomFieldRow.Item("DefaultValue"), ""), 50, , , "TimeEntry"))
                If CustomFieldRow.IsRequired Then
                    'tblcell.Controls.Add(CustomControlsBLL.AddRequiredFieldValidator(CustomFieldRow.DatabaseFieldName, CustomFieldRow.DatabaseFieldName, "TimeEntry"))
                End If
                'tblcell.Controls.Add(CustomControlsBLL.AddRangeValidator(CustomFieldRow.DatabaseFieldName, CustomFieldRow.DatabaseFieldName, IIf(Not IsDBNull(CustomFieldRow.Item("MinimumValue")), CustomFieldRow.Item("MinimumValue"), ""), IIf(Not IsDBNull(CustomFieldRow.Item("MaximumValue")), CustomFieldRow.Item("MaximumValue"), ""), "TimeEntry"))
            End If
        End If
        ThisColumn.Controls.Add(tbl)
    End Sub
End Class