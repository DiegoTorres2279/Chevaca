USE [master]
GO
/****** Object:  Database [chevacadb]    Script Date: 04/04/2021 03:53:15 ******/
CREATE DATABASE [chevacadb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'chevacadb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\chevacadb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'chevacadb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\chevacadb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [chevacadb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [chevacadb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [chevacadb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [chevacadb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [chevacadb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [chevacadb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [chevacadb] SET ARITHABORT OFF 
GO
ALTER DATABASE [chevacadb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [chevacadb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [chevacadb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [chevacadb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [chevacadb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [chevacadb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [chevacadb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [chevacadb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [chevacadb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [chevacadb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [chevacadb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [chevacadb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [chevacadb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [chevacadb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [chevacadb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [chevacadb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [chevacadb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [chevacadb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [chevacadb] SET  MULTI_USER 
GO
ALTER DATABASE [chevacadb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [chevacadb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [chevacadb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [chevacadb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [chevacadb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [chevacadb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'chevacadb', N'ON'
GO
ALTER DATABASE [chevacadb] SET QUERY_STORE = OFF
GO
USE [chevacadb]
GO
/****** Object:  User [chevaca_login]    Script Date: 04/04/2021 03:53:15 ******/
CREATE USER [chevaca_login] FOR LOGIN [chevaca_login] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [chevaca_login]
GO
/****** Object:  Table [dbo].[aportes_energias]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aportes_energias](
	[Aporte_energia_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_aportes_energias] PRIMARY KEY CLUSTERED 
(
	[Aporte_energia_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aportes_proteinas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aportes_proteinas](
	[Aporte_proteina_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_aportes_proteinas] PRIMARY KEY CLUSTERED 
(
	[Aporte_proteina_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bebederos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bebederos](
	[Bebedero_ID] [int] IDENTITY(2,1) NOT NULL,
 CONSTRAINT [PK_bebederos] PRIMARY KEY CLUSTERED 
(
	[Bebedero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[camioneros]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[camioneros](
	[Camionero_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_camioneros] PRIMARY KEY CLUSTERED 
(
	[Camionero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[caravanas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[caravanas](
	[Caravana_ID] [int] IDENTITY(2,1) NOT NULL,
	[Numero_Ministerio] [varchar](100) NOT NULL,
	[Dev_Eui] [varchar](100) NOT NULL,
	[Description] [varchar](100) NULL,
	[VacaID] [int] NOT NULL,
 CONSTRAINT [PK_caravana_id] PRIMARY KEY CLUSTERED 
(
	[Numero_Ministerio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chirpstack_devices]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chirpstack_devices](
	[Dev_Eui] [varchar](100) NOT NULL,
	[Ch_Dev_App_Key] [varchar](100) NOT NULL,
	[Ch_St_Prfile_Id] [varchar](100) NOT NULL,
	[Ch_App_ID] [varchar](100) NOT NULL,
 CONSTRAINT [PK_chirpstack] PRIMARY KEY CLUSTERED 
(
	[Dev_Eui] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comederos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comederos](
	[Comedero_ID] [int] IDENTITY(2,1) NOT NULL,
 CONSTRAINT [PK_comederos] PRIMARY KEY CLUSTERED 
(
	[Comedero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dependientes]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dependientes](
	[Dependiente_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
	[Usuario_ID] [int] NOT NULL,
 CONSTRAINT [PK_dependientes] PRIMARY KEY CLUSTERED 
(
	[Dependiente_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dormideros]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dormideros](
	[Dormidero_ID] [int] IDENTITY(2,1) NOT NULL,
 CONSTRAINT [PK_dormideros] PRIMARY KEY CLUSTERED 
(
	[Dormidero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[escritorio_rurales]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[escritorio_rurales](
	[Escritorio_rural_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_escritorio_rurales] PRIMARY KEY CLUSTERED 
(
	[Escritorio_rural_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estancia_campos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estancia_campos](
	[Estancia_campos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Estancia_ID] [int] NOT NULL,
	[Descripcion] [varchar](1) NULL,
	[ChirpstackApplication_ID] [int] NOT NULL,
 CONSTRAINT [PK_estancia_campos] PRIMARY KEY CLUSTERED 
(
	[Estancia_campos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estancia_campos_padrones]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estancia_campos_padrones](
	[Estancia_campos_padrones_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_Campos_ID] [int] NOT NULL,
 CONSTRAINT [PK_estancia_campos_padrones] PRIMARY KEY CLUSTERED 
(
	[Estancia_campos_padrones_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estancia_campos_potreros]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estancia_campos_potreros](
	[Estancia_campos_potreros_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
 CONSTRAINT [PK_estancia_campos_potreros] PRIMARY KEY CLUSTERED 
(
	[Estancia_campos_potreros_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estancia_duenos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estancia_duenos](
	[Estancia_dueno_ID] [int] IDENTITY(2,1) NOT NULL,
	[Persona_ID] [int] NOT NULL,
	[Estancia_ID] [int] NOT NULL,
 CONSTRAINT [PK_estancia_duenos] PRIMARY KEY CLUSTERED 
(
	[Estancia_dueno_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estancias]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estancias](
	[Estancia_ID] [int] IDENTITY(1,1) NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Empresa_RUT] [varchar](50) NULL,
	[Empresa_Nombre] [varchar](50) NOT NULL,
	[Empresa_Dominio] [varchar](50) NOT NULL,
	[Empresa_Rsocial] [varchar](50) NULL,
 CONSTRAINT [PK_estancia1] PRIMARY KEY CLUSTERED 
(
	[Estancia_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[frigorificos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[frigorificos](
	[Frigorifico_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_frigorificos] PRIMARY KEY CLUSTERED 
(
	[Frigorifico_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historial_animales_concursos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historial_animales_concursos](
	[Historial_animales_concursos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_concursos] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_concursos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historial_animales_enfermedades]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historial_animales_enfermedades](
	[Historial_animales_enfermedades_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_enfermedades] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_enfermedades_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historial_animales_ingestas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historial_animales_ingestas](
	[Historial_animales_ingestas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_ingestas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_ingestas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historial_animales_pesadas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historial_animales_pesadas](
	[Historial_animales_pesadas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Peso] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_pesadas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_pesadas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historial_animales_vacunas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historial_animales_vacunas](
	[Historial_animales_vacunas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_vacunas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_vacunas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[independientes]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[independientes](
	[Independiente_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
	[Usuario_ID] [int] NOT NULL,
 CONSTRAINT [PK_independientes] PRIMARY KEY CLUSTERED 
(
	[Independiente_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingeniero_agronomos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingeniero_agronomos](
	[Ingeniero_agronomo_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ingeniero_agronomos] PRIMARY KEY CLUSTERED 
(
	[Ingeniero_agronomo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lista_animales_cate;rias]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lista_animales_cate;rias](
	[Lista_animales_cate;rias_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_lista_animales_cate;rias] PRIMARY KEY CLUSTERED 
(
	[Lista_animales_cate;rias_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lista_animales_razas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lista_animales_razas](
	[Lista_animales_razas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_lista_animales_razas] PRIMARY KEY CLUSTERED 
(
	[Lista_animales_razas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logs]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logs](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario_ID] [int] NOT NULL,
	[Fecha_creado] [datetime] NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[IP_client] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Dato_afectado] [varchar](150) NOT NULL,
 CONSTRAINT [PK_logs] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lotes]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lotes](
	[Lote_ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_lotes] PRIMARY KEY CLUSTERED 
(
	[Lote_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ovejas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ovejas](
	[Oveja_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
	[Lista_animales_razas_ID] [int] NULL,
	[Lista_animales_cate;rias_ID] [int] NULL,
 CONSTRAINT [PK_ovejas] PRIMARY KEY CLUSTERED 
(
	[Oveja_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ovejas_historial_concursos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ovejas_historial_concursos](
	[Historial_animales_concursos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_concursos] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_concursos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ovejas_historial_enfermedades]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ovejas_historial_enfermedades](
	[Historial_animales_enfermedades_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_enfermedades] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_enfermedades_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ovejas_historial_ingestas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ovejas_historial_ingestas](
	[Historial_animales_ingestas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_ingestas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_ingestas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ovejas_historial_pesadas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ovejas_historial_pesadas](
	[Historial_animales_pesadas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Peso] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_pesadas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_pesadas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ovejas_historial_vacunas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ovejas_historial_vacunas](
	[Historial_animales_vacunas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_vacunas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_vacunas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personas](
	[Persona_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellido] [varchar](30) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Cedula] [varchar](30) NULL,
	[FechaNacimiento] [datetime2](7) NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Persona_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_cedula] UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[Proveedor_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED 
(
	[Proveedor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[raciones]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[raciones](
	[Racion_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Aportes_energia_ID] [int] NULL,
	[Aportes_mineral_ID] [int] NULL,
	[Aportes_proteina_ID] [int] NULL,
 CONSTRAINT [PK_raciones] PRIMARY KEY CLUSTERED 
(
	[Racion_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[raciones_prestaciones]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[raciones_prestaciones](
	[Racion_prestacion_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Raciones_ID] [int] NULL,
 CONSTRAINT [PK_raciones_prestaciones] PRIMARY KEY CLUSTERED 
(
	[Racion_prestacion_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[raciones_proveedores]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[raciones_proveedores](
	[Raciones_proveedor_ID] [int] IDENTITY(2,1) NOT NULL,
	[Raciones_ID] [int] NOT NULL,
 CONSTRAINT [PK_raciones_proveedores] PRIMARY KEY CLUSTERED 
(
	[Raciones_proveedor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[Rol_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_Rol_ID] PRIMARY KEY CLUSTERED 
(
	[Rol_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[Usuario_ID] [int] IDENTITY(2,1) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Rol_usuario_ID] [int] NOT NULL,
	[Persona_Id] [int] NOT NULL,
	[Image] [varchar](100) NULL,
 CONSTRAINT [PK_usuarios_Usuario_ID] PRIMARY KEY CLUSTERED 
(
	[Usuario_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacas](
	[Vaca_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
	[Estancia_campos_ID] [int] NOT NULL,
	[Lista_animales_razas_ID] [int] NULL,
	[Lista_animales_cate;rias_ID] [int] NULL,
	[MGAP_ID] [varchar](100) NULL,
	[Chirpstack_Device_ID] [int] NULL,
 CONSTRAINT [PK_vacas_1] PRIMARY KEY CLUSTERED 
(
	[Vaca_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacas_historial_concursos]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacas_historial_concursos](
	[Historial_animales_concursos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_concursos] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_concursos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacas_historial_enfermedades]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacas_historial_enfermedades](
	[Historial_animales_enfermedades_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_enfermedades] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_enfermedades_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacas_historial_ingestas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacas_historial_ingestas](
	[Historial_animales_ingestas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_ingestas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_ingestas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacas_historial_pesadas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacas_historial_pesadas](
	[Historial_Animales_Pesadas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Peso] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_pesadas] PRIMARY KEY CLUSTERED 
(
	[Historial_Animales_Pesadas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vacas_historial_vacunas]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vacas_historial_vacunas](
	[Historial_animales_vacunas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_vacunas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_vacunas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[veterinarias]    Script Date: 04/04/2021 03:53:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[veterinarias](
	[Veterinaria_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_veterinarias] PRIMARY KEY CLUSTERED 
(
	[Veterinaria_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[caravanas]  WITH CHECK ADD  CONSTRAINT [FK_VacaID_Caravanas_to_Vacas] FOREIGN KEY([VacaID])
REFERENCES [dbo].[vacas] ([Vaca_ID])
GO
ALTER TABLE [dbo].[caravanas] CHECK CONSTRAINT [FK_VacaID_Caravanas_to_Vacas]
GO
ALTER TABLE [dbo].[estancia_campos_padrones]  WITH CHECK ADD  CONSTRAINT [FK_estancia_campos_id] FOREIGN KEY([Estancia_Campos_ID])
REFERENCES [dbo].[estancia_campos] ([Estancia_campos_ID])
GO
ALTER TABLE [dbo].[estancia_campos_padrones] CHECK CONSTRAINT [FK_estancia_campos_id]
GO
ALTER TABLE [dbo].[estancia_duenos]  WITH CHECK ADD  CONSTRAINT [FK_ED_Persona_ID_TO_Persona] FOREIGN KEY([Persona_ID])
REFERENCES [dbo].[personas] ([Persona_ID])
GO
ALTER TABLE [dbo].[estancia_duenos] CHECK CONSTRAINT [FK_ED_Persona_ID_TO_Persona]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Persona_ID_TO_Persona] FOREIGN KEY([Persona_Id])
REFERENCES [dbo].[personas] ([Persona_ID])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_Persona_ID_TO_Persona]
GO
ALTER TABLE [dbo].[vacas]  WITH CHECK ADD  CONSTRAINT [FK_estanciaCampoID_Vacas_To_Estancia_campo] FOREIGN KEY([Estancia_campos_ID])
REFERENCES [dbo].[estancia_campos] ([Estancia_campos_ID])
GO
ALTER TABLE [dbo].[vacas] CHECK CONSTRAINT [FK_estanciaCampoID_Vacas_To_Estancia_campo]
GO
USE [master]
GO
ALTER DATABASE [chevacadb] SET  READ_WRITE 
GO
