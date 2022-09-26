Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class EXAMEN_CLINICA


        Public Shared Function Buscar(Optional ByVal vEXA_ID As Short? = Nothing, _
           Optional ByVal vCLI_ID As String = Nothing, _
           Optional ByVal vTPRE_ID As Decimal? = Nothing, _
           Optional ByVal vEXA_RUTA_INDICACIONES As String = Nothing, _
           Optional ByVal vEXA_CANTIDAD_BLOQUES As Decimal? = Nothing, _
           Optional ByVal vEXA_VALOR As Decimal? = Nothing, _
           Optional ByVal vEXA_OBSERVACIONES As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.EXAMEN_CLINICA)
            Try
                Buscar = DataLayer.DAL.EXAMEN_CLINICA.Buscar(vEXA_ID:=vEXA_ID, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vEXA_RUTA_INDICACIONES:=vEXA_RUTA_INDICACIONES, vEXA_CANTIDAD_BLOQUES:=vEXA_CANTIDAD_BLOQUES, vEXA_VALOR:=vEXA_VALOR, vEXA_OBSERVACIONES:=vEXA_OBSERVACIONES, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vEXAMEN_CLINICA As EntityLayer.EL.EXAMEN_CLINICA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.EXAMEN_CLINICA.Guardar(vEXAMEN_CLINICA:=vEXAMEN_CLINICA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vEXAMEN_CLINICA As EntityLayer.EL.EXAMEN_CLINICA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.EXAMEN_CLINICA.Eliminar(vEXAMEN_CLINICA:=vEXAMEN_CLINICA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vEXA_ID As Short? = Nothing, _
       Optional ByVal vCLI_ID As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.EXAMEN_CLINICA
            Dim vL As List(Of EntityLayer.EL.EXAMEN_CLINICA)
            vL = Buscar(vEXA_ID:=vEXA_ID, _
           vCLI_ID:=vCLI_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function




        Public Shared Function sortList_EXAMEN_CLINICA(ByVal order As String, _
                                             ByVal col As String, _
                                             ByVal vLista As List(Of EntityLayer.EL.EXAMEN_CLINICA)) As List(Of EntityLayer.EL.EXAMEN_CLINICA)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "CLI_ID"
                        query = query.OrderBy(Function(x) x.CLI_ID)
                    Case "EXA_CANTIDAD_BLOQUES"
                        query = query.OrderBy(Function(x) x.EXA_CANTIDAD_BLOQUES)
                    Case "EXA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderBy(Function(x) x.EXA_ID)
                    Case "EXA_OBSERVACIONES"
                        query = query.OrderBy(Function(x) x.EXA_OBSERVACIONES)
                    Case "EXA_RUTA_INDICACIONES"
                        query = query.OrderBy(Function(x) x.EXA_RUTA_INDICACIONES)
                    Case "EXA_VALOR"
                        query = query.OrderBy(Function(x) x.EXA_VALOR)
                    Case "TPRE_ID"
                        query = query.OrderBy(Function(x) x.TPRE_ID)
                End Select
            Else
                Select Case col
                    Case "CLI_ID"
                        query = query.OrderByDescending(Function(x) x.CLI_ID)
                    Case "EXA_CANTIDAD_BLOQUES"
                        query = query.OrderByDescending(Function(x) x.EXA_CANTIDAD_BLOQUES)
                    Case "EXA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderByDescending(Function(x) x.EXA_ID)
                    Case "EXA_OBSERVACIONES"
                        query = query.OrderByDescending(Function(x) x.EXA_OBSERVACIONES)
                    Case "EXA_RUTA_INDICACIONES"
                        query = query.OrderByDescending(Function(x) x.EXA_RUTA_INDICACIONES)
                    Case "EXA_VALOR"
                        query = query.OrderByDescending(Function(x) x.EXA_VALOR)
                    Case "TPRE_ID"
                        query = query.OrderByDescending(Function(x) x.TPRE_ID)
                End Select
            End If
            Return query.ToList
        End Function
    End Class


End Namespace

