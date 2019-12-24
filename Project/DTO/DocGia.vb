sImports System.Text.RegularExpressions
Imports Utility

Public Class DocGia
    Public Property MaTheDocGia As Integer
    Public Property TenDocGia As String
    Public Property Email As String
    Public Property DiaChi As String
    Public Property NgaySinh As DateTime
    Public Property NgayTao As DateTime
    Public Property NgayHetHan As DateTime
    Public Property MaLoaiDocGia As Integer

    Public Sub New()
    End Sub
    Public Sub New(row As DataRow)
        Dim doesRowContainsCorrectFields = row.Table.Columns.Contains("MaTheDocGia") And
            row.Table.Columns.Contains("TenDocGia") And
            row.Table.Columns.Contains("Email") And
            row.Table.Columns.Contains("DiaChi") And
            row.Table.Columns.Contains("NgaySinh") And
            row.Table.Columns.Contains("NgayTao") And
            row.Table.Columns.Contains("NgayHetHan") And
            row.Table.Columns.Contains("MaLoaiDocGia")
        If doesRowContainsCorrectFields = False Then
            MaTheDocGia = 0
            TenDocGia = ""
            Email = ""
            DiaChi = ""
            NgaySinh = DateTime.Now
            NgayTao = DateTime.Now
            NgayHetHan = DateTime.Now
            MaLoaiDocGia = 0
            Return
        End If
        MaTheDocGia = Integer.Parse(row("MaTheDocGia"))
        TenDocGia = (row("TenDocGia")).ToString()
        Email = (row("Email")).ToString()
        DiaChi = (row("DiaChi")).ToString()
        NgaySinh = (DateTime).Parse(row("NgaySinh"))
        NgayTao = DateTime.Parse(row("NgayTao"))
        NgayHetHan = DateTime.Parse(row("NgayHetHan"))
        MaLoaiDocGia = Integer.Parse(row("MaLoaiDocGia"))
    End Sub

    Public Sub New(MaTheDocGia As Integer, TenDocGia As String, Email As String, DiaChi As String, NgaySinh As Date, NgayTao As Date, NgayHetHan As Date, LoaiDocGiaId As Integer)
        Me.MaTheDocGia = MaTheDocGia
        Me.TenDocGia = TenDocGia
        Me.Email = Email
        Me.DiaChi = DiaChi
        Me.NgaySinh = NgaySinh
        Me.NgayTao = NgayTao
        Me.MaLoaiDocGia = LoaiDocGiaId
        Me.NgayHetHan = NgayHetHan
    End Sub

    public Function Validate() As Result
        Dim validateUserNameResult = ValidateUserName(TenDocGia)
        Dim validateEmailResult = ValidateEmail(Email)
        If validateUserNameResult.FlagResult = False Then Return validateUserNameResult
        If validateEmailResult.FlagResult = False Then Return validateEmailResult

        Return New Result(True)
    End Function

    Private Function ValidateEmail(Email As String) As Result
        If String.IsNullOrWhiteSpace(Email) Then Return New Result(False, "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        If (Regex.IsMatch(Email, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") = False) Then Return New Result(False, "Email không đúng định dạng,ví dụ: 123@gmail.com", "")
        Return New Result()
    End Function

    Private Function ValidateUserName(tenDocGia As String) As Result
        If String.IsNullOrWhiteSpace(tenDocGia) Then
            Return New Result(False, "Tên độc giả không đúng định dạng", "")
        End If
        Return New Result()
    End Function
End Class
