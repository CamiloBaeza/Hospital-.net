Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class EXAMEN_RESERVA


        Public Shared Function Buscar(Optional ByVal vRESE_ID As Int32? = Nothing, _
           Optional ByVal vEXA_ID As Short? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.EXAMEN_RESERVA)
            Try
                Buscar = DataLayer.DAL.EXAMEN_RESERVA.Buscar(vRESE_ID:=vRESE_ID, vEXA_ID:=vEXA_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function BuscarSeleccion(Optional ByVal vEXA_ID As Short? = Nothing, _
                                            Optional ByVal vCLI_ID As String = Nothing, _
                                            Optional ByVal vTPRE_ID As Decimal? = Nothing, _
                                            Optional ByVal vEXA_RUTA_INDICACIONES As String = Nothing, _
                                            Optional ByVal vEXA_CANTIDAD_BLOQUES As Decimal? = Nothing, _
                                            Optional ByVal vEXA_VALOR As Decimal? = Nothing, _
                                            Optional ByVal vEXA_OBSERVACIONES As String = Nothing, _
                                            Optional ByVal vRESE_ID As Int32? = Nothing,
                                            Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.EXAMEN_CLINICA)
            Try
                BuscarSeleccion = DataLayer.DAL.EXAMEN_RESERVA.BuscarSeleccion(vEXA_ID:=vEXA_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vEXA_RUTA_INDICACIONES:=vEXA_RUTA_INDICACIONES, vEXA_CANTIDAD_BLOQUES:=vEXA_CANTIDAD_BLOQUES, vEXA_VALOR:=vEXA_VALOR, vEXA_OBSERVACIONES:=vEXA_OBSERVACIONES, vRESE_ID:=vRESE_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Sub Guardar(ByVal vEXAMEN_RESERVA As EntityLayer.EL.EXAMEN_RESERVA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.EXAMEN_RESERVA.Guardar(vEXAMEN_RESERVA:=vEXAMEN_RESERVA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vEXAMEN_RESERVA As EntityLayer.EL.EXAMEN_RESERVA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.EXAMEN_RESERVA.Eliminar(vEXAMEN_RESERVA:=vEXAMEN_RESERVA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub
        Public Shared Sub EliminarByReserva(ByVal vRESE_ID As Int32?, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.EXAMEN_RESERVA.EliminarByReserva(vRESE_ID:=vRESE_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vRESE_ID As Int32? = Nothing, _
       Optional ByVal vEXA_ID As Short? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.EXAMEN_RESERVA
            Dim vL As List(Of EntityLayer.EL.EXAMEN_RESERVA)
            vL = Buscar(vRESE_ID:=vRESE_ID, _
           vEXA_ID:=vEXA_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If
        End Function


        Public Shared Function ObtenerBloquesAdicionales(ByVal vEXA_ID_LIST As String, ByVal vCLI_ID As String, Optional ByVal vCon As Conexion = Nothing) As Int32?
            Return DataLayer.DAL.EXAMEN_RESERVA.ObtenerBloquesAdicionales(vEXA_ID_LIST:=vEXA_ID_LIST, vCLI_ID:=vCLI_ID, vCon:=vCon)
        End Function
    End Class


End Namespace

