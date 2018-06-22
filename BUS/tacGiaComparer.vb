Imports DTO

Public Class TacGiaComparer
    Implements IEqualityComparer(Of TacGia)

    Public Function Equals(x As TacGia, y As TacGia) As Boolean Implements IEqualityComparer(Of TacGia).Equals
        Return x.MaTacGia = y.MaTacGia
    End Function

    Public Function GetHashCode(obj As TacGia) As Integer Implements IEqualityComparer(Of TacGia).GetHashCode
        Return obj.MaTacGia.GetHashCode()
    End Function

End Class
