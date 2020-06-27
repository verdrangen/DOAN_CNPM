USE DOAN_CNPM
-----------------ACCOUNT-------------------
GO    -- drop PROC USP_UPDATE_ACCOUNT
CREATE PROC USP_UPDATE_ACCOUNT
@user_name nchar(300),
@password  nchar(10),
@group_id nchar (10)
AS
BEGIN
UPDATE ACCOUNT
SET
USER_NAME =@user_name, 
PASSWORD  =@password , 
GROUP_ID  =@group_id  
WHERE USER_NAME = @user_name
END