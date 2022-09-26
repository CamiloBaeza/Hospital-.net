Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class PAGO_ATENCION_DETALLE
 
 
        Public Shared Function Buscar(Optional ByVal vPADE_ID As Int32? = Nothing, _
           Optional ByVal vPAAT_ID As Int32? = Nothing, _
           Optional ByVal vMEPA_ID As Int32? = Nothing, _
           Optional ByVal vBANC_ID As Decimal? = Nothing, _
           Optional ByVal vPADE_NUMERO_CHEQUE As String = Nothing, _
           Optional ByVal vPADE_RUT_TITULAR As String = Nothing, _
           Optional ByVal vPADE_NOMBRE_TITULAR As String = Nothing, _
           Optional ByVal vPADE_TELEFONO_TITULAR As String = Nothing, _
           Optional ByVal vPADE_OBSERVACION As String = Nothing, _
           Optional ByVal vPADE_BONO_EMPRESA_RUT As String = Nothing, _
           Optional ByVal vPADE_BONO_EMPRESA_NOMBRE As String = Nothing, _
           Optional ByVal vPADE_BONO_EMPRESA_NUMERO As String = Nothing, _
           Optional ByVal vPADE_MONTO As Decimal? = Nothing, _
           Optional ByVal vPADE_VIGENTE As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PAGO_ATENCION_DETALLE)
            Try
                Buscar = DataLayer.DAL.PAGO_ATENCION_DETALLE.Buscar(vPADE_ID:=vPADE_ID, vPAAT_ID:=vPAAT_ID, vMEPA_ID:=vMEPA_ID, vBANC_ID:=vBANC_ID, vPADE_NUMERO_CHEQUE:=vPADE_NUMERO_CHEQUE, vPADE_RUT_TITULAR:=vPADE_RUT_TITULAR, vPADE_NOMBRE_TITULAR:=vPADE_NOMBRE_TITULAR, vPADE_TELEFONO_TITULAR:=vPADE_TELEFONO_TITULAR, vPADE_OBSERVACION:=vPADE_OBSERVACION, vPADE_BONO_EMPRESA_RUT:=vPADE_BONO_EMPRESA_RUT, vPADE_BONO_EMPRESA_NOMBRE:=vPADE_BONO_EMPRESA_NOMBRE, vPADE_BONO_EMPRESA_NUMERO:=vPADE_BONO_EMPRESA_NUMERO, vPADE_MONTO:=vPADE_MONTO, vPADE_VIGENTE:=vPADE_VIGENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vPAGO_ATENCION_DETALLE As EntityLayer.EL.PAGO_ATENCION_DETALLE, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO_ATENCION_DETALLE.Guardar(vPAGO_ATENCION_DETALLE:=vPAGO_ATENCION_DETALLE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vPAGO_ATENCION_DETALLE As EntityLayer.EL.PAGO_ATENCION_DETALLE, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PAGO_ATENCION_DETALLE.Eliminar(vPAGO_ATENCION_DETALLE:=vPAGO_ATENCION_DETALLE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPADE_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PAGO_ATENCION_DETALLE
            Dim vL As List(Of EntityLayer.EL.PAGO_ATENCION_DETALLE)
            vL = Buscar(vPADE_ID:=vPADE_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function


        Public Shared Function sortList_PAGO_ATENCION_DETALLE(ByVal order As String, _
                              ByVal col As String, _
                              ByVal vLista As List(Of EntityLayer.EL.PAGO_ATENCION_DETALLE)) As List(Of EntityLayer.EL.PAGO_ATENCION_DETALLE)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "BANC_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.BANC_DESCRIPCION)
                    Case "BANC_ID"
                        query = query.OrderBy(Function(x) x.BANC_ID)
                    Case "MEPA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.MEPA_DESCRIPCION)
                    Case "MEPA_ID"
                        query = query.OrderBy(Function(x) x.MEPA_ID)
                    Case "PAAT_ID"
                        query = query.OrderBy(Function(x) x.PAAT_ID)
                    Case "PADE_BONO_EMPRESA_RUT"
                        query = query.OrderBy(Function(x) x.PADE_BONO_EMPRESA_RUT)
                    Case "PADE_BONO_EMPRESA_NOMBRE"
                        query = query.OrderBy(Function(x) x.PADE_BONO_EMPRESA_NOMBRE)
                    Case "PADE_BONO_EMPRESA_NUMERO"
                        query = query.OrderBy(Function(x) x.PADE_BONO_EMPRESA_NUMERO)
                    Case "PADE_ID"
                        query = query.OrderBy(Function(x) x.PADE_ID)
                    Case "PADE_MONTO"
                        query = query.OrderBy(Function(x) x.PADE_MONTO)
                    Case "PADE_NOMBRE_TITULAR"
                        query = query.OrderBy(Function(x) x.PADE_NOMBRE_TITULAR)
                    Case "PADE_NUMERO_CHEQUE"
                        query = query.OrderBy(Function(x) x.PADE_NUMERO_CHEQUE)
                    Case "PADE_OBSERVACION"
                        query = query.OrderBy(Function(x) x.PADE_OBSERVACION)
                    Case "PADE_RUT_TITULAR"
                        query = query.OrderBy(Function(x) x.PADE_RUT_TITULAR)
                    Case "PADE_TELEFONO_TITULAR"
                        query = query.OrderBy(Function(x) x.PADE_TELEFONO_TITULAR)
                    Case "PADE_VIGENTE"
                        query = query.OrderBy(Function(x) x.PADE_VIGENTE)


                End Select
            Else
                Select Case col


                    Case "BANC_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.BANC_DESCRIPCION)
                    Case "BANC_ID"
                        query = query.OrderByDescending(Function(x) x.BANC_ID)
                    Case "MEPA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.MEPA_DESCRIPCION)
                    Case "MEPA_ID"
                        query = query.OrderByDescending(Function(x) x.MEPA_ID)
                    Case "PAAT_ID"
                        query = query.OrderByDescending(Function(x) x.PAAT_ID)
                    Case "PADE_BONO_EMPRESA_RUT"
                        query = query.OrderByDescending(Function(x) x.PADE_BONO_EMPRESA_RUT)
                    Case "PADE_BONO_EMPRESA_NOMBRE"
                        query = query.OrderByDescending(Function(x) x.PADE_BONO_EMPRESA_NOMBRE)
                    Case "PADE_BONO_EMPRESA_NUMERO"
                        query = query.OrderByDescending(Function(x) x.PADE_BONO_EMPRESA_NUMERO)
                    Case "PADE_ID"
                        query = query.OrderByDescending(Function(x) x.PADE_ID)
                    Case "PADE_MONTO"
                        query = query.OrderByDescending(Function(x) x.PADE_MONTO)
                    Case "PADE_NOMBRE_TITULAR"
                        query = query.OrderByDescending(Function(x) x.PADE_NOMBRE_TITULAR)
                    Case "PADE_NUMERO_CHEQUE"
                        query = query.OrderByDescending(Function(x) x.PADE_NUMERO_CHEQUE)
                    Case "PADE_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.PADE_OBSERVACION)
                    Case "PADE_RUT_TITULAR"
                        query = query.OrderByDescending(Function(x) x.PADE_RUT_TITULAR)
                    Case "PADE_TELEFONO_TITULAR"
                        query = query.OrderByDescending(Function(x) x.PADE_TELEFONO_TITULAR)
                    Case "PADE_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.PADE_VIGENTE)

                End Select
            End If

            Return query.ToList
        End Function


    End Class


End Namespace

