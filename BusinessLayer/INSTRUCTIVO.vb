Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class INSTRUCTIVO


        Public Shared Function InstructivoAutoCompletar(Optional ByVal vPREFIX_TEXT As String = Nothing,
                                                  Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INSTRUCTIVO)
            InstructivoAutoCompletar = DataLayer.DAL.INSTRUCTIVO.InstructivoAutoCompletar(vPREFIX_TEXT:=vPREFIX_TEXT)
        End Function
 
        Public Shared Function Buscar(Optional ByVal vINST_ID As Int32? = Nothing, _
           Optional ByVal vINST_DESCRIPCION As String = Nothing, _
           Optional ByVal vINST_NOMBRE_ARCHIVO As String = Nothing, _
           Optional ByVal vINST_RUT_ARCHIVO As String = Nothing, _
           Optional ByVal vINST_FECHA_REGISTRO As DateTime? = Nothing, _
           Optional ByVal vINST_FECHA_ELIMINACION As DateTime? = Nothing, _
           Optional ByVal vINST_FECHA_ACTUALIZACION As DateTime? = Nothing, _
           Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _
           Optional ByVal vUSU_ID_ELIMINA As Int32? = Nothing, _
           Optional ByVal vUSU_ID_ACTUALIZA As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INSTRUCTIVO)
            Try
                Buscar = DataLayer.DAL.INSTRUCTIVO.Buscar(vINST_ID:=vINST_ID, vINST_DESCRIPCION:=vINST_DESCRIPCION, vINST_NOMBRE_ARCHIVO:=vINST_NOMBRE_ARCHIVO, vINST_RUT_ARCHIVO:=vINST_RUT_ARCHIVO, vINST_FECHA_REGISTRO:=vINST_FECHA_REGISTRO, vINST_FECHA_ELIMINACION:=vINST_FECHA_ELIMINACION, vINST_FECHA_ACTUALIZACION:=vINST_FECHA_ACTUALIZACION, vUSU_ID_REGISTRA:=vUSU_ID_REGISTRA, vUSU_ID_ELIMINA:=vUSU_ID_ELIMINA, vUSU_ID_ACTUALIZA:=vUSU_ID_ACTUALIZA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vINSTRUCTIVO As EntityLayer.EL.INSTRUCTIVO, ByVal vEXAMENES_ID As String, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.INSTRUCTIVO.Guardar(vINSTRUCTIVO:=vINSTRUCTIVO, vCon:=vCon, vEXAMENES_ID:=vEXAMENES_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub


        Public Shared Function BuscarByExamenes_selected(Optional ByVal vEXAMENES_SELECTED As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.INSTRUCTIVO)
            Try
                BuscarByExamenes_selected = DataLayer.DAL.INSTRUCTIVO.BuscarByExamenes_selected(vEXAMENES_SELECTED:=vEXAMENES_SELECTED)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function
       
 
        Public Shared Sub Eliminar(ByVal vINSTRUCTIVO As EntityLayer.EL.INSTRUCTIVO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.INSTRUCTIVO.Eliminar(vINSTRUCTIVO:=vINSTRUCTIVO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub
 
        Public Shared Function ObtenerPorId(Optional ByVal vINST_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.INSTRUCTIVO
            Dim vL As List(Of EntityLayer.EL.INSTRUCTIVO)
            vL = DataLayer.DAL.INSTRUCTIVO.Buscar_ins(vINST_ID:=vINST_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

