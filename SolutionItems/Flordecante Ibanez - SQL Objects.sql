/*
Run this script to Create Schema for ShoppingCartDb

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [dbo].[User]'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
	DROP TABLE dbo.[User]
END

CREATE TABLE [dbo].[User]
(
[user_id] [int] NOT NULL IDENTITY(1, 1),
[password] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[salt] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[firstname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[lastame] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[email] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[status] [bit] NOT NULL,
[date_added] [datetime] NOT NULL CONSTRAINT [DF_User_date_added] DEFAULT (getdate()),
[date_modified] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_User] on [dbo].[User]'
GO
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED  ([user_id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[CartItem]'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CartItem]') AND type in (N'U'))
BEGIN
	DROP TABLE dbo.[CartItem]
END
CREATE TABLE [dbo].[CartItem]
(
[cart_id] [int] NOT NULL IDENTITY(1, 1),
[customer_id] [int] NOT NULL,
[product_id] [int] NOT NULL,
[quanity] [int] NOT NULL,
[date_added] [datetime] NOT NULL CONSTRAINT [DF_CartItem_date_added] DEFAULT (getdate()),
[date_modified] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_CartItem] on [dbo].[CartItem]'
GO
ALTER TABLE [dbo].[CartItem] ADD CONSTRAINT [PK_CartItem] PRIMARY KEY CLUSTERED  ([cart_id])
GO


IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[Product]'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
	DROP TABLE dbo.[Product]
END
CREATE TABLE [dbo].[Product]
(
[productid] [int] NOT NULL IDENTITY(1, 1),
[productname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[header] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[shortdesc] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[image] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[imagename] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[status] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[unitprice] [decimal] (18, 4) NOT NULL,
[quantity] [int] NOT NULL,
[subtract] [int] NOT NULL,
[sort_order] [int] NOT NULL,
[categoryid] [int] NOT NULL,
[date_added] [datetime] NOT NULL CONSTRAINT [DF_Product_date_added] DEFAULT (getdate()),
[date_modified] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Product] on [dbo].[Product]'
GO
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED  ([productid])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[Order]'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
	DROP TABLE dbo.[Order]
END
CREATE TABLE [dbo].[Order]
(
[order_id] [int] NOT NULL IDENTITY(1, 1),
[customer_id] [int] NOT NULL,
[order_status_id] [int] NOT NULL,
[payment_method_id] [int] NOT NULL,
[payment_method] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[payment_firstname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[payment_lastname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[payment_address_1] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[payment_address_2] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[payment_city] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[payment_postcode] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[payment_country] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[shipping_firstname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[shipping_lastname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[shipping_address_1] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[shipping_address_2] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[shipping_city] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[shipping_postcode] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[shipping_country] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[comment] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[total] [decimal] (18, 4) NULL,
[date_added] [datetime] NOT NULL CONSTRAINT [DF_Order_date_added] DEFAULT (getdate()),
[date_modified] [datetime] NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Order] on [dbo].[Order]'
GO
ALTER TABLE [dbo].[Order] ADD CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED  ([order_id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[Customer]'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
	DROP TABLE dbo.[Customer]
END
CREATE TABLE [dbo].[Customer]
(
[customer_id] [int] NOT NULL IDENTITY(1, 1),
[firstname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[lastname] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[email] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[telephone] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[password] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[salt] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[cart_id] [int] NULL,
[status] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[token] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[date_added] [datetime] NOT NULL CONSTRAINT [DF_Customer_date_added] DEFAULT (getdate())
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Customer] on [dbo].[Customer]'
GO
ALTER TABLE [dbo].[Customer] ADD CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED  ([customer_id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating [dbo].[Payment_Method]'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payment_Method]') AND type in (N'U'))
BEGIN
	DROP TABLE dbo.[Payment_Method]
END
CREATE TABLE [dbo].[Payment_Method]
(
[payment_method_id] [int] NOT NULL IDENTITY(1, 1),
[name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Payment_Method] on [dbo].[Payment_Method]'
GO
ALTER TABLE [dbo].[Payment_Method] ADD CONSTRAINT [PK_Payment_Method] PRIMARY KEY CLUSTERED  ([payment_method_id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO

PRINT N'Creating [dbo].[Order_Status]'
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order_Status]') AND type in (N'U'))
BEGIN
	DROP TABLE dbo.[Order_Status]
END
CREATE TABLE [dbo].[Order_Status]
(
[order_status_id] [int] NOT NULL IDENTITY(1, 1),
[name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Creating primary key [PK_Order_Status] on [dbo].[Order_Status]'
GO
ALTER TABLE [dbo].[Order_Status] ADD CONSTRAINT [PK_Order_Status] PRIMARY KEY CLUSTERED  ([order_status_id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
PRINT N'Adding foreign keys to [dbo].[CartItem]'
GO
ALTER TABLE [dbo].[CartItem] ADD CONSTRAINT [FK_CartItem_Product] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([productid])
ALTER TABLE [dbo].[CartItem] ADD CONSTRAINT [FK_CartItem_Customer] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([customer_id])
GO
IF @@ERROR<>0 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT=0 BEGIN INSERT INTO #tmpErrors (Error) SELECT 1 BEGIN TRANSACTION END
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO

/*
Run this script to Populate Data for ShoppingCartDb

*/
		
