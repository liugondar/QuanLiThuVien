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
    Public Function GetTitleComboBox()
        Return BookTitleComboBox
    End Function

    Public Function GetTypeOfBookComboBox()
        Return TypeOfBookComboBox
    End Function
    Public Function GetAuthorComboBox()
        Return AuthorComboBox
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
        RaiseEvent UC_BookIDTextBox_TextChanged(sender, e)
    End Sub

    Public Sub BookTitleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BookTitleComboBox.SelectedIndexChanged
        RaiseEvent UC_BookTitleComboBox_SelectedIndexChanged(sender, e)
    End Sub

    Public Sub TypeOfBookComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeOfBookComboBox.SelectedIndexChanged
        RaiseEvent UC_TypeOfBookComboBox_SelectedIndexChanged(sender, e)
    End Sub

    Public Sub AuthorComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AuthorComboBox.SelectedIndexChanged
        RaiseEvent UC_AuthorComboBox_SelectedIndexChangeChanged(sender, e)
    End Sub

    Private Sub STTTextBox_TextChanged(sender As Object, e As EventArgs) Handles STTTextBox.TextChanged
        RaiseEvent UC_SttTextBox_TextChanged(sender, e)
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button.Click
        RaiseEvent UC_Button_Click(Me, e)
    End Sub
#End Region

End Class

