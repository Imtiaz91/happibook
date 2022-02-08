using System;
using Happibook.Core.Constant;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class CurrencyDTO : DTO<Currency, int>
    {
        public string Name { get; set; }

        public string IsoCode { get; set; }

        public string Symbol { get; set; }

        public double Rate { get; set; }

        public string Fraction { get; set; }

        public double FractionUnit { get; set; }

        public int DecimalPlace { get; set; }

        public int CountryId { get; set; }

        public bool Active { get; set; }

        public override void ConvertFromEntity(Currency entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.IsoCode = entity.IsoCode;
            this.Symbol = entity.Symbol;
            this.Rate = entity.Rate;
            this.Fraction = entity.Fraction;
            this.FractionUnit = entity.FractionUnit;
            this.DecimalPlace = entity.DecimalPlace;
            this.CountryId = entity.CountryId;
            this.Active = entity.Active;           
        }

        public override Currency ConvertToEntity(Currency entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.IsoCode = this.IsoCode;
            entity.Symbol = this.Symbol;
            entity.Rate = this.Rate;
            entity.Fraction = this.Fraction;
            entity.FractionUnit = this.FractionUnit;
            entity.DecimalPlace = this.DecimalPlace;
            entity.CountryId = this.CountryId;
            entity.Active = this.Active;

            return entity;
        }
    }   
}
