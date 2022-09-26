Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class CONVENIO_EMPRESA


        Public Shared Function Buscar(Optional ByVal vCOEN_ID As Decimal? = Nothing, _
           Optional ByVal vEMP_ID As Decimal? = Nothing, _
           Optional ByVal vCLI_ID As String = Nothing, _
           Optional ByVal vCOEN_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONVENIO_EMPRESA)
            Try
                Buscar = DataLayer.DAL.CONVENIO_EMPRESA.Buscar(vCOEN_ID:=vCOEN_ID, vEMP_ID:=vEMP_ID, vCLI_ID:=vCLI_ID, vCOEN_DESCRIPCION:=vCOEN_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vCONVENIO_EMPRESA As EntityLayer.EL.CONVENIO_EMPRESA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.CONVENIO_EMPRESA.Guardar(vCONVENIO_EMPRESA:=vCONVENIO_EMPRESA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vCONVENIO_EMPRESA As EntityLayer.EL.CONVENIO_EMPRESA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.CONVENIO_EMPRESA.Eliminar(vCONVENIO_EMPRESA:=vCONVENIO_EMPRESA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vCOEN_ID As Decimal? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.CONVENIO_EMPRESA
            If vCOEN_ID.HasValue Then
                Dim vL As List(Of EntityLayer.EL.CONVENIO_EMPRESA)
                vL = Buscar(vCOEN_ID:=vCOEN_ID, _
               vCon:=vCon)
                If vL IsNot Nothing AndAlso vL.Count = 1 Then
                    ObtenerPorId = vL(0)
                Else
                    ObtenerPorId = Nothing
                End If
            Else
                ObtenerPorId = Nothing
            End If
        End Function
    End Class


End Namespace