GO
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS, NOCOUNT ON
GO
SET DATEFORMAT YMD
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
-- Pointer used for text / image updates. This might not be needed, but is declared here just in case
DECLARE @pv BINARY(16)

PRINT ( N'Drop constraints from [dbo].[CartItem]' )
GO
ALTER TABLE [dbo].[CartItem] DROP CONSTRAINT [FK_CartItem_Customer]
ALTER TABLE [dbo].[CartItem] DROP CONSTRAINT [FK_CartItem_Product]

PRINT ( N'Add 1 row to [dbo].[Customer]' )
GO
SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT  INTO [dbo].[Customer]
        ( [customer_id] ,
          [firstname] ,
          [lastname] ,
          [email] ,
          [telephone] ,
          [password] ,
          [salt] ,
          [cart_id] ,
          [status] ,
          [token] ,
          [date_added]
        )
VALUES  ( 2 ,
          N'Test' ,
          N'LastName' ,
          N'test@gmail.com' ,
          N'231325' ,
          N'vZEyut96lMdjoB/8pspX/g==' ,
          N'E8-B8-76-3D-61-5C-23-B0-91-B2-F3-B3-5B-DB-43-C4-F6-7B-FA-A1-1F-B1-36-BD-E2-8C-BD-83-C9-B7-08-37-FF-C8-51-0A-EB-72-D2-40-C0-7E-92-79-DA-1B-35-A6-E5-D0-66-CA-CC-55-AD-90-4F-C1-8D-CE-C3-03-61-D1-E6-B4-5D-50-1B-8E-2E-4B-97-16-99-C2-8E-DB-9A-A7-B2-8C-C9-12-97-9E-8F-12-AF-E3-2C-42-68-E4-A2-3D-99-3F-30-51-8A-F5-62-50-BA-0F-14-AA-9B-51-BC-0B-05-B4-AA-30-5A-E1-81-5A-44-03-A2-D6-89-EA-AF-8A-E7-5B-FB-32-60-F6-B2-8E-5E-78-5A-C8-3A-C1-A7-F3-12-93-C3-6A-E8-94-09-3B-6A-94-89-FF-EF-69-68-C9-D8-2E-23-9F-07-64-38-47-9A-A5-C8-39-EA-07-1A-3E-F6-79-73-DE-2E-31-63-A9-F2-33-19-98-F1-8E-BF-3F-97-14-8B-95-8A-19-CD-51-69-A2-BA-D8-93-6B-1B-6D-AF-41-E9-AC-8E-0F-31-7A-A7-B0-11-15-9F-C6-49-D3-88-0E-70-FE-D3-3C-B2-03-8E-D9-6A-FE-4C-0A-5F-09-FE-45-CE-A9-11-C0-DF-D1-6F-DC-50-01-84-C1-3C-F4' ,
          NULL ,
          N'Active' ,
          N'324543534543' ,
          '2015-10-27 22:45:11.420'
        )
SET IDENTITY_INSERT [dbo].[Customer] OFF

