Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class TIPO_SALUD


        Public Shared Function Buscar(Optional ByVal vTIPS_ID As Int32? = Nothing, _
       Optional ByVal vTIPS_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.TIPO_SALUD)
            Buscar = DataLayer.DAL.TIPO_SALUD.Buscar(vTIPS_ID, vTIPS_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function


        Public Shared Sub Guardar(ByVal vTIPO_SALUD As EntityLayer.EL.TIPO_SALUD, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.TIPO_SALUD.Guardar(vTIPO_SALUD, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vTIPO_SALUD As EntityLayer.EL.TIPO_SALUD, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.TIPO_SALUD.Eliminar(vTIPO_SALUD, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vTIPS_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.TIPO_SALUD
            Dim vL As List(Of EntityLayer.EL.TIPO_SALUD)
            vL = Buscar(vTIPS_ID:=vTIPS_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_TIPO_SALUD(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.TIPO_SALUD)) As List(Of EntityLayer.EL.TIPO_SALUD)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "TIPS_ID"
                        query = query.OrderBy(Function(x) x.TIPS_ID)
                    Case "TIPS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TIPS_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "TIPS_ID"
                        query = query.OrderByDescending(Function(x) x.TIPS_ID)
                    Case "TIPS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TIPS_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function
    End Class


End Namespace

