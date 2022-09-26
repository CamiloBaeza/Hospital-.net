Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class AUSENCIA



        Public Shared Function Buscar(Optional ByVal vAUS_ID As Int32? = Nothing, _
           Optional ByVal vPRES_ID As Decimal? = Nothing, _
           Optional ByVal vUSU_ID As Decimal? = Nothing, _
           Optional ByVal vCLI_ID As Decimal? = Nothing, _
           Optional ByVal vCLIS_ID As Decimal? = Nothing, _
           Optional ByVal vSCLI_ID As Decimal? = Nothing, _
           Optional ByVal vMOA_ID As Decimal? = Nothing, _
           Optional ByVal vAUS_INI As DateTime? = Nothing, _
           Optional ByVal vAUS_FIN As DateTime? = Nothing, _
           Optional ByVal vAUS_HORA_INI As TimeSpan? = Nothing, _
           Optional ByVal vAUS_HORA_FIN As TimeSpan? = Nothing, _
           Optional ByVal vAUS_LUNES As Boolean? = Nothing, _
           Optional ByVal vAUS_MARTES As Boolean? = Nothing, _
           Optional ByVal vAUS_MIERCOLES As Boolean? = Nothing, _
           Optional ByVal vAUS_JUEVES As Boolean? = Nothing, _
           Optional ByVal vAUS_VIERNES As Boolean? = Nothing, _
           Optional ByVal vAUS_SABADO As Boolean? = Nothing, _
           Optional ByVal vAUS_DOMINGO As Boolean? = Nothing, _
           Optional ByVal vFILTRO_FECHA As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.AUSENCIA)
            Try
                Buscar = DataLayer.DAL.AUSENCIA.Buscar(vAUS_ID:=vAUS_ID, vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vSCLI_ID:=vSCLI_ID, vMOA_ID:=vMOA_ID, vAUS_INI:=vAUS_INI, vAUS_FIN:=vAUS_FIN, vAUS_HORA_INI:=vAUS_HORA_INI, vAUS_HORA_FIN:=vAUS_HORA_FIN, vAUS_LUNES:=vAUS_LUNES, vAUS_MARTES:=vAUS_MARTES, vAUS_MIERCOLES:=vAUS_MIERCOLES, vAUS_JUEVES:=vAUS_JUEVES, vAUS_VIERNES:=vAUS_VIERNES, vAUS_SABADO:=vAUS_SABADO, vAUS_DOMINGO:=vAUS_DOMINGO, vFILTRO_FECHA:=vFILTRO_FECHA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function



        Public Shared Sub Guardar(ByVal vAUSENCIA As EntityLayer.EL.AUSENCIA, Optional ByVal vUSU_ID As Int32? = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                If validar_guardar(vAUSENCIA:=vAUSENCIA, vUSU_ID:=vUSU_ID, vCon:=vCon) Then
                    vAUSENCIA.USU_ID_REGISTRA = vUSU_ID
                    vAUSENCIA.AUS_FECHA_REGISTRO = DateTime.Now
                    DataLayer.DAL.AUSENCIA.Guardar(vAUSENCIA:=vAUSENCIA, vCon:=vCon)
                    BL.HORARIO_DIARIO.ReagendarReservar(vPRES_ID:=vAUSENCIA.PRES_ID, vUSU_ID:=vUSU_ID, vCon:=vCon)
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub Eliminar(ByVal vAUSENCIA As EntityLayer.EL.AUSENCIA, Optional ByVal vUSU_ID As Int32? = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                vAUSENCIA.USU_ID_ELIMINA = vUSU_ID
                vAUSENCIA.AUS_FECHA_ELIMINACION = DateTime.Now
                DataLayer.DAL.AUSENCIA.Eliminar(vAUSENCIA:=vAUSENCIA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vAUS_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.AUSENCIA
            Dim vL As List(Of EntityLayer.EL.AUSENCIA)
            vL = Buscar(vAUS_ID:=vAUS_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function



        Public Shared Function validar_guardar(ByRef vAUSENCIA As EntityLayer.EL.AUSENCIA, ByRef vUSU_ID As Int32?, Optional ByVal vCon As Conexion = Nothing) As Boolean
            If vAUSENCIA.AUS_FIN < vAUSENCIA.AUS_INI Then
                Throw New Exception("La fecha de inicio no puede ser posterior a la fecha de término")
            End If
            'If vHORARIO_DIARIO IsNot Nothing Then
            '    If vAUSENCIA.AUS_INI < vHORARIO_DIARIO.HORD_VIGENCIA_INI Then
            '        Throw New Exception("La fecha de inicio no puede ser anterior a la fecha vigencia de inicio del horario")
            '    ElseIf vAUSENCIA.AUS_FIN > vHORARIO_DIARIO.HORD_VIGENCIA_FIN Then
            '        Throw New Exception("La fecha de fin no puede ser posterior a la fecha vigencia de fin del horario")
            '    End If
            'Else
            '    Throw New Exception("No se pudo obtener datos del horario")
            'End If
            Dim lst As List(Of EntityLayer.EL.AUSENCIA) = BL.AUSENCIA.Buscar(vPRES_ID:=vAUSENCIA.PRES_ID, vAUS_INI:=vAUSENCIA.AUS_INI, vAUS_FIN:=vAUSENCIA.AUS_FIN, vAUS_HORA_INI:=vAUSENCIA.AUS_HORA_INI, vAUS_HORA_FIN:=vAUSENCIA.AUS_HORA_FIN, vMOA_ID:=Nothing, vCon:=vCon)
            If lst IsNot Nothing AndAlso lst.Count > 0 Then
                'Throw New Exception("Ya existe registro de ausencia similar para el especialista.")
                lst(0).MOA_ID = vAUSENCIA.MOA_ID
                vAUSENCIA = lst(0)
            End If
            Return True
        End Function

        Public Shared Function sortList_AUSENCIA(ByVal order As String, _
                                             ByVal col As String, _
                                             ByVal vLista As List(Of EntityLayer.EL.AUSENCIA)) As List(Of EntityLayer.EL.AUSENCIA)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "AUS_ID"
                        query = query.OrderBy(Function(x) x.AUS_ID)
                    Case "PRES_ID"
                        query = query.OrderBy(Function(x) x.PRES_ID)
                    Case "AUS_INI"
                        query = query.OrderBy(Function(x) x.AUS_INI)
                    Case "AUS_FIN"
                        query = query.OrderBy(Function(x) x.AUS_FIN)
                    Case "AUS_HORA_INI"
                        query = query.OrderBy(Function(x) x.AUS_HORA_INI)
                    Case "AUS_HORA_FIN"
                        query = query.OrderBy(Function(x) x.AUS_HORA_FIN)
                    Case "MOA_ID"
                        query = query.OrderBy(Function(x) x.MOA_ID)
                    Case "MOA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.MOA_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "AUS_ID"
                        query = query.OrderByDescending(Function(x) x.AUS_ID)
                    Case "PRES_ID"
                        query = query.OrderByDescending(Function(x) x.PRES_ID)
                    Case "AUS_INI"
                        query = query.OrderByDescending(Function(x) x.AUS_INI)
                    Case "AUS_FIN"
                        query = query.OrderByDescending(Function(x) x.AUS_FIN)
                    Case "AUS_HORA_INI"
                        query = query.OrderByDescending(Function(x) x.AUS_HORA_INI)
                    Case "AUS_HORA_FIN"
                        query = query.OrderByDescending(Function(x) x.AUS_HORA_FIN)
                    Case "MOA_ID"
                        query = query.OrderByDescending(Function(x) x.MOA_ID)
                    Case "MOA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.MOA_DESCRIPCION)

                End Select
            End If

            Return query.ToList
        End Function
    End Class
End Namespace

