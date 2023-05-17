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

    'Private Sub tsEliminar_Click(sender As Object, e As EventArgs) Handles tsEliminar.Click
    '    Eliminar()
    'End Sub

    'Private Sub tsModificar_Click(sender As Object, e As EventArgs) Handles tsModificar.Click
    '    Modificar()
    'End Sub



    Private Sub Limpiar()
        SetearHabilitacionBotonesABMLimpiar(Me)
        LimpiarCampos(Me.Controls)
        Me.idTipoAgrupacionSeleccionada = 0
        Me.txtNombreAgrupacion.Focus()
        MostrarAgrupacion()
    End Sub

    Private Sub MostrarAgrupacion()
        Dim Rs As SqlDataReader
        Me.lstAgrupacion.Items.Clear()
        Sql = "select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY [nom agrupacion]"

        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Me.lstAgrupacion.Items.Add($"{Rs(Rs.GetOrdinal("nom agrupacion"))}")
        End While
        Rs.Close()
    End Sub

    Private Sub Guardar()
        On Error GoTo Errores
        If Me.txtNombreAgrupacion.Text = "" Then
            MsgBox("El Código de Tipo Movimiento es requerido", vbCritical)
            Me.txtNombreAgrupacion.Focus()
            Exit Sub
        End If


        Sql = $"INSERT INTO Agrupacion ([nom agrupacion]) VALUES ('ngi'+'{txtNombreAgrupacion.Text}')"
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

End Class