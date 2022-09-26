Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class BOLETA_NULA


        Public Shared Function Buscar(Optional ByVal vBONU_ID As Int32? = Nothing, _
           Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _
           Optional ByVal vUSU_ID_ELIMINA As Int32? = Nothing, _
           Optional ByVal vCLI_ID As String = Nothing, _
           Optional ByVal vCLIS_ID As Int32? = Nothing, _
           Optional ByVal vSCLI_ID As Int32? = Nothing, _
           Optional ByVal vBONU_NUMERO_BOLETA As String = Nothing, _
           Optional ByVal vBONU_FECHA_REGISTRO As DateTime? = Nothing, _
           Optional ByVal vBONU_FECHA_ELIMINACION As DateTime? = Nothing, _
           Optional ByVal vBONU_VIGENTE As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.BOLETA_NULA)
            Try
                Buscar = DataLayer.DAL.BOLETA_NULA.Buscar(vBONU_ID:=vBONU_ID, vUSU_ID_REGISTRA:=vUSU_ID_REGISTRA, vUSU_ID_ELIMINA:=vUSU_ID_ELIMINA, vCLI_ID:=vCLI_ID, vCLIS_ID:=vCLIS_ID, vSCLI_ID:=vSCLI_ID, vBONU_NUMERO_BOLETA:=vBONU_NUMERO_BOLETA, vBONU_FECHA_REGISTRO:=vBONU_FECHA_REGISTRO, vBONU_FECHA_ELIMINACION:=vBONU_FECHA_ELIMINACION, vBONU_VIGENTE:=vBONU_VIGENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vBOLETA_NULA As EntityLayer.EL.BOLETA_NULA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.BOLETA_NULA.Guardar(vBOLETA_NULA:=vBOLETA_NULA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vBOLETA_NULA As EntityLayer.EL.BOLETA_NULA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.BOLETA_NULA.Eliminar(vBOLETA_NULA:=vBOLETA_NULA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vBONU_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.BOLETA_NULA
            If vBONU_ID.HasValue Then
                Dim vL As List(Of EntityLayer.EL.BOLETA_NULA)
                vL = Buscar(vBONU_ID:=vBONU_ID, _
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


        Public Shared Function sortList(ByVal order As String, _
                                            ByVal col As String, _
                                            ByVal vLista As List(Of EntityLayer.EL.BOLETA_NULA)) As List(Of EntityLayer.EL.BOLETA_NULA)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "BONU_FECHA_ELIMINACION"
                        query = query.OrderBy(Function(x) x.BONU_FECHA_ELIMINACION)
                    Case "BONU_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.BONU_FECHA_REGISTRO)
                    Case "BONU_ID"
                        query = query.OrderBy(Function(x) x.BONU_ID)
                    Case "BONU_NUMERO_BOLETA"
                        query = query.OrderBy(Function(x) x.BONU_NUMERO_BOLETA)
                    Case "BONU_VIGENTE"
                        query = query.OrderBy(Function(x) x.BONU_VIGENTE)
                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                    Case "CLIS_ID"
                        query = query.OrderBy(Function(x) x.CLIS_ID)
                    Case "SCLI_ID"
                        query = query.OrderBy(Function(x) x.SCLI_ID)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderBy(Function(x) x.USU_ID_ELIMINA)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderBy(Function(x) x.USU_ID_REGISTRA)
                End Select
            Else
                Select Case col
                    Case "BONU_FECHA_ELIMINACION"
                        query = query.OrderByDescending(Function(x) x.BONU_FECHA_ELIMINACION)
                    Case "BONU_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.BONU_FECHA_REGISTRO)
                    Case "BONU_ID"
                        query = query.OrderByDescending(Function(x) x.BONU_ID)
                    Case "BONU_NUMERO_BOLETA"
                        query = query.OrderByDescending(Function(x) x.BONU_NUMERO_BOLETA)
                    Case "BONU_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.BONU_VIGENTE)
                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                    Case "CLIS_ID"
                        query = query.OrderByDescending(Function(x) x.CLIS_ID)
                    Case "SCLI_ID"
                        query = query.OrderByDescending(Function(x) x.SCLI_ID)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_ELIMINA)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_REGISTRA)
                End Select
            End If

            Return query.ToList
        End Function
    End Class

End Namespace

