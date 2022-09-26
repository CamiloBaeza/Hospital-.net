Imports System
Imports System.Collections
Imports System.Configuration
Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class EXAMEN


        Public Shared Function Buscar(Optional ByVal vEXA_ID As Int32? = Nothing, _
       Optional ByVal vEXA_DESCRIPCION As String = Nothing, _
        Optional ByVal vCLI_ID As String = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            Buscar = DataLayer.DAL.EXAMEN.Buscar(vEXA_ID, vEXA_DESCRIPCION, vCLI_ID:=vCLI_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Function BuscarExamenesByExamens_id(Optional ByVal vEXAMENES_ID As String = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            BuscarExamenesByExamens_id = DataLayer.DAL.EXAMEN.BuscarExamenesByExamenes_id(vEXAMENES_ID:=vEXAMENES_ID)
        End Function


        Public Shared Function BuscarByClinica(Optional ByVal vEXA_ID As Int32? = Nothing, _
       Optional ByVal vEXA_DESCRIPCION As String = Nothing, _
       Optional ByVal vCOD_GPR As Int32? = Nothing, _
       Optional ByVal vSUB_PRE As Int32? = Nothing, _
       Optional ByVal vNUM_PRE As Int32? = Nothing, _
       Optional ByVal vURG_PRE As Int32? = Nothing, _
       Optional ByVal vCLI_ID As String = Nothing, _
       Optional ByVal vTPRE_ID As Int32? = Nothing, _
       Optional ByVal vPENDIENTE_INGRESO As Boolean = Nothing, _
       Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            BuscarByClinica = DataLayer.DAL.EXAMEN.BuscarByClinica(vEXA_ID:=vEXA_ID, vEXA_DESCRIPCION:=vEXA_DESCRIPCION, vCOD_GPR:=vCOD_GPR, vSUB_PRE:=vSUB_PRE, vNUM_PRE:=vNUM_PRE, vURG_PRE:=vURG_PRE, vCLI_ID:=vCLI_ID, vTPRE_ID:=vTPRE_ID, vPENDIENTE_INGRESO:=vPENDIENTE_INGRESO, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function
        'Listar examen
        Public Shared Function ListarExamen(Optional ByVal vEXA_ID As Int32? = Nothing, _
        Optional ByVal vEXA_DESCRIPCION As String = Nothing, _
        Optional ByVal vCOD_GPR As Int32? = Nothing, _
        Optional ByVal vSUB_PRE As Int32? = Nothing, _
        Optional ByVal vNUM_PRE As Int32? = Nothing, _
        Optional ByVal vURG_PRE As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            ListarExamen = DataLayer.DAL.EXAMEN.ListarExamen(vEXA_ID, vEXA_DESCRIPCION, vCOD_GPR:=vCOD_GPR, vSUB_PRE:=vSUB_PRE, vNUM_PRE:=vNUM_PRE, vURG_PRE:=vURG_PRE, vCon:=vCon, vControlEstado:=vControlEstado)
        End Function

        Public Shared Sub GuardarEspecialidadExamen(ByVal vEXAMEN As EntityLayer.EL.EXAMEN,
                                   Optional ByVal vCLI_ID As String = Nothing, _
                                Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.EXAMEN.GuardarEspecialidadExamen(vEXAMEN, vCLI_ID:=vCLI_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Sub


        Public Shared Sub Guardar(ByVal vEXAMEN As EntityLayer.EL.EXAMEN,
                                     Optional ByVal vCLI_ID As String = Nothing, _
                                  Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.EXAMEN.Guardar(vEXAMEN, vCLI_ID:=vCLI_ID, vCon:=vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Sub Eliminar(ByVal vEXAMEN As EntityLayer.EL.EXAMEN, Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing)
            DataLayer.DAL.EXAMEN.Eliminar(vEXAMEN, vCon, vControlEstado:=vControlEstado)
        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vEXA_ID As Int32? = Nothing, _
                                              Optional ByVal vCLI_ID As String = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.EXAMEN
            Dim vL As List(Of EntityLayer.EL.EXAMEN)
            vL = Buscar(vEXA_ID:=vEXA_ID, _
                        vCLI_ID:=vCLI_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function


        Public Shared Function sortList_EXAMEN(ByVal order As String, _
                                              ByVal col As String, _
                                              ByVal vLista As List(Of EntityLayer.EL.EXAMEN)) As List(Of EntityLayer.EL.EXAMEN)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col
                    Case "EXA_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderBy(Function(x) x.EXA_ID)
                End Select
            Else
                Select Case col
                    Case "EXA_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.EXA_DESCRIPCION)
                    Case "EXA_ID"
                        query = query.OrderByDescending(Function(x) x.EXA_ID)
                End Select
            End If

            Return query.ToList
        End Function


        Public Shared Function BuscarExamenFichaMedicaPersonal(Optional ByVal vUSU_ID As Int32? = Nothing, _
                                                                   Optional ByVal vCOD_GPR As String = Nothing, _
   Optional ByVal vEXA_DESCRIPCION As String = Nothing, _
   Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            BuscarExamenFichaMedicaPersonal = DataLayer.DAL.EXAMEN.BuscarExamenFichaMedicaPersonal(vUSU_ID:=vUSU_ID, vCOD_GPR:=vCOD_GPR)
        End Function

        Public Shared Function BuscarExamenesAutoComplete(Optional ByVal vEXA_DESCRIPCION As String = Nothing, _
                                                           Optional ByVal vCLI_ID As String = Nothing, _
     Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            BuscarExamenesAutoComplete = DataLayer.DAL.EXAMEN.BuscarExamenes(vEXA_DESCRIPCION:=vEXA_DESCRIPCION, vCLI_ID:=vCLI_ID)
        End Function

        Public Shared Function BuscarExamenesAutoCompleteByCOD_GPR(Optional ByVal vEXA_DESCRIPCION As String = Nothing, _
                                                          Optional ByVal vCOD_GPR As String = Nothing, _
    Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            BuscarExamenesAutoCompleteByCOD_GPR = DataLayer.DAL.EXAMEN.BuscarExamenesAutoCompleteByCOD_GPR(vEXA_DESCRIPCION:=vEXA_DESCRIPCION, vCOD_GPR:=vCOD_GPR)
        End Function

        Public Shared Function BuscarExamenesRPT_RecetaExamen(Optional ByVal vFIME_ID As Int32? = Nothing, _
                                                          Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.EXAMEN)
            BuscarExamenesRPT_RecetaExamen = DataLayer.DAL.EXAMEN.BuscarExamenesRPT_RecetaExamen(vFIME_ID:=vFIME_ID)
        End Function

    End Class

End Namespace

