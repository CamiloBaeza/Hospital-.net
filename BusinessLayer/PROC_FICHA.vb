Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class PROC_FICHA
 
 
 Public Shared Function Buscar(			 Optional ByVal vPROC_ID As Int32? = Nothing, _ 
			 Optional ByVal vFIME_ID As Int32? = Nothing, _ 
			 Optional ByVal vPRFI_INDICACIONES As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PROC_FICHA )
	Try
Buscar = DataLayer.DAL.PROC_FICHA.Buscar(vPROC_ID := vPROC_ID,vFIME_ID := vFIME_ID,vPRFI_INDICACIONES := vPRFI_INDICACIONES,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vPROC_FICHA As EntityLayer.EL.PROC_FICHA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PROC_FICHA.Guardar(vPROC_FICHA := vPROC_FICHA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vPROC_FICHA As EntityLayer.EL.PROC_FICHA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.PROC_FICHA.Eliminar(vPROC_FICHA := vPROC_FICHA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vPROC_ID As Int32? = Nothing, _ 
Optional ByVal vFIME_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.PROC_FICHA 
 Dim vL As List(Of EntityLayer.EL.PROC_FICHA)
 vL = Buscar(vPROC_ID:=vPROC_ID, _ 
vFIME_ID:=vFIME_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

