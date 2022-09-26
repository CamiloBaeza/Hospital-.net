Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class HORARIO_DIARIO
        Public Shared Function ValidarHorarioDiario(ByVal vHD As EntityLayer.EL.HORARIO_DIARIO, _
                                    Optional ByVal vCon As Conexion = Nothing) As String
            Return DataLayer.DAL.HORARIO_DIARIO.ValidarHorarioDiario(vHD:=vHD, vCon:=vCon)
        End Function

        Public Shared Function Buscar(Optional ByVal vHORD_ID As Int32? = Nothing, _
                                      Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                      Optional ByVal vTPRE_ID As Decimal? = Nothing, _
                                      Optional ByVal vHORD_DIA As Short? = Nothing, _
                                      Optional ByVal vHORD_HORA_INI As Date? = Nothing, _
                                      Optional ByVal vHORD_HORA_FIN As Date? = Nothing, _
                                      Optional ByVal vHORD_VIGENCIA_INI As DateTime? = Nothing, _
                                      Optional ByVal vHORD_VIGENCIA_FIN As DateTime? = Nothing, _
                                      Optional ByVal vHORD_INTERVALO As Int32? = Nothing, _
                                      Optional ByVal vHORD_VISIBLE_WEB As Boolean? = Nothing, _
                                      Optional ByVal vHORD_SOBRE_CUPO_MAX As Int32? = Nothing, _
                                      Optional ByVal vHORD_OBSERVACION As String = Nothing, _
                                      Optional ByVal vHORD_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vHORD_FECHA_REGISTRO As Date? = Nothing, _
                                      Optional ByVal vHORD_FECHA_ELIMINACION As Date? = Nothing, _
                                      Optional ByVal vHORD_USU_ID_ELIMINACION As Integer? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HORARIO_DIARIO)
            Try
                Buscar = DataLayer.DAL.HORARIO_DIARIO.Buscar(vHORD_ID:=vHORD_ID, vPRES_ID:=vPRES_ID, vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vUSU_ID:=vUSU_ID, vTPRE_ID:=vTPRE_ID, vHORD_DIA:=vHORD_DIA, vHORD_HORA_INI:=vHORD_HORA_INI, vHORD_HORA_FIN:=vHORD_HORA_FIN, vHORD_VIGENCIA_INI:=vHORD_VIGENCIA_INI, vHORD_VIGENCIA_FIN:=vHORD_VIGENCIA_FIN, vHORD_INTERVALO:=vHORD_INTERVALO, vHORD_VISIBLE_WEB:=vHORD_VISIBLE_WEB, vHORD_SOBRE_CUPO_MAX:=vHORD_SOBRE_CUPO_MAX, vHORD_OBSERVACION:=vHORD_OBSERVACION, vHORD_VIGENTE:=vHORD_VIGENTE, vHORD_FECHA_REGISTRO:=vHORD_FECHA_REGISTRO, vHORD_FECHA_ELIMINACION:=vHORD_FECHA_ELIMINACION, vHORD_USU_ID_ELIMINACION:=vHORD_USU_ID_ELIMINACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function BuscarAgendaDia(Optional ByVal vPRES_ID As Decimal? = Nothing, _
           Optional ByVal vFECHA As DateTime? = Nothing,
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HORARIO_DIARIO)
            Try
                BuscarAgendaDia = DataLayer.DAL.HORARIO_DIARIO.BuscarAgendaDia(vPRES_ID:=vPRES_ID, vFECHA:=vFECHA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vHORARIO_DIARIO As EntityLayer.EL.HORARIO_DIARIO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.HORARIO_DIARIO.Guardar(vHORARIO_DIARIO:=vHORARIO_DIARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub


        Public Shared Sub ResolverConflictos(Optional ByVal vHORD_ID As Int32? = Nothing, Optional ByVal vUSU_ID As Int32? = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.HORARIO_DIARIO.ResolverConflictos(vHORD_ID:=vHORD_ID, vUSU_ID:=vUSU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Function ReagendarReservar(Optional ByVal vPRES_ID As Int32? = Nothing, Optional ByVal vUSU_ID As Int32? = Nothing, Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA)
            Try
                Dim vl As List(Of EntityLayer.EL.RESERVA) = DataLayer.DAL.HORARIO_DIARIO.ReagendarReservar(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vCon:=vCon)
                Try
                    RESERVA_LOG_ESTADO.EnviarCorreo(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vCon:=vCon, vlist:=vl)
                Catch ex As Exception

                End Try
                Return vl
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function
        Public Shared Sub Eliminar(ByVal vHORARIO_DIARIO As EntityLayer.EL.HORARIO_DIARIO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.HORARIO_DIARIO.Eliminar(vHORARIO_DIARIO:=vHORARIO_DIARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vHORD_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.HORARIO_DIARIO
            Dim vL As List(Of EntityLayer.EL.HORARIO_DIARIO)
            vL = Buscar(vHORD_ID:=vHORD_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_HORARIO_DIARIO(ByVal order As String, _
                                                       ByVal col As String, _
                                                       ByVal vLista As List(Of EntityLayer.EL.HORARIO_DIARIO)) As List(Of EntityLayer.EL.HORARIO_DIARIO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "HORD_ID"
                        query = query.OrderBy(Function(x) x.HORD_ID)
                    Case "PRES_ID"
                        query = query.OrderBy(Function(x) x.PRES_ID)
                    Case "HORD_DIA"
                        query = query.OrderBy(Function(x) x.HORD_DIA)
                    Case "HORD_HORA_INI"
                        query = query.OrderBy(Function(x) x.HORD_HORA_INI)
                    Case "HORD_HORA_FIN"
                        query = query.OrderBy(Function(x) x.HORD_HORA_FIN)
                    Case "HORD_VIGENCIA_INI"
                        query = query.OrderBy(Function(x) x.HORD_VIGENCIA_INI)
                    Case "HORD_VIGENCIA_FIN"
                        query = query.OrderBy(Function(x) x.HORD_VIGENCIA_FIN)
                    Case "HORD_INTERVALO"
                        query = query.OrderBy(Function(x) x.HORD_INTERVALO)
                    Case "HORD_VISIBLE_WEB"
                        query = query.OrderBy(Function(x) x.HORD_VISIBLE_WEB)
                    Case "HORD_SOBRE_CUPO_MAX"
                        query = query.OrderBy(Function(x) x.HORD_SOBRE_CUPO_MAX)
                    Case "HORD_OBSERVACION"
                        query = query.OrderBy(Function(x) x.HORD_OBSERVACION)
                    Case "HORD_VIGENTE"
                        query = query.OrderBy(Function(x) x.HORD_VIGENTE)

                    Case "HORD_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.HORD_FECHA_REGISTRO)
                    Case "HORD_FECHA_ELIMINACION"
                        query = query.OrderBy(Function(x) x.HORD_FECHA_ELIMINACION)
                    Case "HORD_USU_ID_ELIMINACION"
                        query = query.OrderBy(Function(x) x.HORD_USU_ID_ELIMINACION)
                End Select
            Else
                Select Case col
                    Case "HORD_ID"
                        query = query.OrderByDescending(Function(x) x.HORD_ID)
                    Case "PRES_ID"
                        query = query.OrderByDescending(Function(x) x.PRES_ID)
                    Case "HORD_DIA"
                        query = query.OrderByDescending(Function(x) x.HORD_DIA)
                    Case "HORD_HORA_INI"
                        query = query.OrderByDescending(Function(x) x.HORD_HORA_INI)
                    Case "HORD_HORA_FIN"
                        query = query.OrderByDescending(Function(x) x.HORD_HORA_FIN)
                    Case "HORD_VIGENCIA_INI"
                        query = query.OrderByDescending(Function(x) x.HORD_VIGENCIA_INI)
                    Case "HORD_VIGENCIA_FIN"
                        query = query.OrderByDescending(Function(x) x.HORD_VIGENCIA_FIN)
                    Case "HORD_INTERVALO"
                        query = query.OrderByDescending(Function(x) x.HORD_INTERVALO)
                    Case "HORD_VISIBLE_WEB"
                        query = query.OrderByDescending(Function(x) x.HORD_VISIBLE_WEB)
                    Case "HORD_SOBRE_CUPO_MAX"
                        query = query.OrderByDescending(Function(x) x.HORD_SOBRE_CUPO_MAX)
                    Case "HORD_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.HORD_OBSERVACION)
                    Case "HORD_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.HORD_VIGENTE)

                    Case "HORD_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.HORD_FECHA_REGISTRO)
                    Case "HORD_FECHA_ELIMINACION"
                        query = query.OrderByDescending(Function(x) x.HORD_FECHA_ELIMINACION)
                    Case "HORD_USU_ID_ELIMINACION"
                        query = query.OrderByDescending(Function(x) x.HORD_USU_ID_ELIMINACION)
                End Select
            End If

            Return query.ToList
        End Function
    End Class


End Namespace

