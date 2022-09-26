Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class ESPECIALIDAD
 
 
 Public Shared Function Buscar(Optional ByVal vESP_ID As String = Nothing, _ 
Optional ByVal vESP_DESCRIPCION As String = Nothing, _ 
Optional ByVal vCon As Conexion = Nothing,Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing ) As List(Of EntityLayer.EL.ESPECIALIDAD )
	Buscar = DataLayer.DAL.ESPECIALIDAD.Buscar(vESP_ID,vESP_DESCRIPCION,vCon,vControlEstado:=vControlEstado)
        End Function
        Public Shared Function BuscarEspecialidadClinica(Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vESP_ID As String = Nothing, _
                                      Optional ByVal vESP_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing, _
                                      Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) _
                                  As List(Of EntityLayer.EL.ESPECIALIDAD)
            BuscarEspecialidadClinica = DataLayer.DAL.ESPECIALIDAD.BuscarEspecialidadClinica(vCLI_ID:=vCLI_ID, vESP_ID:=vESP_ID, vESP_DESCRIPCION:=vESP_DESCRIPCION, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarLike(Optional ByVal vESP_ID As String = Nothing, _
       Optional ByVal vESP_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.ESPECIALIDAD)
            BuscarLike = DataLayer.DAL.ESPECIALIDAD.BuscarLike(vESP_ID, vESP_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarEspecialista(Optional ByVal vFecha As String = Nothing, _
Optional ByVal vESP_ID As String = Nothing, _
Optional ByVal vUSU_ID As Int32? = Nothing, _
Optional ByVal vSISS_ID As Int32? = Nothing, _
Optional ByVal vREG_ID As Int32? = Nothing, _
Optional ByVal vCOM_ID As Int32? = Nothing, _
Optional ByVal vHR_INI As String = Nothing, _
Optional ByVal vHR_FIN As String = Nothing, _
Optional ByVal vPROS_ID As Int32? = Nothing, _
Optional ByVal vCLI_ID As Int32? = Nothing, _
Optional ByVal vCLIS_ID As Int32? = Nothing, _
Optional ByVal vCon As Conexion = Nothing, _
Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            ListarEspecialista = DataLayer.DAL.ESPECIALIDAD.ListarHorarioEspecialista(vFecha:=vFecha, vESP_ID:=vESP_ID, vUSU_ID:=vUSU_ID, vSISS_ID:=vSISS_ID, vREG_ID:=vREG_ID, vCOM_ID:=vCOM_ID, vHR_INI:=vHR_INI, vHR_FIN:=vHR_FIN, vPROS_ID:=vPROS_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vCon:=vCon, vControlEstado:=vControlEstado)

        End Function

        Public Shared Function ListarHorarioEspecialista(Optional ByVal vFecha As String = Nothing, _
        Optional ByVal vESP_ID As String = Nothing, _
        Optional ByVal vUSU_ID As Int32? = Nothing, _
        Optional ByVal vSISS_ID As Int32? = Nothing, _
        Optional ByVal vREG_ID As Int32? = Nothing, _
        Optional ByVal vCOM_ID As Int32? = Nothing, _
        Optional ByVal vHR_INI As String = Nothing, _
        Optional ByVal vHR_FIN As String = Nothing, _
        Optional ByVal vPROS_ID As Int32? = Nothing, _
        Optional ByVal vCLI_ID As Int32? = Nothing, _
        Optional ByVal vCLIS_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing, _
        Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            ListarHorarioEspecialista = DataLayer.DAL.ESPECIALIDAD.ListarHorarioEspecialista(vFecha:=vFecha, vESP_ID:=vESP_ID, vUSU_ID:=vUSU_ID, vSISS_ID:=vSISS_ID, vREG_ID:=vREG_ID, vCOM_ID:=vCOM_ID, vHR_INI:=vHR_INI, vHR_FIN:=vHR_FIN, vPROS_ID:=vPROS_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vCon:=vCon, vControlEstado:=vControlEstado)

        End Function

        Public Shared Function ListarEspecialistapordia(Optional ByVal vFecha As String = Nothing, _
Optional ByVal vESP_ID As String = Nothing, _
Optional ByVal vUSU_ID As Int32? = Nothing, _
Optional ByVal vSISS_ID As Int32? = Nothing, _
Optional ByVal vREG_ID As Int32? = Nothing, _
Optional ByVal COM_ID As Int32? = Nothing, _
Optional ByVal vHR_INI As String = Nothing, _
Optional ByVal vHR_FIN As String = Nothing, _
Optional ByVal vPROS_ID As Int32? = Nothing, _
Optional ByVal vCLI_ID As Int32? = Nothing, _
Optional ByVal vCLIS_ID As Int32? = Nothing, _
Optional ByVal vHORD_DIA As Int32? = Nothing, _
Optional ByVal vCon As Conexion = Nothing, _
Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            ListarEspecialistapordia = DataLayer.DAL.ESPECIALIDAD.ListarEspecialistapordia(vFecha, vESP_ID, vUSU_ID, vSISS_ID, vREG_ID, COM_ID, vHR_INI, vHR_FIN, vPROS_ID:=vPROS_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vHORD_DIA:=vHORD_DIA, vCon:=vCon, vControlEstado:=vControlEstado)

        End Function



        Public Shared Function Listar_Problema_Salud_Especialista(
                Optional ByVal vPROS_ID As Int32? = Nothing, _
                Optional ByVal vESP_ID As Int32? = Nothing, _
                Optional ByVal vCon As Conexion = Nothing, _
                Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            Listar_Problema_Salud_Especialista = DataLayer.DAL.ESPECIALIDAD.Listar_Problema_Salud_Especialista(vPROS_ID, vESP_ID, vCon, vControlEstado:=vControlEstado)

        End Function

        Public Shared Sub Guardar(ByVal vESPECIALIDAD As EntityLayer.EL.ESPECIALIDAD, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.ESPECIALIDAD.Guardar(vESPECIALIDAD, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vESPECIALIDAD As EntityLayer.EL.ESPECIALIDAD, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.ESPECIALIDAD.Eliminar(vESPECIALIDAD, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vESP_ID As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.ESPECIALIDAD
            Dim vL As List(Of EntityLayer.EL.ESPECIALIDAD)
            vL = Buscar(vESP_ID:=vESP_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function


        Public Shared Function sortList_ESPECIALIDAD(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.ESPECIALIDAD)) As List(Of EntityLayer.EL.ESPECIALIDAD)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select col
                    Case "ESP_ID"
                        query = query.OrderBy(Function(x) x.ESP_ID)
                    Case "ESP_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.ESP_DESCRIPCION)
                End Select
            Else
                Select col
                    Case "ESP_ID"
                        query = query.OrderByDescending(Function(x) x.ESP_ID)
                    Case "ESP_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.ESP_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function

    End Class


End Namespace

