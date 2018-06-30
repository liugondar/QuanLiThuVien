Public Class BaoCaoTinhHinhMuonSachTheoTheLoai

#Region "-   Property   -"
    Public Property MaBaoCaoTinhHinhMuonSachTheoTheLoai() As String
    Public Property ThoiGian() As DateTime
    Public Property TongSoLuotMuon() As Integer
#End Region

#Region "-   Constructor   -"
    Public Sub New()
    End Sub

    Public Sub New(maBaoCaoTinhHinhMuonSachTheoTheLoai As String, thoiGian As Date, tongSoLuotMuon As Integer)
        Me.MaBaoCaoTinhHinhMuonSachTheoTheLoai = maBaoCaoTinhHinhMuonSachTheoTheLoai
        Me.ThoiGian = thoiGian
        Me.TongSoLuotMuon = tongSoLuotMuon
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaBaoCaoTinhHinhMuonSachTheoTheLoai") And
            row.Table.Columns.Contains("ThoiGian") And
        row.Table.Columns.Contains("TongSoLuotMuon")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        MaBaoCaoTinhHinhMuonSachTheoTheLoai = row("MaBaoCaoTinhHinhMuonSachTheoTheLoai").ToString()
        DateTime.TryParse(row("ThoiGian").ToString(), ThoiGian)
        Integer.TryParse(row("TongSoLuotMuon").ToString(), TongSoLuotMuon)
    End Sub

#End Region

End Class
