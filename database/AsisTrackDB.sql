/* =====================================================================
   AsisTrack - Sistema de Gestión de Control de Asistencia del Personal
   Script de creación de la base de datos (SQL Server)
   Ejecutar completo en SQL Server Management Studio (F5).
   Base de datos del Trabajo Final (Entity Framework Core - Database First).
   Incluye: tablas, procedimientos almacenados y datos de prueba / demostración.
   No se usan triggers.
   ===================================================================== */
USE master;
GO
IF DB_ID('AsisTrackDB') IS NOT NULL
BEGIN
    ALTER DATABASE AsisTrackDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE AsisTrackDB;
END
GO
CREATE DATABASE AsisTrackDB;
GO
USE AsisTrackDB;
GO

/* ---------------------------- TABLAS ---------------------------- */
CREATE TABLE Rol (
    RolID        INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Rol PRIMARY KEY,
    NombreRol    VARCHAR(50)  NOT NULL CONSTRAINT UQ_Rol_Nombre UNIQUE,
    Descripcion  VARCHAR(150) NULL,
    Estado       BIT          NOT NULL CONSTRAINT DF_Rol_Estado DEFAULT 1,
    CreatedBy    INT          NOT NULL,
    CreatedAt    DATETIME     NOT NULL CONSTRAINT DF_Rol_CreatedAt DEFAULT GETDATE(),
    ModifiedBy   INT          NULL,
    ModifiedAt   DATETIME     NULL
);

CREATE TABLE Usuario (
    UsuarioID      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Usuario PRIMARY KEY,
    RolID          INT          NOT NULL CONSTRAINT FK_Usuario_Rol REFERENCES Rol(RolID),
    NombreCompleto VARCHAR(100) NOT NULL,
    NombreUsuario  VARCHAR(30)  NOT NULL CONSTRAINT UQ_Usuario_Nombre UNIQUE,
    Correo         VARCHAR(100) NULL,
    Contrasena     VARCHAR(256) NOT NULL,   -- hash SHA-256 en hexadecimal
    Estado         BIT          NOT NULL CONSTRAINT DF_Usuario_Estado DEFAULT 1,
    CreatedBy      INT          NOT NULL,
    CreatedAt      DATETIME     NOT NULL CONSTRAINT DF_Usuario_CreatedAt DEFAULT GETDATE(),
    ModifiedBy     INT          NULL,
    ModifiedAt     DATETIME     NULL
);

CREATE TABLE Turno (
    TurnoID           INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Turno PRIMARY KEY,
    NombreTurno       VARCHAR(50) NOT NULL,
    HoraInicio        TIME(0)     NOT NULL,
    HoraFin           TIME(0)     NOT NULL,
    ToleranciaMinutos INT         NOT NULL CONSTRAINT DF_Turno_Tolerancia DEFAULT 0,
    Estado            BIT         NOT NULL CONSTRAINT DF_Turno_Estado DEFAULT 1,
    CreatedBy         INT         NOT NULL,
    CreatedAt         DATETIME    NOT NULL CONSTRAINT DF_Turno_CreatedAt DEFAULT GETDATE(),
    ModifiedBy        INT         NULL,
    ModifiedAt        DATETIME    NULL
);

CREATE TABLE Colaborador (
    ColaboradorID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Colaborador PRIMARY KEY,
    TurnoID       INT         NOT NULL CONSTRAINT FK_Colaborador_Turno REFERENCES Turno(TurnoID),
    UsuarioID     INT         NULL     CONSTRAINT FK_Colaborador_Usuario REFERENCES Usuario(UsuarioID),
    Nombres       VARCHAR(50) NOT NULL,
    Apellidos     VARCHAR(50) NOT NULL,
    DNI           CHAR(8)     NOT NULL CONSTRAINT UQ_Colaborador_DNI UNIQUE,
    Cargo         VARCHAR(50) NOT NULL,
    Departamento  VARCHAR(50) NOT NULL,
    Estado        BIT         NOT NULL CONSTRAINT DF_Colaborador_Estado DEFAULT 1,
    CreatedBy     INT         NOT NULL,
    CreatedAt     DATETIME    NOT NULL CONSTRAINT DF_Colaborador_CreatedAt DEFAULT GETDATE(),
    ModifiedBy    INT         NULL,
    ModifiedAt    DATETIME    NULL
);

