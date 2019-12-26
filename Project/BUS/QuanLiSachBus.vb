Imports DAO
Imports DTO
Imports Utility
Public Class QuanLiSachBus

    Private Shared oInstance As QuanLiSachBus = New QuanLiSachBus

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance As QuanLiSachBus
        Get
            Return oInstance
        End Get
    End Property

    Public Function SearchSachByString(query As String, ByRef dausach As List(Of DauSachDTO)) As Result
        Return DAO.QuanLiSachDAO.Instance.SearchSachByString(query, dausach)
    End Function
End Class