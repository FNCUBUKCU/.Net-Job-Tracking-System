create table Proje.Messages(
      Id int identity(1,1) primary key NOT NULL,
	  [Sender] varchar(100)  NOT NULL,
	  [Receiver] varchar(100)  NOT NULL,
	  [Message] varchar(MAX)
);

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gönderilen kisi bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'Sender'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gönderilen mesaj bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'Message'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gönderilen mesaj bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'Receiver'
GO

create table Proje.Departments(
      Id int identity(1,1) primary key NOT NULL,
	  [Name] varchar(100)
);

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Activities', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'isim bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Activities', @level2type=N'COLUMN',@level2name=N'Name'
GO

INSERT INTO Departments VALUES (1020,'ANA BANKACILIK UYGULAMA GELÝÞTÝRME MÜDÜRLÜÐÜ');
INSERT INTO Departments VALUES (1021,'BÝLGÝ TEKNOLOJÝLERÝ SÝSTEM DESTEK MÜDÜRLÜÐÜ');
INSERT INTO Departments VALUES (1022,'MÜÞTERÝ, KANAL VE ANALÝTÝK UYGULAMA GELÝÞTÝRME MÜDÜRLÜÐÜ');
INSERT INTO Departments VALUES (1023,'BÝLGÝ TEKNOLOJÝLERÝ STRATEJÝ VE YÖNETÝÞÝM MÜDÜRLÜÐÜ');

create table Proje.Missions(
      Id int identity(1,1) primary key NOT NULL,
	  [Name] varchar(100),
	  IsDirector bit
);

INSERT INTO Missions VALUES ('Yazýlým Mimarý', '0');
INSERT INTO Missions VALUES ('Developer','1');
INSERT INTO Missions VALUES ('Siber güvenlik Uzmaný','0');
INSERT INTO Missions VALUES ('Test Mühendisi','0');
INSERT INTO Missions VALUES ('Arama Motoru Optimizasyon Uzmaný','0');
INSERT INTO Missions VALUES ('Web Tasarýmcý','0');
INSERT INTO Missions VALUES ('Yazýlým Geliþtirici','0');


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Missions', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'isim' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Missions', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'yönetici kontrolü' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Missions', @level2type=N'COLUMN',@level2name=N'IsDirector'
GO


create table Proje.Activities(
      Id int identity(1,1) primary key NOT NULL,
	  [Name] varchar(100)
);

INSERT INTO Activities VALUES ('Tatil');
INSERT INTO Activities VALUES ('Ýzin');
INSERT INTO Activities VALUES ('Toplantý');
INSERT INTO Activities VALUES ('Seminer');


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Activities', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'isim bilgi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Activities', @level2type=N'COLUMN',@level2name=N'Name'
GO


create table Proje.Users (
      Id int identity(1,1) primary key NOT NULL,
	  [Name] varchar(100) NOT NULL,
	  [Lastname] varchar(100) NOT NULL,
	  [Email] varchar(100) NOT NULL,
	  [Password] varchar(20) NOT NULL,
	  [PhoneNumber] varchar(100),
	  [DepartmentId] int NOT NULL foreign key references Proje.Departments(Id),
	  [MissionId] int NOT NULL foreign key references Proje.Missions(Id),
	  [ActivitieId] int NOT NULL foreign key references Proje.Activities(Id),
	  [Status] varchar(1)
);

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'isim bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'soyisim bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Lastname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'mail bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'parola bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'telefon bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'PhoneNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'departman bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DepartmentId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ünvan bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'MissionId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'aktivite bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'ActivitieId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'durum' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Status'
GO

