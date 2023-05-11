Imports System.Data.SqlClient

Public Class frmTiposMovimiento
    Private Sub frmTiposMovimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Conectar a Base de Datos
        TipoMov_ConectarBase()
        Me.Limpiar()
    End Sub

    Private Sub tsLimpiar_Click(sender As Object, e As EventArgs) Handles tsLimpiar.Click
        Limpiar()
    End Sub

    Private Sub tsGuardar_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        Guardar()
    End Sub

    Private Sub tsEliminar_Click(sender As Object, e As EventArgs) Handles tsEliminar.Click
        Eliminar()
    End Sub


#Region "RUTINAS BOTONES"

    Private Sub Limpiar()
        Me.tsEliminar.Enabled = False
        Me.EliminarToolStripMenuItem.Enabled = False

        Me.ModificarToolStripMenuItem.Enabled = False
        Me.tsModificar.Enabled = False

        Me.LimpiarToolStripMenuItem.Enabled = True
        Me.tsLimpiar.Enabled = True

        Me.GuardarToolStripMenuItem.Enabled = True
        Me.tsGuardar.Enabled = True


        Me.txtCodTipoMov.Text = ""
        Me.txtNomTipoMov.Text = ""
        Me.txtCodTipoMov.Focus()
        MostrarTipoMov(0)
    End Sub

    Private Sub MostrarTipoMov(Orden As Integer)
        Dim Rs As SqlDataReader
        Me.lstTipoMovimiento.Items.Clear()
        Select Case Orden
            Case 0
                Sql = "select * from tipomovi with (nolock) WHERE substring([nom tipomovi],1,3)='ngi' ORDER BY [tip tipomovi]"
            Case 1
                Sql = "select * from tipomovi with (nolock) WHERE substring([nom tipomovi],1,3)='ngi' ORDER BY [nom tipomovi]"
        End Select
        Instruccion = New SqlCommand(Sql, DaoTipoMov)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Me.lstTipoMovimiento.Items.Add($"{Rs(0)} {Rs(2)} {Rs(1)}")
        End While
        Rs.Close()
    End Sub

    Private Sub Guardar()
        On Error GoTo Errores
        If Me.txtCodTipoMov.Text = "" Then
            MsgBox("El Código de Tipo Movimiento es requerido", vbCritical)
            Me.txtCodTipoMov.Focus()
            Exit Sub
        End If
        If Me.txtNomTipoMov.Text = "" Then
            MsgBox("El Nombre de Tipo Movimiento es requerido", vbCritical)
            Me.txtNomTipoMov.Focus()
            Exit Sub
        End If
        Sql = $"INSERT INTO tipomovi ([nom tipomovi],[tip tipomovi]) VALUES('ngi'+'{txtNomTipoMov.Text}','{txtCodTipoMov.Text}')"
        Instruccion = New SqlCommand(Sql, DaoTipoMov)
        Instruccion.ExecuteNonQuery()
        Me.Limpiar()
        Exit Sub
Errores:
        Select Case Err.Number
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub

    Private Sub Eliminar()
        Dim OpC As Integer
        On Error GoTo Errores
        OpC = MsgBox("¿Desea eliminar este Registo?", vbYesNo, "Verifique")
        If OpC = vbYes Then
            Sql = $"DELETE FROM tipomovi WHERE [nom tipomovi]= '{txtNomTipoMov.Text}'"
            Instruccion = New SqlCommand(Sql, DaoTipoMov)
            Instruccion.ExecuteNonQuery()
        End If
        Limpiar()
        Exit Sub
Errores:
        Select Case Err.Number
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub

    Private Sub Modificar()
        On Error GoTo Errores
        If Me.txtCodTipoMov.Text = "" Then
            MsgBox("El Código de Tipo Movimiento es requerido", vbCritical)
            Me.txtCodTipoMov.Focus()
            Exit Sub
        End If
        If Me.txtNomTipoMov.Text = "" Then
            MsgBox("El Nombre de Tipo Movimiento es requerido", vbCritical)
            Me.txtNomTipoMov.Focus()
            Exit Sub
        End If
        Sql = $"UPDATE tipomovi SET [nom tipomovi]='{txtNomTipoMov.Text}', [tip tipomovi]='{txtCodTipoMov.Text}' WHERE [id tipomovi]=" & Val(Me.txtCodigo.Text) & ""
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

    Private Sub lstTipoMovimiento_DoubleClick(sender As Object, e As EventArgs) Handles lstTipoMovimiento.DoubleClick
        If Me.lstTipoMovimiento.SelectedItem <> "" Then
            Dim Rs As SqlDataReader
            Sql = $"select * from tipomovi WHERE [id tipomovi]= {Val(Mid(Me.lstTipoMovimiento.SelectedItem, 1, Me.lstTipoMovimiento.SelectedItem.ToString.IndexOf(" ") + 1))}"
            Instruccion = New SqlCommand(Sql, DaoTipoMov)
            Rs = Instruccion.ExecuteReader()
            While Rs.Read
                Me.txtCodTipoMov.Text = Rs(2)
                Me.txtNomTipoMov.Text = Rs(1)
            End While
            Rs.Close()
            tsEliminar.Enabled = True
            tsModificar.Enabled = True
            tsLimpiar.Enabled = True
            tsGuardar.Enabled = False
            Me.LimpiarToolStripMenuItem.Enabled = True
            Me.EliminarToolStripMenuItem.Enabled = True ' Boton Eliminar
            Me.ModificarToolStripMenuItem.Enabled = True ' Boton Modificar
            Me.GuardarToolStripMenuItem.Enabled = False ' Boton Agregar
        Else
            MsgBox("No se seleccionó ningun item", vbCritical, "Verifique")
            Me.lstTipoMovimiento.Focus()
        End If
    End Sub











#End Region
End Class