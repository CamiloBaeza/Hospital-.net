Imports System
Imports System.Collections
Imports System.Configuration
Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class INSTRUCTIVO_EXAMEN
        Public Shared Function Buscar(Optional ByVal vEXA_DESCRIPCION As String = Nothing, _
                                      Optional ByVal vINST_NOMBRE_ARCHIVO As String = Nothing, _
                                      Optional ByVal vCon As Conexion = Nothing,
                                      Optional ByVal vCLI_ID As String = Nothing, _
                                      Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.INSTRUCTIVO_EXAMEN)
            Buscar = DataLayer.DAL.INSTRUCTIVO_EXAMEN.Buscar(vCLI_ID:=vCLI_ID, vEXA_DESCRIPCION:=vEXA_DESCRIPCION, vCon:=vCon, vINST_NOMBRE_ARCHIVO:=vINST_NOMBRE_ARCHIVO)
        End Function



        Public Shared Sub Guardar(ByVal vINSTRUCTIVO_EXAMEN As EntityLayer.EL.INSTRUCTIVO_EXAMEN, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.INSTRUCTIVO_EXAMEN.Guardar(vINSTRUCTIVO_EXAMEN:=vINSTRUCTIVO_EXAMEN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vINSTRUCTIVO_EXAMEN As EntityLayer.EL.INSTRUCTIVO_EXAMEN, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.INSTRUCTIVO_EXAMEN.Eliminar(vINSTRUCTIVO_EXAMEN:=vINSTRUCTIVO_EXAMEN, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

  
    End Class
End Namespace
