Imports System.Drawing

Public Class BookInfoControl
#Region "-  Fields  -"
    Public Event UC_BookIDTextBox_TextChanged(sender As Object, e As EventArgs)
    Public Event UC_BookTitleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
    Public Event UC_TypeOfBookComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
    Public Event UC_AuthorComboBox_SelectedIndexChangeChanged(sender As Object, e As EventArgs)
    Public Event UC_SttTextBox_TextChanged(sender As Object, e As EventArgs)
    Public Event UC_Button_Click(sender As Object, e As EventArgs)
    Public isButtonClick As Boolean

    Public Function GetBookIdTextBox()
        Return BookIdTextBox
    End Function
    Public Function GetSTTTextBox()
        Return STTTextBox
    End Function
    Public Function GetTitleTextBox()
        Return BookTitleTextBox
    End Function

    Public Function GetTypeOfBookTextBox()
        Return TypeOfBookTextBox
    End Function
    Public Function GetAuthorTextBox()
        Return AuthorTextBox
    End Function

    Public Function GetButton()
        Return Button
    End Function
#End Region
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        isButtonClick = False
        ' Add any initialization after the InitializeComponent() call.
        Button.BackColor = ColorTranslator.FromHtml("#DC3545")
        Button.Text = "Xóa"
    End Sub

#Region "-  Events -"
    Public Sub BookIdTextBox_TextChanged(sender As Object, e As EventArgs) Handles BookIdTextBox.TextChanged
        RaiseEvent UC_BookIDTextBox_TextChanged(Me, e)
    End Sub

    Public Sub BookTitleTextBox_TextChanged(sender As Object, e As EventArgs) Handles BookTitleTextBox.TextChanged
        RaiseEvent UC_BookTitleComboBox_SelectedIndexChanged(Me, e)
    End Sub

    Public Sub TypeOfBookTExtBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeOfBookTextBox.TextChanged
        RaiseEvent UC_TypeOfBookComboBox_SelectedIndexChanged(Me, e)
    End Sub

    Public Sub AuthorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AuthorTextBox.TextChanged
        RaiseEvent UC_AuthorComboBox_SelectedIndexChangeChanged(Me, e)
    End Sub

    Private Sub STTTextBox_TextChanged(sender As Object, e As EventArgs) Handles STTTextBox.TextChanged
        RaiseEvent UC_SttTextBox_TextChanged(Me, e)
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button.Click
        RaiseEvent UC_Button_Click(Me, e)
    End Sub
#End Region

End Class

