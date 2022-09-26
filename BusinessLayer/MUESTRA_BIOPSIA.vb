Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class MUESTRA_BIOPSIA


        Public Shared Function Buscar(Optional ByVal vMUE_ID As Int32? = Nothing, _
           Optional ByVal vFIME_ID As Int32? = Nothing, _
           Optional ByVal vMUE_CORRELATIVO As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.MUESTRA_BIOPSIA)
            Try
                Buscar = DataLayer.DAL.MUESTRA_BIOPSIA.Buscar(vMUE_ID:=vMUE_ID, vFIME_ID:=vFIME_ID, vMUE_CORRELATIVO:=vMUE_CORRELATIVO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vMUESTRA_BIOPSIA As EntityLayer.EL.MUESTRA_BIOPSIA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MUESTRA_BIOPSIA.Guardar(vMUESTRA_BIOPSIA:=vMUESTRA_BIOPSIA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function GenerarCorrelativo(ByVal vFIME_ID As Int32?, ByVal vCLI_ID As String, Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.MUESTRA_BIOPSIA
            Try
                GenerarCorrelativo = DataLayer.DAL.MUESTRA_BIOPSIA.GenerarCorrelativo(vFIME_ID:=vFIME_ID, vCLI_ID:=vCLI_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Function

        Public Shared Sub Eliminar(ByVal vMUESTRA_BIOPSIA As EntityLayer.EL.MUESTRA_BIOPSIA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MUESTRA_BIOPSIA.Eliminar(vMUESTRA_BIOPSIA:=vMUESTRA_BIOPSIA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vMUE_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.MUESTRA_BIOPSIA
            Dim vL As List(Of EntityLayer.EL.MUESTRA_BIOPSIA)
            vL = Buscar(vMUE_ID:=vMUE_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

