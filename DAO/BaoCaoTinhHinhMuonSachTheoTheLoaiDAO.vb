Imports DTO
Imports Utility

Public Class BaoCaoTinhHinhMuonSachTheoTheLoaiDAO

#Region "-  Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-  Fields   -"
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert   -"
    Public Function InsertOne(baoCaoTinhHinhMuonSachTheoTheLoai As BaoCaoTinhHinhMuonSachTheoTheLoai) As Result

        Dim query = String.Format("EXECUTE USP_NhapBaoCaoTinhHinhMuonSachTheoTheLoai @thoiGian='{0}'",
baoCaoTinhHinhMuonSachTheoTheLoai.ThoiGian)

        Return _dataProvider.ExcuteNonquery(query)
    End Function

#End Region

#Region "-   Retrieve data    -"
    Public Function GetTheLastID(ByRef maBaoCaoTinhHinhMuonSachTheoTheLoai) As Result
        Dim query = String.Format("SELECT top 1 [MaBaoCaoTinhHinhMuonSachTheoTheLoai] from BaoCaoTinhHinhMuonSachTheoTheLoai ORDER by [MaBaoCaoTinhHinhMuonSachTheoTheLoai] desc")

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExcuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maBaoCaoTinhHinhMuonSachTheoTheLoai = row("MaBaoCaoTinhHinhMuonSachTheoTheLoai")
        Next
        Return result
    End Function
#End Region

End Class
