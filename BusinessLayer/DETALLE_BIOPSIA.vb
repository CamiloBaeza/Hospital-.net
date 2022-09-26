Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class DETALLE_BIOPSIA


        Public Shared Function Buscar(Optional ByVal vDEBI_ID As Int32? = Nothing, _
           Optional ByVal vMUE_ID As Int32? = Nothing, _
           Optional ByVal vDEBI_CORRELATIVO As Int32? = Nothing, _
           Optional ByVal vDEBI_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DETALLE_BIOPSIA)
            Try
                Buscar = DataLayer.DAL.DETALLE_BIOPSIA.Buscar(vDEBI_ID:=vDEBI_ID, vMUE_ID:=vMUE_ID, vDEBI_CORRELATIVO:=vDEBI_CORRELATIVO, vDEBI_DESCRIPCION:=vDEBI_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vDETALLE_BIOPSIA As EntityLayer.EL.DETALLE_BIOPSIA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.DETALLE_BIOPSIA.Guardar(vDETALLE_BIOPSIA:=vDETALLE_BIOPSIA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vDETALLE_BIOPSIA As EntityLayer.EL.DETALLE_BIOPSIA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.DETALLE_BIOPSIA.Eliminar(vDETALLE_BIOPSIA:=vDETALLE_BIOPSIA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub EliminarByMueID(ByVal vMUE_ID As Int32?, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.DETALLE_BIOPSIA.EliminarByMueID(vMUE_ID:=vMUE_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vDEBI_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.DETALLE_BIOPSIA
            Dim vL As List(Of EntityLayer.EL.DETALLE_BIOPSIA)
            vL = Buscar(vDEBI_ID:=vDEBI_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

