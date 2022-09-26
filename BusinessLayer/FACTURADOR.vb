Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class FACTURADOR

        Public Shared Function Buscar(Optional ByVal vFACT_ID As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FACTURADOR)
            Try
                Buscar = DataLayer.DAL.FACTURADOR.Buscar(vFACT_ID:=vFACT_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function
    End Class
End Namespace