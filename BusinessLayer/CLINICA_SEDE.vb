Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class CLINICA_SEDE


        Public Shared Function Buscar(Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vPAI_ID As Integer? = Nothing, _
                                      Optional ByVal vREG_ID As Integer? = Nothing, _
                                      Optional ByVal vCOM_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vCLIS_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vCLIS_CALLE As String = Nothing, _
                                      Optional ByVal vCLIS_TELEFONO As String = Nothing, _
                                      Optional ByVal vCLIS_TELEFONO2 As String = Nothing, _
                                      Optional ByVal vCLIS_FAX As String = Nothing, _
                                      Optional ByVal vCLIS_MAIL As String = Nothing, _
                                      Optional ByVal vCLIS_SITIO_WEB As String = Nothing, _
                                      Optional ByVal vCLIS_HORA_INI As DateTime? = Nothing, _
                                      Optional ByVal vCLIS_HORA_FIN As DateTime? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing,
                                      Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA_SEDE)
            Buscar = DataLayer.DAL.CLINICA_SEDE.Buscar(vCLIS_ID, vPAI_ID, vREG_ID, vCOM_ID, vCLI_ID, vCLIS_DESCRIPCION, vCLIS_CALLE, vCLIS_TELEFONO, vCLIS_TELEFONO2, vCLIS_FAX, vCLIS_MAIL, vCLIS_SITIO_WEB, vCLIS_HORA_INI, vCLIS_HORA_FIN, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarPorUsuario(Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                                Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                Optional ByVal vCOM_ID As Int32? = Nothing, _
                                                Optional ByVal vCLI_ID As String = Nothing, _
                                                Optional ByVal vCLIS_DESCRIPCION As String = Nothing, _
                                                Optional ByVal vCLIS_CALLE As String = Nothing, _
                                                Optional ByVal vCLIS_TELEFONO As String = Nothing, _
                                                Optional ByVal vCLIS_TELEFONO2 As String = Nothing, _
                                                Optional ByVal vCLIS_FAX As String = Nothing, _
                                                Optional ByVal vCLIS_MAIL As String = Nothing, _
                                                Optional ByVal vCLIS_SITIO_WEB As String = Nothing, _
                                                Optional ByVal vCLIS_HORA_INI As DateTime? = Nothing, _
                                                Optional ByVal vCLIS_HORA_FIN As DateTime? = Nothing, _
                                                Optional ByVal vCon As Conexion = Nothing, _
                                                Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA_SEDE)
            BuscarPorUsuario = DataLayer.DAL.CLINICA_SEDE.BuscarPorUsuario(vCLIS_ID:=vCLIS_ID, vUSU_ID:=vUSU_ID, vCOM_ID:=vCOM_ID, vCLI_ID:=vCLI_ID, vCLIS_DESCRIPCION:=vCLIS_DESCRIPCION, vCLIS_CALLE:=vCLIS_CALLE, vCLIS_TELEFONO:=vCLIS_TELEFONO, vCLIS_TELEFONO2:=vCLIS_TELEFONO2, vCLIS_FAX:=vCLIS_FAX, vCLIS_MAIL:=vCLIS_MAIL, vCLIS_SITIO_WEB:=vCLIS_SITIO_WEB, vCLIS_HORA_INI:=vCLIS_HORA_INI, vCLIS_HORA_FIN:=vCLIS_HORA_FIN, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function


        Public Shared Function BuscarAdm(Optional ByVal vCLIS_ID As Int32? = Nothing, _
Optional ByVal vCOM_ID As Int32? = Nothing, _
Optional ByVal vCLI_ID As String = Nothing, _
Optional ByVal vCLIS_DESCRIPCION As String = Nothing, _
Optional ByVal vCLIS_CALLE As String = Nothing, _
Optional ByVal vCLIS_TELEFONO As String = Nothing, _
Optional ByVal vCLIS_TELEFONO2 As String = Nothing, _
Optional ByVal vCLIS_FAX As String = Nothing, _
Optional ByVal vCLIS_MAIL As String = Nothing, _
Optional ByVal vCLIS_SITIO_WEB As String = Nothing, _
Optional ByVal vCLIS_HORA_INI As DateTime? = Nothing, _
Optional ByVal vCLIS_HORA_FIN As DateTime? = Nothing, _
Optional ByVal vUSU_ID As Int32? = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA_SEDE)
            BuscarAdm = DataLayer.DAL.CLINICA_SEDE.BuscarAdm(vCLIS_ID, vCOM_ID, vCLI_ID, vCLIS_DESCRIPCION, vCLIS_CALLE, vCLIS_TELEFONO, vCLIS_TELEFONO2, vCLIS_FAX, vCLIS_MAIL, vCLIS_SITIO_WEB, vCLIS_HORA_INI, vCLIS_HORA_FIN, vUSU_ID, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function Listar(Optional ByVal vCLIS_ID As Int32? = Nothing, _
       Optional ByVal vCOM_ID As Int32? = Nothing, _
       Optional ByVal vREG_ID As Int32? = Nothing, _
       Optional ByVal vCLI_ID As String = Nothing, _
       Optional ByVal vCLIS_DESCRIPCION As String = Nothing, _
       Optional ByVal vCLIS_CALLE As String = Nothing, _
       Optional ByVal vCLIS_TELEFONO As String = Nothing, _
       Optional ByVal vCLIS_TELEFONO2 As String = Nothing, _
       Optional ByVal vCLIS_FAX As String = Nothing, _
       Optional ByVal vCLIS_MAIL As String = Nothing, _
       Optional ByVal vCLIS_SITIO_WEB As String = Nothing, _
       Optional ByVal vCLIS_HORA_INI As DateTime? = Nothing, _
       Optional ByVal vCLIS_HORA_FIN As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA_SEDE)
            Listar = DataLayer.DAL.CLINICA_SEDE.Listar(vCLIS_ID, vCOM_ID, vREG_ID, vCLI_ID, vCLIS_DESCRIPCION, vCLIS_CALLE, vCLIS_TELEFONO, vCLIS_TELEFONO2, vCLIS_FAX, vCLIS_MAIL, vCLIS_SITIO_WEB, vCLIS_HORA_INI, vCLIS_HORA_FIN, vCon, vControlEstado:=vControlEstado)
        End Function


        Public Shared Function ListaClinicaSede(Optional ByVal vCLIS_ID As Int32? = Nothing, _
       Optional ByVal vCOM_ID As Int32? = Nothing, _
       Optional ByVal vCLI_ID As String = Nothing, _
       Optional ByVal vCLIS_DESCRIPCION As String = Nothing, _
       Optional ByVal vCLIS_CALLE As String = Nothing, _
       Optional ByVal vCLIS_TELEFONO As String = Nothing, _
       Optional ByVal vCLIS_TELEFONO2 As String = Nothing, _
       Optional ByVal vCLIS_FAX As String = Nothing, _
       Optional ByVal vCLIS_MAIL As String = Nothing, _
       Optional ByVal vCLIS_SITIO_WEB As String = Nothing, _
       Optional ByVal vCLIS_HORA_INI As DateTime? = Nothing, _
       Optional ByVal vCLIS_HORA_FIN As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListaClinicaSede = DataLayer.DAL.CLINICA_SEDE.ListaClinicaSede(vCLIS_ID, vCOM_ID, vCLI_ID, vCLIS_DESCRIPCION, vCLIS_CALLE, vCLIS_TELEFONO, vCLIS_TELEFONO2, vCLIS_FAX, vCLIS_MAIL, vCLIS_SITIO_WEB, vCLIS_HORA_INI, vCLIS_HORA_FIN, vCon, vControlEstado:=vControlEstado)
        End Function


        '        Public Shared Function ListaClinicaSedeAdmAgenda(Optional ByVal vUSU_ID As Int32? = Nothing, _
        '                                                        Optional ByVal vCLI_ID As String = Nothing, _
        'Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
        '            ListaClinicaSedeAdmAgenda = DataLayer.DAL.CLINICA_SEDE.ListaClinicaSedeAdmAgenda(vUSU_ID, vCLI_ID, vCon, vControlEstado:=vControlEstado)
        '        End Function





        Public Shared Function ListaClinicaSedePorUsuario(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                Optional ByVal vCLI_ID As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListaClinicaSedePorUsuario = DataLayer.DAL.CLINICA_SEDE.ListaClinicaSedePorUsuario(vUSU_ID, vCLI_ID, vCon, vControlEstado:=vControlEstado)
        End Function





        Public Shared Sub Guardar(ByVal vCLINICA_SEDE As EntityLayer.EL.CLINICA_SEDE, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.CLINICA_SEDE.Guardar(vCLINICA_SEDE, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vCLINICA_SEDE As EntityLayer.EL.CLINICA_SEDE, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.CLINICA_SEDE.Eliminar(vCLINICA_SEDE, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vCLIS_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As EntityLayer.EL.CLINICA_SEDE
            Dim vL As List(Of EntityLayer.EL.CLINICA_SEDE)
            vL = Buscar(vCLIS_ID:=vCLIS_ID, _
           vCon:=vCon, vControlEstado:=vControlEstado)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_CLINICA_SEDE(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.CLINICA_SEDE)) As List(Of EntityLayer.EL.CLINICA_SEDE)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLI_DESCRIPCION)
                    Case "CLIS_ID"
                        query = query.OrderBy(Function(x) x.CLIS_ID)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.CLIS_DESCRIPCION)
                    Case "COM_ID"
                        query = query.OrderBy(Function(x) x.COM_ID)
                    Case "COM_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.COM_DESCRIPCION)
                    Case "CLIS_RUT"
                        query = query.OrderBy(Function(x) x.CLIS_RUT)
                    Case "CLIS_CALLE"
                        query = query.OrderBy(Function(x) x.CLIS_CALLE)
                    Case "CLIS_TELEFONO"
                        query = query.OrderBy(Function(x) x.CLIS_TELEFONO)
                    Case "CLIS_TELEFONO2"
                        query = query.OrderBy(Function(x) x.CLIS_TELEFONO2)
                    Case "CLIS_RAZON_SOCIAL"
                        query = query.OrderBy(Function(x) x.CLIS_RAZON_SOCIAL)
                    Case "CLIS_PERSONA_CONTACTO"
                        query = query.OrderBy(Function(x) x.CLIS_PERSONA_CONTACTO)
                    Case "CLIS_FAX"
                        query = query.OrderBy(Function(x) x.CLIS_FAX)
                    Case "CLIS_GIRO"
                        query = query.OrderBy(Function(x) x.CLIS_GIRO)
                    Case "REG_ID"
                        query = query.OrderBy(Function(x) x.REG_ID)
                End Select
            Else
                Select Case col
                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                    Case "CLI_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLI_DESCRIPCION)
                    Case "CLIS_ID"
                        query = query.OrderBy(Function(x) x.CLIS_ID)
                    Case "CLIS_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.CLIS_DESCRIPCION)
                    Case "COM_ID"
                        query = query.OrderByDescending(Function(x) x.COM_ID)
                    Case "COM_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.COM_DESCRIPCION)
                    Case "CLIS_RUT"
                        query = query.OrderByDescending(Function(x) x.CLIS_RUT)
                    Case "CLIS_CALLE"
                        query = query.OrderByDescending(Function(x) x.CLIS_CALLE)
                    Case "CLIS_TELEFONO"
                        query = query.OrderByDescending(Function(x) x.CLIS_TELEFONO)
                    Case "CLIS_TELEFONO2"
                        query = query.OrderByDescending(Function(x) x.CLIS_TELEFONO2)
                    Case "CLIS_RAZON_SOCIAL"
                        query = query.OrderByDescending(Function(x) x.CLIS_RAZON_SOCIAL)
                    Case "CLIS_PERSONA_CONTACTO"
                        query = query.OrderByDescending(Function(x) x.CLIS_PERSONA_CONTACTO)
                    Case "CLIS_FAX"
                        query = query.OrderByDescending(Function(x) x.CLIS_FAX)
                    Case "CLIS_GIRO"
                        query = query.OrderByDescending(Function(x) x.CLIS_GIRO)
                    Case "REG_ID"
                        query = query.OrderByDescending(Function(x) x.REG_ID)
                End Select
            End If

            Return query.ToList
        End Function

        'buscar clinica sede
        Public Shared Function BuscarSede(Optional ByVal vCLI_ID As Int32? = Nothing, _
                                         Optional ByVal vCLIS_ID As Int32? = Nothing, _
Optional ByVal vCLIS_DESCRIPCION As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA_SEDE)
            BuscarSede = DataLayer.DAL.CLINICA_SEDE.BuscarSede(vCLI_ID, vCLIS_ID, vCLIS_DESCRIPCION, vCon, vControlEstado:=vControlEstado)
        End Function
    End Class


End Namespace

