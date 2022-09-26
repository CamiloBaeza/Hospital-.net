Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class AGENDA_CONSOLIDADA


        Public Shared Function BuscarEspecialista(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                  Optional ByVal vCLI_ID As Int32? = Nothing, _
                                                  Optional ByVal vFECHA As DateTime? = Nothing, _
                                                  Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.AGENDA_CONSOLIDADA)
            Try
                BuscarEspecialista = DataLayer.DAL.AGENDA_CONSOLIDADA.Buscar(vUSU_ID:=vUSU_ID, vCLI_ID:=vCLI_ID, vFECHA:=vFECHA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function
    End Class


End Namespace

