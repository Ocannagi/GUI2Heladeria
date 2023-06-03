Imports System.Data.SqlClient
Imports TrabajoFinal.frmTiposMovimiento
Module FuncionesFriend

    Friend Sub SetearHabilitacionBotonesABMLimpiar(formulario As frmTiposMovimiento)

        formulario.tsEliminar.Enabled = False
        formulario.EliminarToolStripMenuItem.Enabled = False

        formulario.ModificarToolStripMenuItem.Enabled = False
        formulario.tsModificar.Enabled = False

        formulario.LimpiarToolStripMenuItem.Enabled = True
        formulario.tsLimpiar.Enabled = True

        formulario.GuardarToolStripMenuItem.Enabled = True
        formulario.tsGuardar.Enabled = True
    End Sub

    Friend Sub SetearHabilitacionBotonesABMLimpiar(formulario As frmAgrupacion)

        formulario.tsEliminar.Enabled = False
        formulario.EliminarToolStripMenuItem.Enabled = False

        formulario.ModificarToolStripMenuItem.Enabled = False
        formulario.tsModificar.Enabled = False

        formulario.LimpiarToolStripMenuItem.Enabled = True
        formulario.tsLimpiar.Enabled = True

        formulario.GuardarToolStripMenuItem.Enabled = True
        formulario.tsGuardar.Enabled = True
    End Sub

    Friend Sub SetearHabilitacionBotonesABMLimpiar(formulario As frmArticulos)

        formulario.tsEliminar.Enabled = False
        formulario.EliminarToolStripMenuItem.Enabled = False

        formulario.ModificarToolStripMenuItem.Enabled = False
        formulario.tsModificar.Enabled = False

        formulario.LimpiarToolStripMenuItem.Enabled = True
        formulario.tsLimpiar.Enabled = True

        formulario.GuardarToolStripMenuItem.Enabled = True
        formulario.tsGuardar.Enabled = True
    End Sub

    Friend Sub SetearHabilitacionBotonesABMLimpiar(formulario As frmMovimientos)

        formulario.LimpiarToolStripMenuItem.Enabled = True
        formulario.tsLimpiar.Enabled = True

        formulario.GuardarToolStripMenuItem.Enabled = True
        formulario.tsGuardar.Enabled = True
    End Sub

    Friend Sub SetearHabilitacionBotonesABMSeleccionar(formulario As frmAgrupacion)
        formulario.tsEliminar.Enabled = True
        formulario.tsModificar.Enabled = True
        formulario.tsLimpiar.Enabled = True
        formulario.tsGuardar.Enabled = False
        formulario.LimpiarToolStripMenuItem.Enabled = True
        formulario.EliminarToolStripMenuItem.Enabled = True ' Boton Eliminar
        formulario.ModificarToolStripMenuItem.Enabled = True ' Boton Modificar
        formulario.GuardarToolStripMenuItem.Enabled = False ' Boton Agregar
    End Sub

    Friend Function IdTipoMovEnUso(id As Integer, Dao As SqlConnection) As Boolean
        Dim query = $"SELECT 1 FROM Movimiento WHERE [id tipomovi] = {id}"
        Dim consulta = New SqlCommand(query, Dao)
        Dim algo = Val(consulta.ExecuteScalar())
        Return Val(consulta.ExecuteScalar()) = 1
    End Function

    Friend Function IdTipoAgrupEnUso(id As Integer, Dao As SqlConnection) As Boolean
        Dim query = $"SELECT 1 FROM Articulo WHERE [id agrupacion] = {id}"
        Dim consulta = New SqlCommand(query, Dao)
        Return Val(consulta.ExecuteScalar()) = 1
    End Function

    Friend Function IdArticuloEnUso(id As Integer, Dao As SqlConnection) As Boolean
        Dim query = $"SELECT 1 FROM Movimiento WHERE [id articulo] = {id}"
        Dim consulta = New SqlCommand(query, Dao)
        Return Val(consulta.ExecuteScalar()) = 1
    End Function

    Friend Function _CamposVaciosAgrupacion(frmAgrupacion As frmAgrupacion, ByRef mensaje As String) As Boolean
        Dim tamMensaje = mensaje.Length
        If frmAgrupacion.txtNombreAgrupacion.Text = "" Then
            mensaje += "El nombre de la agrupación es requerido" + vbCrLf
            frmAgrupacion.txtNombreAgrupacion.BackColor = Color.LightPink
        End If

        Return mensaje.Length > tamMensaje
    End Function


    Friend Function _CamposVaciosArticulos(frmArticulos As frmArticulos, ByRef mensaje As String) As Boolean
        mensaje = "Los siguientes campos deben estar completos:" + vbCrLf
        Dim tamMensaje As Integer = mensaje.Length

        If frmArticulos.txtNomArticulo.Text = "" Then
            mensaje += "Nombre art." + vbCrLf
            frmArticulos.txtNomArticulo.BackColor = Color.LightPink
        End If
        If frmArticulos.txtPrecio.Text = "" Then
            mensaje += "Precio" + vbCrLf
            frmArticulos.txtPrecio.BackColor = Color.LightPink
        End If
        If frmArticulos.cmbAgrupacion.SelectedIndex() = 0 Or frmArticulos.cmbAgrupacion.SelectedIndex() = -1 Then
            mensaje += "Agrupacion" + vbCrLf
            frmArticulos.cmbAgrupacion.BackColor = Color.LightPink
        End If

        If mensaje.Length > tamMensaje Then
            Return True
        End If
        Return False
    End Function

    Friend Function _CamposVaciosTipoMovi(frmTiposMovimiento As frmTiposMovimiento, ByRef mensaje As String) As Boolean
        mensaje = "Los siguientes campos deben estar completos:" + vbCrLf
        Dim tamMensaje As Integer = mensaje.Length

        If frmTiposMovimiento.txtCodTipoMov.Text = "" Then
            mensaje += "CódTipoMov" + vbCrLf
            frmTiposMovimiento.txtCodTipoMov.BackColor = Color.LightPink
        End If
        If frmTiposMovimiento.txtNomTipoMov.Text = "" Then
            mensaje += "Descripción" + vbCrLf
            frmTiposMovimiento.txtNomTipoMov.BackColor = Color.LightPink
        End If
        If frmTiposMovimiento.cckEsPositivo.CheckState = CheckState.Indeterminate Then
            mensaje += "Estado Tipo Movimiento se debe definir" + vbCrLf
            frmTiposMovimiento.cckEsPositivo.BackColor = Color.LightPink
        End If

        If mensaje.Length > tamMensaje Then
            Return True
        End If
        Return False
    End Function

    Friend Function _CamposVaciosMovi(frmMovimiento As frmMovimientos, ByRef mensaje As String) As Boolean
        mensaje = "Los siguientes campos deben estar completos:" + vbCrLf
        Dim tamMensaje As Integer = mensaje.Length

        If frmMovimiento.txtCodArt.Text = "" Then
            mensaje += "Código" + vbCrLf
            frmMovimiento.txtCodArt.BackColor = Color.LightPink
        End If
        If frmMovimiento.cmbArticulo.SelectedIndex() = 0 Or frmMovimiento.cmbArticulo.SelectedIndex() = -1 Then
            mensaje += "Artículo" + vbCrLf
            frmMovimiento.cmbArticulo.BackColor = Color.LightPink
        End If
        If frmMovimiento.txtCantidad.Text = "" Then
            mensaje += "Cantidad" + vbCrLf
            frmMovimiento.txtCantidad.BackColor = Color.LightPink
        End If
        If frmMovimiento.cmbTipoMov.SelectedIndex() = 0 Or frmMovimiento.cmbTipoMov.SelectedIndex() = -1 Then
            mensaje += "Tipo de Movimiento" + vbCrLf
            frmMovimiento.cmbTipoMov.BackColor = Color.LightPink
        End If
        If frmMovimiento.txtObs.Text = "" Or frmMovimiento.txtObs.Text.Length < 4 Then
            mensaje += "Observación (se requiere al menos 4 caracteres)" + vbCrLf
            frmMovimiento.txtObs.BackColor = Color.LightPink
        End If

        If mensaje.Length > tamMensaje Then
            Return True
        End If
        Return False
    End Function

    Friend Function HayCamposConContenidoFrmMovimientos(frmMovimientos As frmMovimientos) As Boolean
        Dim resultado As Boolean = False
        If frmMovimientos.txtCodArt.Text <> "" And frmMovimientos.txtCodArt.Text <> "0" Then
            resultado = True
        ElseIf frmMovimientos.cmbArticulo.SelectedIndex > 0 Then
            resultado = True
        ElseIf frmMovimientos.txtCantidad.Text <> "" Then
            resultado = True
        ElseIf frmMovimientos.cmbTipoMov.SelectedIndex > 0 Then
            resultado = True
        ElseIf frmMovimientos.txtObs.Text <> "" Then
            resultado = True
        End If
        Return resultado
    End Function

End Module
