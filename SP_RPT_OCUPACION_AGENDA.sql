USE [clinicloud_DESA]
GO
/****** Object:  StoredProcedure [dbo].[[SP_RPT_OCUPACION_AGENDA]]    Script Date: 20/10/2015 13:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RPT_OCUPACION_AGENDA]
@CLIS_ID AS int = NULL, -- centro
@SCLI_ID AS int = NULL, -- servicio clinico
@PRES_DESCRIPCION AS varchar(200) = NULL, --examen /medico
@TPRE_ID AS int = NULL, -- TIPO PRESTACION
@FECHA_INI AS DATETIME = NULL,
@FECHA_FIN AS DATETIME = NULL,
@CLI_ID_SESSION AS VARCHAR(15) = NULL

AS
BEGIN

      SELECT 
      TPRES.TPRE_DESCRIPCION,
      --[TOTAL].PRES_DESCRIPCION,
      COUNT(DISTINCT [TOTAL].[INDICE_BLOQUE]) [HR_OFERTA]
      --COUNT(DISTINCT [TOTAL].[OCUPADO]) [HR_OCUPADA],
      --COUNT(DISTINCT [TOTAL].[INDICE_BLOQUE]) - COUNT(DISTINCT [TOTAL].[OCUPADO]) [HR_DISPONIBLE],
      --COUNT(DISTINCT [TOTAL].[RESE_ID]) [CANT_RESERVADA],
      --COUNT(DISTINCT [TOTAL].[CONFIRMADA]) [HR_CONFIRMADA],
      --COUNT(DISTINCT [TOTAL].[ATENDIDA]) [HR_ATENDIDA],
      --SUM(CASE WHEN [TOTAL].[AUSENCIA_HORARIO] = 1 THEN 1 ELSE 0 END) [HR_TOTAL_BLOQUEOS],
      --SUM(HORD_SOBRE_CUPO_MAX) HR_SOBRECUPO
      FROM (SELECT
			CONVERT(VARCHAR(100),DET.[HORA_INI]) + CONVERT(VARCHAR(100),DET.FECHA,103) 
            [INDICE_BLOQUE],
            CASE WHEN RES.RESE_ID IS NOT NULL 
                THEN CONVERT(VARCHAR(100),DET.[HORA_INI]) + CONVERT(VARCHAR(100),DET.FECHA,103) 
                ELSE NULL 
            END [OCUPADO],
            CASE WHEN RES.RESE_ID IS NOT NULL AND RES.ERES_ID = 7 /*CONFIRMADA*/ 
                THEN CONVERT(VARCHAR(100),RES.RESE_ID) 
                ELSE NULL 
            END [CONFIRMADA],
            CASE WHEN RES.RESE_ID IS NOT NULL AND RES.ERES_ID IN (SELECT ERES_ID
																	FROM dbo.FN_OBTENER_ESTADOS_ATENDIDO()
                                                                    )  /*ATENDIDA*/ 
                THEN CONVERT(VARCHAR(100),RES.RESE_ID) 
                ELSE NULL 
            END [ATENDIDA],
            PRES.PRES_ID,
            PRES.TPRE_ID,
            PRES.SCLI_ID,
            PRES.PRES_DESCRIPCION,
            DET.NUMERO,
            RES.RESE_ID,
            RES.RESE_ORDEN,
            RES.RESE_FECHA_RESERVA,
            DET.FECHA [FECHA],
            RES.ERES_ID,
            DET.HORA_INI [DETALLE_HORA_INI],
            DET.HORA_FIN [DETALLE_HORA_FIN],
            HD.HORD_ID,
            HD.HORD_HORA_INI,
            HD.HORD_HORA_FIN,            
            CASE WHEN RES.RESE_ID IS NULL 
                      THEN HD.HORD_SOBRE_CUPO_MAX 
                 ELSE  
                    CASE WHEN RES.RESE_ID= (SELECT MIN([RESE_ID])
                                            FROM [RESERVA] RESD
                                            WHERE RESD.HORD_ID = HD.HORD_ID    
                                              AND RESD.RESE_VIGENTE = 1
                                              AND ISNULL(RESD.ERES_ID,-1) NOT IN (SELECT ERES_ID FROM FN_OBTENER_ESTADOS_NO_VIGENTE())
                                              AND DET.HORA_INI >= RESD.RESE_HORA_INI 
                                              AND DET.HORA_FIN <= RESD.RESE_HORA_FIN 
                                              /*AND RESD.RESE_HORA_FIN <= DET.HORA_FIN*/
                                              AND CAST(RESD.RESE_FECHA_RESERVA AS DATE) = CAST(DET.FECHA AS DATE) 
                                            )
                         THEN 
                         	HORD_SOBRE_CUPO_MAX
                         ELSE 
                            NULL
                    END
             END HORD_SOBRE_CUPO_MAX,
            dbo.FN_VALIDAR_AUSENCIA_HORARIO(HD.PRES_ID,DET.FECHA,DET.HORA_INI) [AUSENCIA_HORARIO],
            (CASE WHEN ISNULL(PRES.PRES_HABILITAR_FESTIVOS,0) = 1 
                THEN CONVERT(BIT,0)
            ELSE            
                dbo.FN_VALIDAR_FERIADO(DET.FECHA) 
            END) [FERIADO_HORARIO],                                
            CASE WHEN ISNULL(DET.FECHA,GETDATE()) > DATEADD(DAY,ISNULL(PRES.PRES_PLAZO_SOLICITUD_MAX,0),GETDATE()) THEN 1 ELSE 0 END [PLAZO_MAXIMO_HORARIO]
            FROM HORARIO_DIARIO  HD WITH (NOLOCK) 
            JOIN PRESTACION PRES WITH (NOLOCK)  ON PRES.PRES_ID = HD.PRES_ID
            JOIN (SELECT 
                  FECHA
                  ,HD.HORD_ID 
                  ,CASE WHEN HD.HORD_HORA_INI IS NOT NULL AND HD.HORD_HORA_FIN IS NOT NULL AND HD.HORD_HORA_INI <= HD.HORD_HORA_FIN AND HD.HORD_INTERVALO IS NOT NULL
                     AND HD.HORD_INTERVALO > 0 THEN 1 
                     ELSE 0 
                     END INCLUYE
                  ,(CICLO.NUMERO-1) [NUMERO]
                  ,DATEADD(minute, (CICLO.NUMERO-1) * HD.HORD_INTERVALO, HD.HORD_HORA_INI) [HORA_INI]
                  ,CASE WHEN DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI) >= HD.HORD_HORA_FIN
                     OR DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI) = '00:00:00.000'
                     OR DATEADD(minute, (CICLO.NUMERO-1) * HD.HORD_INTERVALO, HD.HORD_HORA_INI) > DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI)/*IMPORTANTE*/
                     THEN HD.HORD_HORA_FIN
                     ELSE DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI)
                     END [HORA_FIN]
                  FROM HORARIO_DIARIO  as HD  WITH (INDEX(Ref3857))
                  JOIN (SELECT (rn) NUMERO
                        FROM (SELECT [rn]=Row_number() OVER(ORDER BY (SELECT NULL))
                              FROM INTERVALO a WITH (NOLOCK)) ctedaterange
                        ) CICLO 
                    ON CICLO.NUMERO <= ROUND( CONVERT(NUMERIC(15,3),Datediff(minute, HD.HORD_HORA_INI, HD.HORD_HORA_FIN))/CONVERT(NUMERIC(15,3),HD.HORD_INTERVALO),0) 
                  JOIN (SELECT FECHA FROM dbo.FN_OBTENER_DIAS_INTERVALO_RANGO(@FECHA_INI,@FECHA_FIN)) AS TBR
                    ON TBR.FECHA BETWEEN HD.HORD_VIGENCIA_INI AND HD.HORD_VIGENCIA_FIN
                    AND ((DATEPART(weekday, TBR.FECHA) + @@DATEFIRST - 2) % 7 + 1) = HD.HORD_DIA
                  WHERE 
                  /*( ISNULL(@PRES_ID,-1) = -1 OR HD.PRES_ID = @PRES_ID )
                  AND */
                  (HD.HORD_ID + 0) > 0
                  AND HD.HORD_VIGENTE = 1
                  ) DET ON DET.HORD_ID = HD.HORD_ID 
            LEFT JOIN RESERVA RES WITH (NOLOCK)  ON RES.HORD_ID = DET.HORD_ID    
               AND RES.RESE_VIGENTE = 1
               AND ISNULL(RES.ERES_ID,-1) NOT IN (SELECT ERES_ID FROM FN_OBTENER_ESTADOS_NO_VIGENTE())
              AND DET.HORA_INI >= RES.RESE_HORA_INI 
              AND DET.HORA_FIN <= RES.RESE_HORA_FIN 
               /*AND RES.RESE_HORA_INI >= DET.HORA_INI
               AND RES.RESE_HORA_FIN <= DET.HORA_FIN  */
               AND CAST(RES.RESE_FECHA_RESERVA AS DATE) = CAST(DET.FECHA AS DATE) 
            WHERE HD.HORD_ID = DET.HORD_ID
            AND DET.INCLUYE=1
            AND (@SCLI_ID IS NULL OR PRES.SCLI_ID = @SCLI_ID OR @SCLI_ID=0)
            AND (@PRES_DESCRIPCION IS NULL OR PRES.PRES_DESCRIPCION = @PRES_DESCRIPCION OR ISNULL(@PRES_DESCRIPCION, '')='')
            AND (PRES.TPRE_ID = @TPRE_ID OR ISNULL(@TPRE_ID, '')='' OR @TPRE_ID=0)
    ) TOTAL
                                               JOIN TIPO_PRESTACION AS TPRES  ON TOTAL.TPRE_ID = TPRES.TPRE_ID
                                               JOIN SERVICIO_CLINICO AS SCLI ON TOTAL.SCLI_ID = SCLI.SCLI_ID
                                               JOIN CLINICA_SEDE AS CLIS ON SCLI.CLIS_ID = CLIS.CLIS_ID                                      
                                               WHERE (@CLIS_ID IS NULL OR CLIS.CLIS_ID = @CLIS_ID OR @CLIS_ID=0)
                                               AND (@SCLI_ID IS NULL OR SCLI.SCLI_ID = @SCLI_ID OR @SCLI_ID=0)
                                               AND (@PRES_DESCRIPCION IS NULL OR TOTAL.PRES_DESCRIPCION = @PRES_DESCRIPCION OR ISNULL(@PRES_DESCRIPCION, '')='')
                                               AND (TOTAL.TPRE_ID = @TPRE_ID OR ISNULL(@TPRE_ID, '')='' OR @TPRE_ID=0)
                                               AND (CLIS.CLI_ID = @CLI_ID_SESSION OR ISNULL(@CLI_ID_SESSION,-1) = -1)
    GROUP BY 
    [TOTAL].PRES_ID,
    [TOTAL].PRES_DESCRIPCION,
    TPRES.TPRE_DESCRIPCION
    ORDER BY 
    [TOTAL].PRES_DESCRIPCION ASC


