USE [master]
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'music')
BEGIN
CREATE DATABASE [music] ON  PRIMARY 
( NAME = N'music', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\music.mdf' , SIZE = 2240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'music_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\music_log.LDF' , SIZE = 560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
EXEC dbo.sp_dbcmptlevel @dbname=N'music', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [music].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [music] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [music] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [music] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [music] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [music] SET ARITHABORT OFF 
GO
ALTER DATABASE [music] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [music] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [music] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [music] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [music] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [music] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [music] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [music] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [music] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [music] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [music] SET  ENABLE_BROKER 
GO
ALTER DATABASE [music] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [music] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [music] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [music] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [music] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [music] SET  READ_WRITE 
GO
ALTER DATABASE [music] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [music] SET  MULTI_USER 
GO
ALTER DATABASE [music] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [music] SET DB_CHAINING OFF 
USE [music]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genres]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Genres](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Artists]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Artists](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[GenreID] [int] NOT NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Artist_Genre]') AND parent_object_id = OBJECT_ID(N'[dbo].[Artists]'))
ALTER TABLE [dbo].[Artists]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Genre] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([ID])
GO
ALTER TABLE [dbo].[Artists] CHECK CONSTRAINT [FK_Artist_Genre]
GO

/* insert data */
INSERT INTO [music].[dbo].[Genres]([Name])
     VALUES('Pop')
INSERT INTO [music].[dbo].[Genres]([Name])
     VALUES('Indie')
INSERT INTO [music].[dbo].[Genres]([Name])
     VALUES('Classical')
GO

INSERT INTO [music].[dbo].[Artists]([Name],[GenreID])
     VALUES('Radiohead', 1)
INSERT INTO [music].[dbo].[Artists]([Name],[GenreID])
     VALUES('Take That', 0)
INSERT INTO [music].[dbo].[Artists]([Name],[GenreID])
     VALUES('Blur', 1)
INSERT INTO [music].[dbo].[Artists]([Name],[GenreID])
     VALUES('Beethoven', 2)
INSERT INTO [music].[dbo].[Artists]([Name],[GenreID])
     VALUES('Girls Aloud', 0)
INSERT INTO [music].[dbo].[Artists]([Name],[GenreID])
     VALUES('The Divine Comedy', 1)
GO