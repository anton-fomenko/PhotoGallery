USE [master]
GO
/****** Object:  Database [PhotoGallery]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE DATABASE [PhotoGallery]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotoGallery', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PhotoGallery.mdf' , SIZE = 9408KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PhotoGallery_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PhotoGallery_log.ldf' , SIZE = 3200KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PhotoGallery] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotoGallery].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhotoGallery] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhotoGallery] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhotoGallery] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhotoGallery] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhotoGallery] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhotoGallery] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhotoGallery] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhotoGallery] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhotoGallery] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhotoGallery] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhotoGallery] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhotoGallery] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhotoGallery] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhotoGallery] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhotoGallery] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhotoGallery] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhotoGallery] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhotoGallery] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PhotoGallery] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhotoGallery] SET RECOVERY FULL 
GO
ALTER DATABASE [PhotoGallery] SET  MULTI_USER 
GO
ALTER DATABASE [PhotoGallery] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhotoGallery] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhotoGallery] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhotoGallery] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PhotoGallery] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhotoGallery', N'ON'
GO
USE [PhotoGallery]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[Photo_PhotoId] [int] NULL,
	[MainPhoto_PhotoId] [int] NULL,
 CONSTRAINT [PK_dbo.Albums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELMAH_Error](
	[ErrorId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()),
	[Application] [nvarchar](60) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL,
 CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhotoBytesContents]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhotoBytesContents](
	[PhotoBytesContentId] [int] NOT NULL,
	[OriginalPhoto] [varbinary](max) NULL,
	[MediumPhoto] [varbinary](max) NULL,
	[ThumbPhoto] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.PhotoBytesContents] PRIMARY KEY CLUSTERED 
(
	[PhotoBytesContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[PhotoId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreationDate] [datetime] NULL,
	[Location] [nvarchar](max) NULL,
	[CameraModel] [nvarchar](max) NULL,
	[FocalLengthOfLens] [int] NULL,
	[Aperture] [real] NULL,
	[ShutterSpeed] [nvarchar](max) NULL,
	[Iso] [int] NULL,
	[Flash] [bit] NULL,
	[UserId] [nvarchar](max) NULL,
	[Likes] [int] NOT NULL,
	[Dislikes] [int] NOT NULL,
	[Album_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Photos] PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfiles](
	[UserProfileId] [int] IDENTITY(1,1) NOT NULL,
	[UserIdentityId] [nvarchar](max) NULL,
	[FreePhotosUploaded] [int] NULL,
	[FreeAlbumsCreated] [int] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.UserProfiles] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Votes]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Liked] [bit] NOT NULL,
	[Photo_PhotoId] [int] NULL,
	[UserProfile_UserProfileId] [int] NULL,
 CONSTRAINT [PK_dbo.Votes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_MainPhoto_PhotoId]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_MainPhoto_PhotoId] ON [dbo].[Albums]
(
	[MainPhoto_PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Photo_PhotoId]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Photo_PhotoId] ON [dbo].[Albums]
(
	[Photo_PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ELMAH_Error_App_Time_Seq]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error]
(
	[Application] ASC,
	[TimeUtc] DESC,
	[Sequence] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PhotoBytesContentId]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_PhotoBytesContentId] ON [dbo].[PhotoBytesContents]
(
	[PhotoBytesContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Album_Id]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Album_Id] ON [dbo].[Photos]
(
	[Album_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Photo_PhotoId]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Photo_PhotoId] ON [dbo].[Votes]
(
	[Photo_PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserProfile_UserProfileId]    Script Date: 10/31/2016 3:47:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserProfile_UserProfileId] ON [dbo].[Votes]
(
	[UserProfile_UserProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Albums_dbo.Photos_MainPhoto_PhotoId] FOREIGN KEY([MainPhoto_PhotoId])
REFERENCES [dbo].[Photos] ([PhotoId])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_dbo.Albums_dbo.Photos_MainPhoto_PhotoId]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Albums_dbo.Photos_Photo_PhotoId] FOREIGN KEY([Photo_PhotoId])
REFERENCES [dbo].[Photos] ([PhotoId])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_dbo.Albums_dbo.Photos_Photo_PhotoId]
GO
ALTER TABLE [dbo].[PhotoBytesContents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhotoBytesContents_dbo.Photos_PhotoBytesContentId] FOREIGN KEY([PhotoBytesContentId])
REFERENCES [dbo].[Photos] ([PhotoId])
GO
ALTER TABLE [dbo].[PhotoBytesContents] CHECK CONSTRAINT [FK_dbo.PhotoBytesContents_dbo.Photos_PhotoBytesContentId]
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Photos_dbo.Albums_Album_Id] FOREIGN KEY([Album_Id])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_dbo.Photos_dbo.Albums_Album_Id]
GO
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Votes_dbo.Photos_Photo_PhotoId] FOREIGN KEY([Photo_PhotoId])
REFERENCES [dbo].[Photos] ([PhotoId])
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_dbo.Votes_dbo.Photos_Photo_PhotoId]
GO
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Votes_dbo.UserProfiles_UserProfile_UserProfileId] FOREIGN KEY([UserProfile_UserProfileId])
REFERENCES [dbo].[UserProfiles] ([UserProfileId])
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_dbo.Votes_dbo.UserProfiles_UserProfile_UserProfileId]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT 
        @TotalCount = COUNT(1) 
    FROM 
        [ELMAH_Error]
    WHERE 
        [Application] = @Application

    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM 
            [ELMAH_Error]
        WHERE   
            [Application] = @Application
        ORDER BY 
            [TimeUtc] DESC, 
            [Sequence] DESC

    END
    ELSE
    BEGIN

        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT 
        errorId     = [ErrorId], 
        application = [Application],
        host        = [Host], 
        type        = [Type],
        source      = [Source],
        message     = [Message],
        [user]      = [User],
        statusCode  = [StatusCode], 
        time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM 
        [ELMAH_Error] error
    WHERE
        [Application] = @Application
    AND
        [TimeUtc] <= @FirstTimeUTC
    AND 
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC, 
        [Sequence] DESC
    FOR
        XML AUTO



GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT 
        [AllXml]
    FROM 
        [ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId
    AND
        [Application] = @Application



GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NTEXT,
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )



GO
/****** Object:  StoredProcedure [dbo].[spGetPhotosByName]    Script Date: 10/31/2016 3:47:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[spGetPhotosByName]
@Name nvarchar(50),
@UserId nvarchar(50)
as
Begin
  Select * from Photos Where Name LIKE @Name + '%' and UserId = @UserId
End

GO
USE [master]
GO
ALTER DATABASE [PhotoGallery] SET  READ_WRITE 
GO
