Public Class CuonSachDTO
    Private strMaCuonSach As String
    Private strDauSach As String

    Public Sub New()
    End Sub

    Public Sub New(strMaCuonSach As String, strDauSach As String)
        Me.strMaCuonSach = strMaCuonSach

        Me.strDauSach = strDauSach

    End Sub

    Public Property MaCuonSach As String
        Get
            Return strMaCuonSach
        End Get
        Set(value As String)
            strMaCuonSach = value
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


End Class
