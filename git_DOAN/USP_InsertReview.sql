------------------REVIEW---INSERT------------------
GO --drop PROC USP_INSERT_REVIEW
CREATE PROC USP_INSERT_REVIEW
@id_book int,
@comment nchar(300),
@rating nchar(100)
AS
BEGIN
insert into REVREVIEW(ID_BOOK,COMMENT,RATING)
values (@id_book,@comment,@rating)
END