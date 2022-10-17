Imports Microsoft.VisualBasic
Imports TimeLiveDataSetTableAdapters

Public Class PaymentStatusBLL

    Private _PaymentStatusTableAdapter As PaymentStatusTableAdapter = Nothing
    Protected ReadOnly Property Adapter() As PaymentStatusTableAdapter
        Get
            If _PaymentStatusTableAdapter Is Nothing Then
                _PaymentStatusTableAdapter = New PaymentStatusTableAdapter()
            End If

            Return _PaymentStatusTableAdapter
        End Get
    End Property
    <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, True)>
    Public Function GetPaymentStatus() As TimeLiveDataSet.PaymentStatusDataTable
        UIUtilities.FixTableForNoRecords(Adapter.GetData)
        Return Adapter.GetData
    End Function

End Class
