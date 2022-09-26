Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class VIEWSTATE


        Public Shared Function Buscar(Optional ByVal vVIEW_ID As Long? = Nothing, _
           Optional ByVal vVIEW_SESSION_ID As String = Nothing, _
           Optional ByVal vVIEW_REQUEST_PATH As String = Nothing, _
           Optional ByVal vVIEW_VIEWSTATE As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.VIEWSTATE)
            Try
                Buscar = DataLayer.DAL.VIEWSTATE.Buscar(vVIEW_ID:=vVIEW_ID, vVIEW_SESSION_ID:=vVIEW_SESSION_ID, vVIEW_REQUEST_PATH:=vVIEW_REQUEST_PATH, vVIEW_VIEWSTATE:=vVIEW_VIEWSTATE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vVIEWSTATE As EntityLayer.EL.VIEWSTATE, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.VIEWSTATE.Guardar(vVIEWSTATE:=vVIEWSTATE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vVIEWSTATE As EntityLayer.EL.VIEWSTATE, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.VIEWSTATE.Eliminar(vVIEWSTATE:=vVIEWSTATE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vVIEW_ID As Long? = Nothing, _
       Optional ByVal vVIEW_SESSION_ID As String = Nothing, _
       Optional ByVal vVIEW_REQUEST_PATH As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.VIEWSTATE
            If vVIEW_ID.HasValue AndAlso String.IsNullOrEmpty(vVIEW_SESSION_ID) = False AndAlso String.IsNullOrEmpty(vVIEW_REQUEST_PATH) = False Then
                Dim vL As List(Of EntityLayer.EL.VIEWSTATE)
                vL = Buscar(vVIEW_ID:=vVIEW_ID, _
               vVIEW_SESSION_ID:=vVIEW_SESSION_ID, _
               vVIEW_REQUEST_PATH:=vVIEW_REQUEST_PATH, _
               vCon:=vCon)
                If vL IsNot Nothing AndAlso vL.Count = 1 Then
                    ObtenerPorId = vL(0)
                Else
                    ObtenerPorId = Nothing
                End If
            Else
                ObtenerPorId = Nothing
            End If
        End Function
    End Class


End Namespace

