<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.btnQBEmployees = New System.Windows.Forms.Button()
        Me.btnQBCustomers = New System.Windows.Forms.Button()
        Me.btnQBJobOrItem = New System.Windows.Forms.Button()
        Me.btnQBTimeTracking = New System.Windows.Forms.Button()
        Me.btnTLClients = New System.Windows.Forms.Button()
        Me.btnTLEmployees = New System.Windows.Forms.Button()
        Me.btnQBExpenseTracking = New System.Windows.Forms.Button()
        Me.btnQBVendors = New System.Windows.Forms.Button()
        Me.btnTLProjectAndTask = New System.Windows.Forms.Button()
        Me.btnQBAccounts = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnQBEmployees
        '
        Me.btnQBEmployees.Location = New System.Drawing.Point(8, 16)
        Me.btnQBEmployees.Name = "btnQBEmployees"
        Me.btnQBEmployees.Size = New System.Drawing.Size(393, 36)
        Me.btnQBEmployees.TabIndex = 0
        Me.btnQBEmployees.Text = "Transfer TimeLive Employees to QuickBooks as Employees"
        Me.btnQBEmployees.UseVisualStyleBackColor = True
        '
        'btnQBCustomers
        '
        Me.btnQBCustomers.Location = New System.Drawing.Point(8, 88)
        Me.btnQBCustomers.Name = "btnQBCustomers"
        Me.btnQBCustomers.Size = New System.Drawing.Size(393, 36)
        Me.btnQBCustomers.TabIndex = 1
        Me.btnQBCustomers.Text = "Tranfer TimeLive Clients to QuicBooks as Customers"
        Me.btnQBCustomers.UseVisualStyleBackColor = True
        '
        'btnQBJobOrItem
        '
        Me.btnQBJobOrItem.Location = New System.Drawing.Point(8, 124)
        Me.btnQBJobOrItem.Name = "btnQBJobOrItem"
        Me.btnQBJobOrItem.Size = New System.Drawing.Size(393, 36)
        Me.btnQBJobOrItem.TabIndex = 2
        Me.btnQBJobOrItem.Text = "Transfer TimeLive Projects/Tasks to QuickBooks as Jobs/Items"
        Me.btnQBJobOrItem.UseVisualStyleBackColor = True
        '
        'btnQBTimeTracking
        '
        Me.btnQBTimeTracking.Location = New System.Drawing.Point(8, 196)
        Me.btnQBTimeTracking.Name = "btnQBTimeTracking"
        Me.btnQBTimeTracking.Size = New System.Drawing.Size(393, 36)
        Me.btnQBTimeTracking.TabIndex = 3
        Me.btnQBTimeTracking.Text = "Transfer TimeLive Time Entries to QuickBooks as Time Entries"
        Me.btnQBTimeTracking.UseVisualStyleBackColor = True
        '
        'btnTLClients
        '
        Me.btnTLClients.Location = New System.Drawing.Point(8, 51)
        Me.btnTLClients.Name = "btnTLClients"
        Me.btnTLClients.Size = New System.Drawing.Size(393, 36)
        Me.btnTLClients.TabIndex = 7
        Me.btnTLClients.Text = "Transfer QuickBooks Customers to TimeLive as Clients"
        Me.btnTLClients.UseVisualStyleBackColor = True
        '
        'btnTLEmployees
        '
        Me.btnTLEmployees.Location = New System.Drawing.Point(8, 16)
        Me.btnTLEmployees.Name = "btnTLEmployees"
        Me.btnTLEmployees.Size = New System.Drawing.Size(393, 36)
        Me.btnTLEmployees.TabIndex = 6
        Me.btnTLEmployees.Text = "Transfer QuickBooks Employees/Vendors to TimeLive as Employees"
        Me.btnTLEmployees.UseVisualStyleBackColor = True
        '
        'btnQBExpenseTracking
        '
        Me.btnQBExpenseTracking.Location = New System.Drawing.Point(8, 232)
        Me.btnQBExpenseTracking.Name = "btnQBExpenseTracking"
        Me.btnQBExpenseTracking.Size = New System.Drawing.Size(393, 36)
        Me.btnQBExpenseTracking.TabIndex = 5
        Me.btnQBExpenseTracking.Text = "Transfer TimeLive Expense Entries to QuickBooks as Vendor Bills"
        Me.btnQBExpenseTracking.UseVisualStyleBackColor = True
        '
        'btnQBVendors
        '
        Me.btnQBVendors.Location = New System.Drawing.Point(8, 52)
        Me.btnQBVendors.Name = "btnQBVendors"
        Me.btnQBVendors.Size = New System.Drawing.Size(393, 36)
        Me.btnQBVendors.TabIndex = 4
        Me.btnQBVendors.Text = "Transfer TimeLive Vendors to QuickBooks as Vendors"
        Me.btnQBVendors.UseVisualStyleBackColor = True
        '
        'btnTLProjectAndTask
        '
        Me.btnTLProjectAndTask.Location = New System.Drawing.Point(8, 87)
        Me.btnTLProjectAndTask.Name = "btnTLProjectAndTask"
        Me.btnTLProjectAndTask.Size = New System.Drawing.Size(393, 36)
        Me.btnTLProjectAndTask.TabIndex = 8
        Me.btnTLProjectAndTask.Text = "Transfer Jobs/Items to TimeLive as Projects/Tasks"
        Me.btnTLProjectAndTask.UseVisualStyleBackColor = True
        '
        'btnQBAccounts
        '
        Me.btnQBAccounts.Location = New System.Drawing.Point(8, 160)
        Me.btnQBAccounts.Name = "btnQBAccounts"
        Me.btnQBAccounts.Size = New System.Drawing.Size(393, 36)
        Me.btnQBAccounts.TabIndex = 11
        Me.btnQBAccounts.Text = "Transfer TimeLive Expense Codes to QuickBooks as Accounts"
        Me.btnQBAccounts.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnQBEmployees)
        Me.GroupBox1.Controls.Add(Me.btnQBAccounts)
        Me.GroupBox1.Controls.Add(Me.btnQBVendors)
        Me.GroupBox1.Controls.Add(Me.btnQBCustomers)
        Me.GroupBox1.Controls.Add(Me.btnQBJobOrItem)
        Me.GroupBox1.Controls.Add(Me.btnQBTimeTracking)
        Me.GroupBox1.Controls.Add(Me.btnQBExpenseTracking)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 272)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transfer TimeLive to QuickBooks"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnTLEmployees)
        Me.GroupBox2.Controls.Add(Me.btnTLClients)
        Me.GroupBox2.Controls.Add(Me.btnTLProjectAndTask)
        Me.GroupBox2.Location = New System.Drawing.Point(424, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 128)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transfer QuickBooks to TimeLive"
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 287)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TimeLive QuickBooks Integration Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnQBEmployees As System.Windows.Forms.Button
    Friend WithEvents btnQBCustomers As System.Windows.Forms.Button
    Friend WithEvents btnQBJobOrItem As System.Windows.Forms.Button
    Friend WithEvents btnQBTimeTracking As System.Windows.Forms.Button
    Friend WithEvents btnTLClients As System.Windows.Forms.Button
    Friend WithEvents btnTLEmployees As System.Windows.Forms.Button
    Friend WithEvents btnQBExpenseTracking As System.Windows.Forms.Button
    Friend WithEvents btnQBVendors As System.Windows.Forms.Button
    Friend WithEvents btnTLProjectAndTask As System.Windows.Forms.Button
    Friend WithEvents btnQBAccounts As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