PRINT ( N'Add 12 rows to [dbo].[Order_Status]' )
GO
SET IDENTITY_INSERT [dbo].[Order_Status] ON
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 1, N'Pending' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 2, N'Processing' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 3, N'Shipped' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 5, N'Complete' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 6, N'Canceled' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 7, N'Denied' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 8, N'Canceled Reversal' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 9, N'Failed' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 10, N'Refunded' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 11, N'Reversed' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 12, N'Chargeback' )
INSERT  INTO [dbo].[Order_Status]
        ( [order_status_id], [name] )
VALUES  ( 13, N'Expired' )
SET IDENTITY_INSERT [dbo].[Order_Status] OFF

PRINT ( N'Add 3 rows to [dbo].[Payment_Method]' )
GO
SET IDENTITY_INSERT [dbo].[Payment_Method] ON
INSERT  INTO [dbo].[Payment_Method]
        ( [payment_method_id], [name] )
VALUES  ( 1, N'Credit Card' )
INSERT  INTO [dbo].[Payment_Method]
        ( [payment_method_id], [name] )
VALUES  ( 2, N'Paypal' )
INSERT  INTO [dbo].[Payment_Method]
        ( [payment_method_id], [name] )
VALUES  ( 3, N'Bank Transfer' )
SET IDENTITY_INSERT [dbo].[Payment_Method] OFF

PRINT ( N'Add 9 rows to [dbo].[Product]' )
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 1 ,
          N'Admunaquax' ,
          N'AdmunaquaxRapwerantor' ,
          N'estis Id cognitio, quo quad habitatio et fecundio,' ,
          N'Admunaquaxestis Id cognitio, quo quad habitatio et fecundio,' ,
          N'http://lorempixel.com/210/140/' ,
          N'Rapwerantor' ,
          N'Active' ,
          150.0000 ,
          2 ,
          0 ,
          10 ,
          1 ,
          '2015-10-11 01:28:27.560' ,
          NULL
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 2 ,
          N'Tupmunistor' ,
          N'TupmunistorKlidimicator' ,
          N'gravis ut e si Quad quantare et quartu gravum quoq' ,
          N'Tupmunistorgravis ut e si Quad quantare et quartu gravum quoq' ,
          N'http://lorempixel.com/200/140/' ,
          N'Klidimicator' ,
          N'Active' ,
          150.0000 ,
          4 ,
          0 ,
          8 ,
          1 ,
          '2015-10-29 01:15:51.860' ,
          NULL
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 3 ,
          N'Rapdudicator' ,
          N'RapdudicatorThrupebex' ,
          N'Id Sed eudis linguens nomen et sed Versus novum qu' ,
          N'RapdudicatorId Sed eudis linguens nomen et sed Versus novum qu' ,
          N'http://lorempixel.com/190/140/' ,
          N'Thrupebex' ,
          N'Active' ,
          150.0000 ,
          5 ,
          0 ,
          8 ,
          1 ,
          '2015-10-21 04:49:55.290' ,
          NULL
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 4 ,
          N'Suppickeficator' ,
          N'SuppickeficatorKlihupamantor' ,
          N'e nomen brevens, volcans cognitio, travissimantor ' ,
          N'Suppickeficatore nomen brevens, volcans cognitio, travissimantor ' ,
          N'http://lorempixel.com/220/140/' ,
          N'Klihupamantor' ,
          N'Active' ,
          150.0000 ,
          2 ,
          0 ,
          7 ,
          1 ,
          '2015-10-05 19:43:16.310' ,
          NULL
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 5 ,
          N'Doperupistor' ,
          N'DoperupistorTrumunanex' ,
          N'novum et nomen novum Longam, parte Et apparens bon' ,
          N'Doperupistornovum et nomen novum Longam, parte Et apparens bon' ,
          N'http://lorempixel.com/210/130/' ,
          N'Trumunanex' ,
          N'Active' ,
          150.0000 ,
          5 ,
          0 ,
          8 ,
          1 ,
          '2015-10-21 11:16:53.280' ,
          NULL
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 6 ,
          N'Requestommin' ,
          N'RequestomminDoptinefor' ,
          N'estis novum delerium. vobis quorum glavans habitat' ,
          N'Requestomminestis novum delerium. vobis quorum glavans habitat' ,
          N'http://lorempixel.com/210/120/' ,
          N'Doptinefor' ,
          N'Active' ,
          150.0000 ,
          4 ,
          0 ,
          3 ,
          1 ,
          '2015-10-09 06:57:18.280' ,
          NULL
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 7 ,
          N'Rejuban' ,
          N'RejubanTupmunaquantor' ,
          N'quad imaginator quartu funem. fecit. et e plorum f' ,
          N'Rejubanquad imaginator quartu funem. fecit. et e plorum f' ,
          N'http://lorempixel.com/210/110/' ,
          N'Tupmunaquantor' ,
          N'Active' ,
          150.0000 ,
          5 ,
          0 ,
          4 ,
          1 ,
          '2015-10-24 10:21:36.600' ,
          '2015-10-27 01:56:55.247'
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 8 ,
          N'Monkilin' ,
          N'MonkilinMonpebower' ,
          N'Et cognitio, habitatio non transit. eggredior. par' ,
          N'MonkilinEt cognitio, habitatio non transit. eggredior. par' ,
          N'http://lorempixel.com/210/100/' ,
          N'Monpebower' ,
          N'Active' ,
          150.0000 ,
          3 ,
          0 ,
          5 ,
          1 ,
          '2015-10-18 15:30:59.820' ,
          NULL
        )
