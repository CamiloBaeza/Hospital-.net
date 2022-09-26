Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class RECETA_MEDICAMENTO


        Public Shared Function Buscar(Optional ByVal vMEDI_ID As Int32? = Nothing, _
           Optional ByVal vFIME_ID As Int32? = Nothing, _
           Optional ByVal vREME_INDICACIONES As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RECETA_MEDICAMENTO)
            Try
                Buscar = DataLayer.DAL.RECETA_MEDICAMENTO.Buscar(vMEDI_ID:=vMEDI_ID, vFIME_ID:=vFIME_ID, vREME_INDICACIONES:=vREME_INDICACIONES, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function BuscarInforme(Optional ByVal vFIME_ID As Int32? = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RECETA_MEDICAMENTO_INFORME)
            Try
                BuscarInforme = DataLayer.DAL.RECETA_MEDICAMENTO.BuscarInforme(vFIME_ID:=vFIME_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Sub Guardar(ByVal vRECETA_MEDICAMENTO As EntityLayer.EL.RECETA_MEDICAMENTO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RECETA_MEDICAMENTO.Guardar(vRECETA_MEDICAMENTO:=vRECETA_MEDICAMENTO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vRECETA_MEDICAMENTO As EntityLayer.EL.RECETA_MEDICAMENTO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RECETA_MEDICAMENTO.Eliminar(vRECETA_MEDICAMENTO:=vRECETA_MEDICAMENTO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vMEDI_ID As Int32? = Nothing, _
       Optional ByVal vFIME_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.RECETA_MEDICAMENTO
            Dim vL As List(Of EntityLayer.EL.RECETA_MEDICAMENTO)
            vL = Buscar(vMEDI_ID:=vMEDI_ID, _
           vFIME_ID:=vFIME_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

