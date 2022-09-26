Imports System
Imports System.Collections
Imports System.Configuration
Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class MOTIVO_AUSENCIA


        Public Shared Function Buscar(Optional ByVal vMOA_ID As Decimal? = Nothing, _
           Optional ByVal vMOA_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.MOTIVO_AUSENCIA)
            Try
                Buscar = DataLayer.DAL.MOTIVO_AUSENCIA.Buscar(vMOA_ID:=vMOA_ID, vMOA_DESCRIPCION:=vMOA_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vMOTIVO_AUSENCIA As EntityLayer.EL.MOTIVO_AUSENCIA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MOTIVO_AUSENCIA.Guardar(vMOTIVO_AUSENCIA:=vMOTIVO_AUSENCIA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vMOTIVO_AUSENCIA As EntityLayer.EL.MOTIVO_AUSENCIA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MOTIVO_AUSENCIA.Eliminar(vMOTIVO_AUSENCIA:=vMOTIVO_AUSENCIA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vMOA_ID As Decimal? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.MOTIVO_AUSENCIA
            Dim vL As List(Of EntityLayer.EL.MOTIVO_AUSENCIA)
            vL = Buscar(vMOA_ID:=vMOA_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function


        Public Shared Function sortList_MOTIVO_AUSENCIA(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.MOTIVO_AUSENCIA)) As List(Of EntityLayer.EL.MOTIVO_AUSENCIA)

            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "MOA_ID"
                        query = query.OrderBy(Function(x) x.MOA_ID)
                    Case "MOA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.MOA_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "MOA_ID"
                        query = query.OrderByDescending(Function(x) x.MOA_ID)
                    Case "MOA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.MOA_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function
    End Class





End Namespace

