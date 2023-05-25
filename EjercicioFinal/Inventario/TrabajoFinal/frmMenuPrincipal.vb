Public Class frmMenuPrincipal
    Private Sub ArticulosABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulosABMToolStripMenuItem.Click
        Me.Hide()
        frmArticulos.Show()
    End Sub

    Private Sub AgrupacionABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgrupacionABMToolStripMenuItem.Click
        Me.Hide()
        frmAgrupacion.Show()
    End Sub

    Private Sub MovimientosABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosABMToolStripMenuItem.Click
        Me.Hide()
        frmMovimientos.Show()
    End Sub

    Private Sub TipoMovimientoABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoMovimientoABMToolStripMenuItem.Click
        Me.Hide()
        frmTiposMovimiento.Show()
    End Sub

    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
