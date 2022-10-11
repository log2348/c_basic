USE BOARD
GO

-- DROP TABLE dbo.TB_Board

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

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('����1', '�ۼ���1', Convert(varchar,SYSDATETIME(),20), '�Խñ� ����1')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('����2', '�ۼ���1', Convert(varchar,SYSDATETIME(),20), '�Խñ� ����1')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('����3', '�ۼ���1', Convert(varchar,SYSDATETIME(),20), '�Խñ� ����1')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('����4', '�ۼ���1', Convert(varchar,SYSDATETIME(),20), '�Խñ� ����1')
GO

INSERT INTO dbo.TB_Board (board_Title, Board_Writer, Board_Date, Board_Contents)
	VALUES ('����5', '�ۼ���1', Convert(varchar,SYSDATETIME(),20), '�Խñ� ����1')
GO

CREATE PROC dbo.UP_BOARD_TB_BOARD_R
	@SEQ int

AS
BEGIN 
	SELECT
         	Board_Id AS [��ȣ], 
			Board_Title  AS [����], 
			Board_Writer AS [�ۼ���], 
			Board_Contents  AS [����],
			Board_Date AS [�ۼ���] ,
			Board_Comment_Count AS [��ȸ��]
		FROM dbo.TB_Board
		WHERE
			Board_Id = @SEQ

END
GO

EXEC dbo.UP_BOARD_TB_BOARD_L
GO

CREATE PROC dbo.UP_BOARD_TB_BOARD_U
	@SEQ int,
	@CONTENT varchar(1000)
AS
BEGIN
	UPDATE
		dbo.TB_Board
	SET
		Board_Contents = @CONTENT,
		Board_Date = GETDATE()
	WHERE
		Board_Id = @SEQ
END
GO

EXEC dbo.UP_BOARD_TB_BOARD_U
	@SEQ = 1,
	@CONTENT = '���� ����'
GO
