Imports System.IO

Public Class frmABMProductos
    Friend Const espaciosCodigo As Integer = 3
    Friend Const espaciosDescripcion As Integer = 30
    Friend Const espaciosPrecio As Integer = 7
    Friend Const minEspaciosBlanco As Integer = 5
    Const maxEnteros As Integer = 4
    Const maxDecimales As Integer = 2

    Const nomArchivo As String = "Productos.txt" 'Nombre físico del archivo
    Const ubicacion As String = "C:\Intel\" ' Ubicación dosnde se va a guardar
    Dim hayCambios As Boolean = False
    Friend productos As New List(Of Producto)


    Friend Class Producto
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Precio As String

        Public Sub New(codigo As String, descripcion As String, precio As String)
            Me.Codigo = codigo
            Me.Descripcion = descripcion
            Me.Precio = precio
        End Sub

    End Class

    Friend Function GetArchivo() As String
        Return ubicacion & nomArchivo
    End Function

    Private Sub frmABMProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(ubicacion & nomArchivo) Then
            Crear(ubicacion & nomArchivo)
        Else
            Me.Leer(ubicacion & nomArchivo)
        End If

        _HabilitarBtn_SegCant()
    End Sub

    Private Sub frmABMProductos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If _HayCamposSinPersistirABMProductos() Then
            Dim opc = MsgBox("Hay un producto sin persistir. ¿Desea cerrar el formulario de Productos de todos modos?", vbYesNo + vbCritical)
            If opc = vbNo Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If hayCambios Then
            Dim opc = MsgBox("¿Desea guardar los cambios en " + nomArchivo + "?", vbYesNo + vbCritical)
            If opc = vbYes Then
                Me.Guardar(ubicacion & nomArchivo)
            End If
        End If


    End Sub

#Region "SUBRUTINAS LECTOESCRITURA ARCHIVO"



    Private Sub LeerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeerToolStripMenuItem.Click
        Leer(ubicacion & nomArchivo)
    End Sub

    Friend Sub Leer(archivo As String)
        If _HayCamposSinPersistirABMProductos() Then
            MsgBox("Tiene un registro sin agregar al Formulario de Productos. Agrégelo o borre los campos de entrada antes de continuar", vbCritical, "Error")
            Exit Sub
        End If

        If hayCambios Then
            Dim opc = MsgBox("¿Desea guardar los cambios en " + nomArchivo + "?" + vbCrLf + "Si elege ""NO"", perderá todos los cambios y se recuperarán todos los registros en su estado anterior", vbYesNo + vbCritical)
            If opc = vbYes Then
                Me.Guardar(ubicacion & nomArchivo)
            End If
        End If

        Me.lstProductos.Items.Clear()
        Me.productos.Clear()
        Dim leerArchivo = My.Computer.FileSystem.OpenTextFileReader(archivo)
        While Not leerArchivo.EndOfStream
            Dim registro = leerArchivo.ReadLine
            Dim codigo = "", descripcion = "", precio = ""

            Me.lstProductos.Items.Add(registro)
            DistribuirRegistroProducto(registro, codigo, descripcion, precio)
            Me.productos.Add(New Producto(codigo, codigo + " - " + descripcion, precio))
        End While
        leerArchivo.Close()

        Me.lblCantidad.Text = lstProductos.Items.Count()
        _HabilitarBtn_SegCant()
        Me.hayCambios = False
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Guardar(ubicacion & nomArchivo)
    End Sub

    Private Sub Guardar(archivo As String)
        Dim grabarArchivo As New StreamWriter(archivo)

        If Val(lblCantidad.Text) <= 0 Then
            Dim opc = MsgBox("¿Desea guardar el Formulario de Productos vacío?" + vbCrLf + "Si elege ""SÍ"", perderá todos los registros previos que pudiera tener guardados", vbYesNo + vbCritical)
            If opc = vbYes Then

                For i = 0 To lstProductos.Items.Count() - 1
                    grabarArchivo.WriteLine(lstProductos.Items(i).ToString())
                Next
                grabarArchivo.Close()
                MsgBox("Archivo guardado correctamente", vbInformation)
                hayCambios = False
                Me.txtCodigo.Focus()
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        For i = 0 To lstProductos.Items.Count() - 1
            grabarArchivo.WriteLine(lstProductos.Items(i).ToString())
        Next
        grabarArchivo.Close()
        MsgBox("Archivo guardado correctamente", vbInformation)
        hayCambios = False
        Me.txtCodigo.Focus()
    End Sub
