Imports Microsoft.VisualBasic

Public Class CacheManager
    Public Shared Sub AddStaticDataInCache(ByVal ObjectToCache As Object, ByVal Key As String)
        CacheManager.AddInCache(ObjectToCache, Key, CacheItemPriority.NotRemovable, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20))
    End Sub
    Public Shared Sub AddAccountDataInCache(ByVal ObjectToCache As Object, ByVal Key As String)
        CacheManager.AddInCache(ObjectToCache, Key, CacheItemPriority.Normal, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20))
    End Sub
    Public Shared Sub AddAccountEmployeeDataInCache(ByVal ObjectToCache As Object, ByVal Key As String)
        If DBUtilities.IsApplicationContext Then
            CacheManager.AddInCache(ObjectToCache, Key, CacheItemPriority.Normal, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20))
        End If
    End Sub
    Public Shared Sub AddInCache(ByVal ObjectToCache As Object, ByVal Key As String, ByVal Priority As System.Web.Caching.CacheItemPriority, ByVal absoluteExpiration As Date, ByVal slidingExpiration As TimeSpan)
        System.Web.HttpContext.Current.Cache.Add(Key, ObjectToCache, Nothing, absoluteExpiration, slidingExpiration, Priority, Nothing)
    End Sub

    'VAI RETORNAR SEMPRE NOTHING DE FORMA A DESACTIVAR A CACHE
    'DESTA FORMA GARANTE SE UM ESTADO COERENTE UMA VEZ QUE TODOS OS ACESSOS DAS ENTRIES E EXPENSES SAO FEITOS A BD
    Public Shared Function GetItemFromCache(ByVal Key As String) As Object
        Return Nothing 'System.Web.HttpContext.Current.Cache.Get(Key)
    End Function
    Public Shared Function GetCacheKeyForAccountsData(ByVal strDataTableName As String, ByVal strFunctionName As String, ByVal strParameters As String, Optional ByVal SessionAccountId As Integer = -1)
        Return GetCacheKeyForAccountEmployeeData(strDataTableName, strFunctionName, strParameters, SessionAccountId)
    End Function
    Public Shared Function GetCacheKeyForAccountEmployeeData(ByVal strDataTableName As String, ByVal strFunctionName As String, ByVal strParameters As String, Optional ByVal SessionAccountId As Integer = -1)
        Dim strAccountEmployeeId As String = DBUtilities.GetSessionAccountEmployeeId
        Dim strAccountId As String
        If SessionAccountId > 0 Then
            strAccountId = SessionAccountId
        Else
            strAccountId = DBUtilities.GetSessionAccountId
        End If
        Return strDataTableName & "__" & strFunctionName & "__" & "SessionAccountEmployee=" & strAccountEmployeeId & "__" & "SessionAccount=" & strAccountId & "__" & strParameters
    End Function
    Public Shared Function GetEmployeeCacheKeyParameterForTimeEntryData(ByVal strParameters As String, ByVal TimeEntryStartDate As Date, ByVal TimeEntryEndDate As Date)
        Dim TotalDays As Integer = DateDiff(DateInterval.Day, TimeEntryStartDate, TimeEntryEndDate)
        Dim strTimeEntryDates As String = ""
        For i As Integer = 0 To TotalDays
            strTimeEntryDates += "_TimeEntryDate=" & TimeEntryStartDate.AddDays(i)
        Next
        Return strParameters & strTimeEntryDates
    End Function
    Public Shared Sub ClearCache(ByVal TableToDelete As String, Optional ByVal strParameters As String = "No parameter", Optional ByVal IsDeleteByAccountId As Boolean = False, Optional ByVal IsDeleteForAccountEmployeeId As Boolean = False)
        If DBUtilities.IsApplicationContext Then
            Dim strAccountKey As String = "SessionAccount=" & DBUtilities.GetSessionAccountId
            Dim strAccountEmployeeKey As String = "SessionAccountEmployee=" & DBUtilities.GetSessionAccountEmployeeId
            Dim strCurrentKey As String
            Dim cacheContents As System.Collections.IDictionaryEnumerator = System.Web.HttpContext.Current.Cache.GetEnumerator

            While cacheContents.MoveNext
                strCurrentKey = cacheContents.Key.ToString()
                Dim Keys() As String = Split(strCurrentKey, "__")
                If Keys.Length >= 4 Then
                    If Keys(0).IndexOf(TableToDelete) >= 0 And Keys(4).IndexOf(strParameters) >= 0 Then
                        System.Web.HttpContext.Current.Cache.Remove(strCurrentKey)
                    End If
                    If IsDeleteByAccountId = True And Keys(0).IndexOf(TableToDelete) >= 0 And Keys(3) = strAccountKey Then
                        System.Web.HttpContext.Current.Cache.Remove(strCurrentKey)
                    End If
                    If IsDeleteForAccountEmployeeId = True And Keys(0).IndexOf(TableToDelete) >= 0 And Keys(2) = strAccountEmployeeKey Then
                        System.Web.HttpContext.Current.Cache.Remove(strCurrentKey)
                    End If
                End If
            End While
        End If
    End Sub
    Public Shared Sub RemoveFromCache(ByVal KeyToDelete As String)
        System.Web.HttpContext.Current.Cache.Remove(KeyToDelete)
    End Sub
End Class
