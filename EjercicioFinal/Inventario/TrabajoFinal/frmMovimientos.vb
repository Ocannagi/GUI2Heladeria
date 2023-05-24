Imports System.Data.SqlClient

Public Class frmMovimientos
    Private Sub frmMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dao_ConectarBase()
        CargarComboArticulo()
        CargarComboTipoMovimiento()
        Limpiar()
        Me.dtpFecha.Focus()
    End Sub


    Friend espaciosFecha As Integer = 10
    Friend espaciosArticulo As Integer = frmArticulos.espaciosNomAgrupacion
    Friend espaciosCantidad As Integer = 9
    Friend espaciosTipoCant As Integer = frmTiposMovimiento.espaciosCodTipoMov

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
        Sql = "select aa.[id articulo], aa.[nom articulo], ag.[nom agrupacion], aa.[pco articulo] from Articulo aa with (nolock) INNER JOIN Agrupacion ag ON aa.[id agrupacion] = ag.[id agrupacion] WHERE [nom articulo] like 'ngi%' ORDER BY [id articulo] desc"
        Instruccion = New SqlCommand(Sql, Dao)
        Rs = Instruccion.ExecuteReader()
        Rs.Read()
        Dim espaciosIDmax As Integer = Rs(0).ToString().Length
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


End Class