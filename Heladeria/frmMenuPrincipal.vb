Imports System.IO

Public Class frmMenuPrincipal
    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(frmABMVentas.GetArchivo()) Then
            frmABMVentas.Leer(frmABMVentas.GetArchivo())
        End If
    End Sub

    Private Sub AltasYActualizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltasYActualizacionesToolStripMenuItem.Click
        frmABMProductos.ShowDialog()
    End Sub

    Private Sub GeneraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraciónToolStripMenuItem.Click
        frmABMVentas.ShowDialog()
    End Sub

    Private Sub frmMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("¿Está seguro de cerrar la aplicación?", vbYesNo) = vbNo Then
            e.Cancel = True
        End If
    End Sub
End Class
