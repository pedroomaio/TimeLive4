Imports Microsoft.VisualBasic
Public Class TimesheetItemTemplate
    Implements ITemplate
    Private m_STColumnName As String
    Private m_ETColumnName As String
    Private m_TTColumnName As String
    Private m_MESTColumnName As String
    Private m_MEETColumnName As String
    Private m_METTColumnName As String
    Private m_MEVSTColumnName As String
    Private m_MEVETColumnName As String
    Private m_MEVTTColumnName As String
    Private m_imgStatusColumnName As String
    Private m_IsEnable As Boolean
    Private m_PColumnName As String
    Private m_MEPColumnName As String
    Private m_MEVPColumnName As String
    Private m_NVColumnName As String
    Private m_ATColumnName As String
    Private m_IColumnName As String

    Public Property STColumnName() As String
        Get
            Return m_STColumnName
        End Get
        Set(ByVal value As String)
            m_STColumnName = value
        End Set
    End Property
    Public Property ETColumnName() As String
        Get
            Return m_ETColumnName
        End Get
        Set(ByVal value As String)
            m_ETColumnName = value
        End Set
    End Property
    Public Property TTColumnName() As String
        Get
            Return m_TTColumnName
        End Get
        Set(ByVal value As String)
            m_TTColumnName = value
        End Set
    End Property
    Public Property MESTColumnName() As String
        Get
            Return m_MESTColumnName
        End Get
        Set(ByVal value As String)
            m_MESTColumnName = value
        End Set
    End Property
    Public Property MEETColumnName() As String
        Get
            Return m_MEETColumnName
        End Get
        Set(ByVal value As String)
            m_MEETColumnName = value
        End Set
    End Property
    Public Property METTColumnName() As String
        Get
            Return m_METTColumnName
        End Get
        Set(ByVal value As String)
            m_METTColumnName = value
        End Set
    End Property
    Public Property MEVSTColumnName() As String
        Get
            Return m_MEVSTColumnName
        End Get
        Set(ByVal value As String)
            m_MEVSTColumnName = value
        End Set
    End Property
    Public Property MEVETColumnName() As String
        Get
            Return m_MEVETColumnName
        End Get
        Set(ByVal value As String)
            m_MEVETColumnName = value
        End Set
    End Property
    Public Property MEVTTColumnName() As String
        Get
            Return m_MEVTTColumnName
        End Get
        Set(ByVal value As String)
            m_MEVTTColumnName = value
        End Set
    End Property
    Public Property imgStatusColumnName() As String
        Get
            Return m_imgStatusColumnName
        End Get
        Set(ByVal value As String)
            m_imgStatusColumnName = value
        End Set
    End Property
    Public Property PColumnName() As String
        Get
            Return m_PColumnName
        End Get
        Set(ByVal value As String)
            m_PColumnName = value
        End Set
    End Property
    Public Property MEPColumnName() As String
        Get
            Return m_MEPColumnName
        End Get
        Set(ByVal value As String)
            m_MEPColumnName = value
        End Set
    End Property
    Public Property MEVPColumnName() As String
        Get
            Return m_MEVPColumnName
        End Get
        Set(ByVal value As String)
            m_MEVPColumnName = value
        End Set
    End Property
    Public Property NVColumnName() As String
        Get
            Return m_NVColumnName
        End Get
        Set(ByVal value As String)
            m_NVColumnName = value
        End Set
    End Property
    Public Property ATColumnName() As String
        Get
            Return m_ATColumnName
        End Get
        Set(value As String)
            m_ATColumnName = value
        End Set
    End Property
    Public Property IColumnName() As String
        Get
            Return m_IColumnName
        End Get
        Set(ByVal value As String)
            m_IColumnName = value
        End Set
    End Property
    Public Sub New(ByVal STColumnName As String, ByVal ETColumnName As String, ByVal TTColumnName As String, ByVal MESTColumnName As String, ByVal MEETColumnName As String, ByVal METTColumnName As String, ByVal MEVSTColumnName As String, ByVal MEVETColumnName As String, ByVal MEVTTColumnName As String, ByVal imgStatusColumnName As String, ByVal IsEnable As Boolean, ByVal PColumnName As String, ByVal MEPColumnName As String, ByVal MEVPColumnName As String, ByVal NVColumnName As String, ByVal ATColumnName As String, ByVal InfoColumnName As String)
        Me.STColumnName = STColumnName
        Me.ETColumnName = ETColumnName
        Me.TTColumnName = TTColumnName
        Me.MESTColumnName = MESTColumnName
        Me.MEETColumnName = MEETColumnName
        Me.METTColumnName = METTColumnName
        Me.MEVSTColumnName = MEVSTColumnName
        Me.MEVETColumnName = MEVETColumnName
        Me.MEVTTColumnName = MEVTTColumnName
        Me.imgStatusColumnName = imgStatusColumnName
        m_IsEnable = IsEnable
        Me.PColumnName = PColumnName
        Me.MEPColumnName = MEPColumnName
        Me.MEVPColumnName = MEVPColumnName
        Me.NVColumnName = NVColumnName
        Me.ATColumnName = ATColumnName
        Me.IColumnName = InfoColumnName
    End Sub

    Private Sub InstantiateIn(ByVal ThisColumn As System.Web.UI.Control) Implements ITemplate.InstantiateIn
        If m_IsEnable = True Then
            Dim browser As System.Web.HttpBrowserCapabilities = System.Web.HttpContext.Current.Request.Browser
            Dim AttachmentLink As New HyperLink()
            Dim Info As New Label()
            Dim STTextBox As New TextBox()
            Dim STMaskedEditExtender As New AjaxControlToolkit.MaskedEditExtender
            Dim STMaskedEditValidator As New AjaxControlToolkit.MaskedEditValidator
            Dim ETTextBox As New TextBox()
            Dim ETMaskedEditExtender As New AjaxControlToolkit.MaskedEditExtender
            Dim ETMaskedEditValidator As New AjaxControlToolkit.MaskedEditValidator
            Dim TTTextBox As New TextBox()
            Dim TTMaskedEditExtender As New AjaxControlToolkit.MaskedEditExtender
            Dim TTMaskedEditValidator As New AjaxControlToolkit.MaskedEditValidator
            Dim PTextBox As New TextBox()
            Dim PMaskedEditExtender As New AjaxControlToolkit.MaskedEditExtender
            Dim PMaskedEditValidator As New AjaxControlToolkit.MaskedEditValidator
            Dim NumericValidator As New RangeValidator
            Dim StatusImage As New System.Web.UI.WebControls.Image
            Dim tbl As New System.Web.UI.WebControls.Table
            Dim tblrow As New System.Web.UI.WebControls.TableRow
            Dim tblcell As New System.Web.UI.WebControls.TableCell
            tbl.BorderWidth = "0"
            tblrow.BorderWidth = "0"
            tblcell.BorderWidth = "0"
            With tbl
                .ID = "T" + TTColumnName
                .CssClass = "intab"
                .ClientIDMode = ClientIDMode.Static
            End With
            With tblrow
                .ID = "R" + TTColumnName
                .ClientIDMode = ClientIDMode.Static
            End With
            With tblcell
                .ID = "C" + TTColumnName
                .Width = 50
                .ClientIDMode = ClientIDMode.Static
            End With

            tbl.Rows.Add(tblrow)
            tblrow.Cells.Add(tblcell)


            With AttachmentLink
                .ID = ATColumnName
                .CssClass = "AttachmentLink"
                .Visible = False
                '.ToolTip = "Add Attachment"
                .Text = "Attachment"
                .Attributes.Add("onclick", "javascript:window.open (this.href, 'popupwindow', 'width=700,height=505,left=300,top=150,scrollbars=yes'); return false;")

            End With
            tblcell.Controls.Add(AttachmentLink)

            With Info
                .ID = IColumnName
                .CssClass = "circle"
                .Text = "i"
                .Visible = False
                .Attributes.Add("style", "margin-left: 50px !important; font-family: Georgia !important; font-size: 9px !important; font-weight:bold !important;cursor:pointer")
            End With
            tblcell.Controls.Add(Info)

            If DBUtilities.GetShowClockStartEnd = True And DBUtilities.IsTimeEntryHoursFormat = "Time" Then
                With STTextBox
                    .ID = STColumnName
                    .Style.Add("text-align", "center")
                    .Width = 50
                End With
                tblcell.Controls.Add(STTextBox)

                With STMaskedEditExtender
                    .Enabled = m_IsEnable
                    .ID = MESTColumnName
                    .AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                    .AutoCompleteValue = "00:00"
                    .Mask = "99:99"
                    .MaskType = AjaxControlToolkit.MaskedEditType.Time
                    .TargetControlID = STTextBox.ID
                End With
                tblcell.Controls.Add(STMaskedEditExtender)

                With STMaskedEditValidator
                    .Enabled = m_IsEnable
                    .ID = MEVSTColumnName
                    .InvalidValueMessage = "Invalid Time"
                    .ControlToValidate = STTextBox.ID
                    .ControlExtender = STMaskedEditExtender.ID
                End With
                tblcell.Controls.Add(STMaskedEditValidator)

                With ETTextBox
                    .ID = ETColumnName
                    .Style.Add("text-align", "center")
                    .Width = 50
                End With
                tblcell.Controls.Add(ETTextBox)

                With ETMaskedEditExtender
                    .Enabled = m_IsEnable
                    .ID = MEETColumnName
                    .AcceptAMPM = LocaleUtilitiesBLL.IsAcceptAMPMForTimeentry
                    .AutoCompleteValue = "00:00"
                    .Mask = "99:99"
                    .MaskType = AjaxControlToolkit.MaskedEditType.Time
                    .TargetControlID = ETTextBox.ID
                End With
                tblcell.Controls.Add(ETMaskedEditExtender)

                With ETMaskedEditValidator
                    .Enabled = m_IsEnable
                    .ID = MEVETColumnName
                    .InvalidValueMessage = "Invalid Time"
                    .ControlToValidate = ETTextBox.ID
                    .ControlExtender = ETMaskedEditExtender.ID
                End With
                tblcell.Controls.Add(ETMaskedEditValidator)
            End If

            With TTTextBox
                .ID = TTColumnName
                .Style.Add("text-align", "center")
                .Width = 50
            End With
            tblcell.Controls.Add(TTTextBox)

            With TTMaskedEditExtender
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    .Enabled = False
                Else
                    .Enabled = m_IsEnable
                End If
                .ID = METTColumnName
                .AutoCompleteValue = "00:00"
                .Mask = "99:99"
                .MaskType = AjaxControlToolkit.MaskedEditType.Time
                .TargetControlID = TTTextBox.ID
            End With
            tblcell.Controls.Add(TTMaskedEditExtender)

            With TTMaskedEditValidator
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    .Enabled = False
                Else
                    .Enabled = m_IsEnable
                End If
                .ID = MEVTTColumnName
                .InvalidValueMessage = "Invalid Time"
                .ControlToValidate = TTTextBox.ID
                .ControlExtender = TTMaskedEditExtender.ID
            End With
            tblcell.Controls.Add(TTMaskedEditValidator)

            If LocaleUtilitiesBLL.ShowPercentageInTimesheet() Then
                With PTextBox
                    .ID = PColumnName
                    .Width = 50
                End With
                tblcell.Controls.Add(PTextBox)

                With PMaskedEditExtender
                    .Enabled = m_IsEnable
                    .ID = MEPColumnName
                    .AutoComplete = False
                    .Mask = "999"
                    '.ClearMaskOnLostFocus = False
                    .MaskType = AjaxControlToolkit.MaskedEditType.Number
                    .TargetControlID = PTextBox.ID
                End With
                tblcell.Controls.Add(PMaskedEditExtender)

                With PMaskedEditValidator
                    .Enabled = m_IsEnable
                    .ID = MEVPColumnName
                    .InvalidValueMessage = "Invalid Time"
                    .ControlToValidate = PTextBox.ID
                    .ControlExtender = PMaskedEditExtender.ID
                    .MaximumValue = 100
                    .MaximumValueMessage = "Invalid Percentage"


                End With
                tblcell.Controls.Add(PMaskedEditValidator)
            End If
            With StatusImage
                .ID = imgStatusColumnName
                .Width = 10
                .ImageUrl = "~/Images/clearpixel.gif"
                .EnableTheming = "True"
                .ClientIDMode = ClientIDMode.Static
            End With
            tblcell.Controls.Add(StatusImage)

            With NumericValidator
                If DBUtilities.IsTimeEntryHoursFormat = "Decimal" Then
                    .Enabled = m_IsEnable
                Else
                    .Enabled = False
                End If
                .ID = NVColumnName
                .ControlToValidate = TTTextBox.ID
                .MaximumValue = 23.99
                .MinimumValue = 0
                .Type = ValidationDataType.Double
                .ErrorMessage = "Invalid Time"
                .Display = ValidatorDisplay.Dynamic
            End With
            tblcell.Controls.Add(NumericValidator)
            ThisColumn.Controls.Add(tbl)
        End If

    End Sub
End Class