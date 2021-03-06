USE [Library12]
GO
/****** Object:  Table [dbo].[TempDueRecord]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempDueRecord](
	[SN] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[For_Book] [numeric](18, 0) NOT NULL,
	[For_Copy] [numeric](18, 0) NOT NULL,
	[For_Others] [numeric](18, 0) NOT NULL,
	[Previous_Due] [numeric](18, 0) NOT NULL,
	[Total] [numeric](18, 0) NOT NULL,
	[Memo_Number] [int] NOT NULL,
 CONSTRAINT [PK_TempDueRecord] PRIMARY KEY CLUSTERED 
(
	[SN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temp_Sell_Counter]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Sell_Counter](
	[S.N] [int] IDENTITY(1,1) NOT NULL,
	[Book_Name] [nvarchar](max) NOT NULL,
	[Writer_Name] [nvarchar](max) NOT NULL,
	[Edition] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Print] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit_Price] [numeric](18, 0) NOT NULL,
	[Total] [numeric](18, 0) NOT NULL,
	[Pay] [numeric](18, 0) NOT NULL,
	[Due] [numeric](18, 0) NOT NULL,
	[Memo_Number] [int] NOT NULL,
 CONSTRAINT [PK_Temp_Sell_Counter] PRIMARY KEY CLUSTERED 
(
	[S.N] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temp_Order_Hold]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Order_Hold](
	[Serial_No] [nchar](10) NOT NULL,
	[Customer_Name] [nvarchar](max) NOT NULL,
	[Mobile_No] [nvarchar](50) NOT NULL,
	[Book_Name] [nvarchar](max) NOT NULL,
	[Writer_Name] [nvarchar](max) NOT NULL,
	[Edition] [nchar](10) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Print] [nvarchar](50) NOT NULL,
	[Quantity] [nchar](10) NOT NULL,
	[Unit_Price] [nvarchar](max) NOT NULL,
	[Total] [nvarchar](50) NOT NULL,
	[Advance] [nvarchar](50) NOT NULL,
	[Due] [nvarchar](50) NOT NULL,
	[Supply_Date] [nvarchar](50) NOT NULL,
	[S_No] [int] IDENTITY(1,1) NOT NULL,
	[Memo_Number] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temp_Order_Delivery]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Order_Delivery](
	[Serial_No] [nchar](10) NOT NULL,
	[Customer_Name] [nvarchar](max) NOT NULL,
	[Mobile_No] [nvarchar](50) NOT NULL,
	[Book_Name] [nvarchar](max) NOT NULL,
	[Writer_Name] [nvarchar](max) NOT NULL,
	[Edition] [nchar](10) NOT NULL,
	[Print] [nvarchar](50) NOT NULL,
	[Quantity] [nchar](10) NOT NULL,
	[Unit_Price] [nvarchar](max) NOT NULL,
	[Total] [nvarchar](50) NOT NULL,
	[Advance] [nvarchar](50) NOT NULL,
	[Due] [nvarchar](50) NOT NULL,
	[S_No] [int] IDENTITY(1,1) NOT NULL,
	[Paying_Amount] [nvarchar](50) NOT NULL,
	[Memo_Number] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sell_Counter]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sell_Counter](
	[Serial] [int] NOT NULL,
	[Book_Name] [nvarchar](max) NOT NULL,
	[Writer_Name] [nvarchar](max) NOT NULL,
	[Book_Edition] [nvarchar](50) NOT NULL,
	[Book_Type] [nvarchar](50) NOT NULL,
	[Print] [nvarchar](50) NOT NULL,
	[Quantiy] [int] NOT NULL,
	[Unit_Price_Sell] [numeric](18, 0) NOT NULL,
	[Total_Sell_Amount] [numeric](18, 0) NOT NULL,
	[Unit_Price_Buy] [numeric](18, 0) NOT NULL,
	[Buy_Total] [numeric](18, 0) NOT NULL,
	[Collection] [numeric](18, 0) NOT NULL,
	[Due] [numeric](18, 0) NOT NULL,
	[Benifit] [numeric](18, 0) NOT NULL,
	[Loss] [numeric](18, 0) NOT NULL,
	[Sell_Date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Self_Order_Memo_Counter]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Self_Order_Memo_Counter](
	[Memo_No] [int] IDENTITY(1,1) NOT NULL,
	[Printing_Date] [date] NOT NULL,
 CONSTRAINT [PK_S_O_Memo_Counter] PRIMARY KEY CLUSTERED 
(
	[Memo_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Self_Order]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Self_Order](
	[Serial No] [int] IDENTITY(1,1) NOT NULL,
	[Book Name] [nvarchar](max) NOT NULL,
	[Writer Name] [nvarchar](max) NOT NULL,
	[Edition] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Print] [nvarchar](50) NOT NULL,
	[Quanitity] [int] NOT NULL,
	[Order Date] [date] NOT NULL,
	[Memo_Number] [int] NOT NULL,
 CONSTRAINT [PK_Self_Order] PRIMARY KEY CLUSTERED 
(
	[Serial No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Security_12]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Security_12](
	[User_Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Security_12] ([User_Name], [Password]) VALUES (N'A', N'a')
/****** Object:  Table [dbo].[Reduce]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reduce](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[F_Book] [numeric](18, 0) NOT NULL,
	[N_Book] [numeric](18, 0) NOT NULL,
	[F_Copy] [numeric](18, 0) NOT NULL,
	[N_Copy] [numeric](18, 0) NOT NULL,
	[F_Others] [numeric](18, 0) NOT NULL,
	[N_Others] [numeric](18, 0) NOT NULL,
	[Total_Due] [numeric](18, 0) NOT NULL,
	[Reduce_Amount] [numeric](18, 0) NOT NULL,
	[N_Total_Due] [numeric](18, 0) NOT NULL,
	[Reduce_date] [date] NOT NULL,
 CONSTRAINT [PK_Reduce] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photocopy]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photocopy](
	[Serial_No] [int] IDENTITY(1,1) NOT NULL,
	[Machine_1] [int] NOT NULL,
	[Machine_2] [int] NOT NULL,
	[Machine_3] [int] NOT NULL,
	[Machine_4] [int] NOT NULL,
	[Total_Copy] [numeric](18, 2) NOT NULL,
	[Copy_Rate] [numeric](18, 2) NOT NULL,
	[Total_Amount] [numeric](18, 2) NOT NULL,
	[Copy_Date] [date] NOT NULL,
 CONSTRAINT [PK_Photocopy] PRIMARY KEY CLUSTERED 
(
	[Serial_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Order_No] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[Book_Name] [nvarchar](max) NOT NULL,
	[Writer] [nvarchar](max) NOT NULL,
	[Edition] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[B_Print] [nvarchar](50) NOT NULL,
	[Buy_Unit_Price] [numeric](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Unit_Price] [numeric](18, 0) NOT NULL,
	[Total_price] [numeric](18, 0) NOT NULL,
	[Advance] [numeric](18, 0) NOT NULL,
	[Due] [numeric](18, 0) NOT NULL,
	[Order_Date] [date] NOT NULL,
	[Supply_Date] [date] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Order_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Memo_Counter]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Memo_Counter](
	[Memo_No] [int] IDENTITY(1,1) NOT NULL,
	[Printing_Date] [date] NOT NULL,
 CONSTRAINT [PK_Order_Memo_Counter] PRIMARY KEY CLUSTERED 
(
	[Memo_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memo_Counter]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memo_Counter](
	[Memo_No] [int] IDENTITY(1,1) NOT NULL,
	[Printing_Date] [date] NOT NULL,
 CONSTRAINT [PK_Memo_Counter] PRIMARY KEY CLUSTERED 
(
	[Memo_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestmentCost]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestmentCost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Book] [numeric](18, 0) NOT NULL,
	[Paper] [numeric](18, 0) NOT NULL,
	[Ink] [numeric](18, 0) NOT NULL,
	[Equipment] [numeric](18, 0) NOT NULL,
	[Others] [numeric](18, 0) NOT NULL,
	[Investment_Date] [date] NOT NULL,
 CONSTRAINT [PK_InvestmentCost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Income]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[From_Book] [numeric](18, 0) NOT NULL,
	[From_Photocopy] [numeric](18, 0) NOT NULL,
	[From_Others] [numeric](18, 0) NOT NULL,
	[Total_Income] [numeric](18, 0) NOT NULL,
	[Income_Date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holiday_Counter]    Script Date: 03/29/2015 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holiday_Counter](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[Starting Date] [date] NOT NULL,
	[Ending Date] [date] NOT NULL,
	[Total Day's] [int] NOT NULL,
 CONSTRAINT [PK_Holiday_Counter] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FInvestmentCost]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FInvestmentCost](
	[FId] [int] NOT NULL,
	[FBook] [numeric](18, 0) NOT NULL,
	[FPaper] [numeric](18, 0) NOT NULL,
	[FInk] [numeric](18, 0) NOT NULL,
	[FEquipment] [numeric](18, 0) NOT NULL,
	[Fothers] [numeric](18, 0) NOT NULL,
	[FInvestment_Date] [date] NOT NULL,
 CONSTRAINT [PK_FInvestmentCost] PRIMARY KEY CLUSTERED 
(
	[FId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FInvestmentCost] ([FId], [FBook], [FPaper], [FInk], [FEquipment], [Fothers], [FInvestment_Date]) VALUES (1, CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0 AS Numeric(18, 0)), CAST(0x94390B00 AS Date))
/****** Object:  Table [dbo].[DueRecords]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DueRecords](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[F_Book] [numeric](18, 0) NOT NULL,
	[F_Copy] [numeric](18, 0) NOT NULL,
	[F_Others] [nvarchar](50) NOT NULL,
	[Previous_Due] [numeric](18, 0) NOT NULL,
	[Total] [numeric](18, 0) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_DueRecords] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Due_Memo_Counter]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Due_Memo_Counter](
	[Memo_No] [int] IDENTITY(1,1) NOT NULL,
	[Printing_Date] [date] NOT NULL,
 CONSTRAINT [PK_Due_Memo_Counter] PRIMARY KEY CLUSTERED 
(
	[Memo_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Due_Collection]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Due_Collection](
	[SNo] [int] IDENTITY(1,1) NOT NULL,
	[D_Collection] [numeric](18, 0) NOT NULL,
	[Add_Due] [numeric](18, 0) NOT NULL,
	[Pay_Collection] [numeric](18, 0) NOT NULL,
	[Due_Collection_Add_Date] [date] NOT NULL,
 CONSTRAINT [PK_Due_Collection] PRIMARY KEY CLUSTERED 
(
	[SNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery_Report]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Report](
	[Order_NO] [int] NOT NULL,
	[Customer_Name] [nvarchar](max) NOT NULL,
	[Mobile] [numeric](18, 0) NOT NULL,
	[Book_Name] [nvarchar](max) NOT NULL,
	[Writer] [nvarchar](max) NOT NULL,
	[Edition] [nvarchar](50) NOT NULL,
	[Print] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Buy_Unit_Price] [numeric](18, 0) NOT NULL,
	[Unit_Price] [numeric](18, 0) NOT NULL,
	[Advance] [numeric](18, 0) NOT NULL,
	[Due] [numeric](18, 0) NOT NULL,
	[Paying_Amount] [numeric](18, 0) NOT NULL,
	[Final_Due] [numeric](18, 0) NOT NULL,
	[Delivery_Date] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrentReading]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentReading](
	[Id] [int] NOT NULL,
	[Machine_1] [int] NOT NULL,
	[Machine_2] [int] NOT NULL,
	[Machine_3] [int] NOT NULL,
	[Machine_4] [int] NOT NULL,
 CONSTRAINT [PK_CurrentReading] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Current_Self_Order]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Current_Self_Order](
	[Order_No] [int] IDENTITY(1,1) NOT NULL,
	[Book_Name] [nvarchar](max) NOT NULL,
	[Writer] [nvarchar](max) NOT NULL,
	[Edition] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Print] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Order_Date] [date] NOT NULL,
 CONSTRAINT [PK_Current_Self_Order] PRIMARY KEY CLUSTERED 
(
	[Order_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[S.No] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Writer] [nvarchar](max) NOT NULL,
	[Edition] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Book_Print] [nvarchar](50) NOT NULL,
	[Quantiy] [int] NOT NULL,
	[B_Unit_Price] [numeric](18, 0) NOT NULL,
	[Total_Price] [numeric](18, 0) NOT NULL,
	[Purchase_Date] [date] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[S.No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON
INSERT [dbo].[Books] ([S.No], [Name], [Writer], [Edition], [Type], [Book_Print], [Quantiy], [B_Unit_Price], [Total_Price], [Purchase_Date]) VALUES (5, N'Java', N'Balagurusamy', N'3rd', N'Old', N'Photocopy', 155, CAST(120 AS Numeric(18, 0)), CAST(18600 AS Numeric(18, 0)), CAST(0xB8390B00 AS Date))
INSERT [dbo].[Books] ([S.No], [Name], [Writer], [Edition], [Type], [Book_Print], [Quantiy], [B_Unit_Price], [Total_Price], [Purchase_Date]) VALUES (7, N'Microprocessor', N'Raffiquzzaman', N'3rd', N'Old', N'Photocopy', 87, CAST(200 AS Numeric(18, 0)), CAST(17400 AS Numeric(18, 0)), CAST(0xBA390B00 AS Date))
INSERT [dbo].[Books] ([S.No], [Name], [Writer], [Edition], [Type], [Book_Print], [Quantiy], [B_Unit_Price], [Total_Price], [Purchase_Date]) VALUES (8, N'Digital System', N'Tocchi', N'3rd', N'Old', N'News', 127, CAST(120 AS Numeric(18, 0)), CAST(15240 AS Numeric(18, 0)), CAST(0xBE390B00 AS Date))
INSERT [dbo].[Books] ([S.No], [Name], [Writer], [Edition], [Type], [Book_Print], [Quantiy], [B_Unit_Price], [Total_Price], [Purchase_Date]) VALUES (9, N'Digital System', N'Tocchi', N'3rd', N'Old', N'News', 126, CAST(120 AS Numeric(18, 0)), CAST(15000 AS Numeric(18, 0)), CAST(0xBE390B00 AS Date))
INSERT [dbo].[Books] ([S.No], [Name], [Writer], [Edition], [Type], [Book_Print], [Quantiy], [B_Unit_Price], [Total_Price], [Purchase_Date]) VALUES (10, N'Digital System', N'Tocchi', N'3rd', N'Old', N'Photocopy', 127, CAST(120 AS Numeric(18, 0)), CAST(15240 AS Numeric(18, 0)), CAST(0xBE390B00 AS Date))
INSERT [dbo].[Books] ([S.No], [Name], [Writer], [Edition], [Type], [Book_Print], [Quantiy], [B_Unit_Price], [Total_Price], [Purchase_Date]) VALUES (11, N'রসায়ন', N'হাজারী এবং নাগ', N'3rd', N'New', N'Original', 81, CAST(120 AS Numeric(18, 0)), CAST(9720 AS Numeric(18, 0)), CAST(0xC3390B00 AS Date))
SET IDENTITY_INSERT [dbo].[Books] OFF
/****** Object:  Table [dbo].[ALl_Table_Name]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ALl_Table_Name](
	[Serial_No] [int] IDENTITY(1,1) NOT NULL,
	[T_Name] [nvarchar](max) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ALl_Table_Name] ON
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (1, N'Add_Due')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (2, N'Books')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (3, N'CurrentReading')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (4, N'Delivery_Report')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (5, N'Due_Collection')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (6, N'DueRecords')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (7, N'FInvestmentCost')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (8, N'Holiday_Counter')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (9, N'Income')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (10, N'InvestmentCost')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (11, N'Orders')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (12, N'Photocopy')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (13, N'Reduce')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (14, N'Self_Order')
INSERT [dbo].[ALl_Table_Name] ([Serial_No], [T_Name]) VALUES (15, N'sell_Counter')
SET IDENTITY_INSERT [dbo].[ALl_Table_Name] OFF
/****** Object:  Table [dbo].[Add_Due]    Script Date: 03/29/2015 22:32:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Add_Due](
	[Serial_A] [int] IDENTITY(1,1) NOT NULL,
	[Name_A] [nvarchar](max) NOT NULL,
	[Moabile_A] [nvarchar](50) NOT NULL,
	[Book_A] [numeric](18, 0) NOT NULL,
	[Book_N] [numeric](18, 0) NOT NULL,
	[Copy_A] [numeric](18, 0) NOT NULL,
	[Copy_N] [numeric](18, 0) NOT NULL,
	[Others_A] [numeric](18, 0) NOT NULL,
	[Others_N] [numeric](18, 0) NOT NULL,
	[Total_A] [numeric](18, 0) NOT NULL,
	[Added_Amount] [numeric](18, 0) NOT NULL,
	[Total_N] [numeric](18, 0) NOT NULL,
	[Added_Date] [date] NOT NULL,
 CONSTRAINT [PK_Add_Due] PRIMARY KEY CLUSTERED 
(
	[Serial_A] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
