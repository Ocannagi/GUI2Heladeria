Imports System.Data.SqlClient

Public Class frmMenuPrincipal
    Friend espaciosAgrupacion = frmAgrupacion.espaciosNombreAgrupacion
    Friend espaciosCantidad = frmMovimientos.espaciosCantidad + 1
    Friend espaciosResultado = 25
    Dim ordenAgrupacion As Boolean = False
    Dim ordenCantidad As Boolean = True
    Dim ordenResultado As Boolean = True


    Private Sub ArticulosABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulosABMToolStripMenuItem.Click
        Me.Hide()
        frmArticulos.Show()
    End Sub

    Private Sub AgrupacionABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgrupacionABMToolStripMenuItem.Click
        Me.Hide()
        frmAgrupacion.Show()
    End Sub

    Private Sub MovimientosABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosABMToolStripMenuItem.Click
        Me.Hide()
        frmMovimientos.Show()
        frmMovimientos.dtpFecha.Focus()
    End Sub

    Private Sub TipoMovimientoABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoMovimientoABMToolStripMenuItem.Click
        Me.Hide()
        frmTiposMovimiento.Show()
    End Sub

    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dao_ConectarBase()
        Me.statusCon.Text = ModDao.statusCon
        Me.statusBase.Text = Base
        AgregarColumnEsPositivo()
        CargarListaMenuPrincipal("agrupacion")
    End Sub

    Private Sub AgregarColumnEsPositivo()
        On Error GoTo Errores
        Sql = $"select * FROM INFORMATION_SCHEMA.COLUMNS AS c1 where c1.column_name = 'esPositivo' and c1.table_name = 'tipomovi'"
        Instruccion = New SqlCommand(Sql, Dao)
        Dim Rs As SqlDataReader
        Rs = Instruccion.ExecuteReader()
        If Not Rs.HasRows Then
            MsgBox("Eliminaron la columna esPositivo de la tabla tipomovi", vbCritical, "Verifique")
            Sql = "ALTER TABLE tipomovi ADD esPositivo bit DEFAULT NULL"
            Instruccion = New SqlCommand(Sql, Dao)
            Instruccion.ExecuteNonQuery()
        End If
        Rs.Close()
        Exit Sub
Errores:
        Select Case Err.Number
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub

    Friend Sub CargarListaMenuPrincipal(Orden As String)
        lstBalance.Items.Clear()

        On Error GoTo Errores
        Sql = $"IF OBJECT_ID('tempdb..#positivos') IS NOT NULL DROP TABLE #positivos
                IF OBJECT_ID('tempdb..#negativos') IS NOT NULL DROP TABLE #negativos
                CREATE TABLE #positivos (agrupacion nvarchar(50) not null, cantidad int not null, resultado float not null)
                INSERT INTO #positivos (agrupacion,cantidad,resultado)
                    SELECT  ag.[nom agrupacion],
                            SUM(mm.[can movimiento]),
                            SUM(mm.[can movimiento] * mm.[pre movimiento])
                    FROM Agrupacion ag with (nolock)
                        INNER JOIN Articulo ar ON ag.[id agrupacion] = ar.[id agrupacion]
                        INNER JOIN Movimiento mm ON mm.[id articulo] = ar.[id articulo]
                        INNER JOIN Tipomovi tm ON mm.[id tipomovi] = tm.[id tipomovi]
                    WHERE [nom agrupacion] like 'ngi%' AND tm.[nom tipomovi] like 'ngi%' AND tm.esPositivo = 1
                    GROUP BY ag.[nom agrupacion] ORDER BY [nom agrupacion]
                CREATE TABLE #negativos (agrupacion nvarchar(50) not null, cantidad int not null, resultado float not null)
                INSERT INTO #negativos (agrupacion,cantidad,resultado)
                    SELECT  ag.[nom agrupacion],
                            SUM(mm.[can movimiento]),
                            SUM(mm.[can movimiento] * mm.[pre movimiento])
                    FROM Agrupacion ag with (nolock)
                        INNER JOIN Articulo ar ON ag.[id agrupacion] = ar.[id agrupacion]
                        INNER JOIN Movimiento mm ON mm.[id articulo] = ar.[id articulo]
                        INNER JOIN Tipomovi tm ON mm.[id tipomovi] = tm.[id tipomovi]
                    WHERE [nom agrupacion] like 'ngi%' AND tm.[nom tipomovi] like 'ngi%' AND tm.esPositivo = 0
                    GROUP BY ag.[nom agrupacion] ORDER BY [nom agrupacion]


                SELECT  ISNULL(pp.agrupacion,nn.agrupacion) AS agrupacion,
                        ISNULL(pp.cantidad,0) - ISNULL(nn.cantidad,0) AS cantidad,
                        ISNULL(pp.resultado,0) - ISNULL(nn.resultado,0) AS resultado
                FROM #positivos pp
                    FULL JOIN #negativos nn ON pp.agrupacion = nn.agrupacion
                ORDER BY {Orden}

                SELECT SUM(ISNULL(pp.resultado,0) - ISNULL(nn.resultado,0)) AS resultado
                FROM #positivos pp
                    FULL JOIN #negativos nn ON pp.agrupacion = nn.agrupacion

                DROP TABLE #positivos DROP TABLE #negativos"
        Dim DataAdap As New SqlDataAdapter(Sql, Dao)
        Dim dataTable As New DataSet

        DataAdap.Fill(dataTable)

        For Each row As DataRow In dataTable.Tables(0).Rows
            Dim dinero As Double = Val(row("resultado").ToString.Replace(",", "."))
            Dim dineroFormato = FormatCurrency(dinero, 2)


            lstBalance.Items.Add($"{row("agrupacion")}{Space(espaciosAgrupacion - row("agrupacion").ToString.Length + 1)}{Space(espaciosCantidad - row("cantidad").ToString.Length)}{row("cantidad")}{Space(espaciosResultado - dineroFormato.Length)}{dineroFormato}")
        Next

        lblImporteTotal.Text = FormatCurrency(dataTable.Tables(1).Rows(0).Item(0)).Replace(",", ".")

        Exit Sub
Errores:
        Select Case Err.Number
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub

    Private Sub frmMenuPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dao_CerrarBase()
    End Sub

    Private Sub lblAgrupacion_Click(sender As Object, e As EventArgs) Handles lblAgrupacion.Click

        If ordenAgrupacion Then
            CargarListaMenuPrincipal("agrupacion")
            ordenAgrupacion = Not ordenAgrupacion
        Else
            CargarListaMenuPrincipal("agrupacion desc")
            ordenAgrupacion = Not ordenAgrupacion
        End If
    End Sub

    Private Sub lblCantidad_Click(sender As Object, e As EventArgs) Handles lblCantidad.Click
        If ordenCantidad Then
            CargarListaMenuPrincipal("cantidad")
            ordenCantidad = Not ordenCantidad
        Else
            CargarListaMenuPrincipal("cantidad desc")
            ordenCantidad = Not ordenCantidad
        End If
    End Sub

    Private Sub lblResultado_Click(sender As Object, e As EventArgs) Handles lblResultado.Click
        If ordenResultado Then
            CargarListaMenuPrincipal("resultado")
            ordenResultado = Not ordenResultado
        Else
            CargarListaMenuPrincipal("resultado desc")
            ordenResultado = Not ordenResultado
        End If
    End Sub

    Private Sub frmMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MsgBox("¿Está seguro que desea salir del programa?", vbYesNo) = vbNo Then
            e.Cancel = True
        End If
    End Sub
End Class
