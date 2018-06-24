Imports DTO
Imports Utility


Public Class QuiDinhDAO

#Region "-  Fields   -"

    Private _dataProvider As DataProvider

#End Region

#Region "-   Constructors   -"

    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Retrieve data    -"
    Public Function SelectAll(ByRef quiDinh As QuiDinh) As Result
        Dim query = String.Empty
        query &= "Select * from QuiDinh"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            quiDinh = New QuiDinh(row)
        Next
        Return result
    End Function

    Public Function GetTuoiToiDaVaToiThieu(ByRef quiDinh As QuiDinh) As Result
        Dim query = String.Empty
        query &= "Select [TuoiToiDa],[TuoiToiThieu] from QuiDinh"
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Integer.TryParse(row("TuoiToiDa"), quiDinh.TuoiToiDa)
            Integer.TryParse(row("TuoiToiThieu"), quiDinh.TuoiToiThieu)
        Next
        Return result
    End Function

    Public Function GetThoiHanToiDaTheDocGia(ByRef quiDinh As QuiDinh) As Result
        Dim query = String.Empty
        Dim dataTable = New DataTable()
        query &= "Select [ThoiHanToiDaTheDocGia] from QuiDinh"
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Integer.TryParse(row("ThoiHanToiDaTheDocGia"), quiDinh.ThoiHanToiDaTheDocGia)
        Next
        Return result
    End Function

    Public Function GetSoNgayMuonSachToiDa(ByRef quiDinh As QuiDinh) As Result
        Dim query = String.Empty
        Dim dataTable = New DataTable()
        query &= "Select [SoNgayMuonToiDa] from QuiDinh"
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Integer.TryParse(row("SoNgayMuonToiDa"), quiDinh.SoNgayMuonSachToiDa)
        Next
        Return result
    End Function

    Public Function GetSoSachMuonToiDa(ByRef quiDinh As QuiDinh) As Result
        Dim query = String.Empty
        Dim dataTable = New DataTable()
        query &= "Select [SoSachMuonToiDa] from QuiDinh"
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            Integer.TryParse(row("SoSachMuonToiDa"), quiDinh.SoSachMuonToiDa)
        Next
        Return result
    End Function
#End Region

End Class
