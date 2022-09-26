Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class CARACTERISTICA_PRESTACION
 
 
 Public Shared Function Buscar(			 Optional ByVal vCAAT_ID As Int32? = Nothing, _ 
			 Optional ByVal vPRES_ID As Decimal? = Nothing, _ 
			 Optional ByVal vCAPR_OBSERVACION As String = Nothing, _ 
			 Optional ByVal vCAPR_OBSERVACION1 As String = Nothing, _ 
			 Optional ByVal vCAPR_OBSERVACION2 As String = Nothing, _ 
			 Optional ByVal vCAPR_OBSERVACION3 As String = Nothing, _ 
			 Optional ByVal vCAPR_ALERTA As Int32? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CARACTERISTICA_PRESTACION )
	Try
Buscar = DataLayer.DAL.CARACTERISTICA_PRESTACION.Buscar(vCAAT_ID := vCAAT_ID,vPRES_ID := vPRES_ID,vCAPR_OBSERVACION := vCAPR_OBSERVACION,vCAPR_OBSERVACION1 := vCAPR_OBSERVACION1,vCAPR_OBSERVACION2 := vCAPR_OBSERVACION2,vCAPR_OBSERVACION3 := vCAPR_OBSERVACION3,vCAPR_ALERTA := vCAPR_ALERTA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vCARACTERISTICA_PRESTACION As EntityLayer.EL.CARACTERISTICA_PRESTACION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.CARACTERISTICA_PRESTACION.Guardar(vCARACTERISTICA_PRESTACION := vCARACTERISTICA_PRESTACION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vCARACTERISTICA_PRESTACION As EntityLayer.EL.CARACTERISTICA_PRESTACION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.CARACTERISTICA_PRESTACION.Eliminar(vCARACTERISTICA_PRESTACION := vCARACTERISTICA_PRESTACION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vCAAT_ID As Int32? = Nothing, _ 
Optional ByVal vPRES_ID As Decimal? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.CARACTERISTICA_PRESTACION 
 Dim vL As List(Of EntityLayer.EL.CARACTERISTICA_PRESTACION)
 vL = Buscar(vCAAT_ID:=vCAAT_ID, _ 
vPRES_ID:=vPRES_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

        End Function

        Public Shared Function ListaCaracteristicaAtencion(Optional ByVal vPRES_ID As Decimal? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CARACTERISTICA_PRESTACION)

            Try
                ListaCaracteristicaAtencion = DataLayer.DAL.CARACTERISTICA_PRESTACION.ListaCaracteristicaAtencion(vPRES_ID:=vPRES_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

End Class


End Namespace

