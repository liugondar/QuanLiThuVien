Public Class LoaiDocGia
    Public Property LoaiDocGiaId As Integer
    Public Property TenLoaiDocGia As String
    Public Sub New()
    End Sub

    Public Sub New(LoaiDocGiaId As Integer, TenLoaiDocGia As String)
        Me.LoaiDocGiaId = LoaiDocGiaId
        Me.TenLoaiDocGia = TenLoaiDocGia
    End Sub
End Class
