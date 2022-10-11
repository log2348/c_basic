USE BOARD
GO

CREATE TABLE dbo.TB_Board
(
    Board_Id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Board_Title varchar(MAX) NOT NULL,
    Board_Comment_Count int DEFAULT 0 NOT NULL,
    Board_Writer varchar(10) NOT NULL,
    Board_Date smalldatetime NOT NULL,
    Board_Read_Count int DEFAULT 0 NOT NULL,
    Board_Contents varchar(MAX) NOT NULL
)
GO

SELECT * FROM dbo.TB_Board

--DROP TABLE dbo.TB_Board

ALTER TABLE dbo.TB_Board
	ADD Board_Comment_Count int DEFAULT 0 NOT NULL
GO

ALTER TABLE dbo.TB_Board
	ADD Board_Read_Count int DEFAULT 0 NOT NULL
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('제목1', '작성자1', Convert(varchar,SYSDATETIME(),20), '게시글 내용1')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date,  Board_Contents)
	VALUES ('제목2', '작성자2', Convert(varchar,SYSDATETIME(),20), '게시글 내용2')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date,  Board_Contents)
	VALUES ('제목3', '작성자3', Convert(varchar,SYSDATETIME(),20), '게시글 내용3')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('제목4', '작성자4', Convert(varchar,SYSDATETIME(),20), '게시글 내용4')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('제목5', '작성자5', Convert(varchar,SYSDATETIME(),20), '게시글 내용5')
GO


CREATE PROC dbo.UP_BOARD_TB_BOARD_C
	@BOARD_TITLE varchar(500), 
	@BOARD_WRITER varchar(100), 
	@BOARD_CONTENT varchar(1000)  
AS
BEGIN
    INSERT INTO  dbo.TB_Board
    (
		Board_Title, 
		Board_Writer, 
		Board_Content, 
		Write_Date
    )
    VALUES
    (
		@BOARD_TITLE ,
		@BOARD_WRITER,
		@BOARD_CONTENT,
		SYSDATETIME()
    )
END
GO