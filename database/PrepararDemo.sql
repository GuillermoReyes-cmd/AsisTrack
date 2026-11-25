/* =====================================================================
   AsisTrack - Preparar la demostración en vivo
   Ejecutar (F5) en SQL Server Management Studio JUSTO ANTES de exponer.
   Ajusta los 4 turnos de demostración a la hora actual y deja listas
   las marcaciones de hoy. Se puede ejecutar las veces que se necesite.

   Después de ejecutarlo, en la pantalla Marcación:
     DNI 10000001 (Sofía Paredes)  -> Ingreso  -> sale PUNTUAL (llega 2 min después, tolerancia 15)
     DNI 10000002 (Martín Castillo)-> Ingreso  -> sale TARDE (40 min de tardanza, tolerancia 10)
     DNI 10000003 (Lucía Herrera)  -> Salida   -> SALIDA PUNTUAL (sin horas extra)
     DNI 10000004 (Diego Ramos)    -> Salida   -> SALIDA CON 2 h DE HORAS EXTRA
   ===================================================================== */
USE AsisTrackDB;
GO
DECLARE @Ahora TIME(0) = CAST(GETDATE() AS TIME(0));
DECLARE @Hoy   DATETIME = CAST(CAST(GETDATE() AS DATE) AS DATETIME);

-- 1) Turnos ajustados a la hora actual
UPDATE Turno SET HoraInicio = DATEADD(MINUTE, -2,  @Ahora), HoraFin = DATEADD(HOUR, 6, DATEADD(MINUTE, -2, @Ahora)),
                 ToleranciaMinutos = 15, Estado = 1, ModifiedBy = 1, ModifiedAt = GETDATE()
WHERE NombreTurno = 'Demo - Ingreso puntual';

UPDATE Turno SET HoraInicio = DATEADD(MINUTE, -40, @Ahora), HoraFin = DATEADD(HOUR, 6, DATEADD(MINUTE, -40, @Ahora)),
                 ToleranciaMinutos = 10, Estado = 1, ModifiedBy = 1, ModifiedAt = GETDATE()
WHERE NombreTurno = 'Demo - Ingreso tarde';

UPDATE Turno SET HoraFin = DATEADD(MINUTE, -1, @Ahora), HoraInicio = DATEADD(HOUR, -8, DATEADD(MINUTE, -1, @Ahora)),
                 ToleranciaMinutos = 10, Estado = 1, ModifiedBy = 1, ModifiedAt = GETDATE()
WHERE NombreTurno = 'Demo - Salida puntual';

UPDATE Turno SET HoraFin = DATEADD(HOUR, -2, @Ahora), HoraInicio = DATEADD(HOUR, -10, @Ahora),
                 ToleranciaMinutos = 10, Estado = 1, ModifiedBy = 1, ModifiedAt = GETDATE()
WHERE NombreTurno = 'Demo - Horas extra';

-- 2) Se borran las marcaciones de HOY de los 4 colaboradores de demostración
DELETE FROM Marcacion
WHERE ColaboradorID IN (SELECT ColaboradorID FROM Colaborador WHERE DNI IN ('10000001','10000002','10000003','10000004'))
  AND FechaHora >= @Hoy;

-- 3) Los colaboradores de salida ya marcaron su ingreso hoy, a la hora de inicio de su turno
INSERT INTO Marcacion (ColaboradorID, FechaHora, TipoMarcacion, Estado, MinutosTardanza, CreatedBy, CreatedAt)
SELECT c.ColaboradorID, @Hoy + CAST(t.HoraInicio AS DATETIME), 'Ingreso', 'Puntual', 0, 4,
       @Hoy + CAST(t.HoraInicio AS DATETIME)
FROM Colaborador c JOIN Turno t ON t.TurnoID = c.TurnoID
WHERE c.DNI IN ('10000003', '10000004');

-- Resumen para revisar antes de exponer
SELECT c.DNI, c.Nombres + ' ' + c.Apellidos AS Colaborador, t.NombreTurno,
       CONVERT(VARCHAR(5), t.HoraInicio, 108) AS Inicio, CONVERT(VARCHAR(5), t.HoraFin, 108) AS Fin,
       t.ToleranciaMinutos AS Tolerancia
FROM Colaborador c JOIN Turno t ON t.TurnoID = c.TurnoID
WHERE c.DNI IN ('10000001','10000002','10000003','10000004')
ORDER BY c.DNI;
GO
