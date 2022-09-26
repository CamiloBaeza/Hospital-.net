Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class CONVENIO_PRESTACION
 
 
 Public Shared Function Buscar(			 Optional ByVal vEMP_ID As Decimal? = Nothing, _ 
			 Optional ByVal vPRES_ID As Decimal? = Nothing, _ 
			 Optional ByVal vCOPR_OBSERVACION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONVENIO_PRESTACION )
	Try
Buscar = DataLayer.DAL.CONVENIO_PRESTACION.Buscar(vEMP_ID := vEMP_ID,vPRES_ID := vPRES_ID,vCOPR_OBSERVACION := vCOPR_OBSERVACION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

        End Function

        Public Shared Function ListaConvenios(Optional ByVal vPRES_ID As Decimal? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONVENIO_PRESTACION)

            Try
                ListaConvenios = DataLayer.DAL.CONVENIO_PRESTACION.ListaConvenios(vPRES_ID:=vPRES_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vCONVENIO_PRESTACION As EntityLayer.EL.CONVENIO_PRESTACION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.CONVENIO_PRESTACION.Guardar(vCONVENIO_PRESTACION:=vCONVENIO_PRESTACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vCONVENIO_PRESTACION As EntityLayer.EL.CONVENIO_PRESTACION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.CONVENIO_PRESTACION.Eliminar(vCONVENIO_PRESTACION:=vCONVENIO_PRESTACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vEMP_ID As Decimal? = Nothing, _
       Optional ByVal vPRES_ID As Decimal? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.CONVENIO_PRESTACION
            Dim vL As List(Of EntityLayer.EL.CONVENIO_PRESTACION)
            vL = Buscar(vEMP_ID:=vEMP_ID, _
           vPRES_ID:=vPRES_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

