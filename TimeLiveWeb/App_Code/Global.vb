Imports Microsoft.VisualBasic
Imports SmartMassEmail.Providers
Imports SmartMassEmail.Entities
Imports System.Web.Security
''' <summary>
''' This class implement standard ASP.Net Global events. 
''' TimeLive scheduled email is also implemented here.
''' </summary>
''' <remarks>Global.vb implementation</remarks>
Public Class AppGlobal
    Inherits System.Web.HttpApplication
    Private Const DummyPageUrl As String = "Cron.aspx"
    Private Const DummyCacheItemKey As String = "SmartMassEmailDummyCacheItem"
    ''' <summary>
    ''' ASP.Net Application_Start event. Different application initialization code is call in this event.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        UIUtilities.InsertTagforServiceModel()
        UIUtilities.DeleteOldWewebConfigFile()
        UIUtilities.InserthttpModulesWebConfigFile()
        ''web.config tag for chart
        UIUtilities.Inserthttphandlers()
        UIUtilities.InsertdotNetOpenAuthenticationtag()
        UIUtilities.InsertAppSettingsTag("ChartImageHandler", "storage=file;timeout=20;")
        'UIUtilities.InsertTagCaptchaImage()

        ' Initialize Log4Net (TimeLive Logging framework)
        log4net.Config.XmlConfigurator.Configure()
        LoggingBLL.WriteToLog("Application_Start: Initiated")
        ' Register Cache Callback for keeping TimeLive scheduler running
        If Not UIUtilities.DisableSchedule Then
            RegisterCacheEntry()
        End If
        'UIUtilities.ChangeApplicationSettings()
    End Sub
    ''' <summary>
    ''' ASP.Net Application_Error event. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
    ''' <summary>
    ''' Add temporary cache with its expiry and with callback function. Callback function of cache calling 
    ''' RegisterCache again in order to keep it running for another 10 minutes.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RegisterCacheEntry()
        If Not UIUtilities.DisableSchedule Then
            LoggingBLL.WriteToLog("RegisterCacheEntry:Register Cache for scheduled email")
            ' If temporary cache is not find in cache collection, then add this cache with 10 minutes expiry
            If HttpContext.Current.Cache(DummyCacheItemKey) Is Nothing Then
                HttpContext.Current.Cache.Add(DummyCacheItemKey, "Test", Nothing, DateTime.MaxValue, TimeSpan.FromMinutes(UIUtilities.SchedulerThreadTime()), CacheItemPriority.NotRemovable, New CacheItemRemovedCallback(AddressOf MyCacheItemRemovedCallback))
            End If
        End If
    End Sub
    ''' <summary>
    ''' Callback function of temporary cache expiry.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub MyCacheItemRemovedCallback(ByVal key As String, ByVal value As Object, ByVal reason As CacheItemRemovedReason)
        LoggingBLL.WriteToLog(String.Format("MyCacheItemRemovedCallback:DoWorkStart ----> At: {0}", DateTime.Now))
        ' Call Scheduled work function
        DoWork()
        LoggingBLL.WriteToLog(String.Format("MyCacheItemRemovedCallback:DoWorkEnd ----> At: {0}", DateTime.Now))
        LoggingBLL.WriteToLog("MyCacheItemRemovedCallback:HitPage Initiated")
        ' Call Cron page again in order to register cache again.
        HitPage()
    End Sub
    ''' <summary>
    ''' Hitpage function call Cron Page at runtime. Calling cron again and again will keep ASP.Net pool alive.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HitPage()
        LoggingBLL.WriteToLog("HitPage:HitPage Initiated " & GetDummyPageURL())
        Try
            ' Loading Cron page using code
            Dim client As System.Net.WebClient = New System.Net.WebClient
            client.DownloadData(GetDummyPageURL)
        Catch ex As Exception
            LoggingBLL.WriteExceptionNoRaiseToLog("HitPage:HitPage Exception", ex)
        End Try
        LoggingBLL.WriteToLog("HitPage:HitPage End")
    End Sub
    ''' <summary>
    ''' This will return URL of CronPage
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetDummyPageURL() As String
        Dim siteprefix As String
        ' If there is some specific cron page link available in AppSettings, then return that URL
        ' Otherwise simply return SitePrefix URL avaialble in AppSettings
        If Not ConfigurationManager.AppSettings.Get("CronSitePrefix") Is Nothing Then
            siteprefix = ConfigurationManager.AppSettings.Get("CronSitePrefix")
        Else
            siteprefix = ConfigurationManager.AppSettings.Get("SitePrefix")
        End If
        siteprefix = siteprefix + DummyPageUrl
        Return siteprefix
    End Function
    ''' <summary>
    ''' TimeLive main scheduler function
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoWork()
        LoggingBLL.WriteToLog(String.Format("Initated DoWork: Sending scheduled emails  ---> At: {0}", DateTime.Now))
        EMailUtilities.DequeueEmail()
        If UIUtilities.IsSendScheduledEmail Then
            EMailUtilities.SendScheduledEmail()
        End If
        If UIUtilities.IsDevelopmentEnvironment Then
            UIUtilities.DeleteDatabaseBackupTempFiles()
            UIUtilities.DeleteTempFiles()
        End If
        LoggingBLL.WriteToLog("Initated DoWork: Time Off")

        AccountEmployeeTimeOffBLL.UpdateTimeOffPolicies("System", "Cron")
        LoggingBLL.WriteToLog(String.Format("DoWork:End Queue email sending and Time Off  ---> At: {0}", DateTime.Now))
    End Sub
    ''' <summary>
    ''' ASP.Net Begin Request implementation. If the call is of Cron page, then it will call RegisterCache function 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AppGlobal_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BeginRequest
        Dim DummyPageURL As String = GetDummyPageURL()
        If HttpContext.Current.Request.Url.ToString() = DummyPageURL Then
            RegisterCacheEntry()
        End If
    End Sub

    'Private Sub AppGlobal_Error(sender As Object, e As System.EventArgs) Handles Me.Error
    '    LoggingBLL.WriteToLog("Unhandled Exception Occur")
    '    LoggingBLL.WriteToLog(Server.GetLastError.InnerException.ToString)
    'End Sub
    ''' <summary>
    ''' ASP.Net PreRequestHandlerExecute implementation. It setup culture settings of page 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AppGlobal_PreRequestHandlerExecute(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRequestHandlerExecute
        System.Threading.Thread.CurrentThread.CurrentUICulture = LocaleUtilitiesBLL.GetCurrentUICultureInfo()
    End Sub
End Class
