Imports DTO
Public Class SachIdAndNameComparer
    Implements IEqualityComparer(Of DauSachDTO)

    Public Function Equals(x As DauSachDTO, y As DauSachDTO) As Boolean Implements IEqualityComparer(Of DauSachDTO).Equals
        Return x.MaDauSach.Equals(y.MaDauSach) And x.TenSach.Equals(y.TenSach)
    End Function

    Public Function GetHashCode(obj As DauSachDTO) As Integer Implements IEqualityComparer(Of DauSachDTO).GetHashCode
        Return obj.MaDauSach.GetHashCode()
    End Function
End Class
