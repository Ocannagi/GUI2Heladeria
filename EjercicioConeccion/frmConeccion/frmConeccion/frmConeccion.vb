Imports System.Data.SqlClient

Public Class frmConeccion
    Private Sub frmConeccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConectarBase()
    End Sub

    Private Sub frmConeccion_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        DaoCon.Close()
        MsgBox("Conexión Cerrada", vbInformation)
    End Sub
End Class
