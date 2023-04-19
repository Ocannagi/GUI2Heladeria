Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmABMVentas
    Private Sub frmABMVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged

    End Sub

    Private Sub cmbProductos_Click(sender As Object, e As EventArgs) Handles cmbProductos.Click
        If File.Exists(frmABMProductos.GetArchivo()) Then

            Me.cmbProductos.Items.Clear()
            Dim leerArchivo = My.Computer.FileSystem.OpenTextFileReader(frmABMProductos.GetArchivo())
            Dim productos As Producto()

            While Not leerArchivo.EndOfStream
                Dim registro = leerArchivo.ReadLine
                Dim codigo = "", descripcion = "", precio = ""

                frmABMProductos.DistribuirRegistro(registro, codigo, descripcion, precio)

                productos.


            End While
            leerArchivo.Close()




        End If
    End Sub

    Private Class Producto
        Public Property Codigo As String
        Public Property Descripcion As String
        Public Property Precio As String
    End Class
End Class

