Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class TIPO_USUARIO
 
 
 Public Shared Function Buscar(Optional ByVal vTIPU_ID As Short? = Nothing, _ 
Optional ByVal vTIPU_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing ) As List(Of EntityLayer.EL.TIPO_USUARIO )
	Buscar = DataLayer.DAL.TIPO_USUARIO.Buscar(vTIPU_ID,vTIPU_DESCRIPCION,vCon,vControlEstado:=vControlEstado)
 End Function


 Public Shared Sub Guardar(Byval vTIPO_USUARIO As EntityLayer.EL.TIPO_USUARIO, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.TIPO_USUARIO.Guardar(vTIPO_USUARIO,vCon,vControlEstado:=vControlEstado )
 End Sub
 
  Public Shared Sub Eliminar(Byval vTIPO_USUARIO As EntityLayer.EL.TIPO_USUARIO, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.TIPO_USUARIO.Eliminar(vTIPO_USUARIO,vCon,vControlEstado:=vControlEstado )
 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vTIPU_ID As Short? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.TIPO_USUARIO 
 Dim vL As List(Of EntityLayer.EL.TIPO_USUARIO)
 vL = Buscar(vTIPU_ID:=vTIPU_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

