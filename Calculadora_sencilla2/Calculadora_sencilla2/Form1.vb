Public Class Calculadora

    'interfaz'

    Private Sub ButtonNumber_Click(sender As Object, e As EventArgs) Handles Button0.Click, Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        Dim numero = sender.ToString.ElementAt(sender.ToString.Length - 1)
        TextBox1.Text = TextBox1.Text & numero
    End Sub

    Private Sub ButtonOption_Click(sender As Object, e As EventArgs) Handles ButtonDiv.Click, ButtonMult.Click, ButtonSum.Click, ButtonRes.Click
        Dim operador = sender.ToString.ElementAt(sender.ToString.Length - 1)
        If TextBox1.Text.Length > 0 Then
            Select Case TextBox1.Text.Last()
                Case "+", "-", "/", "*"
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1, 1)
                    TextBox1.Text = TextBox1.Text & operador
                Case Else
                    TextBox1.Text = TextBox1.Text & operador
            End Select
        End If
    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        TextBox1.Text = ""
    End Sub

    Public Sub resultado_Click(sender As Object, e As EventArgs) Handles ButtonResultado.Click
        TextBox1.Text = calcular(TextBox1.Text)
    End Sub

    'logica'

    Private Function calcular(cadena As String) As String
        If cadena.Length > 2 And Char.IsDigit(cadena.Last) Then
            Return calcular(cadena, 0)
        Else
            Return cadena
        End If
    End Function

    Private Function calcular(cadena As String, indice As Integer) As String
        Dim cadenaIzq As String
        Dim cadenaDer As String
        If cadena.Length = indice Then
            Return cadena
        ElseIf Char.IsDigit(cadena.Chars(indice)) Then
            Return calcular(cadena, indice + 1)
        Else '. si no es numerico .'
            cadenaIzq = cadena.Substring(0, indice)
            cadenaDer = cadena.Substring(indice + 1)
            If cadena.Chars(indice) = "+" Then
                Return suma_string(calcular(cadenaIzq, 0), calcular(cadenaDer, 0))
            ElseIf cadena.Chars(indice) = "-" Then
                Return resta_string(calcular(cadenaIzq, 0), calcular(cadenaDer, 0))
            ElseIf cadena.Chars(indice) = "*" Then
                Return multiplicacion_string(calcular(cadenaIzq, 0), calcular(cadenaDer, 0))
            ElseIf cadena.Chars(indice) = "/" Then
                Return divicion_string(calcular(cadenaIzq, 0), calcular(cadenaDer, 0))
            End If
        End If
        Return 0
    End Function

    Private Function suma_string(a As String, b As String) As String
        Return (Integer.Parse(a) + Integer.Parse(b)).ToString
    End Function
    Private Function resta_string(a As String, b As String) As String
        Return (Integer.Parse(a) - Integer.Parse(b)).ToString
    End Function
    Private Function multiplicacion_string(a As String, b As String) As String
        Return (Integer.Parse(a) * Integer.Parse(b)).ToString
    End Function
    Private Function divicion_string(nominador As String, denominador As String) As String
        Dim aux_denominador = Integer.Parse(denominador)
        If Not aux_denominador = 0 Then
            Return (Integer.Parse(nominador) / aux_denominador).ToString
        End If
        error_div_cero()
        Return 0
    End Function

    'manejo de errores'
    Private Function error_div_cero()
        Try
            Throw New SyntaxErrorException("No se puede dividir por cero")
        Catch e As Exception
            MsgBox("Error: Division por 0")
            Console.WriteLine(e.Message)
        Finally
        End Try
    End Function


End Class
