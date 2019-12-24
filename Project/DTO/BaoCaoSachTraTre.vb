Public Class BaoCaoSachTraTre

#Region "-   Properties  -"
    Public Property MaBaoCaoSachTraTre() As String
    Public Property ThoiGian() As DateTime

#End Region

#Region "-   Constructor  -"

    Public Sub New(maBaoCaoSachTraTre As String, thoiGian As Date)
        Me.MaBaoCaoSachTraTre = maBaoCaoSachTraTre
        Me.ThoiGian = thoiGian
    End Sub

    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("MaBaoCaoSachTraTre") And
         row.Table.Columns.Contains("ThoiGian")
        If doesRowContainsCorrectFields = False Then
            MaBaoCaoSachTraTre = 0
            ThoiGian = DateTime.Now
            Return
        End If
        MaBaoCaoSachTraTre = row("MaBaoCaoSachTraTre")
        DateTime.TryParse(row("ThoiGian").ToString(), ThoiGian)
    End Sub
    'note
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("MaBaoCaoSachTraTre") And
         row.Table.Columns.Contains("ThoiGian")
        If doesRowContainsCorrectFields = False Then
            MaBaoCaoSachTraTre = 0
            ThoiGian = DateTime.Now
            Return
        End If
        MaBaoCaoSachTraTre = row("MaBaoCaoSachTraTre")
        DateTime.TryParse(row("ThoiGian").ToString(), ThoiGian)
    End Sub
#End Region
End Class
