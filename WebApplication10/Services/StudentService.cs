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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IFacultyRepository facultyRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public StudentService(IFacultyRepository facultyRepository, IUnitOfWork unitOfWork, IStudentRepository studentRepository, IMapper mapper)
        {
            this.facultyRepository = facultyRepository;
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await studentRepository.ListAsync();
        }

        public async Task<ResponseModel<StudentResource>> SaveAsync(Student student)
        {
            try
            {
                var existingFaculty = await facultyRepository.FindByIdAsync(student.FacultyId);
                if (existingFaculty == null)
                    return new ResponseModel<StudentResource>()
                    {
                        Success = false,
                        Message = "Invalid Faculty."
                    };
                await studentRepository.AddAsync(student);
                await unitOfWork.CompleteAsync();
                var studentResource = mapper.Map<Student, StudentResource>(student);
                return new ResponseModel<StudentResource>()
                {
                    Success = true,
                    Data = studentResource,
                    Message = "Successfully added!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<StudentResource>()
                {
                    Success = false,
                    Message = $"An error occurred when saving the Student: { ex.Message}"
                };
            }
        }

        public async Task<ResponseModel<StudentResource>> UpdateAsync(int id, Student student)
        {
            var existingStudent = await studentRepository.FindByIdAsync(id);
            if (existingStudent == null)
            {
                return new ResponseModel<StudentResource>()
                {
                    Success = false,
                    Message = "Student not found!"
                };
            }

            var existingFaculty = await facultyRepository.FindByIdAsync(student.FacultyId);
            if (existingFaculty == null)
                return new ResponseModel<StudentResource>()
                {
                    Success = false,
                    Message = "Invalid faculty."
                };

            existingStudent.Name = student.Name;
            existingStudent.Faculty = existingFaculty;
            try
            {
                studentRepository.Update(existingStudent);
                await unitOfWork.CompleteAsync();
                var studentResource = mapper.Map<Student, StudentResource>(existingStudent);
                return new ResponseModel<StudentResource>()
                {
                    Success = true,
                    Data = studentResource,
                    Message = "Succesfully updated!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<StudentResource>()
                {
                    Success = false,
                    Message = $"An error occurred when updating the country: { ex.Message}"
                };
            }
        }
        public async Task<ResponseModel<StudentResource>> DeleteAsync(int id)
        {
            var existingStudent = await studentRepository.FindByIdAsync(id);
            if (existingStudent == null)
            {
                return new ResponseModel<StudentResource>()
                {
                    Success = false,
                    Message = "Student not found!"
                };
            }
            try
            {
                studentRepository.Remove(existingStudent);
                await unitOfWork.CompleteAsync();
                return new ResponseModel<StudentResource>()
                {
                    Success = true,
                    Message = "Succesfully removed!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<StudentResource>()
                {
                    Success = false,
                    Message = $"An error occurred when removing the country: { ex.Message}"
                };
            }
        }
    }
}
