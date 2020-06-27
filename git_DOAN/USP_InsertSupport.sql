-------------------SUPPORT-----INSERT--------------
GO --drop proc USP_INSERT_SUPPORT
CREATE PROC USP_INSERT_SUPPORT
@id_user int,
@feedback ntext,
@postdate datetime,
@reply ntext
AS
BEGIN
insert into SUPPORT(ID_USER,FEEDBACK,POSTDATE,REPLY)
values (@id_user,@feedback,@postdate,@reply)
END