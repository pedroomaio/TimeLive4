﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.296
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://localhost:1070/TimeLiveWeb/Services/TimeLiveServices.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLiveServices() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLiveServices"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLiveServices") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://localhost:1070/TimeLiveWeb/Services/Employees.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Employees_Employees() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Employees_Employees"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Employees_Employees") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://localhost:1070/TimeLiveWeb/Services/Clients.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Clients_Clients() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Clients_Clients"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Clients_Clients") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://localhost:1070/TimeLiveWeb/Services/Projects.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Projects_Projects() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Projects_Projects"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Projects_Projects") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://localhost:1070/TimeLiveWeb/Services/Tasks.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_Tasks_Tasks() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Tasks_Tasks"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_Tasks_Tasks") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://localhost:1070/TimeLiveWeb/Services/TimeEntries.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_TimeEntries_TimeEntries() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_TimeEntries_TimeEntries"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_TimeEntries_TimeEntries") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://localhost:1070/TimeLiveWeb/Services/ExpenseEntries.asmx"),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property TimeLive_Integration_Quickbooks_Services_TimeLive_ExpenseEntries_ExpenseEntries() As String
            Get
                Return CType(Me("TimeLive_Integration_Quickbooks_Services_TimeLive_ExpenseEntries_ExpenseEntries"),String)
            End Get
            Set
                Me("TimeLive_Integration_Quickbooks_Services_TimeLive_ExpenseEntries_ExpenseEntries") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(""),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property WebServiceURL() As String
            Get
                Return CType(Me("WebServiceURL"),String)
            End Get
            Set
                Me("WebServiceURL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(""),  _
         Global.System.Configuration.SettingsManageabilityAttribute(Global.System.Configuration.SettingsManageability.Roaming)>  _
        Public Property Username() As String
            Get
                Return CType(Me("Username"),String)
            End Get
            Set
                Me("Username") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.TimeLive.Integration.Quickbooks.My.MySettings
            Get
                Return Global.TimeLive.Integration.Quickbooks.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace