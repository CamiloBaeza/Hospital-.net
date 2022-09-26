Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class MEDICAMENTO


        Public Shared Function Buscar(Optional ByVal vMEDI_ID As Int32? = Nothing, _
           Optional ByVal vPPCT_ID As Int32? = Nothing, _
           Optional ByVal vPMED_ID As Int32? = Nothing, _
           Optional ByVal vMEDI_NOMBRE_COMERCIAL As String = Nothing, _
           Optional ByVal vMEDI_CONCENTRACION As String = Nothing, _
           Optional ByVal vMEDI_LABORATORIO As String = Nothing, _
           Optional ByVal vMEDI_BIOEQUIVALENTE As Boolean? = Nothing, _
           Optional ByVal vMEDI_GENERICO As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.MEDICAMENTO)
            Try
                Buscar = DataLayer.DAL.MEDICAMENTO.Buscar(vMEDI_ID:=vMEDI_ID, vPPCT_ID:=vPPCT_ID, vPMED_ID:=vPMED_ID, vMEDI_NOMBRE_COMERCIAL:=vMEDI_NOMBRE_COMERCIAL, vMEDI_CONCENTRACION:=vMEDI_CONCENTRACION, vMEDI_LABORATORIO:=vMEDI_LABORATORIO, vMEDI_BIOEQUIVALENTE:=vMEDI_BIOEQUIVALENTE, vMEDI_GENERICO:=vMEDI_GENERICO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Function sortList_Medicamento(ByVal order As String, _
                                      ByVal col As String, _
                                      ByVal vLista As List(Of EntityLayer.EL.MEDICAMENTO)) As List(Of EntityLayer.EL.MEDICAMENTO)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "MEDI_NOMBRE_COMERCIAL"
                        query = query.OrderBy(Function(x) x.MEDI_NOMBRE_COMERCIAL)
                    Case "MEDI_CONCENTRACION"
                        query = query.OrderBy(Function(x) x.MEDI_CONCENTRACION)
                    Case "MEDI_LABORATORIO"
                        query = query.OrderBy(Function(x) x.MEDI_LABORATORIO)
                    Case "MEDI_BIOEQUIVALENTE"
                        query = query.OrderBy(Function(x) x.MEDI_BIOEQUIVALENTE)
                    Case "MEDI_GENERICO"
                        query = query.OrderBy(Function(x) x.MEDI_GENERICO)
                End Select
            Else
                Select Case col
                    Case "MEDI_NOMBRE_COMERCIAL"
                        query = query.OrderByDescending(Function(x) x.MEDI_NOMBRE_COMERCIAL)
                    Case "MEDI_CONCENTRACION"
                        query = query.OrderByDescending(Function(x) x.MEDI_CONCENTRACION)
                    Case "MEDI_LABORATORIO"
                        query = query.OrderByDescending(Function(x) x.MEDI_LABORATORIO)
                    Case "MEDI_BIOEQUIVALENTE"
                        query = query.OrderByDescending(Function(x) x.MEDI_BIOEQUIVALENTE)
                    Case "MEDI_GENERICO"
                        query = query.OrderByDescending(Function(x) x.MEDI_GENERICO)
                End Select
            End If

            Return query.ToList
        End Function



        Public Shared Function BuscarMedicamentoAutoComplete(Optional ByVal vPPCT_ID As Int32? = Nothing, _
           Optional ByVal vMEDI_NOMBRE_COMERCIAL As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.MEDICAMENTO)
            Try
                BuscarMedicamentoAutoComplete = DataLayer.DAL.MEDICAMENTO.BuscarMedicamentoAutoComplete(vMEDI_NOMBRE_COMERCIAL:=vMEDI_NOMBRE_COMERCIAL, vPPCT_ID:=vPPCT_ID, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vMEDICAMENTO As EntityLayer.EL.MEDICAMENTO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MEDICAMENTO.Guardar(vMEDICAMENTO:=vMEDICAMENTO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vMEDICAMENTO As EntityLayer.EL.MEDICAMENTO, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.MEDICAMENTO.Eliminar(vMEDICAMENTO:=vMEDICAMENTO, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vMEDI_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.MEDICAMENTO
            If vMEDI_ID.HasValue Then
                Dim vL As List(Of EntityLayer.EL.MEDICAMENTO)
                vL = Buscar(vMEDI_ID:=vMEDI_ID, _
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

