Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class HORARIO_SEMANAL

        Public Shared Function Buscar(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                    Optional ByVal vCLIS_ID As Int32? = Nothing, _
                                      Optional ByVal vSCLI_ID As Int32? = Nothing, _
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vESP_ID As Int32? = Nothing, _
                                      Optional ByVal vTPRE_ID As Int32? = Nothing, _
                                      Optional ByVal vTIAT_ID As Int32? = Nothing, _
                                      Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                      Optional ByVal vFECHA As DateTime? = Nothing, _
                                      Optional ByVal vPRES_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vSISS_ID As Int32? = Nothing, _
                                      Optional ByVal vEMP_ID As Int32? = Nothing, _
                                      Optional ByVal vAUSENCIA_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vFERIADO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vPLAZO_MAXIMO_HORARIO As Boolean? = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HORARIO_SEMANAL)
            Try
                Buscar = DataLayer.DAL.HORARIO_SEMANAL.Buscar(vUSU_ID:=vUSU_ID, vCLIS_ID:=vCLIS_ID, vSCLI_ID:=vSCLI_ID, vCLI_ID:=vCLI_ID, vESP_ID:=vESP_ID, vTPRE_ID:=vTPRE_ID, vTIAT_ID:=vTIAT_ID, vPRES_ID:=vPRES_ID, vFECHA:=vFECHA, vPRES_DESCRIPCION:=vPRES_DESCRIPCION, vSISS_ID:=vSISS_ID, vEMP_ID:=vEMP_ID,vAUSENCIA_HORARIO:=vAUSENCIA_HORARIO, vFERIADO_HORARIO:=vFERIADO_HORARIO, vPLAZO_MAXIMO_HORARIO:=vPLAZO_MAXIMO_HORARIO,vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vHORARIO_SEMANAL As EntityLayer.EL.HORARIO_SEMANAL, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.HORARIO_SEMANAL.Guardar(vHORARIO_SEMANAL:=vHORARIO_SEMANAL, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vHORARIO_SEMANAL As EntityLayer.EL.HORARIO_SEMANAL, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.HORARIO_SEMANAL.Eliminar(vHORARIO_SEMANAL:=vHORARIO_SEMANAL, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.HORARIO_SEMANAL
            Dim vL As List(Of EntityLayer.EL.HORARIO_SEMANAL)
            vL = Buscar(vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

