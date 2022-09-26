Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class TIPO_FICHA_ITEM
 
 
 Public Shared Function Buscar(			 Optional ByVal vTFIT_ID As Int32? = Nothing, _ 
			 Optional ByVal vTFIT_DESCRIPCION As String = Nothing, _ 
			 Optional ByVal vTFIT_DOMINIO As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.TIPO_FICHA_ITEM )
	Try
Buscar = DataLayer.DAL.TIPO_FICHA_ITEM.Buscar(vTFIT_ID := vTFIT_ID,vTFIT_DESCRIPCION := vTFIT_DESCRIPCION,vTFIT_DOMINIO := vTFIT_DOMINIO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vTIPO_FICHA_ITEM As EntityLayer.EL.TIPO_FICHA_ITEM, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.TIPO_FICHA_ITEM.Guardar(vTIPO_FICHA_ITEM := vTIPO_FICHA_ITEM,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vTIPO_FICHA_ITEM As EntityLayer.EL.TIPO_FICHA_ITEM, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.TIPO_FICHA_ITEM.Eliminar(vTIPO_FICHA_ITEM := vTIPO_FICHA_ITEM,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vTFIT_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.TIPO_FICHA_ITEM 
 Dim vL As List(Of EntityLayer.EL.TIPO_FICHA_ITEM)
 vL = Buscar(vTFIT_ID:=vTFIT_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

