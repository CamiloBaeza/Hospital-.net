Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class FESTIVO

        Public Shared Sub Guardar(ByVal vFESTIVO As EntityLayer.EL.FESTIVO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.FESTIVO.Guardar(vFESTIVO, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vFESTIVO As EntityLayer.EL.FESTIVO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.FESTIVO.Eliminar(vFESTIVO, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function Buscar(Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            Buscar = DataLayer.DAL.FESTIVO.Buscar(vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarPresMes(Optional ByVal vPRES_ID As Int32? = Nothing _
                                    , Optional ByVal vPAC_ID As Int32? = Nothing _
                                    , Optional ByVal vFECHA As DateTime? = Nothing _
                                    , Optional ByVal vHORD_VISIBLE_WEB As Boolean? = Nothing _
                                    , Optional ByVal vSOLO_DISPONIBLE As Boolean? = Nothing _
                                    , Optional ByVal vCon As Conexion = Nothing _
                                   , Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            BuscarPresMes = DataLayer.DAL.FESTIVO.BuscarPresMes(vPRES_ID:=vPRES_ID, vPAC_ID:=vPAC_ID, vFECHA:=vFECHA, vHORD_VISIBLE_WEB:=vHORD_VISIBLE_WEB, vSOLO_DISPONIBLE:=vSOLO_DISPONIBLE, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarPresMesPideHora(Optional ByVal vPRES_ID As Int32? = Nothing _
                            , Optional ByVal vPAC_ID As Int32? = Nothing _
                            , Optional ByVal vFECHA As DateTime? = Nothing _
                            , Optional ByVal vHORD_VISIBLE_WEB As Boolean? = Nothing _
                            , Optional ByVal vSOLO_DISPONIBLE As Boolean? = Nothing _
                            , Optional ByVal vCon As Conexion = Nothing _
                           , Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            BuscarPresMesPideHora = DataLayer.DAL.FESTIVO.BuscarPresMesPideHora(vPRES_ID:=vPRES_ID, vPAC_ID:=vPAC_ID, vFECHA:=vFECHA, vHORD_VISIBLE_WEB:=vHORD_VISIBLE_WEB, vSOLO_DISPONIBLE:=vSOLO_DISPONIBLE, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function Lista(Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FESTIVO)
            Lista = DataLayer.DAL.FESTIVO.Lista(vCon, vControlEstado:=vControlEstado)
        End Function


        Public Shared Function sortList_FESTIVO(ByVal order As String, _
                                             ByVal col As String, _
                                             ByVal vLista As List(Of EntityLayer.EL.FESTIVO)) As List(Of EntityLayer.EL.FESTIVO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "FEST_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.FEST_DESCRIPCION)
                    Case "FEST_FECHA"
                        query = query.OrderBy(Function(x) x.FEST_FECHA)
                    Case "FEST_TIPO"
                        query = query.OrderBy(Function(x) x.FEST_TIPO)
                    Case "FEST_TRABAJA"
                        query = query.OrderBy(Function(x) x.FEST_TRABAJA)

                End Select
            Else
                Select Case col

                    Case "FEST_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.FEST_DESCRIPCION)
                    Case "FEST_FECHA"
                        query = query.OrderByDescending(Function(x) x.FEST_FECHA)
                    Case "FEST_TIPO"
                        query = query.OrderByDescending(Function(x) x.FEST_TIPO)
                    Case "FEST_TRABAJA"
                        query = query.OrderByDescending(Function(x) x.FEST_TRABAJA)

                End Select
            End If

            Return query.ToList
        End Function
    End Class
End Namespace