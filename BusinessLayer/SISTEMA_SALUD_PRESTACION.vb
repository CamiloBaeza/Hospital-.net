Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class SISTEMA_SALUD_PRESTACION
 
 
 Public Shared Function Buscar(			 Optional ByVal vSISS_ID As Int32? = Nothing, _ 
			 Optional ByVal vPRES_ID As Decimal? = Nothing, _ 
			 Optional ByVal vSSPR_IMED As Boolean? = Nothing, _ 
			 Optional ByVal vSSPR_OBSERVACION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.SISTEMA_SALUD_PRESTACION )
	Try
Buscar = DataLayer.DAL.SISTEMA_SALUD_PRESTACION.Buscar(vSISS_ID := vSISS_ID,vPRES_ID := vPRES_ID,vSSPR_IMED := vSSPR_IMED,vSSPR_OBSERVACION := vSSPR_OBSERVACION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vSISTEMA_SALUD_PRESTACION As EntityLayer.EL.SISTEMA_SALUD_PRESTACION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.SISTEMA_SALUD_PRESTACION.Guardar(vSISTEMA_SALUD_PRESTACION := vSISTEMA_SALUD_PRESTACION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vSISTEMA_SALUD_PRESTACION As EntityLayer.EL.SISTEMA_SALUD_PRESTACION, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.SISTEMA_SALUD_PRESTACION.Eliminar(vSISTEMA_SALUD_PRESTACION := vSISTEMA_SALUD_PRESTACION,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vSISS_ID As Int32? = Nothing, _ 
Optional ByVal vPRES_ID As Decimal? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.SISTEMA_SALUD_PRESTACION 
 Dim vL As List(Of EntityLayer.EL.SISTEMA_SALUD_PRESTACION)
 vL = Buscar(vSISS_ID:=vSISS_ID, _ 
vPRES_ID:=vPRES_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

        End Function

        Public Shared Function ListaSistemaSalud(Optional ByVal vPRES_ID As Decimal? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.SISTEMA_SALUD_PRESTACION)
            Try
                ListaSistemaSalud = DataLayer.DAL.SISTEMA_SALUD_PRESTACION.ListaSistemaSalud(vPRES_ID:=vPRES_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

End Class

End Namespace

