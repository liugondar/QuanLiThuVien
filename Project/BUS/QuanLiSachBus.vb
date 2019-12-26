Imports DAO
Imports DTO
Imports Utility
Imports System.Linq
Public Class QuanLiSachBus

    Private Shared oInstance As QuanLiSachBus = New QuanLiSachBus

    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance As QuanLiSachBus
        Get
            Return oInstance
        End Get
    End Property

    Public Function SearchSachByString(query As String, ByRef listDauSach As List(Of DauSachDTO)) As Result
        Dim rs = DAO.QuanLiSachDAO.Instance.SearchSachByString(query, listDauSach)
        Dim comparer = New SachIdAndNameComparer()
        listDauSach = listDauSach.Distinct(comparer).ToList()


        Return rs
    End Function
End Class