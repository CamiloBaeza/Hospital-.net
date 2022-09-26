Imports System
Imports System.Collections
Imports System.Configuration
Imports DataLayer.DAL
Imports EntityLayer.EL
Imports EntityLayer
Imports Utilidades
Imports System.Web.UI.WebControls
Imports System.Threading
Imports Utilidades.Generico
Imports System.Text
Imports System.Web.Configuration
Namespace BL
    Public Class USUARIO

        Public Shared Function BuscarUsuarioAutoCompletar(Optional ByVal vPREFIX_TEXT As String = Nothing,
                                                          Optional ByVal vCLI_ID As String = Nothing, _
                                                            Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                                          Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.USUARIO)
            BuscarUsuarioAutoCompletar = DataLayer.DAL.USUARIO.BuscarUsuarioAutoCompletar(vPREFIX_TEXT:=vPREFIX_TEXT, vCon:=vCon, vCLI_ID:=vCLI_ID, vSCLI_ID:=vSCLI_ID)
        End Function

        Public Shared Function BuscarUsuarioEspecialistaAutoCompletar(Optional ByVal vPREFIX_TEXT As String = Nothing,
                                                     Optional ByVal vCLI_ID As String = Nothing, _
                                                       Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                                     Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.USUARIO)
            BuscarUsuarioEspecialistaAutoCompletar = DataLayer.DAL.USUARIO.BuscarUsuarioEspecialistaAutoCompletar(vPREFIX_TEXT:=vPREFIX_TEXT, vCon:=vCon, vCLI_ID:=vCLI_ID, vSCLI_ID:=vSCLI_ID)
        End Function





        Public Shared Function Buscar(Optional ByVal vUSU_ID As Int32? = Nothing, _
       Optional ByVal vTIPU_ID As Short? = Nothing, _
       Optional ByVal vCOM_ID As Int32? = Nothing, _
       Optional ByVal vPRO_ID As Short? = Nothing, _
       Optional ByVal vUSU_RUT As String = Nothing, _
       Optional ByVal vUSU_NOMBRE As String = Nothing, _
       Optional ByVal vUSU_APELLIDO_PAT As String = Nothing, _
       Optional ByVal vUSU_APELLIDO_MAT As String = Nothing, _
       Optional ByVal vUSU_NACIMIENTO As DateTime? = Nothing, _
       Optional ByVal vUSU_SEXO As String = Nothing, _
       Optional ByVal vUSU_DIRECCION As String = Nothing, _
       Optional ByVal vUSU_VIGENTE As Boolean? = Nothing, _
       Optional ByVal vUSU_RUTA_IMAGEN As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.USUARIO)
            Buscar = DataLayer.DAL.USUARIO.Buscar(vUSU_ID, vTIPU_ID, vCOM_ID, vPRO_ID, vUSU_RUT, vUSU_NOMBRE, vUSU_APELLIDO_PAT, vUSU_APELLIDO_MAT, vUSU_NACIMIENTO, vUSU_SEXO, vUSU_DIRECCION, vUSU_VIGENTE, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarUsuario(Optional ByVal vUSU_ID As Int32? = Nothing, _
        Optional ByVal vTIPU_ID As Short? = Nothing, _
        Optional ByVal vCOM_ID As Int32? = Nothing, _
        Optional ByVal vPRO_ID As Short? = Nothing, _
        Optional ByVal vUSU_RUT As String = Nothing, _
        Optional ByVal vUSU_NOMBRE As String = Nothing, _
        Optional ByVal vUSU_APELLIDO_PAT As String = Nothing, _
        Optional ByVal vUSU_APELLIDO_MAT As String = Nothing, _
        Optional ByVal vUSU_NACIMIENTO As DateTime? = Nothing, _
        Optional ByVal vUSU_SEXO As String = Nothing, _
        Optional ByVal vUSU_DIRECCION As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarUsuario = DataLayer.DAL.USUARIO.ListarUsuario(vUSU_ID, vTIPU_ID, vCOM_ID, vPRO_ID, vUSU_RUT, vUSU_NOMBRE, vUSU_APELLIDO_PAT, vUSU_APELLIDO_MAT, vUSU_NACIMIENTO, vUSU_SEXO, vUSU_DIRECCION, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarUsuariosPorTipo(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                     Optional ByVal vTIPU_ID As Int32? = Nothing, _
                                                     Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                                     Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                                     Optional ByVal vCLI_ID_SESSION As String = Nothing, _
                                                     Optional ByVal vCon As Conexion = Nothing, _
                                                     Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.USUARIO)
            ListarUsuariosPorTipo = DataLayer.DAL.USUARIO.ListarUsuariosPorTipo(vUSU_ID:=vUSU_ID, vTIPU_ID:=vTIPU_ID, vCLIS_ID:=vCLIS_ID, vSCLI_ID:=vSCLI_ID, vCon:=vCon, vControlEstado:=vControlEstado, vCLI_ID_SESSION:=vCLI_ID_SESSION)
        End Function

        Public Shared Function ListarUsuarioEspecialidad(Optional ByVal vUSU_ID As Int32? = Nothing, _
        Optional ByVal vUSU_NOMBRE As String = Nothing, _
        Optional ByVal vESP_ID As String = Nothing, _
        Optional ByVal vESP_DESCRIPCION As String = Nothing, _
        Optional ByVal vUSU_RUT As String = Nothing, _
        Optional ByVal vUSU_APELLIDO_PAT As String = Nothing, _
        Optional ByVal vUSU_APELLIDO_MAT As String = Nothing, _
        Optional ByVal vCLIS_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            ListarUsuarioEspecialidad = DataLayer.DAL.USUARIO.ListarUsuarioEspecialidad(vUSU_ID:=vUSU_ID, vUSU_NOMBRE:=vUSU_NOMBRE, vESP_ID:=vESP_ID, vESP_DESCRIPCION:=vESP_DESCRIPCION, vUSU_RUT:=vUSU_RUT, vUSU_APELLIDO_PAT:=vUSU_APELLIDO_PAT, vUSU_APELLIDO_MAT:=vUSU_APELLIDO_MAT, vCLIS_ID:=vCLIS_ID, vCon:=vCon, vControlEstado:=vControlEstado)

        End Function

        Public Shared Function ListarUsuarioEspecialista(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                         Optional ByVal vCLIS_ID As Int32? = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            ListarUsuarioEspecialista = DataLayer.DAL.USUARIO.ListarUsuarioEspecialista(vUSU_ID, vCLIS_ID, vCon, vControlEstado:=vControlEstado)

        End Function

        Public Shared Function ListarUsuarioLogin(Optional ByVal vUSU_RUT As String = Nothing, _
                                                  Optional ByVal vUSU_CLAVE As String = Nothing, _
                                                  Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                                  Optional ByVal vCLI_ID As String = Nothing, _
                                                  Optional ByVal vCAMBIO_CLINICA As Boolean = False, _
                                                  Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable

            ListarUsuarioLogin = DataLayer.DAL.USUARIO.ListarUsuarioLogin(vUSU_RUT, vUSU_CLAVE, vCLIS_ID, vCLI_ID, vCAMBIO_CLINICA, vCon, vControlEstado:=vControlEstado)

        End Function

        Public Shared Function ListarClinicasUsuario(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.CLINICA)
            ListarClinicasUsuario = DataLayer.DAL.USUARIO.ListarClinicasUsuario(vUSU_ID:=vUSU_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarUsuarioLoginAdmin(ByVal vUSU_RUT As String, _
                                                ByVal vUSU_CLAVE As String, _
                                                Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                                Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarUsuarioLoginAdmin = DataLayer.DAL.USUARIO.ListarUsuarioLoginAdmin(vUSU_RUT:=vUSU_RUT, vUSU_CLAVE:=vUSU_CLAVE, vCLIS_ID:=vCLIS_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Sub Guardar(ByVal vUSUARIO As EntityLayer.EL.USUARIO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.USUARIO.Guardar(vUSUARIO, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vUSUARIO As EntityLayer.EL.USUARIO, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.USUARIO.Eliminar(vUSUARIO, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vUSU_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As EntityLayer.EL.USUARIO
            Dim vL As List(Of EntityLayer.EL.USUARIO)
            vL = Buscar(vUSU_ID:=vUSU_ID, _
           vCon:=vCon, vControlEstado:=vControlEstado)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function


        Public Shared Function ListarEspecialistaSecretaria(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                            Optional ByVal vCLIS_ID As Int32? = Nothing, _
                Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarEspecialistaSecretaria = DataLayer.DAL.USUARIO.ListarEspecialistaSecretaria(vUSU_ID:=vUSU_ID, vCLIS_ID:=vCLIS_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function



        Public Shared Function sortList_USUARIO(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.USUARIO)) As List(Of EntityLayer.EL.USUARIO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "USU_ID"
                        query = query.OrderBy(Function(x) x.USU_ID)
                    Case "TIPU_ID"
                        query = query.OrderBy(Function(x) x.TIPU_ID)
                    Case "COM_ID"
                        query = query.OrderBy(Function(x) x.COM_ID)
                    Case "PRO_ID"
                        query = query.OrderBy(Function(x) x.PRO_ID)
                    Case "USU_RUT"
                        query = query.OrderBy(Function(x) x.USU_RUT)
                    Case "USU_NOMBRE"
                        query = query.OrderBy(Function(x) x.USU_NOMBRE)
                    Case "USU_APELLIDO_PAT"
                        query = query.OrderBy(Function(x) x.USU_APELLIDO_PAT)
                    Case "USU_APELLIDO_MAT"
                        query = query.OrderBy(Function(x) x.USU_APELLIDO_MAT)
                    Case "USU_NACIMIENTO"
                        query = query.OrderBy(Function(x) x.USU_NACIMIENTO)
                    Case "USU_SEXO"
                        query = query.OrderBy(Function(x) x.USU_SEXO)
                    Case "USU_DIRECCION"
                        query = query.OrderBy(Function(x) x.USU_DIRECCION)
                    Case "USU_TELEFONO"
                        query = query.OrderBy(Function(x) x.USU_TELEFONO)
                    Case "USU_CELULAR"
                        query = query.OrderBy(Function(x) x.USU_CELULAR)
                    Case "USU_MAIL"
                        query = query.OrderBy(Function(x) x.USU_MAIL)
                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                    Case "PRO_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PRO_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "USU_ID"
                        query = query.OrderByDescending(Function(x) x.USU_ID)
                    Case "TIPU_ID"
                        query = query.OrderByDescending(Function(x) x.TIPU_ID)
                    Case "COM_ID"
                        query = query.OrderByDescending(Function(x) x.COM_ID)
                    Case "PRO_ID"
                        query = query.OrderByDescending(Function(x) x.PRO_ID)
                    Case "USU_RUT"
                        query = query.OrderByDescending(Function(x) x.USU_RUT)
                    Case "USU_NOMBRE"
                        query = query.OrderByDescending(Function(x) x.USU_NOMBRE)
                    Case "USU_APELLIDO_PAT"
                        query = query.OrderByDescending(Function(x) x.USU_APELLIDO_PAT)
                    Case "USU_APELLIDO_MAT"
                        query = query.OrderByDescending(Function(x) x.USU_APELLIDO_MAT)
                    Case "USU_NACIMIENTO"
                        query = query.OrderByDescending(Function(x) x.USU_NACIMIENTO)
                    Case "USU_SEXO"
                        query = query.OrderByDescending(Function(x) x.USU_SEXO)
                    Case "USU_DIRECCION"
                        query = query.OrderByDescending(Function(x) x.USU_DIRECCION)
                    Case "USU_TELEFONO"
                        query = query.OrderByDescending(Function(x) x.USU_TELEFONO)
                    Case "USU_CELULAR"
                        query = query.OrderByDescending(Function(x) x.USU_CELULAR)
                    Case "USU_MAIL"
                        query = query.OrderByDescending(Function(x) x.USU_MAIL)
                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                    Case "PRO_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PRO_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function


        Public Shared Function enviar_correo_cambio_clave(ByVal vRUT_COMPLETO As String) As String
            Dim vres As String = ""
            Try
                Dim vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/cabecera-correo.jpg")
                Dim vCuentaOrigen = WebConfigurationManager.AppSettings.Get("mail_cuenta_origen").ToString
                Dim vServidor = WebConfigurationManager.AppSettings.Get("mail_servidor").ToString
                Dim vNombrecuenta = WebConfigurationManager.AppSettings.Get("mail_nombre_cuenta").ToString
                Dim vMail_SMTPPassword = WebConfigurationManager.AppSettings.Get("mail_smtp_password").ToString
                Dim vMail_Port = WebConfigurationManager.AppSettings.Get("mail_port").ToString
                Dim vMail_SSL = WebConfigurationManager.AppSettings.Get("mail_ssl").ToString
                If String.IsNullOrEmpty(vRUT_COMPLETO) Then
                    Throw New Exception("Debe ingresar un rut válido")
                Else
                    '----------Validar Existe Registro-------------   
                    Dim usuario As List(Of EntityLayer.EL.USUARIO)
                    usuario = BL.USUARIO.Buscar(vUSU_RUT:=vRUT_COMPLETO)
                    If usuario Is Nothing OrElse usuario.Count = 0 Then
                        Throw New Exception("El usuario no se encuentra registrado")
                        '----------Validar que tenga EMAIL-------------
                    ElseIf usuario.Item(0).USU_MAIL Is Nothing Then
                        Throw New Exception("El usuario no tiene mail registrado")
                    Else
                        '----------Generar Nueva Contraseña------------
                        Dim nuevaContraseña, contraseñaEncriptada As String
                        'nuevaContraseña = clsUtilidad.generate_random_string()
                        nuevaContraseña = If(String.IsNullOrEmpty(usuario.Item(0).USU_CLAVE), vRUT_COMPLETO.Replace("-", ""), Encriptacion.DecryptText(usuario.Item(0).USU_CLAVE, Encriptacion.Key))
                        '----------Encriptar Nueva Contraseña----------
                        contraseñaEncriptada = ""
                        Try
                            contraseñaEncriptada = Encriptacion.EncryptText(nuevaContraseña, Encriptacion.Key)
                        Catch ex As Exception
                            Throw New Exception("Ocurrió un problema al tratar de encriptar la contraseña")
                        End Try
                        '----------Guardar Nueva Contraseña------------
                        usuario.Item(0).USU_CLAVE = contraseñaEncriptada
                        BL.USUARIO.Guardar(usuario.Item(0))
                        '----------Se obtiene el Template--------------
                        Dim texto, asunto, mail As String 'para probar los hilos
                        Dim variablesAsunto, variablesTexto As List(Of ListItem)
                        Dim item As ListItem
                        variablesAsunto = Nothing
                        asunto = getTextoTemplate("olvidoClaveAsunto", variablesAsunto)
                        variablesTexto = New List(Of ListItem)
                        item = New ListItem("nombreUsuario", usuario.Item(0).USU_NOMBRE_COMPLETO)
                        variablesTexto.Add(item)
                        item = New ListItem("nuevaClave", nuevaContraseña)
                        variablesTexto.Add(item)
                        'texto = getTextoTemplate("olvidoClave", variablesTexto)
                        texto = getTextoTemplate("olvidoClaveHTML", variablesTexto)
                        mail = usuario.Item(0).USU_MAIL
                        vres = mail
                        Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:="", vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                        t.Start()
                    End If
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return vres
        End Function


    End Class


End Namespace

