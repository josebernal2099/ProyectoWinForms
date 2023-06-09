USE [master]
GO
/****** Object:  Database [Examen]    Script Date: 26/04/2023 12:05:09 a. m. ******/
CREATE DATABASE [Examen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Examen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Examen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Examen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Examen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Examen] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Examen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Examen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Examen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Examen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Examen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Examen] SET ARITHABORT OFF 
GO
ALTER DATABASE [Examen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Examen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Examen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Examen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Examen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Examen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Examen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Examen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Examen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Examen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Examen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Examen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Examen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Examen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Examen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Examen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Examen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Examen] SET RECOVERY FULL 
GO
ALTER DATABASE [Examen] SET  MULTI_USER 
GO
ALTER DATABASE [Examen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Examen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Examen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Examen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Examen] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Examen', N'ON'
GO
ALTER DATABASE [Examen] SET QUERY_STORE = OFF
GO
USE [Examen]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Examen]
GO
/****** Object:  Table [dbo].[articles]    Script Date: 26/04/2023 12:05:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[description] [nvarchar](150) NULL,
	[price] [float] NOT NULL,
	[total_in_shelf] [int] NOT NULL,
	[total_in_vault] [int] NOT NULL,
	[store_id] [int] NOT NULL,
 CONSTRAINT [PK_articles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stores]    Script Date: 26/04/2023 12:05:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[address] [nvarchar](150) NULL,
 CONSTRAINT [PK_stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[articles]  WITH CHECK ADD  CONSTRAINT [FK_articles_stores] FOREIGN KEY([store_id])
REFERENCES [dbo].[stores] ([id])
GO
ALTER TABLE [dbo].[articles] CHECK CONSTRAINT [FK_articles_stores]
GO
/****** Object:  StoredProcedure [dbo].[spCnObtenerArticulos]    Script Date: 26/04/2023 12:05:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCnObtenerArticulos]          
      
AS                            
BEGIN                  
                   
 select a.id, 
 a.name,
 a.description, 
 a.price, 
 a.total_in_shelf, 
 a.total_in_vault,
 s.name as store_name
 from articles a
	inner join stores s
	on a.store_id = s.id
                   
END
GO
/****** Object:  StoredProcedure [dbo].[spCnObtenerArticulosPorTienda]    Script Date: 26/04/2023 12:05:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCnObtenerArticulosPorTienda](
	@pIdStore int
	)        
AS                            
BEGIN                  
                   
 select a.id, 
 a.name,
 a.description, 
 a.price, 
 a.total_in_shelf, 
 a.total_in_vault,
 s.name as store_name
 from articles a
	inner join stores s
	on a.store_id = s.id
 where a.store_id = @pIdStore
                   
END
GO
/****** Object:  StoredProcedure [dbo].[spCnObtenerTiendas]    Script Date: 26/04/2023 12:05:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCnObtenerTiendas]          
      
AS                            
BEGIN                  
                   
 select id, 
 name, 
 address 
 from stores
                   
END
GO
USE [master]
GO
ALTER DATABASE [Examen] SET  READ_WRITE 
GO
