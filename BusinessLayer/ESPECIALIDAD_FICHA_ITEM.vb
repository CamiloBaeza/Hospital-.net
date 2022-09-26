Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL 
   Public Class ESPECIALIDAD_FICHA_ITEM
 
 
        Public Shared Function Buscar(Optional ByVal vFITE_ID As Int32? = Nothing, _
           Optional ByVal vESP_ID As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM)
            Try
                Buscar = DataLayer.DAL.ESPECIALIDAD_FICHA_ITEM.Buscar(vFITE_ID:=vFITE_ID, vESP_ID:=vESP_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function sortList_EspecialidadFichaItem(ByVal order As String, _
                                        ByVal col As String, _
                                        ByVal vLista As List(Of EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM)) As List(Of EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "FITE_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.FITE_DESCRIPCION)
                    Case "ESP_ID"
                        query = query.OrderBy(Function(x) x.ESP_ID)
                End Select
            Else
                Select Case col
                    Case "FITE_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.FITE_DESCRIPCION)
                    Case "ESP_ID"
                        query = query.OrderByDescending(Function(x) x.ESP_ID)
                End Select
            End If

            Return query.ToList
        End Function


        Public Shared Function BuscarEspecialidadFichaItemConfig(
            Optional ByVal vFITE_ID As Int32? = Nothing, _
           Optional ByVal vCLI_ID As Int32? = Nothing, _
           Optional ByVal vESP_ID As Int32? = Nothing, _
           Optional ByVal vCONFIGURADO As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM)
            Try
                BuscarEspecialidadFichaItemConfig = DataLayer.DAL.ESPECIALIDAD_FICHA_ITEM.BuscarEspecialidadFichaItemConfig(vFITE_ID:=vFITE_ID, vESP_ID:=vESP_ID, vCon:=vCon, vCLI_ID:=vCLI_ID, vCONFIGURADO:=vCONFIGURADO)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vESPECIALIDAD_FICHA_ITEM As EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.ESPECIALIDAD_FICHA_ITEM.Guardar(vESPECIALIDAD_FICHA_ITEM:=vESPECIALIDAD_FICHA_ITEM, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vESPECIALIDAD_FICHA_ITEM As EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.ESPECIALIDAD_FICHA_ITEM.Eliminar(vESPECIALIDAD_FICHA_ITEM:=vESPECIALIDAD_FICHA_ITEM, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vFITE_ID As Int32? = Nothing, _
       Optional ByVal vESP_ID As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM
            Dim vL As List(Of EntityLayer.EL.ESPECIALIDAD_FICHA_ITEM)
            vL = Buscar(vFITE_ID:=vFITE_ID, _
           vESP_ID:=vESP_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

