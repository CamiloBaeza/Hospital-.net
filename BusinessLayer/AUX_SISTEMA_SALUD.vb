Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class AUX_SISTEMA_SALUD

        Public Shared Function Buscar(Optional ByVal vPRES_ID As Decimal? = Nothing, _
            Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.AUX_SISTEMA_SALUD)
            Try
                Buscar = DataLayer.DAL.AUX_SISTEMA_SALUD.Buscar(vPRES_ID:=vPRES_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

    End Class
End Namespace
