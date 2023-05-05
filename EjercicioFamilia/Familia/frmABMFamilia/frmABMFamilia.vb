Imports System.Data.SqlClient

Public Class frmABMFamilia
    Private Sub frmABMFamilia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Conectar a Base de Datos
        ConectarBase()
        Me.BotonLimpiar()
    End Sub

    Private Sub frmABMFamilia_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        DaoCon.Close()
        MsgBox("Conexión Cerrada", vbInformation)
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        Me.BotonLimpiar()
    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        Me.BotonAgregar()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Me.BotonEliminar()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Me.botonModificar()
    End Sub

    Sub BotonLimpiar()
        Me.btnEliminar.Enabled = False
        Me.EliminarToolStripMenuItem.Enabled = False

        Me.ModificarToolStripMenuItem.Enabled = False
        Me.btnModificar.Enabled = False ' Boton Modificar

        Me.LimpiarToolStripMenuItem.Enabled = True
        Me.btnLimpiar.Enabled = True

        Me.AgregarToolStripMenuItem.Enabled = True
        Me.btnAgregar.Enabled = True


        Me.txtCodigo.Text = ""
        Me.txtDescripcion.Text = ""
        Me.txtDescripcion.Focus()
        BotonMostrar(0)
    End Sub

    Sub BotonAgregar()
        On Error GoTo Errores
        If Me.txtDescripcion.Text = "" Then
            MsgBox("El nombre es requerido", vbCritical)
            Me.txtDescripcion.Focus()
            Exit Sub
        End If
        Sql = "INSERT INTO familia ([nom familia]) VALUES ('" & Me.txtDescripcion.Text & "')"
        Instruccion = New SqlCommand(Sql, DaoCon)
        Instruccion.ExecuteNonQuery()
        Me.BotonLimpiar()
        Exit Sub
Errores:
        Select Case Err.Number
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub


    Sub BotonEliminar()
        Dim OpC As Integer
        On Error GoTo Errores
        OpC = MsgBox("¿Desea eliminar este Registo?", vbYesNo, "Verifique")
        If OpC = vbYes Then
            Sql = "DELETE FROM familia WHERE [id familia]=" &
           Val(Me.txtCodigo.Text) & ""
            Instruccion = New SqlCommand(Sql, DaoCon)
            Instruccion.ExecuteNonQuery()
        End If
        Me.BotonLimpiar()
        Exit Sub
Errores:
        Select Case Err.Number
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub

    Sub botonModificar()
        On Error GoTo Errores
        If Me.txtDescripcion.Text = "" Then
            MsgBox("El nombre es requerido", vbCritical)
            Me.txtDescripcion.Focus()
            Exit Sub
        End If
        Sql = "UPDATE familia SET [nom familia]='" & Me.txtDescripcion.Text & "' WHERE [id familia]=" & Val(Me.txtCodigo.Text) & ""
        Instruccion = New SqlCommand(Sql, DaoCon)
        Instruccion.ExecuteNonQuery()
        Me.BotonLimpiar()
        Exit Sub
Errores:
        Select Case Err.Number
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub
    Sub BotonMostrar(Orden As Integer)
        Dim Rs As SqlDataReader
        Me.lstListado.Items.Clear()
        Select Case Orden
            Case 0
                Sql = "select * from familia ORDER BY [ID familia]"
            Case 1
                Sql = "select * from familia ORDER BY [nom familia]"
        End Select
        Instruccion = New SqlCommand(Sql, DaoCon)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Me.lstListado.Items.Add(Format(Rs(0), "00000") & " " & Rs(1))
        End While
        Rs.Close()
    End Sub

    Private Sub lstListado_DoubleClick(sender As Object, e As EventArgs) Handles lstListado.DoubleClick
        Dim Rs As SqlDataReader
        If Me.lstListado.SelectedItem <> "" Then
            Sql = "select * from familia Where [id familia]=" &
           Val(Mid(Me.lstListado.SelectedItem, 1, 5)) & ""
            Instruccion = New SqlCommand(Sql, DaoCon)
            Rs = Instruccion.ExecuteReader()
            While Rs.Read
                Me.txtCodigo.Text = Rs(0)
                Me.txtDescripcion.Text = Rs(1)
            End While
            Rs.Close()
            Me.btnEliminar.Enabled = True
            Me.btnModificar.Enabled = True
            Me.btnLimpiar.Enabled = True
            Me.btnAgregar.Enabled = False
            Me.LimpiarToolStripMenuItem.Enabled = True
            Me.EliminarToolStripMenuItem.Enabled = True ' Boton Eliminar
            Me.ModificarToolStripMenuItem.Enabled = True ' Boton Modificar
            Me.AgregarToolStripMenuItem.Enabled = False ' Boton Agregar
        Else
            MsgBox("No se seleccionó ningun item", vbCritical, "Verifique")
            Me.lstListado.Focus()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.BotonLimpiar()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.BotonAgregar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Me.BotonEliminar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Me.botonModificar()
    End Sub

    Private Sub lblCodigo_Click(sender As Object, e As EventArgs) Handles lblCodigo.Click
        Me.BotonMostrar(0)
    End Sub

    Private Sub lblDescripcion_Click(sender As Object, e As EventArgs) Handles lblDescripcion.Click
        Me.BotonMostrar(1)
    End Sub
End Class
