Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class TIPO_ATENCION_HORARIO


        Public Shared Function Buscar(Optional ByVal vTIAT_ID As Int32? = Nothing, _
                                      Optional ByVal vHORD_ID As Int32? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.TIPO_ATENCION_HORARIO)
            Try
                Buscar = DataLayer.DAL.TIPO_ATENCION_HORARIO.Buscar(vTIAT_ID:=vTIAT_ID, vHORD_ID:=vHORD_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarTipoAtencionHorario(Optional ByVal vTIAT_ID As Int32? = Nothing, _
                                      Optional ByVal vHORD_ID As Int32? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.TIPO_ATENCION)
            Try
                BuscarTipoAtencionHorario = DataLayer.DAL.TIPO_ATENCION_HORARIO.BuscarTipoAtencionHorario(vTIAT_ID:=vTIAT_ID, vHORD_ID:=vHORD_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Sub Guardar(ByVal vTIPO_ATENCION_HORARIO As EntityLayer.EL.TIPO_ATENCION_HORARIO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.TIPO_ATENCION_HORARIO.Guardar(vTIPO_ATENCION_HORARIO:=vTIPO_ATENCION_HORARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vTIPO_ATENCION_HORARIO As EntityLayer.EL.TIPO_ATENCION_HORARIO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.TIPO_ATENCION_HORARIO.Eliminar(vTIPO_ATENCION_HORARIO:=vTIPO_ATENCION_HORARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vTIAT_ID As Int32? = Nothing, _
       Optional ByVal vHORD_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.TIPO_ATENCION_HORARIO
            Dim vL As List(Of EntityLayer.EL.TIPO_ATENCION_HORARIO)
            vL = Buscar(vTIAT_ID:=vTIAT_ID, _
           vHORD_ID:=vHORD_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

