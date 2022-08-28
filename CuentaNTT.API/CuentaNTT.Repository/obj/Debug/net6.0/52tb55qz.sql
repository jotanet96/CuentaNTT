IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [personaNTT] (
    [per_id] int NOT NULL IDENTITY,
    [per_identificacion] varchar(16) NOT NULL,
    [per_nombre] varchar(64) NOT NULL,
    [per_genero] varchar(10) NOT NULL,
    [per_edad] int NOT NULL,
    [per_direccion] varchar(128) NOT NULL,
    [per_telefono] varchar(16) NULL,
    [per_clientId] int NOT NULL,
    CONSTRAINT [PK_personaNTT] PRIMARY KEY ([per_id])
);
GO

CREATE TABLE [clienteNTT] (
    [cli_id] int NOT NULL IDENTITY,
    [cli_usuario] varchar(16) NOT NULL,
    [cli_contrasena] varchar(500) NOT NULL,
    [cli_salt] varchar(500) NOT NULL,
    [cli_estado] bit NOT NULL DEFAULT CAST(1 AS bit),
    [cli_personaId] int NOT NULL,
    CONSTRAINT [PK_clienteNTT] PRIMARY KEY ([cli_id]),
    CONSTRAINT [FK_clienteNTT_personaNTT_cli_personaId] FOREIGN KEY ([cli_personaId]) REFERENCES [personaNTT] ([per_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [cuentaNTT] (
    [cue_numero_cuenta] varchar(16) NOT NULL,
    [cue_tipo_cuenta] varchar(16) NOT NULL,
    [cue_saldo_inicial] decimal(15,3) NOT NULL,
    [cue_estado] bit NOT NULL DEFAULT CAST(1 AS bit),
    [cue_clienteId] int NOT NULL,
    [cue_id] int NOT NULL,
    CONSTRAINT [PK_cuentaNTT] PRIMARY KEY ([cue_numero_cuenta]),
    CONSTRAINT [FK_cuentaNTT_clienteNTT_cue_clienteId] FOREIGN KEY ([cue_clienteId]) REFERENCES [clienteNTT] ([cli_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [movimientoNTT] (
    [mov_id] int NOT NULL IDENTITY,
    [mov_usuario] datetime NOT NULL,
    [mov_tipo_movimiento] varchar(16) NOT NULL,
    [mov_valor] decimal(15,3) NOT NULL,
    [mov_saldo] decimal(15,3) NOT NULL,
    [mov_cuentaId] varchar(16) NOT NULL,
    CONSTRAINT [PK_movimientoNTT] PRIMARY KEY ([mov_id]),
    CONSTRAINT [FK_movimientoNTT_cuentaNTT_mov_cuentaId] FOREIGN KEY ([mov_cuentaId]) REFERENCES [cuentaNTT] ([cue_numero_cuenta]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_clienteNTT_cli_personaId] ON [clienteNTT] ([cli_personaId]);
GO

CREATE INDEX [IX_cuentaNTT_cue_clienteId] ON [cuentaNTT] ([cue_clienteId]);
GO

CREATE INDEX [IX_movimientoNTT_mov_cuentaId] ON [movimientoNTT] ([mov_cuentaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220827173627_CuentaNTT', N'6.0.8');
GO

COMMIT;
GO

