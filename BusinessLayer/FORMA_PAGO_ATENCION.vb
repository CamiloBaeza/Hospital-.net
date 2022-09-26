Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class FORMA_PAGO_ATENCION
 
 
 Public Shared Function Buscar(			 Optional ByVal vFOPC_ID As Int32? = Nothing, _ 
			 Optional ByVal vFOPC_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FORMA_PAGO_ATENCION )
	Try
Buscar = DataLayer.DAL.FORMA_PAGO_ATENCION.Buscar(vFOPC_ID := vFOPC_ID,vFOPC_DESCRIPCION := vFOPC_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vFORMA_PAGO_ATENCION As EntityLayer.EL.FORMA_PAGO_ATENCION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.FORMA_PAGO_ATENCION.Guardar(vFORMA_PAGO_ATENCION := vFORMA_PAGO_ATENCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vFORMA_PAGO_ATENCION As EntityLayer.EL.FORMA_PAGO_ATENCION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.FORMA_PAGO_ATENCION.Eliminar(vFORMA_PAGO_ATENCION := vFORMA_PAGO_ATENCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vFOPC_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.FORMA_PAGO_ATENCION 
 Dim vL As List(Of EntityLayer.EL.FORMA_PAGO_ATENCION)
 vL = Buscar(vFOPC_ID:=vFOPC_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

