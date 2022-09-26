Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class SERVICIO_CONTRATO


        Public Shared Function Buscar(Optional ByVal vSERC_ID As Int32? = Nothing, _
           Optional ByVal vSERV_ID As Int32? = Nothing, _
           Optional ByVal vCONT_ID As Int32? = Nothing, _
           Optional ByVal vSERC_VALOR_USUARIO As Decimal? = Nothing, _
           Optional ByVal vSERC_FECHA_INI As DateTime? = Nothing, _
           Optional ByVal vSERC_FECHA_FIN As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.SERVICIO_CONTRATO)
            Buscar = DataLayer.DAL.SERVICIO_CONTRATO.Buscar(vSERC_ID, vSERV_ID, vCONT_ID, vSERC_VALOR_USUARIO, vSERC_FECHA_INI, vSERC_FECHA_FIN, vCon, vControlEstado)
        End Function


        Public Shared Sub Guardar(ByVal vSERVICIO_CONTRATO As EntityLayer.EL.SERVICIO_CONTRATO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.SERVICIO_CONTRATO.Guardar(vSERVICIO_CONTRATO, vCon, vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vSERVICIO_CONTRATO As EntityLayer.EL.SERVICIO_CONTRATO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.SERVICIO_CONTRATO.Eliminar(vSERVICIO_CONTRATO, vCon, vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vSERC_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.SERVICIO_CONTRATO
            Dim vL As List(Of EntityLayer.EL.SERVICIO_CONTRATO)
            vL = Buscar(vSERC_ID:=vSERC_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_SERVICIO_CONTRATO(ByVal order As String, _
                                        ByVal col As String, _
                                        ByVal vLista As List(Of EntityLayer.EL.SERVICIO_CONTRATO)) As List(Of EntityLayer.EL.SERVICIO_CONTRATO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "CONT_ID"
                        query = query.OrderBy(Function(x) x.CONT_ID)
                    Case "SERC_FECHA_FIN"
                        query = query.OrderBy(Function(x) x.SERC_FECHA_FIN)
                    Case "SERC_FECHA_INI"
                        query = query.OrderBy(Function(x) x.SERC_FECHA_INI)
                    Case "SERC_ID"
                        query = query.OrderBy(Function(x) x.SERC_ID)
                    Case "SERC_VALOR_USUARIO"
                        query = query.OrderBy(Function(x) x.SERC_VALOR_USUARIO)
                    Case "SERV_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.SERV_DESCRIPCION)
                    Case "SERV_ID"
                        query = query.OrderBy(Function(x) x.SERV_ID)
                End Select
            Else
                Select Case col
                    Case "CONT_ID"
                        query = query.OrderByDescending(Function(x) x.CONT_ID)
                    Case "SERC_FECHA_FIN"
                        query = query.OrderByDescending(Function(x) x.SERC_FECHA_FIN)
                    Case "SERC_FECHA_INI"
                        query = query.OrderByDescending(Function(x) x.SERC_FECHA_INI)
                    Case "SERC_ID"
                        query = query.OrderByDescending(Function(x) x.SERC_ID)
                    Case "SERC_VALOR_USUARIO"
                        query = query.OrderByDescending(Function(x) x.SERC_VALOR_USUARIO)
                    Case "SERV_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.SERV_DESCRIPCION)
                    Case "SERV_ID"
                        query = query.OrderByDescending(Function(x) x.SERV_ID)

                End Select
            End If

            Return query.ToList
        End Function
    End Class


End Namespace

