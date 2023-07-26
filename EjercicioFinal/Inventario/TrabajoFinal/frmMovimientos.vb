Imports System.Data.SqlClient

Public Class frmMovimientos
    Private Sub frmMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dao_ConectarBase()
        Me.statusBase.Text = Base
        Me.statusCon.Text = ModDao.statusCon
        CargarComboArticulo()
        CargarComboTipoMovimiento()
        Limpiar()
        dtpFecha.Format = DateTimePickerFormat.Custom
        dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Focus()
    End Sub

    Private Sub frmMovimientos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMenuPrincipal.CargarListaMenuPrincipal("agrupacion")
        frmMenuPrincipal.Show()
    End Sub

    Private Sub frmMovimientos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If HayCamposConContenidoFrmMovimientos(Me) Then
            If MsgBox("Hay campos sin persistir. Si cierra el formulario,los datos se perderán ¿Está seguro de cerrar el formulario?", vbYesNo) = vbNo Then
                e.Cancel = True
            End If
        End If
    End Sub


    Friend espaciosTipoMovi As Integer = frmTiposMovimiento.espaciosCodTipoMov
    Friend espaciosFecha As Integer = 10
    Friend espaciosArticulo As Integer = frmArticulos.espaciosNomArticulo
    Friend espaciosCantidad As Integer = 9
    Friend espaciosPrecioMov As Integer = frmArticulos.espaciosEnteros + frmArticulos.espaciosDecimales + 1
    Friend espaciosObs As Integer = 250
    Dim errorCombo As Boolean = False

    Dim ordenID As Boolean = False
    Dim ordenCodTipoMovi As Boolean = True
    Dim ordenNomArti As Boolean = True
    Dim ordenFecha As Boolean = True
    Dim ordenCantidad As Boolean = True
    Dim ordenPrecio As Boolean = True
    Dim ordenObs As Boolean = True



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
#End Region

#Region "VALIDACIÓN CAMPOS"
    Private Sub txtCodArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArt.KeyPress
        If Not EsCaracterNumero(sender, e) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodArt_TextChanged(sender As Object, e As EventArgs) Handles txtCodArt.TextChanged

        If txtCodArt.Text <> "" Then
            For index = 0 To cmbArticulo.Items.Count() - 1
                Dim algo As DataRowView = cmbArticulo.Items(index)
                Dim otraCosa = algo.Row.ItemArray

                If otraCosa(0).ToString() = txtCodArt.Text Then
                    cmbArticulo.SelectedIndex() = index
                    errorCombo = False
                    Exit Sub
                End If
            Next
        End If

        errorCombo = True
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If SuperaMaxLength(sender, e, espaciosCantidad) Or Not EsCaracterNumero(sender, e) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        QuitarCeroInicial(sender)
    End Sub

    Private Sub txtObs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObs.KeyPress
        If SuperaMaxLength(sender, e, espaciosObs) Or Not EsCaracterLetraEspacioNumeroPunto(sender, e) Then
            e.Handled = True
        End If
    End Sub

    Private Sub AnalizarErrorCombo()
        If errorCombo Then
            txtCodArt.Text = "0"
        End If
    End Sub

    Private Sub ObsVacío()
        If txtObs.Text = "" Then
            txtObs.Text = "Sin Observaciones"
        End If
    End Sub

#End Region

#Region "FOCO"

    Private Sub dtpFecha_Enter(sender As Object, e As EventArgs) Handles dtpFecha.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub dtpFecha_Leave(sender As Object, e As EventArgs) Handles dtpFecha.Leave
        sender.BackColor = Color.White
    End Sub

    Private Sub txtCodArt_Enter(sender As Object, e As EventArgs) Handles txtCodArt.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub txtCodArt_Leave(sender As Object, e As EventArgs) Handles txtCodArt.Leave
        If errorCombo Then
            txtCodArt.Text = "0"
        End If
        sender.BackColor = Color.White
    End Sub

    Private Sub cmbArticulo_Enter(sender As Object, e As EventArgs) Handles cmbArticulo.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub cmbArticulo_Leave(sender As Object, e As EventArgs) Handles cmbArticulo.Leave
        sender.BackColor = Color.White
    End Sub

    Private Sub txtCantidad_Enter(sender As Object, e As EventArgs) Handles txtCantidad.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
        sender.BackColor = Color.White
    End Sub

    Private Sub cmbTipoMov_Enter(sender As Object, e As EventArgs) Handles cmbTipoMov.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub cmbTipoMov_Leave(sender As Object, e As EventArgs) Handles cmbTipoMov.Leave
        sender.BackColor = Color.White
    End Sub

    Private Sub txtObs_Enter(sender As Object, e As EventArgs) Handles txtObs.Enter
        sender.BackColor = Color.LightYellow
    End Sub

    Private Sub txtObs_Leave(sender As Object, e As EventArgs) Handles txtObs.Leave
        sender.BackColor = Color.White
    End Sub


