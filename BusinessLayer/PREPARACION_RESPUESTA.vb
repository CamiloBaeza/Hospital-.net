Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class PREPARACION_RESPUESTA
 
 
 Public Shared Function Buscar(			 Optional ByVal vPERE_ID As Int32? = Nothing, _ 
			 Optional ByVal vPREX_ID As Int32? = Nothing, _ 
			 Optional ByVal vEXA_ID As Short? = Nothing, _ 
			 Optional ByVal vRESE_ID As Int32? = Nothing, _ 
			 Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _ 
			 Optional ByVal vPRRE_RESPUESTA As String = Nothing, _ 
			 Optional ByVal vPRRE_INFORMADO As Boolean? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PREPARACION_RESPUESTA )
	Try
Buscar = DataLayer.DAL.PREPARACION_RESPUESTA.Buscar(vPERE_ID := vPERE_ID,vPREX_ID := vPREX_ID,vEXA_ID := vEXA_ID,vRESE_ID := vRESE_ID,vUSU_ID_REGISTRA := vUSU_ID_REGISTRA,vPRRE_RESPUESTA := vPRRE_RESPUESTA,vPRRE_INFORMADO := vPRRE_INFORMADO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vPREPARACION_RESPUESTA As EntityLayer.EL.PREPARACION_RESPUESTA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PREPARACION_RESPUESTA.Guardar(vPREPARACION_RESPUESTA := vPREPARACION_RESPUESTA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vPREPARACION_RESPUESTA As EntityLayer.EL.PREPARACION_RESPUESTA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PREPARACION_RESPUESTA.Eliminar(vPREPARACION_RESPUESTA := vPREPARACION_RESPUESTA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vPERE_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.PREPARACION_RESPUESTA 
 Dim vL As List(Of EntityLayer.EL.PREPARACION_RESPUESTA)
 vL = Buscar(vPERE_ID:=vPERE_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

