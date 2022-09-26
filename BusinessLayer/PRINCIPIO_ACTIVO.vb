Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class PRINCIPIO_ACTIVO


        Public Shared Function Buscar(Optional ByVal vPPCT_ID As Int32? = Nothing, _
           Optional ByVal vPPCT_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PRINCIPIO_ACTIVO)
            Try
                Buscar = DataLayer.DAL.PRINCIPIO_ACTIVO.Buscar(vPPCT_ID:=vPPCT_ID, vPPCT_DESCRIPCION:=vPPCT_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarPrincipioActivoAutocomplete(Optional ByVal vPPCT_DESCRIPCION As String = Nothing, _
    Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PRINCIPIO_ACTIVO)
            Try
                BuscarPrincipioActivoAutocomplete = DataLayer.DAL.PRINCIPIO_ACTIVO.BuscarPrincipioActivoAutocomplete(vPPCT_DESCRIPCION:=vPPCT_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function



        Public Shared Sub Guardar(ByVal vPRINCIPIO_ACTIVO As EntityLayer.EL.PRINCIPIO_ACTIVO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PRINCIPIO_ACTIVO.Guardar(vPRINCIPIO_ACTIVO:=vPRINCIPIO_ACTIVO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vPRINCIPIO_ACTIVO As EntityLayer.EL.PRINCIPIO_ACTIVO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PRINCIPIO_ACTIVO.Eliminar(vPRINCIPIO_ACTIVO:=vPRINCIPIO_ACTIVO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPPCT_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PRINCIPIO_ACTIVO
            Dim vL As List(Of EntityLayer.EL.PRINCIPIO_ACTIVO)
            vL = Buscar(vPPCT_ID:=vPPCT_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If
        End Function

        Public Shared Function ObtenerPorMedicamento(Optional ByVal vMEDI_ID As Int32? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PRINCIPIO_ACTIVO
           Try
                ObtenerPorMedicamento = DataLayer.DAL.PRINCIPIO_ACTIVO.ObtenerPorMedicamento(vMEDI_ID:=vMEDI_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function
    End Class


End Namespace

