insert EsquemaContable values (1, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (2, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (3, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (4, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (5, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (6, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (7, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (8, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (9, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (10, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (11, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (12, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (13, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (15, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (39, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (40, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (41, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (60, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (61, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (63, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (64, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gan-Ventas', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gs-Compras', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Compra%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gan-Ventas', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gs-Compras', Signo from EsquemaContable where IdNaturalezaComprobante like 'Compra%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Pas-Db-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-10.5', 'Pas-Db-I-Iva10.5', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-27', 'Pas-Db-I-Iva27', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-5', 'Pas-Db-I-Iva5', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-2.5', 'Pas-Db-I-Iva2.5', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Pas-Db-I-Otros', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Pas-Db-I-IngBrut', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Pas-Db-I-ImpInt', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Pas-Db-I-ImpMun', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Pas-Db-I-PercINac', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Act-Cr-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-10.5', 'Act-Cr-I-Iva10.5', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-27', 'Act-Cr-I-Iva27', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-0', 'Act-Cr-I-Iva0', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Act-Cr-I-Otros', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Act-Cr-I-IngBrut', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Act-Cr-I-ImpInt', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Act-Cr-I-ImpMun', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Act-Cr-I-PercepINac', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
