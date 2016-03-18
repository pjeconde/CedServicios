USE [CedeiraSERVICIOS]
GO

DROP TABLE [dbo].[Ticket]
GO

CREATE TABLE [dbo].[Ticket](
	[Cuit] [varchar](11) NOT NULL,
	[Service] [varchar](50) NOT NULL,
	[UniqueId] [varchar](15) NOT NULL,
	[GenerationTime] [datetime] NOT NULL,
	[ExpirationTime] [datetime] NOT NULL,
	[Sign] [varchar](250) NOT NULL,
	[Token] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_TicketAFIP] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC,
	[Service] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

