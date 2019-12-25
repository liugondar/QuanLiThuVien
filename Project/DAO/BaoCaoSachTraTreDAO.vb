﻿Imports DTO
Imports Utility

Public Class BaoCaoSachTraTreDAO

#Region "-   Fields   -"
    Private _dataProvider As DataProvider
#End Region

#Region "-   Constructor   -"
    Public Sub New()
        _dataProvider = New DataProvider()
    End Sub

#End Region

#Region "-  Insert   -"
    Public Function InsertOne(BaoCaoSachTraTre As BaoCaoSachTraTre) As Result
        Dim query = String.Format("EXECUTE USP_NhapBaoCaoTraSachTre @ThoiGian='{0}'", BaoCaoSachTraTre.ThoiGian.ToString(DateHelper.Instance.GetFormatType()))
        Dim result = _dataProvider.ExecuteNonquery(query)
        Return result
    End Function
#End Region

#Region "-   Retrieve data    -"
    Public Function GetTheLastID(ByRef maBaoCaoSachTraTre As String) As Result
        Dim query = String.Format("select top 1 [MaBaoCaoSachTraTre]
from BaoCaoSachTraTre
ORDER by [MaBaoCaoSachTraTre] DESC")
        Dim dataTable = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(query, dataTable)

        For Each row In dataTable.Rows
            maBaoCaoSachTraTre = row("MaBaoCaoSachTraTre").ToString()
        Next
        Return result
    End Function

    Public Function GetTinhHinhTraTreByMonth(month As Date, ByRef baocao As List(Of BaoCaoTraTreByMonth)) As Result
        Dim qr = String.Format("EXECUTE dbo.GetThongMuonTre '{0}'", month.ToString(DateHelper.Instance.GetFormatType()))

        Dim tb = New DataTable()
        Dim result = _dataProvider.ExecuteQuery(qr, tb)
        For Each row In tb.Rows
            Dim temp = New BaoCaoTraTreByMonth(row)
            baocao.Add(temp)
        Next
        Return result
    End Function
#End Region
End Class
