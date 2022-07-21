USE [ACCOUNT_DBF]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[usp_CreateNewAccount]
		@account = N'test',				-- ID: test
		@pw = N'89d1ed22aac58f5bbea53b2fde81a946'	-- PW: test

SELECT	'Return Value' = @return_value

GO

UPDATE account_tbl_detail set m_chLoginAuthority = 'Z'