-------------------REVIEW----DELETE
GO  --drop proc USP_DELETE_REVIEW
CREATE PROC USP_DELETE_REVIEW
@id_review int
AS
BEGIN
 delete from REVIEW where ID_REVIEW= @id_review
END