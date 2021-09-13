--esquemas de test
SELECT DISTINCT
    IM.imitm as Cod_interno,
    IM.imlitm as CODPRODUCTO,
    IM.imaitm as codbarra,
    IM.imdsc1 as descripcion,
    (select trim(drdl01)
              from CRPCTL.f0005
             where drsy = '41'
               and drrt = 'S2'
               and trim(drky) = ib.ibsrp2) Marca,
    sum(LI.lipqoh-(LI.lihcom+LI.lipcom))/100  as existencia,
    LI.limcu as SUC_PLANTA,
    CASE
       WHEN IB.IBSTKT ='S' THEN 'ACTIVO'
       WHEN IB.IBSTKT ='O' THEN 'INACTIVO'
       WHEN IB.IBSTKT ='U' THEN 'AGOTAR_STOCK'
       END AS ESTADO,
    CK.CKCPGP as Lista_Precio,
    BP.BPCRCD as Moneda,
    (round((BP.BPUPRC / 10000) * 1.1 ))  AS PRECIO,
    IB.IBSRP6 AS COD_IVA,
    (select trim(drdl01)
              from CRPCTL.f0005
             where drsy = '41'
               and drrt = '06'
               and trim(drky) = trim(IB.IBSRP6)) as iva,
    CASE
       WHEN trim(IB.IBSRP6) ='N05' THEN 5
       WHEN trim(IB.IBSRP6) ='N10' THEN 10
       WHEN trim(IB.IBSRP6) ='EXE' THEN 0
       WHEN trim(IB.IBSRP6) ='R10' THEN 0
       END AS PORCEN_IVA
    from CRPDTA.f41021 LI  , CRPDTA.f4101 IM , CRPDTA.F4102 IB ,CRPDTA.F4106 BP , CRPDTA.F40942 CK
    where IM.imitm=LI.liitm and li.liitm=ib.ibitm and li.limcu=ib.ibmcu and im.imitm=ib.ibitm
    and BP.BPITM = IM.IMITM and BP.BPITM = IB.IBITM and BP.BPITM = li.liitm
    and CK.CKCGID = BP.BPCGID
    and LI.limcu = LPAD('19ASUSTBE',12)
    and CKCPGP='G019007'
    and BP.BPCRCD ='GUA'
    and BPEXDJ >= (100000 + to_char(sysdate , 'YYDDD'))
    and LI.lipqoh >= 0
    --and IB.IBSTKT= \'S\' -- PARA TRAER SOLAMENTE LOS PRODUCTOS CON ESTADOS ACTIVOS - SI SE USA ESTE WHERE NO ES NECESARIO EL CASE WHEN
    group by IM.imitm,IM.imaitm,IM.imdsc1, LI.limcu,IB.IBSTKT,IM.imlitm,BP.BPUPRC,CK.CKCPGP,BPCRCD,IB.ibsrp2,IB.IBSRP6;