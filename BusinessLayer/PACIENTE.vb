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
    Public Class PACIENTE

        Public Shared Function BuscarPacienteAutoCompletar(Optional ByVal vPREFIX_TEXT As String = Nothing,
                                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PACIENTE)
            BuscarPacienteAutoCompletar = DataLayer.DAL.PACIENTE.BuscarPacienteAutoCompletar(vPREFIX_TEXT:=vPREFIX_TEXT)
        End Function



        Public Shared Function Buscar(Optional ByVal vPAC_ID As Int32? = Nothing, _
       Optional ByVal vCOM_ID As Int32? = Nothing, _
       Optional ByVal vSISS_ID As Int32? = Nothing, _
       Optional ByVal vPAC_RUT As String = Nothing, _
       Optional ByVal vPAC_PASAPORTE As String = Nothing, _
       Optional ByVal vPAC_NOMBRE As String = Nothing, _
       Optional ByVal vPAC_APELLIDO_PAT As String = Nothing, _
       Optional ByVal vPAC_APELLIDO_MAT As String = Nothing, _
       Optional ByVal vPAC_CALLE As String = Nothing, _
       Optional ByVal vPAC_TELEFONO As String = Nothing, _
       Optional ByVal vPAC_CELULAR As String = Nothing, _
       Optional ByVal vPAC_MAIL As String = Nothing, _
       Optional ByVal vPAC_NACIMIENTO As DateTime? = Nothing, _
       Optional ByVal vPAC_SEXO As String = Nothing, _
       Optional ByVal vPAC_TITULAR As Boolean? = Nothing, _
       Optional ByVal vPAC_CLAVE As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.PACIENTE)
            Buscar = DataLayer.DAL.PACIENTE.Buscar(vPAC_ID, vCOM_ID, vSISS_ID, vPAC_RUT, vPAC_PASAPORTE, vPAC_NOMBRE, vPAC_APELLIDO_PAT, vPAC_APELLIDO_MAT, vPAC_CALLE, vPAC_TELEFONO, vPAC_CELULAR, vPAC_MAIL, vPAC_NACIMIENTO, vPAC_SEXO, vPAC_TITULAR, vPAC_CLAVE, vCon, vControlEstado:=vControlEstado)
        End Function




        Public Shared Sub Guardar(ByVal vPACIENTE As EntityLayer.EL.PACIENTE, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.PACIENTE.Guardar(vPACIENTE, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vPACIENTE As EntityLayer.EL.PACIENTE, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.PACIENTE.Eliminar(vPACIENTE, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPAC_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As EntityLayer.EL.PACIENTE
            If vPAC_ID.HasValue Then
                Dim vL As List(Of EntityLayer.EL.PACIENTE)
                vL = Buscar(vPAC_ID:=vPAC_ID, _
               vCon:=vCon, vControlEstado:=vControlEstado)
                If vL IsNot Nothing AndAlso vL.Count = 1 Then
                    ObtenerPorId = vL(0)
                Else
                    ObtenerPorId = Nothing
                End If
            Else
                ObtenerPorId = Nothing
            End If
        End Function

        Public Shared Function ListarPaciente(ByVal vPACIENTE As EntityLayer.EL.PACIENTE, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            ListarPaciente = DataLayer.DAL.PACIENTE.ListarPaciente(vPACIENTE, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function ListarPacienteReservas(ByVal vRutPaciente As String, Optional ByVal vCon As Conexion = Nothing) As DataTable
            ListarPacienteReservas = DataLayer.DAL.PACIENTE.ListarPacienteReservas(vRutPaciente, vCon)
        End Function

        Public Shared Function sortList_PACIENTE(ByVal order As String, _
                                       ByVal col As String, _
                                       ByVal vLista As List(Of EntityLayer.EL.PACIENTE)) As List(Of EntityLayer.EL.PACIENTE)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "COM_ID"
                        query = query.OrderBy(Function(x) x.COM_ID)
                    Case "PAC_APELLIDO_MAT"
                        query = query.OrderBy(Function(x) x.PAC_APELLIDO_MAT)
                    Case "PAC_APELLIDO_PAT"
                        query = query.OrderBy(Function(x) x.PAC_APELLIDO_PAT)
                    Case "PAC_CALLE"
                        query = query.OrderBy(Function(x) x.PAC_CALLE)
                    Case "PAC_CELULAR"
                        query = query.OrderBy(Function(x) x.PAC_CELULAR)
                    Case "PAC_CLAVE"
                        query = query.OrderBy(Function(x) x.PAC_CLAVE)
                    Case "PAC_CODIGO_CAMBIO_CLAVE"
                        query = query.OrderBy(Function(x) x.PAC_CODIGO_CAMBIO_CLAVE)
                    Case "PAC_ID"
                        query = query.OrderBy(Function(x) x.PAC_ID)
                    Case "PAC_MAIL"
                        query = query.OrderBy(Function(x) x.PAC_MAIL)
                    Case "PAC_NACIMIENTO"
                        query = query.OrderBy(Function(x) x.PAC_NACIMIENTO)
                    Case "PAC_NOMBRE"
                        query = query.OrderBy(Function(x) x.PAC_NOMBRE)

                    Case "PAC_RUT"
                        query = query.OrderBy(Function(x) x.PAC_RUT)
                    Case "PAC_SEXO"
                        query = query.OrderBy(Function(x) x.PAC_SEXO)
                    Case "PAC_TELEFONO"
                        query = query.OrderBy(Function(x) x.PAC_TELEFONO)
                    Case "SISS_ID"
                        query = query.OrderBy(Function(x) x.SISS_ID)
                    Case "CREDENCIAL"
                        query = query.OrderBy(Function(x) x.CREDENCIAL)
                End Select
            Else
                Select Case col
                    Case "COM_ID"
                        query = query.OrderByDescending(Function(x) x.COM_ID)
                    Case "PAC_APELLIDO_MAT"
                        query = query.OrderByDescending(Function(x) x.PAC_APELLIDO_MAT)
                    Case "PAC_APELLIDO_PAT"
                        query = query.OrderByDescending(Function(x) x.PAC_APELLIDO_PAT)
                    Case "PAC_CALLE"
                        query = query.OrderByDescending(Function(x) x.PAC_CALLE)
                    Case "PAC_CELULAR"
                        query = query.OrderByDescending(Function(x) x.PAC_CELULAR)
                    Case "PAC_CLAVE"
                        query = query.OrderByDescending(Function(x) x.PAC_CLAVE)
                    Case "PAC_CODIGO_CAMBIO_CLAVE"
                        query = query.OrderByDescending(Function(x) x.PAC_CODIGO_CAMBIO_CLAVE)
                    Case "PAC_ID"
                        query = query.OrderByDescending(Function(x) x.PAC_ID)
                    Case "PAC_MAIL"
                        query = query.OrderByDescending(Function(x) x.PAC_MAIL)
                    Case "PAC_NACIMIENTO"
                        query = query.OrderByDescending(Function(x) x.PAC_NACIMIENTO)
                    Case "PAC_NOMBRE"
                        query = query.OrderByDescending(Function(x) x.PAC_NOMBRE)
                    Case "PAC_RUT"
                        query = query.OrderByDescending(Function(x) x.PAC_RUT)
                    Case "PAC_SEXO"
                        query = query.OrderByDescending(Function(x) x.PAC_SEXO)
                    Case "PAC_TELEFONO"
                        query = query.OrderByDescending(Function(x) x.PAC_TELEFONO)
                    Case "SISS_ID"
                        query = query.OrderByDescending(Function(x) x.SISS_ID)
                    Case "CREDENCIAL"
                        query = query.OrderByDescending(Function(x) x.CREDENCIAL)
                End Select
            End If

            Return query.ToList
        End Function


        Public Shared Function enviarMailContraseña(ByVal vTIPO_CREDENCIAL As String, ByVal vRUT As String, ByVal vPASAPORTE As String) As String
            Dim vResultado As String = ""
            Try
                Dim vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/cabecera-correo-pidehora.jpg")
                Dim vCuentaOrigen = WebConfigurationManager.AppSettings.Get("mail_cuenta_origen").ToString
                Dim vServidor = WebConfigurationManager.AppSettings.Get("mail_servidor").ToString
                Dim vNombrecuenta = WebConfigurationManager.AppSettings.Get("mail_nombre_cuenta").ToString
                Dim vMail_SMTPPassword = WebConfigurationManager.AppSettings.Get("mail_smtp_password").ToString
                Dim vMail_Port = WebConfigurationManager.AppSettings.Get("mail_port").ToString
                Dim vMail_SSL = WebConfigurationManager.AppSettings.Get("mail_ssl").ToString
                Dim vLista As New List(Of EL.PACIENTE)
                Dim vclave_default As String = ""
                '----------Validar Existe Registro------------- 
                If vTIPO_CREDENCIAL = Generico.TIPO_CREDENCIAL_RUT Then
                    vLista = BL.PACIENTE.Buscar(vPAC_RUT:=vRUT)
                    vclave_default = vRUT.Replace("-", "")
                ElseIf vTIPO_CREDENCIAL = Generico.TIPO_CREDENCIAL_PASAPORTE Then
                    vLista = BL.PACIENTE.Buscar(vPAC_PASAPORTE:=vPASAPORTE)
                    vclave_default = vPASAPORTE
                Else
                    Throw New Exception("Tipo de credencial no está definida")
                End If

                If vLista IsNot Nothing AndAlso vLista.Count > 0 Then
                    '----------Validar Existe Mail------------- 
                    If vLista.Item(0).PAC_MAIL Is Nothing Then
                        Throw New Exception("El paciente no tiene mail registrado")
                    Else
                        '----------Generar Nueva Contraseña------------
                        Dim nuevaContraseña, contraseñaEncriptada As String

                        nuevaContraseña = If(String.IsNullOrEmpty(vLista.Item(0).PAC_CLAVE), vclave_default, Encriptacion.DecryptText(vLista.Item(0).PAC_CLAVE, Encriptacion.Key))
                        '----------Encriptar Nueva Contraseña----------
                        contraseñaEncriptada = ""
                        Try
                            contraseñaEncriptada = Encriptacion.EncryptText(nuevaContraseña, Encriptacion.Key)
                        Catch ex As Exception
                            Throw New Exception("Ocurrió un problema al tratar de encriptar la contraseña")
                        End Try

                        '----------Guardar Nueva Contraseña------------
                        vLista.Item(0).PAC_CLAVE = contraseñaEncriptada
                        BL.PACIENTE.Guardar(vLista.Item(0))
                        '----------Se obtiene el Template--------------
                        Dim texto, asunto, mail As String 'para probar los hilos
                        Dim variablesAsunto, variablesTexto As List(Of ListItem)
                        Dim item As ListItem
                        variablesAsunto = Nothing
                        asunto = getTextoTemplate("olvidoClaveAsuntoPideHora", variablesAsunto)
                        variablesTexto = New List(Of ListItem)
                        item = New ListItem("nombreUsuario", vLista.Item(0).PAC_NOMBRE_COMPLETO)
                        variablesTexto.Add(item)
                        item = New ListItem("nuevaClave", nuevaContraseña)
                        variablesTexto.Add(item)
                        'texto = getTextoTemplate("olvidoClavePideHora", variablesTexto)
                        texto = getTextoTemplate("olvidoClavePideHoraHTML", variablesTexto)
                        mail = vLista.Item(0).PAC_MAIL
                        vResultado = mail
                        Dim t As New Thread(Sub() EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:="", vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                        t.Start()
                        'Dim envio As Boolean = False
                    End If
                Else
                    Throw New Exception("Paciente ingresado es incorrecto.")
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return vResultado
        End Function
    End Class


End Namespace

