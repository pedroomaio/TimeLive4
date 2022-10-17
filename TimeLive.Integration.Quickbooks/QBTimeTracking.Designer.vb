<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QBTimeTracking
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QBTimeTracking))
        Me.btnGetAndAddTimeEntries = New System.Windows.Forms.Button()
        Me.lblUptoDate = New System.Windows.Forms.Label()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.dpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.rbtJobitems = New System.Windows.Forms.RadioButton()
        Me.rbItem = New System.Windows.Forms.RadioButton()
        Me.rbJob = New System.Windows.Forms.RadioButton()
        Me.cbClass = New System.Windows.Forms.ComboBox()
        Me.cbPayrollItem = New System.Windows.Forms.ComboBox()
        Me.chkPayrollTimesheet = New System.Windows.Forms.CheckBox()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.lblPayrollItem = New System.Windows.Forms.Label()
        Me.cbEmployee = New System.Windows.Forms.ComboBox()
        Me.lblEmployee = New System.Windows.Forms.Label()
        Me.cbWageType = New System.Windows.Forms.ComboBox()
        Me.lblWageType = New System.Windows.Forms.Label()
        Me.pgbar = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'btnGetAndAddTimeEntries
        '
        Me.btnGetAndAddTimeEntries.Location = New System.Drawing.Point(8, 109)
        Me.btnGetAndAddTimeEntries.Name = "btnGetAndAddTimeEntries"
        Me.btnGetAndAddTimeEntries.Size = New System.Drawing.Size(592, 75)
        Me.btnGetAndAddTimeEntries.TabIndex = 0
        Me.btnGetAndAddTimeEntries.Text = "Transfer TimeLive Time Entries to QuickBooks as Time Entries"
        Me.btnGetAndAddTimeEntries.UseVisualStyleBackColor = True
        '
        'lblUptoDate
        '
        Me.lblUptoDate.AutoSize = True
        Me.lblUptoDate.Location = New System.Drawing.Point(33, 68)
        Me.lblUptoDate.Name = "lblUptoDate"
        Me.lblUptoDate.Size = New System.Drawing.Size(59, 13)
        Me.lblUptoDate.TabIndex = 10
        Me.lblUptoDate.Text = "Upto Date:"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Location = New System.Drawing.Point(33, 47)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(59, 13)
        Me.lblFromDate.TabIndex = 9
        Me.lblFromDate.Text = "From Date:"
        '
        'dpEndDate
        '
        Me.dpEndDate.CustomFormat = ""
        Me.dpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpEndDate.Location = New System.Drawing.Point(93, 64)
        Me.dpEndDate.Name = "dpEndDate"
        Me.dpEndDate.Size = New System.Drawing.Size(87, 20)
        Me.dpEndDate.TabIndex = 8
        '
        'dpStartDate
        '
        Me.dpStartDate.CustomFormat = ""
        Me.dpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpStartDate.Location = New System.Drawing.Point(93, 43)
        Me.dpStartDate.Name = "dpStartDate"
        Me.dpStartDate.Size = New System.Drawing.Size(87, 20)
        Me.dpStartDate.TabIndex = 7
        '
        'rbtJobitems
        '
        Me.rbtJobitems.AutoSize = True
        Me.rbtJobitems.Checked = True
        Me.rbtJobitems.Location = New System.Drawing.Point(8, 88)
        Me.rbtJobitems.Name = "rbtJobitems"
        Me.rbtJobitems.Size = New System.Drawing.Size(77, 17)
        Me.rbtJobitems.TabIndex = 13
        Me.rbtJobitems.TabStop = True
        Me.rbtJobitems.Text = "Jobs/Items"
        Me.rbtJobitems.UseVisualStyleBackColor = True
        '
        'rbItem
        '
        Me.rbItem.AutoSize = True
        Me.rbItem.Location = New System.Drawing.Point(197, 88)
        Me.rbItem.Name = "rbItem"
        Me.rbItem.Size = New System.Drawing.Size(102, 17)
        Me.rbItem.TabIndex = 12
        Me.rbItem.TabStop = True
        Me.rbItem.Text = "Items/Sub Items"
        Me.rbItem.UseVisualStyleBackColor = True
        '
        'rbJob
        '
        Me.rbJob.AutoSize = True
        Me.rbJob.Location = New System.Drawing.Point(93, 88)
        Me.rbJob.Name = "rbJob"
        Me.rbJob.Size = New System.Drawing.Size(96, 17)
        Me.rbJob.TabIndex = 11
        Me.rbJob.TabStop = True
        Me.rbJob.Text = "Jobs/Sub Jobs"
        Me.rbJob.UseVisualStyleBackColor = True
        '
        'cbClass
        '
        Me.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbClass.Enabled = False
        Me.cbClass.FormattingEnabled = True
        Me.cbClass.Items.AddRange(New Object() {"<None>", "CostCenter", "Department", "EmployeeType", "Milestone", "WorkType"})
        Me.cbClass.Location = New System.Drawing.Point(381, 20)
        Me.cbClass.Name = "cbClass"
        Me.cbClass.Size = New System.Drawing.Size(219, 21)
        Me.cbClass.TabIndex = 14
        '
        'cbPayrollItem
        '
        Me.cbPayrollItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPayrollItem.Enabled = False
        Me.cbPayrollItem.FormattingEnabled = True
        Me.cbPayrollItem.Items.AddRange(New Object() {"<None>", "CostCenter", "Department", "EmployeeType", "Milestone", "WorkType"})
        Me.cbPayrollItem.Location = New System.Drawing.Point(381, 47)
        Me.cbPayrollItem.Name = "cbPayrollItem"
        Me.cbPayrollItem.Size = New System.Drawing.Size(219, 21)
        Me.cbPayrollItem.TabIndex = 15
        '
        'chkPayrollTimesheet
        '
        Me.chkPayrollTimesheet.AutoSize = True
        Me.chkPayrollTimesheet.Location = New System.Drawing.Point(381, 3)
        Me.chkPayrollTimesheet.Name = "chkPayrollTimesheet"
        Me.chkPayrollTimesheet.Size = New System.Drawing.Size(219, 17)
        Me.chkPayrollTimesheet.TabIndex = 16
        Me.chkPayrollTimesheet.Text = "Transfer time entries to payroll timesheets"
        Me.chkPayrollTimesheet.UseVisualStyleBackColor = True
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Location = New System.Drawing.Point(345, 24)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(35, 13)
        Me.lblClass.TabIndex = 17
        Me.lblClass.Text = "Class:"
        '
        'lblPayrollItem
        '
        Me.lblPayrollItem.AutoSize = True
        Me.lblPayrollItem.Location = New System.Drawing.Point(316, 51)
        Me.lblPayrollItem.Name = "lblPayrollItem"
        Me.lblPayrollItem.Size = New System.Drawing.Size(64, 13)
        Me.lblPayrollItem.TabIndex = 18
        Me.lblPayrollItem.Text = "Payroll Item:"
        '
        'cbEmployee
        '
        Me.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEmployee.FormattingEnabled = True
        Me.cbEmployee.Location = New System.Drawing.Point(93, 20)
        Me.cbEmployee.Name = "cbEmployee"
        Me.cbEmployee.Size = New System.Drawing.Size(219, 21)
        Me.cbEmployee.TabIndex = 19
        '
        'lblEmployee
        '
        Me.lblEmployee.AutoSize = True
        Me.lblEmployee.Location = New System.Drawing.Point(5, 24)
        Me.lblEmployee.Name = "lblEmployee"
        Me.lblEmployee.Size = New System.Drawing.Size(87, 13)
        Me.lblEmployee.TabIndex = 20
        Me.lblEmployee.Text = "Employee Name:"
        '
        'cbWageType
        '
        Me.cbWageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWageType.Enabled = False
        Me.cbWageType.FormattingEnabled = True
        Me.cbWageType.Items.AddRange(New Object() {"Bonus", "Comission", "Hourly-Overtime", "Hourly-Regular", "Hourly-Sick", "Hourly-Vacation", "Salary-Regular", "Salary-Sick", "Salary-Vacation"})
        Me.cbWageType.Location = New System.Drawing.Point(381, 75)
        Me.cbWageType.Name = "cbWageType"
        Me.cbWageType.Size = New System.Drawing.Size(219, 21)
        Me.cbWageType.TabIndex = 21
        '
        'lblWageType
        '
        Me.lblWageType.AutoSize = True
        Me.lblWageType.Location = New System.Drawing.Point(311, 79)
        Me.lblWageType.Name = "lblWageType"
        Me.lblWageType.Size = New System.Drawing.Size(66, 13)
        Me.lblWageType.TabIndex = 22
        Me.lblWageType.Text = "Wage Type:"
        '
        'pgbar
        '
        Me.pgbar.Location = New System.Drawing.Point(8, 189)
        Me.pgbar.MarqueeAnimationSpeed = 1
        Me.pgbar.Name = "pgbar"
        Me.pgbar.Size = New System.Drawing.Size(592, 10)
        Me.pgbar.TabIndex = 23
        '
        'QBTimeTracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 202)
        Me.Controls.Add(Me.pgbar)
        Me.Controls.Add(Me.lblWageType)
        Me.Controls.Add(Me.cbWageType)
        Me.Controls.Add(Me.lblEmployee)
        Me.Controls.Add(Me.cbEmployee)
        Me.Controls.Add(Me.lblPayrollItem)
        Me.Controls.Add(Me.lblClass)
        Me.Controls.Add(Me.chkPayrollTimesheet)
        Me.Controls.Add(Me.cbPayrollItem)
        Me.Controls.Add(Me.cbClass)
        Me.Controls.Add(Me.rbtJobitems)
        Me.Controls.Add(Me.rbItem)
        Me.Controls.Add(Me.rbJob)
        Me.Controls.Add(Me.lblUptoDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.dpEndDate)
        Me.Controls.Add(Me.dpStartDate)
        Me.Controls.Add(Me.btnGetAndAddTimeEntries)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "QBTimeTracking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TimeLive QuickBooks Integration Manager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGetAndAddTimeEntries As System.Windows.Forms.Button
    Friend WithEvents lblUptoDate As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents dpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbtJobitems As System.Windows.Forms.RadioButton
    Friend WithEvents rbItem As System.Windows.Forms.RadioButton
    Friend WithEvents rbJob As System.Windows.Forms.RadioButton
    Friend WithEvents cbClass As System.Windows.Forms.ComboBox
    Friend WithEvents cbPayrollItem As System.Windows.Forms.ComboBox
    Friend WithEvents chkPayrollTimesheet As System.Windows.Forms.CheckBox
    Friend WithEvents lblClass As System.Windows.Forms.Label
    Friend WithEvents lblPayrollItem As System.Windows.Forms.Label
    Friend WithEvents cbEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmployee As System.Windows.Forms.Label
    Friend WithEvents cbWageType As System.Windows.Forms.ComboBox
    Friend WithEvents lblWageType As System.Windows.Forms.Label
    Friend WithEvents pgbar As System.Windows.Forms.ProgressBar
End Class
