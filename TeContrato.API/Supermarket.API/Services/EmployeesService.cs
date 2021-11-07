using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communications;

namespace Supermarket.API.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeeRepository _employeesRepository;
        public readonly IUnitOfWork _unitOfWork;


        public EmployeesService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeesRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeesResponse> DeleteAsync(int id)
        {
            var existingTag = await _employeesRepository.FindById(id);

            if (existingTag == null)
                return new EmployeesResponse("City not found");

            try
            {
                _employeesRepository.Remove(existingTag);
                return new EmployeesResponse(existingTag);
            }
            catch (Exception ex)
            {
                return new EmployeesResponse($"An error ocurred while deleting city: {ex.Message}");
            }
        }

        public async Task<EmployeesResponse> GetByIdAsync(int id)
        {
            var existingTag = await _employeesRepository.FindById(id);

            if (existingTag == null)
                return new EmployeesResponse("City not found");
            return new EmployeesResponse(existingTag);
        }
        
        public async Task<EmployeesResponse> SaveAsync(Employees city)
        {
            try
            {
                await _employeesRepository.AddAsync(city);
                await _unitOfWork.CompleteAsync();

                return new EmployeesResponse(city);
            }
            catch (Exception e)
            {
                return new EmployeesResponse($"Ocurrió un Error: {e.Message}");
            }
        }

        public async Task<IEnumerable<Employees>> ListAsync()
        {
            return await _employeesRepository.ListAsync();

        }

        public async Task<EmployeesResponse> UpdateAsync(int id, Employees city)
        {
            var existingCity = await _employeesRepository.FindById(id);

            if (existingCity == null)
                return new EmployeesResponse("City not found");

            existingCity.Nemployee = city.Nemployee;

            try
            {
                _employeesRepository.Update(existingCity);

                return new EmployeesResponse(existingCity);
            }
            catch (Exception ex)
            {
                return new EmployeesResponse($"An error ocurred while updating the city: {ex.Message}");
            }

        }
    }
}