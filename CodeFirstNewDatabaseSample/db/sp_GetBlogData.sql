USE [VendorManagement]
GO
/****** Object:  StoredProcedure [dbo].[UpdateVendorEmailAddress2]    Script Date: 1/27/2020 9:03:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetBlogData]


AS

BEGIN

SELECT [BlogId]
      ,[Name] as [BlogName]
  FROM [CodeFirstNewDatabaseSample.BloggingContext].[dbo].[Blogs]

END
