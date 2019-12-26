Imports DAO
Imports Utility
Imports DTO
Public Class ThongKeBus
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance As ThongKeBus
        Get
            Static INST As ThongKeBus = New ThongKeBus
            Return INST
        End Get
    End Property

    Public Function CountBorowTimesByMonths(ByRef listThongKeSlMuon As List(Of ThongKeSoLuotMuon)) As Result
        For Each thongke In listThongKeSlMuon
            Dim rs = ThongKeDAO.Instance.CountBorrowsByMonth(thongke)
            If Not rs.FlagResult Then
                Return rs
            End If
        Next

        Return New Result()
    End Function
End Class