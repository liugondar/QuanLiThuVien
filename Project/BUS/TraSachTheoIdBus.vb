Imports DAO
Imports DTO
Imports Utility
Public Class TraSachTheoIdBus
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance As TraSachTheoIdBus
        Get
            Static INST As TraSachTheoIdBus = New TraSachTheoIdBus
            Return INST
        End Get
    End Property

    Function GetInfoBookLentByReaderId(readerId As String, ByRef customBook As List(Of CustomBookInfoDisplay)) As Result
        Return TraSachTheoIdDAO.Instance.GetInfoBookLentByReaderId(readerId, customBook)
    End Function
End Class