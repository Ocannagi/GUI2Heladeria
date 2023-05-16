Public Class frmAgrupacion
    Friend espaciosNombreAgrupacion As Integer = 50
    Friend idTipoAgrupacionSeleccionada = 0

    Private Sub frmAgrupacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dao_ConectarBase()
        Me.Limpiar()
    End Sub

    Private Sub Limpiar()
        SetearHabilitacionBotonesABMLimpiar(Me)
        LimpiarCampos(Me.Controls)
        Me.idTipoAgrupacionSeleccionada = 0
        Me.txtNombreAgrupacion.Focus()
        ''MostrarAgrupacion(0)
    End Sub
End Class