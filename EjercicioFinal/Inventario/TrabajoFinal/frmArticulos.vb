Imports System.Data.SqlClient

Public Class frmArticulos
    Private Sub frmArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CargarComboAgrupacion()
    End Sub



    'Private Sub CargarComboAgrupacion()
    '    Sql = "select * from Agrupacion with (nolock) WHERE [nom agrupacion] like 'ngi%' ORDER BY [nom agrupacion]"
    '    Dim DataAdap As New SqlDataAdapter(Sql, Dao)
    '    Dim dataSet As New DataSet

    '    DataAdap.Fill(dataSet)

    '    cmbAgrupacion.DataSource = dataSet.Tables(0)
    '    cmbAgrupacion.DisplayMember = "id agrupacion"




    'End Sub
End Class