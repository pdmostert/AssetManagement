﻿USE [master]
GO

/****** Object:  Database [AssetManagementDB]    Script Date: 2024/05/16 05:16:49 ******/
CREATE DATABASE [AssetManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssetManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AssetManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AssetManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AssetManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssetManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AssetManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AssetManagementDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AssetManagementDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AssetManagementDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AssetManagementDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [AssetManagementDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AssetManagementDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AssetManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AssetManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AssetManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AssetManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AssetManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AssetManagementDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AssetManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AssetManagementDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AssetManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AssetManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AssetManagementDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AssetManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AssetManagementDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AssetManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AssetManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AssetManagementDB] SET RECOVERY FULL 
GO

ALTER DATABASE [AssetManagementDB] SET  MULTI_USER 
GO

ALTER DATABASE [AssetManagementDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AssetManagementDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AssetManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [AssetManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [AssetManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [AssetManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [AssetManagementDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [AssetManagementDB] SET  READ_WRITE 
GO

