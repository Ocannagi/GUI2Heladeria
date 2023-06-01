Imports System.Data.SqlClient

Public Class frmAgrupacion
    Friend espaciosNombreAgrupacion As Integer = 50
    Friend idTipoAgrupacionSeleccionada As Integer = 0

    Dim ordenId As Boolean = False
    Dim ordenAgrup As Boolean = True

    Private Sub frmAgrupacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombreAgrupacion.MaxLength = espaciosNombreAgrupacion
        Me.statusCon.Text = ModDao.statusCon
        Me.statusBase.Text = Base
        'Dao_ConectarBase()
        Me.Limpiar()
    End Sub

#Region "ACCESO BOTONES"
    Private Sub tsLimpiar_Click(sender As Object, e As EventArgs) Handles tsLimpiar.Click
        Limpiar()
    End Sub

    Private Sub tsGuardar_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        Guardar()
    End Sub

    Private Sub tsEliminar_Click(sender As Object, e As EventArgs) Handles tsEliminar.Click
        Eliminar()
    End Sub

    Private Sub tsModificar_Click(sender As Object, e As EventArgs) Handles tsModificar.Click
        Modificar()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        Limpiar()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Guardar()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Eliminar()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Modificar()
    End Sub
#End Region

#Region "VALIDACIÓN CAMPOS"
    Private Sub txtNombreAgrupacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreAgrupacion.KeyPress
        If SuperaMaxLength(sender, e, espaciosNombreAgrupacion) Or Not EsCaracterLetraEspacio(sender, e) Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "COLORES CAMPOS"

    Private Sub txtNombreAgrupacion_Enter(sender As Object, e As EventArgs) Handles txtNombreAgrupacion.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub txtNombreAgrupacion_Leave(sender As Object, e As EventArgs) Handles txtNombreAgrupacion.Leave
        sender.BackColor = Color.White
    End Sub

#End Region

#Region "RUTINAS BOTONES"

    Private Sub Limpiar()
        SetearHabilitacionBotonesABMLimpiar(Me)
        LimpiarCampos(Me.Controls)
        Me.idTipoAgrupacionSeleccionada = 0
        Me.txtNombreAgrupacion.Focus()
        MostrarAgrupacion("[id agrupacion]")
    End Sub

    Private Sub MostrarAgrupacion(Orden As String)
        Dim Rs As SqlDataReader
        Me.lstAgrupacion.Items.Clear()
        Sql = "select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY [id agrupacion] desc"
        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        Rs.Read()

        Dim espaciosIDmax As Integer
        If Rs.HasRows Then
            espaciosIDmax = Rs(0).ToString().Length
        Else
            espaciosIDmax = 1
        End If
        Rs.Close()


        Sql = $"select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY {Orden}"

        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Me.lstAgrupacion.Items.Add($"{Space(espaciosIDmax - Rs(Rs.GetOrdinal("id agrupacion")).ToString.Length)}{Rs(Rs.GetOrdinal("id agrupacion"))} {Rs(Rs.GetOrdinal("nom agrupacion"))}")
        End While
        Rs.Close()
    End Sub

    Private Sub Guardar()
        On Error GoTo Errores
        Dim mensaje As String = ""
        If _CamposVaciosAgrupacion(Me, mensaje) Then
            MsgBox(mensaje, vbCritical, "Error")
            Exit Sub
        End If
        Dim Rs As SqlDataReader
        Sql = $"select * from Agrupacion with (nolock) WHERE [nom agrupacion] = 'ngi'+'{txtNombreAgrupacion.Text.Trim}' OR [nom agrupacion] = '{txtNombreAgrupacion.Text.Trim}' "
        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()

        If Rs.HasRows Then
            MsgBox("No se permite guardar agrupaciones repetidas", vbCritical)
            Me.txtNombreAgrupacion.Focus()
            txtNombreAgrupacion.BackColor = Color.LightPink
            Rs.Close()
            Exit Sub
        End If
        Rs.Close()

        Sql = $"INSERT INTO Agrupacion ([nom agrupacion]) VALUES ('ngi'+'{txtNombreAgrupacion.Text.Trim}')"
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
            If IdTipoAgrupEnUso(idTipoAgrupacionSeleccionada, Dao) Then
                MsgBox("El ID del registro seleccionado se encuentra en uso, no se puede eliminar, solo modificar", vbCritical, "Verifique")
                lstAgrupacion.Focus()
                Exit Sub
            End If
            Sql = $"DELETE FROM Agrupacion WHERE [id agrupacion]= {idTipoAgrupacionSeleccionada}"
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
        Dim mensaje As String = ""
        If _CamposVaciosAgrupacion(Me, mensaje) Then
            MsgBox(mensaje, vbCritical, "Error")
            Limpiar()
            Exit Sub
        End If

        Sql = $"UPDATE Agrupacion SET [nom agrupacion]='{txtNombreAgrupacion.Text.Trim}' WHERE [id agrupacion]= {idTipoAgrupacionSeleccionada}"
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

    Private Sub lstAgrupacion_DoubleClick(sender As Object, e As EventArgs) Handles lstAgrupacion.DoubleClick
        If Me.lstAgrupacion.SelectedItem <> "" Then
            Dim Rs As SqlDataReader
            Dim aver = Val(Mid(Me.lstAgrupacion.SelectedItem, 1, Me.lstAgrupacion.SelectedItem.ToString.IndexOf("n")))
            Sql = $"select * from Agrupacion WHERE [id agrupacion]= {Val(Mid(Me.lstAgrupacion.SelectedItem, 1, Me.lstAgrupacion.SelectedItem.ToString.IndexOf("n")))}"
            Instruccion = New SqlCommand(Sql, Dao)
            Rs = Instruccion.ExecuteReader()
            While Rs.Read
                Me.idTipoAgrupacionSeleccionada = Rs(Rs.GetOrdinal("id agrupacion"))
                Me.txtNombreAgrupacion.Text = Rs(Rs.GetOrdinal("nom agrupacion"))
            End While
            Rs.Close()
            SetearHabilitacionBotonesABMSeleccionar(Me)
        Else
            MsgBox("No se seleccionó ningun item", vbCritical, "Verifique")
            Me.lstAgrupacion.Focus()
        End If
    End Sub

    Private Sub frmAgrupacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMenuPrincipal.Show()
    End Sub

    Private Sub lblId_Click(sender As Object, e As EventArgs) Handles lblId.Click
        If ordenId Then
            MostrarAgrupacion("[id agrupacion]")
            ordenId = Not ordenId
        Else
            MostrarAgrupacion("[id agrupacion] desc")
            ordenId = Not ordenId
        End If
    End Sub

    Private Sub lblAgrupacion_Click(sender As Object, e As EventArgs) Handles lblAgrupacion.Click
        If ordenAgrup Then
            MostrarAgrupacion("[nom agrupacion]")
            ordenAgrup = Not ordenAgrup
        Else
            MostrarAgrupacion("[nom agrupacion] desc")
            ordenAgrup = Not ordenAgrup
        End If
    End Sub






#End Region

End Class