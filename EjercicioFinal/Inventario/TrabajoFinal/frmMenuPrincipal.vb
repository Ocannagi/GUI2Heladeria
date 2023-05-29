Imports System.Data.SqlClient

Public Class frmMenuPrincipal
    Friend espaciosAgrupacion = frmAgrupacion.espaciosNombreAgrupacion
    Friend espaciosCantidad = frmMovimientos.espaciosCantidad + 1
    Friend espaciosResultado = 23


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
    End Sub

    Private Sub TipoMovimientoABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoMovimientoABMToolStripMenuItem.Click
        Me.Hide()
        frmTiposMovimiento.Show()
    End Sub

    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dao_ConectarBase()
        AgregarColumnEsPositivo()
        CargarListaMenuPrincipal()
    End Sub

    Private Sub AgregarColumnEsPositivo()
        On Error GoTo Errores
        Sql = $"select * FROM INFORMATION_SCHEMA.COLUMNS AS c1 where c1.column_name = 'esPositivo' and c1.table_name = 'tipomovi'"
        Instruccion = New SqlCommand(Sql, Dao)
        Dim Rs As SqlDataReader
        Rs = Instruccion.ExecuteReader()
        If Not Rs.HasRows Then
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

    Friend Sub CargarListaMenuPrincipal()
        lstBalance.Items.Clear()
        On Error GoTo Errores
        Sql = "IF OBJECT_ID('tempdb..#positivos') IS NOT NULL DROP TABLE #positivos
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
                    WHERE [nom agrupacion] like 'ngi%' AND tm.esPositivo = 1
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
                    WHERE [nom agrupacion] like 'ngi%' AND tm.esPositivo = 0
                    GROUP BY ag.[nom agrupacion] ORDER BY [nom agrupacion]
                SELECT  ISNULL(pp.agrupacion,nn.agrupacion) AS agrupacion,
                        ISNULL(pp.cantidad,0) - ISNULL(nn.cantidad,0) AS cantidad,
                        ISNULL(pp.resultado,0) - ISNULL(nn.resultado,0) AS resultado
                FROM #positivos pp
                    FULL JOIN #negativos nn ON pp.agrupacion = nn.agrupacion
                ORDER BY agrupacion
                DROP TABLE #positivos DROP TABLE #negativos"
        Dim DataAdap As New SqlDataAdapter(Sql, Dao)
        Dim dataTable As New DataTable

        DataAdap.Fill(dataTable)

        For Each row As DataRow In dataTable.Rows
            lstBalance.Items.Add($"{row("agrupacion")}{Space(espaciosAgrupacion - row("agrupacion").ToString.Length + 1)}{Space(espaciosCantidad - row("cantidad").ToString.Length)}{row("cantidad")}{Space(espaciosResultado - row("resultado").ToString.Length)}{row("resultado")}")
        Next
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
End Class
