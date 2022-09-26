Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports EntityLayer
Imports Utilidades
Imports System.IO
Namespace BL
    Public Class RESERVA


        Public Shared Function Buscar(Optional ByVal vRESE_ID As Int32? = Nothing, _
    Optional ByVal vTIAT_ID As Int32? = Nothing, _
    Optional ByVal vSISS_ID As Int32? = Nothing, _
    Optional ByVal vERES_ID As Int32? = Nothing, _
    Optional ByVal vPAC_ID As Int32? = Nothing, _
    Optional ByVal vEXA_ID As Short? = Nothing, _
    Optional ByVal vPRES_ID As Decimal? = Nothing, _
    Optional ByVal vHORD_ID As Int32? = Nothing, _
    Optional ByVal vRESE_HORA_INI As TimeSpan? = Nothing, _
    Optional ByVal vRESE_HORA_FIN As TimeSpan? = Nothing, _
    Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
    Optional ByVal vRESE_FECHA_REGISTRO As DateTime? = Nothing, _
    Optional ByVal vRESE_PAC_NUEVO As Boolean? = Nothing, _
    Optional ByVal vRESE_OBSERVACIONES As String = Nothing, _
    Optional ByVal vRESE_ORDEN As Decimal? = Nothing, _
    Optional ByVal vRESE_VALOR_ATENCION As Decimal? = Nothing, _
    Optional ByVal vRESE_PAGO_LIBERADO As Boolean? = Nothing, _
    Optional ByVal vRESE_VIGENTE As Boolean? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA)
            Try
                Buscar = DataLayer.DAL.RESERVA.Buscar(vRESE_ID:=vRESE_ID, vTIAT_ID:=vTIAT_ID, vSISS_ID:=vSISS_ID, vERES_ID:=vERES_ID, vPAC_ID:=vPAC_ID, vEXA_ID:=vEXA_ID, vPRES_ID:=vPRES_ID, vHORD_ID:=vHORD_ID, vRESE_HORA_INI:=vRESE_HORA_INI, vRESE_HORA_FIN:=vRESE_HORA_FIN, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vRESE_FECHA_REGISTRO:=vRESE_FECHA_REGISTRO, vRESE_PAC_NUEVO:=vRESE_PAC_NUEVO, vRESE_OBSERVACIONES:=vRESE_OBSERVACIONES, vRESE_ORDEN:=vRESE_ORDEN, vRESE_VALOR_ATENCION:=vRESE_VALOR_ATENCION, vRESE_PAGO_LIBERADO:=vRESE_PAGO_LIBERADO, vRESE_VIGENTE:=vRESE_VIGENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarRepetida(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                            Optional ByVal vCLI_ID As String = Nothing, _
                                            Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                            Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                            Optional ByVal vPRES_ID As Int32? = Nothing, _
                                            Optional ByVal vHORD_ID As Int32? = Nothing, _
                                            Optional ByVal vPAC_ID As Int32? = Nothing, _
                                            Optional ByVal vRESE_HORA_INI As TimeSpan? = Nothing, _
                                            Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA)
            Try
                BuscarRepetida = DataLayer.DAL.RESERVA.BuscarRepetida(vRESE_ID:=vRESE_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vSCLI_ID:=vSCLI_ID, vPRES_ID:=vPRES_ID, vHORD_ID:=vHORD_ID, vPAC_ID:=vPAC_ID, vRESE_HORA_INI:=vRESE_HORA_INI, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarUltimaAtencion(Optional ByVal vRESE_ID As Int32? = Nothing, _
      Optional ByVal vPAC_ID As Int32? = Nothing, _
      Optional ByVal vPRES_ID As Decimal? = Nothing, _
      Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA)
            Try
                BuscarUltimaAtencion = DataLayer.DAL.RESERVA.BuscarUltimaAtencion(vRESE_ID:=vRESE_ID, vPAC_ID:=vPAC_ID, vPRES_ID:=vPRES_ID, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function



        Public Shared Function buscarAtencion(Optional ByVal vPRES_ID As Decimal? = Nothing, _
   Optional ByVal vRESE_FECHA_RESERVA As Date? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA)
            Try
                buscarAtencion = DataLayer.DAL.RESERVA.buscarAtencion(vPRES_ID:=vPRES_ID, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Sub GuardarCambioEstado(ByVal vRESERVA As EntityLayer.EL.RESERVA, _
                                  Optional ByVal vTIPU_ID As Int32? = Nothing, _
                                  Optional ByVal vUSU_ID As Int32? = Nothing, _
                                  Optional ByVal vERES_ID As Int32? = Nothing, _
                                  Optional ByVal vLOGE_COMENTARIO As String = Nothing, _
                                  Optional ByVal vCon As Conexion = Nothing)
            Try
                If vERES_ID.HasValue Then

                    DataLayer.DAL.RESERVA.GuardarCambioEstado(vRESERVA:=vRESERVA, vTIPU_ID:=vTIPU_ID, vUSU_ID:=vUSU_ID, vERES_ID:=vERES_ID, vLOGE_COMENTARIO:=vLOGE_COMENTARIO, vCon:=vCon)
                    'Dim vl As New EL.RESERVA_LOG_ESTADO
                    'vl.RESE_ID = vRESERVA.RESE_ID
                    'vl.ERES_ID = vRESERVA.ERES_ID
                    'vl.LOGE_FECHA_REGISTRO = Nothing
                    'vl.USU_ID = vUSU_ID
                    'vl.LOGE_COMENTARIO = vLOGE_COMENTARIO
                    'BL.RESERVA_LOG_ESTADO.Guardar(vRESERVA_LOG_ESTADO:=vl, vCon:=vCon)
                End If

            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub Guardar(ByVal vRESERVA As EntityLayer.EL.RESERVA, _
                                  Optional ByVal vTIPU_ID As Int32? = Nothing, _
                                  Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RESERVA.Guardar(vRESERVA:=vRESERVA, vTIPU_ID:=vTIPU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Function ValidarRegistroReserva(ByVal vRESERVA As EntityLayer.EL.RESERVA, _
                                                      Optional ByVal vTIPU_ID As Int32? = Nothing, _
                                                    Optional ByVal vCon As Conexion = Nothing) As Boolean
            Return DataLayer.DAL.RESERVA.ValidarRegistroReserva(vRESERVA:=vRESERVA, vTIPU_ID:=vTIPU_ID, vCon:=vCon)
        End Function

        Public Shared Function ValidacionPrevia(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                                   Optional ByVal vVERSION_CSA As String = Nothing, _
                                                    Optional ByVal vCLI_ID As String = Nothing, _
                                                    Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                                    Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                                       Optional ByVal vTIPU_ID As Int32? = Nothing, _
                                                    Optional ByVal vPRES_ID As Int32? = Nothing, _
                                                    Optional ByVal vHORD_ID As Int32? = Nothing, _
                                                    Optional ByVal vPAC_ID As Int32? = Nothing, _
                                                    Optional ByVal vRESE_HORA_INI As TimeSpan? = Nothing, _
                                                    Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
                                                   Optional ByVal vCon As Conexion = Nothing) As String
            Return DataLayer.DAL.RESERVA.ValidacionPrevia(vRESE_ID:=vRESE_ID, vVERSION_CSA:=vVERSION_CSA, vTIPU_ID:=vTIPU_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vSCLI_ID:=vSCLI_ID, vPRES_ID:=vPRES_ID, vHORD_ID:=vHORD_ID, vPAC_ID:=vPAC_ID, vRESE_HORA_INI:=vRESE_HORA_INI, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vCon:=vCon)
        End Function
        Public Shared Function ValidarRestriccionAtencion(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                                    Optional ByVal vCLI_ID As String = Nothing, _
                                                    Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                                    Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                                    Optional ByVal vPRES_ID As Int32? = Nothing, _
                                                    Optional ByVal vHORD_ID As Int32? = Nothing, _
                                                    Optional ByVal vPAC_ID As Int32? = Nothing, _
                                                    Optional ByVal vRESE_HORA_INI As TimeSpan? = Nothing, _
                                                    Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
                                                    Optional ByVal vSISS_ID As Int32? = Nothing, _
                                                   Optional ByVal vCon As Conexion = Nothing) As String
            Return DataLayer.DAL.RESERVA.ValidarRestriccionAtencion(vRESE_ID:=vRESE_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vSCLI_ID:=vSCLI_ID, vPRES_ID:=vPRES_ID, vHORD_ID:=vHORD_ID, vPAC_ID:=vPAC_ID, vRESE_HORA_INI:=vRESE_HORA_INI, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vSISS_ID:=vSISS_ID, vCon:=vCon)
        End Function
        Public Shared Function ValidarConflictoRango(ByVal vRANGO As String, _
                                            Optional ByVal vDATA_TYPE As String = Nothing, _
                                            Optional ByVal vTIPO_INTERVALO As String = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing) As Boolean
            Return DataLayer.DAL.RESERVA.ValidarConflictoRango(vRANGO:=vRANGO, vDATA_TYPE:=vDATA_TYPE, vTIPO_INTERVALO:=vTIPO_INTERVALO, vCon:=vCon)
        End Function
        Public Shared Sub AnularReserva(ByVal vRESERVA As EntityLayer.EL.RESERVA, Optional ByVal vCon As Conexion = Nothing)
            Try
                If vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.paciente_recibido OrElse _
                    vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.pago_liberado_por_confirmar OrElse _
                    vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.pago_liberado_rechazado OrElse _
                    vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.pago_liberado_confirmado OrElse _
                    vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.paciente_atendido OrElse _
                    vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.pagado OrElse _
                    vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.paciente_en_atencion Then
                    Throw New Exception("No es posible eliminar reservas que ya pasaron por atención")
                Else
                    vRESERVA.RESE_VIGENTE = False
                    vRESERVA.ERES_ID = Utilidades.Generico.ESTADO_RESERVA.anulado
                    DataLayer.DAL.RESERVA.Guardar(vRESERVA:=vRESERVA, vCon:=vCon)
                    If vRESERVA.RESE_ID.HasValue Then
                        Dim vlog As New EL.RESERVA_LOG_ESTADO()
                        vlog.RESE_ID = vRESERVA.RESE_ID
                        vlog.ERES_ID = vRESERVA.ERES_ID
                        vlog.USU_ID = Nothing
                        vlog.LOGE_COMENTARIO = "ANULADO POR PACIENTE"
                        vlog.LOGE_FECHA_REGISTRO = DateTime.Now
                        BL.RESERVA_LOG_ESTADO.Guardar(vRESERVA_LOG_ESTADO:=vlog, vCon:=vCon)
                    End If
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vRESERVA As EntityLayer.EL.RESERVA, Optional ByVal vUSU_SESSION As Int32? = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                If vRESERVA.RESE_ID.HasValue Then
                    DataLayer.DAL.RESERVA.Eliminar(vRESERVA:=vRESERVA, vUSU_SESSION:=vUSU_SESSION, vCon:=vCon)
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub EliminarPago(ByVal vRESERVA As EntityLayer.EL.RESERVA, Optional ByVal vUSU_SESSION As Int32? = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                If vRESERVA.RESE_ID.HasValue Then
                    DataLayer.DAL.RESERVA.EliminarPago(vRESERVA:=vRESERVA, vUSU_SESSION:=vUSU_SESSION, vCon:=vCon)
                    GuardarCambioEstado(vRESERVA:=vRESERVA, vUSU_ID:=vUSU_SESSION, vERES_ID:=Utilidades.Generico.ESTADO_RESERVA.paciente_recibido, vLOGE_COMENTARIO:="PAGO ATENCIÓN ELIMINADO", vCon:=vCon)
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vRESE_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.RESERVA
            If vRESE_ID.HasValue Then
                Dim vL As List(Of EntityLayer.EL.RESERVA)
                vL = Buscar(vRESE_ID:=vRESE_ID, _
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


        Public Shared Function sortList_RESERVA(ByVal order As String, _
                                             ByVal col As String, _
                                             ByVal vLista As List(Of EntityLayer.EL.RESERVA)) As List(Of EntityLayer.EL.RESERVA)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "DIAS_ULTIMA_ATENCION"
                        query = query.OrderBy(Function(x) x.DIAS_ULTIMA_ATENCION)
                    Case "ERES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.ERES_DESCRIPCION)
                    Case "ERES_ID"
                        query = query.OrderBy(Function(x) x.ERES_ID)
                    Case "EXA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderBy(Function(x) x.EXA_ID)
                    Case "HORD_ID"
                        query = query.OrderBy(Function(x) x.HORD_ID)
                    Case "PAC_ID"
                        query = query.OrderBy(Function(x) x.PAC_ID)
                    Case "PAC_NOMBRE"
                        query = query.OrderBy(Function(x) x.PAC_NOMBRE)
                    Case "USU_NACIMIENTO"
                        query = query.OrderBy(Function(x) x.PAC_PASAPORTE)
                    Case "PAC_RUT"
                        query = query.OrderBy(Function(x) x.PAC_RUT)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PRES_DESCRIPCION)
                    Case "PRES_ID"
                        query = query.OrderBy(Function(x) x.PRES_ID)
                    Case "RESE_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.RESE_FECHA_REGISTRO)
                    Case "RESE_FECHA_RESERVA"
                        query = query.OrderBy(Function(x) x.RESE_FECHA_RESERVA)
                    Case "RESE_HORA_FIN"
                        query = query.OrderBy(Function(x) x.RESE_HORA_FIN)
                    Case "RESE_HORA_INI"
                        query = query.OrderBy(Function(x) x.RESE_HORA_INI)
                    Case "RESE_ID"
                        query = query.OrderBy(Function(x) x.RESE_ID)
                    Case "RESE_OBSERVACIONES"
                        query = query.OrderBy(Function(x) x.RESE_OBSERVACIONES)
                    Case "RESE_ORDEN"
                        query = query.OrderBy(Function(x) x.RESE_ORDEN)
                    Case "RESE_PAC_NUEVO"
                        query = query.OrderBy(Function(x) x.RESE_PAC_NUEVO)
                    Case "RESE_PAGO_LIBERADO"
                        query = query.OrderBy(Function(x) x.RESE_PAGO_LIBERADO)
                    Case "RESE_VALOR_ATENCION"
                        query = query.OrderBy(Function(x) x.RESE_VALOR_ATENCION)
                    Case "RESE_VIGENTE"
                        query = query.OrderBy(Function(x) x.RESE_VIGENTE)
                    Case "SISS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.SISS_DESCRIPCION)
                    Case "SISS_ID"
                        query = query.OrderBy(Function(x) x.SISS_ID)
                    Case "TIAT_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TIAT_DESCRIPCION)
                    Case "TIAT_ID"
                        query = query.OrderBy(Function(x) x.TIAT_ID)
                End Select
            Else
                Select Case col
                    Case "DIAS_ULTIMA_ATENCION"
                        query = query.OrderByDescending(Function(x) x.DIAS_ULTIMA_ATENCION)
                    Case "ERES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.ERES_DESCRIPCION)
                    Case "ERES_ID"
                        query = query.OrderByDescending(Function(x) x.ERES_ID)
                    Case "EXA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderByDescending(Function(x) x.EXA_ID)
                    Case "HORD_ID"
                        query = query.OrderByDescending(Function(x) x.HORD_ID)
                    Case "PAC_ID"
                        query = query.OrderByDescending(Function(x) x.PAC_ID)
                    Case "PAC_NOMBRE"
                        query = query.OrderByDescending(Function(x) x.PAC_NOMBRE)
                    Case "USU_NACIMIENTO"
                        query = query.OrderByDescending(Function(x) x.PAC_PASAPORTE)
                    Case "PAC_RUT"
                        query = query.OrderByDescending(Function(x) x.PAC_RUT)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PRES_DESCRIPCION)
                    Case "PRES_ID"
                        query = query.OrderByDescending(Function(x) x.PRES_ID)
                    Case "RESE_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.RESE_FECHA_REGISTRO)
                    Case "RESE_FECHA_RESERVA"
                        query = query.OrderByDescending(Function(x) x.RESE_FECHA_RESERVA)
                    Case "RESE_HORA_FIN"
                        query = query.OrderByDescending(Function(x) x.RESE_HORA_FIN)
                    Case "RESE_HORA_INI"
                        query = query.OrderByDescending(Function(x) x.RESE_HORA_INI)
                    Case "RESE_ID"
                        query = query.OrderByDescending(Function(x) x.RESE_ID)
                    Case "RESE_OBSERVACIONES"
                        query = query.OrderByDescending(Function(x) x.RESE_OBSERVACIONES)
                    Case "RESE_ORDEN"
                        query = query.OrderByDescending(Function(x) x.RESE_ORDEN)
                    Case "RESE_PAC_NUEVO"
                        query = query.OrderByDescending(Function(x) x.RESE_PAC_NUEVO)
                    Case "RESE_PAGO_LIBERADO"
                        query = query.OrderByDescending(Function(x) x.RESE_PAGO_LIBERADO)
                    Case "RESE_VALOR_ATENCION"
                        query = query.OrderByDescending(Function(x) x.RESE_VALOR_ATENCION)
                    Case "RESE_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.RESE_VIGENTE)
                    Case "SISS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.SISS_DESCRIPCION)
                    Case "SISS_ID"
                        query = query.OrderByDescending(Function(x) x.SISS_ID)
                    Case "TIAT_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TIAT_DESCRIPCION)
                    Case "TIAT_ID"
                        query = query.OrderByDescending(Function(x) x.TIAT_ID)

                End Select
            End If

            Return query.ToList
        End Function


        Public Shared Function sortList_RESERVA_LIGHT(ByVal order As String, _
                                             ByVal col As String, _
                                             ByVal vLista As List(Of EntityLayer.EL.RESERVA_LIGHT)) As List(Of EntityLayer.EL.RESERVA_LIGHT)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "ERES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.ERES_DESCRIPCION)
                    Case "ERES_ID"
                        query = query.OrderBy(Function(x) x.ERES_ID)
                    Case "PAC_ID"
                        query = query.OrderBy(Function(x) x.PAC_ID)
                    Case "PAC_NOMBRE"
                        query = query.OrderBy(Function(x) x.PAC_NOMBRE)
                    Case "RESE_FECHA_RESERVA"
                        query = query.OrderBy(Function(x) x.RESE_FECHA_RESERVA)
                    Case "RESE_HORA_FIN"
                        query = query.OrderBy(Function(x) x.RESE_HORA_FIN)
                    Case "RESE_HORA_INI"
                        query = query.OrderBy(Function(x) x.RESE_HORA_INI)
                    Case "RESE_ID"
                        query = query.OrderBy(Function(x) x.RESE_ID)
                    Case "RESE_OBSERVACIONES"
                        query = query.OrderBy(Function(x) x.RESE_OBSERVACIONES)
                    Case "RESE_ORDEN"
                        query = query.OrderBy(Function(x) x.RESE_ORDEN)
                    Case "SISS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.SISS_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "ERES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.ERES_DESCRIPCION)
                    Case "ERES_ID"
                        query = query.OrderByDescending(Function(x) x.ERES_ID)
                    Case "PAC_ID"
                        query = query.OrderByDescending(Function(x) x.PAC_ID)
                    Case "PAC_NOMBRE"
                        query = query.OrderByDescending(Function(x) x.PAC_NOMBRE)
                    Case "RESE_FECHA_RESERVA"
                        query = query.OrderByDescending(Function(x) x.RESE_FECHA_RESERVA)
                    Case "RESE_HORA_FIN"
                        query = query.OrderByDescending(Function(x) x.RESE_HORA_FIN)
                    Case "RESE_HORA_INI"
                        query = query.OrderByDescending(Function(x) x.RESE_HORA_INI)
                    Case "RESE_ID"
                        query = query.OrderByDescending(Function(x) x.RESE_ID)
                    Case "RESE_OBSERVACIONES"
                        query = query.OrderByDescending(Function(x) x.RESE_OBSERVACIONES)
                    Case "RESE_ORDEN"
                        query = query.OrderByDescending(Function(x) x.RESE_ORDEN)
                    Case "SISS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.SISS_DESCRIPCION)

                End Select
            End If

            Return query.ToList
        End Function

        Public Shared Function validar(ByVal vPRESTACION As EL.PRESTACION, ByVal vRESERVA As EL.RESERVA, ByVal vUSU_ID_SESSION As Int32?, ByVal vCLI_ID_SESSION As Int32?) As Boolean
            If vPRESTACION Is Nothing Then
                Throw New Exception("No se estableció propiedad prestación.")
            ElseIf Not vRESERVA.RESE_FECHA_RESERVA.HasValue Then
                Throw New Exception("No se estableció fecha reserva.")
            ElseIf Not vRESERVA.RESE_HORA_INI.HasValue Then
                Throw New Exception("No se estableció hora reserva.")
            End If
            Return True
        End Function


        Public Shared Function validarWeb(ByVal vPRESTACION As EL.PRESTACION, ByVal vRESERVA As EL.RESERVA, ByVal vDETALLE_HORA_INI As TimeSpan?, ByVal vDETALLE_HORA_FIN As TimeSpan?, ByVal vCLI_ID_SESSION As Int32?, Optional ByVal vCon As Conexion = Nothing) As Boolean
            If vPRESTACION IsNot Nothing AndAlso vRESERVA IsNot Nothing Then
                If vRESERVA.EXA_ID.HasValue = False AndAlso vPRESTACION.TPRE_DEFAULT = False Then
                    Throw New Exception("Debe seleccionar un examen")
                End If

                Dim vmsg As String
                vmsg = BL.RESERVA.ValidacionPrevia(vRESE_ID:=Nothing, _
                                                    vCLI_ID:=vCLI_ID_SESSION, _
                                                    vCLIS_ID:=Nothing, _
                                                    vHORD_ID:=If(vRESERVA Is Nothing, Nothing, vRESERVA.HORD_ID), _
                                                    vPAC_ID:=If(vRESERVA Is Nothing, Nothing, vRESERVA.PAC_ID), _
                                                    vPRES_ID:=If(vRESERVA Is Nothing, Nothing, vRESERVA.PRES_ID), _
                                                    vRESE_FECHA_RESERVA:=If(vRESERVA Is Nothing, Nothing, vRESERVA.RESE_FECHA_RESERVA), _
                                                    vRESE_HORA_INI:=If(vRESERVA Is Nothing, Nothing, vRESERVA.RESE_HORA_INI), _
                                                    vSCLI_ID:=Nothing)
                If String.IsNullOrEmpty(vmsg) = False Then
                    Throw New Exception(vmsg)
                End If

                'Dim vl As List(Of EL.RESERVA) = BL.HORARIO_SEMANAL_DETALLE.BuscarReservas(vHORD_ID:=vRESERVA.HORD_ID, _
                '                                                                           vDETALLE_HORA_INI:=vDETALLE_HORA_INI, _
                '                                                                           vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, _
                '                                                                           vFECHA:=vRESERVA.RESE_FECHA_RESERVA, _
                '                                                                           vAUSENCIA_HORARIO:=False, _
                '                                                                           vFERIADO_HORARIO:=False, _
                '                                                                           vPLAZO_MAXIMO_HORARIO:=False)
                'If vl IsNot Nothing AndAlso vl.Count > 0 Then
                '    Throw New Exception("El bloque horario seleccionado fue reservado, por favor intenta en horario")
                'End If

                Return True

            End If

            Return True
        End Function

        Public Shared Sub GuardarWeb(ByVal vPRESTACION As EL.PRESTACION, ByVal vRESERVA As EL.RESERVA, ByVal vUSU_ID_SESSION As Int32?, ByVal vCLI_ID_SESSION As Int32?, ByVal vDETALLE_HORA_INI As TimeSpan?, ByVal vDETALLE_HORA_FIN As TimeSpan?, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vLISTA_EXAMENES As List(Of EL.EXAMEN_RESERVA) = Nothing)
            Try
                If validarWeb(vPRESTACION:=vPRESTACION, vRESERVA:=vRESERVA, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vCLI_ID_SESSION:=vCLI_ID_SESSION, vCon:=vCon) Then
                    BL.RESERVA.GuardarFull(vPRESTACION:=vPRESTACION, vRESERVA:=vRESERVA, vTIPU_ID_SESSION:=Nothing, vUSU_ID_SESSION:=vUSU_ID_SESSION, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vLISTA_EXAMENES:=vLISTA_EXAMENES)
                    'Guardar(vPRESTACION:=vPRESTACION, vRESERVA:=vRESERVA, vTIPU_ID_SESSION:=Nothing, vUSU_ID_SESSION:=vUSU_ID_SESSION, vCLI_ID_SESSION:=vCLI_ID_SESSION, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vCon:=vCon, vLISTA_EXAMENES:=vLISTA_EXAMENES)
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub GuardarReservaFicticia(ByVal vRESERVA As EL.RESERVA, ByVal vUSU_ID_SESSION As Int32?, ByVal vCLI_ID_SESSION As Int32?, ByVal vDETALLE_HORA_INI As TimeSpan?, ByVal vDETALLE_HORA_FIN As TimeSpan?, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vTIPU_ID_SESSION As Int32? = Nothing)
            Try
                If vRESERVA.RESE_FECHA_RESERVA < Date.Now.Date Then
                    Throw New Exception("La fecha de reserva ya no está vigente")
                End If

                guardar_reserva(vRESERVA:=vRESERVA, vTIPU_ID_SESSION:=vTIPU_ID_SESSION, vUSU_ID_SESSION:=vUSU_ID_SESSION, vCLI_ID_SESSION:=vCLI_ID_SESSION, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Function validarFull(ByVal vPRESTACION As EL.PRESTACION, ByVal vRESERVA As EL.RESERVA, ByVal vTIPU_ID_SESSION As Int32?) As Boolean
            If Not vRESERVA.RESE_FECHA_RESERVA.HasValue Then
                Throw New Exception("No se estableció fecha reserva.")
            ElseIf Not vRESERVA.RESE_HORA_INI.HasValue Then
                Throw New Exception("No se estableció hora reserva.")
            ElseIf vRESERVA.RESE_FECHA_RESERVA < Date.Now.Date Then
                Throw (New Exception("La fecha de reserva ya no está vigente"))
            End If
            Return True
        End Function

        Public Shared Sub GuardarFull(ByVal vPRESTACION As EL.PRESTACION, _
                                      ByVal vRESERVA As EL.RESERVA, _
                                      ByVal vUSU_ID_SESSION As Int32?, _
                                      ByVal vDETALLE_HORA_INI As TimeSpan?, _
                                      ByVal vDETALLE_HORA_FIN As TimeSpan?, _
                                      Optional ByVal vTIPU_ID_SESSION As Int32? = Nothing, _
                                      Optional ByVal vLISTA_EXAMENES As List(Of EL.EXAMEN_RESERVA) = Nothing, _
                                      Optional ByVal vLISTA_ESPERA As EntityLayer.EL.LISTA_ESPERA = Nothing, _
                                      Optional ByVal vBORRAR_LISTA_ESPERA As Boolean? = Nothing, _
                                      Optional ByVal vEnviarEmail As Boolean? = Nothing, _
                                      Optional ByVal vCONTRASTE As Boolean? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing,
                                      Optional ByVal vXML_PREPARACION As String = Nothing,
                                      Optional ByVal vEXA_ID_SELECCIONADOS As String = Nothing,
                                      Optional ByVal path As String = Nothing,
                                      Optional ByVal reportCheckList As MemoryStream = Nothing)
            Try
                If validarFull(vPRESTACION:=vPRESTACION, vRESERVA:=vRESERVA, vTIPU_ID_SESSION:=vTIPU_ID_SESSION) Then
                    vRESERVA.DETALLE_HORA_INI = vDETALLE_HORA_INI
                    vRESERVA.DETALLE_HORA_FIN = vDETALLE_HORA_FIN
                    Dim vl As New System.Text.StringBuilder
                    If vLISTA_EXAMENES IsNot Nothing Then
                        For Each ve As EL.EXAMEN_RESERVA In vLISTA_EXAMENES
                            If ve.EXA_ID.HasValue Then
                                vl.Append(ve.EXA_ID.ToString).Append("|")
                            End If
                        Next
                    End If
                    Dim vEnviarEmailAux As Boolean = False
                    vEnviarEmailAux = DataLayer.DAL.RESERVA.GuardarFull(vRESERVA:=vRESERVA, _
                                                      vLISTA_EXAMENES:=vl.ToString, _
                                                      vTIPU_ID_SESSION:=vTIPU_ID_SESSION, _
                                                      vUSU_ID_SESSION:=vUSU_ID_SESSION, _
                                                      vLISTA_ESPERA:=vLISTA_ESPERA, _
                                                      vBORRAR_LISTA_ESPERA:=vBORRAR_LISTA_ESPERA, _
                                                      vCon:=vCon,
                                                      vXML_PREPARACION:=vXML_PREPARACION,
                                                      vEXA_ID_SELECCIONADOS:=vEXA_ID_SELECCIONADOS,
                                                      vCONTRASTE:=vCONTRASTE)

                    If vEnviarEmail.HasValue = False Then
                        vEnviarEmail = vEnviarEmailAux
                    End If

                    If vEnviarEmail Then
                        Dim vRESERVA_LOG_ESTADO As New EL.RESERVA_LOG_ESTADO
                        vRESERVA_LOG_ESTADO.ERES_ID = vRESERVA.ERES_ID
                        vRESERVA_LOG_ESTADO.RESE_ID = vRESERVA.RESE_ID
                        If vEnviarEmail And vRESERVA_LOG_ESTADO.ERES_ID <> Generico.ESTADO_RESERVA.en_proceso Then

                            Dim preparativos As Boolean = False
                            If vXML_PREPARACION IsNot Nothing AndAlso Not vXML_PREPARACION.Equals("") Then
                                preparativos = True
                            End If

                            RESERVA_LOG_ESTADO.EnviarCorreo(vRESERVA_LOG_ESTADO:=vRESERVA_LOG_ESTADO,
                                                            vCon:=vCon,
                                                            vEXA_ID_SELECCIONADOS:=vEXA_ID_SELECCIONADOS,
                                                            vPath_instructivo:=path,
                                                            reportCheckList:=reportCheckList,
                                                            XML_PREPARATIVO:=vXML_PREPARACION,
                                                            vRESE_ID:=vRESERVA.RESE_ID, preparativos:=preparativos,
                                                            vUSU_ID_SESSION:=vUSU_ID_SESSION,
                                                            vRESERVA:=vRESERVA)
                        End If
                    End If
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub Guardar(ByVal vPRESTACION As EL.PRESTACION, ByVal vRESERVA As EL.RESERVA, ByVal vUSU_ID_SESSION As Int32?, ByVal vCLI_ID_SESSION As Int32?, ByVal vDETALLE_HORA_INI As TimeSpan?, ByVal vDETALLE_HORA_FIN As TimeSpan?, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vTIPU_ID_SESSION As Int32? = Nothing, Optional ByVal vLISTA_EXAMENES As List(Of EL.EXAMEN_RESERVA) = Nothing)
            Try
                If validar(vPRESTACION:=vPRESTACION, vRESERVA:=vRESERVA, vUSU_ID_SESSION:=vUSU_ID_SESSION, vCLI_ID_SESSION:=vCLI_ID_SESSION) Then
                    vRESERVA.DETALLE_HORA_INI = vDETALLE_HORA_INI
                    vRESERVA.DETALLE_HORA_FIN = vDETALLE_HORA_FIN
                    If vRESERVA.EXA_ID.HasValue = False Then
                        guardar_reserva(vRESERVA:=vRESERVA, vTIPU_ID_SESSION:=vTIPU_ID_SESSION, vUSU_ID_SESSION:=vUSU_ID_SESSION, vCLI_ID_SESSION:=vCLI_ID_SESSION, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vCon:=vCon, vLISTA_EXAMENES:=vLISTA_EXAMENES)
                    Else
                        guardar_reserva_examen(vRESERVA:=vRESERVA, vTIPU_ID_SESSION:=vTIPU_ID_SESSION, vUSU_ID_SESSION:=vUSU_ID_SESSION, vCLI_ID_SESSION:=vCLI_ID_SESSION, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vCon:=vCon, vLISTA_EXAMENES:=vLISTA_EXAMENES)
                    End If
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub guardar_reserva(ByVal vRESERVA As EL.RESERVA, ByVal vUSU_ID_SESSION As Int32?, ByVal vCLI_ID_SESSION As Int32?, ByVal vDETALLE_HORA_INI As TimeSpan?, ByVal vDETALLE_HORA_FIN As TimeSpan?, Optional ByVal vCon As Utilidades.Conexion = Nothing, Optional ByVal vTIPU_ID_SESSION As Int32? = Nothing, Optional ByVal vLISTA_EXAMENES As List(Of EL.EXAMEN_RESERVA) = Nothing)
            If BL.RESERVA.ValidarRegistroReserva(vRESERVA:=vRESERVA, vTIPU_ID:=vTIPU_ID_SESSION, vCon:=vCon) Then
                BL.RESERVA.Guardar(vRESERVA:=vRESERVA, vCon:=vCon, vTIPU_ID:=vTIPU_ID_SESSION)
                If vRESERVA.RESE_ID.HasValue Then
                    If vLISTA_EXAMENES IsNot Nothing Then
                        BL.EXAMEN_RESERVA.EliminarByReserva(vRESE_ID:=vRESERVA.RESE_ID, vCon:=vCon)
                        If vLISTA_EXAMENES IsNot Nothing Then
                            For Each ve As EL.EXAMEN_RESERVA In vLISTA_EXAMENES
                                ve.Existe = False
                                ve.RESE_ID = vRESERVA.RESE_ID
                                ve.EXA_ID = ve.EXA_ID
                                BL.EXAMEN_RESERVA.Guardar(ve, vCon:=vCon)
                            Next
                        End If

                    End If
                End If

                If vRESERVA.RESE_ID.HasValue Then 'GENERA LOG Y ENVIA CORREO SOLO CUANDO CREA UNA NUEVA RESERVA
                    Dim vlog As New EL.RESERVA_LOG_ESTADO()
                    vlog.RESE_ID = vRESERVA.RESE_ID
                    vlog.ERES_ID = vRESERVA.ERES_ID
                    vlog.USU_ID = vUSU_ID_SESSION
                    vlog.LOGE_COMENTARIO = vRESERVA.RESE_OBSERVACIONES
                    vlog.LOGE_FECHA_REGISTRO = DateTime.Now
                    BL.RESERVA_LOG_ESTADO.Guardar(vRESERVA_LOG_ESTADO:=vlog, vCon:=vCon)
                End If
            End If
        End Sub

        Public Shared Sub guardar_reserva_examen(ByVal vRESERVA As EL.RESERVA, ByVal vUSU_ID_SESSION As Int32?, ByVal vCLI_ID_SESSION As Int32?, ByVal vDETALLE_HORA_INI As TimeSpan?, ByVal vDETALLE_HORA_FIN As TimeSpan?, Optional ByVal vCon As Utilidades.Conexion = Nothing, Optional ByVal vTIPU_ID_SESSION As Int32? = Nothing, Optional ByVal vLISTA_EXAMENES As List(Of EL.EXAMEN_RESERVA) = Nothing)
            If vRESERVA IsNot Nothing Then
                If vRESERVA.RESE_TOTAL_BLOQUES.HasValue Then
                    Dim vHoraFin As TimeSpan = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.Next_N(vPRES_ID:=vRESERVA.PRES_ID, vHORD_ID:=vRESERVA.HORD_ID, vRESE_FECHA_RESERVA:=vRESERVA.RESE_FECHA_RESERVA, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vRESE_TOTAL_BLOQUES:=vRESERVA.RESE_TOTAL_BLOQUES, vRESE_ID:=vRESERVA.RESE_ID, vCon:=vCon)
                    vRESERVA.RESE_HORA_FIN = vHoraFin
                End If
                guardar_reserva(vRESERVA:=vRESERVA, vTIPU_ID_SESSION:=vTIPU_ID_SESSION, vUSU_ID_SESSION:=vUSU_ID_SESSION, vCLI_ID_SESSION:=vCLI_ID_SESSION, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vCon:=vCon, vLISTA_EXAMENES:=vLISTA_EXAMENES)
            End If
        End Sub

        Public Shared Sub guardar_proximo_control(ByVal vRESERVA As EL.RESERVA, _
                                                          ByVal vUSU_ID_SESSION As Int32?, _
                                                          Optional ByVal vTIPU_ID_SESSION As Int32? = Nothing, _
                                                          Optional ByVal vCon As Utilidades.Conexion = Nothing)
            If vRESERVA IsNot Nothing And vUSU_ID_SESSION IsNot Nothing Then
                If vTIPU_ID_SESSION = Generico.TIPO_USUARIO.ESPECIALISTA Then
                    DataLayer.DAL.RESERVA.GuardarProximoControl(vRESERVA:=vRESERVA, vUSU_ID:=vUSU_ID_SESSION, vCon:=vCon)
                Else
                    Throw New Exception("Perfil no puede registrar este tipo de reserva")
                End If
            End If
        End Sub

        Public Shared Function BuscarReservasPaciente(Optional ByVal vPAC_RUT As String = Nothing, _
                                                      Optional ByVal vPAC_PASAPORTE As String = Nothing, _
                                                      Optional ByVal vFECHA_INI As DateTime? = Nothing, _
                                                      Optional ByVal vFECHA_FIN As DateTime? = Nothing, _
                                                      Optional ByVal vCLI_ID As String = Nothing, _
                                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA)
            Try
                BuscarReservasPaciente = DataLayer.DAL.RESERVA.BuscarReservasPaciente(vPAC_RUT:=vPAC_RUT, vPAC_PASAPORTE:=vPAC_PASAPORTE, vFECHA_INI:=vFECHA_INI, vFECHA_FIN:=vFECHA_FIN, vCLI_ID:=vCLI_ID, vCon:=vCon)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End Function

        Public Shared Sub ReversarEstadoReserva(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                              Optional ByVal vUSU_ID As Int32? = Nothing, _
                                              Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RESERVA.ReversarEstadoReserva(vRESE_ID:=vRESE_ID, vUSU_ID:=vUSU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub


        Public Shared Function BuscarReservaPacienteEspera(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                                              Optional ByVal vCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vTIAT_ID As Int32? = Nothing, _
                                      Optional ByVal vSISS_ID As Int32? = Nothing, _
                                      Optional ByVal vERES_ID As Int32? = Nothing, _
                                      Optional ByVal vPAC_ID As Int32? = Nothing, _
                                      Optional ByVal vEXA_ID As Short? = Nothing, _
                                      Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
                                      Optional ByVal vRESE_FECHA_REGISTRO As DateTime? = Nothing, _
                                      Optional ByVal vRESE_PAC_NUEVO As Boolean? = Nothing, _
                                      Optional ByVal vRESE_OBSERVACIONES As String = Nothing, _
                                      Optional ByVal vRESE_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                        Optional ByVal vVERSION_CSA As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA_FICHA_MEDICA)
            Try
                BuscarReservaPacienteEspera = DataLayer.DAL.RESERVA.BuscarReservaPacienteEspera(vVERSION_CSA:=vVERSION_CSA, vCLI_ID:=vCLI_ID, vRESE_ID:=vRESE_ID, vTIAT_ID:=vTIAT_ID, vSISS_ID:=vSISS_ID, vERES_ID:=vERES_ID, vPAC_ID:=vPAC_ID, vEXA_ID:=vEXA_ID, vPRES_ID:=vPRES_ID, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vRESE_FECHA_REGISTRO:=vRESE_FECHA_REGISTRO, vRESE_PAC_NUEVO:=vRESE_PAC_NUEVO, vRESE_OBSERVACIONES:=vRESE_OBSERVACIONES, vRESE_VIGENTE:=vRESE_VIGENTE, vUSU_ID:=vUSU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function BuscarReservaPacienteAtendido(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                                             Optional ByVal vCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vTIAT_ID As Int32? = Nothing, _
                                      Optional ByVal vSISS_ID As Int32? = Nothing, _
                                      Optional ByVal vERES_ID As Int32? = Nothing, _
                                      Optional ByVal vPAC_ID As Int32? = Nothing, _
                                      Optional ByVal vEXA_ID As Short? = Nothing, _
                                      Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
                                      Optional ByVal vRESE_FECHA_REGISTRO As DateTime? = Nothing, _
                                      Optional ByVal vRESE_PAC_NUEVO As Boolean? = Nothing, _
                                      Optional ByVal vRESE_OBSERVACIONES As String = Nothing, _
                                      Optional ByVal vRESE_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA_FICHA_MEDICA)
            Try
                BuscarReservaPacienteAtendido = DataLayer.DAL.RESERVA.BuscarReservaPacienteAtendido(vCLI_ID:=vCLI_ID, vRESE_ID:=vRESE_ID, vTIAT_ID:=vTIAT_ID, vSISS_ID:=vSISS_ID, vERES_ID:=vERES_ID, vPAC_ID:=vPAC_ID, vEXA_ID:=vEXA_ID, vPRES_ID:=vPRES_ID, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vRESE_FECHA_REGISTRO:=vRESE_FECHA_REGISTRO, vRESE_PAC_NUEVO:=vRESE_PAC_NUEVO, vRESE_OBSERVACIONES:=vRESE_OBSERVACIONES, vRESE_VIGENTE:=vRESE_VIGENTE, vUSU_ID:=vUSU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

    End Class


End Namespace