#End Region

#Region "RUTINAS"

    Private Sub CargarComboArticulo()
        Sql = "select * from Articulo with (nolock) WHERE [nom articulo] like 'ngi%' ORDER BY [nom articulo]"
        Dim DataAdap As New SqlDataAdapter(Sql, Dao)
        Dim dataSet As New DataSet

        DataAdap.Fill(dataSet)
        Dim row = dataSet.Tables(0).NewRow()
        row(0) = 0
        row(1) = "-- Seleccione --"
        dataSet.Tables(0).Rows.InsertAt(row, 0)
        cmbArticulo.DataSource = dataSet.Tables(0)
        cmbArticulo.DisplayMember = "nom articulo"
        cmbArticulo.ValueMember = "nom articulo"
    End Sub


    Private Sub CargarComboTipoMovimiento()
        Sql = "select * from Tipomovi with (nolock) WHERE [nom tipomovi] like 'ngi%' ORDER BY [nom tipomovi]"
        Dim DataAdap As New SqlDataAdapter(Sql, Dao)
        Dim dataSet As New DataSet

        DataAdap.Fill(dataSet)
        Dim row = dataSet.Tables(0).NewRow()
        row(0) = 0
        row(1) = "-- Seleccione --"
        dataSet.Tables(0).Rows.InsertAt(row, 0)
        cmbTipoMov.DataSource = dataSet.Tables(0)
        cmbTipoMov.DisplayMember = "nom tipomovi"
        cmbTipoMov.ValueMember = "nom tipomovi"
    End Sub

    Private Sub Limpiar()
        SetearHabilitacionBotonesABMLimpiar(Me)
        LimpiarCampos(Me.Controls)
        Me.dtpFecha.Focus()
        MostrarMovimiento("[id movimiento]")
    End Sub

    Private Sub MostrarMovimiento(Orden As String)
        Dim Rs As SqlDataReader
        Me.lstMovimientos.Items.Clear()
        Sql = "select mm.[id movimiento], tm.[tip tipomovi], aa.[nom articulo], mm.[Fec movimiento], mm.[can movimiento], mm.[pre movimiento], mm.[obs movimiento] from Movimiento mm with (nolock) INNER JOIN Tipomovi tm on mm.[id tipomovi] = tm.[id tipomovi] INNER JOIN Articulo aa on mm.[id articulo] = aa.[id articulo] WHERE aa.[nom articulo] like 'ngi%' AND tm.[nom tipomovi] like 'ngi%' ORDER BY [id movimiento] desc"
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


        Sql = $"select mm.[id movimiento], tm.[tip tipomovi], aa.[nom articulo], mm.[Fec movimiento], mm.[can movimiento], mm.[pre movimiento], mm.[obs movimiento] from Movimiento mm with (nolock) INNER JOIN Tipomovi tm on mm.[id tipomovi] = tm.[id tipomovi] INNER JOIN Articulo aa on mm.[id articulo] = aa.[id articulo] WHERE aa.[nom articulo] like 'ngi%' AND tm.[nom tipomovi] like 'ngi%' ORDER BY {Orden}"


        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Dim idMov = Rs(Rs.GetOrdinal("id movimiento"))
            Dim espPosIDMov = Space(espaciosIDmax - Rs(0).ToString.Length + 1)
            Dim codTipoMovi = Rs(Rs.GetOrdinal("tip tipomovi"))
            Dim espPosCodTipoMovi = Space(espaciosTipoMovi - Rs(Rs.GetOrdinal("tip tipomovi")).ToString.Length + 1)
            Dim nomArt = Rs(Rs.GetOrdinal("nom articulo"))
            Dim espPosNomArt = Space(espaciosArticulo - Rs(Rs.GetOrdinal("nom articulo")).ToString.Length + 1)
            Dim fechaMov = Format(CType(Rs(Rs.GetOrdinal("Fec movimiento")), Date), "dd/MM/yyyy")
            Dim espPosFecMov = Space(1)
            Dim cantMov = Rs(Rs.GetOrdinal("can movimiento"))
            Dim espPosCantMov = Space(espaciosCantidad - Rs(Rs.GetOrdinal("can movimiento")).ToString.Length + 1)
            Dim espPreMov = Space(espaciosPrecioMov + 6 - FormatCurrency(Rs(Rs.GetOrdinal("pre movimiento"))).Length)
            Dim precMov = FormatCurrency(Rs(Rs.GetOrdinal("pre movimiento"))).Replace(",", ".")
            Dim obsmov = Rs(Rs.GetOrdinal("obs movimiento"))

            Me.lstMovimientos.Items.Add($"{idMov}{espPosIDMov}{codTipoMovi}{espPosCodTipoMovi}{nomArt}{espPosNomArt}{fechaMov}{espPosFecMov}{espPosCantMov}{cantMov} {espPreMov}{precMov} {obsmov}")
        End While
        Rs.Close()
        Me.dtpFecha.Focus()
    End Sub

    Private Sub Guardar()
        On Error GoTo Errores
        AnalizarErrorCombo()
        ObsVacío()

        Dim mensaje = ""
        If _CamposVaciosMovi(Me, mensaje) Then
            MsgBox(mensaje, vbCritical, "Error")
            Exit Sub
        End If

        Dim idTipoMovi As Integer = cmbTipoMov.SelectedItem(0)
        Dim idArt As Integer = cmbArticulo.SelectedItem(0)
        Dim fechaString = Format(dtpFecha.Value, "dd/MM/yyyy")
        Dim precio As String = cmbArticulo.SelectedItem(3).ToString().Replace(",", ".")

        Dim cantidad = Val(txtCantidad.Text)
        Dim obs = txtObs.Text


        Sql = $"INSERT INTO movimiento ([id tipomovi],[id articulo],[fec movimiento],[can movimiento],[pre movimiento],[obs movimiento]) VALUES({idTipoMovi},{idArt},'{fechaString}',{cantidad},{precio},'{obs}')"

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

    Private Sub cmbArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArticulo.SelectedIndexChanged
        txtCodArt.Text = CType(sender, ComboBox).SelectedItem("id articulo")
    End Sub

    Private Sub lblId_Click(sender As Object, e As EventArgs) Handles lblId.Click
        If ordenID Then
            MostrarMovimiento("[id movimiento]")
            ordenID = Not ordenID
        Else
            MostrarMovimiento("[id movimiento] desc")
            ordenID = Not ordenID
        End If
    End Sub

    Private Sub lblCodTipoMov_Click(sender As Object, e As EventArgs) Handles lblCodTipoMov.Click
        If ordenCodTipoMovi Then
            MostrarMovimiento("[tip tipomovi]")
            ordenCodTipoMovi = Not ordenCodTipoMovi
        Else
            MostrarMovimiento("[tip tipomovi] desc")
            ordenCodTipoMovi = Not ordenCodTipoMovi
        End If
    End Sub

    Private Sub lblArticulo_Click(sender As Object, e As EventArgs) Handles lblArticulo.Click
        If ordenNomArti Then
            MostrarMovimiento("[nom articulo]")
            ordenNomArti = Not ordenNomArti
        Else
            MostrarMovimiento("[nom articulo] desc")
            ordenNomArti = Not ordenNomArti
        End If
    End Sub

    Private Sub lblFecha_Click(sender As Object, e As EventArgs) Handles lblFecha.Click
        If ordenFecha Then
            MostrarMovimiento("[Fec movimiento]")
            ordenFecha = Not ordenFecha
        Else
            MostrarMovimiento("[Fec movimiento] desc")
            ordenFecha = Not ordenFecha
        End If
    End Sub

    Private Sub lblCantidad_Click(sender As Object, e As EventArgs) Handles lblCantidad.Click
        If ordenCantidad Then
            MostrarMovimiento("[can movimiento]")
            ordenCantidad = Not ordenCantidad
        Else
            MostrarMovimiento("[can movimiento] desc")
            ordenCantidad = Not ordenCantidad
        End If
    End Sub

    Private Sub lblPrecio_Click(sender As Object, e As EventArgs) Handles lblPrecio.Click
        If ordenPrecio Then
            MostrarMovimiento("[pre movimiento]")
            ordenPrecio = Not ordenPrecio
        Else
            MostrarMovimiento("[pre movimiento] desc")
            ordenPrecio = Not ordenPrecio
        End If
    End Sub

    Private Sub lblObs_Click(sender As Object, e As EventArgs) Handles lblObs.Click
        If ordenObs Then
            MostrarMovimiento("[obs movimiento]")
            ordenObs = Not ordenObs
        Else
            MostrarMovimiento("[obs movimiento] desc")
            ordenObs = Not ordenObs
        End If
    End Sub
#End Region


End Class