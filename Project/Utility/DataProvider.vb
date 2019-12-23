Imports System.Configuration
Imports System.Data.SqlClient

Public Class DataProvider
    Private Shared _instance As DataProvider
    Public Shared Property Instance As DataProvider
        Get

            If _instance Is Nothing Then
                _instance = New DataProvider()
            End If

            Return DataProvider._instance
        End Get
        Private Set(ByVal value As DataProvider)
            DataProvider._instance = value
        End Set
    End Property
    Private connectionString As String
    Public Sub New()
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Function ExecuteNonquery(query As String) As Result
        System.Diagnostics.Debug.WriteLine(query, "nonquery ")
        System.Diagnostics.Debug.WriteLine("-----------")
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

    Public Function ExecuteQuery(query As String, ByRef dataTable As DataTable) As Result
        System.Diagnostics.Debug.WriteLine(query, "query")
        System.Diagnostics.Debug.WriteLine("-----------")

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
