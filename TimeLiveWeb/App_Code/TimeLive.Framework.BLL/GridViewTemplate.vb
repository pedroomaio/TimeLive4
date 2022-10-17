Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Public Class GridViewTemplate
    Implements ITemplate
    'A variable to hold the type of ListItemType.
    Private _templateType As ListItemType
    Public Event EventHandler As EventHandler
    'A variable to hold the column name.
    Private _columnName As String
    Private _ColumnDisplayName As String


    'Constructor where we define the template type and column name.
    Public Sub New(type As ListItemType, colname As String, ColumnDisplayName As String)
        'Stores the template type.
        _templateType = type

        'Stores the column name.
        _columnName = colname
        _ColumnDisplayName = ColumnDisplayName

    End Sub
    Private Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        Select Case _templateType
            Case ListItemType.Header
                If _columnName = "CheckBox" Then

                    Dim HeaderCheckBox As New CheckBox()
                    HeaderCheckBox.ID = "chkCheckAll"
                    HeaderCheckBox.AutoPostBack = "True"
                    HeaderCheckBox.Attributes.Add("onclick", "ChangeAllCheckBoxStates(this.checked);")
                    ThisColumn.Controls.Add(HeaderCheckBox)
                   
                Else
                    Dim lnk As New LinkButton()
                    lnk.CommandName = "Sort"
                    lnk.CausesValidation = "False"
                    lnk.CommandArgument = _columnName
                    lnk.Text = _ColumnDisplayName
                    ThisColumn.Controls.Add(lnk)
                End If
                '<HeaderTemplate>
                '      <asp:LinkButton ID="LinkButton4" runat="server" __designer:wfdid="w3" 
                '          CausesValidation="False" CommandArgument="TaskName" CommandName="Sort" 
                '          Text='<%# ResourceHelper.GetFromResource("Milestone") %>'></asp:LinkButton></HeaderTemplate>
                Exit Select

            Case ListItemType.Item
                'Creates a new text box control and add it to the container.
                Dim hl As New HyperLink()
                Dim lbl1 As New Label()
                If _columnName = "TaskName" Then
                    With hl
                        .ID = "HLTaskName"
                        AddHandler hl.DataBinding, AddressOf hl_DataBinding
                        'Attaches the data binding event.
                        'Creates a column with size 4.
                        ThisColumn.Controls.Add(hl)
                    End With
                    With lbl1
                        AddHandler lbl1.DataBinding, AddressOf lbl1_DataBinding
                        ThisColumn.Controls.Add(lbl1)
                    End With
                    'Adds the newly created textbox to the container.
                ElseIf _columnName = "MilestoneDescription" Then
                    Dim image As New Image
                    With image
                        .ID = "Image1"
                        .ImageUrl = "~/Images/Completed.gif"
                        AddHandler image.DataBinding, AddressOf image_DataBinding
                        ThisColumn.Controls.Add(image)
                    End With
                    With hl
                        .ID = "HLMilestone"
                        AddHandler hl.DataBinding, AddressOf hl_DataBinding
                        ThisColumn.Controls.Add(hl)
                    End With
                    With lbl1
                        AddHandler lbl1.DataBinding, AddressOf lbl1_DataBinding
                        ThisColumn.Controls.Add(lbl1)
                    End With
                Else
                    If _columnName = "CheckBox" Then
                        Dim ItemCheckBox As New CheckBox()
                        ItemCheckBox.ID = "chkSelect"
                        ThisColumn.Controls.Add(ItemCheckBox)
                    Else
                        lbl1.ID = "lbl" & _columnName
                        'Allocates the new text box object.
                        AddHandler lbl1.DataBinding, AddressOf lbl1_DataBinding
                        'Attaches the data binding event.
                        'Creates a column with size 4.
                        ThisColumn.Controls.Add(lbl1)
                        'Adds the newly created textbox to the container.
                    End If
                End If
                '  <ItemTemplate>
                '        &nbsp;
                '<asp:Image ID="Image1" runat="server" __designer:wfdid="w11" 
                'ImageUrl = "~/Images/Completed.gif"
                '            Visible='<%# IIF(IsDBNull(Eval("Completed")),"false",Eval("Completed")) %>' />
                '
                '<asp:HyperLink ID="HLMilestone" runat="server" __designer:wfdid="w76" 
                'NavigateUrl='<%# Eval("AccountProjectMilestoneId", IIF(AccountPagePermissionBLL.IsPageHasPermissionOf(30, 3), "~/ProjectAdmin/AccountProjectMilestones.aspx?AccountProjectMilestoneId={0}","~/Employee/MyTasks.aspx")) %>' 
                'Text='<%# Eval("MilestoneDescription") %>' 
                'Visible='<%# IIF(AccountPagePermissionBLL.IsPageHasPermissionOf(30, 3),"True","False") %>'></asp:HyperLink>
                '
                '<asp:Label ID="Label20" runat="server" __designer:wfdid="w2" 
                '            Text='<%# Eval("MilestoneDescription") %>' 
                '            Visible='<%# IIF(AccountPagePermissionBLL.IsPageHasPermissionOf(30, 3),"False","True") %>'></asp:Label></ItemTemplate>
                Exit Select
            Case ListItemType.EditItem
                Dim txt As New TextBox()
                AddHandler txt.DataBinding, AddressOf txt_DataBinding
                ThisColumn.Controls.Add(txt)
                '<EditItemTemplate>
                '        <asp:TextBox ID="TextBox1" runat="server" __designer:wfdid="w12" 
                '            Text='<%# Bind("Completed") %>'></asp:TextBox></EditItemTemplate>
                Exit Select

            Case ListItemType.Footer
                'Dim chkColumn As New CheckBox()
                'chkColumn.ID = Convert.ToString("Chk") & _columnName
                'ThisColumn.Controls.Add(chkColumn)
                Exit Select
        End Select
    End Sub
    Private Sub lbl1_DataBinding(sender As Object, e As EventArgs)
        Dim lbldata As Label = DirectCast(sender, Label)
        Dim container As GridViewRow = DirectCast(lbldata.NamingContainer, GridViewRow)
        Dim datavalue As Object = (DataBinder.Eval(container.DataItem, _columnName))
        'If Not IsDBNull(DataBinder.Eval(container.DataItem, _columnName)) Then
        '    lbldata.Text = IIf(DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15, Left(DataBinder.Eval(container.DataItem, _columnName), 13) & "..", DataBinder.Eval(container.DataItem, _columnName))
        '    If DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15 Then
        '        lbldata.ToolTip = DataBinder.Eval(container.DataItem, _columnName).ToString()
        '    End If
        'End If
        If Not IsDBNull(DataBinder.Eval(container.DataItem, _columnName)) Then
            If _columnName = "StartDate" Or _columnName = "DeadlineDate" Then
                Dim dt As Date = Date.Parse(DataBinder.Eval(container.DataItem, _columnName))
                Dim dateString = dt.ToShortDateString()
                lbldata.Text = dateString
            ElseIf _columnName = "AssignedTo" Then
                lbldata.Text = IIf(DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15, Left(DataBinder.Eval(container.DataItem, _columnName), 13) & "..", DataBinder.Eval(container.DataItem, _columnName))
                If DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15 Then
                    lbldata.ToolTip = DataBinder.Eval(container.DataItem, _columnName).ToString()
                End If
            Else
                lbldata.Text = DataBinder.Eval(container.DataItem, _columnName).ToString()
            End If
        End If
        If _columnName = "TaskName" Then
            lbldata.Visible = IIf(AccountPagePermissionBLL.IsPageHasPermissionOf(28, 3), "False", "True")
        End If
        If _columnName = "MilestoneDescription" Then
            lbldata.Visible = IIf(AccountPagePermissionBLL.IsPageHasPermissionOf(30, 3), "False", "True")
        End If
    End Sub
    Private Sub hl_DataBinding(sender As Object, e As EventArgs)
        Dim hldata As HyperLink = DirectCast(sender, HyperLink)
        Dim container As GridViewRow = DirectCast(hldata.NamingContainer, GridViewRow)
        'If Not IsDBNull(DataBinder.Eval(container.DataItem, _columnName)) Then
        '    hldata.Text = IIf(DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15, Left(DataBinder.Eval(container.DataItem, _columnName), 13) & "..", DataBinder.Eval(container.DataItem, _columnName))
        '    If DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15 Then
        '        hldata.ToolTip = DataBinder.Eval(container.DataItem, _columnName).ToString()
        '    End If
        'End If
        If Not IsDBNull(DataBinder.Eval(container.DataItem, _columnName)) Then
            If _columnName = "DeadlineDate" Then
                hldata.Text = Date.Parse(DataBinder.Eval(container.DataItem, _columnName).ToString())
            ElseIf _columnName = "DeadlineDate" Then
                hldata.Text = Date.Parse(DataBinder.Eval(container.DataItem, _columnName).ToString())
            Else
                hldata.Text = DataBinder.Eval(container.DataItem, _columnName).ToString()
            End If
        End If
        If _columnName = "TaskName" Then
            hldata.NavigateUrl = (IIf(AccountPagePermissionBLL.IsPageHasPermissionOf(28, 3), "~/Employee/AccountProjectTaskComments.aspx?AccountProjectTaskId=" & container.DataItem("AccountProjectTaskId") & "", "~/Employee/MyTasks.aspx"))
            hldata.Visible = IIf(AccountPagePermissionBLL.IsPageHasPermissionOf(28, 3), "True", "False")
        End If
        If _columnName = "MilestoneDescription" Then
            hldata.NavigateUrl = (IIf(AccountPagePermissionBLL.IsPageHasPermissionOf(30, 3), "~/ProjectAdmin/AccountProjectMilestones.aspx?AccountProjectMilestoneId=" & container.DataItem("AccountProjectMilestoneId") & "", "~/Employee/MyTasks.aspx"))
            hldata.Visible = IIf(AccountPagePermissionBLL.IsPageHasPermissionOf(30, 3), "True", "False")
        End If
    End Sub
    Private Sub txt_DataBinding(sender As Object, e As EventArgs)
        Dim txtdata As TextBox = DirectCast(sender, TextBox)
        Dim container As GridViewRow = DirectCast(txtdata.NamingContainer, GridViewRow)
        'If Not IsDBNull(DataBinder.Eval(container.DataItem, _columnName)) Then
        '    txtdata.Text = IIf(DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15, Left(DataBinder.Eval(container.DataItem, _columnName), 13) & "..", DataBinder.Eval(container.DataItem, _columnName))
        '    If DataBinder.Eval(container.DataItem, _columnName).ToString.Length > 15 Then
        '        txtdata.ToolTip = DataBinder.Eval(container.DataItem, _columnName).ToString()
        '    End If
        'End If
        If Not IsDBNull(DataBinder.Eval(container.DataItem, _columnName)) Then
            txtdata.Text = DataBinder.Eval(container.DataItem, _columnName).ToString()
        End If
    End Sub
    'Public Sub BindCheckBox(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim HeaderCheckBox As CheckBox = CType(sender, CheckBox)
    '    Dim container As GridViewRow = CType(HeaderCheckBox.NamingContainer, GridViewRow)
    '    If Not IsDBNull(DataBinder.Eval(container.DataItem("AccountProjectTaskId"), "CheckBox")) Then
    '        HeaderCheckBox.Checked = False
    '    Else
    '        HeaderCheckBox.Checked = CBool(container.DataItem("AccountProjectTaskId"))
    '    End If
    'End Sub
    Private Sub image_DataBinding(sender As Object, e As EventArgs)
        Dim Image As Image = DirectCast(sender, Image)
        Dim container As GridViewRow = DirectCast(Image.NamingContainer, GridViewRow)
        Dim datavalue As Object = (DataBinder.Eval(container.DataItem, "Completed"))
        Image.Visible = IIf(IsDBNull(DataBinder.Eval(container.DataItem, "Completed")), "false", DataBinder.Eval(container.DataItem, "Completed"))
        'Visible='<%# IIF(IsDBNull(Eval("Completed")),"false",Eval("Completed")) %>' />
    End Sub
   
End Class