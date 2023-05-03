Imports System.IO

Public Class frmLog
    Friend espaciosCodigo As Integer = 5
    Friend espaciosCantidad As Integer = 4

    Friend minEspaciosBlanco = 3

    Dim enteros = 5
    Dim decimales = 2
    Dim punto = 1
    Friend espaciosPrecio As Integer = enteros + decimales + punto

    Friend formatCodigo = Cero(espaciosCodigo)
    Friend formatCantidad = Cero(espaciosCantidad)
    Friend formatPrecio = Cero(enteros) + "." + Cero(decimales)

    Friend nomArchivo As String = "Log.txt" 'Nombre físico del archivo
    Friend ubicacion As String = "C:\Intel\" ' Ubicación dosnde se va a guardar


    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(ubicacion & nomArchivo) Then
            Crear(ubicacion & nomArchivo)
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Agregar()

        Dim fechaSimple = Format(Now, "dd/MM/yyyy")
        Dim fechaHoraMinutoSegundo = Format(Now, "dd/mm/yyyyHH:mm:ss")
        Dim codigo = Format(Val(txtCodigo.Text.Trim), formatCodigo)
        Dim cantidad = Format(Val(txtCantidad.Text.Trim), formatCantidad)
        Dim precio = Format(Val(txtPrecio.Text.Trim), formatPrecio).Replace(",", ".")
        txtPrecio.Text = (txtPrecio.Text.Trim)

        Dim registroLista As String = fechaSimple + Space(minEspaciosBlanco) + codigo + Space(minEspaciosBlanco) + cantidad + Space(minEspaciosBlanco) + precio
        Dim registroLog As String = fechaHoraMinutoSegundo + codigo + cantidad + precio

        Me.lstRecibo.Items.Add(registroLista)
        GuardarDeAUno(ubicacion & nomArchivo, registroLog)

        Limpiar()

    End Sub

    Private Sub Limpiar()
        Me.txtCodigo.Text = ""
        Me.txtCantidad.Text = ""
        Me.txtPrecio.Text = ""
        Me.txtCodigo.Focus()
    End Sub

    Private Sub Crear(archivo)
        Dim crearArchivo As FileStream = File.Create(archivo)
        crearArchivo.Close()
    End Sub

    Private Sub GuardarDeAUno(archivo As String, registro As String)
        Dim grabarArchivo As New StreamWriter(archivo)
        grabarArchivo.WriteLine(registro)
        grabarArchivo.Close()
    End Sub


    Private Function Cero(cantidad As Integer) As String
        Dim str = ""
        While cantidad > 0
            str += "0"
            cantidad -= 1
        End While

        Return str
    End Function


    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If SuperaMaxLength(sender, e, espaciosCodigo) Or Not EsCaracterNumero(sender, e) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If SuperaMaxLength(sender, e, espaciosCantidad) Or Not EsCaracterNumero(sender, e) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        CambiarComa(sender, e)

        If SuperaMaxLength(sender, e, espaciosPrecio) Or HayDoblePunto(sender, e) Or Not EsCaracterNumeroPunto(sender, e) Or SuperaCantEnteros(sender, e, enteros) Then
            e.Handled = True
        End If
    End Sub


End Class
