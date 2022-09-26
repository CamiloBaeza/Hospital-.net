Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class CONVENIOS_TIPO_PRESTACION


        Public Shared Function Buscar(Optional ByVal vCOEN_ID As Decimal? = Nothing, _
           Optional ByVal vTPRE_ID As Decimal? = Nothing, _
           Optional ByVal vCOTP_PORC_DESCUENTO As Decimal? = Nothing, _
           Optional ByVal vCLI_ID As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CONVENIOS_TIPO_PRESTACION)
            Try
                Buscar = DataLayer.DAL.CONVENIOS_TIPO_PRESTACION.Buscar(vCOEN_ID:=vCOEN_ID, vTPRE_ID:=vTPRE_ID, vCOTP_PORC_DESCUENTO:=vCOTP_PORC_DESCUENTO, vCLI_ID:=vCLI_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vCONVENIOS_TIPO_PRESTACION As EntityLayer.EL.CONVENIOS_TIPO_PRESTACION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.CONVENIOS_TIPO_PRESTACION.Guardar(vCONVENIOS_TIPO_PRESTACION:=vCONVENIOS_TIPO_PRESTACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vCONVENIOS_TIPO_PRESTACION As EntityLayer.EL.CONVENIOS_TIPO_PRESTACION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.CONVENIOS_TIPO_PRESTACION.Eliminar(vCONVENIOS_TIPO_PRESTACION:=vCONVENIOS_TIPO_PRESTACION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vCOEN_ID As Decimal? = Nothing, _
       Optional ByVal vTPRE_ID As Decimal? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.CONVENIOS_TIPO_PRESTACION
            Dim vL As List(Of EntityLayer.EL.CONVENIOS_TIPO_PRESTACION)
            vL = Buscar(vCOEN_ID:=vCOEN_ID, _
           vTPRE_ID:=vTPRE_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_CONVENIOS_TIPO_PRESTACION(ByVal order As String, _
                                                       ByVal col As String, _
                                                       ByVal vLista As List(Of EntityLayer.EL.CONVENIOS_TIPO_PRESTACION)) As List(Of EntityLayer.EL.CONVENIOS_TIPO_PRESTACION)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "COEN_ID"
                        query = query.OrderBy(Function(x) x.COEN_ID)
                    Case "COEN_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.COEN_DESCRIPCION)
                    Case "TPRE_ID"
                        query = query.OrderBy(Function(x) x.TPRE_ID)
                    Case "TPRE_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TPRE_DESCRIPCION)
                    Case "COTP_PORC_DESCUENTO"
                        query = query.OrderBy(Function(x) x.COTP_PORC_DESCUENTO)
                End Select
            Else
                Select Case col
                    Case "COEN_ID"
                        query = query.OrderByDescending(Function(x) x.COEN_ID)
                    Case "COEN_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.COEN_DESCRIPCION)
                    Case "TPRE_ID"
                        query = query.OrderByDescending(Function(x) x.TPRE_ID)
                    Case "TPRE_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TPRE_DESCRIPCION)
                    Case "COTP_PORC_DESCUENTO"
                        query = query.OrderByDescending(Function(x) x.COTP_PORC_DESCUENTO)
                End Select
            End If
            Return query.ToList
        End Function
    End Class


End Namespace

