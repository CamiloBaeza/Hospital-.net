Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class SEND_MAIL
 
 
 Public Shared Function Buscar(			 Optional ByVal vSEMA_ID As Int32? = Nothing, _ 
			 Optional ByVal vSEMA_ASUNTO As String = Nothing, _ 
			 Optional ByVal vSEMA_CUENTA_DESTINO As String = Nothing, _ 
			 Optional ByVal vSEMA_CUENTA_COPIA As String = Nothing, _ 
			 Optional ByVal vSEMA_CUENTA_ORIGEN As String = Nothing, _ 
			 Optional ByVal vSEMA_CUERPO As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.SEND_MAIL )
	Try
Buscar = DataLayer.DAL.SEND_MAIL.Buscar(vSEMA_ID := vSEMA_ID,vSEMA_ASUNTO := vSEMA_ASUNTO,vSEMA_CUENTA_DESTINO := vSEMA_CUENTA_DESTINO,vSEMA_CUENTA_COPIA := vSEMA_CUENTA_COPIA,vSEMA_CUENTA_ORIGEN := vSEMA_CUENTA_ORIGEN,vSEMA_CUERPO := vSEMA_CUERPO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vSEND_MAIL As EntityLayer.EL.SEND_MAIL, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.SEND_MAIL.Guardar(vSEND_MAIL := vSEND_MAIL,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vSEND_MAIL As EntityLayer.EL.SEND_MAIL, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.SEND_MAIL.Eliminar(vSEND_MAIL := vSEND_MAIL,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vSEMA_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.SEND_MAIL 
 Dim vL As List(Of EntityLayer.EL.SEND_MAIL)
 vL = Buscar(vSEMA_ID:=vSEMA_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

