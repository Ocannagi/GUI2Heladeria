Imports System.Data.SqlClient


Module Coneccion
    Public DaoCon As SqlConnection
    Public Sql As String ' Cadena de SQL SERVER
    Public Instruccion As SqlCommand '
    Sub ConectarBase()
        On Error GoTo Errores
        Dim Servidor As String = "estack.ddns.net"
        Dim Base As String = "cosenzo"
        DaoCon = New SqlConnection("server=" & Servidor & ";database=" &
       Base & ";User ID=sa;Password=Ita1821!")
        DaoCon.Open()
        frmABMFamilia.statusCon.Text = "Establecida"
        frmABMFamilia.statusBase.Text = Base
        Exit Sub
Errores:
        Select Case Err.Number
            Case 5
                MsgBox(Err.Description & " (" & Format(Err.Number,
               "00000)"), vbInformation)
                MsgBox("El programa se Cerrará", vbCritical)
                End
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number,
               "00000)"))
                Exit Sub
        End Select
    End Sub
End Module
