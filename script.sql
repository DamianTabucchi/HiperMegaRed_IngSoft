USE [master]
GO
/****** Object:  Database [HMR]    Script Date: 28/10/2024 18:57:07 ******/
CREATE DATABASE [HMR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HMR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\HMR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HMR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\HMR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HMR] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HMR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HMR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HMR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HMR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HMR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HMR] SET ARITHABORT OFF 
GO
ALTER DATABASE [HMR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HMR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HMR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HMR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HMR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HMR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HMR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HMR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HMR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HMR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HMR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HMR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HMR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HMR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HMR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HMR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HMR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HMR] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HMR] SET  MULTI_USER 
GO
ALTER DATABASE [HMR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HMR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HMR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HMR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HMR] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HMR] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HMR] SET QUERY_STORE = OFF
GO
USE [HMR]
GO
/****** Object:  Table [dbo].[bcproductos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bcproductos](
	[id] [uniqueidentifier] NOT NULL,
	[producto_id] [uniqueidentifier] NOT NULL,
	[producto_nombre] [nvarchar](50) NOT NULL,
	[producto_marca] [nvarchar](50) NOT NULL,
	[producto_modelo] [nvarchar](50) NOT NULL,
	[producto_tipo] [varchar](15) NOT NULL,
	[producto_stock] [int] NOT NULL,
	[producto_deposito] [nvarchar](50) NOT NULL,
	[producto_descripcion] [nvarchar](50) NOT NULL,
	[producto_precio_unidad] [float] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[producto_punto_pedido] [int] NULL,
	[producto_activo] [bit] NULL,
	[producto_proveedor] [uniqueidentifier] NULL,
 CONSTRAINT [PK__bcproduc__3213E83F046FB25C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bitacoras]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacoras](
	[Id] [uniqueidentifier] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[fechacreacion] [datetime] NOT NULL,
	[criticidad] [varchar](50) NOT NULL,
	[modulo] [varchar](50) NOT NULL,
	[accion] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bitacorascambios]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacorascambios](
	[id] [uniqueidentifier] NOT NULL,
	[bc_producto_id] [uniqueidentifier] NOT NULL,
	[bc_activo] [bit] NOT NULL,
	[bc_producto_nombre] [nvarchar](50) NOT NULL,
	[bc_producto_marca] [nvarchar](50) NOT NULL,
	[bc_producto_modelo] [nvarchar](50) NOT NULL,
	[bc_producto_tipo] [varchar](15) NOT NULL,
	[bc_producto_stock] [int] NOT NULL,
	[bc_producto_deposito] [nvarchar](50) NOT NULL,
	[bc_producto_descripcion] [nvarchar](50) NOT NULL,
	[bc_producto_precio_unidad] [float] NOT NULL,
	[bc_producto_punto_pedido] [int] NULL,
	[bc_producto_activo] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carritos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carritos](
	[id] [uniqueidentifier] NOT NULL,
	[carrito_cliente_dni] [decimal](9, 0) NULL,
	[carrito_fecha] [datetime] NULL,
	[carrito_preciototal] [float] NULL,
	[carrito_pagado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carritos_productos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carritos_productos](
	[id_carrito] [uniqueidentifier] NOT NULL,
	[id_producto] [uniqueidentifier] NOT NULL,
	[cantidad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[cliente_dni] [decimal](9, 0) NOT NULL,
	[cliente_nombre] [nvarchar](50) NULL,
	[cliente_apellido] [nvarchar](50) NULL,
	[cliente_mail] [varchar](max) NULL,
	[cliente_telefono] [varchar](max) NULL,
 CONSTRAINT [PK__clientes__506C3DE1B614CCBA] PRIMARY KEY CLUSTERED 
(
	[cliente_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cotizaciones]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cotizaciones](
	[Id] [uniqueidentifier] NOT NULL,
	[cotizacion_numero] [int] NOT NULL,
	[cotizacion_fecha_emision] [datetime] NOT NULL,
	[cotizacion_fecha_entrega] [date] NOT NULL,
	[cotizacion_proveedor_id] [uniqueidentifier] NOT NULL,
	[cotizacion_solcot_id] [uniqueidentifier] NOT NULL,
	[cotizacion_monto_total] [float] NOT NULL,
	[cotizacion_condiciones] [varchar](100) NOT NULL,
 CONSTRAINT [PK_cotizaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cotizacionproductos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cotizacionproductos](
	[id_cotizacion] [uniqueidentifier] NOT NULL,
	[id_productocotizado] [uniqueidentifier] NOT NULL,
	[cantidad] [int] NOT NULL,
	[productocotizado_precio_unidad] [float] NOT NULL,
	[productocotizado_total] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[id] [uniqueidentifier] NOT NULL,
	[factura_fecha] [datetime] NULL,
	[factura_carrito_id] [uniqueidentifier] NULL,
	[factura_monto] [float] NULL,
	[factura_cliente_dni] [decimal](9, 0) NULL,
	[factura_productos_entregados] [bit] NULL,
	[factura_metodo_pago] [nchar](10) NULL,
	[factura_vuelto] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idiomas](
	[Id] [varchar](5) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Idiomas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordenes_de_pago]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordenes_de_pago](
	[id] [uniqueidentifier] NOT NULL,
	[orden_fecha] [datetime] NULL,
	[orden_cliente_dni] [decimal](9, 0) NOT NULL,
	[orden_carrito_id] [uniqueidentifier] NOT NULL,
	[orden_total] [float] NULL,
	[orden_pago] [bit] NULL,
 CONSTRAINT [PK_ordenes_de_pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordenesdereposicion]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordenesdereposicion](
	[Id] [uniqueidentifier] NOT NULL,
	[orden_numero] [int] NOT NULL,
	[orden_fecha_creacion] [datetime] NOT NULL,
	[orden_fecha_aprobacion] [datetime] NULL,
	[orden_justificacion] [varchar](250) NULL,
	[orden_estado] [varchar](50) NOT NULL,
	[orden_solicitante] [uniqueidentifier] NOT NULL,
	[orden_aprobador] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ordenesdereposicion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordenproductos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordenproductos](
	[id_orden_reposicion] [uniqueidentifier] NOT NULL,
	[id_prodsol] [uniqueidentifier] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_ordenproductos] PRIMARY KEY CLUSTERED 
(
	[id_orden_reposicion] ASC,
	[id_prodsol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[permiso] [nvarchar](50) NULL,
 CONSTRAINT [PK_permiso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso_permiso]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_permiso](
	[id_permiso_padre] [int] NOT NULL,
	[id_permiso_hijo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prodsol]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prodsol](
	[Id] [uniqueidentifier] NOT NULL,
	[prodsol_producto_id] [uniqueidentifier] NOT NULL,
	[prodsol_cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[Id] [uniqueidentifier] NOT NULL,
	[producto_nombre] [nvarchar](50) NOT NULL,
	[producto_marca] [nvarchar](50) NOT NULL,
	[producto_modelo] [nvarchar](50) NOT NULL,
	[producto_tipo] [varchar](15) NOT NULL,
	[producto_stock] [int] NOT NULL,
	[producto_deposito] [nvarchar](50) NOT NULL,
	[producto_descripcion] [nvarchar](50) NOT NULL,
	[producto_precio_unidad] [float] NOT NULL,
	[producto_punto_pedido] [int] NULL,
	[producto_activo] [bit] NULL,
	[producto_proveedor] [uniqueidentifier] NULL,
 CONSTRAINT [PK__producto__FB5CEEEC4D7DE71B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[Id] [uniqueidentifier] NOT NULL,
	[proveedor_cuit] [bigint] NOT NULL,
	[proveedor_nombre] [varchar](50) NOT NULL,
	[proveedor_nombre_poc] [varchar](50) NOT NULL,
	[proveedor_direccion] [varchar](50) NOT NULL,
	[proveedor_telefono] [varchar](50) NOT NULL,
	[proveedor_email] [varchar](50) NOT NULL,
	[proveedor_categoria] [varchar](50) NOT NULL,
	[proveedor_notas_adicionales] [varchar](100) NULL,
	[proveedor_activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solicitudesdecotizacion]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solicitudesdecotizacion](
	[Id] [uniqueidentifier] NOT NULL,
	[solcot_fecha_solicitud] [datetime] NOT NULL,
	[solcot_ordenrepo_id] [uniqueidentifier] NOT NULL,
	[solcot_proveedor] [uniqueidentifier] NOT NULL,
	[solcot_solicitante] [uniqueidentifier] NOT NULL,
	[solcot_numero_solicitud] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solicitudproductos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solicitudproductos](
	[id_solcot] [uniqueidentifier] NOT NULL,
	[id_solprod] [uniqueidentifier] NOT NULL,
	[cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[testeo]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[testeo](
	[Prueba] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traducciones]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traducciones](
	[Idioma] [varchar](5) NOT NULL,
	[Clave] [varchar](255) NOT NULL,
	[Valor] [varchar](500) NULL,
 CONSTRAINT [PK_Traducciones] PRIMARY KEY CLUSTERED 
(
	[Idioma] ASC,
	[Clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[LastLogin] [date] NULL,
	[FailCount] [int] NULL,
	[Language] [nvarchar](50) NULL,
	[Expired] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[DNI] [decimal](9, 0) NULL,
	[DVHorizontal] [int] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios_permisos]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_permisos](
	[id_permiso] [int] NOT NULL,
	[id_usuario] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[permiso_permiso]  WITH CHECK ADD  CONSTRAINT [FK_permiso_permiso_permiso] FOREIGN KEY([id_permiso_padre])
REFERENCES [dbo].[permiso] ([id])
GO
ALTER TABLE [dbo].[permiso_permiso] CHECK CONSTRAINT [FK_permiso_permiso_permiso]
GO
ALTER TABLE [dbo].[permiso_permiso]  WITH CHECK ADD  CONSTRAINT [FK_permiso_permiso_permiso1] FOREIGN KEY([id_permiso_hijo])
REFERENCES [dbo].[permiso] ([id])
GO
ALTER TABLE [dbo].[permiso_permiso] CHECK CONSTRAINT [FK_permiso_permiso_permiso1]
GO
ALTER TABLE [dbo].[usuarios_permisos]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_permisos_permiso] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[permiso] ([id])
GO
ALTER TABLE [dbo].[usuarios_permisos] CHECK CONSTRAINT [FK_usuarios_permisos_permiso]
GO
ALTER TABLE [dbo].[usuarios_permisos]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_permisos_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([Id])
GO
ALTER TABLE [dbo].[usuarios_permisos] CHECK CONSTRAINT [FK_usuarios_permisos_usuarios]
GO
ALTER TABLE [dbo].[bcproductos]  WITH CHECK ADD  CONSTRAINT [CK__bcproduct__produ__30C33EC3] CHECK  (([producto_tipo]='Otros' OR [producto_tipo]='RAM' OR [producto_tipo]='GPU' OR [producto_tipo]='CPU' OR [producto_tipo]='Motherboard' OR [producto_tipo]='Silla' OR [producto_tipo]='Headset' OR [producto_tipo]='Microfono' OR [producto_tipo]='Auriculares' OR [producto_tipo]='PAD' OR [producto_tipo]='Teclado' OR [producto_tipo]='Mouse'))
GO
ALTER TABLE [dbo].[bcproductos] CHECK CONSTRAINT [CK__bcproduct__produ__30C33EC3]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [CK__productos__produ__2DE6D218] CHECK  (([producto_tipo]='Otros' OR [producto_tipo]='RAM' OR [producto_tipo]='GPU' OR [producto_tipo]='CPU' OR [producto_tipo]='Motherboard' OR [producto_tipo]='Silla' OR [producto_tipo]='Headset' OR [producto_tipo]='Microfono' OR [producto_tipo]='Auriculares' OR [producto_tipo]='PAD' OR [producto_tipo]='Teclado' OR [producto_tipo]='Mouse'))
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [CK__productos__produ__2DE6D218]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [CK__productos__produ__36B12243] CHECK  (([producto_tipo]='Otros' OR [producto_tipo]='RAM' OR [producto_tipo]='GPU' OR [producto_tipo]='CPU' OR [producto_tipo]='Motherboard' OR [producto_tipo]='Silla' OR [producto_tipo]='Headset' OR [producto_tipo]='Microfono' OR [producto_tipo]='Auriculares' OR [producto_tipo]='PAD' OR [producto_tipo]='Teclado' OR [producto_tipo]='Mouse'))
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [CK__productos__produ__36B12243]
GO
/****** Object:  StoredProcedure [dbo].[Carrito_Insert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Carrito_Insert] 
	-- Add the parameters for the stored procedure here
	@cartID UNIQUEIDENTIFIER,
	@cartClientID DECIMAL (9, 0),
	@cartEmisionDate DATETIME,
	@cartTotal FLOAT,
	@cartpayed BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO carritos (id, carrito_cliente_dni, carrito_fecha, carrito_preciototal, carrito_pagado)
	VALUES (@cartID, @cartClientID, @cartEmisionDate, @cartTotal, @cartpayed)
END
GO
/****** Object:  StoredProcedure [dbo].[proveedor_upsert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[proveedor_upsert]
    @provId UNIQUEIDENTIFIER,
    @provCuit BIGINT,
    @provNombre VARCHAR(50),
    @provNombrePoc VARCHAR(50),
    @provDireccion VARCHAR(50),
    @provTelefono VARCHAR(50),
    @provEmail VARCHAR(50),
    @provCategoria VARCHAR(50),
    @provNotasAdicionales VARCHAR(100),
	@provActivo BIT
AS
BEGIN
    -- Inicia una transacción para asegurar atomicidad en caso de que haya errores
    BEGIN TRANSACTION

    -- Verifica si el proveedor ya existe en la tabla mediante su Id
    IF EXISTS (SELECT 1 FROM proveedores WHERE Id = @provId)
    BEGIN
        -- Si existe, realiza un update
        UPDATE proveedores
        SET 
            proveedor_cuit = @provCuit,
            proveedor_nombre = @provNombre,
            proveedor_nombre_poc = @provNombrePoc,
            proveedor_direccion = @provDireccion,
            proveedor_telefono = @provTelefono,
            proveedor_email = @provEmail,
            proveedor_categoria = @provCategoria,
            proveedor_notas_adicionales = @provNotasAdicionales,
			proveedor_activo = @provActivo
        WHERE Id = @provId;
    END
    ELSE
    BEGIN
        -- Si no existe, realiza un insert
        INSERT INTO proveedores (
            Id,
            proveedor_cuit,
            proveedor_nombre,
            proveedor_nombre_poc,
            proveedor_direccion,
            proveedor_telefono,
            proveedor_email,
            proveedor_categoria,
            proveedor_notas_adicionales,
			proveedor_activo
        )
        VALUES (
            @provId,
            @provCuit,
            @provNombre,
            @provNombrePoc,
            @provDireccion,
            @provTelefono,
            @provEmail,
            @provCategoria,
            @provNotasAdicionales,
			@provActivo
        );
    END

    -- Confirma la transacción
    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_cliente_insert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_cliente_insert]
	@clientdni DECIMAL (9, 0),
	@clientname NVARCHAR(50),
	@clientapellido NVARCHAR(50),
	@clientmail NVARCHAR(50),
	@clienttel NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO clientes (cliente_dni, cliente_nombre, cliente_apellido, cliente_mail, cliente_telefono)
	VALUES (@clientdni, @clientname, @clientapellido, @clientmail, @clienttel)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_factura_insert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_factura_insert]
	@factid UNIQUEIDENTIFIER,
	@factfecha DATETIME,
	@factcart UNIQUEIDENTIFIER,
	@factmonto FLOAT,
	@factclientdni DECIMAL (9, 0),
	@factentregado BIT,
	@facturametodo nchar(10),
	@facturavuelto FLOAT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO facturas (id, factura_fecha, factura_carrito_id, factura_monto, factura_cliente_dni, factura_productos_entregados, factura_metodo_pago, factura_vuelto)
	VALUES (@factid, @factfecha, @factcart, @factmonto, @factclientdni, @factentregado, @facturametodo, @facturavuelto)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Idioma_Upsert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Idioma_Upsert]
	-- Add the parameters for the stored procedure here
	@idioma varchar(5), 
	@descripcion varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	  BEGIN TRAN
 
		IF EXISTS ( SELECT * FROM dbo.Idiomas WITH (UPDLOCK) WHERE id = @idioma)
 
		  UPDATE dbo.Idiomas
			 SET Id = @idioma, Descripcion = @descripcion
		   WHERE id = @idioma;
 
		ELSE 
 
		  INSERT dbo.Idiomas( Id, Descripcion)
		  VALUES ( @idioma,@descripcion);
 
	  COMMIT
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Orden_Insert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Orden_Insert]
	@orderid UNIQUEIDENTIFIER,
	@orderfecha DATETIME,
	@orderclientdni DECIMAL (9, 0),
	@ordercartid UNIQUEIDENTIFIER,
	@orderamount FLOAT,
	@orderpago BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO ordenes_de_pago (id, orden_fecha, orden_cliente_dni, orden_carrito_id, orden_total, orden_pago)
	VALUES (@orderid, @orderfecha, @orderclientdni, @ordercartid, @orderamount, @orderpago)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Producto_UpdateOrInsert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Producto_UpdateOrInsert]
	@prodId UNIQUEIDENTIFIER,
	@prodName NVARCHAR(50),
	@prodMarc NVARCHAR(50),
	@prodModel NVARCHAR(50),
	@prodType VARCHAR(15),
	@prodDepo NVARCHAR(50),
	@prodDesc NVARCHAR(50),
	@prodPrec FLOAT,
	@prodStock INT,
	@prodPP INT,
	@prodAct BIT,
	@prodProveedor UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT 1 FROM productos WHERE id = @prodId)
	BEGIN
		UPDATE productos
		SET
			producto_nombre = @prodName,
			producto_marca = @prodMarc,
			producto_modelo = @prodModel,
            producto_tipo = @prodType,
            producto_precio_unidad = @prodPrec,
            producto_stock = @prodStock,
            producto_deposito = @prodDepo,
            producto_descripcion = @prodDesc,
			producto_punto_pedido = @prodPP,
			producto_activo = @prodAct,
			producto_proveedor = @prodProveedor
        WHERE id = @prodId;
	END
	ELSE
	BEGIN
		INSERT INTO productos (id, producto_nombre, producto_marca, producto_modelo, producto_tipo, producto_precio_unidad, producto_stock, producto_deposito, producto_descripcion, producto_punto_pedido, producto_activo, producto_proveedor)
		VALUES (@prodId, @prodName, @prodMarc, @prodModel, @prodType, @prodPrec, @prodStock, @prodDepo, @prodDesc, @prodPP, @prodAct, @prodProveedor)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Traducciones_Upsert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Traducciones_Upsert]
	-- Add the parameters for the stored procedure here
	@idioma varchar(5), 
	@clave varchar(255),
	@valor varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	  BEGIN TRAN
 
		IF EXISTS ( SELECT * FROM dbo.Traducciones WITH (UPDLOCK) WHERE idioma = @idioma AND clave = @clave)
 
		  UPDATE dbo.Traducciones
			 SET valor = @valor
		   WHERE idioma = @idioma AND clave = @clave;
 
		ELSE 
 
		  INSERT dbo.Traducciones ( idioma, clave, valor )
		  VALUES ( @idioma, @clave,@valor );
 
	  COMMIT
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Usuario_UpdateOrInsert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Usuario_UpdateOrInsert]
    @Id UNIQUEIDENTIFIER,
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @LastLogin DATE,
    @FailCount INT,
    @Language NVARCHAR(50),
    @Expired BIT,
    @Name NVARCHAR(50),
    @Lastname NVARCHAR(50),
    @Mail NVARCHAR(50),
    @Phone NVARCHAR(50),
	@dni Decimal (9, 0),
	@dvh INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the user already exists in the usuarios table
    IF EXISTS (SELECT 1 FROM usuarios WHERE Id = @Id)
    BEGIN
        -- User exists, update the information
        UPDATE usuarios
        SET Username = @Username,
            Password = @Password,
            LastLogin = @LastLogin,
            FailCount = @FailCount,
            Language = @Language,
            Expired = @Expired,
            Name = @Name,
            Lastname = @Lastname,
            Mail = @Mail,
            Phone = @Phone,
			DNI = @DNI,
			DVHorizontal = @dvh
        WHERE Id = @Id;
    END
    ELSE
    BEGIN
        -- User does not exist, insert a new row
        INSERT INTO usuarios (Id, Username, Password, LastLogin, FailCount, Language, Expired, Name, Lastname, Mail, Phone, DNI, DVHorizontal)
        VALUES (@Id, @Username, @Password, @LastLogin, @FailCount, @Language, @Expired, @Name, @Lastname, @Mail, @Phone, @dni, @dvh);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Usuario_Upsert]    Script Date: 28/10/2024 18:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Usuario_Upsert]
    @Id UNIQUEIDENTIFIER,
    @Username NVARCHAR(50),
    @Password NVARCHAR(50),
    @LastLogin DATE,
    @FailCount INT,
    @Language NVARCHAR(50),
    @Expired BIT,
    @Name NVARCHAR(50),
    @Lastname NVARCHAR(50),
    @Mail NVARCHAR(50),
    @Phone NVARCHAR(50)
AS
BEGIN
    UPDATE usuarios
    SET
        Username = @Username,
        Password = @Password,
        LastLogin = @LastLogin,
        FailCount = @FailCount,
        Language = @Language,
        Expired = @Expired,
        Name = @Name,
        Lastname = @Lastname,
        Mail = @Mail,
        Phone = @Phone
    WHERE
        Id = @Id;
END
GO
USE [master]
GO
ALTER DATABASE [HMR] SET  READ_WRITE 
GO
