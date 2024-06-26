USE [master]
GO
/****** Object:  Database [CRM system]    Script Date: 19.06.2024 20:07:19 ******/
CREATE DATABASE [CRM system]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRM system', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CRM system.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRM system_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CRM system_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CRM system] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRM system].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRM system] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRM system] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRM system] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRM system] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRM system] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRM system] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRM system] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRM system] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRM system] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRM system] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRM system] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRM system] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRM system] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRM system] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRM system] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CRM system] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRM system] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRM system] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRM system] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRM system] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRM system] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRM system] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRM system] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRM system] SET  MULTI_USER 
GO
ALTER DATABASE [CRM system] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRM system] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRM system] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRM system] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRM system] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRM system] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CRM system] SET QUERY_STORE = ON
GO
ALTER DATABASE [CRM system] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CRM system]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 19.06.2024 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](40) NOT NULL,
	[FirstName] [nvarchar](40) NOT NULL,
	[Patronymic] [nvarchar](40) NULL,
	[Birthday] [date] NOT NULL,
	[PhoneNumber] [char](11) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[IdPost] [char](1) NOT NULL,
	[IdWorkSchedule] [tinyint] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[Login] [varchar](15) NOT NULL,
	[Password] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appeal]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appeal](
	[IdAppeal] [int] IDENTITY(1,1) NOT NULL,
	[AppealNumber] [varchar](7) NOT NULL,
	[IdStatus] [tinyint] NOT NULL,
	[IdCategory] [tinyint] NOT NULL,
	[IdClient] [int] NOT NULL,
	[BriefDescription] [nvarchar](40) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IdAppealForm] [char](1) NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[IdPriority] [tinyint] NOT NULL,
	[Commentary] [nvarchar](max) NULL,
 CONSTRAINT [PK_IdAppeal] PRIMARY KEY CLUSTERED 
(
	[IdAppeal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_AppealStatistics]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[VW_AppealStatistics]
AS
	SELECT CONCAT(e.LastName, ' ', e.FirstName) AS 'Employee', COUNT(IdAppeal) AS 'Appeal'
	FROM Employee e LEFT JOIN Appeal a ON e.IdEmployee = a.IdEmployee
	WHERE a.IdStatus = 5
	GROUP BY e.LastName, e.FirstName
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[IdFeedback] [int] IDENTITY(1,1) NOT NULL,
	[IdEvaluation] [tinyint] NOT NULL,
	[Commentary] [nvarchar](max) NULL,
	[IdClient] [int] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[IdFeedback] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[IdEvaluation] [tinyint] NOT NULL,
	[Number] [char](1) NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[IdEvaluation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](40) NULL,
	[FirstName] [nvarchar](40) NULL,
	[Patronymic] [nvarchar](40) NULL,
	[PhoneNumber] [char](11) NULL,
	[Email] [nvarchar](40) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_ClientFeedBack]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_ClientFeedBack]
AS
SELECT c.LastName, c.FirstName, c.Patronymic, 
		e.Number, f.Commentary	  
FROM Client c JOIN ClientFeedback cf ON c.IdClient = cf.IdClient JOIN Feedback f ON cf.IdFeedback = f.IdFeedback 
			  JOIN Evaluation e ON f.IdEvaluation = e.IdEvaluation
