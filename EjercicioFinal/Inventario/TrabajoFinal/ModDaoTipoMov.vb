Imports System.Data.SqlClient

Module ModDaoTipoMov
    Public DaoTipoMov As SqlConnection
    Public Sql As String ' Cadena de SQL SERVER
    Public Instruccion As SqlCommand '
    Sub TipoMov_ConectarBase()
        On Error GoTo Errores
        Dim Servidor As String = "estack.ddns.net"
        Dim Base As String = "UCES04"
        DaoTipoMov = New SqlConnection("server=" & Servidor & ";database=" &
       Base & ";User ID=sa;Password=Ita1821!")
        DaoTipoMov.Open()
        frmTiposMovimiento.statusCon.Text = "Establecida"
        frmTiposMovimiento.statusBase.Text = Base
        Exit Sub
Errores:
        Select Case Err.Number
            Case 5
                frmTiposMovimiento.statusCon.Text = "Perdida"
                MsgBox(Err.Description & " (" & Format(Err.Number,
               "00000)"), vbInformation)
                MsgBox("El programa se Cerrará", vbCritical)
                End
            Case Else
                frmTiposMovimiento.statusCon.Text = "Perdida"
                MsgBox(Err.Description & " (" & Format(Err.Number,
               "00000)"))
                Exit Sub
        End Select
    End Sub
End Module
