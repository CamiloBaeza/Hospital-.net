Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class PROFESION


        Public Shared Function Buscar(Optional ByVal vPRO_ID As Short? = Nothing, _
       Optional ByVal vPRO_DESCRIPCION As String = Nothing, _
       Optional ByVal vPRO_DESCRIPCION_VAL As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.PROFESION)
            Buscar = DataLayer.DAL.PROFESION.Buscar(vPRO_ID, vPRO_DESCRIPCION, vPRO_DESCRIPCION_VAL, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarDt(Optional ByVal vPRO_ID As Short? = Nothing, _
Optional ByVal vPRO_DESCRIPCION As String = Nothing, _
Optional ByVal vPRO_DESCRIPCION_VAL As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As DataTable
            BuscarDt = DataLayer.DAL.PROFESION.BuscarDt(vPRO_ID, vPRO_DESCRIPCION, vPRO_DESCRIPCION_VAL, vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Sub Guardar(ByVal vPROFESION As EntityLayer.EL.PROFESION, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.PROFESION.Guardar(vPROFESION, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vPROFESION As EntityLayer.EL.PROFESION, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.PROFESION.Eliminar(vPROFESION, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPRO_ID As Short? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PROFESION
            Dim vL As List(Of EntityLayer.EL.PROFESION)
            vL = Buscar(vPRO_ID:=vPRO_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

