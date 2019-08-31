using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;
using WebApplication10.Domain.Services;
using WebApplication10.Resources;

namespace WebApplication10.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await countryRepository.ListAsync();
        }
        public async Task<ResponseModel<CountryResource>> SaveAsync(Country country)
        {
            try
            {
                await countryRepository.AddAsync(country);
                await unitOfWork.CompleteAsync();

                return new ResponseModel<CountryResource>()
                {
                    Success = true,
                    Message = "Successfully added!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<CountryResource>()
                {
                    Success=false,
                    Message=$"An error occurred when saving the country: {ex.Message}"
                };
            }
        }
        public async Task<ResponseModel<CountryResource>> UpdateAsync(int id, Country country)
        {
            var existingCountry = await countryRepository.FindByIdAsync(id);

            if (existingCountry == null)
                return new ResponseModel<CountryResource>()
                {
                    Success = false,
                    Message = "Country not found."
                };

            existingCountry.Name = country.Name;

            try
            {
                countryRepository.Update(existingCountry);
                await unitOfWork.CompleteAsync();

                return new ResponseModel<CountryResource>()
                {
                    Success = true,
                    Message="Successfully updated!!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<CountryResource>()
                {
                    Success = false,
                    Message = $"An error occurred when updating the country: {ex.Message}"
                };
            }
        }
        public async Task<ResponseModel<CountryResource>> DeleteAsync(int id)
        {
            var existingCountry = await countryRepository.FindByIdAsync(id);

            if (existingCountry == null)
                return new ResponseModel<CountryResource>
                {
                    Success = false,
                    Message = "Country not found."
                };

            try
            {
                countryRepository.Remove(existingCountry);
                await unitOfWork.CompleteAsync();

                return new ResponseModel<CountryResource>()
                {
                    Success = true,
                    Message = "Successfully removed!!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<CountryResource>()
                {
                    Success = false,
                    Message=$"An error occurred when removing the country: {ex.Message}",
                };
            }
        }
    }
}
