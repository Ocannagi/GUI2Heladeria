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
            frmABMProductos.txtDescripcion.BackColor = Color.LightPink
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

    Friend Function _HayCamposSinPersistir() As Boolean
        Dim bool = False
        If frmABMProductos.txtCodigo.Text <> "" Or frmABMProductos.txtDescripcion.Text <> "" Or frmABMProductos.txtPrecio.Text <> "" Then
            'frmABMProductos.txtCodigo.Focus()
            bool = True
        End If
        Return bool
    End Function

    Friend Sub _DeshabilitarSiHayCamposSinPersistir()
        If _HayCamposSinPersistir() Then
            frmABMProductos.btnEliminar.Enabled = False
            frmABMProductos.btnModificar.Enabled = False
        Else
            _HabilitarBtn_SegCant()
        End If
    End Sub

End Module
