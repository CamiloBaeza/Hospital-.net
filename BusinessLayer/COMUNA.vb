Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class COMUNA


        Public Shared Function Buscar(Optional ByVal vCOM_ID As Int32? = Nothing, _
                                      Optional ByVal vREG_ID As Int32? = Nothing, _
                                      Optional ByVal vCOM_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing,
                                      Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.COMUNA)
            Buscar = DataLayer.DAL.COMUNA.Buscar(vCOM_ID, vREG_ID, vCOM_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarComuna(Optional ByVal vCOM_ID As Int32? = Nothing, _
                                            Optional ByVal vREG_ID As Int32? = Nothing, _
                                            Optional ByVal vCOM_DESCRIPCION As String = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing,
                                            Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.COMUNA)
            BuscarComuna = DataLayer.DAL.COMUNA.BuscarComuna(vCOM_ID, vREG_ID, vCOM_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListaComuna(Optional ByVal vPAI_ID As Int32? = Nothing, _
                                           Optional ByVal vREG_ID As Int32? = Nothing, _
                                           Optional ByVal vCOM_ID As Int32? = Nothing, _
                                           Optional ByVal vREG_DESCRIPCION As String = Nothing, _
                                           Optional ByVal vCOM_DESCRIPCION As String = Nothing, _
                                           Optional ByVal vCon As Conexion = Nothing,
                                           Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListaComuna = DataLayer.DAL.COMUNA.ListaComuna(vPAI_ID, vREG_ID, vCOM_ID, vREG_DESCRIPCION, vCOM_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Sub Guardar(ByVal vCOMUNA As EntityLayer.EL.COMUNA, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.COMUNA.Guardar(vCOMUNA, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vCOMUNA As EntityLayer.EL.COMUNA, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.COMUNA.Eliminar(vCOMUNA, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vCOM_ID As Int32? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As EntityLayer.EL.COMUNA
            Dim vL As List(Of EntityLayer.EL.COMUNA)
            vL = Buscar(vCOM_ID:=vCOM_ID, _
           vCon:=vCon, vControlEstado:=vControlEstado)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_COMUNA(ByVal order As String, _
                                               ByVal col As String, _
                                               ByVal vLista As List(Of EntityLayer.EL.COMUNA)) As List(Of EntityLayer.EL.COMUNA)
            Dim query = From v In vLista

            If order = "Asc" Then
                Select Case col
                    Case "COM_ID"
                        query = query.OrderBy(Function(x) x.COM_ID)
                    Case "REG_ID"
                        query = query.OrderBy(Function(x) x.REG_ID)
                    Case "COM_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.COM_DESCRIPCION)
                        'Case "DAN_CODIGO"
                        '    query = query.OrderBy(Function(x) x.DAN_CODIGO)
                        'Case "DAN_VIGENCIA"
                        '    query = query.OrderBy(Function(x) x.DAN_VIGENCIA)
                End Select
            Else
                Select Case col
                    Case "COM_ID"
                        query = query.OrderByDescending(Function(x) x.COM_ID)
                    Case "REG_ID"
                        query = query.OrderByDescending(Function(x) x.REG_ID)
                    Case "COM_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.COM_DESCRIPCION)
                        'Case "DAN_CODIGO"
                        '    query = query.OrderByDescending(Function(x) x.DAN_CODIGO)
                        'Case "DAN_VIGENCIA"
                        '    query = query.OrderByDescending(Function(x) x.DAN_VIGENCIA)
                End Select
            End If

            Return query.ToList
        End Function


    End Class

End Namespace

