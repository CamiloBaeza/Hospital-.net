Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class USUARIO_ESPECIALIDAD


        Public Shared Function Buscar(Optional ByVal vESP_ID As String = Nothing, _
           Optional ByVal vUSU_ID As Int32? = Nothing, _
           Optional ByVal vDOCESP_INGRESO As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.USUARIO_ESPECIALIDAD)
            Try
                Buscar = DataLayer.DAL.USUARIO_ESPECIALIDAD.Buscar(vESP_ID:=vESP_ID, vUSU_ID:=vUSU_ID, vDOCESP_INGRESO:=vDOCESP_INGRESO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vUSUARIO_ESPECIALIDAD As EntityLayer.EL.USUARIO_ESPECIALIDAD, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.USUARIO_ESPECIALIDAD.Guardar(vUSUARIO_ESPECIALIDAD:=vUSUARIO_ESPECIALIDAD, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vUSUARIO_ESPECIALIDAD As EntityLayer.EL.USUARIO_ESPECIALIDAD, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.USUARIO_ESPECIALIDAD.Eliminar(vUSUARIO_ESPECIALIDAD:=vUSUARIO_ESPECIALIDAD, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vESP_ID As String = Nothing, _
                                            Optional ByVal vUSU_ID As Int32? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.USUARIO_ESPECIALIDAD
            Dim vL As List(Of EntityLayer.EL.USUARIO_ESPECIALIDAD)
            vL = Buscar(vESP_ID:=vESP_ID, vUSU_ID:=vUSU_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count >= 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function


        Public Shared Function ListaUsuarioEspecialidad(Optional ByVal vUSU_ID As Int32? = Nothing, _
       Optional ByVal vESP_ID As String = Nothing, _
       Optional ByVal vDOCESP_INGRESO As DateTime? = Nothing, _
       Optional ByVal vUSU_RUT As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.USUARIO_ESPECIALIDAD)
            ListaUsuarioEspecialidad = DataLayer.DAL.USUARIO_ESPECIALIDAD.ListaUsuarioEspecialidad(vUSU_ID, vESP_ID, vDOCESP_INGRESO, vUSU_RUT, vCon, vControlEstado:=vControlEstado)
        End Function


        Public Shared Function sortList(ByVal order As String, _
                                     ByVal col As String, _
                                     ByVal vLista As List(Of EntityLayer.EL.USUARIO_ESPECIALIDAD)) As List(Of EntityLayer.EL.USUARIO_ESPECIALIDAD)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "USU_ID"
                        query = query.OrderBy(Function(x) x.USU_ID)
                    Case "ESP_ID"
                        query = query.OrderBy(Function(x) x.ESP_ID)
                    Case "DOCESP_INGRESO"
                        query = query.OrderBy(Function(x) x.DOCESP_INGRESO)
                    Case "ESP_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.ESP_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "USU_ID"
                        query = query.OrderByDescending(Function(x) x.USU_ID)
                    Case "ESP_ID"
                        query = query.OrderByDescending(Function(x) x.ESP_ID)
                    Case "DOCESP_INGRESO"
                        query = query.OrderByDescending(Function(x) x.DOCESP_INGRESO)
                    Case "ESP_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.ESP_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function

    End Class


End Namespace

