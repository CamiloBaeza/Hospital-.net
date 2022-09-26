Imports System
Imports System.Collections
Imports System.Configuration

Imports DataLayer.DAL
Imports EntityLayer.EL
Imports Utilidades
Namespace BL
    Public Class FICHA_MEDICA
        Public Shared Function sortList(ByVal order As String, _
                                       ByVal col As String, _
                                       ByVal vLista As List(Of EntityLayer.EL.FICHA_MEDICA)) As List(Of EntityLayer.EL.FICHA_MEDICA)
            Dim query = From v In vLista

            If order.ToUpper = "ASC" Then
                Select Case col

                    Case "HDIAGNOSTICO"
                        query = query.OrderBy(Function(x) x.HDIAGNOSTICO)
                    Case "FIME_FP_INDI_INDICACION"
                        query = query.OrderBy(Function(x) x.FIME_FP_INDI_INDICACION)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PRES_DESCRIPCION)

                    Case "EXFI_GENERAL"
                        query = query.OrderBy(Function(x) x.EXFI_GENERAL)
                    Case "EXFI_SEGMENTARIO"
                        query = query.OrderBy(Function(x) x.EXFI_SEGMENTARIO)
                    Case "Existe"
                        query = query.OrderBy(Function(x) x.Existe)
                    Case "FIME_ALERG_ALIMENTO"
                        query = query.OrderBy(Function(x) x.FIME_ALERG_ALIMENTO)
                    Case "FIME_ALERG_LATEX"
                        query = query.OrderBy(Function(x) x.FIME_ALERG_LATEX)
                    Case "FIME_ALERG_MEDICAMENTO"
                        query = query.OrderBy(Function(x) x.FIME_ALERG_MEDICAMENTO)
                    Case "FIME_ALERG_MEDIO_CONT"
                        query = query.OrderBy(Function(x) x.FIME_ALERG_MEDIO_CONT)
                    Case "FIME_ALERG_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_ALERG_OBSERVACION)
                    Case "FIME_CLIN_GRUPO_Y_RH"
                        query = query.OrderBy(Function(x) x.FIME_CLIN_GRUPO_Y_RH)


                    Case "FIME_CLIN_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_CLIN_OBSERVACION)
                    Case "FIME_FECHA_ELIMINACION"
                        query = query.OrderBy(Function(x) x.FIME_FECHA_ELIMINACION)
                    Case "FIME_FECHA_FICHA_MEDICA"
                        query = query.OrderBy(Function(x) x.FIME_FECHA_FICHA_MEDICA)
                    Case "FIME_FECHA_REGISTRO"
                        query = query.OrderBy(Function(x) x.FIME_FECHA_REGISTRO)
                    Case "FIME_FP_DIAG_GES"
                        query = query.OrderBy(Function(x) x.FIME_FP_DIAG_GES)
                    Case "FIME_FP_DIAG_GES"
                        query = query.OrderBy(Function(x) x.FIME_FP_DIAG_GES)
                    Case "FIME_FP_DIAG_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_FP_DIAG_OBSERVACION)
                    Case "FIME_FP_EX_GEN_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_FP_EX_GEN_OBSERVACION)
                    Case "FIME_FP_EXA_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_FP_EXA_OBSERVACION)
                    Case "FIME_FP_INDI_BIOPSIA"
                        query = query.OrderBy(Function(x) x.FIME_FP_INDI_BIOPSIA)
                    Case "FIME_FP_INDI_FECHA_CONTROL"
                        query = query.OrderBy(Function(x) x.FIME_FP_INDI_FECHA_CONTROL)
                    Case "FIME_FP_INDI_INDICACION"
                        query = query.OrderBy(Function(x) x.FIME_FP_INDI_INDICACION)
                    Case "FIME_FP_INDI_LICENCIA"
                        query = query.OrderBy(Function(x) x.FIME_FP_INDI_LICENCIA)
                    Case "FIME_FP_MEDI_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_FP_MEDI_OBSERVACION)
                    Case "FIME_FP_MEXA_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_FP_MEXA_OBSERVACION)
                    Case "FIME_FP_MO_ANAMNESIS"
                        query = query.OrderBy(Function(x) x.FIME_FP_MO_ANAMNESIS)
                    Case "FIME_FP_MO_INFO_PRIVADA"
                        query = query.OrderBy(Function(x) x.FIME_FP_MO_INFO_PRIVADA)
                    Case "FIME_FP_MO_MOTIVO"
                        query = query.OrderBy(Function(x) x.FIME_FP_MO_MOTIVO)
                    Case "FIME_GES_CAEC"
                        query = query.OrderBy(Function(x) x.FIME_GES_CAEC)
                    Case "FIME_GES_FECHA"
                        query = query.OrderBy(Function(x) x.FIME_GES_FECHA)
                    Case "FIME_GES_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_GES_OBSERVACION)
                    Case "FIME_GES_PATOLOGIA"
                        query = query.OrderBy(Function(x) x.FIME_GES_PATOLOGIA)
                    Case "FIME_GINE_ABORTO"
                        query = query.OrderBy(Function(x) x.FIME_GINE_ABORTO)
                    Case "FIME_GINE_CICLOS"
                        query = query.OrderBy(Function(x) x.FIME_GINE_CICLOS)
                    Case "FIME_GINE_FUA"
                        query = query.OrderBy(Function(x) x.FIME_GINE_FUA)
                    Case "FIME_GINE_FUP"
                        query = query.OrderBy(Function(x) x.FIME_GINE_FUP)


                    Case "FIME_GINE_GESTA"
                        query = query.OrderBy(Function(x) x.FIME_GINE_GESTA)
                    Case "FIME_GINE_MAC"
                        query = query.OrderBy(Function(x) x.FIME_GINE_MAC)
                    Case "FIME_GINE_MENOPAUSIA"
                        query = query.OrderBy(Function(x) x.FIME_GINE_MENOPAUSIA)
                    Case "FIME_GINE_NAC_MUERTO"
                        query = query.OrderBy(Function(x) x.FIME_GINE_NAC_MUERTO)
                    Case "FIME_GINE_NAC_VIVO"
                        query = query.OrderBy(Function(x) x.FIME_GINE_NAC_VIVO)
                    Case "FIME_GINE_PAP"
                        query = query.OrderBy(Function(x) x.FIME_GINE_PAP)
                    Case "FIME_GINE_PARTO"
                        query = query.OrderBy(Function(x) x.FIME_GINE_PARTO)
                    Case "FIME_GINE_PESO"
                        query = query.OrderBy(Function(x) x.FIME_GINE_PESO)
                    Case "FIME_GINE_TIPO_PARTO"
                        query = query.OrderBy(Function(x) x.FIME_GINE_TIPO_PARTO)
                    Case "FIME_HABI_ACT_FISICA"
                        query = query.OrderBy(Function(x) x.FIME_HABI_ACT_FISICA)
                    Case "FIME_HABI_ALCOHOL"
                        query = query.OrderBy(Function(x) x.FIME_HABI_ALCOHOL)
                    Case "FIME_HABI_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_HABI_OBSERVACION)
                    Case "FIME_HABI_TABACO"
                        query = query.OrderBy(Function(x) x.FIME_HABI_TABACO)
                    Case "FIME_HORA_FIN"
                        query = query.OrderBy(Function(x) x.FIME_HORA_FIN)
                    Case "FIME_HORA_INI"
                        query = query.OrderBy(Function(x) x.FIME_HORA_INI)
                    Case "FIME_ID"
                        query = query.OrderBy(Function(x) x.FIME_ID)
                    Case "FIME_MORB_CARDIOLOGICO"
                        query = query.OrderBy(Function(x) x.FIME_MORB_CARDIOLOGICO)



                    Case "FIME_MORB_DIABETES"
                        query = query.OrderBy(Function(x) x.FIME_MORB_DIABETES)
                    Case "FIME_MORB_GENETICO"
                        query = query.OrderBy(Function(x) x.FIME_MORB_GENETICO)
                    Case "FIME_MORB_HIPERTENSION"
                        query = query.OrderBy(Function(x) x.FIME_MORB_HIPERTENSION)
                    Case "FIME_MORB_INMUNOLOGICO"
                        query = query.OrderBy(Function(x) x.FIME_MORB_INMUNOLOGICO)
                    Case "FIME_MORB_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_MORB_OBSERVACION)
                    Case "FIME_MORB_ONCOLOGICO"
                        query = query.OrderBy(Function(x) x.FIME_MORB_ONCOLOGICO)
                    Case "FIME_QUIRU_CIRUGIA_PREVIA"
                        query = query.OrderBy(Function(x) x.FIME_QUIRU_CIRUGIA_PREVIA)
                    Case "FIME_QUIRU_OBSERVACION"
                        query = query.OrderBy(Function(x) x.FIME_QUIRU_OBSERVACION)
                    Case "FIME_VIGENTE"
                        query = query.OrderBy(Function(x) x.FIME_VIGENTE)
                    Case "HDIAGNOSTICO"
                        query = query.OrderBy(Function(x) x.HDIAGNOSTICO)
                    Case "MUESTRAEXAMEN"
                        query = query.OrderBy(Function(x) x.MUESTRAEXAMEN)
                    Case "ORDENEXAMEN"
                        query = query.OrderBy(Function(x) x.ORDENEXAMEN)
                    Case "PAC_ID"
                        query = query.OrderBy(Function(x) x.PAC_ID)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderBy(Function(x) x.PRES_DESCRIPCION)
                    Case "PRES_ID"
                        query = query.OrderBy(Function(x) x.PRES_ID)
                    Case "PROCEDIMIENTO"
                        query = query.OrderBy(Function(x) x.PROCEDIMIENTO)
                    Case "RECEMEDIAMENTO"
                        query = query.OrderBy(Function(x) x.RECEMEDIAMENTO)


                    Case "RESE_ID"
                        query = query.OrderBy(Function(x) x.RESE_ID)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderBy(Function(x) x.USU_ID_ELIMINA)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderBy(Function(x) x.USU_ID_REGISTRA)


                End Select
            Else
                Select Case col

                    Case "HDIAGNOSTICO"
                        query = query.OrderByDescending(Function(x) x.HDIAGNOSTICO)

                    Case "FIME_FP_INDI_INDICACION"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_INDI_INDICACION)

                    Case "PRES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PRES_DESCRIPCION)


                    Case "EXFI_GENERAL"
                        query = query.OrderByDescending(Function(x) x.EXFI_GENERAL)
                    Case "EXFI_SEGMENTARIO"
                        query = query.OrderByDescending(Function(x) x.EXFI_SEGMENTARIO)
                    Case "Existe"
                        query = query.OrderByDescending(Function(x) x.Existe)
                    Case "FIME_ALERG_ALIMENTO"
                        query = query.OrderByDescending(Function(x) x.FIME_ALERG_ALIMENTO)
                    Case "FIME_ALERG_LATEX"
                        query = query.OrderByDescending(Function(x) x.FIME_ALERG_LATEX)
                    Case "FIME_ALERG_MEDICAMENTO"
                        query = query.OrderByDescending(Function(x) x.FIME_ALERG_MEDICAMENTO)
                    Case "FIME_ALERG_MEDIO_CONT"
                        query = query.OrderByDescending(Function(x) x.FIME_ALERG_MEDIO_CONT)
                    Case "FIME_ALERG_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_ALERG_OBSERVACION)
                    Case "FIME_CLIN_GRUPO_Y_RH"
                        query = query.OrderByDescending(Function(x) x.FIME_CLIN_GRUPO_Y_RH)


                    Case "FIME_CLIN_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_CLIN_OBSERVACION)
                    Case "FIME_FECHA_ELIMINACION"
                        query = query.OrderBy(Function(x) x.FIME_FECHA_ELIMINACION)
                    Case "FIME_FECHA_FICHA_MEDICA"
                        query = query.OrderByDescending(Function(x) x.FIME_FECHA_FICHA_MEDICA)
                    Case "FIME_FECHA_REGISTRO"
                        query = query.OrderByDescending(Function(x) x.FIME_FECHA_REGISTRO)
                    Case "FIME_FP_DIAG_GES"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_DIAG_GES)
                    Case "FIME_FP_DIAG_GES"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_DIAG_GES)
                    Case "FIME_FP_DIAG_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_DIAG_OBSERVACION)
                    Case "FIME_FP_EX_GEN_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_EX_GEN_OBSERVACION)
                    Case "FIME_FP_EXA_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_EXA_OBSERVACION)
                    Case "FIME_FP_INDI_BIOPSIA"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_INDI_BIOPSIA)
                    Case "FIME_FP_INDI_FECHA_CONTROL"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_INDI_FECHA_CONTROL)
                    Case "FIME_FP_INDI_INDICACION"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_INDI_INDICACION)
                    Case "FIME_FP_INDI_LICENCIA"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_INDI_LICENCIA)
                    Case "FIME_FP_MEDI_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_MEDI_OBSERVACION)
                    Case "FIME_FP_MEXA_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_MEXA_OBSERVACION)
                    Case "FIME_FP_MO_ANAMNESIS"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_MO_ANAMNESIS)
                    Case "FIME_FP_MO_INFO_PRIVADA"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_MO_INFO_PRIVADA)
                    Case "FIME_FP_MO_MOTIVO"
                        query = query.OrderByDescending(Function(x) x.FIME_FP_MO_MOTIVO)
                    Case "FIME_GES_CAEC"
                        query = query.OrderByDescending(Function(x) x.FIME_GES_CAEC)
                    Case "FIME_GES_FECHA"
                        query = query.OrderByDescending(Function(x) x.FIME_GES_FECHA)
                    Case "FIME_GES_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_GES_OBSERVACION)
                    Case "FIME_GES_PATOLOGIA"
                        query = query.OrderByDescending(Function(x) x.FIME_GES_PATOLOGIA)
                    Case "FIME_GINE_ABORTO"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_ABORTO)
                    Case "FIME_GINE_CICLOS"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_CICLOS)
                    Case "FIME_GINE_FUA"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_FUA)
                    Case "FIME_GINE_FUP"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_FUP)


                    Case "FIME_GINE_GESTA"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_GESTA)
                    Case "FIME_GINE_MAC"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_MAC)
                    Case "FIME_GINE_MENOPAUSIA"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_MENOPAUSIA)
                    Case "FIME_GINE_NAC_MUERTO"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_NAC_MUERTO)
                    Case "FIME_GINE_NAC_VIVO"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_NAC_VIVO)
                    Case "FIME_GINE_PAP"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_PAP)
                    Case "FIME_GINE_PARTO"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_PARTO)
                    Case "FIME_GINE_PESO"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_PESO)
                    Case "FIME_GINE_TIPO_PARTO"
                        query = query.OrderByDescending(Function(x) x.FIME_GINE_TIPO_PARTO)
                    Case "FIME_HABI_ACT_FISICA"
                        query = query.OrderByDescending(Function(x) x.FIME_HABI_ACT_FISICA)
                    Case "FIME_HABI_ALCOHOL"
                        query = query.OrderByDescending(Function(x) x.FIME_HABI_ALCOHOL)
                    Case "FIME_HABI_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_HABI_OBSERVACION)
                    Case "FIME_HABI_TABACO"
                        query = query.OrderByDescending(Function(x) x.FIME_HABI_TABACO)
                    Case "FIME_HORA_FIN"
                        query = query.OrderByDescending(Function(x) x.FIME_HORA_FIN)
                    Case "FIME_HORA_INI"
                        query = query.OrderByDescending(Function(x) x.FIME_HORA_INI)
                    Case "FIME_ID"
                        query = query.OrderByDescending(Function(x) x.FIME_ID)
                    Case "FIME_MORB_CARDIOLOGICO"
                        query = query.OrderByDescending(Function(x) x.FIME_MORB_CARDIOLOGICO)



                    Case "FIME_MORB_DIABETES"
                        query = query.OrderByDescending(Function(x) x.FIME_MORB_DIABETES)
                    Case "FIME_MORB_GENETICO"
                        query = query.OrderByDescending(Function(x) x.FIME_MORB_GENETICO)
                    Case "FIME_MORB_HIPERTENSION"
                        query = query.OrderByDescending(Function(x) x.FIME_MORB_HIPERTENSION)
                    Case "FIME_MORB_INMUNOLOGICO"
                        query = query.OrderByDescending(Function(x) x.FIME_MORB_INMUNOLOGICO)
                    Case "FIME_MORB_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_MORB_OBSERVACION)
                    Case "FIME_MORB_ONCOLOGICO"
                        query = query.OrderByDescending(Function(x) x.FIME_MORB_ONCOLOGICO)
                    Case "FIME_QUIRU_CIRUGIA_PREVIA"
                        query = query.OrderByDescending(Function(x) x.FIME_QUIRU_CIRUGIA_PREVIA)
                    Case "FIME_QUIRU_OBSERVACION"
                        query = query.OrderByDescending(Function(x) x.FIME_QUIRU_OBSERVACION)
                    Case "FIME_VIGENTE"
                        query = query.OrderByDescending(Function(x) x.FIME_VIGENTE)
                    Case "HDIAGNOSTICO"
                        query = query.OrderByDescending(Function(x) x.HDIAGNOSTICO)
                    Case "MUESTRAEXAMEN"
                        query = query.OrderByDescending(Function(x) x.MUESTRAEXAMEN)
                    Case "ORDENEXAMEN"
                        query = query.OrderByDescending(Function(x) x.ORDENEXAMEN)
                    Case "PAC_ID"
                        query = query.OrderByDescending(Function(x) x.PAC_ID)
                    Case "PRES_DESCRIPCION"
                        query = query.OrderByDescending(Function(x) x.PRES_DESCRIPCION)
                    Case "PRES_ID"
                        query = query.OrderByDescending(Function(x) x.PRES_ID)
                    Case "PROCEDIMIENTO"
                        query = query.OrderByDescending(Function(x) x.PROCEDIMIENTO)
                    Case "RECEMEDIAMENTO"
                        query = query.OrderByDescending(Function(x) x.RECEMEDIAMENTO)


                    Case "RESE_ID"
                        query = query.OrderByDescending(Function(x) x.RESE_ID)
                    Case "USU_ID_ELIMINA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_ELIMINA)
                    Case "USU_ID_REGISTRA"
                        query = query.OrderByDescending(Function(x) x.USU_ID_REGISTRA)




                End Select
            End If

            Return query.ToList
        End Function

        Public Shared Function Buscar(Optional ByVal vFIME_ID As Int32? = Nothing, _
           Optional ByVal vPAC_ID As Int32? = Nothing, _
           Optional ByVal vPRES_ID As Decimal? = Nothing, _
           Optional ByVal vUSU_ID_REGISTRA As Int32? = Nothing, _
           Optional ByVal vUSU_ID_ELIMINA As Int32? = Nothing, _
           Optional ByVal vRESE_ID As Int32? = Nothing, _
           Optional ByVal vFIME_GES_PATOLOGIA As String = Nothing, _
           Optional ByVal vFIME_GES_FECHA As String = Nothing, _
           Optional ByVal vFIME_GES_CAEC As String = Nothing, _
           Optional ByVal vFIME_GES_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_MORB_DIABETES As String = Nothing, _
           Optional ByVal vFIME_MORB_HIPERTENSION As String = Nothing, _
           Optional ByVal vFIME_MORB_ONCOLOGICO As String = Nothing, _
           Optional ByVal vFIME_MORB_CARDIOLOGICO As String = Nothing, _
           Optional ByVal vFIME_MORB_INMUNOLOGICO As String = Nothing, _
           Optional ByVal vFIME_MORB_GENETICO As String = Nothing, _
           Optional ByVal vFIME_MORB_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_CLIN_GRUPO_Y_RH As String = Nothing, _
           Optional ByVal vFIME_CLIN_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_QUIRU_CIRUGIA_PREVIA As String = Nothing, _
           Optional ByVal vFIME_QUIRU_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_GINE_GESTA As String = Nothing, _
           Optional ByVal vFIME_GINE_PARTO As String = Nothing, _
           Optional ByVal vFIME_GINE_ABORTO As String = Nothing, _
           Optional ByVal vFIME_GINE_NAC_VIVO As String = Nothing, _
           Optional ByVal vFIME_GINE_NAC_MUERTO As String = Nothing, _
           Optional ByVal vFIME_GINE_TIPO_PARTO As String = Nothing, _
           Optional ByVal vFIME_GINE_MENOPAUSIA As String = Nothing, _
           Optional ByVal vFIME_GINE_FUP As String = Nothing, _
           Optional ByVal vFIME_GINE_FUA As String = Nothing, _
           Optional ByVal vFIME_GINE_CICLOS As String = Nothing, _
           Optional ByVal vFIME_GINE_PESO As String = Nothing, _
           Optional ByVal vFIME_GINE_MAC As String = Nothing, _
           Optional ByVal vFIME_GINE_PAP As String = Nothing, _
           Optional ByVal vFIME_HABI_TABACO As String = Nothing, _
           Optional ByVal vFIME_HABI_ALCOHOL As String = Nothing, _
           Optional ByVal vFIME_HABI_ACT_FISICA As String = Nothing, _
           Optional ByVal vFIME_HABI_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_ALERG_LATEX As String = Nothing, _
           Optional ByVal vFIME_ALERG_MEDICAMENTO As String = Nothing, _
           Optional ByVal vFIME_ALERG_MEDIO_CONT As String = Nothing, _
           Optional ByVal vFIME_ALERG_ALIMENTO As String = Nothing, _
           Optional ByVal vFIME_ALERG_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_FP_MO_MOTIVO As String = Nothing, _
           Optional ByVal vFIME_FP_MO_ANAMNESIS As String = Nothing, _
           Optional ByVal vFIME_FP_MO_INFO_PRIVADA As String = Nothing, _
           Optional ByVal vFIME_FP_EX_GEN_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_FP_DIAG_GES As Boolean? = Nothing, _
           Optional ByVal vFIME_FP_DIAG_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_FP_INDI_INDICACION As String = Nothing, _
           Optional ByVal vFIME_FP_INDI_FECHA_CONTROL As DateTime? = Nothing, _
           Optional ByVal vFIME_FP_INDI_LICENCIA As Boolean? = Nothing, _
           Optional ByVal vFIME_FP_INDI_BIOPSIA As Boolean? = Nothing, _
           Optional ByVal vFIME_FP_MEDI_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_FP_EXA_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_FP_MEXA_OBSERVACION As String = Nothing, _
           Optional ByVal vFIME_HORA_INI As TimeSpan? = Nothing, _
           Optional ByVal vFIME_HORA_FIN As TimeSpan? = Nothing, _
           Optional ByVal vFIME_FECHA_FICHA_MEDICA As DateTime? = Nothing, _
           Optional ByVal vFIME_FECHA_REGISTRO As DateTime? = Nothing, _
           Optional ByVal vFIME_FECHA_ELIMINACION As DateTime? = Nothing, _
           Optional ByVal vFIME_VIGENTE As Boolean? = Nothing, _
       Optional ByVal vCon As Conexion = Nothing) As List(Of EntityLayer.EL.FICHA_MEDICA)
            Try
                Buscar = DataLayer.DAL.FICHA_MEDICA.Buscar(vFIME_ID:=vFIME_ID, vPAC_ID:=vPAC_ID, vPRES_ID:=vPRES_ID, vUSU_ID_REGISTRA:=vUSU_ID_REGISTRA, vUSU_ID_ELIMINA:=vUSU_ID_ELIMINA, vRESE_ID:=vRESE_ID, vFIME_GES_PATOLOGIA:=vFIME_GES_PATOLOGIA, vFIME_GES_FECHA:=vFIME_GES_FECHA, vFIME_GES_CAEC:=vFIME_GES_CAEC, vFIME_GES_OBSERVACION:=vFIME_GES_OBSERVACION, vFIME_MORB_DIABETES:=vFIME_MORB_DIABETES, vFIME_MORB_HIPERTENSION:=vFIME_MORB_HIPERTENSION, vFIME_MORB_ONCOLOGICO:=vFIME_MORB_ONCOLOGICO, vFIME_MORB_CARDIOLOGICO:=vFIME_MORB_CARDIOLOGICO, vFIME_MORB_INMUNOLOGICO:=vFIME_MORB_INMUNOLOGICO, vFIME_MORB_GENETICO:=vFIME_MORB_GENETICO, vFIME_MORB_OBSERVACION:=vFIME_MORB_OBSERVACION, vFIME_CLIN_GRUPO_Y_RH:=vFIME_CLIN_GRUPO_Y_RH, vFIME_CLIN_OBSERVACION:=vFIME_CLIN_OBSERVACION, vFIME_QUIRU_CIRUGIA_PREVIA:=vFIME_QUIRU_CIRUGIA_PREVIA, vFIME_QUIRU_OBSERVACION:=vFIME_QUIRU_OBSERVACION, vFIME_GINE_GESTA:=vFIME_GINE_GESTA, vFIME_GINE_PARTO:=vFIME_GINE_PARTO, vFIME_GINE_ABORTO:=vFIME_GINE_ABORTO, vFIME_GINE_NAC_VIVO:=vFIME_GINE_NAC_VIVO, vFIME_GINE_NAC_MUERTO:=vFIME_GINE_NAC_MUERTO, vFIME_GINE_TIPO_PARTO:=vFIME_GINE_TIPO_PARTO, vFIME_GINE_MENOPAUSIA:=vFIME_GINE_MENOPAUSIA, vFIME_GINE_FUP:=vFIME_GINE_FUP, vFIME_GINE_FUA:=vFIME_GINE_FUA, vFIME_GINE_CICLOS:=vFIME_GINE_CICLOS, vFIME_GINE_PESO:=vFIME_GINE_PESO, vFIME_GINE_MAC:=vFIME_GINE_MAC, vFIME_GINE_PAP:=vFIME_GINE_PAP, vFIME_HABI_TABACO:=vFIME_HABI_TABACO, vFIME_HABI_ALCOHOL:=vFIME_HABI_ALCOHOL, vFIME_HABI_ACT_FISICA:=vFIME_HABI_ACT_FISICA, vFIME_HABI_OBSERVACION:=vFIME_HABI_OBSERVACION, vFIME_ALERG_LATEX:=vFIME_ALERG_LATEX, vFIME_ALERG_MEDICAMENTO:=vFIME_ALERG_MEDICAMENTO, vFIME_ALERG_MEDIO_CONT:=vFIME_ALERG_MEDIO_CONT, vFIME_ALERG_ALIMENTO:=vFIME_ALERG_ALIMENTO, vFIME_ALERG_OBSERVACION:=vFIME_ALERG_OBSERVACION, vFIME_FP_MO_MOTIVO:=vFIME_FP_MO_MOTIVO, vFIME_FP_MO_ANAMNESIS:=vFIME_FP_MO_ANAMNESIS, vFIME_FP_MO_INFO_PRIVADA:=vFIME_FP_MO_INFO_PRIVADA, vFIME_FP_EX_GEN_OBSERVACION:=vFIME_FP_EX_GEN_OBSERVACION, vFIME_FP_DIAG_GES:=vFIME_FP_DIAG_GES, vFIME_FP_DIAG_OBSERVACION:=vFIME_FP_DIAG_OBSERVACION, vFIME_FP_INDI_INDICACION:=vFIME_FP_INDI_INDICACION, vFIME_FP_INDI_FECHA_CONTROL:=vFIME_FP_INDI_FECHA_CONTROL, vFIME_FP_INDI_LICENCIA:=vFIME_FP_INDI_LICENCIA, vFIME_FP_INDI_BIOPSIA:=vFIME_FP_INDI_BIOPSIA, vFIME_FP_MEDI_OBSERVACION:=vFIME_FP_MEDI_OBSERVACION, vFIME_FP_EXA_OBSERVACION:=vFIME_FP_EXA_OBSERVACION, vFIME_FP_MEXA_OBSERVACION:=vFIME_FP_MEXA_OBSERVACION, vFIME_HORA_INI:=vFIME_HORA_INI, vFIME_HORA_FIN:=vFIME_HORA_FIN, vFIME_FECHA_FICHA_MEDICA:=vFIME_FECHA_FICHA_MEDICA, vFIME_FECHA_REGISTRO:=vFIME_FECHA_REGISTRO, vFIME_FECHA_ELIMINACION:=vFIME_FECHA_ELIMINACION, vFIME_VIGENTE:=vFIME_VIGENTE, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Function

        Public Shared Function BuscarFichaHistorial(Optional ByVal vPAC_ID As Int32? = Nothing, _
                                                    Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                                     Optional ByVal vUSU_ID As Decimal? = Nothing, _
                                                    Optional ByVal vFIME_ID As Int32? = Nothing, _
                                                    Optional ByVal vFIME_VIGENTE As Boolean? = Nothing, _
                                                    Optional ByVal vCLI_ID As String = Nothing, _
                                                    Optional ByVal vCon As Conexion = Nothing, _
                                                    Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FICHA_MEDICA)
            BuscarFichaHistorial = DataLayer.DAL.FICHA_MEDICA.BuscarFichaHistorial(vCLI_ID:=vCLI_ID, vUSU_ID:=vUSU_ID, vPAC_ID:=vPAC_ID, vPRES_ID:=vPRES_ID, vFIME_ID:=vFIME_ID, vFIME_VIGENTE:=vFIME_VIGENTE)
        End Function
        Public Shared Function BuscarFichaHistorialDigital(Optional ByVal vPAC_ID As Int32? = Nothing, _
                                            Optional ByVal vPRES_ID As Decimal? = Nothing, _
                                             Optional ByVal vUSU_ID As Decimal? = Nothing, _
                                             Optional ByVal vCLI_ID As String = Nothing, _
                                            Optional ByVal vFIME_VIGENTE As Boolean? = Nothing, _
                                            Optional ByVal vCon As Conexion = Nothing, _
                                                Optional ByVal vFIME_FP_DIAG_GES As Boolean? = Nothing, _
    Optional ByVal vFIME_FECHA_FICHA_MEDICA As DateTime? = Nothing, _
                                            Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FICHA_MEDICA)
            BuscarFichaHistorialDigital = DataLayer.DAL.FICHA_MEDICA.BuscarFichaHistorialDigital(vUSU_ID:=vUSU_ID, vPAC_ID:=vPAC_ID, vPRES_ID:=vPRES_ID, vCLI_ID:=vCLI_ID, vFIME_VIGENTE:=vFIME_VIGENTE, vFIME_FECHA_FICHA_MEDICA:=vFIME_FECHA_FICHA_MEDICA, vFIME_FP_DIAG_GES:=vFIME_FP_DIAG_GES)
        End Function

        Public Shared Function BuscarFichaMedicaPaciente(Optional ByVal vPAC_ID As Int32? = Nothing, _
  Optional ByVal vCon As Conexion = Nothing, Optional ByVal vControlEstado As Utilidades.ControlEstado = Nothing) As List(Of EntityLayer.EL.FICHA_MEDICA)
            BuscarFichaMedicaPaciente = DataLayer.DAL.FICHA_MEDICA.BuscarFichaMedicaPaciente(vPAC_ID, vControlEstado:=vControlEstado)
        End Function



        Public Shared Sub Guardar(ByVal vFICHA_MEDICA As EntityLayer.EL.FICHA_MEDICA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.FICHA_MEDICA.Guardar(vFICHA_MEDICA:=vFICHA_MEDICA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub


        Public Shared Sub GuardarFichaMedicaPaciente(ByVal vFICHA_MEDICA As EntityLayer.EL.FICHA_MEDICA, _
                                                     ByVal vXMLExamenFisicoEspecifico As String, _
                                                     ByVal vXMLExamenFisicoGeneral As String, _
                                                     ByVal vXMLRecetaExamen As String, _
                                                     ByVal vXMLHipotesisDiagnostica As String, _
                                                     ByVal vXMLResultadoExamen As String, _
                                                     ByVal vXMLRecetaMedicamento As String, _
                                                     ByVal vXMLProcedimiento As String, _
                                                     ByVal vFIME_B_ID_VIGENTE As Int32?, _
                                                           ByVal vXMLBiopsia As String, _
                                                    ByVal vCLI_ID As Int32?, _
                                                     Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.FICHA_MEDICA.GuardarFichaMedicaPaciente(vXMLRecetaExamen:=vXMLRecetaExamen, vFICHA_MEDICA:=vFICHA_MEDICA, vXMLExamenFisicoGeneral:=vXMLExamenFisicoGeneral, vXMLExamenFisicoEspecifico:=vXMLExamenFisicoEspecifico, vXMLHipotesisDiagnostica:=vXMLHipotesisDiagnostica, vXMLResultadoExamen:=vXMLResultadoExamen, vCon:=vCon, vXMLRecetaMedicamento:=vXMLRecetaMedicamento, vXMLProcedimiento:=vXMLProcedimiento, vFIME_B_ID_VIGENTE:=vFIME_B_ID_VIGENTE, vCLI_ID:=vCLI_ID, vXMLBiopsia:=vXMLBiopsia)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Sub Eliminar(ByVal vFICHA_MEDICA As EntityLayer.EL.FICHA_MEDICA, Optional ByVal vCon As Conexion = Nothing)
            Try
                DataLayer.DAL.FICHA_MEDICA.Eliminar(vFICHA_MEDICA:=vFICHA_MEDICA, vCon:=vCon)
            Catch vEx As Exception
                Throw New Exception(vEx.Message, vEx)
            End Try

        End Sub

        Public Shared Function ObtenerPorId(Optional ByVal vFIME_ID As Int32? = Nothing, _
        Optional ByVal vCon As Conexion = Nothing) As EntityLayer.EL.FICHA_MEDICA
            Dim vL As List(Of EntityLayer.EL.FICHA_MEDICA)
            vL = Buscar(vFIME_ID:=vFIME_ID, _
           vCon:=vCon)
            If vL IsNot Nothing AndAlso vL.Count = 1 Then
                ObtenerPorId = vL(0)
            Else
                ObtenerPorId = Nothing
            End If

        End Function
    End Class


End Namespace

