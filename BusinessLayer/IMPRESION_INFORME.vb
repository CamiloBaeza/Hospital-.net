Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class IMPRESION_INFORME
 
 
 Public Shared Function Buscar(			 Optional ByVal vIMPR_ID As Int32? = Nothing, _ 
			 Optional ByVal vIMPRE_INF_ATENCION_RECIBIDA As Boolean? = Nothing, _ 
			 Optional ByVal vIMPRE_INF_GES As Boolean? = Nothing, _ 
			 Optional ByVal vIMPRE_INF_ORDEN_EXAMEN As Boolean? = Nothing, _ 
			 Optional ByVal vIMPRE_INF_RECETA As Boolean? = Nothing, _ 
			 Optional ByVal vIMPRE_INF_REGISTRO_BIOPSIA As Boolean? = Nothing, _ 
			 Optional ByVal vFIME_ID As Int32? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.IMPRESION_INFORME )
	Try
Buscar = DataLayer.DAL.IMPRESION_INFORME.Buscar(vIMPR_ID := vIMPR_ID,vIMPRE_INF_ATENCION_RECIBIDA := vIMPRE_INF_ATENCION_RECIBIDA,vIMPRE_INF_GES := vIMPRE_INF_GES,vIMPRE_INF_ORDEN_EXAMEN := vIMPRE_INF_ORDEN_EXAMEN,vIMPRE_INF_RECETA := vIMPRE_INF_RECETA,vIMPRE_INF_REGISTRO_BIOPSIA := vIMPRE_INF_REGISTRO_BIOPSIA,vFIME_ID := vFIME_ID,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vIMPRESION_INFORME As EntityLayer.EL.IMPRESION_INFORME, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.IMPRESION_INFORME.Guardar(vIMPRESION_INFORME := vIMPRESION_INFORME,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vIMPRESION_INFORME As EntityLayer.EL.IMPRESION_INFORME, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.IMPRESION_INFORME.Eliminar(vIMPRESION_INFORME := vIMPRESION_INFORME,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vIMPR_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.IMPRESION_INFORME 
 Dim vL As List(Of EntityLayer.EL.IMPRESION_INFORME)
 vL = Buscar(vIMPR_ID:=vIMPR_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

