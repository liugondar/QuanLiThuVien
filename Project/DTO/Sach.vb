Imports System.Windows.Forms
Imports Utility

Public Class Sach
    Public Sub New()
    End Sub

    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaSach") And
            row.Table.Columns.Contains("MaDauSach") And
            row.Table.Columns.Contains("TinhTrang")
        If doesRowContainsCorrectFields = False Then
            Return
        End If
        Integer.TryParse(row("MaSach").ToString(), MaSach)
        Integer.TryParse(row("MaDauSach").ToString(), MaSach)
        Integer.TryParse(row("TinhTrang").ToString(), TinhTrang)
    End Sub

    Public Sub New(maSach As String, maDauSach As String, tinhTrang As Integer)
        Me.MaSach = maSach
        Me.MaDauSach = maDauSach
        Me.TinhTrang = tinhTrang
    End Sub
    Public Sub New(maSach As String, maDauSach As String)
        Me.MaSach = maSach
        Me.MaDauSach = maDauSach
        Me.TinhTrang = 0
    End Sub

    Public Property MaSach() As String
    Public Property MaDauSach() As String
    Public Property TinhTrang() As Integer

End Class
