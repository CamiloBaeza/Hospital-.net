Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class PREPARATIVO_EXAMEN
 
 
 Public Shared Function Buscar(			 Optional ByVal vPREX_ID As Int32? = Nothing, _ 
			 Optional ByVal vPREP_ID As Int32? = Nothing, _ 
			 Optional ByVal vEXA_ID As Short? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PREPARATIVO_EXAMEN )
	Try
Buscar = DataLayer.DAL.PREPARATIVO_EXAMEN.Buscar(vPREX_ID := vPREX_ID,vPREP_ID := vPREP_ID,vEXA_ID := vEXA_ID,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vPREPARATIVO_EXAMEN As EntityLayer.EL.PREPARATIVO_EXAMEN, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PREPARATIVO_EXAMEN.Guardar(vPREPARATIVO_EXAMEN := vPREPARATIVO_EXAMEN,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vPREPARATIVO_EXAMEN As EntityLayer.EL.PREPARATIVO_EXAMEN, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PREPARATIVO_EXAMEN.Eliminar(vPREPARATIVO_EXAMEN := vPREPARATIVO_EXAMEN,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vPREX_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.PREPARATIVO_EXAMEN 
 Dim vL As List(Of EntityLayer.EL.PREPARATIVO_EXAMEN)
 vL = Buscar(vPREX_ID:=vPREX_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

