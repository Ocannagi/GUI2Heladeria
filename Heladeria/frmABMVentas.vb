Imports System.IO
Imports System.Net.Http.Headers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmABMVentas
    Const nomArchivo As String = "Ventas.txt" 'Nombre físico del archivo
    Const ubicacion As String = "C:\Intel\" ' Ubicación dosnde se va a guardar

    Const espaciosCodigo As Integer = frmABMProductos.espaciosCodigo
    Const espaciosDescripcion As Integer = frmABMProductos.espaciosDescripcion
    Const espaciosPrecio As Integer = frmABMProductos.espaciosPrecio
    Const minEspaciosBlanco As Integer = frmABMProductos.minEspaciosBlanco
    Const espaciosProducto As Integer = espaciosCodigo + espaciosDescripcion + 3 ' 3 = " - "
    Dim hayCambios As Boolean = False




    Private Sub frmABMVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombo()
        If Not File.Exists(ubicacion & nomArchivo) Then
            Crear(ubicacion & nomArchivo)
        Else
            'Me.Leer(ubicacion & nomArchivo)
        End If
    End Sub

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
                listaProductosCopy.Insert(0, New frmABMProductos.Producto With {.Codigo = "", .Descripcion = "Seleccione un Item", .Precio = ""})
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

        Dim registro As String = Me.cmbProductos.SelectedValue.Descripcion + Space((espaciosProducto + minEspaciosBlanco) - Me.cmbProductos.SelectedValue.Descripcion.Length) + Me.cmbProductos.SelectedValue.Precio + Space((espaciosPrecio + minEspaciosBlanco) - Me.cmbProductos.SelectedValue.Precio.Length) + txtCantidad.Text

        Me.lstVentas.Items.Add(registro)
        hayCambios = True
        Limpiar()

    End Sub

    Private Sub Limpiar()
        Me.cmbProductos.SelectedIndex() = 0
        Me.txtCantidad.Text = ""
        Me.cmbProductos.Focus()

    End Sub

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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub
End Class

