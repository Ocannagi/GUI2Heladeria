Imports System.Data.SqlClient

Public Class frmTiposMovimiento

    Private idTipoMovSeleccionado As Integer = 0
    Friend espaciosNombreTipoMov As Integer = 50
    Friend espaciosCodTipoMov As Integer = 1

    Private Sub frmTiposMovimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodTipoMov.MaxLength = espaciosCodTipoMov
        txtNomTipoMov.MaxLength = espaciosNombreTipoMov
        'Dao_ConectarBase()
        Me.statusBase.Text = Base
        Me.statusCon.Text = ModDao.statusCon
        Me.Limpiar()
    End Sub

#Region "BOTONES"

    Private Sub tsLimpiar_Click(sender As Object, e As EventArgs) Handles tsLimpiar.Click
        Limpiar()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        Limpiar()
    End Sub

    Private Sub tsGuardar_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        Guardar()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Guardar()
    End Sub

    Private Sub tsEliminar_Click(sender As Object, e As EventArgs) Handles tsEliminar.Click
        Eliminar()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Eliminar()
    End Sub

    Private Sub tsModificar_Click(sender As Object, e As EventArgs) Handles tsModificar.Click
        Modificar()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Modificar()
    End Sub

#End Region

#Region "VALIDACIÓN CAMPOS"
    Private Sub txtCodTipoMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodTipoMov.KeyPress
        If SuperaMaxLength(sender, e, espaciosCodTipoMov) Or Not EsCaracterLetraSimple(sender, e) Then
            e.Handled = True
        End If
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtNomTipoMov_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomTipoMov.KeyPress
        If SuperaMaxLength(sender, e, espaciosNombreTipoMov) Or Not EsCaracterLetraEspacio(sender, e) Then
            e.Handled = True
        End If
    End Sub

#End Region


#Region "RUTINAS BOTONES"

    Private Sub Limpiar()
        SetearHabilitacionBotonesABMLimpiar(Me)
        LimpiarCampos(Me.Controls)
        Me.idTipoMovSeleccionado = 0
        Me.txtCodTipoMov.Focus()
        MostrarTipoMov(0)
    End Sub

    Private Sub MostrarTipoMov(Orden As Integer)
        Dim Rs As SqlDataReader
        Me.lstTipoMovimiento.Items.Clear()
        Select Case Orden
            Case 0
                Sql = "select * from tipomovi with (nolock) WHERE [nom tipomovi] like 'ngi%' ORDER BY [tip tipomovi]"
            Case 1
                Sql = "select * from tipomovi with (nolock) WHERE [nom tipomovi] like 'ngi%' ORDER BY [nom tipomovi]"
        End Select
        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Me.lstTipoMovimiento.Items.Add($"{Rs(Rs.GetOrdinal("id tipomovi"))} {Rs(Rs.GetOrdinal("tip tipomovi"))} {Rs(Rs.GetOrdinal("nom tipomovi"))}{Space(espaciosNombreTipoMov - Rs(Rs.GetOrdinal("nom tipomovi")).ToString.Length + 1)}{Rs(Rs.GetOrdinal("esPositivo"))}")
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
        If Me.cckEsPositivo.CheckState = CheckState.Indeterminate Then
            MsgBox("Definir el estado del Tipo de Movimiento es requerido", vbCritical)
            Me.cckEsPositivo.Focus()
            Exit Sub
        End If

        Dim esPositivo As Integer
        Select Case cckEsPositivo.CheckState
            Case CheckState.Checked
                esPositivo = 1
            Case CheckState.Unchecked
                esPositivo = 0
            Case Else
                esPositivo = 0
        End Select

        Sql = $"INSERT INTO tipomovi ([nom tipomovi],[tip tipomovi], esPositivo) VALUES('ngi'+'{txtNomTipoMov.Text.Trim}','{txtCodTipoMov.Text}',{esPositivo})"
        Instruccion = New SqlCommand(Sql, Dao)
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
            If IdTipoMovEnUso(idTipoMovSeleccionado, Dao) Then
                MsgBox("El ID del registro seleccionado se encuentra en uso, no se puede eliminar, solo modificar", vbCritical, "Verifique")
                lstTipoMovimiento.Focus()
                Exit Sub
            End If

            Sql = $"DELETE FROM tipomovi WHERE [id tipomovi]= {idTipoMovSeleccionado}"
            Instruccion = New SqlCommand(Sql, Dao)
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
        If Me.cckEsPositivo.CheckState = CheckState.Indeterminate Then
            MsgBox("Definir el estado del Tipo de Movimiento es requerido", vbCritical)
            Me.cckEsPositivo.Focus()
        End If

        Dim esPositivo As Integer
        Select Case cckEsPositivo.CheckState
            Case CheckState.Checked
                esPositivo = 1
            Case CheckState.Unchecked
                esPositivo = 0
            Case Else
                esPositivo = 0
        End Select

        Sql = $"UPDATE tipomovi SET [nom tipomovi]='{txtNomTipoMov.Text.Trim}', [tip tipomovi]='{txtCodTipoMov.Text}', esPositivo = {esPositivo} WHERE [id tipomovi]= {idTipoMovSeleccionado}"
        Instruccion = New SqlCommand(Sql, Dao)
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


    Private Sub lstTipoMovimiento_DoubleClick(sender As Object, e As EventArgs) Handles lstTipoMovimiento.DoubleClick
        If Me.lstTipoMovimiento.SelectedItem <> "" Then
            Dim Rs As SqlDataReader
            Sql = $"select * from tipomovi WHERE [id tipomovi]= {Val(Mid(Me.lstTipoMovimiento.SelectedItem, 1, Me.lstTipoMovimiento.SelectedItem.ToString.IndexOf(" ") + 1))}"
            Instruccion = New SqlCommand(Sql, Dao)
            Rs = Instruccion.ExecuteReader()
            While Rs.Read
                Me.idTipoMovSeleccionado = Rs(Rs.GetOrdinal("id tipomovi"))
                Me.txtCodTipoMov.Text = Rs(Rs.GetOrdinal("tip tipomovi"))
                Me.txtNomTipoMov.Text = Rs(Rs.GetOrdinal("nom tipomovi"))

                If Rs(Rs.GetOrdinal("esPositivo")) Is DBNull.Value Then
                    cckEsPositivo.CheckState = CheckState.Indeterminate
                ElseIf Rs(Rs.GetOrdinal("esPositivo")) = 0 Then
                    cckEsPositivo.CheckState = CheckState.Unchecked
                Else
                    cckEsPositivo.CheckState = CheckState.Checked
                End If

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

    Private Sub frmTiposMovimiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMenuPrincipal.Show()
    End Sub

#End Region

End Class