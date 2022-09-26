Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class HOS_VAL_CSA


        Public Shared Function Buscar(Optional ByVal vHVAL_ID As Int32? = Nothing, _
           Optional ByVal vPAAT_ID As Int32? = Nothing, _
           Optional ByVal vFICHA_RDP As Decimal? = Nothing, _
           Optional ByVal vTIP_RDP As String = Nothing, _
           Optional ByVal vCOD_GPR As Int32? = Nothing, _
           Optional ByVal vSUB_PRE As Int32? = Nothing, _
           Optional ByVal vNUM_PRE As Int32? = Nothing, _
           Optional ByVal vURG_PRE As Int32? = Nothing, _
           Optional ByVal vCOD_TMO As Int32? = Nothing, _
           Optional ByVal vAFE_IS_VAL As Int32? = Nothing, _
           Optional ByVal vIVA_IS_VAL As Int32? = Nothing, _
           Optional ByVal vEXE_IS_VAL As Int32? = Nothing, _
           Optional ByVal vAFE_FON_VAL As Int32? = Nothing, _
           Optional ByVal vIVA_FON_VAL As Int32? = Nothing, _
           Optional ByVal vEXE_FON_VAL As Int32? = Nothing, _
           Optional ByVal vAFE_PAR_VAL As Int32? = Nothing, _
           Optional ByVal vIVA_PAR_VAL As Int32? = Nothing, _
           Optional ByVal vEXE_PAR_VAL As Int32? = Nothing, _
           Optional ByVal vAFE_FONI_VAL As Int32? = Nothing, _
           Optional ByVal vIVA_FONI_VAL As Int32? = Nothing, _
           Optional ByVal vEXE_FONI_VAL As Int32? = Nothing, _
           Optional ByVal vAFE_ISI_VAL As Int32? = Nothing, _
           Optional ByVal vIVA_ISI_VAL As Int32? = Nothing, _
           Optional ByVal vEXE_ISI_VAL As Int32? = Nothing, _
           Optional ByVal vAFE_PARI_VAL As Int32? = Nothing, _
           Optional ByVal vIVA_PARI_VAL As Int32? = Nothing, _
           Optional ByVal vEXE_PARI_VAL As Int32? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.HOS_VAL_CSA)
            Try
                Buscar = DataLayer.DAL.HOS_VAL_CSA.Buscar(vHVAL_ID:=vHVAL_ID, vPAAT_ID:=vPAAT_ID, vFICHA_RDP:=vFICHA_RDP, vTIP_RDP:=vTIP_RDP, vCOD_GPR:=vCOD_GPR, vSUB_PRE:=vSUB_PRE, vNUM_PRE:=vNUM_PRE, vURG_PRE:=vURG_PRE, vCOD_TMO:=vCOD_TMO, vAFE_IS_VAL:=vAFE_IS_VAL, vIVA_IS_VAL:=vIVA_IS_VAL, vEXE_IS_VAL:=vEXE_IS_VAL, vAFE_FON_VAL:=vAFE_FON_VAL, vIVA_FON_VAL:=vIVA_FON_VAL, vEXE_FON_VAL:=vEXE_FON_VAL, vAFE_PAR_VAL:=vAFE_PAR_VAL, vIVA_PAR_VAL:=vIVA_PAR_VAL, vEXE_PAR_VAL:=vEXE_PAR_VAL, vAFE_FONI_VAL:=vAFE_FONI_VAL, vIVA_FONI_VAL:=vIVA_FONI_VAL, vEXE_FONI_VAL:=vEXE_FONI_VAL, vAFE_ISI_VAL:=vAFE_ISI_VAL, vIVA_ISI_VAL:=vIVA_ISI_VAL, vEXE_ISI_VAL:=vEXE_ISI_VAL, vAFE_PARI_VAL:=vAFE_PARI_VAL, vIVA_PARI_VAL:=vIVA_PARI_VAL, vEXE_PARI_VAL:=vEXE_PARI_VAL, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function


        Public Shared Sub Guardar(ByVal vHOS_VAL_CSA As EntityLayer.EL.HOS_VAL_CSA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.HOS_VAL_CSA.Guardar(vHOS_VAL_CSA:=vHOS_VAL_CSA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        'Public Shared Sub GuardarPagos(ByVal vPAGO_ATENCION As EntityLayer.EL.PAGO_ATENCION, Optional ByVal vCon As Conexion = Nothing)
        '    Try
        '        DataLayer.DAL.HOS_VAL_CSA.GuardarPagos(vPAGO_ATENCION:=vPAGO_ATENCION, vCon:=vCon)
        '    Catch vEx As Exception
        '        Throw New Exception(vEx.Message, vEx)
        '    End Try

        'End Sub

        Public Shared Sub Eliminar(ByVal vHOS_VAL_CSA As EntityLayer.EL.HOS_VAL_CSA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.HOS_VAL_CSA.Eliminar(vHOS_VAL_CSA:=vHOS_VAL_CSA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vHVAL_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.HOS_VAL_CSA
            Dim vL As List(Of EntityLayer.EL.HOS_VAL_CSA)
            vL = Buscar(vHVAL_ID:=vHVAL_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

