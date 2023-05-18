Imports System.Data.SqlClient

Public Class frmAgrupacion
    Friend espaciosNombreAgrupacion As Integer = 50
    Friend idTipoAgrupacionSeleccionada = 0

    Private Sub frmAgrupacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dao_ConectarBase()
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

    Private Sub tsModificar_Click(sender As Object, e As EventArgs) Handles tsModificar.Click
        Modificar()
    End Sub


#Region "VALIDACIÓN CAMPOS"
    Private Sub txtNombreAgrupacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreAgrupacion.KeyPress
        If SuperaMaxLength(sender, e, espaciosNombreAgrupacion) Or Not EsCaracterLetraEspacio(sender, e) Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "RUTINAS BOTONES"

    Private Sub Limpiar()
        SetearHabilitacionBotonesABMLimpiar(Me)
        LimpiarCampos(Me.Controls)
        Me.idTipoAgrupacionSeleccionada = 0
        Me.txtNombreAgrupacion.Focus()
        MostrarAgrupacion(0)
    End Sub

    Private Sub MostrarAgrupacion(Orden As Integer)
        Dim Rs As SqlDataReader
        Me.lstAgrupacion.Items.Clear()
        Sql = "select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY [nom agrupacion]"

        Select Case Orden
            Case 0
                Sql = "select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY [nom agrupacion]"
            Case 1
                Sql = "select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY [id agrupacion]"
        End Select


        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Me.lstAgrupacion.Items.Add($"{Rs(Rs.GetOrdinal("id agrupacion"))} {Rs(Rs.GetOrdinal("nom agrupacion"))}")
        End While
        Rs.Close()
    End Sub

    Private Sub Guardar()
        On Error GoTo Errores
        If Me.txtNombreAgrupacion.Text = "" Then
            MsgBox("El nombre de la agrupación es requerido", vbCritical)
            Me.txtNombreAgrupacion.Focus()
            Exit Sub
        End If
        Dim Rs As SqlDataReader
        Sql = $"select * from Agrupacion with (nolock) WHERE [nom agrupacion] = 'ngi'+'{txtNombreAgrupacion.Text.Trim}' OR [nom agrupacion] = '{txtNombreAgrupacion.Text.Trim}' "
        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()

        If Rs.HasRows Then
            MsgBox("No se permite guardar agrupaciones repetidas", vbCritical)
            Me.txtNombreAgrupacion.Focus()
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
        If Me.txtNombreAgrupacion.Text = "" Then
            MsgBox("El nombre de la agrupación es requerido", vbCritical)
            Me.txtNombreAgrupacion.Focus()
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
            Sql = $"select * from Agrupacion WHERE [id agrupacion]= {Val(Mid(Me.lstAgrupacion.SelectedItem, 1, Me.lstAgrupacion.SelectedItem.ToString.IndexOf(" ") + 1))}"
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

#End Region

End Class