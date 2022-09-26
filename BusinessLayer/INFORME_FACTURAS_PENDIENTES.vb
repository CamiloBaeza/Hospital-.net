Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class INFORME_FACTURAS_PENDIENTES

        Public Shared Function Buscar(Optional ByVal vFECHA_INICIO As DateTime? = Nothing, _
           Optional ByVal vFECHA_FIN As DateTime? = Nothing, _
          Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INFORME_FACTURAS_PENDIENTES)
            Try
                Buscar = DataLayer.DAL.INFORME_FACTURAS_PENDIENTES.Buscar(vFECHA_INICIO:=vFECHA_INICIO, vFECHA_FIN:=vFECHA_FIN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function sortList_INFORME_FACTURAS_PENDIENTES(ByVal order As String, _
                                        ByVal col As String, _
                                        ByVal vLista As List(Of EntityLayer.EL.INFORME_FACTURAS_PENDIENTES)) As List(Of EntityLayer.EL.INFORME_FACTURAS_PENDIENTES)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "AVIP_FECHA_AVISO_PAGO"
                        query = query.OrderBy(Function(x) x.AVIP_FECHA_AVISO_PAGO)
                    Case "CLIS_RUT"
                        query = query.OrderBy(Function(x) x.CLIS_RUT)
                    Case "CLIS_RAZON_SOCIAL"
                        query = query.OrderBy(Function(x) x.CLIS_RAZON_SOCIAL)
                    Case "CONT_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.CONT_FECHA_REGISTRO)
                    Case "VEND_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.VEND_DESCRIPCION)
                    Case "AVIP_SALDO"
                        query = query.OrderBy(Function(x) x.AVIP_SALDO)
                    Case "AVIP_VALOR_TOTAL"
                        query = query.OrderBy(Function(x) x.AVIP_VALOR_TOTAL)
                End Select
            Else
                Select Case col
                    Case "AVIP_FECHA_AVISO_PAGO"
                        query = query.OrderByDescending(Function(x) x.AVIP_FECHA_AVISO_PAGO)
                    Case "CLIS_RUT"
                        query = query.OrderByDescending(Function(x) x.CLIS_RUT)
                    Case "CLIS_RAZON_SOCIAL"
                        query = query.OrderByDescending(Function(x) x.CLIS_RAZON_SOCIAL)
                    Case "CONT_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.CONT_FECHA_REGISTRO)
                    Case "VEND_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.VEND_DESCRIPCION)
                    Case "AVIP_SALDO"
                        query = query.OrderByDescending(Function(x) x.AVIP_SALDO)
                    Case "AVIP_VALOR_TOTAL"
                        query = query.OrderByDescending(Function(x) x.AVIP_VALOR_TOTAL)
                End Select
            End If

            Return query.ToList
        End Function
    End Class
End Namespace
