Imports System.Configuration
Public NotInheritable Class Strings
    Private Shared ReadOnly _instance As New Lazy(Of Strings)(Function() New Strings(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance() As Strings
        Get
            Return _instance.Value
        End Get
    End Property

    Function GetDeletedString() As String
        Return " and DeleteFlag = N'Y' "
    End Function

    Function GetNotDeleteString() As String
        Return " and DeleteFlag= N'N' "
    End Function

    Public Function GetSuccessMessage() As String
        Return "Thực hiện thành công!"
    End Function
    Public Function GetErrMessage() As String
        Return "Thao tác thất bại"
    End Function

    Public Function LogErr(err As String)
        System.Console.WriteLine("[ERR]: " & err)
    End Function
    Public Function LogMess(mesa As String)
        System.Console.WriteLine("[mess]: " & mesa)
    End Function
End Class
