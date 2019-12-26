Imports Utility
Imports DTO
Public Class ThongKeDAO
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property Instance As ThongKeDAO
        Get
            Static INST As ThongKeDAO = New ThongKeDAO
            Return INST
        End Get
    End Property

    Function CountBorrowsByMonth(ByRef thongKe As ThongKeSoLuotMuon) As Result
        Dim qr As String = String.Format("EXECUTE dbo.USP_CountSlMuon '{0}'", thongKe.Month.ToString(DateHelper.Instance.GetFormatType()))
        Dim tb = New DataTable()
        Dim rs As Result = DataProvider.Instance.ExecuteQuery(qr, tb)
        If Not rs.FlagResult Then
            Return rs
        End If

        For Each row In tb.Rows
            thongKe.SoLuotMuon = row("SoLuotMuon")
        Next
        Return New Result()
    End Function
End Class