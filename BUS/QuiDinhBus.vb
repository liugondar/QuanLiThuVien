Imports DAO
Imports DTO
Imports Utility

Public Class QuiDinhBus
    Private _quiDinhDAO As QuiDinhDAO

    Public Sub New()
        _quiDinhDAO = New QuiDinhDAO()
    End Sub

    Public Function SelectAll(ByRef quiDinh As QuiDinh) As Result
        Dim result = _quiDinhDAO.SelectAll(quiDinh)
        Return result
    End Function

    Public Function LayTuoiToiDaVaToiThieu(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.LayTuoiToiDaVaToiThieu(quiDinh)
    End Function
    Public Function LayThoiHanToiDaTheDocGia(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.LayThoiHanToiDaTheDocGia(quiDinh)
    End Function

    Public Function LaySoNgayMuonSachToiDa(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.LaySoNgayMuonSachToiDa(quiDinh)
    End Function

    Public Function LaySoSachMuonToiDa(ByRef quiDinh As QuiDinh) As Result
        Return _quiDinhDAO.LaySoSachMuonToiDa(quiDinh)
    End Function
End Class
