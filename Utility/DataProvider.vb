Imports System.Configuration
Imports System.Data.SqlClient

Public Class DataProvider
    Private connectionString As String
    Public Sub New()
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Function ExcuteNonquery(query As String) As Result
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
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False, ex.Message, ex.StackTrace)
                End Try
            End Using
        End Using

        Return New Result(True)
    End Function

    Public Function ExcuteQuery(query As String) As DataTable
        Dim Data As DataTable = New DataTable()

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(query, conn)
            adapter.Fill(Data)
            conn.Close()
        End Using
        Return Data
    End Function


End Class
