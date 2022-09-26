Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class USUARIO_CONTRATO


        Public Shared Function Buscar(Optional ByVal vUSCO_ID As Int32? = Nothing, _
           Optional ByVal vUSU_ID As Int32? = Nothing, _
           Optional ByVal vCONT_ID As Int32? = Nothing, _
           Optional ByVal vUSCO_FECHA_INI As DateTime? = Nothing, _
           Optional ByVal vUSCO_FECHA_FIN As DateTime? = Nothing, _
           Optional ByVal vUSCO_VIGENTE As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.USUARIO_CONTRATO)
            Buscar = DataLayer.DAL.USUARIO_CONTRATO.Buscar(vUSCO_ID, vUSU_ID, vCONT_ID, vUSCO_FECHA_INI, vUSCO_FECHA_FIN, vUSCO_VIGENTE, vCon, vControlEstado)
        End Function


        Public Shared Sub Guardar(ByVal vUSUARIO_CONTRATO As EntityLayer.EL.USUARIO_CONTRATO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.USUARIO_CONTRATO.Guardar(vUSUARIO_CONTRATO, vCon, vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vUSUARIO_CONTRATO As EntityLayer.EL.USUARIO_CONTRATO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.USUARIO_CONTRATO.Eliminar(vUSUARIO_CONTRATO, vCon, vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vUSCO_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.USUARIO_CONTRATO
            Dim vL As List(Of EntityLayer.EL.USUARIO_CONTRATO)
            vL = Buscar(vUSCO_ID:=vUSCO_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_USUARIO_CONTRATO(ByVal order As String, _
                                        ByVal col As String, _
                                        ByVal vLista As List(Of EntityLayer.EL.USUARIO_CONTRATO)) As List(Of EntityLayer.EL.USUARIO_CONTRATO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "CONT_ID"
                        query = query.OrderBy(Function(x) x.CONT_ID)
                    Case "TIPU_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TIPU_DESCRIPCION)
                    Case "USCO_FECHA_FIN"
                        query = query.OrderBy(Function(x) x.USCO_FECHA_FIN)
                    Case "USCO_FECHA_INI"
                        query = query.OrderBy(Function(x) x.USCO_FECHA_INI)
                    Case "USCO_ID"
                        query = query.OrderBy(Function(x) x.USCO_ID)
                    Case "USCO_VIGENTE"
                        query = query.OrderBy(Function(x) x.USCO_VIGENTE)
                    Case "USU_ID"
                        query = query.OrderBy(Function(x) x.USU_ID)
                    Case "USU_NOMBRE_COMPLETO"
                        query = query.OrderBy(Function(x) x.USU_NOMBRE_COMPLETO)
                    Case "USU_RUT"
                        query = query.OrderBy(Function(x) x.USU_RUT)
                End Select
            Else
                Select Case col

                    Case "CONT_ID"
                        query = query.OrderByDescending(Function(x) x.CONT_ID)
                    Case "TIPU_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TIPU_DESCRIPCION)
                    Case "USCO_FECHA_FIN"
                        query = query.OrderByDescending(Function(x) x.USCO_FECHA_FIN)
                    Case "USCO_FECHA_INI"
                        query = query.OrderByDescending(Function(x) x.USCO_FECHA_INI)
                    Case "USCO_ID"
                        query = query.OrderByDescending(Function(x) x.USCO_ID)
                    Case "USCO_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.USCO_VIGENTE)
                    Case "USU_ID"
                        query = query.OrderByDescending(Function(x) x.USU_ID)
                    Case "USU_NOMBRE_COMPLETO"
                        query = query.OrderByDescending(Function(x) x.USU_NOMBRE_COMPLETO)
                    Case "USU_RUT"
                        query = query.OrderByDescending(Function(x) x.USU_RUT)
                End Select
            End If

            Return query.ToList
        End Function
    End Class


End Namespace

