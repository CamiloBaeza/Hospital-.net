Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class DETALLE_FACTURA
 
 
 Public Shared Function Buscar(			 Optional ByVal vDEFA_ID As Int32? = Nothing, _ 
			 Optional ByVal vFACT_ID As Int32? = Nothing, _ 
			 Optional ByVal vDEFA_DESCRIPCION As String = Nothing, _ 
			 Optional ByVal vDEFA_VALOR As Decimal? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DETALLE_FACTURA )
	Buscar = DataLayer.DAL.DETALLE_FACTURA.Buscar(vDEFA_ID,vFACT_ID,vDEFA_DESCRIPCION,vDEFA_VALOR,vCon)
 End Function


 Public Shared Sub Guardar(Byval vDETALLE_FACTURA As EntityLayer.EL.DETALLE_FACTURA, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.DETALLE_FACTURA.Guardar(vDETALLE_FACTURA,vCon)
 End Sub
 
  Public Shared Sub Eliminar(Byval vDETALLE_FACTURA As EntityLayer.EL.DETALLE_FACTURA, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.DETALLE_FACTURA.Eliminar(vDETALLE_FACTURA,vCon)
 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vDEFA_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.DETALLE_FACTURA 
 Dim vL As List(Of EntityLayer.EL.DETALLE_FACTURA)
 vL = Buscar(vDEFA_ID:=vDEFA_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

