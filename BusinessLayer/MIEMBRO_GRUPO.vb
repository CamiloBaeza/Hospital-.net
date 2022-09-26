Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class MIEMBRO_GRUPO


        Public Shared Function Buscar(Optional ByVal vMIGR_ID As Int32? = Nothing, _
           Optional ByVal vPAC_ID As Int32? = Nothing, _
           Optional ByVal vPAC_ID_LIDER As Int32? = Nothing, _
           Optional ByVal vMIGR_PARENTESCO As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.MIEMBRO_GRUPO)
            Try
                Buscar = DataLayer.DAL.MIEMBRO_GRUPO.Buscar(vMIGR_ID:=vMIGR_ID, vPAC_ID:=vPAC_ID, vPAC_ID_LIDER:=vPAC_ID_LIDER, vMIGR_PARENTESCO:=vMIGR_PARENTESCO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vMIEMBRO_GRUPO As EntityLayer.EL.MIEMBRO_GRUPO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MIEMBRO_GRUPO.Guardar(vMIEMBRO_GRUPO:=vMIEMBRO_GRUPO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vMIEMBRO_GRUPO As EntityLayer.EL.MIEMBRO_GRUPO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MIEMBRO_GRUPO.Eliminar(vMIEMBRO_GRUPO:=vMIEMBRO_GRUPO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vMIGR_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.MIEMBRO_GRUPO
            Dim vL As List(Of EntityLayer.EL.MIEMBRO_GRUPO)
            vL = Buscar(vMIGR_ID:=vMIGR_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

