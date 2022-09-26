Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class LISTA_ESPERA


        Public Shared Function Buscar(Optional ByVal vLIES_ID As Int32? = Nothing, _
           Optional ByVal vRESE_ID As Int32? = Nothing, _
           Optional ByVal vLIES_R1_HORA_INI As TimeSpan? = Nothing, _
           Optional ByVal vLIES_R1_HORA_FIN As TimeSpan? = Nothing, _
           Optional ByVal vLIES_R1_LU As Boolean? = Nothing, _
           Optional ByVal vLIES_R1_MA As Boolean? = Nothing, _
           Optional ByVal vLIES_R1_MI As Boolean? = Nothing, _
           Optional ByVal vLIES_R1_JU As Boolean? = Nothing, _
           Optional ByVal vLIES_R1_VI As Boolean? = Nothing, _
           Optional ByVal vLIES_R1_SA As Boolean? = Nothing, _
           Optional ByVal vLIES_R1_DO As Boolean? = Nothing, _
           Optional ByVal vLIES_R2_HORA_INI As TimeSpan? = Nothing, _
           Optional ByVal vLIES_R2_HORA_FIN As TimeSpan? = Nothing, _
           Optional ByVal vLIES_R2_LU As Boolean? = Nothing, _
           Optional ByVal vLIES_R2_MA As Boolean? = Nothing, _
           Optional ByVal vLIES_R2_MI As Boolean? = Nothing, _
           Optional ByVal vLIES_R2_JU As Boolean? = Nothing, _
           Optional ByVal vLIES_R2_VI As Boolean? = Nothing, _
           Optional ByVal vLIES_R2_SA As Boolean? = Nothing, _
           Optional ByVal vLIES_R2_DO As Boolean? = Nothing, _
           Optional ByVal vLIES_R3_HORA_INI As TimeSpan? = Nothing, _
           Optional ByVal vLIES_R3_HORA_FIN As TimeSpan? = Nothing, _
           Optional ByVal vLIES_R3_LU As Boolean? = Nothing, _
           Optional ByVal vLIES_R3_MA As Boolean? = Nothing, _
           Optional ByVal vLIES_R3_MI As Boolean? = Nothing, _
           Optional ByVal vLIES_R3_JU As Boolean? = Nothing, _
           Optional ByVal vLIES_R3_VI As Boolean? = Nothing, _
           Optional ByVal vLIES_R3_SA As Boolean? = Nothing, _
           Optional ByVal vLIES_R3_DO As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.LISTA_ESPERA)
            Try
                Buscar = DataLayer.DAL.LISTA_ESPERA.Buscar(vLIES_ID:=vLIES_ID, vRESE_ID:=vRESE_ID, vLIES_R1_HORA_INI:=vLIES_R1_HORA_INI, vLIES_R1_HORA_FIN:=vLIES_R1_HORA_FIN, vLIES_R1_LU:=vLIES_R1_LU, vLIES_R1_MA:=vLIES_R1_MA, vLIES_R1_MI:=vLIES_R1_MI, vLIES_R1_JU:=vLIES_R1_JU, vLIES_R1_VI:=vLIES_R1_VI, vLIES_R1_SA:=vLIES_R1_SA, vLIES_R1_DO:=vLIES_R1_DO, vLIES_R2_HORA_INI:=vLIES_R2_HORA_INI, vLIES_R2_HORA_FIN:=vLIES_R2_HORA_FIN, vLIES_R2_LU:=vLIES_R2_LU, vLIES_R2_MA:=vLIES_R2_MA, vLIES_R2_MI:=vLIES_R2_MI, vLIES_R2_JU:=vLIES_R2_JU, vLIES_R2_VI:=vLIES_R2_VI, vLIES_R2_SA:=vLIES_R2_SA, vLIES_R2_DO:=vLIES_R2_DO, vLIES_R3_HORA_INI:=vLIES_R3_HORA_INI, vLIES_R3_HORA_FIN:=vLIES_R3_HORA_FIN, vLIES_R3_LU:=vLIES_R3_LU, vLIES_R3_MA:=vLIES_R3_MA, vLIES_R3_MI:=vLIES_R3_MI, vLIES_R3_JU:=vLIES_R3_JU, vLIES_R3_VI:=vLIES_R3_VI, vLIES_R3_SA:=vLIES_R3_SA, vLIES_R3_DO:=vLIES_R3_DO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


      
        Public Shared Function BuscarReservas(Optional ByVal vDETALLE_HORA_INI As TimeSpan? = Nothing, _
                                            Optional ByVal vFECHA As DateTime? = Nothing, _
                                            Optional ByVal vHORD_DIA As Int32? = Nothing, _
                                            Optional ByVal vHORD_ID As Int32? = Nothing, _
                                            Optional ByVal vPRES_ID As Int32? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.RESERVA_LIGHT)
            Try
                BuscarReservas = DataLayer.DAL.LISTA_ESPERA.BuscarReservas(vDETALLE_HORA_INI:=vDETALLE_HORA_INI, vFECHA:=vFECHA, vHORD_DIA:=vHORD_DIA, vHORD_ID:=vHORD_ID, vPRES_ID:=vPRES_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vLISTA_ESPERA As EntityLayer.EL.LISTA_ESPERA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.LISTA_ESPERA.Guardar(vLISTA_ESPERA:=vLISTA_ESPERA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vLISTA_ESPERA As EntityLayer.EL.LISTA_ESPERA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.LISTA_ESPERA.Eliminar(vLISTA_ESPERA:=vLISTA_ESPERA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vLIES_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.LISTA_ESPERA
            Dim vL As List(Of EntityLayer.EL.LISTA_ESPERA)
            vL = Buscar(vLIES_ID:=vLIES_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

