Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class FICHA_MEDICA_DETALLE
 
 
 Public Shared Function Buscar(			 Optional ByVal vFDET As Int32? = Nothing, _ 
			 Optional ByVal vFITE_ID As Int32? = Nothing, _ 
			 Optional ByVal vFIME_ID As Int32? = Nothing, _ 
			 Optional ByVal vFDET_VALOR As String = Nothing, _ 
			 Optional ByVal vFDET_OBSERVACION As String = Nothing, _ 
			 Optional ByVal vFDET_FECHA_REGISTRO As DateTime? = Nothing, _ 
			 Optional ByVal vFDET_FECHA_ELIMINACION As DateTime? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_MEDICA_DETALLE )
	Try
Buscar = DataLayer.DAL.FICHA_MEDICA_DETALLE.Buscar(vFDET := vFDET,vFITE_ID := vFITE_ID,vFIME_ID := vFIME_ID,vFDET_VALOR := vFDET_VALOR,vFDET_OBSERVACION := vFDET_OBSERVACION,vFDET_FECHA_REGISTRO := vFDET_FECHA_REGISTRO,vFDET_FECHA_ELIMINACION := vFDET_FECHA_ELIMINACION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vFICHA_MEDICA_DETALLE As EntityLayer.EL.FICHA_MEDICA_DETALLE, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.FICHA_MEDICA_DETALLE.Guardar(vFICHA_MEDICA_DETALLE := vFICHA_MEDICA_DETALLE,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vFICHA_MEDICA_DETALLE As EntityLayer.EL.FICHA_MEDICA_DETALLE, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.FICHA_MEDICA_DETALLE.Eliminar(vFICHA_MEDICA_DETALLE := vFICHA_MEDICA_DETALLE,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vFDET As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.FICHA_MEDICA_DETALLE 
 Dim vL As List(Of EntityLayer.EL.FICHA_MEDICA_DETALLE)
 vL = Buscar(vFDET:=vFDET, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

