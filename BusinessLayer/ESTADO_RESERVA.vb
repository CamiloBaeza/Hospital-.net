Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class ESTADO_RESERVA


        Public Shared Function Buscar(Optional ByVal vERES_ID As Int32? = Nothing, _
           Optional ByVal vERES_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.ESTADO_RESERVA)
            Try
                Buscar = DataLayer.DAL.ESTADO_RESERVA.Buscar(vERES_ID:=vERES_ID, vERES_DESCRIPCION:=vERES_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vESTADO_RESERVA As EntityLayer.EL.ESTADO_RESERVA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.ESTADO_RESERVA.Guardar(vESTADO_RESERVA:=vESTADO_RESERVA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vESTADO_RESERVA As EntityLayer.EL.ESTADO_RESERVA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.ESTADO_RESERVA.Eliminar(vESTADO_RESERVA:=vESTADO_RESERVA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vERES_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.ESTADO_RESERVA
            Dim vL As List(Of EntityLayer.EL.ESTADO_RESERVA)
            vL = Buscar(vERES_ID:=vERES_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

