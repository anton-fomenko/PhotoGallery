USE [master]
GO
/****** Object:  Database [PhotoGalleryIdentity]    Script Date: 11/1/2016 3:32:10 PM ******/
CREATE DATABASE [PhotoGalleryIdentity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotoGalleryIdentity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PhotoGalleryIdentity.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PhotoGalleryIdentity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PhotoGalleryIdentity_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PhotoGalleryIdentity] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotoGalleryIdentity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhotoGalleryIdentity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET RECOVERY FULL 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET  MULTI_USER 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhotoGalleryIdentity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PhotoGalleryIdentity] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhotoGalleryIdentity', N'ON'
GO
USE [PhotoGalleryIdentity]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/1/2016 3:32:10 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/1/2016 3:32:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/1/2016 3:32:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/1/2016 3:32:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/1/2016 3:32:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/1/2016 3:32:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Albums] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201610251430575_InitialCreate', N'PhotoGallery.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C6D6FE43410FE8EC47F88F20950D9F4853B1DD52EA86CDBA3A26FBAED21BE9DBC89771B5DE284C429AD10BF8C0FFC24FE02E3BCDB8E136737FB5284846EEDF133E3F18C3D9E8CFBEFDFFF8C7F7CF63DE30947B11B908979343A340D4CECC071C972622674F1ED3BF3C71FBEFC627CE1F8CFC6AF05DD09A38391249E988F9486A79615DB8FD847F1C877ED288883051DD9816F2127B08E0F0FBFB78E8E2C0C10266019C6F84342A8EBE3F407FC9C06C4C6214D90771338D88BF376E899A5A8C62DF2711C221B4FCCFBC78006EF91E7E1E86594919BC699E722106586BD85692042028A28087AFA31C6331A0564390BA101790F2F2106BA05F2629C4FE0B422D79DCBE1319B8B550D2CA0EC24A681DF13F0E824578E250E5F49C566A93C50DF05A899BEB059A72A9C98570E4E9B3E041E284064783AF522463C316F4A166771788BE9A81838CA202F2380FB23883E8FEA880786F6B883D2988E4787ECBF03639A783489F084E08446C83B30EE93B9E7DABFE09787E033269393A3F9E2E4DD9BB7C83979FB1D3E79539F29CC15E8B80668BA8F821047201B5E94F3370D8B1F678903CB61B5319956C096C02F4CE3063D5F63B2A48FE031C7EF4CE3D27DC64ED1921BD747E2821BC1201A25F0F336F13C34F770D96FB5F264FF6FE17AFCE6ED205C6FD193BB4C975EE00F8E13815F7DC05EDA1B3FBA61E65EDC7A7FCAC92EA3C067BF79FBCA7A3FCD8224B2D9640225C9038A9698F2D28DADCA78B54C9A410D6FD605EAFE9B36935436EF465236A1553CA160B16D6F28E4DD2C5F6D8B3B0B4358BCD4B49846DA0CAEE1B41A09C3C1186A4495F11CE91A0F8149FD9FF7C24B378A69C78608FFD462DDCEE91A6D89D199374FFC78E36C2E7CE47A031C231A5C20845BB8918F4BFBF82900A745A4F76ADFA338865DD4F919C58F1B57D00CDB4904CE3DA3C80F37CE0DFC9CE0DBC49FB33D637BBC065B9A873F824B64D320BA206CD4DA78D781FD3948E80571CE11C51FA95D00B29F0FAEAF0F30883867B68DE3F8128C193BD3006E2805E015A127C7BDE1D8DEBEEB306EEA21D76F8EE38453E853415AC572CD14523CA7206B8AE9DA44BD0E962ED113B520558B9A51748A9A93F5159581E9499A53AA054D093AE5CCA8068B92D3151A3E4C4E61F73F4E5E2FEC51ED053535CE6087C4EF31C1116C63CE3DA21447A45A019D7D63176156BA7C8CE9C6CFA694D3AFC84B8666B59237A49BC0F0DE90C2EEBF37A46242F393EBB0A844E3F2581003BC167DF3BDB4DBE704C9B6ED0EDC34B7CD7C3B7B80CA5DCEE238B0DDD40B1AD28679D287971F6238A33B0394CD46CC22C1C4C0D05D76E4410BCCCD148DEA8E9C630F536C9CD9595A758A621B39B21A61424E0FC18A13B541B02A9BC40BF78DC4132C1D476C106297A0183CD52554760B97D86E88BC4E2D0923358F3036F79287D8738E434C18C34E4DE8306F4E1E31014A3EC2A27469686CD52CAEDD101551AB6ACDBB42D86ADDA59CCE566CB2237656D8651EBF6DC430DB35B605E36C57898E00CA44E82E0C34BFABE81A807871D93703156E4C0A03CD43AAAD1828AFB11D1828AF925767A0D9155577FD85FBEABE99277F51DEFEB1DEAAAE1DD826A78F3D33CD2CF684311446E04836CFF339EBC4CFB4E1720672E6F7B3380F75451361E0334CF9944D15EF36C6A1563B8868446D8095A17580E69F502520C9A17A0857E4F25AA5CBA3881EB045DEAD1536DFFB05D89A0DC8D8F54FC93542F50767D138B56E1FE5CC4A6B908C5CEBB250C369300871F3E227AEA114555E56568C4E2CDC271AAE4D2C5F8C16057544AE0A251593195C4B8569766BA92920EB1392ADA525217C5268A998CCE05ACA6DB45B490D41418FB0602D15F147F840CE56643ACAD3A6EC1B5B598959DE30B614B568E31B14862E59D66AD3F216639615A64DBF9DF52FD8F2330CCB8E1BEAB64A694B4E3488D0120BBDC01A244DBF929F238AE688E579A68E2F91359EAD8AEDBF60593F3EE5452CCE81829AFDBBFCFE28153E7087AD1C8DE4209730459F8534691EBDC1009A871BAC581079286A48DD4F032FF1893AC2528FCE3EE0D5C7672D32C2D812E4972228495D529CCBEB5E6B6564AF186A95CA0866F5955243A8F45DC49F758DAB6252354A91A2AAA3A8D2563B5B395528D36FB5C430B1FF6275226CC6B36A553D75905AB33E5655B75387AA5AF5918AC29C3A4ED1A68F92D7DDD441F2A69E18B5D20D09ACD6A78FCA57D7D431F91E7D44A184A60E2974F590B25E28C30959EF58094FA1D1660A7D0E72694C1D5DEEED61DB72910C67E472F70AD80D328B7D3D7C48AEA3E1DC49EED6C7AE8A6AC413628FCF65E5C56CF58339BBBCAF77322B3036B3DD0F73B0D76A14EA40B5E69E587915820496B7EFA539296FB0AB9B5396B459CF9C1418EABD87FBBCCF6F3DAD35096A4CEE9B3DB7BDB7D52CA8F1FA19ED464D43BAC18A2425F7F2262BDC58C7F9EDB1FB8995749DCC484CA350231CED2F31C5FE88118C66BF7B53CFC56C232F086E10711738A6599D8A797C78742C3CD2DA9F0753561C3B5EC3ED5BF56A8A5FB32D949C912714D98F28920B40D6785454814AB9F52BE2E0E789F9673AEA344DD3B07FA5CD07C655FC91B8BF27D0F11025D8F84B2E681DE69145FB1D724F9FC4E86BF5EAB74FD9D003E32E028F39350E055DAEB2C2FC43995ED26443D79066E5E733AFD7A1A4972905F2573E7AFEBA0EB7CAEB93B5C0F817266B4171AF481A7527B8FDEA8F46E62E1DE4C1C85AF36D7C14B21662C3C38FA1F00651A1EA61C72A58CA471D0EFCA4E9A38E9E6ED1F8C86315D1940F3C5CD21F4C7CDEA1BFD916237778A0365CFDB6B1F1A67AEE2C8F5FAB5676D727B05445BF96A3CB95F23DE0D6A8865FC1325E5921F9603140439DF860D8BB34ED8D1787EF4B3D7855A9B3DB32F06D567EB77CDBFB5F157CEF41896243C9D5EECBBAB76D6BAA74F59ED7C6F62BDEDE3363CB0BF1765FA2BD6D635325B3F7DCD87A1562EF99ADEDEAFCDCB1A5691FA13B2FAB962BC4149F9D9A32DE5D65D3D9E701B8E1CF0330822CA2CC5EBB36D7E9B5D5187730AC48D44CD505822263C97124BE12453BDB7E73CD0FFCD6C9E634ED6C1565B56DBCF3FDBF95774ED3CE5B51ACBA8B82EFC672D1A622FC8E7DACAD92ED3515787333E9784FD015B3B6D610BCA67AEE4194C2798FE24BF8EB29DF1E442543BA4E8F726DF9A3369C9DB5BF2E0AE777EC2E2B08F6B74609B6B953B3A4B9228BA038BC05890A12214373832972E0483D8BA8BB4036856E96634E9FEBA7793BF6A5638E9D2B7297D030A13065ECCF3D2EE1C5828036FE694D3A2FF3F82E4CFFF2CC105300315D969BBF233F25AEE794725F36E48414102CBAC833BA6C2D29CBEC2E5F4AA4DB806802E5EA2B83A207EC871E80C57764869EF02AB281F95DE325B25FAA0CA00AA47B2178B58FCF5DB48C901FE718D578F80936ECF8CF3FFC07FDDFFEBC64570000, N'6.1.3-40302')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'166dd8f0-2dae-4ef6-aad4-525e5d9d9f77', NULL, NULL, NULL, N'test15@test.com', 0, N'AC48zHz2zZ90i9AyA8Sqd1k6rRhmI4gubf5NeTNg4tZ5B1yBfNPcTJp9i13t//Vm8Q==', N'7b22db78-fa9b-4e00-b823-0e47f56aef59', NULL, 0, 0, NULL, 1, 0, N'test15@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'171bb02a-8999-489b-8d98-36d677b5c758', NULL, NULL, NULL, N'paiduser@test.com', 0, N'ALejyPTNOVfIp7RGRiN0rvXZZbkkz0oIFZfoDkkYUZcEWklGLZQJfmWsrUZZj5t5yQ==', N'76300b24-acd2-4b6a-9554-7b0338f48b01', NULL, 0, 0, NULL, 1, 0, N'paiduser@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1851766f-0bfe-4da9-9c21-9304285b6668', NULL, NULL, NULL, N'test25@test.com', 0, N'AEkWs6jTxPQOXWOslpQ0AHoSub2/0m1k/pKjotybN6wkAFuKRde4PhaLrf7qOJPNsw==', N'cbcb7978-50d0-45ff-b83a-a8578ffd4753', NULL, 0, 0, NULL, 1, 0, N'test25@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'27a1ee3f-704c-4925-ac1d-383737e4cc31', NULL, NULL, NULL, N'test7@test.com', 0, N'AOaGrOLFieUYwE37R5mhmBTLjdIROP9VC+y6mU20Qvxwr6v07J8JgNrIm304k/HRSg==', N'83c3c9bb-2f6b-45f4-ad34-e21eb7e9a129', NULL, 0, 0, NULL, 1, 0, N'test7@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2b07b57b-2d2f-4c9a-8cf0-e869a52e9729', NULL, NULL, NULL, N'test17@test.com', 0, N'AG3umNMU5rPKv5XhuWRVUmdx+A7mKhVW+elENZVvCpt2GiWY5oyFJA/urdIU+DEa3w==', N'33b50f41-61e7-4b9c-8465-8e639355f5b6', NULL, 0, 0, NULL, 1, 0, N'test17@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ec82c2c-dda9-4e0b-a67b-50ad55709440', NULL, NULL, NULL, N'test2@test.com', 0, N'ALss9BTfJYky93rSPQKhjdTF+CRqkzYRv1IBh7w4hsvOuGF43e/yL45T5uC+H8cj6g==', N'f14b91a1-78b5-4485-9cfa-ece9affca188', NULL, 0, 0, NULL, 1, 0, N'test2@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'32e273c1-47da-4b66-8a83-f4e4a4cc41c8', NULL, NULL, NULL, N'test12@test.com', 0, N'AIHO8W1qik7+d9le7Yjf0yW9O4/zo1trLWxeA0q7TwV38+x6pzN0p+8kT6ayGkv+1w==', N'669bf330-71d9-46f3-adc2-8226cde4d8bf', NULL, 0, 0, NULL, 1, 0, N'test12@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3983f66b-1d6d-462b-bcff-001aa0ab00ee', NULL, NULL, NULL, N'test4@test.com', 0, N'AERjA0EOxwkRrtezItK6W3Wbk037rFdZYs5iTNYGSz2P9RAEc9RbrSZGwBgm2ArRWg==', N'21265ca6-96fc-4a4f-b2e6-4ad0b618ca00', NULL, 0, 0, NULL, 1, 0, N'test4@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3ef2d0ff-1485-4b13-b6b4-94f29de7bca1', NULL, NULL, NULL, N'test21@test.com', 0, N'AJBnyY31HzyAq4X5wvVmvllIyclUylPEY6yhkyYB1KvMXYF8f/+FnRChzmi3TGA2Tw==', N'c22a102e-0d0e-469c-95db-bb94fa6c9252', NULL, 0, 0, NULL, 1, 0, N'test21@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'453bc003-b287-46b9-b326-a5f046bb2996', NULL, NULL, NULL, N'test11@test.com', 0, N'ACFQuNhnoN+cAHxMO30V6zgMXKvBUf5xofAEAixZfKhBTlEe4mbdxSC3JmOC6LXtGQ==', N'f177dfde-3fa9-44f7-9a7d-69a6818c61d6', NULL, 0, 0, NULL, 1, 0, N'test11@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'57324a92-7e9b-403e-a8ff-d3e44596dd14', NULL, NULL, NULL, N'test22@test.com', 0, N'AD4U1yl4aSDusoUp3noTab5CbQUMrFLLPvcPL/g8cw6bCpkCHrmCwW+zPsttg8Y8Ug==', N'bbed0cb2-b534-4873-a375-0d4fb539124d', NULL, 0, 0, NULL, 1, 0, N'test22@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'73d32eb6-9737-4d11-878d-caaacc289006', NULL, NULL, NULL, N'test13@test.com', 0, N'AKc2JwziDbyMQj2FMn0AjWwAIWWkUB0/aKAHCIYzbFH+KIL5Ls7aG0QbMUSje3rg+w==', N'37eaf31a-9876-496a-8e2d-af960d3f28be', NULL, 0, 0, NULL, 1, 0, N'test13@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'82076a15-b2e8-4c19-9feb-0e40691dd252', NULL, NULL, NULL, N'test28@test.com', 0, N'ANLpuBOKnYP2DXaYgTXiLMdrOWIMOP8b4T1u8Ab0wAwIZVtMoT2JAFAuqOTaeA4JOA==', N'17364934-4378-444c-a82b-776b169adff3', NULL, 0, 0, NULL, 1, 0, N'test28@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8f1d87aa-1d77-40bb-82dc-2a88be61f0b8', NULL, NULL, NULL, N'test26@test.com', 0, N'APh5BlCAliyI3q4m6afGnnlBD9zI39LjCbOHM8hapcanEKx0oiP0MnZAh8jHTDbdVg==', N'79ff8fae-7f6f-4fc4-b37d-6d7e95b02a6f', NULL, 0, 0, NULL, 1, 0, N'test26@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'929eb222-20fc-451d-93da-daaa49977ce9', NULL, NULL, NULL, N'test24@test.com', 0, N'AHgNQ/cSEnCeUs5K9Sr1IOfVJ48lPJDhFb9SY+mVgT7Mm1yn/inngqpf7O1keGtZEw==', N'dac11169-8419-45be-bd17-045c3bb09ea8', NULL, 0, 0, NULL, 1, 0, N'test24@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a11e6188-0122-42ae-9049-4c853e46a153', NULL, NULL, NULL, N'freeuser@test.com', 0, N'AOgerRY52O+bxCEtssVdA8WmDAM0w0fxWSk/ZBbDKLcGnlQXCkoThUcbj8H6sl7eXA==', N'5b9ebfb4-4ada-4cb0-a28b-55e9f58e34cc', NULL, 0, 0, NULL, 1, 0, N'freeuser@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a2b74051-e840-4a6b-832d-bb777cc2ed65', NULL, NULL, NULL, N'test1@test.com', 0, N'ALA8ux/SgZVku/JCR/1JpuoP6bYb4ITSz2ea+CHAy0xYlx4zeqB5jmn/WspBxJmN7g==', N'2ff929e2-5dbb-44ea-a452-40afc3cba42d', NULL, 0, 0, NULL, 1, 0, N'test1@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a7718733-1f70-4427-a509-19a27cf1880c', NULL, NULL, NULL, N'test18@test.com', 0, N'ACVj0YwsnorJ1QsPzfhpJuZR0WmLUsBXZOvSOhqnKs6PD6X4RYaWlNZMO097Dt1p1A==', N'adfbe354-906c-4a71-a02b-986aa06c75ff', NULL, 0, 0, NULL, 1, 0, N'test18@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a97cd89d-9773-4799-8369-721c479946b4', NULL, NULL, NULL, N'test23@test.com', 0, N'APSBOCHJL1VZvU6YKPedfdnV6Vk87Ri2pCGaZN9/4x1vYY77QWwBnqk5+5I7BTUi4A==', N'a514ece2-92c4-47b4-8ae2-4e6a0a926f55', NULL, 0, 0, NULL, 1, 0, N'test23@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa4176ff-ead5-40ba-9971-f1f01d23f1da', NULL, NULL, NULL, N'test19@test.com', 0, N'AAxwFfbYeO2Q6/nnZ++G9TjOB9i1MB1kX+xaGfnq1oJfBdyAFCJqDTZRKcAwzmILXA==', N'4d17f846-0509-4bb3-8756-5cd067d3e3a0', NULL, 0, 0, NULL, 1, 0, N'test19@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa74e0e5-049a-4e19-bdc1-795766d7bae0', NULL, NULL, NULL, N'vafon5@gmail.com', 0, N'AP9oHKLYoHhbpi6eBCVpcQlLmypKSZEXGRZeiH/Q8KCQWPfHIXn6396MHF0XT2oUDA==', N'6113c49f-f231-4cd1-8b41-5983a41bd5b0', NULL, 0, 0, NULL, 1, 0, N'vafon5@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b61fc362-539c-44b6-9eb5-37bb36a982f4', NULL, NULL, NULL, N'test14@test.com', 0, N'AKGEJoh/GMXoIPSnTtqYWhnE42Vr84q5VmtkrrBBei8k0EsFKMoxVO+SF8V3T5cUBQ==', N'33c91297-045b-4b05-887e-a7b6c5608e44', NULL, 0, 0, NULL, 1, 0, N'test14@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b666edbe-dcd4-4d79-8bdf-7381989208a3', NULL, NULL, NULL, N'test10@test.com', 0, N'ANv+MBEpI46UniPTRxOiA0fLOhbnnV7rZJPqscQk+8rN/NRtfDpJVJIuTdIGvbLiNg==', N'be443048-7255-4ee6-a54c-4bdb2d35eee7', NULL, 0, 0, NULL, 1, 0, N'test10@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c8cd7b00-80c5-4b9c-aff6-a7ce29f444aa', NULL, NULL, NULL, N'test9@test.com', 0, N'ALVgk+iXl8eTIKCvCPXl1VkaUwdxbvIYqlprvz2qfSb1q8LQb1Hsse+pVaTHT8AonA==', N'1da02feb-b1a4-497c-8232-5ab26ce411f3', NULL, 0, 0, NULL, 1, 0, N'test9@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e5072594-cea7-47c3-9d11-b6bb14b99073', NULL, NULL, NULL, N'test20@test.com', 0, N'AHoO80x3l1HErHRj8U5L7vXEnp8TEyLubjGTRZzzlUuZlBiSgtjTxp76FLH7tEu07w==', N'cb69a576-08b9-40d9-bd24-d5c73ee58319', NULL, 0, 0, NULL, 1, 0, N'test20@test.com')
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Albums], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'edf0fb0d-6333-40fe-b9a3-066bb0e3affd', NULL, NULL, NULL, N'test16@test.com', 0, N'ACIQ1ACoKTo/FOlt0m62M9iqkZ1ul6MN/uW4RVJxypEsuY0s924JFaK9XfSHxjVoJA==', N'0f4db57c-56a3-4f06-90c9-63ba4315a757', NULL, 0, 0, NULL, 1, 0, N'test16@test.com')
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/1/2016 3:32:10 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 11/1/2016 3:32:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 11/1/2016 3:32:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 11/1/2016 3:32:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 11/1/2016 3:32:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/1/2016 3:32:10 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [PhotoGalleryIdentity] SET  READ_WRITE 
GO
