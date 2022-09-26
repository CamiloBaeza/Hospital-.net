Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class BANCO
 
 
 Public Shared Function Buscar(			 Optional ByVal vBANC_ID As Decimal? = Nothing, _ 
			 Optional ByVal vBANC_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.BANCO )
	Try
Buscar = DataLayer.DAL.BANCO.Buscar(vBANC_ID := vBANC_ID,vBANC_DESCRIPCION := vBANC_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vBANCO As EntityLayer.EL.BANCO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.BANCO.Guardar(vBANCO := vBANCO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vBANCO As EntityLayer.EL.BANCO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.BANCO.Eliminar(vBANCO := vBANCO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vBANC_ID As Decimal? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.BANCO 
 Dim vL As List(Of EntityLayer.EL.BANCO)
 vL = Buscar(vBANC_ID:=vBANC_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

