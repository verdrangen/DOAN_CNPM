GO
CREATE PROC USP_Login
@userName nchar(10), @password nchar(10), @groupID nchar(10)
AS
BEGIN
	SELECT * FROM dbo.ACCOUNT WHERE USER_NAME = @userName AND PASSWORD = @password AND GROUP_ID = @groupID
END
