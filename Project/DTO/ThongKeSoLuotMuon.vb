Public Class ThongKeSoLuotMuon
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields As Boolean = row.Table.Columns.Contains("SoLuotMuon")
        If doesRowContainsCorrectFields = False Then
            SoLuotMuon = 0
            Return
        End If
        SoLuotMuon = Integer.Parse(row("SoLuotMuon"))
    End Sub

    Public Sub New(month As Date, soLuotMuon As Integer)
        Me.Month = month
        Me.SoLuotMuon = soLuotMuon
    End Sub
    Public Sub New(month As Date)
        Me.Month = month
    End Sub

    Public Property Month() As Date
    Public Property SoLuotMuon() As Integer


End Class
