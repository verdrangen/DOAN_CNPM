
---------------SUPPORT-----DELETE---------
GO  --drop proc USP_DELETE_SUPPORT
CREATE PROC USP_DELETE_SUPPORT
@id_support int
AS
BEGIN
 delete from SUPPORT where ID_SUPPORT= @id_support
END