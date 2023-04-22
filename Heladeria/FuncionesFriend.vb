Imports System.IO
Imports Heladeria.frmABMProductos
Imports Heladeria.frmABMVentas

Module FuncionesFriend
    Friend Function _CamposVaciosABMProductos(ByRef mensaje As String) As Boolean
        mensaje = "Los siguientes campos deben estar completos:" + vbCrLf
        Dim tamMensaje As Integer = mensaje.Length

        If frmABMProductos.txtCodigo.Text = "" Then
            mensaje += "Código" + vbCrLf
            frmABMProductos.txtCodigo.BackColor = Color.LightPink
        End If
        If frmABMProductos.txtDescripcion.Text = "" Then
            mensaje += "Descripcion" + vbCrLf
            frmABMProductos.txtDescripcion.BackColor = Color.LightPink
        End If
        If frmABMProductos.txtPrecio.Text = "" Then
            mensaje += "Precio" + vbCrLf
            frmABMProductos.txtPrecio.BackColor = Color.LightPink
        End If

        If mensaje.Length > tamMensaje Then
            Return True
        End If
        Return False
    End Function

    Friend Function _CamposVaciosABMVentas(ByRef mensaje As String) As Boolean
        mensaje = "Los siguientes campos deben estar completos:" + vbCrLf
        Dim tamMensaje As Integer = mensaje.Length

        If frmABMVentas.lblPrecio.Text = "" Then
            mensaje += "Producto: Debe seleccionar un item válido" + vbCrLf
            frmABMVentas.cmbProductos.BackColor = Color.LightPink
        End If
        If frmABMVentas.txtCantidad.Text = "" Then
            mensaje += "Cantidad" + vbCrLf
            frmABMVentas.txtCantidad.BackColor = Color.LightPink
        End If

        If mensaje.Length > tamMensaje Then
            Return True
        End If
        Return False
    End Function

    Friend Sub _HabilitarBtn_SegCant()
        If Val(frmABMProductos.lblCantidad.Text) <= 0 Then
            frmABMProductos.btnEliminar.Enabled = False
            frmABMProductos.btnModificar.Enabled = False
        Else
            frmABMProductos.btnEliminar.Enabled = True
            frmABMProductos.btnModificar.Enabled = True
        End If
    End Sub

    Friend Function _HayItemSeleccionado() As Boolean
        Dim bool As Boolean = True
        If frmABMProductos.lstProductos.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un Item", vbCritical, "Error")
            frmABMProductos.lstProductos.Focus()
            bool = False
        End If
        Return bool
    End Function

    Friend Function _HayCamposSinPersistirABMProductos() As Boolean
        Dim bool = False
        If frmABMProductos.txtCodigo.Text <> "" Or frmABMProductos.txtDescripcion.Text <> "" Or frmABMProductos.txtPrecio.Text <> "" Then
            'frmABMProductos.txtCodigo.Focus()
            bool = True
        End If
        Return bool
    End Function

    Friend Function _HayCamposSinPersistirABMVentas() As Boolean
        Dim bool = False
        If frmABMVentas.cmbProductos.SelectedIndex() > 0 Or frmABMVentas.txtCantidad.Text <> "" Then
            bool = True
        End If
        Return bool
    End Function


    Friend Sub _DeshabilitarSiHayCamposSinPersistir()
        If _HayCamposSinPersistirABMProductos() Then
            frmABMProductos.btnEliminar.Enabled = False
            frmABMProductos.btnModificar.Enabled = False
        Else
            _HabilitarBtn_SegCant()
        End If
    End Sub

    Friend Sub DistribuirRegistroProducto(registro As String, ByRef codigo As String, ByRef descripcion As String, ByRef precio As String)
        codigo = Mid(registro, 1, frmABMProductos.espaciosCodigo).Trim
        descripcion = Mid(registro, frmABMProductos.espaciosCodigo + frmABMProductos.minEspaciosBlanco + 1, frmABMProductos.espaciosDescripcion).Trim
        precio = Mid(registro, frmABMProductos.espaciosCodigo + frmABMProductos.minEspaciosBlanco + frmABMProductos.espaciosDescripcion + frmABMProductos.minEspaciosBlanco + 1).Trim
    End Sub

    Friend Sub DistribuirRegistroVta(registro As String, ByRef codigo As String, ByRef codigoGuionDescripcion As String, ByRef precio As String, ByRef cantidad As String, ByRef nroVta As String)

        codigo = Mid(registro, 1, frmABMVentas.espaciosCodigo).Trim
        codigoGuionDescripcion = Mid(registro, 1, frmABMVentas.espaciosProducto).Trim
        precio = Mid(registro, frmABMVentas.espaciosProducto + frmABMVentas.minEspaciosBlanco + 1, frmABMVentas.espaciosPrecio).Trim
        cantidad = Mid(registro, frmABMVentas.espaciosProducto + frmABMVentas.minEspaciosBlanco + frmABMVentas.espaciosPrecio + frmABMVentas.minEspaciosBlanco + 1, frmABMVentas.espaciosCantidad).Trim
        If nroVta = "" Then
            nroVta = Mid(registro, frmABMVentas.espaciosProducto + frmABMVentas.minEspaciosBlanco + frmABMVentas.espaciosPrecio + frmABMVentas.minEspaciosBlanco + frmABMVentas.espaciosCantidad + frmABMVentas.minEspaciosBlanco + 1).Trim
        End If
    End Sub

    Friend Sub CargarCombo()
        If File.Exists(frmABMProductos.GetArchivo()) Then
            frmABMProductos.Leer(frmABMProductos.GetArchivo())
            If frmABMProductos.objListaproductos.Count > 0 Then
                Dim listaProductosCopy As New List(Of Producto)
                listaProductosCopy.AddRange(frmABMProductos.objListaproductos.ToArray)
                listaProductosCopy.Insert(0, New Producto("", "Seleccione un Item", ""))
                frmABMVentas.cmbProductos.DataSource = listaProductosCopy
                frmABMVentas.cmbProductos.DisplayMember = "Descripcion"
            End If
        End If
    End Sub

    Friend Function CalcularTotalVentas() As Double
        Dim totalVta As Double = 0
        For Each registro As RegistroVta In frmABMVentas.listaRegistroVta
            totalVta += (Val(registro.Producto.Precio) * registro.Cantidad)
        Next
        Return Math.Round(totalVta, 2)
    End Function

End Module
