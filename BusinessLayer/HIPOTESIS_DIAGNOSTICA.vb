Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class HIPOTESIS_DIAGNOSTICA
 
 
 Public Shared Function Buscar(			 Optional ByVal vHDIA_ID As Int32? = Nothing, _ 
			 Optional ByVal vDIAG_ID As Int32? = Nothing, _ 
			 Optional ByVal vFIME_ID As Int32? = Nothing, _ 
			 Optional ByVal vHDIA_CAEC As Boolean? = Nothing, _ 
			 Optional ByVal vHDIA_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HIPOTESIS_DIAGNOSTICA )
	Try
Buscar = DataLayer.DAL.HIPOTESIS_DIAGNOSTICA.Buscar(vHDIA_ID := vHDIA_ID,vDIAG_ID := vDIAG_ID,vFIME_ID := vFIME_ID,vHDIA_CAEC := vHDIA_CAEC,vHDIA_DESCRIPCION := vHDIA_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vHIPOTESIS_DIAGNOSTICA As EntityLayer.EL.HIPOTESIS_DIAGNOSTICA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.HIPOTESIS_DIAGNOSTICA.Guardar(vHIPOTESIS_DIAGNOSTICA := vHIPOTESIS_DIAGNOSTICA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vHIPOTESIS_DIAGNOSTICA As EntityLayer.EL.HIPOTESIS_DIAGNOSTICA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.HIPOTESIS_DIAGNOSTICA.Eliminar(vHIPOTESIS_DIAGNOSTICA := vHIPOTESIS_DIAGNOSTICA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vHDIA_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.HIPOTESIS_DIAGNOSTICA 
 Dim vL As List(Of EntityLayer.EL.HIPOTESIS_DIAGNOSTICA)
 vL = Buscar(vHDIA_ID:=vHDIA_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

