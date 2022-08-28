CREATE DATABASE [NTT_Test]
GO

USE [NTT_Test]
GO
/****** Object:  Table [dbo].[clienteNTT]    Script Date: 28/08/2022 18:10:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clienteNTT](
	[cli_id] [int] IDENTITY(1,1) NOT NULL,
	[cli_usuario] [varchar](16) NOT NULL,
	[cli_contrasena] [varchar](500) NOT NULL,
	[cli_salt] [varchar](500) NOT NULL,
	[cli_estado] [bit] NOT NULL,
	[cli_personaId] [int] NOT NULL,
 CONSTRAINT [PK_clienteNTT] PRIMARY KEY CLUSTERED 
(
	[cli_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentaNTT]    Script Date: 28/08/2022 18:10:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentaNTT](
	[cue_numero_cuenta] [varchar](16) NOT NULL,
	[cue_tipo_cuenta] [varchar](16) NOT NULL,
	[cue_saldo_inicial] [decimal](15, 3) NOT NULL,
	[cue_estado] [bit] NOT NULL,
	[cue_clienteId] [int] NOT NULL,
	[cue_id] [int] NOT NULL,
 CONSTRAINT [PK_cuentaNTT] PRIMARY KEY CLUSTERED 
(
	[cue_numero_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movimientoNTT]    Script Date: 28/08/2022 18:10:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movimientoNTT](
	[mov_id] [int] IDENTITY(1,1) NOT NULL,
	[mov_usuario] [datetime] NOT NULL,
	[mov_tipo_movimiento] [varchar](16) NOT NULL,
	[mov_valor] [decimal](15, 3) NOT NULL,
	[mov_saldo] [decimal](15, 3) NOT NULL,
	[mov_cuentaId] [varchar](16) NOT NULL,
 CONSTRAINT [PK_movimientoNTT] PRIMARY KEY CLUSTERED 
(
	[mov_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personaNTT]    Script Date: 28/08/2022 18:10:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personaNTT](
	[per_id] [int] IDENTITY(1,1) NOT NULL,
	[per_identificacion] [varchar](16) NOT NULL,
	[per_nombre] [varchar](64) NOT NULL,
	[per_genero] [varchar](10) NOT NULL,
	[per_edad] [int] NOT NULL,
	[per_direccion] [varchar](128) NOT NULL,
	[per_telefono] [varchar](16) NULL,
	[per_clientId] [int] NOT NULL,
 CONSTRAINT [PK_personaNTT] PRIMARY KEY CLUSTERED 
(
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clienteNTT] ON 
GO
INSERT [dbo].[clienteNTT] ([cli_id], [cli_usuario], [cli_contrasena], [cli_salt], [cli_estado], [cli_personaId]) VALUES (2, N'jlema', N'cQ0YnRkFowvrUfKRfXba5d83LE8BYKdW2Qk9NjiBr7M=', N'8qxRwPHiXAw4+31OHX8KqQ==', 1, 4)
GO
INSERT [dbo].[clienteNTT] ([cli_id], [cli_usuario], [cli_contrasena], [cli_salt], [cli_estado], [cli_personaId]) VALUES (3, N'mmontalvo', N'YigaOgRiSwzs7B5Ebk2MqHprzgJtGpvFALQJy0zj7mQ=', N'fLa+Ra+32f4HYkxwnZ74cg==', 1, 5)
GO
INSERT [dbo].[clienteNTT] ([cli_id], [cli_usuario], [cli_contrasena], [cli_salt], [cli_estado], [cli_personaId]) VALUES (4, N'josorio', N'ryxQwUSub/oPjhQHYoxPQt3nOZGkaeyObDAdkqYe0JI=', N'aYTDzMP2I1aTutAIpZcCtQ==', 1, 6)
GO
SET IDENTITY_INSERT [dbo].[clienteNTT] OFF
GO
INSERT [dbo].[cuentaNTT] ([cue_numero_cuenta], [cue_tipo_cuenta], [cue_saldo_inicial], [cue_estado], [cue_clienteId], [cue_id]) VALUES (N'225487', N'Corriente', CAST(100.000 AS Decimal(15, 3)), 1, 3, 0)
GO
INSERT [dbo].[cuentaNTT] ([cue_numero_cuenta], [cue_tipo_cuenta], [cue_saldo_inicial], [cue_estado], [cue_clienteId], [cue_id]) VALUES (N'478758', N'Ahorro', CAST(2000.000 AS Decimal(15, 3)), 1, 2, 0)
GO
INSERT [dbo].[cuentaNTT] ([cue_numero_cuenta], [cue_tipo_cuenta], [cue_saldo_inicial], [cue_estado], [cue_clienteId], [cue_id]) VALUES (N'495878', N'Ahorros', CAST(0.000 AS Decimal(15, 3)), 1, 4, 0)
GO
INSERT [dbo].[cuentaNTT] ([cue_numero_cuenta], [cue_tipo_cuenta], [cue_saldo_inicial], [cue_estado], [cue_clienteId], [cue_id]) VALUES (N'496825', N'Ahorros', CAST(540.000 AS Decimal(15, 3)), 1, 3, 0)
GO
INSERT [dbo].[cuentaNTT] ([cue_numero_cuenta], [cue_tipo_cuenta], [cue_saldo_inicial], [cue_estado], [cue_clienteId], [cue_id]) VALUES (N'585545', N'Corriente', CAST(1000.000 AS Decimal(15, 3)), 1, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[movimientoNTT] ON 
GO
INSERT [dbo].[movimientoNTT] ([mov_id], [mov_usuario], [mov_tipo_movimiento], [mov_valor], [mov_saldo], [mov_cuentaId]) VALUES (1, CAST(N'2022-08-28T06:53:51.217' AS DateTime), N'Debito', CAST(-575.000 AS Decimal(15, 3)), CAST(1425.000 AS Decimal(15, 3)), N'478758')
GO
INSERT [dbo].[movimientoNTT] ([mov_id], [mov_usuario], [mov_tipo_movimiento], [mov_valor], [mov_saldo], [mov_cuentaId]) VALUES (2, CAST(N'2022-02-10T15:30:10.413' AS DateTime), N'Deposito', CAST(600.000 AS Decimal(15, 3)), CAST(700.000 AS Decimal(15, 3)), N'225487')
GO
INSERT [dbo].[movimientoNTT] ([mov_id], [mov_usuario], [mov_tipo_movimiento], [mov_valor], [mov_saldo], [mov_cuentaId]) VALUES (3, CAST(N'2022-08-14T15:30:10.413' AS DateTime), N'Deposito', CAST(150.000 AS Decimal(15, 3)), CAST(150.000 AS Decimal(15, 3)), N'495878')
GO
INSERT [dbo].[movimientoNTT] ([mov_id], [mov_usuario], [mov_tipo_movimiento], [mov_valor], [mov_saldo], [mov_cuentaId]) VALUES (4, CAST(N'2022-02-08T15:30:10.413' AS DateTime), N'Debito', CAST(-540.000 AS Decimal(15, 3)), CAST(0.000 AS Decimal(15, 3)), N'496825')
GO
SET IDENTITY_INSERT [dbo].[movimientoNTT] OFF
GO
SET IDENTITY_INSERT [dbo].[personaNTT] ON 
GO
INSERT [dbo].[personaNTT] ([per_id], [per_identificacion], [per_nombre], [per_genero], [per_edad], [per_direccion], [per_telefono], [per_clientId]) VALUES (4, N'3001020304', N'Jose Lema', N'Masculino', 20, N'Otavalo sn y principal', N'098254785 ', 0)
GO
INSERT [dbo].[personaNTT] ([per_id], [per_identificacion], [per_nombre], [per_genero], [per_edad], [per_direccion], [per_telefono], [per_clientId]) VALUES (5, N'3101020304', N'Marianela Montalvo', N'Femenino', 25, N'Amazonas y NNUU', N'097548965 ', 0)
GO
INSERT [dbo].[personaNTT] ([per_id], [per_identificacion], [per_nombre], [per_genero], [per_edad], [per_direccion], [per_telefono], [per_clientId]) VALUES (6, N'3201020304', N'Juan Osorio', N'Masculino', 40, N'13 junio y Equinoccial', N'098874587 ', 0)
GO
SET IDENTITY_INSERT [dbo].[personaNTT] OFF
GO
ALTER TABLE [dbo].[clienteNTT] ADD  DEFAULT (CONVERT([bit],(1))) FOR [cli_estado]
GO
ALTER TABLE [dbo].[cuentaNTT] ADD  DEFAULT (CONVERT([bit],(1))) FOR [cue_estado]
GO
ALTER TABLE [dbo].[clienteNTT]  WITH CHECK ADD  CONSTRAINT [FK_clienteNTT_personaNTT_cli_personaId] FOREIGN KEY([cli_personaId])
REFERENCES [dbo].[personaNTT] ([per_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[clienteNTT] CHECK CONSTRAINT [FK_clienteNTT_personaNTT_cli_personaId]
GO
ALTER TABLE [dbo].[cuentaNTT]  WITH CHECK ADD  CONSTRAINT [FK_cuentaNTT_clienteNTT_cue_clienteId] FOREIGN KEY([cue_clienteId])
REFERENCES [dbo].[clienteNTT] ([cli_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cuentaNTT] CHECK CONSTRAINT [FK_cuentaNTT_clienteNTT_cue_clienteId]
GO
ALTER TABLE [dbo].[movimientoNTT]  WITH CHECK ADD  CONSTRAINT [FK_movimientoNTT_cuentaNTT_mov_cuentaId] FOREIGN KEY([mov_cuentaId])
REFERENCES [dbo].[cuentaNTT] ([cue_numero_cuenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[movimientoNTT] CHECK CONSTRAINT [FK_movimientoNTT_cuentaNTT_mov_cuentaId]
GO
