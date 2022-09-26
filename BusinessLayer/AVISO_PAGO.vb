Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class AVISO_PAGO


        Public Shared Function Buscar(Optional ByVal vAVIP_ID As Int32? = Nothing, _
                                      Optional ByVal vCONT_ID As Int32? = Nothing, _
                                      Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _
                                      Optional ByVal vUSU_ID_ELIMINA As Int32? = Nothing, _
                                      Optional ByVal vAVIP_FECHA_AVISO_PAGO As DateTime? = Nothing, _
                                      Optional ByVal vAVIP_MONTO As Decimal? = Nothing, _
                                      Optional ByVal vAVIP_SALDO As Decimal? = Nothing, _
                                      Optional ByVal vAVIP_FECHA_SALDO_CERO As DateTime? = Nothing, _
                                      Optional ByVal vAVIP_FECHA_REGISTRO As DateTime? = Nothing, _
                                      Optional ByVal vAVIP_FECHA_ELIMINACION As DateTime? = Nothing, _
                                      Optional ByVal vAVIP_FECHA_ENVIO As DateTime? = Nothing, _
                                      Optional ByVal vAVIP_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vAVIP_VALOR_UF As Decimal? = Nothing, _
                                      Optional ByVal vAVIP_NUM_USUARIOS As Int32? = Nothing, _
                                      Optional ByVal vAVIP_VALOR_IVA As Decimal? = Nothing, _
                                      Optional ByVal vAVIP_VALOR_TOTAL As Decimal? = Nothing, _
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.AVISO_PAGO)
            Try
                Buscar = DataLayer.DAL.AVISO_PAGO.Buscar(vAVIP_ID:=vAVIP_ID, vCONT_ID:=vCONT_ID, vUSU_ID_REGISTRA:=vUSU_ID_REGISTRA, vUSU_ID_ELIMINA:=vUSU_ID_ELIMINA, vAVIP_FECHA_AVISO_PAGO:=vAVIP_FECHA_AVISO_PAGO, vAVIP_MONTO:=vAVIP_MONTO, vAVIP_SALDO:=vAVIP_SALDO, vAVIP_FECHA_SALDO_CERO:=vAVIP_FECHA_SALDO_CERO, vAVIP_FECHA_REGISTRO:=vAVIP_FECHA_REGISTRO, vAVIP_FECHA_ELIMINACION:=vAVIP_FECHA_ELIMINACION, vAVIP_FECHA_ENVIO:=vAVIP_FECHA_ENVIO, vAVIP_VIGENTE:=vAVIP_VIGENTE, vAVIP_VALOR_UF:=vAVIP_VALOR_UF, vAVIP_NUM_USUARIOS:=vAVIP_NUM_USUARIOS, vAVIP_VALOR_IVA:=vAVIP_VALOR_IVA, vAVIP_VALOR_TOTAL:=vAVIP_VALOR_TOTAL, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Sub Generar(Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _
                                  Optional ByVal vAVIP_FECHA_AVISO_PAGO As DateTime? = Nothing, _
                                  Optional ByVal vAVIP_VALOR_UF As Decimal? = Nothing, _
                                  Optional ByVal vAVIP_VALOR_IVA As Decimal? = Nothing, _
                                  Optional ByVal vCLI_ID As String = Nothing, _
                                  Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                  Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.AVISO_PAGO.Generar(vUSU_ID_REGISTRA:=vUSU_ID_REGISTRA, vAVIP_FECHA_AVISO_PAGO:=vAVIP_FECHA_AVISO_PAGO, vAVIP_VALOR_UF:=vAVIP_VALOR_UF, vAVIP_VALOR_IVA:=vAVIP_VALOR_IVA, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub Guardar(ByVal vAVISO_PAGO As EntityLayer.EL.AVISO_PAGO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.AVISO_PAGO.Guardar(vAVISO_PAGO:=vAVISO_PAGO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vAVISO_PAGO As EntityLayer.EL.AVISO_PAGO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.AVISO_PAGO.Eliminar(vAVISO_PAGO:=vAVISO_PAGO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vAVIP_ID As Int32? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.AVISO_PAGO
            Dim vL As List(Of EntityLayer.EL.AVISO_PAGO)
            vL = Buscar(vAVIP_ID:=vAVIP_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_AVISO_PAGO(ByVal order As String, _
                                                   ByVal col As String, _
                                                   ByVal vLista As List(Of EntityLayer.EL.AVISO_PAGO)) As List(Of EntityLayer.EL.AVISO_PAGO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "AVIP_ID"
                        query = query.OrderBy(Function(x) x.AVIP_ID)
                    Case "CONT_ID"
                        query = query.OrderBy(Function(x) x.CONT_ID)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderBy(Function(x) x.USU_ID_REGISTRA)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderBy(Function(x) x.USU_ID_ELIMINA)
                    Case "AVIP_FECHA_AVISO_PAGO"
                        query = query.OrderBy(Function(x) x.AVIP_FECHA_AVISO_PAGO)
                    Case "AVIP_MONTO"
                        query = query.OrderBy(Function(x) x.AVIP_MONTO)
                    Case "AVIP_SALDO"
                        query = query.OrderBy(Function(x) x.AVIP_SALDO)
                    Case "AVIP_FECHA_SALDO_CERO"
                        query = query.OrderBy(Function(x) x.AVIP_FECHA_SALDO_CERO)
                    Case "AVIP_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.AVIP_FECHA_REGISTRO)
                    Case "AVIP_FECHA_ELIMINACION"
                        query = query.OrderBy(Function(x) x.AVIP_FECHA_ELIMINACION)
                    Case "AVIP_VIGENTE"
                        query = query.OrderBy(Function(x) x.AVIP_VIGENTE)
                    Case "AVIP_VALOR_UF"
                        query = query.OrderBy(Function(x) x.AVIP_VALOR_UF)
                    Case "AVIP_NUM_USUARIOS"
                        query = query.OrderBy(Function(x) x.AVIP_NUM_USUARIOS)
                    Case "AVIP_VALOR_IVA"
                        query = query.OrderBy(Function(x) x.AVIP_VALOR_IVA)
                    Case "AVIP_VALOR_TOTAL"
                        query = query.OrderBy(Function(x) x.AVIP_VALOR_TOTAL)

                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLI_DESCRIPCION)
                    Case "CLIS_ID"
                        query = query.OrderBy(Function(x) x.CLIS_ID)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLIS_DESCRIPCION)
                    Case "CONT_FECHA_INI"
                        query = query.OrderBy(Function(x) x.CONT_FECHA_INI)
                    Case "ESAP_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.ESAP_DESCRIPCION)
                End Select
            ElseIf order.ToUpper = "DESC" Then
                Select Case col
                    Case "AVIP_ID"
                        query = query.OrderByDescending(Function(x) x.AVIP_ID)
                    Case "CONT_ID"
                        query = query.OrderByDescending(Function(x) x.CONT_ID)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_REGISTRA)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_ELIMINA)
                    Case "AVIP_FECHA_AVISO_PAGO"
                        query = query.OrderByDescending(Function(x) x.AVIP_FECHA_AVISO_PAGO)
                    Case "AVIP_MONTO"
                        query = query.OrderByDescending(Function(x) x.AVIP_MONTO)
                    Case "AVIP_SALDO"
                        query = query.OrderByDescending(Function(x) x.AVIP_SALDO)
                    Case "AVIP_FECHA_SALDO_CERO"
                        query = query.OrderByDescending(Function(x) x.AVIP_FECHA_SALDO_CERO)
                    Case "AVIP_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.AVIP_FECHA_REGISTRO)
                    Case "AVIP_FECHA_ELIMINACION"
                        query = query.OrderByDescending(Function(x) x.AVIP_FECHA_ELIMINACION)
                    Case "AVIP_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.AVIP_VIGENTE)
                    Case "AVIP_VALOR_UF"
                        query = query.OrderByDescending(Function(x) x.AVIP_VALOR_UF)
                    Case "AVIP_NUM_USUARIOS"
                        query = query.OrderByDescending(Function(x) x.AVIP_NUM_USUARIOS)
                    Case "AVIP_VALOR_IVA"
                        query = query.OrderByDescending(Function(x) x.AVIP_VALOR_IVA)
                    Case "AVIP_VALOR_TOTAL"
                        query = query.OrderByDescending(Function(x) x.AVIP_VALOR_TOTAL)

                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLI_DESCRIPCION)
                    Case "CLIS_ID"
                        query = query.OrderByDescending(Function(x) x.CLIS_ID)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLIS_DESCRIPCION)
                    Case "CONT_FECHA_INI"
                        query = query.OrderByDescending(Function(x) x.CONT_FECHA_INI)
                    Case "ESAP_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.ESAP_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function
    End Class


End Namespace

