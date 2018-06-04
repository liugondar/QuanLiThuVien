Imports DTO

Public Class SachComparer
    Implements IEqualityComparer(Of Sach)

    Public Function Equals(x As Sach, y As Sach) As Boolean Implements IEqualityComparer(Of Sach).Equals
        Return x.MaSach = y.MaSach
    End Function

    Public Function GetHashCode(obj As Sach) As Integer Implements IEqualityComparer(Of Sach).GetHashCode
        Return obj.MaSach.GetHashCode()
    End Function
End Class
