use chevacadb;
drop database chevacadb;

USE [master]
;
/****** Object:  Database [chevacadb]    Script Date: 11-Jan-21 11:48:04 ******/
CREATE DATABASE [chevacadb]
;
use [chevacadb]
;
/****** Object:  Table [dbo].[aportes_energias]    Script Date: 11-Jan-21 11:48:04 ******/


CREATE TABLE [dbo].[aportes_energias](
	[Aporte_energia_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_aportes_energias] PRIMARY KEY CLUSTERED 
(
	[Aporte_energia_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[aportes_proteinas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[aportes_proteinas](
	[Aporte_proteina_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_aportes_proteinas] PRIMARY KEY CLUSTERED 
(
	[Aporte_proteina_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
;
/****** Object:  Table [dbo].[bebederos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[bebederos](
	[Bebedero_ID] [int] IDENTITY(2,1) NOT NULL,
 CONSTRAINT [PK_bebederos] PRIMARY KEY CLUSTERED 
(
	[Bebedero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[camioneros]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[camioneros](
	[Camionero_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_camioneros] PRIMARY KEY CLUSTERED 
(
	[Camionero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[comederos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[comederos](
	[Comedero_ID] [int] IDENTITY(2,1) NOT NULL,
 CONSTRAINT [PK_comederos] PRIMARY KEY CLUSTERED 
(
	[Comedero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[dormideros]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[dormideros](
	[Dormidero_ID] [int] IDENTITY(2,1) NOT NULL,
 CONSTRAINT [PK_dormideros] PRIMARY KEY CLUSTERED 
(
	[Dormidero_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[escritorio_rurales]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[escritorio_rurales](
	[Escritorio_rural_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_escritorio_rurales] PRIMARY KEY CLUSTERED 
(
	[Escritorio_rural_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

CREATE TABLE [dbo].[estancias](
	[Estancia_ID] int identity NOT NULL,
	Organization_ID int not null ,
	Empresa_RUT varchar(12) not null ,
	[Empresa_Nombre] [varchar](100) NOT NULL,
	[Empresa_Rsocial] varchar(100) not null ,
 CONSTRAINT [PK_estancias] PRIMARY KEY CLUSTERED
(
	[Estancia_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

/****** Object:  Table [dbo].[estancia_campos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[estancia_campos](
	[Estancia_campos_ID] int identity (2,1) NOT NULL,
	[Nombre] varchar(100) ,
	[Estancia_ID] int NOT NULL,
	[Descripcion] varchar NULL,
	[ChirpstackApplication_ID] int not null ,

 CONSTRAINT [PK_estancia_campos] PRIMARY KEY CLUSTERED 
(
	[Estancia_campos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

/****** Object:  Table [dbo].[estancia_duenos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[estancia_duenos](
	[Estancia_dueno_ID] [int] IDENTITY(2,1) NOT NULL,
	Persona_ID int not null,
	[Estancia_ID] int NOT NULL,
 CONSTRAINT [PK_estancia_duenos] PRIMARY KEY CLUSTERED
(
	[Estancia_Dueno_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

/****** Object:  Table [dbo].[estancia_campos_padrones]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[estancia_campos_padrones](
	[Estancia_campos_padrones_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_Campos_ID] int NOT NULL,
 CONSTRAINT [PK_estancia_campos_padrones] PRIMARY KEY CLUSTERED 
(
	[Estancia_campos_padrones_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[estancia_campos_potreros]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[estancia_campos_potreros](
	[Estancia_campos_potreros_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
 CONSTRAINT [PK_estancia_campos_potreros] PRIMARY KEY CLUSTERED 
(
	[Estancia_campos_potreros_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

/****** Object:  Table [dbo].[frigorificos]    Script Date: 11-Jan-21 11:48:04 ******/


CREATE TABLE [dbo].[frigorificos](
	[Frigorifico_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_frigorificos] PRIMARY KEY CLUSTERED 
(
	[Frigorifico_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[historial_animales_concursos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[historial_animales_concursos](
	[Historial_animales_concursos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_concursos] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_concursos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[historial_animales_enfermedades]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[historial_animales_enfermedades](
	[Historial_animales_enfermedades_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_enfermedades] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_enfermedades_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[historial_animales_ingestas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[historial_animales_ingestas](
	[Historial_animales_ingestas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_ingestas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_ingestas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[historial_animales_pesadas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[historial_animales_pesadas](
	[Historial_animales_pesadas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Peso] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_pesadas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_pesadas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[historial_animales_vacunas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[historial_animales_vacunas](
	[Historial_animales_vacunas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_historial_animales_vacunas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_vacunas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[ingeniero_agronomos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[ingeniero_agronomos](
	[Ingeniero_agronomo_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ingeniero_agronomos] PRIMARY KEY CLUSTERED 
(
	[Ingeniero_agronomo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[lista_animales_cate;rias]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[lista_animales_cate;rias](
	[Lista_animales_cate;rias_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_lista_animales_cate;rias] PRIMARY KEY CLUSTERED 
(
	[Lista_animales_cate;rias_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[lista_animales_razas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[lista_animales_razas](
	[Lista_animales_razas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_lista_animales_razas] PRIMARY KEY CLUSTERED 
(
	[Lista_animales_razas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[logs]    Script Date: 11-Jan-21 11:48:04 ******/

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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[lotes]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[lotes](
	[Lote_ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_lotes] PRIMARY KEY CLUSTERED 
(
	[Lote_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[ovejas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[ovejas](
	[Oveja_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
	[Lista_animales_razas_ID] [int] NULL,
	[Lista_animales_cate;rias_ID] [int] NULL,
 CONSTRAINT [PK_ovejas] PRIMARY KEY CLUSTERED 
(
	[Oveja_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[ovejas_historial_concursos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[ovejas_historial_concursos](
	[Historial_animales_concursos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_concursos] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_concursos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[ovejas_historial_enfermedades]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[ovejas_historial_enfermedades](
	[Historial_animales_enfermedades_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_enfermedades] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_enfermedades_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[ovejas_historial_ingestas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[ovejas_historial_ingestas](
	[Historial_animales_ingestas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_ingestas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_ingestas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[ovejas_historial_pesadas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[ovejas_historial_pesadas](
	[Historial_animales_pesadas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Peso] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_pesadas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_pesadas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[ovejas_historial_vacunas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[ovejas_historial_vacunas](
	[Historial_animales_vacunas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_ovejas_historial_vacunas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_vacunas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[proveedores]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[proveedores](
	[Proveedor_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED 
(
	[Proveedor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[raciones]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[raciones](
	[Racion_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Aportes_energia_ID] [int] NULL,
	[Aportes_mineral_ID] [int] NULL,
	[Aportes_proteina_ID] [int] NULL,
 CONSTRAINT [PK_raciones] PRIMARY KEY CLUSTERED 
(
	[Racion_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[raciones_prestaciones]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[raciones_prestaciones](
	[Racion_prestacion_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Raciones_ID] [int] NULL,
 CONSTRAINT [PK_raciones_prestaciones] PRIMARY KEY CLUSTERED 
(
	[Racion_prestacion_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[raciones_proveedores]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[raciones_proveedores](
	[Raciones_proveedor_ID] [int] IDENTITY(2,1) NOT NULL,
	[Raciones_ID] [int] NOT NULL,
 CONSTRAINT [PK_raciones_proveedores] PRIMARY KEY CLUSTERED 
(
	[Raciones_proveedor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[trabajadores]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[trabajadores](
	[Trabajador_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
 CONSTRAINT [PK_trabajadores] PRIMARY KEY CLUSTERED 
(
	[Trabajador_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[trabajadores_perros]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[trabajadores_perros](
	[Trabajador_perro_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_trabajadores_perros] PRIMARY KEY CLUSTERED 
(
	[Trabajador_perro_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[usuarios]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[usuarios](
	[Usuario_ID] [int] IDENTITY(2,1) NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Rol_usuario_ID] [int] NOT NULL,
	Persona_Id [int] not null ,
	Image varchar(100) null ,
 CONSTRAINT [PK_usuarios_Usuario_ID] PRIMARY KEY CLUSTERED 
(
	[Usuario_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;

create table roles(
    Rol_ID int IDENTITY not null,
    Nombre varchar (100),
    Descripcion varchar(max),
     CONSTRAINT [PK_Rol_ID] PRIMARY KEY CLUSTERED
(
	[Rol_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;


/****** Object:  Table [dbo].[Admins]    Script Date: 11-Jan-21 11:48:04 ******/
CREATE table personas(
    [Persona_ID] [int] IDENTITY(2,1) not NULL,
	[Nombre] [varchar](30) not null ,
    [Apellido] [varchar](30) not null ,
	[Email] [VARCHAR](100) not NULL,
	Cedula varchar(30) null ,
	FechaNacimiento datetime2 null ,

	CONSTRAINT PK_Personas PRIMARY KEY (Persona_ID)
);


/****** Object:  Table [dbo].[vacas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[vacas](
	[Vaca_ID] [int] IDENTITY(2,1) NOT NULL,
	[Estancia_ID] [int] NOT NULL,
	[Estancia_campos_ID] [int] not null ,
	[Lista_animales_razas_ID] [int] NULL,
	[Lista_animales_cate;rias_ID] [int] NULL,
	[MGAP_ID] [varchar](100) NULL,
	[Chirpstack_Device_ID] [int] NULL,
 	CONSTRAINT [PK_vacas_1] PRIMARY KEY CLUSTERED ([Vaca_ID] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[vacas_historial_concursos]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[vacas_historial_concursos](
	[Historial_animales_concursos_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_concursos] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_concursos_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[vacas_historial_enfermedades]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[vacas_historial_enfermedades](
	[Historial_animales_enfermedades_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_enfermedades] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_enfermedades_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[vacas_historial_ingestas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[vacas_historial_ingestas](
	[Historial_animales_ingestas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_ingestas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_ingestas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[vacas_historial_pesadas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[vacas_historial_pesadas](
	[Historial_Animales_Pesadas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Peso] [decimal](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_pesadas] PRIMARY KEY CLUSTERED 
(
	[Historial_animales_pesadas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[vacas_historial_vacunas]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[vacas_historial_vacunas](
	[Historial_animales_vacunas_ID] [int] IDENTITY(2,1) NOT NULL,
	[Animal_ID] [int] NOT NULL,
 CONSTRAINT [PK_vacas_historial_vacunas] PRIMARY KEY CLUSTERED
(
	[Historial_animales_vacunas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

;
/****** Object:  Table [dbo].[veterinarias]    Script Date: 11-Jan-21 11:48:04 ******/

CREATE TABLE [dbo].[veterinarias](
	[Veterinaria_ID] [int] IDENTITY(2,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_veterinarias] PRIMARY KEY CLUSTERED 
(
	[Veterinaria_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
;
/****** Object:  Table [dbo].[caravanas]    Script Date: 11-Jan-21 11:48:04 ******/


/****** Object:  Table [dbo].[caravanas]    Script Date: 11-Jan-21 11:48:04 ******/
CREATE table dbo.caravanas(
    [Caravana_ID] [int] IDENTITY(2,1) NOT NULL,
	[Numero_Ministerio] [varchar](100) not null,
	[Dev_Eui] [varchar](100) not null,
	[Description] [varchar](100) null ,
	VacaID int not null ,
	constraint PK_caravana_id primary key (Numero_Ministerio)
)
;

/****** Object:  Table [dbo].[chirpstack_devices]    Script Date: 11-Jan-21 11:48:04 ******/
CREATE table dbo.chirpstack_devices(
	[Dev_Eui] [varchar](100) not null,
	[Ch_Dev_App_Key] [varchar](100) not null ,
	[Ch_St_Prfile_Id] [varchar](100) not null,
	[Ch_App_ID] [varchar](100) not null,

	constraint PK_chirpstack primary key (Dev_Eui)
)
;




/****** CONSTRAINTS ******/
alter table usuarios add constraint [FK_Persona_ID_TO_Persona] foreign key ("Persona_Id") references dbo.personas(Persona_ID);
alter table estancia_duenos add constraint  [FK_ED_Persona_ID_TO_Persona] foreign key ("Persona_ID") references dbo.personas(Persona_ID);

alter table caravanas add CONSTRAINT [FK_VacaID_Caravanas_to_Vacas] foreign key ("VacaID") references dbo.vacas(Vaca_ID);

alter table estancias add constraint  Uk_empresa_rut unique ("Empresa_RUT");
alter table estancias add constraint  UK_organization_ID unique ("Organization_ID");


alter table estancia_campos add constraint [FK_ID_Estancia_campos_To_Estancias] foreign key (Estancia_ID) references estancias(Estancia_ID);
alter table estancia_campos_padrones add constraint  FK_estancia_campos_id foreign key (Estancia_Campos_ID) references  estancia_campos(Estancia_Campos_ID);

--La cedula de cada dueno es unica
alter table personas add constraint UK_cedula unique ("Cedula");
alter table estancia_duenos add constraint FK_Estancia_duenos_ID_To_Estancias foreign key (Estancia_ID) references estancias (Estancia_ID);

--A una vaca le agrego FK para indicarle que estancia y en que campo se encuentra
alter table vacas add constraint FK_EstanciaID_Vacas_To_Estancias foreign key (Estancia_ID) references estancias(Estancia_ID);
alter table vacas add constraint FK_estanciaCampoID_Vacas_To_Estancia_campo foreign key (Estancia_campos_ID) references estancia_campos(Estancia_campos_ID);

USE [master]
;
ALTER DATABASE [chevacadb] SET  READ_WRITE
;

use chevacadb

insert into roles values ('Founder','Fundadores de Chevaca');

insert into personas values ('Pablo', 'Llorach', 'llorach.pablo@gmail.com', '42883341', null );


insert into usuarios values ('llorach.pablo@gmail.com', '13aBr2009', 1,2,null );

select * from usuarios;

select * from roles;


select * from personas;