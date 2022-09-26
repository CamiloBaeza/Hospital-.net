Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class ESPECIALIDAD_EXAMEN
 
 
 Public Shared Function Buscar(			 Optional ByVal vEXA_ID As Short? = Nothing, _ 
			 Optional ByVal vESP_ID As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.ESPECIALIDAD_EXAMEN )
	Try
Buscar = DataLayer.DAL.ESPECIALIDAD_EXAMEN.Buscar(vEXA_ID := vEXA_ID,vESP_ID := vESP_ID,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

        End Function

        Public Shared Function sortList_EspecialidadExamen(ByVal order As String, _
                                     ByVal col As String, _
                                     ByVal vLista As List(Of EntityLayer.EL.ESPECIALIDAD_EXAMEN)) As List(Of EntityLayer.EL.ESPECIALIDAD_EXAMEN)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "EXA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.EXA_DESCRIPCION)
                    Case "ESP_ID"
                        query = query.OrderBy(Function(x) x.ESP_ID)
                End Select
            Else
                Select Case col
                    Case "EXA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.EXA_DESCRIPCION)
                    Case "ESP_ID"
                        query = query.OrderByDescending(Function(x) x.ESP_ID)
                End Select
            End If

            Return query.ToList
        End Function



        Public Shared Function BuscarEspecialidadExamenConfig(
         Optional ByVal vEXA_ID As Int32? = Nothing, _
         Optional ByVal vCLI_ID As Int32? = Nothing, _
         Optional ByVal vESP_ID As Int32? = Nothing, _
         Optional ByVal vCONFIGURADO As Boolean? = Nothing, _
     Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.ESPECIALIDAD_EXAMEN)
            Try
                BuscarEspecialidadExamenConfig = DataLayer.DAL.ESPECIALIDAD_EXAMEN.BuscarEspecialidadExamenConfig(vEXA_ID:=vEXA_ID, vESP_ID:=vESP_ID, vCon:=vCon, vCLI_ID:=vCLI_ID, vCONFIGURADO:=vCONFIGURADO)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function




 Public Shared Sub Guardar(Byval vESPECIALIDAD_EXAMEN As EntityLayer.EL.ESPECIALIDAD_EXAMEN, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.ESPECIALIDAD_EXAMEN.Guardar(vESPECIALIDAD_EXAMEN := vESPECIALIDAD_EXAMEN,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
  Public Shared Sub Eliminar(Byval vESPECIALIDAD_EXAMEN As EntityLayer.EL.ESPECIALIDAD_EXAMEN, Optional ByVal vCon As Conexion = Nothing)  
	Try
DataLayer.DAL.ESPECIALIDAD_EXAMEN.Eliminar(vESPECIALIDAD_EXAMEN := vESPECIALIDAD_EXAMEN,vCon:=vCon)
Catch vEx as Exception
Throw New Exception(vEx.Message, vEx)
End Try

 End Sub
 
 Public Shared Function ObtenerPorId(Optional ByVal vEXA_ID As Short? = Nothing, _ 
Optional ByVal vESP_ID As String = Nothing, _ 
 Optional ByVal vCon As Conexion = Nothing) As  EntityLayer.EL.ESPECIALIDAD_EXAMEN 
 Dim vL As List(Of EntityLayer.EL.ESPECIALIDAD_EXAMEN)
 vL = Buscar(vEXA_ID:=vEXA_ID, _ 
vESP_ID:=vESP_ID, _ 
vCon:=vCon) 
If vL IsNot Nothing AndAlso vL.Count = 1 Then 
ObtenerPorId = vL(0) 
Else 
ObtenerPorId = Nothing 
End If 

 End Function
End Class


End Namespace

