Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Imports EntityLayer

Namespace BL
    Public Class DATOS_SENDMAIL


        Public Shared Function Buscar(Optional ByVal vRESE_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vCLI_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vCLIS_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vCLIS_CALLE As String = Nothing, _
                                      Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vSCLI_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vPAC_ID As Int32? = Nothing, _
                                      Optional ByVal vPAC_NOMBRE As String = Nothing, _
                                      Optional ByVal vPAC_MAIL As String = Nothing, _
                                      Optional ByVal vRESE_FECHA_RESERVA As DateTime? = Nothing, _
                                      Optional ByVal vRESE_HORA_INI As TimeSpan? = Nothing, _
                                      Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vESP_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                      Optional ByVal vUSU_NOMBRE As String = Nothing, _
                                      Optional ByVal vUSU_MAIL As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DATOS_SENDMAIL)
            Try
                Buscar = DataLayer.DAL.DATOS_SENDMAIL.Buscar(vRESE_ID:=vRESE_ID, vCLI_ID:=vCLI_ID, vCLI_DESCRIPCION:=vCLI_DESCRIPCION, vCLIS_ID:=vCLIS_ID, vCLIS_DESCRIPCION:=vCLIS_DESCRIPCION, vCLIS_CALLE:=vCLIS_CALLE, vSCLI_ID:=vSCLI_ID, vSCLI_DESCRIPCION:=vSCLI_DESCRIPCION, vPAC_ID:=vPAC_ID, vPAC_NOMBRE:=vPAC_NOMBRE, vPAC_MAIL:=vPAC_MAIL, vRESE_FECHA_RESERVA:=vRESE_FECHA_RESERVA, vRESE_HORA_INI:=vRESE_HORA_INI, vPRES_ID:=vPRES_ID, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vESP_DESCRIPCION:=vESP_DESCRIPCION, vUSU_ID:=vUSU_ID, vUSU_NOMBRE:=vUSU_NOMBRE, vUSU_MAIL:=vUSU_MAIL, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarReagendar(Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vUSU_ID As Int32? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DATOS_SENDMAIL)

            Try
                BuscarReagendar = DataLayer.DAL.DATOS_SENDMAIL.BuscarReagendar(vPRES_ID:=vPRES_ID, vUSU_ID:=vUSU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function ListadoReservasPorReagendar(Optional ByVal vNDIAS As Int32? = 1, _
                                                           Optional ByVal vCon As Conexion = Nothing) As Boolean
            Try
                Dim vCLI_ID As String = Nothing
                Dim vCLI_DESCRIPCION As String = Nothing
                Dim vSCLI_ID As Int32? = Nothing
                Dim vSCLI_DESCRIPCION As String = Nothing
                Dim vCLIS_ID As Int32? = Nothing
                Dim vCLIS_DESCRIPCION As String = Nothing

                Dim clinicas As List(Of EL.CLINICA) = BL.CLINICA.Buscar()
                If clinicas IsNot Nothing Then
                    For Each clinica As EL.CLINICA In clinicas
                        vCLI_ID = clinica.CLI_ID
                        Dim centros As List(Of EL.CLINICA_SEDE) = BL.CLINICA_SEDE.Buscar(vCLI_ID:=clinica.CLI_ID)
                        If centros IsNot Nothing Then
                            For Each centro As EL.CLINICA_SEDE In centros
                                vCLIS_ID = centro.CLIS_ID
                                vCLI_DESCRIPCION = centro.CLI_DESCRIPCION
                                vCLIS_DESCRIPCION = centro.CLIS_DESCRIPCION


                                Dim servicios As List(Of EL.SERVICIO_CLINICO) = BL.SERVICIO_CLINICO.Buscar(vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID)
                                If servicios IsNot Nothing Then
                                    For Each servicio As EL.SERVICIO_CLINICO In servicios
                                        vSCLI_ID = servicio.SCLI_ID
                                        vSCLI_DESCRIPCION = servicio.SCLI_DESCRIPCION
                                        Dim vData As DataSet = DataLayer.DAL.DATOS_SENDMAIL.ListadoReservasPorReagendar(vSCLI_ID:=vSCLI_ID, vNDIAS:=vNDIAS, vCon:=vCon)

                                        If Not vData Is Nothing AndAlso vData.Tables.Count > 0 Then
                                            Dim vTabla As DataTable = vData.Tables(0)
                                            Dim vLista As DataTable = vData.Tables(1)

                                            Dim vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-" & vCLI_ID & ".png")
                                            If Not System.IO.File.Exists(vAbsoluteUri) Then
                                                vAbsoluteUri = System.Web.HttpContext.Current.Server.MapPath("~/IMAGENCLINICA/logo-clinicloud.png")
                                            End If

                                            'Dim vlistaCorreoUsuariosSupervisor As New List(Of EntityLayer.EL.USUARIO_SERVICIO_CLINICO)
                                            'Dim vlistaCorreoUsuariosSecretaria As New List(Of EntityLayer.EL.USUARIO_SERVICIO_CLINICO)
                                            Dim mail As String = ""
                                            Dim copia As String = ""
                                            Dim vCuentaOrigen = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("mail_cuenta_origen").ToString
                                            Dim vServidor = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("mail_servidor").ToString
                                            Dim vNombrecuenta = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("mail_nombre_cuenta").ToString
                                            'Se cambia a Clinicloud ya que viene con PideHora desde el web.config
                                            vNombrecuenta = "CliniCloud"
                                            Dim vMail_SMTPPassword = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("mail_smtp_password").ToString
                                            Dim vMail_Port = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("mail_port").ToString
                                            Dim vMail_SSL = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("mail_ssl").ToString

                                            Dim asunto, texto As String
                                            Dim variablesAsunto, variablesTexto As List(Of System.Web.UI.WebControls.ListItem)
                                            variablesAsunto = New List(Of System.Web.UI.WebControls.ListItem)
                                            asunto = Utilidades.Generico.getTextoTemplate("porReAgendarListadoAsunto", Nothing)

                                            variablesTexto = New List(Of System.Web.UI.WebControls.ListItem)

                                            If vTabla IsNot Nothing AndAlso vTabla.Rows.Count > 0 Then

                                                Dim strB As System.Text.StringBuilder = New System.Text.StringBuilder()
                                                Dim item As System.Web.UI.WebControls.ListItem

                                                item = New System.Web.UI.WebControls.ListItem("servicio", vSCLI_DESCRIPCION)
                                                variablesTexto.Add(item)
                                                item = New System.Web.UI.WebControls.ListItem("sucursal", vCLIS_DESCRIPCION)
                                                variablesTexto.Add(item)

                                                strB.AppendLine("<table style='font-family: Arial; margin:0 auto; border:1px solid #000000; border-radius: 5px 5px 5px 5px;'>")
                                                'create table header
                                                Dim estiloTR As String = "style='padding-top: 20px; padding-left: 20px; border-collapse: collapse;	border: 1px solid #000000;	padding : 3px 5px;font-family: Arial;'"
                                                strB.AppendLine("<tr " & estiloTR & " >")
                                                Dim estiloTH As String = "style='padding-top: 20px; padding-left: 20px; border-collapse: collapse;	border: 1px solid #000000;	padding : 3px 5px; font-weight: lighter; text-transform: uppercase; font-size: 14px; background:#E3E0E0; font-family: Arial;'"
                                                strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Fecha Atención</th>")
                                                strB.AppendLine("<th " & estiloTH & " align='center' align='middle'>Agenda</th>")
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

                                                For Each vFila As DataRow In vTabla.Rows
                                                    strB.AppendLine("<tr " & estiloTR & " >")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("RESE_FECHA_RESERVA") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("PRES_DESCRIPCION") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("CREDENCIAL") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("PAC_NOMBRE") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("PAC_TELEFONO") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("ERES_DESCRIPCION") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("TIAT_DESCRIPCION") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("SISS_DESCRIPCION") & "</td>")
                                                    strB.AppendLine("<td " & estiloTD & " align='center' align='middle'>" & vFila("RESE_OBSERVACIONES") & "</td>")
                                                    strB.AppendLine("</tr>")
                                                Next

                                                strB.AppendLine("</table>")

                                                item = New System.Web.UI.WebControls.ListItem("clinica", vCLI_DESCRIPCION)
                                                variablesTexto.Add(item)
                                                item = New System.Web.UI.WebControls.ListItem("tabla", strB.ToString)
                                                variablesTexto.Add(item)
                                                texto = Utilidades.Generico.getTextoTemplate("porReAgendarListadoHTML", variablesTexto)

                                                'If String.IsNullOrEmpty(mail) = False Then
                                                If Not String.IsNullOrEmpty(vLista.Rows(0)("LISTA_SECRETARIA")) Then
                                                    mail = vLista.Rows(0)("LISTA_SECRETARIA")
                                                End If

                                                If Not String.IsNullOrEmpty(vLista.Rows(0)("LISTA_SUPERVISORA")) Then
                                                    If Not mail.Contains(vLista.Rows(0)("LISTA_SUPERVISORA")) Then
                                                        mail = mail & vLista.Rows(0)("LISTA_SUPERVISORA")
                                                    End If
                                                End If

                                                '----------Se envia el mail--------------------
                                                If String.IsNullOrEmpty(mail) = False Then
                                                    Dim t As New System.Threading.Thread(Sub() Utilidades.Generico.EnviarMensaje(vsubject:=asunto, vbody:=texto, vFileAttachments:="", vcuentaDestino:=mail, vcuentaCopia:=copia, vNombrecuenta:=vNombrecuenta, vcuentaOrigen:=vCuentaOrigen, vSMTPServidor:=vServidor, vHtml:=True, vAbsoluteUri:=vAbsoluteUri, vMAIL_SMTPPASSWORD:=vMail_SMTPPassword, vMAIL_PORT:=vMail_Port, vMAIL_SSL:=vMail_SSL))
                                                    t.Start()
                                                End If

                                                'End If

                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If

                Return True

            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarDatosEliminacionPago(Optional ByVal vRESE_ID As Int32? = Nothing,
                                   Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DATOS_SENDMAIL)

            Try
                BuscarDatosEliminacionPago = DataLayer.DAL.DATOS_SENDMAIL.BuscarDatosEliminacionPago(vRESE_ID:=vRESE_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

    End Class
End Namespace

