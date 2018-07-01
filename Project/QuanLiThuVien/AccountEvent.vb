Imports DTO

Public Class AccountEvent
    Inherits EventArgs

    Private _acc As Account

    Friend Sub New(ByVal acc As Account)
        Me._acc = acc
    End Sub

    Friend Property Acc As Account
        Get
            Return _acc
        End Get
        Set(ByVal value As Account)
            _acc = value
        End Set
    End Property
End Class
