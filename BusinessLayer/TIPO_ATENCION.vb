Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class TIPO_ATENCION


        Public Shared Function Buscar(Optional ByVal vTIAT_ID As Int32? = Nothing, _
           Optional ByVal vTIAT_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.TIPO_ATENCION)
            Try
                Buscar = DataLayer.DAL.TIPO_ATENCION.Buscar(vTIAT_ID:=vTIAT_ID, vTIAT_DESCRIPCION:=vTIAT_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vTIPO_ATENCION As EntityLayer.EL.TIPO_ATENCION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.TIPO_ATENCION.Guardar(vTIPO_ATENCION:=vTIPO_ATENCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vTIPO_ATENCION As EntityLayer.EL.TIPO_ATENCION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.TIPO_ATENCION.Eliminar(vTIPO_ATENCION:=vTIPO_ATENCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vTIAT_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.TIPO_ATENCION
            Dim vL As List(Of EntityLayer.EL.TIPO_ATENCION)
            vL = Buscar(vTIAT_ID:=vTIAT_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

