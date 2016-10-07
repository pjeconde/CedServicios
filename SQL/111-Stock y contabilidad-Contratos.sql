insert EsquemaContable values (1, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (2, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (3, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (4, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (5, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (6, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (7, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (8, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (9, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (10, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (11, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (12, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (13, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (15, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (39, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (40, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (41, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (60, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (61, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (63, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (64, 'VentaContrato', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gan-Ventas', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gan-Ventas', Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Pas-Db-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-10.5', 'Pas-Db-I-Iva10.5', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-27', 'Pas-Db-I-Iva27', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-5', 'Pas-Db-I-Iva5', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-2.5', 'Pas-Db-I-Iva2.5', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Pas-Db-I-Otros', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Pas-Db-I-IngBrut', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Pas-Db-I-ImpInt', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Pas-Db-I-ImpMun', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Pas-Db-I-PercINac', -Signo from EsquemaContable where IdNaturalezaComprobante= 'VentaContrato' and Concepto='T'
