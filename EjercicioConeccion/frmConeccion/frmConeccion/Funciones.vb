Imports System.Data.SqlClient

Module Funciones
    Public DaoCon As SqlConnection

    Sub ConectarBase()
        On Error GoTo Errores
        Dim Servidor As String = "estack.ddns.net"
        Dim Base As String = "UCES01"
        DaoCon = New SqlConnection("server=" & Servidor & ";database=" & Base & ";User ID=sa;Password=Ita1821!")
        DaoCon.Open()
        MsgBox("Conexión Establecida", vbInformation)
        Exit Sub
Errores:
        Select Case Err.Number
            Case 5
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"), vbInformation)
                MsgBox("El programa se Cerrará", vbCritical)
                End
            Case Else
                MsgBox(Err.Description & " (" & Format(Err.Number, "00000)"))
                Exit Sub
        End Select
    End Sub
End Module
