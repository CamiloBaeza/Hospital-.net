Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class SERVICIO_CLINICO
        Public Shared Function Buscar(Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vSCLI_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.SERVICIO_CLINICO)
            Try
                Buscar = DataLayer.DAL.SERVICIO_CLINICO.Buscar(vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vSCLI_DESCRIPCION:=vSCLI_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function
        Public Shared Function BuscarPorUsuario(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                               Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                              Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                              Optional ByVal vCLI_ID As Int32? = Nothing, _
                                              Optional ByVal vSCLI_DESCRIPCION As String = Nothing, _
                                              Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.SERVICIO_CLINICO)
            Try
                BuscarPorUsuario = DataLayer.DAL.SERVICIO_CLINICO.BuscarPorUsuario(vUSU_ID:=vUSU_ID, vSCLI_ID:=vSCLI_ID, vCLIS_ID:=vCLIS_ID, vCLI_ID:=vCLI_ID, vSCLI_DESCRIPCION:=vSCLI_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Sub Guardar(ByVal vSERVICIO_CLINICO As EntityLayer.EL.SERVICIO_CLINICO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.SERVICIO_CLINICO.Guardar(vSERVICIO_CLINICO:=vSERVICIO_CLINICO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vSERVICIO_CLINICO As EntityLayer.EL.SERVICIO_CLINICO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.SERVICIO_CLINICO.Eliminar(vSERVICIO_CLINICO:=vSERVICIO_CLINICO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.SERVICIO_CLINICO
            Dim vL As List(Of EntityLayer.EL.SERVICIO_CLINICO)
            vL = Buscar(vSCLI_ID:=vSCLI_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_SERVICIO_CLINICO(ByVal order As String, _
                                                         ByVal col As String, _
                                                         ByVal vLista As List(Of EntityLayer.EL.SERVICIO_CLINICO)) As List(Of EntityLayer.EL.SERVICIO_CLINICO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "SCLI_ID"
                        query = query.OrderBy(Function(x) x.SCLI_ID)
                    Case "SCLI_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.SCLI_DESCRIPCION)
                    Case "CLIS_ID"
                        query = query.OrderBy(Function(x) x.CLIS_ID)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLIS_DESCRIPCION)
                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLI_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "SCLI_ID"
                        query = query.OrderByDescending(Function(x) x.SCLI_ID)
                    Case "SCLI_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.SCLI_DESCRIPCION)
                    Case "CLIS_ID"
                        query = query.OrderByDescending(Function(x) x.CLIS_ID)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLIS_DESCRIPCION)
                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLI_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function
    End Class


End Namespace

