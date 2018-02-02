CREATE PROCEDURE [dbo].[RetriveAccounts]
AS
	SELECT LoginUser.UserName,
			LoginUser.Password
	FROM   LoginUser
	ORDER BY LoginUser.UserName
RETURN 0