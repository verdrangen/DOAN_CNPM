------------------USER-----------------------
USE DOAN_CNPM
GO  -- DROP PROC USP_UPDATE_USER
CREATE PROC USP_UPDATE_USER
@id_user int,
@user_name nchar(300),
@phonenumber nchar(10),
@dob datetime,
@gender nchar(10),
@email  nchar(30)
AS
BEGIN
UPDATE ACCOUNT_DETAIL
SET
USER_NAME = @user_name,
PHONENUMBER =@phonenumber,
DOB = @dob,
GENDER = @gender,
EMAIL =@email
WHERE ID_USER =@id_user
END