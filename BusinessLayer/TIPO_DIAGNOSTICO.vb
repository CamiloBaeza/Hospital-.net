Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class TIPO_DIAGNOSTICO
 
 
 Public Shared Function Buscar(			 Optional ByVal vTDIAG_ID As Int32? = Nothing, _ 
			 Optional ByVal vTDIAG_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.TIPO_DIAGNOSTICO )
	Try
Buscar = DataLayer.DAL.TIPO_DIAGNOSTICO.Buscar(vTDIAG_ID := vTDIAG_ID,vTDIAG_DESCRIPCION := vTDIAG_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vTIPO_DIAGNOSTICO As EntityLayer.EL.TIPO_DIAGNOSTICO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.TIPO_DIAGNOSTICO.Guardar(vTIPO_DIAGNOSTICO := vTIPO_DIAGNOSTICO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vTIPO_DIAGNOSTICO As EntityLayer.EL.TIPO_DIAGNOSTICO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.TIPO_DIAGNOSTICO.Eliminar(vTIPO_DIAGNOSTICO := vTIPO_DIAGNOSTICO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vTDIAG_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.TIPO_DIAGNOSTICO 
 Dim vL As List(Of EntityLayer.EL.TIPO_DIAGNOSTICO)
 vL = Buscar(vTDIAG_ID:=vTDIAG_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

