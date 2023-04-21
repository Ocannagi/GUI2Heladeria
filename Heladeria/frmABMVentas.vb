Imports System.IO
Imports Heladeria.frmABMProductos

Public Class frmABMVentas
    Const nomArchivo As String = "Ventas.txt" 'Nombre físico del archivo
    Const ubicacion As String = "C:\Intel\" ' Ubicación dosnde se va a guardar
    Friend Function GetArchivo() As String
        Return ubicacion & nomArchivo
    End Function

    Friend Const espaciosCodigo As Integer = frmABMProductos.espaciosCodigo
    Friend Const espaciosDescripcion As Integer = frmABMProductos.espaciosDescripcion
    Friend Const espaciosPrecio As Integer = frmABMProductos.espaciosPrecio
    Friend Const minEspaciosBlanco As Integer = frmABMProductos.minEspaciosBlanco
    Friend Const espaciosProducto As Integer = espaciosCodigo + espaciosDescripcion + 3 ' 3 = " - "
    Friend Const espaciosCantidad As Integer = 5
    Dim maxEnterosCantidad As Integer = 2
    Dim maxDecimalesCantidad As Integer = 2
    Dim hayCambios As Boolean = False
    Friend listaRegistroVta As New List(Of RegistroVta)
    Friend TotalVentas As Double = 0

    'TODO: Antes de cerrar la ventana, si hay cambios sin persistir, avisar.

    Friend Class RegistroVta
        Public Property Producto As Producto
        Public Property Cantidad As Double
        Public Property NroVta As Integer

        Public Sub New(codigo As String, codigoGuionDescripcion As String, precio As String, cantidad As String, nroVta As String)
            Producto = New Producto(codigo, codigoGuionDescripcion, precio)
            Me.Cantidad = Val(cantidad)
            Me.NroVta = Val(nroVta)
        End Sub

    End Class


    Private Sub frmABMVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombo()
        If Not File.Exists(ubicacion & nomArchivo) Then
            Crear(ubicacion & nomArchivo)
            lblNroComprobanteVta.Text = 1.ToString
        Else
            Me.Leer(ubicacion & nomArchivo)
        End If
    End Sub

    Private Sub frmABMVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _HayCamposSinPersistirABMVentas() Then
            Dim opc = MsgBox("Hay una venta sin persistir. ¿Desea cerrar el formulario de Ventas de todos modos?", vbYesNo + vbCritical)
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

#Region "BOTONES"
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Guardar(ubicacion & nomArchivo)
    End Sub
#End Region

#Region "VALIDACIONES"

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        CambiarComa(sender, e)

        If SuperaMaxLength(sender, e, espaciosCantidad) Or HayDoblePunto(sender, e) Or Not EsCaracterNumeroPunto(sender, e) Or SuperaCantEnteros(sender, e, maxEnterosCantidad) Or SuperaCantDecimales(sender, e, maxDecimalesCantidad) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        AgregarCeroPrePunto(sender)
    End Sub

#End Region



#Region "SUBRUTINAS LECTOESCRITURA Y COMBO"



    Private Sub cmbProductos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedValueChanged
        If frmABMProductos.productos.Count > 0 Then
            Dim producto As frmABMProductos.Producto = Me.cmbProductos.SelectedValue
            Me.lblPrecio.Text = producto.Precio
        End If
    End Sub



    Private Sub Agregar()
        Dim mensaje As String = ""
        If _CamposVaciosABMVentas(mensaje) Then
            MsgBox(mensaje, vbCritical, "Error")
            Exit Sub
        End If

        Dim registro As String = ArmarTxtRegisro(Me.cmbProductos.SelectedValue.Descripcion, Me.cmbProductos.SelectedValue.Precio, txtCantidad.Text)

        Me.lstVentas.Items.Add(registro)
        hayCambios = True
        Limpiar()

    End Sub

    Private Function ArmarTxtRegisro(codigoGuionDescripcion As String, precio As String, cantidad As String) As String
        Dim registro As String = codigoGuionDescripcion + Space((espaciosProducto + minEspaciosBlanco) - codigoGuionDescripcion.Length) + precio + Space((espaciosPrecio + minEspaciosBlanco) - precio.Length) + cantidad.Trim + Space((espaciosCantidad + minEspaciosBlanco) - cantidad.Trim.Length)
        Return registro
    End Function

    Private Sub Limpiar()
        Me.cmbProductos.SelectedIndex() = 0
        Me.txtCantidad.Text = ""
        Me.cmbProductos.Focus()
    End Sub

    Friend Sub Leer(archivo As String)
        Me.listaRegistroVta.Clear()
        Dim leerArchivo = My.Computer.FileSystem.OpenTextFileReader(archivo)
        While Not leerArchivo.EndOfStream
            Dim registro = leerArchivo.ReadLine
            Dim codigo = "", codigoGuionDescripcion = "", precio = "", cantidad = "", nroVta = ""

            DistribuirRegistroVta(registro, codigo, codigoGuionDescripcion, precio, cantidad, nroVta)
            Me.listaRegistroVta.Add(New RegistroVta(codigo, codigoGuionDescripcion, precio, cantidad, nroVta))
        End While
        leerArchivo.Close()
        If listaRegistroVta.Count > 0 Then
            lblNroComprobanteVta.Text = (listaRegistroVta.Item(listaRegistroVta.Count - 1).NroVta + 1).ToString
            TotalVentas = CalcularTotalVentas()
            frmMenuPrincipal.lblTotalVentas.Text = TotalVentas.ToString
        End If
        Me.hayCambios = False
    End Sub



    Private Sub Guardar(archivo As String)
        If _HayCamposSinPersistirABMVentas() Then
            MsgBox("Tiene un registro sin agregar al Comprobante de Venta. Agrégelo o borre los campos de entrada antes de continuar", vbCritical, "Error")
            Exit Sub
        End If

        Dim grabarArchivo As New StreamWriter(archivo)

        For i = 0 To lstVentas.Items.Count() - 1
            Dim codigo = "", codigoGuionDescripcion = "", precio = "", cantidad = "", nroVta = lblNroComprobanteVta.Text

            DistribuirRegistroVta(lstVentas.Items(i).ToString, codigo, codigoGuionDescripcion, precio, cantidad, nroVta)
            Me.listaRegistroVta.Add(New RegistroVta(codigo, codigoGuionDescripcion, precio, cantidad, nroVta))
        Next
        For Each registro As RegistroVta In listaRegistroVta
            grabarArchivo.WriteLine(ArmarTxtRegisro(registro.Producto.Descripcion, registro.Producto.Precio, registro.Cantidad.ToString) + registro.NroVta.ToString)
        Next

        grabarArchivo.Close()
        Leer(archivo)
        Me.lstVentas.Items.Clear()
        MsgBox("Archivo guardado correctamente", vbInformation)

        Me.cmbProductos.Focus()

    End Sub

#End Region


#Region "SUBRUTINAS COLORES CAMPOS"

    Private Sub cmbProductos_Enter(sender As Object, e As EventArgs) Handles cmbProductos.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub cmbProductos_Leave(sender As Object, e As EventArgs) Handles cmbProductos.Leave
        sender.BackColor = Color.White
    End Sub

    Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
        sender.BackColor = Color.White
    End Sub




#End Region


End Class

