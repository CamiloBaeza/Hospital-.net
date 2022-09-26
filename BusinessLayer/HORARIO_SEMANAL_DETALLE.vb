Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class HORARIO_SEMANAL_DETALLE
        Public Shared Function Buscar(Optional ByVal vPRES_ID As Int32? = Nothing, _
                                      Optional ByVal vFECHA As DateTime? = Nothing, _
                                      Optional ByVal vCANT_RESERVAS As Int32? = Nothing, _
                                      Optional ByVal vVISIBLE_WEB As Boolean? = Nothing, _
                                      Optional ByVal vAUSENCIA_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vFERIADO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vPLAZO_MAXIMO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HORARIO_SEMANAL_DETALLE)
            Try
                Buscar = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.Buscar(vPRES_ID:=vPRES_ID, vFECHA:=vFECHA, vCANT_RESERVAS:=vCANT_RESERVAS, vVISIBLE_WEB:=vVISIBLE_WEB, vAUSENCIA_HORARIO:=vAUSENCIA_HORARIO, vFERIADO_HORARIO:=vFERIADO_HORARIO, vPLAZO_MAXIMO_HORARIO:=vPLAZO_MAXIMO_HORARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarPideHora(Optional ByVal vPRES_ID As Int32? = Nothing, _
                                              Optional ByVal vPAC_ID As Int32? = Nothing, _
                                      Optional ByVal vFECHA As DateTime? = Nothing, _
                                      Optional ByVal vCANT_RESERVAS As Int32? = Nothing, _
                                      Optional ByVal vVISIBLE_WEB As Boolean? = Nothing, _
                                      Optional ByVal vAUSENCIA_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vFERIADO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vPLAZO_MAXIMO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HORARIO_SEMANAL_DETALLE)
            Try
                BuscarPideHora = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.BuscarPideHora(vPRES_ID:=vPRES_ID, vPAC_ID:=vPAC_ID, vFECHA:=vFECHA, vCANT_RESERVAS:=vCANT_RESERVAS, vVISIBLE_WEB:=vVISIBLE_WEB, vAUSENCIA_HORARIO:=vAUSENCIA_HORARIO, vFERIADO_HORARIO:=vFERIADO_HORARIO, vPLAZO_MAXIMO_HORARIO:=vPLAZO_MAXIMO_HORARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarFull(Optional ByVal vPRES_ID As Int32? = Nothing, _
                                      Optional ByVal vFECHA As DateTime? = Nothing, _
                                      Optional ByVal vCANT_RESERVAS As Int32? = Nothing, _
                                      Optional ByVal vVISIBLE_WEB As Boolean? = Nothing, _
                                      Optional ByVal vAUSENCIA_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vFERIADO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vPLAZO_MAXIMO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HORARIO_SEMANAL_DETALLE)
            Try
                BuscarFull = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.BuscarFull(vPRES_ID:=vPRES_ID, vFECHA:=vFECHA, vCANT_RESERVAS:=vCANT_RESERVAS, vVISIBLE_WEB:=vVISIBLE_WEB, vAUSENCIA_HORARIO:=vAUSENCIA_HORARIO, vFERIADO_HORARIO:=vFERIADO_HORARIO, vPLAZO_MAXIMO_HORARIO:=vPLAZO_MAXIMO_HORARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarNextN(Optional ByVal vPRES_ID As Int32? = Nothing, _
                                           Optional ByVal vHORD_ID As Int32? = Nothing, _
       Optional ByVal vFECHA As DateTime? = Nothing,
       Optional ByVal vHORA As TimeSpan? = Nothing,
       Optional ByVal vN As Int32? = Nothing,
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HORARIO_SEMANAL_DETALLE)
            Try
                Dim vlista As List(Of EntityLayer.EL.HORARIO_SEMANAL_DETALLE) = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.Buscar(vPRES_ID:=vPRES_ID, vFECHA:=vFECHA, vCon:=vCon, vAUSENCIA_HORARIO:=Nothing, vFERIADO_HORARIO:=Nothing, vPLAZO_MAXIMO_HORARIO:=Nothing)
                If vlista IsNot Nothing Then
                    vlista = vlista.FindAll(Function(ve) ve.DETALLE_HORA_INI >= vHORA AndAlso ve.HORD_ID = vHORD_ID).OrderBy(Function(ve) ve.DETALLE_HORA_FIN).ToList
                    If vlista IsNot Nothing AndAlso vlista.Count > vN Then
                        vlista.RemoveRange(vN, vlista.Count - vN)
                    End If
                End If
                Return vlista
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarReservas(Optional ByVal vHORD_ID As Int32? = Nothing, _
                Optional ByVal vFECHA As DateTime? = Nothing,
                Optional ByVal vDETALLE_HORA_INI As TimeSpan? = Nothing,
                Optional ByVal vDETALLE_HORA_FIN As TimeSpan? = Nothing,
                Optional ByVal vAUSENCIA_HORARIO As Boolean? = Nothing, _
                Optional ByVal vFERIADO_HORARIO As Boolean? = Nothing, _
                Optional ByVal vPLAZO_MAXIMO_HORARIO As Boolean? = Nothing, _
                Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA)
            Try
                BuscarReservas = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.BuscarReservas(vHORD_ID:=vHORD_ID, vFECHA:=vFECHA, vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vDETALLE_HORA_FIN:=vDETALLE_HORA_FIN, vAUSENCIA_HORARIO:=vAUSENCIA_HORARIO, vFERIADO_HORARIO:=vFERIADO_HORARIO, vPLAZO_MAXIMO_HORARIO:=vPLAZO_MAXIMO_HORARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarReservasDiarias(Optional ByVal vPRES_ID As Int32? = Nothing, _
                Optional ByVal vFECHA As DateTime? = Nothing,
                Optional ByVal vAUSENCIA_HORARIO As Boolean? = Nothing, _
                Optional ByVal vFERIADO_HORARIO As Boolean? = Nothing, _
                Optional ByVal vPLAZO_MAXIMO_HORARIO As Boolean? = Nothing, _
                Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA_LIGHT)
            Try
                BuscarReservasDiarias = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.BuscarReservasDiarias(vPRES_ID:=vPRES_ID, vFECHA:=vFECHA, vAUSENCIA_HORARIO:=vAUSENCIA_HORARIO, vFERIADO_HORARIO:=vFERIADO_HORARIO, vPLAZO_MAXIMO_HORARIO:=vPLAZO_MAXIMO_HORARIO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarReservasSinAgenda(Optional ByVal vPRES_ID As Int32? = Nothing, _
                                                    Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                                    Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                                    Optional ByVal vCLI_ID As String = Nothing, _
                                                    Optional ByVal vTPRE_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA_LIGHT)
            Try
                BuscarReservasSinAgenda = DataLayer.DAL.HORARIO_SEMANAL_DETALLE.BuscarReservasSinAgenda(vPRES_ID:=vPRES_ID, vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function
    End Class


End Namespace

