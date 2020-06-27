----------------BOOKMARK---delete---------
GO  --drop PROC USP_DELETE_BOOKMARK
CREATE PROC USP_DELETE_BOOKMARK
@id_bookmark int
AS
BEGIN
 delete from BOOKMARK where ID_BOOKMARK= @id_bookmark
END