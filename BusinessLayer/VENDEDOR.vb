Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class VENDEDOR
 
 
 Public Shared Function Buscar(			 Optional ByVal vVEND_ID As Int32? = Nothing, _ 
			 Optional ByVal vVEND_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.VENDEDOR )
	Buscar = DataLayer.DAL.VENDEDOR.Buscar(vVEND_ID,vVEND_DESCRIPCION,vCon)
 End Function


 Public Shared Sub Guardar(Byval vVENDEDOR As EntityLayer.EL.VENDEDOR, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.VENDEDOR.Guardar(vVENDEDOR,vCon)
 End Sub
 
  Public Shared Sub Eliminar(Byval vVENDEDOR As EntityLayer.EL.VENDEDOR, Optional ByVal vCon As Conexion = Nothing)  
	DataLayer.DAL.VENDEDOR.Eliminar(vVENDEDOR,vCon)
 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vVEND_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.VENDEDOR 
 Dim vL As List(Of EntityLayer.EL.VENDEDOR)
 vL = Buscar(vVEND_ID:=vVEND_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

