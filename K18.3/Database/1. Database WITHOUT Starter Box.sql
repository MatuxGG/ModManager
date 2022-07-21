USE [master]
RAISERROR( 'Step 1: Clearing backup history',0,1) WITH NOWAIT
GO
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'CHARACTER_01_DBF'
GO
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'RANKING_DBF'
GO
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'ITEM_DBF'
GO
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'ACCOUNT_DBF'
GO
RAISERROR( 'Step 2: Deleting if databases if exists',0,1) WITH NOWAIT
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'CHARACTER_01_DBF')
DROP DATABASE [CHARACTER_01_DBF]
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'RANKING_DBF')
DROP DATABASE [RANKING_DBF]
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'LOGGING_01_DBF')
DROP DATABASE [LOGGING_01_DBF]
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ACCOUNT_DBF')
DROP DATABASE [ACCOUNT_DBF]
GO
RAISERROR( 'Step 3: Create [CHARACTER_01_DBF]',0,1) WITH NOWAIT
GO
CREATE DATABASE [CHARACTER_01_DBF]
GO
ALTER DATABASE [CHARACTER_01_DBF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET ARITHABORT OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET  READ_WRITE 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET  MULTI_USER 
GO
ALTER DATABASE [CHARACTER_01_DBF] SET PAGE_VERIFY CHECKSUM  
GO
USE [CHARACTER_01_DBF]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [CHARACTER_01_DBF] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
RAISERROR( 'Step 4: Create [ACCOUNT_DBF]',0,1) WITH NOWAIT
GO
CREATE DATABASE [ACCOUNT_DBF]
GO
ALTER DATABASE [ACCOUNT_DBF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET ARITHABORT OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ACCOUNT_DBF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ACCOUNT_DBF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ACCOUNT_DBF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ACCOUNT_DBF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ACCOUNT_DBF] SET  READ_WRITE 
GO
ALTER DATABASE [ACCOUNT_DBF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ACCOUNT_DBF] SET  MULTI_USER 
GO
ALTER DATABASE [ACCOUNT_DBF] SET PAGE_VERIFY CHECKSUM  
GO
USE [ACCOUNT_DBF]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [ACCOUNT_DBF] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
RAISERROR( 'Step 5: Create [RANKING_DBF]',0,1) WITH NOWAIT
GO
CREATE DATABASE [RANKING_DBF]
GO
ALTER DATABASE [RANKING_DBF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RANKING_DBF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RANKING_DBF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RANKING_DBF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RANKING_DBF] SET ARITHABORT OFF 
GO
ALTER DATABASE [RANKING_DBF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RANKING_DBF] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [RANKING_DBF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RANKING_DBF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RANKING_DBF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RANKING_DBF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RANKING_DBF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RANKING_DBF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RANKING_DBF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RANKING_DBF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RANKING_DBF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RANKING_DBF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RANKING_DBF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RANKING_DBF] SET  READ_WRITE 
GO
ALTER DATABASE [RANKING_DBF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RANKING_DBF] SET  MULTI_USER 
GO
ALTER DATABASE [RANKING_DBF] SET PAGE_VERIFY CHECKSUM  
GO
USE [RANKING_DBF]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [RANKING_DBF] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
RAISERROR( 'Step 6: Create [LOGGING_01_DBF]',0,1) WITH NOWAIT
GO
CREATE DATABASE [LOGGING_01_DBF]
GO
ALTER DATABASE [LOGGING_01_DBF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET ARITHABORT OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LOGGING_01_DBF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LOGGING_01_DBF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LOGGING_01_DBF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LOGGING_01_DBF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LOGGING_01_DBF] SET  READ_WRITE 
GO
ALTER DATABASE [LOGGING_01_DBF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LOGGING_01_DBF] SET  MULTI_USER 
GO
ALTER DATABASE [LOGGING_01_DBF] SET PAGE_VERIFY CHECKSUM  
GO
USE [LOGGING_01_DBF]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [LOGGING_01_DBF] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
RAISERROR( 'Step 7: Configure [ACCOUNT_DBF]',0,1) WITH NOWAIT
GO
USE [ACCOUNT_DBF]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PCZoneIP](
	[IPID] [int] NOT NULL,
	[PCZoneID] [int] NOT NULL,
	[IPFrom1] [tinyint] NOT NULL,
	[IPFrom2] [tinyint] NOT NULL,
	[IPFrom3] [tinyint] NOT NULL,
	[IPFrom4] [tinyint] NOT NULL,
	[IPTo4] [tinyint] NOT NULL,
	[IsUse] [tinyint] NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[OperID] [varchar](32) NULL,
	[OperDate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PCZone](
	[PCZoneID] [int] NOT NULL,
	[PCZoneName] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Phone] [varchar](100) NOT NULL,
	[CPU] [varchar](100) NOT NULL,
	[VGA] [varchar](100) NOT NULL,
	[RAM] [varchar](100) NOT NULL,
	[Monitor] [varchar](100) NOT NULL,
	[Comment] [varchar](1000) NOT NULL,
	[Grade] [tinyint] NOT NULL,
	[Account] [varchar](32) NOT NULL,
	[RegDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEventRecommend](
	[ofaccount] [varchar](32) NULL,
	[byaccount] [varchar](32) NULL,
	[regdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvent_Board_Provide](
	[account] [varchar](32) NULL,
	[serverindex] [char](2) NULL,
	[m_idPlayer] [char](7) NULL,
	[m_szName] [varchar](32) NULL,
	[regdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_MessengerList]
@serverindex char(2),
@m_szName varchar(32)
as

set nocount on

declare @q1 nvarchar(4000)
declare @m_idPlayer char(7)
set @q1 = '
select @m_idPlayer = m_idPlayer from CHR' + @serverindex + '.CHARACTER_' + @serverindex + '_DBF.dbo.CHARACTER_TBL where m_szName = ''' + @m_szName + ''''
exec sp_executesql @q1, N'@m_idPlayer char(7) output', @m_idPlayer output

set @q1 = '
select c.m_szName, m_idPlayer
from CHR' + @serverindex + '.CHARACTER_' + @serverindex + '_DBF.dbo.tblMessenger as m
	inner join CHR' + @serverindex + '.CHARACTER_' + @serverindex + '_DBF.dbo.CHARACTER_TBL as c on m.idFriend = c.m_idPlayer
where m.idPlayer = ''' + @m_idPlayer + ''' and isblock = ''F'' and chUse = ''T'' order by m.idFriend'
exec sp_executesql @q1
GO
/****** Object:  Table [dbo].[Event_PCZone_20091027_01]    Script Date: 04/03/2010 12:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Event_PCZone_20091027_01](
	[SEQ] [bigint] NOT NULL,
	[id_no1] [varchar](6) NOT NULL,
	[id_no2] [varchar](7) NOT NULL,
	[account] [varchar](32) NOT NULL,
	[s_date] [char](8) NOT NULL,
	[RegIP] [varchar](15) NOT NULL,
	[Gift_Item] [bit] NOT NULL,
	[Gift_Date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Event_PCZone_20091027]    Script Date: 04/03/2010 12:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Event_PCZone_20091027](
	[SEQ] [bigint] NOT NULL,
	[id_no1] [varchar](32) NOT NULL,
	[id_no2] [varchar](32) NOT NULL,
	[account] [varchar](32) NOT NULL,
	[s_date] [char](8) NOT NULL,
	[RegIP] [varchar](15) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[Gift_Item] [bit] NOT NULL,
	[Gift_Date] [datetime] NULL,
	[serverindex] [char](2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CashHistory]    Script Date: 04/03/2010 12:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CashHistory](
	[account] [varchar](32) NULL,
	[beforeCash] [int] NULL,
	[afterCash] [int] NULL,
	[regdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountPlay]    Script Date: 04/03/2010 12:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountPlay](
	[Account] [varchar](32) NOT NULL,
	[PlayDate] [int] NOT NULL,
	[PlayTime] [int] NOT NULL,
 CONSTRAINT [PK_AccountPlay] PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACCOUNT_TBL_DETAIL]    Script Date: 04/03/2010 12:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACCOUNT_TBL_DETAIL](
	[account] [varchar](32) NOT NULL,
	[gamecode] [char](4) NOT NULL,
	[tester] [char](1) NOT NULL,
	[m_chLoginAuthority] [char](1) NOT NULL,
	[regdate] [datetime] NOT NULL,
	[BlockTime] [char](8) NULL,
	[EndTime] [char](8) NULL,
	[WebTime] [char](8) NULL,
	[isuse] [char](1) NOT NULL,
	[secession] [datetime] NULL,
	[email] [varchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ACCOUNT_TBL]    Script Date: 04/03/2010 12:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ACCOUNT_TBL](
	[account] [varchar](32) NOT NULL,
	[password] [varchar](32) NOT NULL,
	[isuse] [char](1) NOT NULL,
	[member] [char](1) NOT NULL,
	[id_no1] [varchar](32) NULL,
	[id_no2] [varchar](32) NULL,
	[realname] [char](1) NOT NULL,
	[reload] [char](1) NULL,
	[OldPassword] [varchar](32) NULL,
	[TempPassword] [varchar](32) NULL,
	[cash] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ACCOUNT_STR]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[ACCOUNT_STR]
@iaccount   	VARCHAR(32),
@ipassword VARCHAR(16)
/***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************



	ACCOUNT_STR ????
	??? : ???
	??? : 2004.01.18

	ex) ACCOUNT_STR 'beat','1234'

***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************/
AS
set nocount on
IF EXISTS(SELECT a.account FROM ACCOUNT_TBL a,ACCOUNT_TBL_DETAIL b 
                  WHERE a.account = b.account AND a.account = @iaccount AND gamecode = 'A000')
	BEGIN
		IF EXISTS(SELECT account FROM ACCOUNT_TBL  
                        WHERE account = @iaccount  AND password = @ipassword )
-- 			BEGIN
-- 			
-- 				DECLARE @birthyear CHAR(4),@currdate CHAR(8)
-- 				SELECT  @birthyear = 	CASE 	WHEN  SUBSTRING(id_no2,1,1) IN ('9','0') THEN '18' + SUBSTRING(id_no1,1,2)
-- 							             							WHEN  SUBSTRING(id_no2,1,1) IN ('1','2') THEN '19' + SUBSTRING(id_no1,1,2)
-- 																	WHEN	 SUBSTRING(id_no2,1,1) IN ('3','4') THEN '20' + SUBSTRING(id_no1,1,2)
-- 																	WHEN  SUBSTRING(id_no2,1,1) IN ('5','6') THEN '21' + SUBSTRING(id_no1,1,2)			
-- 																	WHEN  SUBSTRING(id_no2,1,1) IN ('7','8') THEN '22' + SUBSTRING(id_no1,1,2)
-- 														END			 
-- 				   FROM ACCOUNT_TBL
-- 				WHERE account = @iaccount
-- 
-- 				SELECT @currdate = CONVERT(CHAR(8),GETDATE(),112)
-- 
-- 				SELECT	fError = 	CASE 	WHEN a.id_no1 = 'a00000' 
-- 																THEN '0' 
-- 								 							WHEN b.BlockTime >= @currdate AND b.EndTime < @currdate
-- 										   						THEN '3' 		
-- 															WHEN a.realname = 'F' 
-- 																THEN '4' 										 			
-- 												 			WHEN  @birthyear >  DATEADD(Year,-13,@currdate)
-- 																THEN '5'
-- 												 			WHEN  @birthyear >=  DATEADD(Year,-11,@currdate) AND b.tester = '0'
-- 																THEN '6'															
-- 															ELSE '0' 	END,
-- 
-- 								fText 	=	CASE 	WHEN a.id_no1 = 'a00000' 
-- 																THEN '?? ? ??'	
-- 												 			WHEN b.BlockTime >= @currdate AND b.EndTime < @currdate
-- 														   		THEN '??????? ??? ??'			
-- 															WHEN a.realname = 'F' 
-- 																THEN '????? ???'									 			
-- 												 			WHEN  @birthyear >  DATEADD(Year,-13,@currdate)
-- 																THEN '???? 12? ?? ??? ??? ????? ?? ????.'	
-- 												 			WHEN  @birthyear >=  DATEADD(Year,-11,@currdate) AND b.tester = '0'
-- 																THEN '14? ?? ??? ??? ??? ???? ????? ?? ??? ?????'																
-- 															ELSE  '????? 14? ??' END
-- 				   FROM 	ACCOUNT_TBL a, ACCOUNT_TBL_DETAIL b 
-- 				WHERE 	a.account = b.account AND b.account = @iaccount AND a.[password] = @ipassword
-- 			END
			BEGIN
				SELECT fError = '0', fText = 'OK'
			END
		ELSE
			BEGIN
				SELECT fError = '1', fText = 'Wrong Password !!'
			END
	END	
ELSE
	BEGIN
		SELECT fError = '2', fText = 'Account Not Exists !!'
	END
RETURN

-- ?? ?? Rule
-- 1. (fError=2 ??) ????? ??. ????? "gamecode = A000" ? ??? ??.
-- 2. (fError=1 ??) ????.
-- 3. (fError=0 ??) ?? ? ?? ??( id_no1? a0000 )?? ??.??.??? ??
-- 4. (fError=3 ??) ?????, ???? ??.
-- 5. (fError=4 ??) ????.
-- 6. (fError=5 ??) 12? ???? ??. ???? "???? 12? ?? ??? ??? ]
--                            ????? ?? ????." ?? ??.
-- 7. (fError=6 ??) ?????? ?? ?? ?? tester = 0 ?? "14? ?? ??? ??? 
--                            ?????? ????? ?? ??? ?????"?? ??.
-- 8. (fError=0 ??) ?? ???? ?? ???? ??.
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateNewAccount]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_CreateNewAccount]
@account varchar(32),
@pw varchar(32),
@cash int = 0,
@email varchar(100) = ''
as
set nocount on
set xact_abort on

if not exists (select * from ACCOUNT_TBL where account = @account)
begin


	begin tran
	INSERT ACCOUNT_TBL(account,password,isuse,member,id_no1,id_no2,realname, cash)
	VALUES(@account, @pw, 'T', 'A', '', '', '', @cash)
	INSERT ACCOUNT_TBL_DETAIL(account,gamecode,tester,m_chLoginAuthority,regdate,BlockTime,EndTime,WebTime,isuse,secession, email)
	VALUES(@account,'A000','2','F',GETDATE(),CONVERT(CHAR(8),GETDATE()-1,112),CONVERT(CHAR(8),DATEADD(year,10,GETDATE()),112),CONVERT(CHAR(8),GETDATE()-1,112),'T',NULL, @email)
	insert AccountPlay (Account, PlayDate)
	select @account, convert(int, convert(char(8), getdate(), 112))

	if @@error <> 0
	begin
		rollback tran
		select -1
	end
	else
	begin
		commit tran
		select 1
	end
end
else
begin
	select 0
end
GO
/****** Object:  StoredProcedure [dbo].[usp_ChangePW]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ChangePW]
@account varchar(32),
@pw varchar(32)
as
set nocount on
set xact_abort on

if exists (select * from ACCOUNT_TBL where account = @account)
begin


	begin tran
	update ACCOUNT_TBL
	set [password] = @pw
	where account = @account

	if @@error <> 0
	begin
		rollback tran
		select -1
	end
	else
	begin
		commit tran
		select 1
	end
end
else
begin
	select 0
end
GO
/****** Object:  StoredProcedure [dbo].[usp_ChangeEmail]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ChangeEmail]
@account varchar(32),
@email varchar(100)
as
set nocount on
set xact_abort on

if exists (select * from ACCOUNT_TBL_DETAIL where account = @account)
begin
	begin tran
	update ACCOUNT_TBL_DETAIL
	set email = @email
	where account = @account

	if @@error <> 0
	begin
		rollback tran
		select -1
	end
	else
	begin
		commit tran
		select 1
	end
end
else
begin
	select 0
end
GO
/****** Object:  StoredProcedure [dbo].[uspVerifyEventReturnAccount]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspVerifyEventReturnAccount] 
@paccount	varchar(32)
,@return_value char(1) output
AS

SET NOCOUNT ON

	IF EXISTS (SELECT * FROM tblEventReturn200607 WHERE account=@paccount) BEGIN
		UPDATE tblEventReturn200607 SET ConfirmDt=getdate() WHERE account=@paccount
		SET @return_value = 1
		PRINT(@return_value)
		RETURN 1
	END
	ELSE BEGIN
		SET @return_value = 0
		PRINT(@return_value)
		RETURN 0
	END

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspRecommendAccount]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspRecommendAccount]

@ofaccount varchar(32),
@byaccount varchar(32)

as

set nocount on

insert into tblEventRecommend(ofaccount, byaccount)
select @ofaccount, @byaccount
GO
/****** Object:  StoredProcedure [dbo].[uspChangePassword]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[uspChangePassword]
@pAccount		varchar(32),
@pFlag			int=1,
@pPassword		varchar(32)=''
AS
SET NOCOUNT ON
	
	DECLARE @PasswordString	varchar(50)
	DECLARE @hashPassword char(32)
	DECLARE @oldPassword  char(32)
	
	SELECT @oldPassword=password FROM ACCOUNT_TBL WHERE account=@pAccount
	
	IF @@ROWCOUNT=0 BEGIN
		SELECT retValue=9000 
		RETURN
	END
	ELSE BEGIN
		IF @pFlag=0 BEGIN
			IF @pPassword='' BEGIN
				PRINT 'automatically convert to password:aeonsoft'
				SET @pPassword='aeonsoft'
			END
			
			
			UPDATE ACCOUNT_TBL SET password=@pPassword WHERE account=@pAccount
			
			IF @@ROWCOUNT=0 BEGIN
				SELECT retValue=9001
				RETURN
			END
				
			INSERT INTO MANAGE_DBF.dbo.tblChangePasswordHistory(account, ChangeDt, Password, NewPassword) VALUES (@pAccount, getdate(), @oldPassword, lower(@hashPassword))
			
			IF @@ROWCOUNT=0 BEGIN
				SELECT retValue=9001
				RETURN
			END
		END
		ELSE BEGIN
			SELECT TOP 1 @oldPassword=Password FROM MANAGE_DBF.dbo.tblChangePasswordHistory WHERE account=@pAccount ORDER BY ChangeDt DESC
			
			IF @@ROWCOUNT=0 BEGIN
				SELECT retValue=9002
				RETURN
			END
			ELSE BEGIN
				UPDATE ACCOUNT_DBF.dbo.ACCOUNT_TBL SET password=@oldPassword WHERE account=@pAccount
			
				IF @@ROWCOUNT=0 BEGIN
					SELECT retValue=9003
					RETURN
				END
			END
		END
	END
	
	PRINT 'Change Successfully'
	SELECT retValue=1
	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCashInfo]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_UpdateCashInfo]
@account varchar(32),
@cash int
as
set nocount on
set xact_abort on

if exists (select * from ACCOUNT_TBL where account = @account)
begin
	begin tran
		insert into CashHistory (account, beforeCash, afterCash)
		select @account, cash, @cash from ACCOUNT_TBL where account = @account

		update ACCOUNT_TBL
		set cash = @cash
		where account = @account
	if @@error <> 0
	begin
		rollback tran
		select -1
	end
	else
	begin
		commit tran
		select 1
	end
end
else
begin
	select 0
end
GO
/****** Object:  StoredProcedure [dbo].[usp_undopw]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
create proc [dbo].[usp_undopw]
@id varchar(20),
@dtime varchar(25)
as

set nocount on
set xact_abort on

declare @check int
declare @oldPassword varchar(40)

set @check = (select count([Password]) from MANAGE_DBF.dbo.tblChangePasswordHistory where account = @id and ChangeDt >= @dtime + '.000' and ChangeDt <= @dtime + '.999')

if(@check = 0)
	select 0
else
begin
	set @oldPassword = (select [Password] from MANAGE_DBF.dbo.tblChangePasswordHistory where account = @id and ChangeDt >= @dtime + '.000' and ChangeDt <= @dtime + '.999')

	update ACCOUNT_DBF.dbo.ACCOUNT_TBL
	set [password] = @oldPassword
	where account=@id

	select 1
end
GO
/****** Object:  StoredProcedure [dbo].[USP_PCZoneIP_Check]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
declare @o_Grade tinyint
exec dbo.USP_PCZoneIP_Check '218.38.238.131', @o_Grade output
select @o_Grade

exec LOGIN_STR 'chipi', '85158c7b8a7f3113b0f32b70ed936b2c', '127.0.0.0'
*/
CREATE   proc [dbo].[USP_PCZoneIP_Check]
     @i_IPAddress varchar(15)
    , @o_Grade tinyint output
as
set nocount on
set transaction isolation level read uncommitted

declare @i_IP1 tinyint
declare @i_IP2 tinyint
declare @i_IP3 tinyint
declare @i_IP4 tinyint

declare @index int

--@i_IP1
set @index = charindex('.', @i_IPAddress)
set @i_IP1 = left(@i_IPAddress, @index-1)
set @i_IPAddress = right(@i_IPAddress, len(@i_IPAddress)-@index)

--@i_IP2
set @index = charindex('.', @i_IPAddress)
set @i_IP2 = left(@i_IPAddress, @index-1)
set @i_IPAddress = right(@i_IPAddress, len(@i_IPAddress)-@index)

--@i_IP3, @i_IP4 
set @index = charindex('.', @i_IPAddress)
set @i_IP3 = left(@i_IPAddress, @index-1)
set @i_IP4 = right(@i_IPAddress, len(@i_IPAddress)-@index)

--PCZoneIP_Check
select @o_Grade = b.Grade
from PCZoneIP a
        inner join PCZone b
            on a.PCZoneID = b.PCZoneID
where IsUse in (1, 9)
and IPFrom1 = @i_IP1
and IPFrom2 = @i_IP2
and IPFrom3 = @i_IP3
and IPFrom4 <= @i_IP4 and IPTo4 >= @i_IP4

select @o_Grade = isnull(@o_Grade, 0)
GO
/****** Object:  StoredProcedure [dbo].[usp_passwordhistory]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_passwordhistory]
@account varchar(20)
as

set nocount on
set xact_abort on

select ChangeDt
from MANAGE_DBF.dbo.tblChangePasswordHistory
where account = @account
order by ChangeDt desc
GO
/****** Object:  StoredProcedure [dbo].[usp_og_ChangePassWord]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_og_ChangePassWord]
@account varchar(32),
@password varchar(32)
as
set nocount on
set xact_abort on

if exists (select * from ACCOUNT_TBL where account = @account)
begin	
	begin tran			
		Update ACCOUNT_TBL SET Password = @password Where account=@account
		if @@error <> 0
		begin
			rollback tran
			select -1
		end
		else
		begin
			commit tran
			select 1
		end
end
else
begin
	select 0
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAccountPassword]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[sp_UpdateAccountPassword]
		@account		varchar(32),
		@password	varchar(32)
AS
SET NOCOUNT ON


	Update ACCOUNT_TBL SET Password = @password Where Account=@account
GO
/****** Object:  StoredProcedure [dbo].[LOGINJOIN_STR]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROC [dbo].[LOGINJOIN_STR]
	@iGu        		CHAR(2) 			= 'A1', 
	@iaccount   	VARCHAR(32)
/***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************

	LOGINJOIN_STR ????
	??? : ???
	??? : 2004.01.30 
	??? : 2004.04.08  @iGu = 'A3' WHERE ?? ??

	ex) LOGINONOFF_STR 'A1','1234'

***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************/

AS
set nocount on

IF @iGu = 'A1' -- ON
	BEGIN
		UPDATE ACCOUNT_TBL_DETAIL
		SET isuse = 'J'
		WHERE account = @iaccount
	RETURN
	END

ELSE
IF @iGu = 'A2' -- OFF
	BEGIN
		UPDATE ACCOUNT_TBL_DETAIL
		SET isuse = 'O'
		WHERE account = @iaccount	
	RETURN
	END

ELSE
IF @iGu = 'A3' -- ALL OFF
	BEGIN
		UPDATE ACCOUNT_TBL_DETAIL
		SET isuse = 'O'
		WHERE  isuse = 'J'
	RETURN
	END

set nocount off
GO
/****** Object:  StoredProcedure [dbo].[LOGIN_STR]    Script Date: 04/03/2010 12:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LOGIN_STR]
	@iaccount   	VARCHAR(32),
	@ipassword 		char(32)
   -- Ver. 14 PCZoneIP
   ,@i_IPAddress varchar(15) = '0.0.0.0'

AS
set nocount on

-- Ver 14. PCZoneIP_Check
declare @o_Grade tinyint
exec dbo.USP_PCZoneIP_Check @i_IPAddress, @o_Grade output      

IF EXISTS(SELECT a.account FROM ACCOUNT_TBL a,ACCOUNT_TBL_DETAIL b 
                  WHERE a.account = b.account AND a.account = @iaccount ) -- AND gamecode = 'A000') 
BEGIN
	
	DECLARE @curDate char(8)

		IF EXISTS(SELECT account FROM ACCOUNT_TBL  
                        WHERE account = @iaccount  AND password = @ipassword) BEGIN

			SELECT 	@curDate=CONVERT(CHAR(8), getdate(), 112)
			
			SELECT 	fError=CASE 
							-- WHEN session<>@isession OR sessionExpireDt<getdate() THEN '91'
							WHEN BlockTime>=@curDate THEN '9' 
							ELSE '0' END,
				   	fText= CASE 
							-- WHEN session<>@isession OR sessionExpireDt<getdate() THEN 'Session Expired'
							WHEN BlockTime>=@curDate THEN 'Block' ELSE 'OK' END,
				   	fCheck=tester,
					f18='1' 
					-- Ver14. PCZoneIP
					 ,fPCZone = @o_Grade
			FROM ACCOUNT_TBL a INNER JOIN ACCOUNT_TBL_DETAIL b ON (a.account=b.account)
			WHERE a.account=@iaccount
		END
		ELSE BEGIN
			SELECT fError = '1', fText = 'Wrong Password !!',fCheck ='',f18='1', fPCZone = '0'			-- PCZoneIP (, fPCZone = '0' ??)
		END
END	
ELSE BEGIN
	SELECT fError = '2', fText = 'Account Not Exists !!',fCheck ='',f18='1', fPCZone = '0'			-- PCZoneIP (, fPCZone = '0' ??)
END

RETURN

-- ?? ?? Rule
-- 1. (fError=2 ??) ????? ??. ????? "gamecode = A000" ? ??? ??.
-- 2. (fError=1 ??) ????.
-- 3. (fError=0 ??) ?? ? ?? ??( id_no1? a0000 )?? ??.??.??? ??
-- 4. (fError=3 ??) ?????, ???? ??.
-- 5. (fError=4 ??) ????.
-- 6. (fError=5 ??) 12? ???? ??. ???? "???? 12? ?? ??? ??? ]
--                            ????? ?? ????." ?? ??.
-- 7. (fError=6 ??) ?????? ?? ?? ?? tester = 0 ?? "14? ?? ??? ??? 
--                            ?????? ????? ?? ??? ?????"?? ??.
-- 8. (fError=0 ??) ?? ???? ?? ???? ??.
set nocount off
GO
/****** Object:  Default [DF_AccountPlay_Account]    Script Date: 04/03/2010 12:41:04 ******/
ALTER TABLE [dbo].[AccountPlay] ADD  CONSTRAINT [DF_AccountPlay_Account]  DEFAULT ('') FOR [Account]
GO
/****** Object:  Default [DF_AccountPlay_PlayDate]    Script Date: 04/03/2010 12:41:04 ******/
ALTER TABLE [dbo].[AccountPlay] ADD  CONSTRAINT [DF_AccountPlay_PlayDate]  DEFAULT ('') FOR [PlayDate]
GO
/****** Object:  Default [DF_AccountPlay_PlayTime]    Script Date: 04/03/2010 12:41:04 ******/
ALTER TABLE [dbo].[AccountPlay] ADD  CONSTRAINT [DF_AccountPlay_PlayTime]  DEFAULT ((0)) FOR [PlayTime]
GO
/****** Object:  Default [DF_CashHistory_regdate]    Script Date: 04/03/2010 12:41:04 ******/
ALTER TABLE [dbo].[CashHistory] ADD  CONSTRAINT [DF_CashHistory_regdate]  DEFAULT (getdate()) FOR [regdate]
GO
RAISERROR( 'Step 8: Configure [CHARACTER_01_DBF]',0,1) WITH NOWAIT
GO

USE [CHARACTER_01_DBF]
GO
/****** Object:  Table [dbo].[tblCouple_deleted]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCouple_deleted](
	[cid] [int] NULL,
	[nServer] [int] NULL,
	[nExperience] [int] NULL,
	[add_Date] [datetime] NULL,
	[del_Date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCouple]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCouple](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[nServer] [int] NOT NULL,
	[nExperience] [int] NULL,
	[add_Date] [datetime] NULL,
 CONSTRAINT [PK_tblCouple] PRIMARY KEY CLUSTERED 
(
	[cid] ASC,
	[nServer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCampus]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCampus](
	[idCampus] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_tblCampus] PRIMARY KEY CLUSTERED 
(
	[idCampus] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus', @level2type=N'COLUMN',@level2name=N'idCampus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  Table [dbo].[tblAccountList]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblAccountList](
	[account] [varchar](32) NULL,
	[rid] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_VALENTINE_EVENT]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_VALENTINE_EVENT](
	[Prodate] [char](8) NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[regdate] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAX_INFO_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAX_INFO_TBL](
	[serverindex] [char](2) NULL,
	[nTimes] [int] NULL,
	[nContinent] [int] NULL,
	[dwID] [char](7) NULL,
	[dwNextID] [char](7) NULL,
	[bSetTaxRate] [int] NULL,
	[change_time] [char](12) NULL,
	[save_time] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCombatInfo]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCombatInfo](
	[CombatID] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[Status] [varchar](3) NOT NULL,
	[StartDt] [datetime] NULL,
	[EndDt] [datetime] NULL,
	[Comment] [varchar](1000) NOT NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tblCombatInfo] PRIMARY KEY CLUSTERED 
(
	[CombatID] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblChangeBankPW]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChangeBankPW](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[make_comma]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[make_comma](

@cur_num varchar(6005) 

) returns int

as

begin
  

 declare @i as int
 declare @ret as int




  set @i = 1
  set @ret = 0

 

  while @i <= len(@cur_num)

   begin

      

       if   substring(@cur_num,@i,1)  = '/'

         begin
         

             set @ret = @ret + 1


         end 

       set @i = @i + 1             

   end 

 

   return @ret

 

end
GO
/****** Object:  Table [dbo].[MAIL_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MAIL_TBL](
	[serverindex] [char](2) NOT NULL,
	[nMail] [bigint] NOT NULL,
	[idReceiver] [char](7) NULL,
	[idSender] [char](7) NULL,
	[nGold] [bigint] NOT NULL,
	[tmCreate] [int] NULL,
	[byRead] [int] NULL,
	[szTitle] [varchar](128) NOT NULL,
	[szText] [varchar](255) NOT NULL,
	[dwItemId] [int] NOT NULL,
	[nItemNum] [int] NOT NULL,
	[nRepairNumber] [int] NOT NULL,
	[nHitPoint] [int] NOT NULL,
	[nMaxHitPoint] [int] NOT NULL,
	[nMaterial] [int] NOT NULL,
	[byFlag] [int] NOT NULL,
	[dwSerialNumber] [int] NOT NULL,
	[nOption] [int] NOT NULL,
	[bItemResist] [int] NOT NULL,
	[nResistAbilityOption] [int] NOT NULL,
	[idGuild] [int] NOT NULL,
	[nResistSMItemId] [int] NOT NULL,
	[bCharged] [int] NOT NULL,
	[dwKeepTime] [int] NOT NULL,
	[nRandomOptItemId] [bigint] NULL,
	[nPiercedSize] [int] NOT NULL,
	[dwItemId1] [int] NOT NULL,
	[dwItemId2] [int] NOT NULL,
	[dwItemId3] [int] NOT NULL,
	[dwItemId4] [int] NOT NULL,
	[SendDt] [datetime] NULL,
	[ReadDt] [datetime] NULL,
	[GetGoldDt] [datetime] NULL,
	[DeleteDt] [datetime] NULL,
	[ItemFlag] [int] NOT NULL,
	[ItemReceiveDt] [datetime] NULL,
	[GoldFlag] [int] NOT NULL,
	[bPet] [int] NULL,
	[nKind] [int] NULL,
	[nLevel] [int] NULL,
	[dwExp] [int] NULL,
	[wEnergy] [int] NULL,
	[wLife] [int] NULL,
	[anAvailLevel_D] [int] NULL,
	[anAvailLevel_C] [int] NULL,
	[anAvailLevel_B] [int] NULL,
	[anAvailLevel_A] [int] NULL,
	[anAvailLevel_S] [int] NULL,
	[dwItemId5] [int] NULL,
	[dwItemId6] [int] NULL,
	[dwItemId7] [int] NULL,
	[dwItemId8] [int] NULL,
	[dwItemId9] [int] NULL,
	[dwItemId10] [int] NULL,
	[dwItemId11] [int] NULL,
	[dwItemId12] [int] NULL,
	[dwItemId13] [int] NULL,
	[dwItemId14] [int] NULL,
	[dwItemId15] [int] NULL,
	[nPiercedSize2] [int] NULL,
	[szPetName] [varchar](32) NULL,
 CONSTRAINT [PK_MAIL_No] PRIMARY KEY CLUSTERED 
(
	[serverindex] ASC,
	[nMail] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PARTY_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PARTY_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[partyname] [varchar](16) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RAINBOWRACE_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RAINBOWRACE_TBL](
	[serverindex] [char](2) NULL,
	[nTimes] [int] NULL,
	[m_idPlayer] [char](7) NULL,
	[chState] [char](1) NULL,
	[nRanking] [int] NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QUEST_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUEST_TBL](
	[m_idPlayer] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_wId] [int] NOT NULL,
	[m_nState] [tinyint] NULL,
	[m_wTime] [int] NULL,
	[m_nKillNPCNum_0] [tinyint] NULL,
	[m_nKillNPCNum_1] [tinyint] NULL,
	[m_bPatrol] [tinyint] NULL,
	[m_bDialog] [tinyint] NULL,
	[m_bReserve3] [tinyint] NULL,
	[m_bReserve4] [tinyint] NULL,
	[m_bReserve5] [tinyint] NULL,
	[m_bReserve6] [tinyint] NULL,
	[m_bReserve7] [tinyint] NULL,
	[m_bReserve8] [tinyint] NULL,
 CONSTRAINT [PK_QUEST_idPlayer_idQuest] PRIMARY KEY CLUSTERED 
(
	[serverindex] ASC,
	[m_idPlayer] ASC,
	[m_wId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SECRET_ROOM_MEMBER_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SECRET_ROOM_MEMBER_TBL](
	[serverindex] [char](2) NULL,
	[nTimes] [int] NULL,
	[nContinent] [int] NULL,
	[m_idGuild] [char](6) NULL,
	[m_idPlayer] [char](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_generate_insert_script]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_generate_insert_script] 
	@tablename_mask sysname = NULL
as
	begin
	
	-------------------------------------------------------------------------------- 
	
	-- Stored Procedure: sp_generate_insert_script
	-- Language: Microsoft Transact SQL (7.0)
	-- Author: Inez Boone (inez.boone@xs4al.nl)
	-- working on the Sybase version of & thanks to:
	-- Reinoud van Leeuwen (reinoud@xs4all.nl)
	-- Version: 1.4
	-- Date: December 6th, 2000
	-- Description: This stored procedure generates an SQL script to fill the
	-- tables in the database with their current content.
	-- Parameters: IN: @tablename_mask : mask for tablenames
	-- History: 1.0 October 3rd 1998 Reinoud van Leeuwen
	-- first version for Sybase
	-- 1.1 October 7th 1998 Reinoud van Leeuwen
	-- added limited support for text fields; the first 252 
	-- characters are selected.
	-- 1.2 October 13th 1998 Reinoud van Leeuwen
	-- added support for user-defined datatypes
	-- 1.3 August 4 2000 Inez Boone
	-- version for Microsoft SQL Server 7.0
	-- use dynamic SQL, no intermediate script
	-- 1.4 December 12 2000 Inez Boone
	-- handles quotes in strings, handles identity columns
	-- 1.5 December 21 2000 Inez Boone
	-- Output sorted alphabetically to assist db compares,
	-- skips timestamps
	-- 1.6 June 10 2005 Beatchoi@yahoo.co.kr
	-- added support for reserver keyword 
	-------------------------------------------------------------------------------- 
	
	-- NOTE: If, when executing in the Query Analyzer, the result is truncated, you can remedy
	-- this by choosing Query / Current Connection Options, choosing the Advanced tab and
	-- adjusting the value of 'Maximum characters per column'.
	-- Unchecking 'Print headers' will get rid of the line of dashes.
	
	
	declare @tablename varchar (128)
	declare @tablename_max varchar (128)
	declare @tableid int
	declare @columncount numeric (7,0)
	declare @columncount_max numeric (7,0)
	declare @columnname varchar (30)
	declare @columntype int
	declare @string varchar (30)
	declare @leftpart varchar (8000) /* 8000 is the longest string SQLSrv7 can EXECUTE */
	declare @rightpart varchar (8000) /* without having to resort to concatenation */
	declare @hasident int
	 
	
	set nocount on
	
	-- take ALL tables when no mask is given (!)
	
	if (@tablename_mask is NULL)
		begin
			select @tablename_mask = '%'
		end
	
	
	-- create table columninfo now, because it will be used several times
	
	 
	
	create table #columninfo (num numeric (7,0) identity,name varchar(30),usertype smallint)
	
	select name,id into #tablenames
	from sysobjects
	where type in ('U' ,'S')
	and name like @tablename_mask
	
	 
	
	-- loop through the table #tablenames
	
	select @tablename_max = MAX (name),@tablename = MIN (name)
	from #tablenames
	
	
	while @tablename <= @tablename_max
		begin
			select @tableid = id
			from #tablenames
			where name = @tablename
			
			if (@@rowcount <> 0)
			begin
				-- Find out whether the table contains an identity column
				select @hasident = max( status & 0x80 )
				from syscolumns
				where id = @tableid
				
				truncate table #columninfo
				
				insert into #columninfo (name,usertype)
				select name, type
				from syscolumns C
				where id = @tableid
				and type <> 37 -- do not include timestamps
				
				-- Fill @leftpart with the first part of the desired insert-statement, with the fieldnames
				
				select @leftpart = 'select ''insert into '+@tablename
				select @leftpart = @leftpart + '('
				select @columncount = MIN (num),@columncount_max = MAX (num)
				from #columninfo
				
				
				while @columncount <= @columncount_max
					begin
						select @columnname = quotename([name]),@columntype = usertype
						from #columninfo
						where num = @columncount
				
						if (@@rowcount <> 0)			
							begin
								if (@columncount < @columncount_max)
									begin
										select @leftpart = @leftpart + @columnname + ','
									end
								else
									begin
										select @leftpart = @leftpart + @columnname + ')'
									end
							end
						select @columncount = @columncount + 1
					end
		
		 
		
				select @leftpart = @leftpart + ' values('''
	
				-- Now fill @rightpart with the statement to retrieve the values of the fields, correctly formatted
	
				select @columncount = MIN (num),
				@columncount_max = MAX (num)
				from #columninfo
	
	 
				select @rightpart = ''
	
				while @columncount <= @columncount_max
					begin
						select @columnname = quotename(name),@columntype = usertype
						from #columninfo
						where num = @columncount
				
						if (@@rowcount <> 0)
							begin
							
								if @columntype in (39,47) /* char fields need quotes (except when entering NULL);
								                                        * use char(39) == ', easier readable than escaping
								                                        */
								begin
									select @rightpart = @rightpart + '+'
									select @rightpart = @rightpart + 'ISNULL(' + replicate( char(39), 4 ) + '+replace(' + @columnname + ',' + replicate( char(39), 4 ) + ',' + replicate( char(39), 6) + ')+' + replicate ( char(39), 4 ) + ',''NULL'')'
								end
								
								else if @columntype = 35 /* TEXT fields cannot be RTRIM-ed and need quotes */
																			 /* convert to VC 1000 to leave space for other fields */
								begin
									select @rightpart = @rightpart + '+'
									select @rightpart = @rightpart + 'ISNULL(' + replicate( char(39), 4 ) + '+replace (convert(varchar(1000),' + @columnname + ')' + ',' + replicate( char(39), 4 ) + ',' + replicate( char(39), 6 ) + ')+' + replicate( char(39), 4 ) + ',''NULL'')'
								end
								
								else if @columntype in (58,61,111) /* datetime fields */
								begin
									select @rightpart = @rightpart + '+'
									select @rightpart = @rightpart + 'ISNULL(' + replicate( char(39), 4 ) + '+convert (varchar(20),' + @columnname + ')+'+ replicate( char(39), 4 ) + ',''NULL'')'
								end
								
								else /* numeric types */
								begin
									select @rightpart = @rightpart + '+'
									select @rightpart = @rightpart + 'ISNULL(convert(varchar(99),' + @columnname + '),''NULL'')'
								end
					
								if ( @columncount < @columncount_max)
								begin
									select @rightpart = @rightpart + '+'','''
								end
				
							end
								select @columncount = @columncount + 1
						end
				end
	
			select @rightpart = @rightpart + '+'')''' + ' from ' + @tablename
	
			-- Order the select-statements by the first column so you have the same order for
			-- different database (easy for comparisons between databases with different creation orders)
	
			select @rightpart = @rightpart + ' order by 1' 
	
			-- For tables which contain an identity column we turn identity_insert on
			-- so we get exactly the same content 
		
			if @hasident > 0
				select 'SET IDENTITY_INSERT ' + @tablename + ' ON'
			
				exec ( @leftpart + @rightpart )
			
			if @hasident > 0
				select 'SET IDENTITY_INSERT ' + @tablename + ' OFF'
			
			select @tablename = MIN (name)
			from #tablenames
			where name > @tablename

		end

	end
return
GO
/****** Object:  Table [dbo].[SKILLINFLUENCE_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SKILLINFLUENCE_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[SkillInfluence] [varchar](7500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SKILL_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SKILL_TBL](
	[Index] [int] NULL,
	[szName] [varchar](256) NULL,
	[job] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SHOW_STAT_DATE_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SHOW_STAT_DATE_STR]
@tablemask sysname='%', @indexmask sysname='%'
AS

	SELECT
			LEFT(CAST(user_name(uid)+'.'+o.name AS sysname),30) AS tablename,
			LEFT(i.name,30) as indexname,
			CASE
				WHEN indexproperty(o.id, i.name, 'IsAutoStatistics') = 1 THEN 'AutoStatistics'
				WHEN indexproperty(o.id, i.name, 'IsStatistics') = 1     THEN 'Statistics'
				ELSE 'Index'
			END AS Type,
			stats_date(o.id, i.indid) AS statsUpdated,
			rowcnt,
			rowmodctr,
			ISNULL(CAST(rowmodctr/CAST(NULLIF(rowcnt,0) AS decimal(20,2)) * 100 AS int),0) AS percentmodifiedRows,
			CASE i.status & 0x1000000
				WHEN 0 THEN 'No'
				ELSE 'Yes'
			END AS [norecompute?],
			i.status
	  FROM
			dbo.sysobjects o join dbo.sysindexes i ON (o.id = i.id)
	 WHERE
			o.name like @tablemask
	   AND 	i.name like @indexmask
	   AND 	objectproperty(o.id, 'IsUserTable')=1
	   AND	i.indid between 1 and 254
	 ORDER BY tablename, indexname

RETURN
GO
/****** Object:  Table [dbo].[SECRET_ROOM_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SECRET_ROOM_TBL](
	[serverindex] [char](2) NULL,
	[nTimes] [int] NULL,
	[nContinent] [int] NULL,
	[m_idGuild] [char](6) NULL,
	[nPenya] [int] NULL,
	[chState] [char](1) NULL,
	[s_date] [datetime] NULL,
	[dwWorldID] [int] NULL,
	[nWarState] [int] NULL,
	[nKillCount] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TASKBAR_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TASKBAR_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_aSlotApplet] [varchar](3100) NULL,
	[m_aSlotQueue] [varchar](225) NULL,
	[m_SkillBar] [smallint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TASKBAR_ITEM_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TASKBAR_ITEM_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_aSlotItem] [varchar](6885) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAG_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAG_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[f_idPlayer] [char](7) NULL,
	[m_Message] [varchar](255) NULL,
	[State] [char](1) NULL,
	[CreateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSkillPoint]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSkillPoint](
	[serverindex] [char](2) NOT NULL,
	[PlayerID] [char](7) NULL,
	[SkillID] [int] NOT NULL,
	[SkillLv] [int] NOT NULL,
	[SkillPosition] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRestPoint]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRestPoint](
	[serverindex] [char](2) NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[m_nRestPoint] [int] NULL,
	[m_LogOutTime] [int] NULL,
 CONSTRAINT [PK_tblRestPoint] PRIMARY KEY NONCLUSTERED 
(
	[serverindex] ASC,
	[m_idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRemoveItemFromGuildBank]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRemoveItemFromGuildBank](
	[nNum] [int] IDENTITY(1,1) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[idGuild] [char](6) NOT NULL,
	[ItemIndex] [varchar](32) NOT NULL,
	[ItemSerialNum] [int] NOT NULL,
	[ItemCnt] [int] NOT NULL,
	[DeleteRequestCnt] [int] NOT NULL,
	[DeleteCnt] [int] NOT NULL,
	[ItemFlag] [int] NOT NULL,
	[RegisterDt] [datetime] NOT NULL,
	[DeleteDt] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblQuizAnswer]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuizAnswer](
	[m_nIndex] [int] NOT NULL,
	[m_Answer1] [varchar](256) NULL,
	[m_Answer2] [varchar](256) NULL,
	[m_Answer3] [varchar](256) NULL,
	[m_Answer4] [varchar](256) NULL,
 CONSTRAINT [PK_tblQuizAnswer] PRIMARY KEY CLUSTERED 
(
	[m_nIndex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswer', @level2type=N'COLUMN',@level2name=N'm_nIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswer', @level2type=N'COLUMN',@level2name=N'm_Answer1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswer', @level2type=N'COLUMN',@level2name=N'm_Answer2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswer', @level2type=N'COLUMN',@level2name=N'm_Answer3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? 4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswer', @level2type=N'COLUMN',@level2name=N'm_Answer4'
GO
/****** Object:  Table [dbo].[tblQuiz]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuiz](
	[m_nIndex] [int] IDENTITY(1,1) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_nQuizType] [int] NOT NULL,
	[m_nAnswer] [int] NULL,
	[m_chState] [char](1) NOT NULL,
	[m_szQuestion] [varchar](1024) NULL,
	[s_date] [datetime] NULL,
	[m_Item] [int] NULL,
	[m_ItemCount] [tinyint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPropose]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPropose](
	[nServer] [int] NULL,
	[idProposer] [int] NULL,
	[tPropose] [int] NULL,
 CONSTRAINT [UQ_tblPropose_idProposer] UNIQUE CLUSTERED 
(
	[nServer] ASC,
	[idProposer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPocketExt]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPocketExt](
	[serverindex] [char](2) NOT NULL,
	[idPlayer] [char](7) NOT NULL,
	[nPocket] [int] NOT NULL,
	[szExt] [varchar](2000) NOT NULL,
	[szPiercing] [varchar](8000) NULL,
	[szPet] [varchar](4200) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPocket]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPocket](
	[serverindex] [char](2) NOT NULL,
	[idPlayer] [char](7) NOT NULL,
	[nPocket] [int] NOT NULL,
	[szItem] [varchar](4290) NOT NULL,
	[szIndex] [varchar](215) NOT NULL,
	[szObjIndex] [varchar](215) NOT NULL,
	[bExpired] [int] NOT NULL,
	[tExpirationDate] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMessenger]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMessenger](
	[idPlayer] [char](7) NOT NULL,
	[idFriend] [char](7) NOT NULL,
	[bBlock] [int] NOT NULL,
	[chUse] [char](1) NOT NULL,
	[serverindex] [char](2) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblMaster_all]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblMaster_all](
	[serverindex] [char](2) NULL,
	[m_idPlayer] [char](7) NULL,
	[sec] [tinyint] NULL,
	[c01] [int] NULL,
	[c02] [int] NULL,
	[c03] [int] NULL,
	[c04] [int] NULL,
	[c05] [int] NULL,
	[c06] [int] NULL,
	[c07] [int] NULL,
	[c08] [int] NULL,
	[c09] [int] NULL,
	[c10] [int] NULL,
	[c11] [int] NULL,
	[c12] [int] NULL,
	[c13] [int] NULL,
	[c14] [int] NULL,
	[c15] [int] NULL,
	[c16] [int] NULL,
	[c17] [int] NULL,
	[c18] [int] NULL,
	[c19] [int] NULL,
	[c20] [int] NULL,
	[c21] [int] NULL,
	[c22] [int] NULL,
	[c23] [int] NULL,
	[c24] [int] NULL,
	[c25] [int] NULL,
	[c26] [int] NULL,
	[c27] [int] NULL,
	[c28] [int] NULL,
	[c29] [int] NULL,
	[c30] [int] NULL,
	[c31] [int] NULL,
	[c32] [int] NULL,
	[c33] [int] NULL,
	[c34] [int] NULL,
	[c35] [int] NULL,
	[c36] [int] NULL,
	[c37] [int] NULL,
	[c38] [int] NULL,
	[c39] [int] NULL,
	[c40] [int] NULL,
	[c41] [int] NULL,
	[c42] [int] NULL,
	[c43] [int] NULL,
	[c44] [int] NULL,
	[c45] [int] NULL,
	[c46] [int] NULL,
	[c47] [int] NULL,
	[c48] [int] NULL,
	[c49] [int] NULL,
	[c50] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLordSkill]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLordSkill](
	[nServer] [int] NOT NULL,
	[nSkill] [int] NOT NULL,
	[nTick] [int] NOT NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLordEvent]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLordEvent](
	[nServer] [int] NOT NULL,
	[idPlayer] [int] NOT NULL,
	[nTick] [int] NOT NULL,
	[fEFactor] [float] NOT NULL,
	[fIFactor] [float] NOT NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLordElector]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLordElector](
	[nServer] [int] NOT NULL,
	[idElection] [int] NOT NULL,
	[idElector] [int] NOT NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLordElection]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLordElection](
	[nServer] [int] NOT NULL,
	[idElection] [int] NOT NULL,
	[eState] [int] NOT NULL,
	[s_date] [datetime] NULL,
	[szBegin] [varchar](16) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLordCandidates]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLordCandidates](
	[nServer] [int] NOT NULL,
	[idElection] [int] NOT NULL,
	[idPlayer] [int] NOT NULL,
	[iDeposit] [bigint] NOT NULL,
	[nVote] [int] NOT NULL,
	[szPledge] [varchar](255) NOT NULL,
	[IsLeftOut] [char](1) NOT NULL,
	[s_date] [datetime] NULL,
	[tCreate] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLord]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLord](
	[nServer] [int] NOT NULL,
	[idElection] [int] NOT NULL,
	[idLord] [int] NOT NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLogout_Penya_Diff_Log]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLogout_Penya_Diff_Log](
	[serverindex] [char](2) NULL,
	[m_idPlayer] [char](7) NULL,
	[m_dwGold_old] [bigint] NULL,
	[regdate_old] [datetime] NULL,
	[m_dwGold_now] [bigint] NULL,
	[regdate_now] [datetime] NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLogout_Penya]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLogout_Penya](
	[serverindex] [char](2) NULL,
	[m_idPlayer] [char](7) NULL,
	[m_dwGold] [bigint] NULL,
	[regdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblHousing_Visit]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblHousing_Visit](
	[serverindex] [char](2) NULL,
	[m_idPlayer] [char](7) NULL,
	[f_idPlayer] [char](7) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblHousing]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblHousing](
	[serverindex] [char](2) NULL,
	[m_idPlayer] [char](7) NULL,
	[ItemIndex] [int] NULL,
	[tKeepTime] [bigint] NULL,
	[bSetup] [int] NULL,
	[x_Pos] [float] NULL,
	[y_Pos] [float] NULL,
	[z_Pos] [float] NULL,
	[fAngle] [float] NULL,
	[Start_Time] [datetime] NULL,
	[End_Time] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblGuildHouse_Furniture]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblGuildHouse_Furniture](
	[serverindex] [char](2) NOT NULL,
	[m_idGuild] [char](6) NOT NULL,
	[SEQ] [int] NOT NULL,
	[ItemIndex] [int] NULL,
	[bSetup] [int] NULL,
	[x_Pos] [float] NULL,
	[y_Pos] [float] NULL,
	[z_Pos] [float] NULL,
	[fAngle] [float] NULL,
	[tKeepTime] [int] NULL,
	[s_date] [datetime] NULL,
	[set_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'm_idGuild'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ITEM ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'ItemIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'bSetup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'fAngle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ?? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'tKeepTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N's_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_Furniture', @level2type=N'COLUMN',@level2name=N'set_date'
GO
/****** Object:  Table [dbo].[tblGuildHouse]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblGuildHouse](
	[serverindex] [char](2) NOT NULL,
	[m_idGuild] [char](6) NOT NULL,
	[dwWorldID] [int] NULL,
	[tKeepTime] [int] NOT NULL,
	[m_szGuild] [varchar](32) NULL,
 CONSTRAINT [PK_tblGuildHoues] PRIMARY KEY CLUSTERED 
(
	[serverindex] ASC,
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse', @level2type=N'COLUMN',@level2name=N'm_idGuild'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse', @level2type=N'COLUMN',@level2name=N'dwWorldID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??? ?? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse', @level2type=N'COLUMN',@level2name=N'tKeepTime'
GO
/****** Object:  Table [dbo].[tblFunnyCoin]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblFunnyCoin](
	[fcid] [int] IDENTITY(1,1) NOT NULL,
	[account] [varchar](32) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[Item_Name] [int] NOT NULL,
	[Item_Cash] [int] NOT NULL,
	[Item_UniqueNo] [bigint] NOT NULL,
	[s_date] [datetime] NOT NULL,
	[fid] [int] NOT NULL,
	[ItemFlag] [tinyint] NOT NULL,
	[f_date] [datetime] NULL,
 CONSTRAINT [PK_tblFunnyCoin] PRIMARY KEY CLUSTERED 
(
	[fcid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEvent_Board_Provide]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvent_Board_Provide](
	[account] [varchar](32) NULL,
	[regdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblElection]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblElection](
	[s_week] [char](6) NULL,
	[chrcount] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCouplePlayer_deleted]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCouplePlayer_deleted](
	[nServer] [int] NULL,
	[idPlayer] [int] NULL,
	[cid] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[chkHanguel]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[chkHanguel](@str nvarchar(1000))
returns int
as
begin
declare @i int,@j nchar(1),@ret int
set @i = 1
set @j = ''
set @ret =0

set @str = rtrim(ltrim(@str))

while @i <= len(@str)
	begin
		set @j = substring(@str,@i,1)
		
		if charindex(@j,N'!"#$%& ''()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~',1) > 0
		select @ret = @ret + 1

		set @i = @i + 1
	end


if len(@str) = @ret
set @ret = 1
else
set @ret = 0

return @ret
end
GO
/****** Object:  Table [dbo].[CHARACTER_TBL_validity_check]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHARACTER_TBL_validity_check](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NULL,
	[account] [varchar](32) NULL,
	[m_szName] [varchar](32) NULL,
	[TotalPlayTime] [bigint] NULL,
	[m_dwGold] [int] NULL,
	[m_nLevel] [int] NULL,
	[m_nJob] [int] NULL,
	[sum_ability] [int] NULL,
	[CreateTime] [datetime] NULL,
	[regdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHARACTER_TBL_penya_check]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CHARACTER_TBL_penya_check](
	[account] [varchar](32) NULL,
	[m_szName] [varchar](32) NULL,
	[m_dwGold] [int] NULL,
	[s_date] [datetime] NULL,
	[check_sec] [int] NULL,
	[serverindex] [char](2) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHARACTER_TBL_DEL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CHARACTER_TBL_DEL](
	[serverindex] [char](2) NULL,
	[m_idPlayer] [char](7) NULL,
	[m_szName] [varchar](32) NULL,
	[account] [varchar](32) NULL,
	[m_nLevel] [int] NULL,
	[m_nJob] [int] NULL,
	[CreateTime] [datetime] NULL,
	[deldate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHARACTER_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHARACTER_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[account] [varchar](32) NULL,
	[m_szName] [varchar](32) NULL,
	[playerslot] [int] NULL,
	[dwWorldID] [int] NULL,
	[m_dwIndex] [int] NULL,
	[m_vScale_x] [real] NULL,
	[m_dwMotion] [int] NULL,
	[m_vPos_x] [real] NULL,
	[m_vPos_y] [real] NULL,
	[m_vPos_z] [real] NULL,
	[m_fAngle] [real] NULL,
	[m_szCharacterKey] [varchar](32) NULL,
	[m_nHitPoint] [int] NULL,
	[m_nManaPoint] [int] NULL,
	[m_nFatiguePoint] [int] NULL,
	[m_nFuel] [int] NULL,
	[m_dwSkinSet] [int] NULL,
	[m_dwHairMesh] [int] NULL,
	[m_dwHairColor] [int] NULL,
	[m_dwHeadMesh] [int] NULL,
	[m_dwSex] [int] NULL,
	[m_dwRideItemIdx] [int] NULL,
	[m_dwGold] [int] NULL,
	[m_nJob] [int] NULL,
	[m_pActMover] [varchar](50) NULL,
	[m_nStr] [int] NULL,
	[m_nSta] [int] NULL,
	[m_nDex] [int] NULL,
	[m_nInt] [int] NULL,
	[m_nLevel] [int] NULL,
	[m_nMaximumLevel] [int] NULL,
	[m_nExp1] [bigint] NULL,
	[m_nExp2] [bigint] NULL,
	[m_aJobSkill] [varchar](500) NULL,
	[m_aLicenseSkill] [varchar](500) NULL,
	[m_aJobLv] [varchar](500) NULL,
	[m_dwExpertLv] [int] NULL,
	[m_idMarkingWorld] [int] NULL,
	[m_vMarkingPos_x] [real] NULL,
	[m_vMarkingPos_y] [real] NULL,
	[m_vMarkingPos_z] [real] NULL,
	[m_nRemainGP] [int] NULL,
	[m_nRemainLP] [int] NULL,
	[m_nFlightLv] [int] NULL,
	[m_nFxp] [int] NULL,
	[m_nTxp] [int] NULL,
	[m_lpQuestCntArray] [varchar](3072) NULL,
	[m_chAuthority] [char](1) NULL,
	[m_dwMode] [int] NULL,
	[m_idparty] [int] NULL,
	[m_idCompany] [char](6) NULL,
	[m_idMuerderer] [int] NULL,
	[m_nFame] [int] NULL,
	[m_nDeathExp] [bigint] NULL,
	[m_nDeathLevel] [int] NULL,
	[m_dwFlyTime] [int] NULL,
	[m_nMessengerState] [int] NULL,
	[blockby] [varchar](32) NULL,
	[TotalPlayTime] [int] NULL,
	[isblock] [char](1) NULL,
	[End_Time] [char](12) NULL,
	[BlockTime] [char](8) NULL,
	[CreateTime] [datetime] NULL,
	[m_tmAccFuel] [int] NULL,
	[m_tGuildMember] [char](14) NULL,
	[m_dwSkillPoint] [int] NULL,
	[m_aCompleteQuest] [varchar](1024) NULL,
	[m_dwReturnWorldID] [int] NULL,
	[m_vReturnPos_x] [real] NULL,
	[m_vReturnPos_y] [real] NULL,
	[m_vReturnPos_z] [real] NULL,
	[MultiServer] [int] NOT NULL,
	[m_SkillPoint] [int] NULL,
	[m_SkillLv] [int] NULL,
	[m_SkillExp] [bigint] NULL,
	[dwEventFlag] [bigint] NULL,
	[dwEventTime] [int] NOT NULL,
	[dwEventElapsed] [int] NOT NULL,
	[PKValue] [int] NOT NULL,
	[PKPropensity] [int] NOT NULL,
	[PKExp] [int] NOT NULL,
	[AngelExp] [bigint] NULL,
	[AngelLevel] [int] NOT NULL,
	[FinalLevelDt] [smalldatetime] NOT NULL,
	[m_dwPetId] [int] NULL,
	[m_nExpLog] [int] NULL,
	[m_nAngelExpLog] [int] NULL,
	[m_nCoupon] [int] NOT NULL,
	[m_nHonor] [int] NULL,
	[m_nLayer] [int] NULL,
	[m_nCampusPoint] [int] NOT NULL,
	[idCampus] [int] NOT NULL,
	[m_aCheckedQuest] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ?? ???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CHARACTER_TBL', @level2type=N'COLUMN',@level2name=N'm_nCampusPoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CHARACTER_TBL', @level2type=N'COLUMN',@level2name=N'idCampus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??? ???? ??? ??? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CHARACTER_TBL', @level2type=N'COLUMN',@level2name=N'm_aCheckedQuest'
GO
/****** Object:  UserDefinedFunction [dbo].[ChangeTime]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     FUNCTION [dbo].[ChangeTime] (
    @iTime   VARCHAR(14) )

RETURNS VARCHAR(50) 
AS  
BEGIN 
    DECLARE @ret  VARCHAR(30)
    DECLARE @ret1 VARCHAR(4)
    DECLARE @ret2 VARCHAR(2)
    DECLARE @ret3 VARCHAR(2)
    DECLARE @ret4 VARCHAR(2)
    DECLARE @ret5 VARCHAR(2)


    SET @ret  = ''
    SET @ret1 = ''
    SET @ret2 = ''
    SET @ret3 = ''
    SET @ret4 = ''
    SET @ret5 = ''

  
    BEGIN
        SELECT @ret1  = left(@iTime, 4)
        SELECT @ret2  = substring(@iTime, 5, 2)
        SELECT @ret3  = substring(@iTime, 7, 2)
        SELECT @ret4  = substring(@iTime, 9, 2)
        SELECT @ret5  = substring(@iTime, 11, 2)

    END

    SELECT @ret = @ret1 + '-' + @ret2 + '-' + @ret3 + ' ' + @ret4 + ':' + @ret5

    RETURN @ret

END
GO
/****** Object:  Table [dbo].[CARD_CUBE_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CARD_CUBE_TBL](
	[m_idPlayer] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_Card] [varchar](1980) NULL,
	[m_Cube] [varchar](1980) NULL,
	[m_apIndex_Card] [varchar](215) NULL,
	[m_dwObjIndex_Card] [varchar](215) NULL,
	[m_apIndex_Cube] [varchar](215) NULL,
	[m_dwObjIndex_Cube] [varchar](215) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BILING_ITEM_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BILING_ITEM_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_dwSMTime] [varchar](2560) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
RAISERROR( 'Step 9: Configure [BASE_VALUE_TBL]',0,1) WITH NOWAIT
GO
/****** Object:  Table [dbo].[BASE_VALUE_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BASE_VALUE_TBL](
	[g_nSex] [char](1) NULL,
	[m_vScale_x] [real] NULL,
	[m_dwMotion] [int] NULL,
	[m_fAngle] [real] NULL,
	[m_nHitPoint] [int] NULL,
	[m_nManaPoint] [int] NULL,
	[m_nFatiguePoint] [int] NULL,
	[m_dwRideItemIdx] [int] NULL,
	[m_dwGold] [int] NULL,
	[m_nJob] [int] NULL,
	[m_pActMover] [varchar](50) NULL,
	[m_nStr] [int] NULL,
	[m_nSta] [int] NULL,
	[m_nDex] [int] NULL,
	[m_nInt] [int] NULL,
	[m_nLevel] [int] NULL,
	[m_nExp1] [bigint] NULL,
	[m_nExp2] [bigint] NULL,
	[m_aJobSkill] [varchar](500) NULL,
	[m_aLicenseSkill] [varchar](500) NULL,
	[m_aJobLv] [varchar](500) NULL,
	[m_dwExpertLv] [int] NULL,
	[m_idMarkingWorld] [int] NULL,
	[m_vMarkingPos_x] [real] NULL,
	[m_vMarkingPos_y] [real] NULL,
	[m_vMarkingPos_z] [real] NULL,
	[m_nRemainGP] [int] NULL,
	[m_nRemainLP] [int] NULL,
	[m_nFlightLv] [int] NULL,
	[m_nFxp] [int] NULL,
	[m_nTxp] [int] NULL,
	[m_lpQuestCntArray] [varchar](1024) NULL,
	[m_chAuthority] [char](1) NULL,
	[m_dwMode] [int] NULL,
	[blockby] [varchar](32) NULL,
	[TotalPlayTime] [int] NULL,
	[isblock] [char](1) NULL,
	[m_Inventory] [varchar](max) NULL,
	[m_apIndex] [varchar](2500) NULL,
	[m_adwEquipment] [varchar](135) NULL,
	[m_aSlotApplet] [varchar](3100) NULL,
	[m_aSlotItem] [varchar](6885) NULL,
	[m_aSlotQueue] [varchar](225) NULL,
	[m_SkillBar] [smallint] NULL,
	[m_dwObjIndex] [varchar](2500) NULL,
	[m_Card] [varchar](1980) NULL,
	[m_Cube] [varchar](1980) NULL,
	[m_apIndex_Card] [varchar](215) NULL,
	[m_dwObjIndex_Card] [varchar](215) NULL,
	[m_apIndex_Cube] [varchar](215) NULL,
	[m_dwObjIndex_Cube] [varchar](215) NULL,
	[m_idparty] [int] NULL,
	[m_nNumKill] [int] NULL,
	[m_idMuerderer] [int] NULL,
	[m_nSlaughter] [int] NULL,
	[m_nFame] [int] NULL,
	[m_nDeathExp] [int] NULL,
	[m_nDeathLevel] [int] NULL,
	[m_dwFlyTime] [int] NULL,
	[m_nMessengerState] [int] NULL,
	[m_Bank] [varchar](4290) NULL,
	[m_apIndex_Bank] [varchar](215) NULL,
	[m_dwObjIndex_Bank] [varchar](215) NULL,
	[m_dwGoldBank] [int] NULL
) ON [PRIMARY]
GO

INSERT [dbo].[BASE_VALUE_TBL] ([g_nSex], [m_vScale_x], [m_dwMotion], [m_fAngle], [m_nHitPoint], [m_nManaPoint], [m_nFatiguePoint], [m_dwRideItemIdx], [m_dwGold], [m_nJob], [m_pActMover], [m_nStr], [m_nSta], [m_nDex], [m_nInt], [m_nLevel], [m_nExp1], [m_nExp2], [m_aJobSkill], [m_aLicenseSkill], [m_aJobLv], [m_dwExpertLv], [m_idMarkingWorld], [m_vMarkingPos_x], [m_vMarkingPos_y], [m_vMarkingPos_z], [m_nRemainGP], [m_nRemainLP], [m_nFlightLv], [m_nFxp], [m_nTxp], [m_lpQuestCntArray], [m_chAuthority], [m_dwMode], [blockby], [TotalPlayTime], [isblock], [m_Inventory], [m_apIndex], [m_adwEquipment], [m_aSlotApplet], [m_aSlotItem], [m_aSlotQueue], [m_SkillBar], [m_dwObjIndex], [m_Card], [m_Cube], [m_apIndex_Card], [m_dwObjIndex_Card], [m_apIndex_Cube], [m_dwObjIndex_Cube], [m_idparty], [m_nNumKill], [m_idMuerderer], [m_nSlaughter], [m_nFame], [m_nDeathExp], [m_nDeathLevel], [m_dwFlyTime], [m_nMessengerState], [m_Bank], [m_apIndex_Bank], [m_dwObjIndex_Bank], [m_dwGoldBank]) VALUES (N'0', 1, 0, 0, 230, 63, 32, 0, 0, 0, N'0,0', 15, 15, 15, 15, 1, 0, 0, N'0,1,1,1/0,1,2,1/0,1,3,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/$', N'0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/$', N'1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/$', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'$', N'F', 268566528, NULL, 0, N'F', N'0,502,0,0,,1,0,9000000,0,0,0,0,0/1,2801,0,0,,1,0,0,0,0,0,0,0/2,4805,0,0,,5,0,0,0,0,0,0,0/42,506,0,0,,1,0,5850000,0,0,0,0,0/43,510,0,0,,1,0,4500000,0,0,0,0,0/44,21,0,0,,1,0,7200000,0,0,0,0,0/45,2800,0,0,,3,0,0,0,0,0,0,0/$', N'45/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/-1/-1/0/-1/42/43/-1/-1/-1/-1/44/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$', N'-1/-1/0/-1/42/43/-1/-1/-1/-1/44/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$', N'2,2,2010,0,2,0,0/3,2,581,0,3,0,0/4,3,25,0,4,0,0/$', N'0,0,5,45,0,0,0,1/0,1,5,1,0,1,0,1/0,2,3,3,0,2,0,1/0,8,3,2,0,8,0,1/$', N'$', 0, N'44/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/46/47/52/0/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$', N'$', N'$', N'5/36/37/38/39/40/41/$', N'0/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/$', N'0/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/$', N'0/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/$', 0, 0, 0, 0, 0, 0, 0, 0, 0, N'$', N'$', N'$', 0)
INSERT [dbo].[BASE_VALUE_TBL] ([g_nSex], [m_vScale_x], [m_dwMotion], [m_fAngle], [m_nHitPoint], [m_nManaPoint], [m_nFatiguePoint], [m_dwRideItemIdx], [m_dwGold], [m_nJob], [m_pActMover], [m_nStr], [m_nSta], [m_nDex], [m_nInt], [m_nLevel], [m_nExp1], [m_nExp2], [m_aJobSkill], [m_aLicenseSkill], [m_aJobLv], [m_dwExpertLv], [m_idMarkingWorld], [m_vMarkingPos_x], [m_vMarkingPos_y], [m_vMarkingPos_z], [m_nRemainGP], [m_nRemainLP], [m_nFlightLv], [m_nFxp], [m_nTxp], [m_lpQuestCntArray], [m_chAuthority], [m_dwMode], [blockby], [TotalPlayTime], [isblock], [m_Inventory], [m_apIndex], [m_adwEquipment], [m_aSlotApplet], [m_aSlotItem], [m_aSlotQueue], [m_SkillBar], [m_dwObjIndex], [m_Card], [m_Cube], [m_apIndex_Card], [m_dwObjIndex_Card], [m_apIndex_Cube], [m_dwObjIndex_Cube], [m_idparty], [m_nNumKill], [m_idMuerderer], [m_nSlaughter], [m_nFame], [m_nDeathExp], [m_nDeathLevel], [m_dwFlyTime], [m_nMessengerState], [m_Bank], [m_apIndex_Bank], [m_dwObjIndex_Bank], [m_dwGoldBank]) VALUES (N'1', 1, 0, 0, 230, 63, 32, 0, 0, 0, N'0,0', 15, 15, 15, 15, 1, 0, 0, N'0,1,1,1/0,1,2,1/0,1,3,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/$', N'0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/0,0,0,1/$', N'1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/1/$', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'$', N'F', 268566528, NULL, 0, N'F', N'0,504,0,0,,1,0,9000000,0,0,0,0,0/1,2801,0,0,,1,0,0,0,0,0,0,0/2,4805,0,0,,5,0,0,0,0,0,0,0/42,508,0,0,,1,0,5850000,0,0,0,0,0/43,512,0,0,,1,0,4500000,0,0,0,0,0/44,21,0,0,,1,0,7200000,0,0,0,0,0/45,2800,0,0,,3,0,0,0,0,0,0,0/$', N'45/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/-1/-1/0/-1/42/43/-1/-1/-1/-1/44/-1/-1/-1/$', N'-1/-1/0/-1/42/43/-1/-1/-1/-1/44/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$', N'2,2,2010,0,2,0,0/3,2,581,0,3,0,0/4,3,25,0,4,0,0/$', N'0,0,5,45,0,0,0,1/0,1,5,1,0,1,0,1/0,2,3,3,0,2,0,1/0,8,3,2,0,8,0,1/$', N'$', 0, N'44/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/46/47/52/0/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$', N'$', N'$', N'5/36/37/38/39/40/41/$', N'0/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/$', N'0/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/$', N'0/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/$', 0, 0, 0, 0, 0, 0, 0, 0, 0, N'$', N'$', N'$', 0)

SET ANSI_PADDING OFF
GO
USE CHARACTER_01_DBF
GO
UPDATE BASE_VALUE_TBL SET m_Inventory = '0,2800,0,0,,3,0,-1,0,0,0,-322033766,0,0,0,0,0,0/1,2801,0,0,,1,0,-1,0,0,0,-1981991882,0,0,0,0,0,0/2,4805,0,0,,5,0,-1,0,0,0,1215878883,0,0,0,0,0,0/6,502,0,0,,1,0,9000000,0,0,0,-818549536,0,0,0,0,0,-1/169,510,0,0,,1,0,4500000,0,0,0,505042330,0,0,0,0,0,-1/172,21,0,0,,1,0,7200000,0,0,0,-1944939863,0,0,0,0,0,-1/173,506,0,0,,1,0,5850000,0,0,0,-1119756572,0,0,0,0,0,-1/$' WHERE g_nSex = '0'
UPDATE BASE_VALUE_TBL SET m_apIndex = '0/1/2/174/170/171/3/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/42/43/44/45/46/47/48/49/50/51/52/53/54/55/56/57/58/59/60/61/62/63/64/65/66/67/68/69/70/71/72/73/74/75/76/77/78/79/80/81/82/83/84/85/86/87/88/89/90/91/92/93/94/95/96/97/98/99/100/101/102/103/104/105/106/107/108/109/110/111/112/113/114/115/116/117/118/119/120/121/122/123/124/125/126/127/128/129/130/131/132/133/134/135/136/137/138/139/140/141/142/143/144/145/146/147/148/149/150/151/152/153/154/155/156/157/158/159/160/161/162/163/164/165/166/167/-1/-1/6/-1/173/169/-1/-1/-1/-1/172/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$' WHERE g_nSex = '0'
UPDATE BASE_VALUE_TBL SET m_dwObjIndex = '0/1/2/6/173/178/170/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/42/43/44/45/46/47/48/49/50/51/52/53/54/55/56/57/58/59/60/61/62/63/64/65/66/67/68/69/70/71/72/73/74/75/76/77/78/79/80/81/82/83/84/85/86/87/88/89/90/91/92/93/94/95/96/97/98/99/100/101/102/103/104/105/106/107/108/109/110/111/112/113/114/115/116/117/118/119/120/121/122/123/124/125/126/127/128/129/130/131/132/133/134/135/136/137/138/139/140/141/142/143/144/145/146/147/148/149/150/151/152/153/154/155/156/157/158/159/160/161/162/163/164/165/166/167/170/173/4/5/178/172/3/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$' WHERE g_nSex = '0'
UPDATE BASE_VALUE_TBL SET m_adwEquipment = '0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/$' WHERE g_nSex = '0'
GO
UPDATE BASE_VALUE_TBL SET m_Inventory = '0,2800,0,0,,3,0,-1,0,0,0,-45364226,0,0,0,0,0,0/1,2801,0,0,,1,0,-1,0,0,0,38338230,0,0,0,0,0,0/2,4805,0,0,,5,0,-1,0,0,0,-1372191970,0,0,0,0,0,0/3,21,0,0,,1,0,7200000,0,0,0,-1665507005,0,0,0,0,0,-1/170,508,0,0,,1,0,5850000,0,0,0,-385612173,0,0,0,0,0,-1/171,504,0,0,,1,0,9000000,0,0,0,903262398,0,0,0,0,0,-1/173,512,0,0,,1,0,4500000,0,0,0,955505939,0,0,0,0,0,-1/$' WHERE g_nSex = '1'
UPDATE BASE_VALUE_TBL SET m_apIndex = '0/1/2/174/169/172/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/42/43/44/45/46/47/48/49/50/51/52/53/54/55/56/57/58/59/60/61/62/63/64/65/66/67/68/69/70/71/72/73/74/75/76/77/78/79/80/81/82/83/84/85/86/87/88/89/90/91/92/93/94/95/96/97/98/99/100/101/102/103/104/105/106/107/108/109/110/111/112/113/114/115/116/117/118/119/120/121/122/123/124/125/126/127/128/129/130/131/132/133/134/135/136/137/138/139/140/141/142/143/144/145/146/147/148/149/150/151/152/153/154/155/156/157/158/159/160/161/162/163/164/165/166/167/-1/-1/171/-1/170/173/-1/-1/-1/-1/3/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$' WHERE g_nSex = '1'
UPDATE BASE_VALUE_TBL SET m_dwObjIndex = '0/1/2/178/173/178/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/41/42/43/44/45/46/47/48/49/50/51/52/53/54/55/56/57/58/59/60/61/62/63/64/65/66/67/68/69/70/71/72/73/74/75/76/77/78/79/80/81/82/83/84/85/86/87/88/89/90/91/92/93/94/95/96/97/98/99/100/101/102/103/104/105/106/107/108/109/110/111/112/113/114/115/116/117/118/119/120/121/122/123/124/125/126/127/128/129/130/131/132/133/134/135/136/137/138/139/140/141/142/143/144/145/146/147/148/149/150/151/152/153/154/155/156/157/158/159/160/161/162/163/164/165/166/167/170/4/172/170/5/173/3/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/-1/$' WHERE g_nSex = '1'
UPDATE BASE_VALUE_TBL SET m_adwEquipment = '0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/0/$' WHERE g_nSex = '1'
GO
/****** Object:  Table [dbo].[BANK_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANK_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_BankPw] [char](4) NOT NULL,
	[m_Bank] [varchar](4290) NOT NULL,
	[m_apIndex_Bank] [varchar](215) NOT NULL,
	[m_dwObjIndex_Bank] [varchar](215) NOT NULL,
	[m_dwGoldBank] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_AccountPlay_Update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_AccountPlay_Update]
	@i_Account varchar(32)
	, @i_PlayDate int
	, @i_PlayTime int
as

set nocount on
set transaction isolation level read uncommitted

update ACCOUNT_DBF.dbo.AccountPlay set
	PlayDate = @i_PlayDate
	, PlayTime = @i_PlayTime
where Account = @i_Account
GO
/****** Object:  StoredProcedure [dbo].[USP_AccountPlay_Select]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_AccountPlay_Select]
@i_Account varchar(32)
as
set nocount on
set transaction isolation level read uncommitted

select PlayDate
	, PlayTime
from ACCOUNT_DBF.dbo.AccountPlay
where Account = @i_Account
GO
/****** Object:  Table [dbo].[BANK_EXT_TBL]    Script Date: 04/03/2010 12:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BANK_EXT_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_extBank] [varchar](1296) NULL,
	[m_BankPiercing] [varchar](8000) NULL,
	[szBankPet] [varchar](4200) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[BACKSYSTEM_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BACKSYSTEM_STR]
@iGu		CHAR(2) 	= 'S1',
@iIndex		INT		= 0
AS
set nocount on
IF @iGu = 'G1'  -- Base GameSetting
	BEGIN
		select * from Base_GameSetteing
		RETURN
	END
ELSE
IF @iGu = 'G2' -- QUEST_TBL Data Insert
	BEGIN
		RETURN
	END

set nocount off
GO
/****** Object:  Table [dbo].[armor]    Script Date: 04/03/2010 12:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[armor](
	[armor] [int] NULL,
	[rid] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMPANY_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPANY_TBL](
	[m_idCompany] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_szCompany] [varchar](16) NULL,
	[m_leaderid] [char](6) NULL,
	[isuse] [char](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_MEMBER_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_MEMBER_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_idGuild] [char](6) NOT NULL,
	[m_szAlias] [varchar](20) NULL,
	[m_nWin] [int] NULL,
	[m_nLose] [int] NULL,
	[m_nSurrender] [int] NULL,
	[m_nMemberLv] [int] NULL,
	[m_nGiveGold] [bigint] NULL,
	[m_nGivePxp] [int] NULL,
	[m_idWar] [int] NULL,
	[m_idVote] [int] NULL,
	[isuse] [char](1) NULL,
	[CreateTime] [datetime] NULL,
	[m_nClass] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_COMBAT_1TO1_TENDER_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_COMBAT_1TO1_TENDER_TBL](
	[serverindex] [char](2) NOT NULL,
	[combatID] [int] NOT NULL,
	[m_idGuild] [char](6) NOT NULL,
	[m_nPenya] [int] NOT NULL,
	[s_date] [datetime] NOT NULL,
	[State] [char](1) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL](
	[serverindex] [char](2) NOT NULL,
	[combatID] [int] NOT NULL,
	[m_idWorld] [int] NOT NULL,
	[Start_Time] [datetime] NOT NULL,
	[End_Time] [datetime] NULL,
	[m_idGuild_1st] [char](6) NOT NULL,
	[m_idGuild_2nd] [char](6) NOT NULL,
	[State] [char](1) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL](
	[serverindex] [char](2) NOT NULL,
	[combatID] [int] NOT NULL,
	[m_idGuild] [char](6) NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[m_nSeq] [int] NULL,
	[Start_Time] [datetime] NULL,
	[End_Time] [datetime] NULL,
	[State] [char](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_BANK_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_BANK_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_apIndex] [varchar](215) NULL,
	[m_dwObjIndex] [varchar](215) NULL,
	[m_GuildBank] [text] NULL,
 CONSTRAINT [PK_GUILD_BANK_idGuild] PRIMARY KEY CLUSTERED 
(
	[serverindex] ASC,
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_BANK_EXT_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_BANK_EXT_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_extGuildBank] [varchar](1296) NULL,
	[m_GuildBankPiercing] [varchar](8000) NULL,
	[szGuildBankPet] [varchar](4200) NULL,
 CONSTRAINT [PK_GUILD_BANK_EXT_idGuild] PRIMARY KEY CLUSTERED 
(
	[serverindex] ASC,
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[getQuest]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[getQuest](@str1 varchar(8000))
returns int
as
begin


declare @return int
declare @tmp table (no int null)

--declare @str1 varchar(8000)
declare @str2 varchar(8000)
--set @str1 = '22, 14, 0/20, 14, 0/21, 14, 0/100, 14, 0/19, 0, 0/107, 0, 0/4, 14, 0/2009, 0, 0/$'
declare @str1_s int,@str1_e int
declare @str2_s int,@str2_e int
declare @i int

set @str1_s = 1
while 1=1
begin
set @str1_e = charindex('/',@str1 ,@str1_s)
if @str1_e < 1 
break

set @str2 = SUBSTRING(@str1,@str1_s,@str1_e-@str1_s)

set @str2_s = 1
set @i = 1
	while 1=1
		begin
		set @str2_e = charindex(',',@str2 ,@str2_s)
		if @str2_e < 1 
		break
		
		if @i = 1
		begin
		insert @tmp
		(no)
		select SUBSTRING(@str2,@str2_s,@str2_e-@str2_s)
		end
		set @str2_s = @str2_e + 1
		set @i = @i + 1
		end



set @str1_s = @str1_e + 1
end

if exists(select * from @tmp where no between 100 and 200)
select @return = 1
else
select @return = 0

return @return

end
GO
/****** Object:  StoredProcedure [dbo].[GET_INSERT_SCRIPT_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GET_INSERT_SCRIPT_STR]
@tbl_name VARCHAR(128) 
AS
/*

     email : beatchoi@yahoo.co.kr
     Program : Sukjoon Choi
     Date : 2005.4.29
*/


-- DECLARE @tbl_name VARCHAR(128)
-- 
-- SET @tbl_name = 'sysfiles'

DECLARE @column VARCHAR(8000)
DECLARE @value VARCHAR(8000)

DECLARE @columnsStr VARCHAR(8000)
DECLARE @valuesStr VARCHAR(8000)

SET @column = ''
SET @value = ''
SET @columnsStr = ''
SET @valuesStr = ''

DECLARE TBL_Column_Cursor CURSOR 
FOR 
SELECT 
[column] = QUOTENAME(a.name) + ',',
[value] = CASE  WHEN b.xprec = 23 
                        THEN   ''''''' + CONVERT(VARCHAR,(ISNULL('+ a.name + ',''''))) + '''''
                        WHEN b.xprec = 0 
                        THEN   ''''''' + ISNULL('+ a.name + ','''') + '''''  
                        ELSE  ''' + CONVERT(VARCHAR,(ISNULL('+ a.name + ',''''))) + ' 
              END +''','
FROM syscolumns a,systypes b 
WHERE a.id = object_id( @tbl_name) 
AND a.xtype = b.xtype
ORDER BY  a.colid

OPEN TBL_Column_Cursor

FETCH NEXT FROM TBL_Column_Cursor 
INTO @column,@value

WHILE @@FETCH_STATUS = 0
BEGIN
SET	@columnsStr = @columnsStr + @column
SET	@valuesStr = @valuesStr + @value  

FETCH NEXT FROM TBL_Column_Cursor 
INTO   @column,@value
END

SET @columnsStr = LEFT(@columnsStr,LEN(@columnsStr) -1)
SET @valuesStr = LEFT(@valuesStr,LEN(@valuesStr) -1)

CLOSE TBL_Column_Cursor
DEALLOCATE TBL_Column_Cursor

EXEC('SELECT ''INSERT INTO '  + @tbl_name + ' ('  + @columnsStr + '''' +' + '') VALUES (' + @valuesStr + ')'' 
           FROM  ' +  @tbl_name)

RETURN
GO
/****** Object:  UserDefinedFunction [dbo].[fnTimeFormat]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION [dbo].[fnTimeFormat] (
    @iTime   INT,
    @iFormat INT
)  
RETURNS VARCHAR(50) 
AS  
BEGIN 
    DECLARE @ret  VARCHAR(50)
    DECLARE @ret1 VARCHAR(50)
    DECLARE @ret2 VARCHAR(50)
    DECLARE @ret3 VARCHAR(50)
    DECLARE @ret4 VARCHAR(50)

    SET @ret  = ''
    SET @ret1 = ''
    SET @ret2 = ''
    SET @ret3 = ''
    SET @ret4 = ''
  
    IF @iTime > 60*60*24   
    BEGIN
        SELECT @ret1  = CAST(FLOOR((@iTime)/(60*60*24)) AS VARCHAR) + '? '
        SELECT @iTime = @iTime - FLOOR(@iTime/(60*60*24))*60*60*24
    END

    IF @iTime > 60*60
    BEGIN
        SELECT @ret2  = CAST(FLOOR((@iTime)/(60*60)) AS VARCHAR) + '?? '
        SELECT @iTime = @iTime - FLOOR(@iTime/(60*60))*60*60
    END

    IF @iTime > 60
    BEGIN
        SELECT @ret3  = CAST(FLOOR((@iTime)/(60)) AS VARCHAR) + '? '
        SELECT @iTime = @iTime - FLOOR(@iTime/(60))*60
    END

    IF @iTime <> 0
    BEGIN
        SELECT @ret4  = CAST(@iTime AS VARCHAR) + '?'
    END
  
    SELECT @ret = @ret1 + @ret2 + @ret3 + @ret4

    RETURN @ret

END
GO
/****** Object:  UserDefinedFunction [dbo].[fnDateFormat]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    FUNCTION [dbo].[fnDateFormat] (
    @iDate   VARCHAR(14),
    @iFormat INT
)  
RETURNS VARCHAR(50) 
AS  
BEGIN 
  RETURN
  CASE 
    WHEN @iFormat = 0 THEN        -- YYYY? MM? DD? HH? MM? SS?
                SUBSTRING(@iDate,  1, 4) + '? ' + 
                SUBSTRING(@iDate,  5, 2) + '? ' + 
                SUBSTRING(@iDate,  7, 2) + '? ' + 
                SUBSTRING(@iDate,  9, 2) + '? ' + 
                SUBSTRING(@iDate, 11, 2) + '? ' + 
                SUBSTRING(@iDate, 13, 2) + '?'
    WHEN @iFormat = 1 THEN         -- YY/MM/DD HH:MM:SS
                SUBSTRING(@iDate,  3, 2) + '/' + 
                SUBSTRING(@iDate,  5, 2) + '/' + 
                SUBSTRING(@iDate,  7, 2) + ' ' + 
                SUBSTRING(@iDate,  9, 2) + ':' + 
                SUBSTRING(@iDate, 11, 2) + ':' + 
                SUBSTRING(@iDate, 13, 2)
    WHEN @iFormat = 2 THEN         -- YY/MM/DD HH?
                SUBSTRING(@iDate,  3, 2) + '/' + 
                SUBSTRING(@iDate,  5, 2) + '/' + 
                SUBSTRING(@iDate,  7, 2) + ' ' + 
                SUBSTRING(@iDate,  9, 2) + '?'
    WHEN @iFormat = 3 THEN         -- YY/MM/DD
                SUBSTRING(@iDate,  3, 2) + '/' + 
                SUBSTRING(@iDate,  5, 2) + '/' + 
                SUBSTRING(@iDate,  7, 2)
    WHEN @iFormat = 4 THEN         -- MM/DD HH:MM:SS
                SUBSTRING(@iDate,  5, 2) + '/' + 
                SUBSTRING(@iDate,  7, 2) + ' ' + 
                SUBSTRING(@iDate,  9, 2) + ':' + 
                SUBSTRING(@iDate, 11, 2) + ':' + 
                SUBSTRING(@iDate, 13, 2)
    WHEN @iFormat = 5 THEN         -- MM/DD HH:MM:SS
                SUBSTRING(@iDate,  1, 4) + '/' + 
                SUBSTRING(@iDate,  5, 2) + '/' + 
                SUBSTRING(@iDate,  7, 2) + ' ' + 
                SUBSTRING(@iDate,  9, 2) + ':' + 
                SUBSTRING(@iDate, 11, 2) 
    ELSE     'Not Define iFormat'
  END
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_job]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_job](@m_nJob int)
returns varchar(50)
as
begin
return
	case when @m_nJob = 0 then 'Vagarant'
		when @m_nJob = 1 then 'Mecenary'
		when @m_nJob = 2 then 'Acrobat'
		when @m_nJob = 3 then 'Assist'
		when @m_nJob = 4 then 'Magician'
		when @m_nJob = 6 then 'Knight'
		when @m_nJob = 7 then 'Blade'
		when @m_nJob = 8 then 'Jester'
		when @m_nJob = 9 then 'Ranger'
		when @m_nJob = 10 then 'Ringmaster'
		when @m_nJob = 11 then 'Billposter'
		when @m_nJob = 12 then 'Psykeeper'
		when @m_nJob = 13 then 'Elementer'
		when @m_nJob = 16 then 'Master Knight'
		when @m_nJob = 17 then 'Master Blade'
		when @m_nJob = 18 then 'Master Jester'
		when @m_nJob = 19 then 'Master Ranger'
		when @m_nJob = 20 then 'Master Ringmaster'
		when @m_nJob = 21 then 'Master Billposter'
		when @m_nJob = 22 then 'Master Psykeeper'
		when @m_nJob = 23 then 'Master Elementer'
		when @m_nJob = 24 then 'Hero Knight'
		when @m_nJob = 25 then 'Hero Blade'
		when @m_nJob = 26 then 'Hero Jester'
		when @m_nJob = 27 then 'Hero Ranger'
		when @m_nJob = 28 then 'Hero Ringmaster'
		when @m_nJob = 29 then 'Hero Billposter'
		when @m_nJob = 30 then 'Hero Psykeeper'
		when @m_nJob = 31 then 'Hero Elementer'
		else 'Not Define' end
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ItemResist]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_ItemResist] (@iResist int)  
returns varchar(50)
as
begin  
/*********************************************************************************
m_bItemResist : ?? (?> ?, ?, ??, ? )	??
>  // * ?? ??. : 0	?(?)
>  // * ?   ?? : 1	?(?)
>  // * ?   ?? : 2	?(?)
>  // * ?? ?? : 3	??(?)
>  // * ?? ?? : 4	??(?)
>  // * ?   ?? : 5	?(?)
**********************************************************************************/
declare @ret varchar(50)

if @iResist is null
	set @ret = ''
else
	select @ret =  case @iResist
			when 0 then '?(?)'
			when 1 then '?(?)'
			when 2 then '?(?)'
			when 3 then '??(?)'
			when 4 then '??(?)'
			when 5 then '?(?)'
			else convert(varchar(50), @iResist)
			end
return @ret
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_item2row]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_item2row]
(@m_idPlayer char(7),@serverindex char(2),@arr_item varchar(6000))
returns @item_row table (m_idPlayer char(7),serverindex char(2),m_dwObjId int,m_dwItemId int, m_nItemNum int, m_nUniqueNo bigint, m_nAbilityOption int, ItemResist int, ResistAbilityOpt int)
as
begin

declare @item varchar(255),@item_property varchar(50)
declare @pos_s int,@pos_e int
declare @pos_sub_s int,@pos_sub_e int

declare @m_dwobjid varchar(11)
declare @m_dwitemid varchar(11)
declare @m_nitemnum varchar(11)
declare @m_nUniqueNo varchar(11)
declare @m_nabilityoption varchar(11)
--------------------------------------------------
/*	????	Start				*/
--------------------------------------------------
declare @ItemResist varchar(11)
declare @ResistAbilityOpt varchar(11)
--------------------------------------------------
/*	????	End				*/
--------------------------------------------------

declare @idx int

set @pos_e = 1
while 1=1
begin
set @pos_s = charindex('/',@arr_item,@pos_e)

if @pos_s = 0
break
  set @item = substring(@arr_item,@pos_e,@pos_s-@pos_e)
  set @pos_sub_e = 1
  set @idx = 1
  while @idx <= 15  --   <- 13?? 15? ??
     begin
       set @pos_sub_s = charindex(',',@item,@pos_sub_e)
       if @pos_sub_s = 0
       break
       set @item_property = substring(@item,@pos_sub_e,@pos_sub_s-@pos_sub_e)

	   if @idx = 1
          set @m_dwobjid = @item_property
       if @idx = 2
          set @m_dwitemid = @item_property
       if @idx = 6
          set @m_nitemnum = @item_property
       if @idx=12
	set @m_nUniqueNo=@item_property
       if @idx = 13
          set @m_nabilityoption = @item_property
--------------------------------------------------
/*	????	Start				*/
--------------------------------------------------
       if @idx = 14
	set @ItemResist = @item_property
       if @idx = 15
	set @ResistAbilityOpt = @item_property
--------------------------------------------------
/*	????	End				*/
--------------------------------------------------

       set @idx = @idx + 1
       set @pos_sub_e = @pos_sub_s + 1 

     end
     if not exists(select * from @item_row where m_dwObjId = @m_dwobjid) and @m_dwobjid is not null and @m_dwitemid is not null
     insert @item_row
     values
     (@m_idPlayer,@serverindex,@m_dwobjid,@m_dwitemid,@m_nitemnum,@m_nUniqueNo, @m_nabilityoption, @ItemResist, @ResistAbilityOpt)

set @pos_e = @pos_s + 1 
end
return 
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_HI_Kind]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fn_HI_Kind]
(
    @hkind int
)
RETURNS VARCHAR(50)
AS
BEGIN

	DECLARE @ret VARCHAR(50)

	IF @hkind IS NULL
		SET @ret = ''
	ELSE
		SELECT @ret =  CASE @hkind
			WHEN 0 THEN '??? ??'	-- HS_COLLECT
			WHEN 1 THEN '??? ??'	-- HS_TRADE
			WHEN 2 THEN '? ??? ??'	-- HS_HATCHING_EGG
			WHEN 3 THEN '????'		-- HS_COUPLE_COUNT
			WHEN 4 THEN '??? ??'	-- HS_COUPLE_LV
			WHEN 5 THEN '??????'	-- HS_PK_COUNT
			WHEN 6 THEN '?? ??'		-- HS_STR
			WHEN 7 THEN '??? ??'	-- HS_STA
			WHEN 8 THEN '??? ??'	-- HS_DEX
			WHEN 9 THEN '??? ??'	-- HS_INT
			WHEN 10 THEN '?? ???'	-- HS_PVP_POINT01
			WHEN 11 THEN '?? ???'	-- HS_PVP_POINT02
			WHEN 12 THEN '???? ???'	-- HS_PVP_POINT03
			WHEN 13 THEN '???? ???'	-- HS_PVP_POINT04
			WHEN 14 THEN '??? ???'	-- HS_PVP_POINT05
			WHEN 15 THEN '?? ???'	-- HS_PVP_POINT06
			WHEN 16 THEN '??? ???'	-- HS_PVP_POINT07
			WHEN 17 THEN '??? ???'	-- HS_PVP_POINT08
			WHEN 18 THEN '???? ???'	-- HS_PVP_POINT09
			WHEN 19 THEN '??? ???'	-- HS_PVP_POINT10
			WHEN 20 THEN '??? ???'	-- JOB_KNIGHT_MASTER
			WHEN 21 THEN '???? ???'	-- JOB_BLADE_MASTER
			WHEN 22 THEN '??? ???'	-- JOB_JESTER_MASTER
			WHEN 23 THEN '??? ???'	-- JOB_RANGER_MASTER
			WHEN 24 THEN '???? ???'	-- JOB_RINGMASTER_MASTER
			WHEN 25 THEN '???? ???'	-- JOB_BILLPOSTER_MASTER
			WHEN 26 THEN '???? ???'	-- JOB_PSYCHIKEEPER_MASTER
			WHEN 27 THEN '???? ???'	-- JOB_ELEMENTOR_MASTER
			WHEN 28 THEN '??? ???'	-- JOB_KNIGHT_HERO
			WHEN 29 THEN '???? ???'	-- JOB_BLADE_HERO
			WHEN 30 THEN '??? ???'	-- JOB_JESTER_HERO
			WHEN 31 THEN '??? ???'	-- JOB_RANGER_HERO
			WHEN 32 THEN '???? ???'	-- JOB_RINGMASTER_HERO
			WHEN 33 THEN '???? ???'	-- JOB_BILLPOSTER_HERO
			WHEN 34 THEN '???? ???'	-- JOB_PSYCHIKEEPER_HERO
			WHEN 35 THEN '???? ???'	-- JOB_ELEMENTOR_HERO
			WHEN 36 THEN '??'		-- HS_LORD
			WHEN 37 THEN '?????'	-- HS_JUMP
			WHEN 38 THEN '?? ?? ???'	-- II_GEN_FOO_PIL_GRAY
			WHEN 39 THEN '?? ?? ???'	-- II_GEN_FOO_PIL_YELLOW
			WHEN 40 THEN '?? ?? ???'	-- II_GEN_FOO_PIL_BLUE
			WHEN 41 THEN '?? ?? ???'	-- II_GEN_FOO_PIL_RED
			WHEN 42 THEN '?? ?? ???'	-- II_GEN_FOO_PIL_GOLD
			WHEN 43 THEN '??? ?? ???'	-- II_GEN_FOO_PIL_SINBI
			WHEN 44 THEN '???? ???'	-- II_GEN_FOO_INS_LOLLIPOP
			WHEN 45 THEN '??? ???'	-- II_GEN_FOO_INS_BISCUIT
			WHEN 46 THEN '??? ? ???'	-- II_GEN_FOO_INS_CHOCOLATE
			WHEN 47 THEN '?? ???'	-- II_GEN_FOO_INS_MILK
			WHEN 48 THEN '?? ???'	-- II_GEN_FOO_INS_BREAD
			WHEN 49 THEN '??? ???'	-- II_GEN_FOO_INS_HOTDOG
			WHEN 50 THEN '?? ???'	-- II_GEN_FOO_INS_HODDUK
			WHEN 51 THEN '?? ???'	-- II_GEN_FOO_INS_KIMBAP
			WHEN 52 THEN '??? ???'	-- II_GEN_FOO_INS_CHICKENSTICK
			WHEN 53 THEN '??? ???'	-- II_GEN_FOO_INS_STARCANDY
			WHEN 54 THEN '?? ???'	-- II_GEN_FOO_COO_MEATSKEWER
			WHEN 55 THEN '??? ???'	-- II_GEN_FOO_COO_BARBECUE
			WHEN 56 THEN '???? ???'	-- II_GEN_FOO_COO_SEAFOODPANCAKE
			WHEN 57 THEN '???? ???'	-- II_GEN_FOO_COO_FISHSOUP
			WHEN 58 THEN '????? ???'	-- II_GEN_FOO_COO_SAUSAGECASSEROLE
			WHEN 59 THEN '???? ???'	-- II_GEN_FOO_COO_FISHSTEW
			WHEN 60 THEN '??? ???'	-- II_GEN_FOO_COO_STEAMEDSEAFOOD
			WHEN 61 THEN '????? ???'	-- II_GEN_FOO_COO_MEATSALAD
			WHEN 62 THEN '??? ???'	-- II_GEN_FOO_COO_GRATIN
			WHEN 63 THEN '???? ???'	-- II_GEN_FOO_COO_SEAFOODPIZZA
			WHEN 64 THEN '????? ???'	-- II_GEN_FOO_ICE_ORANGEJUIICE
			WHEN 65 THEN '????? ???'	-- II_GEN_FOO_ICE_STRAWBERRYSHAKE
			WHEN 66 THEN '????? ???'	-- II_GEN_FOO_ICE_PINEAPPLECONE
			WHEN 67 THEN '?????? ???'	-- II_GEN_FOO_ICE_BANANAJUJUBAR
			WHEN 68 THEN '???? ???'	-- II_GEN_FOO_ICE_FRUITJUICE
			WHEN 69 THEN '???? ???'	-- II_GEN_FOO_ICE_FRUITICEWATER
			WHEN 70 THEN '????? ???'	-- II_GEN_FOO_ICE_FRUITPARFAIT
			WHEN 71 THEN '???? ???'	-- II_GEN_FOO_ICE_FRUITSHERBET
			WHEN 72 THEN '??????? ???'	-- II_GEN_FOO_ICE_ICECREAMCAKE
			WHEN 73 THEN '???? ???'	-- II_GEN_FOO_ICE_FRUITPUNCH
			WHEN 74 THEN '???? ?? ???'	-- MI_AIBATT2
			WHEN 75 THEN '???? ??? ???'	-- MI_LAWOLF2

			WHEN 76 THEN '????? ???'	-- MI_CARDPUPPET2
			WHEN 77 THEN '???? ????'	-- MI_GLAPHAN2
			WHEN 78 THEN '? ???'	-- MI_DU_METEONYKER
			WHEN 79 THEN '?????X ? ???'	-- MI_CYCLOPSX
			WHEN 80 THEN '?? ???'	-- MI_NPC_YETI01
			WHEN 81 THEN '??? ??? ??'	-- MI_NPC_YETI02
			WHEN 82 THEN '??? ??'	-- MI_NPC_AUGOO01
			WHEN 83 THEN '???? ????'	-- MI_NPC_AUGOO02
			WHEN 84 THEN '?? ???'	-- MI_NPC_SADKING01
			WHEN 85 THEN '??? ????'	-- MI_NPC_SADKING02
			WHEN 86 THEN '??? ???'	-- MI_NPC_MAMMOTH01
			WHEN 87 THEN '???? ?? ???'	-- MI_NPC_MAMMOTH02
			WHEN 88 THEN '??? ???? ??'	-- MI_KINGSTER02
			WHEN 89 THEN '??? ?? ?? ???'	-- MI_KRAKEN02
			WHEN 90 THEN '???? ?? ???'	-- MI_CREPER02
			WHEN 91 THEN '??? ? ?? ??'	-- MI_NAGA02
			WHEN 92 THEN '????? ?? ?? ??'	-- MI_ATROX02
			WHEN 93 THEN '???? ???'	-- MI_OKEAN02
			WHEN 94 THEN '???? ???? ??'	-- MI_TAIGA02
			WHEN 95 THEN '????? ? ???'	-- MI_DORIAN02
			WHEN 96 THEN '??? ?????'	-- MI_MEREL02
			WHEN 97 THEN '????? ????'	-- MI_CLOCKWORK1
			WHEN 98 THEN '??? ? ???'	-- MI_DU_METEONYKER2
			ELSE CONVERT(VARCHAR(50), @hkind)
	END
	RETURN @ret
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GuildGold]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_GuildGold] (@m_nGuildGold int)
returns bigint
as
begin
	declare @result bigint
	if @m_nGuildGold >= 0
	begin
		select @result =  @m_nGuildGold
	end
	else
	begin
		select @result =  2147483647 - cast(@m_nGuildGold as bigint)
	end
	return @result
end
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetExpRatio]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION [dbo].[fn_GetExpRatio] (
    @Level	int,
    @exp	bigint
)  
RETURNS NUMERIC(3,0)
AS  
BEGIN 
	
	RETURN
		CASE 	WHEN @Level=1 THEN CAST(@exp AS NUMERIC(12,0)) / 14.0 * 100
				WHEN @Level=2 THEN CAST(@exp AS NUMERIC(12,0)) / 20.0 * 100
				WHEN @Level=3 THEN CAST(@exp AS NUMERIC(12,0)) / 36.0 * 100 	
				WHEN @Level=4 THEN CAST(@exp AS NUMERIC(12,0)) / 	90.0 * 100 	
				WHEN @Level=5 THEN CAST(@exp AS NUMERIC(12,0)) / 	152.0 * 100 	
				WHEN @Level=6 THEN CAST(@exp AS NUMERIC(12,0)) / 	250.0 * 100 	
				WHEN @Level=7 THEN CAST(@exp AS NUMERIC(12,0)) / 	352.0 * 100 	
				WHEN @Level=8 THEN CAST(@exp AS NUMERIC(12,0)) / 	480.0 * 100 	
				WHEN @Level=9 THEN CAST(@exp AS NUMERIC(12,0)) / 	591.0 * 100 	
				WHEN @Level=11 THEN CAST(@exp AS NUMERIC(12,0)) / 	743.0 * 100 	
				WHEN @Level=12 THEN CAST(@exp AS NUMERIC(12,0)) / 	973.0 * 100 	
				WHEN @Level=13 THEN CAST(@exp AS NUMERIC(12,0)) / 	1290.0 * 100 	
				WHEN @Level=14 THEN CAST(@exp AS NUMERIC(12,0)) / 	1632.0 * 100 	
				WHEN @Level=15 THEN CAST(@exp AS NUMERIC(12,0)) / 	1928.0 * 100 	
				WHEN @Level=16 THEN CAST(@exp AS NUMERIC(12,0)) / 	2340.0 * 100 	
				WHEN @Level=17 THEN CAST(@exp AS NUMERIC(12,0)) / 	3480.0 * 100 	
				WHEN @Level=18 THEN CAST(@exp AS NUMERIC(12,0)) / 	4125.0 * 100 	
				WHEN @Level=19 THEN CAST(@exp AS NUMERIC(12,0)) / 	4995.0 * 100 	
				WHEN @Level=20 THEN CAST(@exp AS NUMERIC(12,0)) / 	5880.0 * 100 	
				WHEN @Level=21 THEN CAST(@exp AS NUMERIC(12,0)) / 	7840.0 * 100 	
				WHEN @Level=22 THEN CAST(@exp AS NUMERIC(12,0)) / 	6875.0 * 100 	
				WHEN @Level=23 THEN CAST(@exp AS NUMERIC(12,0)) / 	8243.0 * 100 	
				WHEN @Level=24 THEN CAST(@exp AS NUMERIC(12,0)) / 	10380.0 * 100 	
				WHEN @Level=25 THEN CAST(@exp AS NUMERIC(12,0)) / 	13052.0 * 100 	
				WHEN @Level=26 THEN CAST(@exp AS NUMERIC(12,0)) / 	16450.0 * 100 	
				WHEN @Level=27 THEN CAST(@exp AS NUMERIC(12,0)) / 	20700.0 * 100 	
				WHEN @Level=28 THEN CAST(@exp AS NUMERIC(12,0)) / 	26143.0 * 100 	
				WHEN @Level=29 THEN CAST(@exp AS NUMERIC(12,0)) / 	31950.0 * 100 	
				WHEN @Level=30 THEN CAST(@exp AS NUMERIC(12,0)) / 	38640.0 * 100 	
				WHEN @Level=31 THEN CAST(@exp AS NUMERIC(12,0)) / 	57035.0 * 100 	
				WHEN @Level=32 THEN CAST(@exp AS NUMERIC(12,0)) / 	65000.0 * 100 	
				WHEN @Level=33 THEN CAST(@exp AS NUMERIC(12,0)) / 	69125.0 * 100 	
				WHEN @Level=34 THEN CAST(@exp AS NUMERIC(12,0)) / 	72000.0 * 100 	
				WHEN @Level=35 THEN CAST(@exp AS NUMERIC(12,0)) / 	87239.0 * 100 	
				WHEN @Level=36 THEN CAST(@exp AS NUMERIC(12,0)) / 	105863.0 * 100 	
				WHEN @Level=37 THEN CAST(@exp AS NUMERIC(12,0)) / 	128694.0 * 100 	
				WHEN @Level=38 THEN CAST(@exp AS NUMERIC(12,0)) / 	182307.0 * 100 	
		WHEN @Level=39 THEN CAST(@exp AS NUMERIC(12,0)) / 	221450.0 * 100 	
		WHEN @Level=40 THEN CAST(@exp AS NUMERIC(12,0)) / 	269042.0 * 100 	
		WHEN @Level=41 THEN CAST(@exp AS NUMERIC(12,0)) / 	390368.0 * 100 	
		WHEN @Level=42 THEN CAST(@exp AS NUMERIC(12,0)) / 	438550.0 * 100 	
		WHEN @Level=43 THEN CAST(@exp AS NUMERIC(12,0)) / 	458137.0 * 100 	
		WHEN @Level=44 THEN CAST(@exp AS NUMERIC(12,0)) / 	468943.0 * 100 	
		WHEN @Level=45 THEN CAST(@exp AS NUMERIC(12,0)) / 	560177.0 * 100 	
		WHEN @Level=46 THEN CAST(@exp AS NUMERIC(12,0)) / 	669320.0 * 100 	
		WHEN @Level=47 THEN CAST(@exp AS NUMERIC(12,0)) / 	799963.0 * 100 	
		WHEN @Level=48 THEN CAST(@exp AS NUMERIC(12,0)) / 	1115396.0 * 100
		WHEN @Level=49 THEN CAST(@exp AS NUMERIC(12,0)) / 	1331100.0 * 100
		WHEN @Level=50 THEN CAST(@exp AS NUMERIC(12,0)) / 	1590273.0 * 100
		WHEN @Level=51 THEN CAST(@exp AS NUMERIC(12,0)) / 	2306878.0 * 100
		WHEN @Level=52 THEN CAST(@exp AS NUMERIC(12,0)) / 	2594255.0 * 100
		WHEN @Level=53 THEN CAST(@exp AS NUMERIC(12,0)) / 	2711490.0 * 100
		WHEN @Level=54 THEN CAST(@exp AS NUMERIC(12,0)) / 	2777349.0 * 100
		WHEN @Level=55 THEN CAST(@exp AS NUMERIC(12,0)) / 	3318059.0 * 100
		WHEN @Level=56 THEN CAST(@exp AS NUMERIC(12,0)) / 	3963400.0 * 100
		WHEN @Level=57 THEN CAST(@exp AS NUMERIC(12,0)) / 	4735913.0 * 100
		WHEN @Level=58 THEN CAST(@exp AS NUMERIC(12,0)) / 	6600425.0 * 100
		WHEN @Level=59 THEN CAST(@exp AS NUMERIC(12,0)) / 	7886110.0 * 100
		WHEN @Level=60 THEN CAST(@exp AS NUMERIC(12,0)) / 	9421875.0 * 100
		WHEN @Level=61 THEN CAST(@exp AS NUMERIC(12,0)) / 	13547310.0 * 100 	
		WHEN @Level=62 THEN CAST(@exp AS NUMERIC(12,0)) / 	15099446.0 * 100 	
		WHEN @Level=63 THEN CAST(@exp AS NUMERIC(12,0)) / 	15644776.0 * 100 	
		WHEN @Level=64 THEN CAST(@exp AS NUMERIC(12,0)) / 	15885934.0 * 100 	
		WHEN @Level=65 THEN CAST(@exp AS NUMERIC(12,0)) / 	18817757.0 * 100 	
		WHEN @Level=66 THEN CAST(@exp AS NUMERIC(12,0)) / 	22280630.0 * 100 	
		WHEN @Level=67 THEN CAST(@exp AS NUMERIC(12,0)) / 	26392968.0 * 100 	
		WHEN @Level=68 THEN CAST(@exp AS NUMERIC(12,0)) / 	36465972.0 * 100 	
		WHEN @Level=69 THEN CAST(@exp AS NUMERIC(12,0)) / 	43184958.0 * 100 	
		WHEN @Level=70 THEN CAST(@exp AS NUMERIC(12,0)) / 	51141217.0 * 100 	
		WHEN @Level=71 THEN CAST(@exp AS NUMERIC(12,0)) / 	73556918.0 * 100 	
		WHEN @Level=72 THEN CAST(@exp AS NUMERIC(12,0)) / 	81991117.0 * 100 	
		WHEN @Level=73 THEN CAST(@exp AS NUMERIC(12,0)) / 	84966758.0 * 100 	
		WHEN @Level=74 THEN CAST(@exp AS NUMERIC(12,0)) / 	86252845.0 * 100 	
		WHEN @Level=75 THEN CAST(@exp AS NUMERIC(12,0)) / 	102171368.0 * 100 	
		WHEN @Level=76 THEN CAST(@exp AS NUMERIC(12,0)) / 	120995493.0 * 100 	
		WHEN @Level=77 THEN CAST(@exp AS NUMERIC(12,0)) / 	143307208.0 * 100 	
		WHEN @Level=78 THEN CAST(@exp AS NUMERIC(12,0)) / 	198000645.0 * 100 	
		WHEN @Level=79 THEN CAST(@exp AS NUMERIC(12,0)) / 	234477760.0 * 100 	
		WHEN @Level=80 THEN CAST(@exp AS NUMERIC(12,0)) / 	277716683.0 * 100 	
		WHEN @Level=81 THEN CAST(@exp AS NUMERIC(12,0)) / 	381795797.0 * 100 	
		WHEN @Level=82 THEN CAST(@exp AS NUMERIC(12,0)) / 	406848219.0 * 100 	
		WHEN @Level=83 THEN CAST(@exp AS NUMERIC(12,0)) / 	403044458.0 * 100 	
		WHEN @Level=84 THEN CAST(@exp AS NUMERIC(12,0)) / 	391191019.0 * 100 	
		WHEN @Level=85 THEN CAST(@exp AS NUMERIC(12,0)) / 	442876559.0 * 100 	
		WHEN @Level=86 THEN CAST(@exp AS NUMERIC(12,0)) / 	501408635.0 * 100 	
		WHEN @Level=87 THEN CAST(@exp AS NUMERIC(12,0)) / 	567694433.0 * 100 	
		WHEN @Level=88 THEN CAST(@exp AS NUMERIC(12,0)) / 	749813704.0 * 100 	
		WHEN @Level=89 THEN CAST(@exp AS NUMERIC(12,0)) / 	849001357.0 * 100 	
		WHEN @Level=90 THEN CAST(@exp AS NUMERIC(12,0)) / 	961154774.0 * 100 	
		WHEN @Level=91 THEN CAST(@exp AS NUMERIC(12,0)) / 	1309582668.0 * 100 	
		WHEN @Level=92 THEN CAST(@exp AS NUMERIC(12,0)) / 	1382799035.0 * 100 	
		WHEN @Level=93 THEN CAST(@exp AS NUMERIC(12,0)) / 	1357505030.0 * 100 	
		WHEN @Level=94 THEN CAST(@exp AS NUMERIC(12,0)) / 	1305632790.0 * 100 	
		WHEN @Level=95 THEN CAST(@exp AS NUMERIC(12,0)) / 	1464862605.0 * 100 	
		WHEN @Level=96 THEN CAST(@exp AS NUMERIC(12,0)) / 	1628695740.0 * 100 	
		WHEN @Level=97 THEN CAST(@exp AS NUMERIC(12,0)) / 	1810772333.0 * 100 	
		WHEN @Level=98 THEN CAST(@exp AS NUMERIC(12,0)) / 	2348583653.0 * 100 	
		WHEN @Level=99 THEN CAST(@exp AS NUMERIC(12,0)) / 	2611145432.0 * 100 	
		WHEN @Level=100 THEN CAST(@exp AS NUMERIC(12,0)) / 	2903009208.0 * 100 	
		WHEN @Level=101 THEN CAST(@exp AS NUMERIC(12,0)) / 	3919352097.0 * 100 	
		WHEN @Level=102 THEN CAST(@exp AS NUMERIC(12,0)) / 	4063358600.0 * 100 	
		WHEN @Level=103 THEN CAST(@exp AS NUMERIC(12,0)) / 	3916810682.0 * 100 	
		WHEN @Level=104 THEN CAST(@exp AS NUMERIC(12,0)) / 	4314535354.0 * 100 	
		WHEN @Level=105 THEN CAST(@exp AS NUMERIC(12,0)) / 	4752892146.0 * 100 	
		WHEN @Level=106 THEN CAST(@exp AS NUMERIC(12,0)) / 	5235785988.0 * 100 	
		WHEN @Level=107 THEN CAST(@exp AS NUMERIC(12,0)) / 	5767741845.0 * 100 	
		WHEN @Level=108 THEN CAST(@exp AS NUMERIC(12,0)) / 	6353744416.0 * 100 	
		WHEN @Level=109 THEN CAST(@exp AS NUMERIC(12,0)) / 	6999284849.0 * 100 	
		WHEN @Level=110 THEN CAST(@exp AS NUMERIC(12,0)) / 	7710412189.0 * 100 	
		WHEN @Level=111 THEN CAST(@exp AS NUMERIC(12,0)) / 	8493790068.0 * 100 	
		WHEN @Level=112 THEN CAST(@exp AS NUMERIC(12,0)) / 	9356759139.0 * 100	
		WHEN @Level=113 THEN CAST(@exp AS NUMERIC(12,0)) / 	10307405867.0 * 100 	
		WHEN @Level=114 THEN CAST(@exp AS NUMERIC(12,0)) / 	11354638303.0 * 100 	
		WHEN @Level=115 THEN CAST(@exp AS NUMERIC(12,0)) / 	12508269555.0 * 100 	
		WHEN @Level=116 THEN CAST(@exp AS NUMERIC(12,0)) / 	13779109742.0 * 100 	
		WHEN @Level=117 THEN CAST(@exp AS NUMERIC(12,0)) / 	15179067292.0 * 100 	
		WHEN @Level=118 THEN CAST(@exp AS NUMERIC(12,0)) / 	16721260528.0 * 100 	
		WHEN @Level=119 THEN CAST(@exp AS NUMERIC(12,0)) / 	18420140598.0 * 100 	
		WHEN @Level=120 THEN CAST(@exp AS NUMERIC(12,0)) / 	20291626883.0 * 100 	
		WHEN @Level=121 THEN CAST(@exp AS NUMERIC(12,0)) / 	22353256174.0 * 100 	
		WHEN @Level=122 THEN CAST(@exp AS NUMERIC(12,0)) / 	24624347002.0 * 100 	
		WHEN @Level=123 THEN CAST(@exp AS NUMERIC(12,0)) / 	27126180657.0 * 100 	
		WHEN @Level=124 THEN CAST(@exp AS NUMERIC(12,0)) / 	29882200612.0 * 100 	
		WHEN @Level=125 THEN CAST(@exp AS NUMERIC(12,0)) / 	32918232194.0 * 100 	
		WHEN @Level=126 THEN CAST(@exp AS NUMERIC(12,0)) / 	36262724585.0 * 100 	
		WHEN @Level=127 THEN CAST(@exp AS NUMERIC(12,0)) / 	39947017402.0 * 100 	
		WHEN @Level=128 THEN CAST(@exp AS NUMERIC(12,0)) / 	44005634371.0 * 100 	
		WHEN @Level=129 THEN CAST(@exp AS NUMERIC(12,0)) / 	48476606823.0 * 100 	
		WHEN @Level=130 THEN CAST(@exp AS NUMERIC(12,0)) / 	53401830076.0 * 100 	
		WHEN @Level=131 THEN CAST(@exp AS NUMERIC(12,0)) / 	58827456011.0 * 100 	
		WHEN @Level=132 THEN CAST(@exp AS NUMERIC(12,0)) / 	64804325542.0 * 100 	
		WHEN @Level=133 THEN CAST(@exp AS NUMERIC(12,0)) / 	71388445017.0 * 100 	
		WHEN @Level=134 THEN CAST(@exp AS NUMERIC(12,0)) / 	78641511031.0 * 100 	
		WHEN @Level=135 THEN CAST(@exp AS NUMERIC(12,0)) / 	86631488552.0 * 100 	
		WHEN @Level=136 THEN CAST(@exp AS NUMERIC(12,0)) / 	95433247789.0 * 100 	
		WHEN @Level=137 THEN CAST(@exp AS NUMERIC(12,0)) / 	105129265764.0 * 100 	
		WHEN @Level=138 THEN CAST(@exp AS NUMERIC(12,0)) / 	115810399166.0 * 100 	
		WHEN @Level=139 THEN CAST(@exp AS NUMERIC(12,0)) / 	127576735721.0 * 100 	
		WHEN @Level=140 THEN CAST(@exp AS NUMERIC(12,0)) / 	140538532070.0 * 100 	
		WHEN @Level=141 THEN CAST(@exp AS NUMERIC(12,0)) / 	154817246928.0 * 100 	
		WHEN @Level=142 THEN CAST(@exp AS NUMERIC(12,0)) / 	170546679216.0 * 100 	
		WHEN @Level=143 THEN CAST(@exp AS NUMERIC(12,0)) / 	187874221825.0 * 100 	
		WHEN @Level=144 THEN CAST(@exp AS NUMERIC(12,0)) / 	206962242762.0 * 100 	
		WHEN @Level=145 THEN CAST(@exp AS NUMERIC(12,0)) / 	227989606627.0 * 100 	
		WHEN @Level=146 THEN CAST(@exp AS NUMERIC(12,0)) / 	251153350660.0 * 100 	
		WHEN @Level=147 THEN CAST(@exp AS NUMERIC(12,0)) / 	276670531087.0 * 100 	
		WHEN @Level=148 THEN CAST(@exp AS NUMERIC(12,0)) / 	304780257046.0 * 100 	
		WHEN @Level=149 THEN CAST(@exp AS NUMERIC(12,0)) / 	335745931162.0 * 100 	
		WHEN @Level=150 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=151 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=152 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=153 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=154 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=155 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=156 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=157 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=158 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=159 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=160 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=161 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=162 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=163 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=164 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=165 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=166 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=167 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=168 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=169 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=170 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=171 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=172 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=173 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=174 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=175 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=176 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=177 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=178 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=179 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=180 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=181 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=182 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=183 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=184 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=185 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=186 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=187 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=188 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=189 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=190 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=191 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=192 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=193 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=194 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=195 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=196 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=197 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=198 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=199 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
		WHEN @Level=200 THEN CAST(@exp AS NUMERIC(12,0)) / 	369857717768.0 * 100 	
	    ELSE  0	END
END
GO
/****** Object:  Table [dbo].[EVIDANCE]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EVIDANCE](
	[account] [varchar](32) NOT NULL,
	[gamecode] [char](4) NOT NULL,
	[tester] [char](1) NOT NULL,
	[m_chLoginAuthority] [char](1) NOT NULL,
	[regdate] [datetime] NOT NULL,
	[BlockTime] [char](8) NULL,
	[EndTime] [char](8) NULL,
	[WebTime] [char](8) NULL,
	[isuse] [char](1) NOT NULL,
	[secession] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_QUEST_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_QUEST_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[n_Id] [int] NOT NULL,
	[nState] [int] NULL,
	[s_date] [char](14) NULL,
	[e_date] [char](14) NULL,
 CONSTRAINT [PK_GUILD_QUEST_idGuild] PRIMARY KEY CLUSTERED 
(
	[serverindex] ASC,
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedDataType [dbo].[m_idPlayer]    Script Date: 04/03/2010 12:42:44 ******/
CREATE TYPE [dbo].[m_idPlayer] FROM [char](7) NOT NULL
GO
/****** Object:  Table [dbo].[level]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[level](
	[Col001] [float] NULL,
	[Col002] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JOB_SKILL_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JOB_SKILL_TBL](
	[m_nJob] [int] NOT NULL,
	[SkillID] [int] NOT NULL,
	[SkillPosition] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ITEM_SEND_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ITEM_SEND_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[Item_Name] [varchar](32) NOT NULL,
	[Item_count] [int] NOT NULL,
	[m_nAbilityOption] [int] NOT NULL,
	[m_nNo] [int] IDENTITY(1,1) NOT NULL,
	[End_Time] [char](8) NULL,
	[m_bItemResist] [int] NOT NULL,
	[m_nResistAbilityOption] [int] NOT NULL,
	[m_bCharged] [int] NOT NULL,
	[idSender] [char](7) NULL,
	[nPiercedSize] [int] NOT NULL,
	[adwItemId0] [int] NOT NULL,
	[adwItemId1] [int] NOT NULL,
	[adwItemId2] [int] NOT NULL,
	[adwItemId3] [int] NOT NULL,
	[m_dwKeepTime] [bigint] NOT NULL,
	[ItemFlag] [int] NOT NULL,
	[ReceiveDt] [datetime] NOT NULL,
	[ProvideDt] [datetime] NULL,
	[nRandomOptItemId] [bigint] NULL,
	[ItemBillingNo] [char](21) NULL,
	[adwItemId4] [int] NULL,
	[adwItemId5] [int] NULL,
	[adwItemId6] [int] NULL,
	[adwItemId7] [int] NULL,
	[adwItemId8] [int] NULL,
	[adwItemId9] [int] NULL,
	[nUMPiercedSize] [int] NULL,
	[adwUMItemId0] [int] NULL,
	[adwUMItemId1] [int] NULL,
	[adwUMItemId2] [int] NULL,
	[adwUMItemId3] [int] NULL,
	[adwUMItemId4] [int] NULL,
 CONSTRAINT [PK_ITEM_SEND_No] PRIMARY KEY NONCLUSTERED 
(
	[serverindex] ASC,
	[m_nNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ITEM_REMOVE_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ITEM_REMOVE_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[Item_Name] [varchar](32) NOT NULL,
	[m_nAbilityOption] [int] NOT NULL,
	[Item_count] [int] NOT NULL,
	[State] [char](1) NOT NULL,
	[m_nNo] [int] IDENTITY(1,1) NOT NULL,
	[End_Time] [char](8) NULL,
	[m_bItemResist] [int] NOT NULL,
	[m_nResistAbilityOption] [int] NOT NULL,
	[ItemFlag] [int] NOT NULL,
	[ReceiveDt] [datetime] NOT NULL,
	[DeleteDt] [datetime] NULL,
	[RequestUser] [varchar](30) NOT NULL,
	[RandomOption] [bigint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INVENTORY_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INVENTORY_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_Inventory] [varchar](max) NULL,
	[m_apIndex] [varchar](2500) NULL,
	[m_adwEquipment] [varchar](500) NULL,
	[m_dwObjIndex] [varchar](2500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INVENTORY_EXT_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INVENTORY_EXT_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_extInventory] [varchar](max) NULL,
	[m_InventoryPiercing] [varchar](max) NULL,
	[szInventoryPet] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_WAR_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_WAR_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_idWar] [int] NULL,
	[f_idGuild] [char](6) NULL,
	[m_nDeath] [int] NULL,
	[m_nSurrender] [int] NULL,
	[m_nCount] [int] NULL,
	[m_nAbsent] [int] NULL,
	[f_nDeath] [int] NULL,
	[f_nSurrender] [int] NULL,
	[f_nCount] [char](10) NULL,
	[f_nAbsent] [int] NULL,
	[State] [char](1) NULL,
	[StartTime] [char](12) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[Lv_1] [int] NULL,
	[Lv_2] [int] NULL,
	[Lv_3] [int] NULL,
	[Lv_4] [int] NULL,
	[Pay_0] [int] NULL,
	[Pay_1] [int] NULL,
	[Pay_2] [int] NULL,
	[Pay_3] [int] NULL,
	[Pay_4] [int] NULL,
	[m_szGuild] [varchar](16) NULL,
	[m_nLevel] [int] NULL,
	[m_nGuildGold] [int] NULL,
	[m_nGuildPxp] [int] NULL,
	[m_nWin] [int] NULL,
	[m_nLose] [int] NULL,
	[m_nSurrender] [int] NULL,
	[m_nWinPoint] [int] NULL,
	[m_dwLogo] [int] NULL,
	[m_szNotice] [varchar](127) NULL,
	[isuse] [char](1) NULL,
	[CreateTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GUILD_VOTE_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GUILD_VOTE_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_idVote] [int] NULL,
	[m_cbStatus] [char](1) NULL,
	[m_szTitle] [varchar](128) NULL,
	[m_szQuestion] [varchar](255) NULL,
	[m_szString1] [varchar](32) NULL,
	[m_szString2] [varchar](32) NULL,
	[m_szString3] [varchar](32) NULL,
	[m_szString4] [varchar](32) NULL,
	[m_cbCount1] [int] NULL,
	[m_cbCount2] [int] NULL,
	[m_cbCount3] [int] NULL,
	[m_cbCount4] [int] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_GUILD_VOTE_id] PRIMARY KEY CLUSTERED 
(
	[serverindex] ASC,
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MESSENGER_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MESSENGER_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[f_idPlayer] [char](7) NULL,
	[m_nJob] [int] NULL,
	[m_dwSex] [int] NULL,
	[State] [char](1) NULL,
	[CreateTime] [datetime] NULL,
	[m_dwState] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildFurniture_Log]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/*============================================================    
1. ??? : ???    
2. ??? : 2009.11.23    
3. ???? ? : usp_GuildFurniture_Log    
4. ???? ?? : ?? ??? ?? Log ??    
5. ????    
 @serverindex char(2)   ???    
 @m_idGuild  char (6)  ?????    
 @SEQ   int     SEQ  ( 0 ??? GuildHouse ? ???? ?? ?? ?)  
6. ???      
7. ?? ??    
8. ?? ?? ??    
    EXEC usp_GuildFurniture_Log '05', '123456'    
9. ?? ? ident ? ???    
 select * from tblGuildHouse_FurnitureLog    
 delete tblGuildHouse_FurnitureLog    
============================================================*/    
    
CREATE proc [dbo].[usp_GuildFurniture_Log]    
 @serverindex char(2),    
 @m_idGuild  char (6),  
 @SEQ int = 0  
as    
    
set nocount on    
set xact_abort on    
  
if @SEQ = 0  
begin  
-- EXEC('  insert into LOG_' + @serverindex + '_DBF.dbo.tblGuildHouse_FurnitureLog   
 EXEC('  insert into LOGGING_01_DBF.dbo.tblGuildHouse_FurnitureLog   
   (  
    serverindex, m_idGuild, SEQ, ItemIndex, bSetup, s_date, set_date  
   )  
  SELECT  serverindex, m_idGuild, SEQ, ItemIndex, bSetup, s_date, set_date   
   from tblGuildHouse_Furniture (nolock)  
   where serverindex = ' + @serverindex + ' and m_idGuild = ' + @m_idGuild +''  
  )  
end  
else if @SEQ <> 0  
begin  
-- EXEC('  insert into LOG_' + @serverindex + '_DBF.dbo.tblGuildHouse_FurnitureLog   
 EXEC('  insert into LOGGING_01_DBF.dbo.tblGuildHouse_FurnitureLog    (  
    serverindex, m_idGuild, SEQ, ItemIndex, bSetup, s_date, set_date  
   )  
  SELECT  serverindex, m_idGuild, SEQ, ItemIndex, bSetup, s_date, set_date  
   
   from tblGuildHouse_Furniture (nolock)  
   where serverindex = ' + @serverindex + ' and m_idGuild = ' + @m_idGuild + ' and SEQ = ' + @SEQ + ' '  
  )  
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildHouse_Log]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/*============================================================  
1. ??? : ???  
2. ??? : 2009.11.23  
3. ???? ? : usp_GuildHouse_Log  
4. ???? ?? : ?? ??? Log ??  
5. ????  
 @serverindex char(2)   ???  
 @m_idGuild  char (6)  ?????  
 @SEQ   int     SEQ  
 @dwItemId    int    ?? ITEM  
 @bSetup   int    ?? ??  
6. ???    
7. ?? ??  
8. ?? ?? ??  
    EXEC usp_GuildHouse_Log '05', '123456'  
9. ?? ? ident ? ???  
 select * from tblGuildHouse  
 delete tblGuildHouse  
============================================================*/  
  
CREATE      proc [dbo].[usp_GuildHouse_Log]  
	@serverindex char(2),  
	@m_idGuild  char (6),
	@SEQ int = 0
as  
  
set nocount on  
set xact_abort on  

--	EXEC('  insert into LOG_' + @serverindex + '_DBF.dbo.tblGuildHouse_FurnitureLog 
	EXEC('  insert into LOGGING_01_DBF.dbo.tblGuildHouseLog 			(
				serverindex, m_idGuild, dwWorldID, tKeepTime, m_szGuild
			)
		SELECT  serverindex, m_idGuild, dwWorldID, tKeepTime, m_szGuild
			from tblGuildHouse (nolock)
			where serverindex = ' + @serverindex + ' and m_idGuild = ' + @m_idGuild + ' '
		)
GO
/****** Object:  Table [dbo].[TAX_DETAIL_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAX_DETAIL_TBL](
	[serverindex] [char](2) NULL,
	[nTimes] [int] NULL,
	[nContinent] [int] NULL,
	[nTaxKind] [int] NULL,
	[nTaxRate] [int] NULL,
	[nTaxCount] [int] NULL,
	[nTaxGold] [int] NULL,
	[nTaxPerin] [int] NULL,
	[nNextTaxRate] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WANTED_TBL]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WANTED_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[penya] [bigint] NULL,
	[szMsg] [varchar](40) NULL,
	[s_date] [char](12) NULL,
	[CreateTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[uspSetSealCharUpdate]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspSetSealCharUpdate]
@serverindex	char(2),
@im_idPlayer 	CHAR(7) = '',
@account	VARCHAR(32)	= '',
@nPlayerSlot	INT	=0,
@im_idPlayerW 	CHAR(7) = ''
AS
SET NOCOUNT ON

UPDATE	CHARACTER_TBL
SET	isblock = 'F' ,account = @account, playerslot = @nPlayerSlot
WHERE	m_idPlayer = @im_idPlayerW AND serverindex = @serverindex AND isblock = 'S'

RETURN
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspSetSealChar]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspSetSealChar]
@serverindex	char(2),
@im_idPlayer 	CHAR(7) = ''
AS
SET NOCOUNT ON

UPDATE CHARACTER_TBL
SET	isblock = 'S' 
WHERE 	m_idPlayer = @im_idPlayer AND serverindex = @serverindex

UPDATE	MESSENGER_TBL
SET	State = 'D'
WHERE	m_idPlayer = @im_idPlayer AND serverindex = @serverindex AND State = 'T'

UPDATE MAIL_TBL
SET byRead=90, DeleteDt=getdate() 
WHERE idReceiver = @im_idPlayer AND serverindex = @serverindex AND byRead<>90

RETURN
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspSavePocket]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   proc [dbo].[uspSavePocket]
@serverindex	CHAR(2),
@idPlayer	CHAR(7),
@nPocket	int,
@pszItem	VARCHAR(4290)	= '$',
@pszIndex	VARCHAR(215)	= '$',
@pszObjIndex	VARCHAR(215)	= '$',
@pszExt		VARCHAR(2000)	= '$',
@pszPiercing	VARCHAR(8000)	= '$',
@pszPet		VARCHAR(4200)	= '$',
@bExpired	int	= 1,
@tExpirationDate	int		= 0
AS
set nocount on

UPDATE	tblPocket
SET	szItem = @pszItem,
	szIndex = @pszIndex,
	szObjIndex = @pszIndex,
	bExpired = @bExpired,
	tExpirationDate = @tExpirationDate
WHERE	serverindex = @serverindex AND idPlayer = @idPlayer AND nPocket = @nPocket

UPDATE	tblPocketExt
SET	szExt = @pszExt,
	szPiercing = @pszPiercing,
	szPet = @pszPet
WHERE	serverindex = @serverindex AND idPlayer = @idPlayer AND nPocket = @nPocket

set nocount off
RETURN
GO
/****** Object:  StoredProcedure [dbo].[uspRestoreCandidates]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[uspRestoreCandidates]
@nServer int,
@idElection int
AS
SET NOCOUNT ON

SELECT idPlayer, iDeposit, szPledge, nVote, tCreate
FROM tblLordCandidates
WHERE nServer = @nServer AND idElection = @idElection AND IsLeftOut = 'F'
GO
/****** Object:  StoredProcedure [dbo].[uspReservRemoveItemFromCharacter]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspReservRemoveItemFromCharacter]
		@pserverindex		char(2),
		@pPlayerID			char(7),
		@pItemIndex			int,
		@pItemCnt			int=1,
		@pStorage			char(1)='I',
		@pAbilityOpt		int=0,
		@pItemResist		int=0,
		@pResAbilityOpt		int=0,
		@pRandomOpt			int=0,
		@pPiercedSize		int=0,
		@pPierceID1			int=0,
		@pPierceID2			int=0,
		@pPierceID3			int=0,
		@pPierceID4			int=0,
		@pRequestUser		varchar(32)='EoCRM'
AS
SET NOCOUNT ON

	INSERT INTO ITEM_REMOVE_TBL
		(serverindex, m_idPlayer, 
			Item_Name, Item_count, m_nAbilityOption, m_bItemResist, m_nResistAbilityOption, RandomOption,
			State, 
			RequestUser)
	VALUES
		(@pserverindex, @pPlayerID,
			@pItemIndex, @pItemCnt, @pAbilityOpt, @pItemResist, @pResAbilityOpt, @pRandomOpt,
			@pStorage,
			@pRequestUser) 

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspRemoveItemFromGuildBank]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspRemoveItemFromGuildBank]
		@pserverindex	char(2),
		@pNum			int,
		@pDeleteCnt		int
AS
SET NOCOUNT ON

	UPDATE tblRemoveItemFromGuildBank
		SET ItemFlag=1, DeleteCnt=@pDeleteCnt, DeleteDt=getdate()
	WHERE	serverindex=@pserverindex 
	AND		nNum=@pNum
	
	IF @@ROWCOUNT=0 BEGIN
		SELECT retValue ='0'
	END
	ELSE BEGIN
		SELECT retValue = '1'
	END
	
	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspRestorePropose]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------
create proc [dbo].[uspRestorePropose]
@nServer int
as
set nocount on

select nServer, idProposer, tPropose from tblPropose where nServer = @nServer
GO
/****** Object:  StoredProcedure [dbo].[uspRestoreLordSkill]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspRestoreLordSkill]
@nServer int
AS
SET NOCOUNT ON

SELECT nSkill, nTick FROM tblLordSkill
WHERE nServer = @nServer
GO
/****** Object:  StoredProcedure [dbo].[uspRestoreLord]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspRestoreLord]
@nServer int
AS
SET NOCOUNT ON

SELECT TOP 1 idLord FROM tblLord
WHERE nServer = @nServer
ORDER BY idElection DESC
GO
/****** Object:  StoredProcedure [dbo].[uspRestoreLEvent]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspRestoreLEvent]
@nServer int
AS
SET NOCOUNT ON

SELECT idPlayer, nTick, fEFactor, fIFactor FROM tblLordEvent
WHERE nServer = @nServer AND nTick > 0
GO
/****** Object:  StoredProcedure [dbo].[uspRestoreElection]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[uspRestoreElection]
@nServer int
AS
SET NOCOUNT ON

SELECT TOP 1 idElection, eState, szBegin, nRequirement = (select top 1 chrcount from tblElection order by s_week desc) FROM tblLordElection
WHERE nServer = @nServer
ORDER BY idElection DESC
GO
/****** Object:  StoredProcedure [dbo].[WANTED_STR]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WANTED_STR]
@iGu char(2) = 'S1',
@im_idPlayer CHAR(7) = '',
@iserverindex CHAR(2) = '',
@ipenya INT = 0,
@iszMsg VARCHAR(40) = ''
AS
SET NOCOUNT ON
IF @iGu = 'A1'
	BEGIN 
		IF EXISTS(SELECT m_idPlayer FROM WANTED_TBL WHERE m_idPlayer =@im_idPlayer AND serverindex = @iserverindex)
			UPDATE WANTED_TBL
				   SET penya = penya + @ipenya,
							szMsg = CASE WHEN @iszMsg = '' THEN szMsg ELSE @iszMsg END,
							s_date = CONVERT(CHAR(8),DATEADD(d,30,GETDATE()),112) + '2359'
			 WHERE m_idPlayer =@im_idPlayer 
			       AND serverindex = @iserverindex
		ELSE
			INSERT WANTED_TBL
				(m_idPlayer,serverindex,penya,szMsg,s_date,CreateTime)
			VALUES
				(@im_idPlayer,@iserverindex,@ipenya, @iszMsg,CONVERT(CHAR(8),DATEADD(d,30,GETDATE()),112) + '2359',GETDATE())
	END 
/*
	
	 ??? ??
	 ex ) 
	 WANTED_STR 'A1',@im_idPlayer,@iserverindex,@ipenya,@iszMsg
	 WANTED_STR 'A1','000001','01',1000,1
*/
ELSE
IF @iGu = 'S1'
	BEGIN
		IF EXISTS(SELECT m_idPlayer FROM  WANTED_TBL WHERE s_date  <= CONVERT(CHAR(8),GETDATE(),112) + '2359' AND serverindex = @iserverindex) 
			DELETE WANTED_TBL
			WHERE s_date  <= CONVERT(CHAR(8),GETDATE(),112) + '2359'
			    AND serverindex = @iserverindex

		SELECT A.m_idPlayer,A.serverindex,B.m_szName,szMsg = ISNULL(A.szMsg,''),A.penya,A.s_date
		   FROM WANTED_TBL A,CHARACTER_TBL B
		 WHERE A.m_idPlayer = B.m_idPlayer
		      AND A.serverindex = B.serverindex
	END
/*
	
	 ??? ??? ????
	 ex ) 
	 WANTED_STR 'S1',@im_idPlayer,@iserverindex
	WANTED_STR 'S1','','01'
*/
ELSE
IF @iGu = 'D1'
	BEGIN
		DELETE WANTED_TBL
		WHERE m_idPlayer =@im_idPlayer 
		     AND serverindex = @iserverindex
	END
/*
	
	 ??? ??
	 ex ) 
	 WANTED_STR 'D1',@im_idPlayer,@iserverindex
	WANTED_STR 'D1','000001','01'
*/
RETURN
SET NOCOUNT OFF
GO
/****** Object:  View [dbo].[viwCharacterItem]    Script Date: 04/03/2010 12:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viwCharacterItem]
AS
	SELECT 	a.m_idPlayer,
			a.serverindex,
			a.m_szName,
			a.m_nLevel,
			b.m_Inventory,
			c.m_extInventory,
			d.m_Bank,
			e.m_extBank
	FROM	CHARACTER_TBL a 
			INNER JOIN INVENTORY_TBL b ON (a.m_idPlayer=b.m_idPlayer)
			INNER JOIN INVENTORY_EXT_TBL c ON (a.m_idPlayer=c.m_idPlayer)
			INNER JOIN BANK_TBL d ON (a.m_idPlayer=d.m_idPlayer)
			INNER JOIN BANK_EXT_TBL e ON (a.m_idPlayer=e.m_idPlayer)
GO
/****** Object:  View [dbo].[viw_Item_Info]    Script Date: 04/03/2010 12:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viw_Item_Info]
as
select a.m_idPlayer, a.serverindex, b.m_Inventory,c.m_Bank,
	(select top 1 szItem from tblPocket with (nolock) where nPocket = 0 and idPlayer = a.m_idPlayer) as szItem0,
	(select top 1 szItem from tblPocket with (nolock) where nPocket = 1 and idPlayer = a.m_idPlayer) as szItem1,
	(select top 1 szItem from tblPocket with (nolock) where nPocket = 2 and idPlayer = a.m_idPlayer) as szItem2
from CHARACTER_TBL as a with (nolock)
			inner join INVENTORY_TBL as b with (nolock) on a.serverindex = b.serverindex and a.m_idPlayer = b.m_idPlayer
			inner join BANK_TBL as c with (nolock) on a.serverindex = c.serverindex and a.m_idPlayer = c.m_idPlayer
where a.isblock = 'F'
GO
/****** Object:  View [dbo].[view_character_level]    Script Date: 04/03/2010 12:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[view_character_level]
as
select a.m_idPlayer,a.serverindex,a.m_szName,m_nLevel=(a.m_nLevel/10)+1,b.m_Inventory,c.m_Bank
from CHARACTER_TBL a,INVENTORY_TBL b,BANK_TBL c
where a.m_idPlayer = b.m_idPlayer
and b.m_idPlayer = c.m_idPlayer
GO
/****** Object:  View [dbo].[view_character]    Script Date: 04/03/2010 12:42:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE view [dbo].[view_character]
as
select a.m_idPlayer, a.serverindex, b.m_Inventory, c.m_Bank, d.szItem
from CHARACTER_TBL as a inner join INVENTORY_TBL as b on a.m_idPlayer = b.m_idPlayer
			inner join BANK_TBL as c on a.m_idPlayer = c.m_idPlayer
			inner join tblPocket as d on a.m_idPlayer = d.idPlayer
where a.isblock = 'F'
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateMessenger]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[uspUpdateMessenger]
		@serverindex	char(2),
		@idPlayer		char(7),
		@idFriend		char(7),
		@bBlock			int
AS
SET NOCOUNT ON

	UPDATE tblMessenger SET bBlock = @bBlock WHERE serverindex = @serverindex AND idPlayer = @idPlayer AND idFriend = @idFriend

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadSealChar]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspLoadSealChar]
@serverindex	char(2),
@account	VARCHAR(32) = ''
AS
SET NOCOUNT ON

select TOP 3 playerslot,m_idPlayer,m_szName
from CHARACTER_TBL
where serverindex=@serverindex and account= @account and isblock='F'
order by playerslot

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadRemoveItemFromGuildBank]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadRemoveItemFromGuildBank]
		@pserverindex	char(2)
AS
SET NOCOUNT ON
	
	SELECT	nNum,
			idGuild,
			ItemIndex,
			ItemSerialNum,
			ItemCnt,
			DeleteCnt,
			DeleteRequestCnt
	FROM	tblRemoveItemFromGuildBank
	WHERE	serverindex=@pserverindex
	AND		ItemFlag=0

	-- Error Handling
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadPlayerData]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROCEDURE [dbo].[uspLoadPlayerData]
		@iserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT m_idPlayer, m_szName, m_dwSex, m_nLevel, m_nJob, m_nMessengerState FROM CHARACTER_TBL
	WHERE	serverindex = @iserverindex ORDER BY m_idPlayer
 
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadMessengerListRegisterMe]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspLoadMessengerListRegisterMe]
		@pserverindex		char(2),
		@pPlayerID			char(7)
AS
SET NOCOUNT ON

	SELECT	a.f_idPlayer, count(a.f_idPlayer)
	FROM	MESSENGER_TBL a, MESSENGER_TBL b
	WHERE	a.f_idPlayer=b.m_idPlayer
		AND	a.serverindex=b.serverindex
		AND	a.m_idPlayer = @pPlayerID
		AND a.serverindex = @pserverindex
		AND a.State = 'T'
		AND b.State = 'T'
	GROUP BY a.f_idPlayer
	
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadMessengerList]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspLoadMessengerList]
		@pserverindex		char(2),
		@pPlayerID			char(7)
AS
SET NOCOUNT ON

	SELECT	a.f_idPlayer, b.m_nJob, b.m_dwSex, a.m_dwState
	FROM	dbo.MESSENGER_TBL a
			INNER JOIN dbo.CHARACTER_TBL b
				ON (a.serverindex=b.serverindex AND a.f_idPlayer=b.m_idPlayer)
	WHERE	a.serverindex=@pserverindex
		AND	a.m_idPlayer=@pPlayerID
		AND	a.State='T'
		AND	b.isblock='F'
	ORDER BY	a.CreateTime
	
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadMessenger]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[uspLoadMessenger]
		@serverindex	char(2),
		@idPlayer		char(7)
AS
SET NOCOUNT ON
	SELECT idPlayer, idFriend, bBlock FROM tblMessenger
	WHERE	serverindex = @serverindex AND idPlayer = @idPlayer AND chUse = 'T'

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadMaxMailID]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[uspLoadMaxMailID]
@pserverindex char(2)
AS
SET NOCOUNT ON

/*	SELECT	MAX(nMail) as MaxMailID 
	FROM 	dbo.MAIL_TBL
	WHERE	serverindex=@pserverindex*/
	SELECT MaxMailID = (SELECT isnull(MAX(nMail), 0)
				FROM dbo.MAIL_TBL
				WHERE serverindex=@pserverindex),
		nCount = (SELECT COUNT(nMail)
				FROM MAIL_TBL
				WHERE serverindex = @pserverindex AND byRead<90)
GO
/****** Object:  StoredProcedure [dbo].[uspLoadMaxCombatID]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadMaxCombatID]
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT	ISNULL(MAX(CombatID),0) as MaxNum FROM tblCombatInfo
	 WHERE	serverindex=@pserverindex
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadGuildMember]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadGuildMember]
		@pserverindex	char(2),
		@pGuildID		char(6)
AS
SET NOCOUNT ON

	SELECT	m_idPlayer 
	  FROM	GUILD_MEMBER_TBL
	 WHERE	m_idGuild=@pGuildID
	 
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadCombatList]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadCombatList]
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT	CombatID, serverindex, Status, StartDt, EndDt, Comment 
	  FROM	tblCombatInfo
	 WHERE	serverindex=@pserverindex
 
	RETURN


SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadCombatInfo]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadCombatInfo]
		@pCombatID		int,
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT	CombatID, serverindex, Status, StartDt, EndDt, Comment 
	  FROM	tblCombatInfo
	 WHERE	serverindex=@pserverindex
	   AND	CombatID=@pCombatID
 
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspProvideItemToCharacter]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspProvideItemToCharacter]
		@pPlayerID			char(7),
		@pserverindex		char(2),
		@pItemIndex			int,
		@pItemCnt			int=1,
		@pAbilityOption		int=0,
		@pEndTime			char(8)=NULL,
		@pItemResist		int=0,
		@pResAbilityOpt		int=0,
		@pCharged			int=0,
		@pSender			char(7)='0000000',
		@pRandomOption		int=0,
		@pPiercedSize		int=0,
		@pPierceID1			int=0,
		@pPierceID2			int=0,
		@pPierceID3			int=0,
		@pPierceID4			int=0,
		@pKeepTime			int=0
AS
SET NOCOUNT ON

	DECLARE	@ItemName	varchar(32)

	IF @pItemIndex=12 OR @pItemIndex=13 OR @pItemIndex=14 OR @pItemIndex=15 BEGIN
		SET @ItemName='penya'
	END
	ELSE BEGIN
		SET @ItemName=@pItemIndex
	END
	
	INSERT INTO ITEM_SEND_TBL
		(m_idPlayer, serverindex, 
				Item_Name, Item_count, m_nAbilityOption, End_Time, m_bItemResist, m_nResistAbilityOption, nRandomOptItemId,
				m_bCharged, idSender, 
				nPiercedSize, adwItemId0, adwItemId1, adwItemId2, adwItemId3,
				m_dwKeepTime)
		VALUES
		(@pPlayerID, @pserverindex,
				@ItemName, @pItemCnt, @pAbilityOption, @pEndTime, @pItemResist, @pResAbilityOpt, @pRandomOption,
				@pCharged, @pSender,
				@pPiercedSize, @pPierceID1, @pPierceID2, @pPierceID3, @pPierceID4,
				@pKeepTime) 
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLordSkillTick]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspLordSkillTick]
@nServer int,
@nSkill int,
@nTick int
AS
SET NOCOUNT ON

IF EXISTS ( SELECT * FROM tblLordSkill WHERE nServer = @nServer AND nSkill = @nSkill )
BEGIN
	UPDATE tblLordSkill
	SET nTick = @nTick
	WHERE nServer = @nServer AND nSkill = @nSkill
END
ELSE
BEGIN
	INSERT tblLordSkill( nServer, nSkill, nTick )
	VALUES ( @nServer, @nSkill, @nTick )
END
GO
/****** Object:  StoredProcedure [dbo].[uspLordEventTick]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspLordEventTick]

             @nServer            int,

             @idPlayer           int,

             @nTick               int

AS

SET NOCOUNT ON

             UPDATE tblLordEvent

             SET nTick = @nTick

             WHERE nServer = @nServer AND idPlayer = @idPlayer AND nTick > 0
GO
/****** Object:  StoredProcedure [dbo].[uspInitMultiServer]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE	PROCEDURE [dbo].[uspInitMultiServer]
		@pserverindex	char(2),
		@pMultiServer	int
AS
SET NOCOUNT ON
	UPDATE CHARACTER_TBL SET MultiServer=0
		WHERE serverindex=@pserverindex AND MultiServer=@pMultiServer

	SELECT 1
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspInitializeLEvent]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspInitializeLEvent]
@nServer	int
AS
SET NOCOUNT ON

UPDATE tblLordEvent SET nTick = 0 WHERE nServer = @nServer
GO
/****** Object:  StoredProcedure [dbo].[uspLoadCharacterSkill]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspLoadCharacterSkill]
		@serverindex	char(2),
		@pPlayerID		char(7)
AS
SET NOCOUNT ON

	SELECT PlayerID, SkillID, SkillLv, SkillPosition FROM tblSkillPoint 
	WHERE 	PlayerID=@pPlayerID 
	and		serverindex=@serverindex

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLearnSkill]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[uspLearnSkill]
		@serverindex 	char(2),
		@pPlayerID		char(7),
		@pSkillID		int,
		@pSkillLv		int,
		@pSkillPosition	int
AS
SET NOCOUNT ON

	IF @pSkillID=-1 BEGIN
		IF ExISTS ( SELECT * FROM dbo.tblSkillPoint WHERE serverindex=@serverindex AND PlayerID=@pPlayerID AND SkillPosition=@pSkillPosition) BEGIN
			DELETE FROM tblSkillPoint WHERE serverindex=@serverindex AND PlayerID=@pPlayerID and SkillPosition=@pSkillPosition
		END
		
		RETURN
	END

	IF EXISTS ( SELECT * FROM dbo.tblSkillPoint WHERE serverindex=@serverindex AND PlayerID=@pPlayerID AND SkillPosition=@pSkillPosition) BEGIN
		UPDATE tblSkillPoint 
			SET SkillID=@pSkillID,SkillLv=@pSkillLv 
		WHERE serverindex=@serverindex AND PlayerID=@pPlayerID AND SkillPosition=@pSkillPosition
	END
	ELSE BEGIN
		INSERT INTO tblSkillPoint VALUES (@serverindex, @pPlayerID, @pSkillID, @pSkillLv, @pSkillPosition)
	END

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspConvertCharacterSkill]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
SELECT count(*) FROM tblSkillPoint

SELECT * FROM tblSkillPoint
SELECT m_idPlayer FROM CHARACTER_TBL WHERE serverindex='01' and m_idPlayer='033924'
TRUNCATE TABLE tblSkillPoint
dbo.uspConvertCharacterSkill '01', '033924'
SELECT serverindex, m_szName, m_idPlayer, m_nJob, m_nLevel, m_aJobSkill, m_nExp1 FROM CHARACTER_TBL WHERE m_aJobSkill=''

SELECT serverindex, m_szName, m_idPlayer, m_nJob, m_nLevel, m_aJobSkill, m_nExp1 FROM CHARACTER_TBL WHERE m_szName='???'
select * from tblSkillPoint WHERE PlayerID='009672'

20,1,1,1/0,1,2,1/0,1,3,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,1/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/0,1,-1,0/$


--SELECT * FROM CHARACTER_TBL WHERE m_szName='ccasse'
*/

CREATE              Procedure [dbo].[uspConvertCharacterSkill]
		@serverindex		char(2),
		@pPlayerID			char(7)='',
		@pSkillList			varchar(5000)=''
AS
SET NOCOUNT ON

	DECLARE	@SkillExp		int,
				@SkillLevel	int,
				@SkillID		int,
				@SkillStatus	int
				
    DECLARE	@SkillString		varchar(500),
				@SkillStringLength 	int

	DECLARE	@SkillSetStartPos	int,
				@SkillSetEndPos		int,
				@SkillSetLength		int
				
	DECLARE	@SkillElemStartPos	int,
				@SkillElemEndPos		int,
				@SkillElemLength		int,
				@SkillElemIndex		int,
				@SkillElemString		int
	
    SELECT	-1 as SkillExp,
			-1 as SkillLevel,
			-1 as SkillID, 
			-1 as SkillStatus
    INTO   #TMP

	DECLARE 	@CharacterLevel int,
				@Job	int,
				@CharExp	bigint

	DECLARE 	@ExtraPointForJob 	int,
				@ExtraPointForLevelExp	int,
				@LevelExpRatio		int,
				@FinalSkillPoint	int


	IF @pPlayerID='' BEGIN
		DELETE FROM tblSkillPoint WHERE serverindex=@serverindex
	END
	ELSE BEGIN
		DELETE FROM tblSkillPoint WHERE serverindex=@serverindex and PlayerID=@pPlayerID
	END

	IF @pPlayerID='' BEGIN
		DECLARE curCharacter CURSOR FOR
			SELECT m_idPlayer, m_nJob, m_nLevel, m_aJobSkill, m_nExp1 FROM CHARACTER_TBL WHERE serverindex=@serverindex AND isblock<>'D'
	END
	ELSE BEGIN
		DECLARE curCharacter CURSOR FOR
			SELECT m_idPlayer, m_nJob, m_nLevel, m_aJobSkill, m_nExp1 FROM CHARACTER_TBL WHERE serverindex=@serverindex and m_idPlayer=@pPlayerID
	END

	OPEN curCharacter

	FETCH NEXT FROM curCharacter INTO @pPlayerID, @Job, @CharacterLevel, @pSkillList, @CharExp

	--PRINT 'START'	
	WHILE(@@FETCH_STATUS=0) BEGIN
		--PRINT 'START'
		-- READ FROM TABLE
		--SELECT @CharacterLevel=m_nLevel , @pSkillList=m_aJobSkill FROM CHARACTER_TBL WHERE m_idPlayer=@pPlayerID and serverindex=@serverindex
	
	    SELECT @SkillStringLength = LEN(@pSkillList)
	    SELECT @SkillSetStartPos = 0             
	    SELECT @SkillSetEndPos   = -1          
	
		DECLARE @SkillPosition	int, @SkillPoint int, @Point int
		SET @SkillPosition=0
		SET @SkillPoint=0
		SET @Point=0
		SET 	@ExtraPointForJob 	=0
		SET		@ExtraPointForLevelExp	=0
		SET		@LevelExpRatio		=0
		SET @FinalSkillPoint=0
	
	
		--PRINT @SkillSetEndPos
		SET @SkillPosition=-1
		SET 	@ExtraPointForJob=0
		SET		@ExtraPointForLevelExp=0
		SET		@LevelExpRatio=0
		SET 	@SkillPoint=0

	    WHILE ( @SkillSetEndPos <> 0 )	BEGIN
			SET @Point=0

			SET @SkillPosition = @SkillPosition + 1
			SELECT @SkillSetStartPos = @SkillSetEndPos+1
	        SELECT @SkillSetEndPos = CHARINDEX('/', @pSkillList, @SkillSetStartPos)
			--PRINT @SkillSetEndPos
			
			IF @SkillSetEndPos=0 BREAK
	
	        SELECT @SkillSetLength = @SkillSetEndPos - @SkillSetStartPos
	        
	        IF (@SkillSetEndPos>@SkillStringLength) 
				BREAK
			ELSE BEGIN
				SELECT @SkillString = SUBSTRING(@pSkillList, @SkillSetStartPos, @SkillSetLength) + ','
				--PRINT @SkillString
	                
	            SET	@SkillElemStartPos	= 1
	            SET @SkillElemEndPos = CHARINDEX(',', @SkillString, @SkillElemStartPos)   
				SET @SkillElemLength = @SkillElemEndPos-@SkillElemStartPos
				
				SET @SkillExp = SUBSTRING(@SkillString, @SkillElemStartPos, @SkillElemLength)
				
				SET @SkillElemStartPos=@SkillElemEndPos+1
				SET @SkillElemEndPos=CHARINDEX(',',@SkillString, @SkillElemStartPos)
				SET @SkillElemLength = @SkillElemEndPos-@SkillElemStartPos
				
				SET @SkillLevel = SUBSTRING(@SkillString, @SkillElemStartPos, @SkillElemLength)
				
				SET @SkillElemStartPos=@SkillElemEndPos+1
				SET @SkillElemEndPos=CHARINDEX(',',@SkillString, @SkillElemStartPos)
				SET @SkillElemLength = @SkillElemEndPos-@SkillElemStartPos
				
				SET @SkillID = SUBSTRING(@SkillString, @SkillElemStartPos, @SkillElemLength)
	
				SET @SkillElemStartPos=@SkillElemEndPos+1
				SET @SkillElemEndPos=CHARINDEX(',',@SkillString, @SkillElemStartPos)
				SET @SkillElemLength = @SkillElemEndPos-@SkillElemStartPos
				
				SET @SkillStatus = SUBSTRING(@SkillString, @SkillElemStartPos, @SkillElemLength)
				
				--SELECT @SkillPosition as 'Skill Position', @SkillExp as 'Skill Exp', @SkillLevel as 'Skill Level', @SkillID as 'Skill ID', @SkillStatus as 'Skill Status'
			END
	
			SELECT @Point=CASE WHEN job=0 THEN 1 
								WHEN job in (1,2,3,4,5) THEN 2
								WHEN job>5 THEN 3
								ELSE 0 END * @SkillLevel
			 FROM MANAGE_DBF.dbo.SKILL_TBL
			WHERE [Index]=@SkillID

			--PRINT @Point
			
			SET @SkillPoint = @SkillPoint + @Point
	
			--PRINT @SkillPoint

			IF @SkillID > -1 BEGIN		
		        INSERT INTO tblSkillPoint(serverindex, SkillPosition, PlayerID, SkillID, SkillLv) 
					SELECT @serverindex, @SkillPosition, @pPlayerID, @SkillID, 0
			END

	    END -- END OF WHILE

		-- EXTRA POINT FOR JOB	
		SELECT @ExtraPointForJob=CASE 	WHEN @Job=0 THEN 0
										WHEN @Job in (1,2,3,4,5) THEN 30
										WHEN @Job>5	THEN 60
								 ELSE 0	END
		
		-- EXTRA POINT FOR LEVEL EXP
		SELECT @LevelExpRatio = dbo.fn_GetExpRatio(@CharacterLevel, @CharExp)

		SELECT @ExtraPointForLevelExp = CASE WHEN @LevelExpRatio < 33 THEN 0
											WHEN @LevelExpRatio BETWEEN 33 AND 65 THEN 1
											WHEN @LevelExpRatio BETWEEN 66 AND 98 THEN 2
											WHEN @LevelExpRatio BETWEEN 99 AND 100 THEN 3
										ELSE 0 END

		SET @FinalSkillPoint = @SkillPoint + @ExtraPointForLevelExp + @ExtraPointForJob

		IF @FinalSkillPoint < (@CharacterLevel - 1) * 3 + @ExtraPointForJob + @ExtraPointForLevelExp BEGIN
			SET @FinalSkillPoint = (@CharacterLevel - 1) * 3 + @ExtraPointForJob + @ExtraPointForLevelExp
		END


		UPDATE CHARACTER_TBL SET m_SkillExp=0, m_SkillPoint=@FinalSkillPoint, m_SkillLv=@FinalSkillPoint WHERE m_idPlayer=@pPlayerID AND serverindex=@serverindex

		FETCH NEXT FROM curCharacter INTO @pPlayerID, @Job, @CharacterLevel, @pSkillList, @CharExp
	END	-- END OF CURSOR

	CLOSE curCharacter
	DEALLOCATE curCharacter

	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspEndCombat]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspEndCombat]
		@pCombatID		int,
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	UPDATE tblCombatInfo SET Status='30',EndDt=getdate() WHERE CombatID=@pCombatID AND serverindex=@pserverindex

	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END

	SELECT 1 as retValue
	RETURN 1
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspElectionSetPledge]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspElectionSetPledge]
@nServer int,
@idElection int,
@idPlayer int,
@szPledge varchar(255)
AS
SET NOCOUNT ON

UPDATE tblLordCandidates
SET szPledge = @szPledge
WHERE nServer = @nServer AND idElection = @idElection AND idPlayer = @idPlayer
GO
/****** Object:  StoredProcedure [dbo].[uspElectionLeaveOut]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspElectionLeaveOut]

             @nServer            int,

             @idElection         int,

             @idPlayer           int

AS

SET NOCOUNT ON

             UPDATE tblLordCandidates

             SET IsLeftOut = 'D'

             WHERE nServer = @nServer AND idElection = @idElection AND idPlayer = @idPlayer
GO
/****** Object:  StoredProcedure [dbo].[uspElectionInitialize]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspElectionInitialize]
@nServer            int,
@idElection         int,
@szBegin           varchar( 16 )
AS
SET NOCOUNT ON

INSERT INTO tblLordElection ( nServer, idElection, eState, szBegin )
VALUES ( @nServer, @idElection, 0, @szBegin )
GO
/****** Object:  StoredProcedure [dbo].[uspElectionIncVote]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspElectionIncVote]
@nServer	int,
@idElection	int,
@idPlayer	int,
@idElector	int
AS
SET NOCOUNT ON

IF EXISTS ( SELECT * FROM tblLordElector WHERE nServer = @nServer AND idElection = @idElection AND idElector = @idElector )
BEGIN
	SELECT	bResult = 0
END
ELSE
BEGIN
	INSERT tblLordElector ( nServer, idElection, idElector )
	VALUES ( @nServer, @idElection, @idElector )

	UPDATE tblLordCandidates
	SET nVote = nVote + 1
	WHERE nServer = @nServer AND idElection = @idElection AND idPlayer = @idPlayer

	SELECT bResult = 1
END
GO
/****** Object:  StoredProcedure [dbo].[uspElectionEndVote]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[uspElectionEndVote]
@nServer	int,
@idElection	int,
@idPlayer	int,
@szBegin	varchar(16)
AS
SET NOCOUNT ON

UPDATE tblLordElection
SET eState = 3
WHERE nServer = @nServer AND idElection = @idElection

UPDATE tblLordSkill
SET nTick =0
WHERE nServer = @nServer

INSERT INTO tblLord ( nServer, idElection, idLord )
VALUES ( @nServer, @idElection, @idPlayer )

INSERT INTO tblLordElection ( nServer, idElection, eState, szBegin)
VALUES ( @nServer, @idElection + 1, 0, @szBegin)
GO
/****** Object:  StoredProcedure [dbo].[uspElectionBeginVote]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    proc [dbo].[uspElectionBeginVote]
@nServer int,
@idElection int
AS
SET NOCOUNT ON

UPDATE tblLordElection
SET eState = 2
WHERE nServer = @nServer AND idElection = @idElection

--SELECT top 1 nRequirement = chrcount from tblElection order by s_week desc
-- ???
SELECT top 1 nRequirement = 0 from tblElection order by s_week desc
GO
/****** Object:  StoredProcedure [dbo].[uspElectionBeginCandidacy]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspElectionBeginCandidacy]
@nServer int,
@idElection int
AS
SET NOCOUNT ON

IF EXISTS ( SELECT * FROM tblLordElection WHERE nServer = @nServer AND idElection = @idElection )
BEGIN
	UPDATE tblLordElection
	SET eState = 1
	WHERE nServer = @nServer AND idElection = @idElection
END
ELSE
BEGIN
	INSERT tblLordElection ( nServer, idElection, eState )
	VALUES ( @nServer, @idElection, 1 )
END
GO
/****** Object:  StoredProcedure [dbo].[uspElectionAddDeposit]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[uspElectionAddDeposit]
@nServer int,
@idElection int,
@idPlayer int,
@iDeposit bigint,
@tCreate int
AS
SET NOCOUNT ON

IF EXISTS ( SELECT * FROM tblLordCandidates WHERE nServer = @nServer AND idElection = @idElection AND idPlayer = @idPlayer )
BEGIN
	UPDATE tblLordCandidates
	SET iDeposit = iDeposit + @iDeposit
	WHERE nServer = @nServer AND idElection = @idElection AND idPlayer = @idPlayer
END
ELSE
BEGIN
	INSERT INTO tblLordCandidates ( nServer, idElection, idPlayer, iDeposit, szPledge, nVote, tCreate)
	VALUES ( @nServer, @idElection, @idPlayer, @iDeposit, '', 0, @tCreate )
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeletePropose]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------
create proc [dbo].[uspDeletePropose]
@nServer int,
@tPropose int
as
set nocount on

delete tblPropose where nServer = @nServer and tPropose < @tPropose
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteMessenger]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspDeleteMessenger]
		@serverindex	char(2),
		@idPlayer		char(7),
		@idFriend		char(7)
AS
SET NOCOUNT ON

	UPDATE tblMessenger SET chUse = 'F' WHERE serverindex = @serverindex AND ( ( idPlayer = @idPlayer AND idFriend = @idFriend ) OR ( idPlayer = @idFriend AND idFriend = @idPlayer ) )

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_RestPoint_Update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_RestPoint_Update    Script Date: 2009-12-01 ?? 2:41:44 ******/






/*============================================================
1. ??? : ???
2. ??? : 2009.11.30
3. ???? ? : usp_RestPoint_Update
4. ???? ?? : ??? ?? ??? ????
5. ????
	@serverindex char(2)		???
	@m_idPlyaer char(7)			??? ID
	@m_nRestPoint int			?? ???
	@m_LogOutTime int			??
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_RestPoint_Update '01', '1234567', 100
9. ?? ? ident ? ???
	select * from tblRestPoint
	delete tblGuildHouse_Furniture
	dbcc CHECKIDENT ( 'tblGuildHouse_Furniture', reseed, 0)
============================================================*/

CREATE   proc [dbo].[usp_RestPoint_Update]
	@serverindex char(2), 
	@m_idPlayer char(7), 
	@m_nRestPoint int,
	@m_LogOutTime int
as

set nocount on
set xact_abort on

	if exists ( select * from tblRestPoint (nolock) where serverindex = @serverindex and m_idPlayer = @m_idPlayer )
		begin
			update tblRestPoint 
			set m_nRestPoint = @m_nRestPoint, m_LogOutTime = @m_LogOutTime 
			where serverindex = @serverindex and m_idPlayer = @m_idPlayer
		end
	else
		begin
			insert into tblRestPoint (serverindex, m_idPlayer, m_nRestPoint, m_LogOutTime)
			select @serverindex, @m_idPlayer, @m_nRestPoint, @m_LogOutTime
		end
GO
/****** Object:  StoredProcedure [dbo].[usp_Quiz_update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
create  proc [dbo].[usp_Quiz_update]

	@serverindex char(2),
	@m_nIndex int,
	@m_nQuizType int, 
	@m_nAnswer int, 
	@m_szQuestion varchar(1024)
as

set nocount on
set xact_abort on

	update tblQuiz set m_nQuizType = @m_nQuizType, m_nAnswer = @m_nAnswer, m_szQuestion = @m_szQuestion
	where serverindex = @serverindex and m_nIndex = @m_nIndex
GO
/****** Object:  StoredProcedure [dbo].[usp_Quiz_Load]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.09.09
3. ???? ? : usp_Quiz_Load
4. ???? ?? : tblQuiz ??? ?? ?? ??? ??
5. ????
	@serverindex	char(2)		: ???
	@nQuizType		int			: ????
6. ??? 	
	m_nIndex					: Quiz ??
	m_nAnswer					: Quiz ??
	m_szQuestion				: Quiz ??
7. ?? ??
    2009. 09.09 / ??? / ?? ??
	2009. 10.12 / ??? / ?? ? ?? / m_nIndex
8. ?? ?? ??
    EXEC usp_Quiz_Load '05', 1
9. ?? ? ident ? ???
	select * from tblQuizAnswer
	select * from tblQuiz
	delete tblQuiz
	delete tblQuizAnswer
	DBCC checkident(tblQuiz ,reseed, 0)
============================================================*/




CREATE         proc [dbo].[usp_Quiz_Load] 

	@serverindex char(2), 
	@m_nQuizType int 

as
set nocount on

	select TQ.m_nIndex ,m_nAnswer, 
	case when m_Answer1 is not null then TQ.m_szQuestion +'|'+ isnull(m_Answer1, '') +'|'+ isnull(m_Answer2, '') +'|'+ isnull(m_Answer3, '') +'|'+ isnull(m_Answer4, '') 
	else TQ.m_szQuestion end m_szQuestion, m_Item, m_ItemCount
	from tblQuiz TQ (nolock) left join tblQuizAnswer TQA (nolock)
	on TQ.m_nIndex = TQA.m_nIndex
	where serverindex = @serverindex and m_nQuizType = @m_nQuizType and m_chState = 'T'
	order by TQ.m_nIndex
GO
/****** Object:  StoredProcedure [dbo].[usp_Quiz_Insert]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     proc [dbo].[usp_Quiz_Insert]

	@serverindex char(2), 
	@m_nQuizType int, 
	@m_nAnswer int, 
	@m_chState char(1), 
	@m_szQuestion varchar(1024),
	@m_Item int = Null,
	@m_ItemCount tinyint = Null,
	@m_Answer1 varchar(255) = '',
	@m_Answer2 varchar(255) = '',
	@m_Answer3 varchar(255) = '',
	@m_Answer4 varchar(255) = ''


/*
exec usp_Quiz_Insert '05', 1, 1, 'T', '????|??4?/??'
exec usp_Quiz_Insert '05', 1, 2, 'T', '????|??4?/???'
exec usp_Quiz_Insert '05', 2, 2, 'T', '????|??4?/??'
exec usp_Quiz_Insert '05', 2, 2, 'T', '????|??4?/???', '1. aa', '2. bb', '3. cc', '4. dd'
delete tblQuiz
delete tblQuizAnswer
select * from tblQuiz
select * from tblQuizAnswer
*/

as

set nocount on
set xact_abort on

	insert into tblQuiz(serverindex, m_nQuizType, m_nAnswer, m_chState, m_szQuestion, m_Item, m_ItemCount)
	select @serverindex, @m_nQuizType, @m_nAnswer, @m_chState, @m_szQuestion, @m_Item, @m_ItemCount 

if @m_nQuizType = 2 
	begin
		declare @m_nIndex int
		select @m_nIndex = max(m_nIndex) from tblQuiz (nolock)

		if 	@m_Answer1 = '' or @m_Answer2 = '' or @m_Answer3 = '' or @m_Answer4 = '' 
			begin
				set @m_Answer1 = '1'
				set @m_Answer2 = '2'
				set @m_Answer3 = '3'
				set @m_Answer4 = '4'
			end

		INSERT INTO tblQuizAnswer(m_nIndex, m_Answer1, m_Answer2, m_Answer3, m_Answer4)
		select @m_nIndex, @m_Answer1, @m_Answer2, @m_Answer3, @m_Answer4
	end
GO
/****** Object:  StoredProcedure [dbo].[usp_Quiz_Del]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
create proc [dbo].[usp_Quiz_Del]
	@serverindex char(2), 
	@m_nIndex int,
	@Gu  int = 0
as
set nocount on

if @Gu = 0

	update tblQuiz set m_chState = 'F'
	where serverindex = @serverindex and m_nIndex = @m_nIndex

else
	delete tblQuiz where serverindex = @serverindex and m_nIndex = @m_nIndex
GO
/****** Object:  StoredProcedure [dbo].[usp_Master_Update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_Master_Update]
@serverindex char(2),
@m_idPlayer char(7),
@sec tinyint,
@c01 int = 0, @c02 int = 0, @c03 int = 0, @c04 int = 0, @c05 int = 0,
@c06 int = 0, @c07 int = 0, @c08 int = 0, @c09 int = 0, @c10 int = 0,
@c11 int = 0, @c12 int = 0, @c13 int = 0, @c14 int = 0, @c15 int = 0,
@c16 int = 0, @c17 int = 0, @c18 int = 0, @c19 int = 0, @c20 int = 0,
@c21 int = 0, @c22 int = 0, @c23 int = 0, @c24 int = 0, @c25 int = 0,
@c26 int = 0, @c27 int = 0, @c28 int = 0, @c29 int = 0, @c30 int = 0,
@c31 int = 0, @c32 int = 0, @c33 int = 0, @c34 int = 0, @c35 int = 0,
@c36 int = 0, @c37 int = 0, @c38 int = 0, @c39 int = 0, @c40 int = 0,
@c41 int = 0, @c42 int = 0, @c43 int = 0, @c44 int = 0, @c45 int = 0,
@c46 int = 0, @c47 int = 0, @c48 int = 0, @c49 int = 0, @c50 int = 0
as
set nocount on
set xact_abort on

update tblMaster_all
set	c01 = @c01, c02 = @c02, c03 = @c03, c04 = @c04, c05 = @c05,
	c06 = @c06, c07 = @c07, c08 = @c08, c09 = @c09, c10 = @c10,
	c11 = @c11, c12 = @c12, c13 = @c13, c14 = @c14, c15 = @c15,
	c16 = @c16, c17 = @c17, c18 = @c18, c19 = @c19, c20 = @c20,
	c21 = @c21, c22 = @c22, c23 = @c23, c24 = @c24, c25 = @c25,
	c26 = @c26, c27 = @c27, c28 = @c28, c29 = @c29, c30 = @c30,
	c31 = @c31, c32 = @c32, c33 = @c33, c34 = @c34, c35 = @c35,
	c36 = @c36, c37 = @c37, c38 = @c38, c39 = @c39, c40 = @c40,
	c41 = @c41, c42 = @c42, c43 = @c43, c44 = @c44, c45 = @c45,
	c46 = @c46, c47 = @c47, c48 = @c48, c49 = @c49, c50 = @c50
where serverindex = @serverindex and m_idPlayer = @m_idPlayer and sec = @sec
GO
/****** Object:  StoredProcedure [dbo].[usp_Master_Select]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------------------------
create proc [dbo].[usp_Master_Select]
@serverindex char(2),
@m_idPlayer  char(7)
as
set nocount on

select 	serverindex, m_idPlayer, sec,
	c01, c02, c03, c04, c05, c06, c07, c08, c09, c10,
	c11, c12, c13, c14, c15, c16, c17, c18, c19, c20,
	c21, c22, c23, c24, c25, c26, c27, c28, c29, c30,
	c31, c32, c33, c34, c35, c36, c37, c38, c39, c40,
	c41, c42, c43, c44, c45, c46, c47, c48, c49, c50
from tblMaster_all with (nolock)
where serverindex = @serverindex and m_idPlayer = @m_idPlayer
order by sec
GO
/****** Object:  StoredProcedure [dbo].[uspAttendance]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE proc [dbo].[uspAttendance]

@serverindex char(2),
--@m_szName varchar(32)
@m_idPlayer char(7)

as

set nocount on

select master.dbo.dec2bin(dwEventFlag)
from CHARACTER_TBL
where serverindex = @serverindex and m_idPlayer = @m_idPlayer--m_szName = @m_szName
GO
/****** Object:  StoredProcedure [dbo].[uspAddPropose]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------
create proc [dbo].[uspAddPropose]
@nServer int,
@idProposer int,
@tPropose int
as
set nocount on

insert into tblPropose (nServer, idProposer, tPropose)
select @nServer, @idProposer, @tPropose
GO
/****** Object:  StoredProcedure [dbo].[uspAddNewCombat]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspAddNewCombat]
		@pCombatID		int,
		@pserverindex	char(2),
		@pComment		varchar(1000)=''
AS
SET NOCOUNT ON

	INSERT INTO tblCombatInfo(CombatID,serverindex,Status,StartDt,EndDt,Comment)
			VALUES (@pCombatID, @pserverindex, '10', NULL, NULL, @pComment)

	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END
	
	SELECT 1 as retValue
	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspAddMessenger]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[uspAddMessenger]
@serverindex	char(2),
@idPlayer		char(7),
@idFriend		char(7)
AS
SET NOCOUNT ON

	IF EXISTS(SELECT * FROM tblMessenger WHERE serverindex = @serverindex AND idPlayer = @idPlayer AND idFriend = @idFriend)
	BEGIN
		UPDATE tblMessenger SET chUse = 'T', bBlock = 0
		WHERE serverindex = @serverindex AND idPlayer = @idPlayer AND idFriend = @idFriend
	END
	ELSE
	BEGIN
		INSERT tblMessenger (serverindex, idPlayer, idFriend) VALUES (@serverindex, @idPlayer, @idFriend)
	END

	IF EXISTS(SELECT * FROM tblMessenger WHERE serverindex = @serverindex AND idPlayer = @idFriend AND idFriend = @idPlayer)
	BEGIN
		UPDATE tblMessenger SET chUse = 'T', bBlock = 0
		WHERE serverindex = @serverindex AND idPlayer = @idFriend AND idFriend = @idPlayer
	END
	ELSE
	BEGIN
		INSERT tblMessenger (serverindex, idPlayer, idFriend) VALUES (@serverindex, @idFriend, @idPlayer)
	END

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspAddLEComponent]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspAddLEComponent]

             @nServer            int,

             @idPlayer           int,

             @nTick               int,

             @fEFactor           float,

             @fIFactor             float

AS

SET NOCOUNT ON

             IF EXISTS ( SELECT * FROM tblLordEvent WHERE nServer = @nServer AND idPlayer = @idPlayer AND nTick > 0 )

                          BEGIN

                                       SELECT bResult = 0

                          END

             ELSE

                          BEGIN

                                       INSERT INTO tblLordEvent 

                                                    ( nServer, idPlayer, nTick, fEFactor, fIFactor )

                                       VALUES

                                                    ( @nServer, @idPlayer, @nTick, @fEFactor, @fIFactor )

                                       SELECT bResult = 1

                          END
GO
/****** Object:  StoredProcedure [dbo].[TAX_DETAIL_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TAX_DETAIL_STR]
@iGu char(2) = 'S2',
@serverindex char(2) = '01',
@nTimes int,
@nContinent int,
@nTaxKind int,
@nTaxRate int,
@nTaxCount int,
@nTaxGold int,
@nTaxPerin int,
@nNextTaxRate int
as

set nocount on

if @iGu = 'S2'
begin
	select nTaxKind, nTaxRate, nTaxCount, nTaxGold, nTaxPerin, nNextTaxRate
	from TAX_DETAIL_TBL
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent
end

if @iGu = 'I1'
begin
	insert into TAX_DETAIL_TBL (serverindex, nTimes, nContinent, nTaxKind, nTaxRate, nTaxCount, nTaxGold, nTaxPerin, nNextTaxRate)
	select @serverindex, @nTimes, @nContinent, @nTaxKind, @nTaxRate, @nTaxCount, @nTaxGold, @nTaxPerin, @nNextTaxRate
end

if @iGu = 'U1'
begin
	update TAX_DETAIL_TBL
	set nTaxRate = @nTaxRate, nTaxCount = @nTaxCount, nTaxGold = @nTaxGold, nTaxPerin = @nTaxPerin, nNextTaxRate = @nNextTaxRate
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent and nTaxKind = @nTaxKind
end
GO
/****** Object:  StoredProcedure [dbo].[uspChangeMultiServer]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE    PROCEDURE [dbo].[uspChangeMultiServer]
		@pserverindex 	char(2),
		@pidPlayer		char(7),
		@pMultiServer	char(1),
		@account varchar(32) = '',
		@aaa varchar(32) = '',
		@aab varchar(32) = ''
AS
SET NOCOUNT ON	
	UPDATE CHARACTER_TBL SET MultiServer = @pMultiServer WHERE m_idPlayer = @pidPlayer --and serverindex=@pserverindex
	SELECT @account = account FROM CHARACTER_TBL WHERE m_idPlayer=@pidPlayer and serverindex=@pserverindex
	SELECT @aaa = a.m_chLoginAuthority, @aab = c.m_chAuthority
	FROM CHARACTER_TBL c
	LEFT JOIN ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL a ON a.account = c.account
	WHERE m_idPlayer = @pidPlayer

	SET @aaa = ISNULL(@aaa, 'F')
	SET @aab = ISNULL(@aab, 'F')

	IF @aaa <> @aab
	BEGIN
		IF @aaa <> 'F'
		UPDATE CHARACTER_TBL SET m_chAuthority = @aaa WHERE m_idPlayer = @pidPlayer
	END
	
	IF @pMultiServer <> '0'
	BEGIN
		UPDATE ACCOUNT_DBF.dbo.ACCOUNT_TBL SET isuse = 'J' WHERE account = @account
		UPDATE ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL SET isuse = 'J' WHERE account = @account
	END
	ELSE
	BEGIN
		UPDATE ACCOUNT_DBF.dbo.ACCOUNT_TBL SET isuse = 'F' WHERE account = @account
		UPDATE ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL SET isuse = 'J' WHERE account = @account
	END

	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001
		RETURN
	END

	SELECT 1
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_Housing_Visit_Insert]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[usp_Housing_Visit_Insert]
@serverindex char(2),
@m_idPlayer char(7),
@f_idPlayer char(7)
as
set nocount on

insert into tblHousing_Visit (serverindex, m_idPlayer, f_idPlayer)
select @serverindex, @m_idPlayer, @f_idPlayer
GO
/****** Object:  StoredProcedure [dbo].[usp_Housing_Visit_Delete]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[usp_Housing_Visit_Delete]
@serverindex char(2),
@m_idPlayer char(7),
@f_idPlayer char(7)
as
set nocount on

delete tblHousing_Visit
where serverindex = @serverindex and m_idPlayer = @m_idPlayer and f_idPlayer = @f_idPlayer
GO
/****** Object:  StoredProcedure [dbo].[usp_Housing_Update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[usp_Housing_Update]
@serverindex char(2),
@m_idPlayer char(7),
@ItemIndex int,
@bSetup int,
@x_Pos float,
@y_Pos float,
@z_Pos float,
@fAngle float
as
set nocount on
set xact_abort on

update tblHousing
set bSetup = @bSetup, x_Pos = @x_Pos, y_Pos = @y_Pos, z_Pos = @z_Pos, fAngle = @fAngle
where serverindex = @serverindex and m_idPlayer = @m_idPlayer and ItemIndex = @ItemIndex and bSetup <> 99
GO
/****** Object:  StoredProcedure [dbo].[usp_Housing_Load]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[usp_Housing_Load]
@serverindex char(2),
@m_idPlayer char(7)
as
set nocount on

select serverindex, m_idPlayer, ItemIndex, tKeepTime, bSetup, x_Pos, y_Pos, z_Pos, fAngle, Start_Time, End_Time
from tblHousing with (nolock)
where serverindex = @serverindex and m_idPlayer = @m_idPlayer and bSetup <> 99

select serverindex, m_idPlayer, f_idPlayer
from tblHousing_Visit with (nolock)
where serverindex = @serverindex and m_idPlayer = @m_idPlayer
GO
/****** Object:  StoredProcedure [dbo].[usp_Housing_Insert]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[usp_Housing_Insert]
@serverindex char(2),
@m_idPlayer char(7),
@ItemIndex int,
@tKeepTime bigint
as
set nocount on
set xact_abort on

insert into tblHousing (serverindex, m_idPlayer, ItemIndex, tKeepTime)
select @serverindex, @m_idPlayer, @ItemIndex, @tKeepTime
GO
/****** Object:  StoredProcedure [dbo].[usp_Housing_Del]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------------------------------
create proc [dbo].[usp_Housing_Del]
@serverindex char(2),
@m_idPlayer char(7),
@ItemIndex int
as
set nocount on
set xact_abort on

update tblHousing
set bSetup = 99, End_Time = getdate()
where serverindex = @serverindex and m_idPlayer = @m_idPlayer and ItemIndex = @ItemIndex and bSetup <> 99
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildHouse_Update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_GuildHouse_Update    Script Date: 2009-12-01 ?? 2:41:44 ******/




/*============================================================
1. ??? : ???
2. ??? : 2009.11.23
3. ???? ? : usp_GuildHouse_Update
4. ???? ?? : ?? ??? ????
5. ????
	@serverindex char(2)	???
	@m_idGuild char(6)		?? ID
	@dwWorldId int			World ID
	@tKeepTime int			?? ??? ?? ????
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_GuildHouse_Update '05', '123456', 240, 150
9. ?? ? ident ? ???
	select * from tblGuildHouse
	delete tblGuildHouse
============================================================*/

CREATE  proc [dbo].[usp_GuildHouse_Update]
	@serverindex char(2),
	@m_idGuild char(6), 
	@tKeepTime int
as

set nocount on
set xact_abort on

	if exists ( select * from tblGuildHouse (nolock) where serverindex = @serverindex and m_idGuild = @m_idGuild)
	begin
		update tblGuildHouse
		set tKeepTime = @tKeepTime
		where serverindex = @serverindex and m_idGuild = @m_idGuild
	end
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildHouse_MaxSEQ]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_GuildHouse_MaxSEQ    Script Date: 2009-12-01 ?? 2:41:44 ******/






/*============================================================  
1. ??? : ???  
2. ??? : 2009.11.23  
3. ???? ? : usp_GuildHouse_MaxSEQ  
4. ???? ?? : ?? ?? MAX SEQ ? ??
5. ????  
 @serverindex char(2)   ???  
6. ???    
SEQ
7. ?? ??  
8. ?? ?? ??  
    EXEC usp_GuildHouse_MaxSEQ '75'
9. ?? ? ident ? ???  
 select * from tblGuildHouse  
 delete tblGuildHouse  
============================================================*/  
  
CREATE     proc [dbo].[usp_GuildHouse_MaxSEQ]
	@serverindex char(2)
as  
  
set nocount on  
set xact_abort on  

declare @CHR_MAX int, @LOGGING_MAX int 
	
	select @CHR_MAX = max(SEQ) from tblGuildHouse_Furniture (nolock)
	select @LOGGING_MAX = max(SEQ) from LOGGING_01_DBF.dbo.tblGuildHouse_FurnitureLog

	if @CHR_MAX > @LOGGING_MAX 
		select @CHR_MAX as SEQ
	else if @CHR_MAX < @LOGGING_MAX 
		select @LOGGING_MAX as SEQ
	else
		select @CHR_MAX
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildHouse_Load]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_GuildHouse_Load    Script Date: 2009-12-01 ?? 2:41:44 ******/


/*============================================================
1. ??? : ???
2. ??? : 2009.11.23
3. ???? ? : usp_GuildHouse_Load
4. ???? ?? : ?? ??? ??
5. ????
	@serverindex	char(2)		: ???
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_GuildHouse_Load '75'
9. ?? ? ident ? ???
	select * from tblGuildHouse
	delete tblGuildHouse
============================================================*/

CREATE       proc [dbo].[usp_GuildHouse_Load]

	@serverindex char(2)

as

set nocount on
set xact_abort on

	select serverindex, m_idGuild, dwWorldID, tKeepTime from tblGuildHouse (nolock)
	where serverindex = @serverindex
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildHouse_Insert]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_GuildHouse_Insert    Script Date: 2009-12-01 ?? 2:41:44 ******/




/*============================================================
1. ??? : ???
2. ??? : 2009.11.23
3. ???? ? : usp_GuildHouse_Insert
4. ???? ?? : ?? ??? ??
5. ????
	@serverindex char(2)	???
	@m_idGuild char(6)		?? ID
	@dwWorldId int			World ID
	@tKeepTime int			?? ??? ?? ????
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_GuildHouse_Insert '01', '000001', 240, 150
9. ?? ? ident ? ???
	select * from tblGuildHouse
	delete tblGuildHouse
============================================================*/

CREATE  proc [dbo].[usp_GuildHouse_Insert]
	@serverindex char(2),
	@m_idGuild char(6), 
	@dwWorldId int, 
	@tKeepTime int
as

set nocount on
set xact_abort on

	declare @m_szGuild varchar(16)


	select @m_szGuild = m_szGuild from GUILD_TBL (nolock)
	where m_idGuild = @m_idGuild and serverindex = @serverindex

	INSERT INTO tblGuildHouse (serverindex, m_idGuild, dwWorldID, tKeepTime, m_szGuild)
	select @serverindex, @m_idGuild, @dwWorldId, @tKeepTime, @m_szGuild

	insert into LOGGING_01_DBF.dbo.tblGuildHouseLog (serverindex, m_idGuild, dwWorldID, tKeepTime, m_szGuild)
	select @serverindex, @m_idGuild, @dwWorldId, @tKeepTime, @m_szGuild
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildHouse_Expired]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_GuildHouse_Expired    Script Date: 2009-12-01 ?? 2:41:44 ******/





/*============================================================
1. ??? : ???
2. ??? : 2009.11.23
3. ???? ? : usp_GuildHouse_Expired
4. ???? ?? : ?? ??? ??
5. ????
	@serverindex char(2)	???
	@m_idGuild char(6)		?? ID
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_GuildHouse_Expired '05', '123456'
9. ?? ? ident ? ???
	select * from tblGuildHouse
	delete tblGuildHouse
============================================================*/

CREATE   proc [dbo].[usp_GuildHouse_Expired]
	@serverindex char(2),
	@m_idGuild char(6)
as

set nocount on
set xact_abort on

	if exists ( select * from tblGuildHouse (nolock) where serverindex = @serverindex and m_idGuild = @m_idGuild)
	begin
		update tblGuildHouse
		set tKeepTime = 0
		where serverindex = @serverindex and m_idGuild = @m_idGuild

		update tblGuildHouse_Furniture
		set bSetup = 0
		where serverindex = @serverindex and m_idGuild = @m_idGuild
	end
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildHouse_Delete]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================    
1. ??? : ???    
2. ??? : 2009.11.23    
3. ???? ? : usp_GuildHouse_Delete    
4. ???? ?? : ?? ??? ??    
5. ????    
 @serverindex char(2) ???    
 @m_idGuild char(6)  ?? ID    
6. ???      
7. ?? ??    
8. ?? ?? ??    
    EXEC usp_GuildHouse_Delete '05', '123456'    
9. ?? ? ident ? ???    
 select * from tblGuildHouse    
 delete tblGuildHouse    
============================================================*/    
    
CREATE         proc [dbo].[usp_GuildHouse_Delete]    
 @serverindex char(2),    
 @m_idGuild char(6)    
as    
    
set nocount on    
set xact_abort on    
    
if exists ( select * from tblGuildHouse where serverindex = @serverindex and m_idGuild = @m_idGuild)    
 begin     
 if exists (select * from tblGuildHouse_Furniture (nolock) where serverindex = @serverindex and m_idGuild = @m_idGuild)    
  begin    
   exec usp_GuildFurniture_Log @serverindex, @m_idGuild    
     
   delete tblGuildHouse_Furniture    
   where serverindex = @serverindex and m_idGuild = @m_idGuild    
  end    
  
  exec usp_GuildHouse_Log  @serverindex, @m_idGuild    
  
  delete tblGuildHouse     
  where serverindex = @serverindex and m_idGuild = @m_idGuild    
 end
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildFurniture_Update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_GuildFurniture_Update    Script Date: 2009-12-01 ?? 2:41:44 ******/



/*============================================================
1. ??? : ???
2. ??? : 2009.11.23
3. ???? ? : usp_GuildFurniture_Update
4. ???? ?? : ?? ?? ??
5. ????
	@serverindex char(2)		???
	@m_idGuild char(6)			??ID
	@ItemIndex int				??? ID
	@tKeepTime int				??? ????
6. ??? 	
	SEQ int						?? SEQ ??
7. ?? ??
8. ?? ?? ??
	exec usp_GuildHouse_Insert '01', '123456', 240, 30
    EXEC usp_GuildFurniture_Update '01', '123456', 12345, 30
9. ?? ? ident ? ???
	select * from tblGuildHouse_Furniture
	delete tblGuildHouse_Furniture
	dbcc CHECKIDENT ( 'tblGuildHouse_Furniture', reseed, 0)
============================================================*/

create proc [dbo].[usp_GuildFurniture_Update]
	@serverindex char(2), 
	@m_idGuild char(6), 
	@SEQ int, 
	@ItemIndex int, 
	@bSetup float, 
	@x_Pos float,  
	@y_Pos float, 
	@z_Pos float, 
	@fAngle float, 
	@tKeepTime int
as

set nocount on
set xact_abort on

	if exists ( select * from tblGuildHouse_Furniture (nolock) where serverindex = @serverindex and m_idGuild = @m_idGuild and SEQ = @SEQ)
	begin
		update tblGuildHouse_Furniture 
		set bSetup = @bSetup, x_Pos = @x_Pos, y_Pos = @y_Pos, z_Pos = @z_Pos, fAngle = @fAngle, tKeepTime = @tKeepTime
		where serverindex = @serverindex and m_idGuild = @m_idGuild and SEQ = @SEQ
	end
GO
/****** Object:  StoredProcedure [dbo].[usp_Campus_Load]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_Campus_Load    Script Date: 2009-12-01 ?? 2:41:44 ******/





/*============================================================
1. ??? : ???
2. ??? : 2009.11.20
3. ???? ? : usp_Campus_Load
4. ???? ?? : ?? ??? ?? 
5. ????
	@serverindex	char(2)		: ???
6. ??? 	
	idCampus			: ?? ID
	serverindex			: ???
7. ?? ??
8. ?? ?? ??
    EXEC usp_Campus_Load '05'
9. ?? ? ident ? ???
	select * from tblCampus
	delete tblCampus
============================================================*/

CREATE   proc [dbo].[usp_Campus_Load] 

	@serverindex char(2)

as
set nocount on

	select idCampus, serverindex from tblCampus (nolock)
	where serverindex = @serverindex
GO
/****** Object:  StoredProcedure [dbo].[usp_Campus_Insert]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_Campus_Insert    Script Date: 2009-12-01 ?? 2:41:44 ******/


/*============================================================
1. ??? : ???
2. ??? : 2009.11.20
3. ???? ? : usp_Campus_Insert
4. ???? ?? : ?? ??? ??
5. ????
	@idCampus		int			: ?? ID
	@serverindex	char(2)		: ???
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_Campus_Insert 123, '05'
9. ?? ? ident ? ???
	select * from tblCampus
	delete tblCampus
============================================================*/

CREATE       proc [dbo].[usp_Campus_Insert]

	@idCampus int, 
	@serverindex char(2)

as

set nocount on
set xact_abort on

	insert into tblCampus(idCampus, serverindex)
	select @idCampus, @serverindex
GO
/****** Object:  StoredProcedure [dbo].[usp_Campus_Delete]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_Campus_Delete    Script Date: 2009-12-01 ?? 2:41:44 ******/


/*============================================================
1. ??? : ???
2. ??? : 2009.11.20
3. ???? ? : usp_Campus_Delete
4. ???? ?? : ?? ??? ??
5. ????
	@idCampus		int			: ?? ID
	@serverindex	char(2)		: ???
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_Campus_Delete 123, '05'
9. ?? ? ident ? ???
	select * from tblCampus
	delete tblCampus
============================================================*/

CREATE       proc [dbo].[usp_Campus_Delete]

	@idCampus int, 
	@serverindex char(2)

as

set nocount on
set xact_abort on

	delete tblCampus where idCampus = @idCampus and serverindex = @serverindex
GO
/****** Object:  StoredProcedure [dbo].[usp_bbb_seed]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_bbb_seed]

@serverindex char(2),
@lpenya int,
@hpenya int

as

set nocount on

SELECT a.m_nLevel as m_nLevel, a.m_szName as m_szName, cast(a.m_dwGold as bigint) + cast(b.m_dwGoldBank as bigint) as total,
       a.m_dwGold as m_dwGold, b.m_dwGoldBank as m_dwGoldBank
FROM   CHARACTER_TBL a, BANK_TBL b
WHERE  a.serverindex = @serverindex
	AND    cast(a.m_dwGold as bigint) + cast(b.m_dwGoldBank as bigint) >= @lpenya AND cast(a.m_dwGold as bigint) + cast(b.m_dwGoldBank as bigint) <= @hpenya
	AND    a.serverindex = b.serverindex AND a.m_idPlayer = b.m_idPlayer
	AND    a.account not in ( SELECT account 
				FROM   ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL 
				WHERE  m_chLoginAuthority <> 'F' ) 
ORDER BY cast(a.m_dwGold as bigint) + cast(b.m_dwGoldBank as bigint) DESC
GO
/****** Object:  StoredProcedure [dbo].[usp_bbb_level]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_bbb_level]

@serverindex char(2),
@llevel int,
@hlevel int

as

set nocount on

SELECT a.m_nLevel as m_nLevel, a.m_szName as m_szName, cast(a.m_dwGold as bigint) + cast(b.m_dwGoldBank as bigint) as total,
       a.m_dwGold as m_dwGold, b.m_dwGoldBank as m_dwGoldBank
FROM   CHARACTER_TBL a, BANK_TBL b
WHERE  a.serverindex = @serverindex
	AND    a.m_nLevel >= @llevel AND a.m_nLevel <= @hlevel
	AND    a.serverindex = b.serverindex AND a.m_idPlayer = b.m_idPlayer
	AND    a.account not in ( SELECT account 
				FROM   ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL 
				WHERE  m_chLoginAuthority <> 'F' ) 
ORDER BY a.m_nLevel DESC
GO
/****** Object:  StoredProcedure [dbo].[usp_BankPW_Check]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.12.10
3. ???? ? : usp_BankPW_Check
4. ???? ?? : BANK ???? ?? 
5. ????
	@serverindex	char(2)		: ???
	@m_idPlayer		char(7)		: ??? ID
	@BankPW			char(4)		: Bank PW
6. ??? 	
	f_check			: 0 - ??, 1 - ???
7. ?? ??
8. ?? ?? ??
    EXEC usp_BankPW_Check '75', '1452296', '0001'
9. ?? ? ident ? ???
	select * from BANK_TBL
============================================================*/

create    proc [dbo].[usp_BankPW_Check] 

	@serverindex char(2),
	@m_idPlayer char(7),
	@BankPW char(4)

as
set nocount on

	declare @c_BankPW char(4)
	select @c_BankPW = m_BankPw from BANK_TBL (nolock)
	where serverindex = @serverindex and m_idPlayer = @m_idPlayer

	if @c_BankPW = @BankPW
		select f_check = 0
	else
		select f_check = 1
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildFurniture_Load]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_GuildFurniture_Load    Script Date: 2009-12-01 ?? 2:41:44 ******/



/*============================================================
1. ??? : ???
2. ??? : 2009.11.23
3. ???? ? : usp_GuildFurniture_Load
4. ???? ?? : ?? ?? ??
5. ????
	@serverindex	char(2)		: ???
	@m_idGuild		char(6)		: ?? ID
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_GuildFurniture_Load '05', '123456'
9. ?? ? ident ? ???
	select * from tblGuildHouse_Furniture
	delete tblGuildHouse_Furniture
============================================================*/

create proc [dbo].[usp_GuildFurniture_Load]

	@serverindex char(2),
	@m_idGuild char(6)

as

set nocount on
set xact_abort on

	select serverindex, m_idGuild, SEQ, ItemIndex, bSetup, x_Pos, y_Pos, z_Pos, fAngle, tKeepTime 
		from tblGuildHouse_Furniture (nolock)
		where serverindex = @serverindex and m_idGuild = @m_idGuild
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildFurniture_Insert]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.usp_GuildFurniture_Insert    Script Date: 2009-12-01 ?? 2:41:44 ******/
/*============================================================    
1. ??? : ???    
2. ??? : 2009.11.23    
3. ???? ? : usp_GuildFurniture_Insert    
4. ???? ?? : ?? ?? ??    
5. ????    
 @serverindex char(2)  ???    
 @m_idGuild char(6)   ??ID    
 @ItemIndex int    ??? ID    
 @tKeepTime int    ??? ????    
6. ???      
 SEQ int      ?? SEQ ??    
7. ?? ??    
8. ?? ?? ??    
 exec usp_GuildHouse_Insert '01', '123456', 240, 30    
    EXEC usp_GuildFurniture_Insert '01', '123456', 3, 12345, 30    
9. ?? ? ident ? ???    
 select * from tblGuildHouse_Furniture    
 delete tblGuildHouse_Furniture    
============================================================*/    
    
CREATE proc [dbo].[usp_GuildFurniture_Insert]    
	@serverindex char(2),     
	@m_idGuild char(6),     
	@SEQ int,
	@ItemIndex int,     
	@tKeepTime int,  
	@bSetup float = 0,     
	@x_Pos float = 0,      
	@y_Pos float = 0,     
	@z_Pos float = 0,     
	@fAngle float = 0     
  
as    
    
set nocount on    
set xact_abort on    
    
    
 insert into tblGuildHouse_Furniture (serverindex, m_idGuild, SEQ, ItemIndex, tKeepTime, bSetup, x_Pos, y_Pos, z_Pos, fAngle)    
 select @serverindex, @m_idGuild, @SEQ, @ItemIndex, @tKeepTime, @bSetup, @x_Pos, @y_Pos, @z_Pos, @fAngle
GO
/****** Object:  StoredProcedure [dbo].[usp_GuildFurniture_Delete]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================  
1. ??? : ???  
2. ??? : 2009.11.23  
3. ???? ? : usp_GuildFurniture_Delete  
4. ???? ?? : ?? ?? ??  
5. ????  
 @serverindex char(2)  : ???  
 @m_idGuild  char(6)  : ?? ID  
6. ???    
7. ?? ??  
8. ?? ?? ??  
    EXEC usp_GuildFurniture_Delete '05', '123456'  
9. ?? ? ident ? ???  
 select * from tblGuildHouse_Furniture_Furniture  
 delete tblGuildHouse_Furniture_Furniture  
============================================================*/  
  
CREATE   proc [dbo].[usp_GuildFurniture_Delete]  
	@serverindex char(2),  
	@m_idGuild char(6),  
	@SEQ int  
as  
  
set nocount on  
set xact_abort on  

	if exists ( select * from tblGuildHouse_Furniture (nolock) where serverindex = @serverindex and m_idGuild = @m_idGuild and SEQ = @SEQ)  
	begin   
		exec usp_GuildFurniture_Log @serverindex, @m_idGuild, @SEQ

		delete tblGuildHouse_Furniture  
		where serverindex = @serverindex and m_idGuild = @m_idGuild and SEQ = @SEQ  
	end
GO
/****** Object:  StoredProcedure [dbo].[usp_Guild_Combat_1to1_Tender]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  proc [dbo].[usp_Guild_Combat_1to1_Tender]
@serverindex char(2),
@combatID int,
@m_idGuild char(6),
@m_nPenya int,
@State char(1),
@iGu char(2)
as
set nocount on
set xact_abort on

if @iGu = 'I1'
begin
	insert into GUILD_COMBAT_1TO1_TENDER_TBL(serverindex, combatID, m_idGuild, m_nPenya, State)
	select @serverindex, @combatID, @m_idGuild, @m_nPenya, @State
end

-- T : ?? ? ?? ??
-- F : ?? ??
-- C : ?? ??
-- E : ?? ??
-- G : ?? ?? ?? ??? ?? ??
-- N : ?? ?? ?? ??? ?? ?? ?? 1:1???? ??
if @iGu = 'U1'
begin
	if @State = 'F' or @State = 'C' or @State = 'E'
	begin
		update GUILD_COMBAT_1TO1_TENDER_TBL
		set m_nPenya = @m_nPenya, State = @State, s_date = getdate()
		where serverindex = @serverindex and combatID = @combatID and m_idGuild = @m_idGuild and State = 'T'
	end
	else if @State ='N' or @State = 'G'
	begin
		update GUILD_COMBAT_1TO1_TENDER_TBL
		set m_nPenya = @m_nPenya, State = @State, s_date = getdate()
		where serverindex = @serverindex and m_idGuild = @m_idGuild and State = 'F'
	end
	else
	begin
		update GUILD_COMBAT_1TO1_TENDER_TBL
		set m_nPenya = @m_nPenya, State = @State, s_date = getdate()
		where serverindex = @serverindex and combatID = @combatID and m_idGuild = @m_idGuild
	end
end

-- ?? ?? ??
if @iGu = 'S1'
begin
	select m_idGuild, m_nPenya
	from GUILD_COMBAT_1TO1_TENDER_TBL
	where serverindex = @serverindex and combatID = @combatID and State = 'T'
	order by m_nPenya desc, s_date asc
end

-- ?? ?? ?? ??
if @iGu = 'S2'
begin
	select m_idGuild, m_nPenya
	from GUILD_COMBAT_1TO1_TENDER_TBL
	where serverindex = @serverindex and State = 'F'
--	where combatID in (select max(combatID), (max(combatID) - 1) from GUILD_COMBAT_1TO1_TENDER_TBL where State = 'F') and State = 'F'
	order by m_nPenya desc
end
GO
/****** Object:  StoredProcedure [dbo].[usp_Guild_Combat_1to1_CombatID]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_Guild_Combat_1to1_CombatID]
@serverindex char(2)
as
set nocount on

if not exists (select * from GUILD_COMBAT_1TO1_TENDER_TBL where serverindex = @serverindex)
begin
	select 0 as combatID
end
else
begin
	select max(combatID) as combatID
	from GUILD_COMBAT_1TO1_TENDER_TBL
	where serverindex = @serverindex
end
GO
/****** Object:  StoredProcedure [dbo].[usp_Guild_Combat_1to1_Battle_Person]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_Guild_Combat_1to1_Battle_Person]
@serverindex char(2),
@combatID int,
@m_idGuild char(6),
@m_idPlayer char(7),
@m_nSeq int,
@State char(1),
@iGu char(2)
as
set nocount on
set xact_abort on

if @iGu = 'I1'
begin
	insert into GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL (serverindex, combatID, m_idGuild, m_idPlayer, m_nSeq, State)
	select @serverindex, @combatID, @m_idGuild, @m_idPlayer, @m_nSeq, @State
end

if @iGu = 'U1'
begin
	if @State = 'N'
	begin
		update GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL
		set Start_Time = getdate(), State = @State
		where serverindex = @serverindex and combatID = @combatID and m_idGuild = @m_idGuild and m_idPlayer = @m_idPlayer
	end
	else
	begin
		update GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL
		set End_Time = getdate(), State = @State
		where serverindex = @serverindex and combatID = @combatID and m_idGuild = @m_idGuild and m_idPlayer = @m_idPlayer
	end
end

if @iGu = 'S1'
begin
	select m_idPlayer
	from GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL
	where serverindex = @serverindex and combatID = @combatID and m_idGuild = @m_idGuild
	order by m_nSeq
end

if @iGu = 'D1'
begin
	delete from GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL
	where serverindex = @serverindex and combatID = @combatID and m_idGuild = @m_idGuild
end
GO
/****** Object:  StoredProcedure [dbo].[usp_Guild_Combat_1to1_Battle]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[usp_Guild_Combat_1to1_Battle]
@serverindex char(2),
@combatID int,
@m_idWorld int,
@m_idGuild_1st char(6),
@m_idGuild_2nd char(6),
@State char(1),
@iGu char(2)
as
set nocount on
set xact_abort on

if @iGu = 'I1'
begin
	delete from GUILD_COMBAT_1TO1_BATTLE_TBL
	where serverindex = @serverindex and combatID = @combatID and m_idWorld = @m_idWorld

	insert into GUILD_COMBAT_1TO1_BATTLE_TBL(serverindex, combatID, m_idWorld, m_idGuild_1st, m_idGuild_2nd, State)
	select @serverindex, @combatID, @m_idWorld, @m_idGuild_1st, @m_idGuild_2nd, @State
end

if @iGu = 'U1'
begin
	update GUILD_COMBAT_1TO1_BATTLE_TBL
	set End_Time = getdate(), State = @State
	where serverindex = @serverindex and combatID = @combatID and m_idWorld = @m_idWorld
end
GO
/****** Object:  StoredProcedure [dbo].[usp_FunnyCoin_update]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_FunnyCoin_update]
@fcid int
as
set nocount on
set xact_abort on

begin tran
update tblFunnyCoin
set ItemFlag = 1, f_date = getdate()
where fcid = @fcid

if @@error <> 0
begin
	rollback tran
	select -1 as 'result_code'
end
else
begin
	commit tran
	select 1 as 'result_code'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_FunnyCoin_input_NoResult]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[usp_FunnyCoin_input_NoResult]
@serverindex char(2),
@m_idPlayer char(7),
@Item_Name int,
@Item_Cash int,
@Item_UniqueNo bigint
--with encryption
as
set nocount on

/*if exists (select * from tblFunnyCoin where Item_UniqueNo = @Item_UniqueNo)
begin
	select -2 as 'result'
	return
end
*/
begin tran
declare @s_date datetime, @account varchar(32)
select @s_date = getdate(), @account = account
from CHARACTER_TBL (nolock)
where serverindex = @serverindex and m_idPlayer = @m_idPlayer

insert into tblFunnyCoin (account, serverindex, m_idPlayer, Item_Name, Item_Cash, Item_UniqueNo, s_date, fid)
select @account, @serverindex, @m_idPlayer, @Item_Name, @Item_Cash, @Item_UniqueNo, @s_date, dbo.fn_FC(@m_idPlayer, @Item_Cash, @Item_UniqueNo, @s_date)

if @@error <> 0
begin
	rollback tran
	--select -1 as 'result'
end
else
begin
	commit tran
	--select 1 as 'result'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_FunnyCoin_input]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_FunnyCoin_input]
@serverindex char(2),
@m_idPlayer char(7),
@Item_Name int,
@Item_Cash int,
@Item_UniqueNo bigint
--with encryption
as
set nocount on

begin tran
declare @s_date datetime, @account varchar(32)
select @s_date = getdate(), @account = account
from CHARACTER_TBL (nolock)
where serverindex = @serverindex and m_idPlayer = @m_idPlayer

insert into tblFunnyCoin (account, serverindex, m_idPlayer, Item_Name, Item_Cash, Item_UniqueNo, s_date, fid)
select @account, @serverindex, @m_idPlayer, @Item_Name, @Item_Cash, @Item_UniqueNo, @s_date, dbo.fn_FC(@m_idPlayer, @Item_Cash, @Item_UniqueNo, @s_date)

if @@error <> 0
begin
	rollback tran
	select -1 as 'result'
end
else
begin
	commit tran
	select 1 as 'result'
end
GO
/****** Object:  StoredProcedure [dbo].[MESSENGER_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE   Procedure [dbo].[MESSENGER_STR]
	@iGu         			char(2)		= 'S1', 
	@im_idPlayer 			char(7)		= '0000001',
	@iserverindex  			char(2)		= '01',
	@if_idPlayer 			char(7)		=	'',
	@im_dwSex 				int			= 0,
	@im_nJob				int			= 0,
	@iState 				char(1)		='',
	@im_dwState				int			= 0
AS
SET NOCOUNT ON

	DECLARE	@sql	nvarchar(4000)
	SET	@sql=''
	
	IF	@iGu = 'A1'
		BEGIN
			IF EXISTS(SELECT * FROM  MESSENGER_TBL  WHERE m_idPlayer = @im_idPlayer  AND serverindex = @iserverindex  AND f_idPlayer = @if_idPlayer)
			UPDATE MESSENGER_TBL
				SET State = 'T',
						m_dwState = @im_dwState
			WHERE m_idPlayer = @im_idPlayer
				AND serverindex = @iserverindex
				AND f_idPlayer = @if_idPlayer
			ELSE
			INSERT MESSENGER_TBL
				(m_idPlayer,serverindex,f_idPlayer,m_nJob,m_dwSex,m_dwState,State,CreateTime)
			VALUES
				(@im_idPlayer,@iserverindex,@if_idPlayer,@im_nJob,@im_dwSex,0,'T',GETDATE())	
			RETURN
		END
	/*
		
		??? ?? ????
		ex ) 
		MESSENGER_STR 'A1',@im_idPlayer,@iserverindex,@if_idPlayer,@im_nJob,@im_dwSex
		MESSENGER_STR 'A1','000001','01','000002',1,1
	*/
	ELSE
	----------------------------------------
	--	??? ??? ????
	--	MESSENGER_STR 'S1','000001','01'
	IF @iGu = 'S1'	BEGIN
		SET @sql=N'
			EXEC uspLoadMessengerList @pserverindex, @pPlayerID
		'
		
		EXECUTE sp_executesql	@sql, 
								N'@pPlayerID char(7), @pserverindex char(2)', 
								@im_idPlayer, @iserverindex

		RETURN
	END
	----------------------------------------
	--	?? ??? ??? ??? ????
	--	MESSENGER_STR 'S2','000001','02'
	ELSE
	IF @iGu = 'S2'	BEGIN
		SET @sql=N'
			EXEC uspLoadMessengerListRegisterMe @pserverindex, @pPlayerID
		'
		
		EXECUTE sp_executesql	@sql, 
								N'@pPlayerID char(7), @pserverindex char(2)', 
								@im_idPlayer, @iserverindex

			RETURN
		END
	ELSE
	IF	@iGu = 'D1'
		BEGIN
			UPDATE MESSENGER_TBL
				SET State = 'D'
			WHERE m_idPlayer = @im_idPlayer
				AND serverindex = @iserverindex
				AND f_idPlayer = @if_idPlayer
				AND State = 'T'
			RETURN
		END
	ELSE
	IF @iGu = 'D2'
		BEGIN
			DELETE MESSENGER_TBL
			WHERE m_idPlayer NOT IN
			(SELECT m_idPlayer 
				FROM CHARACTER_TBL where serverindex = @iserverindex)
				and  serverindex = @iserverindex

			DELETE MESSENGER_TBL
			WHERE f_idPlayer NOT IN
			(SELECT m_idPlayer 
				FROM CHARACTER_TBL where serverindex = @iserverindex)
				and  serverindex = @iserverindex

			DELETE MESSENGER_TBL
			WHERE State = 'D'
			and  serverindex = @iserverindex
			RETURN
		END

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[MAKE_RANKING_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE        PROC [dbo].[MAKE_RANKING_STR]
@iserverindex CHAR(2) = '01'
AS
set nocount on
DECLARE @currDate char(10),@om_nCount INT,@of_nCount INT				
SET @currDate = CONVERT(CHAR(8),GETDATE(),112) 
						   + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
				--		   + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2)


--R1 : ????
--R2 : ???
--R3 : ???
--R4 : ?????
--R5 : ?????
--R6 : ????
--R7 : ????
--R8 : ?????

--SELECT * FROM RANKING_DBF.dbo.RANKING_TBL
--DELETE RANKING_DBF.dbo.RANKING_TBL
--R1 : ????

IF EXISTS(SELECT * FROM RANKING_DBF.dbo.RANKING_TBL WHERE s_date = @currDate and serverindex = @iserverindex)
BEGIN
	DELETE RANKING_DBF.dbo.RANKING_TBL WHERE s_date = @currDate and serverindex = @iserverindex
END

BEGIN
INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,
				m_szGuild,
				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)
SELECT TOP 20 Gu = 'R1',s_date = @currDate,-- m_Title = '????',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose)+	MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold),0),				
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
		AND A.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority ='F'
		AND C.account = D.account
  GROUP BY B.m_idGuild
ORDER BY m_nWinPoint DESC,m_nWin DESC



--R2 : ???

INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,
				m_szGuild,
				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)
SELECT TOP 20 Gu = 'R2',s_date = @currDate,--m_Title = '???',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose)+	MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold),0),				
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
       AND A.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority = 'F'
		AND C.account = D.account
  GROUP BY B.m_idGuild
ORDER BY m_nWin DESC,CreateTime

--R3 : ???

INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,

				m_szGuild,

				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)
SELECT TOP 20 Gu = 'R3',s_date = @currDate,-- m_Title = '???',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose)+	MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold),0),				
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
       AND A.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority = 'F'
		AND C.account = D.account
  GROUP BY B.m_idGuild
ORDER BY m_nLose DESC,m_nSurrender DESC

--R4 : ?????

INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,
				m_szGuild,
				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)
SELECT TOP 20 Gu = 'R4',s_date = @currDate,-- m_Title = '?????',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose)+	MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold),0),				
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
       AND A.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority = 'F'
		AND C.account = D.account
  GROUP BY B.m_idGuild
ORDER BY m_nSurrender DESC,m_nLose DESC

--R5 : ?????

INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,
				m_szGuild,
				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)
SELECT TOP 20 Gu = 'R5',s_date = @currDate,-- m_Title = '?????',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose)+	MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold),0),				
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
       AND A.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority = 'F'
		AND C.account = D.account
  GROUP BY B.m_idGuild
ORDER BY m_MaximumUnity DESC,CreateTime

--R6 : ????
INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,
				m_szGuild,
				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)

SELECT TOP 20 Gu = 'R6', s_date = @currDate,-- m_Title = '????',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose) + MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold + 4294967295),0),				
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
      	AND A.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority = 'F'
		AND C.account = D.account
	and A.m_nGuildGold > 0
  GROUP BY B.m_idGuild
order by m_nGuildGold desc, CreateTime
--R7 : ????

INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,
				m_szGuild,
				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)
SELECT TOP 20 Gu = 'R7',s_date = @currDate,-- m_Title = '????',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose)+	MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold),0),
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
       AND A.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority = 'F'
		AND C.account = D.account
  GROUP BY B.m_idGuild
ORDER BY m_AvgLevel DESC,CreateTime

--R8 : ?????

INSERT RANKING_DBF.dbo.RANKING_TBL
		(
				Gu,	s_date,
				serverindex,
				m_dwLogo,
				m_idGuild,
				m_szGuild,
				m_szName,
				m_nWin,
				m_nLose,
				m_nSurrender,
				m_MaximumUnity,
				m_AvgLevel,
				m_nGuildGold,
				m_nWinPoint,
				m_nPlayTime,
				CreateTime
		)
SELECT TOP 20 Gu = 'R8',s_date = @currDate,-- m_Title = '????',
				serverindex = MAX(A.serverindex),
				m_dwLogo = MAX(A.m_dwLogo),
				B.m_idGuild,
				m_szGuild = MAX(A.m_szGuild),
				m_szName = MAX(C.m_szName),
				m_nWin = MAX(A.m_nWin),
				m_nLose = MAX(A.m_nLose)+	MAX(A.m_nSurrender),
				m_nSurrender = MAX(A.m_nSurrender),
				m_MaximumUnity = CONVERT(REAL,MAX(A.m_nWin)-(COUNT(B.m_nSurrender)/MAX(A.m_nLevel))),
				m_AvgLevel = ISNULL(AVG(E.m_nLevel),0),
				m_nGuildGold = ISNULL(MAX(A.m_nGuildGold),0),
				m_nWinPoint = ISNULL(MAX(A.m_nWinPoint),0),
				m_nPlayTime = ISNULL(SUM(E.TotalPlayTime),0),
				CreateTime = MAX(A.CreateTime)
    FROM GUILD_TBL A,GUILD_MEMBER_TBL B,CHARACTER_TBL C,ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL D,CHARACTER_TBL E
  WHERE A.m_idGuild = B.m_idGuild
      	AND C.serverindex = E.serverindex
		AND C.m_idPlayer =  E.m_idPlayer
       AND B.m_nMemberLv = 0
       AND B.m_idPlayer = C.m_idPlayer
		AND A.serverindex = B.serverindex
		AND B.serverindex = C.serverindex
		AND C.serverindex = @iserverindex
		AND D.m_chLoginAuthority = 'F'
		AND C.account = D.account
  GROUP BY B.m_idGuild
ORDER BY m_nPlayTime DESC,CreateTime
END
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[make_quest_tbl_str]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   proc [dbo].[make_quest_tbl_str]
as
set nocount on
declare @m_lpQuestCntArray varchar(3072)
declare @pos_s int,@pos_e int,@property varchar(255)

declare @m_idPlayer char(7)
declare @serverindex char(2)

--declare quest_cursor cursor for
create table #temp (id int identity(1,1),m_idPlayer char(7),serverindex char(2),m_lpQuestCntArray varchar(3072))


insert #temp
(m_idPlayer,serverindex,m_lpQuestCntArray )
select m_idPlayer,serverindex,m_lpQuestCntArray 
from CHARACTER_TBL 
--where m_lpQuestCntArray <> '$'
order by m_idPlayer,serverindex

create unique clustered index temp_idx ON #temp(id)

-- open quest_cursor
-- 
-- fetch next from quest_cursor
-- into @m_idPlayer,@serverindex,@m_lpQuestCntArray

declare @i int,@j int 

select @i = 1
select @j = max(id) from #temp

while @i <= @j
		begin
					select @m_idPlayer = m_idPlayer ,@serverindex = serverindex,@m_lpQuestCntArray = m_lpQuestCntArray from #temp where id = @i
					if @m_lpQuestCntArray<> '' and @m_lpQuestCntArray <> '$' and @m_lpQuestCntArray is not null
							begin
								set @pos_s = 1
								set @pos_e = charindex('/',@m_lpQuestCntArray,@pos_s)
								declare @idx int
								while 1=1
									begin
										set @pos_e = charindex('/',@m_lpQuestCntArray,@pos_s)
										set @property = substring(@m_lpQuestCntArray,@pos_s,@pos_e-@pos_s)
										exec('insert  QUEST_TBL values(''' + @m_idPlayer + ''',''' + @serverindex + ''',' + @property + ')')
										--print (@i)
										set @pos_s =  @pos_e + 1
										if charindex('/',@m_lpQuestCntArray,@pos_s) = 0
										break
									end
							end
		
		
-- 		fetch next from quest_cursor
-- 		into @m_idPlayer,@serverindex,@m_lpQuestCntArray
			set @i = @i + 1
		end
-- close quest_cursor
-- deallocate quest_cursor

set nocount off
return
GO
/****** Object:  StoredProcedure [dbo].[MAIL_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[MAIL_STR]
	@iGu		CHAR(2),
	@nMail		INT,
	@serverindex	CHAR(2),
	@idReceiver	CHAR(7)	= '0000000',
	@idSender	CHAR(7)	= '0000000',
	@nGold		INT	= 0,
	@tmCreate	INT	= 0,
	@byRead	INT	= 0,
	@szTitle		VARCHAR(128)	= '',
	@szText		VARCHAR(1024)	= '',
	@dwItemId	INT	= 0,
	@nItemNum	INT	= 0,
	@nRepairNumber	INT	= 0,
	@nHitPoint	INT	= 0,
	@nMaxHitPoint	INT	= 0,
	@nMaterial	INT	= 0,
	@byFlag		INT	= 0,
	@dwSerialNumber	INT	= 0,
	@nOption	INT	= 0,
	@bItemResist	INT	= 0,
	@nResistAbilityOption	INT	= 0,
	@idGuild		INT	= 0,
	@nResistSMItemId	INT	= 0,
	@bCharged	INT	= 0,
	@dwKeepTime	INT	= 0,
	@nRandomOptItemId	BIGINT	= 0,
	@nPiercedSize	INT	= 0,
	@dwItemId1	INT	= 0,
	@dwItemId2	INT	= 0,
	@dwItemId3	INT	= 0,
	@dwItemId4	INT	= 0
	------------------- Version9 Pet
	,@bPet    int = 0,
	@nKind  int = 0,
	@nLevel int = 0,
	@dwExp              int = 0,
	@wEnergy          int = 0,
	@wLife   int = 0,
	@anAvailLevel_D int = 0, 
	@anAvailLevel_C int = 0,
	@anAvailLevel_B int = 0,
	@anAvailLevel_A int = 0,
	@anAvailLevel_S int = 0,

	@dwItemId5 int = 0
	---------------- ver.12
	,@dwItemId6 int = 0, @dwItemId7 int = 0, @dwItemId8 int = 0, @dwItemId9 int = 0, @dwItemId10 int = 0
	,@dwItemId11 int = 0, @dwItemId12 int = 0, @dwItemId13 int = 0, @dwItemId14 int = 0, @dwItemId15 int = 0
	,@nPiercedSize2 int = 0
	----------- Ver. 13
	, @szPetName varchar(32) = ''

AS
set nocount on
IF @iGu	= 'S1'
	BEGIN
		SELECT * FROM MAIL_TBL WHERE serverindex = @serverindex AND byRead<90 order by nMail
	RETURN
	END
ELSE
IF @iGu	= 'A1'
	BEGIN
		INSERT MAIL_TBL
			(
				nMail,
				serverindex,
				idReceiver,
				idSender,
				nGold,
				tmCreate,
				byRead,
				szTitle,
				szText,
				dwItemId,
				nItemNum,
				nRepairNumber,
				nHitPoint,
				nMaxHitPoint,
				nMaterial,
				byFlag,
				dwSerialNumber,
				nOption,
				bItemResist,
				nResistAbilityOption,
				idGuild,
				nResistSMItemId,
				bCharged,
				dwKeepTime,
				nRandomOptItemId,
				nPiercedSize,
				dwItemId1,
				dwItemId2,
				dwItemId3,
				dwItemId4,
				SendDt
				,bPet, nKind, nLevel, dwExp, wEnergy, wLife, anAvailLevel_D, anAvailLevel_C, anAvailLevel_B, anAvailLevel_A, anAvailLevel_S
				,dwItemId5
				, dwItemId6, dwItemId7, dwItemId8, dwItemId9, dwItemId10, dwItemId11
				, dwItemId12, dwItemId13, dwItemId14, dwItemId15, nPiercedSize2
				, szPetName
			)
			VALUES 
			(
				@nMail,
				@serverindex,
				@idReceiver,
				@idSender,
				@nGold,
				@tmCreate,
				@byRead,
				@szTitle,
				@szText,
				@dwItemId,
				@nItemNum,
				@nRepairNumber,
				@nHitPoint,
				@nMaxHitPoint,
				@nMaterial,
				@byFlag,
				@dwSerialNumber,
				@nOption,
				@bItemResist,
				@nResistAbilityOption,
				@idGuild,
				@nResistSMItemId,
				@bCharged,
				@dwKeepTime,
				@nRandomOptItemId,
				@nPiercedSize,
				@dwItemId1,
				@dwItemId2,
				@dwItemId3,
				@dwItemId4,
				getdate()
				,@bPet, @nKind, @nLevel, @dwExp, @wEnergy, @wLife, @anAvailLevel_D, @anAvailLevel_C, @anAvailLevel_B, @anAvailLevel_A, @anAvailLevel_S
				,@dwItemId5
				, @dwItemId6, @dwItemId7, @dwItemId8, @dwItemId9, @dwItemId10, @dwItemId11
				, @dwItemId12, @dwItemId13, @dwItemId14, @dwItemId15, @nPiercedSize2
				, @szPetName
			)
	RETURN
	END
IF @iGu	= 'D1'
	BEGIN
		UPDATE MAIL_TBL SET byRead=90, DeleteDt=getdate() WHERE nMail = @nMail AND serverindex = @serverindex
	RETURN
	END

if @iGu = 'D2'
begin
	UPDATE MAIL_TBL SET byRead=90, DeleteDt=getdate() WHERE serverindex = @serverindex AND tmCreate < @tmCreate
end

IF @iGu	= 'U1'
	BEGIN
		UPDATE MAIL_TBL SET 
			ItemFlag=90, ItemReceiveDt=getdate()
			WHERE nMail = @nMail AND serverindex = @serverindex
	RETURN
	END

IF @iGu	= 'U2'
	BEGIN
		UPDATE MAIL_TBL SET GoldFlag=90, GetGoldDt=getdate() WHERE nMail = @nMail AND serverindex = @serverindex
	RETURN
	END


IF @iGu	= 'U3'
	BEGIN
		UPDATE MAIL_TBL SET byRead = 1, ReadDt=getdate() WHERE nMail = @nMail AND serverindex = @serverindex
	RETURN
	END

set nocount off
GO
/****** Object:  StoredProcedure [dbo].[GUILD_VOTE_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE   PROC [dbo].[GUILD_VOTE_STR]
@iGu CHAR(2) ='S1',
@iserverindex CHAR(2) = '01',
@im_idGuild CHAR(6) = '000000',
@im_idVote INT = 0,
@im_szTitle VARCHAR(128) ='',
@im_szQuestion VARCHAR(255) = '',
@im_szString1 VARCHAR(32) = '',
@im_szString2 VARCHAR(32) = '',
@im_szString3 VARCHAR(32) = '',
@im_szString4 VARCHAR(32) = '',
@im_cbCount	INT = 0
AS
set nocount on
IF @iGu = 'S1'
	BEGIN
		SELECT 	m_idGuild,serverindex,m_idVote,m_cbStatus,m_szTitle,m_szQuestion,
						m_szString1,m_szString2,m_szString3,m_szString4,
						m_cbCount1,m_cbCount2,m_cbCount3,m_cbCount4
		   FROM GUILD_VOTE_TBL
		WHERE serverindex = @iserverindex
			  AND m_cbStatus IN ('1','2')
		ORDER BY m_idGuild,m_idVote DESC
	RETURN
	END

/*
	 GUILD ?? ?? ????
	 ex ) 
	 GUILD_VOTE_STR 'S1',	@iserverindex
	 GUILD_VOTE_STR 'S1',	'01'

*/
ELSE
IF @iGu = 'A1'
	BEGIN
		DECLARE @om_idVote INT,@oCount INT,@om_idVoteMin INT
	
		SELECT @om_idVote = ISNULL(MAX(m_idVote),0) + 1 
			FROM  GUILD_VOTE_TBL 
		 WHERE serverindex = @iserverindex
	
		SELECT @oCount = COUNT(m_idGuild),@om_idVoteMin = MIN(m_idVote) 
		   FROM GUILD_VOTE_TBL
		WHERE m_idGuild = @im_idGuild
			AND serverindex = @iserverindex
			AND m_cbStatus IN ('1','2')

		IF @oCount >= 20
		UPDATE GUILD_VOTE_TBL
			SET m_cbStatus = '3'
		WHERE m_idVote = @om_idVoteMin 
		    AND  m_idGuild = @im_idGuild
		

		INSERT GUILD_VOTE_TBL
		(
			m_idGuild,serverindex,m_idVote,m_cbStatus,m_szTitle,m_szQuestion,
			m_szString1,m_szString2,m_szString3,m_szString4,
			m_cbCount1,m_cbCount2,m_cbCount3,m_cbCount4,CreateTime
		)
		VALUES
		(
			@im_idGuild,@iserverindex,@om_idVote,'1',@im_szTitle,@im_szQuestion,
			@im_szString1,@im_szString2,@im_szString3,@im_szString4,
			0,0,0,0,GETDATE()
		)
		SELECT m_idVote  = @om_idVote 
	RETURN
	END
/*
	 GUILD ?? ????
	 ex ) 
	 GUILD_VOTE_STR 'A1',	@iserverindex,@im_idGuild,@im_idVote,@im_szTitle,@im_szQuestion,
												@im_szString1,@im_szString2,@im_szString3,@im_szString4

	 GUILD_VOTE_STR 'A1',	'01','000001',0,'??? ???','??? ????? ?????',
												'??','???','????',''

*/
ELSE
IF @iGu = 'U1'
	BEGIN
		IF EXISTS(SELECT * FROM GUILD_MEMBER_TBL WHERE m_idPlayer= @im_idGuild AND serverindex = @iserverindex  AND m_idVote = @im_idVote)
			SELECT n_Error = '2',f_Text = '?? ???????.'
		ELSE
			BEGIN
			DECLARE @om_cbCount CHAR(1)
			SET @om_cbCount =  CONVERT(CHAR(1),@im_cbCount)
			EXEC('
			UPDATE GUILD_VOTE_TBL 
				SET m_cbCount ' + @om_cbCount + ' =  m_cbCount' + @om_cbCount +  ' + 1
			WHERE m_idVote = + ' + @im_idVote + '
			UPDATE GUILD_MEMBER_TBL
				SET m_idVote = ''' + @im_idVote + ''' 
			WHERE m_idPlayer= ''' + @im_idGuild + '''
			     AND serverindex = ''' + @iserverindex  + ''''
			)
			SELECT n_Error = '1',f_Text = 'OK.'
			END
	RETURN
	END
/*
	 GUILD ?? ??
	 ex ) 
	 GUILD_VOTE_STR 'U1',	@iserverindex,@im_idGuild,@im_idVote,@im_szTitle,@im_szQuestion,
												@im_szString1,@im_szString2,@im_szString3,@im_szString4,
												@im_cbCount
	 GUILD_VOTE_STR 'U1',	'01','000001',0,'??? ???','??? ????? ?????',
												'??','???','????','',
												0

*/
IF @iGu = 'U2'
	BEGIN
		UPDATE GUILD_VOTE_TBL 
			SET 	m_cbStatus = '2'
		WHERE m_idVote = @im_idVote
		     AND serverindex = @iserverindex
	RETURN
	END

/*
	 GUILD ?? ????
	 ex ) 
	 GUILD_VOTE_STR 'U2',@iserverindex,@im_idGuild,@im_idVote
	 GUILD_VOTE_STR 'U2','01','000000',123

*/
IF @iGu = 'D1'
	BEGIN
		UPDATE GUILD_VOTE_TBL 
			SET 	m_cbStatus = '3'
		WHERE m_idVote = @im_idVote
		     AND serverindex = @iserverindex
	RETURN
	END

/*
	 GUILD ?? ????
	 ex ) 
	 GUILD_VOTE_STR 'D1',@iserverindex,@im_idGuild,@im_idVote
	 GUILD_VOTE_STR 'D1','01','000000',123

*/

set nocount off
GO
/****** Object:  StoredProcedure [dbo].[GUILD_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[GUILD_STR]
	@iGu        		  				CHAR(2) 			=	'S1', 
	@im_idPlayer					CHAR(7) 			= '0000001',
	@iserverindex  				CHAR(2) 			= '01',
	@im_idGuild					CHAR(6)				= '000001',
	@im_szGuild					varCHAR(48)			='',
	@iLv_1								INT 						=1,
	@iLv_2								INT 						=1,
	@iLv_3								INT 						=1,
	@iLv_4								INT 						=1,
	@im_nLevel					INT 						=1,
	@im_nGuildGold			INT 						=0,
	@im_nGuildPxp				INT 						=0,
	@im_nWin						INT 						=0,
	@im_nLose					INT 						=0,
	@im_nSurrender			INT 						=0,
	@im_dwLogo					INT 						=0,
	@im_szNotice				VARCHAR(127)	='',
	@im_nClass					INT 						=0
AS
set nocount on
IF @iGu = 'S1'
	BEGIN
		SELECT  m_idGuild,serverindex,Lv_1,Lv_2,Lv_3,Lv_4,Pay_0,Pay_1,Pay_2,Pay_3,Pay_4,m_szGuild,m_nLevel,
						m_nGuildGold,m_nGuildPxp,m_nWin,m_nLose,m_nSurrender,m_nWinPoint,
						m_dwLogo,m_szNotice
		   FROM GUILD_TBL 
		 WHERE serverindex = @iserverindex
					AND isuse='T'
		 ORDER BY m_idGuild
		RETURN
	END
/*

	

	SELECT * FROM GUILD_TBL
	SELECT * FROM GUILD_MEMBER_TBL
	SELECT * FROM GUILD_BANK_TBL WHERE serverindex ='07'
	
	DELETE GUILD_TBL WHERE serverindex ='07'
	DELETE GUILD_MEMBER_TBL WHERE serverindex ='07'
	DELETE GUILD_BANK_TBL WHERE serverindex ='07'

	 GUILD ?? ???? - ???
	 ex ) 
	 GUILD_STR 'S1',@im_idPlayer,@iserverindex
	 GUILD_STR 'S1','','01'

*/
ELSE
IF @iGu = 'S2'
	BEGIN
		SELECT 	A.m_idPlayer,A.serverindex,A.m_idGuild,A.m_szAlias,A.m_nWin,A.m_nLose,A.m_nSurrender,
						A.m_nMemberLv,A.m_nClass,A.m_nGiveGold,A.m_nGivePxp,B.m_nJob,B.m_nLevel,B.m_dwSex,
						m_idWar=ISNULL(A.m_idWar,0),m_idVote=ISNULL(A.m_idVote,0)
		   FROM GUILD_MEMBER_TBL A, CHARACTER_TBL B
		 WHERE A.m_idPlayer = B.m_idPlayer
		      AND A.serverindex = B.serverindex
				AND B.serverindex = @iserverindex
--		      AND B.isblock='F'
			   AND A.isuse = 'T'
		 ORDER BY A.m_idPlayer
		RETURN
	END

/*
	

	 GUILD ?? ?? ????- ???
	 ex ) 
	 GUILD_STR 'S2',@im_idPlayer,@iserverindex
	 GUILD_STR 'S2','','01'

*/
ELSE
IF @iGu = 'A1'
	BEGIN
-- 		IF NOT EXISTS (SELECT * FROM GUILD_TBL WHERE m_szGuild = @im_szGuild AND serverindex = @iserverindex)
-- 			BEGIN
				IF (NOT EXISTS (SELECT * FROM GUILD_TBL WHERE m_idGuild = @im_idGuild AND serverindex = @iserverindex) and  NOT EXISTS (SELECT * FROM GUILD_BANK_TBL WHERE m_idGuild = @im_szGuild AND serverindex = @iserverindex))
					BEGIN
						INSERT  GUILD_TBL
							(
								m_idGuild,serverindex,Lv_1,Lv_2,Lv_3,Lv_4,Pay_0,Pay_1,Pay_2,Pay_3,Pay_4,
							 	m_szGuild,m_nLevel,m_nGuildGold,m_nGuildPxp,
								m_nWin,m_nLose,m_nSurrender,m_nWinPoint,m_dwLogo,
								m_szNotice,isuse,CreateTime
							)
						VALUES
							(
								@im_idGuild,@iserverindex,@iLv_1,@iLv_2,@iLv_3,@iLv_4,0,0,0,0,0,
							 	@im_szGuild,1,0,0,
								0,0,0,0,@im_dwLogo,
								@im_szNotice,'T',GETDATE()
							)
						INSERT GUILD_BANK_TBL
							(
								m_idGuild,serverindex,m_apIndex,
								m_dwObjIndex,m_GuildBank
							)
						VALUES
							(
								@im_idGuild,@iserverindex,'$',
								'$','$'
							)

						INSERT GUILD_BANK_EXT_TBL
							(
								m_idGuild,serverindex,m_extGuildBank,m_GuildBankPiercing
							)
						VALUES
							(
								@im_idGuild,@iserverindex,'$','$'
							)
-- 						IF @@SERVERNAME='CHAR-DB1'
-- 						BEGIN
-- 						INSERT [LOG].LOG_DBF.dbo.GUILD_TBL  --?? ??? ?? ?? ??? ?? ????
-- 							(
-- 								m_idGuild,serverindex,m_szGuild,isuse
-- 							)
-- 						VALUES
-- 							(
-- 								@im_idGuild,@iserverindex,@im_szGuild,'T'
-- 							)
-- 						END
						SELECT  nError = '1', fText = '?? ?? OK'
					END
				ELSE
					BEGIN
						SELECT  nError = '2', fText = '?? ??? ??'
					END
-- 			END
-- 		ELSE
-- 			BEGIN
-- 				SELECT  nError = '3', fText = '?? ?? ??'
-- 			END	
-- 		RETURN
	END
/*
	
	 GUILD ??- ???
	 ex ) 
	 GUILD_STR 'A1',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4,@im_nLevel,@im_nGuildGold,
								  @im_nGuildPxp,@im_nWin,@im_nLose,@im_nSurrender,@im_dwLogo,@im_szNotice

	 GUILD_STR 'A1','000000','01','000004','?????',1,1,1,1,1,0,
								  0,0,0,0,0,'??????? ???? ??? ?????.'

*/
ELSE
IF @iGu = 'A2'
	BEGIN		
		IF NOT EXISTS( SELECT * FROM GUILD_MEMBER_TBL  WHERE  m_idPlayer = @im_idPlayer AND serverindex = @iserverindex AND m_idGuild = @im_idGuild)
		INSERT  GUILD_MEMBER_TBL 
			(
				m_idPlayer,serverindex,m_idGuild,m_szAlias,
				m_nWin,m_nLose,m_nSurrender,m_nMemberLv,m_nClass,
				m_nGiveGold,m_nGivePxp,m_idWar,m_idVote,isuse,CreateTime
			)
		VALUES
			(
				@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild, 	--(@im_szGuild = m_szAlias)
				0,0,0,@im_nLevel,	0,														--(@iLv_1 = m_nPay , @im_nLevel = m_nMemberLv)
				@im_nGuildGold,@im_nGuildPxp,0,'','T',GETDATE()				--(@im_nGuildGold = m_nGiveGold,@im_nGuildPxp= m_nGivePxp)
			)
		RETURN
	END
/*
	
	 GUILD ??
	 ex ) 
	 GUILD_STR 'A2',@im_idPlayer,@iserverindex,@im_idGuild(@im_szGuild = m_szAlias),@im_szGuild,@iLv_1(@iLv_1 = m_nPay),
								 @iLv_2,@iLv_3,@iLv_4,@im_nLevel(@im_nLevel = m_nMemberLv),@im_nGuildGold(@im_nGuildGold = m_nGiveGold),
								  @im_nGuildPxp(@im_nGuildPxp= m_nGivePxp)

	 GUILD_STR 'A2','000023','01','000001','',1,
									0,0,0,0,1,0,
								  	0
*/
ELSE
IF @iGu = 'U1'
	BEGIN
		UPDATE GUILD_TBL
			  SET	Lv_1 = @iLv_1,
						Lv_2 = @iLv_2,
						Lv_3 = @iLv_3,
						Lv_4 = @iLv_4			 			
		 WHERE m_idGuild = @im_idGuild
			  AND serverindex = @iserverindex
			  AND isuse = 'T'
		RETURN
	END
/*
	
	 GUILD ?? ?? - ???
	 ex ) 
	 GUILD_STR 'U1',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4

	 GUILD_STR 'U1','000000','01','000001','',0,0,0,0,0
*/

ELSE
IF @iGu = 'U2'
	BEGIN
		UPDATE GUILD_MEMBER_TBL
			  SET	m_nMemberLv = @im_nLevel,
						m_nClass = 0		 			-- ??? ????
		 WHERE m_idPlayer = @im_idPlayer
			  AND serverindex = @iserverindex
			  AND isuse = 'T'
		RETURN
	END
/*
	
	 GUILD ?? ?? ??- ???
	 ex ) 
	 GUILD_STR 'U2',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4,@im_nLevel

	 GUILD_STR 'U2','000000','01','000001','',0,0,0,0,0,12
*/
ELSE
IF @iGu = 'U3'
	BEGIN
		UPDATE GUILD_TBL
			SET m_dwLogo = @im_dwLogo
		 WHERE m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex
		RETURN
	END
/*
	
	 GUILD ?? ????- ???
	 ex ) 
	 GUILD_STR 'U3',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4,@im_nLevel,@im_nGuildGold,
								  @im_nGuildPxp,@im_nWin,@im_nLose,@im_nSurrender,@im_dwLogo,@im_szNotice

	 GUILD_STR 'U3','000000','01','000001','',0,0,0,0,0,0,
								  0,0,0,0,0,123,@im_szNotice

*/


ELSE
IF @iGu = 'U4'
	BEGIN
		UPDATE GUILD_TBL
			SET m_nLevel = @im_nLevel,
                  m_nGuildGold = @im_nGuildGold,
                  m_nGuildPxp = @im_nGuildPxp
	   WHERE m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex

		UPDATE GUILD_MEMBER_TBL
			SET m_nGiveGold = m_nGiveGold +  @iLv_1,
                  m_nGivePxp = m_nGivePxp +  @iLv_2
		WHERE  m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex
			  AND m_idPlayer = @im_idPlayer
		RETURN
	END
/*
	
	 GUILD ?? - ???
	 ex ) 
	GUILD_STR 'U4',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4,@im_nLevel,@im_nGuildGold,
								  @im_nGuildPxp

	GUILD_STR 'U4','000000','01','000001','',0,0,0,0,16,1000,
								  14

*/


ELSE
IF @iGu = 'U5'
	BEGIN
		UPDATE GUILD_TBL
			SET m_szNotice = @im_szNotice
		 WHERE m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex
		RETURN
	END

/*
	
	 GUILD ???? - ???
	 ex ) 
	 GUILD_STR 'U5',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4,@im_nLevel,@im_nGuildGold,
								  @im_nGuildPxp,@im_nWin,@im_nLose,@im_nSurrender,@im_dwLogo,@im_szNotice


	 GUILD_STR 'U5','000000','01','000001','',0,0,0,0,0,0,
								  0,0,0,0,0,0,'??????? ???? ??? ?????.'

*/


ELSE
IF @iGu = 'U6'
	BEGIN
		UPDATE GUILD_TBL
			SET Pay_0 = @im_dwLogo,
					Pay_1 = @iLv_1,
					Pay_2 = @iLv_2,
					Pay_3 = @iLv_3,
					Pay_4 = @iLv_4
		 WHERE m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex
		RETURN
	END

/*
	
	 GUILD ???? - ???
	 ex ) 
	 GUILD_STR 'U6',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4,@im_nLevel,@im_nGuildGold,
								  @im_nGuildPxp,@im_nWin,@im_nLose,@im_nSurrender,@im_dwLogo

	 GUILD_STR 'U6','000000','01','000001','',100,80,60,40,0,0,
								  0,0,0,0,0,20

*/


ELSE
IF @iGu = 'U7'
	BEGIN
		INSERT ITEM_SEND_TBL
			(m_idPlayer,serverindex,Item_Name,Item_count,m_nAbilityOption,End_Time)

		SELECT 	A.m_idPlayer,
						A.serverindex,
						'penya',
						CASE A.m_nMemberLv 	WHEN 0 THEN  B.Pay_0 
																	WHEN 1 THEN  B.Pay_1 
																	WHEN 2 THEN  B.Pay_2
																	WHEN 3 THEN  B.Pay_3
																	WHEN 4 THEN  B.Pay_4 
																 	ELSE 0 END ,
						0,
						NULL
			FROM GUILD_MEMBER_TBL A,GUILD_TBL B
        WHERE A.m_idGuild =B.m_idGuild
				AND B.m_idGuild = @im_idGuild
		      AND A.serverindex = B.serverindex
			  AND B.serverindex = @iserverindex
			  AND A.isuse = 'T'
			  AND (
							(A.m_nMemberLv = 0 AND B.Pay_0  > 0)  OR
						  	(A.m_nMemberLv = 1 AND B.Pay_1  > 0)  OR 
						  	(A.m_nMemberLv = 2 AND B.Pay_2  > 0)  OR 
						  	(A.m_nMemberLv = 3 AND B.Pay_3  > 0)  OR 
						  	(A.m_nMemberLv = 4 AND B.Pay_4  > 0) 
						)

		UPDATE GUILD_TBL 
			   SET m_nGuildGold = @iLv_1	
			 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex
		SELECT nError = '1',fText ='OK'
	RETURN
	END

/*
	
	 GUILD ???? - ???
	 ex ) 
	 GUILD_STR 'U7',@im_idPlayer,@iserverindex,@im_idGuild,'',@iLv_1

	 GUILD_STR 'U7','000000','02','000029','',10000


*/

ELSE
IF @iGu = 'U8'
	BEGIN
		UPDATE GUILD_TBL
			SET m_szGuild = @im_szGuild
		 WHERE m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex

-- 		IF @@SERVERNAME='CHAR-DB1'
-- 		BEGIN
-- 		UPDATE [LOG].LOG_DBF.dbo.GUILD_TBL  --?? ??? ?? ?? ??? ?? ????
-- 			SET  m_szGuild = @im_szGuild
-- 		 WHERE m_idGuild = @im_idGuild
-- 		      AND serverindex = @iserverindex
-- 		END
		RETURN
	END


/*
	
	 GUILD ?? ?? - ???
	 ex ) 
	 GUILD_STR 'U8',@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild

	 GUILD_STR 'U8', '000000', '01', '000001', 'asasas'    


*/
ELSE
IF @iGu = 'U9'
	BEGIN
		UPDATE GUILD_MEMBER_TBL 
			SET m_nClass = @im_nClass
		 WHERE m_idPlayer = @im_idPlayer
		      AND serverindex = @iserverindex
		RETURN
	END


/*
	
	 GUILD? ?? ?? - ???
	 ex ) 
	 GUILD_STR 'U9',,@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild,@iLv_1,@iLv_2,@iLv_3,@iLv_4,@im_nLevel,@im_nGuildGold,
								  @im_nGuildPxp,@im_nWin,@im_nLose,@im_nSurrender,@im_dwLogo,@im_nClass

	 GUILD_STR 'U9','000000','01','000001','',100,80,60,40,0,0,
								  0,0,0,0,0,20,2


*/

ELSE
IF @iGu = 'UA'
	BEGIN
		UPDATE GUILD_MEMBER_TBL 
			SET m_szAlias = @im_szGuild --m_szAlias
		 WHERE m_idPlayer = @im_idPlayer
		      AND serverindex = @iserverindex
		RETURN
	END


/*
	
	 GUILD? ?? ?? - ???
	 ex ) 
	 GUILD_STR 'UA',,@im_idPlayer,@iserverindex,@im_idGuild,@im_szGuild(m_szAlias)

	 GUILD_STR 'UA','000000','01','000001','????'


*/
ELSE
IF @iGu = 'D1'
	BEGIN
		
			UPDATE CHARACTER_TBL
	         	SET m_tGuildMember = CONVERT(CHAR(8),DATEADD(d,2,GETDATE()),112) 
										+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,DATEADD(d,2,GETDATE()))),2) 
										+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,DATEADD(d,2,GETDATE()))),2) 
										+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,DATEADD(d,2,GETDATE()))),2)
				FROM CHARACTER_TBL A,GUILD_MEMBER_TBL B
			 WHERE A.m_idPlayer = B.m_idPlayer
					AND B.m_idGuild = @im_idGuild
					AND A.serverindex = B.serverindex
			      AND B.serverindex = @iserverindex

			DELETE GUILD_TBL
			 WHERE m_idGuild = @im_idGuild
			      AND serverindex = @iserverindex
	
			DELETE GUILD_MEMBER_TBL
			 WHERE m_idGuild = @im_idGuild
			      AND serverindex = @iserverindex
	
			DELETE GUILD_BANK_TBL
			 WHERE m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex

			DELETE GUILD_BANK_EXT_TBL
			 WHERE m_idGuild = @im_idGuild
		      AND serverindex = @iserverindex

			DELETE GUILD_QUEST_TBL
			WHERE	m_idGuild=@im_idGuild
			AND	serverindex=@iserverindex
				
-- 			IF @@SERVERNAME='CHAR-DB1'
-- 			BEGIN
-- 			UPDATE [LOG].LOG_DBF.dbo.GUILD_TBL  --?? ??? ?? ?? ??? ?? ????
-- 				SET  isuse = 'D'
-- 			 WHERE m_idGuild = @im_idGuild
-- 			      AND serverindex = @iserverindex
-- 
-- 			END





--		??? ??? (??? ????)
-- 		UPDATE GUILD_TBL
-- 			SET isuse = 'F'
-- 		 WHERE m_idGuild = @im_idGuild
-- 		      AND serverindex = @iserverindex
-- 
-- 		UPDATE GUILD_MEMBER_TBL
-- 			SET isuse = 'F'
-- 		 WHERE m_idGuild = @im_idGuild
-- 		      AND serverindex = @iserverindex
		RETURN
	END

/*
	
	 GUILD ??- ???
	 ex ) 
	 GUILD_STR 'D1',@im_idPlayer,@iserverindex,@im_idGuild

	 GUILD_STR 'D1','000000','01','000001'

*/

ELSE
IF @iGu = 'D2'
	BEGIN

		UPDATE CHARACTER_TBL
         	SET m_tGuildMember = CONVERT(CHAR(8),DATEADD(d,2,GETDATE()),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,DATEADD(d,2,GETDATE()))),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,DATEADD(d,2,GETDATE()))),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,DATEADD(d,2,GETDATE()))),2)
		 WHERE m_idPlayer = @im_idPlayer
		      AND serverindex = @iserverindex


		DELETE  GUILD_MEMBER_TBL
		 WHERE m_idPlayer = @im_idPlayer
		      AND serverindex = @iserverindex


--		??? ??? (??? ????)
-- 		UPDATE GUILD_MEMBER_TBL
-- 			SET isuse = 'F'
-- 		 WHERE m_idGuild = @im_idGuild
-- 		      AND serverindex = @iserverindex
 		RETURN
	END

/*
	
	 GUILD ??/?? - ???
	 ex ) 
	 GUILD_STR 'D2',@im_idPlayer,@iserverindex,@im_idGuild

	 GUILD_STR 'D2','000000','01','000001'

*/
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[GUILD_WAR_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GUILD_WAR_STR]
	@iGu        		  				CHAR(2) 				,	 
	@im_idGuild					CHAR(6)					,
	@iserverindex				CHAR(2)					,
	@im_idWar						INT			=0,	
	@iState							CHAR(1) = '', -- 0:?? 1:?????? 2:?????? 3:?????? 4:?????? 9:???
	@if_idGuild						CHAR(6)	= '',
	@im_idPlayer					CHAR(7)='',
	@im_nWinPoint				INT =0,
	@if_nWinPoint				INT =0
AS
set nocount on
IF @iGu = 'S1'
	BEGIN


		SELECT m_idGuild,serverindex,f_idGuild,m_idWar,m_nDeath,m_nSurrender,m_nCount,m_nAbsent,f_nDeath,f_nSurrender,f_nCount,f_nAbsent,State,StartTime
 			FROM GUILD_WAR_TBL 
		WHERE 	serverindex 				= @iserverindex
			AND State = '0'
-- 		UNION ALL
-- 		SELECT m_idGuild=f_idGuild,serverindex,m_idWar,m_nDeath=f_nDeath,m_nSurrender=f_nSurrender,m_nCount=f_nCount,State,StartTime
--  			FROM GUILD_WAR_TBL 
-- 		WHERE 	serverindex 				= @iserverindex
-- 			AND State = '0'
		ORDER BY m_idWar,serverindex
	RETURN
	END
/*
	 GUILD WAR ?? ????
	 ex ) 
	 GUILD_WAR_STR 'S1',@im_idGuild,@iserverindex,@im_idWar,@iState,@if_idGuild
	 GUILD_WAR_STR 'S1','000000','01'

*/
ELSE
IF @iGu = 'S2'
	BEGIN
		SELECT Max_m_idWar = ISNULL(MAX(m_idWar),0)
 			FROM GUILD_WAR_TBL 
		WHERE 	serverindex 				= @iserverindex
	RETURN
	END
/*
	 Max m_idWAR ????
	 ex ) 
	 GUILD_WAR_STR 'S2','',@iserverindex
	 GUILD_WAR_STR 'S2','','01'

*/

ELSE
IF @iGu = 'A1'
	BEGIN
		DECLARE @currDate char(12),@om_nCount INT,@of_nCount INT				
		SET @currDate = CONVERT(CHAR(8),GETDATE(),112) 
								   + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
								   + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2)

		
		SELECT @om_nCount = COUNT(m_idGuild) FROM GUILD_MEMBER_TBL WHERE m_idGuild = @im_idGuild AND isuse = 'T'
		SELECT @of_nCount = COUNT(m_idGuild) FROM GUILD_MEMBER_TBL WHERE m_idGuild = @if_idGuild AND isuse = 'T'

		INSERT GUILD_WAR_TBL
			(
				m_idGuild,serverindex,m_idWar,f_idGuild,m_nDeath,m_nSurrender,m_nCount,m_nAbsent,f_nDeath,f_nSurrender,f_nCount,f_nAbsent,State,StartTime
			)
		VALUES
			(
				@im_idGuild,@iserverindex,@im_idWar,@if_idGuild,0,0,@om_nCount,0,0,0,@of_nCount,0,'0',@currDate
			)
		UPDATE GUILD_MEMBER_TBL
			   SET m_idWar = @im_idWar
		 WHERE m_idGuild IN (@im_idGuild,@if_idGuild)
		      AND serverindex = @iserverindex
			   AND isuse = 'T'

	RETURN
	END
/*
	 GUILD ? ????
	 ex ) 
	 GUILD_WAR_STR 'A1',@im_idGuild,@iserverindex,@im_idWar,@iState,@if_idGuild
	 GUILD_WAR_STR 'A1','000001','01',123,'','000002'

*/
ELSE
IF @iGu = 'U1'
	BEGIN
		UPDATE GUILD_WAR_TBL
			   SET m_nSurrender = m_nSurrender + 1
		 WHERE m_idWar = @im_idWar
			  AND m_idGuild = @im_idGuild
			  AND serverindex = @iserverindex
			  AND State  = '0'

		UPDATE GUILD_WAR_TBL
			   SET f_nSurrender = f_nSurrender + 1
		 WHERE m_idWar = @im_idWar
			  AND f_idGuild = @im_idGuild
			  AND serverindex 	= @iserverindex
			  AND State  = '0'

		UPDATE GUILD_MEMBER_TBL
			  SET m_idWar = 0,
					  m_nSurrender = m_nSurrender + 1 		
		 WHERE m_idPlayer = @im_idPlayer
			AND serverindex 	= @iserverindex
			AND m_idWar > 0

	RETURN
	END
/*
	 GUILD ?? ??
	 ex ) 
	 GUILD_WAR_STR 'U1',@im_idGuild,@iserverindex,@im_idWar,@iState,@if_idGuild,@im_idPlayer
	 GUILD_WAR_STR 'U1','000001','01',123,'','000002'

*/
ELSE
IF @iGu = 'U2'
	BEGIN
		UPDATE GUILD_WAR_TBL
			   SET m_nDeath = m_nDeath + 1
		 WHERE m_idWar = @im_idWar
			  AND m_idGuild = @im_idGuild
			  AND serverindex = @iserverindex

		UPDATE GUILD_WAR_TBL
			   SET f_nDeath = f_nDeath + 1
		 WHERE m_idWar = @im_idWar
			  AND f_idGuild = @im_idGuild
			  AND serverindex 	= @iserverindex

	RETURN
	END
/*
	 GUILD ?? ??
	 ex ) 
	 GUILD_WAR_STR 'U2',@im_idGuild,@iserverindex,@im_idWar,@iState,@if_idGuild (m_idPlayer)
	 GUILD_WAR_STR 'U2','000001','01',123,'','000002'

*/
ELSE
IF @iGu = 'U3'
	BEGIN
		UPDATE GUILD_WAR_TBL
			   SET State = @iState
		 WHERE m_idWar = @im_idWar
		      AND serverindex = serverindex

		IF @iState = '1' -- ??? ????
			BEGIN
				UPDATE GUILD_TBL
					SET m_nWin = m_nWin + 1,m_nWinPoint = @im_nWinPoint
				WHERE m_idGuild = @im_idGuild
				     AND serverindex = @iserverindex

				UPDATE GUILD_TBL
					SET m_nLose = m_nLose + 1,m_nWinPoint = @if_nWinPoint
				WHERE m_idGuild = @if_idGuild
				     AND serverindex = @iserverindex
	
				UPDATE GUILD_MEMBER_TBL
					  SET m_nWin = m_nWin + 1
				WHERE m_idGuild = @im_idGuild
					  AND serverindex = @iserverindex
				     AND m_idWar > 0
					  AND isuse='T'
	
				UPDATE GUILD_MEMBER_TBL
					  SET  m_nLose = m_nLose + 1
				WHERE m_idGuild = @if_idGuild
					  AND serverindex = @iserverindex
				     AND m_idWar > 0
					  AND isuse='T'
			END
		ELSE
		IF @iState = '2' -- ??? ????
			BEGIN
				UPDATE GUILD_TBL
					SET m_nWin = m_nWin + 1,m_nWinPoint = @im_nWinPoint
				WHERE m_idGuild = @im_idGuild
				     AND serverindex = @iserverindex	

				UPDATE GUILD_TBL
					SET m_nSurrender = m_nSurrender + 1,m_nWinPoint = @if_nWinPoint
				WHERE m_idGuild = @if_idGuild
				     AND serverindex = @iserverindex

				UPDATE GUILD_MEMBER_TBL
					  SET m_nWin = m_nWin + 1
				WHERE m_idGuild = @im_idGuild
					  AND serverindex = @iserverindex
				     AND m_idWar > 0
					  AND isuse='T'
	
				UPDATE GUILD_MEMBER_TBL
					  SET  m_nLose = m_nLose + 1
				WHERE m_idGuild = @if_idGuild
					  AND serverindex = @iserverindex
				     AND m_idWar > 0
					  AND isuse='T'
			END
		ELSE
		IF  @iState = '3'  -- ??? ????
			BEGIN
				UPDATE GUILD_TBL
					SET m_nLose = m_nLose + 1,m_nWinPoint = @im_nWinPoint
				WHERE m_idGuild = @im_idGuild
				     AND serverindex = @iserverindex

				UPDATE GUILD_TBL
					SET  m_nWin = m_nWin + 1,m_nWinPoint = @if_nWinPoint
				WHERE m_idGuild = @if_idGuild
				     AND serverindex = @iserverindex
	
				UPDATE GUILD_MEMBER_TBL
					  SET  m_nLose = m_nLose + 1
				WHERE m_idGuild = @im_idGuild
					  AND serverindex = @iserverindex
					  AND m_idWar > 0
					  AND isuse='T'

				UPDATE GUILD_MEMBER_TBL
					  SET m_nWin = m_nWin + 1
				WHERE m_idGuild = @if_idGuild
					  AND serverindex = @iserverindex
				     AND m_idWar > 0
					  AND isuse='T'
			END
		ELSE
		IF  @iState = '4'   -- ??? ????
			BEGIN
				UPDATE GUILD_TBL
					SET m_nSurrender = m_nSurrender + 1,m_nWinPoint = @im_nWinPoint
				WHERE m_idGuild = @im_idGuild
				     AND serverindex = @iserverindex	

				UPDATE GUILD_TBL
					SET  m_nWin = m_nWin + 1,m_nWinPoint = @if_nWinPoint
				WHERE m_idGuild = @if_idGuild
				     AND serverindex = @iserverindex
	
				UPDATE GUILD_MEMBER_TBL
					  SET  m_nLose = m_nLose + 1
				WHERE m_idGuild = @im_idGuild
					  AND serverindex = @iserverindex
				     AND m_idWar > 0	
					  AND isuse='T'

				UPDATE GUILD_MEMBER_TBL
					  SET  m_nWin = m_nWin + 1
				WHERE m_idGuild = @if_idGuild
					  AND serverindex = @iserverindex
				     AND m_idWar > 0
					  AND isuse='T'
			END

		UPDATE GUILD_MEMBER_TBL 
				SET m_idWar = 0
		 WHERE m_idWar = @im_idWar
			  AND serverindex = @iserverindex
		     AND m_idWar > 0
 		     AND isuse='T'			

	RETURN
	END
/*
	 GUILD ? ??
	 ex ) 
	 GUILD_WAR_STR 'U3',@im_idGuild,@iserverindex,@im_idWar,@iState,@if_idGuild 
	 GUILD_WAR_STR 'U3','000001','01',123,'','000002'

*/
ELSE
IF @iGu = 'U4'
	BEGIN
		UPDATE GUILD_WAR_TBL
			   SET m_nAbsent=m_nAbsent+1
		 WHERE m_idWar = @im_idWar
			  AND m_idGuild = @im_idGuild
			  AND serverindex = @iserverindex

		UPDATE GUILD_WAR_TBL
			   SET f_nAbsent=f_nAbsent+1
		 WHERE m_idWar = @im_idWar
			  AND f_idGuild = @im_idGuild
			  AND serverindex 	= @iserverindex

	RETURN
	END
/*
	 GUILD ??? ??
	 ex ) 
	 GUILD_WAR_STR 'U4',@im_idGuild,@iserverindex,@im_idWar,@iState,@if_idGuild (m_idPlayer)
	 GUILD_WAR_STR 'U4','000001','01',123,'','000002'

*/
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[GUILD_QUEST_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE               PROC [dbo].[GUILD_QUEST_STR]
	@iGu        		  				CHAR(2) 			=	'S1', 
	@im_idGuild				CHAR(6) 			= '000001',
	@iserverindex  				CHAR(2) 		= '01',
	@in_Id					INT					= 0,
	@in_State						INT					= 0
AS
set nocount on


DECLARE @odate CHAR(14)
  SELECT @odate = CONVERT(CHAR(8),GETDATE(),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,GETDATE())),2)

IF @iGu = 'S1'
	BEGIN
		SELECT m_idGuild,serverindex,n_Id,nState,s_date,e_date
          FROM GUILD_QUEST_TBL
		 WHERE serverindex = @iserverindex 
		 ORDER BY m_idGuild,serverindex,n_Id
		RETURN
	END
/*
  	?? ??? ? ????
	 ex ) 
   GUILD_QUEST_STR 'S1', @im_idGuild,@iserverindex

   	GUILD_QUEST_STR 'S1', '','01'
*/
ELSE
IF @iGu = 'A1'
	BEGIN
		IF NOT EXISTS(SELECT *  FROM GUILD_QUEST_TBL WHERE m_idGuild= @im_idGuild AND serverindex = @iserverindex AND n_Id	= @in_Id)
			INSERT GUILD_QUEST_TBL
				(m_idGuild,serverindex,n_Id,nState,s_date,e_date)
			VALUES
				(@im_idGuild,@iserverindex,@in_Id,0,@odate,'')
		RETURN
	END
/*
  	?? ??? ??
	 ex ) 
   GUILD_QUEST_STR 'A1', @im_idGuild,@iserverindex,@in_Id

   	GUILD_QUEST_STR 'A1', '000001','01',0
*/
ELSE
IF @iGu = 'U1'
	BEGIN
		UPDATE GUILD_QUEST_TBL
			   SET nState = @in_State,
						e_date =  @odate
		 WHERE m_idGuild= @im_idGuild 
             AND serverindex = @iserverindex 
             AND n_Id	= @in_Id
		RETURN
	END
/*
  	?? ??? ??
	 ex ) 
   GUILD_QUEST_STR 'U1', @im_idGuild,@iserverindex,@in_Id,@in_State

   	GUILD_QUEST_STR 'U1', '000001','01',0,1
*/
ELSE
IF @iGu = 'D1'
	BEGIN
		DELETE GUILD_QUEST_TBL
		 WHERE m_idGuild= @im_idGuild 
             AND serverindex = @iserverindex 
             AND n_Id	= @in_Id
		RETURN
	END
/*
  	?? ??? ??
	 ex ) 
   GUILD_QUEST_STR 'D1', @im_idGuild,@iserverindex,@in_Id,@in_State

   	GUILD_QUEST_STR 'D1', '000001','01',0,1
*/
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[DEL_FALSE_CHARACTER_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[DEL_FALSE_CHARACTER_STR]
@serverindex char(2) = '01'
AS
UPDATE CHARACTER_TBL
SET isblock = 'D'
 --select m_idPlayer,TotalPlayTime  from CHARACTER_TBL
  where m_idPlayer in (
			select x.m_idPlayer
			from 
			(
				select a.m_idPlayer 
				  from CHARACTER_TBL a,
					     (
	                          select account, playerslot
					        from CHARACTER_TBL 
					      where isblock='F'
							and serverindex =@serverindex
					       group by account,playerslot 
					      having count(account)>1
	                        ) b
				  where a.account=b.account
				    and a.playerslot =b.playerslot
					 and serverindex =@serverindex
				    and a.isblock = 'F'
			) x
			where x.m_idPlayer NOT IN(  select m_idPlayer = min(m_idPlayer) 
													   from CHARACTER_TBL
													 where isblock='F'
														  and serverindex =@serverindex
													   group by account,playerslot 
													  having count(account)>1)
			)
  and isblock = 'F'
  and serverindex =@serverindex
RETURN
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GUILD_COMBAT_count]    Script Date: 04/03/2010 12:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_GUILD_COMBAT_count] (@combatID int, @m_idGuild char(6))
returns int
as
begin
	declare @count int

	select @count = count(*) from GUILD_COMBAT_1TO1_BATTLE_PERSON_TBL
	where combatID = @combatID and m_idGuild = @m_idGuild and State = 'W'

	return @count
end
GO
/****** Object:  StoredProcedure [dbo].[GUILD_BANK_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[GUILD_BANK_STR]
	@iGu        		  				CHAR(2) 				,	 
	@im_idGuild					CHAR(6)					,
	@iserverindex				CHAR(2)					,
	@im_nGuildGold			INT = 0,
	@im_apIndex 				VARCHAR(215) = '',
	@im_dwObjIndex 			VARCHAR(215) = '',
	@im_GuildBank				TEXT 				   = '',
	@im_idPlayer					CHAR(7) = '',
	@im_extGuildBank		varchar(2000) = '',
	@im_GuildBankPiercing varchar(8000) = ''
	, @iszGuildBankPet varchar(4200) = '$'
AS
set nocount on
IF @iGu = 'S1'
	BEGIN
		SELECT A.m_idGuild, A.serverindex, B.m_nGuildGold, A.m_apIndex, A.m_dwObjIndex, A.m_GuildBank,C.m_extGuildBank,C.m_GuildBankPiercing, C.szGuildBankPet
			FROM GUILD_BANK_TBL A, GUILD_TBL B, GUILD_BANK_EXT_TBL C
		WHERE A.m_idGuild = B.m_idGuild
			 AND B.m_idGuild = C.m_idGuild
			AND A.serverindex = B.serverindex 
			AND B.serverindex = C.serverindex 
			AND C.serverindex = @iserverindex
	RETURN
	END
/*
	 GUILD BANK ?? ????
	 ex ) 
	 GUILD_BANK_STR 'S1',@im_idGuild,@iserverindex
	 GUILD_BANK_STR 'S1','000000','01'

*/
IF @iGu = 'U1'
	BEGIN

		DECLARE @om_nGuildGold bigint

		SELECT @om_nGuildGold =  m_nGuildGold - @im_nGuildGold
			FROM GUILD_TBL
		 WHERE 	m_idGuild   				= @im_idGuild	
			  AND 	serverindex 				= @iserverindex

		UPDATE GUILD_BANK_TBL 
			  SET 	m_apIndex = @im_apIndex,
						m_dwObjIndex = @im_dwObjIndex,
						m_GuildBank = @im_GuildBank
		 WHERE 	m_idGuild   				= @im_idGuild	
			  AND 	serverindex 				= @iserverindex

		UPDATE GUILD_BANK_EXT_TBL 
			  SET 	m_extGuildBank = @im_extGuildBank,
				m_GuildBankPiercing = @im_GuildBankPiercing
			,szGuildBankPet = @iszGuildBankPet
		 WHERE 	m_idGuild   				= @im_idGuild	
			  AND 	serverindex 				= @iserverindex

		UPDATE GUILD_TBL 
			SET m_nGuildGold = @im_nGuildGold
		 WHERE 	m_idGuild   				= @im_idGuild	
			  AND 	serverindex 				= @iserverindex

		IF (@om_nGuildGold > 0 and @im_idPlayer <> '0000000')
			BEGIN
				UPDATE GUILD_MEMBER_TBL
					   SET m_nGiveGold = m_nGiveGold - @om_nGuildGold
				 WHERE m_idPlayer = @im_idPlayer
					  AND 	serverindex  = @iserverindex
			END
	RETURN
	END
/*
	 GUILD BANK ????
	 ex ) 
	 GUILD_BANK_STR 'U1',@im_idGuild,@iserverindex,@im_nGuildGold,@im_apIndex,@im_dwObjIndex,@im_GuildBank,@im_idPlayer
	 GUILD_BANK_STR 'U1','000001','01',0,'$','$','$', 1000  
	 GUILD_BANK_STR 'U1','000001','01',0,'$','$','$',  0       
*/


set nocount off
GO
/****** Object:  StoredProcedure [dbo].[COMPANY_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE   PROC [dbo].[COMPANY_STR]
	@iGu        		  				CHAR(2) 			, 
	@im_idCompany			CHAR(6) 			= '000001',
	@iserverindex  				CHAR(2) 			= '01',
	@im_leaderid					CHAR(7) 			= '0000001',
	@im_szCompany			VARCHAR(16)	=	''

AS
set nocount on
IF 	@iGu = 'A1'
	BEGIN
		IF EXISTS(SELECT * FROM  COMPANY_TBL  WHERE m_szCompany = @im_szCompany  AND serverindex = @iserverindex AND isuse = 'T')
			BEGIN
				SELECT fError = '1', fText = '??? ??? ??'
				RETURN	
			END
		ELSE
		IF EXISTS(SELECT * FROM  COMPANY_TBL  WHERE m_leaderid = @im_leaderid  AND serverindex = @iserverindex AND isuse = 'T')
			BEGIN
				SELECT fError = '2', fText = '??? ??'
				RETURN	
			END

		ELSE
			BEGIN

			UPDATE CHARACTER_TBL SET m_idCompany = @im_idCompany WHERE m_idPlayer = @im_leaderid AND  serverindex = @iserverindex 
			INSERT COMPANY_TBL
				(m_idCompany,serverindex,m_szCompany,m_leaderid,isuse)
			VALUES
				(@im_idCompany,@iserverindex,@im_szCompany,@im_leaderid,'T')	
	
			SELECT fError = '0', fText = 'OK'
			RETURN

			END
	END			
/*
	
	 ??? ??  ????
	 ex ) 
	 COMPANY_STR 'A1',@im_idCompany,@iserverindex,@im_leaderid,@im_szCompany
	 COMPANY_STR 'A1','000001','01','000001','??????'

*/

ELSE
IF	@iGu = 'A2'
	BEGIN
		UPDATE  CHARACTER_TBL
			   SET m_idCompany = @im_idCompany
		 WHERE m_idPlayer = @im_leaderid
		      AND serverindex = @iserverindex
		RETURN
	END
/*
	
	 ??? ????
	 ex ) 
	 COMPANY_STR 'A2',@im_idCompany,@iserverindex,@im_leaderid(m_idPlayer),@im_szCompany
	 COMPANY_STR 'A2','000001','01','000001'

*/

ELSE
IF	@iGu = 'S1'
	BEGIN
		DECLARE @maxid CHAR(6)
		SELECT @maxid = max(m_idCompany) FROM COMPANY_TBL
		SELECT m_idCompany,m_szCompany,m_leaderid,maxid = @maxid
			FROM COMPANY_TBL
	     WHERE  serverindex = @iserverindex
			    AND isuse = 'T'
		  ORDER BY m_idCompany
		RETURN
	END
/*
	
	 ??? ?? ????
	 ex ) 
	 COMPANY_STR 'S1',@im_idCompany,@iserverindex
	 COMPANY_STR 'S1','','01'

*/

ELSE
IF @iGu = 'D1'
	BEGIN
		UPDATE COMPANY_TBL
			SET  isuse = 'F'
		WHERE m_idCompany = @im_idCompany
		    AND serverindex = @iserverindex

		UPDATE CHARACTER_TBL
			SET m_idCompany = '000000'
		WHERE m_idCompany = @im_idCompany
		    AND serverindex = @iserverindex
		SELECT  fError = '0', fText = 'OK'
	RETURN
	END
/*
	
	 ??? ??
	 ex ) 
	 COMPANY_STR 'D1',@im_idCompany,@iserverindex
	 COMPANY_STR 'D1','000001','01'

*/

ELSE
IF @iGu = 'D2'
	BEGIN
		UPDATE CHARACTER_TBL
			SET  m_idCompany = '000000'
		WHERE m_idPlayer = @im_idCompany
		    AND serverindex = @iserverindex
		SELECT  fError = '0', fText = 'OK'
	RETURN
	END
/*
	
	 ??? ??
	 ex ) 
	 COMPANY_STR 'D2',@im_idCompany(m_idPlayer),@iserverindex
	 COMPANY_STR 'D2','000001','01'

*/

set nocount off
GO
/****** Object:  StoredProcedure [dbo].[ADD_BANK_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE       PROC [dbo].[ADD_BANK_STR]
	@iGu        		  				CHAR(2) 			= 'U1', 
	@im_idPlayer   				CHAR(7) 			= '0000001',
	@iserverindex  				CHAR(2) 			= '01',
	-- BANK_TBL
	@im_Bank						VARCHAR(4290)= '',
	@im_apIndex_Bank		VARCHAR(215)= '',
	@im_dwObjIndex_Bank VARCHAR(215)= '',
	@im_dwGoldBank			INT						= 0,
	@im_extBank	varchar(2000) = '',
	@im_BankPiercing	varchar(8000) = '',
	@iszBankPet varchar(4200) = '$'

/*******************************************************
	Gu ??
    S : SELECT
    I  : INSERT
    U : UPDATE
    D : DELETE
*******************************************************/
AS
set nocount on
IF @iGu = 'U1' -- ??? ??
	BEGIN
		UPDATE BANK_TBL 
			  SET 	m_Bank 						= @im_Bank,
						m_apIndex_Bank 		= @im_apIndex_Bank, 
						m_dwObjIndex_Bank = @im_dwObjIndex_Bank, 
						m_dwGoldBank 		= @im_dwGoldBank
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex

		UPDATE BANK_EXT_TBL
		      SET 	m_extBank 				= @im_extBank,
			m_BankPiercing		= @im_BankPiercing
			, szBankPet = @iszBankPet
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex
		SELECT fError = '1', fText = 'OK'
		RETURN
	END
/*
	
	??????
	 ex ) 
ADD_BANK_STR 'U1', @iGu,@im_idPlayer,@iserverindex,@im_Bank	,@im_apIndex_Bank	,@im_dwObjIndex_Bank,@im_dwGoldBank
ADD_BANK_STR 'U1','000001','01','$','$','$',1000

*/
set nocount off
RETURN
GO
/****** Object:  StoredProcedure [dbo].[BANK_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE      PROC [dbo].[BANK_STR]
	@iGu        		  				CHAR(1) 			, 
	@im_idPlayer					CHAR(7) 			= '0000001',
	@iserverindex  				CHAR(2) 			= '01',
	@im_BankPW					CHAR(4)

AS
set nocount on
IF 	@iGu = 'U'
	BEGIN
		UPDATE BANK_TBL 
			   SET m_BankPw = @im_BankPW
		WHERE  m_idPlayer = @im_idPlayer
		      AND serverindex = @iserverindex

 		insert into tblChangeBankPW  (m_idPlayer, serverindex)
		select @im_idPlayer, @iserverindex

		RETURN
	END			
/*
	
	 BANK ????  ????
	 ex ) 
	 BANK_STR 'U',@im_idPlayer,@iserverindex,@im_BankPW
	 BANK_STR 'U','000001','01','1234'

*/
GO
USE [CHARACTER_01_DBF]
GO

/****** Object:  StoredProcedure [dbo].[CHARACTER_STR]    Script Date: 11.06.2014 13:17:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[CHARACTER_STR]
	@iGu        		  				CHAR(2) 			= 'S1', 
	@im_idPlayer   				CHAR(7) 			= '0000001',
	@iserverindex  				CHAR(2) 			= '01',
	/**********************************************
	 INSERT Â¢Â¯e
	**********************************************/
	-- CHARACTER_TBL
	@iaccount 						VARCHAR(32)	= '',
	@im_szName 				VARCHAR(32)	= '',
	@iplayerslot 					INT						= 0,
	@idwWorldID 				INT 						= 0,
	@im_dwIndex 				INT 						= 0,
	@im_vPos_x 					REAL 					= 0,
	@im_vPos_y 					REAL 					= 0,
	@im_vPos_z 					REAL 					= 0,
	@im_szCharacterKey 	VARCHAR(32)	= '',
	@im_dwSkinSet 			INT						= 0,
	@im_dwHairMesh 		INT						= 0,
	@im_dwHairColor 		INT						= 0,
	@im_dwHeadMesh 		INT						= 0,
	@im_dwSex 					INT						= 0,
	/**********************************************
	 UPDATE Â¢Â¯e
	**********************************************/
	-- CHARACTER_TBL
	@im_vScale_x				REAL					=	0,
	@im_dwMotion				INT						=	0,
	@im_fAngle					REAL					=	0,
	@im_nHitPoint				INT						=	0,
	@im_nManaPoint			INT						=	0,
	@im_nFatiguePoint		INT						=	0,
	@im_dwRideItemIdx		INT						=	0,
	@im_dwGold					INT						=	0,
	@im_nJob						INT						=	0,
	@im_pActMover				VARCHAR(50)	=	'',
	@im_nStr						INT						=	0,
	@im_nSta						INT						=	0,
	@im_nDex						INT						=	0,
	@im_nInt							INT						=	0,
	@im_nLevel					INT						=	0,
	@im_nExp1					BIGINT						=	0,
	@im_nExp2					BIGINT						=	0,
	@im_aJobSkill				VARCHAR(500)	='',
	@im_aLicenseSkill		VARCHAR(500)	='',
	@im_aJobLv					VARCHAR(500)	='',
	@im_dwExpertLv			INT						=	0,
	@im_idMarkingWorld	INT						=	0,
	@im_vMarkingPos_x	REAL					=	0,
	@im_vMarkingPos_y	REAL					=	0,
	@im_vMarkingPos_z	REAL					=	0,
	@im_nRemainGP			INT						=	0,
	@im_nRemainLP			INT						=	0,
	@im_nFlightLv				INT						=	0,
	@im_nFxp						INT						=	0,
	@im_nTxp						INT						=	0,
	@im_lpQuestCntArray	VARCHAR(3072)= '',
	@im_chAuthority			CHAR(1)				= '',
	@im_dwMode				INT						=	0,
	@im_idparty					INT						=	0,
	@im_idMuerderer			INT						=	0,
	@im_nFame					INT						=	0,
	@im_nDeathExp				BIGINT					=  0,
	@im_nDeathLevel				INT					=  0,
	@im_dwFlyTime					INT					=  0,
	@im_nMessengerState 	INT					=  0,
	@iTotalPlayTime			INT						= 	0
	-------------- (ADD : Version8-PK System)
	,@im_nPKValue    		int=0
	,@im_dwPKPropensity    	int=0
	,@im_dwPKExp     		int=0
	-- CARD_CUBE_TBL
	,@im_Card 						VARCHAR(1980)= '',
	@im_Index_Card 			VARCHAR(215) 	= '',
	@im_ObjIndex_Card 	VARCHAR(215) 	= '',
	@im_Cube 						VARCHAR(1980)= '',
	@im_Index_Cube 			VARCHAR(215) 	= '',
	@im_ObjIndex_Cube 	VARCHAR(215) 	= '',
	-- INVENTORY_TBL
	@im_Inventory 				VARCHAR(MAX)= '',
	@im_apIndex 				VARCHAR(2500) 	= '',
	@im_adwEquipment 	VARCHAR(135) 	= '',
	@im_dwObjIndex 			VARCHAR(2500) 	= '',
	-- TASKBAR_TBL
	@im_aSlotApplet 			VARCHAR(3100)= '',
	-- TASKBAR_ITEM_TBL
	@im_aSlotItem 				VARCHAR(6885)= '',
	-- TASKBAR_TBL
	@im_aSlotQueue 			VARCHAR(225)= '',
	@im_SkillBar					SMALLINT			= 0,
	-- BANK_TBL
	@im_Bank						VARCHAR(4290)= '',
	@im_apIndex_Bank		VARCHAR(215)= '',
	@im_dwObjIndex_Bank VARCHAR(215)= '',
	@im_dwGoldBank			INT						= 0,
	@im_nFuel						INT						= -1,
	@im_tmAccFuel				INT 						= 0,
	@im_dwSMTime			VARCHAR(2560)='',
	@iSkillInfluence				varchar(2048) ='',
	@im_dwSkillPoint			INT 						= 0,
	@im_aCompleteQuest	varchar(3072) = '',
	@im_extInventory			varchar(max) = '',
	@im_extBank					varchar(2000) = '',
	@im_InventoryPiercing varchar(max) = '',
	@im_BankPiercing		varchar(8000) = '',
	@im_dwReturnWorldID INT		 				= 1,
	@im_vReturnPos_x 		REAL					= 0,
	@im_vReturnPos_y 		REAL					= 0,
	@im_vReturnPos_z 		REAL					= 0,
	-------------- ( Version 7 : Skill Update)
	@im_SkillPoint			int=0,
	@im_SkillLv				int=0,
	@im_SkillExp			bigint=0,
	-------------- (AÂ©Â¬Â¡Ã†Â¢Â® Â¨Â¬IÂ¨Â¬Â¨Â¢ : 2006 11 13 Attendant Class)
	@idwEventFlag                   bigint=0,
	@idwEventTime          int=0,


	@idwEventElapsed                int=0
	-------------- (ADD : Version8-Angel System)
	,@im_nAngelExp		bigint=0
	,@im_nAngelLevel		int=0
	--------------- Version 9 AÂ©Â¬Â¡Ã†Â¢Â® Â¨Â¬IÂ¨Â¬Â¨Â¢ PetÂ¡Ã†uÂ¡Â¤A
,@iszInventoryPet	varchar(max)     = '$'

,@iszBankPet	varchar(4200)     = '$'
,@im_dwPetId int = -1

,@im_nExpLog int = 0
,@im_nAngelExpLog int = 0
,@im_nCoupon int = 0
--------------- ver. 13
, @im_nHonor int = -1
, @im_nLayer int = 0
---------- Ver 15
--, @im_BankPW char(4) = '0000'
, @im_aCheckedQuest varchar(100) =''
, @im_nCampusPoint int = 0
, @im_idCampus int = 0

/*******************************************************
	Gu Â¡Â¾Â¢Â¬Â¨Â¬Â¨Â¢
    S : SELECT
    I  : INSERT
    U : UPDATE
    D : DELETE


2005.04.11 updated

ALTER TABLE  CHARACTER_TBL  ADD   m_aCompleteQuest  varchar(1024) NULL
ALTER TABLE CHARACTER_TBL  ALTER COLUMN   m_lpQuestCntArray	VARCHAR(3072) NULL

*******************************************************/
AS
set nocount on
declare @last_connect tinyint
set @last_connect = 1

DECLARE @om_chLoginAuthority CHAR(1),@oaccount VARCHAR(32),@oplayerslot INT

IF @iGu = 'S2' -- Â¨Ã¶Â¨Ã¶Â¡Â¤OÂ¢Â¯Â¢Â® Â¥Ã¬uÂ¢Â¬Â¡Ã CAÂ¡Â¤Â©Ã¶AIÂ¨ÃºiÂ¢Â¬Â¢Ã§Â¨Ã¶Â¨Â¬Â¨Â¡Â¢Ã§ AIÂ¨Â¬Â¡ÃAaÂ¢Â¬Â¢Ã§AÂ¢Â´Â¨Â¬Â¢Â¬  Â¡Ã†Â¢Â®AÂ¢Ã§Â¢Â¯AÂ¡Â¾a
	BEGIN
		IF @iaccount = '' OR @im_szName  = ''
 		BEGIN
 			SELECT m_chAuthority = '',fError = '1', fText = 'Â¨ÃºIEÂ¡ÃŒÂ¨Â¡Â©Ã·Â¢Â¬Â©Ã·'
 			RETURN
 		END

		select playerslot,max(m_idPlayer) as m_idplayer
		into #temp_realPlayerslot
		from dbo.CHARACTER_TBL A
		where A.isblock = 'F' AND A.account = @iaccount AND A.serverindex = @iserverindex  
		group by playerslot

			SELECT	A.dwWorldID, 
							A.m_szName,
					 		A.playerslot,
							A.End_Time, 
							A.BlockTime,
							A.m_dwIndex, 
							A.m_idPlayer, 
							A.m_idparty,
							A.m_dwSkinSet, 
							A.m_dwHairMesh, 
							A.m_dwHeadMesh, 
							A.m_dwHairColor, 
							A.m_dwSex, 
							A.m_nJob, 
							A.m_nLevel, 
							A.m_vPos_x, 
							A.m_vPos_y, 
							A.m_vPos_z, 
							A.m_nStr,
							A.m_nSta,
							A.m_nDex,
							A.m_nInt,
							A.m_aJobLv,
							A.m_chAuthority,
							A.m_idCompany,
							A.m_nMessengerState,
							B.m_Inventory, 
							B.m_apIndex,
							B.m_adwEquipment,
							B.m_dwObjIndex,
							m_idGuild = CASE WHEN C.m_idGuild  IS NULL THEN '0' ELSE C.m_idGuild END	,
							m_idWar = CASE WHEN C.m_idWar  IS NULL THEN '0' ELSE C.m_idWar END,
							D.m_extInventory,
							D.m_InventoryPiercing,
							------------- ver. 13
							A.m_nHonor,
							last_connect = @last_connect
			FROM CHARACTER_TBL as A 
				inner join INVENTORY_TBL as B on A.m_idPlayer = B.m_idPlayer and A.serverindex = B.serverindex
				inner join INVENTORY_EXT_TBL as D on B.serverindex = D.serverindex and B.m_idPlayer = D.m_idPlayer
				inner join #temp_realPlayerslot as ttt on A.m_idPlayer = ttt.m_idPlayer AND A.playerslot= ttt.playerslot
				left outer join GUILD_MEMBER_TBL as C on D.m_idPlayer = C.m_idPlayer and D.serverindex = C.serverindex
			WHERE 	A.isblock = 'F'
				AND A.account = @iaccount  
				AND A.serverindex = @iserverindex
			ORDER BY A.playerslot

insert into CHARACTER_TBL_penya_check (account, m_szName, m_dwGold, check_sec, serverindex)
select @iaccount, m_szName, m_dwGold, 9, @iserverindex
from CHARACTER_TBL (nolock)
where account = @iaccount and serverindex = @iserverindex and TotalPlayTime < 1 and m_dwGold >= 1

				RETURN
 	END
ELSE
IF @iGu = 'S3' -- Â¨Ã¹Â¡Â©Â©Ã¶oÂ¡Ã†Â¢Â® AÂ©Ã¸AÂ¨Ã¶Â¨Ã¶CCaAÂ¡Ã­ COÂ¢Â¥e AÂ©Ã¸Â¢Â¬?AIAC idPlayerÂ¢Â¬| Â¢Â¥U Â¡Ã†Â¢Â®AoÂ¡Ã†iÂ¢Â¯E
	BEGIN
		 SELECT m_szName, m_idPlayer,m_idCompany
			FROM CHARACTER_TBL 
		 WHERE serverindex = @iserverindex 
--			  AND  isblock = 'F'
		 ORDER BY m_idPlayer
		RETURN
	END
	

ELSE
IF @iGu = 'S4' -- AÂ©Â¬Â¡Ã†Â¢Â®CO Â¨ÃºÂ¨Â¡AIAU EÂ¢Ã§AI
	BEGIN

	declare @s4_account varchar(32), @i1_e_date datetime

		declare @q1 nvarchar(4000)

		set @q1 = '
		SELECT 	Item_Name, Item_count, m_nAbilityOption, m_nNo, m_bItemResist, m_nResistAbilityOption,
			m_bCharged, nPiercedSize, adwItemId0, adwItemId1, adwItemId2, adwItemId3, adwItemId4,
			m_dwKeepTime, nRandomOptItemId,
			isnull(adwItemId5, 0) as adwItemId5, isnull(adwItemId6, 0) as adwItemId6, isnull(adwItemId7, 0) as adwItemId7, isnull(adwItemId8, 0) as adwItemId8, isnull(adwItemId9, 0) as adwItemId9, isnull(nUMPiercedSize, 0) as nUMPiercedSize,
			isnull(adwUMItemId0, 0) as adwUMItemId0, isnull(adwUMItemId1, 0) as adwUMItemId1, isnull(adwUMItemId2, 0) as adwUMItemId2, isnull(adwUMItemId3, 0) as adwUMItemId3, isnull(adwUMItemId4, 0) as adwUMItemId4
		FROM ITEM_SEND_TBL 
		WHERE m_idPlayer = @im_idPlayer 	
			AND serverindex = @iserverindex
			AND ItemFlag = 0'
		exec sp_executesql @q1, N'@im_idPlayer char(7), @iserverindex char(2)', @im_idPlayer, @iserverindex
		RETURN
	END
	

ELSE
IF @iGu = 'S5' -- Â¨ÃºÂ¨Â¡AIAU AoÂ¡Â¾Â¨Â­EA AÂ¡Â¿AIÂ¨Â¬iÂ¢Â¯Â¢Â®Â¨Ã¹Â¡Â© Â¨ÃºÂ¨Â¡AIAU Â¡Ã­eA|
	BEGIN
--		DELETE ITEM_SEND_TBL 
		UPDATE ITEM_SEND_TBL SET ProvideDt=getdate(), ItemFlag=1
 		 WHERE	m_nNo  = @iplayerslot
		IF @@ROWCOUNT = 0
		SELECT fError = '0'
		ELSE
		SELECT fError = '1'
		RETURN
	END


ELSE
IF @iGu = 'S6' -- Â¡Ã­eA|CO Â¨ÃºÂ¨Â¡AIAU EÂ¢Ã§AI

	BEGIN
		SELECT 	Item_Name, 
						Item_count,
						m_nAbilityOption,
						m_nNo,
						State,
						m_bItemResist,
						m_nResistAbilityOption
			FROM ITEM_REMOVE_TBL 
 		 WHERE	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex
			  AND  	ItemFlag = 0
	RETURN
	END


ELSE
IF @iGu = 'S7' -- Â¨ÃºÂ¨Â¡AIAU Â¡Ã­eA|EA AÂ¡Â¿AIÂ¨Â¬iÂ¢Â¯Â¢Â®Â¨Ã¹Â¡Â© Â¨ÃºÂ¨Â¡AIAU Â¡Ã­eA|
	BEGIN
--		DELETE  ITEM_REMOVE_TBL 
		UPDATE ITEM_REMOVE_TBL SET DeleteDt=getdate(), ItemFlag=1
 		 WHERE	m_nNo  = @iplayerslot

		IF @@ROWCOUNT = 0
		SELECT fError = '0'
		ELSE
		SELECT fError = '1'
		RETURN
	END


IF @iGu = 'S8' -- Â¥Ã¬Â¡ÃAIAI AuAÂ¨Ã¹ Â¡Ã†Â¢Â®AÂ¢Ã§Â¢Â¯AÂ¡Â¾a
	BEGIN


				SELECT @om_chLoginAuthority = m_chLoginAuthority
				  FROM  ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL 
				WHERE account   = @iaccount
						
				
				SELECT	m_chLoginAuthority = @om_chLoginAuthority,
								A.account,
								A.m_idPlayer,
								A.playerslot,
								A.serverindex,
								A.dwWorldID,
								A.m_szName,
								A.m_dwIndex,
								A.m_vScale_x,
								A.m_dwMotion,
								A.m_vPos_x,
								A.m_vPos_y,
								A.m_vPos_z,
								A.m_fAngle,
								A.m_szCharacterKey,
								A.m_idPlayer,
								A.m_nHitPoint,
								A.m_nManaPoint,
								A.m_nFatiguePoint,
								A.m_nFuel,
								A.m_dwSkinSet,
								A.m_dwHairMesh,
								A.m_dwHairColor,
								A.m_dwHeadMesh,
								A.m_dwSex,
								A.m_dwRideItemIdx,
								A.m_dwGold,
								A.m_nJob,
								A.m_pActMover,
								A.m_nStr,
								A.m_nSta,
								A.m_nDex,
								A.m_nInt,
								A.m_nLevel,

								A.m_nMaximumLevel,
								A.m_nExp1,
								A.m_nExp2,
								A.m_aJobSkill,
								A.m_aLicenseSkill,
								A.m_aJobLv,
								A.m_dwExpertLv,
								A.m_idMarkingWorld,
								A.m_vMarkingPos_x,
								A.m_vMarkingPos_y,
								A.m_vMarkingPos_z,
								A.m_nRemainGP,
								A.m_nRemainLP,
								A.m_nFlightLv,
								A.m_nFxp,
								A.m_nTxp,
								A.m_lpQuestCntArray,
								m_aCompleteQuest = ISNULL(A.m_aCompleteQuest,'$'),
								A.m_chAuthority,
								A.m_dwMode,
								A.m_idparty,
								A.m_idCompany,
								A.m_idMuerderer,
								A.m_nFame,
								A.m_nDeathExp,
								A.m_nDeathLevel,
								A.m_dwFlyTime,
								A.m_nMessengerState,
								A.End_Time,
								A.BlockTime,
								A.blockby,
								A.isblock,
								A.TotalPlayTime,
								A.CreateTime,
								A.m_dwSkillPoint,
								B.m_aSlotApplet,								
								B.m_aSlotQueue,
								B.m_SkillBar,
								C.m_aSlotItem,
								D.m_Inventory,
								D.m_apIndex,
								D.m_adwEquipment,
								D.m_dwObjIndex,
								m_idGuild = ISNULL(G.m_idGuild,'0'),
								m_idWar = ISNULL(G.m_idWar,'0'),
								A.m_tmAccFuel,
								A.m_tGuildMember,		
								m_dwSMTime = ISNULL(H.m_dwSMTime,'NULL')	,
								SkillInfluence = ISNULL(E.SkillInfluence,'$'),
								F.m_extInventory,																						 		
								F.m_InventoryPiercing,
								A.m_dwReturnWorldID,
								A.m_vReturnPos_x,
								A.m_vReturnPos_y,
								A.m_vReturnPos_z,
								last_connect = @last_connect,
								A.m_SkillPoint,
								A.m_SkillLv,
						        A.m_SkillExp,
						      -------------- (2006 11 13 AÂ©Â¬Â¡Ã†Â¢Â® Â¨Â¬IÂ¨Â¬Â¨Â¢ : Attedant Event)
						        A.dwEventFlag,
						        A.dwEventTime,
						        A.dwEventElapsed
						      -------------- (Version8 : PK System)
								,A.PKValue 		as m_nPKValue
								,A.PKPropensity as m_dwPKPropensity
								,A.PKExp 		as m_dwPKExp
						      -------------- (Version8 : Angel System)
								,A.AngelExp 	as m_nAngelExp
								,A.AngelLevel 	as m_nAngelLevel
							------------------- Version9 Pet

								,F.szInventoryPet as szInventoryPet
								,A.m_dwPetId
								, A.m_nExpLog, A.m_nAngelExpLog
								,m_nCoupon
								------------ ver. 13
								, A.m_nLayer
								---------- Ver 15
								, A.m_aCheckedQuest	
								, A.m_nCampusPoint
								, A.idCampus
								, isnull(R.m_nRestPoint, 0) m_nRestPoint
								, isnull(R.m_LogOutTime, 0) m_LogOutTime
			FROM CHARACTER_TBL A 
					inner join TASKBAR_TBL B on A.m_idPlayer   = B.m_idPlayer and A.serverindex  = B.serverindex
					inner join TASKBAR_ITEM_TBL C on B.m_idPlayer   = C.m_idPlayer and B.serverindex  = C.serverindex
					inner join INVENTORY_TBL D on C.m_idPlayer   = D.m_idPlayer and C.serverindex  = D.serverindex
					inner join SKILLINFLUENCE_TBL E on D.m_idPlayer   = E.m_idPlayer and D.serverindex  = E.serverindex
					inner join INVENTORY_EXT_TBL F on E.m_idPlayer   = F.m_idPlayer and E.serverindex  = F.serverindex
					left outer join GUILD_MEMBER_TBL G on F.serverindex = G.serverindex and F.m_idPlayer = G.m_idPlayer
					left outer join BILING_ITEM_TBL H on F.serverindex = H.serverindex and F.m_idPlayer = H.m_idPlayer
					left outer join tblRestPoint R on F.serverindex = R.serverindex and F.m_idPlayer = R.m_idPlayer
			WHERE A.m_idPlayer = @im_idPlayer
					AND A.serverindex = @iserverindex
					AND A.account = lower(@iaccount)
					AND A.isblock = 'F' -- fix

insert into CHARACTER_TBL_validity_check (m_idPlayer, serverindex, account, m_szName, TotalPlayTime, m_dwGold, m_nLevel, m_nJob, sum_ability, CreateTime)
select m_idPlayer, serverindex, account, m_szName, TotalPlayTime, m_dwGold, m_nLevel, m_nJob, (m_nStr + m_nSta + m_nDex + m_nInt), CreateTime
from CHARACTER_TBL (nolock)
where m_idPlayer = @im_idPlayer and TotalPlayTime <= 1
	and (m_dwGold >= 1 or m_nLevel >= 2 or m_nJob >= 1 or (m_nStr + m_nSta + m_nDex + m_nInt) > 60)


declare @m_dwGold_old bigint, @m_dwGold_now bigint
select @m_dwGold_old = m_dwGold from tblLogout_Penya (nolock) where m_idPlayer = @im_idPlayer
select @m_dwGold_now = m_dwGold from CHARACTER_TBL (nolock) where serverindex = @iserverindex and m_idPlayer = @im_idPlayer
if (@m_dwGold_old <> @m_dwGold_now)
begin
	insert into tblLogout_Penya_Diff_Log (serverindex, m_idPlayer, m_dwGold_old, regdate_old, m_dwGold_now)
	select serverindex, m_idPlayer, @m_dwGold_old, regdate, @m_dwGold_now
	from tblLogout_Penya (nolock)
	where m_idPlayer = @im_idPlayer and serverindex = @iserverindex
end

				-- Â©Ã¶Â©Â£AÂ¨Ã AÂ¢Â´Â¨Â¬Â¢Â¬ Â¡Ã†Â¢Â®AÂ¢Ã§Â¢Â¯AÂ¡Â¾a account Â¨Â¬Â¡Ã†
	
-- 				DECLARE @bank TABLE (m_idPlayer CHAR(6),serverindex CHAR(2),playerslot INT)
-- 
-- 				INSERT @bank
-- 				(m_idPlayer,serverindex,playerslot)
--               SELECT m_idPlayer,serverindex,playerslot 
--               FROM CHARACTER_TBL 
--               WHERE account = @iaccount 
--               AND isblock = 'F'
--               ORDER BY playerslot

				SELECT  a.m_idPlayer,
								c.playerslot,
 								a.m_Bank,
								a.m_apIndex_Bank,
								a.m_dwObjIndex_Bank,
								a.m_dwGoldBank,
								a.m_BankPw,				 		
								b.m_extBank,
						                            b.m_BankPiercing
								,b.szBankPet
				   FROM 	dbo.BANK_TBL a,
                            dbo.BANK_EXT_TBL b,	
                            dbo.CHARACTER_TBL  c
               WHERE 	a.m_idPlayer = b.m_idPlayer
                    AND a.serverindex = b.serverindex
                    AND b.m_idPlayer = c.m_idPlayer
                    AND b.serverindex = c.serverindex
 					  AND c.account = @iaccount 
                    AND c.isblock = 'F'
				ORDER BY c.playerslot

				-- Pocket Info
			SELECT	a.nPocket,
				a.szItem,
				a.szIndex,
				a.szObjIndex,
				a.bExpired,
				a.tExpirationDate,
				b.szExt,
				b.szPiercing,
				b.szPet
			FROM	tblPocket as a inner join tblPocketExt as b
				on a.serverindex = b.serverindex AND a.idPlayer = b.idPlayer AND a.nPocket = b.nPocket
			WHERE a.serverindex = @iserverindex AND a.idPlayer = @im_idPlayer
			ORDER BY a.nPocket

		RETURN
	END

ELSE
IF @iGu = 'U1' -- AÂ©Ã¸Â¢Â¬?AI AuAa
	BEGIN
		UPDATE CHARACTER_TBL
		      SET	dwWorldID 				= @idwWorldID,
						m_dwIndex 				= @im_dwIndex,			
						m_dwSex	 				= @im_dwSex,
						m_vScale_x 				= @im_vScale_x,						
						m_dwMotion 				= @im_dwMotion,
						m_vPos_x 					= @im_vPos_x,
						m_vPos_y 					= @im_vPos_y,
						m_vPos_z 					= @im_vPos_z,
						m_dwHairMesh    	= @im_dwHairMesh,
						m_dwHairColor	    	= @im_dwHairColor,
						m_dwHeadMesh	   	= @im_dwHeadMesh,  -- 2004/11/08   AÂ©Â¬Â¡Ã†Â¢Â®  
						m_fAngle 					= 0, --@im_fAngle,
						m_szCharacterKey 	= @im_szCharacterKey,
						m_nHitPoint 				= @im_nHitPoint,
						m_nManaPoint 			= @im_nManaPoint,
						m_nFatiguePoint 		= @im_nFatiguePoint,
						m_nFuel						= @im_nFuel,
						m_dwRideItemIdx 		= @im_dwRideItemIdx,
						m_dwGold 					= @im_dwGold,
						m_nJob 						= @im_nJob,
						m_pActMover 			= @im_pActMover,
						m_nStr 						= @im_nStr,
						m_nSta 						= @im_nSta,
						m_nDex 						= @im_nDex,
						m_nInt 						= @im_nInt,
						m_nLevel 					= @im_nLevel,
						m_nMaximumLevel	= CASE WHEN m_nMaximumLevel < @im_nLevel THEN @im_nLevel ELSE m_nMaximumLevel END,
						m_nExp1	 				= @im_nExp1,
						m_nExp2 					= @im_nExp2,
						m_aJobSkill 				= @im_aJobSkill,
						m_aLicenseSkill 		= @im_aLicenseSkill,
						m_aJobLv 					= @im_aJobLv,
						m_dwExpertLv 			= @im_dwExpertLv,
						m_idMarkingWorld 	= @im_idMarkingWorld,
						m_vMarkingPos_x 	= @im_vMarkingPos_x,
						m_vMarkingPos_y 	= @im_vMarkingPos_y,
						m_vMarkingPos_z 	= @im_vMarkingPos_z,
						m_nRemainGP 			= @im_nRemainGP,
						m_nRemainLP 			= @im_nRemainLP,
						m_nFlightLv 				= @im_nFlightLv,
						m_nFxp 						= @im_nFxp,
						m_nTxp 						= @im_nTxp,
						m_lpQuestCntArray 	= @im_lpQuestCntArray,
						m_aCompleteQuest = @im_aCompleteQuest,
						m_dwMode 				= @im_dwMode,
						m_idparty 					= @im_idparty,
						m_idMuerderer 		= @im_idMuerderer,
						m_nFame 					= @im_nFame,	
						m_nDeathExp			= @im_nDeathExp,
						m_nDeathLevel			= @im_nDeathLevel,
						--m_dwFlyTime				= m_dwFlyTime + @im_dwFlyTime,
						m_dwFlyTime = @im_dwFlyTime,
						m_nMessengerState = @im_nMessengerState,
						TotalPlayTime 			= TotalPlayTime + @iTotalPlayTime,
						m_tmAccFuel 			= @im_tmAccFuel,
						m_dwSkillPoint			= @im_dwSkillPoint,
						m_dwReturnWorldID= @im_dwReturnWorldID,
						m_vReturnPos_x		= @im_vReturnPos_x,
						m_vReturnPos_y		= @im_vReturnPos_y,
						m_vReturnPos_z		= @im_vReturnPos_z,
						m_SkillPoint		=@im_SkillPoint,
						m_SkillLv			=@im_SkillLv,
				        m_SkillExp                      =@im_SkillExp
				      -------------- (AÂ©Â¬Â¡Ã†Â¢Â® Â¨Â¬IÂ¨Â¬Â¨Â¢ : 2006 11 13 Attendant Event)
				        , dwEventFlag                     =@idwEventFlag
				        , dwEventTime                     =@idwEventTime
				        , dwEventElapsed          =@idwEventElapsed
				      -------------- (ADD: Version8-PK System)

						, PKValue        	= @im_nPKValue
						, PKPropensity   	= @im_dwPKPropensity
						, PKExp         	= @im_dwPKExp
				      -------------- (ADD: Version8-Angel System)
						, AngelExp			= @im_nAngelExp
						, AngelLevel		= @im_nAngelLevel
					--------------------- Version9 Pet
						, m_dwPetId = @im_dwPetId

						, m_nExpLog = @im_nExpLog
						, m_nAngelExpLog = @im_nAngelExpLog
						, m_nCoupon = @im_nCoupon
						------------- ver. 13
						, m_nHonor = @im_nHonor
						, m_nLayer = @im_nLayer
						---------- Ver 15
						, m_aCheckedQuest = @im_aCheckedQuest
						, m_nCampusPoint = @im_nCampusPoint
						, idCampus = @im_idCampus
				WHERE   m_idPlayer                              = @im_idPlayer  
				AND 	serverindex 				= @iserverindex

-- 		if object_id('QUEST_TBL') is not null
-- 			EXEC QUEST_STR 'A1',@im_idPlayer,@iserverindex,@im_lpQuestCntArray

update tblLogout_Penya
set m_dwGold = @im_dwGold, regdate = getdate()
where m_idPlayer = @im_idPlayer and serverindex = @iserverindex

		IF @im_nLevel>=120 BEGIN
			UPDATE 	CHARACTER_TBL 
				SET FinalLevelDt=getdate() 
			WHERE 	serverindex=@iserverindex 
				AND m_idPlayer=@im_idPlayer 
				AND FinalLevelDt='2000-01-01'
		END

		--Â¨Ã¹UCoÂ¨Ã¹Â¢Ã§ Â¢Â¯aAÂ¡Ã­Â¡Ã­cCÂ¡Â¿ Â¨Â¬oÂ¢Â¬Â¥Ã¬ Â¡Ã†uÂ¡Â¤A
		IF @im_dwSMTime > '' 
			BEGIN
				IF EXISTS(SELECT * FROM BILING_ITEM_TBL WHERE m_idPlayer= @im_idPlayer  AND serverindex 	= @iserverindex)
				UPDATE BILING_ITEM_TBL
						SET m_dwSMTime = @im_dwSMTime
				 WHERE	m_idPlayer   				= @im_idPlayer 	
					  AND 	serverindex 				= @iserverindex
				ELSE
				INSERT BILING_ITEM_TBL
					(m_idPlayer,serverindex,m_dwSMTime)
				VALUES
					(@im_idPlayer,@iserverindex,@im_dwSMTime)
			END
		ELSE
			 DELETE BILING_ITEM_TBL
			 WHERE	m_idPlayer   				= @im_idPlayer 	
			      AND 	serverindex 				= @iserverindex

			
-- 		UPDATE 	CARD_CUBE_TBL 
-- 				SET m_Card 						= @im_Card,
-- 						m_apIndex_Card 		= @im_Index_Card,
-- 						m_dwObjIndex_Card= @im_ObjIndex_Card,
-- 						m_Cube 						= @im_Cube,
-- 						m_apIndex_Cube 	= @im_Index_Cube,
-- 						m_dwObjIndex_Cube=@im_ObjIndex_Cube 
-- 		 WHERE	m_idPlayer   				= @im_idPlayer 	
-- 			  AND 	serverindex 				= @iserverindex
		
		UPDATE INVENTORY_TBL 
		      SET 	m_Inventory 				= @im_Inventory,
						m_apIndex 				= @im_apIndex,
						m_adwEquipment 	= @im_adwEquipment,
						m_dwObjIndex 			= @im_dwObjIndex
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex
		

		
		UPDATE TASKBAR_TBL 
			  SET 	m_aSlotApplet 			= @im_aSlotApplet,
						m_aSlotQueue 			= @im_aSlotQueue,
						m_SkillBar					= @im_SkillBar
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex




		UPDATE TASKBAR_ITEM_TBL 
			  SET 	m_aSlotItem 				= @im_aSlotItem						
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex

		UPDATE BANK_TBL 
			  SET 	m_Bank 						= @im_Bank,
						m_apIndex_Bank 		= @im_apIndex_Bank, 
						m_dwObjIndex_Bank = @im_dwObjIndex_Bank, 
						m_dwGoldBank 		= @im_dwGoldBank
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex

		UPDATE SKILLINFLUENCE_TBL
			 SET SkillInfluence = @iSkillInfluence
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex

		UPDATE INVENTORY_EXT_TBL 
		      SET 	m_extInventory 				= @im_extInventory,
						m_InventoryPiercing= @im_InventoryPiercing
			,szInventoryPet	= @iszInventoryPet
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex

		UPDATE BANK_EXT_TBL 
			  SET 	m_extBank 						= @im_extBank,
						m_BankPiercing			= @im_BankPiercing
			, szBankPet = @iszBankPet
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex

		SELECT fError = '1', fText = 'OK'
		RETURN
	END


ELSE
IF @iGu = 'U2' --AN AIÂ¢Â¯eÂ¨Ã¶AÂ¡Ã†Â¡ÃŒ Â¨Ã¹oAÂ¢Â´
	BEGIN
		UPDATE CHARACTER_TBL
		      SET	TotalPlayTime 			= TotalPlayTime + @iplayerslot 
		 WHERE	m_szName  				= @im_szName 	
			  AND 	serverindex 				= @iserverindex
		RETURN
	END


ELSE
IF @iGu = 'U3' --AN AIÂ¢Â¯eÂ¨Ã¶AÂ¡Ã†Â¡ÃŒ Â¨Ã¹oAÂ¢Â´ new
	BEGIN
		UPDATE CHARACTER_TBL
		      SET	TotalPlayTime 			= TotalPlayTime + @iplayerslot 
		 WHERE 	m_idPlayer   				= @im_idPlayer 	
			  AND 	serverindex 				= @iserverindex
		RETURN
	END

ELSE
IF @iGu = 'U4' --AÂ©Ã¸Â¢Â¬?AI Â¢Â¬i Â¨Â¬?Â¡Ã†Â©Â¡
	BEGIN
		IF EXISTS(SELECT m_idPlayer FROM CHARACTER_TBL WHERE m_szName  = @im_szName  AND serverindex	= @iserverindex)
			BEGIN
				SELECT fError = '0'
			END
		ELSE
			BEGIN
				UPDATE CHARACTER_TBL
				      SET	m_szName			= @im_szName
				 WHERE 	m_idPlayer   				= @im_idPlayer 	
					  AND 	serverindex 				= @iserverindex
				SELECT fError = '1'
			END
		RETURN
	END


-- Ver 15
ELSE
IF @iGu = 'U5' --Â¡Ã­cA| Â¨Â¡Â¡Ã€AIÂ¨Â¡Â¢Ã§ Â¨ÃºÂ¡Ã€Â¥Ã¬Â¡ÃAIÂ¨Â¡Â¢Ã§ AÂ©Â¬Â¡Ã†Â¢Â®
	BEGIN
		IF EXISTS(SELECT m_idPlayer FROM CHARACTER_TBL WHERE m_idPlayer = @im_idPlayer AND serverindex	= @iserverindex)
			BEGIN
				UPDATE CHARACTER_TBL
				      SET	m_nCampusPoint			= m_nCampusPoint + @iplayerslot
				 WHERE 	m_idPlayer   				= @im_idPlayer 	
					  AND 	serverindex 				= @iserverindex

				declare @u5m_nCampusPoint int

				select @u5m_nCampusPoint = m_nCampusPoint from CHARACTER_TBL (nolock) WHERE  m_idPlayer = @im_idPlayer AND serverindex	= @iserverindex
				SELECT fError = '1', @u5m_nCampusPoint  m_nCampusPoint
			END
		ELSE
		RETURN
	END
ELSE
IF @iGu = 'U6' -- Â¡Ã­cA| ID Â¨ÃºÂ¡Ã€Â¥Ã¬Â¡ÃAIÂ¨Â¡Â¢Ã§ AÂ©Â¬Â¡Ã†Â¢Â®
	BEGIN
		IF EXISTS(SELECT m_idPlayer FROM CHARACTER_TBL WHERE  m_idPlayer = @im_idPlayer AND serverindex	= @iserverindex)
			BEGIN
				UPDATE CHARACTER_TBL
				      SET	idCampus			= @iplayerslot
				 WHERE 	m_idPlayer   				= @im_idPlayer 	
					  AND 	serverindex 				= @iserverindex
				SELECT fError = '1'
			END
		ELSE
			BEGIN
				SELECT fError = '0'
			END
		RETURN
	END


ELSE
IF @iGu = 'D1' -- AÂ©Ã¸Â¢Â¬?AI Â¡Ã­eA|
	BEGIN
		IF @im_szName = ''
		BEGIN
			SELECT fError = '1', fText = '2AÂ¡Ã€ Â¨Â¬nÂ©Ã¶Â¨Â¢Â©Ã¶Â©ÂªEÂ¡ÃŒ Â¨Â¡Â©Ã·Â¢Â¬Â©Ã·'
			RETURN
		END
			if not exists (select * from CHARACTER_TBL where m_idPlayer = @im_idPlayer and account = @iaccount and serverindex = @iserverindex)
			begin
				select fError = '1'
				return
			end

			DECLARE @Exists int
/*	
			IF EXISTS(SELECT name  from syscolumns where name='m_idPlayer' AND collation= 'Japanese_BIN')
				BEGIN
					IF EXISTS(SELECT * FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL  WHERE account = @iaccount AND (password =  @im_szName OR member = 'B' ))
		              SET @Exists = 1
					ELSE
						SET @Exists = 0				
				END
			ELSE
				BEGIN
--					IF EXISTS(SELECT *  FROM ACCOUNT_DBF.dbo.ACCOUNT_TBL  WHERE account = @iaccount AND (id_no2 =  @im_szName OR member = 'B' ))
					if exists (select  *  from BANK_TBL (nolock) where m_idPlayer = @im_idPlayer AND m_BankPw =  @im_szName )
		              SET @Exists = 1
					ELSE
						SET @Exists = 0		
				END
*/
set @Exists = 1
			IF @Exists > 0
				BEGIN
					DECLARE @currDate char(12)				
					SET @currDate = CONVERT(CHAR(8),GETDATE(),112) 
											   + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
											   + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2)



					IF EXISTS(SELECT m_idPlayer FROM GUILD_MEMBER_TBL WHERE 	m_idPlayer = @im_idPlayer AND serverindex = @iserverindex	AND m_idWar > 0)
						BEGIN
						SELECT fError = '3', fText = 'Â¡Â¾Â©Â¡Â¥Ã¬aAuAÂ©Â¬'
						RETURN
						END
					ELSE
						BEGIN
						UPDATE CHARACTER_TBL
							  SET isblock 						= 'D',
									  End_Time						= @currDate ,	
									  BlockTime					= LEFT(@currDate,8)
						WHERE 	m_idPlayer   				= @im_idPlayer 	
							  AND 	serverindex 				= @iserverindex	
	
						UPDATE MESSENGER_TBL
							   SET State = 'D'
						 WHERE 	m_idPlayer   				= @im_idPlayer 	
							  AND 	serverindex 				= @iserverindex	
	
						UPDATE MESSENGER_TBL
							   SET State = 'D'
						 WHERE 	f_idPlayer   				= @im_idPlayer 	
							  AND 	serverindex 				= @iserverindex	



						IF EXISTS(SELECT m_idPlayer FROM GUILD_MEMBER_TBL   WHERE 	m_idPlayer = @im_idPlayer AND serverindex = @iserverindex) 
							BEGIN
								SELECT fError = '4', fText = m_idGuild FROM GUILD_MEMBER_TBL   WHERE 	m_idPlayer = @im_idPlayer AND serverindex = @iserverindex
								RETURN

							END
						ELSE
							BEGIN
								SELECT fError = '0', fText = 'DELETE OK'
								RETURN
							END
							
						END
				END
			ELSE
				BEGIN
					SELECT fError = '1', fText = 'AOÂ©Ã¶IÂ©Ã¶Â©ÂªEÂ¡ÃŒÂ¨Â¡Â©Ã·Â¢Â¬Â©Ã·'
					RETURN
				END
	END


ELSE
IF @iGu = 'I1' -- AEÂ¡Â¾a AÂ¢Â´Â¨Â¬Â¢Â¬ AOÂ¡Â¤A
	BEGIN
	
	IF (SELECT COUNT(*) AS [Count] FROM [CHARACTER_TBL] WHERE [account] = @iaccount AND [isblock] = 'F' AND [playerslot] = @iplayerslot AND [serverindex] = @iserverindex) > 0
		BEGIN
			SELECT fError = '0', fText = 'Can not overwrite player!'
			RETURN
		END

	-- 20100218 Â¡Ã­yÂ¨Ã¹Â¨Â¬ AÂ©Ã¸Â¢Â¬?AI 3Â¡Ã†Â©Ã¸ AEÂ¡Ã†u Â¨Ã¶A
	declare @i1_cnt int
	select @i1_cnt = count(*) from CHARACTER_TBL where account = @iaccount and isblock = 'F'
	if @i1_cnt > 2
	begin
		SELECT  fError = '0', fText = 'AÂ©Ã¸Â¢Â¬?AI Â¢Â¬Â©Ã¶AÂ¨Ã¶!' 
		RETURN
	end

    IF EXISTS(SELECT m_szName FROM CHARACTER_TBL
          WHERE (( lower(m_szName) = lower(@im_szName) ) OR (playerslot = @iPlayerslot AND account = @iaccount  ) ) AND isblock = 'F' AND serverindex = @iserverindex )
        BEGIN
            SELECT  fError = '0', fText = 'Can not overwrite player!' -- fix char overwrite
            RETURN
        END
    ELSE  
		BEGIN
			DECLARE
								@om_idPlayer 					CHAR		(7)		,
								@om_vScale_x					REAL					,
								@om_dwMotion					INT						,
								@om_fAngle						REAL					,
								@om_nHitPoint					INT						,
								@om_nManaPoint				INT						,
								@om_nFatiguePoint			INT						,
								@om_dwRideItemIdx		INT						,
								@om_dwGold					INT						,
								@om_nJob							INT						,
								@om_pActMover				VARCHAR(50)	,
								@om_nStr							INT						,
								@om_nSta							INT						,
								@om_nDex							INT						,
								@om_nInt							INT						,
								@om_nLevel						INT						,
								@om_nExp1						BIGINT						,
								@om_nExp2						BIGINT						,	
								@om_aJobSkill					VARCHAR	(500),
								@om_aLicenseSkill			VARCHAR	(500),
								@om_aJobLv						VARCHAR	(500),
								@om_dwExpertLv				INT						,
								@om_idMarkingWorld		INT						,
								@om_vMarkingPos_x		REAL					,
								@om_vMarkingPos_y		REAL					,
								@om_vMarkingPos_z		REAL					,
								@om_nRemainGP				INT						,
								@om_nRemainLP				INT						,
								@om_nFlightLv					INT						,
								@om_nFxp							INT						,
								@om_nTxp							INT						,
								@om_lpQuestCntArray		VARCHAR(1024),
								@om_chAuthority				CHAR(1)				,
								@om_dwMode					INT						,
								@oblockby							VARCHAR(32)	,
								@oTotalPlayTime				INT						,
								@oisblock							CHAR(1)				,
								@oEnd_Time						CHAR(12)	,
								@om_Inventory					VARCHAR(max),
								@om_apIndex					VARCHAR(1000)	,
								@om_adwEquipment		VARCHAR(135)	,
								@om_aSlotApplet				VARCHAR(3100),
								@om_aSlotItem					VARCHAR(6885),
								@om_aSlotQueue				VARCHAR(225),
								@om_SkillBar						SMALLINT,
								@om_dwObjIndex				VARCHAR(1000)	,
								@om_Card							VARCHAR(1980),
								@om_Cube						VARCHAR(1980),
								@om_apIndex_Card			VARCHAR(215)	,
								@om_dwObjIndex_Card	VARCHAR(215)	,
								@om_apIndex_Cube		VARCHAR(215)	,
								@om_dwObjIndex_Cube	VARCHAR(215)	,
								@om_idparty						INT						,
								@om_idMuerderer			INT						,
								@om_nFame						INT						,
								@om_nDeathExp				BIGINT						,
								@om_nDeathLevel			INT						,
								@om_dwFlyTime				INT						,
								@om_nMessengerState	INT						,
								@om_Bank							VARCHAR(4290),
								@om_apIndex_Bank		 	VARCHAR(215)	,
								@om_dwObjIndex_Bank VARCHAR(215)	,
								@om_dwGoldBank			INT						
								---------- Ver 15
								, @om_aCheckedQuest varchar(100) 
								, @om_nCampusPoint int 
								, @om_idCampus int

				 IF EXISTS (SELECT * FROM CHARACTER_TBL WHERE  serverindex = @iserverindex)
				 SELECT @om_idPlayer = RIGHT('0000000' + CONVERT(VARCHAR(7),MAX(m_idPlayer)+1),7)
			       FROM CHARACTER_TBL
				  WHERE  serverindex = @iserverindex
				ELSE		
				SELECT @om_idPlayer = '0000001'	
			
				 SELECT @om_vScale_x 				= m_vScale_x,
								@om_dwMotion 				= m_dwMotion,
								@om_fAngle 						= m_fAngle,
								@om_nHitPoint 					= m_nHitPoint,
								@om_nManaPoint 			= m_nManaPoint,
								@om_nFatiguePoint 			= m_nFatiguePoint,
								@om_dwRideItemIdx 		= m_dwRideItemIdx,
								@om_dwGold 					= m_dwGold,
								@om_nJob 						= m_nJob,
								@om_pActMover 				= m_pActMover,
								@om_nStr 							= m_nStr,

								@om_nSta 							= m_nSta,
								@om_nDex 						= m_nDex,
								@om_nInt 							= m_nInt,
								@om_nLevel 						= m_nLevel,
								@om_nExp1 						= m_nExp1,
								@om_nExp2 						= m_nExp2,

								@om_aJobSkill 					= m_aJobSkill,
								@om_aLicenseSkill 			= m_aLicenseSkill,
								@om_aJobLv 					= m_aJobLv,
								@om_dwExpertLv 				= m_dwExpertLv,
								@om_idMarkingWorld 		= m_idMarkingWorld,
								@om_vMarkingPos_x 		= m_vMarkingPos_x,
								@om_vMarkingPos_y 		= m_vMarkingPos_y,
								@om_vMarkingPos_z 		= m_vMarkingPos_z,
								@om_nRemainGP 			= m_nRemainGP,
								@om_nRemainLP 			= m_nRemainLP,
								@om_nFlightLv 					= m_nFlightLv,
								@om_nFxp 						= m_nFxp,
								@om_nTxp 						= m_nTxp,
								@om_lpQuestCntArray		= m_lpQuestCntArray,
								@om_chAuthority 				= m_chAuthority,
								@om_dwMode 					= m_dwMode,
								@oblockby 						= blockby,
								@oTotalPlayTime 				= TotalPlayTime,
								@oisblock 							= isblock,
								@oEnd_Time 					= CONVERT(CHAR(8),DATEADD(yy,3,GETDATE()),112) + '0000',
								@om_Inventory 					= m_Inventory,
								@om_apIndex 					= m_apIndex,
								@om_adwEquipment 		= m_adwEquipment,
								@om_aSlotApplet 				= m_aSlotApplet,
								@om_aSlotItem 					= m_aSlotItem,
								@om_aSlotQueue 			= m_aSlotQueue,
								@om_SkillBar						= m_SkillBar,
								@om_dwObjIndex 			= m_dwObjIndex,
								@om_Card 						= m_Card,
								@om_Cube 						= m_Cube,
								@om_apIndex_Card 		= m_apIndex_Card,
								@om_dwObjIndex_Card	= m_dwObjIndex_Card,
								@om_apIndex_Cube 		= m_apIndex_Cube,
								@om_dwObjIndex_Cube = m_dwObjIndex_Cube,
								@om_idparty 						= m_idparty,			
								@om_idMuerderer 			= m_idMuerderer,
								@om_nFame 						= m_nFame,
								@om_nDeathExp				= m_nDeathExp,
								@om_nDeathLevel			= m_nDeathLevel,
								@om_dwFlyTime				= m_dwFlyTime,
								@om_nMessengerState 	= m_nMessengerState,
								@om_Bank							= m_Bank,
								@om_apIndex_Bank		 	= m_apIndex_Bank,
								@om_dwObjIndex_Bank 	= m_dwObjIndex_Bank,
								@om_dwGoldBank			= m_dwGoldBank			
	
			       FROM BASE_VALUE_TBL
				 WHERE g_nSex 								= @im_dwSex
			


				INSERT CHARACTER_TBL
							(
								m_idPlayer,
								serverindex,
								account,
								m_szName,
								playerslot,
								dwWorldID,
								m_dwIndex,
								m_vScale_x,
								m_dwMotion,
								m_vPos_x,
								m_vPos_y,
								m_vPos_z,
								m_fAngle,
								m_szCharacterKey,
								m_nHitPoint,
								m_nManaPoint,
								m_nFatiguePoint,
								m_nFuel,
								m_dwSkinSet,
								m_dwHairMesh,
								m_dwHairColor,
								m_dwHeadMesh,
								m_dwSex,
								m_dwRideItemIdx,
								m_dwGold,
								m_nJob,
								m_pActMover,
								m_nStr,
								m_nSta,
								m_nDex,
								m_nInt,
								m_nLevel,
								m_nMaximumLevel,
								m_nExp1,
								m_nExp2,
								m_aJobSkill,
								m_aLicenseSkill,
								m_aJobLv,
								m_dwExpertLv,
								m_idMarkingWorld,
								m_vMarkingPos_x,
								m_vMarkingPos_y,
								m_vMarkingPos_z,
								m_nRemainGP,
								m_nRemainLP,
								m_nFlightLv,
								m_nFxp,
								m_nTxp,
								m_lpQuestCntArray,
								m_aCompleteQuest,
								m_chAuthority,
								m_dwMode,
								m_idparty,
								m_idCompany,
								m_idMuerderer,
								m_nFame,
								m_nDeathExp,
								m_nDeathLevel,
								m_dwFlyTime,
								m_nMessengerState,
								blockby,
								TotalPlayTime,
								isblock,
								End_Time,
								BlockTime,
								CreateTime,
								m_tmAccFuel,
								m_tGuildMember,
								m_dwSkillPoint,
								m_dwReturnWorldID,
								m_vReturnPos_x,
								m_vReturnPos_y,
								m_vReturnPos_z,
								m_SkillPoint,
								m_SkillLv,
								m_SkillExp
								---------- Ver 15
								, m_aCheckedQuest
								, m_nCampusPoint
								, idCampus
							)
				VALUES
							(
								@om_idPlayer,
								@iserverindex,
								@iaccount,
								@im_szName,
								@iplayerslot,
								@idwWorldID,
								@im_dwIndex,
								@om_vScale_x,
								@om_dwMotion,
								@im_vPos_x,

								@im_vPos_y,
								@im_vPos_z,
								@om_fAngle,
								@im_szCharacterKey,
								@om_nHitPoint,
								@om_nManaPoint,
								@om_nFatiguePoint,
								-1, --m_nFuel
								@im_dwSkinSet,
								@im_dwHairMesh,
								@im_dwHairColor,
								@im_dwHeadMesh,
								@im_dwSex,
								@om_dwRideItemIdx,
								@om_dwGold,
								@om_nJob,
								@om_pActMover,
								@om_nStr,
								@om_nSta,
								@om_nDex,
								@om_nInt,
								@om_nLevel,
								1, --m_nMaximumLevel
								@om_nExp1,
								@om_nExp2,
								@om_aJobSkill,
								@om_aLicenseSkill,
								@om_aJobLv,
								@om_dwExpertLv,
								@om_idMarkingWorld,
								@om_vMarkingPos_x,
								@om_vMarkingPos_y,
								@om_vMarkingPos_z,
								@om_nRemainGP,
								@om_nRemainLP,
								@om_nFlightLv,
								@om_nFxp,
								@om_nTxp,
								@om_lpQuestCntArray,
								'$', -- m_aCompleteQuest
								@om_chAuthority,
								@om_dwMode,
								@om_idparty,
								'000000', -- m_idCompany
								@om_idMuerderer,
								@om_nFame,
								@om_nDeathExp,
								@om_nDeathLevel,
								@om_dwFlyTime	,
								@om_nMessengerState,
								@oblockby,
								@oTotalPlayTime,
								@oisblock,
								@oEnd_Time,
								CONVERT(CHAR(8),DATEADD(d,-1,GETDATE()),112),
								GETDATE(),
								0,
								CONVERT(CHAR(8),DATEADD(d,-1,GETDATE()),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,DATEADD(d,-1,GETDATE()))),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,DATEADD(d,-1,GETDATE()))),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,DATEADD(d,-1,GETDATE()))),2),
								0, --m_dwSkillPoint
						                            1,
						                            0, 
						                            0,
						                            0,
							@im_SkillPoint,
							@im_SkillLv,
							@im_SkillExp
							-- Ver 15
							, '$'
							, 0
							, 0
							)


				INSERT INVENTORY_TBL
							(
								m_idPlayer,
								serverindex,
								m_Inventory,
								m_apIndex,
								m_adwEquipment,
								m_dwObjIndex
							)
				VALUES 
							(
								@om_idPlayer,
								@iserverindex,
								@om_Inventory,
								@om_apIndex,
								@om_adwEquipment,
								@om_dwObjIndex
							)


-- 				INSERT CARD_CUBE_TBL
-- 							(
-- 								m_idPlayer,
-- 								serverindex,
-- 								m_Card,
-- 								m_Cube,
-- 								m_apIndex_Card,
-- 								m_dwObjIndex_Card,
-- 								m_apIndex_Cube,
-- 								m_dwObjIndex_Cube
-- 							)
-- 				VALUES 
-- 							(
-- 								@om_idPlayer,
-- 								@iserverindex,
-- 								@om_Card,
-- 								@om_Cube,
-- 								@om_apIndex_Card,
-- 								@om_dwObjIndex_Card,
-- 								@om_apIndex_Cube,
-- 								@om_dwObjIndex_Cube
-- 							)



				IF @@SERVERNAME = 'WEB' OR  @@SERVERNAME = 'SERVER4'
				SET @om_aSlotApplet = '2,2,2010,0,2,0,0/3,2,1005,0,3,0,0/4,3,25,0,4,0,0/$'

				INSERT TASKBAR_TBL
							(
								m_idPlayer,
								serverindex,
								m_aSlotApplet,
								m_aSlotQueue,
								m_SkillBar

							)
				VALUES 
							(
								@om_idPlayer,
								@iserverindex,
								@om_aSlotApplet,
								@om_aSlotQueue,
								@om_SkillBar
							)


				INSERT TASKBAR_ITEM_TBL
							(
								m_idPlayer,
								serverindex,
								m_aSlotItem
							)
				VALUES 
							(
								@om_idPlayer,
								@iserverindex,
								@om_aSlotItem
							)
			INSERT BANK_TBL
							(
								m_idPlayer,
								serverindex,
								m_Bank,
								m_BankPw,
								m_apIndex_Bank, 
								m_dwObjIndex_Bank ,
								m_dwGoldBank
							)
				VALUES 
							(
								@om_idPlayer,
								@iserverindex,
								@om_Bank,
								'0000', -- m_BankPw
--								@im_BankPW,
								@om_apIndex_Bank, 
								@om_dwObjIndex_Bank,
								@om_dwGoldBank 
							)

		INSERT SKILLINFLUENCE_TBL
							( 								
								m_idPlayer,
								serverindex,
								SkillInfluence
							)
				VALUES 
							(
								@om_idPlayer,
								@iserverindex,
								'$'
							)

		INSERT INVENTORY_EXT_TBL
							( 								
								m_idPlayer,
								serverindex,
								m_extInventory,
								m_InventoryPiercing
							)
				VALUES 
							(
								@om_idPlayer,
								@iserverindex,
								'$','$'
							)

		INSERT BANK_EXT_TBL
							( 								
								m_idPlayer,
								serverindex,
								m_extBank,
								m_BankPiercing
							)
				VALUES 
							(
								@om_idPlayer,
								@iserverindex,
								'$','$'
							)

		-- Skill Information
		INSERT INTO tblSkillPoint(serverindex, PlayerID, SkillID, SkillLv, SkillPosition)
        	VALUES (@iserverindex, @om_idPlayer, 1, 0, 0)
		INSERT INTO tblSkillPoint(serverindex, PlayerID, SkillID, SkillLv, SkillPosition)
        	VALUES (@iserverindex, @om_idPlayer, 2, 0, 1)
		INSERT INTO tblSkillPoint(serverindex, PlayerID, SkillID, SkillLv, SkillPosition)
        	VALUES (@iserverindex, @om_idPlayer, 3, 0, 2)

		-- Pocket
	INSERT  tblPocket ( serverindex, idPlayer, nPocket, szItem, szIndex, szObjIndex, bExpired, tExpirationDate )
	VALUES ( @iserverindex, @om_idPlayer, 0, '$', '$', '$', 0, 0 )
	
	INSERT  tblPocketExt ( serverindex, idPlayer, nPocket, szExt, szPiercing, szPet )
	VALUES ( @iserverindex, @om_idPlayer, 0, '$', '$', '$' )
	
	INSERT  tblPocket ( serverindex, idPlayer, nPocket, szItem, szIndex, szObjIndex, bExpired, tExpirationDate )
	VALUES ( @iserverindex, @om_idPlayer, 1, '$', '$', '$', 1, 0 )
	
	INSERT  tblPocketExt ( serverindex, idPlayer, nPocket, szExt, szPiercing, szPet )
	VALUES ( @iserverindex, @om_idPlayer, 1, '$', '$', '$' )
	
	INSERT  tblPocket ( serverindex, idPlayer, nPocket, szItem, szIndex, szObjIndex, bExpired, tExpirationDate )
	VALUES ( @iserverindex, @om_idPlayer, 2, '$', '$', '$', 1, 0 )
	
	INSERT  tblPocketExt ( serverindex, idPlayer, nPocket, szExt, szPiercing, szPet )
	VALUES ( @iserverindex, @om_idPlayer, 2, '$', '$', '$' )

	------------------- ver. 13
	insert into tblMaster_all (serverindex, m_idPlayer, sec)
	select @iserverindex, @om_idPlayer, 1
	insert into tblMaster_all (serverindex, m_idPlayer, sec)
	select @iserverindex, @om_idPlayer, 2
	insert into tblMaster_all (serverindex, m_idPlayer, sec)
	select @iserverindex, @om_idPlayer, 3

	------------------- ver. 15
	insert into tblRestPoint (serverindex, m_idPlayer)
	select @iserverindex, @om_idPlayer

	------------ Penay check default setting
	insert into tblLogout_Penya (serverindex, m_idPlayer)
	select @iserverindex, @om_idPlayer


		SELECT fError = '1', fText = 'OK',m_idPlayer=@om_idPlayer
		RETURN
		END
	END


set nocount off
RETURN

GO
/****** Object:  StoredProcedure [dbo].[CHARACTER_DELETE_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE         PROC [dbo].[CHARACTER_DELETE_STR]
AS
DECLARE @serverindex char(2)

DECLARE Delete_Server CURSOR FOR 
SELECT serverindex FROM CHARACTER_TBL GROUP BY serverindex ORDER BY serverindex

OPEN Delete_Server

FETCH NEXT FROM Delete_Server 
INTO @serverindex

WHILE @@FETCH_STATUS = 0
BEGIN

---		DECLARE @DeleteDelayDay int
---		set @DeleteDelayDay = '-7'
---		SELECT * FROM CHARACTER_TBL WHERE isblock='D' AND End_Time <= convert(char(8), DATEADD(d,@DeleteDelayDay,getdate()),112)

					DELETE CHARACTER_TBL WHERE isblock='D' AND  End_Time <= convert(char(8),DATEADD(d,-7,getdate()),112) and serverindex = @serverindex
					
					DECLARE @name varchar(256)
					DECLARE Delete_Cursor CURSOR FOR 
					SELECT	B.name
						FROM	syscolumns A,sysobjects B
						WHERE	A.id = B.id
					   AND B.name NOT IN('CHARACTER_TBL','MESSENGER_TBL')
					   AND A.name = 'm_idPlayer' and A.name = 'serverindex'
					   AND B.type='U'
					ORDER BY B.name
					
					OPEN Delete_Cursor
					
					FETCH NEXT FROM Delete_Cursor 
					INTO @name
					
					WHILE @@FETCH_STATUS = 0
					BEGIN
						PRINT @name + '??'
						EXEC('DELETE ' + @name + ' WHERE m_idPlayer NOT IN (SELECT m_idPlayer FROM CHARACTER_TBL where serverindex = ''' + @serverindex + ''') and serverindex = ''' + @serverindex + '''')
					   FETCH NEXT FROM Delete_Cursor 
					   INTO @name
					END
					
					DELETE TAG_TBL  WHERE f_idPlayer NOT IN (SELECT m_idPlayer FROM CHARACTER_TBL where serverindex = @serverindex) and serverindex = @serverindex
					
					PRINT '??? ?? ??'
					-- ?? 2009-09-16 ??? ?? ?? ?? (EXEC MESSENGER_STR 'D2','',@serverindex ?? ?? ??)
					delete tblMessenger
					where idPlayer not in (select m_idPlayer from CHARACTER_TBL where serverindex = @serverindex)

					delete tblMessenger
					where idFriend not in (select m_idPlayer from CHARACTER_TBL where serverindex = @serverindex)

--					EXEC MESSENGER_STR 'D2','',@serverindex

					
					PRINT 'Delete Skill'
					DELETE 	tblSkillPoint 
					WHERE 	PlayerID NOT IN (SELECT m_idPlayer FROM CHARACTER_TBL WHERE serverindex=@serverindex) 
					AND 	serverindex=@serverindex


					CLOSE Delete_Cursor
					DEALLOCATE Delete_Cursor

FETCH NEXT FROM Delete_Server 
INTO @serverindex

END
CLOSE Delete_Server
DEALLOCATE Delete_Server

RETURN
GO
/****** Object:  Table [dbo].[tblCouplePlayer]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCouplePlayer](
	[cid] [int] NOT NULL,
	[nServer] [int] NULL,
	[idPlayer] [int] NULL,
 CONSTRAINT [UQ_tblCouplePlayer_idPlayer] UNIQUE CLUSTERED 
(
	[nServer] ASC,
	[idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TAG_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROC [dbo].[TAG_STR]
	@iGu        		  				CHAR(2) 			= 'S1', 
	@im_idPlayer   				CHAR(7) 			= '0000001',
	@iserverindex  				CHAR(2) 			= '01',
	@if_idPlayer 					CHAR(7)				=	'',
	@im_Message 				VARCHAR(255)	=	''
AS
set nocount on

IF 	@iGu = 'A1'
	BEGIN
	DECLARE @count int
	SELECT @count = COUNT(*) 
      FROM TAG_TBL
	WHERE  m_idPlayer = @im_idPlayer
	     AND serverindex = @iserverindex
		 AND State = 'T'

	IF @count < 20 
	 BEGIN
		INSERT TAG_TBL
			(m_idPlayer,serverindex,f_idPlayer,m_Message,State,CreateTime)
		VALUES
			(@im_idPlayer,@iserverindex,@if_idPlayer,@im_Message,'T',GETDATE())	
		SELECT fError='0'
		RETURN
	 END
	ELSE
	 BEGIN
		SELECT fError='1'
		RETURN
	 END
	END
/*
	
	 ?? ????
	 ex ) 
	 TAG_STR 'A1',@im_idPlayer,@iserverindex,@if_idPlayer,@im_Message
	 TAG_STR 'A1','000001','01','000002','??????'
*/
ELSE
IF @iGu = 'S1'
	BEGIN
		SELECT a.f_idPlayer, b.m_szName, a.m_Message,CreateTime=CONVERT(CHAR(8),a.CreateTime,112)
		   FROM TAG_TBL a, CHARACTER_TBL b
		WHERE a.m_idPlayer = @im_idPlayer
			AND a.m_idPlayer = b.m_idPlayer
		    AND a.serverindex = @iserverindex
		   AND  a.serverindex =  b.serverindex
			AND a.State = 'T'
		ORDER BY a.CreateTime
		
		UPDATE TAG_TBL
		      SET State = 'D'
		 WHERE m_idPlayer = @im_idPlayer
			  AND serverindex = @iserverindex

		SELECT fError='0'
		RETURN
	END
/*
	
	 ?? ????
	 ex ) 
	 TAG_STR 'S1',@im_idPlayer,@iserverindex
	 TAG_STR 'S1','000001','01'


*/


ELSE
IF	@iGu = 'D1'
	BEGIN
		DELETE TAG_TBL
		WHERE m_idPlayer NOT IN
		   (SELECT m_idPlayer 
			FROM CHARACTER_TBL)

		DELETE TAG_TBL
		WHERE f_idPlayer NOT IN
		   (SELECT m_idPlayer 
			FROM CHARACTER_TBL)

		DELETE TAG_TBL
		WHERE State = 'D'
			AND CreateTime < DATEADD(d,-7,GETDATE())
		RETURN
	END

/*
	
	 ?? ????( ??? ?????, ????? ???? )
	 ex ) 
	 TAG_STR 'D1'
	 TAG_STR 'D1'

*/
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[SECRET_ROOM_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  proc [dbo].[SECRET_ROOM_STR]
@iGu char(2),
@serverindex char(2),
@nTimes int,
@nContinent int,
@m_idGuild char(6),
@nPenya int,
@chState char(1),
@dwWorldID int,
@nWarState int,
@nKillCount int
as

set nocount on
set xact_abort on

if @iGu = 'S1'
begin
	select isnull(max(nTimes), 0) as nTimes from SECRET_ROOM_TBL where serverindex = @serverindex
end

if @iGu = 'S2'
begin
	select nContinent, m_idGuild, nPenya
	from SECRET_ROOM_TBL
	where serverindex = @serverindex and nTimes = @nTimes and chState = @chState
	order by nContinent asc, nPenya desc, s_date asc
end

if @iGu = 'I1'
begin
	insert into SECRET_ROOM_TBL (serverindex, nTimes, nContinent, m_idGuild, nPenya, chState, s_date)
	select @serverindex, @nTimes, @nContinent, @m_idGuild, @nPenya, @chState, getdate()
end


if @iGu = 'U1'
begin
	update SECRET_ROOM_TBL
	set nPenya = @nPenya, chState = @chState, s_date = getdate()
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent and m_idGuild = @m_idGuild and chState = 'T'
end

if @iGu = 'U2'
begin
	update SECRET_ROOM_TBL
	set nPenya = @nPenya, chState = @chState, dwWorldID = @dwWorldID, nWarState = @nWarState, nKillCount = @nKillCount, s_date = getdate()
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent and m_idGuild = @m_idGuild and chState = 'T'
end
GO
/****** Object:  StoredProcedure [dbo].[SECRET_ROOM_MEMBER_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SECRET_ROOM_MEMBER_STR]
@iGu char(2),
@serverindex char(2),
@nTimes int,
@nContinent int,
@m_idGuild char(6),
@m_idPlayer char(7)
as

set nocount on
set xact_abort on

if @iGu = 'S2'
begin
	select m_idPlayer
	from SECRET_ROOM_MEMBER_TBL
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent and m_idGuild = @m_idGuild
end

if @iGu = 'I1'
begin
	insert into SECRET_ROOM_MEMBER_TBL (serverindex, nTimes, nContinent, m_idGuild, m_idPlayer)
	select @serverindex, @nTimes, @nContinent, @m_idGuild, @m_idPlayer
end

if @iGu = 'D1'
begin
	delete SECRET_ROOM_MEMBER_TBL
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent and m_idGuild = @m_idGuild
end
GO
/****** Object:  StoredProcedure [dbo].[QUEST_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- select m_idPlayer,serverindex,m_wId from QUEST_TBL
-- GROUP BY m_idPlayer,serverindex,m_wId
-- 
-- QUEST_STR 'D1','001011','02',36
-- QUEST_STR 'S1','001022','01'

CREATE   PROC [dbo].[QUEST_STR]
@iGu CHAR(2) = 'S1',
@m_idPlayer CHAR(7) = '0000001',
@serverindex CHAR(2) = '01',
@m_wId int = null,
@m_nState tinyint = null,
@m_wTime int = null,
@m_nKillNPCNum_0 tinyint = null,
@m_nKillNPCNum_1 tinyint = null,
@m_bPatrol tinyint = null,
@m_bDialog tinyint = null,
@m_bReserve3 tinyint = null,
@m_bReserve4 tinyint = null,
@m_bReserve5 tinyint = null,
@m_bReserve6 tinyint = null,
@m_bReserve7 tinyint = null,
@m_bReserve8 tinyint = null,
@m_Inventory varchar(max) = '', 
@m_apIndex varchar(2500) = '', 
@m_adwEquipment varchar(135) = '', 
@m_dwObjIndex varchar(2500) = ''
AS
IF @iGu = 'S1'
	BEGIN
		SELECT m_idPlayer,serverindex,m_wId,m_nState,m_wTime,m_nKillNPCNum_0,m_nKillNPCNum_1,
                    m_bPatrol,m_bDialog,m_bReserve3,m_bReserve4,m_bReserve5,m_bReserve6,m_bReserve7,m_bReserve8
         FROM QUEST_TBL
		WHERE m_idPlayer = @m_idPlayer
            AND serverindex = @serverindex
       ORDER BY m_idPlayer,serverindex,m_wId
	END
/*
	
	 ??? ?? ????
	 ex ) 
	 QUEST_STR 'S1',@m_idPlayer,@serverindex
	 QUEST_STR 'S1','000001','01'

*/
IF @iGu = 'A1'
	BEGIN 
		IF NOT EXISTS(SELECT * FROM QUEST_TBL WHERE m_idPlayer = @m_idPlayer AND  serverindex = @serverindex AND m_wId = @m_wId)
	       INSERT QUEST_TBL	
			( m_idPlayer,serverindex,m_wId,m_nState,m_wTime,m_nKillNPCNum_0,m_nKillNPCNum_1,
	          m_bPatrol,m_bDialog,m_bReserve3,m_bReserve4,m_bReserve5,m_bReserve6,m_bReserve7,m_bReserve8)
			VALUES
			(@m_idPlayer,@serverindex,@m_wId,@m_nState,@m_wTime,@m_nKillNPCNum_0,@m_nKillNPCNum_1,
	         @m_bPatrol,@m_bDialog,@m_bReserve3,@m_bReserve4,@m_bReserve5,@m_bReserve6,@m_bReserve7,@m_bReserve8)
		ELSE
			UPDATE QUEST_TBL
                 SET m_nState = @m_nState,
                        m_wTime = @m_wTime,
                        m_nKillNPCNum_0 = @m_nKillNPCNum_0,
                        m_nKillNPCNum_1 = @m_nKillNPCNum_1,
                        m_bPatrol = @m_bPatrol,
                        m_bDialog = @m_bDialog,
                        m_bReserve3 = @m_bReserve3,
                        m_bReserve4 = @m_bReserve4,
                        m_bReserve5 = @m_bReserve5,
                        m_bReserve6 = @m_bReserve6,
                        m_bReserve7 = @m_bReserve7,
                        m_bReserve8 = @m_bReserve8
			 WHERE m_idPlayer = @m_idPlayer 
		         AND  serverindex = @serverindex 
	             AND m_wId = @m_wId

		IF @m_Inventory <> ''
			UPDATE INVENTORY_TBL
				   SET m_Inventory = @m_Inventory, 
                         m_apIndex = @m_apIndex, 
                         m_adwEquipment = @m_adwEquipment, 
                         m_dwObjIndex = @m_dwObjIndex
			 WHERE m_idPlayer = @m_idPlayer 
		         AND  serverindex = @serverindex 
	END
/*
	
	 ??? ????
	 ex ) 
	QUEST_STR 'A1',@m_idPlayer,@serverindex,@m_wId,@m_nState,@m_wTime,@m_nKillNPCNum_0,@m_nKillNPCNum_1,@m_bPatrol,@m_bDialog,
                               @m_bReserve3,@m_bReserve4,@m_bReserve5,@m_bReserve6,@m_bReserve7,@m_bReserve8,@m_Inventory, @m_apIndex, @m_adwEquipmen, @m_dwObjIndex

	QUEST_STR 'A1',@m_idPlayer,@serverindex,@m_wId = 1,@m_nState = 0,@m_wTime = 65535,@m_nKillNPCNum_0 = 0,@m_nKillNPCNum_1 = 0,@m_bPatrol = 0,@m_bDialog = 0,
                              @m_bReserve3 = 0,@m_bReserve4 = 0,@m_bReserve5 = 0,@m_bReserve6 = 0,@m_bReserve7 = 0,@m_bReserve8 = 0,@m_Inventory = '$', @m_apIndex = '$', @m_adwEquipmen = '$', @m_dwObjIndex = '$'


*/

IF @iGu = 'U1'
	BEGIN
		UPDATE QUEST_TBL
               SET m_nState = @m_nState,
                      m_wTime = @m_wTime,
                      m_nKillNPCNum_0 = @m_nKillNPCNum_0,
                      m_nKillNPCNum_1 = @m_nKillNPCNum_1,
                      m_bPatrol = @m_bPatrol,
                      m_bDialog = @m_bDialog,
                      m_bReserve3 = @m_bReserve3,
                      m_bReserve4 = @m_bReserve4,
                      m_bReserve5 = @m_bReserve5,
                      m_bReserve6 = @m_bReserve6,
                      m_bReserve7 = @m_bReserve7,
                      m_bReserve8 = @m_bReserve8
		 WHERE m_idPlayer = @m_idPlayer 
	         AND  serverindex = @serverindex 
             AND m_wId = @m_wId

		IF @m_Inventory <> ''
			UPDATE INVENTORY_TBL
				   SET m_Inventory = @m_Inventory, 
                         m_apIndex = @m_apIndex, 
                         m_adwEquipment = @m_adwEquipment, 
                         m_dwObjIndex = @m_dwObjIndex
			 WHERE m_idPlayer = @m_idPlayer 
		         AND  serverindex = @serverindex 	

   END

/*
	
	 ??? ????
	 ex ) 
	QUEST_STR 'U1',@m_idPlayer,@serverindex,@m_wId,@m_nState,@m_wTime,@m_nKillNPCNum_0,@m_nKillNPCNum_1,@m_bPatrol,@m_bDialog,
                               @m_bReserve3,@m_bReserve4,@m_bReserve5,@m_bReserve6,@m_bReserve7,@m_bReserve8,@m_Inventory, @m_apIndex, @m_adwEquipmen, @m_dwObjIndex

	QUEST_STR 'U1',@m_idPlayer,@serverindex,@m_wId = 1,@m_nState = 0,@m_wTime = 65535,@m_nKillNPCNum_0 = 0,@m_nKillNPCNum_1 = 0,@m_bPatrol = 0,@m_bDialog = 0,
                              @m_bReserve3 = 0,@m_bReserve4 = 0,@m_bReserve5 = 0,@m_bReserve6 = 0,@m_bReserve7 = 0,@m_bReserve8 = 0,@m_Inventory = '$', @m_apIndex = '$', @m_adwEquipmen = '$', @m_dwObjIndex = '$'


*/
IF @iGu = 'D1'
	BEGIN	
			DELETE QUEST_TBL
			 WHERE m_idPlayer = @m_idPlayer 
		         AND  serverindex = @serverindex 
	             AND m_wId = @m_wId

		IF @m_Inventory <> ''
			UPDATE INVENTORY_TBL
				   SET m_Inventory = @m_Inventory, 
                         m_apIndex = @m_apIndex, 
                         m_adwEquipment = @m_adwEquipment, 
                         m_dwObjIndex = @m_dwObjIndex
			 WHERE m_idPlayer = @m_idPlayer 
		         AND  serverindex = @serverindex 
   END
/*
	
	 ??? ????
	 ex ) 
	QUEST_STR 'D1',@m_idPlayer,@serverindex,@m_wId,@m_nState,@m_wTime,@m_nKillNPCNum_0,@m_nKillNPCNum_1,@m_bPatrol,@m_bDialog,
                               @m_bReserve3,@m_bReserve4,@m_bReserve5,@m_bReserve6,@m_bReserve7,@m_bReserve8,@m_Inventory, @m_apIndex, @m_adwEquipmen, @m_dwObjIndex

	QUEST_STR 'D1',@m_idPlayer,@serverindex,@m_wId = 1,@m_nState = 0,@m_wTime = 65535,@m_nKillNPCNum_0 = 0,@m_nKillNPCNum_1 = 0,@m_bPatrol = 0,@m_bDialog = 0,
                              @m_bReserve3 = 0,@m_bReserve4 = 0,@m_bReserve5 = 0,@m_bReserve6 = 0,@m_bReserve7 = 0,@m_bReserve8 = 0,@m_Inventory = '$', @m_apIndex = '$', @m_adwEquipmen = '$', @m_dwObjIndex = '$'


*/

RETURN
GO
/****** Object:  StoredProcedure [dbo].[RAINBOWRACE_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RAINBOWRACE_STR]
@iGu char(2),
@serverindex char(2),
@nTimes int,
@m_idPlayer char(7),
@nRanking int
as

set nocount on
set xact_abort on

declare @q1 nvarchar(4000)

if @iGu = 'S1'
begin
	select isnull(max(nTimes), 0) as nTimes from RAINBOWRACE_TBL where serverindex = @serverindex
end

-- ??? ??
if @iGu = 'S2'
begin
	set @q1 = '
	update RAINBOWRACE_TBL
	set chState = ''N'', nRanking = 0
	where serverindex = @serverindex and nTimes = @nTimes and chState = ''R'''
	exec sp_executesql @q1, N'@serverindex char(2), @nTimes int', @serverindex, @nTimes

	set @q1 = '
	select m_idPlayer
	from RAINBOWRACE_TBL
	where serverindex = @serverindex and nTimes = @nTimes and chState = ''N'''
	exec sp_executesql @q1, N'@serverindex char(2), @nTimes int', @serverindex, @nTimes
end
/*-- ??? ??
if @iGu = 'S2'
begin
	select m_idPlayer
	from RAINBOWRACE_TBL
	where serverindex = @serverindex and nTimes = @nTimes and chState in ('N', 'R')
end*/

-- ?? ??
if @iGu = 'S3'
begin
	select m_idPlayer
	from RAINBOWRACE_TBL
	where serverindex = @serverindex and nTimes = @nTimes - 1 and chState = 'W' and nRanking > 0
	order by nRanking
end


-- ??
if @iGu = 'I1'
begin
	insert into RAINBOWRACE_TBL (serverindex, nTimes, m_idPlayer, chState, nRanking, s_date)
	select @serverindex, @nTimes, @m_idPlayer, 'N', 0, getdate()
end

-- ??(??????)
if @iGu = 'U1'
begin
	update RAINBOWRACE_TBL
	set chState = 'R', nRanking = @nRanking, s_date = getdate()
	where serverindex = @serverindex and nTimes = @nTimes and  m_idPlayer = @m_idPlayer and chState = 'N'
end

-- ???? ??? ??
if @iGu = 'U2'
begin
	set xact_abort off

	-- ??????? ??
	update RAINBOWRACE_TBL
	set chState = 'W'
	where serverindex = @serverindex and nTimes = @nTimes and chState = 'R'

	-- ????? ??
	update RAINBOWRACE_TBL
	set chState = 'L',  nRanking = 0, s_date = getdate()
	where serverindex = @serverindex and nTimes = @nTimes and chState = 'N'
end

-- ??
if @iGu = 'U3'
begin
	update RAINBOWRACE_TBL
	set chState = 'F',  nRanking = 0, s_date = getdate()
	where serverindex = @serverindex and nTimes = @nTimes and m_idPlayer = @m_idPlayer
end
GO
/****** Object:  StoredProcedure [dbo].[PARTY_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[PARTY_STR]
	@iGu        		  				CHAR(2) 			= 'S1', 
	@im_idPlayer   				CHAR(7) 			= '0000001',
	@iserverindex  				CHAR(2) 			= '01',
	@ipartyname 				VARCHAR(16)				=	''
AS
set nocount on
IF 	@iGu = 'A1'
	BEGIN
		IF EXISTS(SELECT * FROM  PARTY_TBL  WHERE m_idPlayer = @im_idPlayer  AND serverindex = @iserverindex)
		UPDATE PARTY_TBL
			SET partyname = @ipartyname
		WHERE m_idPlayer = @im_idPlayer
		    AND serverindex = @iserverindex
		ELSE
		INSERT PARTY_TBL
			(m_idPlayer,serverindex,partyname)
		VALUES
			(@im_idPlayer,@iserverindex,@ipartyname)	
		RETURN
	END
/*
	
	 ????  ????
	 ex ) 
	 PARTY_STR 'A1',@im_idPlayer,@iserverindex,@ipartyname
	 PARTY_STR 'A1','000001','01','??????'

*/

ELSE
IF @iGu = 'S1'
	BEGIN
		SELECT partyname
		   FROM PARTY_TBL
		WHERE m_idPlayer = @im_idPlayer
		    AND serverindex = @iserverindex
		RETURN
	END
/*
	
	 ?? ???? ????
	 ex ) 
	 PARTY_STR 'S1',@im_idPlayer,@iserverindex
	 PARTY_STR 'S1','000001','01'

*/

ELSE
IF @iGu = 'S2'
	BEGIN
		SELECT partyname,m_idPlayer
		   FROM PARTY_TBL
		WHERE serverindex = @iserverindex
	    ORDER BY partyname
		RETURN
	END
/*
	
	 ?? ???? ?? ????
	 ex ) 
	 PARTY_STR 'S2','',@iserverindex
	 PARTY_STR 'S2','','01'

*/
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[NEW_MESSENGER_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[NEW_MESSENGER_STR]
	@iGu         			char(2)		= 'S1', 
	@im_idPlayer 			char(7)		= '0000001',
	@iserverindex  			char(2)		= '01',
	@if_idPlayer 			char(7)		=	'',
	@im_dwSex 				int			= 0,
	@im_nJob				int			= 0,
	@iState 				char(1)		='',
	@im_dwState				int			= 0
AS
SET NOCOUNT ON

	DECLARE	@sql	nvarchar(4000)
	SET	@sql=''
	
	IF	@iGu = 'A1'
		BEGIN
			IF EXISTS(SELECT * FROM  MESSENGER_TBL  WHERE m_idPlayer = @im_idPlayer  AND serverindex = @iserverindex  AND f_idPlayer = @if_idPlayer)
			UPDATE MESSENGER_TBL
				SET State = 'T',
						m_dwState = @im_dwState
			WHERE m_idPlayer = @im_idPlayer
				AND serverindex = @iserverindex
				AND f_idPlayer = @if_idPlayer
			ELSE
			INSERT MESSENGER_TBL
				(m_idPlayer,serverindex,f_idPlayer,m_nJob,m_dwSex,m_dwState,State,CreateTime)
			VALUES
				(@im_idPlayer,@iserverindex,@if_idPlayer,@im_nJob,@im_dwSex,0,'T',GETDATE())	
			RETURN
		END
	/*
		
		??? ?? ????
		ex ) 
		NEW_MESSENGER_STR 'A1',@im_idPlayer,@iserverindex,@if_idPlayer,@im_nJob,@im_dwSex
		NEW_MESSENGER_STR 'A1','000001','01','000002',1,1
	*/
	ELSE
	----------------------------------------
	--	??? ??? ????
	--	NEW_MESSENGER_STR 'S1','000001','01'
	IF @iGu = 'S1'	BEGIN
		SET @sql=N'
			EXEC uspLoadMessengerList @pserverindex, @pPlayerID
		'
		
		EXECUTE sp_executesql	@sql, 
								N'@pPlayerID char(7), @pserverindex char(2)', 
								@im_idPlayer, @iserverindex

		RETURN
	END
	----------------------------------------
	--	?? ??? ??? ??? ????
	--	NEW_MESSENGER_STR 'S2','000001','02'
	ELSE
	IF @iGu = 'S2'	BEGIN
		SET @sql=N'
			EXEC uspLoadMessengerListRegisterMe @pserverindex, @pPlayerID
		'
		
		EXECUTE sp_executesql	@sql, 
								N'@pPlayerID char(7), @pserverindex char(2)', 
								@im_idPlayer, @iserverindex

			RETURN
		END
	ELSE
	IF	@iGu = 'D1'
		BEGIN
			UPDATE MESSENGER_TBL
				SET State = 'D'
			WHERE m_idPlayer = @im_idPlayer
				AND serverindex = @iserverindex
				AND f_idPlayer = @if_idPlayer
				AND State = 'T'
			RETURN
		END
	ELSE
	IF @iGu = 'D2'
		BEGIN
			DELETE MESSENGER_TBL
			WHERE m_idPlayer NOT IN
			(SELECT m_idPlayer 
				FROM CHARACTER_TBL where serverindex = @iserverindex)
				and  serverindex = @iserverindex

			DELETE MESSENGER_TBL
			WHERE f_idPlayer NOT IN
			(SELECT m_idPlayer 
				FROM CHARACTER_TBL where serverindex = @iserverindex)
				and  serverindex = @iserverindex

			DELETE MESSENGER_TBL
			WHERE State = 'D'
			and  serverindex = @iserverindex
			RETURN
		END

SET NOCOUNT OFF
GO
/****** Object:  Table [dbo].[tblCampusMember]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCampusMember](
	[idCampus] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[nMemberLv] [int] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_tblCampusMember] PRIMARY KEY NONCLUSTERED 
(
	[m_idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusMember', @level2type=N'COLUMN',@level2name=N'idCampus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusMember', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusMember', @level2type=N'COLUMN',@level2name=N'm_idPlayer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ???? ??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusMember', @level2type=N'COLUMN',@level2name=N'nMemberLv'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??? ??? ? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusMember', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  StoredProcedure [dbo].[TAX_INFO_STR]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[TAX_INFO_STR]
@iGu char(2) = 'S1',
@serverindex char(2) = '01',
@nTimes int,
@nContinent int,
@dwID char(7),
@dwNextID char(7),
@bSetTaxRate int,
@change_time char(12)
as

set nocount on

if @iGu = 'S1'
begin
	select isnull(max(nTimes), 0) as nTimes
	from TAX_INFO_TBL
	where serverindex = @serverindex
end

if @iGu = 'S2'
begin
	select  dwID, dwNextID, bSetTaxRate, change_time
	from TAX_INFO_TBL
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent
end

if @iGu = 'S3'
begin
	select m_idPlayer
	from GUILD_MEMBER_TBL
	where serverindex = @serverindex and m_idGuild = right(@dwID, 6) and m_nMemberLv = 0
end

if @iGu = 'I1'
begin
	insert into TAX_INFO_TBL (serverindex, nTimes, nContinent, dwID, dwNextID, change_time, bSetTaxRate)
	select @serverindex, @nTimes, @nContinent, @dwID, @dwNextID, @change_time, @bSetTaxRate
end

if @iGu = 'U1'
begin
	update TAX_INFO_TBL
	set dwID = @dwID, dwNextID = @dwNextID, bSetTaxRate = @bSetTaxRate, save_time = getdate()
	where serverindex = @serverindex and nTimes = @nTimes and nContinent = @nContinent
end
GO
/****** Object:  Table [dbo].[tblCombatJoinGuild]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCombatJoinGuild](
	[CombatID] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[GuildID] [char](6) NOT NULL,
	[Status] [varchar](3) NOT NULL,
	[ApplyDt] [datetime] NOT NULL,
	[CombatFee] [bigint] NOT NULL,
	[ReturnCombatFee] [bigint] NOT NULL,
	[Reward] [bigint] NOT NULL,
	[Point] [int] NOT NULL,
	[RewardDt] [datetime] NULL,
	[CancelDt] [datetime] NULL,
	[StraightWin] [int] NOT NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tblCombatJoinGuild] PRIMARY KEY CLUSTERED 
(
	[CombatID] ASC,
	[serverindex] ASC,
	[GuildID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCombatJoinPlayer]    Script Date: 04/03/2010 12:42:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCombatJoinPlayer](
	[CombatID] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[GuildID] [char](6) NOT NULL,
	[PlayerID] [char](7) NOT NULL,
	[Status] [varchar](3) NOT NULL,
	[Point] [int] NOT NULL,
	[Reward] [bigint] NOT NULL,
	[RewardDt] [datetime] NULL,
 CONSTRAINT [PK_tblCombatJoinPlayer] PRIMARY KEY CLUSTERED 
(
	[CombatID] ASC,
	[serverindex] ASC,
	[GuildID] ASC,
	[PlayerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[MAIL_STR_REALTIME]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE         proc [dbo].[MAIL_STR_REALTIME]
	@iGu		CHAR(2),
	@serverindex 	CHAR(2),
	@nMail_Before	INT = 0,
	@nMail_After	INT = 0,
	@idPlayer	CHAR(7) = '0000000',
	@nLevel		INT = 0,
	@iaccount 	VARCHAR(32) = '',
	@tmCreate	INT = 0,
	@dwSerialNumber	INT = 0,
	@nHitPoint	INT = 0
as
set nocount on

declare @sdate datetime
declare @edate datetime
declare @iserverindex char(2)

--set @sdate = '2007-07-18 00:00:00'--'2007-07-10 00:00:00'	-- '2007-07-18 00:00:00'
--set @edate = '2007-08-31 23:59:00'--'2007-07-10 23:00:00'  -- '2007-08-31 23:59:00'

-- set @sdate = '2008-01-15 11:00:00'
-- set @edate = '2008-02-24 12:00:00'
select @sdate = '2009-12-26 10:00:00', @edate = '2010-02-03 10:00:00'
set @iserverindex = cast((cast(@serverindex as int) + 50) as char(2))

IF @iGu	= 'S1'
	BEGIN
		SELECT * FROM MAIL_TBL 
		WHERE serverindex = @iserverindex AND byRead<90  
		ORDER BY nMail
	RETURN
	END
ELSE
IF @iGu	= 'U1'
	BEGIN
		UPDATE MAIL_TBL SET nMail = @nMail_After, serverindex = @serverindex, dwSerialNumber = @dwSerialNumber, nHitPoint = @nHitPoint
		WHERE serverindex = @iserverindex and nMail = @nMail_Before
	RETURN
	END
ELSE
IF @iGu  = 'I1'

	BEGIN
		-- ??? ???? ??
		IF(getdate() < @sdate or getdate() > @edate) BEGIN
			RETURN
		END
		-- ??? ??? ?? ?? 	
		IF( NOT EXISTS(SELECT * FROM tbl_Event_NewAccount_0912 where  account  = @iaccount ) )	BEGIN
			RETURN
		END

--		if exists (select * from ACCOUNT_DBF.dbo.ACCOUNT_TBL_DETAIL where account = @iaccount and (regdate >= @sdate and regdate <= @edate))
		begin

		declare @ItemID1 int, @ItemID2 int, @ItemID3 int, @ItemID4 int
		declare @ItemNum1 int, @ItemNum2 int, @ItemNum3 int, @ItemNum4 int
		declare @provide_count int, @provide_num int
		declare @item_flag int

		set @provide_num = 1

		if (@nMail_After = 0)
		begin
			if (@nLevel = 5) or (@nLevel = 15)
			begin
				select @ItemID1 = 10270, @ItemNum1 = 1, @provide_count = 1, @item_flag = 2
			end
			if (@nLevel = 10) or (@nLevel = 1)
			begin
				select @ItemID1 = 26205, @ItemNum1 = 3, @provide_count = 1, @item_flag = 2
			end
			if (@nLevel = 20)
			begin
				select @ItemID1 = 26208, @ItemNum1 = 3, @ItemID2 = 10270, @ItemNum2 = 2, @provide_count = 2, @item_flag = 2
			end
			if (@nLevel = 23) or (@nLevel = 29) or (@nLevel = 35) or (@nLevel = 43) or (@nLevel = 47) or (@nLevel = 51)
			begin
				select @ItemID1 = 10270, @ItemNum1 = 2, @provide_count = 1, @item_flag = 2
			end
			if (@nLevel = 26) or (@nLevel = 32) or (@nLevel = 38)
			begin
				select @ItemID1 = 26208, @ItemNum1 = 3, @provide_count = 1, @item_flag = 2
			end
			if (@nLevel = 40) or (@nLevel = 50)
			begin
				select @ItemID1 = 26211, @ItemNum1 = 2, @ItemID2 = 10207, @ItemNum2 = 3, @ItemID3 = 10208, @ItemNum3 = 3, @provide_count = 3, @item_flag = 2
			end
			if (@nLevel = 45)
			begin
				select @ItemID1 = 26211, @ItemNum1 = 2, @ItemID2 = 10207, @ItemNum2 = 1, @ItemID3 = 10208, @ItemNum3 = 1, @provide_count = 3, @item_flag = 2
			end
			if (@nLevel = 55)
			begin
				select @ItemID1 = 26211, @ItemNum1 = 2, @ItemID2 = 10270, @ItemNum2 = 2, @provide_count = 2, @item_flag = 2
			end
			if (@nLevel = 58)
			begin
				select @ItemID1 = 26211, @ItemNum1 = 2, @ItemID2 = 10207, @ItemNum2 = 3, @ItemID3 = 10208, @ItemNum3 = 3, @ItemID4 = 10270, @ItemNum4 = 2, @provide_count = 4, @item_flag = 2
			end
			if (@nLevel = 60)
			begin
				select @ItemID1 = 30148, @ItemNum1 = 10,  @provide_count = 1, @item_flag = 2
			end
		end
		if (@nMail_After in (1, 2, 3, 4))
		begin
				select @ItemID1 = 26650, @ItemNum1 = 1, @provide_count = 1, @item_flag = 0
		end
		if (@nMail_After in (6, 7))
		begin
			if (@nMail_Before = 0)
			begin
				select @ItemID1 = 22482, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
			if (@nMail_Before = 1)
			begin
				select @ItemID1 = 22483, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
		end

		if (@nMail_After in (8, 9))
		begin
			if (@nMail_Before = 0)
			begin
				select @ItemID1 = 22484, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
			if (@nMail_Before = 1)
			begin
				select @ItemID1 = 22485, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
		end
		if (@nMail_After in (10, 11))
		begin
			if (@nMail_Before = 0)
			begin
				select @ItemID1 = 22496, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
			if (@nMail_Before = 1)
			begin
				select @ItemID1 = 22497, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
		end
		if (@nMail_After in (12, 13))
		begin
			if (@nMail_Before = 0)
			begin
				select @ItemID1 = 22498, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
			if (@nMail_Before = 1)
			begin
				select @ItemID1 = 22499, @ItemNum1 = 1, @ItemID2 = 26651, @ItemNum2 = 1, @provide_count = 2, @item_flag = 0
			end
		end

		while @provide_num <= @provide_count
		begin
			-- ?? ??? ?? ??
			DECLARE @nMaxMailID int
			SELECT @nMaxMailID = MAX(nMail) + 1 from MAIL_TBL where serverindex = @iserverindex
			SET @nMaxMailID = ISNULL( @nMaxMailID, 0 )
	
			-- ??? ??
			DECLARE @szTitle		VARCHAR(128)
			DECLARE @szText		VARCHAR(1024)
			if @nMail_After = 0
				select @szTitle = '?? ?? ???', @szText = '?? ??!! ?? UP!!'
			else
				select @szTitle = '?? ?? ???', @szText = '??? ?? ????.'
	
			if @provide_num = 1
			begin
				EXEC dbo.MAIL_STR 'A1', @nMaxMailID, @iserverindex, @idPlayer, '0000000', 0, @tmCreate, 0, @szTitle, @szText,@ItemID1, @ItemNum1, 0, 0, 0, 0, @item_flag
			end
			if @provide_num = 2
			begin
				EXEC dbo.MAIL_STR 'A1', @nMaxMailID, @iserverindex, @idPlayer, '0000000', 0, @tmCreate, 0, @szTitle, @szText,@ItemID2, @ItemNum2, 0, 0, 0, 0, @item_flag
			end
			if @provide_num = 3
			begin
				EXEC dbo.MAIL_STR 'A1', @nMaxMailID, @iserverindex, @idPlayer, '0000000', 0, @tmCreate, 0, @szTitle, @szText,@ItemID3, @ItemNum3, 0, 0, 0, 0, @item_flag
			end
			if @provide_num = 4
			begin
				EXEC dbo.MAIL_STR 'A1', @nMaxMailID, @iserverindex, @idPlayer, '0000000', 0, @tmCreate, 0, @szTitle, @szText,@ItemID4, @ItemNum4, 0, 0, 0, 0, @item_flag
			end
	
			set @provide_num = @provide_num + 1
		end

		end
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_CampusMember_Load]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_CampusMember_Load    Script Date: 2009-12-01 ?? 2:41:44 ******/


/*============================================================
1. ??? : ???
2. ??? : 2009.11.20
3. ???? ? : usp_CampusMember_Load
4. ???? ?? : ?? ?? ??? ??
5. ????
	@serverindex	char(2)		: ???
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_CampusMember_Load '05'
9. ?? ? ident ? ???
	select * from tblCampusMember
	delete tblCampusMember
============================================================*/

CREATE       proc [dbo].[usp_CampusMember_Load]

	@serverindex char(2)
as

set nocount on
set xact_abort on

	select idCampus, serverindex, m_idPlayer, nMemberLv 
	from tblCampusMember (nolock)
	where serverindex = @serverindex
GO
/****** Object:  StoredProcedure [dbo].[usp_CampusMember_Insert]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_CampusMember_Insert    Script Date: 2009-12-01 ?? 2:41:44 ******/


/*============================================================
1. ??? : ???
2. ??? : 2009.11.20
3. ???? ? : usp_CampusMember_Insert
4. ???? ?? : ?? ?? ??? ??
5. ????
	@idCampus		int			: ?? ID
	@serverindex	char(2)		: ???
	@m_idPlayer		char(7)		: ???? ID
	@nMemberLv		int			: ?? ???? ??? ??
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_Campus_Insert 123, '05'
    EXEC usp_CampusMember_Insert 123, '05', '0745479', 2
9. ?? ? ident ? ???
	select * from tblCampus
	select * from tblCampusMember
    EXEC usp_Campus_Delete 123, '05'
============================================================*/

CREATE       proc [dbo].[usp_CampusMember_Insert]

	@idCampus	int,
	@serverindex	char(2),
	@m_idPlayer	char(7),
	@nMemberLv	int

as

set nocount on
set xact_abort on

	if not exists (select * from tblCampusMember (nolock) where m_idPlayer = @m_idPlayer)
		begin
			INSERT INTO tblCampusMember(idCampus, serverindex, m_idPlayer, nMemberLv)
			select @idCampus, @serverindex, @m_idPlayer, @nMemberLv
		end
GO
/****** Object:  StoredProcedure [dbo].[usp_CampusMember_Delete]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_CampusMember_Delete    Script Date: 2009-12-01 ?? 2:41:44 ******/





/*============================================================
1. ??? : ???
2. ??? : 2009.11.20
3. ???? ? : usp_CampusMember_Delete
4. ???? ?? : ?? ?? ??? ??
5. ????
	@serverindex	char(2)		: ???
	@m_idPlayer		char(7)		: ???? ID
	@nMemberLv		int			: ?? ???? ?? ??
6. ??? 	
7. ?? ??
8. ?? ?? ??
    EXEC usp_CampusMember_Delete 123, '0745479'
9. ?? ? ident ? ???
	select * from tblCampus
	select * from tblCampusMember
    EXEC usp_Campus_Delete '05', '0745479', 2
============================================================*/

CREATE         proc [dbo].[usp_CampusMember_Delete]

	@serverindex	char(2),
	@m_idPlayer		char(7),
	@nMemberLv		int

as

set nocount on
set xact_abort on

declare @idCampus int

	select @idCampus = idCampus from tblCampusMember (nolock)
		where m_idPlayer = @m_idPlayer and serverindex = @serverindex

	if @nMemberLv = 1
		begin
			exec usp_Campus_Delete @idCampus, @serverindex
		end
	else if @nMemberLv = 2
		begin
			delete tblCampusMember
			where m_idPlayer = @m_idPlayer and serverindex = @serverindex and nMemberLv = @nMemberLv
		end
GO
/****** Object:  StoredProcedure [dbo].[uspCancelGuildToCombat]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspCancelGuildToCombat]
		@pCombatID		int,
		@pserverindex	char(2),
		@pGuildID		char(6)
AS
SET NOCOUNT ON

	UPDATE tblCombatJoinGuild SET Status='11' WHERE CombatID=@pCombatID AND serverindex=@pserverindex AND GuildID=@pGuildID
		
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END

	SELECT 1 retValue
	RETURN 

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspAddCoupleExperience]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspAddCoupleExperience]
@nServer int,
@idPlayer int,
@nExperience int
as
set nocount on 

declare @id int

select @id =cid from tblCouplePlayer where nServer = @nServer and idPlayer = @idPlayer
update tblCouple set nExperience = nExperience + @nExperience where nServer = @nServer and cid = @id
GO
/****** Object:  StoredProcedure [dbo].[uspAddCouple]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[uspAddCouple]
@nServer int,
@idFirst int,
@idSecond int
as
set nocount on

declare @id int

insert into tblCouple (nServer, nExperience)
select @nServer, 0

select @id = @@identity from tblCouple where nServer = @nServer

insert into tblCouplePlayer (nServer, idPlayer, cid)
select @nServer, @idFirst, @id

insert into tblCouplePlayer (nServer, idPlayer, cid)
select @nServer, @idSecond, @id
GO
/****** Object:  StoredProcedure [dbo].[usp_item2row]    Script Date: 04/03/2010 12:42:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_item2row]
as
set nocount on
truncate table tblitem2row

declare @m_idPlayer char(7), @serverindex char(2), @m_Inventory varchar(6000), @m_Bank varchar(6000), @szItem0 varchar(6000), @szItem1 varchar(6000), @szItem2 varchar(6000)

declare item2row_cursor cursor fast_forward for 
select m_idPlayer, serverindex, m_Inventory, m_Bank, szItem0, szItem1, szItem2
from viw_Item_Info with (nolock)
order by m_idPlayer

open item2row_cursor

fetch next from item2row_cursor 
into @m_idPlayer, @serverindex, @m_Inventory, @m_Bank, @szItem0, @szItem1, @szItem2

while @@fetch_status = 0
begin	
   if @m_Inventory <> '$'
	insert tblitem2row
		(m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, m_nAbilityOption, ItemResist, ResistAbilityOpt, m_position)
	select m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, isnull(m_nAbilityOption,0), isnull(ItemResist, 0), isnull(ResistAbilityOpt, 0), 'I'
	from dbo.fn_item2row (@m_idPlayer, @serverindex, @m_Inventory)

   if @m_Bank <> '$'
	insert tblitem2row
		(m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, m_nAbilityOption, ItemResist, ResistAbilityOpt, m_position)
	select m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, isnull(m_nAbilityOption,0), isnull(ItemResist, 0), isnull(ResistAbilityOpt, 0), 'B'
	from dbo.fn_item2row (@m_idPlayer, @serverindex, @m_Bank)

   if @szItem0 <> '$'
	insert tblitem2row
		(m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, m_nAbilityOption, ItemResist, ResistAbilityOpt, m_position)
	select m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, isnull(m_nAbilityOption,0), isnull(ItemResist, 0), isnull(ResistAbilityOpt, 0), 'P'
	from dbo.fn_item2row (@m_idPlayer, @serverindex, @szItem0)

   if @szItem1 <> '$'
	insert tblitem2row
		(m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, m_nAbilityOption, ItemResist, ResistAbilityOpt, m_position)
	select m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, isnull(m_nAbilityOption,0), isnull(ItemResist, 0), isnull(ResistAbilityOpt, 0), 'P'
	from dbo.fn_item2row (@m_idPlayer, @serverindex, @szItem1)

   if @szItem2 <> '$'
	insert tblitem2row
		(m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, m_nAbilityOption, ItemResist, ResistAbilityOpt, m_position)
	select m_idPlayer, serverindex, m_dwObjId, m_dwItemId, m_nUniqueNo, m_nItemNum, isnull(m_nAbilityOption,0), isnull(ItemResist, 0), isnull(ResistAbilityOpt, 0), 'P'
	from dbo.fn_item2row (@m_idPlayer, @serverindex, @szItem2)

	fetch next from item2row_cursor 
	into  @m_idPlayer, @serverindex, @m_Inventory, @m_Bank, @szItem0, @szItem1, @szItem2
end
close item2row_cursor
deallocate item2row_cursor
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteCouple]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[uspDeleteCouple]
@nServer int,
@idPlayer int
as
set nocount on

declare @id int, @idPartner int

select @id =cid from tblCouplePlayer where nServer = @nServer and idPlayer = @idPlayer

select @idPartner = idPlayer from tblCouplePlayer where nServer = @nServer and cid = @id and idPlayer <> @idPlayer

insert into tblCouple_deleted (cid, nServer, nExperience, add_Date)
select cid, nServer, nExperience, add_Date from tblCouple WHERE nServer = @nServer AND cid = @id

insert into tblCouplePlayer_deleted (nServer, idPlayer, cid)
select  nServer, idPlayer, cid from tblCouplePlayer where nServer = @nServer AND cid = @id

delete tblCouple where nServer = @nServer and cid = @id

delete tblCouplePlayer where nServer = @nServer and cid = @id
GO
/****** Object:  StoredProcedure [dbo].[uspCombatContinue]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[uspCombatContinue]
		@pCombatID		int,
		@pserverindex		char(2),
		@pGuildID		char(6),
		@pStraightWin		int
AS
SET NOCOUNT ON

	UPDATE dbo.tblCombatJoinGuild
	SET	StraightWin = @pStraightWin
	WHERE	CombatID=@pCombatID
	   AND	serverindex=@pserverindex
	   AND	GuildID=@pGuildID

	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END

	SELECT 1 as retValue	
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspGradeCombatGuild]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspGradeCombatGuild]
		@pCombatID		int,
		@pserverindex	char(2),
		@pGuildID		char(6),
		@pPoint			int,
		@pReturnCombatFee	bigint=0,
		@pReward		bigint=0,
		@pStraightWin	int=0
AS
SET NOCOUNT ON

	DECLARE @Status	varchar(3)
	
	IF @pReward=0 AND @pReturnCombatFee=0 
		SET @Status='31'
	ELSE
		SET @Status='30'
	
	UPDATE	tblCombatJoinGuild 
	   SET	Point=@pPoint,
			ReturnCombatFee=@pReturnCombatFee,
			Reward=@pReward,
			StraightWin=@pStraightWin,
			Status=@Status
	 WHERE	CombatID=@pCombatID
	   AND	serverindex=@pserverindex
	   AND	GuildID=@pGuildID
	
	
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END
	
	SELECT 1 as retValue
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspJoinGuildToCombat]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspJoinGuildToCombat]
		@pCombatID		int,
		@pserverindex	char(2),
		@pGuildID		char(6),
		@pCombatFee		bigint = 0,
		@pStraightWin	int = 0
AS
SET NOCOUNT ON

	IF EXISTS ( SELECT * FROM tblCombatJoinGuild WHERE CombatID=@pCombatID and GuildID=@pGuildID and serverindex=@pserverindex) BEGIN
		UPDATE	tblCombatJoinGuild SET Status='12', CombatFee=@pCombatFee, ApplyDt=getdate(), CancelDt=getdate(), StraightWin=@pStraightWin 
		WHERE	CombatID=@pCombatID
		AND		serverindex=@pserverindex
		AND		GuildID=@pGuildID
		
		IF @@ROWCOUNT=0 BEGIN
			SELECT 9003 as retValue
			RETURN
		END
	END
	ELSE BEGIN
		INSERT INTO tblCombatJoinGuild(CombatID, serverindex, GuildID, Status, ApplyDt, CombatFee, ReturnCombatFee, Reward, Point, RewardDt, CancelDt, StraightWin)
			VALUES (@pCombatID, @pserverindex, @pGuildID, '10', getdate(), @pCombatFee, 0, 0, 0, NULL, NULL, @pStraightWin)
	END
			
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END
	
	SELECT 1 as retValue
	RETURN
				

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadWinnerGuildInfo]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspLoadWinnerGuildInfo]
		@pCombatID		int,
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT	CombatID, serverindex, GuildID, Status, ApplyDt, CombatFee, StraightWin, Reward, Point
	  FROM	tblCombatJoinGuild
	 WHERE	CombatID=@pCombatID
	   AND	serverindex=@pserverindex
	   AND	StraightWin>0
	   
	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadCombatGuildList]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadCombatGuildList]
		@pCombatID		int,
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT	CombatID, serverindex, GuildID, Status, ApplyDt, CombatFee, StraightWin, Reward, Point
	  FROM	tblCombatJoinGuild
	 WHERE	CombatID=@pCombatID
	   AND	serverindex=@pserverindex
	order by ApplyDt

	RETURN
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadCombatGuildInfo]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadCombatGuildInfo]
		@pserverindex	char(2),
		@pGuildID		char(6)
AS
SET NOCOUNT ON

	SELECT	a.CombatID, a.GuildID, a.Status, a.CombatFee, a.ReturnCombatFee, a.Point, a.Reward
	  FROM	tblCombatJoinGuild a 
	 WHERE	a.serverindex=@pserverindex
	   AND  a.GuildID=@pGuildID
	   AND	a.RewardDt is NULL

	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspStartCombat]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspStartCombat]
		@pCombatID		int,
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	UPDATE tblCombatInfo SET Status='20' WHERE CombatID=@pCombatID AND serverindex=@pserverindex AND Status='10'
	
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END
		
	UPDATE tblCombatJoinGuild SET Status='20' WHERE CombatID=@pCombatID AND serverindex=@pserverindex AND Status='10'
	
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9002 as retValue
		RETURN
	END

	SELECT 1 as retValue
	RETURN
		
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspRestoreCouple]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------
create proc [dbo].[uspRestoreCouple]
@nServer int
as
set nocount on

select  C.cid, C.nExperience,
	idFirst = (select max(idPlayer) from tblCouplePlayer where C.cid = cid and C.nServer = nServer  ),
	idSecond = (select min(idPlayer) from tblCouplePlayer where C.cid = cid and C.nServer = nServer  )
from tblCouple C
where nServer = @nServer
GO
/****** Object:  StoredProcedure [dbo].[uspRewardCombatGuild]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspRewardCombatGuild]
		@pCombatID		int,
		@pserverindex	char(2),
		@pGuildID		char(6)
AS
SET NOCOUNT ON

	UPDATE	tblCombatJoinGuild
	   SET	RewardDt=getdate(),
			Status='31'
	 WHERE	CombatID=@pCombatID
	   AND	serverindex=@pserverindex
	   AND	GuildID=@pGuildID
	   
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END

	SELECT 1 as retValue	
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspRewardCombatPlayer]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspRewardCombatPlayer]
		@pCombatID		int,
		@pserverindex	char(2),
		@pGuildID		char(6),
		@pPlayerID		char(7)
AS
SET NOCOUNT ON

	UPDATE	tblCombatJoinPlayer 
		SET	RewardDt=getdate(),
			Status='31'
	  WHERE	CombatID=@pCombatID
	  AND	serverindex=@pserverindex
	  AND	GuildID=@pGuildID
	  AND	PlayerID=@pPlayerID
			
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END

	SELECT 1 as retValue
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspRankGuildCombatPlayer]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[uspRankGuildCombatPlayer]
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT	a.PlayerID, max(b.m_nJob) as Job, sum(a.Point) as PointSummary
	  FROM	tblCombatJoinPlayer a INNER JOIN CHARACTER_TBL b ON (a.PlayerID=b.m_idPlayer)
	GROUP BY	a.PlayerID
	HAVING sum(a.Point)>0
	ORDER BY sum(a.Point)

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadCombatBestPlayer]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadCombatBestPlayer]
		@pCombatID		int,
		@pserverindex	char(2)
AS
SET NOCOUNT ON

	SELECT	TOP 1 PlayerID
	  FROM	tblCombatJoinPlayer
	 WHERE	CombatID=@pCombatID
	   AND	serverindex=@pserverindex
	   AND	Reward>0
	   
	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoadCombatUnpaidList]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[uspLoadCombatUnpaidList]
		@pserverindex	char(2)
AS
SET NOCOUNT ON

		SELECT	'G' as Flag, CombatID, serverindex, GuildID, Status, '000000' as PlayerID, CombatFee, ReturnCombatFee, Reward
		FROM 	tblCombatJoinGuild
		WHERE serverindex=@pserverindex
		AND  Status='30'
	UNION ALL
		SELECT  'P' as Flag, CombatID, serverindex, GuildID, Status, PlayerID, 0 as CombatFee, 0 as ReturnCombatFee,Reward
		FROM tblCombatJoinPlayer 
		WHERE serverindex=@pserverindex
		AND Status='30'
		AND Reward>0
	ORDER BY CombatID, Flag, Reward, ReturnCombatFee, GuildID

	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspGradeCombatPlayer]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspGradeCombatPlayer]
		@pCombatID		int,
		@pserverindex	char(2),
		@pGuildID		char(6),
		@pPlayerID		char(7),
		@pPoint			int,
		@pReward		int=0
AS
SET NOCOUNT ON

	INSERT INTO tblCombatJoinPlayer(CombatID, serverindex, GuildID, PlayerID, Point, Reward, Status)
			VALUES (@pCombatID, @pserverindex, @pGuildID, @pPlayerID, @pPoint, @pReward, DEFAULT)

	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001 as retValue
		RETURN
	END

	SELECT 1 as retValue
	RETURN

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspExpireCombatReward]    Script Date: 04/03/2010 12:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspExpireCombatReward]
		@pCombatID		int,
		@pserverindex	char(2),
		@pGuildID		char(6),
		@pPlayerID		char(7)='0000000'
AS
SET NOCOUNT ON

	IF @pPlayerID='0000000' BEGIN
		UPDATE	tblCombatJoinGuild SET Status='32' 
		WHERE	CombatID=@pCombatID
		  AND	serverindex=@pserverindex
		  AND	GuildID=@pGuildID
		
		IF @@ROWCOUNT=0 BEGIN
			SELECT 9001 as retValue
			RETURN
		END
	END
	ELSE BEGIN
		UPDATE	tblCombatJoinPlayer SET Status='32' 
		WHERE	CombatID=@pCombatID
		  AND	serverindex=@pserverindex
		  AND	GuildID=@pGuildID
		  AND	PlayerID=@pPlayerID
		  
		IF @@ROWCOUNT=0 BEGIN
			SELECT 9002 as retValue
			RETURN
		END
	END

	SELECT 1 as retValue

SET NOCOUNT OFF
GO
/****** Object:  Default [DF_BANK_EXT_m_extBank]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_EXT_TBL] ADD  CONSTRAINT [DF_BANK_EXT_m_extBank]  DEFAULT ('$') FOR [m_extBank]
GO
/****** Object:  Default [DF_BANK_EXT_m_BankPiercing]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_EXT_TBL] ADD  CONSTRAINT [DF_BANK_EXT_m_BankPiercing]  DEFAULT ('$') FOR [m_BankPiercing]
GO
/****** Object:  Default [DF_BANK_EXT_TBL_szBankPet]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_EXT_TBL] ADD  CONSTRAINT [DF_BANK_EXT_TBL_szBankPet]  DEFAULT ('$') FOR [szBankPet]
GO
/****** Object:  Default [DF_BANK_m_BankPw]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_TBL] ADD  CONSTRAINT [DF_BANK_m_BankPw]  DEFAULT ('0000') FOR [m_BankPw]
GO
/****** Object:  Default [DF_BANK_m_Bank]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_TBL] ADD  CONSTRAINT [DF_BANK_m_Bank]  DEFAULT ('$') FOR [m_Bank]
GO
/****** Object:  Default [DF_BANK_m_apIndex_Bank]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_TBL] ADD  CONSTRAINT [DF_BANK_m_apIndex_Bank]  DEFAULT ('$') FOR [m_apIndex_Bank]
GO
/****** Object:  Default [DF_BANK_m_dwObjIndex_Bank]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_TBL] ADD  CONSTRAINT [DF_BANK_m_dwObjIndex_Bank]  DEFAULT ('$') FOR [m_dwObjIndex_Bank]
GO
/****** Object:  Default [DF_BANK_m_dwGoldBank]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[BANK_TBL] ADD  CONSTRAINT [DF_BANK_m_dwGoldBank]  DEFAULT ((0)) FOR [m_dwGoldBank]
GO
/****** Object:  Default [DF_CHARACTER_TBL_m_nFuel]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_TBL_m_nFuel]  DEFAULT ((-1)) FOR [m_nFuel]
GO
/****** Object:  Default [DF_CHARACTER_MultiServer]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_MultiServer]  DEFAULT ((0)) FOR [MultiServer]
GO
/****** Object:  Default [DF_CHARACTER_dwEventFlag]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_dwEventFlag]  DEFAULT ((0)) FOR [dwEventFlag]
GO
/****** Object:  Default [DF_CHARACTER_dwEventTime]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_dwEventTime]  DEFAULT ((0)) FOR [dwEventTime]
GO
/****** Object:  Default [DF_CHARACTER_dwEventElapsed]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_dwEventElapsed]  DEFAULT ((0)) FOR [dwEventElapsed]
GO
/****** Object:  Default [DF_CHARACTER_PKValue]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_PKValue]  DEFAULT ((0)) FOR [PKValue]
GO
/****** Object:  Default [DF_CHARACTER_PKPropensity]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_PKPropensity]  DEFAULT ((0)) FOR [PKPropensity]
GO
/****** Object:  Default [DF_CHARACTER_PKExp]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_PKExp]  DEFAULT ((0)) FOR [PKExp]
GO
/****** Object:  Default [DF_CHARACTER_AngelExp]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_AngelExp]  DEFAULT ((0)) FOR [AngelExp]
GO
/****** Object:  Default [DF_CHARACTER_AngelLevel]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_AngelLevel]  DEFAULT ((0)) FOR [AngelLevel]
GO
/****** Object:  Default [DF_CHARACTER_FinalLevelDt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_FinalLevelDt]  DEFAULT ('2000-01-01') FOR [FinalLevelDt]
GO
/****** Object:  Default [DF__CHARACTER__m_dwP__6B0FDBE9]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF__CHARACTER__m_dwP__6B0FDBE9]  DEFAULT ((-1)) FOR [m_dwPetId]
GO
/****** Object:  Default [DF__CHARACTER__m_nEx__7E22B05D]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF__CHARACTER__m_nEx__7E22B05D]  DEFAULT ((0)) FOR [m_nExpLog]
GO
/****** Object:  Default [DF__CHARACTER__m_nAn__7F16D496]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF__CHARACTER__m_nAn__7F16D496]  DEFAULT ((0)) FOR [m_nAngelExpLog]
GO
/****** Object:  Default [DF__CHARACTER__m_nCo__05A3D694]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  DEFAULT ((0)) FOR [m_nCoupon]
GO
/****** Object:  Default [DF_CHARACTER_TBL_m_nHonor]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_TBL_m_nHonor]  DEFAULT ((-1)) FOR [m_nHonor]
GO
/****** Object:  Default [DF_CHARACTER_TBL_m_nLayer]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_TBL_m_nLayer]  DEFAULT ((0)) FOR [m_nLayer]
GO
/****** Object:  Default [DF_CHARACTER_TBL_m_nCampusPoint]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_TBL_m_nCampusPoint]  DEFAULT ((0)) FOR [m_nCampusPoint]
GO
/****** Object:  Default [DF_CHARACTER_TBL_idCampus]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_TBL_idCampus]  DEFAULT ((0)) FOR [idCampus]
GO
/****** Object:  Default [DF_CHARACTER_TBL_m_aCheckedQuest]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL] ADD  CONSTRAINT [DF_CHARACTER_TBL_m_aCheckedQuest]  DEFAULT ('$') FOR [m_aCheckedQuest]
GO
/****** Object:  Default [DF_CHARACTER_TBL_validity_check_regdate]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[CHARACTER_TBL_validity_check] ADD  CONSTRAINT [DF_CHARACTER_TBL_validity_check_regdate]  DEFAULT (getdate()) FOR [regdate]
GO
/****** Object:  Default [DF_GUILD_BANK_EXT_TBL_szGuildBankPet]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[GUILD_BANK_EXT_TBL] ADD  CONSTRAINT [DF_GUILD_BANK_EXT_TBL_szGuildBankPet]  DEFAULT ('$') FOR [szGuildBankPet]
GO
/****** Object:  Default [DF__GUILD_COM__m_nPe__7167D3BD]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[GUILD_COMBAT_1TO1_TENDER_TBL] ADD  CONSTRAINT [DF__GUILD_COM__m_nPe__7167D3BD]  DEFAULT ((0)) FOR [m_nPenya]
GO
/****** Object:  Default [DF__GUILD_COM__s_dat__725BF7F6]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[GUILD_COMBAT_1TO1_TENDER_TBL] ADD  CONSTRAINT [DF__GUILD_COM__s_dat__725BF7F6]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_INVENTORY_EXT_TBL_szInventoryPet]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[INVENTORY_EXT_TBL] ADD  CONSTRAINT [DF_INVENTORY_EXT_TBL_szInventoryPet]  DEFAULT ('$') FOR [szInventoryPet]
GO
/****** Object:  Default [DF_ITEM_REMOVE_AbilityOpt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_AbilityOpt]  DEFAULT ((0)) FOR [m_nAbilityOption]
GO
/****** Object:  Default [DF_ITEM_REMOVE_ItemCnt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_ItemCnt]  DEFAULT ((1)) FOR [Item_count]
GO
/****** Object:  Default [DF_ITEM_REMOVE_State]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_State]  DEFAULT ('I') FOR [State]
GO
/****** Object:  Default [DF_ITEM_REMOVE_ItemResist]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_ItemResist]  DEFAULT ((0)) FOR [m_bItemResist]
GO
/****** Object:  Default [DF_ITEM_REMOVE_ResAbilityOpt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_ResAbilityOpt]  DEFAULT ((0)) FOR [m_nResistAbilityOption]
GO
/****** Object:  Default [DF_ITEM_REMOVE_ItemFlag]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_ItemFlag]  DEFAULT ((0)) FOR [ItemFlag]
GO
/****** Object:  Default [DF_ITEM_REMOVE_ReceiveDt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_ReceiveDt]  DEFAULT (getdate()) FOR [ReceiveDt]
GO
/****** Object:  Default [DF_ITEM_REMOVE_RequestUser]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_RequestUser]  DEFAULT ((0)) FOR [RequestUser]
GO
/****** Object:  Default [DF_ITEM_REMOVE_RandomOpt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_ITEM_REMOVE_RandomOpt]  DEFAULT ((0)) FOR [RandomOption]
GO
/****** Object:  Default [DF_ITEM_SEND_ItemCnt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_ItemCnt]  DEFAULT ((1)) FOR [Item_count]
GO
/****** Object:  Default [DF_ITEM_SEND_AbilityOpt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_AbilityOpt]  DEFAULT ('000000') FOR [m_nAbilityOption]
GO
/****** Object:  Default [DF_ITEM_SEND_ItemResist]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_ItemResist]  DEFAULT ('000000') FOR [m_bItemResist]
GO
/****** Object:  Default [DF_ITEM_SEND_ResAbilityOpt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_ResAbilityOpt]  DEFAULT ('000000') FOR [m_nResistAbilityOption]
GO
/****** Object:  Default [DF_ITEM_SEND_Charged]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_Charged]  DEFAULT ((0)) FOR [m_bCharged]
GO
/****** Object:  Default [DF_ITEM_SEND_idSender]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_idSender]  DEFAULT ('0000000') FOR [idSender]
GO
/****** Object:  Default [DF_ITEM_SEND_nPiercedSize]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_nPiercedSize]  DEFAULT ((0)) FOR [nPiercedSize]
GO
/****** Object:  Default [DF_ITEM_SEND_adwItemId0]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_adwItemId0]  DEFAULT ((0)) FOR [adwItemId0]
GO
/****** Object:  Default [DF_ITEM_SEND_adwItemId1]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_adwItemId1]  DEFAULT ((0)) FOR [adwItemId1]
GO
/****** Object:  Default [DF_ITEM_SEND_adwItemId2]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_adwItemId2]  DEFAULT ((0)) FOR [adwItemId2]
GO
/****** Object:  Default [DF_ITEM_SEND_adwItemId3]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_adwItemId3]  DEFAULT ((0)) FOR [adwItemId3]
GO
/****** Object:  Default [DF_ITEM_SEND_KeepTime]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_KeepTime]  DEFAULT ((0)) FOR [m_dwKeepTime]
GO
/****** Object:  Default [DF_ITEM_SEND_ItemFlag]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_ItemFlag]  DEFAULT ((0)) FOR [ItemFlag]
GO
/****** Object:  Default [DF_ITEM_SEND_ReceiveDt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_ReceiveDt]  DEFAULT (getdate()) FOR [ReceiveDt]
GO
/****** Object:  Default [DF_ITEM_SEND_RandomOpt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_RandomOpt]  DEFAULT ((0)) FOR [nRandomOptItemId]
GO
/****** Object:  Default [DF_ITEM_SEND_adwItemId4]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_adwItemId4]  DEFAULT ((0)) FOR [adwItemId4]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwItemId5]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwItemId5]  DEFAULT ((0)) FOR [adwItemId5]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwItemId6]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwItemId6]  DEFAULT ((0)) FOR [adwItemId6]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwItemId7]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwItemId7]  DEFAULT ((0)) FOR [adwItemId7]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwItemId8]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwItemId8]  DEFAULT ((0)) FOR [adwItemId8]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwItemId9]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwItemId9]  DEFAULT ((0)) FOR [adwItemId9]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_nUMPiercedSize]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_nUMPiercedSize]  DEFAULT ((0)) FOR [nUMPiercedSize]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwUMItemId0]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwUMItemId0]  DEFAULT ((0)) FOR [adwUMItemId0]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwUMItemId1]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwUMItemId1]  DEFAULT ((0)) FOR [adwUMItemId1]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwUMItemId2]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwUMItemId2]  DEFAULT ((0)) FOR [adwUMItemId2]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwUMItemId3]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwUMItemId3]  DEFAULT ((0)) FOR [adwUMItemId3]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_adwUMItemId4]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[ITEM_SEND_TBL] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_adwUMItemId4]  DEFAULT ((0)) FOR [adwUMItemId4]
GO
/****** Object:  Default [DF_MAIL_TBL_tmCreate]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_tmCreate]  DEFAULT ((0)) FOR [tmCreate]
GO
/****** Object:  Default [DF_MAIL_TBL_byRead]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_byRead]  DEFAULT ((0)) FOR [byRead]
GO
/****** Object:  Default [DF_MAIL_TBL_ItemFlag]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_ItemFlag]  DEFAULT ((0)) FOR [ItemFlag]
GO
/****** Object:  Default [DF_MAIL_TBL_GoldFag]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_GoldFag]  DEFAULT ((0)) FOR [GoldFlag]
GO
/****** Object:  Default [DF__MAIL_TBL__bPet__6C040022]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__bPet__6C040022]  DEFAULT ((0)) FOR [bPet]
GO
/****** Object:  Default [DF__MAIL_TBL__nKind__6CF8245B]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__nKind__6CF8245B]  DEFAULT ((0)) FOR [nKind]
GO
/****** Object:  Default [DF__MAIL_TBL__nLevel__6DEC4894]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__nLevel__6DEC4894]  DEFAULT ((0)) FOR [nLevel]
GO
/****** Object:  Default [DF__MAIL_TBL__dwExp__6EE06CCD]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__dwExp__6EE06CCD]  DEFAULT ((0)) FOR [dwExp]
GO
/****** Object:  Default [DF__MAIL_TBL__wEnerg__6FD49106]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__wEnerg__6FD49106]  DEFAULT ((0)) FOR [wEnergy]
GO
/****** Object:  Default [DF__MAIL_TBL__wLife__70C8B53F]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__wLife__70C8B53F]  DEFAULT ((0)) FOR [wLife]
GO
/****** Object:  Default [DF__MAIL_TBL__anAvai__71BCD978]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__anAvai__71BCD978]  DEFAULT ((0)) FOR [anAvailLevel_D]
GO
/****** Object:  Default [DF__MAIL_TBL__anAvai__72B0FDB1]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__anAvai__72B0FDB1]  DEFAULT ((0)) FOR [anAvailLevel_C]
GO
/****** Object:  Default [DF__MAIL_TBL__anAvai__73A521EA]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__anAvai__73A521EA]  DEFAULT ((0)) FOR [anAvailLevel_B]
GO
/****** Object:  Default [DF__MAIL_TBL__anAvai__74994623]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__anAvai__74994623]  DEFAULT ((0)) FOR [anAvailLevel_A]
GO
/****** Object:  Default [DF__MAIL_TBL__anAvai__758D6A5C]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__anAvai__758D6A5C]  DEFAULT ((0)) FOR [anAvailLevel_S]
GO
/****** Object:  Default [DF__MAIL_TBL__dwItem__7D2E8C24]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF__MAIL_TBL__dwItem__7D2E8C24]  DEFAULT ((0)) FOR [dwItemId5]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId6]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId6]  DEFAULT ((0)) FOR [dwItemId6]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId7]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId7]  DEFAULT ((0)) FOR [dwItemId7]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId8]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId8]  DEFAULT ((0)) FOR [dwItemId8]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId9]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId9]  DEFAULT ((0)) FOR [dwItemId9]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId10]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId10]  DEFAULT ((0)) FOR [dwItemId10]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId11]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId11]  DEFAULT ((0)) FOR [dwItemId11]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId12]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId12]  DEFAULT ((0)) FOR [dwItemId12]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId13]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId13]  DEFAULT ((0)) FOR [dwItemId13]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId14]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId14]  DEFAULT ((0)) FOR [dwItemId14]
GO
/****** Object:  Default [DF_MAIL_TBL_dwItemId15]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_dwItemId15]  DEFAULT ((0)) FOR [dwItemId15]
GO
/****** Object:  Default [DF_MAIL_TBL_nPiercedSize2]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[MAIL_TBL] ADD  CONSTRAINT [DF_MAIL_TBL_nPiercedSize2]  DEFAULT ((0)) FOR [nPiercedSize2]
GO
/****** Object:  Default [DF_TAG_CreateTime]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[TAG_TBL] ADD  CONSTRAINT [DF_TAG_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_tblCampus_CreateTime]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCampus] ADD  CONSTRAINT [DF_tblCampus_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_tblCampusMember_CreateTime]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCampusMember] ADD  CONSTRAINT [DF_tblCampusMember_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_tblChangeBankPW_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblChangeBankPW] ADD  CONSTRAINT [DF_tblChangeBankPW_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblCombatInfo_Comment]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCombatInfo] ADD  CONSTRAINT [DF_tblCombatInfo_Comment]  DEFAULT ('') FOR [Comment]
GO
/****** Object:  Default [DF_tblCombatJoinGuild_StraightWin]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCombatJoinGuild] ADD  CONSTRAINT [DF_tblCombatJoinGuild_StraightWin]  DEFAULT ((0)) FOR [StraightWin]
GO
/****** Object:  Default [DF_tblCombatJoinPlayer_Status]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCombatJoinPlayer] ADD  CONSTRAINT [DF_tblCombatJoinPlayer_Status]  DEFAULT ('30') FOR [Status]
GO
/****** Object:  Default [DF_tblCombatJoinPlayer_Point]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCombatJoinPlayer] ADD  CONSTRAINT [DF_tblCombatJoinPlayer_Point]  DEFAULT ((0)) FOR [Point]
GO
/****** Object:  Default [DF_tblCombatJoinPlayer_Reward]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCombatJoinPlayer] ADD  CONSTRAINT [DF_tblCombatJoinPlayer_Reward]  DEFAULT ((0)) FOR [Reward]
GO
/****** Object:  Default [DF_tblCouple_add_Date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCouple] ADD  CONSTRAINT [DF_tblCouple_add_Date]  DEFAULT (getdate()) FOR [add_Date]
GO
/****** Object:  Default [DF_tblCouple_deleted_del_Date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCouple_deleted] ADD  CONSTRAINT [DF_tblCouple_deleted_del_Date]  DEFAULT (getdate()) FOR [del_Date]
GO
/****** Object:  Default [DF_tblElection_chrcount]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblElection] ADD  CONSTRAINT [DF_tblElection_chrcount]  DEFAULT ((0)) FOR [chrcount]
GO
/****** Object:  Default [DF__tblEvent___regda__57A801BA]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblEvent_Board_Provide] ADD  DEFAULT (getdate()) FOR [regdate]
GO
/****** Object:  Default [DF_tblFunnyCoin_ItemFlag]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblFunnyCoin] ADD  CONSTRAINT [DF_tblFunnyCoin_ItemFlag]  DEFAULT ((0)) FOR [ItemFlag]
GO
/****** Object:  Default [DF_tblGuildHoues_Furniture_bSetup]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblGuildHouse_Furniture] ADD  CONSTRAINT [DF_tblGuildHoues_Furniture_bSetup]  DEFAULT ((0)) FOR [bSetup]
GO
/****** Object:  Default [DF_tblGuildHoues_Furniture_x_Pos]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblGuildHouse_Furniture] ADD  CONSTRAINT [DF_tblGuildHoues_Furniture_x_Pos]  DEFAULT ((0)) FOR [x_Pos]
GO
/****** Object:  Default [DF_tblGuildHoues_Furniture_y_Pos]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblGuildHouse_Furniture] ADD  CONSTRAINT [DF_tblGuildHoues_Furniture_y_Pos]  DEFAULT ((0)) FOR [y_Pos]
GO
/****** Object:  Default [DF_tblGuildHoues_Furniture_z_Pos]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblGuildHouse_Furniture] ADD  CONSTRAINT [DF_tblGuildHoues_Furniture_z_Pos]  DEFAULT ((0)) FOR [z_Pos]
GO
/****** Object:  Default [DF_tblGuildHoues_Furniture_fAngle]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblGuildHouse_Furniture] ADD  CONSTRAINT [DF_tblGuildHoues_Furniture_fAngle]  DEFAULT ((0)) FOR [fAngle]
GO
/****** Object:  Default [DF_tblGuildHoues_Furniture_tKeepTime]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblGuildHouse_Furniture] ADD  CONSTRAINT [DF_tblGuildHoues_Furniture_tKeepTime]  DEFAULT ((0)) FOR [tKeepTime]
GO
/****** Object:  Default [DF_tblGuildHouse_Furniture_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblGuildHouse_Furniture] ADD  CONSTRAINT [DF_tblGuildHouse_Furniture_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblHousing_bSetup]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblHousing] ADD  CONSTRAINT [DF_tblHousing_bSetup]  DEFAULT ((0)) FOR [bSetup]
GO
/****** Object:  Default [DF_tblHousing_x_Pos]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblHousing] ADD  CONSTRAINT [DF_tblHousing_x_Pos]  DEFAULT ((0)) FOR [x_Pos]
GO
/****** Object:  Default [DF_tblHousing_y_Pos]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblHousing] ADD  CONSTRAINT [DF_tblHousing_y_Pos]  DEFAULT ((0)) FOR [y_Pos]
GO
/****** Object:  Default [DF_tblHousing_z_Pos]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblHousing] ADD  CONSTRAINT [DF_tblHousing_z_Pos]  DEFAULT ((0)) FOR [z_Pos]
GO
/****** Object:  Default [DF_tblHousing_fAngle]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblHousing] ADD  CONSTRAINT [DF_tblHousing_fAngle]  DEFAULT ((0)) FOR [fAngle]
GO
/****** Object:  Default [DF_tblHousing_Start_Time]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblHousing] ADD  CONSTRAINT [DF_tblHousing_Start_Time]  DEFAULT (getdate()) FOR [Start_Time]
GO
/****** Object:  Default [DF_tblLogout_Penya_m_dwGold]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLogout_Penya] ADD  CONSTRAINT [DF_tblLogout_Penya_m_dwGold]  DEFAULT ((0)) FOR [m_dwGold]
GO
/****** Object:  Default [DF_tblLogout_Penya_regdate]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLogout_Penya] ADD  CONSTRAINT [DF_tblLogout_Penya_regdate]  DEFAULT (getdate()) FOR [regdate]
GO
/****** Object:  Default [DF_tblLogout_Penya_Diff_Log_regdate]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLogout_Penya_Diff_Log] ADD  CONSTRAINT [DF_tblLogout_Penya_Diff_Log_regdate]  DEFAULT (getdate()) FOR [regdate_now]
GO
/****** Object:  Default [DF_tblLod_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLord] ADD  CONSTRAINT [DF_tblLod_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblLordCandidates_iDeposit]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordCandidates] ADD  CONSTRAINT [DF_tblLordCandidates_iDeposit]  DEFAULT ((0)) FOR [iDeposit]
GO
/****** Object:  Default [DF_tblLordCandidates_nVote]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordCandidates] ADD  CONSTRAINT [DF_tblLordCandidates_nVote]  DEFAULT ((0)) FOR [nVote]
GO
/****** Object:  Default [DF_tblLordCandidates_szPledge]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordCandidates] ADD  CONSTRAINT [DF_tblLordCandidates_szPledge]  DEFAULT ('') FOR [szPledge]
GO
/****** Object:  Default [DF_tblLordCandidates_IsLeftOut]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordCandidates] ADD  CONSTRAINT [DF_tblLordCandidates_IsLeftOut]  DEFAULT ('F') FOR [IsLeftOut]
GO
/****** Object:  Default [DF_tblLordCandidates_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordCandidates] ADD  CONSTRAINT [DF_tblLordCandidates_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblLordCandidates_tCreate]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordCandidates] ADD  CONSTRAINT [DF_tblLordCandidates_tCreate]  DEFAULT ((0)) FOR [tCreate]
GO
/****** Object:  Default [DF_tblLordElection_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordElection] ADD  CONSTRAINT [DF_tblLordElection_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblLordElector_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordElector] ADD  CONSTRAINT [DF_tblLordElector_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblLordEvent_nTick]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordEvent] ADD  CONSTRAINT [DF_tblLordEvent_nTick]  DEFAULT ((0)) FOR [nTick]
GO
/****** Object:  Default [DF_tblLordEvent_fEFactor]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordEvent] ADD  CONSTRAINT [DF_tblLordEvent_fEFactor]  DEFAULT ((0.0)) FOR [fEFactor]
GO
/****** Object:  Default [DF_tblLordEvent_fIFactor]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordEvent] ADD  CONSTRAINT [DF_tblLordEvent_fIFactor]  DEFAULT ((0.0)) FOR [fIFactor]
GO
/****** Object:  Default [DF_tblLordEvent_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordEvent] ADD  CONSTRAINT [DF_tblLordEvent_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblLordSkill_nTick]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordSkill] ADD  CONSTRAINT [DF_tblLordSkill_nTick]  DEFAULT ((0)) FOR [nTick]
GO
/****** Object:  Default [DF_tblLordSkill_s_date]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblLordSkill] ADD  CONSTRAINT [DF_tblLordSkill_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblMaster_all_c01]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c01]  DEFAULT ((0)) FOR [c01]
GO
/****** Object:  Default [DF_tblMaster_all_c02]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c02]  DEFAULT ((0)) FOR [c02]
GO
/****** Object:  Default [DF_tblMaster_all_c03]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c03]  DEFAULT ((0)) FOR [c03]
GO
/****** Object:  Default [DF_tblMaster_all_c04]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c04]  DEFAULT ((0)) FOR [c04]
GO
/****** Object:  Default [DF_tblMaster_all_c05]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c05]  DEFAULT ((0)) FOR [c05]
GO
/****** Object:  Default [DF_tblMaster_all_c06]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c06]  DEFAULT ((0)) FOR [c06]
GO
/****** Object:  Default [DF_tblMaster_all_c07]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c07]  DEFAULT ((0)) FOR [c07]
GO
/****** Object:  Default [DF_tblMaster_all_c08]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c08]  DEFAULT ((0)) FOR [c08]
GO
/****** Object:  Default [DF_tblMaster_all_c09]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c09]  DEFAULT ((0)) FOR [c09]
GO
/****** Object:  Default [DF_tblMaster_all_c10]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c10]  DEFAULT ((0)) FOR [c10]
GO
/****** Object:  Default [DF_tblMaster_all_c11]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c11]  DEFAULT ((0)) FOR [c11]
GO
/****** Object:  Default [DF_tblMaster_all_c12]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c12]  DEFAULT ((0)) FOR [c12]
GO
/****** Object:  Default [DF_tblMaster_all_c13]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c13]  DEFAULT ((0)) FOR [c13]
GO
/****** Object:  Default [DF_tblMaster_all_c14]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c14]  DEFAULT ((0)) FOR [c14]
GO
/****** Object:  Default [DF_tblMaster_all_c15]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c15]  DEFAULT ((0)) FOR [c15]
GO
/****** Object:  Default [DF_tblMaster_all_c16]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c16]  DEFAULT ((0)) FOR [c16]
GO
/****** Object:  Default [DF_tblMaster_all_c17]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c17]  DEFAULT ((0)) FOR [c17]
GO
/****** Object:  Default [DF_tblMaster_all_c18]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c18]  DEFAULT ((0)) FOR [c18]
GO
/****** Object:  Default [DF_tblMaster_all_c19]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c19]  DEFAULT ((0)) FOR [c19]
GO
/****** Object:  Default [DF_tblMaster_all_c20]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c20]  DEFAULT ((0)) FOR [c20]
GO
/****** Object:  Default [DF_tblMaster_all_c21]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c21]  DEFAULT ((0)) FOR [c21]
GO
/****** Object:  Default [DF_tblMaster_all_c22]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c22]  DEFAULT ((0)) FOR [c22]
GO
/****** Object:  Default [DF_tblMaster_all_c23]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c23]  DEFAULT ((0)) FOR [c23]
GO
/****** Object:  Default [DF_tblMaster_all_c24]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c24]  DEFAULT ((0)) FOR [c24]
GO
/****** Object:  Default [DF_tblMaster_all_c25]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c25]  DEFAULT ((0)) FOR [c25]
GO
/****** Object:  Default [DF_tblMaster_all_c26]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c26]  DEFAULT ((0)) FOR [c26]
GO
/****** Object:  Default [DF_tblMaster_all_c27]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c27]  DEFAULT ((0)) FOR [c27]
GO
/****** Object:  Default [DF_tblMaster_all_c28]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c28]  DEFAULT ((0)) FOR [c28]
GO
/****** Object:  Default [DF_tblMaster_all_c29]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c29]  DEFAULT ((0)) FOR [c29]
GO
/****** Object:  Default [DF_tblMaster_all_c30]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c30]  DEFAULT ((0)) FOR [c30]
GO
/****** Object:  Default [DF_tblMaster_all_c31]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c31]  DEFAULT ((0)) FOR [c31]
GO
/****** Object:  Default [DF_tblMaster_all_c32]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c32]  DEFAULT ((0)) FOR [c32]
GO
/****** Object:  Default [DF_tblMaster_all_c33]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c33]  DEFAULT ((0)) FOR [c33]
GO
/****** Object:  Default [DF_tblMaster_all_c34]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c34]  DEFAULT ((0)) FOR [c34]
GO
/****** Object:  Default [DF_tblMaster_all_c35]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c35]  DEFAULT ((0)) FOR [c35]
GO
/****** Object:  Default [DF_tblMaster_all_c36]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c36]  DEFAULT ((0)) FOR [c36]
GO
/****** Object:  Default [DF_tblMaster_all_c37]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c37]  DEFAULT ((0)) FOR [c37]
GO
/****** Object:  Default [DF_tblMaster_all_c38]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c38]  DEFAULT ((0)) FOR [c38]
GO
/****** Object:  Default [DF_tblMaster_all_c39]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c39]  DEFAULT ((0)) FOR [c39]
GO
/****** Object:  Default [DF_tblMaster_all_c40]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c40]  DEFAULT ((0)) FOR [c40]
GO
/****** Object:  Default [DF_tblMaster_all_c41]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c41]  DEFAULT ((0)) FOR [c41]
GO
/****** Object:  Default [DF_tblMaster_all_c42]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c42]  DEFAULT ((0)) FOR [c42]
GO
/****** Object:  Default [DF_tblMaster_all_c43]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c43]  DEFAULT ((0)) FOR [c43]
GO
/****** Object:  Default [DF_tblMaster_all_c44]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c44]  DEFAULT ((0)) FOR [c44]
GO
/****** Object:  Default [DF_tblMaster_all_c45]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c45]  DEFAULT ((0)) FOR [c45]
GO
/****** Object:  Default [DF_tblMaster_all_c46]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c46]  DEFAULT ((0)) FOR [c46]
GO
/****** Object:  Default [DF_tblMaster_all_c47]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c47]  DEFAULT ((0)) FOR [c47]
GO
/****** Object:  Default [DF_tblMaster_all_c48]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c48]  DEFAULT ((0)) FOR [c48]
GO
/****** Object:  Default [DF_tblMaster_all_c49]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c49]  DEFAULT ((0)) FOR [c49]
GO
/****** Object:  Default [DF_tblMaster_all_c50]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMaster_all] ADD  CONSTRAINT [DF_tblMaster_all_c50]  DEFAULT ((0)) FOR [c50]
GO
/****** Object:  Default [DF_tblMessenger_dwState]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMessenger] ADD  CONSTRAINT [DF_tblMessenger_dwState]  DEFAULT ((0)) FOR [bBlock]
GO
/****** Object:  Default [DF_tblMessenger_chUse]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblMessenger] ADD  CONSTRAINT [DF_tblMessenger_chUse]  DEFAULT ('T') FOR [chUse]
GO
/****** Object:  Default [DF__tblQuiz__s_date__38EE7070]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblQuiz] ADD  CONSTRAINT [DF__tblQuiz__s_date__38EE7070]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblRemoveItemFromGuildBank_ItemCnt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblRemoveItemFromGuildBank] ADD  CONSTRAINT [DF_tblRemoveItemFromGuildBank_ItemCnt]  DEFAULT ((0)) FOR [ItemCnt]
GO
/****** Object:  Default [DF_tblRemoveItemFromGuildBank_DeleteRequestCnt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblRemoveItemFromGuildBank] ADD  CONSTRAINT [DF_tblRemoveItemFromGuildBank_DeleteRequestCnt]  DEFAULT ((0)) FOR [DeleteRequestCnt]
GO
/****** Object:  Default [DF_tblRemoveItemFromGuildBank_DeleteCnt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblRemoveItemFromGuildBank] ADD  CONSTRAINT [DF_tblRemoveItemFromGuildBank_DeleteCnt]  DEFAULT ((0)) FOR [DeleteCnt]
GO
/****** Object:  Default [DF_tblRemoveItemFromGuildBank_ItemFlag]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblRemoveItemFromGuildBank] ADD  CONSTRAINT [DF_tblRemoveItemFromGuildBank_ItemFlag]  DEFAULT ((0)) FOR [ItemFlag]
GO
/****** Object:  Default [DF_tblRemoveItemFromGuildBank_RegisterDt]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblRemoveItemFromGuildBank] ADD  CONSTRAINT [DF_tblRemoveItemFromGuildBank_RegisterDt]  DEFAULT (getdate()) FOR [RegisterDt]
GO
/****** Object:  ForeignKey [FK_tblCampusMember_tblCampus]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCampusMember]  WITH CHECK ADD  CONSTRAINT [FK_tblCampusMember_tblCampus] FOREIGN KEY([idCampus], [serverindex])
REFERENCES [dbo].[tblCampus] ([idCampus], [serverindex])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblCampusMember] CHECK CONSTRAINT [FK_tblCampusMember_tblCampus]
GO
/****** Object:  ForeignKey [FK_tblCombatJoinGuild]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCombatJoinGuild]  WITH CHECK ADD  CONSTRAINT [FK_tblCombatJoinGuild] FOREIGN KEY([CombatID], [serverindex])
REFERENCES [dbo].[tblCombatInfo] ([CombatID], [serverindex])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblCombatJoinGuild] CHECK CONSTRAINT [FK_tblCombatJoinGuild]
GO
/****** Object:  ForeignKey [FK_tblCombatJoinPlayer]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCombatJoinPlayer]  WITH CHECK ADD  CONSTRAINT [FK_tblCombatJoinPlayer] FOREIGN KEY([CombatID], [serverindex], [GuildID])
REFERENCES [dbo].[tblCombatJoinGuild] ([CombatID], [serverindex], [GuildID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tblCombatJoinPlayer] CHECK CONSTRAINT [FK_tblCombatJoinPlayer]
GO
/****** Object:  ForeignKey [FK_tblCouplePlayer]    Script Date: 04/03/2010 12:42:44 ******/
ALTER TABLE [dbo].[tblCouplePlayer]  WITH CHECK ADD  CONSTRAINT [FK_tblCouplePlayer] FOREIGN KEY([cid], [nServer])
REFERENCES [dbo].[tblCouple] ([cid], [nServer])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblCouplePlayer] CHECK CONSTRAINT [FK_tblCouplePlayer]
GO
RAISERROR( 'Step 10: Configure [LOGGING_01_DBF]',0,1) WITH NOWAIT
GO

USE [LOGGING_01_DBF]
GO
/****** Object:  Table [dbo].[LOG_DEATH_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_DEATH_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[dwWorldID] [int] NULL,
	[killed_m_szName] [varchar](32) NULL,
	[m_vPos_x] [real] NULL,
	[m_vPos_y] [real] NULL,
	[m_vPos_z] [real] NULL,
	[m_nLevel] [int] NULL,
	[attackPower] [int] NULL,
	[max_HP] [int] NULL,
	[s_date] [char](14) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_CHARACTER_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_CHARACTER_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[account] [varchar](32) NULL,
	[m_szName] [varchar](32) NULL,
	[CreateTime] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_BILLING_ITEM_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_BILLING_ITEM_TBL](
	[m_szName] [varchar](32) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_GetszName] [varchar](32) NULL,
	[dwWorldID] [int] NULL,
	[m_dwGold] [int] NULL,
	[m_nRemainGold] [int] NULL,
	[Item_UniqueNo] [int] NULL,
	[Item_Name] [varchar](32) NULL,
	[Item_durability] [int] NULL,
	[m_nAbilityOption] [int] NULL,
	[m_GetdwGold] [int] NULL,
	[Item_count] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[m_nSlot0] [int] NULL,
	[m_nSlot1] [int] NULL,
	[m_bItemResist] [int] NULL,
	[m_nResistAbilityOption] [int] NULL,
	[m_bCharged] [int] NULL,
	[m_dwKeepTime] [int] NULL,
	[m_nRandomOptItemId] [bigint] NULL,
	[nPiercedSize] [int] NULL,
	[adwItemId0] [int] NULL,
	[adwItemId1] [int] NULL,
	[adwItemId2] [int] NULL,
	[adwItemId3] [int] NULL,
	[MaxDurability] [int] NULL,
	[adwItemId4] [int] NULL,
	[nPetKind] [int] NULL,
	[nPetLevel] [int] NULL,
	[dwPetExp] [int] NULL,
	[wPetEnergy] [int] NULL,
	[wPetLife] [int] NULL,
	[nPetAL_D] [int] NULL,
	[nPetAL_C] [int] NULL,
	[nPetAL_B] [int] NULL,
	[nPetAL_A] [int] NULL,
	[nPetAL_S] [int] NULL,
	[adwItemId5] [int] NULL,
	[adwItemId6] [int] NULL,
	[adwItemId7] [int] NULL,
	[adwItemId8] [int] NULL,
	[adwItemId9] [int] NULL,
	[nUMPiercedSize] [int] NULL,
	[adwUMItemId0] [int] NULL,
	[adwUMItemId1] [int] NULL,
	[adwUMItemId2] [int] NULL,
	[adwUMItemId3] [int] NULL,
	[adwUMItemId4] [int] NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[gethmstime]    Script Date: 04/03/2010 12:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE	 function  [dbo].[gethmstime]
( 
		 @date		int
)  
returns varchar(50)
as

begin

declare @c_date varchar(50)
	select @c_date = RIGHT('00' + convert(varchar(44),@date / 3600),2) + ':' + right('00' + convert(varchar(2),(@date % 3600) / 60),2) + ':'  +  right('00' + convert(varchar(2),@date % 60),2)  
	return @c_date 
end
GO
/****** Object:  UserDefinedFunction [dbo].[getdatetime]    Script Date: 04/03/2010 12:45:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE	 function  [dbo].[getdatetime]
( 
		 @s_date		varchar(14)
)  
returns datetime
as

begin

declare @c_date datetime

	select @c_date = convert(datetime,substring(@s_date,1,4) + '-' +  substring(@s_date,5,2) + '-' +  substring(@s_date,7,2) + ' ' 
							  +  substring(@s_date,9,2) + ':' +  substring(@s_date,11,2) + ':' +  CASE substring(@s_date,13,2) WHEN '' THEN '00' ELSE substring(@s_date,13,2) END  + '.000' )
	return @c_date 
end
GO
/****** Object:  Table [dbo].[CHARACTER_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHARACTER_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[account] [varchar](32) NULL,
	[m_szName] [varchar](32) NULL,
	[isblock] [char](1) NULL,
	[m_nLevel] [int] NULL,
	[m_nJob] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_GUILD_SERVICE_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_GUILD_SERVICE_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_nLevel] [int] NULL,
	[m_GuildLv] [int] NULL,
	[GuildPoint] [int] NULL,
	[Gold] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_GUILD_DISPERSION_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_GUILD_DISPERSION_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_GUILD_BANK_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_GUILD_BANK_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_nGuildGold] [int] NULL,
	[m_GuildBank] [text] NULL,
	[m_Item] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[m_nAbilityOption] [int] NULL,
	[Item_count] [int] NULL,
	[Item_UniqueNo] [int] NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_GAMEMASTER_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_GAMEMASTER_TBL](
	[serverindex] [char](2) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[m_szWords] [char](1030) NULL,
	[s_date] [char](14) NULL,
	[m_idGuild] [char](6) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_SKILL_FREQUENCY_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_SKILL_FREQUENCY_TBL](
	[m_nid] [int] NULL,
	[m_nFrequency] [int] NULL,
	[s_date] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_RESPAWN_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_RESPAWN_TBL](
	[m_nid] [int] NULL,
	[m_nFrequency] [int] NULL,
	[s_date] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[LOG_RESET_STR]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[LOG_RESET_STR]
AS
DECLARE @name varchar(128)
DECLARE LogReset_Cursor CURSOR FOR 
SELECT name 
   FROM sysobjects 
 WHERE  type= 'U'
      AND category = 0 
  ORDER BY name

OPEN LogReset_Cursor

FETCH NEXT FROM LogReset_Cursor 
INTO @name

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT 'DELETE ' + @name
	EXEC('DELETE ' + @name)
   FETCH NEXT FROM LogReset_Cursor 
   INTO @name
END

CLOSE LogReset_Cursor
DEALLOCATE LogReset_Cursor
RETURN
GO
/****** Object:  Table [dbo].[LOG_QUEST_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_QUEST_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[Quest_Index] [int] NULL,
	[State] [char](1) NULL,
	[Start_Time] [char](14) NULL,
	[End_Time] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_PK_PVP_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_PK_PVP_TBL](
	[serverindex] [char](2) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[m_nLevel] [int] NULL,
	[m_vPos_x] [real] NULL,
	[m_vPos_z] [real] NULL,
	[killed_m_idPlayer] [char](7) NULL,
	[killed_m_nLevel] [int] NULL,
	[m_GetPoint] [int] NULL,
	[m_nSlaughter] [int] NULL,
	[m_nFame] [int] NULL,
	[killed_m_nSlaughter] [int] NULL,
	[killed_m_nFame] [int] NULL,
	[m_KillNum] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_LOGIN_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_LOGIN_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[dwWorldID] [int] NULL,
	[Start_Time] [char](14) NULL,
	[End_Time] [char](14) NULL,
	[TotalPlayTime] [int] NULL,
	[m_dwGold] [int] NULL,
	[remoteIP] [varchar](15) NULL,
	[account] [varchar](32) NULL,
	[CharLevel] [int] NULL,
	[Job] [int] NULL,
	[State] [tinyint] NOT NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_LEVELUP_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_LEVELUP_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[m_nExp1] [bigint] NULL,
	[m_nLevel] [int] NULL,
	[m_nJob] [int] NULL,
	[m_nJobLv] [int] NULL,
	[m_nFlightLv] [int] NULL,
	[m_nStr] [int] NULL,
	[m_nDex] [int] NULL,
	[m_nInt] [int] NULL,
	[m_nSta] [int] NULL,
	[m_nRemainGP] [int] NULL,
	[m_nRemainLP] [int] NULL,
	[m_dwGold] [int] NULL,
	[TotalPlayTime] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_ITEM_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_ITEM_TBL](
	[m_szName] [varchar](32) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_GetszName] [varchar](32) NULL,
	[dwWorldID] [int] NULL,
	[m_dwGold] [int] NULL,
	[m_nRemainGold] [int] NULL,
	[Item_UniqueNo] [int] NULL,
	[Item_Name] [varchar](32) NULL,
	[Item_durability] [int] NULL,
	[m_nAbilityOption] [int] NULL,
	[m_GetdwGold] [int] NULL,
	[Item_count] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[m_nSlot0] [int] NULL,
	[m_nSlot1] [int] NULL,
	[m_bItemResist] [int] NULL,
	[m_nResistAbilityOption] [int] NULL,
	[m_bCharged] [int] NULL,
	[m_dwKeepTime] [int] NULL,
	[m_nRandomOptItemId] [bigint] NULL,
	[nPiercedSize] [int] NULL,
	[adwItemId0] [int] NULL,
	[adwItemId1] [int] NULL,
	[adwItemId2] [int] NULL,
	[adwItemId3] [int] NULL,
	[MaxDurability] [int] NULL,
	[adwItemId4] [int] NULL,
	[nPetKind] [int] NULL,
	[nPetLevel] [int] NULL,
	[dwPetExp] [int] NULL,
	[wPetEnergy] [int] NULL,
	[wPetLife] [int] NULL,
	[nPetAL_D] [int] NULL,
	[nPetAL_C] [int] NULL,
	[nPetAL_B] [int] NULL,
	[nPetAL_A] [int] NULL,
	[nPetAL_S] [int] NULL,
	[adwItemId5] [int] NULL,
	[adwItemId6] [int] NULL,
	[adwItemId7] [int] NULL,
	[adwItemId8] [int] NULL,
	[adwItemId9] [int] NULL,
	[nUMPiercedSize] [int] NULL,
	[adwUMItemId0] [int] NULL,
	[adwUMItemId1] [int] NULL,
	[adwUMItemId2] [int] NULL,
	[adwUMItemId3] [int] NULL,
	[adwUMItemId4] [int] NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTradeLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTradeLog](
	[TradeID] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[WorldID] [int] NOT NULL,
	[TradeDt] [datetime] NOT NULL,
 CONSTRAINT [PK_tblTradeLog] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTradeItemLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTradeItemLog](
	[TradeID] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[idPlayer] [char](7) NOT NULL,
	[ItemIndex] [int] NOT NULL,
	[ItemSerialNum] [int] NOT NULL,
	[ItemCnt] [int] NOT NULL,
	[AbilityOpt] [int] NOT NULL,
	[ItemResist] [int] NOT NULL,
	[ResistAbilityOpt] [int] NOT NULL,
	[RandomOpt] [bigint] NOT NULL,
 CONSTRAINT [PK_tblTradeItemLog] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC,
	[serverindex] ASC,
	[idPlayer] ASC,
	[ItemIndex] ASC,
	[ItemSerialNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblTradeDetailLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTradeDetailLog](
	[TradeID] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[idPlayer] [char](7) NOT NULL,
	[Job] [int] NOT NULL,
	[Level] [int] NOT NULL,
	[TradeGold] [bigint] NOT NULL,
	[PlayerIP] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tblTradeDetailLog] PRIMARY KEY CLUSTERED 
(
	[TradeID] ASC,
	[serverindex] ASC,
	[idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSystemErrorLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSystemErrorLog](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NULL,
	[account] [varchar](32) NULL,
	[nChannel] [int] NULL,
	[chType] [char](1) NULL,
	[szError] [varchar](1024) NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sequence Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N'm_idPlayer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N'account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N'nChannel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N'chType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N'szError'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblSystemErrorLog', @level2type=N'COLUMN',@level2name=N's_date'
GO
/****** Object:  Table [dbo].[tblSkillPointLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSkillPointLog](
	[serverindex] [char](2) NULL,
	[PlayerID] [char](7) NULL,
	[SkillID] [int] NULL,
	[SkillLevel] [int] NULL,
	[SkillPoint] [int] NULL,
	[HoldingSkillPoint] [int] NULL,
	[TotalSkillPoint] [int] NULL,
	[SkillExp] [bigint] NULL,
	[UsingBy] [int] NULL,
	[ActionDt] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblQuizUserLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuizUserLog](
	[SEQ] [int] IDENTITY(1,1) NOT NULL,
	[m_idQuizEvent] [int] NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_nChannel] [int] NOT NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizUserLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizUserLog', @level2type=N'COLUMN',@level2name=N'm_idQuizEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? ???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizUserLog', @level2type=N'COLUMN',@level2name=N'm_idPlayer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizUserLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizUserLog', @level2type=N'COLUMN',@level2name=N'm_nChannel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizUserLog', @level2type=N'COLUMN',@level2name=N's_date'
GO
/****** Object:  Table [dbo].[tblQuizLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuizLog](
	[SEQ] [int] IDENTITY(1,1) NOT NULL,
	[m_idQuizEvent] [int] NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_nChannel] [int] NOT NULL,
	[m_nQuizType] [int] NOT NULL,
	[Start_Time] [datetime] NOT NULL,
	[End_Time] [datetime] NULL,
	[m_nWinnerCount] [int] NULL,
	[m_nQuizCount] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'm_idQuizEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'm_nChannel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ?? (OX : 1, ??? : 2)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'm_nQuizType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??? ?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'Start_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??? ?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'End_Time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'm_nWinnerCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ? ?? ?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizLog', @level2type=N'COLUMN',@level2name=N'm_nQuizCount'
GO
/****** Object:  Table [dbo].[tblQuizAnswerLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuizAnswerLog](
	[SEQ] [int] IDENTITY(1,1) NOT NULL,
	[m_idQuizEvent] [int] NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_nChannel] [int] NOT NULL,
	[m_nQuizNum] [int] NOT NULL,
	[m_nSelect] [int] NULL,
	[m_nAnswer] [int] NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SEQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'm_idQuizEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? ???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'm_idPlayer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'm_nChannel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'm_nQuizNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??? ??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'm_nSelect'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N'm_nAnswer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblQuizAnswerLog', @level2type=N'COLUMN',@level2name=N's_date'
GO
/****** Object:  Table [dbo].[tblQuestLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblQuestLog](
	[serverindex] [char](2) NOT NULL,
	[idPlayer] [char](7) NULL,
	[QuestIndex] [int] NOT NULL,
	[State] [varchar](3) NOT NULL,
	[LogDt] [datetime] NOT NULL,
	[Comment] [varchar](20) NOT NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPetLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPetLog](
	[serverindex] [char](2) NOT NULL,
	[idPlayer] [char](7) NOT NULL,
	[iSerial] [bigint] NOT NULL,
	[nType] [int] NOT NULL,
	[dwData] [int] NOT NULL,
	[nKind] [int] NOT NULL,
	[nLevel] [int] NOT NULL,
	[wLife] [int] NOT NULL,
	[wEnergy] [int] NOT NULL,
	[dwExp] [int] NOT NULL,
	[nAvailParam1] [int] NOT NULL,
	[nAvailParam2] [int] NOT NULL,
	[nAvailParam3] [int] NOT NULL,
	[nAvailParam4] [int] NOT NULL,
	[nAvailParam5] [int] NOT NULL,
	[LogDt] [datetime] NOT NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLogExpBox]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLogExpBox](
	[serverindex] [char](2) NULL,
	[idPlayer] [char](7) NULL,
	[objid] [bigint] NOT NULL,
	[iExp] [bigint] NOT NULL,
	[State] [char](1) NULL,
	[s_date] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblGuildHouseLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblGuildHouseLog](
	[SEQ] [int] IDENTITY(1,1) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_idGuild] [char](6) NOT NULL,
	[dwWorldID] [int] NULL,
	[tKeepTime] [int] NOT NULL,
	[m_szGuild] [varchar](32) NULL,
	[s_date] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouseLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouseLog', @level2type=N'COLUMN',@level2name=N'm_idGuild'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouseLog', @level2type=N'COLUMN',@level2name=N'dwWorldID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ??? ?? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouseLog', @level2type=N'COLUMN',@level2name=N'tKeepTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouseLog', @level2type=N'COLUMN',@level2name=N'm_szGuild'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouseLog', @level2type=N'COLUMN',@level2name=N's_date'
GO
/****** Object:  Table [dbo].[tblGuildHouse_FurnitureLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblGuildHouse_FurnitureLog](
	[serverindex] [char](2) NOT NULL,
	[m_idGuild] [char](6) NOT NULL,
	[SEQ] [int] NOT NULL,
	[ItemIndex] [int] NULL,
	[bSetup] [int] NULL,
	[Del_date] [datetime] NULL,
	[s_date] [datetime] NULL,
	[set_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N'm_idGuild'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N'SEQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ITEM ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N'ItemIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N'bSetup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N'Del_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ????' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N's_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ?? ?? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblGuildHouse_FurnitureLog', @level2type=N'COLUMN',@level2name=N'set_date'
GO
/****** Object:  Table [dbo].[tblChangeNameLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChangeNameLog](
	[ChangeID] [int] IDENTITY(1,1) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[StartDt] [datetime] NOT NULL,
	[EndDt] [datetime] NOT NULL,
	[idPlayer] [char](7) NULL,
	[CharName] [varchar](32) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblChangeNameHistoryLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblChangeNameHistoryLog](
	[serverindex] [char](2) NOT NULL,
	[idPlayer] [char](7) NULL,
	[OldCharName] [varchar](32) NOT NULL,
	[NewCharName] [varchar](32) NOT NULL,
	[ChangeDt] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCampusLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCampusLog](
	[SEQ] [int] IDENTITY(1,1) NOT NULL,
	[m_idMaster] [char](7) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_idPupil] [char](7) NULL,
	[idCampus] [int] NULL,
	[chState] [char](1) NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusLog', @level2type=N'COLUMN',@level2name=N'm_idMaster'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusLog', @level2type=N'COLUMN',@level2name=N'm_idPupil'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusLog', @level2type=N'COLUMN',@level2name=N'idCampus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? (T: ??, F: ??)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusLog', @level2type=N'COLUMN',@level2name=N'chState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampusLog', @level2type=N'COLUMN',@level2name=N's_date'
GO
/****** Object:  Table [dbo].[tblCampus_PointLog]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCampus_PointLog](
	[SEQ] [int] IDENTITY(1,1) NOT NULL,
	[m_idPlayer] [char](7) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[chState] [char](1) NULL,
	[nPrevPoint] [int] NULL,
	[nCurrPoint] [int] NULL,
	[s_date] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???? ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus_PointLog', @level2type=N'COLUMN',@level2name=N'm_idPlayer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus_PointLog', @level2type=N'COLUMN',@level2name=N'serverindex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? (Q: ???, P: ????)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus_PointLog', @level2type=N'COLUMN',@level2name=N'chState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ? ?? ???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus_PointLog', @level2type=N'COLUMN',@level2name=N'nPrevPoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'?? ? ?? ???(?????)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus_PointLog', @level2type=N'COLUMN',@level2name=N'nCurrPoint'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'??? ??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCampus_PointLog', @level2type=N'COLUMN',@level2name=N's_date'
GO
/****** Object:  Table [dbo].[LOG_USER_CNT_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_USER_CNT_TBL](
	[serverindex] [char](2) NOT NULL,
	[s_date] [char](14) NULL,
	[number] [int] NULL,
	[m_01] [int] NULL,
	[m_02] [int] NULL,
	[m_03] [int] NULL,
	[m_04] [int] NULL,
	[m_05] [int] NULL,
	[m_06] [int] NULL,
	[m_07] [int] NULL,
	[m_08] [int] NULL,
	[m_09] [int] NULL,
	[m_10] [int] NULL,
	[m_11] [int] NULL,
	[m_12] [int] NULL,
	[m_13] [int] NULL,
	[m_14] [int] NULL,
	[m_15] [int] NULL,
	[m_16] [int] NULL,
	[m_17] [int] NULL,
	[m_18] [int] NULL,
	[m_19] [int] NULL,
	[m_20] [int] NULL,
	[m_channel] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_ITEM_SEND_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_ITEM_SEND_TBL](
	[serverindex] [char](2) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[m_nNo] [int] NULL,
	[m_szItemName] [varchar](32) NULL,
	[m_nItemNum] [int] NULL,
	[s_date] [char](14) NULL,
	[m_bItemResist] [int] NULL,
	[m_nResistAbilityOption] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_ITEM_REMOVE_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_ITEM_REMOVE_TBL](
	[serverindex] [char](2) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[m_nNo] [int] NULL,
	[m_szItemName] [varchar](32) NULL,
	[m_nItemNum] [int] NULL,
	[s_date] [char](14) NULL,
	[m_bItemResist] [int] NULL,
	[m_nResistAbilityOption] [int] NULL,
	[RandomOption] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_ITEM_EVENT_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_ITEM_EVENT_TBL](
	[m_szName] [varchar](32) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_GetszName] [varchar](32) NULL,
	[dwWorldID] [int] NULL,
	[m_dwGold] [int] NULL,
	[m_nRemainGold] [int] NULL,
	[Item_UniqueNo] [int] NULL,
	[Item_Name] [varchar](32) NULL,
	[Item_durability] [int] NULL,
	[m_nAbilityOption] [int] NULL,
	[m_GetdwGold] [int] NULL,
	[Item_count] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[m_nSlot0] [int] NULL,
	[m_nSlot1] [int] NULL,
	[m_bItemResist] [int] NULL,
	[m_nResistAbilityOption] [int] NULL,
	[m_bCharged] [int] NULL,
	[m_dwKeepTime] [int] NULL,
	[m_nRandomOptItemId] [bigint] NULL,
	[nPiercedSize] [int] NULL,
	[adwItemId0] [int] NULL,
	[adwItemId1] [int] NULL,
	[adwItemId2] [int] NULL,
	[adwItemId3] [int] NULL,
	[MaxDurability] [int] NULL,
	[adwItemId4] [int] NULL,
	[nPetKind] [int] NULL,
	[nPetLevel] [int] NULL,
	[dwPetExp] [int] NULL,
	[wPetEnergy] [int] NULL,
	[wPetLife] [int] NULL,
	[nPetAL_D] [int] NULL,
	[nPetAL_C] [int] NULL,
	[nPetAL_B] [int] NULL,
	[nPetAL_A] [int] NULL,
	[nPetAL_S] [int] NULL,
	[adwItemId5] [int] NULL,
	[adwItemId6] [int] NULL,
	[adwItemId7] [int] NULL,
	[adwItemId8] [int] NULL,
	[adwItemId9] [int] NULL,
	[nUMPiercedSize] [int] NULL,
	[adwUMItemId0] [int] NULL,
	[adwUMItemId1] [int] NULL,
	[adwUMItemId2] [int] NULL,
	[adwUMItemId3] [int] NULL,
	[adwUMItemId4] [int] NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_INS_DUNGEON_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_INS_DUNGEON_TBL](
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_DungeonID] [char](7) NOT NULL,
	[m_WorldID] [int] NOT NULL,
	[m_channel] [int] NULL,
	[m_Type] [int] NULL,
	[m_State] [char](1) NULL,
	[m_Date] [datetime] NULL,
 CONSTRAINT [PK_LOG_INS_DUNGEON_TBL] PRIMARY KEY NONCLUSTERED 
(
	[SEQ] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_HONOR_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_HONOR_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NULL,
	[nHonor] [int] NULL,
	[LogDt] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_GUILD_WAR_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_GUILD_WAR_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[f_idGuild] [char](7) NULL,
	[m_idWar] [int] NULL,
	[m_nCurExp] [int] NULL,
	[m_nGetExp] [int] NULL,
	[m_nCurPenya] [int] NULL,
	[m_nGetPenya] [int] NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[e_date] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_GUILD_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_GUILD_TBL](
	[m_idGuild] [char](6) NOT NULL,
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[Do_m_idPlayer] [char](7) NULL,
	[State] [char](1) NULL,
	[s_date] [char](14) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_UNIQUE_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_UNIQUE_TBL](
	[m_idPlayer] [char](7) NULL,
	[serverindex] [char](2) NOT NULL,
	[dwWorldID] [int] NULL,
	[m_vPos_x] [real] NULL,
	[m_vPos_y] [real] NULL,
	[m_vPos_z] [real] NULL,
	[Item_Name] [varchar](32) NULL,
	[Item_AddLv] [int] NULL,
	[s_date] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOG_SVRDOWN_TBL]    Script Date: 04/03/2010 12:45:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOG_SVRDOWN_TBL](
	[serverindex] [char](2) NOT NULL,
	[Start_Time] [char](14) NULL,
	[End_Time] [char](14) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_Log_Ins_Dungeon_Insert]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.08.10
3. ???? ? : usp_Log_Ins_Dungeon_Insert
4. ???? ?? : ???? ?? ?? ??
5. ????
	@serverindex char(2),		: ?????
	@m_DungeonID char(7),		: ???? ?? ?? ID
	@m_WorldID int,				: ?? ID
	@m_channel int, 			: ? ? ??
	@m_Type int, 				: ?? ??
	@m_State char(1)			: ?? ??? ( ??, ??)
6. ??? 						: ??
7. ?? ??
    2009. 08.10 / ??? / ?? ??
8. ?? ?? ??
    EXEC usp_Log_Ins_Dungeon_Insert '01', 'TEST_01', 0000, 01, 1111, 'Y'
9. ?? ? ident ? ???
	select * from LOG_INS_DUNGEON_TBL
	delete LOG_INS_DUNGEON_TBL
	DBCC checkident(LOG_INS_DUNGEON_TBL,reseed, 0)
============================================================*/


CREATE         proc [dbo].[usp_Log_Ins_Dungeon_Insert]
@serverindex char(2),
@m_DungeonID char(7),
@m_WorldID int,
@m_channel int,
@m_Type int,
@m_State char(1)

AS
set nocount on


declare @q1 nvarchar(4000), @q2 nvarchar(4000)

set @q1 = '
			INSERT INTO LOGGING_[&serverindex&]_DBF.dbo.LOG_INS_DUNGEON_TBL(serverindex, m_DungeonID, m_WorldID, m_channel, m_Type, m_State)
			VALUES(@serverindex, @m_DungeonID, @m_WorldID, @m_channel, @m_Type, @m_State)'
set @q2 = replace(@q1, '[&serverindex&]', @serverindex)
exec sp_executesql @q2, N'@serverindex char(2), @m_DungeonID char(7), @m_WorldID int, @m_channel int, @m_Type int, @m_State char(1)', @serverindex = @serverindex, @m_DungeonID = @m_DungeonID, @m_WorldID = @m_WorldID, @m_channel = @m_channel, @m_Type = @m_Type, @m_State = @m_State

/*
			INSERT INTO LOG_INS_DUNGEON_TBL(serverindex, m_DungeonID, m_WorldID, m_channel, m_Type, m_State)
			VALUES(@serverindex, @m_DungeonID, @m_WorldID, @m_channel, @m_Type, @m_State)
*/
GO
/****** Object:  StoredProcedure [dbo].[usp_ElectionStat]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_ElectionStat]
@serverindex char(2)
as
set nocount on

declare @q1 nvarchar(4000), @q2 nvarchar(4000)

set @q1 = '
delete CHARACTER_[&serverindex&]_DBF.dbo.tblElection
where s_week = cast(datepart(yy, getdate()) as varchar(10)) + right(''00'' + cast(datepart(ww, getdate()) as varchar(30)), 2)'
set @q2 = replace(@q1, '[&serverindex&]', @serverindex)
exec sp_executesql @q2

set @q1 = '
insert into CHARACTER_[&serverindex&]_DBF.dbo.tblElection (s_week, chrcount)
select cast(datepart(yy, getdate()) as varchar(10)) + right(''00'' + cast(datepart(ww, getdate()) as varchar(30)), 2), count(distinct m_idPlayer)
from LOGGING_[&serverindex&]_DBF.dbo.LOG_LOGIN_TBL
where Start_Time >= convert(varchar(20), dateadd(m, -1, getdate()), 112) and CharLevel >= 60'
set @q2 = replace(@q1, '[&serverindex&]', @serverindex)
exec sp_executesql @q2
GO
/****** Object:  StoredProcedure [dbo].[uspTransferLoginLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROCEDURE [dbo].[uspTransferLoginLog]
		@pserverindex		char(2),
		@debug				bit=0
AS
SET NOCOUNT ON


	IF @pserverindex<>SUBSTRING(DB_NAME(), CHARINDEX('_', DB_NAME())+1, 2) BEGIN
		RAISERROR('Wrong Database.', 16, 10)
		RETURN
	END
	
	DECLARE		@os_date CHAR(14),
				@preDate datetime

	SELECT @preDate = DATEADD(mi,-5,GETDATE())

	SELECT @os_date = CONVERT(CHAR(8),@preDate,112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,@preDate)),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,@preDate)),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,@preDate)),2)


	/* LOG_LOGIN_TBL *********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_LOGIN_TBL
		(
			m_idPlayer,serverindex,dwWorldID,Start_Time,End_Time,TotalPlayTime,m_dwGold,remoteIP,account
		)
	SELECT
			m_idPlayer,serverindex,dwWorldID,Start_Time,End_Time,TotalPlayTime,m_dwGold,remoteIP,account
	FROM LOG_LOGIN_TBL,
				(SELECT max_date = CASE WHEN max(End_Time)  IS NULL THEN ''00000000000000'' ELSE max(End_Time) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_LOGIN_TBL  
					WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE End_Time > x.max_date
		AND End_Time <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_LOGIN_TBL WHERE End_Time <= ''' + @os_date + '''')


SET NOCOUNT OFF
RETURN
GO
/****** Object:  StoredProcedure [dbo].[uspTransferLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  proc [dbo].[uspTransferLog]
		@pserverindex		char(2),
		@debug				bit=0
AS
SET NOCOUNT ON

	IF @pserverindex<>SUBSTRING(DB_NAME(), CHARINDEX('_', DB_NAME())+1, 2) BEGIN
		RAISERROR('Wrong Database.', 16, 10)
		RETURN
	END
	
	DECLARE @os_date CHAR(14),@preDate datetime
	
	SELECT @preDate = DATEADD(mi,-5,GETDATE())
	
	SELECT @os_date = CONVERT(CHAR(8),@preDate,112) 
									  + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,@preDate)),2) 
									  + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,@preDate)),2) 
									  + RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,@preDate)),2)
	
	
	/* LOG_DEATH_TBL*********************************************************************************/
	
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_DEATH_TBL 
		(
			m_idPlayer,serverindex,dwWorldID,killed_m_szName,m_vPos_x,m_vPos_y,m_vPos_z,
			m_nLevel,attackPower,max_HP,s_date
		)
	SELECT 
			m_idPlayer,serverindex,dwWorldID,killed_m_szName,m_vPos_x,m_vPos_y,m_vPos_z,
			m_nLevel,attackPower,max_HP,s_date
	   FROM LOG_DEATH_TBL,
				 (SELECT max_date  = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
				     FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_DEATH_TBL  
	 			  WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_DEATH_TBL WHERE s_date <= ''' + @os_date + '''')
	
	/* LOG_LOGIN_TBL*********************************************************************************/
	/*
	EXEC('
	INSERT CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_LOGIN_TBL
		(
			m_idPlayer,serverindex,dwWorldID,Start_Time,End_Time,TotalPlayTime,m_dwGold,remoteIP
		)
	SELECT
			m_idPlayer,serverindex,dwWorldID,Start_Time,End_Time,TotalPlayTime,m_dwGold,remoteIP 
	   FROM LOG_LOGIN_TBL,
				 (SELECT max_date = CASE WHEN max(End_Time)  IS NULL THEN ''00000000000000'' ELSE max(End_Time) END
					  FROM CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_LOGIN_TBL  
					WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE End_Time > x.max_date
	      AND End_Time <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_LOGIN_TBL WHERE End_Time <= ''' + @os_date + '''')
	*/
	
	
	/* LOG_QUEST_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_QUEST_TBL 
		(
			m_idPlayer,serverindex,Quest_Index,State,Start_Time,End_Time
		)
	SELECT
			m_idPlayer,serverindex,Quest_Index,State,Start_Time,End_Time
	   FROM LOG_QUEST_TBL,
				 (SELECT max_date = CASE WHEN max(End_Time)  IS NULL THEN ''00000000000000'' ELSE max(End_Time) END
	  				FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_QUEST_TBL  
				 WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE End_Time > x.max_date
	      AND End_Time <= ''' + @os_date +  '''
	IF @@ROWCOUNT > 0
	DELETE LOG_QUEST_TBL WHERE End_Time <= ''' + @os_date + '''')
	
	/* LOG_SVRDOWN_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_SVRDOWN_TBL 
		(
			serverindex,Start_Time,End_Time
		)
	SELECT
			serverindex,Start_Time,End_Time
	   FROM LOG_SVRDOWN_TBL,
				 (SELECT max_date = CASE WHEN max(End_Time)  IS NULL THEN ''00000000000000'' ELSE max(End_Time) END
				     FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_SVRDOWN_TBL 
				  WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE End_Time > x.max_date
	      AND End_Time <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_SVRDOWN_TBL WHERE End_Time <= ''' + @os_date + '''')
	
	/* LOG_UNIQUE_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_UNIQUE_TBL 
		(
			m_idPlayer,serverindex,dwWorldID,m_vPos_x,m_vPos_y,m_vPos_z,Item_Name,Item_AddLv,s_date
		)	
	SELECT
			m_idPlayer,serverindex,dwWorldID,m_vPos_x,m_vPos_y,m_vPos_z,Item_Name,Item_AddLv,s_date
	   FROM LOG_UNIQUE_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
	  				FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_UNIQUE_TBL  
				 WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_UNIQUE_TBL WHERE s_date <= ''' + @os_date + '''')
	
	/* LOG_USER_CNT_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_USER_CNT_TBL 
		(
			serverindex,s_date,number,m_01,m_02,m_03,m_04,m_05,m_06,m_07,m_08,m_09,m_10,
			m_11,m_12,m_13,m_14,m_15,m_16,m_17,m_18,m_19,m_20
		)
	SELECT
			serverindex,s_date,number,m_01,m_02,m_03,m_04,m_05,m_06,m_07,m_08,m_09,m_10,
			m_11,m_12,m_13,m_14,m_15,m_16,m_17,m_18,m_19,m_20
	   FROM LOG_USER_CNT_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
	 				FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_USER_CNT_TBL  
				 WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date +  '''
	IF @@ROWCOUNT > 0
	DELETE LOG_USER_CNT_TBL WHERE s_date <= ''' + @os_date + '''')
	
	/* LOG_LEVELUP_TBL*********************************************************************************/
	/*	EXEC('
	INSERT CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_LEVELUP_TBL
		(
			m_idPlayer,serverindex,m_nExp1,m_nLevel,m_nJob,m_nJobLv,m_nFlightLv,
			m_nStr,m_nDex,m_nInt,m_nSta,	m_nRemainGP,m_nRemainLP,m_dwGold,TotalPlayTime,State,s_date
		)
	SELECT
			m_idPlayer,serverindex,m_nExp1,m_nLevel,m_nJob,m_nJobLv,m_nFlightLv,
			m_nStr,m_nDex,m_nInt,m_nSta,	m_nRemainGP,m_nRemainLP,m_dwGold,TotalPlayTime,State,s_date
	   FROM LOG_LEVELUP_TBL,
				(SELECT max_date = CASE WHEN max(s_date) IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					FROM CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_LEVELUP_TBL  
				 WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_LEVELUP_TBL WHERE s_date  <= ''' + @os_date + '''')
	*/
	/* LOG_GAMEMASTER_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_GAMEMASTER_TBL 
		(
			serverindex,m_idPlayer,m_szWords,s_date,m_idGuild
		)
	SELECT 
			serverindex,m_idPlayer,m_szWords,s_date,m_idGuild
	   FROM LOG_GAMEMASTER_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
				     FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_GAMEMASTER_TBL  
				 WHERE serverindex = ''' + @pserverindex + ''' ) x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_GAMEMASTER_TBL WHERE s_date  <= ''' + @os_date + '''')
	
	
	/* LOG_ITEM_SEND_TBL*********************************************************************************/
	/*
	EXEC('
	INSERT CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_SEND_TBL 
		(
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
		)
	SELECT 
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
	   FROM LOG_ITEM_SEND_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
	  				FROM CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_SEND_TBL 
				 WHERE serverindex = ''' + @pserverindex + ''' ) x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_SEND_TBL WHERE s_date <= ''' + @os_date + '''')
	
	
	EXEC('
	INSERT CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_REMOVE_TBL 
		(
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
		)
	SELECT
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
	   FROM LOG_ITEM_REMOVE_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
	 				FROM CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_REMOVE_TBL  
				 WHERE serverindex = ''' + @pserverindex + ''' ) x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_REMOVE_TBL WHERE s_date  <= ''' + @os_date + '''')
	
	EXEC('
	INSERT CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_TBL 
		(
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
	       m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3
		)
	SELECT 
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
	       m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3
	   FROM LOG_ITEM_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					  FROM CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_TBL   
				  WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_TBL WHERE s_date <= ''' + @os_date + '''')
	
	EXEC('
	INSERT CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_EVENT_TBL 
		(
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
	       m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3
		)
	SELECT 
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
	       m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3
	   FROM LOG_ITEM_EVENT_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					  FROM CRM'+@pserverindex+'.LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_EVENT_TBL  
					WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_EVENT_TBL WHERE s_date  <= ''' + @os_date + '''')
	*/

	/* LOG_SKILL_FREQUENCY_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_SKILL_FREQUENCY_TBL 	
		(	
			m_nid,m_nFrequency,s_date
		)
	SELECT
			m_nid,m_nFrequency,s_date
	   FROM LOG_SKILL_FREQUENCY_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
	  				FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_SKILL_FREQUENCY_TBL 
			 --  WHERE serverindex = ''' + @pserverindex + '''
				  ) x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date +''' 
	IF @@ROWCOUNT > 0
	DELETE LOG_SKILL_FREQUENCY_TBL WHERE s_date <= ''' + @os_date + '''')
	
	/* LOG_RESPAWN_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_RESPAWN_TBL 
		(
			m_nid,m_nFrequency,s_date
		)
	SELECT
			m_nid,m_nFrequency,s_date
	   FROM LOG_RESPAWN_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					  FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_RESPAWN_TBL 
				-- WHERE serverindex = ''' + @pserverindex + '''
				  ) x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date +''' 
	IF @@ROWCOUNT > 0
	DELETE LOG_RESPAWN_TBL WHERE s_date  <= ''' + @os_date + '''')
	
	/* LOG_PK_PVP_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_PK_PVP_TBL 
		(
			serverindex,m_idPlayer,m_nLevel,m_vPos_x,m_vPos_z,killed_m_idPlayer,killed_m_nLevel,m_GetPoint,
			m_nSlaughter,m_nFame,killed_m_nSlaughter,killed_m_nFame,m_KillNum,State,s_date
		)
	SELECT
			serverindex,m_idPlayer,m_nLevel,m_vPos_x,m_vPos_z,killed_m_idPlayer,killed_m_nLevel,m_GetPoint,
			m_nSlaughter,m_nFame,killed_m_nSlaughter,killed_m_nFame,m_KillNum,State,s_date
	   FROM LOG_PK_PVP_TBL ,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					  FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_PK_PVP_TBL  
					WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date +''' 
	IF @@ROWCOUNT > 0
	DELETE LOG_PK_PVP_TBL WHERE s_date <= ''' + @os_date + '''')
	
	
	/* LOG_GUILD_BANK_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_BANK_TBL
		(
			m_idGuild,m_idPlayer,serverindex,m_nGuildGold,m_GuildBank,m_Item,m_nAbilityOption,Item_count,Item_UniqueNo,State,s_date
		)
	SELECT 
			m_idGuild,m_idPlayer,serverindex,m_nGuildGold,m_GuildBank,m_Item,m_nAbilityOption,Item_count,Item_UniqueNo,State,s_date
	  FROM LOG_GUILD_BANK_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
				   FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_BANK_TBL  
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  s_date > x.max_date
	      AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_GUILD_BANK_TBL WHERE s_date  <= ''' + @os_date + '''')
	
	/* LOG_GUILD_DISPERSION_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_DISPERSION_TBL
		(
			m_idGuild,m_idPlayer,serverindex,State,s_date
		)
	SELECT 
			m_idGuild,m_idPlayer,serverindex,State,s_date
	  FROM LOG_GUILD_DISPERSION_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
				     FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_DISPERSION_TBL  
				  WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  s_date > x.max_date
	      AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_GUILD_DISPERSION_TBL WHERE s_date <= ''' + @os_date + '''')
	
	/* LOG_GUILD_SERVICE_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_SERVICE_TBL
		(
			m_idGuild,m_idPlayer,serverindex,m_nLevel,m_GuildLv,GuildPoint,Gold,State,s_date
		)
	SELECT 
			m_idGuild,m_idPlayer,serverindex,m_nLevel,m_GuildLv,GuildPoint,Gold,State,s_date
	  FROM LOG_GUILD_SERVICE_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
				    FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_SERVICE_TBL  
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  s_date > x.max_date
	      AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_GUILD_SERVICE_TBL WHERE s_date  <= ''' + @os_date + '''')
	
	
	/* LOG_GUILD_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_TBL
		(
			m_idGuild,m_idPlayer,serverindex,Do_m_idPlayer,State,s_date
		)
	SELECT 
			m_idGuild,m_idPlayer,serverindex,Do_m_idPlayer,State,s_date
	  FROM LOG_GUILD_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
				    FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_TBL  
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  s_date > x.max_date
	      AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_GUILD_TBL WHERE s_date  <= ''' + @os_date + '''')
	
	/* LOG_GUILD_WAR_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_WAR_TBL
		(
			m_idGuild,serverindex,f_idGuild,m_idWar,m_nCurExp,m_nGetExp,m_nCurPenya,m_nGetPenya,State,s_date,e_date
		)
	SELECT 
			m_idGuild,serverindex,f_idGuild,m_idWar,m_nCurExp,m_nGetExp,m_nCurPenya,m_nGetPenya,State,s_date,e_date
	  FROM LOG_GUILD_WAR_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
				    FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_GUILD_WAR_TBL  
				WHERE serverindex = ''' + @pserverindex + ''') x
	
	WHERE  s_date > x.max_date
	      AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_GUILD_WAR_TBL WHERE s_date <= ''' + @os_date + '''')
	
	/* LOG_BILLING_ITEM_TBL*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_BILLING_ITEM_TBL 
		(
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
	       m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2, adwItemId3, adwItemId4, MaxDurability
		,nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
		)
	SELECT 
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
	       m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3, adwItemId4, MaxDurability
		,nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
	   FROM LOG_BILLING_ITEM_TBL,
				 (SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					  FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_BILLING_ITEM_TBL   
				   WHERE serverindex = ''' + @pserverindex + ''') x
	 WHERE s_date > x.max_date
	      AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_BILLING_ITEM_TBL WHERE s_date <= ''' + @os_date + '''')
	
	/* tblChangeNameHistoryLog*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.tblChangeNameHistoryLog
		(
			serverindex, idPlayer, OldCharName, NewCharName, ChangeDt
		)
	SELECT 
			serverindex, idPlayer, OldCharName, NewCharName, ChangeDt
	FROM tblChangeNameHistoryLog,
				(SELECT max_date = CASE WHEN max(ChangeDt)  IS NULL THEN ''1900-01-01'' ELSE max(ChangeDt) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.tblChangeNameHistoryLog  
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  ChangeDt > x.max_date
		AND ChangeDt <= ''' + @preDate +'''
	IF @@ROWCOUNT > 0
	DELETE tblChangeNameHistoryLog WHERE ChangeDt <= ''' + @preDate + '''')

	
	/* tblChangeNameLog*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.tblChangeNameLog
		(
			ChangeID, serverindex, StartDt, EndDt, idPlayer, CharName
		)
	SELECT 
			ChangeID, serverindex, StartDt, EndDt, idPlayer, CharName
	FROM tblChangeNameLog,
				(SELECT max_date = CASE WHEN max(StartDt)  IS NULL THEN ''1900-01-01'' ELSE max(StartDt) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.tblChangeNameLog  
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  StartDt > x.max_date
		AND StartDt <= ''' + @preDate +'''
	IF @@ROWCOUNT > 0
	DELETE tblChangeNameLog WHERE StartDt <= ''' + @preDate + '''')
	
	/* tblLogExpBox*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.tblLogExpBox
		(
			serverindex, idPlayer, objid, iExp, State, s_date
		)
	SELECT 
			serverindex, idPlayer, objid, iExp, State, s_date
	FROM tblLogExpBox, 
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''1900-01-01'' ELSE max(s_date) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.tblLogExpBox
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  s_date > x.max_date
		AND s_date <= ''' + @preDate +'''
	IF @@ROWCOUNT > 0
	DELETE tblLogExpBox WHERE s_date <= ''' + @preDate + '''')

	/* tblQuestLog*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.tblQuestLog
		(
			serverindex, idPlayer, QuestIndex, State, LogDt, Comment
		)
	SELECT 
			serverindex, idPlayer, QuestIndex, State, LogDt, Comment
	FROM tblQuestLog, 
				(SELECT max_date = CASE WHEN max(LogDt)  IS NULL THEN ''1900-01-01'' ELSE max(LogDt) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.tblQuestLog
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  LogDt > x.max_date
		AND LogDt <= ''' + @preDate +'''
	IF @@ROWCOUNT > 0
	DELETE tblQuestLog WHERE LogDt <= ''' + @preDate + '''')
	/* tblPetLog*********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.tblPetLog
		(
			serverindex, idPlayer, iSerial, nType, dwData, nKind, nLevel, wLife, wEnergy, dwExp, nAvailParam1, nAvailParam2, nAvailParam3, nAvailParam4, nAvailParam5, LogDt
		)
	SELECT 
			serverindex, idPlayer, iSerial, nType, dwData, nKind, nLevel, wLife, wEnergy, dwExp, nAvailParam1, nAvailParam2, nAvailParam3, nAvailParam4, nAvailParam5, LogDt
	FROM tblPetLog, 
				(SELECT max_date = CASE WHEN max(LogDt)  IS NULL THEN ''1900-01-01'' ELSE max(LogDt) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.tblPetLog
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE  LogDt > x.max_date
		AND LogDt <= ''' + @preDate +'''
	IF @@ROWCOUNT > 0
	DELETE tblPetLog WHERE LogDt <= ''' + @preDate + '''')

SET NOCOUNT OFF
RETURN
GO
/****** Object:  StoredProcedure [dbo].[uspTransferLevelupLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROCEDURE [dbo].[uspTransferLevelupLog]
@pserverindex	char(2),
@debug		bit=0
AS
SET NOCOUNT ON


	IF @pserverindex<>SUBSTRING(DB_NAME(), CHARINDEX('_', DB_NAME())+1, 2) BEGIN
		RAISERROR('Wrong Database.', 16, 10)
		RETURN
	END
	

	DECLARE @os_date CHAR(14),@preDate datetime

	SELECT @preDate = DATEADD(mi,-5,GETDATE())

	SELECT @os_date = CONVERT(CHAR(8),@preDate,112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,@preDate)),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,@preDate)),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,@preDate)),2)


	/* LOG_LEVELUP_TBL  *********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_LEVELUP_TBL
		(
			m_idPlayer,serverindex,m_nExp1,m_nLevel,m_nJob,m_nJobLv,m_nFlightLv,
			m_nStr,m_nDex,m_nInt,m_nSta,	m_nRemainGP,m_nRemainLP,m_dwGold,TotalPlayTime,State,s_date
		)
	SELECT
			m_idPlayer,serverindex,m_nExp1,m_nLevel,m_nJob,m_nJobLv,m_nFlightLv,
			m_nStr,m_nDex,m_nInt,m_nSta,	m_nRemainGP,m_nRemainLP,m_dwGold,TotalPlayTime,State,s_date
	FROM LOG_LEVELUP_TBL,
				(SELECT max_date = CASE WHEN max(s_date) IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_LEVELUP_TBL  
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE s_date > x.max_date
		AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_LEVELUP_TBL WHERE s_date  <= ''' + @os_date + '''')

SET NOCOUNT OFF
RETURN
GO
/****** Object:  StoredProcedure [dbo].[uspTransferItemLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE proc [dbo].[uspTransferItemLog]
@pserverindex	char(2),
@debug		bit=0

AS

SET NOCOUNT ON

	IF @pserverindex<>SUBSTRING(DB_NAME(), CHARINDEX('_', DB_NAME())+1, 2) BEGIN
		RAISERROR('Wrong Database.', 16, 10)
		RETURN
	END
	
	DECLARE @os_date CHAR(14),@preDate datetime

	SELECT @preDate = DATEADD(mi,-5,GETDATE())

	SELECT @os_date = CONVERT(CHAR(8),@preDate,112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,@preDate)),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,@preDate)),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,@preDate)),2)

	/* LOG_ITEM_SEND_TBL *********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_SEND_TBL 
		(
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
		)
	SELECT 
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
	FROM LOG_ITEM_SEND_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
  					FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_SEND_TBL 
				WHERE serverindex = ''' + @pserverindex + ''' ) x
	WHERE s_date > x.max_date
		AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_SEND_TBL WHERE s_date <= ''' + @os_date + '''')


	/* LOG_ITEM_REMOVE_TBL *********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_REMOVE_TBL 
		(
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
		)
	SELECT
			serverindex,m_idPlayer,m_nNo,m_szItemName,m_nItemNum,s_date,m_bItemResist,m_nResistAbilityOption
	FROM LOG_ITEM_REMOVE_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
 					FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_REMOVE_TBL  
				WHERE serverindex = ''' + @pserverindex + ''' ) x
	WHERE s_date > x.max_date
		AND s_date <= ''' + @os_date + '''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_REMOVE_TBL WHERE s_date  <= ''' + @os_date + '''')

	/* LOG_ITEM_TBL *********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_TBL 
		(
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
		m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3, adwItemId4, MaxDurability
		,nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
		)
	SELECT 
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
		m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3, adwItemId4, MaxDurability
		,nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
	FROM LOG_ITEM_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_TBL   
				WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE s_date > x.max_date
		AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_TBL WHERE s_date <= ''' + @os_date + '''')

	/* LOG_ITEM_EVENT_TBL *********************************************************************************/
	EXEC('
	INSERT LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_EVENT_TBL 
		(
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
		m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3, adwItemId4, MaxDurability
		,nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
		)
	SELECT 
			m_szName,serverindex,m_GetszName,dwWorldID,m_dwGold,m_nRemainGold,Item_UniqueNo,
			Item_Name,Item_durability,m_nAbilityOption,m_GetdwGold,Item_count,State,s_date,
			m_nSlot0,m_nSlot1,m_bItemResist ,	m_nResistAbilityOption, 
		m_bCharged,m_dwKeepTime,m_nRandomOptItemId,nPiercedSize,adwItemId0,adwItemId1,adwItemId2,adwItemId3, adwItemId4, MaxDurability
		,nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
	FROM LOG_ITEM_EVENT_TBL,
				(SELECT max_date = CASE WHEN max(s_date)  IS NULL THEN ''00000000000000'' ELSE max(s_date) END
					FROM LOG_' + @pserverindex + '_DBF.dbo.LOG_ITEM_EVENT_TBL  
					WHERE serverindex = ''' + @pserverindex + ''') x
	WHERE s_date > x.max_date
		AND s_date <= ''' + @os_date +'''
	IF @@ROWCOUNT > 0
	DELETE LOG_ITEM_EVENT_TBL WHERE s_date  <= ''' + @os_date + '''')

SET NOCOUNT OFF
RETURN
GO
/****** Object:  StoredProcedure [dbo].[uspTransferTradeLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspTransferTradeLog]
		@pserverindex		char(2),
		@debug				bit=0
AS
SET NOCOUNT ON

	IF @pserverindex<>SUBSTRING(DB_NAME(), CHARINDEX('_', DB_NAME())+1, 2) BEGIN
		RAISERROR('Wrong Database.', 16, 10)
		RETURN
	END
	
	DECLARE @TodayMidnight char(10)
	DECLARE @sql	nvarchar(4000)
	
	SET @TodayMidnight=CONVERT(char(10), GETDATE(), 102)

	--SELECT TradeID INTO #TEMP_TradeID FROM tblTradeLog WHERE TradeDt < @TodayMidnight

	SET @sql =
		'	
		INSERT INTO LOG_' + @pserverindex + '_DBF.dbo.tblTradeLog
			SELECT a.* FROM dbo.tblTradeLog a WHERE a.TradeDt<@date
		'
	
	EXEC sp_executesql @sql, N'@date char(10)', @TodayMidnight

	SET @sql=
		'
		INSERT INTO LOG_' + @pserverindex + '_DBF.dbo.tblTradeDetailLog
			SELECT	a.* 
			FROM	dbo.tblTradeDetailLog a 
					INNER JOIN dbo.tblTradeLog b 
					ON (a.TradeID=b.TradeID) 
			WHERE b.TradeDt<@date
		'
	EXEC sp_executesql @sql, N'@date char(10)', @TodayMidnight


	SET @sql=
		'	
		INSERT INTO LOG_' + @pserverindex + '_DBF.dbo.tblTradeItemLog
			SELECT	a.* 
			FROM	dbo.tblTradeItemLog a 
					INNER JOIN dbo.tblTradeLog b 
						ON (a.TradeID=b.TradeID) 
			WHERE b.TradeDt<@date
		'
	EXEC sp_executesql @sql, N'@date char(10)', @TodayMidnight
		
	DELETE dbo.tblTradeItemLog FROM dbo.tblTradeItemLog a INNER JOIN dbo.tblTradeLog b ON (a.TradeID=b.TradeID) WHERE b.TradeDt<@TodayMidnight
	DELETE dbo.tblTradeDetailLog FROM dbo.tblTradeDetailLog a INNER JOIN dbo.tblTradeLog b ON (a.TradeID=b.TradeID) WHERE b.TradeDt<@TodayMidnight
	DELETE dbo.tblTradeLog FROM dbo.tblTradeLog WHERE TradeDt<@TodayMidnight

	RETURN 
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspPetLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspPetLog]
	@serverindex	char(2),
	@idPlayer	char(7),
	@iSerial		bigint,
	@nType		int,
	@dwData	int,
	@nKind		int,
	@nLevel		int,
	@wLife		int,
	@wEnergy	int,
	@dwExp		int,
	@nAvailParam1	int,
	@nAvailParam2	int,
	@nAvailParam3	int,
	@nAvailParam4	int,
	@nAvailParam5	int

AS
SET NOCOUNT ON
	
	INSERT INTO tblPetLog(serverindex, idPlayer, iSerial, nType, dwData, nKind, nLevel, wLife, wEnergy, dwExp, nAvailParam1, nAvailParam2, nAvailParam3, nAvailParam4, nAvailParam5, LogDt)
							    VALUES (@serverindex, @idPlayer, @iSerial, @nType, @dwData, @nKind, @nLevel, @wLife, @wEnergy, @dwExp, @nAvailParam1, @nAvailParam2, @nAvailParam3, @nAvailParam4, @nAvailParam5, getdate())

	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoggingUsingSkillPoint]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspLoggingUsingSkillPoint]
	@pserverindex	char(2),
	@pPlayerID		char(7),
	@pSkillID		int,
	@pSkillLevel	int,
	@pSkillPoint		int,
	@pHoldingSkillPoint	int,
	@pTotalSkillPoint	int,
	@pSkillExp		bigint,
	@pUsingBy		int
AS
SET NOCOUNT ON

	INSERT INTO tblSkillPointLog(serverindex, PlayerID, SkillID, SkillLevel, SkillPoint, HoldingSkillPoint, TotalSkillPoint, SkillExp, UsingBy, ActionDt)
		VALUES (@pserverindex, @pPlayerID, @pSkillID, @pSkillLevel, @pSkillPoint, @pHoldingSkillPoint, @pTotalSkillPoint, @pSkillExp, @pUsingBy, getdate())
	

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoggingTrade]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE   Procedure [dbo].[uspLoggingTrade]
@pFlag		int,
@pTradeID	int,
@pserverindex	char(2),
@pWorldID	int=0,
@pidPlayer	char(7)='0000000',
@pTradeGold	int=0,
@pPlayerIP	varchar(15)='',
@pLevel		int=0,
@pJob		int=0,
@pItemIndex	int=0,
@pItemSerialNum	int=0,
@pItemCnt	int=0,
@pAbilityOpt	int=0,
@pItemResist	int=0,
@pResistAbilityOpt	int=0,
@pRandomOpt	bigint=0
AS
SET NOCOUNT ON

	IF @pFlag=0 BEGIN
		INSERT INTO tblTradeLog(TradeID, serverindex, WorldID, TradeDt)
				VALUES (@pTradeID, @pserverindex, @pWorldID, getdate())
				
		IF @@ROWCOUNT=0 BEGIN
			SELECT 9001
			RETURN
		END
	END
	ELSE IF @pFlag=1 BEGIN
		INSERT INTO tblTradeDetailLog(TradeID, serverindex, idPlayer, Job, Level, TradeGold, PlayerIP)
				VALUES (@pTradeID, @pserverindex, @pidPlayer, @pJob, @pLevel, @pTradeGold, @pPlayerIP)
				
		IF @@ROWCOUNT=0 BEGIN
			SELECT 9002
			RETURN
		END
	END
	ELSE IF @pFlag=2 BEGIN
		INSERT INTO tblTradeItemLog(TradeID, serverindex, idPlayer, ItemIndex, ItemSerialNum, ItemCnt, AbilityOpt, ItemResist, ResistAbilityOpt, RandomOpt)
				VALUES (@pTradeID, @pserverindex, @pidPlayer, @pItemIndex, @pItemSerialNum, @pItemCnt, @pAbilityOpt, @pItemResist, @pResistAbilityOpt, @pRandomOpt)

		IF @@ROWCOUNT=0 BEGIN
			SELECT 9003
			RETURN
		END
	END
	ELSE BEGIN
		SELECT 9004
		RETURN
	END
	
	SELECT 1
	RETURN 

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoggingQuest]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspLoggingQuest]
		@pserverindex	char(2),
		@pidPlayer		char(7),
		@pQuestIndex	int,
		@pState			varchar(3),
		@pComment		varchar(100)=''
AS
SET NOCOUNT ON

	INSERT INTO tblQuestLog(serverindex, idPlayer, QuestIndex, State, LogDt, Comment)
			VALUES (@pserverindex, @pidPlayer, @pQuestIndex, @pState, getdate(), @pComment)
			
	IF @@ROWCOUNT=0 BEGIN
		SELECT 9001
		RETURN
	END
	
	SELECt 1
	RETURN
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoggingLogin]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    Procedure [dbo].[uspLoggingLogin]
		@pPlayerID		char(7),
		@pserverindex	char(2),
		@pAccount		varchar(32),
		@pWorldID		int,
		@pGold			bigint,
		@pLevel			int,
		@pJob			int,
		@pStartDt		char(14),
		@pTotalPlayTime	int,
		@pRemoteIP		varchar(16),
		@i_State tinyint = 0
		
AS
SET NOCOUNT ON
	DECLARE @os_date CHAR(14)
	SELECT @os_date = CONVERT(CHAR(8),GETDATE(),112) 
										+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
										+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2) 
										+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,GETDATE())),2)


	INSERT  LOG_LOGIN_TBL 
		(
			m_idPlayer,
			serverindex,
			account,
			dwWorldID,
			m_dwGold,
			CharLevel,
			Job,
			Start_Time,
			End_Time,
			TotalPlayTime,
			remoteIP,
			State
		)
	VALUES 
		(
			@pPlayerID,
			@pserverindex,
			@pAccount,
			@pWorldID,
			@pGold,
			@pLevel,
			@pJob,
			@pStartDt,
			@os_date,
			@pTotalPlayTime,
			@pRemoteIP,
			@i_State				
		)

	RETURN



SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLoggingAcquireSkillPoint]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[uspLoggingAcquireSkillPoint]
	@pserverindex	char(2),
	@pPlayerID		char(7),
	@pSkillID		int,
	@pSkillLevel	int,
	@pSkillPoint		int,
	@pHoldingSkillPoint	int,
	@pTotalSkillPoint	int,
	@pSkillExp		bigint,
	@pUsingBy		int
AS
SET NOCOUNT ON

	INSERT INTO tblSkillPointLog(serverindex, PlayerID, SkillID, SkillLevel, SkillPoint, HoldingSkillPoint, TotalSkillPoint, SkillExp, UsingBy, ActionDt)
		VALUES (@pserverindex, @pPlayerID, 0, 0, @pSkillPoint, @pHoldingSkillPoint, @pTotalSkillPoint, @pSkillExp, @pUsingBy, getdate())
	

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspLogExpBox]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  Procedure [dbo].[uspLogExpBox]
		@pserverindex	char(2),
		@pidPlayer		char(7),
		@pobjid		bigint,
		@piExp		bigint,
		@pState	char(1)
AS
SET NOCOUNT ON
	
	INSERT INTO tblLogExpBox(serverindex, idPlayer, objid, iExp, State, s_date)
							    VALUES (@pserverindex, @pidPlayer, @pobjid, @piExp, @pState, getdate())

	IF @@ROWCOUNT=0 BEGIN
		RETURN
	END
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[uspHonorLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[uspHonorLog]
@serverindex char(2),
@idPlayer char(7),
@nHonor int
as
set nocount on

insert into LOG_HONOR_TBL(serverindex, m_idPlayer, nHonor)
select @serverindex, @idPlayer, @nHonor
GO
/****** Object:  StoredProcedure [dbo].[uspChangeNameLog]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Procedure [dbo].[uspChangeNameLog]
		@pserverindex	char(2),
		@pidPlayer		char(7),
		@pOldName		varchar(32),
		@pNewName		varchar(32)
AS
SET NOCOUNT ON
	
	DECLARE @ChangeID int
	
	INSERT INTO tblChangeNameHistoryLog(serverindex, idPlayer, OldCharName, NewCharName, ChangeDt) 
							    VALUES (@pserverindex, @pidPlayer, @pOldName, @pNewName, getdate())

	IF @@ROWCOUNT=0 BEGIN
		RETURN
	END
	
	-- FOR LINEAR EXECUTION
	SELECT @ChangeID=ChangeID FROM tblChangeNameLog  WHERE idPlayer=@pidPlayer
	
	IF @@ROWCOUNT>0 BEGIN
		UPDATE tblChangeNameLog SET EndDt=getdate() WHERE ChangeID=@ChangeID
	END
	
	INSERT INTO tblChangeNameLog(serverindex, StartDt, EndDt, idPlayer, CharName) VALUES (@pserverindex, getdate(), DEFAULT, @pidPlayer, @pNewName)
	
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_SystemError_Insert]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.12.11
3. ???? ? : usp_SystemError_Insert
4. ???? ?? : ?? ? ?? ?? ?? ?? ??
5. ????
	@m_idPlayer char(7)			: ???? ID
	@serverindex char(2)		: ???
	@account varchar(32)		: ???? ??
	@nChannel int				: ?? ??
	@chType char(1)				: ?? ??
	@szError varchar(1024)		: ?? ??
6. ??? 						: ??
7. ?? ??
    2009.12.11 / ??? / ?? ??
8. ?? ?? ??
    EXEC usp_SystemError_Insert '1452294', '75', 'igen0904', 1, 'A', 'test'
9. ?? ? ident ? ???
	select * from tblSystemErrorLog
	delete tblSystemErrorLog
	DBCC checkident(tblSystemErrorLog ,reseed, 0)
============================================================*/


create proc [dbo].[usp_SystemError_Insert]
	@m_idPlayer char(7),
	@serverindex char(2),
	@account varchar(32),
	@nChannel int,
	@chType char(1), 
	@szError varchar(1024)
as
set nocount on

/*
	declare @q1 nvarchar(4000), @q2 nvarchar(4000)

	set @q1 = '
			INSERT INTO LOGGING_[&serverindex&]_DBF.dbo.tblSystemErrorLog(m_idPlayer, serverindex, account, nChannel, chType, szError)
			select @m_idPlayer, @serverindex, @account, @nChannel, @chType, @szError'
	set @q2 = replace(@q1, '[&serverindex&]', @serverindex)

	exec sp_executesql @q2, N'@m_idPlayer char(7), @serverindex char(2), @account varchar(32), @nChannel int, @chType char(1), @szError varchar(1024)', @m_idPlayer = @m_idPlayer, @serverindex = @serverindex, @account = @account, @nChannel = @nChannel, @chType = @chType, @szError = @szError

*/

	INSERT INTO tblSystemErrorLog(m_idPlayer, serverindex, account, nChannel, chType, szError)
	select @m_idPlayer, @serverindex, @account, @nChannel, @chType, @szError

RETURN
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[usp_QuizUserLog_Insert]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.10.12
3. ???? ? : usp_QuizUserLog_Insert
4. ???? ?? : ?? ??? ?? ?? ?? Insert
5. ????
	@m_idQuizEvent	int			: ????? ??
	@m_idPlayer		char(7)		: ???? ID 
	@serverindex	char(2)		: ???
	@m_nChannel		int			: ??? ????
6. ??? 						: ??
7. ?? ??
    2009. 09.12 / ??? / ?? ??
8. ?? ?? ??
    EXEC usp_QuizUserLog_Insert '1', '0000002', '01', 2, 4
9. ?? ? ident ? ???
	select * from tblQuizUserLog
	delete tblQuizUserLog
	DBCC checkident(tblQuizUserLog ,reseed, 0)
============================================================*/


CREATE proc [dbo].[usp_QuizUserLog_Insert]
	@m_idQuizEvent int,
	@m_idPlayer char(7),
	@serverindex char(2),
	@m_nChannel int

AS
set nocount on

/*
	declare @q1 nvarchar(4000), @q2 nvarchar(4000)

	set @q1 = '
			INSERT INTO LOGGIN_&serverindex&_DBF.dbo.tblQuizUserLog(m_idQuizEvent, m_idPlayer, serverindex, m_nChannel)
				select @m_idQuizEvent, @m_idPlayer, @serverindex, @m_nChannel '
	set @q2 = replace(@q1, '&serverindex&', @serverindex)

	exec sp_executesql @q2, N' @m_idQuizEvent int, @m_idPlayer char(7), @serverindex char(2), @m_nChannel int, @m_chState char(1)', @m_idQuizEvent = @m_idQuizEvent, @m_idPlayer = @m_idPlayer, @serverindex = @serverindex, @m_nChannel = @m_nChannel, @m_chState = @m_chState

*/

	insert into tblQuizUserLog(m_idQuizEvent, m_idPlayer, serverindex, m_nChannel)
	select @m_idQuizEvent, @m_idPlayer, @serverindex, @m_nChannel


RETURN
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[usp_QuizLog_Update]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.10.09
3. ???? ? : usp_QuizLog_Update
4. ???? ?? : ?? ??? ?? ?? ?? Update
5. ????
	@serverindex	char(2)			: ???
	@idQuizEvent	int				: ????? ??
	@nChannel		int				: ??? ????
	@nWinnerCount	int				: ??? ?
	@nQuizCount		int				: ??? ? ?? ?

6. ??? 							: ??
7. ?? ??
    2009. 09.09 / ??? / ?? ??
8. ?? ?? ??
    EXEC usp_QuizLog_Insert 1, '01', 6, 1
    EXEC usp_QuizLog_Update 1, '01', 6, 500, 5
9. ?? ? ident ? ???
	select * from tblQuizLog
	delete tblQuizLog
	DBCC checkident(tblQuizLog ,reseed, 0)
============================================================*/


CREATE proc [dbo].[usp_QuizLog_Update]
	@idQuizEvent	int,
	@serverindex	char(2),
	@nChannel		int,
	@nWinnerCount	int,
	@nQuizCount		int
AS
set nocount on

/*
declare @q1 nvarchar(4000), @q2 nvarchar(4000)

set @q1 = '
	if exists (select * from LOGGIN_[&serverindex&]_DBF.dbo.tblQuizLog where serverindex = @serverindex and m_nChannel = @nChannel and m_idQuizEvent = @idQuizEvent and End_Time is NULL)
		begin
			update LOGGIN_[&serverindex&]_DBF.dbo.tblQuizLog
			set End_Time = getdate(), m_nWinnerCount = @nWinnerCount, m_nQuizCount = @nQuizCount
			where serverindex = @serverindex and m_nChannel = @nChannel and m_idQuizEvent = @idQuizEvent and End_Time is NULL
		end
	else
		begin
			update LOG_[&serverindex&]_DBF.dbo.tblQuizLog
			set End_Time = getdate(), m_nWinnerCount = @nWinnerCount, m_nQuizCount = @nQuizCount
			where serverindex = @serverindex and m_nChannel = @nChannel and m_idQuizEvent = @idQuizEvent and End_Time is NULL
		end '
set @q2 = replace(@q1, '[&serverindex&]', @serverindex)

exec sp_executesql @q2, N'@serverindex char(2), @idQuizEvent int, @nChannel int, @nWinnerCount int, @nQuizCount int', @serverindex = @serverindex, @idQuizEvent = @idQuizEvent, @nChannel = @nChannel, @nWinnerCount = @nWinnerCount, @nQuizCount = @nQuizCount
*/

	if exists (select * from tblQuizLog (nolock) where serverindex = @serverindex and m_nChannel = @nChannel and m_idQuizEvent = @idQuizEvent and End_Time is NULL)
		begin
			update tblQuizLog
			set End_Time = getdate(), m_nWinnerCount = @nWinnerCount, m_nQuizCount = @nQuizCount
			where serverindex = @serverindex and m_nChannel = @nChannel and m_idQuizEvent = @idQuizEvent and End_Time is NULL
		end

RETURN
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[usp_QuizLog_Insert]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.10.09
3. ???? ? : usp_QuizLog_Insert
4. ???? ?? : ?? ??? ?? ?? ?? Insert
5. ????
	@serverindex	char(2)				: ???
	@idQuizEvent	int				: ????? ??
	@nChannel	int				: ??? ????
	@nQuizType	int				: ????
6. ??? 						: ??
7. ?? ??
    2009. 09.09 / ??? / ?? ??
8. ?? ?? ??
    EXEC usp_QuizLog_Insert '01', '1', 1, 1
9. ?? ? ident ? ???
	select * from tblQuizLog
	delete tblQuizLog
	DBCC checkident(tblQuizLog ,reseed, 0)
============================================================*/


CREATE proc [dbo].[usp_QuizLog_Insert]
	@idQuizEvent	int,
	@serverindex	char(2),
	@nChannel	int,
	@nQuizType	int
AS
set nocount on

/*
	declare @q1 nvarchar(4000), @q2 nvarchar(4000)

	set @q1 = '
			INSERT INTO LOGGING_[&serverindex&]_DBF.dbo.tblQuizLog(m_idQuizEvent, serverindex, m_nChannel, m_nQuizType)
			select @idQuizEvent, @serverindex, @nChannel, @nQuizType'
	set @q2 = replace(@q1, '[&serverindex&]', @serverindex)

	exec sp_executesql @q2, N'@serverindex char(2), @idQuizEvent int, @nChannel int, @nQuizType int ', @serverindex = @serverindex, @idQuizEvent = @idQuizEvent, @nChannel = @nChannel, @nQuizType = @nQuizType

*/

	INSERT INTO tblQuizLog(m_idQuizEvent, serverindex, m_nChannel, m_nQuizType)
	select @idQuizEvent, @serverindex, @nChannel, @nQuizType

RETURN
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[usp_QuizID_Select]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[usp_QuizID_Select] 
	@serverindex char(2)

as 
set nocount on

	declare @m_idQuizEvent int
	
	select @m_idQuizEvent = isnull(max(m_idQuizEvent),0) from dbo.tblQuizLog (nolock)
	where serverindex = @serverindex 

	select QuizID = @m_idQuizEvent
GO
/****** Object:  StoredProcedure [dbo].[usp_QuizAnswerLog_Insert]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/*============================================================
1. ??? : ???
2. ??? : 2009.10.12
3. ???? ? : usp_QuizAnswerLog_Insert
4. ???? ?? : ?? ??? ?? ?? ?? Insert
5. ????
	@m_idQuizEvent	int					????? ??
	@m_idPlayer		char (7)			???
	@serverindex	char (2)			???? ???
	@m_nChannel		int					??? ????
	@m_nQuizNum		int					?? ??
	@m_nSelect		int					??? ??? ??? ??
	@m_nAnswer		int					??? ??

6. ??? 						: ??
7. ?? ??
    2009. 09.12 / ??? / ?? ??
8. ?? ?? ??
    EXEC usp_QuizAnswerLog_Insert '1', '0000002', '01', 1, 2, 2, 2
9. ?? ? ident ? ???
	select * from tblQuizAnswerLog
	delete tblQuizAnswerLog
	DBCC checkident(tblQuizAnswerLog ,reseed, 0)
============================================================*/


CREATE proc [dbo].[usp_QuizAnswerLog_Insert]
	@m_idQuizEvent	int,
	@m_idPlayer		char (7),
	@serverindex	char (2),
	@m_nChannel		int,
	@m_nQuizNum		int,
	@m_nSelect		int,
	@m_nAnswer		int

AS
set nocount on

/*
	declare @q1 nvarchar(4000), @q2 nvarchar(4000)

	set @q1 = '
			INSERT INTO LOG_&serverindex&_DBF.dbo.tblQuizAnswerLog(m_idQuizEvent, m_idPlayer, serverindex, m_nChannel, m_nQuizNum, m_nSelect, m_nAnswer)
			select @m_idQuizEvent, @m_idPlayer, @serverindex, @m_nChannel, @m_nQuizNum, @m_nSelect, @m_nAnswer'
	set @q2 = replace(@q1, '&serverindex&', @serverindex)

	exec sp_executesql @q2, N'@serverindex char(2), @m_idQuizEvent int, @m_idPlayer char(7), @m_nChannel int, @m_nQuizNum int, @m_nSelect int, @m_nAnswer int', @serverindex = @serverindex, @m_idQuizEvent = @m_idQuizEvent, @m_idPlayer = @m_idPlayer, @m_nChannel = @m_nChannel, @m_nQuizNum = @m_nQuizNum, @m_nSelect = @m_nSelect, @m_nAnswer = @m_nAnswer
*/


	insert into tblQuizAnswerLog(m_idQuizEvent, m_idPlayer, serverindex, m_nChannel, m_nQuizNum, m_nSelect, m_nAnswer)
	select @m_idQuizEvent, @m_idPlayer, @serverindex, @m_nChannel, @m_nQuizNum, @m_nSelect, @m_nAnswer


RETURN
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[usp_CampusPointLog_Insert]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_CampusPointLog_Insert    Script Date: 2009-12-01 ?? 3:04:25 ******/

/*============================================================
1. ??? : ???
2. ??? : 2009.11.24
3. ???? ? : usp_CampusPointLog_Insert
4. ???? ?? : ?? ???? ?? ??
5. ????
	@m_idPlayer		char(7)		: ???? ID
	@serverindex	char(2)		: ???
	@chState		char(1)		: ??? (Q: ???, P: ????)
	@nPrevPoint		int			: ?? ? ?? ???
	@nCurrPoint		int			: ?? ? ?? ???(?????)
6. ??? 						: ??
7. ?? ??
8. ?? ?? ??
    EXEC usp_CampusPointLog_Insert '0000001', '01', 'Q', 0, 10 
9. ?? ? ident ? ???
	select * from tblCampus_PointLog
	delete tblCampus_PointLog
	DBCC checkident(tblCampus_PointLog ,reseed, 0)
============================================================*/


CREATE proc [dbo].[usp_CampusPointLog_Insert]
	@m_idPlayer	char(7),
	@serverindex	char(2),
	@chState	char(1),
	@nPrevPoint	int,
	@nCurrPoint	int
AS
set nocount on

/*
	declare @q1 nvarchar(4000), @q2 nvarchar(4000)

	set @q1 = '
			INSERT INTO LOGGING_[&serverindex&]_DBF.dbo.tblCampus_PointLog(m_idPlayer, serverindex, chState, nPrevPoint, nCurrPoint)
			select @m_idPlayer, @serverindex, @chState, @nPrevPoint, @nCurrPoint'
	set @q2 = replace(@q1, '[&serverindex&]', @serverindex)

	exec sp_executesql @q2, N'@m_idPlayer char(7), @serverindex char(2), @chState char(1), @nPrevPoint int, @nCurrPoint int', @m_idPlayer = @m_idPlayer, @serverindex = @serverindex, @chState = @chState, @nPrevPoint = @nPrevPoint, @nCurrPoint = @nCurrPoint

*/

	INSERT INTO tblCampus_PointLog(m_idPlayer, serverindex, chState, nPrevPoint, nCurrPoint)
	select @m_idPlayer, @serverindex, @chState, @nPrevPoint, @nCurrPoint

RETURN
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[usp_CampusLog_Insert]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_CampusLog_Insert    Script Date: 2009-12-01 ?? 3:04:25 ******/  
  
/*============================================================  
1. ??? : ???  
2. ??? : 2009.11.24  
3. ???? ? : usp_CampusLog_Insert  
4. ???? ?? : ?? ?? ??? ?? ??  
5. ????  
 @m_idMaster  char(7)    : ?? ID  
 @serverindex char(2)    : ???  
 @idCampus  int     : ?? ID  
 @m_idPupil  char(7)    : ??? ID  
 @chState  char(1)    : ??? (T: ??, F: ??)  
6. ???       : ??  
7. ?? ??  
8. ?? ?? ??  
    EXEC usp_CampusLog_Insert '0000005', '01', 1, '0000006', 'T'   
9. ?? ? ident ? ???  
 select * from tblCampusLog  
 delete tblCampusLog  
 DBCC checkident(tblCampusLog ,reseed, 0)  
============================================================*/  
  
  
CREATE proc [dbo].[usp_CampusLog_Insert]  
 @m_idMaster  char(7),  
 @serverindex char(2),    
 @idCampus  int,   
 @m_idPupil  char(7),  
 @chState  char(1)  
AS  
set nocount on  
  
/*  
 declare @q1 nvarchar(4000), @q2 nvarchar(4000)  
  
 set @q1 = '  
   INSERT INTO LOGGING_[&serverindex&]_DBF.dbo.tblCampusLog(m_idMaster, serverindex, m_idPupil, idCampus, chState)  
   select @m_idMaster, @serverindex, @idCampus, @m_idPupil, @chState'  
 set @q2 = replace(@q1, '[&serverindex&]', @serverindex)  
  
 exec sp_executesql @q2, N'@serverindex char(2), @m_idMaster char(7), @m_idPupil char(7), @idCampus int, @chState char(1)', @serverindex = @serverindex, @m_idMaster = @m_idMaster, @idCampus = @idCampus, @m_idPupil = @m_idPupil, @chState = @chState  
  
*/  
  
 INSERT INTO tblCampusLog(m_idMaster, serverindex, idCampus, m_idPupil, chState)  
 select @m_idMaster, @serverindex, @idCampus, @m_idPupil, @chState  
  
RETURN  
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[LOG_STR]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LOG_STR]
	@iGu 								CHAR(2),
	@im_idPlayer 				CHAR(7),
	@iserverindex				CHAR(2),
	--1:LOG_LEVELUP_TBL
	@im_nExp1					BIGINT 					= 0,
	@im_nLevel					INT 							= 0,
	@im_nJob						INT 							= 0,
	@im_nJobLv					INT 							= 0,
	@im_nFlightLv				INT 							= 0,
	@im_nStr						INT 							= 0,
	@im_nDex						INT 							= 0,
	@im_nInt 						INT 							= 0,
	@im_nSta						INT 							= 0,
	@im_nRemainGP			INT 							= 0,
	@im_nRemainLP			INT 							= 0,
	@iState							CHAR(1)					= '',
	--2:LOG_DEATH_TBL
	@idwWorldID					INT 							= 0,
	@ikilled_m_szName		VARCHAR(32) 		= '',
	@im_vPos_x					REAL 						= 0,
	@im_vPos_y					REAL 						= 0,
	@im_vPos_z					REAL						= 0,
	@iattackPower				INT 							= 0,
	@imax_HP						INT 							= 0,
	--3:LOG_ITEM_TBL
	@im_GetszName			VARCHAR(32) 		= '',
	@im_dwGold					INT 							= 0,
	@im_nRemainGold		INT 							= 0,
	@iItem_UniqueNo			INT 							= 0,
	@iItem_Name					VARCHAR(32) 		= '',
	@iItem_durability			INT 							= 0,
	@iItem_count					INT 							= 0,
	--4:LOG_UNIQUE_TBL
	@iItem_AddLv 				INT 							= 0,
	--5:LOG_LOGIN_TBL
	@iStart_Time					CHAR(14) 				= '',
	@iTotalPlayTime			INT 							= 0,	
	@iremoteIP						VARCHAR(16) 		= '',
	--6:LOG_QUEST_TBL
	@iQuest_Index				INT 							= 0,
	--8:LOG_SVRDOWN_TBL
	--9:LOG_USER_CNT_TBL
	--A:LOG_PVP_TBL
	@ikilled_m_idPlayer   	CHAR(7)					=''
	--B:LOG_PK_TBL


/*******************************************************
	Gu ??
   L1 : ?? ???
   L2 : ?? ??
   L3 : ?? ???
   L4 : ?? ???
   L5 : ?? ??
   L6 : ?? ??? ??
   L7 : ?? ??? ??
   L8 : ?? ????
   L9 : ?? ????

*******************************************************/
AS
set nocount on
/***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************



	LOG ?? ????
	??? : ???
	??? : 2003.10.17 



***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************/

DECLARE @os_date CHAR(14)
  SELECT @os_date = CONVERT(CHAR(8),GETDATE(),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,GETDATE())),2)

IF @iGu = 'L1'
	BEGIN
			/*************************************************************
			
				?? ???
				@iGu = 'L1'
			
			*************************************************************/
			

			
			INSERT LOG_LEVELUP_TBL
				(
					m_idPlayer,
					serverindex,
					m_nExp1,
					m_nLevel,
					m_nJob,
					m_nJobLv,
					m_nFlightLv,
					m_nStr,
					m_nDex,
					m_nInt,
					m_nSta,
					m_nRemainGP,
					m_nRemainLP,
					m_dwGold,
					TotalPlayTime,
					State,
					s_date
				)
			VALUES
				(
					@im_idPlayer,
					@iserverindex,
					@im_nExp1,
					@im_nLevel,
					@im_nJob,
					@im_nJobLv,
					@im_nFlightLv,
					@im_nStr,
					@im_nDex,
					@im_nInt,
					@im_nSta,
					@im_nRemainGP,
					@im_nRemainLP,
					@iattackPower,	
					@imax_HP,
					@iState,
					@os_date

			)
			RETURN
	END

/*
  	?? ???
	 ex ) 
   	LOG_STR 'L1', @im_idPlayer,@iserverindex,@im_nExp1,@im_nLevel,@im_nJob,@im_nJobLv,@im_nFlightLv,
							  @im_nStr,@im_nDex,@im_nInt,@im_nSta,@im_nRemainGP,@im_nRemainLP,@iState,
							  0,'',0,0,0,	@iattackPower	(m_dwGold),	@imax_HP			(TotalPlayTime)

   	LOG_STR 'L1', '000001','01',0,1,0,1,1,
							  15,15,15,15,0,0,'0'
							  0,'',0,0,0,0,0
*/
ELSE
IF @iGu = 'L2'
	BEGIN
			/*************************************************************
			
				?? ??
				@iGu = 'L2'
			
			*************************************************************/
			INSERT  LOG_DEATH_TBL 
				(
					m_idPlayer,
					serverindex,
					dwWorldID,		
					killed_m_szName,
					m_vPos_x,
					m_vPos_y,
					m_vPos_z,
					m_nLevel,
					attackPower,
					max_HP,
					s_date
				)
			VALUES 
				(
					@im_idPlayer,
					@iserverindex,
					@idwWorldID,		
					@ikilled_m_szName,
					@im_vPos_x,
					@im_vPos_y,
					@im_vPos_z,
					@im_nLevel,
					@iattackPower,
					@imax_HP,
					@os_date
				)
			RETURN
	END
/*
  	?? ??
	 ex ) 
   	LOG_STR 'L2', @im_idPlayer,@iserverindex,0,@im_nLevel,0,0,0,
							  0,0,0,0,0,0,'',
							  @idwWorldID,@ikilled_m_szName,@im_vPos_x,@im_vPos_y,@im_vPos_z,@iattackPower,@imax_HP

   	LOG_STR 'L2', '000001','01',0,10,0,0,0,
							  0,0,0,0,0,0,'0'
							  1,'???',0.0,0.0,0.0,1,1	
*/

ELSE
IF @iGu = 'L3'
	BEGIN
			/*************************************************************
			
				?? ???
				@iGu = 'L3'
			
			*************************************************************/
		IF @iState = 'E'
			BEGIN
					INSERT  LOG_ITEM_EVENT_TBL 
						(
							m_szName,
							serverindex,
							m_GetszName,
							dwWorldID,
							m_dwGold,
							m_nRemainGold,
							Item_UniqueNo,
							Item_Name,
							Item_durability,
							m_nAbilityOption,
							m_GetdwGold,
							Item_count,
							State,
							s_date
						)
					VALUES 
						(
							@ikilled_m_szName,
							@iserverindex,
							@im_GetszName,
							@idwWorldID,
							@im_dwGold,
							@im_nRemainGold,
							@iItem_UniqueNo,
							@iItem_Name,
							@iItem_durability,
							@iItem_AddLv ,
							@im_nExp1,
							@iItem_count,
							@iState,
							@os_date
						)
			END
		ELSE
		IF @iState in ('1','2','3','4','5','6','7','8','9','0')
			BEGIN
					INSERT  LOG_BILLING_ITEM_TBL 
						(
							m_szName,
							serverindex,
							m_GetszName,
							dwWorldID,
							m_dwGold,
							m_nRemainGold,
							Item_UniqueNo,
							Item_Name,
							Item_durability,
							m_nAbilityOption,
							m_GetdwGold,
							Item_count,
							State,
							s_date
						)
					VALUES 
						(
							@ikilled_m_szName,
							@iserverindex,
							@im_GetszName,
							@idwWorldID,
							@im_dwGold,
							@im_nRemainGold,
							@iItem_UniqueNo,
							@iItem_Name,
							@iItem_durability,
							@iItem_AddLv ,
							@im_nExp1,
							@iItem_count,
							@iState,
							@os_date
						)
			END
		ELSE
			BEGIN
					INSERT  LOG_ITEM_TBL 
						(
							m_szName,
							serverindex,
							m_GetszName,
							dwWorldID,
							m_dwGold,
							m_nRemainGold,
							Item_UniqueNo,
							Item_Name,
							Item_durability,
							m_nAbilityOption,
							m_GetdwGold,
							Item_count,
							State,
							s_date
						)
					VALUES 
						(
							@ikilled_m_szName,
							@iserverindex,
							@im_GetszName,
							@idwWorldID,
							@im_dwGold,
							@im_nRemainGold,
							@iItem_UniqueNo,
							@iItem_Name,
							@iItem_durability,
							@iItem_AddLv ,
							@im_nExp1,
							@iItem_count,
							@iState,
							@os_date
						)					
			END

			RETURN
	END

/*
  	?? ???
	 ex ) 
   	LOG_STR 'L3', @im_idPlayer,@iserverindex,0,0,0,0,0,
							  0,0,0,0,0,0,@iState,
							    @idwWorldID,@ikilled_m_szName(m_szName),0,0,0,0,0,
							  @im_GetszName,@im_dwGold,@im_nRemainGold,@iItem_UniqueNo,@iItem_Name,@iItem_durability,@iItem_count

   	LOG_STR 'L3', '000001','01',0,0,0,0,0,
							  0,0,0,0,0,0,'0'
							  0,'????',0,0,0,0,0,
							  '???',100,100,1,'????',1,1
*/
ELSE
IF @iGu = 'L4'
	BEGIN
			/*************************************************************
			
				?? ???
				@iGu = 'L4'
			
			*************************************************************/
			INSERT  LOG_UNIQUE_TBL 
				(
					m_idPlayer,
					serverindex,
					dwWorldID,
					m_vPos_x,
					m_vPos_y,
					m_vPos_z,
					Item_Name,
					Item_AddLv,
					s_date
				)
			VALUES 
				(
					@im_idPlayer,
					@iserverindex,
					@idwWorldID,
					@im_vPos_x,
					@im_vPos_y,
					@im_vPos_z,
					@iItem_Name,
					@iItem_AddLv,
					@os_date
				)
			RETURN
	END

/*
  	?? ???
	 ex ) 
   	LOG_STR 'L4', @im_idPlayer,@iserverindex,0,0,0,0,0,
								  0,0,0,0,0,0,'0',
								 @idwWorldID,'',@im_vPos_x,@im_vPos_y,@im_vPos_z,0,0,
								 '',0,0,0,@iItem_Name,0,0
								  @iItem_AddLv

   	LOG_STR 'L4', '000001','01',0,0,0,0,0,
							  	0,0,0,0,0,0,'0'
							  	0,'',0,0,0,0,0,
							  	'',0,0,0,'',0,0,
								10
*/

ELSE
IF @iGu = 'L5'
	BEGIN
			/*************************************************************
			
				?? ?? 
				@iGu = 'L5'
			
			*************************************************************/
			INSERT  LOG_LOGIN_TBL 
				(
					m_idPlayer,
					serverindex,
					dwWorldID,
					Start_Time,
					End_Time,
					TotalPlayTime,
					m_dwGold,
					remoteIP
				)
			VALUES 
				(
					@im_idPlayer,
					@iserverindex,
					@idwWorldID,
					@iStart_Time,					
					@os_date, 

					@iTotalPlayTime,
					@im_dwGold,
					@iremoteIP
				)
			RETURN
	END
/*
  	?? ??
	 ex ) 
   	LOG_STR 'L5', @im_idPlayer,@iserverindex,0,0,0,0,0,
								  0,0,0,0,0,0,'',
								  @idwWorldID,'',0,0,0,0,0,
								  '',@im_dwGold,0,0,'',0,0,
								0,
								@iStart_Time,@iTotalPlayTime,@iremoteIP

   	LOG_STR 'L5', '000001','01',0,0,0,0,0,
							  	0,0,0,0,0,0,'0'
							  	0,'',0,0,0,0,0,
							  	'',10000,0,0,'',0,0,
								0,
								'20030930123123',100,'61.33.151.12'

*/

ELSE
IF @iGu = 'L6'
	BEGIN
			/*************************************************************
			
				?? ??? ??
				@iGu = 'L6'
			
			*************************************************************/
			INSERT  LOG_QUEST_TBL 
				(
					m_idPlayer,
					serverindex,
					Quest_Index,
					State,
					Start_Time,
					End_Time
				)
			VALUES 
				(
					@im_idPlayer,
					@iserverindex,
					@iQuest_Index,
					@iState,
					@os_date,
					@iStart_Time  -- End_Time ?? 
				)
			RETURN
	END

/*
  	?? ??? ??
	 ex ) 
   	LOG_STR 'L6', @im_idPlayer,@iserverindex,0,0,0,0,0,
								  0,0,0,0,0,0,@iState,
								  0,'',0,0,0,0,0,
								  '',0,0,0,'',0,0,
								0,
								@iStart_Time,	0,'',
								@iQuest_Index

   	LOG_STR 'L6', '000001','01',0,0,0,0,0,
							  	0,0,0,0,0,0,'0'
							  	0,'',0,0,0,0,0,
							  	'',0,0,0,'',0,0,
								0,
								'20030930123123',0,'0',
								1

*/

ELSE
IF @iGu = 'L7'
	BEGIN
			/*************************************************************
			
				?? ??? ??
				@iGu = 'L7'
			
			*************************************************************/
			UPDATE  LOG_QUEST_TBL 
					SET State = 'Q',
							End_Time = @os_date
			 WHERE 	m_idPlayer = @im_idPlayer
				   AND	serverindex = @iserverindex
				   AND	Quest_Index = @iQuest_Index
			RETURN
	END
/*
  	?? ??? ??
	 ex ) 
   	LOG_STR 'L7', @im_idPlayer,@iserverindex,0,0,0,0,0,
								  0,0,0,0,0,0,'',
								  0,'',0,0,0,0,0,
								  '',0,0,0,'',0,0,
								0,
								'',	0,'',
								@iQuest_Index

   	LOG_STR 'L7', '000001','01',0,0,0,0,0,
							  	0,0,0,0,0,0,''
							  	0,'',0,0,0,0,0,
							  	'',0,0,0,'',0,0,
								0,
								'',0,'0',
								1
*/

ELSE
IF @iGu = 'L8'
	BEGIN
			/*************************************************************
			
				?? ????
				@iGu = 'L8'
			
			*************************************************************/
			INSERT  LOG_SVRDOWN_TBL 
				(
					serverindex,
					Start_Time,
					End_Time
				)
			VALUES 
				(
					@iserverindex,
					@iStart_Time,

					@os_date

				)
			RETURN
	END

/*
  	?? ????
	 ex ) 
   	LOG_STR 'L8', '',@iserverindex,0,0,0,0,0,
								  0,0,0,0,0,0,'',
								  0,'',0,0,0,0,0,
								  '',0,0,0,'',0,0,
								0,
								@iStart_Time

   	LOG_STR 'L8', ''','01',0,0,0,0,0,
							  	0,0,0,0,0,0,''
							  	0,'',0,0,0,0,0,
							  	'',0,0,0,'',0,0,
								0,
								'20030923122312'
*/

ELSE
IF @iGu = 'L9'
	BEGIN
			/*************************************************************
			
				?? ?? ??
				@iGu = 'L9'
			
			*************************************************************/
			INSERT  LOG_USER_CNT_TBL 
				(
					serverindex,
					s_date,
					number
				)
			VALUES 
				(
					@iserverindex,
					@os_date,
					@im_nExp1

				)
			RETURN
	END

/*
  	?? ?? ??
	 ex ) 
   	LOG_STR 'L9','',@iserverindex,@im_nExp1 --(number)

   	LOG_STR 'L9','',@iserverindex,234
*/


ELSE
IF @iGu = 'LA'
	BEGIN
			/*************************************************************
			
				?? PVP
				@iGu = 'LA'
			
			*************************************************************/
			INSERT  LOG_PK_PVP_TBL 
				(
					m_idPlayer,
					serverindex,
					m_nLevel,
					m_vPos_x,
					m_vPos_z,
					killed_m_idPlayer,
					killed_m_nLevel,
					m_GetPoint,
					m_nSlaughter,
					m_nFame,
					killed_m_nSlaughter,
					killed_m_nFame,
					m_KillNum,
					State,
					s_date
				)
			VALUES 
				(
					@im_idPlayer,
					@iserverindex,
					@im_nLevel,
					@im_vPos_x,
					@im_vPos_z,
					@ikilled_m_idPlayer,

					@im_nExp1, 	--killed_m_nLevel,
					@im_nJob, 	--m_GetPoint,
					@im_nJobLv, 	--m_nSlaughter,
					@im_nStr, --m_nFame,
					@im_nDex, --killed_m_nSlaughter,
					@im_nInt, --killed_m_nFame,
					@im_nFlightLv, -- m_KillNum,
					@iState, --State,
					@os_date
				)
			RETURN
	END

/*
  	?? PK, PVP
	 ex ) 
   	LOG_STR 'LA', @im_idPlayer,@iserverindex,@im_nExp1(killed_m_nLevel),@im_nLevel,@im_nJob(m_GetnSlaughter),@im_nJobLv(m_nSlaughter),@im_nFlightLv(m_KillNum),
							   @im_nStr(m_nFame),@im_nDex(killed_m_nSlaughter),@im_nInt(killed_m_nFame),0,0,0,'@iState',
							  0,'',@im_vPos_x,0,@im_vPos_z,0,0,
							  '',0,0,0,'',0,0,
							  0,
							  '',0,'',0,@ikilled_m_idPlayer


   	LOG_STR 'LA', '000001','01',15,20,10,100,200,
							   300,400,500,0,0,0,'K',
							  0,'',0.0,0,0.0,0,0,
							  '',0,0,0,'',0,0,
							  0,
							  '',0,'',0,'000002'
*/

ELSE
IF @iGu = 'LC'
	BEGIN
			INSERT  LOG_ITEM_SEND_TBL
				(
					m_idPlayer,
					serverindex,
					m_nNo,
					m_szItemName,
					m_nItemNum,
					s_date,
					m_bItemResist,
					m_nResistAbilityOption
				)
			VALUES 
				(
					@im_idPlayer,
					@iserverindex,
					@im_nExp1,
					@iItem_Name,
					@iItem_count,
					@os_date,
					@im_nStr, --m_bItemResist
					@im_nDex -- m_nResistAbilityOption
				)
			RETURN
	END

/*
	 ??? ?? ??

   	LOG_STR 'LC', @im_idPlayer,@iserverindex,@im_nExp1(m_nNo),0,0,0,0,
							   @im_nStr(m_bItemResist),@im_nDex(m_nResistAbilityOption),0,0,0,0,'',
							  0,'',0,0,0,0,0,
							  '',0,0,0,@iItem_Name,0,@iItem_count

   	LOG_STR 'LC', '000001','01',1,0,0,0,0,
							   0,0,0,0,0,0,'',
							  0,'',0,0,0,0,0,
							  '',0,0,0,'????',0,1



*/

ELSE
IF @iGu = 'LD'
	BEGIN
			INSERT  LOG_ITEM_REMOVE_TBL
				(
					m_idPlayer,
					serverindex,
					m_nNo,
					m_szItemName,
					m_nItemNum,
					s_date,
					m_bItemResist,
					m_nResistAbilityOption
				)
			VALUES 
				(
					@im_idPlayer,
					@iserverindex,
					@im_nExp1,
					@iItem_Name,
					@iItem_count,
					@os_date,
					@im_nStr, --m_bItemResist
					@im_nDex -- m_nResistAbilityOption
				)
			RETURN
	END

/*


	 ??? ?? ??

   	LOG_STR 'LD', @im_idPlayer,@iserverindex,@im_nExp1(m_nNo),0,0,0,0,
							   @im_nStr(m_bItemResist),@im_nDex(m_nResistAbilityOption),0,0,0,0,'',
							  0,'',0,0,0,0,0,
							  '',0,0,0,@iItem_Name,0,@iItem_count

   	LOG_STR 'LD', '000001','01',1,0,0,0,0,
							   0,0,0,0,0,0,'',
							  0,'',0,0,0,0,0,
							  '',0,0,0,'????',0,1
*/

ELSE
IF @iGu = 'LE'
	BEGIN
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nExp1,
					@im_nLevel,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nJob,
					@im_nJobLv,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nFlightLv,
					@im_nStr,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nDex,
					@im_nInt,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nSta,
					@im_nRemainGP,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nRemainLP,
					@idwWorldID,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@iattackPower,
					@imax_HP,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_dwGold,
					@im_nRemainGold,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@iItem_UniqueNo,
					@iItem_durability,
					@os_date
				)
			INSERT  LOG_RESPAWN_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@iItem_count,
					@iItem_AddLv,
					@os_date
				)
			RETURN
	END

/*
	 ??? ??

   	LOG_STR 'LE', 0,0,@im_nExp1,@im_nLevel,@im_nJob,@im_nJobLv,@im_nFlightLv,
							   @im_nStr,@im_nDex,@im_nInt,@im_nSta,@im_nRemainGP,@im_nRemainLP,'',
							  @idwWorldID,'',0,0,0,@iattackPower,@imax_HP,
							  '',@im_dwGold,@im_nRemainGold,@iItem_UniqueNo,'',@iItem_durability,@iItem_count,@iItem_AddLv

   	LOG_STR 'LE', '','',1,1,1,1,1,
							   1,1,1,1,1,1,'',
							  1,'',0,0,0,1,1,
							  '',1,1,1,'',1,1,1
*/

ELSE
IF @iGu = 'LF'
	BEGIN
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nExp1,
					@im_nLevel,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nJob,
					@im_nJobLv,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nFlightLv,
					@im_nStr,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nDex,
					@im_nInt,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nSta,
					@im_nRemainGP,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_nRemainLP,
					@idwWorldID,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@iattackPower,
					@imax_HP,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@im_dwGold,
					@im_nRemainGold,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@iItem_UniqueNo,
					@iItem_durability,
					@os_date
				)
			INSERT  LOG_SKILL_FREQUENCY_TBL
				(
					m_nid,
					m_nFrequency,
					s_date
				)
			VALUES 
				(
					@iItem_count,
					@iItem_AddLv,
					@os_date
				)
			RETURN
	END

/*
	 ???? ??

   	LOG_STR 'LF', 0,0,@im_nExp1,@im_nLevel,@im_nJob,@im_nJobLv,@im_nFlightLv,
							   @im_nStr,@im_nDex,@im_nInt,@im_nSta,@im_nRemainGP,@im_nRemainLP,'',
							  @idwWorldID,'',0,0,0,@iattackPower,@imax_HP,
							  '',@im_dwGold,@im_nRemainGold,@iItem_UniqueNo,'',@iItem_durability,@iItem_count,@iItem_AddLv

   	LOG_STR 'LF', '','',1,1,1,1,1,
							   1,1,1,1,1,1,'',
							  1,'',0,0,0,1,1,
							  '',1,1,1,'',1,1,1
*/

set nocount off
GO
/****** Object:  StoredProcedure [dbo].[LOG_GUILD_STR]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE    PROC [dbo].[LOG_GUILD_STR]
@iGu CHAR(2)  = 'L1',
@im_idGuild CHAR(6)  = '000001',
@im_idPlayer CHAR(7)  = '0000001',
@iserverindex CHAR(2)  = '01',
@im_nGuildGold INT = 0,
@im_nLevel INT = 0,
@im_GuildLv INT = 0,
@iGuildPoint INT = 0,
@iDo_m_idPlayer CHAR(7)  = '',
@iState CHAR(1)  = '',
@im_Item INT = 0,
@im_GuildBank TEXT = '',
@im_nAbilityOption INT = 0,
@iItem_count INT = 0,
@iItem_UniqueNo INT = 0,
@is_date char(14) = ''
AS
set nocount on

DECLARE @os_date CHAR(14)
  SELECT @os_date = CONVERT(CHAR(8),GETDATE(),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,GETDATE())),2)

IF @iGu = 'L1'
	BEGIN
		INSERT LOG_GUILD_TBL
			(m_idGuild,m_idPlayer,serverindex,Do_m_idPlayer,State,s_date)
		VALUES
			(@im_idGuild,@im_idPlayer,@iserverindex,@iDo_m_idPlayer,@iState,@os_date)
	RETURN
	END

/*
  	?? ??/?? ??
	 ex ) 
   	LOG_GUILD_STR 'L1', @im_idGuild,@im_idPlayer,@iserverindex,@im_nGuildGold,@im_nLevel,@im_GuildLv,@iGuildPoint,@iDo_m_idPlayer,@iState
   	LOG_GUILD_STR 'L1', '000001', '000001','01',0,0,0,0,'000002','J'

	@iState : ?? J ?? L ?? R

*/
ELSE
IF  @iGu = 'L2'
	BEGIN
		INSERT LOG_GUILD_BANK_TBL
			(m_idGuild,m_idPlayer,serverindex,m_nGuildGold,m_GuildBank,State,m_Item,m_nAbilityOption,Item_count ,Item_UniqueNo,s_date)
		VALUES
			(@im_idGuild,@im_idPlayer,@iserverindex,@im_nGuildGold,@im_GuildBank,@iState,@im_Item,@im_nAbilityOption,@iItem_count ,@iItem_UniqueNo,@os_date)
	RETURN
	END
/*
  	?? ?? ??
	 ex ) 
   	LOG_GUILD_STR 'L2', @im_idGuild,@im_idPlayer,@iserverindex,@im_nGuildGold,@im_nLevel,@im_GuildLv,@iGuildPoint,@iDo_m_idPlayer,@iState,@im_Item,@im_GuildBank,@im_nAbilityOption,@iItem_count ,@iItem_UniqueNo
   	LOG_GUILD_STR 'L2', '000001', '000001','01',0,0,0,0,'000002','A','9,9,9''$',0,0,0


	@iState : ?? A ?? D ??? I ??? O ??? L

*/
ELSE
IF  @iGu = 'L3'
	BEGIN
		INSERT LOG_GUILD_DISPERSION_TBL
			(m_idGuild,m_idPlayer,serverindex,State,s_date)
		VALUES
			(@im_idGuild,@im_idPlayer,@iserverindex,@iState,@os_date)
	RETURN
	END
/*
  	?? ?? ??
	 ex ) 
   	LOG_GUILD_STR 'L3', @im_idGuild,@im_idPlayer,@iserverindex,@im_nGuildGold,@im_nLevel,@im_GuildLv,@iGuildPoint,@iDo_m_idPlayer,@iState
   	LOG_GUILD_STR 'L3', '000001', '000001','01',0,0,0,0,'','S'

	@iState : ??? S ??? E

*/
ELSE
IF  @iGu = 'L4'
	BEGIN
		INSERT LOG_GUILD_SERVICE_TBL
			(m_idGuild,m_idPlayer,serverindex,m_nLevel,m_GuildLv,GuildPoint,Gold,State,s_date)
		VALUES
			(@im_idGuild,@im_idPlayer,@iserverindex,@im_nLevel,@im_GuildLv,@iGuildPoint,@im_nGuildGold,@iState,@os_date)
	RETURN
	END
/*
  	?? ?? ??
	 ex ) 
   	LOG_GUILD_STR 'L4', @im_idGuild,@im_idPlayer,@iserverindex,@im_nGuildGold,@im_nLevel,@im_GuildLv,@iGuildPoint,@iDo_m_idPlayer,@iState
   	LOG_GUILD_STR 'L4', '000001', '000001','01',15,3,4,0,'','G'

	@iState : G ??? P PXP??
*/
ELSE
IF  @iGu = 'L5'
	BEGIN
		INSERT LOG_GUILD_WAR_TBL
			(m_idGuild,serverindex,f_idGuild,m_idWar,m_nCurExp,m_nGetExp,m_nCurPenya,m_nGetPenya,State,s_date,e_date)
		VALUES
			(@im_idGuild,@iserverindex,@im_idPlayer,@im_Item,@im_nGuildGold,@im_nLevel,@im_GuildLv,@iGuildPoint,@iState,@is_date,@os_date)
	RETURN
	END
/*
SELECT * FROM  LOG_GUILD_WAR_TBL
   ??? ??
	 ex ) 
   	LOG_GUILD_STR 'L5', @im_idGuild,@im_idPlayer(f_idPlayer),@iserverindex,@im_nGuildGold(m_nCurExp),@im_nLevel(m_nGetExp),
											@im_GuildLv(m_nCurPenya),@iGuildPoint(m_nGetPenya),'',@iState,@im_Item(m_idWar),'',0,0,0,@is_date
   	LOG_GUILD_STR 'L5','000001', '000001','01',100,10,100,10,'','1',9,'',0,0,0,'20040717123012'

	@iState : 1 ? 2 ??? 3 ? 4 ???
*/
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[LOG_USER_CNT_STR]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[LOG_USER_CNT_STR]
@iserverindex  	CHAR(2),
@im_channel int,
@im_01 INT = 0,
@im_02 INT = 0,
@im_03 INT = 0,
@im_04 INT = 0,
@im_05 INT = 0,
@im_06 INT = 0,
@im_07 INT = 0,
@im_08 INT = 0,
@im_09 INT = 0,
@im_10 INT = 0,
@im_11 INT = 0,
@im_12 INT = 0,
@im_13 INT = 0,
@im_14 INT = 0,
@im_15 INT = 0,
@im_16 INT = 0,
@im_17 INT = 0,
@im_18 INT = 0,
@im_19 INT = 0,
@im_20 INT = 0
/***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************



	LOG_USER_CNT_STR ????
	??? : ???
	??? : 2003.12.19



***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************/
AS
set nocount on
DECLARE @os_date CHAR(14),@onumber INT

  SELECT @os_date = CONVERT(CHAR(8),GETDATE(),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,GETDATE())),2)

  SELECT @onumber = @im_01 + @im_02 + @im_03 + @im_04 + @im_05 
									 + @im_06 + @im_07 + @im_08 + @im_09 + @im_10 
									 + @im_11 + @im_12 + @im_13 + @im_14 + @im_15 
									 + @im_16 + @im_17 + @im_18 + @im_19 + @im_20

	INSERT LOG_USER_CNT_TBL
		(
			serverindex,
			s_date,
			number,
			m_channel,
			m_01,
			m_02,
			m_03,
			m_04,
			m_05,
			m_06,
			m_07,
			m_08,
			m_09,
			m_10,
			m_11,
			m_12,
			m_13,
			m_14,
			m_15,
			m_16,
			m_17,
			m_18,
			m_19,
			m_20
		)
	VALUES
		(
			@iserverindex,
			@os_date,
			@onumber,
			@im_channel,
			@im_01,
			@im_02,
			@im_03,
			@im_04,
			@im_05,
			@im_06,
			@im_07,
			@im_08,
			@im_09,
			@im_10,
			@im_11,
			@im_12,
			@im_13,
			@im_14,
			@im_15,
			@im_16,
			@im_17,
			@im_18,
			@im_19,
			@im_20
		)
RETURN
set nocount off
GO
/****** Object:  StoredProcedure [dbo].[LOG_ITEM_STR]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE proc [dbo].[LOG_ITEM_STR]
	@im_szName 				VARCHAR(32),
	@iserverindex				CHAR(2),
	@im_GetszName			VARCHAR(32) 		= '',
	@idwWorldID					INT 							= 0,
	@im_dwGold					INT 							= 0,
	@im_nRemainGold		INT 							= 0,
	@iItem_UniqueNo			INT 							= 0,
	@iItem_Name					VARCHAR(32) 		= '',
	@iItem_durability			INT 							= 0,
	@im_nAbilityOption 		INT 							= 0,	
	@Im_GetdwGold			INT 							= 0,	
	@iItem_count					INT 							= 0,
	@iState							CHAR(1)					= '',
	@im_nSlot0  					INT = 0,--: ?? ??? ???? ?????
	@im_nSlot1  					INT = 0,-- : ?? ??? ??? ?????
	@im_bItemResist   		INT = 0,-- : ?? (?> ?, ?, ??, ? )
	@im_nResistAbilityOption   INT = 0,--: m_bItemResist ???
	@im_bCharged   INT = 0,
	@im_dwKeepTime  INT = 0,
	@im_nRandomOptItemId  BIGINT = 0,
	@inPiercedSize  INT = 0,
	@iadwItemId0  INT = 0,
	@iadwItemId1  INT = 0,
	@iadwItemId2  INT = 0,
	@iadwItemId3  INT = 0,
	@iadwItemId4  INT = 0,
	@iMaxDurability INT = 0
,@inPetKind int = 0, @inPetLevel int = 0, @idwPetExp int = 0, @iwPetEnergy int = 0, @iwPetLife int = 0
,@inPetAL_D int = 0, @inPetAL_C int = 0, @inPetAL_B int = 0, @inPetAL_A int = 0, @inPetAL_S int = 0
------------ ver.12
, @iadwItemId5 int = 0, @iadwItemId6 int = 0,@iadwItemId7 int = 0, @iadwItemId8 int = 0, @iadwItemId9 int = 0
, @inUMPiercedSize int = 0, @iadwUMItemId0 int = 0, @iadwUMItemId1 int = 0, @iadwUMItemId2 int = 0, @iadwUMItemId3 int = 0, @iadwUMItemId4 int = 0

AS
set nocount on
/***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************



	LOG ?? ????
	??? : ???
	??? : 2003.10.17 



--20040908 ????
-- ALTER TABLE  LOG_ITEM_EVENT_TBL  ADD m_nSlot0  INT NULL, m_nSlot1 INT NULL, m_bItemResist  INT NULL, m_nResistAbilityOption  INT NULL
-- ALTER TABLE  LOG_BILLING_ITEM_TBL  ADD m_nSlot0  INT NULL, m_nSlot1 INT NULL, m_bItemResist  INT NULL, m_nResistAbilityOption  INT NULL
-- ALTER TABLE  LOG_ITEM_TBL  ADD m_nSlot0  INT NULL, m_nSlot1 INT NULL, m_bItemResist  INT NULL, m_nResistAbilityOption  INT NULL


***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************/

DECLARE @os_date CHAR(14)
  SELECT @os_date = CONVERT(CHAR(8),GETDATE(),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,GETDATE())),2)

	BEGIN
			/*************************************************************
			
				?? ???
				@iGu = 'L3'
			
			*************************************************************/
		IF @iState = 'E'
			BEGIN
					INSERT  LOG_ITEM_EVENT_TBL 
						(
							m_szName,
							serverindex,
							m_GetszName,
							dwWorldID,
							m_dwGold,
							m_nRemainGold,
							Item_UniqueNo,
							Item_Name,
							Item_durability,
							m_nAbilityOption,
							m_GetdwGold,
							Item_count,
							State,
							s_date,
							m_nSlot0,
							m_nSlot1,
							m_bItemResist ,
							m_nResistAbilityOption,
							m_bCharged,
							m_dwKeepTime,
							m_nRandomOptItemId,
							nPiercedSize,
							adwItemId0,
							adwItemId1,
							adwItemId2,
							adwItemId3,
							MaxDurability,
							adwItemId4,
							nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
							, adwItemId5, adwItemId6, adwItemId7, adwItemId8, adwItemId9
							, nUMPiercedSize, adwUMItemId0, adwUMItemId1, adwUMItemId2, adwUMItemId3, adwUMItemId4
						)
					VALUES 
						(
							@im_szName,
							@iserverindex,
							@im_GetszName,
							@idwWorldID,
							@im_dwGold,
							@im_nRemainGold,
							@iItem_UniqueNo,
							@iItem_Name,
							@iItem_durability,
							@im_nAbilityOption ,
							@Im_GetdwGold,
							@iItem_count,
							@iState,
							@os_date,
							@im_nSlot0,
							@im_nSlot1,
							@im_bItemResist ,
							@im_nResistAbilityOption,
							@im_bCharged,
							@im_dwKeepTime,
							@im_nRandomOptItemId,
							@inPiercedSize,
							@iadwItemId0,
							@iadwItemId1,
							@iadwItemId2,
							@iadwItemId3,
							@iMaxDurability,
							@iadwItemId4
							,@inPetKind, @inPetLevel, @idwPetExp, @iwPetEnergy, @iwPetLife
							,@inPetAL_D, @inPetAL_C, @inPetAL_B, @inPetAL_A, @inPetAL_S
							, @iadwItemId5, @iadwItemId6, @iadwItemId7, @iadwItemId8, @iadwItemId9
							, @inUMPiercedSize, @iadwUMItemId0, @iadwUMItemId1, @iadwUMItemId2, @iadwUMItemId3, @iadwUMItemId4
						)
			END
		ELSE
		IF @iState in ('1','2','3','4','5','6','7','8','9','0')
			BEGIN
					INSERT  LOG_BILLING_ITEM_TBL 
						(
							m_szName,
							serverindex,
							m_GetszName,
							dwWorldID,
							m_dwGold,
							m_nRemainGold,
							Item_UniqueNo,
							Item_Name,
							Item_durability,
							m_nAbilityOption,
							m_GetdwGold,
							Item_count,
							State,
							s_date,
							m_nSlot0,
							m_nSlot1,
							m_bItemResist ,
							m_nResistAbilityOption,
							m_bCharged,
							m_dwKeepTime,
							m_nRandomOptItemId,
							nPiercedSize,
							adwItemId0,
							adwItemId1,
							adwItemId2,
							adwItemId3,
							MaxDurability,
							adwItemId4,
							nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
							, adwItemId5, adwItemId6, adwItemId7, adwItemId8, adwItemId9
							, nUMPiercedSize, adwUMItemId0, adwUMItemId1, adwUMItemId2, adwUMItemId3, adwUMItemId4
						)
					VALUES 
						(
							@im_szName,
							@iserverindex,
							@im_GetszName,
							@idwWorldID,
							@im_dwGold,
							@im_nRemainGold,
							@iItem_UniqueNo,
							@iItem_Name,
							@iItem_durability,
							@im_nAbilityOption ,
							@Im_GetdwGold,
							@iItem_count,
							@iState,
							@os_date,
							@im_nSlot0,
							@im_nSlot1,
							@im_bItemResist ,
							@im_nResistAbilityOption,
							@im_bCharged,
							@im_dwKeepTime,
							@im_nRandomOptItemId,
							@inPiercedSize,
							@iadwItemId0,
							@iadwItemId1,
							@iadwItemId2,
							@iadwItemId3,
							@iMaxDurability,
							@iadwItemId4
							,@inPetKind, @inPetLevel, @idwPetExp, @iwPetEnergy, @iwPetLife
							,@inPetAL_D, @inPetAL_C, @inPetAL_B, @inPetAL_A, @inPetAL_S
							, @iadwItemId5, @iadwItemId6, @iadwItemId7, @iadwItemId8, @iadwItemId9
							, @inUMPiercedSize, @iadwUMItemId0, @iadwUMItemId1, @iadwUMItemId2, @iadwUMItemId3, @iadwUMItemId4
						)
			END
		ELSE
			BEGIN
					INSERT  LOG_ITEM_TBL 
						(
							m_szName,
							serverindex,
							m_GetszName,
							dwWorldID,
							m_dwGold,
							m_nRemainGold,
							Item_UniqueNo,
							Item_Name,
							Item_durability,
							m_nAbilityOption,
							m_GetdwGold,
							Item_count,
							State,
							s_date,
							m_nSlot0,
							m_nSlot1,
							m_bItemResist ,
							m_nResistAbilityOption,
							m_bCharged,
							m_dwKeepTime,
							m_nRandomOptItemId,
							nPiercedSize,
							adwItemId0,
							adwItemId1,
							adwItemId2,
							adwItemId3,
							MaxDurability,
							adwItemId4,
							nPetKind, nPetLevel, dwPetExp, wPetEnergy, wPetLife, nPetAL_D, nPetAL_C, nPetAL_B, nPetAL_A, nPetAL_S
							, adwItemId5, adwItemId6, adwItemId7, adwItemId8, adwItemId9
							, nUMPiercedSize, adwUMItemId0, adwUMItemId1, adwUMItemId2, adwUMItemId3, adwUMItemId4
						)
					VALUES 
						(
							@im_szName,
							@iserverindex,
							@im_GetszName,
							@idwWorldID,
							@im_dwGold,
							@im_nRemainGold,
							@iItem_UniqueNo,
							@iItem_Name,
							@iItem_durability,
							@im_nAbilityOption ,
							@Im_GetdwGold,
							@iItem_count,
							@iState,
							@os_date,
							@im_nSlot0,
							@im_nSlot1,
							@im_bItemResist ,
							@im_nResistAbilityOption,
							@im_bCharged,
							@im_dwKeepTime,
							@im_nRandomOptItemId,
							@inPiercedSize,
							@iadwItemId0,
							@iadwItemId1,
							@iadwItemId2,
							@iadwItemId3,
							@iMaxDurability,
							@iadwItemId4
							,@inPetKind, @inPetLevel, @idwPetExp, @iwPetEnergy, @iwPetLife
							,@inPetAL_D, @inPetAL_C, @inPetAL_B, @inPetAL_A, @inPetAL_S
							, @iadwItemId5, @iadwItemId6, @iadwItemId7, @iadwItemId8, @iadwItemId9
							, @inUMPiercedSize, @iadwUMItemId0, @iadwUMItemId1, @iadwUMItemId2, @iadwUMItemId3, @iadwUMItemId4
						)					
			END

			RETURN
	END

/*
  	?? ???
	 ex ) 
   	LOG_ITEM_STR 	@im_szName,
									@iserverindex	,
									@im_GetszName	,
									@idwWorldID,
									@im_dwGold,
									@im_nRemainGold,
									@iItem_UniqueNo,
									@iItem_Name		,
									@iItem_durability		,

									@im_nAbilityOption ,
									@Im_GetdwGold	,
									@iItem_count,
									@iState	,
									@im_nSlot0,
									@im_nSlot1,
									@im_bItemResist,
									@im_nResistAbilityOption
									@im_bCharged,
									@im_dwKeepTime,
									@im_nRandomOptItemId,
									@inPiercedSize,
									@iadwItemId0,
									@iadwItemId1,
									@iadwItemId2,
									@iadwItemId3

	LOG_ITEM_STR 	'???',
									'01',
									'??',
									1,
									0,
									1000,
									-12341,
									'????',
									1,
									3,
									123,
									1,
									'G',
									0,
									0,
									0,
									0,
									0,
									0,
									0,
									0,
									0,
									0,
									0,
									0
*/

set nocount off
GO
/****** Object:  StoredProcedure [dbo].[LOG_GAMEMASTER_STR]    Script Date: 04/03/2010 12:45:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE      PROC [dbo].[LOG_GAMEMASTER_STR]
	@im_idPlayer 				CHAR(7),
	@iserverindex				CHAR(2),
	@iszWords					VARCHAR(256) 		= '',
	@im_idGuild					CHAR(6) = ''

/***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************



	LOG_GAMEMASTER_STR ????
	??? : ???
	??? : 2004.01.20



***********************************************************************************
***********************************************************************************
***********************************************************************************
***********************************************************************************/

AS
set nocount on
DECLARE @os_date CHAR(14)

  SELECT @os_date = CONVERT(CHAR(8),GETDATE(),112) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(hh,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(mi,GETDATE())),2) 
									+ RIGHT('00' + CONVERT(VARCHAR(2),DATEPART(ss,GETDATE())),2)

	INSERT LOG_GAMEMASTER_TBL
		(
			m_idPlayer,
			serverindex,
			m_szWords,
			s_date,
			m_idGuild
		)
	VALUES
		(
			@im_idPlayer,
			@iserverindex,
			@iszWords,
			@os_date,
			@im_idGuild
		)
RETURN
set nocount off
GO
/****** Object:  Default [DF__LOG_BILLI__nPetK__43D61337]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__nPetK__43D61337]  DEFAULT ((0)) FOR [nPetKind]
GO
/****** Object:  Default [DF__LOG_BILLI__nPetL__44CA3770]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__nPetL__44CA3770]  DEFAULT ((0)) FOR [nPetLevel]
GO
/****** Object:  Default [DF__LOG_BILLI__dwPet__45BE5BA9]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__dwPet__45BE5BA9]  DEFAULT ((0)) FOR [dwPetExp]
GO
/****** Object:  Default [DF__LOG_BILLI__wPetE__46B27FE2]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__wPetE__46B27FE2]  DEFAULT ((0)) FOR [wPetEnergy]
GO
/****** Object:  Default [DF__LOG_BILLI__wPetL__47A6A41B]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__wPetL__47A6A41B]  DEFAULT ((0)) FOR [wPetLife]
GO
/****** Object:  Default [DF__LOG_BILLI__nPetA__489AC854]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__nPetA__489AC854]  DEFAULT ((0)) FOR [nPetAL_D]
GO
/****** Object:  Default [DF__LOG_BILLI__nPetA__498EEC8D]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__nPetA__498EEC8D]  DEFAULT ((0)) FOR [nPetAL_C]
GO
/****** Object:  Default [DF__LOG_BILLI__nPetA__4A8310C6]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__nPetA__4A8310C6]  DEFAULT ((0)) FOR [nPetAL_B]
GO
/****** Object:  Default [DF__LOG_BILLI__nPetA__4B7734FF]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__nPetA__4B7734FF]  DEFAULT ((0)) FOR [nPetAL_A]
GO
/****** Object:  Default [DF__LOG_BILLI__nPetA__4C6B5938]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_BILLI__nPetA__4C6B5938]  DEFAULT ((0)) FOR [nPetAL_S]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwItemId5]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwItemId5]  DEFAULT ((0)) FOR [adwItemId5]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwItemId6]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwItemId6]  DEFAULT ((0)) FOR [adwItemId6]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwItemId7]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwItemId7]  DEFAULT ((0)) FOR [adwItemId7]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwItemId8]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwItemId8]  DEFAULT ((0)) FOR [adwItemId8]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwItemId9]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwItemId9]  DEFAULT ((0)) FOR [adwItemId9]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_nUMPiercedSize]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_nUMPiercedSize]  DEFAULT ((0)) FOR [nUMPiercedSize]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwUMItemId0]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwUMItemId0]  DEFAULT ((0)) FOR [adwUMItemId0]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwUMItemId1]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwUMItemId1]  DEFAULT ((0)) FOR [adwUMItemId1]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwUMItemId2]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwUMItemId2]  DEFAULT ((0)) FOR [adwUMItemId2]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_adwUMItemId3]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_adwUMItemId3]  DEFAULT ((0)) FOR [adwUMItemId3]
GO
/****** Object:  Default [DF_LOG_BILLING_ITEM_TBL_TBL_adwUMItemId4]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_BILLING_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_BILLING_ITEM_TBL_TBL_adwUMItemId4]  DEFAULT ((0)) FOR [adwUMItemId4]
GO
/****** Object:  Default [DF_LOG_INS_DUNGEON_TBL_m_Date]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_INS_DUNGEON_TBL] ADD  CONSTRAINT [DF_LOG_INS_DUNGEON_TBL_m_Date]  DEFAULT (getdate()) FOR [m_Date]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetK__3A4CA8FD]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetK__3A4CA8FD]  DEFAULT ((0)) FOR [nPetKind]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetL__3B40CD36]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetL__3B40CD36]  DEFAULT ((0)) FOR [nPetLevel]
GO
/****** Object:  Default [DF__LOG_ITEM___dwPet__3C34F16F]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___dwPet__3C34F16F]  DEFAULT ((0)) FOR [dwPetExp]
GO
/****** Object:  Default [DF__LOG_ITEM___wPetE__3D2915A8]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___wPetE__3D2915A8]  DEFAULT ((0)) FOR [wPetEnergy]
GO
/****** Object:  Default [DF__LOG_ITEM___wPetL__3E1D39E1]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___wPetL__3E1D39E1]  DEFAULT ((0)) FOR [wPetLife]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__3F115E1A]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__3F115E1A]  DEFAULT ((0)) FOR [nPetAL_D]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__40058253]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__40058253]  DEFAULT ((0)) FOR [nPetAL_C]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__40F9A68C]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__40F9A68C]  DEFAULT ((0)) FOR [nPetAL_B]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__41EDCAC5]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__41EDCAC5]  DEFAULT ((0)) FOR [nPetAL_A]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__42E1EEFE]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__42E1EEFE]  DEFAULT ((0)) FOR [nPetAL_S]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwItemId5]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwItemId5]  DEFAULT ((0)) FOR [adwItemId5]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwItemId6]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwItemId6]  DEFAULT ((0)) FOR [adwItemId6]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwItemId7]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwItemId7]  DEFAULT ((0)) FOR [adwItemId7]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwItemId8]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwItemId8]  DEFAULT ((0)) FOR [adwItemId8]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwItemId9]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwItemId9]  DEFAULT ((0)) FOR [adwItemId9]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_nUMPiercedSize]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_nUMPiercedSize]  DEFAULT ((0)) FOR [nUMPiercedSize]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwUMItemId0]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwUMItemId0]  DEFAULT ((0)) FOR [adwUMItemId0]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwUMItemId1]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwUMItemId1]  DEFAULT ((0)) FOR [adwUMItemId1]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwUMItemId2]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwUMItemId2]  DEFAULT ((0)) FOR [adwUMItemId2]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwUMItemId3]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwUMItemId3]  DEFAULT ((0)) FOR [adwUMItemId3]
GO
/****** Object:  Default [DF_LOG_ITEM_EVENT_TBL_adwUMItemId4]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_EVENT_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_EVENT_TBL_adwUMItemId4]  DEFAULT ((0)) FOR [adwUMItemId4]
GO
/****** Object:  Default [DF_LOG_ITEM_REMOVE_TBL_RandomOption]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_REMOVE_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_REMOVE_TBL_RandomOption]  DEFAULT ((0)) FOR [RandomOption]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetK__30C33EC3]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetK__30C33EC3]  DEFAULT ((0)) FOR [nPetKind]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetL__31B762FC]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetL__31B762FC]  DEFAULT ((0)) FOR [nPetLevel]
GO
/****** Object:  Default [DF__LOG_ITEM___dwPet__32AB8735]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___dwPet__32AB8735]  DEFAULT ((0)) FOR [dwPetExp]
GO
/****** Object:  Default [DF__LOG_ITEM___wPetE__339FAB6E]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___wPetE__339FAB6E]  DEFAULT ((0)) FOR [wPetEnergy]
GO
/****** Object:  Default [DF__LOG_ITEM___wPetL__3493CFA7]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___wPetL__3493CFA7]  DEFAULT ((0)) FOR [wPetLife]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__3587F3E0]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__3587F3E0]  DEFAULT ((0)) FOR [nPetAL_D]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__367C1819]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__367C1819]  DEFAULT ((0)) FOR [nPetAL_C]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__37703C52]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__37703C52]  DEFAULT ((0)) FOR [nPetAL_B]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__3864608B]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__3864608B]  DEFAULT ((0)) FOR [nPetAL_A]
GO
/****** Object:  Default [DF__LOG_ITEM___nPetA__395884C4]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF__LOG_ITEM___nPetA__395884C4]  DEFAULT ((0)) FOR [nPetAL_S]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwItemId5]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwItemId5]  DEFAULT ((0)) FOR [adwItemId5]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwItemId6]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwItemId6]  DEFAULT ((0)) FOR [adwItemId6]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwItemId7]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwItemId7]  DEFAULT ((0)) FOR [adwItemId7]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwItemId8]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwItemId8]  DEFAULT ((0)) FOR [adwItemId8]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwItemId9]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwItemId9]  DEFAULT ((0)) FOR [adwItemId9]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_nUMPiercedSize]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_nUMPiercedSize]  DEFAULT ((0)) FOR [nUMPiercedSize]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwUMItemId0]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwUMItemId0]  DEFAULT ((0)) FOR [adwUMItemId0]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwUMItemId1]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwUMItemId1]  DEFAULT ((0)) FOR [adwUMItemId1]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwUMItemId2]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwUMItemId2]  DEFAULT ((0)) FOR [adwUMItemId2]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwUMItemId3]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwUMItemId3]  DEFAULT ((0)) FOR [adwUMItemId3]
GO
/****** Object:  Default [DF_LOG_ITEM_TBL_adwUMItemId4]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_ITEM_TBL] ADD  CONSTRAINT [DF_LOG_ITEM_TBL_adwUMItemId4]  DEFAULT ((0)) FOR [adwUMItemId4]
GO
/****** Object:  Default [DF_LOG_LOGIN_TBL_State]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[LOG_LOGIN_TBL] ADD  CONSTRAINT [DF_LOG_LOGIN_TBL_State]  DEFAULT ((0)) FOR [State]
GO
/****** Object:  Default [DF_tblCampus_PointLog_s_date]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblCampus_PointLog] ADD  CONSTRAINT [DF_tblCampus_PointLog_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblCampusLog_s_date]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblCampusLog] ADD  CONSTRAINT [DF_tblCampusLog_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_OldCharName]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblChangeNameHistoryLog] ADD  CONSTRAINT [DF_OldCharName]  DEFAULT ('') FOR [OldCharName]
GO
/****** Object:  Default [DF_NewCharName]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblChangeNameHistoryLog] ADD  CONSTRAINT [DF_NewCharName]  DEFAULT ('') FOR [NewCharName]
GO
/****** Object:  Default [DF_ChangeDt]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblChangeNameHistoryLog] ADD  CONSTRAINT [DF_ChangeDt]  DEFAULT (getdate()) FOR [ChangeDt]
GO
/****** Object:  Default [DF_EndDt]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblChangeNameLog] ADD  CONSTRAINT [DF_EndDt]  DEFAULT ('2099-12-31') FOR [EndDt]
GO
/****** Object:  Default [DF_CharName]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblChangeNameLog] ADD  CONSTRAINT [DF_CharName]  DEFAULT ('') FOR [CharName]
GO
/****** Object:  Default [DF_tblGuildHouse_FurnitureLog_s_date]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblGuildHouse_FurnitureLog] ADD  CONSTRAINT [DF_tblGuildHouse_FurnitureLog_s_date]  DEFAULT (getdate()) FOR [Del_date]
GO
/****** Object:  Default [DF_tblGuildHouseLog_s_date]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblGuildHouseLog] ADD  CONSTRAINT [DF_tblGuildHouseLog_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblQuestLog_Comment]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblQuestLog] ADD  CONSTRAINT [DF_tblQuestLog_Comment]  DEFAULT ('') FOR [Comment]
GO
/****** Object:  Default [DF_ITEM_SEND_TBL_m_bCharged]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblQuizAnswerLog] ADD  CONSTRAINT [DF_ITEM_SEND_TBL_m_bCharged]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblQuizLog_Start_Time]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblQuizLog] ADD  CONSTRAINT [DF_tblQuizLog_Start_Time]  DEFAULT (getdate()) FOR [Start_Time]
GO
/****** Object:  Default [DF_tblQuizUser_s_date]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblQuizUserLog] ADD  CONSTRAINT [DF_tblQuizUser_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblSystemErrorLog_s_date]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblSystemErrorLog] ADD  CONSTRAINT [DF_tblSystemErrorLog_s_date]  DEFAULT (getdate()) FOR [s_date]
GO
/****** Object:  Default [DF_tblTradeDetailLog_TradeGold]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblTradeDetailLog] ADD  CONSTRAINT [DF_tblTradeDetailLog_TradeGold]  DEFAULT ((0)) FOR [TradeGold]
GO
/****** Object:  Default [DF_tblTradeDetailLog_PlayerIP]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblTradeDetailLog] ADD  CONSTRAINT [DF_tblTradeDetailLog_PlayerIP]  DEFAULT ('0.0.0.0') FOR [PlayerIP]
GO
/****** Object:  Default [DF_tblTradeItemLog_AbilityOpt]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblTradeItemLog] ADD  CONSTRAINT [DF_tblTradeItemLog_AbilityOpt]  DEFAULT ((0)) FOR [AbilityOpt]
GO
/****** Object:  Default [DF_tblTradeItemLog_ItemResist]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblTradeItemLog] ADD  CONSTRAINT [DF_tblTradeItemLog_ItemResist]  DEFAULT ((0)) FOR [ItemResist]
GO
/****** Object:  Default [DF_tblTradeItemLog_ResistAbilityOpt]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblTradeItemLog] ADD  CONSTRAINT [DF_tblTradeItemLog_ResistAbilityOpt]  DEFAULT ((0)) FOR [ResistAbilityOpt]
GO
/****** Object:  Default [DF_tblTradeItemLog_RandomOpt]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblTradeItemLog] ADD  CONSTRAINT [DF_tblTradeItemLog_RandomOpt]  DEFAULT ((0)) FOR [RandomOpt]
GO
/****** Object:  Default [DF_TradeDt]    Script Date: 04/03/2010 12:45:46 ******/
ALTER TABLE [dbo].[tblTradeLog] ADD  CONSTRAINT [DF_TradeDt]  DEFAULT (getdate()) FOR [TradeDt]
GO
RAISERROR( 'Step 11: Configure [RANKING_DBF]',0,1) WITH NOWAIT
GO

USE [RANKING_DBF]
GO
/****** Object:  Table [dbo].[RANKING_TBL]    Script Date: 04/03/2010 12:49:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RANKING_TBL](
	[order] [int] NULL,
	[order_all] [int] NULL,
	[Gu] [char](2) NOT NULL,
	[s_date] [char](10) NOT NULL,
	[serverindex] [char](2) NOT NULL,
	[m_dwLogo] [int] NULL,
	[m_idGuild] [char](6) NOT NULL,
	[m_szGuild] [varchar](48) NULL,
	[m_szName] [varchar](32) NULL,
	[m_nWin] [int] NULL,
	[m_nLose] [int] NULL,
	[m_nSurrender] [int] NULL,
	[m_MaximumUnity] [float] NULL,
	[m_AvgLevel] [float] NULL,
	[m_nGuildGold] [bigint] NULL,
	[m_nWinPoint] [int] NULL,
	[m_nPlayTime] [int] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_RANKING_TBL] PRIMARY KEY CLUSTERED 
(
	[Gu] ASC,
	[s_date] ASC,
	[serverindex] ASC,
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_guildbank_log_view]    Script Date: 04/03/2010 12:48:58 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE  PROC [dbo].[usp_guildbank_log_view]
@iGu char(2) = 'S1',
@im_idGuild char(6) = '01',
@iserverindex CHAR(2) = ''
AS
SET NOCOUNT ON
IF @iGu = 'S1'
	BEGIN 
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex AND State='A'  ORDER BY s_date DESC
	END 
/*
?? A ?? D ??? I ??? O
*/
ELSE
IF @iGu = 'S2'
	BEGIN
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex  AND State='D'   ORDER BY s_date DESC
	END
/*
	
*/
ELSE
IF @iGu = 'S3'
	BEGIN
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex  AND State='I'   ORDER BY s_date DESC
	END
/*
	
*/
ELSE
IF @iGu = 'S4'
	BEGIN
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex AND State='O'    ORDER BY s_date DESC
	END
/*
	
*/
RETURN
SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[RANKING_STR]    Script Date: 04/03/2010 12:48:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROC [dbo].[RANKING_STR]
@iGu CHAR(2) = 'R1',
@iserverindex CHAR(2) =  '01'
AS
DECLARE @os_date CHAR(10)
SELECT @os_date = MAX(s_date) FROM RANKING_TBL WHERE Gu = @iGu AND serverindex = @iserverindex

DECLARE @orderby VARCHAR(255)

--R1 : ????
--R2 : ???
--R3 : ???
--R4 : ?????
--R5 : ?????
--R6 : ????
--R7 : ????
--R8 : ?????

SELECT @orderby = CASE @iGu 	 WHEN 'R1' THEN ' ORDER BY m_nWinPoint DESC,m_nWin DESC'
	WHEN 'R2' THEN ' ORDER BY m_nWin DESC,CreateTime'
	WHEN 'R3' THEN ' ORDER BY m_nLose DESC,m_nSurrender DESC'
	WHEN 'R4' THEN ' ORDER BY m_nSurrender DESC,m_nLose DESC'
	WHEN 'R5' THEN ' ORDER BY m_MaximumUnity DESC,CreateTime'
	WHEN 'R6' THEN ' ORDER BY m_nGuildGold DESC,CreateTime'
	WHEN 'R7' THEN ' ORDER BY m_AvgLevel DESC,CreateTime'
	WHEN 'R8' THEN ' ORDER BY m_nPlayTime DESC,CreateTime' END

EXEC
(
	'SELECT TOP 20 [order],Gu,s_date,serverindex,m_dwLogo,m_idGuild,m_szGuild,m_szName,
	m_nWin,m_nLose,m_nSurrender,m_MaximumUnity,m_AvgLevel,
	m_nGuildGold,m_nWinPoint,m_nPlayTime,CreateTime
	FROM RANKING_TBL
	WHERE Gu = ''' + @iGu + '''
	AND serverindex = ''' + @iserverindex + '''
	AND s_date =  ''' + @os_date + '''' + @orderby
)
RETURN
GO

RAISERROR( 'Step 12: GuildBank Log Fix',0,1) WITH NOWAIT
GO


USE [LOGGING_01_DBF]
GO

/****** Object:  StoredProcedure [dbo].[usp_guildbank_log_view]    Script Date: 9/25/2021 10:02:21 PM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE  PROC [dbo].[usp_guildbank_log_view]
@iGu char(2) = 'S1',
@im_idGuild char(6) = '01',
@iserverindex CHAR(2) = ''
AS
SET NOCOUNT ON
IF @iGu = 'S1'
	BEGIN 
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex AND State='A'  ORDER BY s_date DESC
	END 
/*
?? A ?? D ??? I ??? O
*/
ELSE
IF @iGu = 'S2'
	BEGIN
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex  AND State='D'   ORDER BY s_date DESC
	END
/*
	
*/
ELSE
IF @iGu = 'S3'
	BEGIN
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex  AND State='I'   ORDER BY s_date DESC
	END
/*
	
*/
ELSE
IF @iGu = 'S4'
	BEGIN
	SELECT TOP 100 m_idPlayer,s_date,m_Item,m_nAbilityOption,Item_count
		   FROM LOGGING_01_DBF.dbo.LOG_GUILD_BANK_TBL 
		 WHERE m_idGuild = @im_idGuild  AND serverindex = @iserverindex AND State='O'    ORDER BY s_date DESC
	END
/*
	
*/
RETURN
SET NOCOUNT OFF
GO

RAISERROR( 'Step 13: Deleting Ranking',0,1) WITH NOWAIT
GO

DROP DATABASE RANKING_DBF
GO

RAISERROR( 'Step 14: CheckChar Fixes',0,1) WITH NOWAIT
GO

USE [CHARACTER_01_DBF]
GO
/****** Object:  StoredProcedure [dbo].[CHECK_CHARS]    Script Date: 9/10/2017 11:17:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CHECK_CHARS] 
	@account VARCHAR(32) = '',
	@playerslot int = 0
AS
SET NOCOUNT ON
  SELECT * FROM CHARACTER_TBL WHERE account=@account AND playerslot = @playerslot AND isblock ='F'
SET NOCOUNT OFF

GO

RAISERROR( 'Step 15: Deadlock Fixes',0,1) WITH NOWAIT
GO

USE [CHARACTER_01_DBF]
GO
CREATE UNIQUE CLUSTERED INDEX [IDX_SKILLINFLUENCE_TBLL_m_idPlayer] ON [dbo].[SKILLINFLUENCE_TBL] 
(
	[m_idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [SKILLINFLUENCE_TBL_ID1] ON [dbo].[SKILLINFLUENCE_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_SECRET_ROOM_TBL_serverindex] ON [dbo].[SECRET_ROOM_TBL] 
(
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_SECRET_ROOM_TBL_m_idGuild] ON [dbo].[SECRET_ROOM_TBL] 
(
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_SECRET_ROOM_TBL_nTimes_chState] ON [dbo].[SECRET_ROOM_TBL] 
(
	[nTimes] ASC,
	[chState] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblAccountList_rid] ON [dbo].[tblAccountList] 
(
	[rid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_TAX_INFO_TBL_serverindex_nTimes] ON [dbo].[TAX_INFO_TBL] 
(
	[serverindex] ASC,
	[nTimes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CLU_TAX_INFO_TBL_nContinent] ON [dbo].[TAX_INFO_TBL] 
(
	[nContinent] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_tblPocketExt_idPlayer] ON [dbo].[tblPocketExt] 
(
	[idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_tblPocketExt_idPlayer_nPocket] ON [dbo].[tblPocketExt] 
(
	[idPlayer] ASC,
	[nPocket] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_tblPocket_idPlayer] ON [dbo].[tblPocket] 
(
	[idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_tblPocket_idPlayer_nPocket] ON [dbo].[tblPocket] 
(
	[idPlayer] ASC,
	[nPocket] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [messenger_idx_1] ON [dbo].[tblMessenger] 
(
	[idPlayer] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [messenger_idx_2] ON [dbo].[tblMessenger] 
(
	[idPlayer] ASC,
	[idFriend] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [IDX_tblMaster_all_m_idPlayer] ON [dbo].[tblMaster_all] 
(
	[serverindex] ASC,
	[m_idPlayer] ASC,
	[sec] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLordSkill]    Script Date: 11/13/2012 23:53:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblLordSkill_nServer] ON [dbo].[tblLordSkill] 
(
	[nServer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLordSkill_nSkill] ON [dbo].[tblLordSkill] 
(
	[nSkill] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblLordEvent_nServer] ON [dbo].[tblLordEvent] 
(
	[nServer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLordEvent_idPlayer] ON [dbo].[tblLordEvent] 
(
	[idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLordEvent_nTick] ON [dbo].[tblLordEvent] 
(
	[nTick] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblLordElection_nServer] ON [dbo].[tblLordElection] 
(
	[nServer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLordElection_idElection] ON [dbo].[tblLordElection] 
(
	[idElection] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblLordCandidates_nServer] ON [dbo].[tblLordCandidates] 
(
	[nServer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLordCandidates_idElection_idPlayer] ON [dbo].[tblLordCandidates] 
(
	[idElection] ASC,
	[idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLordCandidates_idElection_IsLeftOut] ON [dbo].[tblLordCandidates] 
(
	[idElection] ASC,
	[IsLeftOut] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLordCandidates_idPlayer] ON [dbo].[tblLordCandidates] 
(
	[idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblLord_nServer] ON [dbo].[tblLord] 
(
	[nServer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_tblLord_idElection] ON [dbo].[tblLord] 
(
	[idElection] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblHousing_Visit_m_idPlayer] ON [dbo].[tblHousing_Visit] 
(
	[serverindex] ASC,
	[m_idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NCL_UNI_tblHousing_Visit] ON [dbo].[tblHousing_Visit] 
(
	[serverindex] ASC,
	[m_idPlayer] ASC,
	[f_idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblHousing] ON [dbo].[tblHousing] 
(
	[serverindex] ASC,
	[m_idPlayer] ASC,
	[bSetup] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_tblElection_s_week] ON [dbo].[tblElection] 
(
	[s_week] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCouplePlayer_deleted]    Script Date: 11/13/2012 23:53:07 ******/
SET ANSI_NULLS ON
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_MAIL_TBL_byRead] ON [dbo].[MAIL_TBL] 
(
	[byRead] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_MAIL_TBL_tmCreate] ON [dbo].[MAIL_TBL] 
(
	[tmCreate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 85) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [MAIL_TBL_ID1] ON [dbo].[MAIL_TBL] 
(
	[idSender] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [MAIL_TBL_ID2] ON [dbo].[MAIL_TBL] 
(
	[idReceiver] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [IDX_CLU_SECRET_ROOM_MEMBER_TBL_serverindex] ON [dbo].[SECRET_ROOM_MEMBER_TBL] 
(
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NCL_SECRET_ROOM_MEMBER_TBL_nTimes_nContinent_m_idGuild] ON [dbo].[SECRET_ROOM_MEMBER_TBL] 
(
	[nTimes] ASC,
	[nContinent] ASC,
	[m_idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_ITEM_SEND_nNo] ON [dbo].[ITEM_SEND_TBL] 
(
	[m_nNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [ITEM_SEND_ID1] ON [dbo].[ITEM_SEND_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE UNIQUE CLUSTERED INDEX [CHARACTER_ID1] ON [dbo].[CHARACTER_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [CHARACTER_ID2] ON [dbo].[CHARACTER_TBL] 
(
	[account] ASC,
	[m_idPlayer] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [CI_CHARACTER_TBL_szName] ON [dbo].[CHARACTER_TBL] 
(
	[m_szName] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CLU_TAX_DETAIL_TBL_nTaxKind] ON [dbo].[TAX_DETAIL_TBL] 
(
	[nTaxKind] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_CLU_TAX_DETAIL_TBL_nTimes_nContinent] ON [dbo].[TAX_DETAIL_TBL] 
(
	[nTimes] ASC,
	[nContinent] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [COMPANY_ID1] ON [dbo].[COMPANY_TBL] 
(
	[m_idCompany] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [ITEM_REMOVE_ID1] ON [dbo].[ITEM_REMOVE_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [INVENTORY_ID1] ON [dbo].[INVENTORY_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [INVENTORY_EXT_ID1] ON [dbo].[INVENTORY_EXT_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [GUILD_WAR_ID1] ON [dbo].[GUILD_WAR_TBL] 
(
	[m_idWar] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [BANK_EXT_ID1] ON [dbo].[BANK_EXT_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [BILING_ITEM_ID1] ON [dbo].[BILING_ITEM_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [BASE_VALUE_ID1] ON [dbo].[BASE_VALUE_TBL] 
(
	[g_nSex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [BANK_ID1] ON [dbo].[BANK_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [GUILD_MEMBER_ID1] ON [dbo].[GUILD_MEMBER_TBL] 
(
	[m_idPlayer] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [Guild_BATTLE_ID1] ON [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL] 
(
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Guild_BATTLE_ID2] ON [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL] 
(
	[combatID] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Guild_BATTLE_ID3] ON [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL] 
(
	[m_idWorld] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Guild_BATTLE_ID4] ON [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL] 
(
	[m_idGuild_1st] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Guild_BATTLE_ID5] ON [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL] 
(
	[m_idGuild_2nd] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Guild_BATTLE_ID6] ON [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL] 
(
	[State] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Guild_BATTLE_ID7] ON [dbo].[GUILD_COMBAT_1TO1_BATTLE_TBL] 
(
	[Start_Time] DESC,
	[End_Time] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [WANTED_ID1] ON [dbo].[WANTED_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [TASKBAR_ID1] ON [dbo].[TASKBAR_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [TASKBAR_ITEM_ID1] ON [dbo].[TASKBAR_ITEM_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [TAG_ID1] ON [dbo].[TAG_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [tblSkillPoint_ID1] ON [dbo].[tblSkillPoint] 
(
	[serverindex] ASC,
	[PlayerID] ASC,
	[SkillID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [NCI_idGuild] ON [dbo].[tblRemoveItemFromGuildBank] 
(
	[idGuild] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [PARTY_ID1] ON [dbo].[PARTY_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [QUEST_ID1] ON [dbo].[QUEST_TBL] 
(
	[m_idPlayer] ASC,
	[serverindex] ASC,
	[m_wId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [CL_RAINBOWRACE_TBL_nTimes] ON [dbo].[RAINBOWRACE_TBL] 
(
	[nTimes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [NC_RAINBOWRACE_TBL_m_idPlayer] ON [dbo].[RAINBOWRACE_TBL] 
(
	[m_idPlayer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [GUILD_ID1] ON [dbo].[GUILD_TBL] 
(
	[m_idGuild] ASC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [MESSENGER_ID1] ON [dbo].[MESSENGER_TBL] 
(
	[m_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [MESSENGER_ID2] ON [dbo].[MESSENGER_TBL] 
(
	[f_idPlayer] DESC,
	[serverindex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [MESSENGER_ID3] ON [dbo].[MESSENGER_TBL] 
(
	[State] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

RAISERROR( 'Step 16: SQL Install Completed.',0,1) WITH NOWAIT
GO