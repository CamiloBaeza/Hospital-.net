Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class FUNCION

        Public Shared Function BuscarAccesoFichaAmbulatoria(Optional ByVal vCLI_ID As Int32? = Nothing, _
              Optional ByVal vUSU_ID As Int32? = Nothing, _
              Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As Boolean
            BuscarAccesoFichaAmbulatoria = DataLayer.DAL.FUNCION.BuscarAccesoFichaAmbulatoria(vCLI_ID:=vCLI_ID, vUSU_ID:=vUSU_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function



        Public Shared Function Buscar(Optional ByVal vFUNCION_ID As Int32? = Nothing, _
       Optional ByVal vDESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FUNCION)
            Buscar = DataLayer.DAL.FUNCION.Buscar(vFUNCION_ID, vDESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarMenu(Optional ByVal vUSU_ID As Int32? = Nothing, _
               Optional ByVal vFUNCION_ID As Int32? = Nothing, _
               Optional ByVal vCLI_ID As Int32? = Nothing, _
               Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FUNCION)
            ListarMenu = DataLayer.DAL.FUNCION.ListarMenu(vUSU_ID, vFUNCION_ID, vCLI_ID, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarMenuPerfil(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                Optional ByVal vTIPU_ID As Int32? = Nothing, _
                                                Optional ByVal vFUNCION_ID As Int32? = Nothing, _
                                                Optional ByVal vCLI_ID As String = Nothing, _
                                                Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FUNCION)
            ListarMenuPerfil = DataLayer.DAL.FUNCION.ListarMenuPerfil(vUSU_ID:=vUSU_ID, vTIPU_ID:=vTIPU_ID, vFUNCION_ID:=vFUNCION_ID, vCLI_ID:=vCLI_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Sub Guardar(ByVal vFUNCION As EntityLayer.EL.FUNCION, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.FUNCION.Guardar(vFUNCION, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vFUNCION As EntityLayer.EL.FUNCION, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.FUNCION.Eliminar(vFUNCION, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ListarSubMenu(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                             Optional ByVal vFUNCION_ID As Int32? = Nothing, _
                                            Optional ByVal vFUNCION_SUBMENU_ID As Int32? = Nothing, _
                                            Optional ByVal vCLI_ID As String = Nothing, _
                                            Optional ByVal vTIPU_ID As Int32? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FUNCION)
            ListarSubMenu = DataLayer.DAL.FUNCION.ListarSubMenu(vUSU_ID:=vUSU_ID, vFUNCION_ID:=vFUNCION_ID, vFUNCION_SUBMENU_ID:=vFUNCION_SUBMENU_ID, vCLI_ID:=vCLI_ID, vTIPU_ID:=vTIPU_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function



        Public Shared Function ObtenerPorId(Optional ByVal vFUNCION_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.FUNCION
            Dim vL As List(Of EntityLayer.EL.FUNCION)
            vL = Buscar(vFUNCION_ID:=vFUNCION_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

