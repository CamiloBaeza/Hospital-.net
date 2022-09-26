Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class PAGO_ATENCION


        Public Shared Function Buscar(Optional ByVal vPAAT_ID As Int32? = Nothing, _
           Optional ByVal vUSU_ID As Int32? = Nothing, _
           Optional ByVal vFOPC_ID As Int32? = Nothing, _
           Optional ByVal vRESE_ID As Int32? = Nothing, _
           Optional ByVal vPAAT_NUMERO_BONO As String = Nothing, _
           Optional ByVal vPAAT_NUMERO_BOLETA As String = Nothing, _
           Optional ByVal vPAAT_NUMERO_GARANTIA As String = Nothing, _
           Optional ByVal vPAAT_OBSERVACION As String = Nothing, _
           Optional ByVal vPAAT_MONTO_BONO As Decimal? = Nothing, _
           Optional ByVal vPAAT_MONTO_APORTE As Decimal? = Nothing, _
           Optional ByVal vPAAT_MONTO_SEGURO_COMP As Decimal? = Nothing, _
           Optional ByVal vPAAT_MONTO_DESCUENTO As Decimal? = Nothing, _
           Optional ByVal vPAAT_MONTO_COPAGO As Decimal? = Nothing, _
           Optional ByVal vPAAT_MONTO_PARTICULAR As Decimal? = Nothing, _
           Optional ByVal vPAAT_FECHA_PAGO As DateTime? = Nothing, _
           Optional ByVal vPAAT_FECHA_REGISTRO As DateTime? = Nothing, _
           Optional ByVal vPAAT_FECHA_VENC_GARANTIA As DateTime? = Nothing, _
           Optional ByVal vPAAT_FECHA_DEVO_GARANTIA As DateTime? = Nothing, _
           Optional ByVal vPAAT_NOMBRE_GARANTIA As String = Nothing, _
           Optional ByVal vPAAT_RUT_GARANTIA As String = Nothing, _
           Optional ByVal vPAAT_LIBERADO As Boolean? = Nothing, _
           Optional ByVal vPAAT_INSTITUCIONAL As Boolean? = Nothing, _
           Optional ByVal vPAAT_VIGENTE As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PAGO_ATENCION)
            Try
                Buscar = DataLayer.DAL.PAGO_ATENCION.Buscar(vPAAT_ID:=vPAAT_ID, vUSU_ID:=vUSU_ID, vFOPC_ID:=vFOPC_ID, vRESE_ID:=vRESE_ID, vPAAT_NUMERO_BONO:=vPAAT_NUMERO_BONO, vPAAT_NUMERO_BOLETA:=vPAAT_NUMERO_BOLETA, vPAAT_NUMERO_GARANTIA:=vPAAT_NUMERO_GARANTIA, vPAAT_OBSERVACION:=vPAAT_OBSERVACION, vPAAT_MONTO_BONO:=vPAAT_MONTO_BONO, vPAAT_MONTO_APORTE:=vPAAT_MONTO_APORTE, vPAAT_MONTO_SEGURO_COMP:=vPAAT_MONTO_SEGURO_COMP, vPAAT_MONTO_DESCUENTO:=vPAAT_MONTO_DESCUENTO, vPAAT_MONTO_COPAGO:=vPAAT_MONTO_COPAGO, vPAAT_MONTO_PARTICULAR:=vPAAT_MONTO_PARTICULAR, vPAAT_FECHA_PAGO:=vPAAT_FECHA_PAGO, vPAAT_FECHA_REGISTRO:=vPAAT_FECHA_REGISTRO, vPAAT_FECHA_VENC_GARANTIA:=vPAAT_FECHA_VENC_GARANTIA, vPAAT_FECHA_DEVO_GARANTIA:=vPAAT_FECHA_DEVO_GARANTIA, vPAAT_NOMBRE_GARANTIA:=vPAAT_NOMBRE_GARANTIA, vPAAT_RUT_GARANTIA:=vPAAT_RUT_GARANTIA, vPAAT_LIBERADO:=vPAAT_LIBERADO, vPAAT_INSTITUCIONAL:=vPAAT_INSTITUCIONAL, vPAAT_VIGENTE:=vPAAT_VIGENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vPAGO_ATENCION As EntityLayer.EL.PAGO_ATENCION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO_ATENCION.Guardar(vPAGO_ATENCION:=vPAGO_ATENCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub GuardarSanatorio(ByVal vPAGO_ATENCION As EntityLayer.EL.PAGO_ATENCION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO_ATENCION.GuardarSanatorio(vPAGO_ATENCION:=vPAGO_ATENCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Sub GuardarEstadoIntegracion(ByVal vPAAT_ID As Int32?, ByVal vPAAT_INCLI_ESTADO As Int32?, ByVal vPAAT_INCLI_ESTADO_ERROR As String, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO_ATENCION.GuardarEstadoIntegracion(vPAAT_ID:=vPAAT_ID, vPAAT_INCLI_ESTADO:=vPAAT_INCLI_ESTADO, vPAAT_INCLI_ESTADO_ERROR:=vPAAT_INCLI_ESTADO_ERROR, vCon:=vCon)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try
        End Sub

        Public Shared Sub Eliminar(ByVal vPAGO_ATENCION As EntityLayer.EL.PAGO_ATENCION, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO_ATENCION.Eliminar(vPAGO_ATENCION:=vPAGO_ATENCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPAAT_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PAGO_ATENCION
            Dim vL As List(Of EntityLayer.EL.PAGO_ATENCION)
            vL = Buscar(vPAAT_ID:=vPAAT_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function BuscarGarantia(Optional ByVal vCLI_ID As Int32? = Nothing, _
                                              Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                              Optional ByVal vTPRE_ID As Int32? = Nothing, _
                                              Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                              Optional ByVal vPRES_ID As Int32? = Nothing, _
                                              Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
                                              Optional ByVal vESP_ID As Int32? = Nothing, _
                                              Optional ByVal vFECHA_INI As DateTime? = Nothing, _
                                              Optional ByVal vFECHA_FIN As DateTime? = Nothing, _
                                              Optional ByVal vTITULAR_PACIENTE As String = Nothing, _
                                              Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PAGO_ATENCION)
            Try
                BuscarGarantia = DataLayer.DAL.PAGO_ATENCION.BuscarGarantia(vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vTPRE_ID:=vTPRE_ID, vSCLI_ID:=vSCLI_ID, vPRES_ID:=vPRES_ID, vESP_ID:=vESP_ID, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vFECHA_INI:=vFECHA_INI, vFECHA_FIN:=vFECHA_FIN, vTITULAR_PACIENTE:=vTITULAR_PACIENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function sortList_PAGO_ATENCION(ByVal order As String, _
                              ByVal col As String, _
                              ByVal vLista As List(Of EntityLayer.EL.PAGO_ATENCION)) As List(Of EntityLayer.EL.PAGO_ATENCION)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "ESTADO"
                        query = query.OrderBy(Function(x) x.ESTADO)
                    Case "FOPC_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.FOPC_DESCRIPCION)
                    Case "FOPC_ID"
                        query = query.OrderBy(Function(x) x.FOPC_ID)
                    Case "MEPA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.MEPA_DESCRIPCION)
                    Case "PAAT_FECHA_DEVO_GARANTIA"
                        query = query.OrderBy(Function(x) x.PAAT_FECHA_DEVO_GARANTIA)
                    Case "PAAT_FECHA_PAGO"
                        query = query.OrderBy(Function(x) x.PAAT_FECHA_PAGO)
                    Case "PAAT_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.PAAT_FECHA_REGISTRO)
                    Case "PAAT_FECHA_VENC_GARANTIA"
                        query = query.OrderBy(Function(x) x.PAAT_FECHA_VENC_GARANTIA)
                    Case "PAAT_GARANTIA_ID"
                        query = query.OrderBy(Function(x) x.PAAT_GARANTIA_ID)
                    Case "PAAT_ID"
                        query = query.OrderBy(Function(x) x.PAAT_ID)
                    Case "PAAT_INSTITUCIONAL"
                        query = query.OrderBy(Function(x) x.PAAT_INSTITUCIONAL)
                    Case "PAAT_LIBERADO"
                        query = query.OrderBy(Function(x) x.PAAT_LIBERADO)
                    Case "PAAT_MONTO_APORTE"
                        query = query.OrderBy(Function(x) x.PAAT_MONTO_APORTE)
                    Case "PAAT_MONTO_BONO"
                        query = query.OrderBy(Function(x) x.PAAT_MONTO_BONO)
                    Case "PAAT_MONTO_COPAGO"
                        query = query.OrderBy(Function(x) x.PAAT_MONTO_COPAGO)
                    Case "PAAT_MONTO_DESCUENTO"
                        query = query.OrderBy(Function(x) x.PAAT_MONTO_DESCUENTO)
                    Case "PAAT_MONTO_PAGADO"
                        query = query.OrderBy(Function(x) x.PAAT_MONTO_PAGADO)
                    Case "PAAT_MONTO_PARTICULAR"
                        query = query.OrderBy(Function(x) x.PAAT_MONTO_PARTICULAR)
                    Case "PAAT_MONTO_SEGURO_COMP"
                        query = query.OrderBy(Function(x) x.PAAT_MONTO_SEGURO_COMP)
                    Case "PAAT_NOMBRE_GARANTIA"
                        query = query.OrderBy(Function(x) x.PAAT_NOMBRE_GARANTIA)
                    Case "PAAT_NUMERO_BOLETA"
                        query = query.OrderBy(Function(x) x.PAAT_NUMERO_BOLETA)
                    Case "PAAT_NUMERO_BONO"
                        query = query.OrderBy(Function(x) x.PAAT_NUMERO_BONO)
                    Case "PAAT_NUMERO_GARANTIA"
                        query = query.OrderBy(Function(x) x.PAAT_NUMERO_GARANTIA)
                    Case "PAAT_OBSERVACION"
                        query = query.OrderBy(Function(x) x.PAAT_OBSERVACION)
                    Case "PAAT_RUT_GARANTIA"
                        query = query.OrderBy(Function(x) x.PAAT_RUT_GARANTIA)
                    Case "PAAT_VIGENTE"
                        query = query.OrderBy(Function(x) x.PAAT_VIGENTE)
                    Case "PACIENTE"
                        query = query.OrderBy(Function(x) x.PACIENTE)
                    Case "PADE_MONTO"
                        query = query.OrderBy(Function(x) x.PADE_MONTO)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PRES_DESCRIPCION)
                    Case "RESE_ID"
                        query = query.OrderBy(Function(x) x.RESE_ID)
                    Case "TPRE_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TPRE_DESCRIPCION)
                    Case "USU_ID"
                        query = query.OrderBy(Function(x) x.USU_ID)
                    Case "PACIENTE"
                        query = query.OrderBy(Function(x) x.PACIENTE)
                End Select
            Else
                Select Case col

                    Case "ESTADO"
                        query = query.OrderByDescending(Function(x) x.ESTADO)
                    Case "FOPC_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.FOPC_DESCRIPCION)
                    Case "FOPC_ID"
                        query = query.OrderByDescending(Function(x) x.FOPC_ID)
                    Case "MEPA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.MEPA_DESCRIPCION)
                    Case "PAAT_FECHA_DEVO_GARANTIA"
                        query = query.OrderByDescending(Function(x) x.PAAT_FECHA_DEVO_GARANTIA)
                    Case "PAAT_FECHA_PAGO"
                        query = query.OrderByDescending(Function(x) x.PAAT_FECHA_PAGO)
                    Case "PAAT_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.PAAT_FECHA_REGISTRO)
                    Case "PAAT_FECHA_VENC_GARANTIA"
                        query = query.OrderByDescending(Function(x) x.PAAT_FECHA_VENC_GARANTIA)
                    Case "PAAT_GARANTIA_ID"
                        query = query.OrderByDescending(Function(x) x.PAAT_GARANTIA_ID)
                    Case "PAAT_ID"
                        query = query.OrderByDescending(Function(x) x.PAAT_ID)
                    Case "PAAT_INSTITUCIONAL"
                        query = query.OrderByDescending(Function(x) x.PAAT_INSTITUCIONAL)
                    Case "PAAT_LIBERADO"
                        query = query.OrderByDescending(Function(x) x.PAAT_LIBERADO)
                    Case "PAAT_MONTO_APORTE"
                        query = query.OrderByDescending(Function(x) x.PAAT_MONTO_APORTE)
                    Case "PAAT_MONTO_BONO"
                        query = query.OrderByDescending(Function(x) x.PAAT_MONTO_BONO)
                    Case "PAAT_MONTO_COPAGO"
                        query = query.OrderByDescending(Function(x) x.PAAT_MONTO_COPAGO)
                    Case "PAAT_MONTO_DESCUENTO"
                        query = query.OrderByDescending(Function(x) x.PAAT_MONTO_DESCUENTO)
                    Case "PAAT_MONTO_PAGADO"
                        query = query.OrderByDescending(Function(x) x.PAAT_MONTO_PAGADO)
                    Case "PAAT_MONTO_PARTICULAR"
                        query = query.OrderByDescending(Function(x) x.PAAT_MONTO_PARTICULAR)
                    Case "PAAT_MONTO_SEGURO_COMP"
                        query = query.OrderByDescending(Function(x) x.PAAT_MONTO_SEGURO_COMP)
                    Case "PAAT_NOMBRE_GARANTIA"
                        query = query.OrderByDescending(Function(x) x.PAAT_NOMBRE_GARANTIA)
                    Case "PAAT_NUMERO_BOLETA"
                        query = query.OrderByDescending(Function(x) x.PAAT_NUMERO_BOLETA)
                    Case "PAAT_NUMERO_BONO"
                        query = query.OrderByDescending(Function(x) x.PAAT_NUMERO_BONO)
                    Case "PAAT_NUMERO_GARANTIA"
                        query = query.OrderByDescending(Function(x) x.PAAT_NUMERO_GARANTIA)
                    Case "PAAT_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.PAAT_OBSERVACION)
                    Case "PAAT_RUT_GARANTIA"
                        query = query.OrderByDescending(Function(x) x.PAAT_RUT_GARANTIA)
                    Case "PAAT_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.PAAT_VIGENTE)
                    Case "PACIENTE"
                        query = query.OrderByDescending(Function(x) x.PACIENTE)
                    Case "PADE_MONTO"
                        query = query.OrderByDescending(Function(x) x.PADE_MONTO)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PRES_DESCRIPCION)
                    Case "RESE_ID"
                        query = query.OrderByDescending(Function(x) x.RESE_ID)
                    Case "TPRE_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TPRE_DESCRIPCION)
                    Case "USU_ID"
                        query = query.OrderByDescending(Function(x) x.USU_ID)
                    Case "PACIENTE"
                        query = query.OrderByDescending(Function(x) x.PACIENTE)
                End Select
            End If

            Return query.ToList
        End Function
    End Class

End Namespace

