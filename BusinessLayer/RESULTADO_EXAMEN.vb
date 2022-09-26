Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class RESULTADO_EXAMEN
        Public Shared Function sortList(ByVal order As String, _
                                       ByVal col As String, _
                                       ByVal vLista As List(Of EntityLayer.EL.RESULTADO_EXAMEN)) As List(Of EntityLayer.EL.RESULTADO_EXAMEN)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "CodigoUnico"
                        query = query.OrderBy(Function(x) x.CodigoUnico)
                    Case "EXA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderBy(Function(x) x.EXA_ID)
                    Case "Existe"
                        query = query.OrderBy(Function(x) x.Existe)
                    Case "FIME_ID"
                        query = query.OrderBy(Function(x) x.FIME_ID)
                    Case "RESX_FECHA"
                        query = query.OrderBy(Function(x) x.RESX_FECHA)
                    Case "RESX_OBSERVACION"
                        query = query.OrderBy(Function(x) x.RESX_OBSERVACION)
                    Case "FIME_ID_ANTERIOR"
                        query = query.OrderBy(Function(x) x.FIME_ID_ANTERIOR)
                    Case "RESX_ID"
                        query = query.OrderBy(Function(x) x.RESX_ID)
                End Select
            Else
                Select Case col
                    Case "CodigoUnico"
                        query = query.OrderByDescending(Function(x) x.CodigoUnico)
                    Case "EXA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderByDescending(Function(x) x.EXA_ID)
                    Case "Existe"
                        query = query.OrderByDescending(Function(x) x.Existe)
                    Case "FIME_ID"
                        query = query.OrderByDescending(Function(x) x.FIME_ID)
                    Case "RESX_FECHA"
                        query = query.OrderByDescending(Function(x) x.RESX_FECHA)
                    Case "RESX_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.RESX_OBSERVACION)
                    Case "FIME_ID_ANTERIOR"
                        query = query.OrderByDescending(Function(x) x.FIME_ID_ANTERIOR)
                    Case "RESX_ID"
                        query = query.OrderByDescending(Function(x) x.RESX_ID)
                End Select
            End If

            Return query.ToList
        End Function
        Public Shared Function BuscarPorUltimaFicha(Optional ByVal vPAC_ID As Int32? = Nothing, _
                                    Optional ByVal vUSU_ID As Int32? = Nothing, _
                                    Optional ByVal vCLI_ID As String = Nothing, _
                                    Optional ByVal vFIME_FECHA_FICHA_MEDICA As DateTime? = Nothing, _
                                    Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESULTADO_EXAMEN)
            Try
                BuscarPorUltimaFicha = DataLayer.DAL.RESULTADO_EXAMEN.BuscarPorUltimaFicha(vCLI_ID:=vCLI_ID, vPAC_ID:=vPAC_ID, vUSU_ID:=vUSU_ID, vFIME_FECHA_FICHA_MEDICA:=vFIME_FECHA_FICHA_MEDICA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function Buscar(Optional ByVal vRESX_ID As Int32? = Nothing, _
           Optional ByVal vFIME_ID As Int32? = Nothing, _
           Optional ByVal vFIME_ID_ANTERIOR As Int32? = Nothing, _
           Optional ByVal vEXA_ID As Short? = Nothing, _
           Optional ByVal vRESX_OBSERVACION As String = Nothing, _
           Optional ByVal vRESX_FECHA As DateTime? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESULTADO_EXAMEN)
            Try
                Buscar = DataLayer.DAL.RESULTADO_EXAMEN.Buscar(vRESX_ID:=vRESX_ID, vFIME_ID:=vFIME_ID, vFIME_ID_ANTERIOR:=vFIME_ID_ANTERIOR, vEXA_ID:=vEXA_ID, vRESX_OBSERVACION:=vRESX_OBSERVACION, vRESX_FECHA:=vRESX_FECHA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vRESULTADO_EXAMEN As EntityLayer.EL.RESULTADO_EXAMEN, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RESULTADO_EXAMEN.Guardar(vRESULTADO_EXAMEN:=vRESULTADO_EXAMEN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vRESULTADO_EXAMEN As EntityLayer.EL.RESULTADO_EXAMEN, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RESULTADO_EXAMEN.Eliminar(vRESULTADO_EXAMEN:=vRESULTADO_EXAMEN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vRESX_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.RESULTADO_EXAMEN
            Dim vL As List(Of EntityLayer.EL.RESULTADO_EXAMEN)
            vL = Buscar(vRESX_ID:=vRESX_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

