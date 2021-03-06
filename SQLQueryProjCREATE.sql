/*    ==Parâmetros de Script==

    Versão do Servidor de Origem : SQL Server 2016 (13.0.4001)
    Edição do Mecanismo de Banco de Dados de Origem : Microsoft SQL Server Enterprise Edition
    Tipo do Mecanismo de Banco de Dados de Origem : SQL Server Autônomo

    Versão do Servidor de Destino : SQL Server 2016
    Edição de Mecanismo de Banco de Dados de Destino : Microsoft SQL Server Enterprise Edition
    Tipo de Mecanismo de Banco de Dados de Destino : SQL Server Autônomo
*/

USE [master]
GO

/****** Object:  Database [BDProj]    Script Date: 01/12/2017 01:54:57 ******/
CREATE DATABASE [BDProj]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDProj', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BDProj.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDProj_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BDProj_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [BDProj] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDProj].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BDProj] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BDProj] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BDProj] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BDProj] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BDProj] SET ARITHABORT OFF 
GO

ALTER DATABASE [BDProj] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BDProj] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BDProj] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BDProj] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BDProj] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BDProj] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BDProj] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BDProj] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BDProj] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BDProj] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BDProj] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BDProj] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BDProj] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BDProj] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BDProj] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BDProj] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BDProj] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BDProj] SET RECOVERY FULL 
GO

ALTER DATABASE [BDProj] SET  MULTI_USER 
GO

ALTER DATABASE [BDProj] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BDProj] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BDProj] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BDProj] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BDProj] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BDProj] SET QUERY_STORE = OFF
GO

USE [BDProj]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [BDProj] SET  READ_WRITE 
GO

