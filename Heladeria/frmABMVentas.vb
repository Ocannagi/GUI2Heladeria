Imports System.IO
Imports System.Net.Http.Headers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Heladeria.frmABMProductos
Imports Microsoft.Win32

Public Class frmABMVentas
    Const nomArchivo As String = "Ventas.txt" 'Nombre físico del archivo
    Const ubicacion As String = "C:\Intel\" ' Ubicación dosnde se va a guardar

    Const espaciosCodigo As Integer = frmABMProductos.espaciosCodigo
    Const espaciosDescripcion As Integer = frmABMProductos.espaciosDescripcion
    Const espaciosPrecio As Integer = frmABMProductos.espaciosPrecio
    Const minEspaciosBlanco As Integer = frmABMProductos.minEspaciosBlanco
    Const espaciosProducto As Integer = espaciosCodigo + espaciosDescripcion + 3 ' 3 = " - "
    Const espaciosCantidad As Integer = 5
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

    Friend Function GetArchivo() As String
        Return ubicacion & nomArchivo
    End Function

    Private Sub cmbProductos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedValueChanged
        If frmABMProductos.productos.Count > 0 Then
            Dim producto As frmABMProductos.Producto = Me.cmbProductos.SelectedValue
            'Dim productoSeleccionado = frmABMProductos.productos.Find(Function(produ) produ.Codigo = Me.cmbProductos.SelectedValue.ToString)
            Me.lblPrecio.Text = producto.Precio
        End If
    End Sub

    Private Sub CargarCombo()
        If File.Exists(frmABMProductos.GetArchivo()) Then
            frmABMProductos.Leer(frmABMProductos.GetArchivo())
            If frmABMProductos.productos.Count > 0 Then
                Dim listaProductosCopy As New List(Of frmABMProductos.Producto)
                listaProductosCopy.AddRange(frmABMProductos.productos.ToArray)
                listaProductosCopy.Insert(0, New Producto("", "Seleccione un Item", ""))
                Me.cmbProductos.DataSource = listaProductosCopy
                Me.cmbProductos.DisplayMember = "Descripcion"
            End If
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

    Private Function CalcularTotalVentas() As Double
        Dim totalVta As Double = 0
        For Each registro As RegistroVta In listaRegistroVta
            totalVta += (Val(registro.Producto.Precio) * registro.Cantidad)
        Next
        Return Math.Round(totalVta, 2)
    End Function

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


    Private Sub DistribuirRegistroVta(registro As String, ByRef codigo As String, ByRef codigoGuionDescripcion As String, ByRef precio As String, ByRef cantidad As String, ByRef nroVta As String)

        codigo = Mid(registro, 1, espaciosCodigo).Trim
        codigoGuionDescripcion = Mid(registro, 1, espaciosProducto).Trim
        precio = Mid(registro, espaciosProducto + minEspaciosBlanco + 1, espaciosPrecio).Trim
        cantidad = Mid(registro, espaciosProducto + minEspaciosBlanco + espaciosPrecio + minEspaciosBlanco + 1, espaciosCantidad).Trim
        If nroVta = "" Then
            nroVta = Mid(registro, espaciosProducto + minEspaciosBlanco + espaciosPrecio + minEspaciosBlanco + espaciosCantidad + minEspaciosBlanco + 1).Trim
        End If
    End Sub

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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Guardar(ubicacion & nomArchivo)
    End Sub
End Class

