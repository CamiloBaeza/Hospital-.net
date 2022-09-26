Imports System
Imports System.Collections
Imports System.Configuration
Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class PROCEDIMIENTO

        Public Shared Function Buscar(Optional ByVal vPROC_ID As Int32? = Nothing, _
           Optional ByVal vCOD_GRP As Int32? = Nothing, _
           Optional ByVal vSUB_PRE As Int32? = Nothing, _
           Optional ByVal vNUM_PRE As Int32? = Nothing, _
           Optional ByVal vURG_PRE As Int32? = Nothing, _
               Optional ByVal vPROC_VIGENTE As Int32? = Nothing, _
           Optional ByVal vPROC_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PROCEDIMIENTO)
            Try
                Buscar = DataLayer.DAL.PROCEDIMIENTO.Buscar(vPROC_VIGENTE:=vPROC_VIGENTE, vPROC_ID:=vPROC_ID, vCOD_GRP:=vCOD_GRP, vSUB_PRE:=vSUB_PRE, vNUM_PRE:=vNUM_PRE, vURG_PRE:=vURG_PRE, vPROC_DESCRIPCION:=vPROC_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarAutoComplete(Optional ByVal vPROC_ID As Int32? = Nothing, _
   Optional ByVal vCOD_GRP As Int32? = Nothing, _
   Optional ByVal vSUB_PRE As Int32? = Nothing, _
   Optional ByVal vNUM_PRE As Int32? = Nothing, _
   Optional ByVal vURG_PRE As Int32? = Nothing, _
   Optional ByVal vPROC_DESCRIPCION As String = Nothing, _
Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.PROCEDIMIENTO)
            Try
                BuscarAutoComplete = DataLayer.DAL.PROCEDIMIENTO.BuscarAutoComplete(vPROC_ID:=vPROC_ID, vCOD_GRP:=vCOD_GRP, vSUB_PRE:=vSUB_PRE, vNUM_PRE:=vNUM_PRE, vURG_PRE:=vURG_PRE, vPROC_DESCRIPCION:=vPROC_DESCRIPCION, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function sortList_Procedimiento(ByVal order As String, _
                                          ByVal col As String, _
                                          ByVal vLista As List(Of EntityLayer.EL.PROCEDIMIENTO)) As List(Of EntityLayer.EL.PROCEDIMIENTO)
            Dim query = From v In vLista
            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "PROC_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PROC_DESCRIPCION)
                    Case "COD_GRP"
                        query = query.OrderBy(Function(x) x.COD_GRP)
                    Case "SUB_PRE"
                        query = query.OrderBy(Function(x) x.SUB_PRE)
                    Case "NUM_PRE"
                        query = query.OrderBy(Function(x) x.NUM_PRE)
                    Case "URG_PRE"
                        query = query.OrderBy(Function(x) x.URG_PRE)
                    Case "CODIGO_FONASA"
                        query = query.OrderBy(Function(x) x.CODIGO_FONASA)
                End Select
            Else
                Select Case col
                    Case "PROC_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PROC_DESCRIPCION)
                    Case "COD_GRP"
                        query = query.OrderByDescending(Function(x) x.COD_GRP)
                    Case "SUB_PRE"
                        query = query.OrderByDescending(Function(x) x.SUB_PRE)
                    Case "NUM_PRE"
                        query = query.OrderByDescending(Function(x) x.NUM_PRE)
                    Case "URG_PRE"
                        query = query.OrderByDescending(Function(x) x.URG_PRE)
                    Case "CODIGO_FONASA"
                        query = query.OrderByDescending(Function(x) x.CODIGO_FONASA)
                End Select
            End If

            Return query.ToList
        End Function





        Public Shared Sub Guardar(ByVal vPROCEDIMIENTO As EntityLayer.EL.PROCEDIMIENTO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PROCEDIMIENTO.Guardar(vPROCEDIMIENTO:=vPROCEDIMIENTO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vPROCEDIMIENTO As EntityLayer.EL.PROCEDIMIENTO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.PROCEDIMIENTO.Eliminar(vPROCEDIMIENTO:=vPROCEDIMIENTO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vPROC_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.PROCEDIMIENTO
            If vPROC_ID.HasValue Then
                Dim vL As List(Of EntityLayer.EL.PROCEDIMIENTO)
                vL = Buscar(vPROC_ID:=vPROC_ID, _
               vCon:=vCon)
                If vL IsNot Nothing AndAlso vL.Count = 1 Then
                    ObtenerPorId = vL(0)
                Else
                    ObtenerPorId = Nothing
                End If
            Else
                ObtenerPorId = Nothing
            End If
        End Function
    End Class


End Namespace

