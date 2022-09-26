Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class DIAGNOSTICO


        Public Shared Function Buscar(Optional ByVal vDIAG_ID As Int32? = Nothing, _
           Optional ByVal vTDIAG_ID As Int32? = Nothing, _
           Optional ByVal vDIAG_CODIGO As String = Nothing, _
           Optional ByVal vDIAG_DESCRIPCION As String = Nothing, _
           Optional ByVal vDIAG_VIGENTE As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DIAGNOSTICO)
            Try
                Buscar = DataLayer.DAL.DIAGNOSTICO.Buscar(vDIAG_ID:=vDIAG_ID, vTDIAG_ID:=vTDIAG_ID, vDIAG_CODIGO:=vDIAG_CODIGO, vDIAG_DESCRIPCION:=vDIAG_DESCRIPCION, vDIAG_VIGENTE:=vDIAG_VIGENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarM(
           Optional ByVal vDIAG_DESCRIPCION As String = Nothing, _
           Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DIAGNOSTICO)
            Try
                BuscarM = DataLayer.DAL.DIAGNOSTICO.BuscarM(vDIAG_DESCRIPCION:=vDIAG_DESCRIPCION)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function sortList_Diagnostico(ByVal order As String, _
                                    ByVal col As String, _
                                    ByVal vLista As List(Of EntityLayer.EL.DIAGNOSTICO)) As List(Of EntityLayer.EL.DIAGNOSTICO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "DIAG_CODIGO"
                        query = query.OrderBy(Function(x) x.DIAG_CODIGO)
                    Case "DIAG_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.DIAG_DESCRIPCION)
                    Case "TDIAG_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TDIAG_DESCRIPCION)

                End Select
            Else
                Select Case col
                    Case "DIAG_CODIGO"
                        query = query.OrderByDescending(Function(x) x.DIAG_CODIGO)
                    Case "DIAG_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.DIAG_DESCRIPCION)
                    Case "TDIAG_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TDIAG_DESCRIPCION)

                End Select
            End If

            Return query.ToList
        End Function



        Public Shared Function BuscarDiagnosticoAutocomplete(Optional ByVal vDIAG_ID As Int32? = Nothing, _
                                                             Optional ByVal vTDIAG_ID As Int32? = Nothing, _
                                                             Optional ByVal vDIAG_CODIGO As String = Nothing, _
                                                             Optional ByVal vDIAG_DESCRIPCION As String = Nothing, _
                                                             Optional ByVal vDIAG_VIGENTE As Boolean? = Nothing, _
                                                             Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                             Optional ByVal vPAC_ID As Int32? = Nothing, _
                                                             Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.DIAGNOSTICO)
            Try
                BuscarDiagnosticoAutocomplete = DataLayer.DAL.DIAGNOSTICO.BuscarDiagnosticoAutocomplete(vDIAG_ID:=vDIAG_ID, vTDIAG_ID:=vTDIAG_ID, vDIAG_CODIGO:=vDIAG_CODIGO, vDIAG_DESCRIPCION:=vDIAG_DESCRIPCION, vDIAG_VIGENTE:=vDIAG_VIGENTE, vPAC_ID:=vPAC_ID, vUSU_ID:=vUSU_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vDIAGNOSTICO As EntityLayer.EL.DIAGNOSTICO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.DIAGNOSTICO.Guardar(vDIAGNOSTICO:=vDIAGNOSTICO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vDIAGNOSTICO As EntityLayer.EL.DIAGNOSTICO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.DIAGNOSTICO.Eliminar(vDIAGNOSTICO:=vDIAGNOSTICO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vDIAG_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.DIAGNOSTICO
            Dim vL As List(Of EntityLayer.EL.DIAGNOSTICO)
            vL = Buscar(vDIAG_ID:=vDIAG_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

