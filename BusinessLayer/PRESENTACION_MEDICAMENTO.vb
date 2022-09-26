Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class PRESENTACION_MEDICAMENTO
 
 
 Public Shared Function Buscar(			 Optional ByVal vPMED_ID As Int32? = Nothing, _ 
			 Optional ByVal vPMED_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PRESENTACION_MEDICAMENTO )
	Try
Buscar = DataLayer.DAL.PRESENTACION_MEDICAMENTO.Buscar(vPMED_ID := vPMED_ID,vPMED_DESCRIPCION := vPMED_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vPRESENTACION_MEDICAMENTO As EntityLayer.EL.PRESENTACION_MEDICAMENTO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PRESENTACION_MEDICAMENTO.Guardar(vPRESENTACION_MEDICAMENTO := vPRESENTACION_MEDICAMENTO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vPRESENTACION_MEDICAMENTO As EntityLayer.EL.PRESENTACION_MEDICAMENTO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PRESENTACION_MEDICAMENTO.Eliminar(vPRESENTACION_MEDICAMENTO := vPRESENTACION_MEDICAMENTO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vPMED_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.PRESENTACION_MEDICAMENTO 
 Dim vL As List(Of EntityLayer.EL.PRESENTACION_MEDICAMENTO)
 vL = Buscar(vPMED_ID:=vPMED_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

