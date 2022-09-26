Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class TIPO_PRESTACION


        Public Shared Function Buscar(Optional ByVal vTPRE_ID As Decimal? = Nothing, _
           Optional ByVal vCLI_ID As String = Nothing, _
           Optional ByVal vTPRE_DESCRIPCION As String = Nothing, _
           Optional ByVal vTPRE_DEFAULT As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.TIPO_PRESTACION)
            Try
                Buscar = DataLayer.DAL.TIPO_PRESTACION.Buscar(vTPRE_ID:=vTPRE_ID, vCLI_ID:=vCLI_ID, vTPRE_DESCRIPCION:=vTPRE_DESCRIPCION, vTPRE_DEFAULT:=vTPRE_DEFAULT, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function


        Public Shared Sub Guardar(ByVal vTIPO_PRESTACION As EntityLayer.EL.TIPO_PRESTACION, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            Try
                DataLayer.DAL.TIPO_PRESTACION.Guardar(vTIPO_PRESTACION:=vTIPO_PRESTACION, vCon:=vCon, vControlEstado:=vControlEstado)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub



        Public Shared Sub Eliminar(ByVal vTIPO_PRESTACION As EntityLayer.EL.TIPO_PRESTACION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.TIPO_PRESTACION.Eliminar(vTIPO_PRESTACION:=vTIPO_PRESTACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vTPRE_ID As Decimal? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.TIPO_PRESTACION
            Dim vL As List(Of EntityLayer.EL.TIPO_PRESTACION)
            vL = Buscar(vTPRE_ID:=vTPRE_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_TIPO_PRESTACION(ByVal order As String, _
                                      ByVal col As String, _
                                      ByVal vLista As List(Of EntityLayer.EL.TIPO_PRESTACION)) As List(Of EntityLayer.EL.TIPO_PRESTACION)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "TPRE_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TPRE_DESCRIPCION)
                    Case "TPRE_ID"
                        query = query.OrderBy(Function(x) x.TPRE_ID)
                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                End Select
            Else
                Select Case col
                    Case "TPRE_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TPRE_DESCRIPCION)
                    Case "TPRE_ID"
                        query = query.OrderByDescending(Function(x) x.TPRE_ID)
                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                End Select
            End If

            Return query.ToList
        End Function

        Public Shared Function BuscarTipoPrestacionAutocomplete_pide_hora(Optional ByVal vCon As Conexion = Nothing, Optional ByVal vCLI_ID As String = Nothing) As List(Of EntityLayer.EL.TIPO_PRESTACION)
            Try
                BuscarTipoPrestacionAutocomplete_pide_hora = DataLayer.DAL.TIPO_PRESTACION.buscarTipoPrestacionAutocomplete_pide_hora(vCLI_ID:=vCLI_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function


    End Class
End Namespace

