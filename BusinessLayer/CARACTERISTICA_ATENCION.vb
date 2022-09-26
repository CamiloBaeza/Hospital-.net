Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class CARACTERISTICA_ATENCION
 
 
 Public Shared Function Buscar(			 Optional ByVal vCAAT_ID As Int32? = Nothing, _ 
			 Optional ByVal vCAAT_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CARACTERISTICA_ATENCION )
	Try
Buscar = DataLayer.DAL.CARACTERISTICA_ATENCION.Buscar(vCAAT_ID := vCAAT_ID,vCAAT_DESCRIPCION := vCAAT_DESCRIPCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

        End Function


 Public Shared Sub Guardar(Byval vCARACTERISTICA_ATENCION As EntityLayer.EL.CARACTERISTICA_ATENCION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.CARACTERISTICA_ATENCION.Guardar(vCARACTERISTICA_ATENCION := vCARACTERISTICA_ATENCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vCARACTERISTICA_ATENCION As EntityLayer.EL.CARACTERISTICA_ATENCION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.CARACTERISTICA_ATENCION.Eliminar(vCARACTERISTICA_ATENCION := vCARACTERISTICA_ATENCION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vCAAT_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.CARACTERISTICA_ATENCION 
 Dim vL As List(Of EntityLayer.EL.CARACTERISTICA_ATENCION)
 vL = Buscar(vCAAT_ID:=vCAAT_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

