Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class RESTRICCION_HORARIO
 
 
 Public Shared Function Buscar(			 Optional ByVal vREHO_ID As Int32? = Nothing, _ 
			 Optional ByVal vPRES_ID As Decimal? = Nothing, _ 
			 Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _ 
			 Optional ByVal vUSU_ID_ELIMINA As Int32? = Nothing, _ 
			 Optional ByVal vTIPS_ID As Int32? = Nothing, _ 
			 Optional ByVal vEMP_ID As Decimal? = Nothing, _ 
			 Optional ByVal vREHO_FECHA_REGISTRO As DateTime? = Nothing, _ 
			 Optional ByVal vREHO_FECHA_ELIMINACION As DateTime? = Nothing, _ 
			 Optional ByVal vREHO_CANTIDAD_MAX As Int32? = Nothing, _ 
			 Optional ByVal vREHO_VIGENCIA_INI As DateTime? = Nothing, _ 
			 Optional ByVal vREHO_VIGENCIA_FIN As DateTime? = Nothing, _ 
			 Optional ByVal vREHO_HORA_FIN As TimeSpan? = Nothing, _ 
			 Optional ByVal vREHO_HORA_INI As TimeSpan? = Nothing, _ 
			 Optional ByVal vREHO_LUNES As Boolean? = Nothing, _ 
			 Optional ByVal vREHO_MARTES As Boolean? = Nothing, _ 
			 Optional ByVal vREHO_MIERCOLES As Boolean? = Nothing, _ 
			 Optional ByVal vREHO_JUEVES As Boolean? = Nothing, _ 
			 Optional ByVal vREHO_VIERNES As Boolean? = Nothing, _ 
			 Optional ByVal vREHO_SABADO As Boolean? = Nothing, _ 
			 Optional ByVal vREHO_DOMINGO As Boolean? = Nothing, _ 
			 Optional ByVal vREHO_VIGENTE As Boolean? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESTRICCION_HORARIO )
	Try
Buscar = DataLayer.DAL.RESTRICCION_HORARIO.Buscar(vREHO_ID := vREHO_ID,vPRES_ID := vPRES_ID,vUSU_ID_REGISTRA := vUSU_ID_REGISTRA,vUSU_ID_ELIMINA := vUSU_ID_ELIMINA,vTIPS_ID := vTIPS_ID,vEMP_ID := vEMP_ID,vREHO_FECHA_REGISTRO := vREHO_FECHA_REGISTRO,vREHO_FECHA_ELIMINACION := vREHO_FECHA_ELIMINACION,vREHO_CANTIDAD_MAX := vREHO_CANTIDAD_MAX,vREHO_VIGENCIA_INI := vREHO_VIGENCIA_INI,vREHO_VIGENCIA_FIN := vREHO_VIGENCIA_FIN,vREHO_HORA_FIN := vREHO_HORA_FIN,vREHO_HORA_INI := vREHO_HORA_INI,vREHO_LUNES := vREHO_LUNES,vREHO_MARTES := vREHO_MARTES,vREHO_MIERCOLES := vREHO_MIERCOLES,vREHO_JUEVES := vREHO_JUEVES,vREHO_VIERNES := vREHO_VIERNES,vREHO_SABADO := vREHO_SABADO,vREHO_DOMINGO := vREHO_DOMINGO,vREHO_VIGENTE := vREHO_VIGENTE,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vRESTRICCION_HORARIO As EntityLayer.EL.RESTRICCION_HORARIO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.RESTRICCION_HORARIO.Guardar(vRESTRICCION_HORARIO := vRESTRICCION_HORARIO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vRESTRICCION_HORARIO As EntityLayer.EL.RESTRICCION_HORARIO, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.RESTRICCION_HORARIO.Eliminar(vRESTRICCION_HORARIO := vRESTRICCION_HORARIO,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vREHO_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.RESTRICCION_HORARIO 
 Dim vL As List(Of EntityLayer.EL.RESTRICCION_HORARIO)
 vL = Buscar(vREHO_ID:=vREHO_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