#End Region


#Region "SUBRUTINAS COLORES CAMPOS"
    Private Sub txtCodigo_Enter(sender As Object, e As EventArgs) Handles txtCodigo.Enter
        sender.BackColor = Color.LightYellow
    End Sub
    Private Sub txtCodigo_Leave(sender As Object, e As EventArgs) Handles txtCodigo.Leave
        sender.BackColor = Color.White
    End Sub
    Private Sub txtDescripcion_Enter(sender As Object, e As EventArgs) Handles txtDescripcion.Enter
        sender.BackColor = Color.LightYellow
    End Sub
    Private Sub txtDescripcion_Leave(sender As Object, e As EventArgs) Handles txtDescripcion.Leave
        sender.BackColor = Color.White
    End Sub
    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        sender.BackColor = Color.LightYellow
    End Sub
    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        sender.BackColor = Color.White
    End Sub
#End Region

#Region "VALIDACIONES CAMPOS"

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If SuperaMaxLength(sender, e, espaciosCodigo) Or Not EsCaracterNumero(sender, e) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        _DeshabilitarSiHayCamposSinPersistir()
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If SuperaMaxLength(sender, e, espaciosDescripcion) Or Not EsCaracterLetraEspacio(sender, e) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged
        _DeshabilitarSiHayCamposSinPersistir()
    End Sub
    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        CambiarComa(sender, e)

        If SuperaMaxLength(sender, e, espaciosPrecio) Or HayDoblePunto(sender, e) Or Not EsCaracterNumeroPunto(sender, e) Or SuperaCantEnteros(sender, e, maxEnteros) Or SuperaCantDecimales(sender, e, maxDecimales) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        AgregarCeroPrePunto(sender)
        _DeshabilitarSiHayCamposSinPersistir()
    End Sub


#End Region


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Limpiar()
        Me.txtCodigo.Text = ""
        Me.txtDescripcion.Text = ""
        Me.txtPrecio.Text = ""
        Me.lblCantidad.Text = lstProductos.Items.Count()
        Me.txtCodigo.Focus()
        _HabilitarBtn_SegCant()
    End Sub



    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub
    Private Sub Agregar()
        Dim mensaje As String = ""
        If _CamposVaciosABMProductos(mensaje) Then
            MsgBox(mensaje, vbCritical, "Error")
            Exit Sub
        End If

        Dim registro As String = Format(Val(txtCodigo.Text.Trim), "000") + Space(minEspaciosBlanco) + txtDescripcion.Text.Trim + Space((espaciosDescripcion + minEspaciosBlanco) - txtDescripcion.Text.Trim.Length) + txtPrecio.Text.Trim

        Me.lstProductos.Items.Add(registro)
        hayCambios = True
        Limpiar()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub

    Private Sub Eliminar()
        If Not _HayItemSeleccionado() Then
            Exit Sub
        End If

        lstProductos.Items.Remove(lstProductos.SelectedItem)
        Me.lblCantidad.Text = lstProductos.Items.Count()
        Me.hayCambios = True
        _HabilitarBtn_SegCant()
        Me.txtCodigo.Focus()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub Modificar()
        If Not _HayItemSeleccionado() Then
            Exit Sub
        End If

        Dim codigo As String = ""
        Dim descripcion As String = ""
        Dim precio As String = ""

        DistribuirRegistroProducto(lstProductos.SelectedItem.ToString(), codigo, descripcion, precio)

        txtCodigo.Text = codigo
        txtDescripcion.Text = descripcion
        txtPrecio.Text = precio
        Eliminar()
    End Sub

End Class