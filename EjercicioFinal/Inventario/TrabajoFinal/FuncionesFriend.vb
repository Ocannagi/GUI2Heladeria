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

End Module
