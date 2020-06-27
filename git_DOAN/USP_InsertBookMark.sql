------------------BOOKMARK-----insert-------------
GO --drop PROC USP_INSERT_BOOKMARK
CREATE PROC USP_INSERT_BOOKMARK
@id_user int,
@id_book int
AS
BEGIN
insert into BOOKMARK (ID_BOOK,ID_USER)
values (@id_book,@id_user)
END