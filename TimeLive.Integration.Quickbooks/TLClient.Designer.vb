<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TLClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TLClient))
        Me.btnAddClientInTimeLive = New System.Windows.Forms.Button()
        Me.pgbar = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'btnAddClientInTimeLive
        '
        Me.btnAddClientInTimeLive.Location = New System.Drawing.Point(2, 2)
        Me.btnAddClientInTimeLive.Name = "btnAddClientInTimeLive"
        Me.btnAddClientInTimeLive.Size = New System.Drawing.Size(350, 75)
        Me.btnAddClientInTimeLive.TabIndex = 0
        Me.btnAddClientInTimeLive.Text = "Transfer QuickBooks Customers to TimeLive as Clients"
        Me.btnAddClientInTimeLive.UseVisualStyleBackColor = True
        '
        'pgbar
        '
        Me.pgbar.Location = New System.Drawing.Point(2, 82)
        Me.pgbar.MarqueeAnimationSpeed = 1
        Me.pgbar.Name = "pgbar"
        Me.pgbar.Size = New System.Drawing.Size(350, 10)
        Me.pgbar.TabIndex = 26
        '
        'TLClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 94)
        Me.Controls.Add(Me.pgbar)
        Me.Controls.Add(Me.btnAddClientInTimeLive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TLClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TimeLive QuickBooks Integration Manager"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddClientInTimeLive As System.Windows.Forms.Button
    Friend WithEvents pgbar As System.Windows.Forms.ProgressBar
End Class
