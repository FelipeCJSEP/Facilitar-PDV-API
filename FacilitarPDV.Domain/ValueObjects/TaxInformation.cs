using FacilitarPDV.Domain.Entities.TaxInformations;
using FacilitarPDV.Domain.Enumerators;
using FacilitarPDV.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilitarPDV.Domain.ValueObjects
{
    public class TaxInformation : Entity
    {
        public DateTime LastPriceUpdate { get; private set; }
        public DateTime LastInput { get; private set; }
        public DateTime LastOutput { get; private set; }
        public TaxInformationOrigin Origin { get; private set; }
        public TaxInformationCstIcms CstIcms { get; private set; }
        public TaxInformationCsosn Csosn { get; private set; }
        public TaxInformationCstPisCofins CstPis { get; private set; }
        public TaxInformationCstPisCofins CstCofins { get; private set; }
        public TaxInformationNcm Ncm { get; private set; }
        public TaxInformationCest Cest { get; private set; }
        public TaxInformationCfop Cfop { get; private set; }
        public decimal MunicipalTaxRate { get; private set; }
        public decimal StateTaxRate { get; private set; }
        public decimal NationalTaxRate { get; private set; }
        public decimal InternationalTaxRate { get; private set; }
        public EProductType Type { get; private set; }

        public TaxInformation(DateTime lastPriceUpdate, DateTime lastInput, DateTime lastOutput, TaxInformationOrigin origin, TaxInformationCstIcms cstIcms, TaxInformationCsosn csosn, TaxInformationCstPisCofins cstPis, TaxInformationCstPisCofins cstCofins, TaxInformationNcm ncm, TaxInformationCfop cfop, decimal municipalTaxRate, decimal stateTaxRate, decimal nationalTaxRate, decimal internationalTaxRate, EProductType type)
        {
            LastPriceUpdate = lastPriceUpdate;
            LastInput = lastInput;
            LastOutput = lastOutput;
            Origin = origin;
            CstIcms = cstIcms;
            Csosn = csosn;
            CstPis = cstPis;
            CstCofins = cstCofins;
            Ncm = ncm;
            Cfop = cfop;
            MunicipalTaxRate = municipalTaxRate;
            StateTaxRate = stateTaxRate;
            NationalTaxRate = nationalTaxRate;
            InternationalTaxRate = internationalTaxRate;
            Type = type;
        }

        public TaxInformation(TaxInformationOrigin origin, TaxInformationCstIcms cstIcms, TaxInformationCsosn csosn, TaxInformationCstPisCofins cstPis, TaxInformationCstPisCofins cstCofins, TaxInformationNcm ncm, TaxInformationCest cest, TaxInformationCfop cfop, decimal municipalTaxRate, decimal stateTaxRate, decimal nationalTaxRate, decimal internationalTaxRate)
        {
            Origin = origin;
            CstIcms = cstIcms;
            Csosn = csosn;
            CstPis = cstPis;
            CstCofins = cstCofins;
            Ncm = ncm;
            Cest = cest;
            Cfop = cfop;
            MunicipalTaxRate = municipalTaxRate;
            StateTaxRate = stateTaxRate;
            NationalTaxRate = nationalTaxRate;
            InternationalTaxRate = internationalTaxRate;
        }
    }
}
