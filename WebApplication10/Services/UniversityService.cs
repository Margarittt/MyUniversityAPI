using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication10.Domain.Models;
using WebApplication10.Domain.Repositories;
using WebApplication10.Domain.Services;
using WebApplication10.Resources;

namespace WebApplication10.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly ICityRepository cityRepository;
        private readonly IUniversityRepository universityRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public UniversityService(IUniversityRepository universityRepository, IUnitOfWork unitOfWork, ICityRepository cityRepository, IMapper mapper)
        {
            this.cityRepository = cityRepository;
            this.universityRepository = universityRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<University>> ListAsync()
        {
            return await universityRepository.ListAsync();
        }

        public async Task<ResponseModel<UniversityResource>> SaveAsync(University university)
        {
            try
            {
                var existingCity = await cityRepository.FindByIdAsync(university.CityId);
                if (existingCity == null)
                    return new ResponseModel<UniversityResource>()
                    {
                        Success = false,
                        Message = "Invalid city."
                    };
                await universityRepository.AddAsync(university);
                await unitOfWork.CompleteAsync();
                var universityResource = mapper.Map<University, UniversityResource>(university);             
                return new ResponseModel<UniversityResource>()
                {
                    Success = true,
                    Data = universityResource,
                    Message = "Successfully added!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UniversityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the country: { ex.Message}"
                };
            }
        }

        public async Task<ResponseModel<UniversityResource>> UpdateAsync(int id, University university)
        {
            var existingUniversity = await universityRepository.FindByIdAsync(id);
            if (existingUniversity == null)
            {
                return new ResponseModel<UniversityResource>()
                {
                    Success = false,
                    Message = "City not found!"
                };
            }

            var existingCity = await cityRepository.FindByIdAsync(university.CityId);
            if (existingCity == null)
                return new ResponseModel<UniversityResource>()
                {
                    Success = false,
                    Message = "Invalid city."
                };

            existingUniversity.Name = university.Name;
            existingUniversity.City = existingCity;
            try
            {
                universityRepository.Update(existingUniversity);
                await unitOfWork.CompleteAsync();
                var universityResource = mapper.Map<University, UniversityResource>(existingUniversity);
                return new ResponseModel<UniversityResource>()
                {
                    Success = true,
                    Data = universityResource,
                    Message = "Succesfully updated!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UniversityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the country: { ex.Message}"
                };
            }
        }
        public async Task<ResponseModel<UniversityResource>> DeleteAsync(int id)
        {
            var existingCity = await cityRepository.FindByIdAsync(id);
            if (existingCity == null)
            {
                return new ResponseModel<UniversityResource>()
                {
                    Success = false,
                    Message = "City not found!"
                };
            }
            try
            {
                cityRepository.Remove(existingCity);
                await unitOfWork.CompleteAsync();
                return new ResponseModel<UniversityResource>()
                {
                    Success = true,
                    Message = "Succesfully removed!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<UniversityResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the country: { ex.Message}"
                };
            }
        }
    }
}
