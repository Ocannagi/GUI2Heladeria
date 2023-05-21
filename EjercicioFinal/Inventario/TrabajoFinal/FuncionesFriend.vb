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

End Module
