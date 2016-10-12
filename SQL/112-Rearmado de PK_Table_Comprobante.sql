ALTER TABLE [dbo].[Comprobante]  
DROP CONSTRAINT [PK_Table_Comprobante];   
GO
ALTER TABLE [dbo].[Comprobante]   
ADD CONSTRAINT [PK_Table_Comprobante] PRIMARY KEY CLUSTERED (
	[Cuit] ASC,
	[IdNaturalezaComprobante] ASC,
	[IdTipoComprobante] ASC,
	[NroPuntoVta] ASC,
	[NroComprobante] ASC,
	[IdTipoDoc] ASC,
	[NroDoc] ASC,
	[Idpersona] ASC,
	[DesambiguacionCuitPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
