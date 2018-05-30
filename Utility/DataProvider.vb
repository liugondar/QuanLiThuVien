Imports System.Configuration
Imports System.Data.SqlClient

Public Class DataProvider
    Private connectionString As String
    Public Sub New()
        connectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiThuVien;Integrated Security=True"
    End Sub
    Public Function ExcuteNonquery(query As String) As Result
        If String.IsNullOrWhiteSpace(query) Then
            Return New Result(False, "Dữ liệu nhập vào không hợp lệ", "")
        End If

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    Return New Result(False, ex.Message, ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True)
    End Function

    Public Function ExcuteQuery(query As String, ByRef dataTable As DataTable) As Result
        If String.IsNullOrWhiteSpace(query) Then
            Return New Result(False, "Không thể lấy dữ liệu", "")
        End If
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, conn)
                adapter.Fill(dataTable)
            Catch ex As Exception
                conn.Close()
                Return New Result(False, ex.Message, ex.StackTrace)
            End Try
        End Using

        If dataTable.Rows.Count < 0 Then
            Return New Result(False, "Không thể lấy dữ liệu", "")
        End If
        Return New Result()
    End Function


End Class
