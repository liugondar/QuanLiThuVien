Imports DTO

Public Class TenNhaXuatBanComparer
    Implements IEqualityComparer(Of DauSachDTO)

    Public Function Equals(x As DauSachDTO, y As DauSachDTO) As Boolean Implements IEqualityComparer(Of DauSachDTO).Equals
        Return x.TenNhaXuatBan.Equals(y.TenNhaXuatBan)
    End Function

    Public Function GetHashCode(obj As DauSachDTO) As Integer Implements IEqualityComparer(Of DauSachDTO).GetHashCode
        Return obj.TenNhaXuatBan.GetHashCode()
    End Function
End Class
