Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class FICHA_ITEM


        Public Shared Function BuscarFichaItem_Tipo(Optional ByVal vESP_ID As Int32? = Nothing, _
                                                     Optional ByVal vFITE_DESCRIPCION As String = Nothing, _
                                                     Optional ByVal vFIGR_ID As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_ITEM)
            Try
                BuscarFichaItem_Tipo = DataLayer.DAL.FICHA_ITEM.BuscarFichaItem_Tipo(vESP_ID:=vESP_ID, vFITE_DESCRIPCION:=vFITE_DESCRIPCION, vFIGR_ID:=vFIGR_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function buscarFichaItemAutocomplete(
                                                             Optional ByVal vFIGR_ID As Int32? = Nothing, _
                                                            Optional ByVal vFITE_DESCRIPCION As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_ITEM)
            Try
                buscarFichaItemAutocomplete = DataLayer.DAL.FICHA_ITEM.buscarFichaItemAutocomplete(vFITE_DESCRIPCION:=vFITE_DESCRIPCION, vFIGR_ID:=vFIGR_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarItemsExamenFisicoGeneral(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                               Optional ByVal vCLI_ID As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_ITEM)
            Try
                BuscarItemsExamenFisicoGeneral = DataLayer.DAL.FICHA_ITEM.BuscarItemsExamenFisicoGeneral(vUSU_ID:=vUSU_ID, vCLI_ID:=vCLI_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function BuscarItemsFichaItem(Optional ByVal vFITE_ID As Int32? = Nothing, _
                                                    Optional ByVal vFIGR_ID As Int32? = Nothing, _
                                                    Optional ByVal vCLI_ID As Int32? = Nothing, _
     Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_ITEM)
            Try
                BuscarItemsFichaItem = DataLayer.DAL.FICHA_ITEM.BuscarItemsFichaItem(vFITE_ID:=vFITE_ID, vFIGR_ID:=vFIGR_ID)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function sortList_FichaItem(ByVal order As String, _
                                         ByVal col As String, _
                                         ByVal vLista As List(Of EntityLayer.EL.FICHA_ITEM)) As List(Of EntityLayer.EL.FICHA_ITEM)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "FITE_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.FITE_DESCRIPCION)
                    Case "FITE_ADD_OBLIGATORIO"
                        query = query.OrderBy(Function(x) x.FITE_ADD_OBLIGATORIO)
                    Case "FITE_ADD_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FITE_ADD_OBSERVACION)
                    Case "FITE_VALIDAR_DOMINIO"
                        query = query.OrderBy(Function(x) x.FITE_VALIDAR_DOMINIO)
                    Case "TFIT_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.TFIT_DESCRIPCION)
                    Case "FITE_UNME"
                        query = query.OrderBy(Function(x) x.FITE_UNME)

                    Case "FIGR_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.FIGR_DESCRIPCION)
                End Select
            Else
                Select Case col
                    Case "FITE_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.FITE_DESCRIPCION)
                    Case "FITE_ADD_OBLIGATORIO"
                        query = query.OrderByDescending(Function(x) x.FITE_ADD_OBLIGATORIO)
                    Case "FITE_ADD_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FITE_ADD_OBSERVACION)
                    Case "FITE_VALIDAR_DOMINIO"
                        query = query.OrderByDescending(Function(x) x.FITE_VALIDAR_DOMINIO)
                    Case "TFIT_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.TFIT_DESCRIPCION)
                    Case "FITE_UNME"
                        query = query.OrderByDescending(Function(x) x.FITE_UNME)

                    Case "FIGR_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.FIGR_DESCRIPCION)
                End Select
            End If

            Return query.ToList
        End Function


        Public Shared Function Buscar(Optional ByVal vFITE_ID As Int32? = Nothing, _
       Optional ByVal vTFIT_ID As Int32? = Nothing, _
       Optional ByVal vFIGR_ID As Int32? = Nothing, _
       Optional ByVal vFITE_DESCRIPCION As String = Nothing, _
       Optional ByVal vFITE_ADD_OBLIGATORIO As Boolean? = Nothing, _
       Optional ByVal vFITE_ADD_OBSERVACION As Boolean? = Nothing, _
       Optional ByVal vFITE_VALIDAR_DOMINIO As Boolean? = Nothing, _
       Optional ByVal vCLI_ID As String = Nothing, _
   Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_ITEM)
            Try
                Buscar = DataLayer.DAL.FICHA_ITEM.Buscar(vFITE_ID:=vFITE_ID, vTFIT_ID:=vTFIT_ID, vFIGR_ID:=vFIGR_ID, vFITE_DESCRIPCION:=vFITE_DESCRIPCION, vFITE_ADD_OBLIGATORIO:=vFITE_ADD_OBLIGATORIO, vFITE_ADD_OBSERVACION:=vFITE_ADD_OBSERVACION, vFITE_VALIDAR_DOMINIO:=vFITE_VALIDAR_DOMINIO, vCLI_ID:=vCLI_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function



        Public Shared Sub Guardar(ByVal vFICHA_ITEM As EntityLayer.EL.FICHA_ITEM, _
                                  ByVal vCLI_ID As String, _
                                  Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.FICHA_ITEM.Guardar(vFICHA_ITEM:=vFICHA_ITEM, vCLI_ID:=vCLI_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vFICHA_ITEM As EntityLayer.EL.FICHA_ITEM, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.FICHA_ITEM.Eliminar(vFICHA_ITEM:=vFICHA_ITEM, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vFITE_ID As Int32? = Nothing, _
                                            Optional ByVal vCLI_ID As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.FICHA_ITEM
            Dim vL As List(Of EntityLayer.EL.FICHA_ITEM)
            If vFITE_ID.HasValue Then
                vL = Buscar(vFITE_ID:=vFITE_ID, vCLI_ID:=vCLI_ID, _
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

