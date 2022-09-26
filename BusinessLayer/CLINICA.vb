Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class CLINICA


        Public Shared Function Buscar(Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vPAI_ID As Integer? = Nothing, _
                                      Optional ByVal vREG_ID As Integer? = Nothing, _
                                      Optional ByVal vCOM_ID As Integer? = Nothing, _
                                      Optional ByVal vCLI_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing,
                                      Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA)
            Buscar = DataLayer.DAL.CLINICA.Buscar(vCLI_ID, vCLI_DESCRIPCION, vPAI_ID, vREG_ID, vCOM_ID, vCon, vControlEstado:=vControlEstado)
        End Function


        Public Shared Function BuscarPorUsuario(Optional ByVal vCLI_ID As String = Nothing, _
Optional ByVal vCLI_DESCRIPCION As String = Nothing, _
Optional ByVal vUSU_RUT As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA)
            BuscarPorUsuario = DataLayer.DAL.CLINICA.BuscarPorUsuario(vCLI_ID, vCLI_DESCRIPCION, vUSU_RUT, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarClinicaUsuario(Optional ByVal vCLI_ID As String = Nothing, _
Optional ByVal vCLI_DESCRIPCION As String = Nothing, _
Optional ByVal vUSU_RUT As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarClinicaUsuario = DataLayer.DAL.CLINICA.ListarClinicaUsuario(vCLI_ID, vCLI_DESCRIPCION, vUSU_RUT, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarClinica(Optional ByVal vCLI_ID As String = Nothing, _
       Optional ByVal vCLI_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA)
            BuscarClinica = DataLayer.DAL.CLINICA.BuscarClinica(vCLI_ID, vCLI_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function



        Public Shared Sub Guardar(ByVal vCLINICA As EntityLayer.EL.CLINICA, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.CLINICA.Guardar(vCLINICA, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vCLINICA As EntityLayer.EL.CLINICA, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.CLINICA.Eliminar(vCLINICA, vCon, vControlEstado:=vControlEstado)
        End Sub


        Public Shared Function ObtenerPorId(Optional ByVal vCLI_ID As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.CLINICA
            If String.IsNullOrEmpty(vCLI_ID) = False Then
                Dim vL As List(Of EntityLayer.EL.CLINICA)
                vL = Buscar(vCLI_ID:=vCLI_ID, _
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

        Public Shared Function sortList_CLINICA(ByVal order As String, _
                                                     ByVal col As String, _
                                                     ByVal vLista As List(Of EntityLayer.EL.CLINICA)) As List(Of EntityLayer.EL.CLINICA)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLI_DESCRIPCION)
                    
                End Select
            Else
                Select Case col
                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLI_DESCRIPCION)
                    
                End Select
            End If

            Return query.ToList
        End Function


        


    End Class


End Namespace

