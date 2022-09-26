Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class SISTEMA_SALUD


        Public Shared Function Buscar(Optional ByVal vSISS_ID As Int32? = Nothing, _
       Optional ByVal vTIPS_ID As Int32? = Nothing, _
       Optional ByVal vSISS_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.SISTEMA_SALUD)
            Buscar = DataLayer.DAL.SISTEMA_SALUD.Buscar(vSISS_ID, vTIPS_ID, vSISS_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        'BuscarLike
        Public Shared Function BuscarLike(Optional ByVal vSISS_ID As Int32? = Nothing, _
       Optional ByVal vTIPS_ID As Int32? = Nothing, _
       Optional ByVal vSISS_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.SISTEMA_SALUD)
            BuscarLike = DataLayer.DAL.SISTEMA_SALUD.BuscarLike(vSISS_ID, vTIPS_ID, vSISS_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function


        'BuscarSistemaSalud
        Public Shared Function BuscarSistemaSalud(Optional ByVal vSISS_ID As Int32? = Nothing, _
       Optional ByVal vTIPS_ID As Int32? = Nothing, _
       Optional ByVal vSISS_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            BuscarSistemaSalud = DataLayer.DAL.SISTEMA_SALUD.BuscarSistemaSalud(vSISS_ID, vTIPS_ID, vSISS_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Sub Guardar(ByVal vSISTEMA_SALUD As EntityLayer.EL.SISTEMA_SALUD, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.SISTEMA_SALUD.Guardar(vSISTEMA_SALUD, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vSISTEMA_SALUD As EntityLayer.EL.SISTEMA_SALUD, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.SISTEMA_SALUD.Eliminar(vSISTEMA_SALUD, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vSISS_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.SISTEMA_SALUD
            Dim vL As List(Of EntityLayer.EL.SISTEMA_SALUD)
            vL = Buscar(vSISS_ID:=vSISS_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_SISTEMA_SALUD(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.SISTEMA_SALUD)) As List(Of EntityLayer.EL.SISTEMA_SALUD)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "SISS_ID"
                        query = query.OrderBy(Function(x) x.SISS_ID)
                    Case "TIPS_ID"
                        query = query.OrderBy(Function(x) x.TIPS_ID)
                    Case "SISS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.SISS_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "SISS_ID"
                        query = query.OrderByDescending(Function(x) x.SISS_ID)
                    Case "TIPS_ID"
                        query = query.OrderByDescending(Function(x) x.TIPS_ID)
                    Case "SISS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.SISS_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function
    End Class


End Namespace

