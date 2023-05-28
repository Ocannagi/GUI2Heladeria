Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Net

Public Class frmArticulos

    Private idArticuloSeleccionado As Integer = 0
    Friend espaciosNomArticulo As Integer = 40
    Friend espaciosNomAgrupacion As Integer = 30
    Friend espaciosEnteros As Integer = 6
    Friend espaciosDecimales As Integer = 2


    Private Sub frmArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNomArticulo.MaxLength = espaciosNomArticulo
        txtPrecio.MaxLength = espaciosEnteros + espaciosDecimales + 1
        Dao_ConectarBase()
        CargarComboAgrupacion()
        Limpiar()
        Me.txtNomArticulo.Focus()

    End Sub

    Private Sub frmArticulos_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dao_CerrarBase()
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
    Private Sub txtNomArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomArticulo.KeyPress
        If SuperaMaxLength(sender, e, espaciosNomAgrupacion) Or Not EsCaracterLetraEspacioNumeroPunto(sender, e) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs)
        CambiarComa(sender, e)

        If SuperaMaxLength(sender, e, espaciosEnteros + espaciosDecimales + 1) Or HayDoblePunto(sender, e) Or Not EsCaracterNumeroPunto(sender, e) Or SuperaCantEnteros(sender, e, espaciosEnteros) Or SuperaCantDecimales(sender, e, espaciosDecimales) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs)
        AgregarCeroPrePunto(sender)
    End Sub

