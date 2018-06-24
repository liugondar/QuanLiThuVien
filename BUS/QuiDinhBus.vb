Imports DAO
Imports DTO
Imports Utility

Public Class QuiDinhBus
#Region "-   Fields   -"
    Private _quiDinhDAO As QuiDinhDAO
#End Region

#Region "-   Constructor   -"

    Public Sub New()
        _quiDinhDAO = New QuiDinhDAO()
    End Sub

#End Region

#Region "-   Retrieve data  -"

    Public Function SelectAll(ByRef quiDinh As QuiDinh) As Result
        Dim result = _quiDinhDAO.SelectAll(quiDinh)
        Return result
    End Function

    Public Function GetTuoiToiDaVaToiThieu(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.GetTuoiToiDaVaToiThieu(quiDinh)
    End Function
    Public Function GetThoiHanToiDaTheDocGia(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.GetThoiHanToiDaTheDocGia(quiDinh)
    End Function

    Public Function GetSoNgayMuonSachToiDa(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.GetSoNgayMuonSachToiDa(quiDinh)
    End Function

    Public Function GetSoSachMuonToiDa(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.GetSoSachMuonToiDa(quiDinh)
    End Function

#End Region

End Class
