Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class MEDIO_PAGO
 
 
 Public Shared Function Buscar(			 Optional ByVal vMEPA_ID As Int32? = Nothing, _ 
			 Optional ByVal vMEPA_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.MEDIO_PAGO )
	Try
Buscar = DataLayer.DAL.MEDIO_PAGO.Buscar(vMEPA_ID := vMEPA_ID,vMEPA_DESCRIPCION := vMEPA_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vMEDIO_PAGO As EntityLayer.EL.MEDIO_PAGO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.MEDIO_PAGO.Guardar(vMEDIO_PAGO := vMEDIO_PAGO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vMEDIO_PAGO As EntityLayer.EL.MEDIO_PAGO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.MEDIO_PAGO.Eliminar(vMEDIO_PAGO := vMEDIO_PAGO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vMEPA_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.MEDIO_PAGO 
 Dim vL As List(Of EntityLayer.EL.MEDIO_PAGO)
 vL = Buscar(vMEPA_ID:=vMEPA_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