#End Region

    Private Sub CargarComboAgrupacion()
        Sql = "select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY [nom agrupacion]"
        Dim DataAdap As New SqlDataAdapter(Sql, Dao)
        Dim dataSet As New DataSet


        DataAdap.Fill(dataSet)
        Dim row = dataSet.Tables(0).NewRow()
        row(0) = 0
        row(1) = "-- Seleccione --"
        dataSet.Tables(0).Rows.InsertAt(row, 0)
        cmbAgrupacion.DataSource = dataSet.Tables(0)
        cmbAgrupacion.DisplayMember = "nom agrupacion"
        cmbAgrupacion.ValueMember = "nom agrupacion"
    End Sub

    Private Sub Limpiar()
        SetearHabilitacionBotonesABMLimpiar(Me)
        LimpiarCampos(Me.Controls)
        Me.idArticuloSeleccionado = 0
        Me.txtNomArticulo.Focus()
        MostrarArticulo(0)
    End Sub

    Private Sub MostrarArticulo(Orden As Integer)
        Dim Rs As SqlDataReader
        Me.lstArticulos.Items.Clear()
        Sql = "select aa.[id articulo], aa.[nom articulo], ag.[nom agrupacion], aa.[pco articulo] from Articulo aa with (nolock) INNER JOIN Agrupacion ag ON aa.[id agrupacion] = ag.[id agrupacion] WHERE [nom articulo] like 'ngi%' ORDER BY [id articulo] desc"
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

        Select Case Orden
            Case 0
                Sql = "select aa.[id articulo], aa.[nom articulo], ag.[nom agrupacion], aa.[pco articulo] from Articulo aa with (nolock) INNER JOIN Agrupacion ag ON aa.[id agrupacion] = ag.[id agrupacion] WHERE [nom articulo] like 'ngi%' ORDER BY [id articulo]"
            Case 1
                Sql = "select aa.[id articulo], aa.[nom articulo], ag.[nom agrupacion], aa.[pco articulo] from Articulo aa with (nolock) INNER JOIN Agrupacion ag ON aa.[id agrupacion] = ag.[id agrupacion] WHERE [nom articulo] like 'ngi%' ORDER BY [nom articulo]"
        End Select

        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Dim idArt = Rs(Rs.GetOrdinal("id articulo"))
            Dim espPosIDArt = Space(espaciosIDmax - Rs(0).ToString.Length + 1)
            Dim nomArt = Rs(Rs.GetOrdinal("nom articulo"))
            Dim espPosNomArt = Space(espaciosNomArticulo - Rs(Rs.GetOrdinal("nom articulo")).ToString.Length + 1)
            Dim nomAgr = Rs(Rs.GetOrdinal("nom agrupacion"))
            Dim espPosNomAgr = Space(espaciosNomAgrupacion - Rs(Rs.GetOrdinal("nom agrupacion")).ToString.Length + 1)
            Dim prec = Rs(Rs.GetOrdinal("pco articulo")).ToString.Replace(",", ".")



            Me.lstArticulos.Items.Add($"{idArt}{espPosIDArt}{nomArt}{espPosNomArt}{nomAgr}{espPosNomAgr}{prec}")
        End While
        Rs.Close()
        Me.txtNomArticulo.Focus()
    End Sub

    Private Sub Guardar()
        On Error GoTo Errores
        If Me.txtNomArticulo.Text = "" Then
            MsgBox("El Nombre de Articulo es requerido", vbCritical)
            Me.txtNomArticulo.Focus()
            Exit Sub
        End If
        If Me.txtPrecio.Text = "" Then
            MsgBox("El Precio del Artículo es requerido", vbCritical)
            Me.txtPrecio.Focus()
            Exit Sub
        End If
        If Me.cmbAgrupacion.SelectedIndex() = 0 Or Me.cmbAgrupacion.SelectedIndex() = -1 Then
            MsgBox("El Tipo de Agrupación es requerido", vbCritical)
            Me.cmbAgrupacion.Focus()
            Exit Sub
        End If
        Dim idAgrup As Integer = cmbAgrupacion.SelectedItem(0)
        Dim precio = txtPrecio.Text
        Dim ngi As String = "ngi"

        Sql = $"INSERT INTO articulo ([nom articulo],[id agrupacion],[pco articulo]) VALUES('{ngi & txtNomArticulo.Text.Trim}',{idAgrup},{precio})"

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
            Sql = $"DELETE FROM Articulo WHERE [id articulo]= {idArticuloSeleccionado}"
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
        If Me.txtNomArticulo.Text = "" Then
            MsgBox("El Nombre de Articulo es requerido", vbCritical)
            Me.txtNomArticulo.Focus()
            Exit Sub
        End If
        If Me.txtPrecio.Text = "" Then
            MsgBox("El Precio del Artículo es requerido", vbCritical)
            Me.txtPrecio.Focus()
            Exit Sub
        End If
        If Me.cmbAgrupacion.SelectedIndex() = 0 Or Me.cmbAgrupacion.SelectedIndex() = -1 Then
            MsgBox("El Tipo de Agrupación es requerido", vbCritical)
            Me.cmbAgrupacion.Focus()
            Exit Sub
        End If

        Sql = $"UPDATE Articulo SET [nom articulo]='{txtNomArticulo.Text.Trim}', [id agrupacion]={cmbAgrupacion.SelectedItem(0)}, [pco articulo]={txtPrecio.Text.Trim} WHERE [id articulo]= {idArticuloSeleccionado}"
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

    Private Sub lstArticulos_DoubleClick(sender As Object, e As EventArgs) Handles lstArticulos.DoubleClick
        If Me.lstArticulos.SelectedItem <> "" Then
            Dim Rs As SqlDataReader
            Sql = $"select aa.[id articulo], aa.[nom articulo],ag.[nom agrupacion], aa.[pco articulo] from Articulo aa with (nolock) INNER JOIN Agrupacion ag ON aa.[id agrupacion] = ag.[id agrupacion] WHERE [id articulo]= {Val(Mid(Me.lstArticulos.SelectedItem, 1, Me.lstArticulos.SelectedItem.ToString.IndexOf(" ") + 1))}"
            Instruccion = New SqlCommand(Sql, Dao)
            Rs = Instruccion.ExecuteReader()
            While Rs.Read
                Me.idArticuloSeleccionado = Rs(Rs.GetOrdinal("id articulo"))
                Me.txtNomArticulo.Text = Rs(Rs.GetOrdinal("nom articulo"))
                Me.txtPrecio.Text = Rs(Rs.GetOrdinal("pco articulo")).ToString.Replace(",", ".")
                Me.cmbAgrupacion.SelectedValue = Rs(Rs.GetOrdinal("nom agrupacion"))

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
            Me.lstArticulos.Focus()
        End If
    End Sub


End Class