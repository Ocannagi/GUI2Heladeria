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
        Dim query = $"SELECT COUNT(1) FROM Movimiento WHERE [id tipomovi] = {id}"
        Dim consulta = New SqlCommand(query, Dao)
        Return Val(consulta.ExecuteScalar()) = 1
    End Function

    Friend Function IdTipoAgrupEnUso(id As Integer, Dao As SqlConnection) As Boolean
        Dim query = $"SELECT COUNT(1) FROM Articulo WHERE [id agrupacion] = {id}"
        Dim consulta = New SqlCommand(query, Dao)
        Return Val(consulta.ExecuteScalar()) = 1
    End Function

End Module
