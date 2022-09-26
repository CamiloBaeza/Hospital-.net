Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class ACCESO
 
 
 Public Shared Function Buscar(Optional ByVal vUSU_ID As Int32? = Nothing, _ 
Optional ByVal vFUNCION_ID As Int32? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing ) As List(Of EntityLayer.EL.ACCESO )
	Buscar = DataLayer.DAL.ACCESO.Buscar(vUSU_ID,vFUNCION_ID,vCon,vControlEstado:=vControlEstado)
 End Function

        Public Shared Function ListarAcceso(Optional ByVal vUSU_ID As Int32? = Nothing, _
       Optional ByVal vFUNCION_ID As Int32? = Nothing, _
       Optional ByVal vUSU_RUT As String = Nothing, _
        Optional ByVal vUSU_NOMBRE As String = Nothing, _
        Optional ByVal vUSU_APELLIDO_PAT As String = Nothing, _
        Optional ByVal vUSU_APELLIDO_MAT As String = Nothing, _
        Optional ByVal vCLI_ID As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarAcceso = DataLayer.DAL.ACCESO.ListarAcceso(vUSU_ID, vFUNCION_ID, vUSU_RUT, vUSU_NOMBRE, vUSU_APELLIDO_PAT, vUSU_APELLIDO_MAT, vCLI_ID, vCon, vControlEstado:=vControlEstado)
        End Function

 Public Shared Sub Guardar(Byval vACCESO As EntityLayer.EL.ACCESO, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.ACCESO.Guardar(vACCESO,vCon,vControlEstado:=vControlEstado )
 End Sub
 
  Public Shared Sub Eliminar(Byval vACCESO As EntityLayer.EL.ACCESO, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.ACCESO.Eliminar(vACCESO,vCon,vControlEstado:=vControlEstado )
        End Sub

 
 Public Shared Function ObtenerPorId(Optional ByVal vUSU_ID As Int32? = Nothing, _ 
Optional ByVal vFUNCION_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.ACCESO 
 Dim vL As List(Of EntityLayer.EL.ACCESO)
 vL = Buscar(vUSU_ID:=vUSU_ID, _ 
vFUNCION_ID:=vFUNCION_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

