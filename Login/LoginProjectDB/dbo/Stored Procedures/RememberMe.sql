CREATE PROCEDURE [dbo].[RememberMe]
AS
	SELECT RememberMeAccount.UserName,
			RememberMeAccount.Password
	FROM RememberMeAccount
RETURN 0