CREATE TABLE Marcacion (
    MarcacionID     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Marcacion PRIMARY KEY,
    ColaboradorID   INT         NOT NULL CONSTRAINT FK_Marcacion_Colaborador REFERENCES Colaborador(ColaboradorID),
    FechaHora       DATETIME    NOT NULL CONSTRAINT DF_Marcacion_FechaHora DEFAULT GETDATE(),
    TipoMarcacion   VARCHAR(10) NOT NULL CONSTRAINT CK_Marcacion_Tipo CHECK (TipoMarcacion IN ('Ingreso', 'Salida')),
    Estado          VARCHAR(15) NOT NULL CONSTRAINT CK_Marcacion_Estado CHECK (Estado IN ('Puntual', 'Tarde')),
    MinutosTardanza INT         NOT NULL CONSTRAINT DF_Marcacion_Minutos DEFAULT 0,
    CreatedBy       INT         NOT NULL,
    CreatedAt       DATETIME    NOT NULL CONSTRAINT DF_Marcacion_CreatedAt DEFAULT GETDATE(),
    ModifiedBy      INT         NULL,
    ModifiedAt      DATETIME    NULL
);

CREATE TABLE Justificacion (
    JustificacionID  INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Justificacion PRIMARY KEY,
    ColaboradorID    INT          NOT NULL CONSTRAINT FK_Justificacion_Colaborador REFERENCES Colaborador(ColaboradorID),
    MarcacionID      INT          NULL     CONSTRAINT FK_Justificacion_Marcacion REFERENCES Marcacion(MarcacionID),
    Motivo           VARCHAR(250) NOT NULL,
    FechaInicio      DATE         NOT NULL,
    FechaFin         DATE         NOT NULL,
    EstadoAprobacion VARCHAR(15)  NOT NULL CONSTRAINT DF_Justificacion_Estado DEFAULT 'Pendiente'
                     CONSTRAINT CK_Justificacion_Estado CHECK (EstadoAprobacion IN ('Pendiente', 'Aprobado', 'Rechazado')),
    AprobadoPor      INT          NULL     CONSTRAINT FK_Justificacion_AprobadoPor REFERENCES Usuario(UsuarioID),
    CreatedBy        INT          NOT NULL,
    CreatedAt        DATETIME     NOT NULL CONSTRAINT DF_Justificacion_CreatedAt DEFAULT GETDATE(),
    ModifiedBy       INT          NULL,
    ModifiedAt       DATETIME     NULL,
    CONSTRAINT CK_Justificacion_Fechas CHECK (FechaFin >= FechaInicio)
);
GO

/* ------------------- PROCEDIMIENTOS ALMACENADOS -------------------
   Se ejecutan desde la capa de datos con Entity Framework Core
   (FromSqlRaw / ExecuteSqlRaw).                                      */

-- Inicio de sesión: busca el usuario por su nombre de usuario (UsuarioDAO)
CREATE PROCEDURE sp_BuscarUsuarioPorNombre
    @NombreUsuario VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UsuarioID, RolID, NombreCompleto, NombreUsuario, Correo, Contrasena, Estado,
           CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
    FROM Usuario
    WHERE NombreUsuario = @NombreUsuario;
END
GO

-- Marcación: busca al colaborador por su DNI (ColaboradorDAO)
CREATE PROCEDURE sp_BuscarColaboradorPorDni
    @DNI CHAR(8)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ColaboradorID, TurnoID, UsuarioID, Nombres, Apellidos, DNI, Cargo, Departamento, Estado,
           CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
    FROM Colaborador
    WHERE DNI = @DNI;
