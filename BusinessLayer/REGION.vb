Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class REGION
 
 
 Public Shared Function Buscar(Optional ByVal vREG_ID As Int32? = Nothing, _ 
Optional ByVal vPAI_ID As Int32? = Nothing, _ 
Optional ByVal vREG_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing ) As List(Of EntityLayer.EL.REGION )
	Buscar = DataLayer.DAL.REGION.Buscar(vREG_ID,vPAI_ID,vREG_DESCRIPCION,vCon,vControlEstado:=vControlEstado)
 End Function

        'BuscarRegion
        Public Shared Function BuscarRegion(Optional ByVal vREG_ID As Int32? = Nothing, _
       Optional ByVal vPAI_ID As Int32? = Nothing, _
       Optional ByVal vREG_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.REGION)
            BuscarRegion = DataLayer.DAL.REGION.BuscarRegion(vREG_ID, vPAI_ID, vREG_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        'ListarRegion
        Public Shared Function ListarRegion(Optional ByVal vREG_ID As Int32? = Nothing, _
       Optional ByVal vPAI_ID As Int32? = Nothing, _
       Optional ByVal vREG_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarRegion = DataLayer.DAL.REGION.ListarRegion(vREG_ID, vPAI_ID, vREG_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function


 Public Shared Sub Guardar(Byval vREGION As EntityLayer.EL.REGION, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.REGION.Guardar(vREGION,vCon,vControlEstado:=vControlEstado )
 End Sub
 
  Public Shared Sub Eliminar(Byval vREGION As EntityLayer.EL.REGION, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.REGION.Eliminar(vREGION,vCon,vControlEstado:=vControlEstado )
 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vREG_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.REGION 
 Dim vL As List(Of EntityLayer.EL.REGION)
 vL = Buscar(vREG_ID:=vREG_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

