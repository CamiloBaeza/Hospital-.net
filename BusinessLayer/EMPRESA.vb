Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class EMPRESA
 
 
        Public Shared Function Buscar(Optional ByVal vEMP_ID As Decimal? = Nothing, _
    Optional ByVal vEMP_NOMBRE As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.EMPRESA)
            Try
                Buscar = DataLayer.DAL.EMPRESA.Buscar(vEMP_ID:=vEMP_ID, vEMP_NOMBRE:=vEMP_NOMBRE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


 Public Shared Sub Guardar(Byval vEMPRESA As EntityLayer.EL.EMPRESA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.EMPRESA.Guardar(vEMPRESA := vEMPRESA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vEMPRESA As EntityLayer.EL.EMPRESA, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.EMPRESA.Eliminar(vEMPRESA := vEMPRESA,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vEMP_ID As Decimal? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.EMPRESA 
 Dim vL As List(Of EntityLayer.EL.EMPRESA)
 vL = Buscar(vEMP_ID:=vEMP_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

