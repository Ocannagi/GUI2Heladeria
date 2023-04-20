Imports System.IO
Imports System.Text.RegularExpressions

Module FuncionesStd
    Friend Function SuperaMaxLength(sender As Object, e As KeyPressEventArgs, length As Integer) As Boolean
        Dim bool As Boolean = False
        If sender.text.length >= length Then
            If e.KeyChar <> vbBack Then
                bool = True
            End If
        End If
        Return bool
    End Function

    Friend Function EsCaracterNumero(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        Dim exp As String = "[0-9]"
        Dim regex As Regex = New Regex(exp)
        If regex.IsMatch(e.KeyChar) Or e.KeyChar = vbBack Then
            bool = True
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

    Friend Function EsCaracterLetraEspacio(sender As Object, e As KeyPressEventArgs) As Boolean
        Dim bool As Boolean = False
        Dim exp As String = "[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]"
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

    Friend Sub AgregarCeroPrePunto(sender As Object)
        If sender.Text = "." Then
            sender.Text = "0."
        End If
        sender.Focus()
        sender.SelectionStart() = sender.Text.Length
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

    Friend Sub Crear(archivo As String)
        Dim crearArchivo As FileStream = File.Create(archivo)
        crearArchivo.Close()
    End Sub

End Module
