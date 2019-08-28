using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Resources;

namespace WebApplication10.Domain.Services.ResponseResult
{
    public class CountryResponse : ResponseModel<Country>
    {
        public Country Country { get;set; }

        private CountryResponse(bool success, Country country, string message) : base(success, country, message)
        {
            Country = country;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="country">Saved country.</param>
        /// <returns>Response.</returns>
        public CountryResponse(Country country) : this(true, country,string.Empty)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CountryResponse(string message) : this(false, null, message)
        { }
    }
}

