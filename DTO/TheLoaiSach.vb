Public Class TheLoaiSach
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaTheLoaiSach") And
          row.Table.Columns.Contains("TenTheLoaiSach")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        Integer.TryParse(row("MaTheLoaiSAch").ToString(), MaTheLoaiSach)
        TenTheLoaiSach = row("TenTheLoaiSach").ToString()
    End Sub

    Public Sub New(maTheLoaiSach As Integer, tenTheLoaiSach As String)
        Me.MaTheLoaiSach = maTheLoaiSach
        Me.TenTheLoaiSach = tenTheLoaiSach
    End Sub

    Public Property MaTheLoaiSach() As Integer
    Public Property TenTheLoaiSach() As String

End Class
