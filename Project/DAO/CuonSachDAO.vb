Imports System.Configuration
Imports System.Data.SqlClient
Imports DTO
Imports Utility

Public Class CuonSachDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub

    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function buildMaCuonSach(ByRef value As String) As Result
        value = String.Empty
        value = "CS"

        Dim query As String = String.Empty
        query &= "SELECT TOP 1 [MaCuonSach] "
        query &= "FROM [CuonSach] "
        query &= "ORDER BY [MaCuonSach] DESC "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    Dim msOnDB As String
                    msOnDB = Nothing
                    If reader.HasRows = True Then
                        While reader.Read()
                            msOnDB = reader("MaCuonSach")
                        End While
                    Else
                        value = value + "000001"
                        Return New Result(True)
                    End If
                    If (msOnDB <> Nothing And msOnDB.Length >= 8) Then
                        Dim v = msOnDB.Substring(2)
                        Dim convertDecimal = Convert.ToDecimal(v)
                        convertDecimal = convertDecimal + 1
                        Dim tmp = convertDecimal.ToString()
                        tmp = tmp.PadLeft(msOnDB.Length - 2, "0")
                        value = value + tmp
                        System.Console.WriteLine(value)
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function selectALL(ByRef list As List(Of CuonSachDTO)) As Result

        Dim query As String = String.Empty
        query &= "SELECT *"
        query &= "FROM [CuonSach]"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        list.Clear()
                        While reader.Read()
                            list.Add(New CuonSachDTO(reader("MaCuonSach"), reader("TinhTrang"), reader("DauSach"), reader("SoKe")))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function getByMaCuonSach(macuonsach As String, ByRef value As CuonSachDTO) As Result

        Dim query As String = String.Empty
        query &= "SELECT *"
        query &= "FROM [CuonSach] "
        query &= "WHERE [MaCuonSach] = @MaCuonSach"


        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaCuonSach", macuonsach)
                End With
                Try
                    conn.Open()
                    Dim reader As SqlDataReader
                    reader = comm.ExecuteReader()
                    If reader.HasRows = True Then
                        While reader.Read()
                            value = New CuonSachDTO(reader("MaCuonSach"), reader("TinhTrang"), reader("DauSach"), reader("SoKe"))
                        End While
                    End If

                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function insert(value As CuonSachDTO) As Result

        Dim query As String = String.Empty
        query &= " INSERT INTO [CuonSach]"
        query &= " VALUES (@MaCuonSach, @TinhTrang, @DauSach, @SoKe)"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaCuonSach", value.MaCuonSach)
                    .Parameters.AddWithValue("@TinhTrang", value.TinhTrang)
                    .Parameters.AddWithValue("@DauSach", value.DauSach)
                    .Parameters.AddWithValue("@SoKe", value.SoKe)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

    Public Function updateTinhTrang(macuonsach As String, value As String) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [CuonSach] SET [TinhTrang] = @value WHERE [MaCuonSach] = @MaCuonSach"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@MaCuonSach", macuonsach)
                    .Parameters.AddWithValue("@value", value)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    System.Console.WriteLine(ex.StackTrace)
                    Return New Result(False)
                End Try
            End Using
        End Using
        Return New Result(True)
    End Function

End Class
