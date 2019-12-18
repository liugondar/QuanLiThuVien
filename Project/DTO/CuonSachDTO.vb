Public Class CuonSachDTO
    Private strMaCuonSach As String
    Private strTinhTrang As String
    Private strDauSach As String
    Private iSoKe As Integer

    Public Sub New()
    End Sub

    Public Sub New(strMaCuonSach As String, strTinhTrang As String, strDauSach As String, iSoKe As Integer)
        Me.strMaCuonSach = strMaCuonSach
        Me.strTinhTrang = strTinhTrang
        Me.strDauSach = strDauSach
        Me.iSoKe = iSoKe
    End Sub

    Public Property MaCuonSach As String
        Get
            Return strMaCuonSach
        End Get
        Set(value As String)
            strMaCuonSach = value
        End Set
    End Property

    Public Property TinhTrang As String
        Get
            Return strTinhTrang
        End Get
        Set(value As String)
            strTinhTrang = value
        End Set
    End Property

    Public Property DauSach As String
        Get
            Return strDauSach
        End Get
        Set(value As String)
            strDauSach = value
        End Set
    End Property

    Public Property SoKe As Integer
        Get
            Return iSoKe
        End Get
        Set(value As Integer)
            iSoKe = value
        End Set
    End Property
End Class
