﻿Imports System.IO

Public Class frmMenuPrincipal
    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(frmABMVentas.GetArchivo()) Then
            frmABMVentas.Leer(frmABMVentas.GetArchivo())
        End If
    End Sub

    Private Sub AltasYActualizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltasYActualizacionesToolStripMenuItem.Click
        frmABMProductos.Show()
    End Sub

    Private Sub GeneraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraciónToolStripMenuItem.Click
        frmABMVentas.Show()
    End Sub
End Class
