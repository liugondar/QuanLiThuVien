Imports System.Drawing
Imports System.Windows.Forms

Public Class PlaceHolderTextBox
    Inherits TextBox

    Private _placeHolderText As String
    Public Sub New()
    End Sub

    Public Property IsPlaceHolder As Boolean = True

    Public Property PlaceHolderText As String
        Get
            Return _placeHolderText
        End Get
        Set(value As String)
            _placeHolderText = value
            SetPlaceHolder()
        End Set
    End Property

    Private Sub SetPlaceHolder()
        Me.Text = PlaceHolderText
        Me.ForeColor = Color.Gray
    End Sub


    Private Sub RemovePlaceHolder()
        If IsPlaceHolder Then
            Me.Clear()
            Me.ForeColor = System.Drawing.SystemColors.WindowText
        End If
    End Sub
    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        If PlaceHolderText.Equals(Me.Text) Then
            RemovePlaceHolder()
        End If
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        If String.IsNullOrWhiteSpace(Me.Text) Then
            SetPlaceHolder()
        End If
    End Sub
End Class

