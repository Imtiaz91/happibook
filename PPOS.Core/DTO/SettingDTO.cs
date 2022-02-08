using System;
using Happibook.Core.Entity;
using Happibook.Core.Enum;
using Recipe.Core.Base.Abstract;

namespace Happibook.Core.DTO
{
    public class SettingDTO : DTO<Setting, int>
    {
        public string Code { get; set; }

        public string SiteName { get; set; }

        public string Slogan { get; set; }

        public string NTNNumber { get; set; }

        public string OwnerName { get; set; }

        public virtual CurrencyDTO CurrencyDto { get; set; }

        public int? CurrencyId { get; set; }

        public string ContactNumber1 { get; set; }

        public string ContactNumber2 { get; set; }

        public string FaxNumber { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public virtual CountryDTO CountryDto { get; set; }

        public int? CountryId { get; set; }

        public int PostalCode { get; set; }

        public string Address { get; set; }

        public string SiteLogo { get; set; }

        public override void ConvertFromEntity(Setting entity)
        {
            base.ConvertFromEntity(entity);
            this.Code = entity.Code;
            this.SiteName = entity.SiteName;
            this.NTNNumber = entity.NTNNumber;
            //this.RegistrationCountryId = entity.RegistrationCountryId;
            this.CurrencyId = entity.CurrencyId;
            this.ContactNumber1 = entity.ContactNumber1;
            this.ContactNumber2 = entity.ContactNumber2;
            this.FaxNumber = entity.FaxNumber;
            this.Email = entity.Email;
            this.Website = entity.Website;
            this.CountryId = entity.CountryId;
            this.PostalCode = entity.PostalCode;
            this.Address = entity.Address;
            this.SiteLogo = entity.SiteLogo;
        }

        public override Setting ConvertToEntity(Setting entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Code = this.Code;
            entity.SiteLogo = this.SiteLogo;
            entity.SiteName = this.SiteName;
            entity.NTNNumber = this.NTNNumber;
            entity.CurrencyId = (this.CurrencyId != null && this.CurrencyId != 0) ? this.CurrencyId : null;
            entity.ContactNumber1 = this.ContactNumber1;
            entity.ContactNumber2 = this.ContactNumber2;
            entity.FaxNumber = this.FaxNumber;
            entity.Email = this.Email;
            entity.Website = this.Website;
            entity.CountryId = (this.CountryId != null && this.CountryId != 0) ? this.CountryId : null;
            entity.PostalCode = this.PostalCode;
            entity.Address = this.Address;
            entity.SiteLogo = this.SiteLogo;

            return entity;
        }
    }
}