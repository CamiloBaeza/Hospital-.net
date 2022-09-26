Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class FICHA_ITEM_GRUPO
 
 
 Public Shared Function Buscar(			 Optional ByVal vFIGR_ID As Int32? = Nothing, _ 
			 Optional ByVal vFIGR_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_ITEM_GRUPO )
	Try
Buscar = DataLayer.DAL.FICHA_ITEM_GRUPO.Buscar(vFIGR_ID := vFIGR_ID,vFIGR_DESCRIPCION := vFIGR_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vFICHA_ITEM_GRUPO As EntityLayer.EL.FICHA_ITEM_GRUPO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.FICHA_ITEM_GRUPO.Guardar(vFICHA_ITEM_GRUPO := vFICHA_ITEM_GRUPO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vFICHA_ITEM_GRUPO As EntityLayer.EL.FICHA_ITEM_GRUPO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.FICHA_ITEM_GRUPO.Eliminar(vFICHA_ITEM_GRUPO := vFICHA_ITEM_GRUPO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vFIGR_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.FICHA_ITEM_GRUPO 
 Dim vL As List(Of EntityLayer.EL.FICHA_ITEM_GRUPO)
 vL = Buscar(vFIGR_ID:=vFIGR_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

