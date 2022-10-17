Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

<System.ComponentModel.DataObject()> _
Public Class AccountEmployeeProjectPreferencesBLL

    Private _AccountEmployeeProjectPreferencesTableAdapter As AccountEmployeeProjectPreferencesTableAdapter

    Protected ReadOnly Property Adapter() As AccountEmployeeProjectPreferencesTableAdapter
        Get
            If _AccountEmployeeProjectPreferencesTableAdapter Is Nothing Then
                _AccountEmployeeProjectPreferencesTableAdapter = New AccountEmployeeProjectPreferencesTableAdapter
            End If

            Return _AccountEmployeeProjectPreferencesTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDataByAccountEmployeeIdAndAccountProjectId(ByVal AccountEmployeeid As Integer, ByVal Accountprojectid As Integer) As TimeLiveDataSet.AccountEmployeeProjectPreferencesDataTable
        Return Adapter.GetDataByAccountEmployeeIdAndAccountProjectId(AccountEmployeeid, Accountprojectid)
    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function AddAccountEmployeeProjectPreference( _
                            ByVal AccountEmployeeId As Integer, ByVal AccountProjectID As Integer, _
                            ByVal SendEMailOfTaskAssignToMe As Boolean, _
                            ByVal SendEMailOfAllProjectActivities As Boolean) As Integer

        With Adapter

            Dim objTable As TimeLiveDataSet.AccountEmployeeProjectPreferencesDataTable = Me.GetDataByAccountEmployeeIdAndAccountProjectId(AccountEmployeeId, AccountProjectID)

            If objTable.Rows.Count > 0 Then
                Me.UpdateAccountEmployeeProjectPreference(AccountEmployeeId, AccountProjectID, SendEMailOfTaskAssignToMe, SendEMailOfAllProjectActivities, CType(objTable.Rows(0), TimeLiveDataSet.AccountEmployeeProjectPreferencesRow).AccountEmployeeProjectPreferencesId)
                Return True
            Else

                Dim RowsAffected As Integer = Adapter.InsertAccountProjectPreference( _
                    AccountEmployeeId, AccountProjectID, SendEMailOfTaskAssignToMe, SendEMailOfAllProjectActivities)
                ' Return true if precisely one row was inserted, otherwise false

                Return RowsAffected = 1

            End If


        End With

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Function UpdateAccountEmployeeProjectPreference( _
                            ByVal AccountEmployeeId As Integer, ByVal AccountProjectID As Integer, _
                            ByVal SendEMailOfActivityAssignToMe As Boolean, _
                            ByVal SendEMailOfAllProjectActivities As Boolean, ByVal Original_AccountEmployeeProjectPreferencesId As Integer) As Boolean

        Dim AccountEmployeeProjectPreferences As TimeLiveDataSet.AccountEmployeeProjectPreferencesDataTable = Adapter.GetDataByAccountEmployeeProjectPreferencesId(Original_AccountEmployeeProjectPreferencesId)
        Dim AccountEmployeeProjectPreference As TimeLiveDataSet.AccountEmployeeProjectPreferencesRow = AccountEmployeeProjectPreferences.Rows(0)

        With AccountEmployeeProjectPreference
            .AccountEmployeeId = AccountEmployeeId
            .AccountProjectId = AccountProjectID
            .SendEMailOfActivityAssignToMe = SendEMailOfActivityAssignToMe
            .SendEMailOfAllProjectActivities = SendEMailOfAllProjectActivities
        End With

        Dim rowsAffected As Integer = Adapter.Update(AccountEmployeeProjectPreference)
            ' Return true if precisely one row was inserted, otherwise false
        Return rowsAffected = 1

    End Function

    Public Function DoesPreferenceExists(ByVal AccountEmployeeId As Integer, ByVal AccountProjectId As Integer) As Boolean
        If Adapter.GetDataByAccountIdAndAccountProjectID(AccountEmployeeId, AccountProjectId).Count > 0 Then
            'Throw New Exception("Preference with this Login is already exist")
            Return True
        Else
            Return False
        End If
    End Function




End Class
