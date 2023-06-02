Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Net

Public Class frmArticulos

    Private idArticuloSeleccionado As Integer = 0
    Friend espaciosNomArticulo As Integer = 40
    Friend espaciosNomAgrupacion As Integer = 30
    Friend espaciosEnteros As Integer = 6
    Friend espaciosDecimales As Integer = 2
    Dim ordenId As Boolean = False
    Dim ordenArticulo = True
    Dim ordenAgrupacion = True
    Dim ordenPrecio = True


    Private Sub frmArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNomArticulo.MaxLength = espaciosNomArticulo
        txtPrecio.MaxLength = espaciosEnteros + espaciosDecimales + 1
        Me.statusBase.Text = Base
        Me.statusCon.Text = ModDao.statusCon
        CargarComboAgrupacion()
        Limpiar()
        Me.txtNomArticulo.Focus()

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

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        CambiarComa(sender, e)

        If SuperaMaxLength(sender, e, espaciosEnteros + espaciosDecimales + 1) Or HayDoblePunto(sender, e) Or Not EsCaracterNumeroPunto(sender, e) Or SuperaCantEnteros(sender, e, espaciosEnteros) Or SuperaCantDecimales(sender, e, espaciosDecimales) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        AgregarCeroPrePunto(sender)
        VerificarSiEliminoPunto(sender, espaciosEnteros)
    End Sub

    Private Sub VerificarSiEliminoPunto(sender As Object, espaciosEnteros As Integer)
        If Not sender.Text.Contains(".") And SuperaMaxLength(sender, espaciosEnteros) Then
            MsgBox("Supero la cantidad de enteros permitidos", vbCritical)
            sender.Text = ""
            sender.BackColor = Color.LightPink
        End If
    End Sub

#End Region

#Region "COLORES"
    Private Sub txtNomArticulo_Enter(sender As Object, e As EventArgs) Handles txtNomArticulo.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub txtNomArticulo_Leave(sender As Object, e As EventArgs) Handles txtNomArticulo.Leave
        sender.BackColor = Color.White
    End Sub

    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        sender.BackColor = Color.White
    End Sub

    Private Sub cmbAgrupacion_Enter(sender As Object, e As EventArgs) Handles cmbAgrupacion.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub cmbAgrupacion_Leave(sender As Object, e As EventArgs) Handles cmbAgrupacion.Leave
        sender.BackColor = Color.Gray
    End Sub

#End Region

#Region "RUTINAS"

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
        MostrarArticulo("[id articulo]")
    End Sub

    Private Sub MostrarArticulo(Orden As String)
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


        Sql = $"select aa.[id articulo], aa.[nom articulo], ag.[nom agrupacion], aa.[pco articulo] from Articulo aa with (nolock) INNER JOIN Agrupacion ag ON aa.[id agrupacion] = ag.[id agrupacion] WHERE [nom articulo] like 'ngi%' ORDER BY {Orden}"


        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Dim idArt = Rs(Rs.GetOrdinal("id articulo"))
            Dim espPreIDArt = Space(espaciosIDmax - Rs(0).ToString.Length)
            Dim nomArt = Rs(Rs.GetOrdinal("nom articulo"))
            Dim espPosNomArt = Space(espaciosNomArticulo - Rs(Rs.GetOrdinal("nom articulo")).ToString.Length + 1)
            Dim nomAgr = Rs(Rs.GetOrdinal("nom agrupacion"))
            Dim espPosNomAgr = Space(espaciosNomAgrupacion - Rs(Rs.GetOrdinal("nom agrupacion")).ToString.Length + 1)
            Dim prec = FormatCurrency(Rs(Rs.GetOrdinal("pco articulo"))).Replace(",", ".")
            Dim espPrevPrecio = Space(espaciosEnteros + espaciosDecimales + 2 + 2 - prec.Length)



            Me.lstArticulos.Items.Add($"{espPreIDArt}{idArt} {nomArt}{espPosNomArt}{nomAgr}{espPosNomAgr}{espPrevPrecio}{prec}")
        End While
        Rs.Close()
        Me.txtNomArticulo.Focus()
    End Sub

    Private Sub Guardar()
        On Error GoTo Errores
        Dim mensaje = ""
        If _CamposVaciosArticulos(Me, mensaje) Then
            MsgBox(mensaje, vbCritical, "Error")
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
            If IdArticuloEnUso(idArticuloSeleccionado, Dao) Then
                MsgBox("El ID del registro seleccionado se encuentra en uso, no se puede eliminar, solo modificar", vbCritical, "Verifique")
                lstArticulos.Focus()
                Exit Sub
            End If

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
            Sql = $"select aa.[id articulo], aa.[nom articulo],ag.[nom agrupacion], aa.[pco articulo] from Articulo aa with (nolock) INNER JOIN Agrupacion ag ON aa.[id agrupacion] = ag.[id agrupacion] WHERE [id articulo]= {Val(Me.lstArticulos.SelectedItem.ToString)}"
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

    Private Sub frmArticulos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMenuPrincipal.Show()
    End Sub

    Private Sub lblId_Click(sender As Object, e As EventArgs) Handles lblId.Click
        If ordenId Then
            MostrarArticulo("[id articulo]")
            ordenId = Not ordenId
        Else
            MostrarArticulo("[id articulo] desc")
            ordenId = Not ordenId
        End If
    End Sub

    Private Sub lblArticulo_Click(sender As Object, e As EventArgs) Handles lblArticulo.Click
        If ordenArticulo Then
            MostrarArticulo("[nom articulo]")
            ordenArticulo = Not ordenArticulo
        Else
            MostrarArticulo("[nom articulo] desc")
            ordenArticulo = Not ordenArticulo
        End If
    End Sub

    Private Sub lblAgrupacion_Click(sender As Object, e As EventArgs) Handles lblAgrupacion.Click
        If ordenAgrupacion Then
            MostrarArticulo("[nom agrupacion]")
            ordenAgrupacion = Not ordenAgrupacion
        Else
            MostrarArticulo("[nom agrupacion] desc")
            ordenAgrupacion = Not ordenAgrupacion
        End If
    End Sub

    Private Sub lblPrecio_Click(sender As Object, e As EventArgs) Handles lblPrecio.Click
        If ordenPrecio Then
            MostrarArticulo("[pco articulo]")
            ordenPrecio = Not ordenPrecio
        Else
            MostrarArticulo("[pco articulo] desc")
            ordenPrecio = Not ordenPrecio
        End If
    End Sub


#End Region

End Class