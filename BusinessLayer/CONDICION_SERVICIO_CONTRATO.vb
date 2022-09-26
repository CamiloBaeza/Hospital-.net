Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class CONDICION_SERVICIO_CONTRATO
 
 
 Public Shared Function Buscar(			 Optional ByVal vCOSC_ID As Int32? = Nothing, _ 
			 Optional ByVal vCOSC_RANGO_INFERIOR As Int32? = Nothing, _ 
			 Optional ByVal vCOSC_RANGO_SUPERIOR As Int32? = Nothing, _ 
			 Optional ByVal vCOSC_VALOR As Decimal? = Nothing, _ 
			 Optional ByVal vSERC_ID As Int32? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONDICION_SERVICIO_CONTRATO )
	Try
Buscar = DataLayer.DAL.CONDICION_SERVICIO_CONTRATO.Buscar(vCOSC_ID := vCOSC_ID,vCOSC_RANGO_INFERIOR := vCOSC_RANGO_INFERIOR,vCOSC_RANGO_SUPERIOR := vCOSC_RANGO_SUPERIOR,vCOSC_VALOR := vCOSC_VALOR,vSERC_ID := vSERC_ID,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vCONDICION_SERVICIO_CONTRATO As EntityLayer.EL.CONDICION_SERVICIO_CONTRATO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.CONDICION_SERVICIO_CONTRATO.Guardar(vCONDICION_SERVICIO_CONTRATO := vCONDICION_SERVICIO_CONTRATO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vCONDICION_SERVICIO_CONTRATO As EntityLayer.EL.CONDICION_SERVICIO_CONTRATO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.CONDICION_SERVICIO_CONTRATO.Eliminar(vCONDICION_SERVICIO_CONTRATO := vCONDICION_SERVICIO_CONTRATO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId( Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.CONDICION_SERVICIO_CONTRATO 
 Dim vL As List(Of EntityLayer.EL.CONDICION_SERVICIO_CONTRATO)
 vL = Buscar(vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

