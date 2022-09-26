Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class SERVICIO
 
 
 Public Shared Function Buscar(			 Optional ByVal vSERV_ID As Int32? = Nothing, _ 
			 Optional ByVal vSERV_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.SERVICIO )
	Buscar = DataLayer.DAL.SERVICIO.Buscar(vSERV_ID,vSERV_DESCRIPCION,vCon)
 End Function


 Public Shared Sub Guardar(Byval vSERVICIO As EntityLayer.EL.SERVICIO, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.SERVICIO.Guardar(vSERVICIO,vCon)
 End Sub
 
  Public Shared Sub Eliminar(Byval vSERVICIO As EntityLayer.EL.SERVICIO, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.SERVICIO.Eliminar(vSERVICIO,vCon)
 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vSERV_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.SERVICIO 
 Dim vL As List(Of EntityLayer.EL.SERVICIO)
 vL = Buscar(vSERV_ID:=vSERV_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

