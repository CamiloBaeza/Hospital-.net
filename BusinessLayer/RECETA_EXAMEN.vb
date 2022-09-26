Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class RECETA_EXAMEN


        Public Shared Function Buscar(Optional ByVal vEXA_ID As Short? = Nothing, _
           Optional ByVal vFIME_ID As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RECETA_EXAMEN)
            Try
                Buscar = DataLayer.DAL.RECETA_EXAMEN.Buscar(vEXA_ID:=vEXA_ID, vFIME_ID:=vFIME_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function DatosRecetaExamen(Optional ByVal vFIME_ID As Int32? = Nothing, _
    Optional ByVal vCon As Conexion = Nothing) As DataTable
            Try
                DatosRecetaExamen = DataLayer.DAL.RECETA_EXAMEN.DatosRecetaExamen(vFIME_ID:=vFIME_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vRECETA_EXAMEN As EntityLayer.EL.RECETA_EXAMEN, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RECETA_EXAMEN.Guardar(vRECETA_EXAMEN:=vRECETA_EXAMEN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vRECETA_EXAMEN As EntityLayer.EL.RECETA_EXAMEN, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.RECETA_EXAMEN.Eliminar(vRECETA_EXAMEN:=vRECETA_EXAMEN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vEXA_ID As Short? = Nothing, _
       Optional ByVal vFIME_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.RECETA_EXAMEN
            Dim vL As List(Of EntityLayer.EL.RECETA_EXAMEN)
            vL = Buscar(vEXA_ID:=vEXA_ID, _
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

