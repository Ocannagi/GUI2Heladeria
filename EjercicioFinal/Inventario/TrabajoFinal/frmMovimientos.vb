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


    Friend espaciosTipoMovi As Integer = frmTiposMovimiento.espaciosCodTipoMov
    Friend espaciosFecha As Integer = 10
    Friend espaciosArticulo As Integer = frmArticulos.espaciosNomArticulo
    Friend espaciosCantidad As Integer = 9
    Friend espaciosPrecioMov As Integer = frmArticulos.espaciosEnteros + frmArticulos.espaciosDecimales + 1
    Friend espaciosObs As Integer = 250

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
        MostrarMovimiento(0)
    End Sub

    Private Sub MostrarMovimiento(Orden As Integer)
        Dim Rs As SqlDataReader
        Me.lstMovimientos.Items.Clear()
        Sql = "select mm.[id movimiento], tm.[tip tipomovi], aa.[nom articulo], mm.[Fec movimiento], mm.[can movimiento], mm.[pre movimiento], mm.[obs movimiento] from Movimiento mm with (nolock) INNER JOIN Tipomovi tm on mm.[id tipomovi] = tm.[id tipomovi] INNER JOIN Articulo aa on mm.[id articulo] = aa.[id articulo] WHERE [nom articulo] like 'ngi%' ORDER BY [id movimiento] desc"
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
                Sql = "select mm.[id movimiento], tm.[tip tipomovi], aa.[nom articulo], mm.[Fec movimiento], mm.[can movimiento], mm.[pre movimiento], mm.[obs movimiento] from Movimiento mm with (nolock) INNER JOIN Tipomovi tm on mm.[id tipomovi] = tm.[id tipomovi] INNER JOIN Articulo aa on mm.[id articulo] = aa.[id articulo] WHERE [nom articulo] like 'ngi%' ORDER BY [id movimiento]"
            Case 1
                Sql = "select mm.[id movimiento], tm.[tip tipomovi], aa.[nom articulo], mm.[Fec movimiento], mm.[can movimiento], mm.[pre movimiento], mm.[obs movimiento] from Movimiento mm with (nolock) INNER JOIN Tipomovi tm on mm.[id tipomovi] = tm.[id tipomovi] INNER JOIN Articulo aa on mm.[id articulo] = aa.[id articulo] WHERE [nom articulo] like 'ngi%' ORDER BY [Fec movimiento]"
        End Select

        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        While Rs.Read
            Dim idMov = Rs(Rs.GetOrdinal("id movimiento"))
            Dim espPosIDMov = Space(espaciosIDmax - Rs(0).ToString.Length + 1)
            Dim codTipoMovi = Rs(Rs.GetOrdinal("tip tipomovi"))
            Dim espPosCodTipoMovi = Space(espaciosTipoMovi - Rs(Rs.GetOrdinal("tip tipomovi")).ToString.Length + 1)
            Dim nomArt = Rs(Rs.GetOrdinal("nom articulo"))
            Dim espPosNomArt = Space(espaciosArticulo - Rs(Rs.GetOrdinal("nom articulo")).ToString.Length + 1)
            Dim fechaMov = CType(Rs(Rs.GetOrdinal("Fec movimiento")), Date).ToShortDateString
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
        If Me.txtCodArt.Text = "" Then
            MsgBox("El Nombre de Articulo es requerido", vbCritical)
            Me.cmbArticulo.Focus()
            Exit Sub
        End If
        If Me.cmbArticulo.SelectedIndex() = 0 Or cmbArticulo.SelectedIndex() = -1 Then
            MsgBox("El Nombre del Artículo es requerido", vbCritical)
            Me.cmbArticulo.Focus()
            Exit Sub
        End If
        If txtCantidad.Text = "" Then
            MsgBox("La Cantidad de Articulos es requerida", vbCritical)
            Me.txtCantidad.Focus()
            Exit Sub
        End If
        If Me.cmbTipoMov.SelectedIndex() = 0 Or Me.cmbTipoMov.SelectedIndex() = -1 Then
            MsgBox("El Tipo de Movimiento es requerido", vbCritical)
            Me.cmbTipoMov.Focus()
            Exit Sub
        End If
        If txtObs.Text = "" Or txtObs.Text.Length < 4 Then
            MsgBox("Completar la observación es requerido (al menos 4 caracteres)", vbCritical)
            Me.txtObs.Focus()
            Exit Sub
        End If

        Dim idTipoMovi As Integer = cmbTipoMov.SelectedItem(0)
        Dim idArt As Integer = cmbArticulo.SelectedItem(0)
        Dim fechaString = String.Format(dtpFecha.Value.ToShortDateString(), "dd/MM/yyyy")
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
        txtCodArt.Text = CType(sender, ComboBox).SelectedItem(0)
    End Sub

    Private Sub tsLimpiar_Click(sender As Object, e As EventArgs) Handles tsLimpiar.Click
        Limpiar()
    End Sub

    Private Sub tsGuardar_Click(sender As Object, e As EventArgs) Handles tsGuardar.Click
        Guardar()
    End Sub

    Private Sub frmMovimientos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMenuPrincipal.CargarListaMenuPrincipal(0)
        frmMenuPrincipal.Show()
    End Sub

End Class