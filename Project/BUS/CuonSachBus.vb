Imports DAO
Imports DTO
Imports Utility

Public Class CuonSachBus
    Private cs As CuonSachDAL

    Public Sub New()
        cs = New CuonSachDAL()
    End Sub
    Public Sub New(connectionString As String)
        cs = New CuonSachDAL(connectionString)
    End Sub

    Public Function buildMaCuonSach(ByRef value As String) As Result
        Return cs.buildMaCuonSach(value)
    End Function

    Public Function selectALL(ByRef list As List(Of CuonSachDTO)) As Result
        Return cs.selectALL(list)
    End Function

    Public Function SelectAllByMaCuonSach(listSach As List(Of Sach), maCuonSach As String) As Result
        Dim result = cs.SelectAllByMaCuonSach(listSach, maCuonSach)
        Return result
    End Function

    Public Function getByMaCuonSach(macuonsach As String, ByRef value As CuonSachDTO) As Result
        Return cs.getByMaCuonSach(macuonsach, value)
    End Function

    Public Function insert(ctpm As CuonSachDTO) As Result
        Return cs.insert(ctpm)
    End Function


End Class