INSERT INTO Proje.Users VALUES (4020,'Ahmet', 'GÜLER', 'ahmetguler@gmail.com', 'aG17845', '05564321212', '1021 ', '2020 ', 1, 'A');
INSERT INTO Proje.Users VALUES (4021,'Ayþe', 'KALYAN', 'aysekalyan@gmail.com', 'Kalyanayse', '05574356212', '1020', '2021', 3, 'A');
INSERT INTO Proje.Users VALUES (4022,'Sevil', 'HATÝPOÐLU','sevilhatipoglu@gmail.com', 'sh19834', '05443217212', '1022', '2024',3, 'P' );
INSERT INTO Proje.Users VALUES (4020,'Hakan', 'BAÞ', 'HAKANBAS@gmail.com', 'basbas28745', '05564321212', '1023', '2024', 2, 'A');
INSERT INTO Proje.Users VALUES (4021,'Emre', 'YILMAZ', 'yýlmazemre@gmail.com', 'yýlem18732', '05238735212', '1022', '2026',1, 'P');
INSERT INTO Proje.Users VALUES (4022,'Tuba', 'ATMACA','atmaca56@gmail.com', 'ca76293t', '05438735452', '1020', '2026'2, 'A');
INSERT INTO Proje.Users VALUES (4020,'Sema', 'TEMÝZ', 'sema1234@gmail.com', 's2879te', '05557498862', '1021', '2023', 2, 'A');
INSERT INTO Proje.Users VALUES (4021,'Arzu', 'YANKI', 'yankýarzu1@gmail.com', 'yanar76294', '05449875582', '1026', '2022',3, 'A');
INSERT INTO Proje.Users VALUES (4022,'Mehmet', 'GÜLOÐLU','mehmetgloglu@gmail.com', '1998mehmet', '05443007711', '1024', '2020', 4, 'P');


create table Proje.Works(
      Id int identity(1,1) primary key NOT NULL,
	  [Number] varchar(100) NOT NULL,
	  [Name] varchar(100) NOT NULL,
	  [StartDate] datetime, 
	  [EndDate] datetime,
	  CreatedTime datetime GETDATE,
	  LastUpdateTime datetime GETDATE,
	  UpdateExplanation varchar(4000) NULL,
      [Status] varchar(1)
);

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'numara bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Number'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'isim bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'baþlangýç tarihi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'StartDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'bitiþ tarihi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'EndDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'oluþturulan zaman bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'CreatedTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'son güncelleme bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'açýklama güncelle' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'UpdateExplanation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'durum' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'Works', @level2type=N'COLUMN',@level2name=N'Status'
GO

INSERT INTO Proje.Works VALUES (4020, 1, 'Bankamatik hesap kontrolü', '20.01.2018', '04.02.2018', 'A');
INSERT INTO Proje.Works VALUES (4021, 2, 'Mobil bankacýlýk için düzenleme', '01.07.2018', '17.08.2018', 'A');
INSERT INTO Proje.Works VALUES (4022, 3, 'Atm sistem kontrolü', '25.10.2018', '26.12.2018', 'P');
INSERT INTO Proje.Works VALUES (4020, 4, 'Onay mekanizmasý yazýlým geliþtirme', '12.04.2018', '30.08.2018', 'A');
INSERT INTO Proje.Works VALUES (4021, 5, 'Atm arayüz tasarýmý', '20.09.2018', '29.02.2018', 'A');
INSERT INTO Proje.Works VALUES (4022, 6, 'Ýnternet bankacýlýðý yazýlým geliþtirme', '14.11.2018', '29.12.2018', 'P');
INSERT INTO Proje.Works VALUES (4020, 7, 'Talep izleme ekraný default sorgu', '18.01.2018', '18.02.2018', 'P');
INSERT INTO Proje.Works VALUES (4021, 8, 'ERP fiþlerinde düzenleme', '27.05.2018', '24.08.2018', 'A');
INSERT INTO Proje.Works VALUES (4022, 9, 'ERP fatura giderleþtirme eft ödemesi kontrol', '29.07.2018', '27.09.2018', 'A');


create table Proje.UserWorks(
      Id int identity(1,1) primary key NOT NULL,
	  UsersId int NOT NULL foreign key references Proje.Users(Id),
	  WorksId int NOT NULL foreign key references Proje.Works(Id),
	  [StartDate] datetime,
	  [EndDate] datetime,
	  ActualEffort int, 
	  AssignedEffort int,
	  RemainingEfort int,
	  CreatedTime datetime,
	  LastUpdateTime datetime, 
	  UpdateExplanation varchar(4000),
      [Status] varchar(1)
);

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'kullanýcý id bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'UsersId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ýþ id bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'WorksId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'baþlangýç tarihi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'StartDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'bitiþ tarihi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'EndDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'gerçek zaman bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'ActualEffort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'harcanan zaman bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'AssignedEffort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'kalan zaman bilgisi' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'RemainingEfort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'oluþturulan zaman ' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'CreatedTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'son güncellenen zaman' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'LastUpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'açýklama güncelleme' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'UpdateExplanation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'durum' , @level0type=N'SCHEMA',@level0name=N'Proje', @level1type=N'TABLE',@level1name=N'UserWorks', @level2type=N'COLUMN',@level2name=N'Status'
GO


