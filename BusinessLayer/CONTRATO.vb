Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class CONTRATO


        Public Shared Function Buscar(Optional ByVal vCONT_ID As Int32? = Nothing, _
           Optional ByVal vCLIS_ID As Int32? = Nothing, _
           Optional ByVal vCONT_DESCRIPCION As String = Nothing, _
           Optional ByVal vCONT_VIGENTE As Boolean? = Nothing, _
           Optional ByVal vCONT_FECHA_REGISTRO As DateTime? = Nothing, _
           Optional ByVal vCONT_FECHA_INI As DateTime? = Nothing, _
           Optional ByVal vCONT_FECHA_FIN As DateTime? = Nothing, _
           Optional ByVal vVEND_ID As Int32? = Nothing, _
           Optional ByVal vCONT_FACTURADOR As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONTRATO)
            Buscar = DataLayer.DAL.CONTRATO.Buscar(vCONT_ID, vCLIS_ID, vCONT_DESCRIPCION, vCONT_VIGENTE, vCONT_FECHA_REGISTRO, vCONT_FECHA_INI, vCONT_FECHA_FIN, vVEND_ID, vCONT_FACTURADOR:=vCONT_FACTURADOR, vCon:=vCon)
        End Function

        Public Shared Function ListarContratos(Optional ByVal vCONT_ID As Int32? = Nothing, _
       Optional ByVal vCLI_ID As String = Nothing, _
           Optional ByVal vCLIS_ID As Int32? = Nothing, _
           Optional ByVal vCONT_DESCRIPCION As String = Nothing, _
           Optional ByVal vCONT_VIGENTE As Boolean? = Nothing, _
           Optional ByVal vCONT_FECHA_REGISTRO As DateTime? = Nothing, _
           Optional ByVal vCONT_FECHA_INI As DateTime? = Nothing, _
           Optional ByVal vCONT_FECHA_FIN As DateTime? = Nothing, _
           Optional ByVal vVEND_ID As Int32? = Nothing, _
           Optional ByVal vCONT_FACTURADOR As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONTRATO)
            ListarContratos = DataLayer.DAL.CONTRATO.ListarContratos(vCONT_ID:=vCONT_ID, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vCONT_DESCRIPCION:=vCONT_DESCRIPCION, vCONT_VIGENTE:=vCONT_VIGENTE, vCONT_FECHA_REGISTRO:=vCONT_FECHA_REGISTRO, vCONT_FECHA_INI:=vCONT_FECHA_INI, vCONT_FECHA_FIN:=vCONT_FECHA_FIN, vVEND_ID:=vVEND_ID, vCONT_FACTURADOR:=vCONT_FACTURADOR, vCon:=vCon)
        End Function

        Public Shared Sub Guardar(ByVal vCONTRATO As EntityLayer.EL.CONTRATO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.CONTRATO.Guardar(vCONTRATO, vCon, vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vCONTRATO As EntityLayer.EL.CONTRATO, Optional ByVal vCon As Conexion = Nothing)
            DataLayer.DAL.CONTRATO.Eliminar(vCONTRATO, vCon)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vCONT_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.CONTRATO
            Dim vL As List(Of EntityLayer.EL.CONTRATO)
            vL = Buscar(vCONT_ID:=vCONT_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_CONTRATO(ByVal order As String, _
                                        ByVal col As String, _
                                        ByVal vLista As List(Of EntityLayer.EL.CONTRATO)) As List(Of EntityLayer.EL.CONTRATO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "CLI_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLI_DESCRIPCION)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLIS_DESCRIPCION)
                    Case "CONT_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CONT_DESCRIPCION)
                    Case "CONT_FECHA_FIN"
                        query = query.OrderBy(Function(x) x.CONT_FECHA_FIN)
                    Case "CONT_FECHA_INI"
                        query = query.OrderBy(Function(x) x.CONT_FECHA_INI)
                    Case "CONT_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.CONT_FECHA_REGISTRO)
                    Case "CONT_ID"
                        query = query.OrderBy(Function(x) x.CONT_ID)
                    Case "CONT_VIGENTE"
                        query = query.OrderBy(Function(x) x.CONT_VIGENTE)
                    Case "VEND_ID"
                        query = query.OrderBy(Function(x) x.VEND_ID)
                    Case "CONT_FACTURADOR"
                        query = query.OrderBy(Function(x) x.CONT_FACTURADOR)
                End Select
            Else
                Select Case col
                    Case "CLI_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLI_DESCRIPCION)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLIS_DESCRIPCION)
                    Case "CONT_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CONT_DESCRIPCION)
                    Case "CONT_FECHA_FIN"
                        query = query.OrderByDescending(Function(x) x.CONT_FECHA_FIN)
                    Case "CONT_FECHA_INI"
                        query = query.OrderByDescending(Function(x) x.CONT_FECHA_INI)
                    Case "CONT_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.CONT_FECHA_REGISTRO)
                    Case "CONT_ID"
                        query = query.OrderByDescending(Function(x) x.CONT_ID)
                    Case "CONT_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.CONT_VIGENTE)
                    Case "VEND_ID"
                        query = query.OrderByDescending(Function(x) x.VEND_ID)
                    Case "CONT_FACTURADOR"
                        query = query.OrderByDescending(Function(x) x.CONT_FACTURADOR)
                End Select
            End If

            Return query.ToList
        End Function

    End Class

    
End Namespace

