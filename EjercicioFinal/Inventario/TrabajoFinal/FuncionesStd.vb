Imports System.Text.RegularExpressions

Module FuncionesStd
    Friend Sub LimpiarCampos(ByVal contenedor As Control.ControlCollection)
        For Each control As Control In contenedor
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Clear()
            ElseIf TypeOf control Is ComboBox Then
                CType(control, ComboBox).SelectedIndex = 0
            ElseIf TypeOf control Is MaskedTextBox Then
                CType(control, MaskedTextBox).Clear()
            ElseIf TypeOf control Is NumericUpDown Then
                CType(control, NumericUpDown).Value = 0
            ElseIf TypeOf control Is CheckBox Then
                CType(control, CheckBox).CheckState = CheckState.Indeterminate
            ElseIf TypeOf control Is RadioButton Then
                CType(control, RadioButton).Checked = False
            ElseIf TypeOf control Is DateTimePicker Then
                CType(control, DateTimePicker).Value = DateTime.Now
            ElseIf control.HasChildren Then
                LimpiarCampos(control.Controls)
            End If
        Next
    End Sub

    Friend Function SuperaMaxLength(sender As Object, e As KeyPressEventArgs, length As Integer) As Boolean
        Dim bool As Boolean = False
        If sender.text.length >= length Then
            If e.KeyChar <> vbBack Then
                bool = True
            End If
        End If
        Return bool
    End Function

    Friend Function EsCaracterLetraEspacio(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        Dim exp As String = "[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]"
        Dim regex As Regex = New Regex(exp)
        If regex.IsMatch(e.KeyChar) Or e.KeyChar = vbBack Then
            bool = True
        End If
        Return bool
    End Function

    Friend Function EsCaracterLetraEspacioNumeroPunto(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        Dim exp As String = "[a-zA-ZñÑáéíóúÁÉÍÓÚ\s0-9.]"
        Dim regex As Regex = New Regex(exp)
        If regex.IsMatch(e.KeyChar) Or e.KeyChar = vbBack Then
            bool = True
        End If
        Return bool
    End Function

    Friend Function EsCaracterLetraSimple(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        Dim exp As String = "[a-zA-Z]"
        Dim regex As Regex = New Regex(exp)
        If regex.IsMatch(e.KeyChar) Or e.KeyChar = vbBack Then
            bool = True
        End If
        Return bool
    End Function

    Friend Sub CambiarComa(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "," Then
            e.KeyChar = "."
        End If
    End Sub

    Friend Function HayDoblePunto(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        If e.KeyChar = "." And sender.Text.Contains(".") Then
            bool = True
        End If
        Return bool
    End Function

    Friend Function SuperaCantEnteros(sender As Object, e As KeyPressEventArgs, maxEnteros As Integer) As Boolean
        Dim bool As Boolean = False
        If Not sender.Text.Contains(".") Then
            If sender.Text.length >= maxEnteros And e.KeyChar <> "." And e.KeyChar <> vbBack Then
                bool = True
            End If
        Else
            If sender.Text.IndexOf(".") >= maxEnteros + 1 And e.KeyChar <> vbBack Then
                bool = True
            End If
        End If
        Return bool
    End Function

    Friend Function SuperaCantDecimales(sender As Object, e As KeyPressEventArgs, maxDecimales As Integer) As Boolean
        Dim bool As Boolean = False
        If sender.Text.Contains(".") Then
            Dim inicio As Integer = sender.Text.IndexOf(".")
            Dim cantidad As Integer = Mid(sender.Text, inicio + 2).Length
            If cantidad >= maxDecimales And e.KeyChar <> vbBack Then
                bool = True
            End If
        End If
        Return bool
    End Function

    Friend Function EsCaracterNumeroPunto(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        Dim exp As String = "[0-9.]"
        Dim regex As Regex = New Regex(exp)
        If regex.IsMatch(e.KeyChar) Or e.KeyChar = vbBack Then
            bool = True
        End If
        Return bool
    End Function

    Friend Sub AgregarCeroPrePunto(sender As Object)
        If sender.Text = "." Then
            sender.Text = "0."
        End If
        sender.Focus()
        sender.SelectionStart() = sender.Text.Length
    End Sub

End Module
