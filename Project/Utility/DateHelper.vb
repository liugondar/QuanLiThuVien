Imports System.Configuration
Public NotInheritable Class DateHelper
    Private Shared ReadOnly _instance As New Lazy(Of DateHelper)(Function() New DateHelper(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance() As DateHelper
        Get
            Return _instance.Value
        End Get
    End Property

    Function GetFormatType() As String
        Return ConfigurationManager.AppSettings("FormatDateString")
    End Function
    Function GetFormatMonth() As String
        Return ConfigurationManager.AppSettings("FormatMonthString")
    End Function
End Class
