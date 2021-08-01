Public Class Calculadora
    Dim resultado As Decimal

    Private Sub ButtonNumber_Click(sender As Object, e As EventArgs) Handles Button0.Click, Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        TextBox1.Text = TextBox1.Text & sender.ToString.ElementAt(sender.ToString.Length - 1)
    End Sub

    Private Sub ButtonOption_Click(sender As Object, e As EventArgs) Handles ButtonDiv.Click, ButtonMult.Click, ButtonSum.Click, ButtonRes.Click
        If TextBox1.Text.Length > 0 Then
            Select Case TextBox1.Text.Last()
                Case "+", "-", "/", "*"
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1, 1)
                    TextBox1.Text = TextBox1.Text & sender.ToString.ElementAt(sender.ToString.Length - 1)
                Case Else
                    TextBox1.Text = TextBox1.Text & sender.ToString.ElementAt(sender.ToString.Length - 1)
            End Select
        End If
    End Sub

    Private Sub resultado_Click(sender As Object, e As EventArgs) Handles ButtonResultado.Click


        Dim index = 0
        While TextBox1.Text.Length > 0


        End While
    End Sub

    Private Function calcular(cadena As String) As Integer
        If cadena.Length > 0 Then
            Return 0
        Else
            Dim index = 0
            While cadena.Length - 1 <> index



            End While
            Return 0
        End If
    End Function




End Class
