----------- Temp table create STARTS ----------
If(OBJECT_ID('tempdb..#Temp') Is Not Null)
	Begin
		Drop Table #Temp
	End
	create table #Temp(
		statusBit bit
	)
    INSERT INTO #Temp (statusBit) VALUES (0);
    PRINT 'TEMP TABLE CREATED and 1 row inserted!'

IF(OBJECT_ID('tempdb..#StatusTemp') Is Not Null)
    BEGIN 
		Drop Table #StatusTemp
	End
	create table #StatusTemp(
		TableName nvarchar(100),
        CreationStatus bit ,
        InsertionStatus bit
	)
    PRINT 'TEMP TABLE For Table status is created'

----------- Temp table create ENDS ----------

----------- Schema create STARTS ----------
DECLARE @sql nvarchar(max)
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Gen_Schema')
    BEGIN
        SET @sql = 'CREATE SCHEMA Gen_Schema;'
        EXEC sp_executesql @sql;
        PRINT 'Schema Created successfully!';
        insert into #StatusTemp values ('Gen_Schema',1,1)
    END
    ELSE
        BEGIN
            PRINT 'x-x SCHEMA ALREADY EXISTS!';
            insert into #StatusTemp values ('Gen_Schema',0,0)
        END

GO -- Go will tell the SQL server that it till now it should execute in a seperate batch, then the below one as a seperate batch
----------- Schema create ENDS ----------

----------- Creation of Table STARTS ----------
BEGIN TRY 
    BEGIN TRANSACTION;
    insert into #StatusTemp values ('Players',0,0)

    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Players' AND schema_id = SCHEMA_ID('Gen_Schema'))
        BEGIN
            CREATE TABLE
                Gen_Schema.Players (
                    PlayerId int IDENTITY (1, 1) PRIMARY KEY, -- IDENTITY for auto increment (start, step)
                    PlayerName varchar(100) not null, -- varchar - Only unicode char, Each take 1 byte, max-8000
                    PlayerInGameName nvarchar (100) not null, -- nvarchar -  unicode char & non unicode char(like Japanese kanji, other lang), Each take 2 byte, max-4000
                    LastPlayedOn DateTime NOT NULL,
                    INDEX IX_Players_PlayerId (PlayerId)
                );
                update #StatusTemp set CreationStatus=1 where TableName='Players'
            PRINT 'Players Table created Successfully!'
        END
    ELSE
		BEGIN
			PRINT 'x-x Players Table already exists'
		END
    UPDATE #Temp SET statusBit = 1;
    COMMIT TRANSACTION;

    END TRY 

    BEGIN CATCH 
        PRINT 'x-x Error while creating the table : ' + ERROR_MESSAGE()
		UPDATE #Temp SET statusBit = 0;
        ROLLBACK TRANSACTION;
    END CATCH;
    GO
----------- Creation of Table ENDS ----------

------------Inserting STARTS ---------------
IF EXISTS (SELECT 1 FROM #Temp WHERE statusBit = 1)
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM [Gen_Schema].[Players])
        BEGIN
            Insert Into [Gen_Schema].[Players] 
                values  ('Thiru','G RabiT',GETDATE()),
                        ('Krishna','BeaR',GETDATE()),
                        ('Radha','Sweety',GetDate()),
                        ('Nila','MoonLight',GetDate()),
                        ('Venba','Princess',GetDate())
            PRINT 'Insertion in Players Table is successful'
            update #StatusTemp set InsertionStatus=1 where TableName='Players'

        END
        ELSE 
            PRINT 'x-x Data already exists in Players Table, Hence skipping insertion'
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        PRINT 'x-x Error while inserting in the table : ' + ERROR_MESSAGE()
        ROLLBACK TRANSACTION;
    END CATCH;
END
ELSE
	PRINT 'x-x CANNOT ABLE TO INSERT SINCE PREV STEP FAILS'
GO
---------Inserting ENDS ---------------

-----------Destructing Temp Table STARTS---------------

If(OBJECT_ID('tempdb..#temp') Is Not Null)
	Begin
		Drop Table #Temp
        PRINT 'TEMP TABLE DROPPED!'
	End
    Go
select * from #StatusTemp
If(OBJECT_ID('tempdb..#StatusTemp') Is Not Null)
	Begin
		Drop Table #StatusTemp
        PRINT 'StatusTemp TABLE DROPPED!'
	End
    Go
-----------Destructing Temp Table ENDS-----------------


----------- Dropping-----------------
Declare @DropEverything bit = 0
if(@DropEverything=1)
    BEGIN
        Drop Table [Gen_Schema].[Players]


        Drop Schema [Gen_Schema]
        PRINT 'DROPPED CREATED TABLE & SCHEMA'

    END

----------- Dropping-----------------

