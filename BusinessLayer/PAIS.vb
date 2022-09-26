Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class PAIS
 
 
 Public Shared Function Buscar(Optional ByVal vPAI_ID As Int32? = Nothing, _ 
Optional ByVal vPAI_DESCRIPCION As String = Nothing, _ 
Optional ByVal vPAI_NACIONALIDAD As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing ) As List(Of EntityLayer.EL.PAIS )
	Buscar = DataLayer.DAL.PAIS.Buscar(vPAI_ID,vPAI_DESCRIPCION,vPAI_NACIONALIDAD,vCon,vControlEstado:=vControlEstado)
 End Function

        'ListarPais
        Public Shared Function ListarPais(Optional ByVal vPAI_ID As Int32? = Nothing, _
Optional ByVal vPAI_DESCRIPCION As String = Nothing, _
Optional ByVal vPAI_NACIONALIDAD As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarPais = DataLayer.DAL.PAIS.ListarPais(vPAI_ID, vPAI_DESCRIPCION, vPAI_NACIONALIDAD, vCon, vControlEstado:=vControlEstado)
        End Function

 Public Shared Sub Guardar(Byval vPAIS As EntityLayer.EL.PAIS, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.PAIS.Guardar(vPAIS,vCon,vControlEstado:=vControlEstado )
 End Sub
 
  Public Shared Sub Eliminar(Byval vPAIS As EntityLayer.EL.PAIS, Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing )  
	DataLayer.DAL.PAIS.Eliminar(vPAIS,vCon,vControlEstado:=vControlEstado )
 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vPAI_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.PAIS 
            Dim vL As List(Of EntityLayer.EL.PAIS)
            vL = Buscar(vPAI_ID:=vPAI_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

 End Function
End Class


End Namespace

