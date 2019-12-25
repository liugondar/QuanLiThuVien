Imports DTO
Imports Utility

Public Class BaoCaoTinhHinhMuonSachTheoTheLoaiDAO

#Region "-  Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-  Constructor   -"
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-   Insert   -"
    Public Function InsertOne(baoCaoTinhHinhMuonSachTheoTheLoai As BaoCaoTinhHinhMuonSachTheoTheLoai) As Result

        Dim formatDate = DateHelper.Instance.GetFormatType()
        Dim query = String.Format("EXECUTE USP_NhapBaoCaoTinhHinhMuonSachTheoTheLoai @ThoiGian='{0}'",
baoCaoTinhHinhMuonSachTheoTheLoai.ThoiGian.ToString(formatDate))

        Return _dataProvider.ExecuteNonquery(query)
    End Function

#End Region

#Region "-   Update    -"
    Public Function UpdateTongSoLuotMuon(maBaoCao As String, tongSoLuotMuon As Integer) As Result
        Dim query = String.Format("
EXECUTE USP_UpdateSoLuongSachMuonTheoTheLoai
 @MaBaoCaoTinhHinhMuonSachTheoTheLoai={0},
 @TongSoLuotMuon={1}",
maBaoCao, tongSoLuotMuon)

        Return _dataProvider.ExecuteNonquery(query)
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function GetTheLastID(ByRef maBaoCaoTinhHinhMuonSachTheoTheLoai) As Result
        Dim query = String.Format("SELECT top 1 [MaBaoCaoTinhHinhMuonSachTheoTheLoai] from BaoCaoTinhHinhMuonSachTheoTheLoai ORDER by [MaBaoCaoTinhHinhMuonSachTheoTheLoai] desc")

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maBaoCaoTinhHinhMuonSachTheoTheLoai = row("MaBaoCaoTinhHinhMuonSachTheoTheLoai")
        Next
        Return result
    End Function
     Public Function GetTheLastName(ByRef maBaoCaoTinhHinhMuonSachTheoTheLoai) As Result
        Dim query = String.Format("SELECT top 1 [MaBaoCaoTinhHinhMuonSachTheoTheLoai] from BaoCaoTinhHinhMuonSachTheoTheLoai ORDER by [MaBaoCaoTinhHinhMuonSachTheoTheLoai] desc")

        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)
        For Each row In dataTable.Rows
            maBaoCaoTinhHinhMuonSachTheoTheLoai = row("MaBaoCaoTinhHinhMuonSachTheoTheLoai")
        Next
        Return result
    End Function

#End Region

End Class
