USE [master]
GO
/****** Object:  Database [OnTheFly]    Script Date: 05/10/2022 11:00:20 ******/
CREATE DATABASE [OnTheFly]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnTheFly', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OnTheFly.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnTheFly_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OnTheFly_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OnTheFly] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnTheFly].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnTheFly] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnTheFly] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnTheFly] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnTheFly] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnTheFly] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnTheFly] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnTheFly] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnTheFly] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnTheFly] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnTheFly] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnTheFly] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnTheFly] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnTheFly] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnTheFly] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnTheFly] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OnTheFly] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnTheFly] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnTheFly] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnTheFly] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnTheFly] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnTheFly] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnTheFly] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnTheFly] SET RECOVERY FULL 
GO
ALTER DATABASE [OnTheFly] SET  MULTI_USER 
GO
ALTER DATABASE [OnTheFly] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnTheFly] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnTheFly] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnTheFly] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnTheFly] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnTheFly] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OnTheFly', N'ON'
GO
ALTER DATABASE [OnTheFly] SET QUERY_STORE = OFF
GO
USE [OnTheFly]
GO
/****** Object:  Table [dbo].[Aeronave]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aeronave](
	[Inscricao] [char](6) NOT NULL,
	[Capacidade] [int] NOT NULL,
	[UltimaVenda] [date] NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[Situacao] [char](1) NOT NULL,
	[CNPJCompanhia] [char](14) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Inscricao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bloqueados]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bloqueados](
	[CNPJ] [char](14) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanhiaAerea]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanhiaAerea](
	[CNPJ] [char](14) NOT NULL,
	[RazaoSocial] [varchar](50) NOT NULL,
	[DataAbertura] [date] NOT NULL,
	[UltimoVoo] [date] NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[Situacao] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destino]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destino](
	[IATA] [char](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IATA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemVenda]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemVenda](
	[IdVenda] [int] NOT NULL,
	[IdPassagem] [int] NOT NULL,
	[IdVoo] [int] NOT NULL,
 CONSTRAINT [PK_IdVenda_IdPassagem_IdVoo] PRIMARY KEY CLUSTERED 
(
	[IdVenda] ASC,
	[IdVoo] ASC,
	[IdPassagem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passageiro]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passageiro](
	[CPF] [char](11) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[UltimaCompra] [date] NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[Situacao] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassagemVoo]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassagemVoo](
	[IdPassagem] [int] NOT NULL,
	[IdVoo] [int] NOT NULL,
	[DataUltimaOperacao] [date] NOT NULL,
	[Valor] [decimal](6, 2) NOT NULL,
	[Situacao] [char](1) NOT NULL,
 CONSTRAINT [PK_PassagemVoo] PRIMARY KEY CLUSTERED 
(
	[IdPassagem] ASC,
	[IdVoo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restritos]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restritos](
	[CPF] [char](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venda]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venda](
	[IdVenda] [int] IDENTITY(1,1) NOT NULL,
	[DataVenda] [date] NOT NULL,
	[Passageiro] [char](11) NOT NULL,
	[ValorTotal] [decimal](7, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voo]    Script Date: 05/10/2022 11:00:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voo](
	[IdVoo] [int] IDENTITY(1,1) NOT NULL,
	[Destino] [char](3) NOT NULL,
	[Aeronave] [char](6) NOT NULL,
	[AssentosOcupados] [int] NOT NULL,
	[DataVoo] [datetime] NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[Situacao] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVoo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Aeronave] ([Inscricao], [Capacidade], [UltimaVenda], [DataCadastro], [Situacao], [CNPJCompanhia]) VALUES (N'F0WSKE', 10, CAST(N'2022-10-05' AS Date), CAST(N'2022-10-03' AS Date), N'A', N'86261407000198')
GO
INSERT [dbo].[CompanhiaAerea] ([CNPJ], [RazaoSocial], [DataAbertura], [UltimoVoo], [DataCadastro], [Situacao]) VALUES (N'40410860000118', N'FLOY FLEMING LTDA', CAST(N'2014-06-09' AS Date), CAST(N'2022-09-30' AS Date), CAST(N'2022-09-30' AS Date), N'A')
INSERT [dbo].[CompanhiaAerea] ([CNPJ], [RazaoSocial], [DataAbertura], [UltimoVoo], [DataCadastro], [Situacao]) VALUES (N'86261407000198', N'LAVERN REID SA', CAST(N'1983-10-24' AS Date), CAST(N'2022-09-30' AS Date), CAST(N'2022-09-30' AS Date), N'A')
GO
INSERT [dbo].[Destino] ([IATA]) VALUES (N'GRU')
GO
INSERT [dbo].[ItemVenda] ([IdVenda], [IdPassagem], [IdVoo]) VALUES (11, 1, 11)
INSERT [dbo].[ItemVenda] ([IdVenda], [IdPassagem], [IdVoo]) VALUES (11, 2, 11)
INSERT [dbo].[ItemVenda] ([IdVenda], [IdPassagem], [IdVoo]) VALUES (12, 3, 11)
INSERT [dbo].[ItemVenda] ([IdVenda], [IdPassagem], [IdVoo]) VALUES (12, 4, 11)
INSERT [dbo].[ItemVenda] ([IdVenda], [IdPassagem], [IdVoo]) VALUES (12, 5, 11)
GO
INSERT [dbo].[Passageiro] ([CPF], [Nome], [DataNascimento], [Sexo], [UltimaCompra], [DataCadastro], [Situacao]) VALUES (N'15397388840', N'MARIA RAQUEL DOS SANTOS', CAST(N'1964-05-23' AS Date), N'F', CAST(N'2022-10-05' AS Date), CAST(N'2022-09-30' AS Date), N'A')
INSERT [dbo].[Passageiro] ([CPF], [Nome], [DataNascimento], [Sexo], [UltimaCompra], [DataCadastro], [Situacao]) VALUES (N'25759223216', N'GILMAR FERREIRA MENDES', CAST(N'1955-12-30' AS Date), N'M', CAST(N'2022-09-30' AS Date), CAST(N'2022-09-30' AS Date), N'A')
INSERT [dbo].[Passageiro] ([CPF], [Nome], [DataNascimento], [Sexo], [UltimaCompra], [DataCadastro], [Situacao]) VALUES (N'39066324821', N'DANIEL VICTOR SANTOS SILVA', CAST(N'2002-08-22' AS Date), N'M', CAST(N'2022-10-04' AS Date), CAST(N'2022-09-30' AS Date), N'A')
GO
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (1, 11, CAST(N'2022-10-04' AS Date), CAST(100.00 AS Decimal(6, 2)), N'P')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (2, 11, CAST(N'2022-10-04' AS Date), CAST(100.00 AS Decimal(6, 2)), N'P')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (3, 11, CAST(N'2022-10-05' AS Date), CAST(100.00 AS Decimal(6, 2)), N'P')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (4, 11, CAST(N'2022-10-05' AS Date), CAST(100.00 AS Decimal(6, 2)), N'P')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (5, 11, CAST(N'2022-10-05' AS Date), CAST(100.00 AS Decimal(6, 2)), N'P')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (6, 11, CAST(N'2022-10-03' AS Date), CAST(100.00 AS Decimal(6, 2)), N'L')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (7, 11, CAST(N'2022-10-03' AS Date), CAST(100.00 AS Decimal(6, 2)), N'L')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (8, 11, CAST(N'2022-10-03' AS Date), CAST(100.00 AS Decimal(6, 2)), N'L')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (9, 11, CAST(N'2022-10-03' AS Date), CAST(100.00 AS Decimal(6, 2)), N'L')
INSERT [dbo].[PassagemVoo] ([IdPassagem], [IdVoo], [DataUltimaOperacao], [Valor], [Situacao]) VALUES (10, 11, CAST(N'2022-10-03' AS Date), CAST(100.00 AS Decimal(6, 2)), N'L')
GO
SET IDENTITY_INSERT [dbo].[Venda] ON 

INSERT [dbo].[Venda] ([IdVenda], [DataVenda], [Passageiro], [ValorTotal]) VALUES (11, CAST(N'2022-10-04' AS Date), N'39066324821', CAST(200.00 AS Decimal(7, 2)))
INSERT [dbo].[Venda] ([IdVenda], [DataVenda], [Passageiro], [ValorTotal]) VALUES (12, CAST(N'2022-10-05' AS Date), N'15397388840', CAST(300.00 AS Decimal(7, 2)))
SET IDENTITY_INSERT [dbo].[Venda] OFF
GO
SET IDENTITY_INSERT [dbo].[Voo] ON 

INSERT [dbo].[Voo] ([IdVoo], [Destino], [Aeronave], [AssentosOcupados], [DataVoo], [DataCadastro], [Situacao]) VALUES (11, N'GRU', N'F0WSKE', 5, CAST(N'2022-10-04T09:00:00.000' AS DateTime), CAST(N'2022-10-03' AS Date), N'A')
SET IDENTITY_INSERT [dbo].[Voo] OFF
GO
ALTER TABLE [dbo].[Aeronave]  WITH CHECK ADD FOREIGN KEY([CNPJCompanhia])
REFERENCES [dbo].[CompanhiaAerea] ([CNPJ])
GO
ALTER TABLE [dbo].[ItemVenda]  WITH CHECK ADD  CONSTRAINT [FK_IdVoo] FOREIGN KEY([IdVoo])
REFERENCES [dbo].[Voo] ([IdVoo])
GO
ALTER TABLE [dbo].[ItemVenda] CHECK CONSTRAINT [FK_IdVoo]
GO
ALTER TABLE [dbo].[PassagemVoo]  WITH CHECK ADD FOREIGN KEY([IdVoo])
REFERENCES [dbo].[Voo] ([IdVoo])
GO
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD FOREIGN KEY([Passageiro])
REFERENCES [dbo].[Passageiro] ([CPF])
GO
ALTER TABLE [dbo].[Voo]  WITH CHECK ADD FOREIGN KEY([Aeronave])
REFERENCES [dbo].[Aeronave] ([Inscricao])
GO
ALTER TABLE [dbo].[Voo]  WITH CHECK ADD FOREIGN KEY([Destino])
REFERENCES [dbo].[Destino] ([IATA])
GO
USE [master]
GO
ALTER DATABASE [OnTheFly] SET  READ_WRITE 
GO
