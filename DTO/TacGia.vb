Public Class TacGia
    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaTacGia") And
           row.Table.Columns.Contains("TenTacGia")
        If doesRowContainsCorrectFields = False Then
            Return
        End If

        Integer.TryParse(row("MaTacGia").ToString(), MaTacGia)
        TenTacGia = row("TenTacGia").ToString()
    End Sub

    Public Sub New(maTacGia As Integer, tenTacGia As String)
        Me.MaTacGia = maTacGia
        Me.TenTacGia = tenTacGia
    End Sub

    Public Property MaTacGia() As Integer
    Public Property TenTacGia() As String

    Public Function Validate() As Boolean
        If String.IsNullOrWhiteSpace(TenTacGia) Then Return False
        Return True
    End Function
End Class