END
GO

-- Marcación: última marcación del colaborador desde una fecha (valida si toca ingreso o salida)
CREATE PROCEDURE sp_UltimaMarcacion
    @ColaboradorID INT,
    @Desde         DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 MarcacionID, ColaboradorID, FechaHora, TipoMarcacion, Estado, MinutosTardanza,
           CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
    FROM Marcacion
    WHERE ColaboradorID = @ColaboradorID AND FechaHora >= @Desde
    ORDER BY FechaHora DESC;
END
GO

-- Reportes: marcaciones de un rango de fechas, ordenadas por colaborador y hora (MarcacionDAO)
CREATE PROCEDURE sp_ListarMarcacionesPorRango
    @Desde DATETIME,
    @Hasta DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MarcacionID, ColaboradorID, FechaHora, TipoMarcacion, Estado, MinutosTardanza,
           CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
    FROM Marcacion
    WHERE FechaHora >= @Desde AND FechaHora < @Hasta
    ORDER BY ColaboradorID, FechaHora;
END
GO

-- Reporte de tardanzas: ingresos registrados como "Tarde" en un rango de fechas
CREATE PROCEDURE sp_ListarTardanzas
    @Desde DATETIME,
    @Hasta DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MarcacionID, ColaboradorID, FechaHora, TipoMarcacion, Estado, MinutosTardanza,
           CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
    FROM Marcacion
    WHERE TipoMarcacion = 'Ingreso' AND Estado = 'Tarde'
      AND FechaHora >= @Desde AND FechaHora < @Hasta;
END
GO

-- Justificaciones: aprobar o rechazar una solicitud pendiente (JustificacionDAO)
CREATE PROCEDURE sp_ResolverJustificacion
    @JustificacionID  INT,
    @EstadoAprobacion VARCHAR(15),
    @UsuarioID        INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Justificacion
    SET EstadoAprobacion = @EstadoAprobacion,
        AprobadoPor      = @UsuarioID,
        ModifiedBy       = @UsuarioID,
        ModifiedAt       = GETDATE()
    WHERE JustificacionID = @JustificacionID
      AND EstadoAprobacion = 'Pendiente';
END
GO

/* ------------------------- DATOS INICIALES ------------------------- */
-- El primer usuario (admin, UsuarioID = 1) se registra a sí mismo como creador.
INSERT INTO Rol (NombreRol, Descripcion, CreatedBy) VALUES
 ('Administrador RR.HH.', 'Acceso total y mantenimiento',          1),
 ('Jefatura de área',     'Aprueba justificaciones y ve reportes', 1),
 ('Marcación',            'Solo registra ingresos y salidas',      1),
 ('Colaborador',          'Consulta su historial',                 1);

