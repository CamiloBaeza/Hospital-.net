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
Imports System.IO


Namespace BL
    Public Class RESERVA_LOG_ESTADO


        Public Shared Function Buscar(Optional ByVal vLOGE_ID As Int32? = Nothing, _
           Optional ByVal vRESE_ID As Int32? = Nothing, _
           Optional ByVal vERES_ID As Int32? = Nothing, _
           Optional ByVal vUSU_ID As Int32? = Nothing, _
           Optional ByVal vLOGE_COMENTARIO As String = Nothing, _
           Optional ByVal vLOGE_FECHA_REGISTRO As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA_LOG_ESTADO)
            Try
                Buscar = DataLayer.DAL.RESERVA_LOG_ESTADO.Buscar(vLOGE_ID:=vLOGE_ID, vRESE_ID:=vRESE_ID, vERES_ID:=vERES_ID, vUSU_ID:=vUSU_ID, vLOGE_COMENTARIO:=vLOGE_COMENTARIO, vLOGE_FECHA_REGISTRO:=vLOGE_FECHA_REGISTRO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vRESERVA_LOG_ESTADO As EntityLayer.EL.RESERVA_LOG_ESTADO, Optional ByVal vEnviar As Boolean = True, Optional ByVal vERES_ANTERIOR As Int32? = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                Dim vEstado As EL.RESERVA_LOG_ESTADO
                If vERES_ANTERIOR.HasValue = False Then
                    vEstado = BL.RESERVA_LOG_ESTADO.BuscarEstadoActualReserva(vRESERVA_LOG_ESTADO.RESE_ID, vCon:=vCon)
                    vERES_ANTERIOR = If(vEstado IsNot Nothing, vEstado.ERES_ID, Nothing)
                End If
                Try
                    'ENVIO CORREO SOLO SI ESTADO ACTUAL HA CAMBIADO o NO TIENE ESTADO ANTERIOR
                    If vRESERVA_LOG_ESTADO.ERES_ID <> vERES_ANTERIOR OrElse vERES_ANTERIOR.HasValue = False Then
                        DataLayer.DAL.RESERVA_LOG_ESTADO.Guardar(vRESERVA_LOG_ESTADO:=vRESERVA_LOG_ESTADO, vCon:=vCon)
                        If (IsNothing(vEnviar)) Or vEnviar = True And vRESERVA_LOG_ESTADO.ERES_ID <> Generico.ESTADO_RESERVA.en_proceso Then
                            EnviarCorreo(vRESERVA_LOG_ESTADO:=vRESERVA_LOG_ESTADO, vCon:=vCon)
                        End If
                    End If
                Catch ex As Exception

                End Try

            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub EnviarCorreo(ByVal vRESERVA_LOG_ESTADO As EntityLayer.EL.RESERVA_LOG_ESTADO,
                                       Optional ByVal vCon As Conexion = Nothing,
                                       Optional ByVal vEnviar As Boolean = True,
                                       Optional ByVal vEXA_ID_SELECCIONADOS As String = Nothing,
                                       Optional ByVal vRESE_ID As String = Nothing,
                                       Optional ByVal vPath_instructivo As String = Nothing,
                                       Optional ByVal reportCheckList As MemoryStream = Nothing,
                                       Optional ByVal XML_PREPARATIVO As String = Nothing,
                                       Optional ByVal preparativos As Boolean = Nothing,
                                       Optional ByVal vUSU_ID_SESSION As Int32? = Nothing,
                                       Optional ByVal vRESERVA As EL.RESERVA = Nothing)
            If vEnviar Then
                If vRESERVA_LOG_ESTADO IsNot Nothing AndAlso vRESERVA_LOG_ESTADO.RESE_ID.HasValue Then


                    Dim vDatosSendMail As EL.DATOS_SENDMAIL = BL.DATOS_SENDMAIL.Buscar(vRESE_ID:=vRESERVA_LOG_ESTADO.RESE_ID, vCon:=vCon)(0)

                    'Se comprueba si la clinica tiene cabecera propia sino se usa la de por defecto

                    Dim vAbsoluteUri As String = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/cabecera-correo-pidehora-" & vDatosSendMail.CLI_ID & ".jpg")

                    If Not File.Exists(vAbsoluteUri) Then
                        vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/cabecera-correo-pidehora.jpg")
                    End If

                    Dim vCuentaOrigen = WebConfigurationManager.AppSettings.Get("mail_cuenta_origen").ToString
                    Dim vServidor = WebConfigurationManager.AppSettings.Get("mail_servidor").ToString
                    Dim vNombrecuenta = WebConfigurationManager.AppSettings.Get("mail_nombre_cuenta").ToString
                    'Dim vlistaCorreoUsuariosSecretaria As List(Of EL.USUARIO_SERVICIO_CLINICO) = If(vDatosSendMail IsNot Nothing, BL.USUARIO_SERVICIO_CLINICO.Buscar(vSCLI_ID:=vDatosSendMail.SCLI_ID, vTIPU_ID:=Generico.TIPO_USUARIO.SECRETARIA), Nothing)
                    'Dim vlistaCorreoUsuariosSecretaria As New List(Of EL.USUARIO_SERVICIO_CLINICO)

                    Dim vEnvioMailPaciente As String = WebConfigurationManager.AppSettings("envio_mail_pacientes").ToString
                    Dim vMailDefecto As String = WebConfigurationManager.AppSettings("mail_cuenta_origen").ToString
                    Dim vMail_SMTPPassword = WebConfigurationManager.AppSettings.Get("mail_smtp_password").ToString
                    Dim vMail_Port = WebConfigurationManager.AppSettings.Get("mail_port").ToString
                    Dim vMail_SSL = WebConfigurationManager.AppSettings.Get("mail_ssl").ToString
                    Dim texto, asunto, mail, copia As String
                    Dim variablesAsunto, variablesTexto As List(Of ListItem)
                    Dim item As ListItem
                    variablesAsunto = New List(Of ListItem)

                    Select Case vRESERVA_LOG_ESTADO.ERES_ID
                        Case Generico.ESTADO_RESERVA.anulado
                            '----------Se obtiene el Template--------------
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesAsunto.Add(item)
                            asunto = getTextoTemplate("anuladoAsunto", variablesAsunto)
                            variablesTexto = New List(Of ListItem)
                            item = New ListItem("nombrePaciente", vDatosSendMail.PAC_NOMBRE)
                            variablesTexto.Add(item)
                            item = New ListItem("fecha", dateToShortString(vDatosSendMail.RESE_FECHA_RESERVA))
                            variablesTexto.Add(item)
                            If vDatosSendMail IsNot Nothing Then
                                item = New ListItem("especialista", vDatosSendMail.PRES_DESCRIPCION)
                                variablesTexto.Add(item)
                                'Se comprueba si es examen o consulta
                                If Not vDatosSendMail.TPRE_DEFAULT Then
                                    item = New ListItem("tituloEspecialista", "Servicio")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", "")
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("tituloEspecialista", "con el Profesional")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", ", <strong>" & vDatosSendMail.ESP_DESCRIPCION & "</strong>")
                                    variablesTexto.Add(item)
                                End If
                            Else
                                item = New ListItem("tituloEspecialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialidad", "")
                                variablesTexto.Add(item)
                            End If
                            If vDatosSendMail IsNot Nothing Then
                                item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                                variablesTexto.Add(item)
                            Else
                                item = New ListItem("clinica", "")
                                variablesTexto.Add(item)
                            End If
                            'texto = getTextoTemplate("anulado", variablesTexto)
                            texto = getTextoTemplate("anuladoHTML", variablesTexto)
                            '----------Recuperamos el mail del paciente----
                            copia = ""
                            If vDatosSendMail IsNot Nothing Then
                                If IsNothing(vEnvioMailPaciente) Or vEnvioMailPaciente = "NO" Then
                                    mail = vMailDefecto
                                Else
                                    mail = vDatosSendMail.PAC_MAIL
                                End If
                                If vDatosSendMail IsNot Nothing And vDatosSendMail.TIPU_ID <> Generico.TIPO_USUARIO.ESPECIALISTA Then
                                    'copia = vDatosSendMail.USU_MAIL
                                    If Not String.IsNullOrEmpty(vDatosSendMail.LISTA_SECRETARIA) Then
                                        If Not vDatosSendMail.LISTA_SECRETARIA.Contains(copia) Then
                                            copia = vDatosSendMail.LISTA_SECRETARIA & ";" + vDatosSendMail.USU_MAIL
                                        End If
                                    Else
                                        copia = vDatosSendMail.USU_MAIL
                                    End If
                                Else
                                    copia = vDatosSendMail.LISTA_SECRETARIA
                                End If
                                'For Each vcorreoUsuario As EL.USUARIO_SERVICIO_CLINICO In vlistaCorreoUsuariosSecretaria
                                '    If Not String.IsNullOrEmpty(copia) Then
                                '        If Not copia.Contains(vcorreoUsuario.USU_MAIL) Then
                                '            copia = copia & ";" + vcorreoUsuario.USU_MAIL
                                '        End If
                                '    Else
                                '        copia = vcorreoUsuario.USU_MAIL
                                '    End If
                                'Next


                                '----------Se envia el mail--------------------
                                Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:=copia, vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                                t.Start()
                            End If
                        Case Generico.ESTADO_RESERVA.confirmado
                            '----------Se obtiene el Template--------------
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesAsunto.Add(item)
                            asunto = getTextoTemplate("confirmadoAsunto", variablesAsunto)
                            variablesTexto = New List(Of ListItem)
                            item = New ListItem("nombrePaciente", vDatosSendMail.PAC_NOMBRE)
                            variablesTexto.Add(item)
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesTexto.Add(item)
                            item = New ListItem("fecha", dateToShortString(vDatosSendMail.RESE_FECHA_RESERVA))
                            variablesTexto.Add(item)
                            item = New ListItem("hora", timeToShortString(vDatosSendMail.RESE_HORA_INI))
                            variablesTexto.Add(item)
                            If vDatosSendMail IsNot Nothing Then
                                'Se comprueba si es examen o consulta
                                If Not vDatosSendMail.TPRE_DEFAULT Then
                                    item = New ListItem("tituloEspecialista", "Servicio")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Examen")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_EXAMENES)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("tituloEspecialista", "Profesional")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Especialidad")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_ESPECIALIDADES)
                                    variablesTexto.Add(item)
                                End If
                                item = New ListItem("especialista", vDatosSendMail.PRES_DESCRIPCION)
                                variablesTexto.Add(item)

                                item = New ListItem("sede", vDatosSendMail.CLIS_DESCRIPCION)
                                variablesTexto.Add(item)

                                If vDatosSendMail IsNot Nothing Then
                                    item = New ListItem("direccion", vDatosSendMail.CLIS_CALLE)
                                    variablesTexto.Add(item)
                                    item = New ListItem("comuna", vDatosSendMail.COM_DESCRIPCION)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("direccion", "")
                                    variablesTexto.Add(item)
                                End If
                            Else
                                item = New ListItem("sede", "")
                                variablesTexto.Add(item)
                                item = New ListItem("direccion", "")
                                variablesTexto.Add(item)
                                item = New ListItem("comuna", "")
                                variablesTexto.Add(item)
                                item = New ListItem("tituloEspecialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("tituloEspecialidad", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialidad", "")
                                variablesTexto.Add(item)
                            End If
                            item = New ListItem("ejecutivo", vDatosSendMail.NOMBRE_EJECUTIVO)
                            variablesTexto.Add(item)
                            'texto = getTextoTemplate("confirmado", variablesTexto)
                            texto = getTextoTemplate("confirmadoHTML", variablesTexto)
                            '----------Recuperamos el mail del paciente----
                            If vDatosSendMail.PAC_MAIL IsNot Nothing Then
                                If IsNothing(vEnvioMailPaciente) Or vEnvioMailPaciente = "NO" Then
                                    mail = vMailDefecto
                                Else
                                    mail = vDatosSendMail.PAC_MAIL
                                End If

                                '----------Se envia el mail--------------------
                                Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:="", vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                                t.Start()
                            End If
                        Case Generico.ESTADO_RESERVA.notificado
                            '----------Se obtiene el Template--------------
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesAsunto.Add(item)
                            asunto = getTextoTemplate("notificadoAsunto", variablesAsunto)
                            variablesTexto = New List(Of ListItem)
                            item = New ListItem("nombrePaciente", vDatosSendMail.PAC_NOMBRE)
                            variablesTexto.Add(item)
                            item = New ListItem("fecha", dateToShortString(vDatosSendMail.RESE_FECHA_RESERVA))
                            variablesTexto.Add(item)
                            If vDatosSendMail.PRES_ID IsNot Nothing Then
                                'Se comprueba si es examen o consulta
                                If Not vDatosSendMail.TPRE_DEFAULT Then
                                    item = New ListItem("tituloEspecialista", "Servicio")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", "")
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("tituloEspecialista", "con el Profesional")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", ", <strong>" & vDatosSendMail.ESP_DESCRIPCION & "</strong>")
                                    variablesTexto.Add(item)
                                End If
                                item = New ListItem("especialista", vDatosSendMail.PRES_DESCRIPCION)
                                variablesTexto.Add(item)
                            Else
                                item = New ListItem("tituloEspecialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialidad", "")
                                variablesTexto.Add(item)
                            End If
                            item = New ListItem("hora", timeToShortString(vDatosSendMail.RESE_HORA_INI))
                            variablesTexto.Add(item)
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesTexto.Add(item)

                            'CONSTRUIR ENLACE DE CONFIRMACION
                            Dim venlace As String = If(WebConfigurationManager.AppSettings.Get("productivo_csa") Is Nothing OrElse WebConfigurationManager.AppSettings.Get("productivo_csa").ToUpper() = "NO", Generico.GetBaseUrl, "http://agenda.sanatorioaleman.cl:8085/clinicloud/")
                            venlace = venlace & "FrmConfirmarReserva.aspx?msg="
                            Dim vl As New List(Of Object)
                            vl.Add(1) 'USU_ID
                            vl.Add(vRESERVA_LOG_ESTADO.RESE_ID) 'RESE_ID
                            vl.Add(vDatosSendMail.PAC_ID) 'PAC_ID
                            vl.Add(Generico.ESTADO_RESERVA.confirmado) 'ERES_ID
                            vl.Add(CType(vDatosSendMail.CLI_ID, Int32?)) 'CLI_ID

                            Dim venlace_si As String = venlace & System.Web.HttpContext.Current.Server.UrlEncode(Encriptacion.EncryptText(Newtonsoft.Json.JsonConvert.SerializeObject(vl).ToString.Trim, Encriptacion.Key))

                            Dim vl2 As New List(Of Object)
                            vl2.Add(1) 'USU_ID
                            vl2.Add(vRESERVA_LOG_ESTADO.RESE_ID) 'RESE_ID
                            vl2.Add(vDatosSendMail.PAC_ID) 'PAC_ID
                            vl2.Add(Generico.ESTADO_RESERVA.anulado) 'ERES_ID
                            vl2.Add(CType(vDatosSendMail.CLI_ID, Int32?)) 'CLI_ID
                            Dim venlace_no As String = venlace & System.Web.HttpContext.Current.Server.UrlEncode(Encriptacion.EncryptText(Newtonsoft.Json.JsonConvert.SerializeObject(vl2).ToString.Trim, Encriptacion.Key))

                            If WebConfigurationManager.AppSettings.Get("productivo_csa") IsNot Nothing AndAlso WebConfigurationManager.AppSettings.Get("productivo_csa").ToUpper = "SI" Then
                                item = New ListItem("enlace_si", "agradeceremos nos env&iacute;e un <strong>SÍ</strong>")
                                variablesTexto.Add(item)
                                item = New ListItem("enlace_no", "o en el caso contrario un <strong>NO</strong>")
                                variablesTexto.Add(item)
                            Else
                                item = New ListItem("enlace_si", "presione <a href='" & venlace_si & "'>SÍ</a>")
                                variablesTexto.Add(item)

                                item = New ListItem("enlace_no", ", en caso contrario, presione <a href='" & venlace_no & "'>NO</a>")
                                variablesTexto.Add(item)
                            End If

                            'texto = getTextoTemplate("notificado", variablesTexto)
                            texto = getTextoTemplate("notificadoHTML", variablesTexto)
                            '----------Recuperamos el mail del paciente----
                            If vDatosSendMail.PAC_ID IsNot Nothing Then
                                If IsNothing(vEnvioMailPaciente) Or vEnvioMailPaciente = "NO" Then
                                    mail = vMailDefecto
                                Else
                                    mail = vDatosSendMail.PAC_MAIL
                                End If

                                '----------Se envia el mail--------------------
                                Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:="", vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                                t.Start()
                            End If

                            'Case clsUtilidad.ESTADO_RESERVA.por_re_agendar_paciente

                        Case Generico.ESTADO_RESERVA.reservado_web
                            '----------Se obtiene el Template--------------
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesAsunto.Add(item)
                            asunto = getTextoTemplate("reservadoAsunto", variablesAsunto)
                            variablesTexto = New List(Of ListItem)
                            item = New ListItem("paciente", vDatosSendMail.PAC_NOMBRE)
                            variablesTexto.Add(item)
                            item = New ListItem("fecha", dateToShortString(vDatosSendMail.RESE_FECHA_RESERVA))
                            variablesTexto.Add(item)
                            If vDatosSendMail.PRES_ID IsNot Nothing Then
                                'Se comprueba si es examen o consulta
                                If Not vDatosSendMail.TPRE_DEFAULT Then
                                    item = New ListItem("tituloEspecialista", "Servicio")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Examen")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_EXAMENES)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("tituloEspecialista", "Profesional")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Especialidad")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_ESPECIALIDADES)
                                    variablesTexto.Add(item)
                                End If
                                item = New ListItem("especialista", vDatosSendMail.PRES_DESCRIPCION)
                                variablesTexto.Add(item)
                                item = New ListItem("especialidad", vDatosSendMail.ESP_DESCRIPCION)
                                variablesTexto.Add(item)
                                item = New ListItem("sede", vDatosSendMail.CLIS_DESCRIPCION)
                                variablesTexto.Add(item)

                                If vDatosSendMail.CLIS_ID IsNot Nothing Then
                                    item = New ListItem("direccion", vDatosSendMail.CLIS_CALLE)
                                    variablesTexto.Add(item)
                                    item = New ListItem("comuna", vDatosSendMail.COM_DESCRIPCION)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("direccion", "")
                                    variablesTexto.Add(item)
                                    item = New ListItem("comuna", "")
                                    variablesTexto.Add(item)
                                End If
                            Else
                                item = New ListItem("tituloEspecialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("tituloEspecialidad", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialidad", "")
                                variablesTexto.Add(item)
                                item = New ListItem("sede", "")
                                variablesTexto.Add(item)
                                item = New ListItem("direccion", "")
                                variablesTexto.Add(item)
                                item = New ListItem("comuna", "")
                                variablesTexto.Add(item)
                            End If
                            If vDatosSendMail.USU_ID IsNot Nothing Then
                                item = New ListItem("ejecutivo", vDatosSendMail.NOMBRE_EJECUTIVO)
                                variablesTexto.Add(item)
                            Else
                                item = New ListItem("ejecutivo", vDatosSendMail.CLI_DESCRIPCION)
                                variablesTexto.Add(item)
                            End If
                            If vDatosSendMail.CLIS_TELEFONO IsNot Nothing Then
                                item = New ListItem("telefono", vDatosSendMail.CLIS_TELEFONO)
                                variablesTexto.Add(item)
                            End If
                            item = New ListItem("hora", timeToShortString(vDatosSendMail.RESE_HORA_INI))
                            variablesTexto.Add(item)
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesTexto.Add(item)
                            texto = getTextoTemplate("reservadoPideHoraHTML", variablesTexto)
                            '----------Recuperamos el mail del paciente----
                            If vDatosSendMail.PAC_ID IsNot Nothing Then
                                If IsNothing(vEnvioMailPaciente) Or vEnvioMailPaciente = "NO" Then
                                    mail = vMailDefecto
                                Else
                                    mail = vDatosSendMail.PAC_MAIL
                                End If

                                '----------Se envia el mail--------------------
                                Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:="", vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                                t.Start()
                            End If
                        Case Generico.ESTADO_RESERVA.reservado_interno

                            Dim listInstructivo As List(Of EL.INSTRUCTIVO) = BL.INSTRUCTIVO.BuscarByExamenes_selected(vEXAMENES_SELECTED:=vEXA_ID_SELECCIONADOS)

                            'Guardo Nombre archivo y la ruta 
                            Dim listItem As New ListItemCollection()
                            If listInstructivo IsNot Nothing Then

                                For x = 0 To listInstructivo.Count - 1
                                    listItem.Add(New ListItem(listInstructivo(x).INST_NOMBRE_ARCHIVO, vPath_instructivo & listInstructivo(x).INST_RUT_ARCHIVO))
                                Next
                            End If

                            'Lista De memoryStream en conjunto con el nombre de los pdf
                            Dim listaItemMemoryStream As New Dictionary(Of String, MemoryStream)

                            '----------Se obtiene el Template--------------
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesAsunto.Add(item)
                            asunto = getTextoTemplate("reservadoAsunto", variablesAsunto)
                            variablesTexto = New List(Of ListItem)
                            item = New ListItem("paciente", vDatosSendMail.PAC_NOMBRE)
                            variablesTexto.Add(item)
                            item = New ListItem("fecha", dateToShortString(vDatosSendMail.RESE_FECHA_RESERVA))
                            variablesTexto.Add(item)
                            If vDatosSendMail IsNot Nothing Then
                                'Se comprueba si es examen o consulta
                                If Not vDatosSendMail.TPRE_DEFAULT Then
                                    item = New ListItem("tituloEspecialista", "Servicio")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Examen")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_EXAMENES)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("tituloEspecialista", "Profesional")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Especialidad")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_ESPECIALIDADES)
                                    variablesTexto.Add(item)
                                End If
                                item = New ListItem("especialista", vDatosSendMail.PRES_DESCRIPCION)
                                variablesTexto.Add(item)
                                item = New ListItem("sede", vDatosSendMail.CLIS_DESCRIPCION)
                                variablesTexto.Add(item)

                                If vDatosSendMail.CLIS_ID IsNot Nothing Then
                                    item = New ListItem("direccion", vDatosSendMail.CLIS_CALLE)
                                    variablesTexto.Add(item)
                                    item = New ListItem("comuna", vDatosSendMail.COM_DESCRIPCION)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("direccion", "")
                                    variablesTexto.Add(item)
                                    item = New ListItem("comuna", "")
                                    variablesTexto.Add(item)
                                End If
                            Else
                                item = New ListItem("tituloEspecialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("tituloEspecialidad", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialidad", "")
                                variablesTexto.Add(item)
                                item = New ListItem("sede", "")
                                variablesTexto.Add(item)
                                item = New ListItem("direccion", "")
                                variablesTexto.Add(item)
                                item = New ListItem("comuna", "")
                                variablesTexto.Add(item)
                            End If
                            item = New ListItem("ejecutivo", vDatosSendMail.NOMBRE_EJECUTIVO)
                            variablesTexto.Add(item)
                            item = New ListItem("hora", timeToShortString(vDatosSendMail.RESE_HORA_INI))
                            variablesTexto.Add(item)
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesTexto.Add(item)
                            item = New ListItem("logo", vAbsoluteUri)
                            variablesTexto.Add(item)
                            If vDatosSendMail.CLIS_TELEFONO IsNot Nothing Then
                                item = New ListItem("telefono", vDatosSendMail.CLIS_TELEFONO)
                                variablesTexto.Add(item)
                            End If
                            'texto = getTextoTemplate("reservado", variablesTexto)
                            texto = getTextoTemplate("reservadoHTML", variablesTexto)
                            '----------Recuperamos el mail del paciente----
                            If vDatosSendMail IsNot Nothing Then
                                If IsNothing(vEnvioMailPaciente) Or vEnvioMailPaciente = "NO" Then
                                    mail = vMailDefecto
                                Else
                                    mail = vDatosSendMail.PAC_MAIL
                                End If

                                Dim url As String
                                url = GetBaseUrl() & "GestionClinica/AdministracionAgenda/Informes/InformeCheckList.aspx?EXA_ID_SELECCIONADOS=" &
                                 vEXA_ID_SELECCIONADOS & "&RESE_ID=" & vRESE_ID & "&USU_ID_SESSION=" & vUSU_ID_SESSION &
                                 "&PAC_ID=" & vRESERVA.PAC_ID & "&FECHA_RESERVA=" & vRESERVA.RESE_FECHA_RESERVA & "&CLI_ID=" & vRESERVA.CLI_ID
                                Dim vPDF As Byte() = GetFileFromUrl(url)
                                Dim ms As New MemoryStream(vPDF)

                                If preparativos Then
                                    listaItemMemoryStream.Add("CheckList.pdf", ms)
                                End If

                                '----------Se envia el mail--------------------
                                Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto,
                                                                        vbody:=texto,
                                                                        vcuentaDestino:=mail,
                                                                        vcuentaCopia:="",
                                                                        vNombrecuenta:=vNombrecuenta,
                                                                        vcuentaOrigen:=vCuentaOrigen,
                                                                        vSMTPServidor:=vServidor,
                                                                        vHtml:=True,
                                                                        vAbsoluteUri:=vAbsoluteUri,
                                                                        vMAIL_SMTPPASSWORD:=vMail_SMTPPassword,
                                                                        vMAIL_PORT:=vMail_Port,
                                                                        vMAIL_SSL:=vMail_SSL,
                                                                        listaInstructivos:=listItem,
                                                                        listaMemoryStream:=listaItemMemoryStream, vMimeType:="application/pdf"
                                                                      ))
                                t.Start()
                            End If

                        Case Generico.ESTADO_RESERVA.re_agendado
                            '----------Se obtiene el Template--------------
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesAsunto.Add(item)
                            asunto = getTextoTemplate("reAgendadoAsunto", variablesAsunto)
                            variablesTexto = New List(Of ListItem)
                            item = New ListItem("nombrePaciente", vDatosSendMail.PAC_NOMBRE)
                            variablesTexto.Add(item)
                            item = New ListItem("fecha", dateToShortString(vDatosSendMail.RESE_FECHA_RESERVA))
                            variablesTexto.Add(item)
                            If vDatosSendMail.PRES_ID IsNot Nothing Then
                                'Se comprueba si es examen o consulta
                                If Not vDatosSendMail.TPRE_DEFAULT Then
                                    item = New ListItem("tituloEspecialista", "Servicio")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Examen")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_EXAMENES)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("tituloEspecialista", "Profesional")
                                    variablesTexto.Add(item)
                                    item = New ListItem("tituloEspecialidad", "Especialidad")
                                    variablesTexto.Add(item)
                                    item = New ListItem("especialidad", vDatosSendMail.DESC_ESPECIALIDADES)
                                    variablesTexto.Add(item)
                                End If
                                item = New ListItem("especialista", vDatosSendMail.PRES_DESCRIPCION)
                                variablesTexto.Add(item)
                                item = New ListItem("sede", vDatosSendMail.CLIS_DESCRIPCION)
                                variablesTexto.Add(item)

                                If vDatosSendMail.CLIS_ID IsNot Nothing Then
                                    item = New ListItem("direccion", vDatosSendMail.CLIS_CALLE)
                                    variablesTexto.Add(item)
                                    item = New ListItem("comuna", vDatosSendMail.COM_DESCRIPCION)
                                    variablesTexto.Add(item)
                                Else
                                    item = New ListItem("direccion", "")
                                    variablesTexto.Add(item)
                                    item = New ListItem("comuna", "")
                                    variablesTexto.Add(item)
                                End If
                            Else
                                item = New ListItem("tituloEspecialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("tituloEspecialidad", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialista", "")
                                variablesTexto.Add(item)
                                item = New ListItem("especialidad", "")
                                variablesTexto.Add(item)
                                item = New ListItem("sede", "")
                                variablesTexto.Add(item)
                                item = New ListItem("direccion", "")
                                variablesTexto.Add(item)
                                item = New ListItem("comuna", "")
                                variablesTexto.Add(item)
                            End If
                            item = New ListItem("ejecutivo", vDatosSendMail.NOMBRE_EJECUTIVO)
                            variablesTexto.Add(item)
                            item = New ListItem("hora", timeToShortString(vDatosSendMail.RESE_HORA_INI))
                            variablesTexto.Add(item)
                            item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                            variablesTexto.Add(item)
                            If vDatosSendMail.CLIS_TELEFONO IsNot Nothing Then
                                item = New ListItem("telefono", vDatosSendMail.CLIS_TELEFONO)
                                variablesTexto.Add(item)
                            End If
                            'texto = getTextoTemplate("reAgendado", variablesTexto)
                            texto = getTextoTemplate("reAgendadoHTML", variablesTexto)
                            '----------Recuperamos el mail del paciente----
                            If vDatosSendMail.PAC_ID IsNot Nothing Then
                                If IsNothing(vEnvioMailPaciente) Or vEnvioMailPaciente = "NO" Then
                                    mail = vMailDefecto
                                Else
                                    mail = vDatosSendMail.PAC_MAIL
                                End If
                                '----------Se envia el mail--------------------
                                Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:="", vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                                t.Start()
                            End If
                    End Select
                End If
            End If


        End Sub

        ''' <summary>
        ''' Envia un email notificando la eliminación del pago de una reserva 
        ''' </summary>
        ''' <param name="vRESE_ID">ID de la Reserva</param>
        ''' <param name="vCon">Cadena de conexión</param>
        ''' <remarks></remarks>
        Public Shared Sub EnviarCorreoEliminaReserva(ByVal vRESE_ID As Int32?, Optional ByVal vCon As Conexion = Nothing)
            Try
                If vRESE_ID.HasValue Then

                    Dim vDatosSendMail As EL.DATOS_SENDMAIL = BL.DATOS_SENDMAIL.BuscarDatosEliminacionPago(vRESE_ID:=vRESE_ID, vCon:=vCon)(0)
                    Dim vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-" & vDatosSendMail.CLI_ID & ".png")
                    If Not File.Exists(vAbsoluteUri) Then
                        vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-clinicloud.png")
                    End If

                    Dim mail As String = ""
                    Dim copia As String = ""
                    Dim vCuentaOrigen = WebConfigurationManager.AppSettings.Get("mail_cuenta_origen").ToString
                    Dim vServidor = WebConfigurationManager.AppSettings.Get("mail_servidor").ToString
                    Dim vNombrecuenta = WebConfigurationManager.AppSettings.Get("mail_nombre_cuenta").ToString
                    vNombrecuenta = "CliniCloud"
                    Dim vMail_SMTPPassword = WebConfigurationManager.AppSettings.Get("mail_smtp_password").ToString
                    Dim vMail_Port = WebConfigurationManager.AppSettings.Get("mail_port").ToString
                    Dim vMail_SSL = WebConfigurationManager.AppSettings.Get("mail_ssl").ToString

                    Dim asunto, texto As String
                    Dim variablesAsunto, variablesTexto As List(Of ListItem)
                    variablesAsunto = New List(Of ListItem)

                    asunto = "Eliminación de pago"
                    variablesTexto = New List(Of ListItem)
                    Dim strB As StringBuilder = New StringBuilder()
                    Dim item As ListItem

                    'SE AGREGAN LAS VARIABLES DE TEXTO'
                    item = New ListItem("pres_descripcion", vDatosSendMail.PRES_DESCRIPCION)
                    variablesTexto.Add(item)

                    item = New ListItem("servicio_clinico", vDatosSendMail.SCLI_DESCRIPCION)
                    variablesTexto.Add(item)

                    item = New ListItem("centro", vDatosSendMail.CLIS_DESCRIPCION)
                    variablesTexto.Add(item)

                    item = New ListItem("usuario_eliminacion", vDatosSendMail.USU_NOMBRE)
                    variablesTexto.Add(item)

                    item = New ListItem("fecha", dateToShortString(vDatosSendMail.PAAT_FECHA_ELIMINACION))
                    variablesTexto.Add(item)

                    item = New ListItem("hora", timeToShortString(vDatosSendMail.PAAT_FECHA_ELIMINACION.Value.TimeOfDay))
                    variablesTexto.Add(item)

                    texto = getTextoTemplate("eliminacionPago", variablesTexto)

                    If vDatosSendMail.LISTA_SUPERVISORA IsNot Nothing Then
                        mail = vDatosSendMail.LISTA_SUPERVISORA
                        'mail = "fdo.iturriaga@hotmail.com"

                        If String.IsNullOrEmpty(mail) = False Then

                            '----------Se envia el mail--------------------
                            If String.IsNullOrEmpty(mail) = False Then
                                Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto,
                                                                        vbody:=texto,
                                                                        vFileAttachments:="",
                                                                        vcuentaDestino:=mail,
                                                                        vcuentaCopia:=copia,
                                                                        vNombrecuenta:=vNombrecuenta,
                                                                        vcuentaOrigen:=vCuentaOrigen,
                                                                        vSMTPServidor:=vServidor,
                                                                        vHtml:=True,
                                                                        vAbsoluteUri:=vAbsoluteUri,
                                                                        vMAIL_SMTPPASSWORD:=vMail_SMTPPassword,
                                                                        vMAIL_PORT:=vMail_Port,
                                                                        vMAIL_SSL:=vMail_SSL))
                                t.Start()
                            End If
                        End If

                    End If


                End If
            Catch ex As Exception

            End Try

        End Sub


        Public Shared Sub EnviarCorreo(ByVal vPRES_ID As Int32?, ByVal vUSU_ID As Int32?, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vlist As List(Of EL.RESERVA) = Nothing)
            Try
                If vPRES_ID.HasValue AndAlso vlist IsNot Nothing Then
                    'Dim vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-sanatorio-sinfondo.png")

                    'Dim vPRESTACION As EL.PRESTACION = If(vPRES_ID IsNot Nothing, BL.PRESTACION.ObtenerPorId(vPRES_ID, vCon:=vCon), Nothing)

                    Dim vDatosSendMail As EL.DATOS_SENDMAIL = BL.DATOS_SENDMAIL.BuscarReagendar(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vCon:=vCon)(0)

                    'Se comprueba si la clinica tiene cabecera propia sino se usa la de por defecto
                    'Dim vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-" & vPRESTACION.CLI_ID & ".png")
                    Dim vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-" & vDatosSendMail.CLI_ID & ".png")
                    If Not File.Exists(vAbsoluteUri) Then
                        vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-clinicloud.png")
                    End If

                    'Dim vTIPO_PRESTACION As EL.TIPO_PRESTACION = If(vPRES_ID IsNot Nothing, BL.TIPO_PRESTACION.ObtenerPorId(vTPRE_ID:=vPRESTACION.TPRE_ID, vCon:=vCon), Nothing)
                    'Dim vUSUARIO_MEDICO As EL.USUARIO = If(Not IsNothing(vPRESTACION.USU_ID), BL.USUARIO.ObtenerPorId(vPRESTACION.USU_ID, vCon:=vCon), Nothing)
                    'Dim vUSUARIO_SESION As EL.USUARIO = If(vUSU_ID.HasValue, BL.USUARIO.ObtenerPorId(vUSU_ID, vCon:=vCon), Nothing)
                    'Dim vlistaCorreoUsuariosSupervisor As List(Of EL.USUARIO_SERVICIO_CLINICO) = If(vPRESTACION IsNot Nothing, BL.USUARIO_SERVICIO_CLINICO.Buscar(vSCLI_ID:=vPRESTACION.SCLI_ID, vTIPU_ID:=Generico.TIPO_USUARIO.SUPERVISOR), Nothing)
                    'Dim vlistaCorreoUsuariosSecretaria As List(Of EL.USUARIO_SERVICIO_CLINICO) = If(vPRESTACION IsNot Nothing, BL.USUARIO_SERVICIO_CLINICO.Buscar(vSCLI_ID:=vPRESTACION.SCLI_ID, vTIPU_ID:=Generico.TIPO_USUARIO.SECRETARIA), Nothing)
                    'Dim vlistaCorreoUsuariosSupervisor As New List(Of EL.USUARIO_SERVICIO_CLINICO)
                    'Dim vlistaCorreoUsuariosSecretaria As New List(Of EL.USUARIO_SERVICIO_CLINICO)
                    Dim mail As String = ""
                    Dim copia As String = ""
                    Dim vCuentaOrigen = WebConfigurationManager.AppSettings.Get("mail_cuenta_origen").ToString
                    Dim vServidor = WebConfigurationManager.AppSettings.Get("mail_servidor").ToString
                    Dim vNombrecuenta = WebConfigurationManager.AppSettings.Get("mail_nombre_cuenta").ToString
                    'Se cambia a Clinicloud ya que viene con PideHora desde el web.config
                    vNombrecuenta = "CliniCloud"
                    Dim vMail_SMTPPassword = WebConfigurationManager.AppSettings.Get("mail_smtp_password").ToString
                    Dim vMail_Port = WebConfigurationManager.AppSettings.Get("mail_port").ToString
                    Dim vMail_SSL = WebConfigurationManager.AppSettings.Get("mail_ssl").ToString

                    Dim asunto, texto As String
                    Dim variablesAsunto, variablesTexto As List(Of ListItem)
                    variablesAsunto = New List(Of ListItem)
                    asunto = getTextoTemplate("porReAgendarModificacionAsunto", Nothing)

                    variablesTexto = New List(Of ListItem)
                    If Not IsNothing(vlist) And vlist.Count > 0 Then
                        Dim strB As StringBuilder = New StringBuilder()
                        Dim item As ListItem
                        'item = New ListItem("tipoAgenda", vTIPO_PRESTACION.TPRE_DESCRIPCION)
                        item = New ListItem("tipoAgenda", vDatosSendMail.TPRE_DESCRIPCION)
                        variablesTexto.Add(item)
                        'item = New ListItem("agenda", vPRESTACION.PRES_DESCRIPCION)
                        item = New ListItem("agenda", vDatosSendMail.PRES_DESCRIPCION)
                        variablesTexto.Add(item)
                        'If Not IsNothing(vUSUARIO_MEDICO) Then
                        If Not IsNothing(vDatosSendMail.USU_RUT) Then
                            'item = New ListItem("rut", vUSUARIO_MEDICO.USU_RUT)
                            item = New ListItem("rut", vDatosSendMail.USU_RUT)
                        Else
                            item = New ListItem("rut", "")
                        End If
                        variablesTexto.Add(item)
                        'item = New ListItem("servicio", vPRESTACION.SCLI_DESCRIPCION)
                        item = New ListItem("servicio", vDatosSendMail.SCLI_DESCRIPCION)
                        variablesTexto.Add(item)
                        'item = New ListItem("sucursal", vPRESTACION.CLIS_DESCRIPCION)
                        item = New ListItem("sucursal", vDatosSendMail.CLIS_DESCRIPCION)
                        variablesTexto.Add(item)

                        'create html & table
                        'Comentamos lo que hemos pasado a template

                        strB.AppendLine("<table style='font-family: Arial; margin:0 auto; border:1px solid #000000; border-radius: 5px 5px 5px 5px;'>")
                        'create table header
                        Dim estiloTR As String = "style='padding-top: 20px; padding-left: 20px; border-collapse: collapse;	border: 1px solid #000000;	padding : 3px 5px;font-family: Arial;'"
                        strB.AppendLine("<tr " & estiloTR & " >")
                        Dim estiloTH As String = "style='padding-top: 20px; padding-left: 20px; border-collapse: collapse;	border: 1px solid #000000;	padding : 3px 5px; font-weight: lighter; text-transform: uppercase; font-size: 14px; background:#E3E0E0; font-family: Arial;'"
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Fecha Atención</th>")
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Rut/Pasaporte</th>")
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Nombre</th>")
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Fono</th>")
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Estado</th>")
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Atención</th>")
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Previsión</th>")
                        strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Observaciones</th>")
                        strB.AppendLine("</tr>")
                        'create table body
                        Dim estiloTD As String = "style='padding-top: 20px; padding-left: 20px; border-collapse: collapse;	border: 1px solid #000000;	padding : 3px 5px; font-size: 12px;font-family: Arial;'"
                        For Each reserva As EL.RESERVA In vlist
                            strB.AppendLine("<tr " & estiloTR & " >")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.RESE_FECHA_RESERVA & "</td>")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.CREDENCIAL & "</td>")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.PAC_NOMBRE & "</td>")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.PAC_TELEFONO & "</td>")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.ERES_DESCRIPCION & "</td>")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.TIAT_DESCRIPCION & "</td>")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.SISS_DESCRIPCION & "</td>")
                            strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & reserva.RESE_OBSERVACIONES & "</td>")
                            strB.AppendLine("</tr>")
                            'ENVIAR CORREO NOTICAR PACIENTE BLOQUEO MEDICO
                            'EnviarCorreoAusencia
                        Next
                        strB.AppendLine("</table>")

                        'item = New ListItem("clinica", vPRESTACION.CLI_DESCRIPCION)
                        item = New ListItem("clinica", vDatosSendMail.CLI_DESCRIPCION)
                        variablesTexto.Add(item)
                        item = New ListItem("tabla", strB.ToString)
                        variablesTexto.Add(item)
                        texto = getTextoTemplate("porReAgendarModificacionHTML", variablesTexto)

                        'If vUSUARIO_SESION IsNot Nothing Then
                        If vDatosSendMail.USU_MAIL IsNot Nothing Then
                            'mail = vUSUARIO_SESION.USU_MAIL
                            mail = vDatosSendMail.USU_MAIL

                            If String.IsNullOrEmpty(mail) = False Then
                                'For Each vcorreoUsuario As EL.USUARIO_SERVICIO_CLINICO In vlistaCorreoUsuariosSecretaria
                                '    If Not copia.Contains(vcorreoUsuario.USU_MAIL) AndAlso vcorreoUsuario.USU_MAIL <> mail Then
                                '        If vcorreoUsuario.USU_MAIL <> mail Then
                                '            If Not String.IsNullOrEmpty(copia) Then
                                '                copia = copia & ";" + vcorreoUsuario.USU_MAIL
                                '            Else
                                '                copia = vcorreoUsuario.USU_MAIL
                                '            End If
                                '        End If
                                '    End If
                                'Next
                                If Not String.IsNullOrEmpty(vDatosSendMail.LISTA_SECRETARIA) Then
                                    If Not vDatosSendMail.LISTA_SECRETARIA.Contains(vDatosSendMail.USU_MAIL) Then
                                        copia = vDatosSendMail.LISTA_SECRETARIA & ";" + vDatosSendMail.USU_MAIL
                                    Else
                                        copia = vDatosSendMail.USU_MAIL
                                    End If
                                End If
                                'For Each vcorreoUsuario As EL.USUARIO_SERVICIO_CLINICO In vlistaCorreoUsuariosSupervisor
                                '    If Not copia.Contains(vcorreoUsuario.USU_MAIL) AndAlso vcorreoUsuario.USU_MAIL <> mail Then
                                '        If vcorreoUsuario.USU_MAIL <> mail Then
                                '            If Not String.IsNullOrEmpty(copia) Then
                                '                copia = copia & ";" + vcorreoUsuario.USU_MAIL
                                '            Else
                                '                copia = vcorreoUsuario.USU_MAIL
                                '            End If
                                '        End If
                                '    End If
                                'Next
                                If Not String.IsNullOrEmpty(vDatosSendMail.LISTA_SUPERVISORA) Then
                                    If Not String.IsNullOrEmpty(copia) Then
                                        copia = copia & ";" + vDatosSendMail.LISTA_SUPERVISORA
                                    Else
                                        copia = vDatosSendMail.LISTA_SUPERVISORA & ";" + vDatosSendMail.USU_MAIL
                                    End If
                                End If

                                '----------Se envia el mail--------------------
                                If String.IsNullOrEmpty(mail) = False Then
                                    Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:=copia, vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                                    t.Start()
                                End If
                            End If

                        End If

                    End If
                End If
            Catch ex As Exception

            End Try

        End Sub

        Public Shared Sub EnviarCorreoAusencia(ByVal vPRES_ID As Int32?, ByVal vUSU_ID As Int32?, ByVal vRESE_ID As Int32?, ByVal vPAC_ID As Int32?, Optional ByVal vCon As Conexion = Nothing)
            'CORREO A PACIENTE DE BLOQUEO MEDICO
            'ENVIAMOS EL CORREO

        End Sub




        '                            If reserva.ERES_ID <> Generico.ESTADO_RESERVA.notificado Then
        '                        reserva.ERES_ID = Generico.ESTADO_RESERVA.notificado
        '                        BL.RESERVA.Guardar(vRESERVA:=reserva, vCon:=vCon)
        '                        If reserva.RESE_ID.HasValue Then
        'Dim vlog As New EL.RESERVA_LOG_ESTADO()
        '                            vlog.RESE_ID = reserva.RESE_ID
        '                            vlog.ERES_ID = reserva.ERES_ID
        '                            vlog.USU_ID = vUSU_ID
        '                            vlog.LOGE_COMENTARIO = ""
        '                            vlog.LOGE_FECHA_REGISTRO = DateTime.Now
        '                            BL.RESERVA_LOG_ESTADO.Guardar(vlog, vCon:=vCon)
        '                        End If
        '                    End If

        Public Shared Sub Eliminar(ByVal vRESERVA_LOG_ESTADO As EntityLayer.EL.RESERVA_LOG_ESTADO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RESERVA_LOG_ESTADO.Eliminar(vRESERVA_LOG_ESTADO:=vRESERVA_LOG_ESTADO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vLOGE_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.RESERVA_LOG_ESTADO
            Dim vL As List(Of EntityLayer.EL.RESERVA_LOG_ESTADO)
            vL = Buscar(vLOGE_ID:=vLOGE_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function sortList_RESERVA_LOG_ESTADO(ByVal order As String, _
                                                           ByVal col As String, _
                                                           ByVal vLista As List(Of EntityLayer.EL.RESERVA_LOG_ESTADO)) As List(Of EntityLayer.EL.RESERVA_LOG_ESTADO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "LOGE_ID"
                        query = query.OrderBy(Function(x) x.LOGE_ID)
                    Case "RESE_ID"
                        query = query.OrderBy(Function(x) x.RESE_ID)
                    Case "ERES_ID"
                        query = query.OrderBy(Function(x) x.ERES_ID)
                    Case "ERES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.ERES_DESCRIPCION)
                    Case "USU_ID"
                        query = query.OrderBy(Function(x) x.USU_ID)
                    Case "USU_NOMBRE"
                        query = query.OrderBy(Function(x) x.USU_NOMBRE)
                    Case "LOGE_COMENTARIO"
                        query = query.OrderBy(Function(x) x.LOGE_COMENTARIO)
                    Case "LOGE_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.LOGE_FECHA_REGISTRO)
                End Select
            Else
                Select Case col
                    Case "LOGE_ID"
                        query = query.OrderByDescending(Function(x) x.LOGE_ID)
                    Case "RESE_ID"
                        query = query.OrderByDescending(Function(x) x.RESE_ID)
                    Case "ERES_ID"
                        query = query.OrderByDescending(Function(x) x.ERES_ID)
                    Case "ERES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.ERES_DESCRIPCION)
                    Case "USU_ID"
                        query = query.OrderByDescending(Function(x) x.USU_ID)
                    Case "USU_NOMBRE"
                        query = query.OrderByDescending(Function(x) x.USU_NOMBRE)
                    Case "LOGE_COMENTARIO"
                        query = query.OrderByDescending(Function(x) x.LOGE_COMENTARIO)
                    Case "LOGE_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.LOGE_FECHA_REGISTRO)
                End Select
            End If

            Return query.ToList
        End Function

        Public Shared Function BuscarEstadoActualReserva(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                                   Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.RESERVA_LOG_ESTADO
            BuscarEstadoActualReserva = DataLayer.DAL.RESERVA_LOG_ESTADO.BuscarEstadoActualReserva(vRESE_ID:=vRESE_ID, vCon:=vCon)
        End Function

    End Class


End Namespace

