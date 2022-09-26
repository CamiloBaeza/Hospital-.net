Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class ESTADO_PAGO
 
 
 Public Shared Function Buscar(			 Optional ByVal vESPA_ID As Int32? = Nothing, _ 
			 Optional ByVal vESPA_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.ESTADO_PAGO )
	Try
Buscar = DataLayer.DAL.ESTADO_PAGO.Buscar(vESPA_ID := vESPA_ID,vESPA_DESCRIPCION := vESPA_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vESTADO_PAGO As EntityLayer.EL.ESTADO_PAGO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.ESTADO_PAGO.Guardar(vESTADO_PAGO := vESTADO_PAGO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vESTADO_PAGO As EntityLayer.EL.ESTADO_PAGO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.ESTADO_PAGO.Eliminar(vESTADO_PAGO := vESTADO_PAGO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vESPA_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.ESTADO_PAGO 
 Dim vL As List(Of EntityLayer.EL.ESTADO_PAGO)
 vL = Buscar(vESPA_ID:=vESPA_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