GO
/****** Object:  Table [dbo].[Task]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[IdTask] [int] IDENTITY(1,1) NOT NULL,
	[TaskNumber] [varchar](7) NOT NULL,
	[IdStatus] [tinyint] NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[IdPriority] [tinyint] NOT NULL,
	[Commentary] [nvarchar](max) NULL,
	[IdAppeal] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[IdTask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_TaskStatistics]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   VIEW [dbo].[VW_TaskStatistics]
AS
	SELECT CONCAT(e.LastName, ' ', e.FirstName) AS 'Employee', COUNT(IdTask) AS 'Task'
	FROM Employee e LEFT JOIN Task t ON e.IdEmployee = t.IdEmployee
	WHERE t.IdStatus = 5
	GROUP BY e.LastName, e.FirstName
GO
/****** Object:  Table [dbo].[AppealForm]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppealForm](
	[IdAppealForm] [char](1) NOT NULL,
	[AppealFormTitle] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_AppealForm] PRIMARY KEY CLUSTERED 
(
	[IdAppealForm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppealTechnicalSupport]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppealTechnicalSupport](
	[IdAppealTechnicalSupport] [int] IDENTITY(1,1) NOT NULL,
	[BriefDescription] [nvarchar](40) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IdEmployee] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_AppealTechnicalSupport] PRIMARY KEY CLUSTERED 
(
	[IdAppealTechnicalSupport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IdCategory] [tinyint] NOT NULL,
	[CategoryTitle] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[IdPost] [char](1) NOT NULL,
	[PostTitle] [nvarchar](20) NOT NULL,
	[Responsibilities] [nvarchar](150) NULL,
	[Salary] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Priority]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Priority](
	[IdPriority] [tinyint] IDENTITY(1,1) NOT NULL,
	[PriorityNumber] [char](1) NOT NULL,
	[PriorityTitle] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[IdPriority] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IdStatus] [tinyint] IDENTITY(1,1) NOT NULL,
	[StatusTitle] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkSchedule]    Script Date: 19.06.2024 20:07:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkSchedule](
	[IdWorkSchedule] [tinyint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](150) NULL,
 CONSTRAINT [PK_WorkSchedule] PRIMARY KEY CLUSTERED 
(
	[IdWorkSchedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appeal]  WITH CHECK ADD  CONSTRAINT [FK_Appeal_AppealForm] FOREIGN KEY([IdAppealForm])
REFERENCES [dbo].[AppealForm] ([IdAppealForm])
GO
ALTER TABLE [dbo].[Appeal] CHECK CONSTRAINT [FK_Appeal_AppealForm]
GO
ALTER TABLE [dbo].[Appeal]  WITH CHECK ADD  CONSTRAINT [FK_Appeal_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Appeal] CHECK CONSTRAINT [FK_Appeal_Employee]
GO
ALTER TABLE [dbo].[Appeal]  WITH CHECK ADD  CONSTRAINT [FK_Appeal_Priority] FOREIGN KEY([IdPriority])
REFERENCES [dbo].[Priority] ([IdPriority])
GO
ALTER TABLE [dbo].[Appeal] CHECK CONSTRAINT [FK_Appeal_Priority]
GO
ALTER TABLE [dbo].[Appeal]  WITH CHECK ADD  CONSTRAINT [FK_Appeal_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO
ALTER TABLE [dbo].[Appeal] CHECK CONSTRAINT [FK_Appeal_Status]
GO
ALTER TABLE [dbo].[Appeal]  WITH CHECK ADD  CONSTRAINT [FK_IdAppeal_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategory])
GO
ALTER TABLE [dbo].[Appeal] CHECK CONSTRAINT [FK_IdAppeal_Category]
GO
ALTER TABLE [dbo].[Appeal]  WITH CHECK ADD  CONSTRAINT [FK_IdAppeal_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Appeal] CHECK CONSTRAINT [FK_IdAppeal_Client]
GO
ALTER TABLE [dbo].[AppealTechnicalSupport]  WITH CHECK ADD  CONSTRAINT [FK_AppealTechnicalSupport_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[AppealTechnicalSupport] CHECK CONSTRAINT [FK_AppealTechnicalSupport_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Post] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Post] ([IdPost])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Post]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_WorkSchedule] FOREIGN KEY([IdWorkSchedule])
REFERENCES [dbo].[WorkSchedule] ([IdWorkSchedule])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_WorkSchedule]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Client] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Client] ([IdClient])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Client]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Evaluation] FOREIGN KEY([IdEvaluation])
REFERENCES [dbo].[Evaluation] ([IdEvaluation])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Evaluation]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Appeal] FOREIGN KEY([IdAppeal])
REFERENCES [dbo].[Appeal] ([IdAppeal])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Appeal]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Employee]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Priority] FOREIGN KEY([IdPriority])
REFERENCES [dbo].[Priority] ([IdPriority])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Priority]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO
USE [master]
GO
ALTER DATABASE [CRM system] SET  READ_WRITE 
GO
