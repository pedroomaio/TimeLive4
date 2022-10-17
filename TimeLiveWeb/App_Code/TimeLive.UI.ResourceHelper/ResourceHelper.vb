Imports Microsoft.VisualBasic

Public Class ResourceHelper
    Public Shared Function GetDeleteMessageJavascript() As String
        Return "return confirm('" & Resources.TimeLive.Resource.Delete_cofirmation & "');"
    End Function
    Public Shared Function GetSubmitMessageJavascript() As String
        Return "return confirm('" & ResourceHelper.GetFromResource(Resources.TimeLive.Resource.Comfirmation_TimeSheet_SubmitApproval) & "');"
    End Function
    Public Shared Function GetSaveMessageJavascript() As String
        Return "return alert('" & Resources.TimeLive.Resource.Save_cofirmation & "');"
    End Function
    Public Shared Function GetSaveMessageJavascriptForDayView() As String
        Return "return alert('" & Resources.TimeLive.Resource.Save_Confirmation_DayView & "');"
    End Function
    Public Shared Function GetDefaultDataLocalValue(ByVal Value As String) As String
        Return System.Web.HttpContext.GetGlobalResourceObject("TimeLive.Web", Value)
    End Function
    Public Shared Function GetSaveMessageJavascriptForInvoice() As String
        Return "return alert('" & Resources.TimeLive.Resource.save_confirmation_Invoice & "');"
    End Function
    Public Shared Function GetCopyMessageJavascriptForDayView() As String
        Return "return confirm('" & Resources.TimeLive.Resource.Copy_Conformation_Message_DayView & "');"
    End Function
    Public Shared Function GetCopyMessageJavascriptForWeekView() As String
        Return "return confirm('" & Resources.TimeLive.Resource.Copy_Conformation_Message_WeekView & "');"
    End Function
    Public Shared Function GetCopyFromTemplateMessageJavascriptForWeekView() As String
        Return "return confirm('" & Resources.TimeLive.Resource.CopyFromTemplate_Conformation_Message_WeekView & "');"
    End Function
    Public Shared Function GetCopyMessageJavascriptForHolidayType() As String
        Return "return confirm('" & ResourceHelper.GetFromResource(Resources.TimeLive.Resource.Copy_Conformation_Message_DayView1) & "');"
    End Function
    Public Shared Function GetPopulateMessageJavascriptForInvoice() As String
        Return "return confirm('" & Resources.TimeLive.Resource.Populate_Conformation_Message_Invoice & "');"
    End Function
    Public Shared Function IsGetFromSystemTerminology(ByVal Term As String) As Boolean
        If Term.Contains("Cost Center") Or Term.Contains("Location") Then
            Return True
        End If
    End Function
    Public Shared Function GetFromResource(ByVal Value As String, Optional ByVal AccountId As Integer = 0) As String
        Return TransformToTerminology(Value, AccountId)
    End Function
    Public Shared Function TransformToTerminology(ByVal Value As String, Optional ByVal AccountId As Integer = 0) As String
        Dim ReplacedValue As String = FindAndReplace(Value)
        Dim TransformValue As String = AccountTerminologyBLL.GetTransformedStringFromTerminology(ReplacedValue, AccountId)
        Dim Name As String = System.Web.HttpContext.GetGlobalResourceObject("TimeLive.Resource", TransformValue)
        If Name Is Nothing Then
            Return TransformValue
        Else
            Return Name
        End If
    End Function
    Public Shared Function FindAndReplace(ByVal Value As String) As String
        Dim App_Name As String = "TimeLive"
        Dim Copyright_Text As String = "Copyright 2007 - 2009 Livetecs LLC. All rights reserved."
        If Value.Contains(App_Name) Then
            If System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME") Is Nothing Then
                Return Value
            Else
                Return Replace(Value, App_Name, System.Configuration.ConfigurationManager.AppSettings("APPLICATION_NAME"))
            End If
        ElseIf Value.Contains(Copyright_Text) Then
            If System.Configuration.ConfigurationManager.AppSettings("COPYRIGHT_TEXT") Is Nothing Then
                Return Value
            Else
                Return System.Configuration.ConfigurationManager.AppSettings("COPYRIGHT_TEXT")
            End If
        End If
        If System.Configuration.ConfigurationManager.AppSettings("BugTracking") = "Yes" Then
            Return Value.Replace("Task", "Bug")
        Else
            Return Value
        End If
        Return Value
    End Function
    Public Shared Function SetResourceValueInDataTable(ByVal dt As DataTable, ByVal ColumnName As String) As DataTable
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows.Item(i).Item(ColumnName) = ResourceHelper.GetFromResource(dt.Rows.Item(i).Item(ColumnName).ToString)
        Next
        Return dt
    End Function
    Public Shared Function GetCustomFieldMessageJavascript() As String
        Return "return confirm('" & "Deleting a Custom Field is a permanent action, and will delete all data entered against this field as well. " & Resources.TimeLive.Resource.Delete_cofirmation & " ');"
    End Function
    Public Shared Function GetResetPolicyMessageJavascript() As String
        Return "return confirm('This will reset the policy as if it starts from today. Do you want to continue?');"
    End Function

End Class
