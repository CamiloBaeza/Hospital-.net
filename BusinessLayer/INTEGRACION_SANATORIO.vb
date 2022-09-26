Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports EntityLayer
Imports Utilidades
Namespace BL
    Public Class INTEGRACION_SANATORIO
        Public Shared Function BuscarScriptORACLE(Optional ByVal vCon As ConexionOracle = Nothing) As List(Of EntityLayer.EL.INTEGRACION_SCRIPT)
            Try
                BuscarScriptORACLE = DataLayer.DAL.INTEGRACION_SANATORIO.BuscarScriptORACLE(vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function
        Public Shared Function BuscarScriptSQLSERVER(Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INTEGRACION_SCRIPT)
            Try
                BuscarScriptSQLSERVER = DataLayer.DAL.INTEGRACION_SANATORIO.BuscarScriptSQLSERVER(vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Sub EjecutarScriptORACLE(Optional ByVal vINTEGRACION_SCRIPT As EntityLayer.EL.INTEGRACION_SCRIPT = Nothing, Optional ByVal vCon As ConexionOracle = Nothing)
            Try
                If vINTEGRACION_SCRIPT IsNot Nothing AndAlso String.IsNullOrEmpty(vINTEGRACION_SCRIPT.SCRIPT) = False Then
                    DataLayer.DAL.INTEGRACION_SANATORIO.EjecutarScriptORACLE(vINTEGRACION_SCRIPT:=vINTEGRACION_SCRIPT, vCon:=vCon)
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub EjecutarScriptSQLSERVER(Optional ByVal vINTEGRACION_SCRIPT As EntityLayer.EL.INTEGRACION_SCRIPT = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                If vINTEGRACION_SCRIPT IsNot Nothing AndAlso String.IsNullOrEmpty(vINTEGRACION_SCRIPT.SCRIPT) = False Then
                    DataLayer.DAL.INTEGRACION_SANATORIO.EjecutarScriptSQLSERVER(vINTEGRACION_SCRIPT:=vINTEGRACION_SCRIPT, vCon:=vCon)
                End If
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub EliminarINSAORACLE(Optional ByVal vINTEGRACION_SCRIPT As EntityLayer.EL.INTEGRACION_SCRIPT = Nothing, Optional ByVal vCon As ConexionOracle = Nothing)
            Try
                DataLayer.DAL.INTEGRACION_SANATORIO.EliminarINSAORACLE(vINTEGRACION_SCRIPT:=vINTEGRACION_SCRIPT, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub


        Public Shared Sub EliminarINSASQLSERVER(Optional ByVal vINTEGRACION_SCRIPT As EntityLayer.EL.INTEGRACION_SCRIPT = Nothing, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.INTEGRACION_SANATORIO.EliminarINSASQLSERVER(vINTEGRACION_SCRIPT:=vINTEGRACION_SCRIPT, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub Integrar()
            'SINCRONIZAR ORACLE a SQLSERVER
            Dim vl As List(Of EL.INTEGRACION_SCRIPT) = BL.INTEGRACION_SANATORIO.BuscarScriptORACLE
            If vl IsNot Nothing Then
                For Each ve As EL.INTEGRACION_SCRIPT In vl
                    Try
                        BL.INTEGRACION_SANATORIO.EjecutarScriptSQLSERVER(ve)
                        BL.INTEGRACION_SANATORIO.EliminarINSAORACLE(ve)
                    Catch ex As Exception

                    End Try
                Next

            End If
            'SINCRONIZAR SQLSERVER a ORACLE
            vl = BL.INTEGRACION_SANATORIO.BuscarScriptSQLSERVER
            If vl IsNot Nothing Then
                For Each ve As EL.INTEGRACION_SCRIPT In vl
                    Try
                        BL.INTEGRACION_SANATORIO.EjecutarScriptORACLE(ve)
                        BL.INTEGRACION_SANATORIO.EliminarINSASQLSERVER(ve)
                    Catch ex As Exception

                    End Try
                Next
            End If
        End Sub




        Public Shared Function GET_HOS_VAL_CSA(ByVal vCOD_GPR As Int32?, _
                                                ByVal vSUB_PRE As Int32?, _
                                                ByVal vNUM_PRE As Int32?, _
                                                ByVal vURG_PRE As Int32?, _
                                                Optional ByVal vCon As ConexionOracle = Nothing) As EL.HOS_VAL_CSA
            Return DataLayer.DAL.INTEGRACION_SANATORIO.GET_HOS_VAL_CSA(vCOD_GPR:=vCOD_GPR, vSUB_PRE:=vSUB_PRE, vNUM_PRE:=vNUM_PRE, vURG_PRE:=vURG_PRE, vCon:=vCon)
        End Function

        Public Shared Function PreIntegrarRecaudacion(ByVal vLISTA_PAGO_ATENCION As List(Of EL.PAGO_ATENCION), _
                                                   ByVal vPACIENTE As EL.PACIENTE) As Boolean

            Try
                'SINCRONIZAR ORACLE a SQLSERVER
                If vLISTA_PAGO_ATENCION Is Nothing Then
                    Throw New Exception("No existe un pago de atención")
                ElseIf vPACIENTE Is Nothing OrElse vPACIENTE.PAC_ID.HasValue = False Then
                    Throw New Exception("No existe un paciente asociado")
                ElseIf vPACIENTE.PARTE_RUT Is Nothing Then
                    Throw New Exception("No existe un RUT de paciente asociado")
                ElseIf vPACIENTE.PARTE_DV Is Nothing Then
                    Throw New Exception("No existe un DV de paciente asociado")
                Else
                    'INTEGRAR PACIENTE
                    Try
                        IntegrarPacienteSqlOracle(vPAC_ID:=vPACIENTE.PAC_ID)
                    Catch ex As Exception
                        Throw New Exception("No es posible integrar los datos del paciente")
                    End Try

                    'VERIFICAMOS SI PACIENTE EXISTE EN ORACLE
                    Dim vRUT_PAC As Int32? = CType(vPACIENTE.PARTE_RUT, Int32?)
                    Dim vDV_PAC As Int32? = CType(vPACIENTE.PARTE_DV, Int32?)
                    Dim vHOS_PAC As EL.HOS_PAC_CSA = DataLayer.DAL.INTEGRACION_SANATORIO.GET_HOS_PAC_CSA(vRUT_PAC:=vRUT_PAC, vDV_PAC:=vDV_PAC)
                    If vHOS_PAC Is Nothing Then
                        Throw New Exception("El paciente especificado no se encuentra integrado en Sanatorio")
                    Else
                        'VALIDAMOS QUE EXISTA COD_INS
                        If String.IsNullOrEmpty(vHOS_PAC.cod_ins) Then
                            Throw New Exception("El paciente no posee COD_INS actualizado en integración")
                        Else
                            Dim vLISTA_CCLD_PAGO_ATENCION As New List(Of EL.CCLD_PAGO_ATENCION)
                            For Each vp As EL.PAGO_ATENCION In vLISTA_PAGO_ATENCION
                                Try
                                    vLISTA_CCLD_PAGO_ATENCION.AddRange(BL.INTEGRACION_SANATORIO.BuscarPagoIntegracion(vPAAT_ID:=vp.PAAT_ID, _
                                                                                    vRUT_PAC:=vHOS_PAC.rut_pac, _
                                                                                    vDV_PAC:=vHOS_PAC.dv_pac, _
                                                                                    vPAT_PAC:=vHOS_PAC.pat_pac, _
                                                                                    vMAT_PAC:=vHOS_PAC.mat_pac, _
                                                                                    vNOM_PAC:=vHOS_PAC.nom_pac, _
                                                                                    vFNA_PAC:=vHOS_PAC.fna_pac, _
                                                                                    vCOD_INS:=vHOS_PAC.cod_ins, _
                                                                                    vDIR_PAC:=vHOS_PAC.dir_pac, _
                                                                                    vCOD_COM:=vHOS_PAC.cod_com, _
                                                                                    vTEL_PAC:=vHOS_PAC.tel_pac, _
                                                                                    vEMA_PAC:=vHOS_PAC.ema_pac, _
                                                                                    vDOMINIO_PAC:=vHOS_PAC.dominio_pac, _
                                                                                    vEXENTO_DPPA:=vp.EXENTO_DPPA, _
                                                                                    vAFECTO_DPPA:=vp.AFECTO_DPPA, _
                                                                                    vTOTAL_DPFA:=vp.TOTAL_DPFA))


                                Catch ex As Exception
                                    BL.PAGO_ATENCION.GuardarEstadoIntegracion(vPAAT_ID:=vp.PAAT_ID, vPAAT_INCLI_ESTADO:=Generico.ESTADO_INTEGRACION.ERROR_PREPROCESO, vPAAT_INCLI_ESTADO_ERROR:=ex.Message)
                                End Try
                            Next

                            For Each vp As EL.CCLD_PAGO_ATENCION In vLISTA_CCLD_PAGO_ATENCION
                                Try
                                    DataLayer.DAL.INTEGRACION_SANATORIO.InsertarPagoIntegracion(vCCLD_PAGO_ATENCION:=vp)
                                    BL.PAGO_ATENCION.GuardarEstadoIntegracion(vPAAT_ID:=vp.PAAT_ID, vPAAT_INCLI_ESTADO:=Generico.ESTADO_INTEGRACION.PENDIENTE, vPAAT_INCLI_ESTADO_ERROR:="")
                                Catch ex As Exception
                                    BL.PAGO_ATENCION.GuardarEstadoIntegracion(vPAAT_ID:=vp.PAAT_ID, vPAAT_INCLI_ESTADO:=Generico.ESTADO_INTEGRACION.ERROR_PREPROCESO, vPAAT_INCLI_ESTADO_ERROR:=ex.Message)
                                End Try
                            Next
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
            Return True
        End Function

        Public Shared Sub IntegrarPacienteSqlOracle(ByVal vPAC_ID As Int32?, Optional ByVal vCon As Conexion = Nothing)
            Dim vl As List(Of EL.INTEGRACION_SCRIPT) = BL.INTEGRACION_SANATORIO.BuscarScriptSQLSERVERPaciente(vPAC_ID:=vPAC_ID, vCon:=vCon)
            If vl IsNot Nothing Then
                For Each ve As EL.INTEGRACION_SCRIPT In vl
                    Try
                        BL.INTEGRACION_SANATORIO.EjecutarScriptORACLE(ve)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                Next
            End If
        End Sub

        Public Shared Function BuscarScriptSQLSERVERPaciente(ByVal vPAC_ID As Int32?, Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INTEGRACION_SCRIPT)
            Try
                BuscarScriptSQLSERVERPaciente = DataLayer.DAL.INTEGRACION_SANATORIO.BuscarScriptSQLSERVERPaciente(vPAC_ID:=vPAC_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Function BuscarPagoIntegracion(Optional ByVal vPAAT_ID As Int32? = Nothing, _
                                                             Optional ByVal vRUT_PAC As Int32? = Nothing, _
                                                             Optional ByVal vDV_PAC As String = Nothing, _
                                                             Optional ByVal vPAT_PAC As String = Nothing, _
                                                             Optional ByVal vMAT_PAC As String = Nothing, _
                                                             Optional ByVal vNOM_PAC As String = Nothing, _
                                                             Optional ByVal vFNA_PAC As DateTime? = Nothing, _
                                                             Optional ByVal vCOD_INS As String = Nothing, _
                                                             Optional ByVal vDIR_PAC As String = Nothing, _
                                                             Optional ByVal vCOD_COM As String = Nothing, _
                                                             Optional ByVal vTEL_PAC As String = Nothing, _
                                                             Optional ByVal vEMA_PAC As String = Nothing, _
                                                             Optional ByVal vDOMINIO_PAC As String = Nothing, _
                                                             Optional ByVal vEXENTO_DPPA As Int32? = Nothing, _
                                                             Optional ByVal vAFECTO_DPPA As Int32? = Nothing, _
                                                             Optional ByVal vTOTAL_DPFA As Int32? = Nothing, _
                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CCLD_PAGO_ATENCION)
            Return DataLayer.DAL.INTEGRACION_SANATORIO.BuscarPagoIntegracion(vPAAT_ID:=vPAAT_ID, _
                                        vRUT_PAC:=vRUT_PAC, _
                                        vDV_PAC:=vDV_PAC, _
                                        vPAT_PAC:=vPAT_PAC, _
                                        vMAT_PAC:=vMAT_PAC, _
                                        vNOM_PAC:=vNOM_PAC, _
                                        vFNA_PAC:=vFNA_PAC, _
                                        vCOD_INS:=vCOD_INS, _
                                        vDIR_PAC:=vDIR_PAC, _
                                        vCOD_COM:=vCOD_COM, _
                                        vTEL_PAC:=vTEL_PAC, _
                                        vEMA_PAC:=vEMA_PAC, _
                                        vDOMINIO_PAC:=vDOMINIO_PAC, _
                                        vEXENTO_DPPA:=vEXENTO_DPPA, _
                                        vAFECTO_DPPA:=vAFECTO_DPPA, _
                                        vTOTAL_DPFA:=vTOTAL_DPFA, _
                                        vCon:=vCon)
        End Function

        Public Shared Sub EliminarPagoIntegracion(ByVal vRESE_ID As Int32?, _
                                                          Optional ByVal vCon As ConexionOracle = Nothing)
            DataLayer.DAL.INTEGRACION_SANATORIO.EliminarPagoIntegracion(vRESE_ID:=vRESE_ID, vCon:=vCon)
        End Sub

        Public Shared Function IntegrarRecaudacion(Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.CCLD_LOG_INTEGRACION)
            Return DataLayer.DAL.INTEGRACION_SANATORIO.IntegrarRecaudacion(vCon:=vCon)
        End Function
       
    End Class
End Namespace
