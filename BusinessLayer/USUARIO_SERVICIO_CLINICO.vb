Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class USUARIO_SERVICIO_CLINICO


        Public Shared Function Buscar(Optional ByVal vUSU_ID As Int32? = Nothing, _
           Optional ByVal vSCLI_ID As Int32? = Nothing, _
           Optional ByVal vUSSC_FECHA_INICIO As DateTime? = Nothing, _
           Optional ByVal vUSSC_FECHA_FIN As DateTime? = Nothing, _
           Optional ByVal vUSSC_VIGENTE As Boolean? = Nothing, _
            Optional ByVal vTIPU_ID As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.USUARIO_SERVICIO_CLINICO)
            Try
                Buscar = DataLayer.DAL.USUARIO_SERVICIO_CLINICO.Buscar(vUSU_ID:=vUSU_ID, vSCLI_ID:=vSCLI_ID, vUSSC_FECHA_INICIO:=vUSSC_FECHA_INICIO, vUSSC_FECHA_FIN:=vUSSC_FECHA_FIN, vUSSC_VIGENTE:=vUSSC_VIGENTE, vTIPU_ID:=vTIPU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vUSUARIO_SERVICIO_CLINICO As EntityLayer.EL.USUARIO_SERVICIO_CLINICO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.USUARIO_SERVICIO_CLINICO.Guardar(vUSUARIO_SERVICIO_CLINICO:=vUSUARIO_SERVICIO_CLINICO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vUSUARIO_SERVICIO_CLINICO As EntityLayer.EL.USUARIO_SERVICIO_CLINICO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.USUARIO_SERVICIO_CLINICO.Eliminar(vUSUARIO_SERVICIO_CLINICO:=vUSUARIO_SERVICIO_CLINICO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vUSU_ID As Int32? = Nothing, _
       Optional ByVal vSCLI_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.USUARIO_SERVICIO_CLINICO
            Dim vL As List(Of EntityLayer.EL.USUARIO_SERVICIO_CLINICO)
            vL = Buscar(vUSU_ID:=vUSU_ID, _
           vSCLI_ID:=vSCLI_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function


        Public Shared Function ListaUsuarioServicio(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                        Optional ByVal vCLI_ID As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListaUsuarioServicio = DataLayer.DAL.USUARIO_SERVICIO_CLINICO.ListaUsuarioServicio(vUSU_ID, vCLI_ID, vCon, vControlEstado:=vControlEstado)
        End Function
    End Class


End Namespace

