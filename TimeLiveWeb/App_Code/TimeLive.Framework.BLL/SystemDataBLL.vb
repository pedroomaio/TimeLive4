Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters
<System.ComponentModel.DataObject()> _
Public Class SystemDataBLL

    Private _SystemNamePrefixAdapter As TimeLiveDataSetTableAdapters.SystemNamePrefixTableAdapter
    Private _SystemCountryAdapter As TimeLiveDataSetTableAdapters.SystemCountryTableAdapter
    Private _SystemCurrencyAdapter As TimeLiveDataSetTableAdapters.SystemCurrencyTableAdapter
    Private _SystemDurationUnitAdapter As TimeLiveDataSetTableAdapters.SystemDurationUnitTableAdapter
    Private _SystemBillingCategoryAdapter As TimeLiveDataSetTableAdapters.SystemBillingCategoryTableAdapter
    Private _SystemWorkingDayAdapter As TimeLiveDataSetTableAdapters.SystemWorkingDayTableAdapter
    Private _SystemStatusTypeAdapter As TimeLiveDataSetTableAdapters.SystemStatusTypeTableAdapter
    Private _SystemTimeSheetApprovalPathAdapter As TimeLiveDataSetTableAdapters.SystemTimeSheetApprovalPathTableAdapter
    Private _AccountTypeAdapter As TimeLiveDataSetTableAdapters.AccountTypeTableAdapter
    Private _SystemTimeZoneTableAdapter As TimeLiveDataSetTableAdapters.SystemTimeZoneTableAdapter
    Private _SystemPackageTypeTableAdapter As TimeLiveDataSetTableAdapters.SystemPackageTypeTableAdapter
    Private _SystemCustomerRequestTypeTableAdapter As TimeLiveDataSetTableAdapters.SystemCustomerRequestTypeTableAdapter
    Private _SystemProjectBillingRateTypeTableAdapter As TimeLiveDataSetTableAdapters.SystemProjectBillingRateTypeTableAdapter
    Private _SystemSecurityCategoryPageTableAdapter As TimeLiveDataSetTableAdapters.SystemSecurityCategoryPageTableAdapter
    Private _SystemApproverTypeTableAdapter As TimeLiveDataSetTableAdapters.SystemApproverTypeTableAdapter
    Private _SystemEMailNotificationTypeTableAdapter As TimeLiveDataSetTableAdapters.SystemEMailNotificationTypeTableAdapter
    Private _SystemEMailNotificationTableAdapter As TimeLiveDataSetTableAdapters.SystemEMailNotificationTableAdapter
    Private _SystemEarnPeriodTableAdapter As AccountTimeOffPolicyTableAdapters.SystemEarnPeriodTableAdapter
    Private _SystemResetToZeroTypeTableAdapter As AccountTimeOffPolicyTableAdapters.SystemResetToZeroTypeTableAdapter
    Private _SystemInvoiceBillingTypeTableAdapter As TimeLiveDataSetTableAdapters.SystemInvoiceBillingTypeTableAdapter
    Private _SystemTimeEntryHoursFormatTableAdapter As TimeLiveDataSetTableAdapters.SystemTimeEntryHoursFormatTableAdapter

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetNamePrefix() As TimeLiveDataSet.SystemNamePrefixDataTable

        If Not CacheManager.GetItemFromCache("SystemNamePrefix") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemNamePrefix")
        Else

            If _SystemNamePrefixAdapter Is Nothing Then
                _SystemNamePrefixAdapter = New TimeLiveDataSetTableAdapters.SystemNamePrefixTableAdapter
            End If
            GetNamePrefix = _SystemNamePrefixAdapter.GetData

            CacheManager.AddStaticDataInCache(GetNamePrefix, "SystemNamePrefix")
            Return GetNamePrefix
        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCountries() As TimeLiveDataSet.SystemCountryDataTable

        If Not CacheManager.GetItemFromCache("SystemCountry") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemCountry")
        Else

            If _SystemCountryAdapter Is Nothing Then
                _SystemCountryAdapter = New TimeLiveDataSetTableAdapters.SystemCountryTableAdapter
            End If
            GetCountries = _SystemCountryAdapter.GetData
            CacheManager.AddStaticDataInCache(GetCountries, "SystemCountry")
            Return GetCountries
        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCountryByCountryId(ByVal CountryId) As TimeLiveDataSet.SystemCountryRow


        If _SystemCountryAdapter Is Nothing Then
            _SystemCountryAdapter = New TimeLiveDataSetTableAdapters.SystemCountryTableAdapter
        End If
        GetCountryByCountryId = _SystemCountryAdapter.GetDataByCountryId(CountryId).Rows(0)

        Return GetCountryByCountryId


    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCurrencies() As TimeLiveDataSet.SystemCurrencyDataTable

        If Not CacheManager.GetItemFromCache("SystemCurrency") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemCurrency")
        Else

            If _SystemCurrencyAdapter Is Nothing Then
                _SystemCurrencyAdapter = New TimeLiveDataSetTableAdapters.SystemCurrencyTableAdapter
            End If
            GetCurrencies = _SystemCurrencyAdapter.GetData
            CacheManager.AddStaticDataInCache(GetCurrencies, "SystemCurrency")
            Return GetCurrencies
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
Public Function GetCurrenciesWithCode() As TimeLiveDataSet.SystemCurrencyDataTable

        'If Not CacheManager.GetItemFromCache("SystemCurrency") Is Nothing Then
        'Return CacheManager.GetItemFromCache("SystemCurrency")
        'Else

        If _SystemCurrencyAdapter Is Nothing Then
            _SystemCurrencyAdapter = New TimeLiveDataSetTableAdapters.SystemCurrencyTableAdapter
            'End If
            GetCurrenciesWithCode = _SystemCurrencyAdapter.GetCurrenciesWithCode()
            'CacheManager.AddStaticDataInCache(GetCurrenyCodeAndCurrencyName, "SystemCurrency")
            Return GetCurrenciesWithCode
        End If
    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetDurationUnit() As TimeLiveDataSet.SystemDurationUnitDataTable

        If Not CacheManager.GetItemFromCache("SystemDuration") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemDuration")
        Else

            If _SystemDurationUnitAdapter Is Nothing Then
                _SystemDurationUnitAdapter = New TimeLiveDataSetTableAdapters.SystemDurationUnitTableAdapter
            End If
            GetDurationUnit = _SystemDurationUnitAdapter.GetData
            CacheManager.AddStaticDataInCache(GetDurationUnit, "SystemDuration")
            Return GetDurationUnit

        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetBillingCategories() As TimeLiveDataSet.SystemBillingCategoryDataTable

        If Not CacheManager.GetItemFromCache("SystemBillingCategory") Is Nothing Then
            GetBillingCategories = CacheManager.GetItemFromCache("SystemBillingCategory")
            Return ResourceHelper.SetResourceValueInDataTable(GetBillingCategories, "SystemBillingCategory")
        Else

            If _SystemBillingCategoryAdapter Is Nothing Then
                _SystemBillingCategoryAdapter = New TimeLiveDataSetTableAdapters.SystemBillingCategoryTableAdapter
            End If

            GetBillingCategories = _SystemBillingCategoryAdapter.GetData

            CacheManager.AddStaticDataInCache(GetBillingCategories, "SystemBillingCategory")

            GetBillingCategories = GetBillingCategories

            Return ResourceHelper.SetResourceValueInDataTable(GetBillingCategories, "SystemBillingCategory")

        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetWorkingDays() As TimeLiveDataSet.SystemWorkingDayDataTable

        If Not CacheManager.GetItemFromCache("SystemWorkingDay") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemWorkingDay")
        Else

            If _SystemWorkingDayAdapter Is Nothing Then
                _SystemWorkingDayAdapter = New TimeLiveDataSetTableAdapters.SystemWorkingDayTableAdapter
            End If

            GetWorkingDays = _SystemWorkingDayAdapter.GetData

            CacheManager.AddStaticDataInCache(GetWorkingDays, "SystemWorkingDay")

            Return GetWorkingDays

        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetStatusTypes() As TimeLiveDataSet.SystemStatusTypeDataTable
        If Not CacheManager.GetItemFromCache("SystemStatusType") Is Nothing Then
            GetStatusTypes = CacheManager.GetItemFromCache("SystemStatusType")
            Return ResourceHelper.SetResourceValueInDataTable(GetStatusTypes, "SystemStatusType")
        Else

            If _SystemStatusTypeAdapter Is Nothing Then
                _SystemStatusTypeAdapter = New TimeLiveDataSetTableAdapters.SystemStatusTypeTableAdapter
            End If

            GetStatusTypes = _SystemStatusTypeAdapter.GetData

            CacheManager.AddStaticDataInCache(GetStatusTypes, "SystemStatusType")

            Return ResourceHelper.SetResourceValueInDataTable(GetStatusTypes, "SystemStatusType")

        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeSheetApprovalPaths() As TimeLiveDataSet.SystemTimeSheetApprovalPathDataTable

        If Not CacheManager.GetItemFromCache("SystemTimeSheetApprovalPath") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemTimeSheetApprovalPath")
        Else

            If _SystemTimeSheetApprovalPathAdapter Is Nothing Then
                _SystemTimeSheetApprovalPathAdapter = New TimeLiveDataSetTableAdapters.SystemTimeSheetApprovalPathTableAdapter
            End If

            GetTimeSheetApprovalPaths = _SystemTimeSheetApprovalPathAdapter.GetData

            CacheManager.AddStaticDataInCache(GetTimeSheetApprovalPaths, "SystemTimeSheetApprovalPath")

            Return GetTimeSheetApprovalPaths

        End If

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetAccountTypes() As TimeLiveDataSet.AccountTypeDataTable

        If Not CacheManager.GetItemFromCache("AccountType") Is Nothing Then
            Return CacheManager.GetItemFromCache("AccountType")
        Else

            If _AccountTypeAdapter Is Nothing Then
                _AccountTypeAdapter = New TimeLiveDataSetTableAdapters.AccountTypeTableAdapter
            End If

            GetAccountTypes = _AccountTypeAdapter.GetData

            CacheManager.AddStaticDataInCache(GetAccountTypes, "AccountType")

            Return GetAccountTypes

        End If

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeZones() As TimeLiveDataSet.SystemTimeZoneDataTable

        If Not CacheManager.GetItemFromCache("SystemTimeZone") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemTimeZone")
        Else

            If _SystemTimeZoneTableAdapter Is Nothing Then
                _SystemTimeZoneTableAdapter = New TimeLiveDataSetTableAdapters.SystemTimeZoneTableAdapter
            End If

            GetTimeZones = _SystemTimeZoneTableAdapter.GetData

            CacheManager.AddStaticDataInCache(GetTimeZones, "SystemTimeZone")

            Return GetTimeZones

        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetTimeZoneByTimeZoneId(ByVal TimeZoneId As Byte) As TimeLiveDataSet.SystemTimeZoneRow

        If _SystemTimeZoneTableAdapter Is Nothing Then
            _SystemTimeZoneTableAdapter = New TimeLiveDataSetTableAdapters.SystemTimeZoneTableAdapter
        End If

        Return _SystemTimeZoneTableAdapter.GetDataBySystemTimeZoneId(TimeZoneId).Rows(0)

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
Public Function GetPackageTypeByPackageTypeId(ByVal PackageTypeId As Short) As TimeLiveDataSet.SystemPackageTypeRow

        If _SystemPackageTypeTableAdapter Is Nothing Then
            _SystemPackageTypeTableAdapter = New TimeLiveDataSetTableAdapters.SystemPackageTypeTableAdapter
        End If

        Return _SystemPackageTypeTableAdapter.GetDataByPackageTypeId(PackageTypeId).Rows(0)

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetCustomerRequestType() As TimeLiveDataSet.SystemCustomerRequestTypeDataTable

        If _SystemCustomerRequestTypeTableAdapter Is Nothing Then
            _SystemCustomerRequestTypeTableAdapter = New TimeLiveDataSetTableAdapters.SystemCustomerRequestTypeTableAdapter
        End If

        GetCustomerRequestType = Me._SystemCustomerRequestTypeTableAdapter.GetData

        Return GetCustomerRequestType

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectBillingRateType() As TimeLiveDataSet.SystemProjectBillingRateTypeDataTable

        If _SystemProjectBillingRateTypeTableAdapter Is Nothing Then
            _SystemProjectBillingRateTypeTableAdapter = New TimeLiveDataSetTableAdapters.SystemProjectBillingRateTypeTableAdapter
        End If

        GetProjectBillingRateType = Me._SystemProjectBillingRateTypeTableAdapter.GetData

        Return ResourceHelper.SetResourceValueInDataTable(GetProjectBillingRateType, "SystemProjectBillingRateType")

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetProjectBillingRateTypeForQB() As TimeLiveDataSet.SystemProjectBillingRateTypeDataTable

        If _SystemProjectBillingRateTypeTableAdapter Is Nothing Then
            _SystemProjectBillingRateTypeTableAdapter = New TimeLiveDataSetTableAdapters.SystemProjectBillingRateTypeTableAdapter
        End If

        GetProjectBillingRateTypeForQB = Me._SystemProjectBillingRateTypeTableAdapter.GetData

        Return GetProjectBillingRateTypeForQB

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemSecurityCategoryPage() As TimeLiveDataSet.SystemSecurityCategoryPageDataTable

        If _SystemSecurityCategoryPageTableAdapter Is Nothing Then
            _SystemSecurityCategoryPageTableAdapter = New TimeLiveDataSetTableAdapters.SystemSecurityCategoryPageTableAdapter
        End If

        GetSystemSecurityCategoryPage = Me._SystemSecurityCategoryPageTableAdapter.GetData

        Return GetSystemSecurityCategoryPage()

    End Function

    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemApproverTypes() As TimeLiveDataSet.SystemApproverTypeDataTable

        If _SystemApproverTypeTableAdapter Is Nothing Then
            _SystemApproverTypeTableAdapter = New TimeLiveDataSetTableAdapters.SystemApproverTypeTableAdapter
        End If

        GetSystemApproverTypes = Me._SystemApproverTypeTableAdapter.GetData()

        Return GetSystemApproverTypes()

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemEMailNotificationTypes() As TimeLiveDataSet.SystemEMailNotificationTypeDataTable

        If _SystemEMailNotificationTypeTableAdapter Is Nothing Then
            _SystemEMailNotificationTypeTableAdapter = New TimeLiveDataSetTableAdapters.SystemEMailNotificationTypeTableAdapter
        End If

        GetSystemEMailNotificationTypes = Me._SystemEMailNotificationTypeTableAdapter.GetData()

        Return GetSystemEMailNotificationTypes()

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemEMailNotifications() As TimeLiveDataSet.SystemEMailNotificationDataTable

        If _SystemEMailNotificationTableAdapter Is Nothing Then
            _SystemEMailNotificationTableAdapter = New TimeLiveDataSetTableAdapters.SystemEMailNotificationTableAdapter
        End If

        GetSystemEMailNotifications = Me._SystemEMailNotificationTableAdapter.GetData()

        Return GetSystemEMailNotifications()

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemEarnPeriods() As AccountTimeOffPolicy.SystemEarnPeriodDataTable

        If _SystemEarnPeriodTableAdapter Is Nothing Then
            _SystemEarnPeriodTableAdapter = New AccountTimeOffPolicyTableAdapters.SystemEarnPeriodTableAdapter
        End If

        GetSystemEarnPeriods = Me._SystemEarnPeriodTableAdapter.GetData()

        Return GetSystemEarnPeriods

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemResetToZeroType() As AccountTimeOffPolicy.SystemResetToZeroTypeDataTable

        If _SystemResetToZeroTypeTableAdapter Is Nothing Then
            _SystemResetToZeroTypeTableAdapter = New AccountTimeOffPolicyTableAdapters.SystemResetToZeroTypeTableAdapter
        End If

        GetSystemResetToZeroType = Me._SystemResetToZeroTypeTableAdapter.GetData()

        Return GetSystemResetToZeroType

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetInvoiceBillingType() As TimeLiveDataSet.SystemInvoiceBillingTypeDataTable

        If Not CacheManager.GetItemFromCache("SystemInvoiceBilling") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemInvoiceBilling")
        Else

            If _SystemInvoiceBillingTypeTableAdapter Is Nothing Then
                _SystemInvoiceBillingTypeTableAdapter = New TimeLiveDataSetTableAdapters.SystemInvoiceBillingTypeTableAdapter
            End If
            GetInvoiceBillingType = _SystemInvoiceBillingTypeTableAdapter.GetData

            CacheManager.AddStaticDataInCache(GetInvoiceBillingType, "SystemInvoiceBilling")
            Return GetInvoiceBillingType()
        End If

    End Function
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)> _
    Public Function GetSystemTimeEntryHoursFormat() As TimeLiveDataSet.SystemTimeEntryHoursFormatDataTable

        If Not CacheManager.GetItemFromCache("SystemTimeEntryHoursFormat") Is Nothing Then
            Return CacheManager.GetItemFromCache("SystemTimeEntryHoursFormat")
        Else

            If _SystemTimeEntryHoursFormatTableAdapter Is Nothing Then
                _SystemTimeEntryHoursFormatTableAdapter = New TimeLiveDataSetTableAdapters.SystemTimeEntryHoursFormatTableAdapter
            End If
            GetSystemTimeEntryHoursFormat = _SystemTimeEntryHoursFormatTableAdapter.GetData

            CacheManager.AddStaticDataInCache(GetSystemTimeEntryHoursFormat, "SystemTimeEntryHoursFormat")
            Return GetSystemTimeEntryHoursFormat()
        End If

    End Function
End Class
