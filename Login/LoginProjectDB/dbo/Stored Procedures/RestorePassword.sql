CREATE PROCEDURE [dbo].[RestorePassword]
AS
	SELECT LoginUser.UserId,
			LoginUser.UserName,
			LoginUser.Password
	FROM LoginUser
RETURN 0