Imports Microsoft.VisualBasic
Imports InteractiveStudios.QlmLicenseLib
Imports System.Security
Imports System.Security.Cryptography
Imports SystemLicenseTableAdapters

<System.ComponentModel.DataObject()> _
Public Class SystemLicenseBLL
    Private _SystemLicenseTableAdapters As SystemLicenseTableAdapter = Nothing

    Protected ReadOnly Property LicenseAdapter() As SystemLicenseTableAdapter
        Get
            If _SystemLicenseTableAdapters Is Nothing Then
                _SystemLicenseTableAdapters = New SystemLicenseTableAdapter()
            End If
            Return _SystemLicenseTableAdapters
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetNumberOfUserOfPackageAndIsTraklive(ByVal PackageCode As String, ByVal IsTrakLive As Boolean) As SystemLicense.SystemLicenseDataTable
        Return LicenseAdapter.GetDataByPackageCode(PackageCode, IsTrakLive)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetHostedPackageFromSystemLicense(ByVal SystemLicenseID As Guid) As SystemLicense.SystemLicenseDataTable
        Return LicenseAdapter.GetDataForHostedPackage(SystemLicenseID)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLicenseDataByVersion(ByVal Version As Integer, ByVal IsTrakLive As Boolean) As SystemLicense.SystemLicenseDataTable
        Return LicenseAdapter.GetDataByVersion(Version, IsTrakLive)
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetLicenseDataByIsCurrentVersion(ByVal IsCurrentVersion As Boolean, ByVal IsTrakLive As Boolean) As SystemLicense.SystemLicenseDataTable
        Return LicenseAdapter.GetDataByIsCurrentVersion(IsCurrentVersion, IsTrakLive)
    End Function
    Public Function GetNumberOfUserOfPackage(ByVal PackageCode As String, ByVal IsTrakLive As Boolean) As Integer
        Dim dtlicenseOld As SystemLicense.SystemLicenseDataTable = Me.GetNumberOfUserOfPackageForOldVersion(PackageCode, IsTrakLive)
        Dim drlicenseOld As SystemLicense.SystemLicenseRow
        If dtlicenseOld.Rows.Count > 0 Then
            drlicenseOld = dtlicenseOld.Rows(0)
            If drlicenseOld.PackageCode.Contains("99999") Then
                Return drlicenseOld.NumberOfUsers
            End If
            If Not IsDBNull(drlicenseOld.Item("Version")) Then
                If drlicenseOld.Version >= 4 Or drlicenseOld.IsTrakLive = True Then
                    Return PackageCode.Substring(PackageCode.LastIndexOf("_") + 1)
                Else
                    Return drlicenseOld.NumberOfUsers
                End If
            Else
                Return drlicenseOld.NumberOfUsers
            End If
        Else
            Dim dtlicense As SystemLicense.SystemLicenseDataTable = Me.GetNumberOfUserOfPackageAndIsTraklive(PackageCode, IsTrakLive)
            Dim drlicense As SystemLicense.SystemLicenseRow
            If dtlicense.Rows.Count > 0 Then
                drlicense = dtlicense.Rows(0)
                If drlicense.PackageCode.Contains("99999") Then
                    Return drlicense.NumberOfUsers
                End If
                If Not IsDBNull(drlicense.Item("Version")) Then
                    If drlicense.Version >= 4 Or drlicense.IsTrakLive = True Then
                        Return PackageCode.Substring(PackageCode.LastIndexOf("_") + 1)
                    Else
                        Return drlicense.NumberOfUsers
                    End If
                Else
                    Return drlicense.NumberOfUsers
                End If
            End If
        End If
        Return 99999
    End Function
    Public Function GetHostedCurrrentSystemLicenseID(ByVal PackageCode As String, ByVal IsTrakLive As Boolean) As Guid
        Dim dtlicense As SystemLicense.SystemLicenseDataTable = Me.GetNumberOfUserOfPackageAndIsTraklive(PackageCode, IsTrakLive)
        Dim drlicense As SystemLicense.SystemLicenseRow
        If dtlicense.Rows.Count > 0 Then
            drlicense = dtlicense.Rows(0)
            Return drlicense.SystemLicenseId
        End If
        Return System.Guid.Empty
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetNumberOfUserOfPackageForOldVersion(ByVal PackageCode As String, ByVal IsTrakLive As Boolean) As SystemLicense.SystemLicenseDataTable
        Return LicenseAdapter.GetDataByPackageCodeOldVersion(PackageCode, IsTrakLive)
    End Function
    Public Function GetPackageCode(ByVal PackageCode As String, ByVal IsTrakLive As Boolean) As String
        Dim dtlicenseOld As SystemLicense.SystemLicenseDataTable = Me.GetNumberOfUserOfPackageForOldVersion(PackageCode, IsTrakLive)
        Dim drlicenseOld As SystemLicense.SystemLicenseRow
        If dtlicenseOld.Rows.Count > 0 Then
            drlicenseOld = dtlicenseOld.Rows(0)
            Return drlicenseOld.PackageCode
        Else
            Dim dtlicense As SystemLicense.SystemLicenseDataTable = Me.GetNumberOfUserOfPackageAndIsTraklive(PackageCode, IsTrakLive)
            Dim drlicense As SystemLicense.SystemLicenseRow
            If dtlicense.Rows.Count > 0 Then
                drlicense = dtlicense.Rows(0)
                Return drlicense.PackageCode
            End If
        End If
        Return "Lite"
    End Function
    Public Function GetVersionOfPackage(ByVal PackageCode As String, ByVal IsTrakLive As Boolean) As Integer
        Dim dtlicenseOld As SystemLicense.SystemLicenseDataTable = Me.GetNumberOfUserOfPackageForOldVersion(PackageCode, IsTrakLive)
        Dim drlicenseOld As SystemLicense.SystemLicenseRow
        If dtlicenseOld.Rows.Count > 0 Then
            drlicenseOld = dtlicenseOld.Rows(0)
            If Not IsDBNull(drlicenseOld("Version")) Then
                Return drlicenseOld.Version
            Else
                Return Me.GetIsCurrentVersion(IsTrakLive)
            End If
        Else
            Dim dtlicense As SystemLicense.SystemLicenseDataTable = Me.GetNumberOfUserOfPackageAndIsTraklive(PackageCode, IsTrakLive)
            Dim drlicense As SystemLicense.SystemLicenseRow
            If dtlicense.Rows.Count > 0 Then
                drlicense = dtlicense.Rows(0)
                If Not IsDBNull(drlicense("Version")) Then
                    Return drlicense.Version
                Else
                    Return Me.GetIsCurrentVersion(IsTrakLive)
                End If
            End If
        End If
    End Function
    Public Function GetIsCurrentVersion(ByVal IsTrakLive As Boolean) As Integer
        Dim dtCVersion As SystemLicense.SystemLicenseDataTable = Me.GetLicenseDataByIsCurrentVersion(True, IsTrakLive)
        Dim drCVersion As SystemLicense.SystemLicenseRow
        If dtCVersion.Rows.Count > 0 Then
            drCVersion = dtCVersion.Rows(0)
            Return drCVersion.Version
        End If
    End Function
End Class
