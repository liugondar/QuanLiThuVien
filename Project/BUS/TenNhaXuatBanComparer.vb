Imports DTO

Public Class TenNhaXuatBanComparer
    Implements IEqualityComparer(Of Sach)

    Public Function Equals(x As Sach, y As Sach) As Boolean Implements IEqualityComparer(Of Sach).Equals
        Return x.TenNhaXuatBan.Equals(y.TenNhaXuatBan)
    End Function

    Public Function GetHashCode(obj As Sach) As Integer Implements IEqualityComparer(Of Sach).GetHashCode
        Return obj.TenNhaXuatBan.GetHashCode()
    End Function
End Class
