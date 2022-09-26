Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class PRESTACION


        Public Shared Function Buscar(Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                      Optional ByVal vUSU_SESSION_ID As Int32? = Nothing, _
                                      Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vTPRE_ID As Decimal? = Nothing, _
                                      Optional ByVal vTPRE_DEFAULT As Boolean? = Nothing, _
                                      Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vPRES_PLAZO_SOLICITUD_MAX As Decimal? = Nothing, _
                                      Optional ByVal vPRES_PLAZO_SIN_COSTO As Decimal? = Nothing, _
                                      Optional ByVal vPRES_ACEPTA_PACIENTE_NUEVO As Boolean? = Nothing, _
                                      Optional ByVal vPRES_ACEPTA_GARANTIA As Boolean? = Nothing, _
                                      Optional ByVal vPRES_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vPAI_ID As Integer? = Nothing, _
                                      Optional ByVal vREG_ID As Integer? = Nothing, _
                                      Optional ByVal vCOM_ID As Int32? = Nothing, _
                                      Optional ByVal vESP_ID As Int32? = Nothing, _
                                      Optional ByVal vPRES_LUGAR_ATENCION As String = Nothing, _
                                      Optional ByVal vPRES_TELEFONO As String = Nothing, _
                                      Optional ByVal vPRES_VALOR_ATENCION As Decimal? = Nothing, _
                                      Optional ByVal vPRES_OBSERVACION As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PRESTACION)
            Try
                Buscar = DataLayer.DAL.PRESTACION.Buscar(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vUSU_SESSION_ID:=vUSU_SESSION_ID, vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vTPRE_DEFAULT:=vTPRE_DEFAULT, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vPRES_PLAZO_SOLICITUD_MAX:=vPRES_PLAZO_SOLICITUD_MAX, vPRES_PLAZO_SIN_COSTO:=vPRES_PLAZO_SIN_COSTO, vPRES_ACEPTA_PACIENTE_NUEVO:=vPRES_ACEPTA_PACIENTE_NUEVO, vPRES_ACEPTA_GARANTIA:=vPRES_ACEPTA_GARANTIA, vPRES_VIGENTE:=vPRES_VIGENTE, vPAI_ID:=vPAI_ID, vREG_ID:=vREG_ID, vCOM_ID:=vCOM_ID, vESP_ID:=vESP_ID, vPRES_LUGAR_ATENCION:=vPRES_LUGAR_ATENCION, vPRES_TELEFONO:=vPRES_TELEFONO, vPRES_VALOR_ATENCION:=vPRES_VALOR_ATENCION, vPRES_OBSERVACION:=vPRES_OBSERVACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarPideHora(Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                      Optional ByVal vFECHA_BUSQUEDA As DateTime? = Nothing, _
                                      Optional ByVal vPAC_ID As Int32? = Nothing, _
                                      Optional ByVal vUSU_SESSION_ID As Int32? = Nothing, _
                                      Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vTPRE_ID As Decimal? = Nothing, _
                                      Optional ByVal vTPRE_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vTPRE_DEFAULT As Boolean? = Nothing, _
                                      Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vPRES_PLAZO_SOLICITUD_MAX As Decimal? = Nothing, _
                                      Optional ByVal vPRES_PLAZO_SIN_COSTO As Decimal? = Nothing, _
                                      Optional ByVal vPRES_ACEPTA_PACIENTE_NUEVO As Boolean? = Nothing, _
                                      Optional ByVal vPRES_ACEPTA_GARANTIA As Boolean? = Nothing, _
                                      Optional ByVal vPRES_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vPAI_ID As Integer? = Nothing, _
                                      Optional ByVal vREG_ID As Integer? = Nothing, _
                                      Optional ByVal vCOM_ID As Int32? = Nothing, _
                                      Optional ByVal vESP_ID As Int32? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PRESTACION)
            Try
                BuscarPideHora = DataLayer.DAL.PRESTACION.BuscarPideHora(vFECHA_BUSQUEDA:=vFECHA_BUSQUEDA, vPRES_ID:=vPRES_ID, vPAC_ID:=vPAC_ID, vUSU_ID:=vUSU_ID, vUSU_SESSION_ID:=vUSU_SESSION_ID, vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vTPRE_DEFAULT:=vTPRE_DEFAULT, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vPRES_PLAZO_SOLICITUD_MAX:=vPRES_PLAZO_SOLICITUD_MAX, vPRES_PLAZO_SIN_COSTO:=vPRES_PLAZO_SIN_COSTO, vPRES_ACEPTA_PACIENTE_NUEVO:=vPRES_ACEPTA_PACIENTE_NUEVO, vPRES_ACEPTA_GARANTIA:=vPRES_ACEPTA_GARANTIA, vPRES_VIGENTE:=vPRES_VIGENTE, vPAI_ID:=vPAI_ID, vREG_ID:=vREG_ID, vCOM_ID:=vCOM_ID, vESP_ID:=vESP_ID, vCon:=vCon, vTPRE_DESCRIPCION:=vTPRE_DESCRIPCION)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function
        Public Shared Function BuscarEspecialista(Optional ByVal vPRES_ID As Decimal? = Nothing, _
            Optional ByVal vUSU_ID As Int32? = Nothing, _
            Optional ByVal vUSU_SESSION_ID As Int32? = Nothing, _
            Optional ByVal vSCLI_ID As Int32? = Nothing, _
            Optional ByVal vCLIS_ID As Int32? = Nothing, _
            Optional ByVal vCLI_ID As String = Nothing, _
            Optional ByVal vTPRE_ID As Decimal? = Nothing, _
            Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
            Optional ByVal vUSU_NOMBRE As String = Nothing, _
            Optional ByVal vUSU_APELLIDO_PAT As String = Nothing, _
            Optional ByVal vUSU_APELLIDO_MAT As String = Nothing, _
            Optional ByVal vPRES_VIGENTE As Boolean? = Nothing, _
            Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.USUARIO)
            Try
                BuscarEspecialista = DataLayer.DAL.PRESTACION.BuscarEspecialista(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vUSU_SESSION_ID:=vUSU_SESSION_ID, vSCLI_ID:=vSCLI_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vUSU_NOMBRE:=vUSU_NOMBRE, vUSU_APELLIDO_PAT:=vUSU_APELLIDO_PAT, vUSU_APELLIDO_MAT:=vUSU_APELLIDO_MAT, vPRES_VIGENTE:=vPRES_VIGENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function buscarPrestacionMedicaAutocomplete(Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                      Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vTPRE_ID As Decimal? = Nothing, _
                                      Optional ByVal vTPRE_DEFAULT As Boolean? = Nothing, _
                                      Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vPRES_PLAZO_SOLICITUD_MAX As Decimal? = Nothing, _
                                      Optional ByVal vPRES_PLAZO_SIN_COSTO As Decimal? = Nothing, _
                                      Optional ByVal vPRES_ACEPTA_PACIENTE_NUEVO As Boolean? = Nothing, _
                                      Optional ByVal vPRES_ACEPTA_GARANTIA As Boolean? = Nothing, _
                                      Optional ByVal vPRES_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vPAI_ID As Integer? = Nothing, _
                                      Optional ByVal vREG_ID As Integer? = Nothing, _
                                      Optional ByVal vCOM_ID As Int32? = Nothing, _
                                      Optional ByVal vESP_ID As Int32? = Nothing, _
                                      Optional ByVal vUSU_SESSION_ID As Int32? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PRESTACION)
            Try
                buscarPrestacionMedicaAutocomplete = DataLayer.DAL.PRESTACION.buscarPrestacionMedicaAutocomplete(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vTPRE_DEFAULT:=vTPRE_DEFAULT, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vPRES_PLAZO_SOLICITUD_MAX:=vPRES_PLAZO_SOLICITUD_MAX, vPRES_PLAZO_SIN_COSTO:=vPRES_PLAZO_SIN_COSTO, vPRES_ACEPTA_PACIENTE_NUEVO:=vPRES_ACEPTA_PACIENTE_NUEVO, vPRES_ACEPTA_GARANTIA:=vPRES_ACEPTA_GARANTIA, vPRES_VIGENTE:=vPRES_VIGENTE, vPAI_ID:=vPAI_ID, vREG_ID:=vREG_ID, vCOM_ID:=vCOM_ID, vESP_ID:=vESP_ID, vUSU_SESSION_ID:=vUSU_SESSION_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarPrestacionAutocomplete(Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                     Optional ByVal vUSU_ID As Int32? = Nothing, _
                                     Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                     Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                     Optional ByVal vCLI_ID As String = Nothing, _
                                     Optional ByVal vTPRE_ID As Decimal? = Nothing, _
                                     Optional ByVal vTPRE_DEFAULT As Boolean? = Nothing, _
                                     Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
                                     Optional ByVal vPRES_PLAZO_SOLICITUD_MAX As Decimal? = Nothing, _
                                     Optional ByVal vPRES_PLAZO_SIN_COSTO As Decimal? = Nothing, _
                                     Optional ByVal vPRES_ACEPTA_PACIENTE_NUEVO As Boolean? = Nothing, _
                                     Optional ByVal vPRES_ACEPTA_GARANTIA As Boolean? = Nothing, _
                                     Optional ByVal vPRES_VIGENTE As Boolean? = Nothing, _
                                     Optional ByVal vPAI_ID As Integer? = Nothing, _
                                     Optional ByVal vREG_ID As Integer? = Nothing, _
                                     Optional ByVal vCOM_ID As Int32? = Nothing, _
                                     Optional ByVal vESP_ID As Int32? = Nothing, _
                                     Optional ByVal vUSU_SESSION_ID As Int32? = Nothing, _
                                     Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PRESTACION)
            Try
                BuscarPrestacionAutocomplete = DataLayer.DAL.PRESTACION.buscarPrestacionAutocomplete(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vTPRE_DEFAULT:=vTPRE_DEFAULT, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vPRES_PLAZO_SOLICITUD_MAX:=vPRES_PLAZO_SOLICITUD_MAX, vPRES_PLAZO_SIN_COSTO:=vPRES_PLAZO_SIN_COSTO, vPRES_ACEPTA_PACIENTE_NUEVO:=vPRES_ACEPTA_PACIENTE_NUEVO, vPRES_ACEPTA_GARANTIA:=vPRES_ACEPTA_GARANTIA, vPRES_VIGENTE:=vPRES_VIGENTE, vPAI_ID:=vPAI_ID, vREG_ID:=vREG_ID, vCOM_ID:=vCOM_ID, vESP_ID:=vESP_ID, vUSU_SESSION_ID:=vUSU_SESSION_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function


        Public Shared Sub Guardar(ByVal vPRESTACION As EntityLayer.EL.PRESTACION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PRESTACION.Guardar(vPRESTACION:=vPRESTACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vPRESTACION As EntityLayer.EL.PRESTACION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PRESTACION.Eliminar(vPRESTACION:=vPRESTACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PRESTACION
            If vPRES_ID.HasValue Then
                Dim vL As List(Of EntityLayer.EL.PRESTACION)
                vL = Buscar(vPRES_ID:=vPRES_ID, _
               vCon:=vCon)
                If vL IsNot Nothing AndAlso vL.Count = 1 Then
                    ObtenerPorId = vL(0)
                Else
                    ObtenerPorId = Nothing
                End If
            Else
                ObtenerPorId = Nothing
            End If
        End Function


        Public Shared Function sortList_PRESTACION(ByVal order As String, _
                                      ByVal col As String, _
                                      ByVal vLista As List(Of EntityLayer.EL.PRESTACION)) As List(Of EntityLayer.EL.PRESTACION)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "EXA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PRES_ACEPTA_GARANTIA)
                    Case "PRES_ACEPTA_PACIENTE_NUEVO"
                        query = query.OrderBy(Function(x) x.PRES_ACEPTA_PACIENTE_NUEVO)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PRES_DESCRIPCION)
                    Case "PRES_ID"
                        query = query.OrderBy(Function(x) x.PRES_ID)
                    Case "PRES_PLAZO_SIN_COSTO"
                        query = query.OrderBy(Function(x) x.PRES_PLAZO_SIN_COSTO)
                    Case "PRES_PLAZO_SOLICITUD_MAX"
                        query = query.OrderBy(Function(x) x.PRES_PLAZO_SOLICITUD_MAX)
                    Case "PRES_VIGENTE"
                        query = query.OrderBy(Function(x) x.PRES_VIGENTE)
                    Case "SCLI_ID"
                        query = query.OrderBy(Function(x) x.SCLI_ID)
                    Case "TPRE_ID"
                        query = query.OrderBy(Function(x) x.TPRE_ID)
                    Case "USU_ID"
                        query = query.OrderBy(Function(x) x.USU_ID)
                End Select
            Else
                Select Case col
                    Case "EXA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PRES_ACEPTA_GARANTIA)
                    Case "PRES_ACEPTA_PACIENTE_NUEVO"
                        query = query.OrderByDescending(Function(x) x.PRES_ACEPTA_PACIENTE_NUEVO)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PRES_DESCRIPCION)
                    Case "PRES_ID"
                        query = query.OrderByDescending(Function(x) x.PRES_ID)
                    Case "PRES_PLAZO_SIN_COSTO"
                        query = query.OrderByDescending(Function(x) x.PRES_PLAZO_SIN_COSTO)
                    Case "PRES_PLAZO_SOLICITUD_MAX"
                        query = query.OrderByDescending(Function(x) x.PRES_PLAZO_SOLICITUD_MAX)
                    Case "PRES_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.PRES_VIGENTE)
                    Case "SCLI_ID"
                        query = query.OrderByDescending(Function(x) x.SCLI_ID)
                    Case "TPRE_ID"
                        query = query.OrderByDescending(Function(x) x.TPRE_ID)
                    Case "USU_ID"
                        query = query.OrderByDescending(Function(x) x.USU_ID)
                End Select
            End If

            Return query.ToList
        End Function

        Public Shared Function BuscarMovimientoMedicosServicios(Optional ByVal vCLIS_ID As Int32? = Nothing, _
    Optional ByVal vTPRE_ID As Int32? = Nothing, _
    Optional ByVal vSCLI_ID As Int32? = Nothing, _
    Optional ByVal vPRES_ID As Int32? = Nothing, _
    Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
    Optional ByVal vFECHA_INI As DateTime? = Nothing, _
    Optional ByVal vFECHA_FIN As DateTime? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As DataTable

            Try
                BuscarMovimientoMedicosServicios = DataLayer.DAL.PRESTACION.BuscarMovimientoMedicosServicios(vCLIS_ID:=vCLIS_ID, vTPRE_ID:=vTPRE_ID, vSCLI_ID:=vSCLI_ID, vPRES_ID:=vPRES_ID, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vFECHA_INI:=vFECHA_INI, vFECHA_FIN:=vFECHA_FIN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

    End Class


End Namespace

