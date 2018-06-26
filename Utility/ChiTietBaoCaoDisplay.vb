Public Class ChiTietBaoCaoDisplay
    Public Property TenTheLoaiSach As String
    Public Property SoLuongMuon As Integer
    Public Property TiLe As Double
    Public Sub New()
    End Sub

    Public Sub New(tenTheLoaiSach As String, soLuongMuon As Integer, tiLe As Double)
        Me.TenTheLoaiSach = tenTheLoaiSach
        Me.SoLuongMuon = soLuongMuon
        Me.TiLe = tiLe
    End Sub
End Class
