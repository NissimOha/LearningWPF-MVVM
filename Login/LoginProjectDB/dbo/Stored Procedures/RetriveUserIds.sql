CREATE PROCEDURE [dbo].[RetriveUserIds]
AS
	SELECT LoginUser.UserId
	FROM LoginUser

RETURN 0