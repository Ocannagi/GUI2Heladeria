Imports System.Text.RegularExpressions

Module FuncionesStd
    Friend Sub LimpiarCampos(ByVal contenedor As Control.ControlCollection)
        For Each control As Control In contenedor
            If TypeOf control Is TextBox Then
                CType(control, TextBox).Clear()
            ElseIf TypeOf control Is ComboBox Then
                CType(control, ComboBox).SelectedIndex = -1
            ElseIf TypeOf control Is MaskedTextBox Then
                CType(control, MaskedTextBox).Clear()
            ElseIf TypeOf control Is NumericUpDown Then
                CType(control, NumericUpDown).Value = 0
            ElseIf TypeOf control Is CheckBox Then
                CType(control, CheckBox).Checked = False
            ElseIf TypeOf control Is RadioButton Then
                CType(control, RadioButton).Checked = False
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

    Friend Function EsCaracterLetraSimple(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        Dim exp As String = "[a-zA-Z]"
        Dim regex As Regex = New Regex(exp)
        If regex.IsMatch(e.KeyChar) Or e.KeyChar = vbBack Then
            bool = True
        End If
        Return bool
    End Function


End Module
