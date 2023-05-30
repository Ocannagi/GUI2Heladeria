Imports System.Data.SqlClient

Module ModDao
    Public Dao As SqlConnection
    Public Sql As String ' Cadena de SQL SERVER
    Public Instruccion As SqlCommand '

    Friend statusCon As String = "Desconectada"
    Friend Base As String = ""

    Sub Dao_ConectarBase()
        On Error GoTo Errores
        Dim Servidor As String = "estack.ddns.net"
        Dim Base As String = "UCES04"
        Dao = New SqlConnection("server=" & Servidor & ";database=" &
       Base & ";User ID=sa;Password=Ita1821!")
        Dao.Open()
        statusCon = "Establecida"
        ModDao.Base = Base
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

    Friend Sub Dao_CerrarBase()
        If Dao.State <> 0 Then
            statusCon = "Desconectada"
            Base = ""
            Dao.Close()
            MsgBox("Conexión Cerrada", vbInformation)
        End If
    End Sub
End Module
