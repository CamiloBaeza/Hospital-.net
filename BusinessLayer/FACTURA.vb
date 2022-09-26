Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class FACTURA
 
 
 Public Shared Function Buscar(			 Optional ByVal vFACT_ID As Int32? = Nothing, _ 
			 Optional ByVal vCONT_ID As Int32? = Nothing, _ 
			 Optional ByVal vFACT_DESCRIPCION As String = Nothing, _ 
			 Optional ByVal vFACT_VALOR As Decimal? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FACTURA )
	Buscar = DataLayer.DAL.FACTURA.Buscar(vFACT_ID,vCONT_ID,vFACT_DESCRIPCION,vFACT_VALOR,vCon)
 End Function


 Public Shared Sub Guardar(Byval vFACTURA As EntityLayer.EL.FACTURA, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.FACTURA.Guardar(vFACTURA,vCon)
 End Sub
 
  Public Shared Sub Eliminar(Byval vFACTURA As EntityLayer.EL.FACTURA, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.FACTURA.Eliminar(vFACTURA,vCon)
 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vFACT_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.FACTURA 
 Dim vL As List(Of EntityLayer.EL.FACTURA)
 vL = Buscar(vFACT_ID:=vFACT_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

