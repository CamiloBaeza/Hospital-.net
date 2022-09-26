Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class INFORME_PENDIENTE_FACTURAR

        Public Shared Function Buscar(Optional ByVal vFECHA_INICIO As DateTime? = Nothing, _
           Optional ByVal vFECHA_FIN As DateTime? = Nothing, _
          Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INFORME_PENDIENTE_FACTURAR)
            Try
                Buscar = DataLayer.DAL.INFORME_PENDIENTE_FACTURAR.Buscar(vFECHA_INICIO:=vFECHA_INICIO, vFECHA_FIN:=vFECHA_FIN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function
     Public Shared Function sortList_INFORME_PENDIENTE_FACTURAR(ByVal order As String, _
                                        ByVal col As String, _
                                        ByVal vLista As List(Of EntityLayer.EL.INFORME_PENDIENTE_FACTURAR)) As List(Of EntityLayer.EL.INFORME_PENDIENTE_FACTURAR)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "FECHA_PALABRAS"
                        query = query.OrderBy(Function(x) x.FECHA_PALABRAS)
                    Case "CLIS_RUT"
                        query = query.OrderBy(Function(x) x.CLIS_RUT)
                    Case "CLIS_RAZON_SOCIAL"
                        query = query.OrderBy(Function(x) x.CLIS_RAZON_SOCIAL)
                    Case "CONT_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.CONT_FECHA_REGISTRO)
                    Case "VEND_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.VEND_DESCRIPCION)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.VEND_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "FECHA_PALABRAS"
                        query = query.OrderByDescending(Function(x) x.FECHA_PALABRAS)
                    Case "CLIS_RUT"
                        query = query.OrderByDescending(Function(x) x.CLIS_RUT)
                    Case "CLIS_RAZON_SOCIAL"
                        query = query.OrderByDescending(Function(x) x.CLIS_RAZON_SOCIAL)
                    Case "CONT_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.CONT_FECHA_REGISTRO)
                    Case "VEND_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.VEND_DESCRIPCION)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.VEND_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function
    End Class
End Namespace
