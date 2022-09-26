Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class CONVENIO_PACIENTE
 
 
 Public Shared Function Buscar(			 Optional ByVal vEMP_ID As Decimal? = Nothing, _ 
			 Optional ByVal vPAC_ID As Int32? = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONVENIO_PACIENTE )
	Try
Buscar = DataLayer.DAL.CONVENIO_PACIENTE.Buscar(vEMP_ID := vEMP_ID,vPAC_ID := vPAC_ID,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Function


 Public Shared Sub Guardar(Byval vCONVENIO_PACIENTE As EntityLayer.EL.CONVENIO_PACIENTE, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.CONVENIO_PACIENTE.Guardar(vCONVENIO_PACIENTE := vCONVENIO_PACIENTE,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vCONVENIO_PACIENTE As EntityLayer.EL.CONVENIO_PACIENTE, Optional ByVal vCon As Conexion = Nothing)  
            Try

                DataLayer.DAL.CONVENIO_PACIENTE.Eliminar(vCONVENIO_PACIENTE:=vCONVENIO_PACIENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vEMP_ID As Decimal? = Nothing, _ 
Optional ByVal vPAC_ID As Int32? = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.CONVENIO_PACIENTE 
 Dim vL As List(Of EntityLayer.EL.CONVENIO_PACIENTE)
 vL = Buscar(vEMP_ID:=vEMP_ID, _ 
vPAC_ID:=vPAC_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

