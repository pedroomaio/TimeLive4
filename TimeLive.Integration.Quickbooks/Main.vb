Imports System.Windows.Forms
Imports Interop.QBFC10
Public Class Main
    Private Sub LoginToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        Login.MdiParent = Me
        Login.Show()
    End Sub

    Private Sub Parent_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            ValidateQBSession()
            Login.MdiParent = Me
            Login.Show()
        Catch ex As Exception            
            MsgBox(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Public Sub ValidateQBSession()
        Dim sessManager As QBSessionManager
        Try
            sessManager = New QBSessionManagerClass()
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
        Catch ex As Exception
            Throw New Exception("QuickBooks is not open. Please open it and then try again.")
        End Try
    End Sub
End Class