-- Contraseñas guardadas como hash SHA-256 (hexadecimal en mayúsculas)
INSERT INTO Usuario (RolID, NombreCompleto, NombreUsuario, Correo, Contrasena, Estado, CreatedBy) VALUES
 (1, 'Administrador del sistema', 'admin',    'admin@asistrack.pe',   CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', 'admin123'),  2), 1, 1),
 (2, 'Vega Torres, Andrea Sofía', 'avega',    'avega@asistrack.pe',   CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', 'jefe123'),   2), 1, 1),
 (2, 'Campos Silva, Ricardo',     'rcampos',  'rcampos@asistrack.pe',  CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', 'jefe123'),   2), 1, 1),
 (3, 'Terminal de marcación',     'kiosko01', NULL,                   CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', 'kiosko123'), 2), 1, 1),
 (4, 'Ramírez Díaz, Carlos',      'cramirez', 'cramirez@asistrack.pe', CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', 'colab123'),  2), 0, 1),
 (4, 'Herrera Soto, Lucía',       'lherrera', 'lherrera@asistrack.pe', CONVERT(VARCHAR(256), HASHBYTES('SHA2_256', 'colab123'),  2), 1, 1);

INSERT INTO Turno (NombreTurno, HoraInicio, HoraFin, ToleranciaMinutos, Estado, CreatedBy) VALUES
 ('Mañana',         '08:00', '17:00', 10, 1, 1),
 ('Tarde',          '14:00', '22:00', 10, 1, 1),
 ('Noche',          '22:00', '06:00', 15, 1, 1),
 ('Partido',        '09:00', '18:00', 10, 1, 1),
 ('Medio tiempo',   '08:00', '13:00',  5, 1, 1),
 ('Administrativo', '08:30', '17:30', 10, 0, 1),
 -- Turnos de DEMOSTRACIÓN (clase: sábados 5:00 p. m.). El script PrepararDemo.sql los ajusta
 -- a la hora exacta de la exposición; estos son los valores por defecto.
 ('Demo - Ingreso puntual', '17:00', '23:00', 15, 1, 1),   -- marcar entre 5:00 y 5:15 p. m. -> Puntual
 ('Demo - Ingreso tarde',   '16:00', '22:00', 10, 1, 1),   -- marcar a las 5:00 p. m. -> Tarde (60 min)
 ('Demo - Salida puntual',  '09:00', '17:00', 10, 1, 1),   -- salir entre 5:00 y 5:29 p. m. -> sin horas extra
 ('Demo - Horas extra',     '07:00', '15:00', 10, 1, 1);   -- salir a las 5:00 p. m. -> 2 h de horas extra

INSERT INTO Colaborador (TurnoID, UsuarioID, Nombres, Apellidos, DNI, Cargo, Departamento, Estado, CreatedBy) VALUES
 (1, 3,    'Ricardo',  'Campos Silva',     '20000001', 'Analista de Cumplimiento',  'Sistemas',    1, 1),
 (1, 2,    'Andrea',   'Vega Torres',      '20000002', 'Jefa de RR.HH.',            'RR.HH.',      1, 1),
 (4, NULL, 'Pablo',    'Quispe Rojas',     '20000003', 'Supervisor de Operaciones', 'Operaciones', 1, 1),
 (1, NULL, 'Bruno',    'Gutiérrez León',   '20000004', 'Operario',                  'Operaciones', 1, 1),
 (1, NULL, 'David',    'Fernández Ortiz',  '20000005', 'Analista Financiero',       'Finanzas',    1, 1),
 (4, NULL, 'María',    'López Torres',     '20000006', 'Ejecutiva de Ventas',       'Ventas',      1, 1),
 (4, 5,    'Carlos',   'Ramírez Díaz',     '20000007', 'Ejecutivo de Ventas',       'Ventas',      0, 1),
 (1, NULL, 'Ana',      'Flores Quispe',    '20000008', 'Desarrolladora',            'Sistemas',    1, 1),
 (2, NULL, 'Luis',     'Huamán Rojas',     '20000009', 'Operario',                  'Operaciones', 1, 1),
 (5, NULL, 'Rosa',     'Vargas Cana',      '20000010', 'Asistente Contable',        'Finanzas',    1, 1),
 (4, NULL, 'Jorge',    'Salas Mendoza',    '20000011', 'Ejecutivo de Ventas',       'Ventas',      1, 1),
 (1, NULL, 'Elena',    'Ríos Paredes',     '20000012', 'Analista de RR.HH.',        'RR.HH.',      1, 1),
 -- Colaboradores de DEMOSTRACIÓN (DNI fáciles de digitar en la exposición)
 (7,  NULL, 'Sofía',    'Paredes Vega',     '10000001', 'Asistente de Logística',    'Operaciones', 1, 1),
 (8,  NULL, 'Martín',   'Castillo Ramos',   '10000002', 'Técnico de Soporte',        'Sistemas',    1, 1),
 (9,  6,    'Lucía',    'Herrera Soto',     '10000003', 'Analista de Planillas',     'RR.HH.',      1, 1),
 (10, NULL, 'Diego',    'Ramos Chávez',     '10000004', 'Operario de Almacén',       'Operaciones', 1, 1);
-- Los datos iniciales se registran con fecha de creación de hace 90 días
UPDATE Rol         SET CreatedAt = DATEADD(DAY, -90, GETDATE());
UPDATE Usuario     SET CreatedAt = DATEADD(DAY, -90, GETDATE());
UPDATE Turno       SET CreatedAt = DATEADD(DAY, -90, GETDATE());
UPDATE Colaborador SET CreatedAt = DATEADD(DAY, -90, GETDATE());
-- Los colaboradores de demostración ingresan HOY (no tienen historial previo)
UPDATE Colaborador SET CreatedAt = CAST(CAST(GETDATE() AS DATE) AS DATETIME)
WHERE DNI IN ('10000001', '10000002', '10000003', '10000004');
GO

/* Datos de prueba: marcaciones de los días hábiles de los últimos 60 días (hasta ayer)
   con horas aleatorias, ~5 % de inasistencias y justificaciones para parte de ellas. */
;WITH Dias AS (
    SELECT CAST(DATEADD(DAY, -60, GETDATE()) AS DATE) AS Fecha
    UNION ALL
    SELECT DATEADD(DAY, 1, Fecha) FROM Dias WHERE Fecha < CAST(DATEADD(DAY, -1, GETDATE()) AS DATE)
)
SELECT c.ColaboradorID, d.Fecha, t.HoraInicio, t.HoraFin, t.ToleranciaMinutos,
       ABS(CHECKSUM(NEWID()) % 100) AS r1,      -- inasistencia si r1 < 5
       ABS(CHECKSUM(NEWID()) % 100) AS r2,      -- tardanza si r2 < 15
       ABS(CHECKSUM(NEWID()) % 100) AS r3,      -- minutos de ingreso
       ABS(CHECKSUM(NEWID()) % 100) AS r4,      -- horas extras si r4 < 30
       ABS(CHECKSUM(NEWID()) % 100) AS r5,      -- minutos de salida
       ABS(CHECKSUM(NEWID()) % 6)   AS k        -- tipo de justificación
INTO #Base
FROM Dias d
CROSS JOIN Colaborador c
JOIN Turno t ON t.TurnoID = c.TurnoID
WHERE c.Estado = 1
  AND c.DNI NOT IN ('10000001', '10000002', '10000003', '10000004')   -- sin historial (demostración)
  AND DATEDIFF(DAY, '19000101', d.Fecha) % 7 < 5          -- lunes a viernes
OPTION (MAXRECURSION 100);

;WITH Ingresos AS (
    SELECT ColaboradorID, Fecha, HoraInicio, HoraFin, ToleranciaMinutos, r4, r5,
           DATEADD(MINUTE,
                   CASE WHEN r2 < 15 THEN 11 + r3 % 20 ELSE (r3 % 16) - 10 END,
                   CAST(Fecha AS DATETIME) + CAST(HoraInicio AS DATETIME)) AS FechaIngreso,
           CAST(Fecha AS DATETIME) + CAST(HoraInicio AS DATETIME) AS InicioOficial
    FROM #Base
    WHERE r1 >= 5
)
INSERT INTO Marcacion (ColaboradorID, FechaHora, TipoMarcacion, Estado, MinutosTardanza, CreatedBy, CreatedAt)
SELECT ColaboradorID, FechaIngreso, 'Ingreso',
       CASE WHEN DATEDIFF(MINUTE, InicioOficial, FechaIngreso) > ToleranciaMinutos THEN 'Tarde' ELSE 'Puntual' END,
       CASE WHEN DATEDIFF(MINUTE, InicioOficial, FechaIngreso) > 0 THEN DATEDIFF(MINUTE, InicioOficial, FechaIngreso) ELSE 0 END,
       4, FechaIngreso
FROM Ingresos
UNION ALL
SELECT ColaboradorID, s.FechaSalida, 'Salida', 'Puntual', 0, 4, s.FechaSalida
FROM Ingresos
CROSS APPLY (SELECT DATEADD(MINUTE,
                            CASE WHEN r4 < 30 THEN 30 + r5 % 91 ELSE r5 % 16 END,
                            CAST(Fecha AS DATETIME) + CAST(HoraFin AS DATETIME)
                              + CASE WHEN HoraFin <= HoraInicio THEN 1 ELSE 0 END) AS FechaSalida) s;

-- Justificaciones para parte de las inasistencias (el resto queda como falta no justificada)
INSERT INTO Justificacion (ColaboradorID, Motivo, FechaInicio, FechaFin, EstadoAprobacion, AprobadoPor, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt)
SELECT ColaboradorID,
       CASE k WHEN 0 THEN 'Descanso médico' WHEN 1 THEN 'Permiso personal' WHEN 2 THEN 'Cita médica'
              ELSE 'Trámite documentario' END,
       Fecha, Fecha,
       CASE WHEN k = 3 THEN 'Rechazado' ELSE 'Aprobado' END,
       2,                                   -- aprobado / rechazado por avega
       1, DATEADD(HOUR, 8, CAST(Fecha AS DATETIME)),
       2, DATEADD(HOUR, 10, CAST(DATEADD(DAY, 1, Fecha) AS DATETIME))
FROM #Base
WHERE r1 < 5 AND k < 4;

DROP TABLE #Base;

-- Dos solicitudes pendientes para mostrar la aprobación en la exposición
INSERT INTO Justificacion (ColaboradorID, Motivo, FechaInicio, FechaFin, CreatedBy) VALUES
 (1, 'Descanso médico por 2 días. Se adjunta certificado médico.', CAST(GETDATE() AS DATE), CAST(DATEADD(DAY, 1, GETDATE()) AS DATE), 3),
 (5, 'Trámite documentario en RENIEC.',                            CAST(DATEADD(DAY, 2, GETDATE()) AS DATE), CAST(DATEADD(DAY, 2, GETDATE()) AS DATE), 1);
GO

/* Prepara la demostración: ingresos de HOY para los colaboradores de salida (10000003 y 10000004)
   y sin marcaciones de hoy para los de ingreso (10000001 y 10000002). */
DELETE FROM Marcacion
WHERE ColaboradorID IN (SELECT ColaboradorID FROM Colaborador WHERE DNI IN ('10000001','10000002','10000003','10000004'))
  AND FechaHora >= CAST(CAST(GETDATE() AS DATE) AS DATETIME);
INSERT INTO Marcacion (ColaboradorID, FechaHora, TipoMarcacion, Estado, MinutosTardanza, CreatedBy, CreatedAt)
SELECT c.ColaboradorID, CAST(CAST(GETDATE() AS DATE) AS DATETIME) + CAST(t.HoraInicio AS DATETIME),
       'Ingreso', 'Puntual', 0, 4, CAST(CAST(GETDATE() AS DATE) AS DATETIME) + CAST(t.HoraInicio AS DATETIME)
FROM Colaborador c JOIN Turno t ON t.TurnoID = c.TurnoID
WHERE c.DNI IN ('10000003', '10000004');
GO

PRINT 'Base de datos AsisTrackDB creada correctamente.';
SELECT 'Marcaciones' AS Tabla, COUNT(*) AS Registros FROM Marcacion
UNION ALL SELECT 'Justificaciones', COUNT(*) FROM Justificacion
UNION ALL SELECT 'Colaboradores', COUNT(*) FROM Colaborador;
GO
