Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class PREPARATIVO



        Public Shared Function sortList_PREPARATIVO(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.PREPARATIVO)) As List(Of EntityLayer.EL.PREPARATIVO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "PREP_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PREP_DESCRIPCION)
                    Case "TIPO_RESPUESTA"
                        query = query.OrderBy(Function(x) x.TIPO_RESPUESTA)
                End Select
            Else
                Select Case col
                    Case "PREP_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PREP_DESCRIPCION)
                    Case "TIPO_RESPUESTA"
                        query = query.OrderByDescending(Function(x) x.TIPO_RESPUESTA)
                End Select
            End If

            Return query.ToList
        End Function

        Public Shared Function BuscarPorReserva(Optional ByVal RESE_ID As Int32? = Nothing, _
             Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PREPARATIVO)
            Try
                BuscarPorReserva = DataLayer.DAL.PREPARATIVO.BuscarPorReserva(vRESE_ID:=RESE_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function



        Public Shared Function Buscar(Optional ByVal vPREP_ID As Int32? = Nothing, _
           Optional ByVal vCLI_ID As String = Nothing, _
           Optional ByVal vPREP_DESCRIPCION As String = Nothing, _
           Optional ByVal vTIPO_RESPUESTA As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PREPARATIVO)
            Try
                Buscar = DataLayer.DAL.PREPARATIVO.Buscar(vPREP_ID:=vPREP_ID, vCLI_ID:=vCLI_ID, vPREP_DESCRIPCION:=vPREP_DESCRIPCION, vTIPO_RESPUESTA:=vTIPO_RESPUESTA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vPREPARATIVO As EntityLayer.EL.PREPARATIVO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PREPARATIVO.Guardar(vPREPARATIVO:=vPREPARATIVO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vPREPARATIVO As EntityLayer.EL.PREPARATIVO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PREPARATIVO.Eliminar(vPREPARATIVO:=vPREPARATIVO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPREP_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PREPARATIVO
            Dim vL As List(Of EntityLayer.EL.PREPARATIVO)
            vL = Buscar(vPREP_ID:=vPREP_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function

        Public Shared Function BuscarPreparativoCheckList(Optional ByVal vCLI_ID As String = Nothing, _
          Optional ByVal vEXAMENES_ID As String = Nothing, _
      Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PREPARATIVO)
            Try
                BuscarPreparativoCheckList = DataLayer.DAL.PREPARATIVO.BuscarPreparativoCheckList(vCLI_ID:=vCLI_ID, vEXAMENES_ID:=vEXAMENES_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function



    End Class


End Namespace