INSERT  INTO [dbo].[Product]
        ( [productid] ,
          [productname] ,
          [header] ,
          [shortdesc] ,
          [description] ,
          [image] ,
          [imagename] ,
          [status] ,
          [unitprice] ,
          [quantity] ,
          [subtract] ,
          [sort_order] ,
          [categoryid] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 9 ,
          N'Rejubedgower' ,
          N'RejubedgowerThrutanefin' ,
          N'non plorum cognitio, quantare quoque transit. et i' ,
          N'Rejubedgowernon plorum cognitio, quantare quoque transit. et i' ,
          N'http://lorempixel.com/210/150/' ,
          N'Thrutanefin' ,
          N'Active' ,
          150.0000 ,
          3 ,
          0 ,
          3 ,
          1 ,
          '2015-10-01 11:04:06.760' ,
          NULL
        )
SET IDENTITY_INSERT [dbo].[Product] OFF

PRINT ( N'Add 5 rows to [dbo].[CartItem]' )
GO
SET IDENTITY_INSERT [dbo].[CartItem] ON
INSERT  INTO [dbo].[CartItem]
        ( [cart_id] ,
          [customer_id] ,
          [product_id] ,
          [quanity] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 1 ,
          2 ,
          2 ,
          1 ,
          '2015-10-28 22:59:45.477' ,
          NULL
        )
INSERT  INTO [dbo].[CartItem]
        ( [cart_id] ,
          [customer_id] ,
          [product_id] ,
          [quanity] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 2 ,
          2 ,
          3 ,
          1 ,
          '2015-10-28 23:00:21.287' ,
          '2015-10-28 14:59:14.000'
        )
INSERT  INTO [dbo].[CartItem]
        ( [cart_id] ,
          [customer_id] ,
          [product_id] ,
          [quanity] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 3 ,
          2 ,
          4 ,
          1 ,
          '2015-10-28 23:00:26.373' ,
          '2015-10-28 14:59:14.000'
        )
INSERT  INTO [dbo].[CartItem]
        ( [cart_id] ,
          [customer_id] ,
          [product_id] ,
          [quanity] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 4 ,
          2 ,
          5 ,
          1 ,
          '2015-10-28 23:00:29.503' ,
          '2015-10-28 14:59:14.000'
        )
INSERT  INTO [dbo].[CartItem]
        ( [cart_id] ,
          [customer_id] ,
          [product_id] ,
          [quanity] ,
          [date_added] ,
          [date_modified]
        )
VALUES  ( 5 ,
          2 ,
          6 ,
          1 ,
          '2015-10-28 23:00:32.173' ,
          '2015-10-28 14:59:14.000'
        )
SET IDENTITY_INSERT [dbo].[CartItem] OFF

PRINT ( N'Add constraints to [dbo].[CartItem]' )
GO
ALTER TABLE [dbo].[CartItem] ADD CONSTRAINT [FK_CartItem_Customer] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customer] ([customer_id])
ALTER TABLE [dbo].[CartItem] ADD CONSTRAINT [FK_CartItem_Product] FOREIGN KEY ([product_id]) REFERENCES [dbo].[Product] ([productid])
COMMIT TRANSACTION
GO
