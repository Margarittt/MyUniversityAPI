using AutoMapper;
using System;
using System.Collections.Generic;
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
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public CityService(ICityRepository cityRepository,IUnitOfWork unitOfWork, ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
                var cityResource = mapper.Map<City, CityResource>(city);
                return new ResponseModel<CityResource>()
                {
                    Success = true,
                    Data = cityResource,
                    Message = "Successfully added!"
                };
            }
            catch(Exception ex)
            {
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the city: { ex.Message}"
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
            existingCity.Country = existingCountry;
            try
            {
                cityRepository.Update(existingCity);
                await unitOfWork.CompleteAsync();
                var cityResource = mapper.Map<City, CityResource>(existingCity);
                return new ResponseModel<CityResource>()
                {
                    Success = true,
                    Data = cityResource,
                    Message = "Succesfully updated!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<CityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when updating the city: { ex.Message}"
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
                    Message = $"An error occurred when removing the city: { ex.Message}"
                };
            }
        }
    }
}
