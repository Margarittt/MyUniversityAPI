using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.Controllers;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;
using WebApplication10.Domain.Services;
using WebApplication10.Resources;

namespace WebApplication10.Services
{
    public class CityService : ICityService
    {
        private readonly ICountryRepository countryRepository;
        private readonly ICityRepository cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public CityService(ICityRepository cityRepository,IUnitOfWork unitOfWork, ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await cityRepository.ListAsync();
        }

        public async Task<ResponseModel<CityResource>> SaveAsync(City city)
        {
            try
            {
                var existingCountry = await countryRepository.FindByIdAsync(city.CountryId);
                if (existingCountry == null)
                    return new ResponseModel<CityResource>()
                    {
                        Success = false,
                        Message= "Invalid country."
                    };
                await cityRepository.AddAsync(city);
                await unitOfWork.CompleteAsync();
                return new ResponseModel<CityResource>()
                {
                    Success = true,
                    Message = "Successfully added!"
                };
            }
            catch(Exception ex)
            {
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the country: { ex.Message}"
                };
            }
        }

        public async Task<ResponseModel<CityResource>> UpdateAsync(int id,City city)
        {
            var existingCity = await cityRepository.FindByIdAsync(id);
            if(existingCity==null)
            {
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = "City not found!"
                };
            }

            var existingCountry = await countryRepository.FindByIdAsync(city.CountryId);
            if (existingCountry == null)
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = "Invalid country."
                };
 
            existingCity.Name = city.Name;
            try
            {
                cityRepository.Update(existingCity);
                await unitOfWork.CompleteAsync();
                return new ResponseModel<CityResource>()
                {
                    Success = true,
                    Message = "Succesfully updated!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the country: { ex.Message}"
                };
            }            
        }
        public async Task<ResponseModel<CityResource>> DeleteAsync(int id)
        {
            var existingCity = await cityRepository.FindByIdAsync(id);
            if (existingCity==null)
            {
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = "City not found!"
                };
            }
            try
            {
                cityRepository.Remove(existingCity);
                await unitOfWork.CompleteAsync();
                return new ResponseModel<CityResource>()
                {
                    Success = true,
                    Message = "Succesfully removed!"
                };
            }
            catch(Exception ex)
            {
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the country: { ex.Message}"
                };
            }
        }
    }
}