/*

 
      SELECT 
      TPRES.TPRE_DESCRIPCION,
      [TOTAL].PRES_DESCRIPCION,
      SUM(1) [HR_OFERTA],
      SUM([TOTAL].[CANT_RESERVAS]) [HR_OCUPADA],
      SUM(1) - SUM([TOTAL].[CANT_RESERVAS])[HR_DISPONIBLE],
      SUM([TOTAL].[HORD_SOBRE_CUPO_MAX]) [HR_SOBRECUPO],
      SUM([TOTAL].[CANT_CONFIRMADAS]) [HR_CONFIRMADA],
      SUM([TOTAL].[CANT_ATENDIDAS]) [HR_ATENDIDA]
      FROM (
        SELECT 
        T5.PRES_ID,
        T5.TPRE_ID,
        T5.SCLI_ID,
        T5.PRES_DESCRIPCION,
        T5.[DETALLE_HORA_INI],
        T5.[DETALLE_HORA_FIN],
        T5.[HORD_ID],
        T5.[HORD_HORA_INI],
        T5.[HORD_HORA_FIN],
        T5.[CANT_RESERVAS],
        T5.[CANT_CONFIRMADAS],
        T5.[CANT_ATENDIDAS],
        T5.[HORD_SOBRE_CUPO_MAX],
        T5.[AUSENCIA_HORARIO],
        T5.[FERIADO_HORARIO],
        T5.[PLAZO_MAXIMO_HORARIO],
        T5.FECHA
        FROM 
        HORARIO_DIARIO HD  WITH (NOLOCK)
        JOIN (SELECT 
            DISTINCT
            T4.PRES_ID,
            T4.TPRE_ID,
            T4.SCLI_ID,
            T4.PRES_DESCRIPCION,
            T4.DETALLE_HORA_INI,
            T4.DETALLE_HORA_FIN,
            T4.HORD_ID,
            T4.HORD_HORA_INI,
            T4.HORD_HORA_FIN,            
            (CASE WHEN T4.RESE_ID IS NOT NULL THEN 1 ELSE 0 END) [CANT_RESERVAS],
            (CASE WHEN T4.RESE_ID IS NOT NULL AND T4.ERES_ID = 7 --CONFIRMADA
            								THEN 1 ELSE 0 END) [CANT_CONFIRMADAS],
            (CASE WHEN T4.RESE_ID IS NOT NULL AND T4.ERES_ID IN 
            								(SELECT ERES_ID
            								FROM dbo.FN_OBTENER_ESTADOS_ATENDIDO())
                                            THEN 1 ELSE 0 END) [CANT_ATENDIDAS],
            T4.HORD_SOBRE_CUPO_MAX,
            T4.[AUSENCIA_HORARIO],
            T4.[FERIADO_HORARIO],
            T4.[PLAZO_MAXIMO_HORARIO],
            T4.FECHA
            FROM 
            (SELECT 
              T3.PRES_ID,
              T3.TPRE_ID,
              T3.SCLI_ID,
              T3.PRES_DESCRIPCION,
              T3.RESE_ID,
              T3.ERES_ID,              
              T3.DETALLE_HORA_INI,
              T3.DETALLE_HORA_FIN,
              T3.HORD_ID,
              T3.HORD_HORA_INI,
              T3.HORD_HORA_FIN,
              T3.HORD_SOBRE_CUPO_MAX,
              T3.AUSENCIA_HORARIO,
              T3.FERIADO_HORARIO,
              T3.PLAZO_MAXIMO_HORARIO,
              T3.FECHA
              FROM (SELECT T2.*
                    FROM (
                            SELECT
                                PRES.PRES_ID,
                                PRES.TPRE_ID,
                                PRES.SCLI_ID,
                                PRES.PRES_DESCRIPCION,
                                RES.RESE_ID,
                                RES.RESE_ORDEN,
                                --RES.RESE_FECHA_RESERVA,
                                DET.FECHA [FECHA],
                                RES.ERES_ID,
                                DET.HORA_INI [DETALLE_HORA_INI],
                                DET.HORA_FIN [DETALLE_HORA_FIN],
                                HD.HORD_ID,
                                HD.HORD_HORA_INI,
                                HD.HORD_HORA_FIN,
                                HD.HORD_SOBRE_CUPO_MAX,
                                dbo.FN_VALIDAR_AUSENCIA_HORARIO(HD.PRES_ID,DET.FECHA,DET.HORA_INI) [AUSENCIA_HORARIO],
                                --dbo.FN_VALIDAR_FERIADO(DET.FECHA) [FERIADO_HORARIO],
                                (CASE WHEN ISNULL(PRES.PRES_HABILITAR_FESTIVOS,0) = 1 
                                    THEN CONVERT(BIT,0)
                                ELSE            
                                    dbo.FN_VALIDAR_FERIADO(DET.FECHA) 
                                END) [FERIADO_HORARIO],                                     
                                CASE WHEN ISNULL(DET.FECHA,GETDATE()) > DATEADD(DAY,ISNULL(PRES.PRES_PLAZO_SOLICITUD_MAX,0),GETDATE()) THEN 1 ELSE 0 END [PLAZO_MAXIMO_HORARIO]

                            FROM HORARIO_DIARIO  HD WITH (NOLOCK) 
                                 JOIN PRESTACION PRES WITH (NOLOCK)  ON PRES.PRES_ID = HD.PRES_ID
                                 JOIN (SELECT 
                                 		FECHA
                                 		,HD.HORD_ID 
                                        ,CASE WHEN HD.HORD_HORA_INI IS NOT NULL AND HD.HORD_HORA_FIN IS NOT NULL AND HD.HORD_HORA_INI <= HD.HORD_HORA_FIN AND HD.HORD_INTERVALO IS NOT NULL
                                           AND HD.HORD_INTERVALO > 0 THEN 1 
                                           ELSE 0 
                                           END INCLUYE
                                        ,(CICLO.NUMERO-1) [NUMERO]
                                        ,DATEADD(minute, (CICLO.NUMERO-1) * HD.HORD_INTERVALO, HD.HORD_HORA_INI) [HORA_INI]
                                        ,CASE WHEN DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI) >= HD.HORD_HORA_FIN
                                           OR DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI) = '00:00:00.000'
                                           OR DATEADD(minute, (CICLO.NUMERO-1) * HD.HORD_INTERVALO, HD.HORD_HORA_INI) > DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI)/*IMPORTANTE*/
                                           THEN HD.HORD_HORA_FIN
                                           ELSE DATEADD(minute, (((CICLO.NUMERO-1)*HD.HORD_INTERVALO) + HD.HORD_INTERVALO), HD.HORD_HORA_INI)
                                           END [HORA_FIN]
                                        FROM HORARIO_DIARIO  as HD  WITH (INDEX(Ref3857))
                                        JOIN (SELECT (rn) NUMERO
                                              FROM (SELECT [rn]=Row_number() OVER(ORDER BY (SELECT NULL))
                                                    FROM INTERVALO a WITH (NOLOCK)) ctedaterange
                                              ) CICLO ON CICLO.NUMERO <= ROUND( CONVERT(NUMERIC(15,3),Datediff(minute, HD.HORD_HORA_INI, HD.HORD_HORA_FIN))/CONVERT(NUMERIC(15,3),HD.HORD_INTERVALO),0) 
                                        JOIN (SELECT FECHA FROM dbo.FN_OBTENER_DIAS_INTERVALO_RANGO(@FECHA_INI,@FECHA_FIN)) AS TBR
                                        ON TBR.FECHA BETWEEN HD.HORD_VIGENCIA_INI AND HD.HORD_VIGENCIA_FIN
                                        AND ((DATEPART(weekday, TBR.FECHA) + @@DATEFIRST - 2) % 7 + 1) = HD.HORD_DIA
                                        WHERE 
                                        --HD.PRES_ID = @PRES_ID
                                        ( ISNULL(@PRES_ID,-1) = -1 OR HD.PRES_ID = @PRES_ID )
                                        --AND ((DATEPART(weekday, @FECHA) + @@DATEFIRST - 2) % 7 + 1) = HD.HORD_DIA
                                        AND (HD.HORD_ID + 0) > 0
                                        AND HD.HORD_VIGENTE = 1
                                        --AND @FECHA BETWEEN HD.HORD_VIGENCIA_INI AND HD.HORD_VIGENCIA_FIN
                                        --AND  CICLO.NUMERO <= ROUND( CONVERT(NUMERIC(15,3),Datediff(minute, HD.HORD_HORA_INI, HD.HORD_HORA_FIN))/CONVERT(NUMERIC(15,3),HD.HORD_INTERVALO),0)  
                                        ) DET ON DET.HORD_ID = HD.HORD_ID 
																			LEFT JOIN RESERVA RES WITH (NOLOCK)  ON RES.HORD_ID = HD.HORD_ID    
                                       AND DET.HORA_INI >= RES.RESE_HORA_INI 
                                       AND DET.HORA_FIN <= RES.RESE_HORA_FIN   
                                       AND RES.RESE_VIGENTE = 1
                                       AND CAST(RES.RESE_FECHA_RESERVA AS DATE) = CAST(DET.FECHA AS DATE) 
                                       AND ISNULL(RES.ERES_ID,-1) NOT IN (SELECT ERES_ID FROM FN_OBTENER_ESTADOS_NO_VIGENTE())
                                 WHERE HD.HORD_ID = DET.HORD_ID
                                 AND DET.INCLUYE=1
                             ) T2
                      WHERE      
                            (ISNULL(@AUSENCIA_HORARIO,T2.AUSENCIA_HORARIO) = T2.AUSENCIA_HORARIO)
                        AND (ISNULL(@FERIADO_HORARIO,T2.FERIADO_HORARIO) = T2.FERIADO_HORARIO)
                        AND (ISNULL(@PLAZO_MAXIMO_HORARIO,T2.PLAZO_MAXIMO_HORARIO) = T2.PLAZO_MAXIMO_HORARIO)
                      ) T3
                  ) T4
            LEFT JOIN RESERVA RES WITH (NOLOCK)  ON T4.RESE_ID = RES.RESE_ID
            ) T5  ON T5.HORD_ID = HD.HORD_ID
      WHERE 
      HD.HORD_VIGENTE = 1
      AND ( ISNULL(@PRES_ID,-1) = -1 OR HD.PRES_ID = @PRES_ID )
      AND (ISNULL(@CANT_RESERVAS,-1) = -1 OR T5.CANT_RESERVAS = @CANT_RESERVAS)
      AND (ISNULL(@VISIBLE_WEB,-1) = -1 OR HD.HORD_VISIBLE_WEB = @VISIBLE_WEB)
    ) TOTAL
			JOIN TIPO_PRESTACION AS TPRES  ON TOTAL.TPRE_ID = TPRES.TPRE_ID
			JOIN SERVICIO_CLINICO AS SCLI ON TOTAL.SCLI_ID = SCLI.SCLI_ID
			JOIN CLINICA_SEDE AS CLIS ON SCLI.CLIS_ID = CLIS.CLIS_ID			
			WHERE (@CLIS_ID IS NULL OR CLIS.CLIS_ID = @CLIS_ID OR @CLIS_ID=0)
			AND (@SCLI_ID IS NULL OR SCLI.SCLI_ID = @SCLI_ID OR @SCLI_ID=0)
			AND (@PRES_DESCRIPCION IS NULL OR TOTAL.PRES_DESCRIPCION = @PRES_DESCRIPCION OR ISNULL(@PRES_DESCRIPCION, '')='')
			AND (TOTAL.TPRE_ID = @TPRE_ID OR ISNULL(@TPRE_ID, '')='' OR @TPRE_ID=0)
			AND (CLIS.CLI_ID = @CLI_ID_SESSION OR ISNULL(@CLI_ID_SESSION,-1) = -1)

    GROUP BY 
    [TOTAL].PRES_ID,
    [TOTAL].PRES_DESCRIPCION,
		TPRES.TPRE_DESCRIPCION
    --,[TOTAL].FECHA
    ORDER BY 
    [TOTAL].PRES_DESCRIPCION ASC
*/

END
