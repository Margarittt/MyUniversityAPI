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
    public class FacultyService : IFacultyService
    {
        private readonly IUniversityRepository universityRepository;
        private readonly IFacultyRepository facultyRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public FacultyService(IUniversityRepository universityRepository, IUnitOfWork unitOfWork, IFacultyRepository facultyRepository, IMapper mapper)
        {
            this.facultyRepository = facultyRepository;
            this.universityRepository = universityRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Faculty>> ListAsync()
        {
            return await facultyRepository.ListAsync();
        }

        public async Task<ResponseModel<FacultyResource>> SaveAsync(Faculty faculty)
        {
            try
            {
                var existingUniversity = await universityRepository.FindByIdAsync(faculty.UniversityId);
                if (existingUniversity == null)
                    return new ResponseModel<FacultyResource>()
                    {
                        Success = false,
                        Message = "Invalid university."
                    };
                await facultyRepository.AddAsync(faculty);
                await unitOfWork.CompleteAsync();
                var facultyResource = mapper.Map<Faculty, FacultyResource>(faculty);
                return new ResponseModel<FacultyResource>()
                {
                    Success = true,
                    Data = facultyResource,
                    Message = "Successfully added!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<FacultyResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the faculty: { ex.Message}"
                };
            }
        }

        public async Task<ResponseModel<FacultyResource>> UpdateAsync(int id, Faculty faculty)
        {
            var existingFaculty = await facultyRepository.FindByIdAsync(id);
            if (existingFaculty == null)
            {
                return new ResponseModel<FacultyResource>()
                {
                    Success = false,
                    Message = "Faculty not found!"
                };
            }

            var existingUniversity = await universityRepository.FindByIdAsync(faculty.UniversityId);
            if (existingUniversity == null)
                return new ResponseModel<FacultyResource>()
                {
                    Success = false,
                    Message = "Invalid university."
                };

            existingFaculty.Name = faculty.Name;
            existingFaculty.University = existingUniversity;
            try
            {
                facultyRepository.Update(existingFaculty);
                await unitOfWork.CompleteAsync();
                var facultyResource = mapper.Map<Faculty, FacultyResource>(existingFaculty);
                return new ResponseModel<FacultyResource>()
                {
                    Success = true,
                    Data = facultyResource,
                    Message = "Succesfully updated!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<FacultyResource>()
                {
                    Success = false,
                    Message = $"An error occurred when updating the faculty: { ex.Message}"
                };
            }
        }
        public async Task<ResponseModel<FacultyResource>> DeleteAsync(int id)
        {
            var existingFaculty = await facultyRepository.FindByIdAsync(id);
            if (existingFaculty == null)
            {
                return new ResponseModel<FacultyResource>()
                {
                    Success = false,
                    Message = "Faculty not found!"
                };
            }
            try
            {
                facultyRepository.Remove(existingFaculty);
                await unitOfWork.CompleteAsync();
                return new ResponseModel<FacultyResource>()
                {
                    Success = true,
                    Message = "Succesfully removed!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<FacultyResource>()
                {
                    Success = false,
                    Message = $"An error occurred when removing the faculty: { ex.Message}"
                };
            }
        }
    }
}

