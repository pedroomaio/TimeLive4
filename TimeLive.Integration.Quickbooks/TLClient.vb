Imports Interop.QBFC10
Public Class TLClient
    Private p_token As String
    Private p_AccountId As String
    Public Overloads Sub Show(ByVal token As String, ByVal AccountId As String)
        If token Is Nothing Then
            MsgBox("Please Login")
        Else
            p_AccountId = AccountId
            p_token = token
            MyBase.Show()
        End If
    End Sub
    ' Queries QuickBooks for all the customers and displays
    Public Sub GetAllCustomers()
        Dim EmailAddress As String
        Dim Telephone1 As String
        Dim Telephone2 As String
        Dim Fax As String
        Dim objClientServices As New Services.TimeLive.Clients.Clients
        Dim authentication As New Services.TimeLive.Clients.SecuredWebServiceHeader
        authentication.AuthenticatedToken = p_token
        objClientServices.SecuredWebServiceHeaderValue = authentication
        'step1: create QBFC session manager and prepare the request
        Dim sessManager As QBSessionManager
        Dim msgSetRs As IMsgSetResponse
        Dim customerfullname As String
        Try
            sessManager = New QBSessionManagerClass()
            Dim msgSetRq As IMsgSetRequest = sessManager.CreateMsgSetRequest("US", 2, 0)
            msgSetRq.Attributes.OnError = ENRqOnError.roeContinue
            Dim synccust As ICustomerQuery = msgSetRq.AppendCustomerQueryRq
            'step2: begin QB session and send the request
            sessManager.OpenConnection("App", "TimeLive Quickbooks")
            sessManager.BeginSession("", ENOpenMode.omDontCare)
            msgSetRs = sessManager.DoRequests(msgSetRq)
            Dim respList As IResponseList
            respList = msgSetRs.ResponseList
            If (respList Is Nothing) Then
                Exit Sub
            End If
            ' Should only expect 1 response
            Dim resp As IResponse
            resp = respList.GetAt(0)
            If (resp.StatusCode = 0) Then
                Dim custRetList As ICustomerRetList
                custRetList = resp.Detail
                ' Should only be 1 CustomerRet object returned
                Dim custRet As ICustomerRet
                Dim pblenth As Integer = custRetList.Count - 1
                If pblenth >= 0 Then
                    pgbar.Maximum = pblenth
                End If
                For i As Integer = 0 To custRetList.Count - 1
                    pgbar.Increment(i)
                    custRet = custRetList.GetAt(i)
                    With custRet
                        If .ParentRef Is Nothing Then
                            If .Email Is Nothing Then
                                EmailAddress = ""
                            Else
                                EmailAddress = .Email.GetValue
                            End If
                            If .Phone Is Nothing Then
                                Telephone1 = ""
                            Else
                                Telephone1 = .Phone.GetValue
                            End If
                            If .AltPhone Is Nothing Then
                                Telephone2 = ""
                            Else
                                Telephone2 = .AltPhone.GetValue
                            End If
                            If .Fax Is Nothing Then
                                Fax = ""
                            Else
                                Fax = .Fax.GetValue
                            End If

                            objClientServices.InsertClient(.Name.GetValue, SetLength(.Name.GetValue), _
                            EmailAddress, "", "", 233, "", "", "", Telephone1, Telephone2, Fax, 0, "", "", False, _
                            False, Now.Date, 0, Now.Date, 0)
                        End If
                    End With
                Next
            End If
            If msgSetRs.ResponseList.GetAt(0).StatusSeverity = "Error" Then
                Throw New Exception(msgSetRs.ResponseList.GetAt(0).StatusMessage)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not sessManager Is Nothing Then
                sessManager.EndSession()
                sessManager.CloseConnection()
            End If
        End Try
    End Sub
    Public Function SetLength(ByVal str As String) As String
        If str.Length > 50 Then
            str = str.Substring(0, 50)
        End If
        Return str
    End Function
    Private Sub btnSyncAndAddClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddClientInTimeLive.Click
        pgbar.Value = 0
        Try
            GetAllCustomers()
            MessageBox.Show("Record(s) transferred successfully")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddClientInTimeLive_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        MainMenu.Enabled = True
    End Sub
End Class