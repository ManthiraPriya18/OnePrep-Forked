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

    ---- Creation Players Table Starts-----------
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
    ---- Creation Players Table Ends-----------
    
    ---- Creation Friends Table Starts-----------
    insert into #StatusTemp values ('Friends',0,0)

    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Friends' AND schema_id = SCHEMA_ID('Gen_Schema'))
        BEGIN
            CREATE TABLE Gen_Schema.Friends (
                PlayerOneId INT NOT NULL,
                PlayerTwoId INT NOT NULL,
                FriendSince DATETIME NOT NULL,
                PRIMARY KEY (PlayerOneId, PlayerTwoId), -- Composite Primary key
                FOREIGN KEY (PlayerOneId) REFERENCES Gen_Schema.Players(PlayerId),
                FOREIGN KEY (PlayerTwoId) REFERENCES Gen_Schema.Players(PlayerId),
                INDEX IX_Friends_PlayerOneId (PlayerOneId),
                INDEX IX_Friends_PlayerTwoId (PlayerTwoId)
            );
                update #StatusTemp set CreationStatus=1 where TableName='Friends'
            PRINT 'Friends Table created Successfully!'
        END
    ELSE
		BEGIN
			PRINT 'x-x Friends Table already exists'
		END
    ---- Creation Friends Table Ends-----------
    
    ---- Creation Guns Table Starts-----------
    insert into #StatusTemp values ('Guns',0,0)

    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Guns' AND schema_id = SCHEMA_ID('Gen_Schema'))
        BEGIN
            CREATE TABLE Gen_Schema.Guns (
                GunId INT IDENTITY (1, 1) PRIMARY KEY,
                GunName nvarchar(50) NOT NULL,
                GunType nvarchar(20) NOT NULL,
                GunInfo nvarchar(max) null,
                INDEX IX_Guns_GunId (GunId)
            );
                update #StatusTemp set CreationStatus=1 where TableName='Guns'
            PRINT 'Guns Table created Successfully!'
        END
    ELSE
		BEGIN
			PRINT 'x-x Guns Table already exists'
		END

    ---- Creation Guns Table Ends  -----------

    ---- Creation PlayerGunStats Table Starts-----------
        insert into #StatusTemp values ('PlayerGunStats',0,0)

        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PlayerGunStats' AND schema_id = SCHEMA_ID('Gen_Schema'))
            BEGIN
                CREATE TABLE Gen_Schema.PlayerGunStats (
                   PlayerId INT NOT NULL,
                   GunId INT NOT NULL,
                   KillCount INT NOT NULL,
                   DamageCount BigInt NOT NULL,
                   FOREIGN Key (PlayerId) REFERENCES Gen_Schema.Players(PlayerId),
                   Foreign Key (GunId) REFERENCES Gen_Schema.Guns(GunId),
                   INDEX IX_PlayerGuns_PlayerId (PlayerId)
                );
                    update #StatusTemp set CreationStatus=1 where TableName='PlayerGunStats'
                PRINT 'PlayerGunStats Table created Successfully!'
            END
        ELSE
            BEGIN
                PRINT 'x-x PlayerGunStats Table already exists'
            END

        ---- Creation PlayerGunStats Table Ends  -----------


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
        ----------- Insertion on Players Table Starts -------------
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
        ----------- Insertion on Players Table Ends -------------
        
        ----------- Insertion on Friends Table Starts -------------
          IF NOT EXISTS (SELECT 1 FROM [Gen_Schema].[Friends])
        BEGIN
            Insert Into [Gen_Schema].[Friends] 
                values  (1,2,GETDATE()),
                        (1,3,GETDATE()),
                        (1,4,GETDATE()),
                        (2,3,GETDATE()),
                        (2,4,GETDATE()),
                        (2,5,GETDATE()),
                        (3,5,GETDATE()),
                        (4,5,GETDATE())
            PRINT 'Insertion in Friends Table is successful'
            update #StatusTemp set InsertionStatus=1 where TableName='Friends'

        END
        ELSE 
            PRINT 'x-x Data already exists in Friends Table, Hence skipping insertion'
        ----------- Insertion on Friends Table Ends ----------------

        ----------- Insertion on Guns Table Starts -------------
        IF NOT EXISTS (SELECT 1 FROM [Gen_Schema].[Guns])
        BEGIN
            Insert into  Gen_Schema.Guns
                Values ('M416','AR','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Thumb grip","Laser"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":true,"CanUseCantedSight":true},"Mag":{"Default":30,"Extended":40,"DrumMag":50},"Damage":{"Head":48,"Body":34,"Foot":22},"HoldBySingleHand":false,"Recoil":30,"Bullets":"5.55mm"}'),
                ('AKM','AR','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Thumb grip","Laser"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":true,"CanUseCantedSight":true},"Mag":{"Default":30,"Extended":40,"DrumMag":50},"Damage":{"Head":56,"Body":42,"Foot":26},"HoldBySingleHand":false,"Recoil":40,"Bullets":"7.62mm"}'),
                ('SCARL','AR','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Thumb grip","Laser"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":true,"CanUseCantedSight":true},"Mag":{"Default":30,"Extended":40,"DrumMag":50},"Damage":{"Head":46,"Body":32,"Foot":22},"HoldBySingleHand":false,"Recoil":32,"Bullets":"5.55mm"}'),

                ('UMP','SMG','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Thumb grip"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":false,"CanUseCantedSight":false},"Mag":{"Default":25,"Extended":35},"Damage":{"Head":32,"Body":24,"Foot":18},"HoldBySingleHand":true,"Recoil":16,"Bullets":"0.45mm"}'),
                ('UZI','SMG','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Thumb grip"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":false,"CanUseCantedSight":false},"Mag":{"Default":25,"Extended":35},"Damage":{"Head":34,"Body":26,"Foot":18},"HoldBySingleHand":true,"Recoil":18,"Bullets":"9mm"}'),

                ('S12K','ShotGun','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Thumb grip"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":true,"CanUseCantedSight":false},"Mag":{"Default":5,"Extended":10},"Damage":{"Head":120,"Body":78,"Foot":34},"HoldBySingleHand":true,"Recoil":35,"Bullets":"12Guage"}'),

                ('AWM','Sniper','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X","8X"],"Grip":["Thumb grip","Laser grip","Vertical grip"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":true,"CanUseCantedSight":true},"Mag":{"Default":5,"Extended":10},"Damage":{"Head":140,"Body":88,"Foot":35},"HoldBySingleHand":false,"Recoil":40,"Bullets":".300Magnum"}'),
                ('M24','Sniper','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X","8X"],"Grip":["Laser grip","Vertical grip"],"CanUseSupressor":true,"CanUseCompensator":true,"CanUseStock":true,"CanUseCantedSight":true},"Mag":{"Default":5,"Extended":10},"Damage":{"Head":120,"Body":72,"Foot":26},"HoldBySingleHand":false,"Recoil":35,"Bullets":"7.62mm"}'),

                ('DP28','LMG','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Laser grip","Vertical grip"],"CanUseSupressor":false,"CanUseCompensator":false,"CanUseStock":false,"CanUseCantedSight":true},"Mag":{"Default":33,"Extended":47},"Damage":{"Head":70,"Body":54,"Foot":18},"HoldBySingleHand":false,"Recoil":26,"Bullets":"5.55mm"}'),
                ('M249','LMG','{"Attachements":{"Scope":["Red dot","Holo","2X","3X","6X"],"Grip":["Laser grip","Vertical grip"],"CanUseSupressor":false,"CanUseCompensator":false,"CanUseStock":false,"CanUseCantedSight":true},"Mag":{"Default":75,"Extended":150},"Damage":{"Head":65,"Body":46,"Foot":22},"HoldBySingleHand":false,"Recoil":28,"Bullets":"5.55mm"}')

            PRINT 'Insertion in Guns Table is successful'
            update #StatusTemp set InsertionStatus=1 where TableName='Guns'

        END
        ELSE 
            PRINT 'x-x Data already exists in Guns Table, Hence skipping insertion'

        ----------- Insertion on Guns Table Ends -------------

        ----------- Insertion on PlayerGunStats Table Starts -------------
        IF NOT EXISTS (SELECT 1 FROM [Gen_Schema].[PlayerGunStats])
        BEGIN
            -- Dummy insert script for PlayerGuns table

            INSERT INTO Gen_Schema.PlayerGunStats 
                (PlayerId, GunId, KillCount, DamageCount) VALUES
                (1, 1, 10, 1000),
                (1, 2, 15, 1500),
                (1, 3, 20, 2000),
                (1, 4, 25, 2500),
                (1, 5, 30, 3000),
                (1, 6, 35, 3500),
                (1, 7, 40, 4000),
                (1, 8, 45, 4500),
                (2, 1, 12, 1200),
                (2, 2, 18, 1800),
                (2, 3, 24, 2400),
                (2, 4, 30, 3000),
                (2, 5, 36, 3600),
                (2, 6, 42, 4200),
                (2, 7, 48, 4800),
                (2, 8, 54, 5400),
                (2, 9, 60, 6000),
                (2, 10, 66, 6600),
                (3, 1, 14, 1400),
                (3, 2, 21, 2100),
                (3, 3, 28, 2800),
                (3, 4, 35, 3500),
                (3, 5, 42, 4200),
                (3, 6, 49, 4900),
                (4, 1, 16, 1600),
                (4, 2, 24, 2400),
                (4, 3, 32, 3200),
                (4, 4, 40, 4000),
                (4, 5, 48, 4800),
                (4, 6, 56, 5600),
                (4, 7, 64, 6400),
                (4, 8, 72, 7200),
                (4, 9, 80, 8000),
                (5, 1, 18, 1800),
                (5, 2, 27, 2700),
                (5, 3, 36, 3600),
                (5, 4, 45, 4500),
                (5, 5, 54, 5400),
                (5, 6, 63, 6300),
                (5, 7, 72, 7200),
                (5, 8, 81, 8100),
                (5, 9, 90, 9000),
                (5, 10, 99, 9900)
            PRINT 'Insertion in PlayerGunStats Table is successful'
            update #StatusTemp set InsertionStatus=1 where TableName='PlayerGunStats'

        END
        ELSE 
            PRINT 'x-x Data already exists in PlayerGunStats Table, Hence skipping insertion'

        ----------- Insertion on PlayerGunStats Table Ends -------------

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
        Drop Table [Gen_Schema].[Friends]
        Drop Table [Gen_Schema].[PlayerGunStats]
        Drop Table [Gen_Schema].[Players]
        Drop Table [Gen_Schema].[Guns]


        Drop Schema [Gen_Schema]
        PRINT 'DROPPED CREATED TABLE & SCHEMA'

    END

----------- Dropping-----------------

