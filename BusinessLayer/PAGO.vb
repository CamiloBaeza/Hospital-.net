Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class PAGO


        Public Shared Function Buscar(Optional ByVal vPAGO_ID As Int32? = Nothing, _
                                      Optional ByVal vESPA_ID As Int32? = Nothing, _
                                      Optional ByVal vCONT_ID As Int32? = Nothing, _
                                      Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _
                                      Optional ByVal vUSU_ID_ELIMINA As Int32? = Nothing, _
                                      Optional ByVal vPAGO_FECHA_PAGO As DateTime? = Nothing, _
                                      Optional ByVal vPAGO_MONTO As Decimal? = Nothing, _
                                      Optional ByVal vPAGO_NUMERO_FACTURA As String = Nothing, _
                                      Optional ByVal vPAGO_FECHA_FACTURA As DateTime? = Nothing, _
                                      Optional ByVal vPAGO_FECHA_REGISTRO As DateTime? = Nothing, _
                                      Optional ByVal vPAGO_FECHA_ELIMINACION As DateTime? = Nothing, _
                                      Optional ByVal vPAGO_OBSERVACION As String = Nothing, _
                                      Optional ByVal vPAGO_VIGENTE As Boolean? = Nothing, _
                                      Optional ByVal vPAGO_FECHA_PAGO_INI As DateTime? = Nothing, _
                                      Optional ByVal vPAGO_FECHA_PAGO_FIN As DateTime? = Nothing, _
                                      Optional ByVal vPAGO_FECHA_FACTURA_INI As DateTime? = Nothing, _
                                      Optional ByVal vPAGO_FECHA_FACTURA_FIN As DateTime? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PAGO)
            Try
                Buscar = DataLayer.DAL.PAGO.Buscar(vPAGO_ID:=vPAGO_ID, vESPA_ID:=vESPA_ID, vCONT_ID:=vCONT_ID, vUSU_ID_REGISTRA:=vUSU_ID_REGISTRA, vUSU_ID_ELIMINA:=vUSU_ID_ELIMINA, vPAGO_FECHA_PAGO:=vPAGO_FECHA_PAGO, vPAGO_MONTO:=vPAGO_MONTO, vPAGO_NUMERO_FACTURA:=vPAGO_NUMERO_FACTURA, vPAGO_FECHA_FACTURA:=vPAGO_FECHA_FACTURA, vPAGO_FECHA_REGISTRO:=vPAGO_FECHA_REGISTRO, vPAGO_FECHA_ELIMINACION:=vPAGO_FECHA_ELIMINACION, vPAGO_OBSERVACION:=vPAGO_OBSERVACION, vPAGO_VIGENTE:=vPAGO_VIGENTE, vPAGO_FECHA_PAGO_INI:=vPAGO_FECHA_PAGO_INI, vPAGO_FECHA_PAGO_FIN:=vPAGO_FECHA_PAGO_FIN, vPAGO_FECHA_FACTURA_INI:=vPAGO_FECHA_FACTURA_INI, vPAGO_FECHA_FACTURA_FIN:=vPAGO_FECHA_FACTURA_FIN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vPAGO As EntityLayer.EL.PAGO, ByVal vAVIP_ID As Int32?, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO.Guardar(vPAGO:=vPAGO, vAVIP_ID:=vAVIP_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vPAGO As EntityLayer.EL.PAGO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO.Eliminar(vPAGO:=vPAGO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPAGO_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PAGO
            Dim vL As List(Of EntityLayer.EL.PAGO)
            vL = Buscar(vPAGO_ID:=vPAGO_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_PAGO(ByVal order As String, _
                                             ByVal col As String, _
                                             ByVal vLista As List(Of EntityLayer.EL.PAGO)) As List(Of EntityLayer.EL.PAGO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "PAGO_ID"
                        query = query.OrderBy(Function(x) x.PAGO_ID)
                    Case "ESPA_ID"
                        query = query.OrderBy(Function(x) x.ESPA_ID)
                    Case "CONT_ID"
                        query = query.OrderBy(Function(x) x.CONT_ID)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderBy(Function(x) x.USU_ID_REGISTRA)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderBy(Function(x) x.USU_ID_ELIMINA)
                    Case "PAGO_FECHA_PAGO"
                        query = query.OrderBy(Function(x) x.PAGO_FECHA_PAGO)
                    Case "PAGO_MONTO"
                        query = query.OrderBy(Function(x) x.PAGO_MONTO)
                    Case "PAGO_NUMERO_FACTURA"
                        query = query.OrderBy(Function(x) x.PAGO_NUMERO_FACTURA)
                    Case "PAGO_FECHA_FACTURA"
                        query = query.OrderBy(Function(x) x.PAGO_FECHA_FACTURA)
                    Case "PAGO_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.PAGO_FECHA_REGISTRO)
                    Case "PAGO_FECHA_ELIMINACION"
                        query = query.OrderBy(Function(x) x.PAGO_FECHA_ELIMINACION)
                    Case "PAGO_OBSERVACION"
                        query = query.OrderBy(Function(x) x.PAGO_OBSERVACION)
                    Case "PAGO_VIGENTE"
                        query = query.OrderBy(Function(x) x.PAGO_VIGENTE)

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
                    Case "ESPA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.ESPA_DESCRIPCION)

                End Select
            ElseIf order.ToUpper = "DESC" Then
                Select Case col
                    Case "PAGO_ID"
                        query = query.OrderByDescending(Function(x) x.PAGO_ID)
                    Case "ESPA_ID"
                        query = query.OrderByDescending(Function(x) x.ESPA_ID)
                    Case "CONT_ID"
                        query = query.OrderByDescending(Function(x) x.CONT_ID)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_REGISTRA)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_ELIMINA)
                    Case "PAGO_FECHA_PAGO"
                        query = query.OrderByDescending(Function(x) x.PAGO_FECHA_PAGO)
                    Case "PAGO_MONTO"
                        query = query.OrderByDescending(Function(x) x.PAGO_MONTO)
                    Case "PAGO_NUMERO_FACTURA"
                        query = query.OrderByDescending(Function(x) x.PAGO_NUMERO_FACTURA)
                    Case "PAGO_FECHA_FACTURA"
                        query = query.OrderByDescending(Function(x) x.PAGO_FECHA_FACTURA)
                    Case "PAGO_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.PAGO_FECHA_REGISTRO)
                    Case "PAGO_FECHA_ELIMINACION"
                        query = query.OrderByDescending(Function(x) x.PAGO_FECHA_ELIMINACION)
                    Case "PAGO_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.PAGO_OBSERVACION)
                    Case "PAGO_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.PAGO_VIGENTE)

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
                    Case "ESPA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.ESPA_DESCRIPCION)

                End Select
            End If
            Return query.ToList
        End Function

    End Class


End Namespace

