Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class INICIO_SESION
 
 
        Public Shared Function Buscar(Optional ByVal vINSE_INI As Int32? = Nothing, _
           Optional ByVal vINSE_WEB_BROWSER As String = Nothing, _
           Optional ByVal vINSE_ID_CLIENTE As String = Nothing, _
           Optional ByVal vINSE_ID_USUARIO As Int32? = Nothing, _
           Optional ByVal vINSE_FECHA_REGISTRO As DateTime? = Nothing, _
           Optional ByVal vINSE_FECHA_ULTIMA_SESION As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INICIO_SESION)
            Try
                Buscar = DataLayer.DAL.INICIO_SESION.Buscar(vINSE_INI:=vINSE_INI, vINSE_WEB_BROWSER:=vINSE_WEB_BROWSER, vINSE_ID_CLIENTE:=vINSE_ID_CLIENTE, vINSE_ID_USUARIO:=vINSE_ID_USUARIO, vINSE_FECHA_REGISTRO:=vINSE_FECHA_REGISTRO, vINSE_FECHA_ULTIMA_SESION:=vINSE_FECHA_ULTIMA_SESION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


 Public Shared Sub Guardar(Byval vINICIO_SESION As EntityLayer.EL.INICIO_SESION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.INICIO_SESION.Guardar(vINICIO_SESION := vINICIO_SESION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vINICIO_SESION As EntityLayer.EL.INICIO_SESION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.INICIO_SESION.Eliminar(vINICIO_SESION := vINICIO_SESION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vINSE_INI As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.INICIO_SESION 
 Dim vL As List(Of EntityLayer.EL.INICIO_SESION)
 vL = Buscar(vINSE_INI:=vINSE_INI, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

